---
title: "EventWaitHandle, CountdownEvent"
ms.date: "09/14/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "wait handles"
  - "threading [.NET Framework], EventWaitHandle class"
  - "event wait handles [.NET Framework]"
ms.assetid: cd94fc34-ac15-427f-b723-a1240a4fab7d
author: "rpetrusha"
ms.author: "ronpet"
---
# EventWaitHandle, CountdownEvent

Event wait handles allow threads to synchronize activities by signaling each other and by waiting on each other's signals. These synchronization events are based on operating system wait handles and can be divided into two types: those that reset automatically when signaled and those that are reset manually.  
  
Event wait handles are useful in many of the same synchronization scenarios as the <xref:System.Threading.Monitor> class. Event wait handles are often easier to use than the <xref:System.Threading.Monitor.Wait%2A?displayProperty=nameWithType> and <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType> methods, and they offer more control over signaling. Named event wait handles can also be used to synchronize activities across application domains and processes, whereas monitors are local to an application domain.  
  
## In this section

 [EventWaitHandle](eventwaithandle.md)  
 The <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType> class can represent either automatic or manual reset events and either local events or named system events.  
  
 [CountdownEvent](countdownevent.md)  
 The <xref:System.Threading.CountdownEvent?displayProperty=nameWithType> class provides a simplified way to implement fork/join parallelism patterns in code that uses wait handles.  

## See also

- <xref:System.Threading.WaitHandle?displayProperty=nameWithType>
- <xref:System.Threading.Barrier?displayProperty=nameWithType>
- [Threading objects and features](threading-objects-and-features.md)
- [Managed threading basics](managed-threading-basics.md)
