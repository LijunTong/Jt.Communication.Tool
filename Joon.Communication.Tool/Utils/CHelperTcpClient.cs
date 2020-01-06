using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperTcpClient
    {
        #region 私有变量
        /// <summary>
        /// 客户端
        /// </summary>
        private Socket _clientSocket;

        /// <summary>
        /// ip地址
        /// </summary>
        private IPAddress _ip;

        /// <summary>
        /// 端口号
        /// </summary>
        private int _port;

        /// <summary>
        /// 接收数据线程
        /// </summary>
        private Thread _receiveDataThread;

        /// <summary>
        /// 接收的数据
        /// </summary>
        private byte[] _recevieDataBuffer;

        
        #endregion

        #region 委托、事件

        /// <summary>
        /// 连接成功 委托
        /// </summary>
        public delegate void ConnectedHandle();

        /// <summary>
        /// 连接成功 事件
        /// </summary>
        public event ConnectedHandle ConnectedEvent;

        /// <summary>
        /// 接收数据 委托
        /// </summary>
        /// <returns></returns>
        public delegate void ReceivedHandle();

        /// <summary>
        /// 接收数据 事件
        /// </summary>
        public event ReceivedHandle ReceivedEvent;

        /// <summary>
        /// 连接关闭 事件
        /// </summary>
        public event ReceivedHandle ClosedEvent;

        #endregion

        /// <summary>
        /// 连接状态
        /// </summary>
        public bool Connected
        {
            get
            {
                if (_clientSocket != null)
                {
                    return _clientSocket.Connected;
                }
                else
                {
                    return false;
                }
            }
        }

        public CHelperTcpClient(IPAddress ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }

        /// <summary>
        /// 连接服务
        /// </summary>
        public void Connect()
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(_ip, _port);

                //客户端初始化
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //连接服务端
                _clientSocket.Connect(ipEndPoint);
                if (ConnectedEvent != null)
                {
                    ConnectedEvent();
                }
                _receiveDataThread = new Thread(new ThreadStart(RecevieData));
                _receiveDataThread.Start();
                //_clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(ConnectCallBack), _clientSocket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 断开服务器
        /// </summary>
        public void Disconnect()
        {
            try
            {
                //if (_receiveDataThread != null)
                //{
                //    _receiveDataThread.Abort();
                //}
                if (_clientSocket != null)
                {
                    //_clientSocket
                    if (_clientSocket.Connected)
                    {
                        _clientSocket.Disconnect(false);
                    }
                    _clientSocket.Close();
                    _clientSocket.Dispose();
                }
                if (ClosedEvent != null)
                {
                    ClosedEvent();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConnectCallBack(IAsyncResult iar)
        {
            try
            {
                _clientSocket = (Socket)iar.AsyncState;

                _clientSocket.EndConnect(iar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private void RecevieData()
        {
            while (true && _clientSocket.Connected)
            {
                int len = 0;
                byte[] buffer = new byte[10240];
                if (_clientSocket == null)
                {
                    break;
                }
                if (!_clientSocket.Connected)
                {
                    break;
                }
                if (_clientSocket.Available <= 0)
                {
                    continue;
                }
                len = _clientSocket.Receive(buffer, buffer.Length, 0);
                if (len > 0)
                {
                    _recevieDataBuffer = new byte[len];
                    for (int i = 0; i < len; i++)
                    {
                        _recevieDataBuffer[i] = buffer[i];
                    }
                    if (ReceivedEvent != null)
                    {
                        ReceivedEvent();
                    }
                }
                else
                {
                    Disconnect();
                    break;
                }
                    
                    
                
                
            }
    
        }

        /// <summary>
        /// 获取接收的数据
        /// </summary>
        /// <returns></returns>
        public byte[] Recevied()
        {
            return _recevieDataBuffer;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendData"></param>
        public void Send(byte[] sendData)
        {
            if (_clientSocket == null)
            {
                return;
            }
            if (_clientSocket.Connected == false)
            {
                return;
            }
            try
            {
                _clientSocket.Send(sendData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
