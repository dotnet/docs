---
title: "Thread.Suspend, Garbage Collection, and Safe Points"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "suspending threads"
  - "safe points"
  - "threading [.NET Framework], suspending"
  - "threading [.NET Framework], garbage collection"
  - "garbage collection, threads"
ms.assetid: e8f58e17-2714-4821-802a-f8eb3b2baa62
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Thread.Suspend, Garbage Collection, and Safe Points
When you call <xref:System.Threading.Thread.Suspend%2A?displayProperty=nameWithType> on a thread, the system notes that a thread suspension has been requested and allows the thread to execute until it has reached a safe point before actually suspending the thread. A safe point for a thread is a point in its execution at which garbage collection can be performed.  
  
 Once a safe point is reached, the runtime guarantees that the suspended thread will not make any further progress in managed code. A thread executing outside managed code is always safe for garbage collection, and its execution continues until it attempts to resume execution of managed code.  
  
> [!NOTE]
>  In order to perform a garbage collection, the runtime must suspend all the threads except the thread performing the collection. Each thread must be brought to a safe point before it can be suspended.  
  
## See Also  
 <xref:System.Threading.Thread>  
 <xref:System.GC>  
 [Threading](../../../docs/standard/threading/index.md)  
 [Automatic Memory Management](../../../docs/standard/automatic-memory-management.md)
