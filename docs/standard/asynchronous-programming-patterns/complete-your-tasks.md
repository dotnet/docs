---
title: "Complete your tasks"
description: Learn how to complete TaskCompletionSource tasks on every code path, avoid hangs, and handle reset scenarios safely.
ms.date: 04/14/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "TaskCompletionSource"
  - "SetException"
  - "TrySetResult"
  - "async hangs"
  - "resettable async primitives"
---

# Complete your tasks

When you expose a task from <xref:System.Threading.Tasks.TaskCompletionSource%601>, you own the task's lifetime. Complete that task on every path. If any path skips completion, callers wait forever.

## Complete every code path

Always complete the task in success and failure paths. Use a `catch` block for cleanup logic when the task fails. Use a `finally` block for cleanup logic that must always run. The following code block shows adding cleanup for a failure path:

:::code language="csharp" source="./snippets/complete-your-tasks/csharp/Program.cs" id="MissingSetExceptionFix":::
:::code language="vb" source="./snippets/complete-your-tasks/vb/Program.vb" id="MissingSetExceptionFix":::

The following code catches an exception, logs it, and forgets to call <xref:System.Threading.Tasks.TaskCompletionSource%601.SetException%2A> or <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetException%2A>. This bug appears often and causes callers to wait forever. For more details about exception handling with tasks, see [Task exception handling](task-exception-handling.md).

:::code language="csharp" source="./snippets/complete-your-tasks/csharp/Program.cs" id="MissingSetExceptionBug":::
:::code language="vb" source="./snippets/complete-your-tasks/vb/Program.vb" id="MissingSetExceptionBug":::

## Prefer `TrySet*` in completion races

Concurrent paths often race to complete the same `TaskCompletionSource`. <xref:System.Threading.Tasks.TaskCompletionSource%601.SetResult%2A>, <xref:System.Threading.Tasks.TaskCompletionSource%601.SetException%2A>, and <xref:System.Threading.Tasks.TaskCompletionSource%601.SetCanceled%2A> throw if the task already completed. In race-prone code, use <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetResult%2A>, <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetException%2A>, and <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetCanceled%2A>. For more patterns to avoid in concurrent scenarios, see [Common async/await bugs](common-async-bugs.md).

:::code language="csharp" source="./snippets/complete-your-tasks/csharp/Program.cs" id="TrySetRace":::
:::code language="vb" source="./snippets/complete-your-tasks/vb/Program.vb" id="TrySetRace":::

## Don't drop references during reset

A common bug appears in resettable async primitives. Fix the reset path by atomically swapping references and completing the previous task (for example, with cancellation):

:::code language="csharp" source="./snippets/complete-your-tasks/csharp/Program.cs" id="ResetFix":::
:::code language="vb" source="./snippets/complete-your-tasks/vb/Program.vb" id="ResetFix":::

**Don't do this:** If you replace a `TaskCompletionSource` instance before completing the previous one, waiters that hold the old task might never complete.

:::code language="csharp" source="./snippets/complete-your-tasks/csharp/Program.cs" id="ResetBug":::
:::code language="vb" source="./snippets/complete-your-tasks/vb/Program.vb" id="ResetBug":::

## Checklist

- Complete every exposed `TaskCompletionSource` task on success, failure, and cancellation paths.
- Use `TrySet*` APIs in paths that might race.
- During reset, complete or cancel the old task before you drop its reference.
- Add timeout-based tests so hangs fail fast in CI.

## See also

- [Task exception handling](task-exception-handling.md)
- [Implement the TAP](implementing-the-task-based-asynchronous-pattern.md)
- [Common async/await bugs](common-async-bugs.md)
