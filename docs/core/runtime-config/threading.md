---
title: Threading config settings
description: Learn about the settings that configure threading for .NET Core apps.
ms.date: 11/04/2021
ms.topic: reference
---
# Runtime configuration options for threading

This article details the settings you can use to configure threading in .NET.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## CPU groups

- Configures whether threads are automatically distributed across CPU groups.
- If you omit this setting, threads are not distributed across CPU groups. This is equivalent to setting the value to `0`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_Thread_UseAllCpuGroups` or `DOTNET_Thread_UseAllCpuGroups` | `0` - disabled<br/>`1` - enabled |

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

- For projects on Windows, configures whether the thread management is delegated to the Windows thread pool.
- If you omit this setting or the platform is not Windows, the managed (portable) thread pool is used instead.
- Only applications published with Native AOT on Windows use the Windows thread pool by default, for which you can opt to use the managed thread pool instead by disabling the config setting.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.UseWindowsThreadPool` | `true` - enabled<br/>`false` - disabled |
| **MSBuild property** | `UseWindowsThreadPool` | `true` - enabled<br/>`false` - disabled |
| **Environment variable** | `DOTNET_ThreadPool_UseWindowsThreadPool` | `0` - disabled<br/>`1` - enabled |

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
