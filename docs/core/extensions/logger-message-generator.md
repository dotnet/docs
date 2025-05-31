---
title: Compile-time logging source generation
description: Learn how to use the LoggerMessageAttribute and compile-time source generation for logging in .NET.
ms.date: 06/21/2024
---

# Compile-time logging source generation

.NET 6 introduces the `LoggerMessageAttribute` type. This attribute is part of the `Microsoft.Extensions.Logging` namespace, and when used, it source-generates performant logging APIs. The source-generation logging support is designed to deliver a highly usable and highly performant logging solution for modern .NET applications. The auto-generated source code relies on the <xref:Microsoft.Extensions.Logging.ILogger> interface in conjunction with <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A?displayProperty=nameWithType> functionality.

The source generator is triggered when `LoggerMessageAttribute` is used on `partial` logging methods. When triggered, it is either able to autogenerate the implementation of the `partial` methods it's decorating, or produce compile-time diagnostics with hints about proper usage. The compile-time logging solution is typically considerably faster at run time than existing logging approaches. It achieves this by eliminating boxing, temporary allocations, and copies to the maximum extent possible.

## Basic usage

To use the `LoggerMessageAttribute`, the consuming class and method need to be `partial`. The code generator is triggered at compile time, and generates an implementation of the `partial` method.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger, string hostName);
}
```

In the preceding example, the logging method is `static` and the log level is specified in the attribute definition. When using the attribute in a static context, either the `ILogger` instance is required as a parameter, or modify the definition to use the `this` keyword to define the method as an extension method.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public static partial void CouldNotOpenSocket(
        this ILogger logger, string hostName);
}
```

You may choose to use the attribute in a non-static context as well. Consider the following example where the logging method is declared as an instance method. In this context, the logging method gets the logger by accessing an `ILogger` field in the containing class.

```csharp
public partial class InstanceLoggingExample
{
    private readonly ILogger _logger;

    public InstanceLoggingExample(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public partial void CouldNotOpenSocket(string hostName);
}
```

Starting with .NET 9, the logging method can additionally get the logger from an `ILogger` primary constructor parameter in the containing class.

```csharp
public partial class InstanceLoggingExample(ILogger logger)
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Critical,
        Message = "Could not open socket to `{HostName}`")]
    public partial void CouldNotOpenSocket(string hostName);
}
```

If there is both an `ILogger` field and a primary constructor parameter, the logging method will get the logger from the field.

Sometimes, the log level needs to be dynamic rather than statically built into the code. You can do this by omitting the log level from the attribute and instead requiring it as a parameter to the logging method.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 0,
        Message = "Could not open socket to `{HostName}`")]
    public static partial void CouldNotOpenSocket(
        ILogger logger,
        LogLevel level, /* Dynamic log level as parameter, rather than defined in attribute. */
        string hostName);
}
```

You can omit the logging message and <xref:System.String.Empty?displayProperty=nameWithType> will be provided for the message. The state will contain the arguments, formatted as key-value pairs.

:::code source="snippets/logging/logger-message-generator/Program.cs":::

Consider the example logging output when using the `JsonConsole` formatter.

```json
{
  "EventId": 23,
  "LogLevel": "Information",
  "Category": "\u003CProgram\u003EF...9CB42__SampleObject",
  "Message": "Liana lives in Seattle.",
  "State": {
    "Message": "Liana lives in Seattle.",
    "name": "Liana",
    "city": "Seattle",
    "{OriginalFormat}": "{Name} lives in {City}."
  }
}
```

## Log method constraints

When using the `LoggerMessageAttribute` on logging methods, some constraints must be followed:

- Logging methods must be `partial` and return `void`.
- Logging method names must *not* start with an underscore.
- Parameter names of logging methods must *not* start with an underscore.
- Logging methods *cannot* be generic.
- If a logging method is `static`, the `ILogger` instance is required as a parameter.

The code-generation model depends on code being compiled with a modern C# compiler, version 9 or later. The C# 9.0 compiler became available with .NET 5. To upgrade to a modern C# compiler, edit your project file to target C# 9.0.

```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
</PropertyGroup>
```

For more information, see [C# language versioning](../../csharp/language-reference/configure-language-version.md).

## Log method anatomy

The <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> signature accepts the <xref:Microsoft.Extensions.Logging.LogLevel> and optionally an <xref:System.Exception>, as shown below.

```csharp
public interface ILogger
{
    void Log<TState>(
        Microsoft.Extensions.Logging.LogLevel logLevel,
        Microsoft.Extensions.Logging.EventId eventId,
        TState state,
        System.Exception? exception,
        Func<TState, System.Exception?, string> formatter);
}
```

As a general rule, the first instance of `ILogger`, `LogLevel`, and `Exception` are treated specially in the log method signature of the source generator. Subsequent instances are treated like normal parameters to the message template:

```csharp
// This is a valid attribute usage
[LoggerMessage(
    EventId = 110, Level = LogLevel.Debug, Message = "M1 {Ex3} {Ex2}")]
public static partial void ValidLogMethod(
    ILogger logger,
    Exception ex,
    Exception ex2,
    Exception ex3);

// This causes a warning
[LoggerMessage(
    EventId = 0, Level = LogLevel.Debug, Message = "M1 {Ex} {Ex2}")]
public static partial void WarningLogMethod(
    ILogger logger,
    Exception ex,
    Exception ex2);
```

> [!IMPORTANT]
> The warnings emitted provide details as to the correct usage of the `LoggerMessageAttribute`. In the preceding example, the `WarningLogMethod` will report a `DiagnosticSeverity.Warning` of `SYSLIB0025`.
>
> ```console
> Don't include a template for `ex` in the logging message since it is implicitly taken care of.
> ```

### Case-insensitive template name support

The generator does a case-insensitive comparison between items in the message template and argument names in the log message. This means that when the `ILogger` enumerates the state, the argument is picked up by the message template, which can make the logs nicer to consume:

```csharp
public partial class LoggingExample
{
    private readonly ILogger _logger;

    public LoggingExample(ILogger logger)
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

Consider the example logging output when using the `JsonConsole` formatter:

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
    "{OriginalFormat}": "Welcome to {City} {Province}!"
  }
}
```

### Indeterminate parameter order

There are no constraints on the ordering of log method parameters. A developer could define the `ILogger` as the last parameter, although it may appear a bit awkward.

```csharp
[LoggerMessage(
    EventId = 110,
    Level = LogLevel.Debug,
    Message = "M1 {Ex3} {Ex2}")]
static partial void LogMethod(
    Exception ex,
    Exception ex2,
    Exception ex3,
    ILogger logger);
```

> [!TIP]
> The order of the parameters on a log method is *not* required to correspond to the order of the template placeholders. Instead, the placeholder names in the template are expected to match the parameters. Consider the following `JsonConsole` output and the order of the errors.
>
> ```json
> {
>   "EventId": 110,
>   "LogLevel": "Debug",
>   "Category": "ConsoleApp.Program",
>   "Message": "M1 System.Exception: Third time's the charm. System.Exception: This is the second error.",
>   "State": {
>     "Message": "M1 System.Exception: Third time's the charm. System.Exception: This is the second error.",
>     "ex2": "System.Exception: This is the second error.",
>     "ex3": "System.Exception: Third time's the charm.",
>     "{OriginalFormat}": "M1 {Ex3} {Ex2}"
>   }
> }
> ```

## Additional logging examples

The following samples demonstrate how to retrieve the event name, set the log level dynamically, and format logging parameters. The logging methods are:

- `LogWithCustomEventName`: Retrieve event name via `LoggerMessage` attribute.
- `LogWithDynamicLogLevel`: Set log level dynamically, to allow log level to be set based on configuration input.
- `UsingFormatSpecifier`: Use format specifiers to format logging parameters.

```csharp
public partial class LoggingSample
{
    private readonly ILogger _logger;

    public LoggingSample(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 20,
        Level = LogLevel.Critical,
        Message = "Value is {Value:E}")]
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
        Message = "Welcome to {City} {Province}!")]
    public partial void LogWithDynamicLogLevel(
        string city, LogLevel level, string province);

    public void TestLogging()
    {
        LogWithCustomEventName();

        LogWithDynamicLogLevel("Vancouver", LogLevel.Warning, "BC");
        LogWithDynamicLogLevel("Vancouver", LogLevel.Information, "BC");

        UsingFormatSpecifier(logger, 12345.6789);
    }
}
```

Consider the example logging output when using the `SimpleConsole` formatter:

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

Consider the example logging output when using the `JsonConsole` formatter:

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
    "{OriginalFormat}": "Welcome to {City} {Province}!"
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
    "{OriginalFormat}": "Welcome to {City} {Province}!"
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
    "{OriginalFormat}": "Value is {Value:E}"
  }
}
```

## Redacting sensitive information in logs

When logging sensitive data, it's important to prevent accidental exposure. Even with compile-time generated logging methods, logging raw sensitive values can lead to data leaks and compliance issues.

The [Microsoft.Extensions.Telemetry](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry) library provides advanced logging and telemetry enrichment capabilities for .NET applications. It extends the logging pipeline to automatically apply redaction to classified data when writing logs. It enables you to enforce data protection policies throughout your application by integrating redaction into your logging workflow. It is built for applications needing sophisticated telemetry and logging insights.

To enable redaction, use the [Microsoft.Extensions.Compliance.Redaction](https://www.nuget.org/packages/Microsoft.Extensions.Compliance.Redaction) library. This library provides **redactors**—components that transform sensitive data (for example, by erasing, masking, or hashing it) so that it is safe to output. Redactors are selected based on **data classification**, which lets you label data according to its sensitivity (such as personal, private, or public).

To use redaction with source-generated logging methods, you should:

1. Classify your sensitive data using a data classification system.
2. Register and configure redactors for each classification in your DI container.
3. Enable redaction in the logging pipeline.
4. Check your logs to ensure no sensitive data is exposed.

For example, if you have a log message that has a parameter that is considered private:

```csharp
[LoggerMessage(0, LogLevel.Information, "User SSN: {SSN}")]
public static partial void LogPrivateInformation(
    this ILogger logger,
    [MyTaxonomyClassifications.Private] string SSN);
```

You will need to have a setting similar to this:

```csharp
using Microsoft.Extensions.Telemetry;
using Microsoft.Extensions.Compliance.Redaction;

var services = new ServiceCollection();
services.AddLogging(builder =>
{
    // Enable redaction.
    builder.EnableRedaction();
});

services.AddRedaction(builder =>
{
    builder.SetRedactor<StarRedactor>(MyTaxonomyClassifications.Private);
});

public void TestLogging()
{
    LogPrivateInformation("MySSN");
}
```

The output should be like this:

`User SSN: *****`

This approach ensures that only redacted data is logged, even when using compile-time generated logging APIs. You can use different redactors for different data types or classifications, and update your redaction logic centrally.

For more details about how to classify your data, see [Data classification in .NET](data-classification.md).
For more details about redaction and redactors, see [Data redaction in .NET](data-redaction.md).

## Summary

With the advent of C# source generators, writing highly performant logging APIs is much easier. Using the source generator approach has several key benefits:

- Allows the logging structure to be preserved and enables the exact format syntax required by [Message Templates](https://messagetemplates.org).
- Allows supplying alternative names for the template placeholders and using format specifiers.
- Allows the passing of all original data as-is, without any complication around how it's stored before something is done with it (other than creating a `string`).
- Provides logging-specific diagnostics, and emits warnings for duplicate event IDs.

Additionally, there are benefits over manually using <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A?displayProperty=nameWithType>:

- Shorter and simpler syntax: Declarative attribute usage rather than coding boilerplate.
- Guided developer experience: The generator gives warnings to help developers do the right thing.
- Support for an arbitrary number of logging parameters. `LoggerMessage.Define` supports a maximum of six.
- Support for dynamic log level. This is not possible with `LoggerMessage.Define` alone.

## See also

- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
- [Console log formatting](console-log-formatter.md)
- [Data redaction in .NET](data-redaction.md)
- [Data classification in .NET](data-classification.md)
- [NuGet: Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/microsoft.extensions.logging.abstractions)
