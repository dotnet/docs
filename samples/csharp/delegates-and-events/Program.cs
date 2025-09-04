using System;

namespace DelegatesAndEvents
{
    /// <summary>
    /// The main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Logs a message to the console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
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
