---
title: "Semaphore and SemaphoreSlim"
description: Learn about Semaphore & SemaphoreSlim. Class Semaphore is a thin wrapper around the Win32 semaphore object. Class SemaphoreSlim is a fast lightweight semaphore.
ms.date: "03/12/2026"
helpviewer_keywords: 
  - "counting semaphores"
  - "semaphores"
  - "threading [.NET], cross-process synchronization"
  - "Semaphore class, about Semaphore class"
  - "SemaphoreSlim class, about SemaphoreSlim class"
  - "threading [.NET], Semaphore class"
ms.assetid: 7722a333-b974-47a2-a7c0-f09097fb644e
ai-usage: ai-assisted
---
# Semaphore and SemaphoreSlim

The <xref:System.Threading.Semaphore?displayProperty=nameWithType> class represents a named (systemwide) or local semaphore. It's a thin wrapper around the Win32 semaphore object. Win32 semaphores are counting semaphores that control access to a pool of resources.

The <xref:System.Threading.SemaphoreSlim> class represents a lightweight, fast semaphore that can be used for waiting within a single process when wait times are expected to be short. During the spin-wait phase, the CPU is actively spinning—it's not idle. How short "short" needs to be depends on the nature of the wait: if threads are competing for CPU resources, the spinning thread is consuming CPU time, so the wait should be very brief, measured in microseconds. If the wait is for a non-CPU-bound resource (such as I/O), the spin-wait overhead is less of a concern and the acceptable wait can be somewhat longer, measured in milliseconds. When wait times are unpredictable or expected to be significant, use <xref:System.Threading.Semaphore?displayProperty=nameWithType> instead, which doesn't spin. <xref:System.Threading.SemaphoreSlim> relies as much as possible on synchronization primitives provided by the common language runtime (CLR). However, it also provides lazily initialized, kernel-based wait handles as necessary to support waiting on multiple semaphores. <xref:System.Threading.SemaphoreSlim> also supports the use of cancellation tokens, but it doesn't support named semaphores or the use of a wait handle for synchronization.

## Managing a limited resource

Threads enter the semaphore by calling different methods depending on the semaphore type. For a <xref:System.Threading.Semaphore?displayProperty=nameWithType> object, call the <xref:System.Threading.WaitHandle.WaitOne%2A> method (inherited from <xref:System.Threading.WaitHandle>). For a <xref:System.Threading.SemaphoreSlim> object, call the <xref:System.Threading.SemaphoreSlim.Wait%2A?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.WaitAsync%2A?displayProperty=nameWithType> method. When the call returns, the count on the semaphore is decremented. When a thread requests entry and the count is zero, the thread blocks. As threads release the semaphore by calling the <xref:System.Threading.Semaphore.Release%2A?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release%2A?displayProperty=nameWithType> method, blocked threads can enter. No guaranteed order—such as first-in, first-out (FIFO) or last-in, first-out (LIFO)—governs which blocked thread enters the semaphore next.

A thread can enter the semaphore multiple times by calling the <xref:System.Threading.Semaphore?displayProperty=nameWithType> object's <xref:System.Threading.WaitHandle.WaitOne%2A> method or the <xref:System.Threading.SemaphoreSlim> object's <xref:System.Threading.SemaphoreSlim.Wait%2A> method repeatedly. To release the semaphore, call the <xref:System.Threading.Semaphore.Release?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release?displayProperty=nameWithType> method the same number of times the thread entered. Alternatively, call the <xref:System.Threading.Semaphore.Release%28System.Int32%29?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim.Release%28System.Int32%29?displayProperty=nameWithType> overload and specify the number of entries to release.

### Semaphores and thread identity

The two semaphore types don't enforce thread identity on calls to the <xref:System.Threading.WaitHandle.WaitOne%2A>, <xref:System.Threading.SemaphoreSlim.Wait%2A>, <xref:System.Threading.Semaphore.Release%2A>, and <xref:System.Threading.SemaphoreSlim.Release%2A?displayProperty=nameWithType> methods. For example, a common usage scenario for semaphores involves a producer thread and a consumer thread, with one thread always incrementing the semaphore count and the other always decrementing it.

Ensure that a thread doesn't release the semaphore too many times. For example, suppose a semaphore has a maximum count of two, and that thread A and thread B both enter the semaphore. If a programming error in thread B causes it to call `Release` twice, both calls succeed. The count on the semaphore is full, and when thread A eventually calls `Release`, a <xref:System.Threading.SemaphoreFullException> is thrown.

## Named semaphores

The Windows operating system allows semaphores to have names. A named semaphore is system wide—once created, it's visible to all threads in all processes. Named semaphores can therefore synchronize the activities of processes as well as threads.

Create a <xref:System.Threading.Semaphore> object that represents a named system semaphore by using one of the constructors that specifies a name.

> [!IMPORTANT]
> Because named semaphores are system wide, it's possible to have multiple <xref:System.Threading.Semaphore> objects that represent the same named semaphore. Each time you call a constructor or the <xref:System.Threading.Semaphore.OpenExisting%2A?displayProperty=nameWithType> method, a new <xref:System.Threading.Semaphore> object is created. Specifying the same name repeatedly creates multiple objects that represent the same named semaphore.
>
> Be careful when you use named semaphores. Because they're system wide, another process that uses the same name can enter your semaphore unexpectedly. Malicious code executing on the same computer could use this as the basis of a denial-of-service attack.
>
> Use access control security to protect a <xref:System.Threading.Semaphore> object that represents a named semaphore, preferably by using a constructor that specifies a <xref:System.Security.AccessControl.SemaphoreSecurity?displayProperty=nameWithType> object. You can also apply access control security using the <xref:System.Threading.Semaphore.SetAccessControl%2A?displayProperty=nameWithType> method, but this leaves a window of vulnerability between the time the semaphore is created and the time it's protected. Protecting semaphores with access control security helps prevent malicious attacks, but doesn't solve the problem of unintentional name collisions.

## See also

- <xref:System.Threading.Semaphore>
- <xref:System.Threading.SemaphoreSlim>
- [Threading Objects and Features](threading-objects-and-features.md)
