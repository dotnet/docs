---
title: High-performance logging
author: IEvangelist
description: Learn how to use LoggerMessage to create cacheable delegates that require fewer object allocations for high-performance logging scenarios.
ms.author: dapine
ms.date: 04/11/2024
---

# High-performance logging in .NET

The <xref:Microsoft.Extensions.Logging.LoggerMessage> class exposes functionality to create cacheable delegates that require fewer object allocations and reduced computational overhead compared to [logger extension methods](xref:Microsoft.Extensions.Logging.LoggerExtensions), such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A>. For high-performance logging scenarios, use the <xref:Microsoft.Extensions.Logging.LoggerMessage> pattern.

<xref:Microsoft.Extensions.Logging.LoggerMessage> provides the following performance advantages over logger extension methods:

- Logger extension methods require "boxing" (converting) value types, such as `int`, into `object`. The <xref:Microsoft.Extensions.Logging.LoggerMessage> pattern avoids boxing by using static <xref:System.Action> fields and extension methods with strongly typed parameters.
- Logger extension methods must parse the message template (named format string) every time a log message is written. <xref:Microsoft.Extensions.Logging.LoggerMessage> only requires parsing a template once when the message is defined.

> [!IMPORTANT]
> Instead of using the [LoggerMessage class](xref:Microsoft.Extensions.Logging.LoggerMessage) to create high-performance logs, you can use the [LoggerMessage attribute](xref:Microsoft.Extensions.Logging.LoggerMessageAttribute) in .NET 6 and later versions. The `LoggerMessageAttribute` provides source-generation logging support designed to deliver a highly usable and highly performant logging solution for modern .NET applications. For more information, see [Compile-time logging source generation (.NET Fundamentals)](./logger-message-generator.md).

The sample app demonstrates <xref:Microsoft.Extensions.Logging.LoggerMessage> features with a priority queue processing worker service. The app processes work items in priority order. As these operations occur, log messages are generated using the <xref:Microsoft.Extensions.Logging.LoggerMessage> pattern.

[!INCLUDE [logging-samples-browser](includes/logging-samples-browser.md)]

## Define a logger message

Use [Define(LogLevel, EventId, String)](xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A) to create an <xref:System.Action> delegate for logging a message. <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A> overloads permit passing up to six type parameters to a named format string (template).

The string provided to the <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A> method is a template and not an interpolated string. Placeholders are filled in the order that the types are specified. Placeholder names in the template should be descriptive and consistent across templates. They serve as property names within structured log data. We recommend [Pascal casing](../../standard/design-guidelines/capitalization-conventions.md) for placeholder names. For example, `{Item}`, `{DateTime}`.

Each log message is an <xref:System.Action> held in a static field created by [LoggerMessage.Define](xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A). For example, the sample app creates a field to describe a log message for the processing of work items:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="FailedProcessingField":::

For the <xref:System.Action>, specify:

- The log level.
- A unique event identifier (<xref:Microsoft.Extensions.Logging.EventId>) with the name of the static extension method.
- The message template (named format string).

As work items are dequeued for processing, the worker service app sets the:

- Log level to <xref:Microsoft.Extensions.Logging.LogLevel.Critical?displayProperty=nameWithType>.
- Event ID to `13` with the name of the `FailedToProcessWorkItem` method.
- Message template (named format string) to a string.

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="FailedProcessingAssignment":::

The <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A?displayProperty=nameWithType> method is used to configure and define an <xref:System.Action> delegate, which represents a log message.

Structured logging stores may use the event name when it's supplied with the event ID to enrich logging. For example, [Serilog](https://github.com/serilog/serilog-extensions-logging) uses the event name.

The <xref:System.Action> is invoked through a strongly typed extension method. The `PriorityItemProcessed` method logs a message every time a work item is processed. `FailedToProcessWorkItem` is called if and when an exception occurs:

:::code language="csharp" source="snippets/logging/worker-service-options/Worker.cs" range="9-33" highlight="17-20":::

Inspect the app's console output:

```console
crit: WorkerServiceOptions.Example.Worker[13]
      Epic failure processing item!
      System.Exception: Failed to verify communications.
         at WorkerServiceOptions.Example.Worker.ExecuteAsync(CancellationToken stoppingToken) in
         ..\Worker.cs:line 27
```

To pass parameters to a log message, define up to six types when creating the static field. The sample app logs the work item details when processing items by defining a `WorkItem` type for the <xref:System.Action> field:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingItemField":::

The delegate's log message template receives its placeholder values from the types provided. The sample app defines a delegate for adding a work item where the item parameter is a `WorkItem`:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingItemAssignment":::

The static extension method for logging that a work item is being processed, `PriorityItemProcessed`, receives the work item argument value and passes it to the <xref:System.Action> delegate:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingItemMethod":::

In the worker service's `ExecuteAsync` method, `PriorityItemProcessed` is called to log the message:

:::code language="csharp" source="snippets/logging/worker-service-options/Worker.cs" range="9-33" highlight="14":::

Inspect the app's console output:

```console
info: WorkerServiceOptions.Example.Worker[1]
      Processing priority item: Priority-Extreme (50db062a-9732-4418-936d-110549ad79e4): 'Verify communications'
```

## Define logger message scope

The [DefineScope(string)](xref:Microsoft.Extensions.Logging.LoggerMessage.DefineScope%2A) method creates a <xref:System.Func%601> delegate for defining a [log scope](logging.md#log-scopes). <xref:Microsoft.Extensions.Logging.LoggerMessage.DefineScope%2A> overloads permit passing up to six type parameters to a named format string (template).

As is the case with the <xref:Microsoft.Extensions.Logging.LoggerMessage.Define%2A> method, the string provided to the <xref:Microsoft.Extensions.Logging.LoggerMessage.DefineScope%2A> method is a template and not an interpolated string. Placeholders are filled in the order that the types are specified. Placeholder names in the template should be descriptive and consistent across templates. They serve as property names within structured log data. We recommend [Pascal casing](../../standard/design-guidelines/capitalization-conventions.md) for placeholder names. For example, `{Item}`, `{DateTime}`.

Define a [log scope](logging.md#log-scopes) to apply to a series of log messages using the <xref:Microsoft.Extensions.Logging.LoggerMessage.DefineScope%2A> method. Enable `IncludeScopes` in the console logger section of *appsettings.json*:

:::code language="json" source="snippets/logging/worker-service-options/appsettings.json" highlight="3-5":::

To create a log scope, add a field to hold a <xref:System.Func%601> delegate for the scope. The sample app creates a field named `s_processingWorkScope` (*Internal/LoggerExtensions.cs*):

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingWorkField":::

Use <xref:Microsoft.Extensions.Logging.LoggerMessage.DefineScope%2A> to create the delegate. Up to six types can be specified for use as template arguments when the delegate is invoked. The sample app uses a message template that includes the date time in which processing started:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingWorkAssignment":::

Provide a static extension method for the log message. Include any type parameters for named properties that appear in the message template. The sample app takes in a `DateTime` for a custom time stamp to log and returns `_processingWorkScope`:

:::code language="csharp" source="snippets/logging/worker-service-options/Extensions/LoggerExtensions.cs" id="ProcessingWorkMethod":::

The scope wraps the logging extension calls in a [using](../../csharp/language-reference/statements/using.md) block:

:::code language="csharp" source="snippets/logging/worker-service-options/Worker.cs" range="9-33" highlight="4":::

Inspect the log messages in the app's console output. The following result shows priority ordering of log messages with the log scope message included:

```console
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Extreme (7d153ef9-8894-4282-836a-8e5e38319fb3): 'Verify communications'
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: D:\source\repos\dotnet-docs\docs\core\extensions\snippets\logging\worker-service-options
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-High (dbad6558-60cd-4eb1-8531-231e90081f62): 'Validate collection'
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Medium (1eabe213-dc64-4e3a-9920-f67fe1dfb0f6): 'Propagate selections'
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Medium (1142688d-d4dc-4f78-95c5-04ec01cbfac7): 'Enter pooling [contention]'
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Low (e85e0c4d-0840-476e-b8b0-22505c08e913): 'Health check network'
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Deferred (07571363-d559-4e72-bc33-cd8398348786): 'Ping weather service'
info: WorkerServiceOptions.Example.Worker[1]
      => Processing scope, started at: 04/11/2024 11:27:52
      Processing priority item: Priority-Deferred (2bf74f2f-0198-4831-8138-03368e60bd6b): 'Set process state'
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

## Log level guarded optimizations

Another performance optimization can be made by checking the <xref:Microsoft.Extensions.Logging.LogLevel>, with <xref:Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)?displayProperty=nameWithType> before an invocation to the corresponding `Log*` method. When logging isn't configured for the given `LogLevel`, the following statements are true:

- <xref:Microsoft.Extensions.Logging.ILogger.Log%2A?displayProperty=nameWithType> isn't called.
- An allocation of `object[]` representing the parameters is avoided.
- Value type boxing is avoided.

For more information:

- [Micro benchmarks in the .NET runtime](https://github.com/dotnet/runtime/issues/51927#issuecomment-842993859)
- [Background and motivation for log level checks](https://github.com/dotnet/runtime/issues/45290#issue-752502603)

## See also

- [Logging in .NET](logging.md)
