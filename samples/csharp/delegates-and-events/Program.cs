using System;

namespace DelegatesAndEvents
{
    public class Program
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }

        public static void Main(string[] args)
        {
            Logger.WriteMessage += LogToConsole;
            var file = new FileLogger("log.txt");
            
            Logger.LogMessage(Severity.Warning, "Console", "This is a warning message");
            
            Logger.LogMessage(Severity.Information, "Console", "Information message one");
            Logger.LogLevel = Severity.Information;

            Logger.LogMessage(Severity.Information, "Console", "Information message two");
        }
    }
}
