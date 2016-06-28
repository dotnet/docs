---
title: Latency Modes
description: Latency Modes
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: d5224f62-ebe1-49d8-9c56-4f37ac42b2f8
---

# Latency Modes

To reclaim objects, the garbage collector must stop all the executing threads in an application. In some situations, such as when an application retrieves data or displays content, a full garbage collection can occur at a critical time and impede performance. You can adjust the intrusiveness of the garbage collector by setting the [GCSettings.LatencyMode](https://docs.microsoft.com/dotnet/core/api/GCSettings#System_Runtime_GCSettings_LatencyMode) property to one of the [System.Runtime.GCLatencyMode](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode) values. 

Latency refers to the time that the garbage collector intrudes in your application. During low latency periods, the garbage collector is more conservative and less intrusive in reclaiming objects. The [System.Runtime.GCLatencyMode](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode) enumeration provides two low latency settings:

* [LowLatency](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_LowLatency) suppresses generation 2 collections and performs only generation 0 and 1 collections. It can be used only for short periods of time. Over longer periods, if the system is under memory pressure, the garbage collector will trigger a collection, which can briefly pause the application and disrupt a time-critical operation.

* [SustainedLowLatency](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_SustainedLowLatency) suppresses foreground generation 2 collections and performs only generation 0, 1, and background generation 2 collections. It can be used for longer periods of time.

During low latency periods, generation 2 collections are suppressed unless the following occurs:

* The system receives a low memory notification from the operating system.

* Your application code induces a collection by calling the [GC.Collect](https://docs.microsoft.com/dotnet/core/api/System.GC#System_GC_Collect_System_Int32_) method and specifying 2 for the generation parameter.

The following table lists the application scenarios for using the [GCLatencyMode](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode) values.

Latency mode | Application scenarios
------------ | --------------------- 
[Batch](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_Batch) | For applications that have no UI or server-side operations.
[Interactive](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_Interactive) | For most applications that have a UI.
[LowLatency](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_LowLatency) | For applications that have short-term, time-sensitive operations during which interruptions from the garbage collector could be disruptive. For example, applications that do animation rendering or data acquisition functions.
[SustainedLowLatency](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_SustainedLowLatency) | For applications that have time-sensitive operations for a contained but potentially longer duration of time during which interruptions from the garbage collector could be disruptive. For example, applications that need quick response times as market data changes during trading hours.   This mode results in a larger managed heap size than other modes. Because it does not compact the managed heap, higher fragmentation is possible. Ensure that sufficient memory is available.
 
## Guidelines for Using Low Latency

When you use [LowLatency](https://docs.microsoft.com/dotnet/core/api/System.Runtime.GCLatencyMode#System_Runtime_GCLatencyMode_LowLatency) mode, consider the following guidelines:

* Keep the period of time in low latency as short as possible.

* Avoid allocating high amounts of memory during low latency periods. Low memory notifications can occur because garbage collection reclaims fewer objects. 

* While in the low latency mode, minimize the number of allocations you make, in particular allocations onto the Large Object Heap and pinned objects. 

* Be aware of threads that could be allocating. Because the [LatencyMode](https://docs.microsoft.com/dotnet/core/api/GCSettings#System_Runtime_GCSettings_LatencyMode) property setting is process-wide, you could generate an [OutOfMemoryException](https://docs.microsoft.com/dotnet/core/api/System.OutOfMemoryException) on any thread that may be allocating. 

* You can force generation 2 collections during a low latency period by calling the [GC.Collect(Int32, GCCollectionMode)](https://docs.microsoft.com/dotnet/core/api/System.GC#System_GC_Collect_System_Int32_System_GCCollectionMode_) method.

## See Also

[System.GC](https://docs.microsoft.com/dotnet/core/api/System.GC)

[Induced Collections](induced.md)

[Garbage Collection](garbage-collection.md)
