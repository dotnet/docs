---
title: Collect detailed assembly loading information - .NET Core
description: Description of how to collect assembly loading information in .NET Core
author: elinor-fung
ms.author: elfung
ms.date: 11/17/2020
---
# Collect detailed assembly loading information

Starting with .NET 5.0, the runtime can emit events through `EventPipe` with detailed information about [managed assembly loading](loading-managed.md) to aid in diagnosing assembly loading issues. These [events](../../fundamentals/diagnostics/runtime-loader-binder-events.md) are emitted by the `Microsoft-Windows-DotNETRuntime` provider under the `AssemblyLoader` keyword (`0x4`).

## Prerequisites

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download) or later versions
- [`dotnet-trace`](../diagnostics/dotnet-trace.md) tool

> [!NOTE]
> The scope of `dotnet-trace` capabilities is greater than collecting detailed assembly loading information. For more information on the usage of `dotnet-trace`, see [`dotnet-trace`](../diagnostics/dotnet-trace.md).

## Collect a trace with assembly loading events

You can use `dotnet-trace` to trace an existing process or to launch a child process and trace it from startup.

### Trace an existing process

To enable assembly loading events in the runtime and collect a trace of them, use `dotnet-trace` with the following command:

```console
dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:4 --process-id <pid>
```

This command collects a trace of the specified `<pid>`, enabling the `AssemblyLoader` events in the `Microsoft-Windows-DotNETRuntime` provider. The result is a `.nettrace` file.

### Use dotnet-trace to launch a child process and trace it from startup

Sometimes it may be useful to collect a trace of a process from its startup. For apps running .NET 5.0 or later, you can use `dotnet-trace` to do this.

The following command launches *hello.exe* with `arg1` and `arg2` as its command line arguments and collects a trace from its runtime startup:

```console
dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:4 -- hello.exe arg1 arg2
```

You can stop collecting the trace by pressing <kbd>Enter</kbd> or <kbd>Ctrl</kbd> + <kbd>C</kbd>. This also closes _hello.exe_.

> [!NOTE]
>
> * Launching *hello.exe* via `dotnet-trace` redirects its input and output, and you won't be able to interact with it on the console by default. Use the `--show-child-io` switch to interact with its `stdin` and `stdout`.
> * Exiting the tool via <kbd>Ctrl</kbd>+<kbd>C</kbd> or `SIGTERM` safely ends both the tool and the child process.
> * If the child process exits before the tool, the tool exits as well and the trace should be safely viewable.

## View a trace

The collected trace file can be viewed on Windows using the Events view in [PerfView](https://github.com/microsoft/perfview). All the assembly loading events will be prefixed with `Microsoft-Windows-DotNETRuntime/AssemblyLoader`.

## Example (on Windows)

This example uses the [assembly loading extension points sample](/samples/dotnet/samples/assembly-loading-extension-points/). The application attempts to load an assembly `MyLibrary` - an assembly that is not referenced by the application and thus requires handling in an assembly loading extension point to be successfully loaded.

### Collect the trace

01. Navigate to the directory with the downloaded sample. Build the application with:

    ```console
    dotnet build
    ```

01. Launch the application with arguments indicating that it should pause, waiting for a key press. On resuming, it will attempt to load the assembly in the default `AssemblyLoadContext` - without the handling necessary for a successful load. Navigate to the output directory and run:

    ```console
    AssemblyLoading.exe /d default
    ```

01. Find the application's process ID.

    ```console
    dotnet-trace ps
    ```

    The output will list the available processes. For example:

    ```console
    35832 AssemblyLoading C:\src\AssemblyLoading\bin\Debug\net5.0\AssemblyLoading.exe
    ```

01. Attach `dotnet-trace` to the running application.

    ```console
    dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:4 --process-id 35832
    ```

01. In the window running the application, press any key to let the program continue. Tracing will automatically stop once the application exits.

### View the trace

Open the collected trace in [PerfView](https://github.com/microsoft/perfview) and open the Events view. Filter the events list to `Microsoft-Windows-DotNETRuntime/AssemblyLoader` events.

:::image type="content" source="media/collect-details/assembly-loader-filter.png" alt-text="PerfView assembly loader filter image":::

All assembly loads that occurred in the application after tracing started will be shown. To inspect the load operation for the assembly of interest for this example - `MyLibrary`, we can do some more filtering.

### Assembly loads

Filter the view to the [`Start`](../../fundamentals/diagnostics/runtime-loader-binder-events.md#assemblyloadstart-event) and [`Stop`](../../fundamentals/diagnostics/runtime-loader-binder-events.md#assemblyloadstop-event) events under `Microsoft-Windows-DotNETRuntime/AssemblyLoader` using the event list on the left. Add the columns `AssemblyName`, `ActivityID`, and `Success` to the view. Filter to events containing `MyLibrary`.

:::image type="content" source="media/collect-details/start-stop.png" alt-text="PerfView Start and Stop events image":::

| Event Name             | AssemblyName                                      | ActivityID | Success |
| ---------------------- | ------------------------------------------------- | ---------- | ------- |
| `AssemblyLoader/Start` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | //1/2/     |         |
| `AssemblyLoader/Stop`  | `MyLibrary, Culture=neutral, PublicKeyToken=null` | //1/2/     | False   |

You should see one `Start`/`Stop` pair with `Success=False` on the `Stop` event, indicating the load operation failed. Note that the two events have the same activity ID. The activity ID can be used to filter all the other assembly loader events to just the ones corresponding to this load operation.

### Breakdown of attempt to load

For a more detailed breakdown of the load operation, filter the view to the [`ResolutionAttempted` events](../../fundamentals/diagnostics/runtime-loader-binder-events.md#resolutionattempted-event) under `Microsoft-Windows-DotNETRuntime/AssemblyLoader` using the event list on the left. Add the columns `AssemblyName`, `Stage`, and `Result` to the view. Filter to events with the activity ID from the `Start`/`Stop` pair.

:::image type="content" source="media/collect-details/resolution-attempted.png" alt-text="PerfView ResolutionAttempted events image":::

| Event Name                           | AssemblyName                                      | Stage                               | Result             |
| ------------------------------------ | ------------------------------------------------- | ----------------------------------- | ------------------ |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `FindInLoadContext`                 | `AssemblyNotFound` |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `ApplicationAssemblies`             | `AssemblyNotFound` |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `AssemblyLoadContextResolvingEvent` | `AssemblyNotFound` |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `AppDomainAssemblyResolveEvent`     | `AssemblyNotFound` |

The events above indicate that the assembly loader attempted to resolve the assembly by looking in the current load context, running the default probing logic for managed application assemblies, invoking handlers for the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event, and invoking handlers for the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType>. For all of these steps, the assembly was not found.

### Extension points

To see which extension points were invoked, filter the view to the [`AssemblyLoadContextResolvingHandlerInvoked`](../../fundamentals/diagnostics/runtime-loader-binder-events.md#assemblyloadcontextresolvinghandlerinvoked-event) and [`AppDomainAssemblyResolveHandlerInvoked`](../../fundamentals/diagnostics/runtime-loader-binder-events.md#appdomainassemblyresolvehandlerinvoked-event) under `Microsoft-Windows-DotNETRuntime/AssemblyLoader` using the event list on the left. Add the columns `AssemblyName` and `HandlerName` to the view. Filter to events with the activity ID from the `Start`/`Stop` pair.

:::image type="content" source="media/collect-details/extension-point.png" alt-text="PerfView extension point events image":::

| Event Name                                                  | AssemblyName                                      | HandlerName                      |
| ----------------------------------------------------------- | ------------------------------------------------- | -------------------------------- |
| `AssemblyLoader/AssemblyLoadContextResolvingHandlerInvoked` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `OnAssemblyLoadContextResolving` |
| `AssemblyLoader/AppDomainAssemblyResolveHandlerInvoked`     | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `OnAppDomainAssemblyResolve`     |

The events above indicate that a handler named `OnAssemblyLoadContextResolving` was invoked for the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event and a handler named `OnAppDomainAssemblyResolve` was invoked for the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

### Collect another trace

Run the application with arguments such that its handler for the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event will load the `MyLibrary` assembly.

```console
AssemblyLoading /d default alc-resolving
```

Collect and open another `.nettrace` file using the [steps from above](#collect-the-trace).

Filter to the `Start` and `Stop` events for `MyLibrary` again. You should see a `Start`/`Stop` pair with another `Start`/`Stop` between them. The inner load operation represents the load triggered by the handler for <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> when it called <xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyPath%2A?displayProperty=nameWithType>. This time, you should see `Success=True` on the `Stop` event, indicating the load operation succeeded. The `ResultAssemblyPath` field shows the path of the resulting assembly.

:::image type="content" source="media/collect-details/start-stop-success.png" alt-text="PerfView successful Start and Stop events image":::

| Event Name             | AssemblyName                                                       | ActivityID | Success | ResultAssemblyPath                                      |
| ---------------------- | ------------------------------------------------------------------ |------------|---------| ------------------------------------------------------- |
| `AssemblyLoader/Start` |                  `MyLibrary, Culture=neutral, PublicKeyToken=null` | //1/2/     |         |                                                         |
| `AssemblyLoader/Start` | `MyLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null` | //1/2/1/   |         |                                                         |
| `AssemblyLoader/Stop`  | `MyLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null` | //1/2/1/   | True    | *C:\src\AssemblyLoading\bin\Debug\net5.0\MyLibrary.dll* |
| `AssemblyLoader/Stop`  |                  `MyLibrary, Culture=neutral, PublicKeyToken=null` | //1/2/     | True    | *C:\src\AssemblyLoading\bin\Debug\net5.0\MyLibrary.dll* |

We can then look at the `ResolutionAttempted` events with the activity ID from the outer load to determine the step at which the assembly was successfully resolved. This time, the events will show that the `AssemblyLoadContextResolvingEvent` stage was successful. The `ResultAssemblyPath` field shows the path of the resulting assembly.

:::image type="content" source="media/collect-details/resolution-attempted-success.png" alt-text="PerfView successful ResolutionAttempted events image":::

| Event Name                           | AssemblyName                                      | Stage                               | Result             | ResultAssemblyPath |
| ------------------------------------ | ------------------------------------------------- | ----------------------------------- | ------------------ | ------------------ |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `FindInLoadContext`                 | `AssemblyNotFound` |                    |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `ApplicationAssemblies`             | `AssemblyNotFound` |                    |
| `AssemblyLoader/ResolutionAttempted` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `AssemblyLoadContextResolvingEvent` | `Success`          | *C:\src\AssemblyLoading\bin\Debug\net5.0\MyLibrary.dll* |

Looking at `AssemblyLoadContextResolvingHandlerInvoked` events will show that the handler named `OnAssemblyLoadContextResolving` was invoked. The `ResultAssemblyPath` field shows the path of the assembly returned by the handler.

:::image type="content" source="media/collect-details/extension-point-success.png" alt-text="PerfView successful extension point events image":::

| Event Name                                                  | AssemblyName                                      | HandlerName                      | ResultAssemblyPath |
| ----------------------------------------------------------- | ------------------------------------------------- | -------------------------------- | ------------------ |
| `AssemblyLoader/AssemblyLoadContextResolvingHandlerInvoked` | `MyLibrary, Culture=neutral, PublicKeyToken=null` | `OnAssemblyLoadContextResolving` | *C:\src\AssemblyLoading\bin\Debug\net5.0\MyLibrary.dll* |

Note that there is no longer a `ResolutionAttempted` event with the `AppDomainAssemblyResolveEvent` stage or any `AppDomainAssemblyResolveHandlerInvoked` events, as the assembly was successfully loaded before reaching the step of the loading algorithm that raises the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

## See also

- [Assembly loader events](../../fundamentals/diagnostics/runtime-loader-binder-events.md)
- [dotnet-trace](../diagnostics/dotnet-trace.md)
- [PerfView](https://github.com/microsoft/perfview)
