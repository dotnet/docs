---
title: "Async semaphores, locks, and reader/writer coordination"
description: Learn to use SemaphoreSlim.WaitAsync for async throttling, build async locks for mutual exclusion, and coordinate readers and writers in async code.
ms.date: 04/16/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "SemaphoreSlim.WaitAsync"
  - "async lock"
  - "async semaphore"
  - "AsyncLock"
  - "reader/writer lock, async"
  - "ConcurrentExclusiveSchedulerPair"
  - "System.Threading.Channels"
---

# Async semaphores, locks, and reader/writer coordination

When async code needs throttling, mutual exclusion, or reader/writer coordination, use the built-in .NET types rather than building your own. This article shows how to apply those types, and then walks through custom implementations to explain how they work internally.

## Async semaphore — throttle concurrent access

A semaphore limits how many callers can access a resource concurrently. <xref:System.Threading.SemaphoreSlim> provides a <xref:System.Threading.SemaphoreSlim.WaitAsync%2A> method that lets you await entry without blocking a thread:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="SemaphoreSlimUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="SemaphoreSlimUsage":::

Always pair `WaitAsync` with `Release` in a `try`/`finally` block. If you forget to release, the semaphore count never increases, and other callers wait indefinitely.

### How an async semaphore works

Internally, an async semaphore maintains a count and a queue of waiters. When the count is above zero, `WaitAsync` decrements the count and returns immediately. When the count is zero, `WaitAsync` enqueues a <xref:System.Threading.Tasks.TaskCompletionSource> and returns its task. `Release` either dequeues a waiter and completes it, or increments the count:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="AsyncSemaphore":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="AsyncSemaphore":::

The `Release` method completes the `TaskCompletionSource` outside the lock, just like the `AsyncAutoResetEvent` in [Build async coordination primitives](async-coordination-primitives.md). This approach prevents synchronous continuations from running while the lock is held.

> [!TIP]
> In production code, use <xref:System.Threading.SemaphoreSlim> instead of this custom type. `SemaphoreSlim.WaitAsync` supports cancellation tokens, timeouts, and has been thoroughly tested.

## Async lock: mutual exclusion across awaits

A lock with a count of 1 provides mutual exclusion. The C# `lock` statement and <xref:System.Threading.Lock> (.NET 9+) don't work across `await` boundaries because they're thread-affine. The thread that acquires the lock might not be the thread that resumes after the `await`. Use <xref:System.Threading.SemaphoreSlim> with a count of 1 instead:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="SemaphoreSlimAsLock":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="SemaphoreSlimAsLock":::

### How an async lock works

You can wrap the semaphore pattern in a type that supports `using` for automatic release. The `LockAsync` method returns a disposable `Releaser`; when the `Releaser` is disposed, it releases the semaphore:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="AsyncLock":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="AsyncLock":::

Usage is concise and safe:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="AsyncLockUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="AsyncLockUsage":::

> [!TIP]
> In production code, use `SemaphoreSlim(1, 1)` directly with `try`/`finally`. The custom `AsyncLock` type shown here illustrates the disposable-releaser pattern but adds complexity without adding capabilities beyond what `SemaphoreSlim` provides.

## Async reader/writer coordination

A reader/writer lock allows multiple concurrent readers but only one exclusive writer. .NET provides <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair>, which offers reader/writer scheduling for tasks through two <xref:System.Threading.Tasks.TaskScheduler> instances:

- <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair.ConcurrentScheduler%2A> — runs tasks concurrently (like readers), as long as no exclusive task is active.
- <xref:System.Threading.Tasks.ConcurrentExclusiveSchedulerPair.ExclusiveScheduler%2A> — runs tasks exclusively (like writers), with no other tasks running.

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="ConcurrentExclusiveUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="ConcurrentExclusiveUsage":::

> [!IMPORTANT]
> `ConcurrentExclusiveSchedulerPair` protects at the task level, not across `await` boundaries. If a task queued to the `ExclusiveScheduler` contains an `await` on an incomplete operation, the exclusive lock releases when the `await` yields and reacquires when the continuation runs. Another exclusive or concurrent task can run during that gap. This behavior works well when you protect in-memory data structures and ensure no `await` interrupts the critical section. For scenarios that require holding the lock across awaits, use a custom `AsyncReaderWriterLock` like the one shown in the following section.

### Custom async reader/writer lock

The following implementation gives writers priority over readers. When a writer is waiting, new readers queue behind it. When a writer finishes and no other writers are waiting, all queued readers run together:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="AsyncReaderWriterLock":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="AsyncReaderWriterLock":::

Usage follows the same disposable-releaser pattern as `AsyncLock`:

:::code language="csharp" source="./snippets/async-coordination-primitives-advanced/csharp/Program.cs" id="AsyncReaderWriterLockUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives-advanced/vb/Program.vb" id="AsyncReaderWriterLockUsage":::

> [!TIP]
> A production reader/writer lock requires thorough testing for edge cases: reentrancy, error paths, cancellation, and fairness policies. Consider established libraries (such as [Nito.AsyncEx](https://github.com/StephenCleary/AsyncEx)) before building your own.

## Channels as an alternative coordination pattern

<xref:System.Threading.Channels.Channel%601> provides a thread-safe producer-consumer queue that supports `async` reads and writes. Bounded channels (<xref:System.Threading.Channels.Channel.CreateBounded%2A>) provide natural back-pressure, replacing some scenarios where you'd otherwise use a semaphore for throttling.

For more information, see [System.Threading.Channels](/dotnet/core/extensions/channels).

## See also

- [Build async coordination primitives](async-coordination-primitives.md)
- [Keeping async methods alive](keeping-async-methods-alive.md)
- [Complete your tasks](complete-your-tasks.md)
- [Consuming the Task-based Asynchronous Pattern](consuming-the-task-based-asynchronous-pattern.md)
