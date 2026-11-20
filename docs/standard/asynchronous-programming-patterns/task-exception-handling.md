---
title: "Task exception handling"
description: Learn how exceptions propagate through Task APIs, when AggregateException appears, and how unobserved task exceptions behave in modern .NET.
ms.date: 04/14/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Task.Result"
  - "GetAwaiter().GetResult()"
  - "AggregateException"
  - "TaskScheduler.UnobservedTaskException"
  - "Task exception handling"
---

# Task exception handling

Use `await` as your default. `await` gives you natural exception flow, keeps your code readable, and avoids sync-over-async deadlocks.

Sometimes you still need to block on a <xref:System.Threading.Tasks.Task>, for example, in legacy synchronous entry points. In those cases, you need to understand how each API surfaces exceptions.

## Compare exception propagation for blocking APIs

When you must block on a task, use <xref:System.Threading.Tasks.Task.GetAwaiter%2A>().GetResult() to preserve the original exception type:

:::code language="csharp" source="./snippets/task-exception-handling/csharp/Program.cs" id="SingleException":::
:::code language="vb" source="./snippets/task-exception-handling/vb/Program.vb" id="SingleException":::

<xref:System.Threading.Tasks.Task`1.Result?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.Wait%2A> wrap exceptions in <xref:System.AggregateException>, which complicates exception handling. The following code uses these APIs and receives the wrong exception type:

:::code language="csharp" source="./snippets/task-exception-handling/csharp/Program.cs" id="SingleExceptionBad":::
:::code language="vb" source="./snippets/task-exception-handling/vb/Program.vb" id="SingleExceptionBad":::

For tasks that fault with multiple exceptions, `GetAwaiter().GetResult()` still throws one exception, but <xref:System.Threading.Tasks.Task.Exception?displayProperty=nameWithType> stores an <xref:System.AggregateException> that contains all inner exceptions:

:::code language="csharp" source="./snippets/task-exception-handling/csharp/Program.cs" id="MultiException":::
:::code language="vb" source="./snippets/task-exception-handling/vb/Program.vb" id="MultiException":::

## `Task.Result` vs `GetAwaiter().GetResult()`

Use this guidance when you choose between the two APIs:

- Prefer `await` when you can. It avoids blocking and deadlock risk.
- If you must block and you want original exception types, use `GetAwaiter().GetResult()`. In WinForms applications, note the [Common pitfalls and deadlocks](/dotnet/desktop/winforms/forms/events#common-pitfalls-and-deadlocks) section of the article on event handlers.
- If your existing code expects <xref:System.AggregateException>, use `Result` or `Wait()` and inspect `InnerExceptions`.

These rules affect exception shape only. Both APIs still block the current thread, so both can deadlock on single-threaded <xref:System.Threading.SynchronizationContext> environments. To understand how to properly complete tasks on all code paths, see [Complete your tasks](complete-your-tasks.md).

## Unobserved task exceptions in modern .NET

The runtime raises <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=nameWithType> when a faulted `Task` gets finalized before code observes its exception.

In modern .NET, unobserved exceptions no longer crash the process by default. The runtime reports them through the event, and then continues execution.

:::code language="csharp" source="./snippets/task-exception-handling/csharp/Program.cs" id="UnobservedTaskException":::
:::code language="vb" source="./snippets/task-exception-handling/vb/Program.vb" id="UnobservedTaskException":::

Use the event for diagnostics and telemetry. Don't use the event as a replacement for normal exception handling in async flows.

## See also

- [Common async/await bugs](common-async-bugs.md)
- [Consume the TAP](consuming-the-task-based-asynchronous-pattern.md)
- [Exception handling (Task Parallel Library)](../parallel-programming/exception-handling-task-parallel-library.md)
