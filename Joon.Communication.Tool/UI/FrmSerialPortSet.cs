using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Joon.Communication.Tool.Models;
using Joon.Communication.Tool.Utils;

namespace Joon.Communication.Tool.UI
{
    public partial class FrmSerialPortSet : Form
    {
        private CHelperIni _chelperIni;

        public FrmSerialPortSet(CHelperIni helper)
        {
            _chelperIni = helper;
            InitializeComponent();

            List<string> serialPort = CHelperSerialPort.GetSerialPort();

            foreach (string item in serialPort)
            {
                this.cmbSerialPort.Items.Add(item);
            }

            foreach (int item in CHelperSerialPort.BaudRates)
            {
                this.cmbBaudRate.Items.Add(item);
            }

            foreach (int  item in CHelperSerialPort.DataBits)
            {
                this.cmbDataBits.Items.Add(item);
            }
            foreach (string  item in CHelperSerialPort.Paritys)
            {
                this.cmbParity.Items.Add(item);
            }

            foreach (string item in CHelperSerialPort.StopBits)
            {
                this.cmbStopBits.Items.Add(item);
            }
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComfire_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigItem config = new ConfigItem();
                config.SerialPort = this.cmbSerialPort.Text;
                config.Parity = this.cmbParity.Text;
                config.StopBits = this.cmbStopBits.Text;
                config.BaudRate = int.Parse(this.cmbBaudRate.Text);
                config.DataBits = int.Parse(this.cmbDataBits.Text);
                CHelperConfig.SetConfig(config, _chelperIni);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmSerialPortSet_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigItem config = CHelperConfig.GetConfig(_chelperIni);
                CHelperControl.CmbSetSelectedItem(this.cmbSerialPort, config.SerialPort);
                CHelperControl.CmbSetSelectedItem(this.cmbBaudRate, config.BaudRate.ToString());
                CHelperControl.CmbSetSelectedItem(this.cmbDataBits, config.DataBits.ToString());
                CHelperControl.CmbSetSelectedItem(this.cmbParity, config.Parity);
                CHelperControl.CmbSetSelectedItem(this.cmbStopBits, config.StopBits);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
