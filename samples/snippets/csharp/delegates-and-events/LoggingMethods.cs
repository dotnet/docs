using System;

namespace DelegatesAndEvents
{
    // <SnippetLogToConsole>
    public static class LoggingMethods
    {
        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
    // </SnippetLogToConsole>
}
