using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperString
    {
        /// <summary>
        /// 字符串转Byte数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string data)
        {
            return Encoding.Default.GetBytes(data);
        }

        /// <summary>
        /// Byte数组转字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToString(Byte[] data)
        {
            return Encoding.Default.GetString(data);
        }

        /// <summary>
        /// hex字符串转byte数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] HexStringToByte(string data)
        {
            byte[] result = new byte[data.Length / 2];
            for (int i = 0; i < data.Length / 2; i++)
            {
                string temp = data.Substring(i * 2, 2);
                result[i] = Convert.ToByte(temp, 16);
            }
            return result;
        }

        /// <summary>
        /// hex字符串转字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HexStringToString(string data)
        {
            return ByteToString(HexStringToByte(data));
        }

        /// <summary>
        /// byte数组转hex字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToHexString(byte[] data)
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                result += data[i].ToString("X2");
            }
            return result;
        }

        /// <summary>
        /// 字符串转hex字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string StringToHexString(string data)
        {
            return ByteToHexString(StringToByte(data));
        }

        /// <summary>
        /// 十进制转16进制
        /// 除基取余法
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string IntToHexString(int val)
        {
            if (val < 0)
            {
                return "";
            }
            string x16 = "0123456789ABCDEFG";
            int baseNo = 16;

            List<int> list = new List<int>();
            while (val >= baseNo)
            {
                int a = val % baseNo;
                list.Add(a);
                val /= baseNo;
            }
            list.Add(val);

            StringBuilder sb = new StringBuilder();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                sb.Append(x16[list[i]]);
            }
            return sb.ToString();
        }
    }
}
