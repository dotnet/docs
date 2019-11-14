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

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_gcAllowVeryLargeObjects` | 0 - disabled<br/><br/>1 - enabled |

## CPU groups

- Apples to server garbage collection (GC) only.
- Configures whether the garbage collector uses CPU groups or not. When a computer has multiple CPU groups, enabling this element extends garbage collection across all CPU groups. The garbage collector uses all cores to create and balance heaps.
- Disabled by default.
- The corresponding setting for .NET Framework apps is [GCCpuGroup](../../framework/configure-apps/file-schema/runtime/gccpugroup-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_GCCpuGroup` | 0 - disabled<br/><br/>1 - enabled |

## Latency level

- Adjusts the intrusiveness of the garbage collector into running apps.
- The default latency level is <xref:System.Runtime.GCLatencyMode.Interactive?displayProperty=nameWithType>.
- For more information, see [Latency modes](../../standard/garbage-collection/latency.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_GCLatencyLevel` | 0 - <xref:System.Runtime.GCLatencyMode.Batch><br/><br/>1 - <xref:System.Runtime.GCLatencyMode.Interactive><br/><br/>2 - <xref:System.Runtime.GCLatencyMode.LowLatency><br/><br/>3 - <xref:System.Runtime.GCLatencyMode.SustainedLowLatency> |

## GC name

- Specifies a path to the library containing the garbage collector that the runtime intends to load.
- For more information, see [Standalone GC Loader Design](https://github.com/dotnet/coreclr/blob/master/Documentation/design-docs/standalone-gc-loading.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| | | `COMPlus_GCName` | *string_path* |

## Background versus non-concurrent

- Configures whether background (concurrent) garbage collection is enabled.
- Enabled by default.
- For more information, see [Background garbage collection](../../standard/garbage-collection/fundamentals.md#background-garbage-collection) and [Background server garbage collection](../../standard/garbage-collection/fundamentals.md#background-server-garbage-collection).
- The corresponding setting for .NET Framework apps is [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.Concurrent" | true - background GC<br/><br/>false - non-concurrent GC | `COMPlus_gcConcurrent` | |

## Retain virtual memory

- Configures whether segments that should be deleted are put on a standby list for future use or are released back to the operating system (OS).
- By default, segments are released back to the operating system.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.RetainVM" | true - put on standby<br/><br/>false - release to OS | `COMPlus_GCRetainVM` | 0<br/><br/>1 |

## Workstation versus server

- Configures whether the application uses server garbage collection or workstation garbage collection.
- Workstation garbage collection is the default.
- For more information, see [Configure garbage collection](../../standard/garbage-collection/fundamentals.md#configure-garbage-collection).
- The corresponding setting for .NET Framework apps is [GCServer](../../framework/configure-apps/file-schema/runtime/gcserver-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.Server" | true - server<br/><br/>false - workstation | `COMPlus_gcServer` | 0<br/><br/>1 |

## Specific processors

- Applies to server garbage collection (GC) only.
- If processor affinity is enabled, specifies the exact processors for which a GC heap and threads are created.
- The decimal value is a mask that defines the processors that are available to the process.
- Introduced in .NET Core 3.0.
- The corresponding setting for .NET Framework apps is [GCHeapAffinitizeMask](../../framework/configure-apps/file-schema/runtime/gcheapaffinitizemask-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.HeapAffinitizeMask" | *decimal value* | `COMPlus_GCHeapAffinitizeMask` | |

## No processor affinity

- Applies to server garbage collection (GC) only.
- Specifies whether to affinitize garbage collection threads with processors. That is, whether to create a dedicated heap, GC thread, and background GC thread (if background garbage collection is enabled) for each processor.
- By default, garbage collection threads are affinitized with processors (value = `false`). Because the garbage collector uses all available processors in server GC, this can result in poor performance, particularly on systems with multiple running instances of a server application.
- Introduced in .NET Core 3.0.
- The corresponding setting for .NET Framework apps is [GCNoAffinitize](../../framework/configure-apps/file-schema/runtime/gcnoaffinitize-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.NoAffinitize" | true - don't affinitize<br/><br/>false - affinitize | `COMPlus_GCNoAffinitize` | 0<br/><br/>1 |

## Limit number of heaps

- Applies to server garbage collection (GC) only.
- Limits the number of heaps created by the garbage collector.
- If GC thread/processor affinity is disabled, this setting limits the number of GC heaps. If GC thread/processor affinity is enabled, this setting limits the number of GC heaps to the processors 0 to one-less-than its specified value.
- This setting is typically used together with "System.GC.HeapAffinitizeMask" and "System.GC.NoAffinitize". For more information, see the [GCHeapCount remarks](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md#remarks).
- Introduced in .NET Core 3.0.
- The corresponding setting for .NET Framework apps is [GCHeapCount](../../framework/configure-apps/file-schema/runtime/gcheapcount-element.md).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.HeapCount" | *number* | `COMPlus_GCHeapCount` | |

## Processor numbers

- Applies to server garbage collection (GC) only.
- Specifies the list of processors to use for garbage collector threads.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.GCHeapAffinitizeRanges" | Comma-separated list of processor numbers or ranges of processor numbers.<br/><br/>Example: "1,3,7-9,12" | `COMPlus_GCHeapAffinitizeRanges` |  |

## Heap size limit

- Specifies the maximum commit size for the GC heap.
- Introduced in .NET Core 3.0.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.HeapHardLimit" | *number* | `COMPlus_GCHeapHardLimit` | *number* |

## Heap usage as percentage

- Specifies the GC heap usage as a percentage of the total memory.
- Introduced in .NET Core 3.0.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.HeapHardLimitPercent" |  | `COMPlus_GCHeapHardLimitPercent` |  |

## Large object heap size limit

- Specifies the threshold size that causes objects to go on the large object heap (LOH).

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.LOHThreshold" |  | `COMPlus_GCLOHThreshold` |  |

## Large pages

- Specifies whether large pages should be used when a heap hard limit is set.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.GC.GCLargePages" |  | `COMPlus_GCLargePages` |  |
