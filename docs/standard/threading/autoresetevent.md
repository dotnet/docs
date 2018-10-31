---
title: "AutoResetEvent"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "threading [.NET Framework], AutoResetEvent class"
  - "AutoResetEvent class"
ms.assetid: 6d39c48d-6b37-4a9b-8631-f2924cfd9c18
author: "rpetrusha"
ms.author: "ronpet"
---
# AutoResetEvent
The <xref:System.Threading.AutoResetEvent> class represents a local wait handle event that resets automatically when signaled, after releasing a single waiting thread. This class represents a special case of its base class, <xref:System.Threading.EventWaitHandle>. See the [EventWaitHandle](../../../docs/standard/threading/eventwaithandle.md) conceptual documentation for the use and features of automatic reset events.  
  
 An <xref:System.Threading.AutoResetEvent> object is automatically reset to non-signaled by the system after a single waiting thread has been released. If no threads are waiting, the event object's state remains signaled.
  
 For an example that uses <xref:System.Threading.AutoResetEvent>, see <xref:System.Threading.Monitor>.  
  
## See also

- <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>
- <xref:System.Threading.WaitHandle?displayProperty=nameWithType>
- [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)  
- [Threading objects and features](threading-objects-and-features.md)  
- [Threading](index.md)  
