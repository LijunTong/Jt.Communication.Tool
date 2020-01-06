namespace Joon.Communication.Tool.UI
{
    partial class FrmSerialPortSet
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnComfire = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "BaudRate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "DataBits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "StopBits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Parity:";
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(79, 66);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(127, 20);
            this.cmbParity.TabIndex = 12;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(79, 119);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(127, 20);
            this.cmbStopBits.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "SerialPort:";
            // 
            // btnComfire
            // 
            this.btnComfire.Location = new System.Drawing.Point(41, 152);
            this.btnComfire.Name = "btnComfire";
            this.btnComfire.Size = new System.Drawing.Size(47, 23);
            this.btnComfire.TabIndex = 16;
            this.btnComfire.Text = "确认";
            this.btnComfire.UseVisualStyleBackColor = true;
            this.btnComfire.Click += new System.EventHandler(this.btnComfire_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(124, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(79, 11);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(127, 20);
            this.cmbSerialPort.TabIndex = 18;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(79, 37);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(127, 20);
            this.cmbBaudRate.TabIndex = 19;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(79, 92);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(127, 20);
            this.cmbDataBits.TabIndex = 20;
            // 
            // FrmSerialPortSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 187);
            this.Controls.Add(this.cmbDataBits);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.cmbSerialPort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComfire);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStopBits);
            this.Controls.Add(this.cmbParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(236, 225);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(236, 225);
            this.Name = "FrmSerialPortSet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口设置";
            this.Load += new System.EventHandler(this.FrmSerialPortSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnComfire;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbDataBits;
    }
}