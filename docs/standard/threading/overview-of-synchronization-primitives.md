---
title: "Overview of synchronization primitives"
description: "Learn about .NET thread synchronization primitives used to synchronize access to a shared resource or control thread interaction"
ms.date: "10/01/2018"
helpviewer_keywords: 
  - "synchronization, threads"
  - "threading [.NET],synchronizing threads"
  - "managed threading"
ms.assetid: b782bcb8-da6a-4c6a-805f-2eb46d504309
---
# Overview of synchronization primitives

.NET provides a range of types that you can use to synchronize access to a shared resource or coordinate thread interaction.

> [!IMPORTANT]
> Use the same synchronization primitive instance to protect access of a shared resource. If you use different synchronization primitive instances to protect the same resource, you'll circumvent the protection provided by a synchronization primitive.

## WaitHandle class and lightweight synchronization types

Multiple .NET synchronization primitives derive from the <xref:System.Threading.WaitHandle?displayProperty=nameWithType> class, which encapsulates a native operating system synchronization handle and uses a signaling mechanism for thread interaction. Those classes include:

- <xref:System.Threading.Mutex?displayProperty=nameWithType>, which grants exclusive access to a shared resource. The state of a mutex is signaled if no thread owns it.
- <xref:System.Threading.Semaphore?displayProperty=nameWithType>, which limits the number of threads that can access a shared resource or a pool of resources concurrently. The state of a semaphore is set to signaled when its count is greater than zero, and nonsignaled when its count is zero.
- <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType>, which represents a thread synchronization event and can be either in a signaled or unsignaled state.
- <xref:System.Threading.AutoResetEvent?displayProperty=nameWithType>, which derives from <xref:System.Threading.EventWaitHandle> and, when signaled, resets automatically to an unsignaled state after releasing a single waiting thread.
- <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>, which derives from <xref:System.Threading.EventWaitHandle> and, when signaled, stays in a signaled state until the <xref:System.Threading.EventWaitHandle.Reset%2A> method is called.

In .NET Framework, because <xref:System.Threading.WaitHandle> derives from <xref:System.MarshalByRefObject?displayProperty=nameWithType>, these types can be used to synchronize the activities of threads across application domain boundaries.

In .NET Framework, .NET Core, and .NET 5+, some of these types can represent named system synchronization handles, which are visible throughout the operating system and can be used for the inter-process synchronization:

- <xref:System.Threading.Mutex>
- <xref:System.Threading.Semaphore> (on Windows)
- <xref:System.Threading.EventWaitHandle> (on Windows)

For more information, see the <xref:System.Threading.WaitHandle> API reference.

Lightweight synchronization types don't rely on underlying operating system handles and typically provide better performance. However, they cannot be used for the inter-process synchronization. Use those types for thread synchronization within one application.

Some of those types are alternatives to the types derived from <xref:System.Threading.WaitHandle>. For example, <xref:System.Threading.SemaphoreSlim> is a lightweight alternative to <xref:System.Threading.Semaphore>.

## Synchronization of access to a shared resource

.NET provides a range of synchronization primitives to control access to a shared resource by multiple threads.

### Monitor class

The <xref:System.Threading.Monitor?displayProperty=nameWithType> class grants mutually exclusive access to a shared resource by acquiring or releasing a lock on the object that identifies the resource. While a lock is held, the thread that holds the lock can again acquire and release the lock. Any other thread is blocked from acquiring the lock and the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> method waits until the lock is released. The <xref:System.Threading.Monitor.Enter%2A> method acquires a released lock. You can also use the <xref:System.Threading.Monitor.TryEnter%2A?displayProperty=nameWithType> method to specify the amount of time during which a thread attempts to acquire a lock. Because the <xref:System.Threading.Monitor> class has thread affinity, the thread that acquired a lock must release the lock by calling the <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> method.

You can coordinate the interaction of threads that acquire a lock on the same object by using the <xref:System.Threading.Monitor.Wait%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType>, and <xref:System.Threading.Monitor.PulseAll%2A?displayProperty=nameWithType> methods.

For more information, see the <xref:System.Threading.Monitor> API reference.

> [!NOTE]
> Use the [lock](../../csharp/language-reference/statements/lock.md) statement in C# and the [SyncLock](../../visual-basic/language-reference/statements/synclock-statement.md) statement in Visual Basic to synchronize access to a shared resource instead of using the <xref:System.Threading.Monitor> class directly. Those statements are implemented by using the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> methods and a `try…finally` block to ensure that the acquired lock is always released.

### Mutex class

The <xref:System.Threading.Mutex?displayProperty=nameWithType> class, like <xref:System.Threading.Monitor>, grants exclusive access to a shared resource. Use one of the [Mutex.WaitOne](<xref:System.Threading.WaitHandle.WaitOne%2A?displayProperty=nameWithType>) method overloads to request the ownership of a mutex. Like <xref:System.Threading.Monitor>, <xref:System.Threading.Mutex> has thread affinity and the thread that acquired a mutex must release it by calling the <xref:System.Threading.Mutex.ReleaseMutex%2A?displayProperty=nameWithType> method.

Unlike <xref:System.Threading.Monitor>, the <xref:System.Threading.Mutex> class can be used for inter-process synchronization. To do that, use a named mutex, which is visible throughout the operating system. To create a named mutex instance, use a [Mutex constructor](<xref:System.Threading.Mutex.%23ctor%2A>) that specifies a name. You can also call the <xref:System.Threading.Mutex.OpenExisting%2A?displayProperty=nameWithType> method to open an existing named system mutex.
  
For more information, see the [Mutexes](mutexes.md) article and the <xref:System.Threading.Mutex> API reference.

### SpinLock structure

The <xref:System.Threading.SpinLock?displayProperty=nameWithType> structure, like <xref:System.Threading.Monitor>, grants exclusive access to a shared resource based on the availability of a lock. When <xref:System.Threading.SpinLock> attempts to acquire a lock that is unavailable, it waits in a loop, repeatedly checking until the lock becomes available.

For more information about the benefits and drawbacks of using spin lock, see the [SpinLock](spinlock.md) article and the <xref:System.Threading.SpinLock> API reference.

### ReaderWriterLockSlim class

The <xref:System.Threading.ReaderWriterLockSlim?displayProperty=nameWithType> class grants exclusive access to a shared resource for writing and allows multiple threads to access the resource simultaneously for reading. You might want to use <xref:System.Threading.ReaderWriterLockSlim> to synchronize access to a shared data structure that supports thread-safe read operations, but requires exclusive access to perform write operation. When a thread requests exclusive access (for example, by calling the <xref:System.Threading.ReaderWriterLockSlim.EnterWriteLock%2A?displayProperty=nameWithType> method), subsequent reader and writer requests block until all existing readers have exited the lock, and the writer has entered and exited the lock.
  
For more information, see the <xref:System.Threading.ReaderWriterLockSlim> API reference.

### Semaphore and SemaphoreSlim classes

The <xref:System.Threading.Semaphore?displayProperty=nameWithType> and <xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType> classes limit the number of threads that can access a shared resource or a pool of resources concurrently. Additional threads that request the resource wait until any thread releases the semaphore. Because the semaphore doesn't have thread affinity, a thread can acquire the semaphore and another one can release it.

<xref:System.Threading.SemaphoreSlim> is a lightweight alternative to <xref:System.Threading.Semaphore> and can be used only for synchronization within a single process boundary.

On Windows, you can use <xref:System.Threading.Semaphore> for the inter-process synchronization. To do that, create a <xref:System.Threading.Semaphore> instance that represents a named system semaphore by using one of the [Semaphore constructors](<xref:System.Threading.Semaphore.%23ctor%2A>) that specifies a name or the <xref:System.Threading.Semaphore.OpenExisting%2A?displayProperty=nameWithType> method. <xref:System.Threading.SemaphoreSlim> doesn't support named system semaphores.

For more information, see the [Semaphore and SemaphoreSlim](semaphore-and-semaphoreslim.md) article and the <xref:System.Threading.Semaphore> or <xref:System.Threading.SemaphoreSlim> API reference.

## Thread interaction, or signaling

Thread interaction (or thread signaling) means that a thread must wait for notification, or a signal, from one or more threads in order to proceed. For example, if thread A calls the <xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType> method of thread B, thread A is blocked until thread B completes. The synchronization primitives described in the preceding section provide a different mechanism for signaling: by releasing a lock, a thread notifies another thread that it can proceed by acquiring the lock.

This section describes additional signaling constructs provided by .NET.

### EventWaitHandle, AutoResetEvent, ManualResetEvent, and ManualResetEventSlim classes

The <xref:System.Threading.EventWaitHandle?displayProperty=nameWithType> class represents a thread synchronization event.

A synchronization event can be either in an unsignaled or signaled state. When the state of an event is unsignaled, a thread that calls the event's <xref:System.Threading.WaitHandle.WaitOne%2A?> overload is blocked until an event is signaled. The <xref:System.Threading.EventWaitHandle.Set%2A?displayProperty=nameWithType> method sets the state of an event to signaled.

The behavior of an <xref:System.Threading.EventWaitHandle> that has been signaled depends on its reset mode:

- An <xref:System.Threading.EventWaitHandle> created with the <xref:System.Threading.EventResetMode.AutoReset?displayProperty=nameWithType> flag resets automatically after releasing a single waiting thread. It's like a turnstile that allows only one thread through each time it's signaled. The <xref:System.Threading.AutoResetEvent?displayProperty=nameWithType> class, which derives from <xref:System.Threading.EventWaitHandle>, represents that behavior.
- An <xref:System.Threading.EventWaitHandle> created with the <xref:System.Threading.EventResetMode.ManualReset?displayProperty=nameWithType> flag remains signaled until its <xref:System.Threading.EventWaitHandle.Reset%2A> method is called. It's like a gate that is closed until signaled and then stays open until someone closes it. The <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType> class, which derives from <xref:System.Threading.EventWaitHandle>, represents that behavior. The <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType> class is a lightweight alternative to <xref:System.Threading.ManualResetEvent>.

On Windows, you can use <xref:System.Threading.EventWaitHandle> for the inter-process synchronization. To do that, create a <xref:System.Threading.EventWaitHandle> instance that represents a named system synchronization event by using one of the [EventWaitHandle constructors](<xref:System.Threading.EventWaitHandle.%23ctor%2A>) that specifies a name or the <xref:System.Threading.EventWaitHandle.OpenExisting%2A?displayProperty=nameWithType> method.

For more information, see the [EventWaitHandle](eventwaithandle.md) article. For the API reference, see <xref:System.Threading.EventWaitHandle>, <xref:System.Threading.AutoResetEvent>, <xref:System.Threading.ManualResetEvent>, and <xref:System.Threading.ManualResetEventSlim>.

### CountdownEvent class

The <xref:System.Threading.CountdownEvent?displayProperty=nameWithType> class represents an event that becomes set when its count is zero. While <xref:System.Threading.CountdownEvent.CurrentCount?displayProperty=nameWithType> is greater than zero, a thread that calls <xref:System.Threading.CountdownEvent.Wait%2A?displayProperty=nameWithType> is blocked. Call <xref:System.Threading.CountdownEvent.Signal%2A?displayProperty=nameWithType> to decrement an event's count.

In contrast to <xref:System.Threading.ManualResetEvent> or <xref:System.Threading.ManualResetEventSlim>, which you can use to unblock multiple threads with a signal from one thread, you can use <xref:System.Threading.CountdownEvent> to unblock one or more threads with signals from multiple threads.

For more information, see the [CountdownEvent](countdownevent.md) article and the <xref:System.Threading.CountdownEvent> API reference.

### Barrier class

The <xref:System.Threading.Barrier?displayProperty=nameWithType> class represents a thread execution barrier. A thread that calls the <xref:System.Threading.Barrier.SignalAndWait%2A?displayProperty=nameWithType> method signals that it reached the barrier and waits until other participant threads reach the barrier. When all participant threads reach the barrier, they proceed and the barrier is reset and can be used again.

You might use <xref:System.Threading.Barrier> when one or more threads require the results of other threads before proceeding to the next computation phase.

For more information, see the [Barrier](barrier.md) article and the <xref:System.Threading.Barrier> API reference.

## Interlocked class

The <xref:System.Threading.Interlocked?displayProperty=nameWithType> class provides static methods that perform simple atomic operations on a variable. Those atomic operations include addition, increment and decrement, exchange and conditional exchange that depends on a comparison, and read operation of a 64-bit integer value.

For more information, see the <xref:System.Threading.Interlocked> API reference.

## SpinWait structure

The <xref:System.Threading.SpinWait?displayProperty=nameWithType> structure provides support for spin-based waiting. You might want to use it when a thread has to wait for an event to be signaled or a condition to be met, but when the actual wait time is expected to be less than the waiting time required by using a wait handle or by otherwise blocking the thread. By using <xref:System.Threading.SpinWait>, you can specify a short period of time to spin while waiting, and then yield (for example, by waiting or sleeping) only if the condition was not met in the specified time.

For more information, see the [SpinWait](spinwait.md) article and the <xref:System.Threading.SpinWait> API reference.

## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- [Thread-safe collections](../collections/thread-safe/index.md)
- [Threading objects and features](threading-objects-and-features.md)
