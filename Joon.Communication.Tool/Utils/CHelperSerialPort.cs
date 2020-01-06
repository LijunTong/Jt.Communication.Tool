using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;


namespace Joon.Communication.Tool.Utils
{
    public class CHelperSerialPort
    {
        public delegate void ReceivedHandle();

        public event ReceivedHandle ReceivedEvent;

        /// <summary>
        /// 波特率
        /// 300、600、1200、2400、4800、9600、19200、38400、43000、56000、57600、115200
        /// </summary>
        public static int[] BaudRates = new int[] { 300,300,600,1200,2400,4800,9600,
            19200,38400,43000,56000,57600,115200};

        /// <summary>
        /// 奇偶校验
        /// </summary>
        public static string[] Paritys = new string[] { "None", "Odd", "Even", "Mark", "Space" };

        /// <summary>
        /// 数据位
        /// </summary>
        public static int[] DataBits = new int[] { 5, 6, 7, 8 };

        /// <summary>
        /// 停止位
        /// </summary>
        public static string[] StopBits = new string[] { "None", "One", "Two", "OnePointFive" };

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort _serialPort;

        public byte[] ReceiveData;

        /// <summary>
        /// 获取所有串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSerialPort()
        {
            return SerialPort.GetPortNames().ToList();
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        public CHelperSerialPort(string portName, int baudRate, string parity, int dataBits, string stopBits)
        {
            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = portName;
                _serialPort.BaudRate = baudRate;
                switch (parity)
                {
                    case "None":
                        _serialPort.Parity = Parity.None;
                        break;
                    case "Odd":
                        _serialPort.Parity = Parity.Odd;
                        break;
                    case "Even":
                        _serialPort.Parity = Parity.Even;
                        break;
                    case "Mark":
                        _serialPort.Parity = Parity.Mark;
                        break;
                    case "Space":
                        _serialPort.Parity = Parity.Space;
                        break;
                    default:
                        _serialPort.Parity = Parity.None;
                        break;

                }

                _serialPort.DataBits = dataBits;
                switch (stopBits)
                {
                    case "None":
                        _serialPort.StopBits = System.IO.Ports.StopBits.None;
                        break;
                    case "One":
                        _serialPort.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "OnePointFive":
                        _serialPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "Two":
                        _serialPort.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                    default:
                        _serialPort.StopBits = System.IO.Ports.StopBits.One;
                        break;

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


            
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open()
        {
            try
            {
                if (_serialPort == null)
                {
                    throw new Exception("串口未初始化.");
                }
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                    _serialPort.DataReceived += _serialPort_DataReceived;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte [] data = new byte[_serialPort.BytesToRead];
            _serialPort.Read(data, 0, data.Length);
            ReceiveData = data;
            if (ReceivedEvent != null)
            {
                ReceivedEvent();
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            try
            {
                if (_serialPort == null)
                {
                    throw new Exception("串口未初始化.");
                }
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
