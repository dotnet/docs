---
title: .NET Core Logging and Tracing
description: An introduction to .NET Core Logging and Tracing.
author: stmaclea
ms.author: stmaclea
ms.date: 08/05/2019
---
# .NET Core Logging and Tracing

Logging and tracing is a primitive technique used since the early days of computers. It simply involves instrumenting an application to produce output to be consumed later.

Logging and tracing are similar. As used here we'll distinguish:
- Logging outputs text as human readable content.
- Tracing outputs binary content.  It can use tokenizing, and filtering to reduce overhead in the traced application.

## Why Logging and Tracing?

These simple techniques are surprisingly powerful. They can be used in situations where a fancy debugger fails:

- Issues occurring over long periods of time, can be difficult to debug with a traditional debugger.
- Multi-threaded applications and distributed applications are often difficult to debug.  Attaching a debugger tends to modify behaviors. Detailed logs can be analyzed as needed to understand complex systems.
- Many services shouldn't be stalled. Attaching a debugger often causes timeout failures.

## Logging APIs

<xref:System.Console?displayProperty=nameWithType>, <xref:System.Diagnostics.Trace?displayProperty=nameWithType>, and <xref:System.Diagnostics.Debug?displayProperty=nameWithType> each provide similar APIs convenient for logging.

The choice of which API to use is up to you. The key differences:
- <xref:System.Console?displayProperty=nameWithType>
  - Always compiled in and always writes to the console.
  - Useful for information that your customer may need to see in release.
  - Because it's the simplest approach, it's often used for ad-hoc temporary debugging. This debug code is often never checked in to source control.
- <xref:System.Diagnostics.Trace?displayProperty=nameWithType>
  - Only enabled when `TRACE` is defined.
  - Writes to attached <xref:System.Diagnostics.TraceListener>s. Usually a debugger.
  - It seems best to use this API when creating release-oriented logs.
- <xref:System.Diagnostics.Debug?displayProperty=nameWithType>
  - Only enabled when `DEBUG` is defined.
  - Writes to attached <xref:System.Diagnostics.TraceListener>s. Usually a debugger.
  - It seems best to use this API when creating debug-oriented logs.

### Logging Related References

- [How to: Compile Conditionally with Trace and Debug](../../framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug)

- [How to: Add Trace Statements to Application Code](../../framework/debug-trace-profile/how-to-add-trace-statements-to-application-code)

- [ASP.NET Logging](/aspnet/core/fundamentals/logging)
provides an overview of the logging techniques it supports.

- [C# String Interpolation](../../csharp/language-reference/tokens/interpolated)
 can simplify writing logging code.

- The <xref:System.Exception.Message?displayProperty=nameWithType> is useful for logging exceptions.

- The <xref:System.Diagnostics.StackTrace?displayProperty=nameWithType>
can be useful to provide debugger like logging info.

- <xref:System.Diagnostics.TraceListener> provides an overview of existing listeners and creating a custom listener.

## Tracing APIs

- <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType>
  - EventSource is the primary root .NET Core tracing API
  - Available in all .NET Standard versions
  - Emits to .NET Core's event pipe on all platforms
  - Also emits to ETW on Windows.
  - Only allows tracing serializable objects

- <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>
  - Only available in .NET Core
  - Allows tracing non-serializable objects
  - Includes a bridge to allow select fields of logged objects to be written to an <xref:System.Diagnostics.Tracing.EventSource>.

- <xref:System.Diagnostics.TraceSource?displayProperty=nameWithType>
  - This API was introduced in .NET Framework 2.0
  - Supported in .NET Standard 2.0
  - Prefer <xref:System.Diagnostics.Tracing.EventSource>

- <xref:System.Diagnostics.EventLog?displayProperty=nameWithType>
  - Windows only
  - Writes messages to Windows event log
  - System administrators expect fatal application error messages to appear in the Windows event log.

## Performance Considerations

String formatting can take noticeable CPU processing time.

In performance critical applications, it's good to:
- Avoid lots of logging when no one is listening
- Only log what is useful
- Defer fancy formatting to the analysis stage

Usually tracing is better than logging for most performance critical applications.
