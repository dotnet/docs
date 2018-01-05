---
title: "Mutexes"
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
  - "threading [.NET Framework], Mutex class"
  - "Mutex class, about Mutex class"
  - "threading [.NET Framework], cross-process synchronization"
ms.assetid: 9dd06e25-12c0-4a9e-855a-452dc83803e2
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Mutexes
You can use a <xref:System.Threading.Mutex> object to provide exclusive access to a resource. The <xref:System.Threading.Mutex> class uses more system resources than the <xref:System.Threading.Monitor> class, but it can be marshaled across application domain boundaries, it can be used with multiple waits, and it can be used to synchronize threads in different processes. For a comparison of managed synchronization mechanisms, see [Overview of Synchronization Primitives](../../../docs/standard/threading/overview-of-synchronization-primitives.md).  
  
 For code examples, see the reference documentation for the <xref:System.Threading.Mutex.%23ctor%2A> constructors.  
  
## Using Mutexes  
 A thread calls the <xref:System.Threading.WaitHandle.WaitOne%2A> method of a mutex to request ownership. The call blocks until the mutex is available, or until the optional timeout interval elapses. The state of a mutex is signaled if no thread owns it.  
  
 A thread releases a mutex by calling its <xref:System.Threading.Mutex.ReleaseMutex%2A> method. Mutexes have thread affinity; that is, the mutex can be released only by the thread that owns it. If a thread releases a mutex it does not own, an <xref:System.ApplicationException> is thrown in the thread.  
  
 Because the <xref:System.Threading.Mutex> class derives from <xref:System.Threading.WaitHandle>, you can also call the static <xref:System.Threading.WaitHandle.WaitAll%2A> or <xref:System.Threading.WaitHandle.WaitAny%2A> methods of <xref:System.Threading.WaitHandle> to request ownership of a <xref:System.Threading.Mutex> in combination with other wait handles.  
  
 If a thread owns a <xref:System.Threading.Mutex>, that thread can specify the same <xref:System.Threading.Mutex> in repeated wait-request calls without blocking its execution; however, it must release the <xref:System.Threading.Mutex> as many times to release ownership.  
  
## Abandoned Mutexes  
 If a thread terminates without releasing a <xref:System.Threading.Mutex>, the mutex is said to be abandoned. This often indicates a serious programming error because the resource the mutex is protecting might be left in an inconsistent state. In the .NET Framework version 2.0, an <xref:System.Threading.AbandonedMutexException> is thrown in the next thread that acquires the mutex.  
  
> [!NOTE]
>  In the .NET Framework versions 1.0 and 1.1, an abandoned <xref:System.Threading.Mutex> is set to the signaled state and the next waiting thread gets ownership. If no thread is waiting, the <xref:System.Threading.Mutex> remains in a signaled state. No exception is thrown.  
  
 In the case of a system-wide mutex, an abandoned mutex might indicate that an application has been terminated abruptly (for example, by using Windows Task Manager).  
  
## Local and System Mutexes  
 Mutexes are of two types: local mutexes and named system mutexes. If you create a <xref:System.Threading.Mutex> object using a constructor that accepts a name, it is associated with an operating-system object of that name. Named system mutexes are visible throughout the operating system and can be used to synchronize the activities of processes. You can create multiple <xref:System.Threading.Mutex> objects that represent the same named system mutex, and you can use the <xref:System.Threading.Mutex.OpenExisting%2A> method to open an existing named system mutex.  
  
 A local mutex exists only within your process. It can be used by any thread in your process that has a reference to the local <xref:System.Threading.Mutex> object. Each <xref:System.Threading.Mutex> object is a separate local mutex.  
  
### Access Control Security for System Mutexes  
 The .NET Framework version 2.0 provides the ability to query and set Windows access control security for named system objects. Protecting system mutexes from the moment of creation is recommended because system objects are global and therefore can be locked by code other than your own.  
  
 For information on access control security for mutexes, see the <xref:System.Security.AccessControl.MutexSecurity> and <xref:System.Security.AccessControl.MutexAccessRule> classes, the <xref:System.Security.AccessControl.MutexRights> enumeration, the <xref:System.Threading.Mutex.GetAccessControl%2A>, <xref:System.Threading.Mutex.SetAccessControl%2A>, and <xref:System.Threading.Mutex.OpenExisting%2A> methods of the <xref:System.Threading.Mutex> class, and the <xref:System.Threading.Mutex.%23ctor%28System.Boolean%2CSystem.String%2CSystem.Boolean%40%2CSystem.Security.AccessControl.MutexSecurity%29> constructor.  
  
## See Also  
 <xref:System.Threading.Mutex>  
 <xref:System.Threading.Mutex.%23ctor%2A>  
 <xref:System.Security.AccessControl.MutexSecurity>  
 <xref:System.Security.AccessControl.MutexAccessRule>  
 [Threading](../../../docs/standard/threading/index.md)  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)  
 [Monitors](http://msdn.microsoft.com/library/33fe4aef-b44b-42fd-9e72-c908e39e75db)  
 [Threads and Threading](../../../docs/standard/threading/threads-and-threading.md)
