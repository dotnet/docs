---
title: "Keeping async methods alive"
description: Learn how to avoid lifetime bugs in fire-and-forget async code by keeping task ownership explicit, observing failures, and coordinating shutdown.
ms.date: 04/15/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "fire-and-forget"
  - "async lifetime"
  - "unobserved task exception"
  - "background task tracking"
  - "TAP best practices"
---
# Keeping async methods alive

Fire-and-forget work is easy to start and easy to lose. If you start an asynchronous operation and drop the returned <xref:System.Threading.Tasks.Task>, you lose visibility into completion, cancellation, and failures.

Most lifetime bugs in async code are ownership bugs, not compiler bugs. The `async` state machine and its `Task` stay alive while work is still reachable through continuations. Problems happen when your app no longer tracks that work.

## Why fire-and-forget causes lifetime bugs

When you start background work without tracking it, you create three risks:

- The operation can fail, and nobody observes the exception.
- The process or host can shut down before the operation finishes.
- The operation can outlive the object or scope that was meant to control it.

Use fire-and-forget only when the work is truly optional and failure is acceptable.

## Bad and good fire-and-forget patterns

The following example starts untracked work and then shows a tracked alternative:

:::code language="csharp" source="./snippets/keeping-async-methods-alive/csharp/Program.cs" id="FireAndForgetPitfall":::
:::code language="vb" source="./snippets/keeping-async-methods-alive/vb/Program.vb" id="FireAndForgetPitfall":::

:::code language="csharp" source="./snippets/keeping-async-methods-alive/csharp/Program.cs" id="FireAndForgetFix":::
:::code language="vb" source="./snippets/keeping-async-methods-alive/vb/Program.vb" id="FireAndForgetFix":::

Track long-running work in an owner component and await tracked tasks during shutdown.

## Keep ownership explicit

Prefer one of these ownership models:

- Return the `Task` and require callers to await it.
- Track background tasks in a dedicated owner service.
- Use a host-managed background abstraction so the host owns lifetime.

If work must continue after the caller returns, transfer ownership explicitly. For example, hand the task to a tracker that logs errors and participates in shutdown.

## Surface exceptions from background tasks

Dropped tasks can fail silently until finalization and unobserved-exception handling occurs. That timing is non-deterministic and too late for normal request or workflow handling.

Attach observation logic when you queue background work. At minimum, log failures in a continuation. Prefer a centralized tracker so every queued operation gets the same policy.

For exception propagation details, see [Task exception handling](task-exception-handling.md).

## Coordinate cancellation and shutdown

Tie background work to a cancellation token that represents app or operation lifetime. During shutdown:

1. Stop accepting new work.
1. Signal cancellation.
1. Await tracked tasks with a bounded timeout.
1. Log incomplete operations.

This flow keeps shutdown predictable and prevents partial writes or orphaned operations.

## FAQ: Can the GC collect an async method before it finishes?

The runtime keeps the async state machine alive while continuations still reference it. You usually don't lose an in-flight async operation to garbage collection of the state machine itself.

You still can lose correctness if you lose ownership of the returned task, dispose required resources early, or let the process end before completion. Focus on task ownership and coordinated shutdown.

## See also

- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Consuming the Task-based Asynchronous Pattern](consuming-the-task-based-asynchronous-pattern.md)
- [Common async/await bugs](common-async-bugs.md)
- [ExecutionContext and SynchronizationContext](executioncontext-synchronizationcontext.md)
- [Task exception handling](task-exception-handling.md)
