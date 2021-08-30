---
title: Threading config settings
description: Learn about run-time settings that configure threading for .NET Core apps.
ms.date: 11/27/2019
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

## `AutoreleasePool` for managed threads

- Configures whether each managed thread receives an implicit [`NSAutoreleasePool`](https://developer.apple.com/documentation/foundation/nsautoreleasepool) when running on a supported macOS platform.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.Threading.Thread.EnableAutoreleasePool` | `true` or `false` | .NET 6.0 |
| **MSBuild property** | `AutoreleasePoolSupport` | `true` or `false` | .NET 6.0 |
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
