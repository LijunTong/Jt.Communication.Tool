using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Joon.Communication.Tool.Utils;
using Joon.Communication.Tool.Models;
using System.Net;
using System.Net.Sockets;

namespace Joon.Communication.Tool.UI
{
    public partial class FrmTcp : Form
    {
        #region 私有变量

        /// <summary>
        /// tcp客户端选项
        /// </summary>
        private string _tcpClientStr = "TcpClient";

        /// <summary>
        /// tcp服务端选项
        /// </summary>
        private string _tcpServiceStr = "TcpService";

        /// <summary>
        /// 端口类型
        /// </summary>
        private PortType _portType;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string _configIniFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");

        /// <summary>
        /// 配置文件名称
        /// </summary>
        private string _configIniFileName = "ToolConfig.ini";

        /// <summary>
        /// INI文件操作类
        /// </summary>
        private CHelperIni _chelperIni;

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string _configPath;

        /// <summary>
        /// 配置文件类
        /// </summary>
        private ConfigItem _configItem;

        /// <summary>
        /// tcp客户端
        /// </summary>
        private CHelperTcpClient _tcpClientSocket;

        /// <summary>
        /// tcp服务端
        /// </summary>
        private CHelperTcpService _tcpServiceSocket;

        private CHelperSerialPort _serialPost;

        /// <summary>
        /// 定时发送
        /// </summary>
        private System.Timers.Timer _sendTimer;


        #endregion

        #region 构造函数

        public FrmTcp()
        {
            InitializeComponent();

            try
            {
                InitData();

            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
                ErrorLog(ex);
            }
        }

        #endregion

        #region 事件函数

        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickSender = (ToolStripMenuItem)sender;
            foreach (ToolStripItem item in this.portToolStripMenuItem.DropDown.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                    if (menuItem == clickSender)
                    {
                        menuItem.Checked = true;
                    }
                    else
                    {
                        menuItem.Checked = false;
                    }
                }
            }

            foreach (string item in this.cmbCType.Items)
            {
                if (item == clickSender.Text)
                {
                    this.cmbCType.SelectedIndex = this.cmbCType.Items.IndexOf(item);
                    break;
                }
            }
        }

        private void cmbCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ToolStripItem item in this.portToolStripMenuItem.DropDown.Items)
                {
                    if (item is ToolStripMenuItem)
                    {
                        ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                        if (menuItem.Text == this.cmbCType.Text)
                        {
                            menuItem.Checked = true;
                        }
                        else
                        {
                            menuItem.Checked = false;
                        }
                    }
                }
                if (this.cmbCType.Text.ToUpper().StartsWith("COM"))
                {
                    _configItem.SerialPort = this.cmbCType.Text;
                }
                _configItem.SerialType = this.cmbCType.Text;
                CHelperConfig.SetConfig(_configItem, _chelperIni);


                if (this.cmbCType.Text == _tcpClientStr)
                {
                    this.btnConnect.Text = "连接";
                    _portType = PortType.TCP_CLIENT;

                    this.cmbLocalIp.Enabled = false;
                    this.tbLocalPort.Enabled = false;
                    this.tbRemoteIp.Enabled = true;
                    this.tbRemotePort.Enabled = true;

                    this.pnlTcp.Visible = true;
                    this.pnlSerial.Visible = false;
                }
                else if (this.cmbCType.Text == _tcpServiceStr)
                {
                    this.btnConnect.Text = "侦听";
                    _portType = PortType.TCP_SERVICE;

                    this.cmbLocalIp.Enabled = true;
                    this.tbLocalPort.Enabled = true;
                    this.tbRemoteIp.Enabled = false;
                    this.tbRemotePort.Enabled = false;

                    this.pnlTcp.Visible = true;
                    this.pnlSerial.Visible = false;
                }
                else if (this.cmbCType.Text == "斗鱼弹幕")
                {
                    this.btnConnect.Text = "连接";
                    _portType = PortType.DouYu;

                    this.cmbLocalIp.Enabled = false;
                    this.tbLocalPort.Enabled = false;
                    this.tbRemoteIp.Enabled = true;
                    this.tbRemotePort.Enabled = true;

                    this.pnlTcp.Visible = true;
                    this.pnlSerial.Visible = false;
                }
                else
                {
                    this.btnConnect.Text = "连接";
                    _portType = PortType.COM;

                    this.pnlTcp.Visible = false;
                    this.pnlSerial.Visible = true;
                }

                ///释放、关闭资源
                if (_tcpClientSocket != null)
                {
                    _tcpClientSocket.ConnectedEvent -= _clientTcp_Connected;
                    _tcpClientSocket.ReceivedEvent -= _clientTcp_Received;
                    _tcpClientSocket.Disconnect();
                    ShowStateTips("已断开");
                }

                if (_tcpServiceSocket != null)
                {
                    _tcpServiceSocket.ListenEvent -= _tcpServiceSocket_ListenEvent;
                    _tcpServiceSocket.ReceivedEvent -= _tcpServiceSocket_ReceviedEvent;
                    _tcpServiceSocket.ClosedEvent -= _tcpServiceSocket_ClosedEvent;
                    _tcpServiceSocket.StopTcpService();
                    ShowStateTips("已停止服务");
                }

                if (_serialPost != null)
                {
                    _serialPost.ReceivedEvent -= _serialPost_ReceivedEvent;
                    _serialPost.Close();
                }


                if (_sendTimer != null)
                {
                    _sendTimer.Stop();
                    _sendTimer.Elapsed -= _sendTimer_Elapsed;
                    _sendTimer.Dispose();
                }



                this.btnConnect.Enabled = true;
                this.btnClose.Enabled = false;

                ShowStateTips("");
                ShowErrorTips("");

            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
                ErrorLog(ex);
            }
        }

        private void FrmTcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_tcpClientSocket != null)
                {
                    _tcpClientSocket.ConnectedEvent -= _clientTcp_Connected;
                    _tcpClientSocket.ReceivedEvent -= _clientTcp_Received;
                    _tcpClientSocket.Disconnect();

                }

                if (_tcpServiceSocket != null)
                {
                    _tcpServiceSocket.ListenEvent -= _tcpServiceSocket_ListenEvent;
                    _tcpServiceSocket.ReceivedEvent -= _tcpServiceSocket_ReceviedEvent;
                    _tcpServiceSocket.StopTcpService();

                }

                if (_sendTimer != null)
                {
                    _sendTimer.Stop();
                    _sendTimer.Elapsed -= _sendTimer_Elapsed;
                    _sendTimer.Dispose();
                }

                if (_serialPost != null)
                {
                    _serialPost.ReceivedEvent -= _serialPost_ReceivedEvent;
                    _serialPost.Close();
                }


            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
                ErrorLog(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.rtbMsg.Clear();
        }

        private void openSerialSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSerialPortSet frm = new FrmSerialPortSet(_chelperIni);
            frm.ShowDialog();
        }

        private void btnMoreSPSet_Click(object sender, EventArgs e)
        {
            FrmSerialPortSet frm = new FrmSerialPortSet(_chelperIni);
            frm.ShowDialog();
            _configItem = CHelperConfig.GetConfig(_chelperIni);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ShowStateTips("");
            ShowErrorTips("");
            try
            {
                if (_portType == PortType.TCP_CLIENT)
                {
                    //端口类型为 tcp客户端

                    if (string.IsNullOrWhiteSpace(this.tbRemoteIp.Text))
                    {
                        ShowErrorTips("请输入正确的远程IP！");
                        return;
                    }

                    int port = 0;
                    if (!int.TryParse(this.tbRemotePort.Text, out port))
                    {
                        ShowErrorTips("请输入正确的远程端口号！");
                        return;
                    }

                    //更新配置文件
                    _configItem.RemotePort = port;
                    _configItem.RemoteIp = this.tbRemoteIp.Text;
                    CHelperConfig.SetConfig(_configItem, _chelperIni);

                    IPAddress ipa = IPAddress.Parse(_configItem.RemoteIp);
                    //开启TCP服务
                    _tcpClientSocket = new CHelperTcpClient(ipa, _configItem.RemotePort);
                    _tcpClientSocket.ConnectedEvent += _clientTcp_Connected;
                    _tcpClientSocket.ReceivedEvent += _clientTcp_Received;
                    _tcpClientSocket.ClosedEvent += _tcpClientSocket_ClosedEvent;
                    _tcpClientSocket.Connect();


                }
                else if (_portType == PortType.DouYu)
                {
                    //端口类型为 tcp客户端

                    if (string.IsNullOrWhiteSpace(this.tbRemoteIp.Text))
                    {
                        ShowErrorTips("请输入正确的远程IP！");
                        return;
                    }

                    int port = 0;
                    if (!int.TryParse(this.tbRemotePort.Text, out port))
                    {
                        ShowErrorTips("请输入正确的远程端口号！");
                        return;
                    }

                    //更新配置文件
                    _configItem.RemotePort = port;
                    _configItem.RemoteIp = this.tbRemoteIp.Text;
                    CHelperConfig.SetConfig(_configItem, _chelperIni);

                    IPAddress ipa;//= IPAddress.Parse(_configItem.RemoteIp);
                    IPHostEntry host = Dns.GetHostEntry(_configItem.RemoteIp);
                    ipa = host.AddressList[0];
                    //开启TCP服务
                    _tcpClientSocket = new CHelperTcpClient(ipa, _configItem.RemotePort);
                    _tcpClientSocket.ConnectedEvent += _clientTcp_Connected;
                    _tcpClientSocket.ReceivedEvent += _clientTcp_Received;
                    _tcpClientSocket.ClosedEvent += _tcpClientSocket_ClosedEvent;
                    _tcpClientSocket.Connect();
                }
                else if (_portType == PortType.TCP_SERVICE)
                {
                    //端口类型为 tcp服务端

                    if (string.IsNullOrWhiteSpace(this.cmbLocalIp.Text))
                    {
                        ShowErrorTips("请输入正确的远程IP！");
                        return;
                    }

                    int port = 0;
                    if (!int.TryParse(this.tbLocalPort.Text, out port))
                    {
                        ShowErrorTips("请输入正确的本地端口号！");
                        return;
                    }

                    //更新配置文件
                    _configItem.LocalIp = this.cmbLocalIp.Text;
                    _configItem.LocalPort = port;
                    CHelperConfig.SetConfig(_configItem, _chelperIni);

                    _tcpServiceSocket = new CHelperTcpService(_configItem.LocalIp, _configItem.LocalPort);
                    _tcpServiceSocket.ReceivedEvent += _tcpServiceSocket_ReceviedEvent;
                    _tcpServiceSocket.ListenEvent += _tcpServiceSocket_ListenEvent;
                    _tcpServiceSocket.ClosedEvent += _tcpServiceSocket_ClosedEvent;

                    _tcpServiceSocket.StartTcpService();

                    ShowStateTips("正在侦听...");
                }
                else
                {

                }
                this.btnConnect.Enabled = false;
                this.btnClose.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message); 
            }
            finally
            {
                
            }
        }

        void _serialPost_ReceivedEvent()
        {
            string dataString = "";
            byte[] reveData = _serialPost.ReceiveData;

            if (this.cbHexDisplay.Checked)
            {
                dataString = CHelperString.ByteToHexString(reveData);
            }
            else
            {
                dataString = CHelperString.ByteToString(reveData);
            }


            AppendRtbText(dataString, "接收");
        }

        void _tcpServiceSocket_ClosedEvent()
        {
            try
            {
                string state = string.Format("正在侦听|已连接[{0}]", _tcpServiceSocket.GetConnectedSocketList().Count);
                ShowStateTips(state);
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
            }
        }

        void _tcpClientSocket_ClosedEvent()
        {
            ShowStateTips("已断开");
            if (this.InvokeRequired)
            {
                this.Invoke((EventHandler)delegate
                {
                    this.btnConnect.Enabled = true;
                    this.btnClose.Enabled = false;
                });

            }
            else
            {
                this.btnConnect.Enabled = true;
                this.btnClose.Enabled = false;
            }
            
        }

        void _tcpServiceSocket_ListenEvent()
        {
            try
            {
                string state = string.Format("正在侦听|已连接[{0}]", _tcpServiceSocket.GetConnectedSocketList().Count);
                ShowStateTips(state);
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
            }
        }

        void _tcpServiceSocket_ReceviedEvent()
        {
            try
            {
                
                string dataString = "";

                byte[] dataByte = _tcpServiceSocket.Recevied();
                
                if (this.cbHexDisplay.Checked)
                {
                    dataString = CHelperString.ByteToHexString(dataByte);
                }
                else
                {
                    dataString = CHelperString.ByteToString(dataByte);
                }


                AppendRtbText(dataString, "接收");
                
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowStateTips("");
            ShowErrorTips("");
            try
            {
                if (_tcpClientSocket != null)
                {
                    _tcpClientSocket.ConnectedEvent -= _clientTcp_Connected;
                    _tcpClientSocket.ReceivedEvent -= _clientTcp_Received;
                    _tcpClientSocket.Disconnect();
                    _tcpClientSocket.ClosedEvent -= _tcpClientSocket_ClosedEvent;
                    
                    ShowStateTips("已断开");
                }

                if (_tcpServiceSocket != null)
                {
                    _tcpServiceSocket.ListenEvent -= _tcpServiceSocket_ListenEvent;
                    _tcpServiceSocket.ReceivedEvent -= _tcpServiceSocket_ReceviedEvent;
                    _tcpServiceSocket.StopTcpService();
                    ShowStateTips("已停止服务");
                }

                
                this.btnConnect.Enabled = true;
                this.btnClose.Enabled = false;
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
            }
            finally
            {
 
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //SendData();
            int [] set = new int[]{1,2,3};
            Subsets(set);
        }

        void _clientTcp_Received()
        {
            try
            {
                byte[] dataByte = _tcpClientSocket.Recevied();
                string dataString = "";
                if (this.cbHexDisplay.Checked)
                {
                    dataString = CHelperString.ByteToHexString(dataByte);
                }
                else
                {
                    dataString = CHelperString.ByteToString(dataByte);
                }

                AppendRtbText(dataString,"接收");
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
            }
        }

        void _clientTcp_Connected()
        {
            ShowStateTips("已连接");
        }

        private void btnOpenSerialPort_Click(object sender, EventArgs e)
        {
            ShowStateTips("");
            ShowErrorTips("");
            if (this.btnOpenSerialPort.Text == "打开串口")
            {
                

                try
                {
                    _serialPost = new CHelperSerialPort(_configItem.SerialPort, _configItem.BaudRate, _configItem.Parity, _configItem.DataBits, _configItem.StopBits);
                    _serialPost.ReceivedEvent += _serialPost_ReceivedEvent;

                    _serialPost.Open();

                    ShowStateTips(string.Format("串口[{0}]已打开", _configItem.SerialPort));
                    this.btnOpenSerialPort.Text = "关闭串口";
                }
                catch (Exception ex)
                {
                    ShowErrorTips(ex.Message);
                }
            }
            else
            {
                if (_serialPost != null)
                {
                    _serialPost.ReceivedEvent -= _serialPost_ReceivedEvent;
                    _serialPost.Close();
                }
                ShowStateTips(string.Format("串口[{0}]已关闭", _configItem.SerialPort));
                this.btnOpenSerialPort.Text = "打开串口";

            }
        }

        private void cbDisplayTime_CheckedChanged(object sender, EventArgs e)
        {
            _configItem.IsDisplayTime = this.cbDisplayTime.Checked;
            CHelperConfig.SetConfig(_configItem, _chelperIni);
        }

        private void fontSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.rtbMsg.Font;
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font font = this.fontDialog1.Font;
                this.rtbMsg.Font = font;
                FontConverter fc = new FontConverter();
                _configItem.MsgFont = fc.ConvertToString(font);
                CHelperConfig.SetConfig(_configItem, _chelperIni);
            }
        }

        private void bgColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.rtbMsg.BackColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = this.colorDialog1.Color;
                this.rtbMsg.BackColor = color;
                ColorConverter cc = new ColorConverter();
                _configItem.BgColor = cc.ConvertToString(color);
                CHelperConfig.SetConfig(_configItem, _chelperIni);
            }
        }

        private void cbHexDisplay_CheckedChanged(object sender, EventArgs e)
        {
            _configItem.IsHexDisplay = this.cbHexDisplay.Checked;
            CHelperConfig.SetConfig(_configItem, _chelperIni);
        }

        private void cbHexSend_CheckedChanged(object sender, EventArgs e)
        {
            _configItem.IsHexSend = this.cbHexSend.Checked;
            CHelperConfig.SetConfig(_configItem, _chelperIni);
        }

        private void cbTimer_CheckedChanged(object sender, EventArgs e)
        {
            int interval = 0;

            if (!int.TryParse(this.tbInterval.Text, out interval))
            {
                ShowErrorTips(string.Format("间隔时间[{0}]格式不正确！", this.tbInterval.Text));
                this.tbInterval.Text = "";
                this.tbInterval.Focus();
                return;
            }
            if (this.cbTimer.Checked)
            {
                this.tbInterval.ReadOnly = true;
                _sendTimer = new System.Timers.Timer();
                _sendTimer.Interval = interval;
                _sendTimer.Elapsed += _sendTimer_Elapsed;
                _sendTimer.Start();
            }
            else
            {
                if (_sendTimer != null)
                {
                    _sendTimer.Stop();
                    _sendTimer.Elapsed -= _sendTimer_Elapsed;
                    _sendTimer.Dispose();
                }
                this.tbInterval.ReadOnly = false;
            }

            _configItem.IsTimer = this.cbTimer.Checked;
            CHelperConfig.SetConfig(_configItem, _chelperIni);
        }

        void _sendTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SendData();
        }

        private void tbInterval_TextChanged(object sender, EventArgs e)
        {
            int interval = 0;

            if (!int.TryParse(this.tbInterval.Text, out interval))
            {
                ShowErrorTips(string.Format("间隔时间[{0}]格式不正确！", this.tbInterval.Text));
                this.tbInterval.Text = "";
                this.tbInterval.Focus();
                return;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.tbFilePath.Text = dialog.FileName;
            }

        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string filePath = this.tbFilePath.Text;
            if (!File.Exists(filePath))
            {
                ShowErrorTips("文件不存在！");
                return;
            }
        }

        private void cmbBandRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region 调用函数

        /// <summary>
        /// 创建配置文件
        /// </summary>
        private void CreateConfig()
        {
            try
            {
                if (!File.Exists(_configPath))
                {
                    if (!Directory.Exists(_configIniFolder))
                    {
                        Directory.CreateDirectory(_configIniFolder);
                    }
                    File.Create(_configPath);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 初始化工具基本信息
        /// </summary>
        private void InitData()
        {
            try
            {
                //初始化 UI 信息
                this.tsslErrorMsg.Text = "";
                this.tsslConnectState.Text = "";

                //获取配置信息
                
                _configPath = Path.Combine(_configIniFolder, _configIniFileName);
                CreateConfig();
                _chelperIni = new CHelperIni(_configPath);
                _configItem = CHelperConfig.GetConfig(_chelperIni);

                //初始化串口信息
                List<string> ports = new List<string>();
                
                List<string> serialPort = CHelperSerialPort.GetSerialPort();
                ports.Add(_tcpClientStr);
                ports.Add(_tcpServiceStr);
                ports.Add("斗鱼弹幕");
                ports.AddRange(serialPort);

                foreach (string item in ports)
                {
                    ToolStripMenuItem tool = new ToolStripMenuItem();
                    tool.Name = item + "toolSMenuItem";
                    tool.Text = item;
                    tool.Click += tool_Click;
                    this.portToolStripMenuItem.DropDown.Items.Add(tool);
                    //增加分割线
                    if (ports.IndexOf(item) == 1)
                    {
                        this.portToolStripMenuItem.DropDown.Items.Add(new ToolStripSeparator());
                    }
                }

                foreach (string item in ports)
                {
                    this.cmbCType.Items.Add(item);
                }
                CHelperControl.CmbSetSelectedItem(this.cmbCType, _configItem.SerialType);

                //初始化本地IP地址
                List<string> ips = CHelperTcp.GetLocalIpv4();
                foreach (string item in ips)
                {
                    this.cmbLocalIp.Items.Add(item);
                }
                CHelperControl.CmbSetSelectedItem(this.cmbLocalIp, _configItem.LocalIp);
                this.tbLocalPort.Text = _configItem.LocalPort == 0 ? "" : _configItem.LocalPort.ToString();

                //初始化远程IP
                this.tbRemoteIp.Text = _configItem.RemoteIp;
                this.tbRemotePort.Text = _configItem.RemotePort == 0 ? "" : _configItem.RemotePort.ToString();


                
                //初始化波特率
                foreach (int item in CHelperSerialPort.BaudRates)
                {
                    this.cmbBandRate.Items.Add(item.ToString());
                }
                CHelperControl.CmbSetSelectedItem(this.cmbBandRate, _configItem.BaudRate.ToString());

                //其它初始化
                this.cbDisplayTime.Checked = _configItem.IsDisplayTime;
                this.cbHexSend.Checked = _configItem.IsHexSend;
                this.cbHexDisplay.Checked = _configItem.IsHexDisplay;

                string fontStr = _configItem.MsgFont;
                if (!string.IsNullOrWhiteSpace(fontStr))
                {
                    FontConverter fc = new FontConverter();
                    Font font = (Font)fc.ConvertFromString(fontStr);
                    this.rtbMsg.Font = font;
                }

                string colorStr = _configItem.BgColor;
                if (!string.IsNullOrWhiteSpace(colorStr))
                {
                    ColorConverter cc = new ColorConverter();
                    Color color = (Color)cc.ConvertFromString(colorStr);
                    this.rtbMsg.BackColor = color;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        private void AppendRtbText(string text,string type)
        {
            if (this.rtbMsg.InvokeRequired)
            {
                this.rtbMsg.Invoke((EventHandler)delegate
                {
                    if (this.cbDisplayTime.Checked)
                    {
                        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        text = string.Format("[{0}]{1}:{2}\r\n", date, type, text);
                    }
                    this.rtbMsg.AppendText(text);
                    this.rtbMsg.ScrollToCaret();
                });
            }
            else
            {
                if (this.cbDisplayTime.Checked)
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    text = string.Format("[{0}]{1}:{2}\r\n", date, type, text);
                }
                this.rtbMsg.AppendText(text);
                this.rtbMsg.ScrollToCaret();
            }
            
        }

        private void ShowErrorTips(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((EventHandler)delegate
                {
                    this.tsslErrorMsg.Text = text;
                    this.tsslErrorMsg.ForeColor = Color.Red;
                   
                });
            }
            else
            {
                this.tsslErrorMsg.Text = text;
                this.tsslErrorMsg.ForeColor = Color.Red;
            }
        }

        private void ShowStateTips(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((EventHandler)delegate
                {
                    this.tsslConnectState.Text = text;
                    this.tsslConnectState.ForeColor = Color.Blue;
                });
            }
            else
            {
                this.tsslConnectState.Text = text;
                this.tsslConnectState.ForeColor = Color.Blue;
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                CHelperLog.info(text);
            }
        }

        private void ErrorLog(Exception ex)
        {
            CHelperLog.error(ex.ToString());
        }

        private void SendData()
        {
            string msg="";

            if (this.rtbSendMsg.InvokeRequired)
            {
                this.rtbSendMsg.Invoke((EventHandler)delegate
                {
                    msg = this.rtbSendMsg.Text;
                });
            }
            else
            {
                msg = this.rtbSendMsg.Text;
            }
            
            ShowErrorTips("");
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }
            //if (_tcpClientSocket == null && _tcpServiceSocket==null)
            //{
            //    return;
            //}
            try
            {
                if (_portType == PortType.TCP_CLIENT )
                {                    //string msg = this.rtbSendMsg.Text;

                    if (_tcpClientSocket.Connected)
                    {
                        byte[] sendData;
                        if (this.cbHexSend.Checked)
                        {
                            sendData = CHelperString.HexStringToByte(msg);
                        }
                        else
                        {
                            sendData = CHelperString.StringToByte(msg);
                        }
                        _tcpClientSocket.Send(sendData);
                        AppendRtbText(msg, "发送");
                    }
                    else
                    {
                        ShowErrorTips("已断开连接");
                    }
                }
                else if (_portType == PortType.DouYu)
                {
                    byte[] sendData = CHelperString.HexStringToByte(ConvertDouyuSendData(msg));
                    _tcpClientSocket.Send(sendData);
                    AppendRtbText(msg, "发送");
                }
                else if (_portType == PortType.TCP_SERVICE)
                {
                    if (_tcpServiceSocket.GetConnectedSocketList().Count <= 0)
                    {

                        return;
                    }
                    byte[] sendData;
                    if (this.cbHexSend.Checked)
                    {
                        sendData = CHelperString.HexStringToByte(msg);
                        if (!this.cbHexDisplay.Checked)
                        {
                            msg = CHelperString.HexStringToString(msg);
                        }
                    }
                    else
                    {
                        sendData = CHelperString.StringToByte(msg);
                        if (this.cbHexDisplay.Checked)
                        {
                            msg = CHelperString.StringToHexString(msg);
                        }
                    }

                    _tcpServiceSocket.Send(sendData);
                    AppendRtbText(msg, "发送");
                }
            }
            catch (Exception ex)
            {
                ShowErrorTips(ex.Message);
                CHelperLog.error(ex.ToString());
            }
        }

        private string ConvertDouyuSendData(string data)
        {
            ///报文头部+消息体
            ///消息长度（4字节）+消息长度+（4字节）+消息类型（2字节；固定为689）+加密字段0+保留字段 暂时未用，默认为 0 。
            ///+消息体+\0

            int len = data.Length;
            int type = 689;
            string lenHex = CHelperString.IntToHexString(len);
            string typeHex = CHelperString.IntToHexString(type);
            string dataHex = CHelperString.StringToHexString(data);
            if (lenHex.Length == 2)
            {
                lenHex += "000000";
            }
            else
            {
                lenHex = string.Format("0{0}000000", lenHex);
            }
            if (typeHex.Length == 3)
            {
                typeHex += "0";
            }
            string sendData = lenHex + lenHex + typeHex + "00" + "00" + dataHex;
            return sendData;
        }
        #endregion

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {

                List<int> list = new List<int>();
                for (int j = i; j < nums.Length; j++)
                {
                    list.Add(nums[j]);
                    List<int> temp = new List<int>(list);

                    result.Add(temp);
                }

            }
            return result;
        }
        

    }
}
