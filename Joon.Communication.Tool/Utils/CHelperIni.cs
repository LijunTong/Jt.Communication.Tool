using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperIni
    {
        #region 导入API

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key,
                string val, string filePath);
 
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll")]
        private extern static int GetPrivateProfileSectionA(string section, byte[] sData, int nSize, string fileName);

        [DllImport("kernel32.dll")]
        private extern static int GetPrivateProfileSectionNamesA(byte[] vData, int iLen, string fileName);

        #endregion

        private string _configPath;

        public CHelperIni(string configPath)
        {
            _configPath = configPath;
        }

        /// <summary>
        /// 设置Key-value
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetValue(string section,string key,string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_configPath))
                {
                    throw new Exception("配置文件路径为空");
                }
                WritePrivateProfileString(section, key, value, _configPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Key-Value
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetValue(string section,string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_configPath))
                {
                    throw new Exception("配置文件路径为空");
                }
                StringBuilder temp = new StringBuilder(1024);
                int length = GetPrivateProfileString(section, key, "", temp, 1024, _configPath);
                return temp.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 读取ini文件下的所有配置节点名称
        /// </summary>
        /// <param name="iniFilePath">ini文件路径</param>
        /// <returns></returns>
        public List<string> GetSections()
        {
            List<string> lstSections = new List<string>();

            byte[] buffer = new byte[10000];
            int readLen = GetPrivateProfileSectionNamesA(buffer, buffer.Length, _configPath);
            List<byte> lstTmp = new List<byte>();
            for (int i = 0; i < readLen; i++)
            {
                if (i == 0 && buffer[i] == 0x00)
                {
                    continue;
                }

                if (buffer[i] != 0x00)
                {
                    lstTmp.Add(buffer[i]);
                }
                else //为0x00的时候，证明一个几点的数据读取完整
                {
                    lstSections.Add(Encoding.Default.GetString(lstTmp.ToArray()));
                    lstTmp.Clear();
                }
            }

            return lstSections;
        }
        
        /// <summary>
        /// 获取指定节点下所有配置项的名称
        /// </summary>
        /// <param name="section">配置节点名称</param>
        /// <param name="iniFilePath">ini文件路径</param>
        /// <returns></returns>
        public List<string> GetKeys(string section)
        {
            List<string> lstKeys = new List<string>();

            byte[] buffer = new byte[10000];
            int readLen = GetPrivateProfileSectionA(section, buffer, 10000, _configPath);
            List<byte> lstTmp = new List<byte>();
            for (int i = 0; i < readLen; i++)
            {
                if (i == 0 && buffer[i] == 0x00)
                {
                    continue;
                }

                if (buffer[i] != 0x00)
                {
                    lstTmp.Add(buffer[i]);
                }
                else //为0x00的时候，证明一个几点的数据读取完整
                {
                    string strKeyValue = Encoding.Default.GetString(lstTmp.ToArray());
                    if (strKeyValue.Length > 0)
                    {
                        lstKeys.Add(strKeyValue.Substring(0, strKeyValue.IndexOf("=")));
                    }
                    lstTmp.Clear();
                }
            }
            return lstKeys;
        }
        
        
    }
}
