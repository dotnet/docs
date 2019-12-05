---
title: Debugging profiling config settings
description: Learn about run-time settings that configure debugging and profiling for .NET Core apps.
ms.date: 11/27/2019
ms.topic: reference
---
# Run-time configuration options for debugging and profiling

## Enable diagnostics

- Configures whether the debugger, the profiler, and EventPipe diagnostics are enabled or disabled.
- Default: Enabled (`1`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_EnableDiagnostics` | `1` - enabled<br/>`0` - disabled |

## Enable profiling

- Configures whether profiling is enabled for the currently running process.
- Default: Disabled (`0`).

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
- For more information, see [Finding the profiler library](https://github.com/dotnet/runtime/blob/master/docs/design/coreclr/profiling/Profiler%20Loading.md).

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `CORECLR_PROFILER_PATH` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_32` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_64` | *string-path* |

## Write perf map

- Enables or disables writing */tmp/perf-$pid.map* on Linux systems.
- Default: Disabled (`0`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_PerfMapEnabled` | `0` - disabled<br/>`1` - enabled |

## Perf log markers

- When `COMPlus_PerfMapEnabled` is set to `1`, enables or disables the specified signal to be accepted and ignored as a marker in the perf logs.
- Default: Disabled (`0`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_PerfMapIgnoreSignal` | `0` - disabled<br/>`1` - enabled |
