using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace BrainstormSessions.LoggingService
{
    public static class Logger
    {

        private static readonly log4net.ILog _log = GetLogger(typeof(log4net.Repository.Hierarchy.Logger));

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        public static void Debug(object message)
        {
            _log.Debug(message);
        }

        public static void Error(object message)
        {
            _log.Error(message);
        }

        public static void Info(object message)
        {
            _log.Info(message);
        }

        public static void Warn(object message)
        {
            _log.Warn(message);
        }


    }
}
