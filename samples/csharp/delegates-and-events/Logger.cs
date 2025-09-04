using System;

namespace DelegatesAndEvents
{
    
    /// <summary>
    /// The severity of a log message.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Verbose messages.
        /// </summary>
        Verbose,
        /// <summary>
        /// Trace messages.
        /// </summary>
        Trace,
        /// <summary>
        /// Informational messages.
        /// </summary>
        Information,
        /// <summary>
        /// Warning messages.
        /// </summary>
        Warning,
        /// <summary>
        /// Error messages.
        /// </summary>
        Error,
        /// <summary>
        /// Critical messages.
        /// </summary>
        Critical
    }

    /// <summary>
    /// A simple logger class.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The delegate that is invoked to write a message.
        /// </summary>
        public static Action<string> WriteMessage;

        /// <summary>
        /// The minimum severity level to log.
        /// </summary>
        public static Severity LogLevel {get;set;} = Severity.Warning;

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="s">The severity of the message.</param>
        /// <param name="component">The component that is logging the message.</param>
        /// <param name="msg">The message to log.</param>
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