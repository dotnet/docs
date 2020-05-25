using System;

namespace DelegatesAndEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // <SnippetConnectDelegate>
            Logger.WriteMessage += LoggingMethods.LogToConsole;
            // </SnippetConnectDelegate>
            // <SnippetFileLogger>
            var file = new FileLogger("log.txt");
            // </SnippetFileLogger>

            Logger.LogMessage(Severity.Warning, "Console", "This is a warning message");

            Logger.LogMessage(Severity.Information, "Console", "Information message one");
            Logger.LogLevel = Severity.Information;

            Logger.LogMessage(Severity.Information, "Console", "Information message two");
        }
    }
}
