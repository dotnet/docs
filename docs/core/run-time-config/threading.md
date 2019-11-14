---
title: Threading config settings
description: Learn about run-time settings for configuring threading.
ms.date: 11/13/2019
ms.topic: reference
---
# Run-time configuration options for threading

## CPU groups

- Configures whether threads are automatically distributed across CPU groups.
- Disabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_Thread_UseAllCpuGroups` | 0 - disabled<br/><<br/>1 - enabled |

## Minimum threads

- Specifies the minimum number of threads for the worker threadpool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Threading.ThreadPool.MinThreads" | An integer that represents the minimum number of threads |  |  |

## Maximum threads

- Specifies the maximum number of threads for the worker threadpool.
- Corresponds to the <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> method.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Threading.ThreadPool.MaxThreads" | An integer that represents the maximum number of threads |  |  |
