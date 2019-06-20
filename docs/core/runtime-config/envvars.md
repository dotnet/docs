---
title: "Runtime configuration with runtimeconfig.json"
description: "Use the runtime.config.json file to configure the runtime behavior of .NET Core applications."
ms.date: "06/19/2019"
author: "rpetrusha"
ms.author: "ronpet"
---
# Runtime configuration with environment variables

.NET Core supports a number of environment variables that you can use to configure your applications. 

The following sections list selected supported environment variables by category. For a complete list of supported, as well as unsupported and internal environment variables, see [Host Configuration Knobs](https://github.com/dotnet/coreclr/blob/a28b25aacdcd2adb0fdfa70bd869f53ba6565976/Documentation/project-docs/clr-configuration-knobs.md).

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to add or correct the information. For information on submitting pull requests for the dotnet/docs repo, see the [contributor's guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).

## Application domains

|Variable name|Variable value|Description|
|--|--|--|
|`COMPlus_ADULazyMemoryRelease`|0 or 1|Determines whether a lazy memory release occurs when an app domain is unloaded. It is on (1) by default; it should be turned off (0) to catch memory leaks, in which case the unload should be immediately followed by a garbage collection.|
|`COMPlus_ADURetryCount`|*n*|Controls the timeout of an app domain unload. It is used for workarounds when a machine is too slow, there are network issues, etc.|
|`COMPlus_FinalizeOnShutdown`|0 or 1|When enabled, on shutdown, it blocks all user threads and calls finalizers for all finalizable objects, including live objects.|

## Assembly loading

|Variable name|Variable value|Description|
|--|--|--|
|COMPlus_designerNamespaceResolution|0 or 1|Enables (1) or disables (0) the <xref:System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMetadata.DesignerNamespaceResolve?displayProperty=nameWithType> event for WinRT types.|

## Debugging

|Variable name|Variable value|Description|
|--|--|--|
|`COMPlus_DbgPackShimPath`|*string_path*|Defines the CoreCLR path to dbgshim.dll. Support for this environment variable may be removed in the future.|
|`COMPlus_DbgRedirectApplication`|*string_path*|Specifies the auxiliary debugger application to launch.|
|`COMPlus_DbgRedirectAttachCmd`|*string_params*|Specifies command parameters for attaching the auxiliary debugger.|
|`COMPlus_DbgRedirectCommonCmd`|*string_format*|Specifies a command line format string for the auxiliary debugger.|
|`COMPlus_DbgRedirectCreateCmd`|*string_params*|Specifies command parameters when creating the auxiliary debugger.|
|`COMPLUS_EnableDiagnostics`|0 or 1|Enables (1) or disables (0) debugger and profiler diagnostics.|

## Garbage collection

|Variable name|Variable value|Description|
|--|--|--|
|`COMPLUS_gcAllowVeryLargeObjects`|0 or 1|Enables (1, the default value) or Disables (0) support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.|
|`COMPLUS_GCCpuGroup`|0 or 1|Enables (1) or disables (0, the default value) support for CPU groups by the garbage collector if server garbage collection is enabled.|
|`COMPLUS_GCLatencyLevel`|see <xref:System.Runtime.GCLatencyMode>|Adjusts the intrusiveness of the garbage collector. The default value is 1 (<xref:System.Runtime.GCLatencyLevel.Interactive?displayProperty=nameWithType>). For more information, see [Latency modes](../../standard/garbage-collection/latency.md).
|`COMPLUS_GCName`|*string_path*|Specifies a path to the library containing the GC that the runtime intends to load. For more information, see [Standalone GC Loader Design](https://github.com/dotnet/coreclr/blob/4c7c066d0bacdb86a2311333de1ca73d94ae5280/Documentation/design-docs/standalone-gc-loading.md).|
|`COMPLUS_GCPollType`|0 or 1|Enables (1) or disables (0, the default value) [`JIT_PollGC`](https://github.com/dotnet/coreclr/blob/deb00ad58acf627763b6c0a7833fa789e3bb1cd0/src/vm/jithelpers.cpp#L6331-L6536) calls to be inserted into user code.|
|`COMPLUS_GCStress`|0 or 1|If on (1), triggers garbage collections at regular intervals. The default is off (0).|
|`COMPLUS_GCStressStart`|*n*|Start GCStress after *n* stress GCs have been attempted. The default value is 0.|
|`COMPLUS_gcTrimCommitOnLowMemory`|0 or 1|When enabled (1), aggressively trims the committed memory for the ephemeral segment to keep as little memory committed as possible. The default is off (0).|

## Interop

|Variable name|Variable value|Description|
|--|--|--|
|`AllowDComReflection`|0 or 1|Enables (1) or disables (0, the default value) the ability to marshal blocked reflection types by out-of-process DCOM clients.|
|`InteropLogArguments`|Enables (1) or disables (0, the default value) logging of all pinned arguments passed to an interop call.|
|`PreferComInsteadOfManagedRemoting`|0 or 1|Determines whether COM (1) or managed remoting (0, the default value) is used to communicate with a cross-app domain COM callable wrapper.|

## Loader

|Variable name|Variable value|Description|
|--|--|--|
|`COMPLUS_ForceLog`|Enables (1) or disables (0, the default value) the Fusion assembly binding log. The log can be viewed with the [Assembly Binding Log Viewer](https://docs.microsoft.com/dotnet/framework/tools/fuslogvw-exe-assembly-binding-log-viewer).|

## Networking
|Variable name|Variable value|Description|
|--|--|--|
|`DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT`|0 or 1|Starting with .NET Core 3.0, indicates whether support for the HTTP/2 protocol is enabled (1) or disabled (0, the default value).|
|`DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER`|0 or 1|Enables the use of <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> (1, the default value) or of the legacy <xref:System.Net.Http.HttpClientHandler?displayProperty=nameWithType> (0) with high-level networking APIs.|

## Profiling

|Variable name|Variable value|Description|
|--|--|--|
|`CORECLR_ENABLE_PROFILING`|0 or 1|Enables (1) or disables (0, the default value) profiling for the currently running process.|
|`CORECLR_PROFILER`|*string-guid*|Specifies the GUID of the profiler to load into the currently running process.|
|`CORECLR_PROFILER_PATH`|*string-path*|Specifies the path to the profiler DLL to load into the currently running process.|
|`CORECLR_PROFILER_PATH_32`|*string-path*|Specifies the path to the profiler DLL to load into the currently running 32-bit process.|
|`CORECLR_PROFILER_PATH_64`|*string-path*|Specifies the path to the profiler DLL to load into the currently running 64-bit process.|
|`PerfMapEnabled`|0 or 1|Enables (1) or disables (0, the default value) writing */tmp/perf-$pid.map* on Linux systems.|
|`PerfMapIgnoreSignal`|0 or 1|When `PerfMapEnabled` is set to 1, enables (1) or disables (0, the default value) the specified signal to be accepted and ignored as a marker in the perf logs.|

## Threading

|Variable name|Variable value|Description|
|--|--|--|
|`COMPLUS_Thread_UseAllCpuGroups`|0 or 1|Enables (1) or disables (0, the default value) automatic distribution threads across CPU groups.|

## Tiered compilation

|Variable name|Variable value|Description|
|--|--|--|
|`COMPLUS_TieredCompilation`|Enables (1, the default value starting with .NET Core 3.0) or disables (0, the default value in .NET Core 2.1 and 2.2) tiered compilation.|


## See also

- [NET Core runtime configuration settings](index.md)
