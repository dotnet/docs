---
title: "Build async coordination primitives"
description: Learn how to build async coordination primitives using TaskCompletionSource, including manual-reset events, auto-reset events, countdown events, and barriers.
ms.date: 04/16/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "async coordination"
  - "TaskCompletionSource"
  - "AsyncManualResetEvent"
  - "AsyncAutoResetEvent"
  - "AsyncCountdownEvent"
  - "AsyncBarrier"
  - "coordination primitives"
---

# Build async coordination primitives

Synchronous coordination primitives like <xref:System.Threading.ManualResetEventSlim>, <xref:System.Threading.CountdownEvent>, and <xref:System.Threading.Barrier> block the calling thread while waiting. In async code, blocking a thread wastes a resource that could be doing other work. Use <xref:System.Threading.Tasks.TaskCompletionSource> to build async equivalents that let callers `await` instead of blocking.

A `TaskCompletionSource` produces a <xref:System.Threading.Tasks.Task> that you complete manually by calling <xref:System.Threading.Tasks.TaskCompletionSource.SetResult%2A>, <xref:System.Threading.Tasks.TaskCompletionSource.SetException%2A>, or <xref:System.Threading.Tasks.TaskCompletionSource.SetCanceled%2A>. Code that awaits that task suspends without blocking a thread, and resumes when you complete the source. This pattern forms the building block for every primitive in this article.

> [!NOTE]
> The primitives in this article are educational implementations. For production throttling and mutual exclusion, use the built-in types covered in [Async semaphores, locks, and reader/writer coordination](async-coordination-primitives-advanced.md). Always complete every `TaskCompletionSource` you create; see [Complete your tasks](complete-your-tasks.md) for guidance.

## Async manual-reset event

A manual-reset event starts in a non-signaled state. Callers wait for the event, and all waiters resume when another party signals (sets) the event. The event stays signaled until you explicitly reset it. The synchronous equivalent is <xref:System.Threading.ManualResetEventSlim>.

`TaskCompletionSource` is itself a one-shot manual-reset event: its `Task` is incomplete until you call a `Set*` method, and then all awaiters resume. Add a `Reset` method that swaps in a new `TaskCompletionSource`, and you have a reusable async manual-reset event.

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncManualResetEvent":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncManualResetEvent":::

Key implementation details:

- The constructor passes <xref:System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously?displayProperty=nameWithType> to prevent `Set` from running waiter continuations synchronously on the calling thread. Without this flag, `Set` could block for an unpredictable amount of time.
- `Reset` uses <xref:System.Threading.Interlocked.CompareExchange%2A> to swap in a new `TaskCompletionSource` only when the current one is already completed. This atomic swap prevents orphaning a task that a waiter already received.

The following example shows how two tasks coordinate through the event:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncManualResetEventUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncManualResetEventUsage":::

## Async auto-reset event

An auto-reset event is similar to a manual-reset event, but it automatically returns to the non-signaled state after releasing exactly one waiter. If multiple callers are waiting when the event is signaled, only one waiter resumes. The synchronous equivalent is <xref:System.Threading.AutoResetEvent>.

Because each signal releases only one waiter, you need a collection of `TaskCompletionSource` instances—one per waiter—so you can complete them individually:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncAutoResetEvent":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncAutoResetEvent":::

Key implementation details:

- The `Set` method completes the `TaskCompletionSource` *outside* the lock. Completing a TCS inside the lock would run synchronous continuations while the lock is held, which could cause deadlocks or unexpected reentrancy.
- When `Set` is called and no waiter is queued, the signal is stored so the next `WaitAsync` call completes immediately.

The following example shows a producer signaling a consumer through the event:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncAutoResetEventUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncAutoResetEventUsage":::

## Async countdown event

A countdown event waits for a specified number of signals before it allows waiters to proceed. This pattern is useful for fork/join scenarios where you start N operations and want to await all N completions. The synchronous equivalent is <xref:System.Threading.CountdownEvent>.

Build the async version by composing the `AsyncManualResetEvent` from the previous section with an atomic counter:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncCountdownEvent":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncCountdownEvent":::

The `Signal` method decrements the count atomically with <xref:System.Threading.Interlocked.Decrement%2A>. When the count reaches zero, it sets the inner event, and all waiters resume.

The following example uses a countdown event to await three concurrent operations:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncCountdownEventUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncCountdownEventUsage":::

## Async barrier

A barrier coordinates a fixed set of participants across multiple rounds. Each participant signals when it finishes its work for the current round and then waits for all other participants to finish. When the last participant signals, all participants resume, and the barrier resets for the next round. The synchronous equivalent is <xref:System.Threading.Barrier>.

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncBarrier":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncBarrier":::

Key implementation details:

- Before completing the shared `TaskCompletionSource`, the method resets the count and swaps in a new `TaskCompletionSource` for the next round. This ordering ensures that when waiters resume, the barrier is already ready for the next round.
- All participants share the same `Task`, which means all synchronous continuations run in series on the thread that completes the task. If that serialization is a concern, give each participant its own `TaskCompletionSource` and complete them in parallel.

The following example runs three participants through two rounds of a barrier:

:::code language="csharp" source="./snippets/async-coordination-primitives/csharp/Program.cs" id="AsyncBarrierUsage":::
:::code language="vb" source="./snippets/async-coordination-primitives/vb/Program.vb" id="AsyncBarrierUsage":::

## See also

- [Async semaphores, locks, and reader/writer coordination](async-coordination-primitives-advanced.md)
- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Complete your tasks](complete-your-tasks.md)
- [Keeping async methods alive](keeping-async-methods-alive.md)
