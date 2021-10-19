using System.Runtime.CompilerServices;
using System.Text;

namespace interpolated_string_handler.Version4
{
    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder = default!;

        private readonly bool enabled;

        // <UseOutParameter>
        public LogInterpolatedStringHandler(int literalLength, int formattedCount, LogLevel level, Logger logger, out bool isEnabled)
        {
            enabled = logger.EnabledLevel >= level;
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
            if (enabled)
            {
                builder = new StringBuilder(formattedCount);
            }
            isEnabled = enabled;
        }
        // </UseOutParameter>

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {s}");
            if (!enabled) return;
            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        // <AppendIFormattable>
        public void AppendFormatted<T>(T t, string format, IFormatProvider? provider=default) where T : IFormattable
        {
            Console.WriteLine($"\tAppendFormatted (IFormattable version) called: {t} with format {{{format}}} is of type {typeof(T)},");
            if (!enabled) return;

            builder.Append(t?.ToString(format, provider));
            Console.WriteLine($"\tAppended the formatted object");
        }
        // </AppendIFormattable>

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {t} is of type {typeof(T)}");
            if (!enabled) return;

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

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
        public void LogMessage(LogLevel level, [InterpolatedStringHandlerArgument("level", "")] LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }
    }
}
