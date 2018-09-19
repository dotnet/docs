---
title: "Overview of synchronization primitives"
description: "Learn about .NET thread synchronization primitives used to synchronize access to a shared resource or control thread interaction"
ms.date: "09/20/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "synchronization, threads"
  - "threading [.NET],synchronizing threads"
  - "managed threading"
ms.assetid: b782bcb8-da6a-4c6a-805f-2eb46d504309
author: "rpetrusha"
ms.author: "ronpet"
---
# Overview of synchronization primitives

.NET provides a range of types that you can use to synchronize access to a shared resource or coordinate thread interaction.

## WaitHandle class and lightweight synchronization types

Multiple .NET synchronization primitives derive from the <xref:System.Threading.WaitHandle?displayProperty=nameWithType> class, which encapsulates a native operating system synchronization handle. Those classes include:

- <xref:System.Threading.Mutex?displayProperty=nameWithType>
- <xref:System.Threading.Semaphore?displayProperty=nameWithType>
- <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType>
- <xref:System.Threading.AutoResetEvent?displayProperty=nameWithType>
- <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>

As <xref:System.Threading.WaitHandle> derives from <xref:System.MarshalByRefObject?displayProperty=nameWithType>, those types can be used to synchronize the activities of threads across application domain boundaries. Moreover, <xref:System.Threading.Mutex>, <xref:System.Threading.Semaphore>, and <xref:System.Threading.EventWaitHandle> can represent named system synchronization handles, which are visible throughout the operating system and can be used for the inter-process synchronization.

For more information, see the <xref:System.Threading.WaitHandle> API reference.

Lightweight synchronization types don't rely on underlying operating system handles and typically provide better performance. However, they cannot be used for the inter-process synchronization. Use those types for thread synchronization within one application.

Some of those types are alternatives to the types derived from <xref:System.Threading.WaitHandle>. For example, <xref:System.Threading.SemaphoreSlim> is a lightweight alternative to <xref:System.Threading.Semaphore>.

## Synchronization of access to a shared resource

When you synchronize access to a shared resource, you might need to implement one of the two following scenarios:

- At maximum only one thread can access the resource at any given time moment. The access to the resource is mutually exclusive.
- The number of threads that access the resource at the same time is limited.

.NET provides synchronization primitives to implement either scenario.

### Monitor class

The <xref:System.Threading.Monitor?displayProperty=nameWithType> class allows you to synchronize access to a shared resource by acquiring or releasing a lock on the dedicated object that identifies the resource.

Use the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> method to acquire a lock on an object. As the <xref:System.Threading.Monitor> class has thread affinity, the thread that acquired a lock must release the lock by calling the <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> method.

<xref:System.Threading.Monitor> grants mutually exclusive access to a shared resource. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> method waits until the lock is released to acquire it. Use the <xref:System.Threading.Monitor.TryEnter%2A?displayProperty=nameWithType> method if you want to specify the amount of time, for which a thread attempts to acquire a lock.

You can coordinate the interaction of threads that acquire a lock on the same object by using the <xref:System.Threading.Monitor.Wait%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType>, and <xref:System.Threading.Monitor.PulseAll%2A?displayProperty=nameWithType> methods.

For more information, see the <xref:System.Threading.Monitor> API reference.

> [!NOTE]
> Use the [lock](../../csharp/language-reference/keywords/lock-statement.md) statement in C# and the [SyncLock](../../visual-basic/language-reference/statements/synclock-statement.md) statement in Visual Basic to synchronize access to a shared resource instead of using the <xref:System.Threading.Monitor> class directly. Those statements are implemented by using the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> methods and a `try…finally` block to ensure that the acquired lock is always released.

### Mutex class

The <xref:System.Threading.Mutex?displayProperty=nameWithType> class, like <xref:System.Threading.Monitor>, grants exclusive access to a shared resource. Use one of the <xref:System.Threading.WaitHandle.WaitOne%2A?displayProperty=nameWithType> method overloads to request an ownership of a mutex. Like <xref:System.Threading.Monitor>, <xref:System.Threading.Mutex> has thread affinity and the thread that acquired a mutex must release it by calling the <xref:System.Threading.Mutex.ReleaseMutex%2A?displayProperty=nameWithType> method.

Unlike <xref:System.Threading.Monitor>, the <xref:System.Threading.Mutex> class can be used for inter-process synchronization. To do that, use a named mutex, which is visible throughout the operating system. To create a named mutex instance, use a [Mutex constructor](<xref:System.Threading.Mutex.%23ctor%2A>) that specifies a name. You also can call the <xref:System.Threading.Mutex.OpenExisting%2A?displayProperty=nameWithType> method to open an existing named system mutex.
  
For more information, see the [Mutexes](mutexes.md) article and the <xref:System.Threading.Mutex> API reference.

### SpinLock struct

The <xref:System.Threading.SpinLock?displayProperty=nameWithType> struct, like <xref:System.Threading.Monitor>, grants exclusive access to a shared resource. When <xref:System.Threading.SpinLock> attempts to acquire the taken lock, it waits in a loop repeatedly checking until the lock becomes available.

For more information about benefits and drawbacks of using spin lock, see the [SpinLock](spinlock.md) article and the <xref:System.Threading.SpinLock> API reference.

### ReaderWriterLockSlim class

Use the <xref:System.Threading.ReaderWriterLockSlim?displayProperty=nameWithType> class to grant exclusive access to a shared resource for writing. Multiple threads can access the resource simultaneously for reading. You might want to use <xref:System.Threading.ReaderWriterLockSlim> to synchronize access to a shared data structure that supports thread-safe read operations, but requires exclusive access to perform write operation. When a thread requests exclusive access (for example, by calling the <xref:System.Threading.ReaderWriterLockSlim.EnterWriteLock%2A?displayProperty=nameWithType> method), subsequent reader requests block until all existing readers have exited the lock, and the writer has entered and exited the lock.
  
For more information, see the [Reader-Writer locks](reader-writer-locks.md) article and the <xref:System.Threading.ReaderWriterLockSlim> API reference.

### Semaphore and SemaphoreSlim classes

Use <xref:System.Threading.Semaphore?displayProperty=nameWithType> or <xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType> to limit the number of threads that can access a resource concurrently. Additional threads that request the resource wait until any thread releases the semaphore.

You create a <xref:System.Threading.Semaphore> instance that represents a named system semaphore by using one of the [Semaphore constructors](<xref:System.Threading.Semaphore.%23ctor%2A>) that specifies a name or the <xref:System.Threading.Semaphore.OpenExisting%2A?displayProperty=nameWithType> method. A named system semaphore can be used for the inter-process synchronization.

<xref:System.Threading.SemaphoreSlim> is a lightweight alternative to <xref:System.Threading.Semaphore> and can be used only for synchronization within a single process boundary. <xref:System.Threading.SemaphoreSlim> doesn't support named system semaphores.

Neither of the semaphore classes has thread affinity. That means that one thread can acquire the semaphore and another one can release it.
  
For more information, see the [Semaphore and SemaphoreSlim](semaphore-and-semaphoreslim.md) article and the <xref:System.Threading.Semaphore> or <xref:System.Threading.SemaphoreSlim> API reference.

## Thread interaction, or signaling

Thread interaction occurs when a thread must wait for notification, or signal, from one or more threads in order to proceed. For example, if a thread A calls the <xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType> method of a thread B, the thread A is blocked until the thread B completes. The synchronization primitives described in the preceding section is another example of signaling: by releasing a lock a thread notifies another thread that it can proceed by acquiring the lock.

This section describes additional signaling constructs provided by .NET.

### EventWaitHandle class

The <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType> class represents a thread synchronization event.

A synchronization event can be either in an unsignaled or signaled state.

When the state of an event is unsignaled, a thread that calls the event's <xref:System.Threading.WaitHandle.WaitOne%2A?> overload is blocked until an event is signaled. The <xref:System.Threading.EventWaitHandle.Set%2A?displayProperty=nameWithType> method sets the state of an event to signaled.

The behavior of an <xref:System.Threading.EventWaitHandle> that has been signaled depends on its reset mode:

- An <xref:System.Threading.EventWaitHandle> created with the <xref:System.Threading.EventResetMode.AutoReset?displayProperty=nameWithType> flag resets automatically after releasing a single waiting thread. It's like a turnstile that allows only one thread through each time it's signaled.
- An <xref:System.Threading.EventWaitHandle> created with the <xref:System.Threading.EventResetMode.ManualReset?displayProperty=nameWithType> flag remains signaled until its <xref:System.Threading.EventWaitHandle.Reset%2A> method is called. It's like a gate that is closed until signaled and then stays open until someone closes it.

You create a <xref:System.Threading.EventWaitHandle> instance that represents a named system synchronization event by using one of the [EventWaitHandle constructors](<xref:System.Threading.EventWaitHandle.%23ctor%2A>) that specifies a name or the <xref:System.Threading.EventWaitHandle.OpenExisting%2A?displayProperty=nameWithType> method. A named system synchronization event can be used for the inter-process synchronization.

For more information, see the [EventWaitHandle](eventwaithandle.md) article and the <xref:System.Threading.EventWaitHandle> API reference.

### AutoResetEvent class

The <xref:System.Threading.AutoResetEvent?displayProperty=nameWithType> class derives from <xref:System.Threading.EventWaitHandle> and represents a synchronization event that, when signaled, resets automatically to an unsignaled state after releasing a single waiting thread.

The <xref:System.Threading.AutoResetEvent> class cannot represent a named system synchronization event and cannot be used for the inter-process synchronization.

For more information, see the [AutoResetEvent](autoresetevent.md) article and the <xref:System.Threading.AutoResetEvent> API reference.

### ManualResetEvent and ManualResetEventSlim classes

The <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType> class derives from <xref:System.Threading.EventWaitHandle> and represents a synchronization event that, when signaled, stays in a signaled state until its <xref:System.Threading.EventWaitHandle.Reset%2A> method is called.

The <xref:System.Threading.ManualResetEvent> class cannot represent a named system synchronization event and cannot be used for the inter-process synchronization.

The <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType> class is a lightweight alternative to <xref:System.Threading.ManualResetEvent>.

For more information, see the [ManualResetEvent and ManualResetEventSlim](manualresetevent-and-manualreseteventslim.md) article and the <xref:System.Threading.ManualResetEvent> or <xref:System.Threading.ManualResetEventSlim> API reference.

### CountdownEvent class

The <xref:System.Threading.CountdownEvent?displayProperty=nameWithType> class represents an event that becomes set when its count is zero.

While <xref:System.Threading.CountdownEvent.CurrentCount?displayProperty=nameWithType> is greater than zero, a thread that calls <xref:System.Threading.CountdownEvent.Wait%2A?displayProperty=nameWithType> is blocked. Call <xref:System.Threading.CountdownEvent.Signal%2A?displayProperty=nameWithType> to decrement an event's count.

In contrast to <xref:System.Threading.ManualResetEvent> or <xref:System.Threading.ManualResetEventSlim>, which you might use to unblock multiple threads with a signal from one thread, you might use <xref:System.Threading.CountdownEvent> to unblock a single thread with signals from multiple threads.

For more information, see the [CountdownEvent](countdownevent.md) article and the <xref:System.Threading.CountdownEvent> API reference.

### Barrier class

The <xref:System.Threading.Barrier?displayProperty=nameWithType> class represents a thread execution barrier. A thread that calls the <xref:System.Threading.Barrier.SignalAndWait%2A?displayProperty=nameWithType> method signals that it reached the barrier and waits until other participant threads reach the barrier. When all participant threads reach the barrier, they proceed and the barrier is reset and can be used again.

You might use <xref:System.Threading.Barrier> when one or more threads require the results of other threads before proceeding to the next computation phase.

For more information, see the [Barrier](barrier.md) article and the <xref:System.Threading.Barrier> API reference.

## Interlocked class

The <xref:System.Threading.Interlocked?displayProperty=nameWithType> class provides static methods that perform simple atomic operations on a variable. Those atomic operations include addition, increment and decrement, exchange and conditional exchange that depends on a comparison, and read operation of a 64-bit integer value.

For more information, see the [Interlocked operations](interlocked-operations.md) article and the <xref:System.Threading.Interlocked> API reference.

## SpinWait struct

The <xref:System.Threading.SpinWait?displayProperty=nameWithType> struct provides support for spin-based waiting. You might want to use it when a thread has to wait for an event to be signaled or a condition to be met, but when the actual wait time is expected to be less than the waiting time required by using a wait handle or by otherwise blocking the thread. By using <xref:System.Threading.SpinWait>, you can specify a short period of time to spin while waiting, and then yield (for example, by waiting or sleeping) only if the condition was not met in the specified time.

For more information, see the [SpinWait](spinwait.md) article and the <xref:System.Threading.SpinWait> API reference.

## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- [Thread-safe collections](../collections/thread-safe/index.md)
- [Threading objects and features](threading-objects-and-features.md)
