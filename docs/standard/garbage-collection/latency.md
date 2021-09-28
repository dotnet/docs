---
description: "Learn more about: Latency modes"
title: "Latency Modes"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "garbage collection, intrusiveness"
  - "garbage collection, latency modes"
ms.assetid: 96278bb7-6eab-4612-8594-ceebfc887d81
---
# Latency modes

To reclaim objects, the garbage collector (GC) must stop all the executing threads in an application. The period of time during which the garbage collector is active is referred to as its *latency*.

In some situations, such as when an application retrieves data or displays content, a full garbage collection can occur at a critical time and impede performance. You can adjust the intrusiveness of the garbage collector by setting the <xref:System.Runtime.GCSettings.LatencyMode%2A?displayProperty=nameWithType> property to one of the <xref:System.Runtime.GCLatencyMode?displayProperty=nameWithType> values.

## Low latency settings

Using a "low" latency setting means the garbage collector intrudes less in your application. Garbage collection is more conservative about reclaiming memory.

The <xref:System.Runtime.GCLatencyMode?displayProperty=nameWithType> enumeration provides two low latency settings:

- [GCLatencyMode.LowLatency](xref:System.Runtime.GCLatencyMode.LowLatency) suppresses generation 2 collections and performs only generation 0 and 1 collections. It can be used only for short periods of time. Over longer periods, if the system is under memory pressure, the garbage collector will trigger a collection, which can briefly pause the application and disrupt a time-critical operation. This setting is available only for workstation garbage collection.

- [GCLatencyMode.SustainedLowLatency](xref:System.Runtime.GCLatencyMode.SustainedLowLatency) suppresses foreground generation 2 collections and performs only generation 0, 1, and background generation 2 collections. It can be used for longer periods of time, and is available for both workstation and server garbage collection. This setting cannot be used if background garbage collection is disabled.

During low latency periods, generation 2 collections are suppressed unless the following occurs:

- The system receives a low memory notification from the operating system.

- Application code induces a collection by calling the <xref:System.GC.Collect%2A?displayProperty=nameWithType> method and specifying 2 for the `generation` parameter.

## Scenarios

The following table lists the application scenarios for using the <xref:System.Runtime.GCLatencyMode> values:

|Latency mode|Application scenarios|
|------------------|---------------------------|
|<xref:System.Runtime.GCLatencyMode.Batch>|For applications that have no user interface (UI) or server-side operations.<br /><br />When background garbage collection is disabled, this is the default mode for workstation and server garbage collection. <xref:System.Runtime.GCLatencyMode.Batch> mode also overrides the [gcConcurrent](../../framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) setting, that is, it prevents background or concurrent collections.|
|<xref:System.Runtime.GCLatencyMode.Interactive>|For most applications that have a UI.<br /><br />This is the default mode for workstation and server garbage collection. However, if an app is hosted, the garbage collector settings of the hosting process take precedence.|
|<xref:System.Runtime.GCLatencyMode.LowLatency>|For applications that have short-term, time-sensitive operations during which interruptions from the garbage collector could be disruptive. For example, applications that render animations or data acquisition functions.|
|<xref:System.Runtime.GCLatencyMode.SustainedLowLatency>|For applications that have time-sensitive operations for a contained but potentially longer duration of time during which interruptions from the garbage collector could be disruptive. For example, applications that need quick response times as market data changes during trading hours.<br /><br />This mode results in a larger managed heap size than other modes. Because it does not compact the managed heap, higher fragmentation is possible. Ensure that sufficient memory is available.|

## Guidelines for using low latency

When you use [GCLatencyMode.LowLatency](xref:System.Runtime.GCLatencyMode.LowLatency) mode, consider the following guidelines:

- Keep the period of time in low latency as short as possible.

- Avoid allocating high amounts of memory during low latency periods. Low memory notifications can occur because garbage collection reclaims fewer objects.

- While in the low latency mode, minimize the number of new allocations, in particular allocations onto the large object heap and pinned objects.

- Be aware of threads that could be allocating. Because the <xref:System.Runtime.GCSettings.LatencyMode%2A> property setting is process-wide, <xref:System.OutOfMemoryException> exceptions can be generated on any thread that is allocating.

- Wrap the low latency code in constrained execution regions. For more information, see [Constrained execution regions](../../framework/performance/constrained-execution-regions.md).

- You can force generation 2 collections during a low latency period by calling the <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%29?displayProperty=nameWithType> method.

## See also

- <xref:System.GC?displayProperty=nameWithType>
- [Induced Collections](induced.md)
- [Garbage Collection](index.md)
