---
title: Console log formatting
description: Learn how to use available console log formatting, or implement custom log formatting for your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
---

# Console log formatting

In .NET 5, support for custom formatting was added to console logs in the `Microsoft.Extensions.Logging.Console` namespace. There are three predefined formatting options available: [`Simple`](#simple), [`Systemd`](#systemd), and [`Json`](#json).

> [!IMPORTANT]
> Previously, the <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerFormat> enum allowed for selecting the desired log format, either human readable which was the `Default`, or single line which is also known as `Systemd`. However, these were **not** customizable, and are now deprecated.

In this article, you will learn about console log formatters. The sample source code demonstrates how to:

- Register a new formatter
- Select a registered formatter to use
  - Either through code, or [configuration](configuration.md)
- Implement a custom formatter
  - Update configuration via <xref:Microsoft.Extensions.Options.IOptionsMonitor%601>
  - Enable custom color formatting

[!INCLUDE [logging-samples-browser](includes/logging-samples-browser.md)]

## Register formatter

The [`Console` logging provider](logging-providers.md#console) has several predefined formatters, and exposes the ability to author your own custom formatter. To register any of the available formatters, use the corresponding `Add{Type}Console` extension method:

| Available types | Method to register type |
|--|--|
| <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Json?displayProperty=nameWithType> | <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddJsonConsole%2A?displayProperty=nameWithType> |
| <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Simple?displayProperty=nameWithType> | <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddSimpleConsole%2A?displayProperty=nameWithType> |
| <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Systemd?displayProperty=nameWithType> | <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddSystemdConsole%2A?displayProperty=nameWithType> |

### Simple

To use the `Simple` console formatter, register it with `AddSimpleConsole`:

:::code language="csharp" source="snippets/logging/console-formatter-simple/Program.cs" highlight="11-16":::

In the preceding sample source code, the <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Simple?displayProperty=nameWithType> formatter was registered. It provides logs with the ability to not only wrap information such as time and log level in each log message, but also allows for ANSI color embedding and indentation of messages.

### Systemd

The <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Systemd?displayProperty=nameWithType> console logger:

- Uses the "Syslog" log level format and severities
- Does **not** format messages with colors
- Always logs messages in a single line

This is commonly useful for containers, which often make use of `Systemd` console logging. With .NET 5, the `Simple` console logger also enables a compact version that logs in a single line, and also allows for disabling colors as shown in an earlier sample.

:::code language="csharp" source="snippets/logging/console-formatter-systemd/Program.cs" highlight="11-15":::

### Json

To write logs in a JSON format, the `Json` console formatter is used. The sample source code shows how an ASP.NET Core app might register it. Using the `webapp` template, create a new ASP.NET Core app with the [dotnet new](../tools/dotnet-new.md) command:

```dotnetcli
dotnet new webapp -o Console.ExampleFormatters.Json
```

When running the app, using the template code, you get the default log format below:

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
```

By default, the `Simple` console log formatter is selected with default configuration. You change this by calling `AddJsonConsole` in the *Program.cs*:

:::code language="csharp" source="snippets/logging/console-formatter-json/Program.cs" highlight="14-22":::

Run the app again, with the above change, the log message is now formatted as JSON:

:::code language="json" source="snippets/logging/console-formatter-json/example-output.json":::

> [!TIP]
> The `Json` console formatter, by default, logs each message in a single line. In order to make it more readable while configuring the formatter, set <xref:System.Text.Json.JsonWriterOptions.Indented?displayProperty=nameWithType> to `true`.

## Set formatter with configuration

The previous samples have shown how to register a formatter programmatically. Alternatively, this can be done with [configuration](configuration.md). Consider the previous web application sample source code, if you update the *appsettings.json* file rather than calling `ConfigureLogging` in the *Program.cs* file, you could get the same outcome. The updated `appsettings.json` file would configure the formatter as follows:

:::code language="json" source="snippets/logging/console-formatter-json/appsettings.json" highlight="14-23":::

The two key values that need to be set are `"FormatterName"` and `"FormatterOptions"`. If a formatter with the value set for `"FormatterName"` is already registered, that formatter is selected, and its properties can be configured as long as they are provided as a key inside the `"FormatterOptions"` node. The predefined formatter names are reserved under <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames>:

- <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Json?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Simple?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterNames.Systemd?displayProperty=nameWithType>

## Implement a custom formatter

To implement a custom formatter, you need to:

- Create a subclass of <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatter>, this represents your custom formatter
- Register your custom formatter with
  - <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A?displayProperty=nameWithType>
  - <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsoleFormatter%60%602(Microsoft.Extensions.Logging.ILoggingBuilder,System.Action{%60%601})?displayProperty=nameWithType>

Create an extension method to handle this for you:

:::code language="csharp" source="snippets/logging/console-formatter-custom/ConsoleLoggerExtensions.cs" highlight="10-11":::

The `CustomOptions` are defined as follows:

:::code language="csharp" source="snippets/logging/console-formatter-custom/CustomOptions.cs":::

In the preceding code, the options are a subclass of <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions>.

The `AddConsoleFormatter` API:

- Registers a subclass of `ConsoleFormatter`
- Handles configuration:
  - Uses a change token to synchronize updates, based on the [options pattern](options.md), and the [IOptionsMonitor](xref:Microsoft.Extensions.Options.IOptionsMonitor%601) interface

:::code language="csharp" source="snippets/logging/console-formatter-custom/Program.cs" highlight="11-12":::

Define a `CustomerFormatter` subclass of `ConsoleFormatter`:

:::code language="csharp" source="snippets/logging/console-formatter-custom/CustomFormatter.cs" highlight="22-38":::

The preceding `CustomFormatter.Write<TState>` API dictates what text gets wrapped around each log message. A standard `ConsoleFormatter` should be able to wrap around scopes, time stamps, and severity level of logs at a minimum. Additionally, you can encode ANSI colors in the log messages, and provide desired indentations as well. The implementation of the `CustomFormatter.Write<TState>` lacks these capabilities.

For inspiration on further customizing formatting, see the existing implementations in the `Microsoft.Extensions.Logging.Console` namespace:

- [SimpleConsoleFormatter](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Logging.Console/src/SimpleConsoleFormatter.cs).
- [SystemdConsoleFormatter](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Logging.Console/src/SystemdConsoleFormatter.cs)
- [JsonConsoleFormatter](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Logging.Console/src/JsonConsoleFormatter.cs)

### Custom configuration options

To further customize the logging extensibility, your derived <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions> class can be configured from any [configuration provider](configuration-providers.md). For example, you could use the [JSON configuration provider](configuration-providers.md#json-configuration-provider) to define your custom options. First define your <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions> subclass.

:::code language="csharp" source="snippets/logging/console-formatter-custom-with-config/CustomWrappingConsoleFormatterOptions.cs":::

The preceding console formatter options class defines two custom properties, representing a prefix and suffix. Next, define the *appsettings.json* file that will configure your console formatter options.

:::code language="json" source="snippets/logging/console-formatter-custom-with-config/appsettings.json" highlight="8,14-17":::

In the preceding JSON config file:

- The `"Logging"` node defines a `"Console"`.
- The `"Console"` node specifies a `"FormatterName"` of `"CustomTimePrefixingFormatter"`, which maps to a custom formatter.
- The `"FormatterOptions"` node defines a `"CustomPrefix"`, and `"CustomSuffix"`, as well as a few other derived options.

> [!TIP]
> The `$.Logging.Console.FormatterOptions` JSON path is reserved, and will map to a custom <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions> when added using the <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsoleFormatter%2A> extension method. This provides the ability to define custom properties, in addition to the ones available.

Consider the following `CustomDatePrefixingFormatter`:

:::code language="csharp" source="snippets/logging/console-formatter-custom-with-config/CustomTimePrefixingFormatter.cs":::

In the preceding formatter implementation:

- The `CustomWrappingConsoleFormatterOptions` are monitored for change, and updated accordingly.
- Messages that are written are wrapped with the configured prefix, and suffix.
- A timestamp is added after the prefix, but before the message using the configured <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions.UseUtcTimestamp?displayProperty=nameWithType> and <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions.TimestampFormat%2A?displayProperty=nameWithType> values.

To use custom configuration options, with custom formatter implementations, add when calling <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.ConfigureLogging(Microsoft.Extensions.Hosting.IHostBuilder,System.Action{Microsoft.Extensions.Hosting.HostBuilderContext,Microsoft.Extensions.Logging.ILoggingBuilder})>.

:::code language="csharp" source="snippets/logging/console-formatter-custom-with-config/Program.cs" highlight="14-16":::

The following console output is similar to what you might expect to see from using this `CustomTimePrefixingFormatter`.

```console
|-<[ 15:03:15.6179 Hello World! ]>-|
|-<[ 15:03:15.6347 The .NET developer community happily welcomes you. ]>-|
```

## Implement custom color formatting

In order to properly enable color capabilities in your custom logging formatter, you can extend the <xref:Microsoft.Extensions.Logging.Console.SimpleConsoleFormatterOptions> as it has a <xref:Microsoft.Extensions.Logging.Console.SimpleConsoleFormatterOptions.ColorBehavior?displayProperty=nameWithType> property that can be useful for enabling colors in logs.

Create a `CustomColorOptions` that derives from `SimpleConsoleFormatterOptions`:

:::code language="csharp" source="snippets/logging/console-formatter-custom/CustomColorOptions.cs" highlight="5":::

Next, write some extension methods in a `TextWriterExtensions` class that allow for conveniently embedding ANSI coded colors within formatted log messages:

:::code language="csharp" source="snippets/logging/console-formatter-custom/TextWriterExtensions.cs":::

A custom color formatter that handles applying custom colors could be defined as follows:

:::code language="csharp" source="snippets/logging/console-formatter-custom/CustomColorFormatter.cs" highlight="13-16,50-63":::

When you run the application, the logs will show the `CustomPrefix` message in the color green when `FormatterOptions.ColorBehavior` is `Enabled`.

> [!NOTE]
> When <xref:Microsoft.Extensions.Logging.Console.LoggerColorBehavior> is `Disabled`, log messages do _not_ interpret embedded ANSI color codes within log messages. Instead, they output the raw message. For example, consider the following:
>
> ```csharp
> logger.LogInformation("Random log \x1B[42mwith green background\x1B[49m message");
> ```
>
> This would output the verbatim string, and it is _not_ colorized.
>
> ```output
> Random log \x1B[42mwith green background\x1B[49m message
> ```

## See also

- [Logging in .NET](logging.md)
- [Implement a custom logging provider in .NET](custom-logging-provider.md)
- [High-performance logging in .NET](high-performance-logging.md)
