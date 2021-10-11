
using System.Runtime.CompilerServices;
using System.Text;

Logger logger = new Logger() { EnabledLevel = LogLevel.Trace };

// Given the above definitions, usage looks like this:
var name = "Fred Silberberg";
logger.LogTrace(80, $"{name} will never be printed because info is < trace!");

int index = 3;
logger.LogTrace(40, $"This interpolated string starts with a literal, {index++} has an int, a {name}, and another {index++}");

// The handler that will actually "build" the interpolated string"
[InterpolatedStringHandler]
public ref struct TraceLoggerParamsInterpolatedStringHandler
{
    // Storage for the built-up string
    StringBuilder builder = default!;

    public TraceLoggerParamsInterpolatedStringHandler(int literalLength, int formattedCount, int maxLength, Logger logger, out bool handlerIsValid)
    {
        if (logger.EnabledLevel != LogLevel.Trace)
        {
            handlerIsValid = false;
            return;
        }
        Console.WriteLine(maxLength);
        builder = new StringBuilder(formattedCount);
        Console.WriteLine($"literal length: {literalLength}, formattedCount: {formattedCount}");

        handlerIsValid = true;
    }

    public void AppendLiteral(string s)
    {
        Console.WriteLine($"AppendLiteral called: {s}");
        // Store and format part as required
        builder.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        Console.WriteLine($"AppendFormatted called: {t} is of type {typeof(T)}");

        // Store and format part as required
        builder.Append(t.ToString());
    }

    public string GetFormattedText() => builder.ToString();
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

// The logger class. The user has an instance of this, accesses it via static state, or some other access
// mechanism
public class Logger
{
    // Initialization code omitted
    public LogLevel EnabledLevel;

    public void LogTrace(int maxLength, [InterpolatedStringHandlerArgument("maxLength", "")] TraceLoggerParamsInterpolatedStringHandler handler)
    {
        // Impl of logging
        Console.WriteLine(handler.GetFormattedText());
    }
}
