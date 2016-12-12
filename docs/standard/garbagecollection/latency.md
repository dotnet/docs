---
title: Latency modes
description: Latency modes
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/18/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 810bd8be-5a48-42c6-b080-3afdb31fc61b
---

# Latency modes

To reclaim objects, the garbage collector must stop all the executing threads in an application. In some situations, such as when an application retrieves data or displays content, a full garbage collection can occur at a critical time and impede performance. You can adjust the intrusiveness of the garbage collector by setting the [GCSettings.LatencyMode](xref:System.Runtime.GCSettings.LatencyMode) property to one of the [System.Runtime.GCLatencyMode](xref:System.Runtime.GCLatencyMode) values. 

Latency refers to the time that the garbage collector intrudes in your application. During low latency periods, the garbage collector is more conservative and less intrusive in reclaiming objects. The [System.Runtime.GCLatencyMode](xref:System.Runtime.GCLatencyMode) enumeration provides two low latency settings:

* [LowLatency](xref:System.Runtime.GCLatencyMode.LowLatency) suppresses generation 2 collections and performs only generation 0 and 1 collections. It can be used only for short periods of time. Over longer periods, if the system is under memory pressure, the garbage collector will trigger a collection, which can briefly pause the application and disrupt a time-critical operation. This setting is available only for workstation garbage collection. 

* [SustainedLowLatency](xref:System.Runtime.GCLatencyMode.SustainedLowLatency) suppresses foreground generation 2 collections and performs only generation 0, 1, and background generation 2 collections. It can be used for longer periods of time, and is available for both workstation and server garbage collection. This setting cannot be used if [concurrent garbage collection](https://msdn.microsoft.com/library/yhwwzef8.aspx) is disabled.

During low latency periods, generation 2 collections are suppressed unless the following occurs:

* The system receives a low memory notification from the operating system.

* Your application code induces a collection by calling the [GC.Collect](xref:System.GC.Collect(System.Int32)) method and specifying 2 for the generation parameter.

The following table lists the application scenarios for using the [GCLatencyMode](xref:System.Runtime.GCLatencyMode) values.

Latency mode | Application scenarios
------------ | --------------------- 
[Batch](xref:System.Runtime.GCLatencyMode.Batch) | For applications that have no UI or server-side operations. This is the default mode when [concurrent garbage collection](https://msdn.microsoft.com/library/yhwwzef8.aspx) is disabled.
[Interactive](xref:System.Runtime.GCLatencyMode.Interactive) | For most applications that have a UI. For applications that have no UI or server-side operations. This is the default mode when [concurrent garbage collection](https://msdn.microsoft.com/library/yhwwzef8.aspx) is enabled.
[LowLatency](xref:System.Runtime.GCLatencyMode.LowLatency) | For applications that have short-term, time-sensitive operations during which interruptions from the garbage collector could be disruptive. For example, applications that do animation rendering or data acquisition functions.
[SustainedLowLatency](xref:System.Runtime.GCLatencyMode.SustainedLowLatency) | For applications that have time-sensitive operations for a contained but potentially longer duration of time during which interruptions from the garbage collector could be disruptive. For example, applications that need quick response times as market data changes during trading hours.   This mode results in a larger managed heap size than other modes. Because it does not compact the managed heap, higher fragmentation is possible. Ensure that sufficient memory is available.
 
## Guidelines for Using Low Latency

When you use [LowLatency](xref:System.Runtime.GCLatencyMode.LowLatency) mode, consider the following guidelines:

* Keep the period of time in low latency as short as possible.

* Avoid allocating high amounts of memory during low latency periods. Low memory notifications can occur because garbage collection reclaims fewer objects. 

* While in the low latency mode, minimize the number of allocations you make, in particular allocations onto the Large Object Heap and pinned objects. 

* Be aware of threads that could be allocating. Because the [LatencyMode](xref:System.Runtime.GCSettings.LatencyMode) property setting is process-wide, you could generate an [OutOfMemoryException](xref:System.OutOfMemoryException) on any thread that may be allocating. 

* You can force generation 2 collections during a low latency period by calling the [GC.Collect(Int32, GCCollectionMode)](xref:System.GC.Collect(System.Int32,System.GCCollectionMode)) method.

## See Also

[System.GC](xref:System.GC)

[Induced Collections](induced.md)

[Garbage collection in .NET](index.md)
