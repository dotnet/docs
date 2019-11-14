---
title: Profiling config settings
description: Learn about run-time settings for configuring profiling.
ms.date: 11/13/2019
ms.topic: reference
---
# Run-time configuration options for profiling

## Enable profiling

- Configures whether profiling is enabled for the currently running process.
- Disabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `CORECLR_ENABLE_PROFILING` | (DWORD)<br/>0 - disabled<br/>1 - enabled |

## Profiler GUID

- Specifies the GUID of the profiler to load into the currently running process.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `CORECLR_PROFILER` | *string-guid* |

## Profiler location

- Specifies the path to the profiler DLL to load into the currently running process (or 32-bit or 64-bit process).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `CORECLR_PROFILER_PATH` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_32` | *string-path* |
| **Environment variable** | `CORECLR_PROFILER_PATH_64` | *string-path* |

## Write perf map

- Enables or disables writing */tmp/perf-$pid.map* on Linux systems.
- Disabled by default

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `PerfMapEnabled` | (DWORD)<br/>0 - disable<br/>1 - enable |

## Perf log markers

- When `PerfMapEnabled` is set to 1, enables or disables the specified signal to be accepted and ignored as a marker in the perf logs.
- Disabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `PerfMapIgnoreSignal` | (DWORD)<br/>0 - disable<br/>1 - enable |
