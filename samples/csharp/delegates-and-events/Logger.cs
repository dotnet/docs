using System;

namespace DelegatesAndEvents
{
    
    // Logger implementation two
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }

    public static class Logger
    {
        public static Action<string> WriteMessage;
        
        public static Severity LogLevel {get;set;} = Severity.Warning;
        
        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;
                
            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            // Assumes that the WriteMessage delegate must not be null:
            WriteMessage(outputMsg);
            // Alternative invoke syntax, for when the delegate
            // may not have any methods attached:
            WriteMessage?.Invoke(outputMsg);
        }
    }
}