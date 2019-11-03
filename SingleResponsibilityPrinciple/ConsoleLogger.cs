using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        //Request  405 - "As a manager, I want to easily monitor the trading errors my traders make so I can provide 
        //them better training to avoid errors."
        //Details: all logs should be sent to an XML file along with outputting to the console.
        public void LogWarning(string message, params object[] args)
        {
            var type = "WARN : ";
            Console.WriteLine(string.Concat(type, message), args);

            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
            }
        }

        //Request  405 - "As a manager, I want to easily monitor the trading errors my traders make so I can provide 
        //them better training to avoid errors."
        //Details: all logs should be sent to an XML file along with outputting to the console.
        public void LogInfo(string message, params object[] args)
        {
            var type = "INFO : ";
            Console.WriteLine(string.Concat(type, message), args);

            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
            }
        }
    }
}
