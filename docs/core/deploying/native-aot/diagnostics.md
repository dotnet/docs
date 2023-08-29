---
title: Diagnostics and instrumentation
description: Learn about diagnostics in native AOT applications
author: lakshanf
ms.author: lakshanf
ms.date: 08/07/2023
---

# Diagnostics and instrumentation

Native AOT shares some, but not all, diagnostics and instrumentation capabilities with CoreCLR. Because of CoreCLR's rich selection of diagnostic utilities, it will sometimes be appropriate to diagnose and debug problems in CoreCLR. Apps which are trim-compatible should not have behavioral differences, so investigations often apply to both runtimes. Nonetheless, some information can only be gathered after publishing, so Native AOT also provides post-publish diagnostic tooling.

## .NET 8 native AOT diagnostic support

The following table summarizes diagnostic features supported for native AOT deployments:

| Feature | Fully supported | Partially supported | Not supported |
| - | - | - | - |
| Observability | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Build-time diagnostics | <span aria-hidden="true">✔️</span><span class="visually-hidden">Fully supported</span> | | |
| Production debugging | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| CPU Profiling | | <span aria-hidden="true">✔️</span><span class="visually-hidden">Partially supported</span> | |
| Heap analysis | | | <span aria-hidden="true">❌</span><span class="visually-hidden">Not supported</span> |

## Observability and telemetry

As of .NET 8, the Native AOT runtime supports [EventPipe](../../diagnostics/eventpipe.md), which is the base layer used by many logging and tracing libraries. You can interface with EventPipe directly through APIs like `EventSource.WriteEvent` or you can use libraries built on top, like [OpenTelemetry](../../diagnostics/observability-with-otel.md). EventPipe support also allows .NET diagnostic tools like [dotnet-trace](../../diagnostics/dotnet-trace.md), [dotnet-counter](../../diagnostics/dotnet-counters.md), and [dotnet-monitor](../../diagnostics/dotnet-monitor.md), to work seamlessly with Native AOT or CoreCLR applications. EventPipe is an optional component in native AOT. To include EventPipe support, set the `EventSourceSupport` MSBuild property to `true`.

```xml
<PropertyGroup>
    <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

Native AOT provides partial support for some [well-known event providers](../../diagnostics/well-known-event-providers.md). Not all [runtime events](../../../fundamentals/diagnostics/runtime-events.md) are supported in native AOT.

## Build-time diagnostics

The .NET CLI tooling (`dotnet` SDK) and Visual studio offer separate commands for `build` and
`publish`. `build` (or `Start` in Visual Studio) will use CoreCLR. Only `publish` will create a
Native AOT application.  Publishing your app as native AOT produces an app that has been
ahead-of-time (AOT) compiled to native code. As mentioned above, this means that not all diagnostic
tools will work seamlessly with published native AOT applications in .NET 8. However, all .NET
diagnostic tools are available for developers during the application building stage. We recommend
developing, debugging, and testing the applications as usual and publish the working app with native
AOT as one of the last steps.

## Debugging

When running your app during development, like inside Visual Studio, or with `dotnet run`, `dotnet build`, or `dotnet test`, applications will run on CoreCLR by default. However, as long as `PublishAot` is present in the project file the behavior should be the same between CoreCLR and Native AOT. This allows you to use the standard Visual Studio managed debugging engine for development and testing.

After publishing, Native AOT applications are true native binaries. The managed debugger will not work on them. However, the Native AOT compiler generates fully native executable files that can be debugged by native debuggers on your platform of choice (e.g. WinDbg or Visual Studio on Windows, and gdb or lldb on Unix-like systems).

The NativeAOT compiler generates information about line numbers, types, locals and parameters. The native debugger will let you inspect stack trace and variables, step into/over source lines, or set line breakpoints.

To debug managed exceptions, set a breakpoint on the `RhThrowEx` method -- this method is called whenever a managed exception is thrown.

Collecting a [dump](../../diagnostics/dumps.md) file for a native AOT application involves some manual steps in .NET 8.

### Visual Studio-specific notes

You can launch a NativeAOT-compiled executable under the VS debugger by opening it in the Visual Studio IDE. In the `File`` menu, choose `Open Project/Solution...`` and navigate to the native executable. You can set breakpoints as needed. To start debugging the EXE, choose the `Start Debugging`` option from the Debug menu.

To set a breakpoint that breaks whenever an exception is thrown, choose the Breakpoints option from the `Debug -> Windows` menu. In the new window, select `New -> Function` breakpoint. Specify `RhThrowEx`` as the Function Name and leave the Language option at "All Languages" (do not select C#).

To see what exception was thrown, start debugging (`Debug -> Start Debugging` or `F5`), open the Watch window (`Debug -> Windows -> Watch`) and add following expression as one of the watches: `(S_P_CoreLib_System_Exception*)@rcx`. This leverages the fact that at the time `RhThrowEx` is called, the x64 CPU register RCX contains the thrown exception. You can also paste the expression into the Immediate Window; the syntax is the same as for watches.

### Importance of the symbol file

In native AOT, symbol-file-dependent diagnostics (such as debugging [PerfView](https://github.com/microsoft/perfview) callstacks) don't work at all unless the diagnostic tool has access to the monolithic PDB that was generated when the application was compiled. In .NET, symbol-file-dependent diagnostics generally work just fine, or even great, even if the diagnostic tool has no access to any PDBs that were generated when the application was compiled. That is, symbols for the .NET runtime and the .NET libraries can be pulled from symbol servers, and diagnostic tools can still show function names and accurate call stacks even without access to the compile-time PDBs.

## CPU profiling

Platform-specific tools like [PerfView](https://github.com/microsoft/perfview) and [Perf](https://perf.wiki.kernel.org/index.php/Main_Page) can be used to collect CPU samples of a native AOT application.

## Heap analysis

Managed heap analysis is not currently supported in native AOT. Heap analysis tools like [dotnet-gcdump](../../diagnostics/dotnet-gcdump.md), [PerfView](https://github.com/microsoft/perfview), and Visual Studio heap analysis tools don't work in native AOT in .NET 8.
