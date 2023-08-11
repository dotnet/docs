---
title: AOT diagnostics
description: Learn about diagnostics in native AOT applications
author: lakshanf
ms.author: lakshanf
ms.date: 08/07/2023
---
# Diagnostics in native AOT applications

The long-term goal for native AOT application diagnostics is to provide the rich diagnostic experience that developers expect out of a .NET application. The .NET diagnostic experience was built over multiple releases, and a critical part of that journey was customer feedback. Native AOT diagnostics will follow a similar path where the right diagnostic experience is built from prioritized customer feedback in multiple releases.

## Native AOT application features

Native AOT applications have the following characteristics that are important to keep in mind in diagnostic scenarios.

### Trimming as a first-class feature

Unused code in a NativeAOT application is stripped out of the final binary. Any unbounded reflection used by the application, including its dependent libraries, is trimmed. The NativeAOT compiler will generate warnings in such cases, and it's critical that these warnings are fixed. For example, if you suppress any warnings without careful analysis, it can lead to hard to debug production failures.

### Importance of the symbol file

In native AOT, symbol-file-dependent diagnostics (such as debugging, PerfView callstacks) don't work at all unless the diagnostic tool has access to the monolithic PDB that was generated when the application was compiled. In .NET, symbol-file-dependent diagnostics generally work just fine (or even work great) even if the diagnostic tool has no access to any PDBs that were generated when the application was compiled (that is, symbols for the .NET runtime and the .NET libraries can be pulled from symbol servers, diagnostic tools can still show function names and accurate callstacks even without access to the PDBs generated at application compile time)

### Application type

Native AOT apps aren't typical managed applications (for example, no JIT). They also aren't typical native applications (for example, they have full GC support). The intent is to meet the reasonable diagnostics expectation of a product in the .NET family, but the experience should also feel familiar to those using production diagnostics on C++ apps.

## .NET 8 native AOT diagnostic support

The following table summarizes diagnostic features supported for native AOT deployments:

| Feature | Fully supported | Partially supported | Not supported |
| - | - | - | - |
| Build (Inner dev loop) diagnostics | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Observability | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| CPU Profiling | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Production debugging | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Heap analysis | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |

### Build (Inner dev loop) diagnostics

Publishing your app as native AOT produces an app that has been ahead-of-time (AOT) compiled to native code. As mentioned above, this means that not all diagnostic tools will work seamlessly with published native AOT applications in .NET 8. However, all .NET diagnostic tools are available for developers during the application building stage. We recommend developing, debugging, and testing the applications as usual and publish the working app with native AOT as one of the last steps.

### Observability

The native AOT runtime supports [EventPipe](../../diagnostics/eventpipe.md), which allows native AOT apps to easily trace their applications. EventPipe support also allows most .NET diagnostic tools, like [dotnet-trace](../../diagnostics/dotnet-trace.md), [dotnet-counter](../../diagnostics/dotnet-counters.md), and [dotnet-monitor](../../diagnostics/dotnet-monitor.md), to work seamlessly with native AOT applications. EventPipe is an optional component in native AOT and require the `EventSourceSupport` property to be set to `true` to include EventPipe support.

```xml
<PropertyGroup>
    <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

[OpenTelemetry](../../diagnostics/observability-with-otel.md) is expected to support native AOT in the key three pillars of observability: logging, tracing, and metrics in .NET 8. Native AOT provides partial support for and some [well-known event providers](../../diagnostics/well-known-event-providers.md). Not all [runtime events](../../../fundamentals/diagnostics/runtime-events.md) are supported in native AOT.

### CPU profiling

The "Microsoft-DotNETCore-SampleProfiler" provider is not currently supported in native AOT. However, platform-specific tools like [PerfView](https://github.com/microsoft/perfview), and [Perf](https://perf.wiki.kernel.org/index.php/Main_Page) can be used to collect CPU samples of a native AOT application.

### Production debugging

Typical production debugging scenarios are done through logging and tracing, and will be [supported](#observability) in native AOT. Low-level debugging, using platform debuggers like WinDbg or Visual Studio on Windows, and gdb or lldb on Unix-like systems, can be used in native AOT. For this case, it is critical that the corresponding symbol file for the application is available to do production debugging.

The native AOT compiler generates information about line numbers, types, locals, and parameters. The native debugger will allow inspecting stack trace and variables, stepping into/over source lines, or setting line breakpoints. Additional feature support like debugging around Exceptions, fixing some name mangling, step into virtual calls, stepping into runtime library code, property and expression evaluation are planned in future releases.

Collecting a [dump](../../diagnostics/dumps.md) file for a native AOT application would involve some manual steps in .NET8 release.

### Heap analysis

Managed heap analysis is not currently supported in native AOT. Heap analysis tools like, [dotnet-gcdump](../../diagnostics/dotnet-gcdump.md), [PerfView](https://github.com/microsoft/perfview) and Visual Studio heap analysis tools will not work in native AOT in .NET 8.
