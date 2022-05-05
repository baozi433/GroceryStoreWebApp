using NLog;

namespace MyFirstWeb.Utility
{
    public class MyLogger : Ilogger
    {
        private static MyLogger instance;

        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }

        private static Logger logger;
        public Logger GetLogger()
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger("ProductsAppRule");
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
