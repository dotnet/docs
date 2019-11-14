---
title: Garbage collector config settings
description: Learn about run-time settings for configuring how the garbage collector manages memory.
ms.date: 11/13/2019
ms.topic: reference
---
# Run-time configuration options for garbage collection

## Large objects

- Configures garbage collector support on 64-bit platforms for arrays that are greater than 2 gigabytes (GB) in total size.
- Enabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `COMPlus_gcAllowVeryLargeObjects` | (DWORD)<br/>0 - disabled<br/>1 - enabled |

## CPU groups

- Apples to server garbage collection (GC) only.
- Configures whether the garbage collector uses CPU groups or not. When a computer has multiple CPU groups, enabling this element extends garbage collection across all CPU groups. The garbage collector uses all cores to create and balance heaps.
- Disabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `COMPlus_GCCpuGroup` | (DWORD)<br/>0 - disabled<br/>1 - enabled |
| **app.config for .NET Framework** | [GCCpuGroup](../../framework/configure-apps/file-schema/runtime/gccpugroup-element.md) | |

## Latency level

- Adjusts the intrusiveness of the garbage collector into running apps.
- The default latency level is <xref:System.Runtime.GCLatencyMode.Interactive?displayProperty=nameWithType>.
- For more information, see [Latency modes](../../standard/garbage-collection/latency.md).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `COMPlus_GCLatencyLevel` | (DWORD)<br/>0 - <xref:System.Runtime.GCLatencyMode.Batch><br/>1 - <xref:System.Runtime.GCLatencyMode.Interactive><br/>2 - <xref:System.Runtime.GCLatencyMode.LowLatency><br/>3 - <xref:System.Runtime.GCLatencyMode.SustainedLowLatency> |

## GC name

- Specifies a path to the library containing the garbage collector that the runtime intends to load.
- For more information, see [Standalone GC Loader Design](https://github.com/dotnet/coreclr/blob/master/Documentation/design-docs/standalone-gc-loading.md).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** |  |  |
| **Environment variable** | `COMPlus_GCName` | *string_path* |

## Background versus non-concurrent

- Configures whether background (concurrent) garbage collection is enabled.
- Enabled by default.
- For more information, see [Background garbage collection](../../standard/garbage-collection/fundamentals.md#background-workstation-garbage-collection) and [Background server garbage collection](../../standard/garbage-collection/fundamentals.md#background-server-garbage-collection).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.Concurrent` | true - background GC<br/>false - non-concurrent GC |
| **Environment variable** | `COMPlus_gcConcurrent` |  |
| **app.config for .NET Framework** | [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) | |

## Retain virtual memory

- Configures whether segments that should be deleted are put on a standby list for future use or are released back to the operating system (OS).
- By default, segments are released back to the operating system.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.RetainVM` | true - put on standby<br/>false - release to OS |
| **Environment variable** | `COMPlus_GCRetainVM` | (DWORD)<br/>0<br/>1 |

## Workstation versus server

- Configures whether the application uses server garbage collection or workstation garbage collection.
- Workstation garbage collection is the default.
- For more information, see [Configure garbage collection](../../standard/garbage-collection/fundamentals.md#configuring-garbage-collection).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.Server` | true - server<br/>false - workstation |
| **Environment variable** | `COMPlus_gcServer` | (DWORD)<br/>0<br/>1 |
| **app.config for .NET Framework** | [GCServer](../../framework/configure-apps/file-schema/runtime/gcserver-element.md) | |

## Specific processors

- Applies to server garbage collection (GC) only.
- If processor affinity is enabled, specifies the exact processors for which a GC heap and threads are created.
- The decimal value is a mask that defines the processors that are available to the process.
- Introduced in .NET Core 3.0.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.HeapAffinitizeMask` | *decimal value* |
| **Environment variable** | `COMPlus_GCHeapAffinitizeMask` |  |
| **app.config for .NET Framework** | [GCHeapAffinitizeMask](../../framework/configure-apps/file-schema/runtime/gcheapaffinitizemask-element.md) | |

## No processor affinity

- Applies to server garbage collection (GC) only.
- Specifies whether to affinitize garbage collection threads with processors. That is, whether to create a dedicated heap, GC thread, and background GC thread (if background garbage collection is enabled) for each processor.
- By default, garbage collection threads are affinitized with processors (value = `false`). Because the garbage collector uses all available processors in server GC, this can result in poor performance, particularly on systems with multiple running instances of a server application.
- Introduced in .NET Core 3.0.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.NoAffinitize` | true - don't affinitize<br/>false - affinitize |
| **Environment variable** | `COMPlus_GCNoAffinitize` | (DWORD)<br/>0<br/>1 |
| **app.config for .NET Framework** | [GCNoAffinitize](../../framework/configure-apps/file-schema/runtime/gcnoaffinitize-element.md) | |

## Limit number of heaps

- Applies to server garbage collection (GC) only.
- Limits the number of heaps created by the garbage collector.
- If GC thread/processor affinity is disabled, this setting limits the number of GC heaps. If GC thread/processor affinity is enabled, this setting limits the number of GC heaps to the processors 0 to one-less-than its specified value.
- This setting is typically used together with "System.GC.HeapAffinitizeMask" and "System.GC.NoAffinitize". For more information, see the [GCHeapCount remarks](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md#remarks).
- Introduced in .NET Core 3.0.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.HeapCount` | *number* |
| **Environment variable** | `COMPlus_GCHeapCount` |  |
| **app.config for .NET Framework** | [GCHeapCount](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md) | |

## Processor numbers

- Applies to server garbage collection (GC) only.
- Specifies the list of processors to use for garbage collector threads.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.GCHeapAffinitizeRanges` | Comma-separated list of processor numbers or ranges of processor numbers.<br/>Example: "1,3,7-9,12" |
| **Environment variable** | `COMPlus_GCHeapAffinitizeRanges` |  |

## Heap size limit

- Specifies the maximum commit size for the GC heap.
- Introduced in .NET Core 3.0.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimit` | *number* |
| **Environment variable** | `COMPlus_GCHeapHardLimit` | (DWORD) *number* |

## Heap usage as percentage

- Specifies the GC heap usage as a percentage of the total memory.
- Introduced in .NET Core 3.0.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.HeapHardLimitPercent` |  |
| **Environment variable** | `COMPlus_GCHeapHardLimitPercent` |  |

## Large object heap size limit

- Specifies the threshold size that causes objects to go on the large object heap (LOH).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.LOHThreshold` |  |
| **Environment variable** | `COMPlus_GCLOHThreshold` |  |

## Large pages

- Specifies whether large pages should be used when a heap hard limit is set.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.GC.GCLargePages` |  |
| **Environment variable** | `COMPlus_GCLargePages` |  |
