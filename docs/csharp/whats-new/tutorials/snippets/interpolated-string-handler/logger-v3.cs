using System.Runtime.CompilerServices;
using System.Text;

namespace interpolated_string_handler.Version3
{
    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder;
        // <AddEnabledFlag>
        private readonly bool enabled;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount, Logger logger, LogLevel logLevel)
        {
            enabled = logger.EnabledLevel >= logLevel;
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }
        // </AddEnabledFlag>

        // <AppendWhenEnabled>
        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
            if (!enabled) return;

            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
            if (!enabled) return;

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }
        // </AppendWhenEnabled>

        // Not part of the pattern, but needed to retrieve the formatted string
        internal string GetFormattedText() => builder.ToString();
    }

    public enum LogLevel
    {
        Off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }

    public class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

        public void LogMessage(LogLevel level, string msg)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(msg);
        }

        // <ArgumentsToHandlerConstructor>
        public void LogMessage(LogLevel level, [InterpolatedStringHandlerArgument("", "level")] LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }
        // </ArgumentsToHandlerConstructor>
    }
}
