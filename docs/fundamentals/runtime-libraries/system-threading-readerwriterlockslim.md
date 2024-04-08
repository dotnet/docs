---
title: System.Threading.ReaderWriterLockSlim class
description: Learn about the System.Threading.ReaderWriterLockSlim class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Threading.ReaderWriterLockSlim class

[!INCLUDE [context](includes/context.md)]

Use <xref:System.Threading.ReaderWriterLockSlim> to protect a resource that is read by multiple threads and written to by one thread at a time. <xref:System.Threading.ReaderWriterLockSlim> allows multiple threads to be in read mode, allows one thread to be in write mode with exclusive ownership of the lock, and allows one thread that has read access to be in upgradeable read mode, from which the thread can upgrade to write mode without having to relinquish its read access to the resource.

> [!NOTE]
>
> - <xref:System.Threading.ReaderWriterLockSlim> is similar to <xref:System.Threading.ReaderWriterLock>, but it has simplified rules for recursion and for upgrading and downgrading lock state. <xref:System.Threading.ReaderWriterLockSlim> avoids many cases of potential deadlock. In addition, the performance of <xref:System.Threading.ReaderWriterLockSlim> is significantly better than <xref:System.Threading.ReaderWriterLock>. <xref:System.Threading.ReaderWriterLockSlim> is recommended for all new development.
> - <xref:System.Threading.ReaderWriterLockSlim> is not thread-abort safe. You should not use it in an environment where threads accessing it can be aborted, such as .NET Framework. If you're using .NET Core or .NET 5+, it should be fine. <xref:System.Threading.Thread.Abort%2A> is not supported in .NET Core and [is obsolete](../../core/compatibility/core-libraries/5.0/thread-abort-obsolete.md) in .NET 5 and later versions.

By default, new instances of <xref:System.Threading.ReaderWriterLockSlim> are created with the <xref:System.Threading.LockRecursionPolicy.NoRecursion?displayProperty=nameWithType> flag and do not allow recursion. This default policy is recommended for all new development, because recursion introduces unnecessary complications and makes your code more prone to deadlocks. To simplify migration from existing projects that use <xref:System.Threading.Monitor> or <xref:System.Threading.ReaderWriterLock>, you can use the <xref:System.Threading.LockRecursionPolicy.SupportsRecursion?displayProperty=nameWithType> flag to create instances of <xref:System.Threading.ReaderWriterLockSlim> that allow recursion.

A thread can enter the lock in three modes: read mode, write mode, and upgradeable read mode. (In the rest of this topic, "upgradeable read mode" is referred to as "upgradeable mode", and the phrase "enter `x` mode" is used in preference to the longer phrase "enter the lock in `x` mode".)

Regardless of recursion policy, only one thread can be in write mode at any time. When a thread is in write mode, no other thread can enter the lock in any mode. Only one thread can be in upgradeable mode at any time. Any number of threads can be in read mode, and there can be one thread in upgradeable mode while other threads are in read mode.

> [!IMPORTANT]
> This type implements the <xref:System.IDisposable> interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its <xref:System.IDisposable.Dispose%2A> method in a `try`/`catch` block. To dispose of it indirectly, use a language construct such as `using` (in C#) or `Using` (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the <xref:System.IDisposable> interface topic.

<xref:System.Threading.ReaderWriterLockSlim> has managed thread affinity; that is, each <xref:System.Threading.Thread> object must make its own method calls to enter and exit lock modes. No thread can change the mode of another thread.

If a <xref:System.Threading.ReaderWriterLockSlim> does not allow recursion, a thread that tries to enter the lock can block for several reasons:

- A thread that tries to enter read mode blocks if there are threads waiting to enter write mode or if there is a single thread in write mode.

  > [!NOTE]
  > Blocking new readers when writers are queued is a lock fairness policy that favors writers. The current fairness policy balances fairness to readers and writers, to promote throughput in the most common scenarios. Future versions of .NET may introduce new fairness policies.

- A thread that tries to enter upgradeable mode blocks if there is already a thread in upgradeable mode, if there are threads waiting to enter write mode, or if there is a single thread in write mode.

- A thread that tries to enter write mode blocks if there is a thread in any of the three modes.

## Upgrade and downgrade locks

Upgradeable mode is intended for cases where a thread usually reads from the protected resource, but might need to write to it if some condition is met. A thread that has entered a <xref:System.Threading.ReaderWriterLockSlim> in upgradeable mode has read access to the protected resource, and can upgrade to write mode by calling the <xref:System.Threading.ReaderWriterLockSlim.EnterWriteLock%2A> or <xref:System.Threading.ReaderWriterLockSlim.TryEnterWriteLock%2A> methods. Because there can be only one thread in upgradeable mode at a time, upgrading to write mode cannot deadlock when recursion is not allowed, which is the default policy.

> [!IMPORTANT]
> Regardless of recursion policy, a thread that initially entered read mode is not allowed to upgrade to upgradeable mode or write mode, because that pattern creates a strong probability of deadlocks. For example, if two threads in read mode both try to enter write mode, they will deadlock. Upgradeable mode is designed to avoid such deadlocks.

If there are other threads in read mode, the thread that is upgrading blocks. While the thread is blocked, other threads that try to enter read mode are blocked. When all threads have exited from read mode, the blocked upgradeable thread enters write mode. If there are other threads waiting to enter write mode, they remain blocked, because the single thread that is in upgradeable mode prevents them from gaining exclusive access to the resource.

When the thread in upgradeable mode exits write mode, other threads that are waiting to enter read mode can do so, unless there are threads waiting to enter write mode. The thread in upgradeable mode can upgrade and downgrade indefinitely, as long as it is the only thread that writes to the protected resource.

> [!IMPORTANT]
> If you allow multiple threads to enter write mode or upgradeable mode, you must not allow one thread to monopolize upgradeable mode. Otherwise, threads that try to enter write mode directly will be blocked indefinitely, and while they are blocked, other threads will be unable to enter read mode.

A thread in upgradeable mode can downgrade to read mode by first calling the <xref:System.Threading.ReaderWriterLockSlim.EnterReadLock%2A> method and then calling the <xref:System.Threading.ReaderWriterLockSlim.ExitUpgradeableReadLock%2A> method. This downgrade pattern is allowed for all lock recursion policies, even <xref:System.Threading.LockRecursionPolicy.NoRecursion>.

After downgrading to read mode, a thread cannot reenter upgradeable mode until it has exited from read mode.

## Enter the lock recursively

You can create a <xref:System.Threading.ReaderWriterLockSlim> that supports recursive lock entry by using the <xref:System.Threading.ReaderWriterLockSlim.%23ctor%28System.Threading.LockRecursionPolicy%29> constructor that specifies lock policy, and specifying <xref:System.Threading.LockRecursionPolicy.SupportsRecursion?displayProperty=nameWithType>.

> [!NOTE]
> The use of recursion is not recommended for new development, because it introduces unnecessary complications and makes your code more prone to deadlocks.

For a <xref:System.Threading.ReaderWriterLockSlim> that allows recursion, the following can be said about the modes a thread can enter:

- A thread in read mode can enter read mode recursively, but cannot enter write mode or upgradeable mode. If it tries to do this, a <xref:System.Threading.LockRecursionException> is thrown. Entering read mode and then entering write mode or upgradeable mode is a pattern with a strong probability of deadlocks, so it is not allowed. As discussed earlier, upgradeable mode is provided for cases where it is necessary to upgrade a lock.

- A thread in upgradeable mode can enter write mode and/or read mode, and can enter any of the three modes recursively. However, an attempt to enter write mode blocks if there are other threads in read mode.

- A thread in write mode can enter read mode and/or upgradeable mode, and can enter any of the three modes recursively.

- A thread that has not entered the lock can enter any mode. This attempt can block for the same reasons as an attempt to enter a non-recursive lock.

A thread can exit the modes it has entered in any order, as long as it exits each mode exactly as many times as it entered that mode. If a thread tries to exit a mode too many times, or to exit a mode it has not entered, a <xref:System.Threading.SynchronizationLockException> is thrown.

## Lock states

You may find it useful to think of the lock in terms of its states. A <xref:System.Threading.ReaderWriterLockSlim> can be in one of four states: not entered, read, upgrade, and write.

- Not entered: In this state, no threads have entered the lock (or all threads have exited the lock).

- Read: In this state, one or more threads have entered the lock for read access to the protected resource.

    > [!NOTE]
    > A thread can enter the lock in read mode by using the <xref:System.Threading.ReaderWriterLockSlim.EnterReadLock%2A> or <xref:System.Threading.ReaderWriterLockSlim.TryEnterReadLock%2A> methods, or by downgrading from upgradeable mode.

- Upgrade: In this state, one thread has entered the lock for read access with the option to upgrade to write access (that is, in upgradeable mode), and zero or more threads have entered the lock for read access. No more than one thread at a time can enter the lock with the option to upgrade; additional threads that try to enter upgradeable mode are blocked.

- Write: In this state, one thread has entered the lock for write access to the protected resource. That thread has exclusive possession of the lock. Any other thread that tries to enter the lock for any reason is blocked.

The following table describes the transitions between lock states, for locks that do not allow recursion, when a thread `t` takes the action described in the leftmost column. At the time it takes the action, `t` has no mode. (The special case where `t` is in upgradeable mode is described in the table footnotes.) The top row describes the starting state of the lock. The cells describe what happens to the thread, and show changes to the lock state in parentheses.

| Transition | Not entered (N) | Read (R) | Upgrade (U) | Write (W) |
|------------|-----------------|----------|-------------|-----------|
|`t` enters read mode|`t` enters (R).|`t` blocks if threads are waiting for write mode; otherwise, `t` enters.|`t` blocks if threads are waiting for write mode; otherwise, `t` enters.<sup>1</sup>|`t` blocks.|
|`t` enters upgradeable mode|`t` enters (U).|`t` blocks if threads are waiting for write mode or upgrade mode; otherwise, `t` enters (U).|`t` blocks.|`t` blocks.|
|`t` enters write mode|`t` enters (W).|`t` blocks.|`t` blocks.<sup>2</sup>|`t` blocks.|

<sup>1</sup> If `t` starts out in upgradeable mode, it enters read mode. This action never blocks. The lock state does not change. (The thread can then complete a downgrade to read mode by exiting upgradeable mode.)

<sup>2</sup> If `t` starts out in upgradeable mode, it blocks if there are threads in read mode. Otherwise it upgrades to write mode. The lock state changes to Write (W). If `t` blocks because there are threads in read mode, it enters write mode as soon as the last thread exits read mode, even if there are threads waiting to enter write mode.

When a state change occurs because a thread exits the lock, the next thread to be awakened is selected as follows:

- First, a thread that is waiting for write mode and is already in upgradeable mode (there can be at most one such thread).
- Failing that, a thread that is waiting for write mode.
- Failing that, a thread that is waiting for upgradeable mode.
- Failing that, all threads that are waiting for read mode.

The subsequent state of the lock is always Write (W) in the first two cases and Upgrade (U) in the third case, regardless of the state of the lock when the exiting thread triggered the state change. In the last case, the state of the lock is Upgrade (U) if there is a thread in upgradeable mode after the state change, and Read (R) otherwise, regardless of the prior state.

## Examples

The following example shows a simple synchronized cache that holds strings with integer keys. An instance of <xref:System.Threading.ReaderWriterLockSlim> is used to synchronize access to the <xref:System.Collections.Generic.Dictionary%602> that serves as the inner cache.

The example includes simple methods to add to the cache, delete from the cache, and read from the cache. To demonstrate time-outs, the example includes a method that adds to the cache only if it can do so within a specified time-out.

To demonstrate upgradeable mode, the example includes a method that retrieves the value associated with a key and compares it with a new value. If the value is unchanged, the method returns a status indicating no change. If no value is found for the key, the key/value pair is inserted. If the value has changed, it is updated. Upgradeable mode allows the thread to upgrade from read access to write access as needed, without the risk of deadlocks.

The example includes a nested enumeration that specifies the return values for the method that demonstrates upgradeable mode.

The example uses the parameterless constructor to create the lock, so recursion is not allowed. Programming the <xref:System.Threading.ReaderWriterLockSlim> is simpler and less prone to error when the lock does not allow recursion.

:::code language="csharp" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/csharp/classexample1.cs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/vb/classexample1.vb" id="Snippet11":::
:::code language="csharp" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/csharp/classexample1.cs" id="Snippet12":::
:::code language="vb" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/vb/classexample1.vb" id="Snippet12":::

The following code then uses the `SynchronizedCache` object to store a dictionary of vegetable names. It creates three tasks. The first writes the names of vegetables stored in an array to a `SynchronizedCache` instance. The second and third task display the names of the vegetables, the first in ascending order (from low index to high index), the second in descending order. The final task searches for the string "cucumber" and, when it finds it, calls the <xref:System.Threading.ReaderWriterLockSlim.EnterUpgradeableReadLock%2A> method to substitute the string "green bean".

:::code language="csharp" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/csharp/classexample1.cs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/vb/classexample1.vb" id="Snippet11":::
:::code language="csharp" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/csharp/classexample1.cs" id="Snippet13":::
:::code language="vb" source="./snippets/System.Threading/ReaderWriterLockSlim/Overview/vb/classexample1.vb" id="Snippet13":::
