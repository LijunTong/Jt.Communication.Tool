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
    public class CHelperTcp
    {
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIp()
        {
            List<IPAddress> ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList();
            List<string> LocalIps = new List<string>();
            foreach (IPAddress item in ips)
            {
                LocalIps.Add(item.ToString());
            }
            return LocalIps;
        }

        /// <summary>
        /// 获取ipv4
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIpv4()
        {
            List<IPAddress> ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList();
            List<string> LocalIps = new List<string>();
            foreach (IPAddress item in ips)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIps.Add(item.ToString());
                }
            }
            return LocalIps;
        }

        /// <summary>
        /// 获取ipv6
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIpv6()
        {
            List<IPAddress> ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList();
            List<string> LocalIps = new List<string>();
            foreach (IPAddress item in ips)
            {
                if (item.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    LocalIps.Add(item.ToString());
                }
            }
            return LocalIps;
        }
        
    }
}
