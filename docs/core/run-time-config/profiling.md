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

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `CORECLR_ENABLE_PROFILING` | 0 - disabled<br/><br/>1 - enabled |

## Profiler GUID

- Specifies the GUID of the profiler to load into the currently running process.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `CORECLR_PROFILER` | *string-guid* |

## Profiler location

- Specifies the path to the profiler DLL to load into the currently running process (or 32-bit or 64-bit process).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `CORECLR_PROFILER_PATH` | *string-path* |
| | | `CORECLR_PROFILER_PATH_32` | *string-path* |
| | | `CORECLR_PROFILER_PATH_64` | *string-path* |

## Write perf map

- Enables or disables writing */tmp/perf-$pid.map* on Linux systems.
- Disabled by default

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `PerfMapEnabled` | 0 - disable<br/><br/>1 - enable |

## Perf log markers

- When `PerfMapEnabled` is set to 1, enables or disables the specified signal to be accepted and ignored as a marker in the perf logs.
- Disabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `PerfMapIgnoreSignal` | 0 - disable<br/><br/>1 - enable |
