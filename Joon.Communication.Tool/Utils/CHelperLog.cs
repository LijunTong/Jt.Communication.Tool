using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Joon.Communication.Tool.Utils
{
    public class CHelperLog
    {
        private static ILog _logInfo = LogManager.GetLogger("info");

        private static ILog _logError = LogManager.GetLogger("error");

        public static void info(string log)
        {
            _logInfo.Info(log);
        }

        public static void error(string log)
        {
            _logInfo.Error(log);
        }
    }
}
