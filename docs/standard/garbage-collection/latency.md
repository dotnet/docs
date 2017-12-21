---
title: "Latency Modes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "garbage collection, intrusiveness"
  - "garbage collection, latency modes"
ms.assetid: 96278bb7-6eab-4612-8594-ceebfc887d81
caps.latest.revision: 41
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Latency Modes
To reclaim objects, the garbage collector must stop all the executing threads in an application. In some situations, such as when an application retrieves data or displays content, a full garbage collection can occur at a critical time and impede performance. You can adjust the intrusiveness of the garbage collector by setting the <xref:System.Runtime.GCSettings.LatencyMode%2A?displayProperty=nameWithType> property to one of the <xref:System.Runtime.GCLatencyMode?displayProperty=nameWithType> values.  
  
 Latency refers to the time that the garbage collector intrudes in your application. During low latency periods, the garbage collector is more conservative and less intrusive in reclaiming objects. The <xref:System.Runtime.GCLatencyMode?displayProperty=nameWithType> enumeration provides two low latency settings:  
  
-   <xref:System.Runtime.GCLatencyMode.LowLatency> suppresses generation 2 collections and performs only generation 0 and 1 collections. It can be used only for short periods of time. Over longer periods, if the system is under memory pressure, the garbage collector will trigger a collection, which can briefly pause the application and disrupt a time-critical operation. This setting is available only for workstation garbage collection.  
  
-   <xref:System.Runtime.GCLatencyMode.SustainedLowLatency> suppresses foreground generation 2 collections and performs only generation 0, 1, and background generation 2 collections. It can be used for longer periods of time, and is available for both workstation and server garbage collection. This setting cannot be used if [concurrent garbage collection](../../../docs/framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) is disabled.  
  
 During low latency periods, generation 2 collections are suppressed unless the following occurs:  
  
-   The system receives a low memory notification from the operating system.  
  
-   Your application code induces a collection by calling the <xref:System.GC.Collect%2A?displayProperty=nameWithType> method and specifying 2 for the `generation` parameter.  
  
 The following table lists the application scenarios for using the <xref:System.Runtime.GCLatencyMode> values.  
  
|Latency mode|Application scenarios|  
|------------------|---------------------------|  
|<xref:System.Runtime.GCLatencyMode.Batch>|For applications that have no UI or server-side operations.<br /><br /> This is the default mode when [concurrent garbage collection](../../../docs/framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) is disabled.|  
|<xref:System.Runtime.GCLatencyMode.Interactive>|For most applications that have a UI.<br /><br /> This is the default mode when [concurrent garbage collection](../../../docs/framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) is enabled.|  
|<xref:System.Runtime.GCLatencyMode.LowLatency>|For applications that have short-term, time-sensitive operations during which interruptions from the garbage collector could be disruptive. For example, applications that do animation rendering or data acquisition functions.|  
|<xref:System.Runtime.GCLatencyMode.SustainedLowLatency>|For applications that have time-sensitive operations for a contained but potentially longer duration of time during which interruptions from the garbage collector could be disruptive. For example, applications that need quick response times as market data changes during trading hours.<br /><br /> This mode results in a larger managed heap size than other modes. Because it does not compact the managed heap, higher fragmentation is possible. Ensure that sufficient memory is available.|  
  
## Guidelines for Using Low Latency  
 When you use <xref:System.Runtime.GCLatencyMode.LowLatency> mode, consider the following guidelines:  
  
-   Keep the period of time in low latency as short as possible.  
  
-   Avoid allocating high amounts of memory during low latency periods. Low memory notifications can occur because garbage collection reclaims fewer objects.  
  
-   While in the low latency mode, minimize the number of allocations you make, in particular allocations onto the Large Object Heap and pinned objects.  
  
-   Be aware of threads that could be allocating. Because the <xref:System.Runtime.GCSettings.LatencyMode%2A> property setting is process-wide, you could generate an <xref:System.OutOfMemoryException> on any thread that may be allocating.  
  
-   Wrap the low latency code in constrained execution regions (for more information, see [Constrained Execution Regions](../../../docs/framework/performance/constrained-execution-regions.md)).  
  
-   You can force generation 2 collections during a low latency period by calling the <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%29?displayProperty=nameWithType> method.  
  
## See Also  
 <xref:System.GC?displayProperty=nameWithType>  
 [Induced Collections](../../../docs/standard/garbage-collection/induced.md)  
 [Garbage Collection](../../../docs/standard/garbage-collection/index.md)
