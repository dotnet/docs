---
title: Compile-time logging source generation
description: Learn how to use compile-time source generation for logging, and the LoggerMessageAttribute with .NET.
author: maryamariyan
ms.author: maariyan
ms.date: 05/06/2021
---

# Compile-time logging source generation

With .NET 6, the `LoggerMessageAttribute` was introduced. This attribute is part of the `Microsoft.Extensions.Logging` namespace, and when used it will source generate performant logging APIs. The source generation logging support is designed to deliver a highly-usable and highly-performant logging solution for modern .NET applications. The auto-generated source code relies on the <xref:Microsoft.Extensions.Logging.ILogger> interface in conjunction with <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A?displayProperty=nameWithType> functionality.

The source generator is triggered when `LoggerMessageAttribute` is used on `partial` logging methods. When triggered, it is either able to autogenerate the implementation of the `partial` methods it's decorating, or produce compile-time diagnostics with hints about proper usage. The compile-time logging solution is typically considerably faster at runtime than existing logging approaches. It does this by eliminating boxing, temporary allocations, and copies to the maximum extent possible.

## Basic usage

To use the `LoggerMessageAttribute`, the consuming class and method need to be `partial`. The code generator is triggered at compile-time, and generates an implementation of the `partial` method.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger, string hostName);
}
```

In the preceding example, the logging method is `static` and the log level is specified in the attribute definition. When using the attribute in a static context, the `ILogger` instance is required as a parameter. You may choose to use the attribute in a non-static context as well. Consider the following example where the logging method is declared as an instance method. In this context, the logging method gets the logger by accessing an `ILogger` field in the containing class.

```csharp
public class InstanceLoggingExample
{
    private readonly ILogger _logger;

    public InstanceLoggingExample(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{hostName}`")]
    public partial void CouldNotOpenSocket(string hostName);
}
```

Sometimes, the log level needs to be dynamic rather than statically built into the code. You can do this by omitting the log level from the attribute and instead requiring it as a parameter to the logging method.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Message = "Could not open socket to `{hostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger,
        LogLevel level, // Dynamic log level as parameter, rather than defined in attribute.
        string hostName);
}
```

You can omit the logging message and <xref:System.String.Empty?displayProperty=nameWithType> will be provided for the message. The state will contain the arguments, and is formatted as key value pairs.

```csharp
using System.Text.Json;
using Microsoft.Extensions.Logging;

ILogger<SampleObject> logger = LoggerFactory.Create(
    builder =>
    builder.AddJsonConsole(
        options =>
        options.JsonWriterOptions = new JsonWriterOptions()
        {
            Indented = true
        }))
    .CreateLogger<SampleObject>();

logger.CustomLogEvent(LogLevel.Information, "Liana", "California");

public static partial class SampleObject
{
    [LoggerMessage(EventId = 23)]
    public static partial void CustomLogEvent(
        this ILogger logger, LogLevel logLevel,
        string name, string state);
}
```

Consider the example logging output when using the `JsonConsole` formatter.

```json
{
  "EventId": 23,
  "LogLevel": "Information",
  "Category": "ConsoleApp.SampleLogger",
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

- Logging methods must be `static`, `partial`, and return `void`.
- Logging method names must *not* start with an underscore.
- Parameter names of logging methods must *not* start with an underscore.
- Logging methods may *not* be defined in nested type.
- Logging methods *cannot* be generic.

Also, the code generation model depends on code being compiled with a modern C# compiler, version 9 or later. The C# 9.0 compiler became available with .NET 5.0. To upgrade to a modern C# compiler, edit your project file and add:

```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
</PropertyGroup>
```

### Sample with exception as argument to log method

Since the <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> API signature accepts the <xref:Microsoft.Extensions.Logging.LogLevel> and optionally an <xref:System.Exception> per log call:

```csharp
using System;
using Microsoft.Extensions.Logging;

public partial interface ILogger
{
    void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter);
}
```

Therefore, as a general rule, the first instance of `ILogger`, `LogLevel`, and `Exception` are treated specially in the log method signature of the source generator. Subsequent instances are treated like normal parameters to the message template:

```csharp
// This is a valid attribute usage
[LoggerMessage(
    EventId = 110, Level = LogLevel.Debug, Message = "M1 {ex3} {ex2}")]
public static partial void ValidLogMethod(
    ILogger logger,
    Exception ex,
    Exception ex2,
    Exception ex3);

// This causes a warning
[LoggerMessage(
    EventId = 0, Level = LogLevel.Debug, Message = "M1 {ex} {ex2}")]
public static partial void WarningLogMethod(
    ILogger logger,
    Exception ex,
    Exception ex2);
```

> [!IMPORTANT]
> The warnings emitted provide details as to the correct usage of the `LoggerMessageAttribute`. In the preceding example the `WarningLogMethod` will report a `DiagnosticSeverity.Warning` of `SYSLIB0025`.
>
> ```console
> Don't include a template for ex in the logging message since it is implicitly taken care of
>

### Case-insensitive template name support

The generator uses case-insensitive comparison between parameters in the message template and log message argument names so when the ILogger enumerates the state, the argument will be picked up by message template, which can make the logs nicer to consume:

```csharp
public partial class LoggingSample6
{
    private readonly ILogger _logger;

    public LoggingSample6(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 10,
        Level = LogLevel.Information,
        Message = "Welcome to {City} {Province}!")]
    public partial void LogMethodSupportsPascalCasingOfNames(
        string city, string province);

    public void TestLogging()
    {
        LogMethodSupportsPascalCasingOfNames("Vancouver", "BC");
    }
}
```

Consider the example logging output when using the `JsonConsole` formatter.

```json
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

### Indeterminate parameter order

There is no constraint in the ordering at this point. So the user could define `ILogger` as the last argument for example:

```csharp
[LoggerMessage(
    EventId = 110,
    Level = LogLevel.Debug,
    Message = "M1 {ex3} {ex2}")]
static partial void LogMethod(
    Exception ex,
    Exception ex2,
    Exception ex3,
    ILogger logger); // 😲
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

    [LoggerMessage(
        EventId = 20,
        Level = LogLevel.Critical,
        Message = "Value is {value:E}")]
    public static partial void UsingFormatSpecifier(
        ILogger logger, double value);

    [LoggerMessage(
        EventId = 9,
        Level = LogLevel.Trace,
        Message = "Fixed message",
        EventName = "CustomEventName")]
    public partial void LogWithCustomEventName();

    [LoggerMessage(
        EventId = 10,
        Message = "Welcome to {city} {province}!")]
    public partial void LogWithDynamicLogLevel(
        string city, LogLevel level, string province);

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

Consider the example logging output when using the `SimpleConsole` formatter.

```console
trce: LoggingExample[9]
      Fixed message
warn: LoggingExample[10]
      Welcome to Vancouver BC!
info: LoggingExample[10]
      Welcome to Vancouver BC!
crit: LoggingExample[20]
      Value is 1.234568E+004
```

Consider the example logging output when using the `JsonConsole` formatter.

```json
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

## Summary

With the advent of C# source generators, writing highly-performant logging APIs is much easier. Using the source generator approach has several key benefits:

- Allows the logging structure to be preserved and enables the exact format syntax required by [Message Templates](https://messagetemplates.org).
- Allows supplying alternative names for the template placeholders and using format specifiers.
- Allows the passing of all original data as-is, without any complication around how it's stored prior to something being done with it (other than creating a `string`).
- Provides logging-specific diagnostics, emits warnings for duplicate event ids.

Additionally, there are benefits over manually using <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A?displayProperty=nameWithType>:

- Shorter and simpler syntax, declarative attribute usage rather than coding boilerplate.
- Guided developer experience, the generator gives warnings to help developers do the right thing.
- Support for an arbitrary number of logging parameters. `LoggerMessage.Define` supports a max of six.
- Support for dynamic log level, this is not possible with `LoggerMessage.Define` alone.

### Known limitations

There are a few known limitations with the underlying implementation details. The first version of the generator uses `LoggerMessage.Define` where possible. The following issues are tracking potential improvements to the `Define` APIs, which could allow for better support of the source generator.

- Support for an arbitrary # of logging parameters and dynamic logging

  Currently the maximum number of parameters allowed from the `LoggerMessage.Define` is six. To mitigate this either the source generator would need to fallback to another approach, or we would need to add more `Define` overloads for the generator to use. The issue also tracks adding APIs to allow `Define` with supporting dynamic logging as well. For more information, see [Add `LoggerMessage.Define` overloads accepting up to 14 arguments](https://github.com/dotnet/runtime/issues/50913).

- More robust support for handling message template parameters

  The code generation using `LoggerMessage.Define` does not currently handle message templates when the number of parameters doesn't match the specified template parameter count. This is true regardless of whether the parameters used in the template are the same. This could be something that the source generator supports as it evolves. For more information, see [`LoggerMessage.Define` doesn't support repeating the same named parameter in the message template](https://github.com/dotnet/runtime/issues/51054).

## See also

- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
- [Console log formatting](console-log-formatter.md)
