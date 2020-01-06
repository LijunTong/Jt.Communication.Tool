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
    public class CHelperTcpService
    {
        #region 私有变量

        /// <summary>
        /// 服务端
        /// </summary>
        private Socket _serviceSocket;

        /// <summary>
        /// ip地址
        /// </summary>
        private string _ip;

        /// <summary>
        /// 端口号
        /// </summary>
        private int _port;

        /// <summary>
        /// 开启 服务端监听的线程
        /// </summary>
        private Thread _startListenThread;

        /// <summary>
        /// 接收数据线程
        /// </summary>
        private Thread _receiveDataThread;

        /// <summary>
        /// 接收的数据
        /// </summary>
        private byte[] _recevieDataBuffer;


        /// <summary>
        /// 已连接的客户端
        /// </summary>
        private List<Socket> _connectedSocketList = new List<Socket>();

        #endregion

        #region 委托、事件

        /// <summary>
        /// 接收数据 委托
        /// </summary>
        public delegate void ReceiveHandle();

        /// <summary>
        /// 接收数据 事件
        /// </summary>
        public event ReceiveHandle ReceivedEvent;

        /// <summary>
        /// 监听委托
        /// </summary>
        public delegate void ListenHandle();

        /// <summary>
        /// 监听事件
        /// </summary>
        public event ListenHandle ListenEvent;

        /// <summary>
        /// 连接关闭 事件
        /// </summary>
        public event ListenHandle ClosedEvent;
        

        #endregion

        public CHelperTcpService(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }

        /// <summary>
        /// 开启监听服务
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void StartTcpService()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(_ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _port);

                _serviceSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serviceSocket.Bind(ipEndPoint);
                _serviceSocket.Listen(20);


                //_serviceSocket.BeginAccept(new AsyncCallback(Listen), _serviceSocket);
                _startListenThread = new Thread(new ThreadStart(Listen));
                _startListenThread.Start();
                _startListenThread.IsBackground = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 停止tcp服务
        /// </summary>
        public void StopTcpService()
        {
            try
            {

                if (_receiveDataThread != null)
                {
                    _receiveDataThread.Abort();
                }
                foreach (Socket item in _connectedSocketList)
                {
                    if (item.Connected)
                    {
                        item.Disconnect(false);
                        item.Close();
                        item.Dispose();
                    }
                }

                _connectedSocketList.Clear();

                if (_serviceSocket != null)
                {
                    if (_serviceSocket.Connected)
                    {
                        _serviceSocket.Disconnect(false);
                    }
                    _serviceSocket.Close();
                    _serviceSocket.Dispose();
                }

                if (_startListenThread != null)
                {
                    _startListenThread.Abort();

                }
                
                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 监听
        /// </summary>
        private void Listen()
        {
            try
            {
                while (true)
                {
                    while (!_serviceSocket.Connected)
                    {
                        break;
                    }
                    Socket client = _serviceSocket.Accept();

                    _connectedSocketList.Add(client);

                    ListenEvent();
                    _receiveDataThread = new Thread(new ParameterizedThreadStart(RecevieData));
                    _receiveDataThread.Start(client);
                    //_receiveDataThread.IsBackground = true;
                }
                //_recevieDataBuffer = new byte[10240];
                //Socket oldSocket = (Socket)iar.AsyncState;
                //Socket s = oldSocket.EndAccept(iar);
                //s.BeginReceive(_recevieDataBuffer,0, _recevieDataBuffer.Length,SocketFlags.None, new AsyncCallback(RecevieData), s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private void RecevieData(object obj)
        {
            Socket client = (Socket)obj;
            try
            {
                //int count = client.EndReceive(iar);
                //if (count > 0)
                //{
                //    ReceivedEvent();
                //}
                while (true)
                {
                    if (client.Available <= 0)
                    {

                    }
                    int len = 0;
                    byte[] buffer = new byte[10240];
                    len = client.Receive(buffer);
                    if (len > 0)
                    {
                        _recevieDataBuffer = new byte[len];
                        for (int i = 0; i < len; i++)
                        {
                            _recevieDataBuffer[i] = buffer[i];
                        }
                        ReceivedEvent();
                    }
                    else
                    {
                        //StopTcpService();
                        _connectedSocketList.Where(x => x == client).First().Close();
                        _connectedSocketList.Remove(client);
                        ClosedEvent();
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] Recevied()
        {
            return _recevieDataBuffer;
        }

        /// <summary>
        /// 获取连接的客户端
        /// </summary>
        /// <returns></returns>
        public List<Socket> GetConnectedSocketList()
        {
            return _connectedSocketList;
        }

        public void Send(byte[] data)
        {
            _connectedSocketList[0].Send(data);
        }
        
    }
}
