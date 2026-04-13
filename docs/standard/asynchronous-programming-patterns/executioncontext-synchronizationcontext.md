---
title: "ExecutionContext and SynchronizationContext"
description: Learn about the difference between ExecutionContext and SynchronizationContext in .NET, how each one is used with async/await, and why SynchronizationContext.Current doesn't flow across awaits.
ms.date: 04/08/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ExecutionContext"
  - "SynchronizationContext"
  - "async await context"
  - "ConfigureAwait"
  - "context flow"
  - "asynchronous programming, context"
---
# ExecutionContext and SynchronizationContext

When you work with `async` and `await`, two context types play important but very different roles: <xref:System.Threading.ExecutionContext> and <xref:System.Threading.SynchronizationContext>. You learn what each one does, how each one interacts with `async`/`await`, and why <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> doesn't flow across await points.

## What is ExecutionContext?

<xref:System.Threading.ExecutionContext> is a container for ambient state that flows with the logical control flow of your program. In a synchronous world, ambient information lives in thread-local storage (TLS), and all code running on a given thread sees that data. In an asynchronous world, a logical operation can start on one thread, suspend, and resume on a different thread. Thread-local data doesn't follow along automatically—<xref:System.Threading.ExecutionContext> makes it follow.

### How ExecutionContext flows

Capture <xref:System.Threading.ExecutionContext> by using <xref:System.Threading.ExecutionContext.Capture?displayProperty=nameWithType>. Restore it during execution of a delegate by using <xref:System.Threading.ExecutionContext.Run*?displayProperty=nameWithType>:

:::code language="csharp" source="./snippets/executioncontext-synchronizationcontext/csharp/Program.cs" id="ExecutionContextCapture":::
:::code language="vb" source="./snippets/executioncontext-synchronizationcontext/vb/Program.vb" id="ExecutionContextCapture":::

All asynchronous APIs in .NET that fork work—<xref:System.Threading.Tasks.Task.Run*>, <xref:System.Threading.ThreadPool.QueueUserWorkItem*>, <xref:System.IO.Stream.BeginRead*>, and others—capture <xref:System.Threading.ExecutionContext> and use the stored context when invoking your callback. This process of capturing state on one thread and restoring it on another is what "flowing ExecutionContext" means.

## What is SynchronizationContext?

<xref:System.Threading.SynchronizationContext> is an abstraction that represents a target environment where you want work to run. Different UI frameworks provide their own implementations:

- Windows Forms provides `WindowsFormsSynchronizationContext`, which overrides <xref:System.Threading.SynchronizationContext.Post*> to call `Control.BeginInvoke`.
- WPF provides `DispatcherSynchronizationContext`, which overrides <xref:System.Threading.SynchronizationContext.Post*> to call `Dispatcher.BeginInvoke`.
- ASP.NET (on .NET Framework) provided its own context that ensured `HttpContext.Current` was available.

By using <xref:System.Threading.SynchronizationContext> instead of framework-specific marshaling APIs, you can write components that work across UI frameworks:

:::code language="csharp" source="./snippets/executioncontext-synchronizationcontext/csharp/Program.cs" id="SyncContextUsage":::
:::code language="vb" source="./snippets/executioncontext-synchronizationcontext/vb/Program.vb" id="SyncContextUsage":::

### Capture a SynchronizationContext

When you capture a <xref:System.Threading.SynchronizationContext>, you read the reference from <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> and store it for later use. You then call <xref:System.Threading.SynchronizationContext.Post*> on the captured reference to schedule work back to that environment.

## Flowing ExecutionContext vs. using SynchronizationContext

Although both mechanisms involve capturing state from a thread, they serve different purposes:

- **Flowing ExecutionContext** means capturing ambient state and making that same state current during a delegate's execution. The delegate runs wherever it ends up running—the state follows it.
- **Using SynchronizationContext** means capturing a scheduling target and using it to *decide where a delegate executes*. The captured context controls where the delegate runs.

In short: <xref:System.Threading.ExecutionContext> answers "what environment should be visible?" while <xref:System.Threading.SynchronizationContext> answers "where should the code run?"

## How async/await interacts with both contexts

The `async`/`await` infrastructure interacts with both contexts automatically, but in different ways.

### ExecutionContext always flows

Whenever an `await` suspends a method (because the awaiter's `IsCompleted` returns `false`), the infrastructure captures an <xref:System.Threading.ExecutionContext>. When the method resumes, the continuation runs within the captured context. This behavior is built into the async method builders (for example, <xref:System.Runtime.CompilerServices.AsyncTaskMethodBuilder>) and applies regardless of what kind of awaitable you use.

<xref:System.Threading.ExecutionContext.SuppressFlow> exists, but it isn't an await-specific switch like `ConfigureAwait(false)`. It suppresses <xref:System.Threading.ExecutionContext> capture for work that you queue while suppression is active. It doesn't provide a per-`await` programming-model option that tells the async method builders to skip restoring the captured <xref:System.Threading.ExecutionContext> for a continuation. That design is intentional because <xref:System.Threading.ExecutionContext> is infrastructure-level support that simulates thread-local semantics in an asynchronous world, and most developers never need to think about it.

### Task awaiters capture SynchronizationContext

The awaiters for <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task`1> include support for <xref:System.Threading.SynchronizationContext>. The async method builders don't include this support.

When you `await` a task:

1. The awaiter checks <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType>.
1. If a context exists, the awaiter captures it.
1. When the task completes, the continuation is posted back to that captured context instead of running on the completing thread or the thread pool.

This behavior is how `await` "brings you back to where you were". For example, resuming on the UI thread in a desktop application.

### ConfigureAwait controls SynchronizationContext capture

If you don't want the marshaling behavior, call <xref:System.Threading.Tasks.Task.ConfigureAwait*> with `false`:

```csharp
await task.ConfigureAwait(false);
```

When you set `continueOnCapturedContext` to `false`, the awaiter doesn't check for a <xref:System.Threading.SynchronizationContext> and the continuation runs wherever the task completes (typically on a thread pool thread). Library authors should use `ConfigureAwait(false)` on every await unless the code specifically needs to resume on the captured context.

## SynchronizationContext.Current doesn't flow across awaits

This point is the most important: <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> **doesn't flow** across await points. The async method builders in the runtime use internal overloads that explicitly suppress <xref:System.Threading.SynchronizationContext> from flowing as part of <xref:System.Threading.ExecutionContext>.

### Why this matters

Technically, <xref:System.Threading.SynchronizationContext> is one of the sub-contexts that <xref:System.Threading.ExecutionContext> can contain. If it flowed as part of <xref:System.Threading.ExecutionContext>, code executing on a thread pool thread might see a UI `SynchronizationContext` as `Current`, not because that thread is the UI thread, but because the context "leaked" via flow. That change would alter the meaning of <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> from "the environment I'm currently in" to "the environment that historically existed somewhere in the call chain."

### The Task.Run example

Consider code that offloads work to the thread pool. The UI-thread behavior described here applies only when <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> is non-null, such as in a UI app:

:::code language="csharp" source="./snippets/executioncontext-synchronizationcontext/csharp/Program.cs" id="TaskRunExample":::
:::code language="vb" source="./snippets/executioncontext-synchronizationcontext/vb/Program.vb" id="TaskRunExample":::

In a console app, <xref:System.Threading.SynchronizationContext.Current?displayProperty=nameWithType> is typically `null`, so the snippet doesn't resume on a real UI thread. Instead, the snippet illustrates the rule conceptually: if a UI <xref:System.Threading.SynchronizationContext> flowed across `await` points, the `await` inside the delegate passed to <xref:System.Threading.Tasks.Task.Run*?displayProperty=nameWithType> would see that UI context as `Current`. The continuation after `await DownloadAsync()` would then post back to the UI thread, causing `Compute(data)` to run on the UI thread instead of on the thread pool. That behavior defeats the purpose of the `Task.Run` call.

Because the runtime suppresses <xref:System.Threading.SynchronizationContext> flow in <xref:System.Threading.ExecutionContext>, the `await` inside `Task.Run` doesn't inherit an outer UI context, and the continuation keeps running on the thread pool as intended.

## Summary

| Aspect | ExecutionContext | SynchronizationContext |
|---|---|---|
| **Purpose** | Carries ambient state across async boundaries | Represents a target scheduler (where code should run) |
| **Captured by** | Async method builders (infrastructure) | Task awaiters (`await task`) |
| **Flows across await?** | Yes, always | No—captured and posted to, not flowed |
| **Suppression API** | `ExecutionContext.SuppressFlow` (advanced; rarely needed) | `ConfigureAwait(false)` |
| **Scope** | All awaitables | `Task` and `Task<TResult>` (custom awaiters can add similar logic) |

## See also

- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Consume the task-based asynchronous pattern](consuming-the-task-based-asynchronous-pattern.md)
- [SynchronizationContext and console apps](synchronizationcontext-console-apps.md)
