---
title: "SpinWait"
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
  - "synchronization primitives, SpinWait"
ms.assetid: 36012f42-34e5-4f86-adf4-973f433ed6c6
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# SpinWait
<xref:System.Threading.SpinWait?displayProperty=nameWithType> is a lightweight synchronization type that you can use in low-level scenarios to avoid the expensive context switches and kernel transitions that are required for kernel events. On multicore computers, when a resource is not expected to be held for long periods of time, it can be more efficient for a waiting thread to spin in user mode for a few dozen or a few hundred cycles, and then retry to acquire the resource. If the resource is available after spinning, then you have saved several thousand cycles. If the resource is still not available, then you have spent only a few cycles and can still enter a kernel-based wait. This spinning-then-waiting combination is sometimes referred to as a *two-phase wait operation*.  
  
 <xref:System.Threading.SpinWait> is designed to be used in conjunction with the .NET Framework types that wrap kernel events such as <xref:System.Threading.ManualResetEvent>. <xref:System.Threading.SpinWait> can also be used by itself for basic spinning functionality in just one program.  
  
 <xref:System.Threading.SpinWait> is more than just an empty loop. It is carefully implemented to provide correct spinning behavior for the general case, and will itself initiate context switches if it spins long enough (roughly the length of time required for a kernel transition). For example, on single-core computers, <xref:System.Threading.SpinWait> yields the time slice of the thread immediately because spinning blocks forward progress on all threads. <xref:System.Threading.SpinWait> also yields even on multi-core machines to prevent the waiting thread from blocking higher-priority threads or the garbage collector. Therefore, if you are using a <xref:System.Threading.SpinWait> in a two-phase wait operation, we recommend that you invoke the kernel wait before the <xref:System.Threading.SpinWait> itself initiates a context switch. <xref:System.Threading.SpinWait> provides the <xref:System.Threading.SpinWait.NextSpinWillYield%2A> property, which you can check before every call to <xref:System.Threading.SpinWait.SpinOnce%2A>. When the property returns `true`, initiate your own Wait operation. For an example, see [How to: Use SpinWait to Implement a Two-Phase Wait Operation](../../../docs/standard/threading/how-to-use-spinwait-to-implement-a-two-phase-wait-operation.md).  
  
 If you are not performing a two-phase wait operation but are just spinning until some condition is true, you can enable <xref:System.Threading.SpinWait> to perform its context switches so that it is a good citizen in the Windows operating system environment. The following basic example shows a <xref:System.Threading.SpinWait> in a lock-free stack. If you require a high-performance, thread-safe stack, consider using <xref:System.Collections.Concurrent.ConcurrentStack%601?displayProperty=nameWithType>.  
  
 [!code-csharp[CDS_SpinWait#05](../../../samples/snippets/csharp/VS_Snippets_Misc/cds_spinwait/cs/spinwait.cs#05)]
 [!code-vb[CDS_SpinWait#05](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_spinwait/vb/cds_spinwait1.vb#05)]  
  
## See Also  
 <xref:System.Threading.Thread.SpinWait%2A>  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
