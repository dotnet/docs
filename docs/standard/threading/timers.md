---
title: "Timers"
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
  - "threading [.NET Framework], timers"
  - "timers, about timers"
ms.assetid: 7091500d-be18-499b-a942-95366ce185e5
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Timers
Timers are lightweight objects that enable you to specify a delegate to be called at a specified time. A thread in the thread pool performs the wait operation.  
  
 Using the <xref:System.Threading.Timer?displayProperty=nameWithType> class is straightforward. You create a **Timer**, passing a <xref:System.Threading.TimerCallback> delegate to the callback method, an object representing state that will be passed to the callback, an initial raise time, and a time representing the period between callback invocations. To cancel a pending timer, call the **Timer.Dispose** function.  
  
> [!NOTE]
>  There are two other timer classes. The <xref:System.Windows.Forms.Timer?displayProperty=nameWithType> class is a control that works with visual designers and is meant to be used in user interface contexts; it raises events on the user interface thread. The <xref:System.Timers.Timer?displayProperty=nameWithType> class derives from <xref:System.ComponentModel.Component>, so it can be used with visual designers; it also raises events, but it raises them on a <xref:System.Threading.ThreadPool> thread. The <xref:System.Threading.Timer?displayProperty=nameWithType> class makes callbacks on a <xref:System.Threading.ThreadPool> thread and does not use the event model at all. It also provides a state object to the callback method, which the other timers do not. It is extremely lightweight.  
  
 The following code example starts a timer that starts after one second (1000 milliseconds) and ticks every second until you press the **Enter** key. The variable containing the reference to the timer is a class-level field, to ensure that the timer is not subject to garbage collection while it is still running. For more information on aggressive garbage collection, see <xref:System.GC.KeepAlive%2A>.  
  
 [!code-cpp[System.Threading.Timer#2](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.Threading.Timer/CPP/source2.cpp#2)]
 [!code-csharp[System.Threading.Timer#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.Threading.Timer/CS/source2.cs#2)]
 [!code-vb[System.Threading.Timer#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Threading.Timer/VB/source2.vb#2)]  
  
## See Also  
 <xref:System.Threading.Timer>  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
