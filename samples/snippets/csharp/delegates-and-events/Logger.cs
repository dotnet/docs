using System;

namespace DelegatesAndEvents
{

    // Logger implementation two
    // <SnippetSeverity>
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }
    // </SnippetSeverity>

    // <SnippetLoggerFinal>
    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static Severity LogLevel { get; set; } = Severity.Warning;

        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage(outputMsg);
        }
    }
    // </SnippetLoggerFinal>
}

namespace ImplementationOne
{
    // <SnippetFirstImplementation>
    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }
    }
    // </SnippetFirstImplementation>
}

namespace ImplementationTwo
{
    using DelegatesAndEvents;

    // <SnippetLoggerTwo>
    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static void LogMessage(Severity s, string component, string msg)
        {
            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage(outputMsg);
        }
    }
    // </SnippetLoggerTwo>
}
