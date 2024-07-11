using log4net;
using log4net.Config;

namespace ExpertsQAAtlantisMk_StefanTalevski
{
    public static class LoggerConfig
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(LoggerConfig));

        public static void ConfigureLogging()
        {
            XmlConfigurator.Configure();
        }
    }
}
