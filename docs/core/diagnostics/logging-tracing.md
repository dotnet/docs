---
title: Logging and tracing - .NET Core
description: An introduction to .NET Core logging and tracing.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/05/2019
---
# .NET Core logging and tracing

Logging and tracing are really two names for the same technique. The simple technique has been used since the early days of computers. It simply involves instrumenting an application to write output to be consumed later.

## Reasons to use logging and tracing

This simple technique is surprisingly powerful. It can be used in situations where a debugger fails:

- Issues occurring over long periods of time, can be difficult to debug with a traditional debugger. Logs allow for detailed post-mortem review spanning long periods of time. In contrast, debuggers are constrained to real-time analysis.
- Multi-threaded applications and distributed applications are often difficult to debug.  Attaching a debugger tends to modify behaviors. Detailed logs can be analyzed as needed to understand complex systems.
- Issues in distributed applications may arise from a complex interaction between many components and it may not be reasonable to connect a debugger to every part of the system.
- Many services shouldn't be stalled. Attaching a debugger often causes timeout failures.
- Issues aren't always foreseen. Logging and tracing are designed for low overhead so that programs can always be recording in case an issue occurs.

## .NET Core APIs

### Print style APIs

The <xref:System.Console?displayProperty=nameWithType>, <xref:System.Diagnostics.Trace?displayProperty=nameWithType>, and <xref:System.Diagnostics.Debug?displayProperty=nameWithType> classes each provide similar print style APIs convenient for logging.

The choice of which print style API to use is up to you. The key differences are:
- <xref:System.Console?displayProperty=nameWithType>
  - Always enabled and always writes to the console.
  - Useful for information that your customer may need to see in the release.
  - Because it's the simplest approach, it's often used for ad-hoc temporary debugging. This debug code is often never checked in to source control.
- <xref:System.Diagnostics.Trace?displayProperty=nameWithType>
  - Only enabled when `TRACE` is defined.
  - Writes to attached <xref:System.Diagnostics.Trace.Listeners>, by default the <xref:System.Diagnostics.DefaultTraceListener>.
  - Use this API when creating logs that will be enabled in most builds.
- <xref:System.Diagnostics.Debug?displayProperty=nameWithType>
  - Only enabled when `DEBUG` is defined.
  - Writes to an attached debugger.
  - On `*nix` writes to stderr if `COMPlus_DebugWriteToStdErr` is set.
  - Use this API when creating logs that will be enabled only in debug builds.

### Logging events

The following APIs are more event oriented. Rather than logging simple strings they log event objects.

- <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType>
  - EventSource is the primary root .NET Core tracing API.
  - Available in all .NET Standard versions.
  - Only allows tracing serializable objects.
  - Writes to the attached [event listeners](xref:System.Diagnostics.Tracing.EventListener).
  - .NET Core provides listeners for:
    - .NET Core's EventPipe on all platforms
    - [Event Tracing for Windows (ETW)](/windows/win32/etw/event-tracing-portal)
    - [LTTng tracing framework for Linux](https://lttng.org/)

- <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>
  - Included in .NET Core and as a [NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource) for .NET Framework.
  - Allows in-process tracing of non-serializable objects.
  - Includes a bridge to allow selected fields of logged objects to be written to an <xref:System.Diagnostics.Tracing.EventSource>.

- <xref:System.Diagnostics.Activity?displayProperty=nameWithType>
  - Provides a definitive way to identify log messages resulting from a specific activity or transaction. This object can be used to correlate logs across different services.

- <xref:System.Diagnostics.EventLog?displayProperty=nameWithType>
  - Windows only.
  - Writes messages to the Windows Event Log.
  - System administrators expect fatal application error messages to appear in the Windows Event Log.

## ILogger and logging frameworks

The low-level APIs may not be the right choice for your logging needs. You may want to consider a logging framework.

The <xref:Microsoft.Extensions.Logging.ILogger> interface has been used to create a common logging interface where the loggers can be inserted through dependency injection.

For instance, to allow you to make the best choice for your application `ASP.NET` offers support for a selection of built-in and third-party frameworks:
- [ASP.NET built in logging providers](/aspnet/core/fundamentals/logging/#built-in-logging-providers)
- [ASP.NET Third-party logging providers](/aspnet/core/fundamentals/logging/#third-party-logging-providers)

## Logging related references

- [How to: Compile Conditionally with Trace and Debug](../../framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md)

- [How to: Add Trace Statements to Application Code](../../framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md)

- [ASP.NET Logging](/aspnet/core/fundamentals/logging)
provides an overview of the logging techniques it supports.

- [C# String Interpolation](../../csharp/language-reference/tokens/interpolated.md)
 can simplify writing logging code.

- The <xref:System.Exception.Message?displayProperty=nameWithType> property is useful for logging exceptions.

- The <xref:System.Diagnostics.StackTrace?displayProperty=nameWithType> class can be useful to provide stack info in your logs.

## Performance considerations

String formatting can take noticeable CPU processing time.

In performance critical applications, it's recommended that you:
- Avoid lots of logging when no one is listening. Avoid constructing costly logging messages by checking if logging is enabled first.
- Only log what's useful.
- Defer fancy formatting to the analysis stage.
