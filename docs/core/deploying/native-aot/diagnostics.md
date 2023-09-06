---
title: Diagnostics and instrumentation
description: Learn about diagnostics in Native AOT applications
author: lakshanf
ms.author: lakshanf
ms.date: 08/07/2023
---

# Diagnostics and instrumentation

Native AOT shares some, but not all, diagnostics and instrumentation capabilities with CoreCLR. Because of CoreCLR's rich selection of diagnostic utilities, it will sometimes be appropriate to diagnose and debug problems in CoreCLR. Apps which are [trim-compatible](../trimming/prepare-libraries-for-trimming.md) should not have behavioral differences, so investigations often apply to both runtimes. Nonetheless, some information can only be gathered after publishing, so Native AOT also provides post-publish diagnostic tooling.

## .NET 8 Native AOT diagnostic support

The following table summarizes diagnostic features supported for Native AOT deployments:

| Feature | Fully supported | Partially supported | Not supported |
| - | - | - | - |
| [Observability](#observability-and-telemetry) | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| [Development-time diagnostics](#development-time-diagnostics) | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| [Native debugging](#native-debugging) | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| [CPU Profiling](#cpu-profiling) | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| [Heap analysis](#heap-analysis) | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |

## Observability and telemetry

As of .NET 8, the Native AOT runtime supports [EventPipe](../../diagnostics/eventpipe.md), which is the base layer used by many logging and tracing libraries. You can interface with EventPipe directly through APIs like `EventSource.WriteEvent` or you can use libraries built on top, like [OpenTelemetry](../../diagnostics/observability-with-otel.md). EventPipe support also allows .NET diagnostic tools like [dotnet-trace](../../diagnostics/dotnet-trace.md), [dotnet-counter](../../diagnostics/dotnet-counters.md), and [dotnet-monitor](../../diagnostics/dotnet-monitor.md), to work seamlessly with Native AOT or CoreCLR applications. EventPipe is an optional component in Native AOT. To include EventPipe support, set the `EventSourceSupport` MSBuild property to `true`.

```xml
<PropertyGroup>
    <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

Native AOT provides partial support for some [well-known event providers](../../diagnostics/well-known-event-providers.md). Not all [runtime events](../../../fundamentals/diagnostics/runtime-events.md) are supported in Native AOT.

## Development-time diagnostics

The .NET CLI tooling (`dotnet` SDK) and Visual studio offer separate commands for `build` and
`publish`. `build` (or `Start` in Visual Studio) will use CoreCLR. Only `publish` will create a
Native AOT application.  Publishing your app as Native AOT produces an app that has been
ahead-of-time (AOT) compiled to native code. As mentioned above, this means that not all diagnostic
tools will work seamlessly with published Native AOT applications in .NET 8. However, all .NET
diagnostic tools are available for developers during the application building stage. We recommend
developing, debugging, and testing the applications as usual and publish the working app with native
AOT as one of the last steps.

## Native debugging

When running your app during development, like inside Visual Studio, or with `dotnet run`, `dotnet build`, or `dotnet test`, applications will run on CoreCLR by default. However, as long as `PublishAot` is present in the project file the behavior should be the same between CoreCLR and Native AOT. This allows you to use the standard Visual Studio managed debugging engine for development and testing.

After publishing, Native AOT applications are true native binaries. The managed debugger will not work on them. However, the Native AOT compiler generates fully native executable files that can be debugged by native debuggers on your platform of choice (for example, WinDbg or Visual Studio on Windows and gdb or lldb on Unix-like systems).

The NativeAOT compiler generates information about line numbers, types, locals and parameters. The native debugger will let you inspect stack trace and variables, step into/over source lines, or set line breakpoints.

To debug managed exceptions, set a breakpoint on the `RhThrowEx` method -- this method is called whenever a managed exception is thrown. The exception is stored in the `rcx` or `x0` register. If your debugger supports viewing C++ objects, you can cast
the register to `S_P_CoreLib_System_Exception*` to see more information about the exception.

Collecting a [dump](../../diagnostics/dumps.md) file for a Native AOT application involves some manual steps in .NET 8.

### Visual Studio-specific notes

You can launch a NativeAOT-compiled executable under the VS debugger by opening it in the Visual Studio IDE. You will need to [open the executable itself in Visual Studio](https://learn.microsoft.com/visualstudio/debugger/how-to-debug-an-executable-not-part-of-a-visual-studio-solution).

To set a breakpoint that breaks whenever an exception is thrown, choose the Breakpoints option from the `Debug -> Windows` menu. In the new window, select `New -> Function` breakpoint. Specify `RhThrowEx` as the Function Name and leave the Language option at "All Languages" (do not select C#).

To see what exception was thrown, start debugging (`Debug -> Start Debugging` or `F5`), open the Watch window (`Debug -> Windows -> Watch`) and add following expression as one of the watches: `(S_P_CoreLib_System_Exception*)@rcx`. This leverages the fact that at the time `RhThrowEx` is called, the x64 CPU register RCX contains the thrown exception. You can also paste the expression into the Immediate Window; the syntax is the same as for watches.

### Importance of the symbol file

When publishing, the Native AOT compiler produces both an executable and a symbol file. Native debugging, and related activities like profiling, require access to the native symbol file. If this file is not present, you may have degraded or broken results.

See [Native debug information](index.md#native-aot-deployment) for details about the name and location of the symbol file.

## CPU profiling

Platform-specific tools like [PerfView](https://github.com/microsoft/perfview) and [Perf](https://perf.wiki.kernel.org/index.php/Main_Page) can be used to collect CPU samples of a Native AOT application.

## Heap analysis

Managed heap analysis is not currently supported in Native AOT. Heap analysis tools like [dotnet-gcdump](../../diagnostics/dotnet-gcdump.md), [PerfView](https://github.com/microsoft/perfview), and Visual Studio heap analysis tools don't work in Native AOT in .NET 8.
