using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperJson
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {
            try
            {
                return JsonConvert.SerializeObject(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            try
            {
                T t = (T)JsonConvert.DeserializeObject(json);
                return t;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
