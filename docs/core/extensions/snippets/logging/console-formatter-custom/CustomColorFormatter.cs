using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Console.ExampleFormatters.Custom;

public sealed class CustomColorFormatter : ConsoleFormatter, IDisposable
{
    private readonly IDisposable? _optionsReloadToken;
    private CustomColorOptions _formatterOptions;

    private bool ConsoleColorFormattingEnabled =>
        _formatterOptions.ColorBehavior == LoggerColorBehavior.Enabled ||
        _formatterOptions.ColorBehavior == LoggerColorBehavior.Default &&
        System.Console.IsOutputRedirected == false;

    public CustomColorFormatter(IOptionsMonitor<CustomColorOptions> options)
        // Case insensitive
        : base("customName") =>
        (_optionsReloadToken, _formatterOptions) =
            (options.OnChange(ReloadLoggerOptions), options.CurrentValue);

    private void ReloadLoggerOptions(CustomColorOptions options) =>
        _formatterOptions = options;

    public override void Write<TState>(
        in LogEntry<TState> logEntry,
        IExternalScopeProvider? scopeProvider,
        TextWriter textWriter)
    {
        if (logEntry.Exception is null)
        {
            return;
        }

        string? message =
            logEntry.Formatter?.Invoke(
                logEntry.State, logEntry.Exception);

        if (message is null)
        {
            return;
        }

        CustomLogicGoesHere(textWriter);
        textWriter.WriteLine(message);
    }

    private void CustomLogicGoesHere(TextWriter textWriter)
    {
        if (ConsoleColorFormattingEnabled)
        {
            textWriter.WriteWithColor(
                _formatterOptions.CustomPrefix ?? string.Empty,
                ConsoleColor.Black,
                ConsoleColor.Green);
        }
        else
        {
            textWriter.Write(_formatterOptions.CustomPrefix);
        }
    }

    public void Dispose() => _optionsReloadToken?.Dispose();
}
