---
title: Implement a custom logging provider
description: Discover how to implement a custom logging provider with colorized logs, writing custom C# ILogger and ILoggerProvider implementations.
ms.date: 02/04/2026
ms.topic: how-to
---

# Implement a custom logging provider in .NET

There are many [logging providers](providers.md) available for common logging needs. But you might need to implement a custom <xref:Microsoft.Extensions.Logging.ILoggerProvider> when one of the available providers doesn't suit your application needs. In this article, you learn how to implement a custom logging provider that can be used to colorize logs in the console.

> [!TIP]
> The custom logging provider example source code is available in the [docs GitHub repo](https://github.com/dotnet/docs/tree/main/docs/core/extensions/snippets/configuration/console-custom-logging).

## Sample custom logger configuration

The sample creates different color console entries per log level and event ID using the following configuration type:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/ColorConsoleLoggerConfiguration.cs":::

The preceding code sets the default level to `Information`, the color to `Green`, and the `EventId` is implicitly `0`.

## Create the custom logger

The `ILogger` implementation category name is typically the logging source. For example, the type where the logger is created:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/ColorConsoleLogger.cs":::

The preceding code:

- Creates one logger instance per category name.
- Checks `_getCurrentConfig().LogLevelToColorMap.ContainsKey(logLevel)` in `IsEnabled`, so each `logLevel` has a unique logger. In this implementation, each log level requires an explicit configuration entry to log.

It's a good practice to call <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled*?displayProperty=nameWithType> within <xref:Microsoft.Extensions.Logging.ILogger.Log*?displayProperty=nameWithType> implementations since `Log` can be called by any consumer, and there are no guarantees that it was previously checked. The `IsEnabled` method should be very fast in most implementations.

:::code language="csharp" source="../snippets/configuration/console-custom-logging/ColorConsoleLogger.cs" id="IsEnabledCheck":::

The logger is instantiated with the `name` and a `Func<ColorConsoleLoggerConfiguration>`, which returns the current config&mdash;this handles updates to the config values as monitored through the <xref:Microsoft.Extensions.Options.IOptionsMonitor`1.OnChange*?displayProperty=nameWithType> callback.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Logging.ILogger.Log*?displayProperty=nameWithType> implementation checks if the `config.EventId` value is set. When `config.EventId` is not set or when it matches the exact `logEntry.EventId`, the logger logs in color.

## Custom logger provider

The `ILoggerProvider` object is responsible for creating logger instances. It's not necessary to create a logger instance per category, but it makes sense for some loggers, like NLog or log4net. This strategy allows you to choose different logging output targets per category, as in the following example:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/ColorConsoleLoggerProvider.cs":::

In the preceding code, <xref:Microsoft.Build.Logging.LoggerDescription.CreateLogger*> creates a single instance of the `ColorConsoleLogger` per category name and stores it in the [`ConcurrentDictionary<TKey,TValue>`](/dotnet/api/system.collections.concurrent.concurrentdictionary-2). Additionally, the <xref:Microsoft.Extensions.Options.IOptionsMonitor`1> interface is required to update changes to the underlying `ColorConsoleLoggerConfiguration` object.

To control the configuration of the `ColorConsoleLogger`, you define an alias on its provider:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/ColorConsoleLoggerProvider.cs" range="6-8" highlight="7":::

The `ColorConsoleLoggerProvider` class defines two class-scoped attributes:

- <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>: The `ColorConsoleLogger` type is _not supported_ in the `"browser"`.
- <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute>: Configuration sections can define options using the `"ColorConsole"` key.

The configuration can be specified with any valid [configuration provider](../configuration-providers.md). Consider the following _appsettings.json_ file:

:::code language="json" source="../snippets/configuration/console-custom-logging/appsettings.json":::

These settings configure the log levels to the following colors:

| <xref:Microsoft.Extensions.Logging.LogLevel>             | <xref:System.ConsoleColor>           |
|----------------------------------------------------------|--------------------------------------|
| <xref:Microsoft.Extensions.Logging.LogLevel.Information> | <xref:System.ConsoleColor.DarkGreen> |
| <xref:Microsoft.Extensions.Logging.LogLevel.Warning>     | <xref:System.ConsoleColor.Cyan>      |
| <xref:Microsoft.Extensions.Logging.LogLevel.Error>       | <xref:System.ConsoleColor.Red>       |

The <xref:Microsoft.Extensions.Logging.LogLevel.Information> log level is set to <xref:System.ConsoleColor.DarkGreen>, which overrides the default value set in the `ColorConsoleLoggerConfiguration` object.

## Usage and registration of the custom logger

By convention, registering services for dependency injection happens as part of the startup routine of an application. The registration occurs in the `Program` class or could also be delegated to a `Startup` class. In this example, it's registered directly from the _Program.cs_ file.

To add the custom logging provider and corresponding logger, add an <xref:Microsoft.Extensions.Logging.ILoggerProvider> by calling a custom extension method, `AddColorConsoleLogger`, on the <xref:Microsoft.Extensions.Logging.ILoggingBuilder> from the <xref:Microsoft.Extensions.Hosting.IHostApplicationBuilder.Logging?displayProperty=nameWithType> property:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/Program.cs" highlight="6-14":::

By convention, extension methods on `ILoggingBuilder` are used to register the custom provider:

:::code language="csharp" source="../snippets/configuration/console-custom-logging/Extensions/ColorConsoleLoggerExtensions.cs":::

The `ILoggingBuilder` creates one or more `ILogger` instances. The `ILogger` instances are used by the framework to log the information.

The configuration from the _appsettings.json_ file overrides the following values:

| <xref:Microsoft.Extensions.Logging.LogLevel>         | <xref:System.ConsoleColor>          |
|------------------------------------------------------|-------------------------------------|
| <xref:Microsoft.Extensions.Logging.LogLevel.Warning> | <xref:System.ConsoleColor.DarkCyan> |
| <xref:Microsoft.Extensions.Logging.LogLevel.Error>   | <xref:System.ConsoleColor.DarkRed>  |

When you run this simple app, it renders color output to the console window similar to the following image:

:::image type="content" source="media/color-console-logger.png" alt-text="Color console logger sample output":::

## See also

- [Logging in .NET](overview.md)
- [Logging providers in .NET](providers.md)
- [Dependency injection in .NET](../dependency-injection/overview.md)
- [High-performance logging in .NET](high-performance-logging.md)
