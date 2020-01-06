using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Joon.Communication.Tool.Models;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperClassProperties
    {
        public static PropertyInfo[] GetProperties(Object obj)
        {
            PropertyInfo[] properties = null;
            try
            {
                properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return properties;
        }


        public static Object TypeTransaction(Type type, string value)
        {
            if (type == typeof(string) || type == typeof(String))
            {
                return value;
            }
            object obj = null;
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (type == typeof(int))
                    {
                        obj = null;
                    }
                    else if (type == typeof(double))
                    {
                        obj = null;
                    }
                    else if (type == typeof(bool))
                    {
                        obj = null;
                    }
                    else if (type == typeof(DateTime))
                    {
                        obj = null;
                    }
                }
                else
                {
                    obj = type.GetMethod("Parse", new Type[] { typeof(string) }).Invoke(null, new object[] { value });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
