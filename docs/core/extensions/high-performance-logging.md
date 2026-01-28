---
title: High-performance logging
description: Learn how to use source-generated logging with LoggerMessageAttribute to create high-performance logs with minimal overhead in .NET applications.
ms.date: 10/20/2025
---

# High-performance logging in .NET

For high-performance logging scenarios in .NET 6 and later versions, use the <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> with compile-time source generation. This approach provides the best performance by eliminating boxing, temporary allocations, and message template parsing at runtime.

Source-generated logging provides the following performance advantages over [logger extension methods](xref:Microsoft.Extensions.Logging.LoggerExtensions), such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A>:

- **Eliminates boxing:** Logger extension methods require "boxing" (converting) value types, such as `int`, into `object`. Source-generated logging avoids boxing by using strongly typed parameters.
- **Parses templates at compile time:** Logger extension methods must parse the message template (named format string) every time a log message is written. Source-generated logging parses templates once at compile time.
- **Reduces allocations:** The source generator creates optimized code that minimizes object allocations and temporary memory usage.

The sample app demonstrates high-performance logging features with a priority queue processing worker service. The app processes work items in priority order. As these operations occur, log messages are generated using source-generated logging.

[!INCLUDE [logging-samples-browser](includes/logging-samples-browser.md)]

## Source-generated logging basics

To use source-generated logging, define `partial` logging methods decorated with the `LoggerMessageAttribute`. The code generator produces the implementation at compile time.

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Processing priority item: {Item}")]
    public static partial void PriorityItemProcessed(
        ILogger logger, WorkItem item);

    [LoggerMessage(
        EventId = 13,
        Level = LogLevel.Critical,
        Message = "Epic failure processing item!")]
    public static partial void FailedToProcessWorkItem(
        ILogger logger, Exception ex);
}
```

For comprehensive information about source-generated logging, including advanced scenarios, dynamic log levels, and logging method constraints, see [Compile-time logging source generation](./logger-message-generator.md).

## Define logger messages with source generation

To create high-performance log messages in .NET 6 and later, define `partial` methods decorated with <xref:Microsoft.Extensions.Logging.LoggerMessageAttribute>. The source generator creates the implementation at compile time.

### Basic logging method

For a simple log message, define a partial method with the attribute specifying the event ID, log level, and message template:

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 13,
        Level = LogLevel.Critical,
        Message = "Epic failure processing item!")]
    public static partial void FailedToProcessWorkItem(
        ILogger logger, Exception ex);
}
```

The message template uses placeholders that are filled by method parameters. Placeholder names should be descriptive and consistent across templates. They serve as property names within structured log data. We recommend [Pascal casing](../../standard/design-guidelines/capitalization-conventions.md) for placeholder names. For example, `{Item}`, `{DateTime}`.

Call the logging method from your code. For example, when an exception occurs during work item processing:

```csharp
try
{
    // Process work item
}
catch (Exception ex)
{
    Log.FailedToProcessWorkItem(logger, ex);
}
```

This produces console output like:

```console
crit: WorkerServiceOptions.Example.Worker[13]
      Epic failure processing item!
      System.Exception: Failed to verify communications.
```

### Logging with parameters

To pass parameters to a log message, add them as method parameters. The parameter names match the placeholders in the message template:

```csharp
public static partial class Log
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Processing priority item: {Item}")]
    public static partial void PriorityItemProcessed(
        ILogger logger, WorkItem item);
}
```

Call the method with the logger and parameter values:

```csharp
var workItem = queue.Dequeue();
Log.PriorityItemProcessed(logger, workItem);
```

This produces console output like:

```console
info: WorkerServiceOptions.Example.Worker[1]
      Processing priority item: Priority-Extreme (50db062a-9732-4418-936d-110549ad79e4): 'Verify communications'
```

Structured logging stores may use the event name when it's supplied with the event ID to enrich logging. For example, [Serilog](https://github.com/serilog/serilog-extensions-logging) uses the event name.

## Define logger message scope with source generation

You can define [log scopes](logging.md#log-scopes) using source-generated logging by creating instance methods that return `IDisposable`. The scope wraps a series of log messages with additional context.

Enable `IncludeScopes` in the console logger section of *appsettings.json*:

:::code language="json" source="snippets/logging/worker-service-options/appsettings.json" highlight="3-5":::

Define a partial logging method that includes scope parameters:

```csharp
public partial class WorkerLogger
{
    private readonly ILogger _logger;

    public WorkerLogger(ILogger logger)
    {
        _logger = logger;
    }

    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Processing priority item: {Item}")]
    public partial void PriorityItemProcessed(WorkItem item);

    public IDisposable? ProcessingWorkScope(DateTime startTime)
    {
        return _logger.BeginScope("Processing scope, started at: {DateTime}", startTime);
    }
}
```

The scope wraps the logging calls in a [using](../../csharp/language-reference/statements/using.md) block:

```csharp
using (logger.ProcessingWorkScope(DateTime.Now))
{
    logger.PriorityItemProcessed(workItem);
}
```

Inspect the log messages in the app's console output. The following result shows priority ordering of log messages with the log scope message included:

```console
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Extreme (7d153ef9-8894-4282-836a-8e5e38319fb3): 'Verify communications'
```

## Summary of source-generated logging benefits

Using source-generated logging with C# provides several key benefits:

- Allows the logging structure to be preserved and enables the exact format syntax required by [Message Templates](https://messagetemplates.org).
- Allows supplying alternative names for the template placeholders and using format specifiers.
- Allows the passing of all original data as-is, without any complication around how it's stored before something is done with it (other than creating a `string`).
- Provides logging-specific diagnostics and emits warnings for duplicate event IDs.
- **Shorter and simpler syntax:** Declarative attribute usage rather than coding boilerplate.
- **Guided developer experience:** The generator gives warnings to help developers do the right thing.
- **Support for an arbitrary number of logging parameters:** No limits on the number of parameters.
- **Support for dynamic log level:** The log level can be passed as a parameter.

For comprehensive information about source-generated logging, including advanced scenarios, constraints, and detailed examples, see [Compile-time logging source generation](./logger-message-generator.md).

## Legacy approach: LoggerMessage.Define (for .NET Framework and .NET Core 3.1)

Before source-generated logging was introduced in .NET 6, the recommended high-performance logging approach was to use the <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A> method to create cacheable delegates. While this approach is still supported for backward compatibility, **new code should use source-generated logging** with `LoggerMessageAttribute` instead.

The <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A> method creates an <xref:System.Action> delegate for logging a message. Here's an example of the legacy approach:

```csharp
public static class LoggerExtensions
{
    private static readonly Action<ILogger, Exception> s_failedToProcessWorkItem;

    static LoggerExtensions()
    {
        s_failedToProcessWorkItem = LoggerMessage.Define(
            LogLevel.Critical,
            new EventId(13, nameof(FailedToProcessWorkItem)),
            "Epic failure processing item!");
    }

    public static void FailedToProcessWorkItem(
        this ILogger logger, Exception ex) =>
        s_failedToProcessWorkItem(logger, ex);
}
```

This legacy approach requires:
- Static fields to hold delegates
- Static constructors to initialize delegates
- Extension methods to invoke delegates

**Limitations compared to source-generated logging:**
- Maximum of six type parameters for `LoggerMessage.Define` overloads
- No support for dynamic log level
- More boilerplate code required
- Less intuitive syntax

If you're maintaining code that uses `LoggerMessage.Define`, consider migrating to source-generated logging when updating to .NET 6 or later. For .NET Framework or .NET Core 3.1 applications, continue using `LoggerMessage.Define`.

## Log level guarded optimizations

Another performance optimization can be made by checking the <xref:Microsoft.Extensions.Logging.LogLevel>, with <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)?displayProperty=nameWithType> before an invocation to the corresponding `Log*` method. When logging isn't configured for the given `LogLevel`, the following statements are true:

- <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> isn't called.
- An allocation of `object[]` representing the parameters is avoided.
- Value type boxing is avoided.

For more information:

- [Micro benchmarks in the .NET runtime](https://github.com/dotnet/runtime/issues/51927#issuecomment-842993859)
- [Background and motivation for log level checks](https://github.com/dotnet/runtime/issues/45290#issue-752502603)

## See also

- [Compile-time logging source generation](logger-message-generator.md)
- [Logging in .NET](logging.md)
