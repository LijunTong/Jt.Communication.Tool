using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joon.Communication.Tool.Models
{
    /*
     * 配置信息类
     * 
     * 该类的所有公共属性都是一个配置项
     * 如有需要增加配置项信息，在该类添加一个属性即可
     */ 
    public class ConfigItem
    {
        private string serialPort;

        /// <summary>
        /// 串口号
        /// </summary>
        public string SerialPort
        {
            get { return serialPort; }
            set { serialPort = value; }
        }

        private int baudRate;

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }

        private string parity;

        /// <summary>
        /// 奇偶校验
        /// </summary>
        public string Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private int dataBits;

        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }

        private string stopBits;

        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }

        private string serialType;

        /// <summary>
        /// 串口类型
        /// </summary>
        public string SerialType
        {
            get { return serialType; }
            set { serialType = value; }
        }

        private string remoteIp;

        /// <summary>
        /// 远程IP
        /// </summary>
        public string RemoteIp
        {
            get { return remoteIp; }
            set { remoteIp = value; }
        }

        private int remotePort;

        /// <summary>
        /// 远程端口
        /// </summary>
        public int RemotePort
        {
            get { return remotePort; }
            set { remotePort = value; }
        }


        private string localIp;

        /// <summary>
        /// 本地IP
        /// </summary>
        public string LocalIp
        {
            get { return localIp; }
            set { localIp = value; }
        }

        private int localPort;

        /// <summary>
        /// 本地端口
        /// </summary>
        public int LocalPort
        {
            get { return localPort; }
            set { localPort = value; }
        }

        private bool isDisplayTime;

        /// <summary>
        /// 是否显示时间戳
        /// </summary>
        public bool IsDisplayTime
        {
            get { return isDisplayTime; }
            set { isDisplayTime = value; }
        }

        private string msgFont;

        /// <summary>
        /// 字体颜色
        /// </summary>
        public string MsgFont
        {
            get { return msgFont; }
            set { msgFont = value; }
        }

        private string bgColor;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }

        private bool isHexDisplay;

        /// <summary>
        /// 是否hex显示
        /// </summary>
        public bool IsHexDisplay
        {
            get { return isHexDisplay; }
            set { isHexDisplay = value; }
        }

        private bool isHexSend;

        /// <summary>
        /// 是否hex发送
        /// </summary>
        public bool IsHexSend
        {
            get { return isHexSend; }
            set { isHexSend = value; }
        }

        private bool isTimer;

        /// <summary>
        /// 是否定时发送
        /// </summary>
        public bool IsTimer
        {
            get { return isTimer; }
            set { isTimer = value; }
        }

        private string interval;

        /// <summary>
        /// 定时发送间隔时间
        /// </summary>
        public string Interval
        {
            get { return interval; }
            set { interval = value; }
        }

    }
}
