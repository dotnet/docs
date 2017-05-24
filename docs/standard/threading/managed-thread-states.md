---
title: "Managed Thread States | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "threading [.NET Framework], states"
ms.assetid: 63890d5e-6025-4a7c-aaf0-d8bfd54b455f
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Managed Thread States
The property <xref:System.Threading.Thread.ThreadState%2A?displayProperty=fullName> provides a bit mask that indicates the thread's current state. A thread is always in at least one of the possible states in the <xref:System.Threading.ThreadState> enumeration, and can be in multiple states at the same time.  
  
> [!IMPORTANT]
>  Thread state is only of interest in a few debugging scenarios. Your code should never use thread state to synchronize the activities of threads.  
  
 When you create a managed thread, it is in the <xref:System.Threading.ThreadState> state. The thread remains in the <xref:System.Threading.ThreadState> state until it is moved into the started state by the operating system. Calling <xref:System.Threading.Thread.Start%2A> lets the operating system know that the thread can be started; it does not change the state of the thread.  
  
 Unmanaged threads that enter the managed environment are already in the started state. Once a thread is in the started state, a number of actions can cause it to change states. The following table lists the actions that cause a change of state, along with the corresponding new state.  
  
|Action|Resulting new state|  
|------------|-------------------------|  
|The constructor for the <xref:System.Threading.Thread> class is called.|<xref:System.Threading.ThreadState>|  
|Another thread calls <xref:System.Threading.Thread.Start%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>|  
|The thread responds to <xref:System.Threading.Thread.Start%2A?displayProperty=fullName> and starts running.|<xref:System.Threading.ThreadState>|  
|The thread calls <xref:System.Threading.Thread.Sleep%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>|  
|The thread calls <xref:System.Threading.Monitor.Wait%2A?displayProperty=fullName> on another object.|<xref:System.Threading.ThreadState>|  
|The thread calls <xref:System.Threading.Thread.Join%2A?displayProperty=fullName> on another thread.|<xref:System.Threading.ThreadState>|  
|Another thread calls <xref:System.Threading.Thread.Suspend%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>|  
|The thread responds to a <xref:System.Threading.Thread.Suspend%2A?displayProperty=fullName> request.|<xref:System.Threading.ThreadState>|  
|Another thread calls <xref:System.Threading.Thread.Resume%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>|  
|Another thread calls <xref:System.Threading.Thread.Abort%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>|  
|The thread responds to an <xref:System.Threading.Thread.Abort%2A?displayProperty=fullName>.|<xref:System.Threading.ThreadState>, then <xref:System.Threading.ThreadState>|  
  
 Because the <xref:System.Threading.ThreadState> state has a value of 0, it is not possible to perform a bit test to discover this state. Instead, the following test (in pseudo-code) can be used:  
  
```  
if ((state & (Unstarted | Stopped)) == 0)   // implies Running     
```  
  
 Threads are often in more than one state at any given time. For example, if a thread is blocked on a <xref:System.Threading.Monitor.Wait%2A?displayProperty=fullName> call and another thread calls <xref:System.Threading.Thread.Abort%2A> on that same thread, the thread will be in both the <xref:System.Threading.ThreadState> and the <xref:System.Threading.ThreadState> states at the same time. In that case, as soon as the thread returns from the call to <xref:System.Threading.Monitor.Wait%2A> or is interrupted, it will receive the <xref:System.Threading.ThreadAbortException>.  
  
 Once a thread leaves the <xref:System.Threading.ThreadState> state as the result of a call to <xref:System.Threading.Thread.Start%2A>, it can never return to the <xref:System.Threading.ThreadState> state. A thread can never leave the <xref:System.Threading.ThreadState> state.  
  
## See Also  
 <xref:System.Threading.ThreadAbortException>   
 <xref:System.Threading.Thread>   
 <xref:System.Threading.ThreadState>   
 [Threading](../../../docs/standard/threading/index.md)