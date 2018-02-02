---
title: "Semaphore and SemaphoreSlim"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "counting semaphores"
  - "semaphores"
  - "threading [.NET Framework], cross-process synchronization"
  - "Semaphore class, about Semaphore class"
  - "SemaphoreSlim class, about SemaphoreSlim class"
  - "threading [.NET Framework], Semaphore class"
ms.assetid: 7722a333-b974-47a2-a7c0-f09097fb644e
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Semaphore and SemaphoreSlim
The <xref:System.Threading.Semaphore?displayProperty=nameWithType> class represents a named (systemwide) or local semaphore. It is a thin wrapper around the Win32 semaphore object. Win32 semaphores are counting semaphores, which can be used to control access to a pool of resources.  
  
 The <xref:System.Threading.SemaphoreSlim> class represents a lightweight, fast semaphore that can be used for waiting within a single process when wait times are expected to be very short. <xref:System.Threading.SemaphoreSlim> relies as much as possible on synchronization primitives provided by the common language runtime (CLR). However, it also provides lazily initialized, kernel-based wait handles as necessary to support waiting on multiple semaphores. <xref:System.Threading.SemaphoreSlim> also supports the use of cancellation tokens, but it does not support named semaphores or the use of a wait handle for synchronization.  
  
## Managing a Limited Resource  
 Threads enter the semaphore by calling the <xref:System.Threading.WaitHandle.WaitOne%2A> method, which is inherited from the <xref:System.Threading.WaitHandle> class, in the case of a <xref:System.Threading.Semaphore?displayProperty=nameWithType> object, or the <xref:System.Threading.SemaphoreSlim.Wait%2A?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.WaitAsync%2A?displayProperty=nameWithType> method, in the case of a <xref:System.Threading.SemaphoreSlim> object.. When the call returns, the count on the semaphore is decremented. When a thread requests entry and the count is zero, the thread blocks. As threads release the semaphore by calling the <xref:System.Threading.Semaphore.Release%2A?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release%2A?displayProperty=nameWithType> method, blocked threads are allowed to enter. There is no guaranteed order, such as first-in, first-out (FIFO) or last-in, first-out (LIFO), for blocked threads to enter the semaphore.  
  
 A thread can enter the semaphore multiple times by calling the <xref:System.Threading.Semaphore?displayProperty=nameWithType> object's <xref:System.Threading.WaitHandle.WaitOne%2A> method or the  <xref:System.Threading.SemaphoreSlim> object's <xref:System.Threading.SemaphoreSlim.Wait%2A> method repeatedly. To release the semaphore, the thread can either call the <xref:System.Threading.Semaphore.Release?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release?displayProperty=nameWithType> method overload the same number of times, or call the <xref:System.Threading.Semaphore.Release%28System.Int32%29?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release%28System.Int32%29?displayProperty=nameWithType> method overload and specify the number of entries to be released.  
  
### Semaphores and Thread Identity  
 The two semaphore types do not enforce thread identity on calls to the <xref:System.Threading.WaitHandle.WaitOne%2A>, <xref:System.Threading.SemaphoreSlim.Wait%2A>, <xref:System.Threading.Semaphore.Release%2A>, and <xref:System.Threading.SemaphoreSlim.Release%2A?displayProperty=nameWithType> methods. For example, a common usage scenario for semaphores involves a producer thread and a consumer thread, with one thread always incrementing the semaphore count and the other always decrementing it.  
  
 It is the programmer's responsibility to ensure that a thread does not release the semaphore too many times. For example, suppose a semaphore has a maximum count of two, and that thread A and thread B both enter the semaphore. If a programming error in thread B causes it to call  `Release` twice, both calls succeed. The count on the semaphore is full, and when thread A eventually calls `Release`, a <xref:System.Threading.SemaphoreFullException> is thrown.  
  
## Named Semaphores  
 The Windows operating system allows semaphores to have names. A named semaphore is system wide. That is, once the named semaphore is created, it is visible to all threads in all processes. Thus, named semaphore can be used to synchronize the activities of processes as well as threads.  
  
 You can create a <xref:System.Threading.Semaphore> object that represents a named system semaphore by using one of the constructors that specifies a name.  
  
> [!NOTE]
>  Because named semaphores are system wide, it is possible to have multiple <xref:System.Threading.Semaphore> objects that represent the same named semaphore. Each time you call a constructor or the <xref:System.Threading.Semaphore.OpenExisting%2A?displayProperty=nameWithType> method, a new <xref:System.Threading.Semaphore> object is created. Specifying the same name repeatedly creates multiple objects that represent the same named semaphore.  
  
 Be careful when you use named semaphores. Because they are system wide, another process that uses the same name can enter your semaphore unexpectedly. Malicious code executing on the same computer could use this as the basis of a denial-of-service attack.  
  
 Use access control security to protect a <xref:System.Threading.Semaphore> object that represents a named semaphore, preferably by using a constructor that specifies a <xref:System.Security.AccessControl.SemaphoreSecurity?displayProperty=nameWithType> object. You can also apply access control security using the <xref:System.Threading.Semaphore.SetAccessControl%2A?displayProperty=nameWithType> method, but this leaves a window of vulnerability between the time the semaphore is created and the time it is protected. Protecting semaphores with access control security helps prevent malicious attacks, but does not solve the problem of unintentional name collisions.  
  
## See Also  
 <xref:System.Threading.Semaphore>  
 <xref:System.Threading.SemaphoreSlim>  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
