---
title: LoggerMessageAttribute and compile-time logging source generation
description: Learn how to use compile-time source generation, or use LoggerMessageAttribute for your .NET applications.
author: maryamariyan
ms.author: maariyan
ms.date: 05/05/2021
---

# LoggerMessageAttribute

As of .NET 6 Preview 4, we instroduced `LoggerMessageAttribute` to help auto-generated perfomant logging APIs using `Microsoft.Extensions.Logging` namespace. The soucrce generation logging support is designed to deliver a highly-usable and high-performance logging solution for modern .NET applications. We leverage the base ILogger model with `LoggerMessage.Define` exposed by .NET and augment it to simplify use and improve performance.

The source generator gets triggered with a `LoggerMessageAttribute` on partial logging methods, and is able to either autogenerate the implementation of these partial methods, or produces compile-time diagnostics hinting to proper usage of this logging approach.

The compile-time logging solution is typically considerably faster at runtime than existing logging approaches. It does this by eliminating boxing, temporary allocations, and copies to the maximum extent possible.

Below is an example class with one declared logging method. The method is marked with an attribute and is declared static and partial. The code generator kicks in at build time and supplies an implementation of this partial method.

```csharp
static partial class Log
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Critical, Message = "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(ILogger logger, string hostName);
}
```

The above sample shows the canonical use of the logging source generator, where the logging method is static and the log level is specified in the attribute definition. There are other forms possible too. For example, in the following example the logging method is declared as an instance method. In this form, the logging method gets the logger by accessing an `ILogger` field in the containing class.

```csharp
class MyLogWrapper
{
    private readonly ILogger _logger;

    public MyLogWrapper(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(EventId = 0, Level = LogLevel.Critical, Message = "Could not open socket to `{hostName}`")]
    public partial void CouldNotOpenSocket(string hostName);
}

```

Sometimes, the logging level needs to be a dynamic property rather than being statically built into the code. You can do this by omitting the logging level from the attribute and instead supplying it as an argument to the logging method:

```csharp
static partial class Log
{
    [LoggerMessage(EventId = 0, Message = "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(ILogger logger, LogLevel level, string hostName);
}
```

You can omit the logging message and an empty string will be provided for the message but the state will contain the arguments and formats them as key value pairs.

```csharp
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace LoggingGeneratorSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LoggerFactory.Create(builder =>
            {
                builder.AddJsonConsole(o => 
                o.JsonWriterOptions = new JsonWriterOptions()
                {
                    Indented = true
                });
            }).CreateLogger<Program>();

            logger.LogMethod(LogLevel.Information, "Liana", "California");
        }
    }

    public static partial class MyPoco
    {
        [LoggerMessage(EventId = 23)]
        public static partial void LogMethod(this ILogger logger, LogLevel logLevel, string name, string state);
    }
}
```

Outputs:
```
{
  "EventId": 23,
  "LogLevel": "Information",
  "Category": "ConsoleApp66.Program",
  "Message": "",
  "State": {
    "Message": "",
    "name": "Liana",
    "state": "California",
    "{OriginalFormat}": ""
  }
}
```

## Requirements

Logging methods have some constraints which must be followed:

- Logging methods must be static, partial, and return void.
- Logging method names must not start with an underscore.
- Parameter names of logging methods must not start with an underscore.
- Logging methods may not be defined in nested type.
- Logging methods cannot be generic.

Also, the code generation model depends on code being compiled with a modern C# compiler, version 9 or later. The C# 9.0 compiler became available with .NET 5.0. To upgrade to a modern C# compiler, edit your project file and add:

```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
</PropertyGroup>
```

#### Sample with exception as argument to log method

Since the `ILogger.Log` API signature takes log level and optionally an exception per log call:

```csharp
public partial interface ILogger
{
    void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, System.Exception? exception, System.Func<TState, System.Exception?, string> formatter);
}
```

Therefore, as a general rule, the first instance of `ILogger`, `LogLevel`, and `Exception` are treated specially in the log method signature of the source generator. Subsequent instances are treated like normal arguments to the message template:

```csharp
// below works
[LoggerMessage(EventId = 110, Level = LogLevel.Debug, Message = "M1 {ex3} {ex2}")]
static partial void LogMethod(ILogger logger, System.Exception ex, System.Exception ex2, System.Exception ex3);

// but this warns:
// DiagnosticSeverity.Warning - SYSLIB0025: Don't include a template for ex in the logging message since it is implicitly taken care of
[LoggerMessage(EventId = 0, Level = LogLevel.Debug, Message = "M1 {ex} {ex2}")]
static partial void LogMethod(ILogger logger, System.Exception ex, System.Exception ex2);
```

### Case-insensitive parameter/template name support

The generator does case-insensitive comparison between parameters in message template and log message argument names so when the ILogger enumerates the state, the argument will be picked up by message template, which can make the logs nicer to consume:

```csharp
public partial class LoggingSample6
{
    private readonly ILogger _logger;

    public LoggingSample6(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(EventId = 10, Level = LogLevel.Information, Message = "Welcome to {City} {Province}!")]
    public partial void LogMethodSupportsPascalCasingOfNames(string city, string province);

    public void TestLogging()
    {
        LogMethodSupportsPascalCasingOfNames("Vancouver", "BC");
    }
}
```

Json console output (notice the log arguments become uppercase):
```
{
  "EventId": 13,
  "LogLevel": "Information",
  "Category": "LoggingExample",
  "Message": "Welcome to Vancouver BC!",
  "State": {
    "Message": "Welcome to Vancouver BC!",
    "City": "Vancouver",
    "Province": "BC",
    "{OriginalFormat}": "Welcome to {city} {province}!"
  }
}
```
### Order of arguments do not matter

There is no constraint in the ordering at this point. So the user could define `ILogger` as the last argument for example:
```csharp
[LoggerMessage(EventId = 110, Level = LogLevel.Debug, Message = "M1 {ex3} {ex2}")]
static partial void LogMethod(System.Exception ex, System.Exception ex2, System.Exception ex3, ILogger logger);
```

### Miscellaneous logging samples using the generator

The samples below show we could:

- `LogWithCustomEventName`: retrieve event name via `LoggerMessage` attribute. 
- `LogWithDynamicLogLevel`: set log level dynamically, to allow log level to be set based on configuration input.
- `UsingFormatSpecifier`: use format specifiers to format logging parameters.

```csharp
public partial class LoggingSample5
{
    private readonly ILogger _logger;

    public LoggingSample5(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(EventId = 20, Level = LogLevel.Critical, Message = "Value is {value:E}")]
    public static partial void UsingFormatSpecifier(ILogger logger, double value);

    [LoggerMessage(EventId = 9, Level = LogLevel.Trace, Message = "Fixed message", EventName = "CustomEventName")]
    public partial void LogWithCustomEventName();

    [LoggerMessage(EventId = 10, Message = "Welcome to {city} {province}!")]
    public partial void LogWithDynamicLogLevel(string city, LogLevel level, string province);

    public void TestLogging()
    {
        LogWithCustomEventName();
        LogWithDynamicLogLevel("Vancouver", Level = LogLevel.Warning, "BC");
        LogWithDynamicLogLevel("Vancouver", Level = LogLevel.Information, "BC");
        double val = 12345.6789;
        Log.UsingFormatSpecifier(logger, val);
    }
}
```
output to `TestLogging()` using SimpleConsole:
```
trce: LoggingExample[9]
      Fixed message
warn: LoggingExample[10]
      Welcome to Vancouver BC!
info: LoggingExample[10]
      Welcome to Vancouver BC!
crit: LoggingExample[20]
      Value is 1.234568E+004
```

same console logs formatted using JsonConsole:
```
{
  "EventId": 9,
  "LogLevel": "Trace",
  "Category": "LoggingExample",
  "Message": "Fixed message",
  "State": {
    "Message": "Fixed message",
    "{OriginalFormat}": "Fixed message"
  }
}
{
  "EventId": 10,
  "LogLevel": "Warning",
  "Category": "LoggingExample",
  "Message": "Welcome to Vancouver BC!",
  "State": {
    "Message": "Welcome to Vancouver BC!",
    "city": "Vancouver",
    "province": "BC",
    "{OriginalFormat}": "Welcome to {city} {province}!"
  }
}
{
  "EventId": 10,
  "LogLevel": "Information",
  "Category": "LoggingExample",
  "Message": "Welcome to Vancouver BC!",
  "State": {
    "Message": "Welcome to Vancouver BC!",
    "city": "Vancouver",
    "province": "BC",
    "{OriginalFormat}": "Welcome to {city} {province}!"
  }
}
{
  "EventId": 20,
  "LogLevel": "Critical",
  "Category": "LoggingExample",
  "Message": "Value is 1.234568E+004",
  "State": {
    "Message": "Value is 1.234568E+004",
    "value": 12345.6789,
    "{OriginalFormat}": "Value is {value:E}"
  }
}
```

### Benefits with the source generator approach:

- Allows the logging structure to be preserved and enables the exact format syntax required by https://messagetemplates.org/
- Allows supplying alternative names for the holes and using format specifiers.
- Allows to pass all of original data as-is without any complication around how it's stored prior to something being done with it other than creating a string.
- Provides logging-specific diagnostics, e.g. it emits warnings for duplicate event ids.

#### Benefits compared to using LoggerMessage.Define directly

- Shorter and simpler syntax than current approach
- Guided developer experience - the generator gives warnings to help developers do the right thing
- Support for an arbitrary # of logging parameters. LoggerMessage.Define tops out at 6
- Support for dynamic log level, current approach doesn't support this

### Known issues/limitations

The first version of the generator uses `LoggerMessage.Define` under the hood where possible. The issues below track potential improvements to make on `Define` APIs to allow better support in the source generator.

- _Support for an arbitrary # of logging parameters and dynamic logging_

Currently maximum number of parameters allowed via `LoggerMessage.Define` (Refer to [dotnet/runtime#50913](https://github.com/dotnet/runtime/issues/50913)) is 6. To mitigate this either the source generator would need to fallback to another approach, or we would need to add more `Define` overloads for the generator to use. The issue also tracks adding APIs to allow `Define` with supporting dynamic logging as well.

- _More robust support for handling message template parameters._

The code generation using `LoggerMessage.Define` does not currently handle message templates when number of parameters do not match the specified template parameters even if the parameters used in the template are the same (Refer to [dotnet/runtime#51054](https://github.com/dotnet/runtime/issues/51054)). This could be something that the source generator supports as it evolves further.

## See also

- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
