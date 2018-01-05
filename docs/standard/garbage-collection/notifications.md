---
title: "Garbage Collection Notifications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "garbage collection, notifications"
ms.assetid: e12d8e74-31e3-4035-a87d-f3e66f0a9b89
caps.latest.revision: 23
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Garbage Collection Notifications
There are situations in which a full garbage collection (that is, a generation 2 collection) by the common language runtime may adversely affect performance. This can be an issue particularly with servers that process large volumes of requests; in this case, a long garbage collection can cause a request time-out. To prevent a full collection from occurring during a critical period, you can be notified that a full garbage collection is approaching and then take action to redirect the workload to another server instance. You can also induce a collection yourself, provided that the current server instance does not need to process requests.  
  
 The <xref:System.GC.RegisterForFullGCNotification%2A> method registers for a notification to be raised when the runtime senses that a full garbage collection is approaching. There are two parts to this notification: when the full garbage collection is approaching and when the full garbage collection has completed.  
  
> [!WARNING]
>  Only blocking garbage collections raise notifications. When the [\<gcConcurrent>](../../../docs/framework/configure-apps/file-schema/runtime/gcconcurrent-element.md) configuration element is enabled, background garbage collections will not raise notifications.  
  
 To determine when a notification has been raised, use the <xref:System.GC.WaitForFullGCApproach%2A> and <xref:System.GC.WaitForFullGCComplete%2A> methods. Typically, you use these methods in a `while` loop to continually obtain a <xref:System.GCNotificationStatus> enumeration that shows the status of the notification. If that value is <xref:System.GCNotificationStatus.Succeeded>, you can do the following:  
  
-   In response to a notification obtained with the <xref:System.GC.WaitForFullGCApproach%2A> method, you can redirect the workload and possibly induce a collection yourself.  
  
-   In response to a notification obtained with the <xref:System.GC.WaitForFullGCComplete%2A> method, you can make the current server instance available to process requests again. You can also gather information. For example, you can use the <xref:System.GC.CollectionCount%2A> method to record the number of collections.  
  
 The <xref:System.GC.WaitForFullGCApproach%2A> and the <xref:System.GC.WaitForFullGCComplete%2A> methods are designed to work together. Using one without the other can produce indeterminate results.  
  
## Full Garbage Collection  
 The runtime causes a full garbage collection when any of the following scenarios are true:  
  
-   Enough memory has been promoted into generation 2 to cause the next generation 2 collection.  
  
-   Enough memory has been promoted into the large object heap to cause the next generation 2 collection.  
  
-   A collection of generation 1 is escalated to a collection of generation 2 due to other factors.  
  
 The thresholds you specify in the <xref:System.GC.RegisterForFullGCNotification%2A> method apply to the first two scenarios. However, in the first scenario you will not always receive the notification at the time proportional to the threshold values you specify for two reasons:  
  
-   The runtime does not check each small object allocation (for performance reasons).  
  
-   Only generation 1 collections promote memory into generation 2.  
  
 The third scenario also contributes to the uncertainty of when you will receive the notification. Although this is not a guarantee, it does prove to be a useful way to mitigate the effects of an inopportune full garbage collection by redirecting the requests during this time or inducing the collection yourself when it can be better accommodated.  
  
## Notification Threshold Parameters  
 The <xref:System.GC.RegisterForFullGCNotification%2A> method has two parameters to specify the threshold values of the generation 2 objects and the large object heap. When those values are met, a garbage collection notification should be raised. The following table describes these parameters.  
  
|Parameter|Description|  
|---------------|-----------------|  
|`maxGenerationThreshold`|A number between 1 and 99 that specifies when the notification should be raised based on the objects promoted in generation 2.|  
|`largeObjectHeapThreshold`|A number between 1 and 99 that specifies when the notification should be raised based on the objects that are allocated in the large object heap.|  
  
 If you specify a value that is too high, there is a high probability that you will receive a notification, but it could be too long a period to wait before the runtime causes a collection. If you induce a collection yourself, you may reclaim more objects than would be reclaimed if the runtime causes the collection.  
  
 If you specify a value that is too low, the runtime may cause the collection before you have had sufficient time to be notified.  
  
## Example  
  
### Description  
 In the following example, a group of servers service incoming Web requests. To simulate the workload of processing requests, byte arrays are added to a <xref:System.Collections.Generic.List%601> collection. Each server registers for a garbage collection notification and then starts a thread on the `WaitForFullGCProc` user method to continuously monitor the <xref:System.GCNotificationStatus> enumeration that is returned by the <xref:System.GC.WaitForFullGCApproach%2A> and the <xref:System.GC.WaitForFullGCComplete%2A> methods.  
  
 The <xref:System.GC.WaitForFullGCApproach%2A> and the <xref:System.GC.WaitForFullGCComplete%2A> methods call their respective event-handling user methods when a notification is raised:  
  
-   `OnFullGCApproachNotify`  
  
     This method calls the `RedirectRequests` user method, which instructs the request queuing server to suspend sending requests to the server. This is simulated by setting the class-level variable `bAllocate` to `false` so that no more objects are allocated.  
  
     Next, the `FinishExistingRequests` user method is called to finish processing the pending server requests. This is simulated by clearing the <xref:System.Collections.Generic.List%601> collection.  
  
     Finally, a garbage collection is induced because the workload is light.  
  
-   `OnFullGCCompleteNotify`  
  
     This method calls the user method `AcceptRequests` to resume accepting requests because the server is no longer susceptible to a full garbage collection. This action is simulated by setting the `bAllocate` variable to `true` so that objects can resume being added to the <xref:System.Collections.Generic.List%601> collection.  
  
 The following code contains the `Main` method of the example.  
  
 [!code-cpp[GCNotification#2](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#2)]
 [!code-csharp[GCNotification#2](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#2)]
 [!code-vb[GCNotification#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#2)]  
  
 The following code contains the `WaitForFullGCProc` user method, that contains a continuous while loop to check for garbage collection notifications.  
  
 [!code-cpp[GCNotification#8](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#8)]
 [!code-csharp[GCNotification#8](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#8)]
 [!code-vb[GCNotification#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#8)]  
  
 The following code contains the `OnFullGCApproachNotify` method as called from the  
  
 `WaitForFullGCProc` method.  
  
 [!code-cpp[GCNotification#5](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#5)]
 [!code-csharp[GCNotification#5](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#5)]
 [!code-vb[GCNotification#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#5)]  
  
 The following code contains the `OnFullGCApproachComplete` method as called from the  
  
 `WaitForFullGCProc` method.  
  
 [!code-cpp[GCNotification#6](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#6)]
 [!code-csharp[GCNotification#6](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#6)]
 [!code-vb[GCNotification#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#6)]  
  
 The following code contains the user methods that are called from the `OnFullGCApproachNotify` and `OnFullGCCompleteNotify` methods. The user methods redirect requests, finish existing requests, and then resume requests after a full garbage collection has occurred.  
  
 [!code-cpp[GCNotification#9](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#9)]
 [!code-csharp[GCNotification#9](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#9)]
 [!code-vb[GCNotification#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#9)]  
  
 The entire code sample is as follows:  
  
 [!code-cpp[GCNotification#1](../../../samples/snippets/cpp/VS_Snippets_CLR/GCNotification/cpp/program.cpp#1)]
 [!code-csharp[GCNotification#1](../../../samples/snippets/csharp/VS_Snippets_CLR/GCNotification/cs/Program.cs#1)]
 [!code-vb[GCNotification#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/GCNotification/vb/program.vb#1)]  
  
## See Also  
 [Garbage Collection](../../../docs/standard/garbage-collection/index.md)
