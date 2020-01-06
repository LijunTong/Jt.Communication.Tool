using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Joon.Communication.Tool.Models;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperConfig
    {
        private static string section = "Setting";

        /// <summary>
        /// 设置配置信息
        /// </summary>
        /// <param name="configItem">配置项</param>
        /// <param name="chelperIni">配置文件操作实例</param>
        public static void SetConfig(ConfigItem configItem,CHelperIni chelperIni)
        {
            try
            {
                PropertyInfo[] props = CHelperClassProperties.GetProperties(configItem);
                foreach (PropertyInfo item in props)
                {
                    string val="";
                    if (item.PropertyType == typeof(int))
                    {
                        int no = (int)item.GetValue(configItem);
                        val = no == 0 ? "" : no.ToString();
                    }
                    else
                    {
                        val = item.GetValue(configItem) == null ? "" : item.GetValue(configItem).ToString();
                    }
                    
                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        chelperIni.SetValue(section, item.Name, val);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取配置问价信息
        /// </summary>
        /// <param name="chelperIni">配置文件操作实例</param>
        /// <returns></returns>
        public static ConfigItem GetConfig(CHelperIni chelperIni)
        {
            ConfigItem configItem = new ConfigItem();
            PropertyInfo[] props = CHelperClassProperties.GetProperties(configItem);
            List<string> keys = chelperIni.GetKeys(section);
            foreach (PropertyInfo item in props)
            {
                if (keys.Contains(item.Name))
                {
                    string val = chelperIni.GetValue(section,item.Name);
                    item.SetValue(configItem, CHelperClassProperties.TypeTransaction(item.PropertyType, val));
                }
            }
            return configItem;
        }
    }
}
