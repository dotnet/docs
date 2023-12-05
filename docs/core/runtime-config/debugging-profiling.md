---
title: Debugging profiling config settings
description: Learn about run-time settings that configure debugging and profiling for .NET apps.
ms.date: 11/27/2019
---
# Runtime configuration options for debugging and profiling

This article details the settings you can use to configure .NET debugging and profiling.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Enable diagnostics

- Configures whether the debugger, the profiler, and EventPipe diagnostics are enabled or disabled.
- If you omit this setting, diagnostics are enabled. This is equivalent to setting the value to `1`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_EnableDiagnostics` or `DOTNET_EnableDiagnostics` | `1` - enabled<br/>`0` - disabled |

## Enable profiling

- Configures whether profiling is enabled for the currently running process.
- If you omit this setting, profiling is disabled. This is equivalent to setting the value to `0`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `CORECLR_ENABLE_PROFILING` | `0` - disabled<br/>`1` - enabled |

## Profiler GUID

- Specifies the GUID of the profiler to load into the currently running process.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `CORECLR_PROFILER` | *string-guid* |

## Profiler location

- Specifies the path to the profiler DLL to load into the currently running process (or 32-bit or 64-bit process).
- If more than one variable is set, the bitness-specific variables take precedence. They specify which bitness of profiler to load.
- For more information, see [Finding the profiler library](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/profiling/Profiler%20Loading.md).

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `CORECLR_PROFILER_PATH` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_32` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_64` | *string-path* |

## Export perf maps and jit dumps

- Enables or disables selective enablement of perf maps or jit dumps. These files allow third party tools, such as the Linux `perf` tool, to identify call sites for dynamically generated code and precompiled ReadyToRun (R2R) modules.
- If you omit this setting, writing perf map and jit dump files are both disabled. This is equivalent to setting the value to `0`.
- When perf maps are disabled, not all managed callsites will be properly resolved.
- Depending on the Linux kernel version, both formats are supported by the `perf` tool.
- Enabling perf maps or jit dumps causes a 10-20% overhead. To minimize performance impact, it's recommended to selectively enable either perf maps or jit dumps, but not both.

The following table compares perf maps and jit maps.

| Format | Description | Supported on |
| - | - | - |
| *Perf maps* | Emits `/tmp/perf-<pid>.map`, which contains symbolic information for dynamically generated code.<br/>Emits `/tmp/perfinfo-<pid>.map`, which includes ReadyToRun (R2R) module symbol information and is used by [PerfCollect](../diagnostics/trace-perfcollect-lttng.md). | Perf maps are supported on all Linux kernel versions. |
| *Jit dumps* | The jit dump format supersedes perf maps and contains more detailed symbolic information. When enabled, jit dumps are output to `/tmp/jit-<pid>.dump` files. | Linux kernel versions 5.4 or higher. |

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_PerfMapEnabled` or `DOTNET_PerfMapEnabled` | `0` - disabled<br/>`1` - perf maps and jit dumps both enabled<br/>`2` - jit dumps enabled<br/>`3` - perf maps enabled |

## Perf log markers

- Enables or disables the specified signal to be accepted and ignored as a marker in the perf logs.
- If you omit this setting, the specified signal is not ignored. This is equivalent to setting the value to `0`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_PerfMapIgnoreSignal` or `DOTNET_PerfMapIgnoreSignal` | `0` - disabled<br/>`1` - enabled |

> [!NOTE]
> This setting is ignored if [DOTNET_PerfMapEnabled](#export-perf-maps-and-jit-dumps) is omitted or set to `0` (that is, disabled).
