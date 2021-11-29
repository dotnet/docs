---
title: Garbage collector config settings
description: Learn about run-time settings for configuring how the garbage collector manages memory for .NET Core apps.
ms.date: 07/10/2020
ms.topic: reference
---
# Runtime configuration options for garbage collection

This page contains information about garbage collector (GC) settings that can be changed at run time. If you're trying to achieve peak performance of a running app, consider using these settings. However, the defaults provide optimum performance for most applications in typical situations.

Settings are arranged into groups on this page. The settings within each group are commonly used in conjunction with each other to achieve a specific result.

> [!NOTE]
>
> - These settings can also be changed dynamically by the app as it's running, so any run-time settings you set may be overridden.
> - Some settings, such as [latency level](../../standard/garbage-collection/latency.md), are typically set only through the API at design time. Such settings are omitted from this page.
> - For number values, use decimal notation for settings in the *runtimeconfig.json* file and hexadecimal notation for environment variable settings. For hexadecimal values, you can specify them with or without the "0x" prefix.
> - If you're using the environment variables, .NET 6 standardizes on the prefix `DOTNET_` instead of `COMPlus_`. However, the `COMPlus_` prefix will continue to work. If you're using a previous version of the .NET runtime, you should still use the `COMPlus_` prefix, for example, `COMPlus_gcServer`.

## Flavors of garbage collection

The two main flavors of garbage collection are workstation GC and server GC. For more information about differences between the two, see [Workstation and server garbage collection](../../standard/garbage-collection/workstation-server-gc.md).

The subflavors of garbage collection are background and non-concurrent.

Use the following settings to select flavors of garbage collection:

- [Workstation vs. server GC](#workstation-vs-server)
- [Background GC](#background-gc)

### Workstation vs. server

- Configures whether the application uses workstation garbage collection or server garbage collection.
- Default: Workstation garbage collection. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Server` | `false` - workstation<br/>`true` - server | .NET Core 1.0 |
| **MSBuild property** | `ServerGarbageCollection` | `false` - workstation<br/>`true` - server | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcServer` | `0` - workstation<br/>`1` - server | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcServer` | `0` - workstation<br/>`1` - server | .NET 6 |
| **app.config for .NET Framework** | [GCServer](../../framework/configure-apps/file-schema/runtime/gcserver-element.md) | `false` - workstation<br/>`true` - server |  |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.Server": true
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ServerGarbageCollection>true</ServerGarbageCollection>
  </PropertyGroup>

</Project>
```

### Background GC

- Configures whether background (concurrent) garbage collection is enabled.
- Default: Use background GC. This is equivalent to setting the value to `true`.
- For more information, see [Background garbage collection](../../standard/garbage-collection/background-gc.md).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Concurrent` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **MSBuild property** | `ConcurrentGarbageCollection` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcConcurrent` | `1` - background GC<br/>`0` - non-concurrent GC | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcConcurrent` | `1` - background GC<br/>`0` - non-concurrent GC | .NET 6 |
| **app.config for .NET Framework** | [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) | `true` - background GC<br/>`false` - non-concurrent GC |  |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.Concurrent": false
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
  </PropertyGroup>

</Project>
```

## Manage resource usage

Use the following settings to manage the garbage collector's memory and processor usage:

- [Affinitize](#affinitize)
- [Affinitize mask](#affinitize-mask)
- [Affinitize ranges](#affinitize-ranges)
- [CPU groups](#cpu-groups)
- [Heap count](#heap-count)
- [Heap limit](#heap-limit)
- [Heap limit percent](#heap-limit-percent)
- [High memory percent](#high-memory-percent)
- [Per-object-heap limits](#per-object-heap-limits)
- [Per-object-heap limit percents](#per-object-heap-limit-percents)
- [Retain VM](#retain-vm)

For more information about some of these settings, see the [Middle ground between workstation and server GC](https://devblogs.microsoft.com/dotnet/middle-ground-between-server-and-workstation-gc/) blog entry.

### Heap count

- Limits the number of heaps created by the garbage collector.
- Applies to server garbage collection only.
- If [GC processor affinity](#affinitize) is enabled, which is the default, the heap count setting affinitizes `n` GC heaps/threads to the first `n` processors. (Use the [affinitize mask](#affinitize-mask) or [affinitize ranges](#affinitize-ranges) settings to specify exactly which processors to affinitize.)
- If [GC processor affinity](#affinitize) is disabled, this setting limits the number of GC heaps.
- For more information, see the [GCHeapCount remarks](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md#remarks).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapCount` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapCount` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapCount` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCHeapCount](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md) | *decimal value* | .NET Framework 4.6.2 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapCount": 16
      }
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the number of heaps to 16, the values would be 16 for the JSON file and 0x10 or 10 for the environment variable.

### Affinitize mask

- Specifies the exact processors that garbage collector threads should use.
- If [GC processor affinity](#affinitize) is disabled, this setting is ignored.
- Applies to server garbage collection only.
- The value is a bit mask that defines the processors that are available to the process. For example, a decimal value of 1023 (or a hexadecimal value of 0x3FF or 3FF if you're using the environment variable) is 0011 1111 1111 in binary notation. This specifies that the first 10 processors are to be used. To specify the next 10 processors, that is, processors 10-19, specify a decimal value of 1047552 (or a hexadecimal value of 0xFFC00 or FFC00), which is equivalent to a binary value of 1111 1111 1100 0000 0000.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapAffinitizeMask` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeMask` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapAffinitizeMask` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCHeapAffinitizeMask](../../framework/configure-apps/file-schema/runtime/gcheapaffinitizemask-element.md) | *decimal value* | .NET Framework 4.6.2 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapAffinitizeMask": 1023
      }
   }
}
```

### Affinitize ranges

- Specifies the list of processors to use for garbage collector threads.
- This setting is similar to [System.GC.HeapAffinitizeMask](#affinitize-mask), except it allows you to specify more than 64 processors.
- For Windows operating systems, prefix the processor number or range with the corresponding [CPU group](/windows/win32/procthread/processor-groups), for example, "0:1-10,0:12,1:50-52,1:70".
- If [GC processor affinity](#affinitize) is disabled, this setting is ignored.
- Applies to server garbage collection only.
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:70" | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:70" | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:70" | .NET 6 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.GCHeapAffinitizeRanges": "0:1-10,0:12,1:50-52,1:70"
      }
   }
}
```

### CPU groups

- Configures whether the garbage collector uses [CPU groups](/windows/win32/procthread/processor-groups) or not.

  When a 64-bit Windows computer has multiple CPU groups, that is, there are more than 64 processors, enabling this element extends garbage collection across all CPU groups. The garbage collector uses all cores to create and balance heaps.

- Applies to server garbage collection on 64-bit Windows operating systems only.
- Default: GC does not extend across CPU groups. This is equivalent to setting the value to `0`.
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.CpuGroup` | `0` - disabled<br/>`1` - enabled | .NET 5 |
| **Environment variable** | `COMPlus_GCCpuGroup` | `0` - disabled<br/>`1` - enabled | .NET Core 1.0 |
| **Environment variable** | `DOTNET_GCCpuGroup` | `0` - disabled<br/>`1` - enabled | .NET 6 |
| **app.config for .NET Framework** | [GCCpuGroup](../../framework/configure-apps/file-schema/runtime/gccpugroup-element.md) | `false` - disabled<br/>`true` - enabled |  |

> [!NOTE]
> To configure the common language runtime (CLR) to also distribute threads from the thread pool across all CPU groups, enable the [Thread_UseAllCpuGroups element](../../framework/configure-apps/file-schema/runtime/thread-useallcpugroups-element.md) option. For .NET Core apps, you can enable this option by setting the value of the `DOTNET_Thread_UseAllCpuGroups` environment variable to `1`.

### Affinitize

- Specifies whether to *affinitize* garbage collection threads with processors. To affinitize a GC thread means that it can only run on its specific CPU. A heap is created for each GC thread.
- Applies to server garbage collection only.
- Default: Affinitize garbage collection threads with processors. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.NoAffinitize` | `false` - affinitize<br/>`true` - don't affinitize | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCNoAffinitize` | `0` - affinitize<br/>`1` - don't affinitize | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCNoAffinitize` | `0` - affinitize<br/>`1` - don't affinitize | .NET 6 |
| **app.config for .NET Framework** | [GCNoAffinitize](../../framework/configure-apps/file-schema/runtime/gcnoaffinitize-element.md) | `false` - affinitize<br/>`true` - don't affinitize | .NET Framework 4.6.2 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.NoAffinitize": true
      }
   }
}
```

### Heap limit

- Specifies the maximum commit size, in bytes, for the GC heap and GC bookkeeping.
- This setting only applies to 64-bit computers.
- This setting is ignored if the [Per-object-heap limits](#per-object-heap-limits) are configured.
- The default value, which only applies in certain cases, is the greater of 20 MB or 75% of the memory limit on the container. The default value applies if:

  - The process is running inside a container that has a specified memory limit.
  - [System.GC.HeapHardLimitPercent](#heap-limit-percent) is not set.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimit` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimit` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapHardLimit` | *hexadecimal value* | .NET 6 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapHardLimit": 209715200
      }
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to specify a heap hard limit of 200 mebibytes (MiB), the values would be 209715200 for the JSON file and 0xC800000 or C800000 for the environment variable.

### Heap limit percent

- Specifies the allowable GC heap usage as a percentage of the total physical memory.
- If [System.GC.HeapHardLimit](#heap-limit) is also set, this setting is ignored.
- This setting only applies to 64-bit computers.
- If the process is running inside a container that has a specified memory limit, the percentage is calculated as a percentage of that memory limit.
- This setting is ignored if the [Per-object-heap limits](#per-object-heap-limits) are configured.
- The default value, which only applies in certain cases, is the greater of 20 MB or 75% of the memory limit on the container. The default value applies if:

  - The process is running inside a container that has a specified memory limit.
  - [System.GC.HeapHardLimit](#heap-limit) is not set.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPercent` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPercent` | *hexadecimal value* | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPercent` | *hexadecimal value* | .NET 6 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.HeapHardLimitPercent": 30
      }
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the heap usage to 30%, the values would be 30 for the JSON file and 0x1E or 1E for the environment variable.

### Per-object-heap limits

You can specify the GC's allowable heap usage on a per-object-heap basis. The different heaps are the large object heap (LOH), small object heap (SOH), and pinned object heap (POH).

- If you specify a value for any of the `DOTNET_GCHeapHardLimitSOH`, `DOTNET_GCHeapHardLimitLOH`, or `DOTNET_GCHeapHardLimitPOH` settings, you must also specify a value for `DOTNET_GCHeapHardLimitSOH` and `DOTNET_GCHeapHardLimitLOH`. If you don't, the runtime will fail to initialize.
- The default value for `DOTNET_GCHeapHardLimitPOH` is 0. `DOTNET_GCHeapHardLimitSOH` and `DOTNET_GCHeapHardLimitLOH` don't have default values.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitSOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitSOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitSOH` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitLOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitLOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitLOH` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPOH` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPOH` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPOH` | *hexadecimal value* | .NET 6 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to specify a heap hard limit of 200 mebibytes (MiB), the values would be 209715200 for the JSON file and 0xC800000 or C800000 for the environment variable.

### Per-object-heap limit percents

You can specify the GC's allowable heap usage on a per-object-heap basis. The different heaps are the large object heap (LOH), small object heap (SOH), and pinned object heap (POH).

- If you specify a value for any of the `DOTNET_GCHeapHardLimitSOHPercent`, `DOTNET_GCHeapHardLimitLOHPercent`, or `DOTNET_GCHeapHardLimitPOHPercent` settings, you must also specify a value for `DOTNET_GCHeapHardLimitSOHPercent` and `DOTNET_GCHeapHardLimitLOHPercent`. If you don't, the runtime will fail to initialize.
- These settings are ignored if `DOTNET_GCHeapHardLimitSOH`, `DOTNET_GCHeapHardLimitLOH`, and `DOTNET_GCHeapHardLimitPOH` are specified.
- A value of 1 means that GC uses 1% of total physical memory for that object heap.
- Each value must be greater than zero and less than 100. Additionally, the sum of the three percentage values must be less than 100. Otherwise, the runtime will fail to initialize.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitSOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitSOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitSOHPercent` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitLOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitLOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitLOHPercent` | *hexadecimal value* | .NET 6 |

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPOHPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPOHPercent` | *hexadecimal value* | .NET 5 |
| **Environment variable** | `DOTNET_GCHeapHardLimitPOHPercent` | *hexadecimal value* | .NET 6 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the heap usage to 30%, the values would be 30 for the JSON file and 0x1E or 1E for the environment variable.

### High memory percent

Memory load is indicated by the percentage of physical memory in use. By default, when the physical memory load reaches **90%**, garbage collection becomes more aggressive about doing full, compacting garbage collections to avoid paging. When memory load is below 90%, GC favors background collections for full garbage collections, which have shorter pauses but don't reduce the total heap size by much. On machines with a significant amount of memory (80GB or more), the default load threshold is between 90% and 97%.

The high memory load threshold can be adjusted by the `DOTNET_GCHighMemPercent` environment variable or `System.GC.HighMemoryPercent` JSON configuration setting. Consider adjusting the threshold if you want to control heap size. For example, for the dominant process on a machine with 64GB of memory, it's reasonable for GC to start reacting when there's 10% of memory available. But for smaller processes, for example, a process that only consumes 1GB of memory, GC can comfortably run with less than 10% of memory available. For these smaller processes, consider setting the threshold higher. On the other hand, if you want larger processes to have smaller heap sizes (even when there's plenty of physical memory available), lowering this threshold is an effective way for GC to react sooner to compact the heap down.

> [!NOTE]
> For processes running in a container, GC considers the physical memory based on the container limit.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HighMemoryPercent` | *decimal value* | .NET 5 |
| **Environment variable** | `COMPlus_GCHighMemPercent` | *hexadecimal value* | .NET Core 3.0<br/>.NET Framework 4.7.2 |
| **Environment variable** | `DOTNET_GCHighMemPercent` | *hexadecimal value* | .NET 6 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to set the high memory threshold to 75%, the values would be 75 for the JSON file and 0x4B or 4B for the environment variable.

### Retain VM

- Configures whether segments that should be deleted are put on a standby list for future use or are released back to the operating system (OS).
- Default: Release segments back to the operating system. This is equivalent to setting the value to `false`.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.RetainVM` | `false` - release to OS<br/>`true` - put on standby | .NET Core 1.0 |
| **MSBuild property** | `RetainVMGarbageCollection` | `false` - release to OS<br/>`true` - put on standby | .NET Core 1.0 |
| **Environment variable** | `COMPlus_GCRetainVM` | `0` - release to OS<br/>`1` - put on standby | .NET Core 1.0 |
| **Environment variable** | `DOTNET_GCRetainVM` | `0` - release to OS<br/>`1` - put on standby | .NET 6 |

#### Examples

*runtimeconfig.json* file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.RetainVM": true
      }
   }
}
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <RetainVMGarbageCollection>true</RetainVMGarbageCollection>
  </PropertyGroup>

</Project>
```

## Large pages

- Specifies whether large pages should be used when a heap hard limit is set.
- Default: Don't use large pages when a heap hard limit is set. This is equivalent to setting the value to `0`.
- This is an experimental setting.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCLargePages` | `0` - disabled<br/>`1` - enabled | .NET Core 3.0 |
| **Environment variable** | `DOTNET_GCLargePages` | `0` - disabled<br/>`1` - enabled | .NET 6 |

## Allow large objects

- Configures garbage collector support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.
- Default: GC supports arrays greater than 2-GB. This is equivalent to setting the value to `1`.
- This option may become obsolete in a future version of .NET.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_gcAllowVeryLargeObjects` | `1` - enabled<br/> `0` - disabled | .NET Core 1.0 |
| **Environment variable** | `DOTNET_gcAllowVeryLargeObjects` | `1` - enabled<br/> `0` - disabled | .NET 6 |
| **app.config for .NET Framework** | [gcAllowVeryLargeObjects](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) | `1` - enabled<br/> `0` - disabled | .NET Framework 4.5 |

## Large object heap threshold

- Specifies the threshold size, in bytes, that causes objects to go on the large object heap (LOH).
- The default threshold is 85,000 bytes.
- The value you specify must be larger than the default threshold.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.LOHThreshold` | *decimal value* | .NET Core 1.0 |
| **Environment variable** | `COMPlus_GCLOHThreshold` | *hexadecimal value* | .NET Core 1.0 |
| **Environment variable** | `DOTNET_GCLOHThreshold` | *hexadecimal value* | .NET 6 |
| **app.config for .NET Framework** | [GCLOHThreshold](../../framework/configure-apps/file-schema/runtime/gclohthreshold-element.md) | *decimal value* | .NET Framework 4.8 |

Example:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.LOHThreshold": 120000
      }
   }
}
```

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to set a threshold size of 120,000 bytes, the values would be 120000 for the JSON file and 0x1D4C0 or 1D4C0 for the environment variable.

## Standalone GC

- Specifies a path to the library containing the garbage collector that the runtime intends to load.
- For more information, see [Standalone GC loader design](https://github.com/dotnet/runtime/blob/main/docs/design/features/standalone-gc-loading.md).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCName` | *string_path* | .NET Core 2.0 |
| **Environment variable** | `DOTNET_GCName` | *string_path* | .NET 6 |
