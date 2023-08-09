---
title: AOT Diagnostics
description: Learn about diagnostics in NativeAOT applications
author: lakshanf
ms.author: lakshanf
ms.date: 08/07/2023
---
# Diagnostics in NativeAOT applications

The long term goal for NativeAOT application diagnostics is to provide the rich diagnostic experience that developers expect out of a .NET application. .NET diagnostic experience was built over multiple releases and getting customer feedback on diagnostic was a critical part of that journey. NativeAOT wants to follow a similar path where the right diagnostic experience is built from prioritized customer feedback in multiple releases.

NativeAOT applications have the following characteristics that are important to keep in mind in diagnostic scenarios:

- Trimming as a first-class feature in NativeAOT application. Unused code in a NativeAOT application is stripped out of the final binary. Any unbounded reflection used by the application including its dependent libraries will be trimmed. NativeAOT compiler will generate warnings in such cases, and it is critical that these warnings are fixed. For example, suppressing any such warnings without careful analysis can lead to hard to debug production failures.
- Symbol file issues: In NativeAOT, symbol-file-dependent diagnostics (debugging, PerfView callstacks, etc) don't work at all unless the diagnostic tool has access to the monolithic PDB that was generated when the application was compiled. In .NET, symbol-file-dependent diagnostics generally work just fine (or even work great) even if the diagnostic tool has no access to any PDBs that were generated when the application was compiled (i.e., symbols for the .NET runtime and the .NET libraries can be pulled from symbol servers, diagnostic tools can still show function names, accurate callstacks, etc even without access to the PDBs generated at application compile time).
- NativeAOT application is neither a typical managed application (for example, no JIT) nor a typical native application (for example, has full GC support). The intent is to meet the reasonable diagnostics expectation of a product that is coming out of the .NET family and also the experience should feel familiar to someone who does production diagnostics on a C++ application.

## Current NativeAOT diagnostic support

Not all diagnostic features in NativeAOT are currently at parity with .NET. The following table summarizes NativeAOT diagnostic feature parity with .NET:

| Feature | Fully Supported | Partially Supported | Not Supported |
| - | - | - | - |
| Build (Inner dev loop) diagnostics | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Observability | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Profiling | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Production debugging | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Heap analysis | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |

### Build time diagnostics

Build time (inner-dev-loop experience) diagnostic experience for a NativeAOT application will match exactly the .NET application experience since the application in build-time will run on .NET. Given the challenges in acquiring diagnostics in production environment and the current gap in diagnostic tools in NativeAOT, spending time in build time diagnostic in NativeAOT will be the best solution to build a performant and reliable NativeAOT application.

### Observability support

NativeAOT runtime supports [EventPipe](../../diagnostics/eventpipe.md) which will allow NativeAOT applications to easily trace their applications. EventPipe support will also allow most .NET diagnostic tools like [dotnet-trace](../../diagnostics/dotnet-trace.md), [dotnet-counter](../../diagnostics/dotnet-counters.md), and [dotnet-monitor](../../diagnostics/dotnet-monitor.md) to work seamlessly with NativeAOT applications.

NativeAOT also provides partial support for [OpenTelemetry](../../diagnostics/observability-with-otel.md) and some [well-known event providers](../../diagnostics/well-known-event-providers.md). Not all [runtime events](../../../fundamentals/diagnostics/runtime-events.md) are supported in NativeAOT.

### Profiling support

"Microsoft-DotNETCore-SampleProfiler" provider is not currently supported in NativeAOT. Platform specific tools like [PerfView](https://github.com/microsoft/perfview), and [Perf](https://perf.wiki.kernel.org/index.php/Main_Page) can be used to collect CPU samples of a NativeAOT application.

### Production debugging

A NativeAOT application in production environment is a native application with full GC support and can be debugged by native platform debuggers  (e.g. WinDbg or Visual Studio on Windows, and gdb or lldb on Unix-like systems). It is critical that the corresponding symbol file for the application is available to do production debugging.

The NativeAOT compiler generates information about line numbers, types, locals and parameters. The native debugger will allow inspecting stack trace and variables, stepping into/over source lines, or setting line breakpoints. Additional feature support like debugging around Exceptions, fixing some name mangling, step into virtual calls, hot reload, stepping into runtime library code, property and expression evaluation are planned in future releases.

Collecting a [dump](../../diagnostics/dumps.md) file for a NativeAOT application would involve some manual steps in .NET8 release.

### Heap analysis support

Heap analysis tool, [dotnet-gcdump](../../diagnostics/dotnet-gcdump.md), is not currently supported in NativeAOT.
