---
title: "EventWaitHandle"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "threading [.NET Framework], EventWaitHandle class"
  - "EventWaitHandle class"
  - "event wait handles [.NET Framework]"
  - "threading [.NET Framework], cross-process synchronization"
ms.assetid: 11ee0b38-d663-4617-b793-35eb6c64e9fc
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# EventWaitHandle
The <xref:System.Threading.EventWaitHandle> class allows threads to communicate with each other by signaling and by waiting for signals. Event wait handles (also referred to simply as events) are wait handles that can be signaled in order to release one or more waiting threads. After it is signaled, an event wait handle is reset either manually or automatically. The <xref:System.Threading.EventWaitHandle> class can represent either a local event wait handle (local event) or a named system event wait handle (named event or system event, visible to all processes).  
  
> [!NOTE]
>  Event wait handles are not events in the sense usually meant by that word in the .NET Framework. There are no delegates or event handlers involved. The word "event" is used to describe them because they have traditionally been referred to as operating-system events, and because the act of signaling the wait handle indicates to waiting threads that an event has occurred.  
  
 Both local and named event wait handles use system synchronization objects, which are protected by <xref:Microsoft.Win32.SafeHandles.SafeWaitHandle> wrappers to ensure that the resources are released. You can use the <xref:System.Threading.WaitHandle.Dispose%2A> method to free the resources immediately when you have finished using the object.  
  
## Event Wait Handles That Reset Automatically  
 You create an automatic reset event by specifying <xref:System.Threading.EventResetMode.AutoReset?displayProperty=nameWithType> when you create the <xref:System.Threading.EventWaitHandle> object. As its name implies, this synchronization event resets automatically when signaled, after releasing a single waiting thread. Signal the event by calling its <xref:System.Threading.EventWaitHandle.Set%2A> method.  
  
 Automatic reset events are usually used to provide exclusive access to a resource for a single thread at a time. A thread requests the resource by calling the <xref:System.Threading.WaitHandle.WaitOne%2A> method. If no other thread is holding the wait handle, the method returns `true` and the calling thread has control of the resource.  
  
> [!IMPORTANT]
>  As with all synchronization mechanisms, you must ensure that all code paths wait on the appropriate wait handle before accessing a protected resource. Thread synchronization is cooperative.  
  
 If an automatic reset event is signaled when no threads are waiting, it remains signaled until a thread attempts to wait on it. The event releases the thread and immediately resets, blocking subsequent threads.  
  
## Event Wait Handles That Reset Manually  
 You create a manual reset event by specifying <xref:System.Threading.EventResetMode.ManualReset?displayProperty=nameWithType> when you create the <xref:System.Threading.EventWaitHandle> object. As its name implies, this synchronization event must be reset manually after it has been signaled. Until it is reset, by calling its <xref:System.Threading.EventWaitHandle.Reset%2A> method, threads that wait on the event handle proceed immediately without blocking.  
  
 A manual reset event acts like the gate of a corral. When the event is not signaled, threads that wait on it block, like horses in a corral. When the event is signaled, by calling its <xref:System.Threading.EventWaitHandle.Set%2A> method, all waiting threads are free to proceed. The event remains signaled until its <xref:System.Threading.EventWaitHandle.Reset%2A> method is called. This makes the manual reset event an ideal way to hold up threads that need to wait until one thread finishes a task.  
  
 Like horses leaving a corral, it takes time for the released threads to be scheduled by the operating system and to resume execution. If the <xref:System.Threading.EventWaitHandle.Reset%2A> method is called before all the threads have resumed execution, the remaining threads once again block. Which threads resume and which threads block depends on random factors like the load on the system, the number of threads waiting for the scheduler, and so on. This is not a problem if the thread that signals the event ends after signaling, which is the most common usage pattern. If you want the thread that signaled the event to begin a new task after all the waiting threads have resumed, you must block it until all the waiting threads have resumed. Otherwise, you have a race condition, and the behavior of your code is unpredictable.  
  
## Features Common to Automatic and Manual Events  
 Typically, one or more threads block on an <xref:System.Threading.EventWaitHandle> until an unblocked thread calls the <xref:System.Threading.EventWaitHandle.Set%2A> method, which releases one of the waiting threads (in the case of automatic reset events) or all of them (in the case of manual reset events). A thread can signal an <xref:System.Threading.EventWaitHandle> and then block on it, as an atomic operation, by calling the static <xref:System.Threading.WaitHandle.SignalAndWait%2A?displayProperty=nameWithType> method.  
  
 <xref:System.Threading.EventWaitHandle> objects can be used with the static <xref:System.Threading.WaitHandle.WaitAll%2A?displayProperty=nameWithType> and <xref:System.Threading.WaitHandle.WaitAny%2A?displayProperty=nameWithType> methods. Because the <xref:System.Threading.EventWaitHandle> and <xref:System.Threading.Mutex> classes both derive from <xref:System.Threading.WaitHandle>, you can use both classes with these methods.  
  
### Named Events  
 The Windows operating system allows event wait handles to have names. A named event is system wide. That is, once the named event is created, it is visible to all threads in all processes. Thus, named events can be used to synchronize the activities of processes as well as threads.  
  
 You can create an <xref:System.Threading.EventWaitHandle> object that represents a named system event by using one of the constructors that specifies an event name.  
  
> [!NOTE]
>  Because named events are system wide, it is possible to have multiple <xref:System.Threading.EventWaitHandle> objects that represent the same named event. Each time you call a constructor, or the <xref:System.Threading.EventWaitHandle.OpenExisting%2A> method, a new <xref:System.Threading.EventWaitHandle> object is created. Specifying the same name repeatedly creates multiple objects that represent the same named event.  
  
 Caution is advised in using named events. Because they are system wide, another process that uses the same name can block your threads unexpectedly. Malicious code executing on the same computer could use this as the basis of a denial-of-service attack.  
  
 Use access control security to protect an <xref:System.Threading.EventWaitHandle> object that represents a named event, preferably by using a constructor that specifies an <xref:System.Security.AccessControl.EventWaitHandleSecurity> object. You can also apply access control security using the <xref:System.Threading.EventWaitHandle.SetAccessControl%2A> method, but this leaves a window of vulnerability between the time the event wait handle is created and the time it is protected. Protecting events with access control security helps prevent malicious attacks, but it does not solve the problem of unintentional name collisions.  
  
> [!NOTE]
>  Unlike the <xref:System.Threading.EventWaitHandle> class, the derived classes <xref:System.Threading.AutoResetEvent> and <xref:System.Threading.ManualResetEvent> can represent only local wait handles. They cannot represent named system events.  
  
## See Also  
 <xref:System.Threading.EventWaitHandle>  
 <xref:System.Threading.WaitHandle>  
 <xref:System.Threading.AutoResetEvent>  
 <xref:System.Threading.ManualResetEvent>  
 [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)
