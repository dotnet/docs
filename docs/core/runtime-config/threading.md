---
title: Threading config settings
description: Learn about the settings that configure threading for .NET apps.
ms.date: 11/04/2021
ms.topic: reference
---
# Runtime configuration options for threading

This article details the settings you can use to configure threading in .NET.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Use all CPU groups on Windows

- On machines that have multiple CPU groups, this setting configures whether components such as the thread pool use all CPU groups or only the primary CPU group of the process. The setting also affects what <xref:System.Environment.ProcessorCount?displayProperty=nameWithType> returns.
- When this setting is enabled, all CPU groups are used and threads are also [automatically distributed across CPU groups](#assign-threads-to-cpu-groups-on-windows) by default.
- This setting is enabled by default on Windows 11 and above, and disabled by default on Windows 10 and below. When enabling this setting, in order for it to take effect the GC must also be configured to use all CPU groups, see [GC CPU groups](./garbage-collector.md#cpu-groups).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_Thread_UseAllCpuGroups` or `DOTNET_Thread_UseAllCpuGroups` | `0` - disabled<br/>`1` - enabled |

## Assign threads to CPU groups on Windows

- On machines that have multiple CPU groups and [all CPU groups are being used](#use-all-cpu-groups-on-windows), this setting configures whether threads are automatically distributed across CPU groups.
- When this setting is enabled, new threads are assigned to a CPU group in a way that tries to fully populate a CPU group that is already in use before utilizing a new CPU group.
- This setting is enabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_Thread_AssignCpuGroups` or `DOTNET_Thread_AssignCpuGroups` | `0` - disabled<br/>`1` - enabled |

## Minimum threads

- Specifies the minimum number of threads for the worker thread pool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.MinThreads` | An integer that represents the minimum number of threads |
| **MSBuild property** | `ThreadPoolMinThreads` | An integer that represents the minimum number of threads |
| **Environment variable** | N/A | N/A |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Threading.ThreadPool.MinThreads": 4
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
  </PropertyGroup>

</Project>
```

## Maximum threads

- Specifies the maximum number of threads for the worker thread pool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> method.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.MaxThreads` | An integer that represents the maximum number of threads |
| **MSBuild property** | `ThreadPoolMaxThreads` | An integer that represents the maximum number of threads |
| **Environment variable** | N/A | N/A |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Threading.ThreadPool.MaxThreads": 20
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ThreadPoolMaxThreads>20</ThreadPoolMaxThreads>
  </PropertyGroup>

</Project>
```

## Windows thread pool

- For projects on Windows, configures whether thread pool thread management is delegated to the Windows thread pool.
- If you omit this setting or the platform is not Windows, the .NET thread pool is used instead.
- Only applications published with Native AOT on Windows use the Windows thread pool by default, for which you can opt to use the .NET thread pool instead by disabling the config setting.
- The Windows thread pool may perform better in some cases, such as in cases where the minimum number of threads is configured to a high value, or when the Windows thread pool is already being heavily used by the app. There may also be cases where the .NET thread pool performs better, such as in heavy I/O handling on larger machines. It's advisable to check performance metrics when changing this config setting.
- Some APIs are not supported when using the Windows thread pool, such as <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType>, <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType>, and <xref:System.Threading.ThreadPool.BindHandle%28System.Runtime.InteropServices.SafeHandle%29?displayProperty=nameWithType>. Thread pool config settings for minimum and maximum threads are also not effective. An alternative to <xref:System.Threading.ThreadPool.BindHandle%28System.Runtime.InteropServices.SafeHandle%29?displayProperty=nameWithType> is the <xref:System.Threading.ThreadPoolBoundHandle> class.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.UseWindowsThreadPool` | `true` - enabled<br/>`false` - disabled | .NET 8 |
| **MSBuild property** | `UseWindowsThreadPool` | `true` - enabled<br/>`false` - disabled | .NET 8 |
| **Environment variable** | `DOTNET_ThreadPool_UseWindowsThreadPool` | `1` - enabled<br/>`0` - disabled | .NET 8 |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Threading.ThreadPool.UseWindowsThreadPool": true
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <UseWindowsThreadPool>true</UseWindowsThreadPool>
  </PropertyGroup>

</Project>
```

## Thread injection in response to blocking work items

In some cases, the thread pool detects work items that block its threads. To compensate, it injects more threads. In .NET 6+, you can use the following [runtime configuration](https://github.com/dotnet/docs/blob/main/docs/core/runtime-config/index.md) settings to configure thread injection in response to blocking work items. Currently, these settings take effect only for work items that wait for another task to complete, such as in typical [sync-over-async](https://devblogs.microsoft.com/pfxteam/should-i-expose-synchronous-wrappers-for-asynchronous-methods/) cases.

| *runtimeconfig.json* setting name | Description | Version introduced |
| - | - | - |
| `System.Threading.ThreadPool.Blocking.ThreadsToAddWithoutDelay_ProcCountFactor` | After the thread count based on `MinThreads` is reached, this value (after it is multiplied by the processor count) specifies how many additional threads may be created without a delay. | .NET 6 |
| `System.Threading.ThreadPool.Blocking.ThreadsPerDelayStep_ProcCountFactor` | After the thread count based on `ThreadsToAddWithoutDelay` is reached, this value (after it is multiplied by the processor count) specifies after how many threads an additional `DelayStepMs` would be added to the delay before each new thread is created. | .NET 6 |
| `System.Threading.ThreadPool.Blocking.DelayStepMs` | After the thread count based on `ThreadsToAddWithoutDelay` is reached, this value specifies how much additional delay to add per `ThreadsPerDelayStep` threads, which would be applied before each new thread is created. | .NET 6 |
| `System.Threading.ThreadPool.Blocking.MaxDelayMs` | After the thread count based on `ThreadsToAddWithoutDelay` is reached, this value specifies the max delay to use before each new thread is created. | .NET 6 |
| `System.Threading.ThreadPool.Blocking.IgnoreMemoryUsage` | By default, the rate of thread injection in response to blocking is limited by heuristics that determine whether there is sufficient physical memory available. In some situations, it may be preferable to inject threads more quickly even in low-memory situations. You can disable the memory usage heuristics by turning off this switch. | .NET 7 |

### How the configuration settings take effect

- After the thread count based on `MinThreads` is reached, up to `ThreadsToAddWithoutDelay` additional threads may be created without a delay.
- After that, before each additional thread is created, a delay is induced, starting with `DelayStepMs`.
- For every `ThreadsPerDelayStep` threads that are added with a delay, an additional `DelayStepMs` is added to the delay.
- The delay may not exceed `MaxDelayMs`.
- Delays are only induced before creating threads. If threads are already available, they would be released without delay to compensate for blocking work items.
- Physical memory usage and limits are also used and, beyond a threshold, the system switches to slower thread injection.

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Threading.ThreadPool.Blocking.ThreadsToAddWithoutDelay_ProcCountFactor": 5
      }
   }
}
```

## `AutoreleasePool` for managed threads

This option configures whether each managed thread receives an implicit [NSAutoreleasePool](https://developer.apple.com/documentation/foundation/nsautoreleasepool) when running on a supported macOS platform.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.Threading.Thread.EnableAutoreleasePool` | `true` or `false` | .NET 6 |
| **MSBuild property** | `AutoreleasePoolSupport` | `true` or `false` | .NET 6 |
| **Environment variable** | N/A | N/A | N/A |

### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.Threading.Thread.EnableAutoreleasePool": true
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <AutoreleasePoolSupport>true</AutoreleasePoolSupport>
  </PropertyGroup>

</Project>
```
