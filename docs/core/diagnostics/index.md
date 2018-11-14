---
title: Diagnostic tools and APIs in .NET Core 
description: An overview of the tools and APIs available to diagnose misbehaving .NET Core applications.
author: noahfalk
ms.author: noahfalk
ms.date: 11/13/2018
ms.topic: article
ms.prod: .net-core
---
# .NET Core Diagnostics

Software doesn't always behave as you would expect, but .NET Core has tools and APIs that will let you diagnose these issues quickly and effectively.
 This article covers different diagnostic options available and helps select the right one for the problem at hand.

## Debugging ##
Debuggers allow programs to be paused or executed step-by-step. At each point the current state of process can be viewed so that you understand why
 executing the code produces the result that it does. Microsoft provides two primary debuggers for managed code:

- **Visual Studio** is an IDE with the most comprehensive debugger available. This is an excellent default choice for developers working on Windows.
  - [Debugging a .NET Core application on Windows with Visual Studio](https://docs.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio)
  For Linux and MacOS apps Visual Studio supports remote debugging over the network. The debugger UI will remain on the Windows machine and the app
  being debugged can run on a separate machine running Linux or OSX.
  - [Debugging a .Net Core application on Linux/OSX with Visual Studio](https://github.com/Microsoft/MIEngine/wiki/Offroad-Debugging-of-.NET-Core-on-Linux---OSX-from-Visual-Studio)

- **VSCode** is a lighter weight fully cross platform code editor. It shares the same high quality debugger implementation as Visual Studio
  with a streamlined UI.
    - [Debugging a .Net Core application with VSCode](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code)

- **Windbg and LLDB** - These are command-line debuggers that are natively designed for working with C/C++/assembly code, but using the 'SOS' plugin
 from .NET Core offers a limited amount of functionality for managed code. These tools have a steeper learning curve and are not suggested as a first
 choice for most typical managed code debugging tasks, but they can be valuable in understanding low-level details of the .NET Core runtime or how
 .NET Core is interacting with components written in C/C++.
 [TODO: link to a guide]

## Logging ##
Logging allows you to record information as a program runs so that you can understand what happened after the fact. It is useful for diagnosing issues
 that are hard to reproduce on demand or issues that occur in production where it would be unacceptable to pause a running service with a debugger. 

**Trace.WriteLine** logs to an attached debugger, files or any TextWriter with minimal configuration. Pluggable
 TraceListener implementations can log to custom destinations. Logging levels, TraceSource and TraceSwitch allow the logging output to be
 filtered on-demand.

**Console.WriteLine** writes text to the application's console. Useful for very quick ad-hoc logging but not very flexible as a longer term solution.

**ILogger** is part of the ASP.Net Core framework, this logging API serves as a DI-friendly wrapper over a variety of providers. In-box options include console,
 debugger, Trace, Windows event log, and EventSource. Additional NuGet packages support more providers such as Azure and a variety of 3rd party loggers.
 This is the recommended logging API for anyone writing ASP.Net Core applications.

**3rd party logging frameworks** - [TODO]: Do we need to vet a list of 3rd party options? As the platform I'd think we want to stay neutral as we can
 but I expect many of our customers want to see that these options are available.

**EventLog** writes messages to the Windows event log. [TODO: Some guidance for when to use this?]

[TODO]: Should we cover Debug.WriteLine? In .Net Core 1.0-2.1 it had different behavior than it does in .NET Framework and logged to the debugger
output stream only. In 2.2 (or 3.0?) it has been updated to behave as it used to, which means it does the same as Trace.WriteLine but conditionally
compiled only for debug builds.


## Tracing, Metrics and Monitors ##

[TODO]: Should we plug Application Insights here? What about other monitors?

**EventSource** emits to ETW on Windows, to .NET Core's EventPipe on any OS, or to in-process EventListener API. 
[TODO]: We should probably cover common runtime instrumentation such as RuntimeEventSource or TplEtwProvider
**DiagnosticsSource** emits .NET objects that may not be serializable to in-process listeners.

[TODO]: Did we have enough work in EventCounter that it is worth talking about?




## Profiling ##
**Visual Studio**
**PerfView**
**3rd party tools**



## Dump debugging ##
**CreateDump**
**ProcDump**
**Visual Studio**
**windbg/LLDB + SOS**


## APIs for creating custom tools ##
**ICorDebug**
**ICorProfiler**
**CLRMD**
**Built-in EventSources**
**Built-in DiagnosticsSources**
