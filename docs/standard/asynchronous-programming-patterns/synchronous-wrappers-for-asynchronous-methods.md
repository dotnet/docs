---
title: "Synchronous wrappers for asynchronous methods"
description: Learn why you should avoid exposing synchronous wrappers for asynchronous methods in .NET libraries, and how to mitigate issues when sync-over-async is unavoidable.
ms.date: 04/06/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "sync over async"
  - "async deadlock"
  - "ConfigureAwait"
  - "asynchronous programming, wrappers"
  - "TAP, synchronous wrappers"
---
# Synchronous wrappers for asynchronous methods

When a library exposes only asynchronous APIs, consumers sometimes wrap them in synchronous calls to satisfy a synchronous interface or contract. This "sync-over-async" pattern can seem straightforward, but it's a common source of deadlocks and performance problems.

## Basic wrapping patterns

A synchronous wrapper around a Task-based Asynchronous Pattern (TAP) method accesses the task's <xref:System.Threading.Tasks.Task`1.Result> property, which blocks the calling thread:

:::code language="csharp" source="./snippets/synchronous-wrappers-for-async-methods/csharp/Program.cs" id="SyncOverAsyncTAP":::
:::code language="vb" source="./snippets/synchronous-wrappers-for-async-methods/vb/Program.vb" id="SyncOverAsyncTAP":::

This approach looks simple, but it can cause serious problems depending on the environment in which it runs.

## Deadlocks with single-threaded contexts

The most dangerous scenario occurs when you call a synchronous wrapper from a thread that has a single-threaded <xref:System.Threading.SynchronizationContext>. This scenario is typically a UI thread in WPF, Windows Forms, or MAUI applications.

:::code language="csharp" source="./snippets/synchronous-wrappers-for-async-methods/csharp/Program.cs" id="DeadlockExample":::
:::code language="vb" source="./snippets/synchronous-wrappers-for-async-methods/vb/Program.vb" id="DeadlockExample":::

Here's what happens step by step:

1. The UI thread calls `Delay`, which calls `DelayAsync(milliseconds).Wait()`.
1. `DelayAsync` runs synchronously until it reaches `await Task.Delay(milliseconds)`.
1. Because the delay isn't complete yet, `await` captures the current <xref:System.Threading.SynchronizationContext> and suspends. `DelayAsync` returns a <xref:System.Threading.Tasks.Task> to the caller.
1. The UI thread blocks in `.Wait()`, waiting for that task to complete.
1. When the delay finishes, the continuation needs to run on the original `SynchronizationContext` which is the UI thread.
1. The UI thread can't process the continuation because it's blocked in `.Wait()`.
1. **Deadlock.**

> [!IMPORTANT]
> The success or failure of sync-over-async code depends on the environment in which it runs. Code that works in a console app might deadlock on a UI thread or in ASP.NET (on .NET Framework). This environmental dependency is a core reason to avoid exposing synchronous wrappers.

## Thread pool exhaustion

Deadlocks aren't limited to UI threads. If an asynchronous method depends on the thread pool to complete its work, for example, by queuing a final processing step, blocking many pool threads with synchronous wrappers can starve the pool:

:::code language="csharp" source="./snippets/synchronous-wrappers-for-async-methods/csharp/Program.cs" id="ThreadPoolDeadlock":::

In this scenario:

1. Many thread pool threads call `Foo`, which blocks in `.Result`.
1. Each async operation completes its I/O and needs a thread pool thread to run its completion callback.
1. Because blocked calls occupy available worker threads, completions might wait a long time for a thread to become available.
1. Modern .NET can add more thread pool threads over time, but the application can still suffer severe thread pool starvation, poor throughput, long delays, or an apparent hang.

This pattern affected `HttpWebRequest.GetResponse` in .NET Framework 1.x, where the synchronous method was implemented as a wrapper around the asynchronous `BeginGetResponse`/`EndGetResponse`.

## Guideline: Avoid exposing synchronous wrappers

Don't expose a synchronous method that wraps an asynchronous implementation. Instead, leave the decision of whether to block to the consumer. The consumer knows their threading environment and can make an informed choice.

If you find yourself needing to call an asynchronous method synchronously, consider first whether you can restructure the code to be "async all the way down." Refactoring is often the better long-term solution.

## Mitigation strategies when sync-over-async is unavoidable

Sometimes sync-over-async is truly unavoidable. For example, it's unavoidable when you implement an interface that requires a synchronous method, and the only available implementation is asynchronous. In those cases, apply the following strategies to reduce the risk.

### Use `ConfigureAwait(false)` in the async implementation

If you control the async method, use <xref:System.Threading.Tasks.Task.ConfigureAwait*?displayProperty=nameWithType> with `false` on every `await` to prevent the continuation from marshaling back to the original `SynchronizationContext`:

:::code language="csharp" source="./snippets/synchronous-wrappers-for-async-methods/csharp/Program.cs" id="ConfigureAwaitMitigation":::
:::code language="vb" source="./snippets/synchronous-wrappers-for-async-methods/vb/Program.vb" id="ConfigureAwaitMitigation":::

As a library author, use `ConfigureAwait(false)` on all awaits unless your code specifically needs to resume on the captured context. Using `ConfigureAwait(false)` is a best practice for performance and helps prevent deadlocks when consumers block.

### Offload to the thread pool

If you don't control the async implementation (and it might not use `ConfigureAwait(false)`), offload the call to the thread pool. The thread pool doesn't have a <xref:System.Threading.SynchronizationContext>, so the await won't try to marshal back to a blocked thread:

```csharp
public int Sync()
{
    return Task.Run(() => Library.FooAsync()).Result;
}
```

```vb
Public Function Sync() As Integer
    Return Task.Run(Function() Library.FooAsync()).Result
End Function
```

### Test in multiple environments

If you must ship a synchronous wrapper, test it from:

- A UI thread (WPF, Windows Forms).
- The thread pool under load.
- The thread pool with a low maximum thread count.
- A console application.

Behavior that works in one environment might deadlock in another.

## See also

- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Consume the task-based asynchronous pattern](consuming-the-task-based-asynchronous-pattern.md)
- [Asynchronous wrappers for synchronous methods](async-wrappers-for-synchronous-methods.md)
