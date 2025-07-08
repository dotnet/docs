---
title: System.Threading.Monitor class
description: Learn about the System.Threading.Monitor class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Threading.Monitor class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Threading.Monitor> class allows you to synchronize access to a region of code by taking and releasing a lock on a particular object by calling the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.TryEnter%2A?displayProperty=nameWithType>, and <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> methods. Object locks provide the ability to restrict access to a block of code, commonly called a critical section. While a thread owns the lock for an object, no other thread can acquire that lock. You can also use the <xref:System.Threading.Monitor> class to ensure that no other thread is allowed to access a section of application code being executed by the lock owner, unless the other thread is executing the code using a different locked object. Because the Monitor class has thread affinity, the thread that acquired a lock must release the lock by calling the Monitor.Exit method.

## Overview

<xref:System.Threading.Monitor> has the following features:

- It is associated with an object on demand.
- It is unbound, which means it can be called directly from any context.
- An instance of the <xref:System.Threading.Monitor> class cannot be created; the methods of the <xref:System.Threading.Monitor> class are all static. Each method is passed the synchronized object that controls access to the critical section.

> [!NOTE]
> Use the <xref:System.Threading.Monitor> class to lock objects other than strings (that is, reference types other than <xref:System.String>), not value types. For details, see the overloads of the <xref:System.Threading.Monitor.Enter%2A> method and [The lock object](#the-lock-object) section later in this article.

The following table describes the actions that can be taken by threads that access synchronized objects:

|Action|Description|
|------------|-----------------|
|<xref:System.Threading.Monitor.Enter%2A>, <xref:System.Threading.Monitor.TryEnter%2A>|Acquires a lock for an object. This action also marks the beginning of a critical section. No other thread can enter the critical section unless it is executing the instructions in the critical section using a different locked object.|
|<xref:System.Threading.Monitor.Wait%2A>|Releases the lock on an object in order to permit other threads to lock and access the object. The calling thread waits while another thread accesses the object. Pulse signals are used to notify waiting threads about changes to an object's state.|
|<xref:System.Threading.Monitor.Pulse%2A> (signal), <xref:System.Threading.Monitor.PulseAll%2A>|Sends a signal to one or more waiting threads. The signal notifies a waiting thread that the state of the locked object has changed, and the owner of the lock is ready to release the lock. The waiting thread is placed in the object's ready queue so that it might eventually receive the lock for the object. Once the thread has the lock, it can check the new state of the object to see if the required state has been reached.|
|<xref:System.Threading.Monitor.Exit%2A>|Releases the lock on an object. This action also marks the end of a critical section protected by the locked object.|

There are two sets of overloads for the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.TryEnter%2A> methods. One set of overloads has a `ref` (in C#) or `ByRef` (in Visual Basic) <xref:System.Boolean> parameter that is atomically set to `true` if the lock is acquired, even if an exception is thrown when acquiring the lock. Use these overloads if it is critical to release the lock in all cases, even when the resources the lock is protecting might not be in a consistent state.

## The lock object

The Monitor class consists of `static` (`Shared` in Visual Basic) methods that operate on an object that controls access to the critical section. The following information is maintained for each synchronized object:

- A reference to the thread that currently holds the lock.
- A reference to a ready queue, which contains the threads that are ready to obtain the lock.
- A reference to a waiting queue, which contains the threads that are waiting for notification of a change in the state of the locked object.

<xref:System.Threading.Monitor> locks objects (that is, reference types), not value types. While you can pass a value type to <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A>, it is boxed separately for each call. Since each call creates a separate object, <xref:System.Threading.Monitor.Enter%2A> never blocks, and the code it is supposedly protecting is not really synchronized. In addition, the object passed to <xref:System.Threading.Monitor.Exit%2A> is different from the object passed to <xref:System.Threading.Monitor.Enter%2A>, so <xref:System.Threading.Monitor> throws <xref:System.Threading.SynchronizationLockException> exception with the message "Object synchronization method was called from an unsynchronized block of code."

The following example illustrates this problem. It launches ten tasks, each of which just sleeps for 250 milliseconds. Each task then updates a counter variable, `nTasks`, which is intended to count the number of tasks that actually launched and executed. Because `nTasks` is a global variable that can be updated by multiple tasks simultaneously, a monitor is used to protect it from simultaneous modification by multiple tasks. However, as the output from the example shows, each of the tasks throws a <xref:System.Threading.SynchronizationLockException> exception.

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/badlock1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/badlock1.vb" id="Snippet2":::

Each task throws a <xref:System.Threading.SynchronizationLockException> exception because the `nTasks` variable is boxed before the call to the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> method in each task. In other words, each method call is passed a separate variable that is independent of the others. `nTasks` is boxed again in the call to the <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> method. Once again, this creates ten new boxed variables, which are independent of each other, `nTasks`, and the ten boxed variables created in the call to the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> method. The exception is thrown, then, because our code is attempting to release a lock on a newly created variable that was not previously locked.

Although you can box a value type variable before calling <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A>, as shown in the following example, and pass the same boxed object to both methods, there is no advantage to doing this. Changes to the unboxed variable are not reflected in the boxed copy, and there is no way to change the value of the boxed copy.

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/badbox1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/badbox1.vb" id="Snippet3":::

When selecting an object on which to synchronize, you should lock only on private or internal objects. Locking on external objects might result in deadlocks, because unrelated code could choose the same objects to lock on for different purposes.

Note that you can synchronize on an object in multiple application domains if the object used for the lock derives from <xref:System.MarshalByRefObject>.

## The critical section

Use the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> methods to mark the beginning and end of a critical section.

> [!NOTE]
> The functionality provided by the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> methods is identical to that provided by the [lock](/dotnet/csharp/language-reference/keywords/lock-statement) statement in C# and the [SyncLock](../../visual-basic/language-reference/statements/synclock-statement.md) statement in Visual Basic, except that the language constructs wrap the <xref:System.Threading.Monitor.Enter(System.Object%2CSystem.Boolean%40)?displayProperty=nameWithType> method overload and the <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> method in a `try`…`finally` block to ensure that the monitor is released.

If the critical section is a set of contiguous instructions, then the lock acquired by the <xref:System.Threading.Monitor.Enter%2A> method guarantees that only a single thread can execute the enclosed code with the locked object. In this case, we recommend that you place that code in a `try` block and place the call to the <xref:System.Threading.Monitor.Exit%2A> method in a `finally` block. This ensures that the lock is released even if an exception occurs. The following code fragment illustrates this pattern.

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/Pattern2.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/Pattern2.vb" id="Snippet2":::

This facility is typically used to synchronize access to a static or instance method of a class.

If a critical section spans an entire method, the locking facility can be achieved by placing the <xref:System.Runtime.CompilerServices.MethodImplAttribute?displayProperty=nameWithType> on the method, and specifying the <xref:System.Runtime.CompilerServices.MethodImplOptions.Synchronized> value in the constructor of <xref:System.Runtime.CompilerServices.MethodImplAttribute?displayProperty=nameWithType>. When you use this attribute, the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> method calls are not needed. The following code fragment illustrates this pattern:

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/Pattern2.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/Pattern2.vb" id="Snippet3":::

Note that the attribute causes the current thread to hold the lock until the method returns; if the lock can be released sooner, use the <xref:System.Threading.Monitor> class, the C# [lock](/dotnet/csharp/language-reference/keywords/lock-statement) statement, or the Visual Basic [SyncLock](../../visual-basic/language-reference/statements/synclock-statement.md) statement inside of the method instead of the attribute.

While it is possible for the <xref:System.Threading.Monitor.Enter%2A> and <xref:System.Threading.Monitor.Exit%2A> statements that lock and release a given object to cross member or class boundaries or both, this practice is not recommended.

## Pulse, PulseAll, and Wait

Once a thread owns the lock and has entered the critical section that the lock protects, it can call the <xref:System.Threading.Monitor.Wait%2A?displayProperty=nameWithType>, <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType>, and <xref:System.Threading.Monitor.PulseAll%2A?displayProperty=nameWithType> methods.

When the thread that holds the lock calls <xref:System.Threading.Monitor.Wait%2A>, the lock is released and the thread is added to the waiting queue of the synchronized object. The first thread in the ready queue, if any, acquires the lock and enters the critical section. The thread that called <xref:System.Threading.Monitor.Wait%2A> is moved from the waiting queue to the ready queue when either the <xref:System.Threading.Monitor.Pulse%2A?displayProperty=nameWithType> or the <xref:System.Threading.Monitor.PulseAll%2A?displayProperty=nameWithType> method is called by the thread that holds the lock (to be moved, the thread must be at the head of the waiting queue). The <xref:System.Threading.Monitor.Wait%2A> method returns when the calling thread reacquires the lock.

When the thread that holds the lock calls <xref:System.Threading.Monitor.Pulse%2A>, the thread at the head of the waiting queue is moved to the ready queue. The call to the <xref:System.Threading.Monitor.PulseAll%2A> method moves all the threads from the waiting queue to the ready queue.

## Monitors and wait handles

It is important to note the distinction between the use of the <xref:System.Threading.Monitor> class and <xref:System.Threading.WaitHandle> objects.

- The <xref:System.Threading.Monitor> class is purely managed, fully portable, and might be more efficient in terms of operating-system resource requirements.
- <xref:System.Threading.WaitHandle> objects represent operating-system waitable objects, are useful for synchronizing between managed and unmanaged code, and expose some advanced operating-system features like the ability to wait on many objects at once.

## Examples

The following example uses the <xref:System.Threading.Monitor> class to synchronize access to a single instance of a random number generator represented by the <xref:System.Random> class. The example creates ten tasks, each of which executes asynchronously on a thread pool thread. Each task generates 10,000 random numbers, calculates their average, and updates two procedure-level variables that maintain a running total of the number of random numbers generated and their sum. After all tasks have executed, these two values are then used to calculate the overall mean.

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/example1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/example1.vb" id="Snippet1":::

Because they can be accessed from any task running on a thread pool thread, access to the variables `total` and `n` must also be synchronized. The <xref:System.Threading.Interlocked.Add%2A?displayProperty=nameWithType> method is used for this purpose.

The following example demonstrates the combined use of the <xref:System.Threading.Monitor> class (implemented with the `lock` or `SyncLock` language construct), the <xref:System.Threading.Interlocked> class, and the <xref:System.Threading.AutoResetEvent> class. It defines two `internal` (in C#) or `Friend` (in Visual Basic) classes, `SyncResource` and `UnSyncResource`, that respectively provide synchronized and unsynchronized access to a resource. To ensure that the example illustrates the difference between the synchronized and unsynchronized access (which could be the case if each method call completes rapidly), the method includes a random delay: for threads whose <xref:System.Threading.Thread.ManagedThreadId?displayProperty=nameWithType> property is even, the method calls <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> to introduce a delay of 2,000 milliseconds. Note that, because the `SyncResource` class is not public, none of the client code takes a lock on the synchronized resource; the internal class itself takes the lock. This prevents malicious code from taking a lock on a public object.

:::code language="csharp" source="./snippets/System.Threading/Monitor/Overview/csharp/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Threading/Monitor/Overview/vb/source.vb" id="Snippet1":::

The example defines a variable, `numOps`, that defines the number of threads that will attempt to access the resource. The application thread calls the <xref:System.Threading.ThreadPool.QueueUserWorkItem(System.Threading.WaitCallback)?displayProperty=nameWithType> method for synchronized and unsynchronized access five times each. The <xref:System.Threading.ThreadPool.QueueUserWorkItem(System.Threading.WaitCallback)?displayProperty=nameWithType> method has a single parameter, a delegate that accepts no parameters and returns no value. For synchronized access, it invokes the `SyncUpdateResource` method; for unsynchronized access, it invokes the `UnSyncUpdateResource` method. After each set of method calls, the application thread calls the [AutoResetEvent.WaitOne](xref:System.Threading.WaitHandle.WaitOne%2A) method so that it blocks until the <xref:System.Threading.AutoResetEvent> instance is signaled.

Each call to the `SyncUpdateResource` method calls the internal `SyncResource.Access` method and then calls the <xref:System.Threading.Interlocked.Decrement%2A?displayProperty=nameWithType> method to decrement the `numOps` counter. The <xref:System.Threading.Interlocked.Decrement%2A?displayProperty=nameWithType> method Is used to decrement the counter, because otherwise you cannot be certain that a second thread will access the value before a first thread's decremented value has been stored in the variable. When the last synchronized worker thread decrements the counter to zero, indicating that all synchronized threads have completed accessing the resource, the `SyncUpdateResource` method calls the <xref:System.Threading.EventWaitHandle.Set%2A?displayProperty=nameWithType> method, which signals the main thread to continue execution.

Each call to the `UnSyncUpdateResource` method calls the internal `UnSyncResource.Access` method and then calls the <xref:System.Threading.Interlocked.Decrement%2A?displayProperty=nameWithType> method to decrement the `numOps` counter. Once again, the <xref:System.Threading.Interlocked.Decrement%2A?displayProperty=nameWithType> method Is used to decrement the counter to ensure that a second thread does not access the value before a first thread's decremented value has been assigned to the variable. When the last unsynchronized worker thread decrements the counter to zero, indicating that no more unsynchronized threads need to access the resource, the `UnSyncUpdateResource` method calls the <xref:System.Threading.EventWaitHandle.Set%2A?displayProperty=nameWithType> method, which signals the main thread to continue execution.

As the output from the example shows, synchronized access ensures that the calling thread exits the protected resource before another thread can access it; each thread waits on its predecessor. On the other hand, without the lock, the `UnSyncResource.Access` method is called in the order in which threads reach it.
