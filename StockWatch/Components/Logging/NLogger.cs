using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockWatch.Components.Logging
{
    public class NLogger : StockWatch.Services.ILog
    {
        private NLog.Logger logger;

        public NLogger()
        {
            logger = NLog.LogManager.GetLogger("Structure.Web");
        }

        public void Info(string message, Exception exception = null)
        {
            logger.InfoException(message, exception);
        }

        public void Debug(string message, Exception exception = null)
        {
            logger.DebugException(message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            logger.WarnException(message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            logger.ErrorException(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            logger.FatalException(message, exception);
        }
    }
}