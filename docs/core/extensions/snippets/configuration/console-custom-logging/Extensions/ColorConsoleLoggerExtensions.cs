using System;
using Microsoft.Extensions.Logging;

public static class ColorConsoleLoggerExtensions
{
    public static ILoggingBuilder AddColorConsoleLogger(
        this ILoggingBuilder builder) =>
        builder.AddColorConsoleLogger(
            new ColorConsoleLoggerConfiguration());

    public static ILoggingBuilder AddColorConsoleLogger(
        this ILoggingBuilder builder,
        Action<ColorConsoleLoggerConfiguration> configure)
    {
        var config = new ColorConsoleLoggerConfiguration();
        configure(config);

        return builder.AddColorConsoleLogger(config);
    }

    public static ILoggingBuilder AddColorConsoleLogger(
        this ILoggingBuilder builder,
        ColorConsoleLoggerConfiguration config)
    {
        builder.AddProvider(new ColorConsoleLoggerProvider(config));
        return builder;
    }
}
