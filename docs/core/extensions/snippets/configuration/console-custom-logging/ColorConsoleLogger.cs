using System;
using Microsoft.Extensions.Logging;

public class ColorConsoleLogger : ILogger
{
    private readonly string _name;
    private readonly ColorConsoleLoggerConfiguration _config;

    public ColorConsoleLogger(
        string name,
        ColorConsoleLoggerConfiguration config) =>
        (_name, _config) = (name, config);

    public IDisposable BeginScope<TState>(TState state) => default;

    public bool IsEnabled(LogLevel logLevel) =>
        _config.LogLevels.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        if (_config.EventId == 0 || _config.EventId == eventId.Id)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = _config.LogLevels[logLevel];
            Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");
            
            Console.ForegroundColor = originalColor;
            Console.WriteLine($"     {_name} - {formatter(state, exception)}");
        }
    }
}
