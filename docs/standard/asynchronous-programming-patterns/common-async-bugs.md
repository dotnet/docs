---
title: "Common async/await bugs"
description: Learn to diagnose the five most common bugs in async/await code, including synchronous execution, async void, SynchronizationContext deadlocks, miassing `await` expressions and Task unwrapping.
ms.date: 04/09/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "async debugging"
  - "async void"
  - "deadlock, async"
  - "SynchronizationContext, deadlock"
  - "Task<Task>, unwrapping"
  - "ConfigureAwait"
---
# Common async/await bugs

Async/await simplifies asynchronous programming, but certain mistakes appear repeatedly. This article describes the five most common bugs in async code and shows you how to fix each one.

## Async method runs synchronously

Adding the `async` keyword to a method doesn't make the method run on a background thread. It tells the compiler to allow `await` inside the method body and to wrap the return value in a <xref:System.Threading.Tasks.Task>. When you invoke an async method, it runs synchronously until it reaches the first `await` on an incomplete awaitable. If the method contains no `await` expressions, or if every awaitable it awaits is already complete, the method completes entirely on the calling thread:

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="SyncExecution":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="SyncExecution":::

Here the method returns a completed task immediately because it never yields. The compiler emits a warning when an async method lacks `await` expressions.

If your goal is to offload CPU-bound work to a thread pool thread, use <xref:System.Threading.Tasks.Task.Run*> instead of `async`:

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="OffloadCorrectly":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="OffloadCorrectly":::

For more guidance on when to use `Task.Run`, see [Asynchronous wrappers for synchronous methods](async-wrappers-for-synchronous-methods.md).

## Can't await an async void method

When you convert a synchronous `void`-returning method to async, change the return type to <xref:System.Threading.Tasks.Task>. If you leave the return type as `void`, the method becomes "async void," which you can't await:

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="AsyncVoid":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="AsyncVoid":::

Async void methods serve a specific purpose: top-level event handlers in UI frameworks. Outside of event handlers, always return `Task` or `Task<T>` from async methods. Async void methods have these drawbacks:

- **Exceptions go unobserved.** Exceptions thrown in an async void method propagate to the <xref:System.Threading.SynchronizationContext> that was active when the method started. The caller can't catch these exceptions.
- **Callers can't track completion.** Without a `Task`, there's no mechanism to know when the operation finishes.
- **Testing is difficult.** You can't await the method in a test to verify its behavior.

## Deadlocks from blocking on async code

This bug is the most common cause of async code that "never completes." It happens when you synchronously block (call <xref:System.Threading.Tasks.Task.Wait*>, <xref:System.Threading.Tasks.Task`1.Result?displayProperty=nameWithType>, or <xref:System.Threading.Tasks.Task.GetAwaiter*>.<xref:System.Runtime.CompilerServices.TaskAwaiter.GetResult*>) on a thread that has a single-threaded <xref:System.Threading.SynchronizationContext>.

The sequence that causes a deadlock:

1. Code on the UI thread (or an ASP.NET request thread in older ASP.NET) calls an async method and blocks on the returned task.
1. The async method awaits an incomplete task without using `ConfigureAwait(false)`.
1. When the awaited task completes, the continuation tries to post back to the original `SynchronizationContext`.
1. That context's thread is blocked waiting for the task to complete—deadlock.

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="Deadlock":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="Deadlock":::

### How to avoid deadlocks

Use one or more of these strategies:

- **Don't block.** Use `await` instead of `.Result` or `.Wait()`:

  :::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="DeadlockFix1":::
  :::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="DeadlockFix1":::

- **Use `ConfigureAwait(false)` in library code.** When your library method doesn't need to resume on the caller's context, specify `ConfigureAwait(false)` on every `await`:

  :::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="DeadlockFix2":::
  :::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="DeadlockFix2":::

  Using `ConfigureAwait(false)` tells the runtime not to marshal the continuation back to the original `SynchronizationContext`. This approach protects callers who block, and it improves performance by avoiding unnecessary thread hops.

> [!WARNING]
> **Static constructor deadlocks.** The CLR holds a lock while running static constructors (`cctor`s). If a static constructor blocks on a task, and that task's continuation needs to run code in the same type (or a type involved in the construction chain), the continuation can't proceed because the `cctor` lock is held. Avoid blocking calls inside static constructors entirely.

## Task\<Task> unwrapping

When you pass an async lambda to a method like <xref:System.Threading.Tasks.TaskFactory.StartNew*>, the returned object is a `Task<Task>` (or `Task<Task<TResult>>`), not a simple `Task`. The outer task completes as soon as the async lambda hits its first yielding `await`. It doesn't wait for the inner task to finish:

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="TaskTaskBug":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="TaskTaskBug":::

Fix this problem in one of three ways:

- **Use <xref:System.Threading.Tasks.Task.Run*> instead.** `Task.Run` automatically unwraps `Task<Task>`:

  :::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="TaskTaskFix1":::
  :::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="TaskTaskFix1":::

- **Call <xref:System.Threading.Tasks.TaskExtensions.Unwrap*> on the result:**

  :::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="TaskTaskFix2":::
  :::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="TaskTaskFix2":::

- **Await twice** (first the outer task, then the inner):

  :::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="TaskTaskFix3":::
  :::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="TaskTaskFix3":::

## Missing await on a task-returning call

If you call a task-returning method in an `async` method without awaiting it, the method starts the asynchronous operation but doesn't wait for it to complete. The compiler warns you about this case with `CS4014` in C# and `BC42358` in Visual Basic:

:::code language="csharp" source="./snippets/common-async-bugs/csharp/Program.cs" id="MissingAwait":::
:::code language="vb" source="./snippets/common-async-bugs/vb/Program.vb" id="MissingAwait":::

Storing the result in a variable suppresses the warning but doesn't fix the underlying bug. Always `await` the task unless you intentionally want fire-and-forget behavior.

## See also

- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Async lambda pitfalls](async-lambda-pitfalls.md)
- [Asynchronous wrappers for synchronous methods](async-wrappers-for-synchronous-methods.md)
- [Synchronous wrappers for asynchronous methods](synchronous-wrappers-for-asynchronous-methods.md)
