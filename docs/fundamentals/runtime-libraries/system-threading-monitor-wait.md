---
title: System.Threading.Monitor.Wait methods
description: Learn about the System.Threading.Monitor.Wait methods.
ms.date: 01/24/2024
ms.topic: article
---
# System.Threading.Monitor.Wait methods

[!INCLUDE [context](includes/context.md)]

## <xref:System.Threading.Monitor.Wait(System.Object,System.Int32,System.Boolean)> method

This method does not return until it reacquires an exclusive lock on the `obj` parameter.

The thread that currently owns the lock on the specified object invokes this method in order to release the object so that another thread can access it. The caller is blocked while waiting to reacquire the lock. This method is called when the caller needs to wait for a state change that will occur as a result of another thread's operations.

The time-out ensures that the current thread does not block indefinitely if another thread releases the lock without first calling the <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A> method. It also moves the thread to the ready queue, bypassing other threads ahead of it in the wait queue, so that it can reacquire the lock sooner. The thread can test the return value of the <xref:System.Threading.Monitor.Wait%2A> method to determine whether it reacquired the lock prior to the time-out. The thread can evaluate the conditions that caused it to enter the wait, and if necessary call the <xref:System.Threading.Monitor.Wait%2A> method again.

When a thread calls `Wait`, it releases the lock and enters the waiting queue. At this point, the next thread in the ready queue (if there is one) is allowed to take control of the lock. The thread that invoked `Wait` remains in the waiting queue until either a thread that holds the lock invokes <xref:System.Threading.Monitor.PulseAll%2A>, or it is the next in the queue and a thread that holds the lock invokes <xref:System.Threading.Monitor.Pulse%2A>. However, if `millisecondsTimeout` elapses before another thread invokes this object's <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A> method, the original thread is moved to the ready queue in order to regain the lock.

> [!NOTE]
> If <xref:System.Threading.Timeout.Infinite> is specified for the `millisecondsTimeout` parameter, this method blocks indefinitely unless the holder of the lock calls <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A>. If `millisecondsTimeout` equals 0, the thread that calls `Wait` releases the lock and then immediately enters the ready queue in order to regain the lock.

The caller executes `Wait` once, regardless of the number of times <xref:System.Threading.Monitor.Enter%2A> has been invoked for the specified object. Conceptually, the `Wait` method stores the number of times the caller invoked <xref:System.Threading.Monitor.Enter%2A> on the object and invokes <xref:System.Threading.Monitor.Exit%2A> as many times as necessary to fully release the locked object. The caller then blocks while waiting to reacquire the object. When the caller reacquires the lock, the system calls <xref:System.Threading.Monitor.Enter%2A> as many times as necessary to restore the saved <xref:System.Threading.Monitor.Enter%2A> count for the caller. Calling `Wait` releases the lock for the specified object only; if the caller is the owner of locks on other objects, these locks are not released.

> [!NOTE]
> A synchronized object holds several references, including a reference to the thread that currently holds the lock, a reference to the ready queue, which contains the threads that are ready to obtain the lock, and a reference to the waiting queue, which contains the threads that are waiting for notification of a change in the object's state.

The <xref:System.Threading.Monitor.Pulse%2A>, <xref:System.Threading.Monitor.PulseAll%2A>, and `Wait` methods must be invoked from within a synchronized block of code.

The remarks for the <xref:System.Threading.Monitor.Pulse%2A> method explain what happens if <xref:System.Threading.Monitor.Pulse%2A> is called when no threads are waiting.

## <xref:System.Threading.Monitor.Wait(System.Object,System.TimeSpan,System.Boolean)> method

This method does not return until it reacquires an exclusive lock on the `obj` parameter.

The thread that currently owns the lock on the specified object invokes this method in order to release the object so that another thread can access it. The caller is blocked while waiting to reacquire the lock. This method is called when the caller needs to wait for a state change that will occur as a result of another thread's operations.

The time-out ensures that the current thread does not block indefinitely if another thread releases the lock without first calling the <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A> method. It also moves the thread to the ready queue, bypassing other threads ahead of it in the wait queue, so that it can reacquire the lock sooner. The thread can test the return value of the <xref:System.Threading.Monitor.Wait%2A> method to determine whether it reacquired the lock prior to the time-out. The thread can evaluate the conditions that caused it to enter the wait, and if necessary call the <xref:System.Threading.Monitor.Wait%2A> method again.

When a thread calls `Wait`, it releases the lock and enters the waiting queue. At this point, the next thread in the ready queue (if there is one) is allowed to take control of the lock. The thread that invoked `Wait` remains in the waiting queue until either a thread that holds the lock invokes <xref:System.Threading.Monitor.PulseAll%2A>, or it is the next in the queue and a thread that holds the lock invokes <xref:System.Threading.Monitor.Pulse%2A>. However, if `timeout` milliseconds elapse before another thread invokes this object's <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A> method, the original thread is moved to the ready queue in order to regain the lock.

> [!NOTE]
> If a <xref:System.TimeSpan> representing -1 millisecond is specified for the `timeout` parameter, this method blocks indefinitely unless the holder of the lock calls <xref:System.Threading.Monitor.Pulse%2A> or <xref:System.Threading.Monitor.PulseAll%2A>. If `timeout` is 0 milliseconds, the thread that calls `Wait` releases the lock and then immediately enters the ready queue in order to regain the lock.

The caller executes `Wait` once, regardless of the number of times <xref:System.Threading.Monitor.Enter%2A> has been invoked for the specified object. Conceptually, the `Wait` method stores the number of times the caller invoked <xref:System.Threading.Monitor.Enter%2A> on the object and invokes <xref:System.Threading.Monitor.Exit%2A> as many times as necessary to fully release the locked object. The caller then blocks while waiting to reacquire the object. When the caller reacquires the lock, the system calls <xref:System.Threading.Monitor.Enter%2A> as many times as necessary to restore the saved <xref:System.Threading.Monitor.Enter%2A> count for the caller. Calling `Wait` releases the lock for the specified object only; if the caller is the owner of locks on other objects, these locks are not released.

> [!NOTE]
> A synchronized object holds several references, including a reference to the thread that currently holds the lock, a reference to the ready queue, which contains the threads that are ready to obtain the lock, and a reference to the waiting queue, which contains the threads that are waiting for notification of a change in the object's state.

The <xref:System.Threading.Monitor.Pulse%2A>, <xref:System.Threading.Monitor.PulseAll%2A>, and `Wait` methods must be invoked from within a synchronized block of code.

The remarks for the <xref:System.Threading.Monitor.Pulse%2A> method explain what happens if <xref:System.Threading.Monitor.Pulse%2A> is called when no threads are waiting.

## Exit the context

The`exitContext` parameter has no effect unless the <xref:System.Threading.Monitor.Wait%2A> method is called from inside a nondefault managed context. This can happen if your thread is inside a call to an instance of a class derived from <xref:System.ContextBoundObject>. Even if you are currently executing a method on a class that is not derived from <xref:System.ContextBoundObject>, like <xref:System.String>, you can be in a nondefault context if a <xref:System.ContextBoundObject> is on your stack in the current application domain.

When your code is executing in a nondefault context, specifying `true` for `exitContext` causes the thread to exit the nondefault managed context (that is, to transition to the default context) before executing the <xref:System.Threading.Monitor.Wait%2A> method. It returns to the original nondefault context after the call to the <xref:System.Threading.Monitor.Wait%2A> method completes.

This can be useful when the context-bound class has the <xref:System.Runtime.Remoting.Contexts.SynchronizationAttribute> attribute applied. In that case, all calls to members of the class are automatically synchronized, and the synchronization domain is the entire body of code for the class. If code in the call stack of a member calls the <xref:System.Threading.Monitor.Wait%2A> method and specifies `true` for `exitContext`, the thread exits the synchronization domain, allowing a thread that is blocked on a call to any member of the object to proceed. When the <xref:System.Threading.Monitor.Wait%2A> method returns, the thread that made the call must wait to reenter the synchronization domain.
