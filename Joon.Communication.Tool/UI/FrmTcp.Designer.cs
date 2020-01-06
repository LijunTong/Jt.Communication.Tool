namespace Joon.Communication.Tool.UI
{
    partial class FrmTcp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTcp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSerialSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlBtmFooter = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslConnectState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslErrorMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlBtmMid = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.cbTimer = new System.Windows.Forms.CheckBox();
            this.cbHexSend = new System.Windows.Forms.CheckBox();
            this.cbHexDisplay = new System.Windows.Forms.CheckBox();
            this.cbDisplayTime = new System.Windows.Forms.CheckBox();
            this.rtbSendMsg = new System.Windows.Forms.RichTextBox();
            this.pnlPort = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlSerial = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMoreSPSet = new System.Windows.Forms.Button();
            this.cmbBandRate = new System.Windows.Forms.ComboBox();
            this.btnOpenSerialPort = new System.Windows.Forms.Button();
            this.pnlTcp = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbLocalIp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRemotePort = new System.Windows.Forms.TextBox();
            this.tbLocalPort = new System.Windows.Forms.TextBox();
            this.tbRemoteIp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBtmTop = new System.Windows.Forms.Panel();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBtmFooter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlBtmMid.SuspendLayout();
            this.pnlPort.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlSerial.SuspendLayout();
            this.pnlTcp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBtmTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.serialPortSettingToolStripMenuItem,
            this.displayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Checked = true;
            this.portToolStripMenuItem.CheckOnClick = true;
            this.portToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.portToolStripMenuItem.Text = "通信端口";
            // 
            // serialPortSettingToolStripMenuItem
            // 
            this.serialPortSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSerialSettingToolStripMenuItem});
            this.serialPortSettingToolStripMenuItem.Name = "serialPortSettingToolStripMenuItem";
            this.serialPortSettingToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.serialPortSettingToolStripMenuItem.Text = "串口设置";
            // 
            // openSerialSettingToolStripMenuItem
            // 
            this.openSerialSettingToolStripMenuItem.Name = "openSerialSettingToolStripMenuItem";
            this.openSerialSettingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openSerialSettingToolStripMenuItem.Text = "打开串口设置";
            this.openSerialSettingToolStripMenuItem.Click += new System.EventHandler(this.openSerialSettingToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontSetToolStripMenuItem,
            this.bgColorToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.displayToolStripMenuItem.Text = "显示";
            // 
            // fontSetToolStripMenuItem
            // 
            this.fontSetToolStripMenuItem.Name = "fontSetToolStripMenuItem";
            this.fontSetToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fontSetToolStripMenuItem.Text = "字体/颜色";
            this.fontSetToolStripMenuItem.Click += new System.EventHandler(this.fontSetToolStripMenuItem_Click);
            // 
            // bgColorToolStripMenuItem
            // 
            this.bgColorToolStripMenuItem.Name = "bgColorToolStripMenuItem";
            this.bgColorToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.bgColorToolStripMenuItem.Text = "背景颜色";
            this.bgColorToolStripMenuItem.Click += new System.EventHandler(this.bgColorToolStripMenuItem_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.pnlBtmFooter);
            this.pnlBottom.Controls.Add(this.pnlBtmMid);
            this.pnlBottom.Controls.Add(this.pnlBtmTop);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 303);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(747, 213);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlBtmFooter
            // 
            this.pnlBtmFooter.Controls.Add(this.statusStrip1);
            this.pnlBtmFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBtmFooter.Location = new System.Drawing.Point(0, 187);
            this.pnlBtmFooter.Name = "pnlBtmFooter";
            this.pnlBtmFooter.Size = new System.Drawing.Size(747, 26);
            this.pnlBtmFooter.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslConnectState,
            this.tsslErrorMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 4);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(747, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslConnectState
            // 
            this.tsslConnectState.Name = "tsslConnectState";
            this.tsslConnectState.Size = new System.Drawing.Size(11, 17);
            this.tsslConnectState.Text = ".";
            // 
            // tsslErrorMsg
            // 
            this.tsslErrorMsg.Name = "tsslErrorMsg";
            this.tsslErrorMsg.Size = new System.Drawing.Size(131, 17);
            this.tsslErrorMsg.Text = "toolStripStatusLabel1";
            // 
            // pnlBtmMid
            // 
            this.pnlBtmMid.Controls.Add(this.label5);
            this.pnlBtmMid.Controls.Add(this.tbInterval);
            this.pnlBtmMid.Controls.Add(this.cbTimer);
            this.pnlBtmMid.Controls.Add(this.cbHexSend);
            this.pnlBtmMid.Controls.Add(this.cbHexDisplay);
            this.pnlBtmMid.Controls.Add(this.cbDisplayTime);
            this.pnlBtmMid.Controls.Add(this.rtbSendMsg);
            this.pnlBtmMid.Controls.Add(this.pnlPort);
            this.pnlBtmMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBtmMid.Location = new System.Drawing.Point(0, 34);
            this.pnlBtmMid.Name = "pnlBtmMid";
            this.pnlBtmMid.Size = new System.Drawing.Size(747, 153);
            this.pnlBtmMid.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(654, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "ms/次";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(607, 24);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(44, 21);
            this.tbInterval.TabIndex = 9;
            this.tbInterval.Text = "2000";
            this.tbInterval.TextChanged += new System.EventHandler(this.tbInterval_TextChanged);
            // 
            // cbTimer
            // 
            this.cbTimer.AutoSize = true;
            this.cbTimer.Location = new System.Drawing.Point(530, 27);
            this.cbTimer.Name = "cbTimer";
            this.cbTimer.Size = new System.Drawing.Size(72, 16);
            this.cbTimer.TabIndex = 8;
            this.cbTimer.Text = "定时发送";
            this.cbTimer.UseVisualStyleBackColor = true;
            this.cbTimer.CheckedChanged += new System.EventHandler(this.cbTimer_CheckedChanged);
            // 
            // cbHexSend
            // 
            this.cbHexSend.AutoSize = true;
            this.cbHexSend.Location = new System.Drawing.Point(458, 27);
            this.cbHexSend.Name = "cbHexSend";
            this.cbHexSend.Size = new System.Drawing.Size(66, 16);
            this.cbHexSend.TabIndex = 7;
            this.cbHexSend.Text = "Hex发送";
            this.cbHexSend.UseVisualStyleBackColor = true;
            this.cbHexSend.CheckedChanged += new System.EventHandler(this.cbHexSend_CheckedChanged);
            // 
            // cbHexDisplay
            // 
            this.cbHexDisplay.AutoSize = true;
            this.cbHexDisplay.Location = new System.Drawing.Point(386, 27);
            this.cbHexDisplay.Name = "cbHexDisplay";
            this.cbHexDisplay.Size = new System.Drawing.Size(66, 16);
            this.cbHexDisplay.TabIndex = 6;
            this.cbHexDisplay.Text = "Hex显示";
            this.cbHexDisplay.UseVisualStyleBackColor = true;
            this.cbHexDisplay.CheckedChanged += new System.EventHandler(this.cbHexDisplay_CheckedChanged);
            // 
            // cbDisplayTime
            // 
            this.cbDisplayTime.AutoSize = true;
            this.cbDisplayTime.Location = new System.Drawing.Point(248, 27);
            this.cbDisplayTime.Name = "cbDisplayTime";
            this.cbDisplayTime.Size = new System.Drawing.Size(132, 16);
            this.cbDisplayTime.TabIndex = 5;
            this.cbDisplayTime.Text = "加时间戳和分包显示";
            this.cbDisplayTime.UseVisualStyleBackColor = true;
            this.cbDisplayTime.CheckedChanged += new System.EventHandler(this.cbDisplayTime_CheckedChanged);
            // 
            // rtbSendMsg
            // 
            this.rtbSendMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbSendMsg.Location = new System.Drawing.Point(241, 47);
            this.rtbSendMsg.Name = "rtbSendMsg";
            this.rtbSendMsg.Size = new System.Drawing.Size(506, 106);
            this.rtbSendMsg.TabIndex = 4;
            this.rtbSendMsg.Text = "";
            // 
            // pnlPort
            // 
            this.pnlPort.Controls.Add(this.panel4);
            this.pnlPort.Controls.Add(this.pnlSerial);
            this.pnlPort.Controls.Add(this.pnlTcp);
            this.pnlPort.Controls.Add(this.panel1);
            this.pnlPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPort.Location = new System.Drawing.Point(0, 0);
            this.pnlPort.Name = "pnlPort";
            this.pnlPort.Size = new System.Drawing.Size(241, 153);
            this.pnlPort.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 119);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 34);
            this.panel4.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(171, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 34);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlSerial
            // 
            this.pnlSerial.Controls.Add(this.label4);
            this.pnlSerial.Controls.Add(this.btnMoreSPSet);
            this.pnlSerial.Controls.Add(this.cmbBandRate);
            this.pnlSerial.Controls.Add(this.btnOpenSerialPort);
            this.pnlSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSerial.Location = new System.Drawing.Point(0, 72);
            this.pnlSerial.Name = "pnlSerial";
            this.pnlSerial.Size = new System.Drawing.Size(241, 47);
            this.pnlSerial.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "波特率:";
            // 
            // btnMoreSPSet
            // 
            this.btnMoreSPSet.Location = new System.Drawing.Point(88, 24);
            this.btnMoreSPSet.Name = "btnMoreSPSet";
            this.btnMoreSPSet.Size = new System.Drawing.Size(153, 23);
            this.btnMoreSPSet.TabIndex = 11;
            this.btnMoreSPSet.Text = "更多串口设置";
            this.btnMoreSPSet.UseVisualStyleBackColor = true;
            this.btnMoreSPSet.Click += new System.EventHandler(this.btnMoreSPSet_Click);
            // 
            // cmbBandRate
            // 
            this.cmbBandRate.FormattingEnabled = true;
            this.cmbBandRate.Location = new System.Drawing.Point(141, 3);
            this.cmbBandRate.Name = "cmbBandRate";
            this.cmbBandRate.Size = new System.Drawing.Size(100, 20);
            this.cmbBandRate.TabIndex = 10;
            this.cmbBandRate.SelectedIndexChanged += new System.EventHandler(this.cmbBandRate_SelectedIndexChanged);
            // 
            // btnOpenSerialPort
            // 
            this.btnOpenSerialPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenSerialPort.Location = new System.Drawing.Point(0, 0);
            this.btnOpenSerialPort.Name = "btnOpenSerialPort";
            this.btnOpenSerialPort.Size = new System.Drawing.Size(80, 47);
            this.btnOpenSerialPort.TabIndex = 9;
            this.btnOpenSerialPort.Text = "打开串口";
            this.btnOpenSerialPort.UseVisualStyleBackColor = true;
            this.btnOpenSerialPort.Click += new System.EventHandler(this.btnOpenSerialPort_Click);
            // 
            // pnlTcp
            // 
            this.pnlTcp.Controls.Add(this.btnConnect);
            this.pnlTcp.Controls.Add(this.btnClose);
            this.pnlTcp.Controls.Add(this.cmbLocalIp);
            this.pnlTcp.Controls.Add(this.label3);
            this.pnlTcp.Controls.Add(this.label2);
            this.pnlTcp.Controls.Add(this.tbRemotePort);
            this.pnlTcp.Controls.Add(this.tbLocalPort);
            this.pnlTcp.Controls.Add(this.tbRemoteIp);
            this.pnlTcp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTcp.Location = new System.Drawing.Point(0, 25);
            this.pnlTcp.Name = "pnlTcp";
            this.pnlTcp.Size = new System.Drawing.Size(241, 47);
            this.pnlTcp.TabIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(199, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(42, 25);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "侦听";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "断开";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbLocalIp
            // 
            this.cmbLocalIp.FormattingEnabled = true;
            this.cmbLocalIp.Location = new System.Drawing.Point(52, 25);
            this.cmbLocalIp.Name = "cmbLocalIp";
            this.cmbLocalIp.Size = new System.Drawing.Size(100, 20);
            this.cmbLocalIp.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "本地:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "远程:";
            // 
            // tbRemotePort
            // 
            this.tbRemotePort.Location = new System.Drawing.Point(154, 3);
            this.tbRemotePort.Name = "tbRemotePort";
            this.tbRemotePort.Size = new System.Drawing.Size(44, 21);
            this.tbRemotePort.TabIndex = 4;
            // 
            // tbLocalPort
            // 
            this.tbLocalPort.Location = new System.Drawing.Point(154, 24);
            this.tbLocalPort.Name = "tbLocalPort";
            this.tbLocalPort.Size = new System.Drawing.Size(44, 21);
            this.tbLocalPort.TabIndex = 7;
            // 
            // tbRemoteIp
            // 
            this.tbRemoteIp.Location = new System.Drawing.Point(52, 3);
            this.tbRemoteIp.Name = "tbRemoteIp";
            this.tbRemoteIp.Size = new System.Drawing.Size(100, 21);
            this.tbRemoteIp.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 25);
            this.panel1.TabIndex = 11;
            // 
            // cmbCType
            // 
            this.cmbCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCType.FormattingEnabled = true;
            this.cmbCType.Location = new System.Drawing.Point(51, 3);
            this.cmbCType.Name = "cmbCType";
            this.cmbCType.Size = new System.Drawing.Size(190, 20);
            this.cmbCType.TabIndex = 0;
            this.cmbCType.SelectedIndexChanged += new System.EventHandler(this.cmbCType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号:";
            // 
            // pnlBtmTop
            // 
            this.pnlBtmTop.Controls.Add(this.btnSendFile);
            this.pnlBtmTop.Controls.Add(this.btnSelect);
            this.pnlBtmTop.Controls.Add(this.tbFilePath);
            this.pnlBtmTop.Controls.Add(this.btnClear);
            this.pnlBtmTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBtmTop.Location = new System.Drawing.Point(0, 0);
            this.pnlBtmTop.Name = "pnlBtmTop";
            this.pnlBtmTop.Size = new System.Drawing.Size(747, 34);
            this.pnlBtmTop.TabIndex = 2;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(322, 6);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(71, 23);
            this.btnSendFile.TabIndex = 6;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(81, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(71, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "选择文件";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(154, 7);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(162, 21);
            this.tbFilePath.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(5, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "清除窗口";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Location = new System.Drawing.Point(0, 25);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(747, 278);
            this.rtbMsg.TabIndex = 3;
            this.rtbMsg.Text = "";
            // 
            // FrmTcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 516);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTcp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通信工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTcp_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBtmFooter.ResumeLayout(false);
            this.pnlBtmFooter.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlBtmMid.ResumeLayout(false);
            this.pnlBtmMid.PerformLayout();
            this.pnlPort.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlSerial.ResumeLayout(false);
            this.pnlSerial.PerformLayout();
            this.pnlTcp.ResumeLayout(false);
            this.pnlTcp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBtmTop.ResumeLayout(false);
            this.pnlBtmTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlBtmFooter;
        private System.Windows.Forms.Panel pnlBtmMid;
        private System.Windows.Forms.Panel pnlBtmTop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.Panel pnlPort;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbLocalPort;
        private System.Windows.Forms.ComboBox cmbLocalIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRemoteIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCType;
        private System.Windows.Forms.RichTextBox rtbSendMsg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ToolStripMenuItem serialPortSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSerialSettingToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSerial;
        private System.Windows.Forms.Button btnMoreSPSet;
        private System.Windows.Forms.ComboBox cmbBandRate;
        private System.Windows.Forms.Button btnOpenSerialPort;
        private System.Windows.Forms.Panel pnlTcp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslConnectState;
        private System.Windows.Forms.ToolStripStatusLabel tsslErrorMsg;
        private System.Windows.Forms.CheckBox cbDisplayTime;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem fontSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bgColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox cbHexDisplay;
        private System.Windows.Forms.CheckBox cbHexSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.CheckBox cbTimer;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSelect;
    }
}