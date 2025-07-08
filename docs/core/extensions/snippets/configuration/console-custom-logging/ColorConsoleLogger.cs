using Microsoft.Extensions.Logging;

public sealed class ColorConsoleLogger(
    string name,
    Func<ColorConsoleLoggerConfiguration> getCurrentConfig) : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        getCurrentConfig().LogLevelToColorMap.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        ColorConsoleLoggerConfiguration config = getCurrentConfig();
        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
            Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");
            
            Console.ForegroundColor = originalColor;
            Console.Write($"     {name} - ");

            Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
            Console.Write($"{formatter(state, exception)}");
            
            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }
    }
}
