---
title: Garbage collector config settings
description: Learn about run-time settings for configuring how the garbage collector manages memory for .NET Core apps.
ms.date: 11/13/2019
ms.topic: reference
---
# Run-time configuration options for garbage collection

This page contains information about garbage collector (GC) settings that can be changed at run time. If you're trying to achieve peak performance of a running app, consider using these settings. However, the defaults provide optimum performance for most applications in typical situations.

Settings are arranged into groups on this page. The settings within each group are commonly used in conjunction with each other to achieve a specific result.

> [!NOTE]
>
> - These settings can also be changed dynamically by the app as it's running, so any run-time settings you set may be overridden.
> - Some settings, such as [latency level](../../standard/garbage-collection/latency.md), are typically set only through the API at design time. Such settings are omitted from this page.
> - For number values, use decimal notation for settings in the *runtimeconfig.json* file and hexadecimal notation for environment variable settings.

## Flavors of garbage collection

The two main flavors of garbage collection are workstation GC and server GC. For more information about differences between the two, see [Fundamentals of garbage collection](../../standard/garbage-collection/fundamentals.md#workstation-and-server-garbage-collection).

The subflavors of garbage collection are background and non-concurrent.

Use the following settings to select flavors of garbage collection:

### System.GC.Server/COMPlus_gcServer

- Configures whether the application uses workstation garbage collection or server garbage collection.
- Default: Workstation garbage collection (`false`).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Server` | `false` - workstation<br/>`true` - server | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcServer` | `0` - workstation<br/>`1` - server | .NET Core 1.0 |
| **app.config for .NET Framework** | [GCServer](../../framework/configure-apps/file-schema/runtime/gcserver-element.md) | `false` - workstation<br/>`true` - server |  |

### System.GC.Concurrent/COMPlus_gcConcurrent

- Configures whether background (concurrent) garbage collection is enabled.
- Default: Enabled (`true`).
- For more information, see [Background garbage collection](../../standard/garbage-collection/fundamentals.md#background-workstation-garbage-collection) and [Background server garbage collection](../../standard/garbage-collection/fundamentals.md#background-server-garbage-collection).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.Concurrent` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **Environment variable** | `COMPlus_gcConcurrent` | `true` - background GC<br/>`false` - non-concurrent GC | .NET Core 1.0 |
| **app.config for .NET Framework** | [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) | `true` - background GC<br/>`false` - non-concurrent GC |  |

## Manage resource usage

Use the settings described in this section to manage the garbage collector's memory and processor usage.

For more information about some of these settings, see the [Middle ground between workstation and server GC](https://devblogs.microsoft.com/dotnet/middle-ground-between-server-and-workstation-gc/) blog entry.

### System.GC.HeapCount/COMPlus_GCHeapCount

- Limits the number of heaps created by the garbage collector.
- Applies to server garbage collection (GC) only.
- If GC processor affinity is enabled, which is the default, the heap count setting affinitizes `n` GC heaps/threads to the first `n` processors. (Use the affinitize mask or affinitize ranges settings to specify exactly which processors to affinitize.)
- If GC processor affinity is disabled, this setting limits the number of GC heaps.
- For more information, see the [GCHeapCount remarks](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md#remarks).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapCount` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapCount` | *hexadecimal value* | .NET Core 3.0 |
| **app.config for .NET Framework** | [GCHeapCount](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md) | *decimal value* | 4.6.2 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the number of heaps to 16, the values would be 16 for the JSON file and 10 for the environment variable.

### System.GC.HeapAffinitizeMask/COMPlus_GCHeapAffinitizeMask

- Specifies the exact processors that garbage collector threads should use.
- If processor affinity is disabled by setting `System.GC.NoAffinitize` to `true`, this setting is ignored.
- Applies to server garbage collection (GC) only.
- The value is a bit mask that defines the processors that are available to the process. For example, a decimal value of 1023 (or a hexadecimal value of 3FF if you're using the environment variable) is 0011 1111 1111 in binary notation. This specifies that the first 10 processors are to be used. To specify the next 10 processors, that is, processors 10-19, specify a decimal value of 1047552 (or a hexadecimal value of FFC00), which is equivalent to a binary value of 1111 1111 1100 0000 0000.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapAffinitizeMask` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeMask` | *hexadecimal value* | .NET Core 3.0 |
| **app.config for .NET Framework** | [GCHeapAffinitizeMask](../../framework/configure-apps/file-schema/runtime/gcheapaffinitizemask-element.md) | *decimal value* | 4.6.2 |

### System.GC.GCHeapAffinitizeRanges/COMPlus_GCHeapAffinitizeRanges

- Specifies the list of processors to use for garbage collector threads.
- This setting is similar to `System.GC.HeapAffinitizeMask`, except it allows you to specify more than 64 processors.
- For Windows operating systems, prefix the processor number or range with the corresponding [CPU group](/windows/win32/procthread/processor-groups), for example, "0:1-10,0:12,1:50-52,1:70".
- If processor affinity is disabled by setting `System.GC.NoAffinitize` to `true`, this setting is ignored.
- Applies to server garbage collection (GC) only.
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:70" | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Unix example: "1-10,12,50-52,70"<br/>Windows example: "0:1-10,0:12,1:50-52,1:70" | .NET Core 3.0 |

### COMPlus_GCCpuGroup

- Configures whether the garbage collector uses [CPU groups](/windows/win32/procthread/processor-groups) or not.

  When a 64-bit Windows computer has multiple CPU groups, that is, there are more than 64 processors, enabling this element extends garbage collection across all CPU groups. The garbage collector uses all cores to create and balance heaps.

- Applies to server garbage collection (GC) on 64-bit Windows operation systems only.
- Default: Disabled (`0`).
- For more information, see [Making CPU configuration better for GC on machines with > 64 CPUs](https://devblogs.microsoft.com/dotnet/making-cpu-configuration-better-for-gc-on-machines-with-64-cpus/) on Maoni Stephens' blog.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCCpuGroup` | `0` - disabled<br/>`1` - enabled | .NET Core 1.0 |
| **app.config for .NET Framework** | [GCCpuGroup](../../framework/configure-apps/file-schema/runtime/gccpugroup-element.md) | `false` - disabled<br/>`true` - enabled |  |

> [!NOTE]
> To configure the common language runtime (CLR) to also distribute threads from the thread pool across all CPU groups, enable the [Thread_UseAllCpuGroups element](../../framework/configure-apps/file-schema/runtime/thread-useallcpugroups-element.md) option. For .NET Core apps, you can enable this option by setting the value of the `COMPlus_Thread_UseAllCpuGroups` environment variable to `1`.

### System.GC.NoAffinitize/COMPlus_GCNoAffinitize

- Specifies whether to *affinitize* garbage collection threads with processors. To affinitize a GC thread means that it can only run on its specific CPU. A heap is created for each GC thread.
- Applies to server garbage collection (GC) only.
- Default: Affinitize garbage collection threads with processors (`false`).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.NoAffinitize` | `false` - affinitize<br/>`true` - don't affinitize | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCNoAffinitize` | `0` - affinitize<br/>`1` - don't affinitize | .NET Core 3.0 |
| **app.config for .NET Framework** | [GCNoAffinitize](../../framework/configure-apps/file-schema/runtime/gcnoaffinitize-element.md) | `false` - affinitize<br/>`true` - don't affinitize | 4.6.2 |

### System.GC.HeapHardLimit/COMPlus_GCHeapHardLimit

- Specifies the maximum commit size, in bytes, for the GC heap and GC bookkeeping.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimit` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimit` | *hexadecimal value* | .NET Core 3.0 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to specify a heap hard limit of 80,000 bytes, the values would be 80000 for the JSON file and 13880 for the environment variable.

### System.GC.HeapHardLimitPercent/COMPlus_GCHeapHardLimitPercent

- Specifies the GC heap usage as a percentage of the total memory.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPercent` | *decimal value* | .NET Core 3.0 |
| **Environment variable** | `COMPlus_GCHeapHardLimitPercent` | *hexadecimal value* | .NET Core 3.0 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to limit the heap usage to 30%, the values would be 30 for the JSON file and 1E for the environment variable.

### System.GC.RetainVM/COMPlus_GCRetainVM

- Configures whether segments that should be deleted are put on a standby list for future use or are released back to the operating system (OS).
- Default: Release segments back to the operating system (`false`).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.RetainVM` | `false` - release to OS<br/>`true` - put on standby| .NET Core 1.0 |
| **Environment variable** | `COMPlus_GCRetainVM` | `0` - release to OS<br/>`1` - put on standby | .NET Core 1.0 |

## Large pages

### COMPlus_GCLargePages

- Specifies whether large pages should be used when a heap hard limit is set.
- Default: Disabled (`0`).
- This is an experimental setting.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCLargePages` | `0` - disabled<br/>`1` - enabled | .NET Core 3.0 |

## Large objects

### COMPlus_gcAllowVeryLargeObjects

- Configures garbage collector support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.
- Default: Enabled (`1`).
- This option may become obsolete in a future version of .NET.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_gcAllowVeryLargeObjects` | `1` - enabled<br/> `0` - disabled | .NET Core 1.0 |
| **app.config for .NET Framework** | [gcAllowVeryLargeObjects](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) | `1` - enabled<br/> `0` - disabled | .NET Framework 4.5 |

## Large object heap threshold

### System.GC.LOHThreshold/COMPlus_GCLOHThreshold

- Specifies the threshold size, in bytes, that causes objects to go on the large object heap (LOH).
- The default threshold is 85,000 bytes.
- The value you specify must be larger than the default threshold.

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | `System.GC.LOHThreshold` | *decimal value* | .NET Core 1.0 |
| **Environment variable** | `COMPlus_GCLOHThreshold` | *hexadecimal value* | .NET Core 1.0 |
| **app.config for .NET Framework** | [GCLOHThreshold](../../framework/configure-apps/file-schema/runtime/gclohthreshold-element.md) | *decimal value* | .NET Framework 4.8 |

> [!TIP]
> If you're setting the option in *runtimeconfig.json*, specify a decimal value. If you're setting the option as an environment variable, specify a hexadecimal value. For example, to set a threshold size of 120,000 bytes, the values would be 120000 for the JSON file and 1D4C0 for the environment variable.

## Standalone GC

### COMPlus_GCName

- Specifies a path to the library containing the garbage collector that the runtime intends to load.
- For more information, see [Standalone GC loader design](https://github.com/dotnet/coreclr/blob/master/Documentation/design-docs/standalone-gc-loading.md).

| | Setting name | Values | Version introduced |
| - | - | - | - |
| **runtimeconfig.json** | N/A | N/A | N/A |
| **Environment variable** | `COMPlus_GCName` | *string_path* | .NET Core 2.0 |
