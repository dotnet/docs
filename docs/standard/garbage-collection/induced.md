---
title: "Induced Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "garbage collection, forced"
ms.assetid: 019008fe-4708-4e65-bebf-04fd9941e149
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Induced Collections
In most cases, the garbage collector can determine the best time to perform a collection, and you should let it run independently. There are rare situations when a forced collection might improve your application's performance. In these cases, you can induce garbage collection by using the <xref:System.GC.Collect%2A?displayProperty=nameWithType> method to force a garbage collection.  
  
 Use the <xref:System.GC.Collect%2A?displayProperty=nameWithType> method when there is a significant reduction in the amount of memory being used at a specific point in your application's code. For example, if your application uses a complex dialog box that has several controls, calling <xref:System.GC.Collect%2A> when the dialog box is closed could improve performance by immediately reclaiming the memory used by the dialog box. Be sure that your application is not inducing garbage collection too frequently, because that can decrease performance if the garbage collector is trying to reclaim objects at non-optimal times. You can supply a <xref:System.GCCollectionMode.Optimized?displayProperty=nameWithType> enumeration value to the <xref:System.GC.Collect%2A> method to collect only when collection would be productive, as discussed in the next section.  
  
## GC collection mode  
 You can use one of the <xref:System.GC.Collect%2A?displayProperty=nameWithType> method overloads that includes a <xref:System.GCCollectionMode> value to specify the behavior for a forced collection as follows.  
  
|`GCCollectionMode` value|Description|  
|------------------------------|-----------------|  
|<xref:System.GCCollectionMode.Default>|Uses the default garbage collection setting for the running version of .NET.|  
|<xref:System.GCCollectionMode.Forced>|Forces garbage collection to occur immediately. This is equivalent to calling the <xref:System.GC.Collect?displayProperty=nameWithType> overload. It results in a full blocking collection of all generations.<br /><br /> You can also compact the large object heap by setting the <xref:System.Runtime.GCSettings.LargeObjectHeapCompactionMode%2A?displayProperty=nameWithType> property to <xref:System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce?displayProperty=nameWithType> before forcing an immediate full blocking garbage collection.|  
|<xref:System.GCCollectionMode.Optimized>|Enables the garbage collector to determine whether the current time is optimal to reclaim objects.<br /><br /> The garbage collector could determine that a collection would not be productive enough to be justified, in which case it will return without reclaiming objects.|  
  
## Background or blocking collections  
 You can call the <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%2CSystem.Boolean%29?displayProperty=nameWithType> method overload to specify whether an induced collection is blocking or not. The type of collection performed depends on a combination of the method's `mode` and `blocking` parameters. `mode` is a member of the <xref:System.GCCollectionMode> enumeration, and `blocking` is a <xref:System.Boolean> value. The following table summarizes the interaction of the `mode` and `blocking` arguments.  
  
|`mode`|`blocking` = `true`|`blocking` = `false`|  
|------------|--------------------------|---------------------------|  
|<xref:System.GCCollectionMode.Forced> or <xref:System.GCCollectionMode.Default>|A blocking collection is performed as soon as possible. If a background collection is in progress and generation is 0 or 1, the <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%2CSystem.Boolean%29> method immediately triggers a blocking collection and returns when the collection is finished. If a background collection is in progress and the `generation` parameter is 2, the method waits until the background collection is finished, triggers a blocking generation 2 collection, and then returns.|A collection is performed as soon as possible. The <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%2CSystem.Boolean%29> method requests a background collection, but this is not guaranteed; depending on the circumstances, a blocking collection may still be performed. If a background collection is already in progress, the method returns immediately.|  
|<xref:System.GCCollectionMode.Optimized>|A blocking collection may be performed, depending on the state of the garbage collector and the `generation` parameter. The garbage collector tries to provide optimal performance.|A collection may be performed, depending on the state of the garbage collector. The <xref:System.GC.Collect%28System.Int32%2CSystem.GCCollectionMode%2CSystem.Boolean%29> method requests a background collection, but this is not guaranteed; depending on the circumstances, a blocking collection may still be performed. The garbage collector tries to provide optimal performance. If a background collection is already in progress, the method returns immediately.|  
  
## See Also  
 [Latency Modes](../../../docs/standard/garbage-collection/latency.md)  
 [Garbage Collection](../../../docs/standard/garbage-collection/index.md)
