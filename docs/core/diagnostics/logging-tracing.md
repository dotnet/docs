---
title: Logging and tracing - .NET
description: An introduction to .NET logging and tracing.
ms.date: 4/29/2022
---
# .NET logging and tracing

Code can be instrumented to produce a log, which serves as a record of interesting events that occurred while the program was running. To understand the application's behavior, logs can be reviewed. Logging and tracing both encapsulate this technique. .NET has accumulated several different logging APIs over its history and this article will help you understand what options are available.

The terms logging and tracing are commonly synonymous, the distinction we usually take is that logging output is expected to be collected all the time, and so should have a low overhead. Tracing is typically more invasive and collects more information from deeper parts of the application and .NET runtime, so is either used when diagnosing specific problems, or automatically for short periods of time as part of deeper performance analysis systems.

Another pivot on the tracing term is [Distributed Tracing](./distributed-tracing.md) - which collects high-level activity & timing data for request based systems, and correlates the requests across services to give a view of how each request is processed by the complete system.

## Key distinctions in logging APIs

### Structured logging

Logging APIs can either be structured or unstructured:

- Unstructured: Log entries have free-form text content that is intended to be viewed by humans.
- Structured: Log entries have a well defined schema and can be encoded in different binary and textual formats. These logs are designed to be machine translatable and queryable so that both humans and automated systems can work with them easily.

APIs that support structured logging are preferable for non-trivial usage. They offer more functionality, flexibility, and performance with little difference in usability.

### Configuration

For simple use cases, you might want to use APIs that directly write messages to the console or a file. But most software projects will find it useful to configure which log events get recorded and how they are persisted. For example, when running in a local dev environment, you might want to output plain text to the console for easy readability. Then when the application is deployed to a production environment, you might switch to have the logs stored in a dedicated database or a set of rolling files. APIs with good configuration options will make these transitions easy, whereas less configurable options would require updating the instrumentation code everywhere to make changes.

### Sinks

Most logging APIs allow log messages to be sent to different destinations called sinks. Some APIs have a large number of pre-made sinks, whereas others only have a few. If no pre-made sink exists, there's usually an extensibility API that will let you author a custom sink, although this requires writing a bit more code.

## .NET logging APIs

### ILogger

For most cases, whether adding logging to an existing project or creating a new project, the [ILogger infrastructure](../extensions/logging.md) is a good default choice. `ILogger` supports fast structured logging, flexible configuration, and a collection of [common sinks](../extensions/logging-providers.md#built-in-logging-providers) including the console, which is what you see when running an ASP.NET app. Additionally, the `ILogger` interface can also serve as a facade over many [third party logging implementations](../extensions/logging-providers.md#third-party-logging-providers) that offer more functionality and extensibility.

`ILogger` provides the logging story for the Open Telemetry implementation for .NET, which enables egress of logs from you application to a variety of APM systems for further analysis.

### EventSource

[EventSource](./eventsource.md) is an older high performance tracing API with structured logging. It was originally designed to integrate well with [Event Tracing for Windows (ETW)](/windows/win32/etw/event-tracing-portal), but was later extended to support [EventPipe](./eventpipe.md) cross-platform tracing and <xref:System.Diagnostics.Tracing.EventListener> for custom sinks. In comparison to `ILogger`, `EventSource` has relatively few pre-made logging sinks and there is no built-in support to configure via separate configuration files. `EventSource` is excellent if you want tighter control over [ETW](/windows/win32/etw/event-tracing-portal) or [EventPipe](./eventpipe.md) integration, but for general purpose logging, `ILogger` is more flexible and easier to use.

### Trace

<xref:System.Diagnostics.Trace?displayProperty=nameWithType> and <xref:System.Diagnostics.Debug?displayProperty=nameWithType> are .NET's oldest logging APIs. These classes have flexible configuration APIs and a large ecosystem of sinks, but only support unstructured logging. On .NET Framework they can be configured via an app.config file, but in .NET Core, there's no built-in, file-based configuration mechanism. They are typically used to produce diagnostics output for the developer while running under the debugger. The .NET team continues to support these APIs for backward-compatibility purposes, but no new functionality will be added. These APIs are a fine choice for applications that are already using them. For newer apps that haven't already committed to a logging API, `ILogger` may offer better functionality.

## Specialized logging APIs

### Console

The <xref:System.Console?displayProperty=nameWithType> class has the <xref:System.Console.Write%2A> and <xref:System.Console.WriteLine%2A> methods that can be used in simple logging scenarios. These APIs are very easy to get started with but the solution won't be as flexible as a general purpose logging API. Console only allows unstructured logging and there is no configuration support to select which log messages are enabled or to retarget to a different sink. Using the ILogger or Trace APIs with a console sink doesn't take much additional effort and keeps the logging configurable.

### DiagnosticSource

<xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> is intended for logging where the log messages will be analyzed synchronously in-process rather than serialized to any storage. This allows the source and listener to exchange arbitrary .NET objects as messages, whereas most logging APIs require the log event to be serializable. This technique can also be extremely fast, handling log events in tens of nanoseconds if the listener is implemented efficiently. Tools that use these APIs often act more like in-process profilers, though the API doesn't impose any constraint here.

### EventLog

<xref:System.Diagnostics.EventLog?displayProperty=nameWithType> is a Windows only API that writes messages to the Windows EventLog. In many cases using ILogger with an optional EventLog sink when running on Windows may give similar functionality without coupling the app tightly to the Windows OS.
