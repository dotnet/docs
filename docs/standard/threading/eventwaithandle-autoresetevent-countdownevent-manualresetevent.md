---
title: "EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "wait handles"
  - "threading [.NET Framework], EventWaitHandle class"
  - "event wait handles [.NET Framework]"
ms.assetid: cd94fc34-ac15-427f-b723-a1240a4fab7d
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent
Event wait handles allow threads to synchronize activities by signaling each other and by waiting on each other's signals. These synchronization events are based on Win32 wait handles and can be divided into two types: those that reset automatically when signaled and those that are reset manually.  
  
 Event wait handles are useful in many of the same synchronization scenarios as the <xref:System.Threading.Monitor> class. Event wait handles are often easier to use than the <xref:System.Threading.Monitor.Wait%2A?displayProperty=nameWithType> and <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType> methods, and they offer more control over signaling. Named event wait handles can also be used to synchronize activities across application domains and processes, whereas monitors are local to an application domain.  
  
## In This Section  
 [EventWaitHandle](../../../docs/standard/threading/eventwaithandle.md)  
 The <xref:System.Threading.EventWaitHandle> class can represent either automatic or manual reset events and either local events or named system events.  
  
 [AutoResetEvent](../../../docs/standard/threading/autoresetevent.md)  
 The <xref:System.Threading.AutoResetEvent> class derives from <xref:System.Threading.EventWaitHandle> and represents a local event that resets automatically.  
  
 [ManualResetEvent and ManualResetEventSlim](../../../docs/standard/threading/manualresetevent-and-manualreseteventslim.md)  
 The <xref:System.Threading.ManualResetEvent> class derives from <xref:System.Threading.EventWaitHandle> and represents a local event that must be reset manually. The <xref:System.Threading.ManualResetEventSlim> class is a lightweight, faster version that can be used for events within the same process.  
  
 [CountdownEvent](../../../docs/standard/threading/countdownevent.md)  
 The <xref:System.Threading.CountdownEvent> class provides a simplified way to implement fork/join parallelism patterns in code that uses wait handles.  
  
## Related Sections  
 [Wait Handles](http://msdn.microsoft.com/library/48d10b6f-5fd7-407c-86ab-0179aef72489)  
 The <xref:System.Threading.WaitHandle> class is the base class for the <xref:System.Threading.EventWaitHandle>, <xref:System.Threading.Semaphore>, and <xref:System.Threading.Mutex> classes. It contains static methods such as <xref:System.Threading.WaitHandle.SignalAndWait%2A> and <xref:System.Threading.WaitHandle.WaitAll%2A> that are useful when working with all types of wait handles.  
  
## See Also  
 <xref:System.Threading.EventWaitHandle>  
 <xref:System.Threading.WaitHandle>  
 <xref:System.Threading.AutoResetEvent>  
 <xref:System.Threading.ManualResetEvent>  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)  
 [Managed Threading Basics](../../../docs/standard/threading/managed-threading-basics.md)
