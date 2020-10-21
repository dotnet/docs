

# Console Log Formatting

In .NET 5.0 we added support for custom formatting of console logs in Microsoft.Extensions.Logging.Console and three available in-box: simple, systemd, and json.

## Motivation (Why needed)

Traditionally in extensions ConsoleLoggerFormat enum allowed for toggling logging format between Systemd (single line) and Default (human readable) but they were not customizable and now have become deprecated. In environments where folks scrape/redirect console logs for structured logging, they want to know how to enable JSON formatted logs. 

## Abstract: Write an abstract. In one **short** paragraph, describe what this topic will cover.

This article describes console log formatters. It goes through samples using the in-box console formatters, showing examples on how to register a new formatter, how to select a registered formatter to use (via both code and config) and how to author (implement) a custom formatter. While going through the custom console formatting topic we discuss more advanced topics such as how to ensure custom console logging gets updated configuration via IOptionsMonitor, and how to implement a color enabled custom formatter.

## Console log formatting APIs

### What is a console formatter? (covered below)

### what are the built-in console log formatters? (covered below)

### Register new formatter (covered below)

The Console Logger provides built-in formatters and the ability author your own custom formatter. New APIs such as `AddSimpleConsole`, `AddSystemdConsole`, and `AddJsonConsole` were introduced in .NET 5.0 to provide different built-in formatting options for log messages to show in console. 

#### Simple

Sample below shows how to configure the simple console formatter:

```c#
using Microsoft.Extensions.Logging.Console;

namespace ConsoleApp46
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole(o => {
                    o.IncludeScopes = true;
                    o.SingleLine = true;
                    o.TimestampFormat = "hh:mm:ss ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("[scope is enabled]"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("Logs contain timestamp and log level.");
                logger.LogInformation("Each log message is fit in a single line.");
            }
        }
    }
}
```

The `ConsoleFormatterName.Simple` formatter provides logs with ability to not only wrap information such as time and log level in each log message but also allows for ANSI color embedding and indentation of messages. 

#### Systemd

The Systemd console logger uses Syslog log level format and severities, does not format messages with colors, and always logs messages in a single line. This has especially been useful for containers which normally use Systemd console logging. Now with .NET 5.0, the Simple console logger also enables a compact version that logs in a single line and also allows for disabling colors as shown in an earlier sample.

```c#
using Microsoft.Extensions.Logging.Console;

namespace ConsoleApp46
{
    class Program
    {
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSystemdConsole(o => {
                    o.IncludeScopes = true;
                    o.TimestampFormat = "hh:mm:ss ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("[scope is enabled]"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("Logs contain timestamp and log level.");
                logger.LogInformation("Systemd console logs never provide color options.");
                logger.LogInformation("Systemd console logs always appear in a single line.");
            }
        }
    }
}
```

#### Json

The .NET community had long requested for a built-in performant console logger that writes logs in a Json format. The code  below shows a console logging sample with ASP.NET Core sample. For example using template ASP.NET Core application:

```
dotnet new webapp -o SampleWebApp
```

When running the app, using the template code, we get the default log format below:

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
```

By default, the Simple console log formatter is selected with default configuration. To change from default, in Program.cs as seen below we could configure logging by adding `AddJsonConsole` which allows to select and configure the Json console formatter:

```c#
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.WebEncoders.Testing;

namespace SampleWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddJsonConsole(o =>
                    {
                        o.IncludeScopes = false;
                        o.TimestampFormat = "hh:mm:ss ";
                        o.JsonWriterOptions = new JsonWriterOptions()
                        {
                            Encoder = JavaScriptTestEncoder.UnsafeRelaxedJsonEscaping, // TODO: 2
                            Indented = true
                        };
                    });
                });
    }
}
```

When running the app again, with the above change, the log message would look something like the snippet shown below:

```
{
  "Timestamp": "09:08:33 ",
  "EventId": 0,
  "LogLevel": "Information",
  "Category": "Microsoft.Hosting.Lifetime",
  "Message": "Now listening on: https://localhost:5001",
  "State": {
    "Message": "Now listening on: https://localhost:5001",
    "address": "https://localhost:5001",
    "{OriginalFormat}": "Now listening on: {address}"
  }
}
```

Json console formatter by default logs each message in a single line, in order to make it more readable while configuring the formatter, we set Indented property on JsonWriterOptions to true.

### How to select which formatter to use (via both code and config)?

So far the samples showed how to register a formatter via code, but another way this can be done is via configuration. Looking back at the ASP.NET Core application sample, if we update the `appsettings.json` file rather than adding ConfigureLogging in Program.cs we could get the same outcome. Here's what we would add in the `appsettings.json` file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    },
    "Console": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
      },
      "FormatterName": "json",
      "FormatterOptions": {
        "SingleLine" : true,
        "IncludeScopes": true,
        "TimestampFormat": "HH:mm:ss ",
        "UseUtcTimestamp": true,
        "JsonWriterOptions": {
          "Indented": true,
        }
      }
    }
  },
  "AllowedHosts": "*"
}
```

The two key values that need to be set are "FormatterName" and "FormatterOptions". If a formatter with the value set for "FormatterName" is already registered, that formatter would get selected, and its properties can be configured as long as they are provided as key inside the "FormatterOptions" element. The built-in formatter names are reserved under [ConsoleFormatterName](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.console.consoleformatternames?view=dotnet-plat-ext-5.0) (json, simple and systemd). It is also possible to register a custom formatter. In a later section we discuss that topic in more detail.

### How do I author a new formatter?

Log formatters need to be both registered (done by AddConsoleFormatter) and selected as the console formatter (done by AddConsole overloads) via the LoggingBuilder:

```c#
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace SampleConsoleApp
{
    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddCustomFormatter(this ILoggingBuilder builder, Action<CustomOptions> configure)
        {
            return builder.AddConsole(o => { o.FormatterName = "customName"; })
                .AddConsoleFormatter<CustomFormatter, CustomOptions>(configure);
        }
    }

    public class CustomOptions : ConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
    }
}
```

The `AddConsoleFormatter` API registers a ConsoleFormatter (in this example the CustomFormatter) along with configuration and change token which keeps the formatter in sync with code and configuration updates to FormatterOptions properties (in this example CustomOptions).

```c#
namespace SampleConsoleApp
{
    class Program  
    {
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddCustomFormatter(o =>
                {
                    o.CustomPrefix = " ~~~~~ ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("TODO: Add logic to enable scopes"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("TODO: Add logic to enable timestamp and log level info.");
            }
        }
    }
}
```

The next piece is to implement the CustomFormatter. A very lightweight implementation is available below:

```c# 
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace SampleConsoleApp
{
    public class CustomFormatter : ConsoleFormatter, IDisposable
    {
        private IDisposable _optionsReloadToken;

        public CustomFormatter(IOptionsMonitor<CustomOptions> options)
            // case insensitive name for the formatter
            : base("customName")
        {
            ReloadLoggerOptions(options.CurrentValue);
            _optionsReloadToken = options.OnChange(ReloadLoggerOptions);
        }

        private void ReloadLoggerOptions(CustomOptions options)
        {
            FormatterOptions = options;
        }

        public CustomOptions FormatterOptions { get; set; }
        public void Dispose()
        {
            _optionsReloadToken?.Dispose();
        }

        public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider scopeProvider, TextWriter textWriter)
        {
            string message = logEntry.Formatter(logEntry.State, logEntry.Exception);
            if (logEntry.Exception == null && message == null)
            {
                return;
            }
            CustomLogicGoesHere(textWriter);
            textWriter.WriteLine(message);
        }

        private void CustomLogicGoesHere(TextWriter textWriter)
        {
            textWriter.Write(FormatterOptions.CustomPrefix);
        }
    }
}
```

The above `CustomFormatter.Write<TState>` API dictates what text gets wrapped around each log message. A standard ConsoleFormatter, same as those provided in in the box like JsonConsoleFormatter, should be able to wrap around scopes, time stats and severity level of logs at least. Additionally they may be able to encode ANSI colors in the log messages or provide proper indentations as well. The above implementation for `CustomFormatter.Write<TState>` lacks these capabilities but is mainly to try out a hello world sample on custom console log formatting. To learn more about how to enable/customize scope/time/severity and optionally indentation/color capabilities take a deeper look at the implementation of the different console formatters available in the box in Microsoft.Extensions.Logging.Console, namely: [JsonConsoleFormatter](https://github.com/dotnet/runtime/blob/master/src/libraries/Microsoft.Extensions.Logging.Console/src/JsonConsoleFormatter.cs), and [SimpleConsoleFormatter](https://github.com/dotnet/runtime/blob/master/src/libraries/Microsoft.Extensions.Logging.Console/src/SimpleConsoleFormatter.cs).

#### Custom Formatting with Color capabilities

In order to properly enable color capabilities in your custom console logger, you may have its FormatterOptions derive from `SimpleConsoleFormatterOptions` as it has a `LoggerColorBehavior` property that can be useful for enabling colors in logs.

In your working sample from previous section, first update CustomOptions to derive from SimpleConsoleFormatterOptions:

```c#
    public class CustomOptions : SimpleConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
    }
```

Then update the CustomFormatter methods below:

```c#
// TODO: Add DisableColors:
        private bool DisableColors =>
          FormatterOptions.ColorBehavior == LoggerColorBehavior.Disabled ||
          (FormatterOptions.ColorBehavior == LoggerColorBehavior.Default && System.Console.IsOutputRedirected);

        private void CustomLogicGoesHere(TextWriter textWriter)
        {
            if (DisableColors)
            {
                textWriter.Write(FormatterOptions.CustomPrefix);
            }
            else
            {
                textWriter.WriteWithColor(FormatterOptions.CustomPrefix, ConsoleColor.Black, ConsoleColor.Green);
            }
        }
```

In order to remove the squiggly on `WriteColorMessage` add the below helper methods as well. These extension methods in `TextWriterExtensions` allow for conveniently embedding ANSI coded colors within formatted log messages:

```c#
using System;
using System.IO;

namespace SampleConsoleApp
{
    public static class TextWriterExtensions
    {
        public static void WriteWithColor(this TextWriter textWriter, string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            // Order: backgroundcolor, foregroundcolor, Message, reset foregroundcolor, reset backgroundcolor
            if (background.HasValue)
            {
                textWriter.Write(GetBackgroundColorEscapeCode(background.Value));
            }
            if (foreground.HasValue)
            {
                textWriter.Write(GetForegroundColorEscapeCode(foreground.Value));
            }
            textWriter.WriteLine(message);
            if (foreground.HasValue)
            {
                textWriter.Write(DefaultForegroundColor); // reset to default foreground color
            }
            if (background.HasValue)
            {
                textWriter.Write(DefaultBackgroundColor); // reset to the background color
            }
        }
        internal const string DefaultForegroundColor = "\x1B[39m\x1B[22m"; // reset to default foreground color
        internal const string DefaultBackgroundColor = "\x1B[49m"; // reset to the background color
        internal static string GetForegroundColorEscapeCode(ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => "\x1B[30m",
                ConsoleColor.DarkRed => "\x1B[31m",
                ConsoleColor.DarkGreen => "\x1B[32m",
                ConsoleColor.DarkYellow => "\x1B[33m",
                ConsoleColor.DarkBlue => "\x1B[34m",
                ConsoleColor.DarkMagenta => "\x1B[35m",
                ConsoleColor.DarkCyan => "\x1B[36m",
                ConsoleColor.Gray => "\x1B[37m",
                ConsoleColor.Red => "\x1B[1m\x1B[31m",
                ConsoleColor.Green => "\x1B[1m\x1B[32m",
                ConsoleColor.Yellow => "\x1B[1m\x1B[33m",
                ConsoleColor.Blue => "\x1B[1m\x1B[34m",
                ConsoleColor.Magenta => "\x1B[1m\x1B[35m",
                ConsoleColor.Cyan => "\x1B[1m\x1B[36m",
                ConsoleColor.White => "\x1B[1m\x1B[37m",
                _ => DefaultForegroundColor // default foreground color
            };
        }

        internal static string GetBackgroundColorEscapeCode(ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => "\x1B[40m",
                ConsoleColor.DarkRed => "\x1B[41m",
                ConsoleColor.DarkGreen => "\x1B[42m",
                ConsoleColor.DarkYellow => "\x1B[43m",
                ConsoleColor.DarkBlue => "\x1B[44m",
                ConsoleColor.DarkMagenta => "\x1B[45m",
                ConsoleColor.DarkCyan => "\x1B[46m",
                ConsoleColor.Gray => "\x1B[47m",
                _ => DefaultBackgroundColor // Use default background color
            };
        }
    }
}
```

When you run your application again, the logs would show `CustomPrefix` message in green when FormatterOptions.ColorBehavior is not disabled. So for example, when configuring options in `AddCustomFormatter` below, when color behavior is set to disabled, the the same log prefix will no longer be shown in green.



