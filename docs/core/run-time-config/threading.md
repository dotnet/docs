---
title: Threading config settings
description: Learn about run-time settings that configure threading for .NET Core apps.
ms.date: 11/27/2019
ms.topic: reference
---
# Run-time configuration options for threading

## CPU groups

- Configures whether threads are automatically distributed across CPU groups.
- Default: Disabled (`0`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | N/A | N/A |
| **Environment variable** | `COMPlus_Thread_UseAllCpuGroups` | `0` - disabled<br/>`1` - enabled |

## Minimum threads

- Specifies the minimum number of threads for the worker threadpool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.MinThreads` | An integer that represents the minimum number of threads |
| **Environment variable** | N/A | N/A |

## Maximum threads

- Specifies the maximum number of threads for the worker threadpool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> method.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Threading.ThreadPool.MaxThreads` | An integer that represents the maximum number of threads |
| **Environment variable** | N/A | N/A |
