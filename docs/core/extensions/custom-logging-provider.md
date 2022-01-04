---
title: Implement a custom logging provider in .NET
description: Learn how to implement a custom logging provider in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 01/04/2022
ms.topic: how-to
---

# Implement a custom logging provider in .NET

There are many [logging providers](logging-providers.md) available for common logging needs. You may need to implement a custom <xref:Microsoft.Extensions.Logging.ILoggerProvider> when one of the available providers doesn't suit your application needs. In this article, you'll learn how to implement a custom logging provider that can be used to colorize logs in the console.

[!INCLUDE [logging-samples-browser](includes/logging-samples-browser.md)]

### Sample custom logger configuration

The sample creates different color console entries per log level and event ID using the following configuration type:

:::code language="csharp" source="snippets/configuration/console-custom-logging/ColorConsoleLoggerConfiguration.cs":::

The preceding code sets the default level to `Information`, the color to `Green`, and the `EventId` is implicitly `0`.

### Create the custom logger

The `ILogger` implementation category name is typically the logging source. For example, the type where the logger is created:

:::code language="csharp" source="snippets/configuration/console-custom-logging/ColorConsoleLogger.cs":::

The preceding code:

- Creates a logger instance per category name.
- Checks `_getCurrentConfig().LogLevels.ContainsKey(logLevel)` in `IsEnabled`, so each `logLevel` has a unique logger. Loggers should also be enabled for all higher log levels:

:::code language="csharp" source="snippets/configuration/console-custom-logging/ColorConsoleLogger.cs" range="15-16":::

The logger is instantiated with the `name` and a `Func<ColorConsoleLoggerConfiguration>`, which returns the current config &mdash; this handles updates to the config values as monitored through the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601.OnChange%2A?displayProperty=nameWithType> callback.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> implementation checks if the `config.EventId` value is set. When `config.EventId` is not set or when it matches the exact `logEntry.EventId`, the logger logs in color.

## Custom logger provider

The `ILoggerProvider` object is responsible for creating logger instances. It's not necessary to create a logger instance per category, but it makes sense for some loggers, like NLog or log4net. This strategy allows you to choose different logging output targets per category, as in the following example:

:::code language="csharp" source="snippets/configuration/console-custom-logging/ColorConsoleLoggerProvider.cs":::

In the preceding code, <xref:Microsoft.Build.Logging.LoggerDescription.CreateLogger%2A> creates a single instance of the `ColorConsoleLogger` per category name and stores it in the [`ConcurrentDictionary<TKey,TValue>`](/dotnet/api/system.collections.concurrent.concurrentdictionary-2). Additionally, the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> interface is required to update changes to the underlying `ColorConsoleLoggerConfiguration` object.

To control the configuration of the `ColorConsoleLogger`, you define an alias on its provider:

:::code language="csharp" source="snippets/configuration/console-custom-logging/ColorConsoleLoggerProvider.cs" range="6-8" highlight="6-7":::

The `ColorConsoleLoggerProvider` class defines two class-scoped attributes:

- <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>: The `ColorConsoleLogger` type is _not supported_ in the `"browser"`.
- <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute>: Configuration sections can define options using the `"ColorConsole"` key.

The configuration can be specified with any valid [configuration provider](configuration-providers.md). Consider the following _appsettings.json_ file:

:::code language="json" source="snippets/configuration/console-custom-logging/appsettings.json":::

This configures the log levels to the following values:

- <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>: <xref:System.ConsoleColor.DarkGreen?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>: <xref:System.ConsoleColor.Cyan?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LogLevel.Error?displayProperty=nameWithType>: <xref:System.ConsoleColor.Red?displayProperty=nameWithType>

The <xref:Microsoft.Extensions.Logging.LogLevel.Information> log level is set to <xref:System.ConsoleColor.DarkGreen>, which overrides the default value set in the `ColorConsoleLoggerConfiguration` object.

## Usage and registration of the custom logger

By convention, registering services for dependency injection happens as part of the startup routine of an application. The registration occurs in the `Program` class, or could be delegated to a `Startup` class. In this example, you'll register directly from the _Program.cs_.

To add the custom logging provider and corresponding logger, add an <xref:Microsoft.Extensions.Logging.ILoggerProvider> with <xref:Microsoft.Extensions.Logging.ILoggingBuilder> from the <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.ConfigureLogging(Microsoft.Extensions.Hosting.IHostBuilder,System.Action{Microsoft.Extensions.Logging.ILoggingBuilder})?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/configuration/console-custom-logging/Program.cs" highlight="6-14":::

The `ILoggingBuilder` creates one or more `ILogger` instances. The `ILogger` instances are used by the framework to log the information.

The configuration from the _appsettings.json_ file overrides the following values:

- <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>: <xref:System.ConsoleColor.DarkCyan?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.LogLevel.Error?displayProperty=nameWithType>: <xref:System.ConsoleColor.DarkRed?displayProperty=nameWithType>

By convention, extension methods on `ILoggingBuilder` are used to register the custom provider:

:::code language="csharp" source="snippets/configuration/console-custom-logging/Extensions/ColorConsoleLoggerExtensions.cs":::

Running this simple application will render color output to the console window similar to the following image:

:::image type="content" source="media/color-console-logger.png" alt-text="Color console logger sample output":::

## See also

- [Logging in .NET](logging.md)
- [Logging providers in .NET](logging-providers.md)
- [Dependency injection in .NET](dependency-injection.md)
- [High-performance logging in .NET](high-performance-logging.md)
