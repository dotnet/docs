---
title: "ManualResetEvent and ManualResetEventSlim"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "threading [.NET Framework], ManualResetEvent class"
  - "ManualResetEvent class, about ManualResetEvent class"
ms.assetid: 465fdcf9-ba24-4d8d-a43f-d983b7cb0cc6
author: "rpetrusha"
ms.author: "ronpet"
---
# ManualResetEvent and ManualResetEventSlim
The <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType> class represents a local wait handle event that must be reset manually after it is signaled. This class represents a special case of its base class, <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType>. See the [EventWaitHandle](../../../docs/standard/threading/eventwaithandle.md) conceptual documentation for the use and features of manual reset events.  
  
 A <xref:System.Threading.ManualResetEvent> object remains signaled until its <xref:System.Threading.EventWaitHandle.Reset%2A?displayProperty=nameWithType> method is called. Any number of waiting threads, or threads that wait on the event after it has been signaled, can be released while the object's state is signaled.
  
 In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can use the <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType> class for better performance when wait times are expected to be very short, and when the event does not cross a process boundary. <xref:System.Threading.ManualResetEventSlim> uses busy spinning for a short time while it waits for the event to become signaled. When wait times are short, spinning can be much less expensive than waiting by using wait handles. However, if the event does not become signaled within a certain period of time, <xref:System.Threading.ManualResetEventSlim> resorts to a regular event handle wait.  
  
## See also

- <xref:System.Threading.WaitHandle?displayProperty=nameWithType>
- [AutoResetEvent](autoresetevent.md)
- [SpinWait](spinwait.md)
- [Semaphore and SemaphoreSlim](semaphore-and-semaphoreslim.md)
- [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)
- [Threading objects and features](threading-objects-and-features.md)
- [Threading](index.md)
