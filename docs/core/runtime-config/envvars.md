---
title: "Runtime configuration with environment variables"
description: "Use environment variables to configure the runtime behavior of .NET Core applications."
ms.date: "06/19/2019"
---
# Runtime configuration with environment variables

.NET Core supports a number of environment variables that you can use to configure your applications. 

The following sections list selected supported environment variables by category. For a complete list of supported, as well as unsupported and internal environment variables, see [Host Configuration Knobs](https://github.com/dotnet/coreclr/blob/a28b25aacdcd2adb0fdfa70bd869f53ba6565976/Documentation/project-docs/clr-configuration-knobs.md).

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to add or correct the information. For information on submitting pull requests for the dotnet/docs repo, see the [contributor's guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).

## Debugging

|Variable name|Variable value|Description|
|--|--|--|
|`COMPlus_EnableDiagnostics`|0 or 1|Enables (1) or disables (0) debugger and profiler diagnostics.|

## Garbage collection

|Variable name|Variable value|Description|
|--|--|--|
|`COMPlus_gcAllowVeryLargeObjects`|0 or 1|Enables (1, the default value) or Disables (0) support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.|
|`COMPlus_GCCpuGroup`|0 or 1|Enables (1) or disables (0, the default value) support for CPU groups by the garbage collector if server garbage collection is enabled.|
|`COMPlus_GCLatencyLevel`|see <xref:System.Runtime.GCLatencyMode>|Adjusts the intrusiveness of the garbage collector. The default value is 1 (<xref:System.Runtime.GCLatencyMode.Interactive?displayProperty=nameWithType>). For more information, see [Latency modes](../../standard/garbage-collection/latency.md).
|`COMPlus_GCName`|*string_path*|Specifies a path to the library containing the GC that the runtime intends to load. For more information, see [Standalone GC Loader Design](https://github.com/dotnet/coreclr/blob/4c7c066d0bacdb86a2311333de1ca73d94ae5280/Documentation/design-docs/standalone-gc-loading.md).|

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
|`COMPlus_Thread_UseAllCpuGroups`|0 or 1|Enables (1) or disables (0, the default value) automatic distribution threads across CPU groups.|

## Tiered compilation

|Variable name|Variable value|Description|
|--|--|--|
|`COMPlus_TieredCompilation`|Enables (1, the default value starting with .NET Core 3.0) or disables (0, the default value in .NET Core 2.1 and 2.2) tiered compilation.|


## See also

- [NET Core runtime configuration settings](index.md)
