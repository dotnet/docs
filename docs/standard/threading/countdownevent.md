---
title: "CountdownEvent"
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
helpviewer_keywords: 
  - "synchronization primitives, CountdownEvent"
ms.assetid: eec3812a-e20f-4ecd-bfef-6921d508b708
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# CountdownEvent
<xref:System.Threading.CountdownEvent?displayProperty=nameWithType> is a synchronization primitive that unblocks its waiting threads after it has been signaled a certain number of times. <xref:System.Threading.CountdownEvent> is designed for scenarios in which you would otherwise have to use a <xref:System.Threading.ManualResetEvent> or <xref:System.Threading.ManualResetEventSlim> and manually decrement a variable before signaling the event. For example, in a fork/join scenario, you can just create a <xref:System.Threading.CountdownEvent> that has a signal count of 5, and then start five work items on the thread pool and have each work item call <xref:System.Threading.CountdownEvent.Signal%2A> when it completes. Each call to <xref:System.Threading.CountdownEvent.Signal%2A> decrements the signal count by 1. On the main thread, the call to <xref:System.Threading.CountdownEvent.Wait%2A> will block until the signal count is zero.  
  
> [!NOTE]
>  For code that does not have to interact with legacy .NET Framework synchronization APIs, consider using <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> objects or the <xref:System.Threading.Tasks.Parallel.Invoke%2A> method for an even easier approach to expressing fork-join parallelism.  
  
 <xref:System.Threading.CountdownEvent> has these additional features:  
  
-   The wait operation can be canceled by using cancellation tokens.  
  
-   Its signal count can be incremented after the instance is created.  
  
-   Instances can be reused after <xref:System.Threading.CountdownEvent.Wait%2A> has returned by calling the <xref:System.Threading.CountdownEvent.Reset%2A> method.  
  
-   Instances expose a <xref:System.Threading.WaitHandle> for integration with other .NET Framework synchronization APIs such as <xref:System.Threading.WaitHandle.WaitAll%2A>.  
  
## Basic Usage  
 The following example demonstrates how to use a <xref:System.Threading.CountdownEvent> with <xref:System.Threading.ThreadPool> work items.  
  
 [!code-csharp[CDS_CountdownEvent#01](../../../samples/snippets/csharp/VS_Snippets_Misc/cds_countdownevent/cs/countdownevent.cs#01)]
 [!code-vb[CDS_CountdownEvent#01](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_countdownevent/vb/module1.vb#01)]  
  
## CountdownEvent With Cancellation  
 The following example shows how to cancel the wait operation on <xref:System.Threading.CountdownEvent> by using a cancellation token. The basic pattern follows the model for unified cancellation, which is introduced in [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)]. For more information, see [Cancellation in Managed Threads](../../../docs/standard/threading/cancellation-in-managed-threads.md).  
  
 [!code-csharp[CDS_CountdownEvent#02](../../../samples/snippets/csharp/VS_Snippets_Misc/cds_countdownevent/cs/countdownevent.cs#02)]
 [!code-vb[CDS_CountdownEvent#02](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_countdownevent/vb/canceleventwait.vb#02)]  
  
 Note that the wait operation does not cancel the threads that are signaling it. Typically, cancellation is applied to a logical operation, and that can include waiting on the event as well as all the work items that the wait is synchronizing. In this example, each work item is passed a copy of the same cancellation token so that it can respond to the cancellation request.  
  
## See Also  
 [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)
