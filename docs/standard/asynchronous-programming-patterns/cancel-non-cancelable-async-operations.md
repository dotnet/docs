---
title: "Cancel non-cancelable async operations"
description: Learn practical patterns for cancellation when an async operation doesn't accept a cancellation token, including canceling the wait, canceling the operation, or both.
ms.date: 04/13/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "cancellation, async"
  - "Task.WhenAny"
  - "WithCancellation"
  - "CancellationToken"
  - "NetworkStream, cancellation"
---
# Cancel non-cancelable async operations

Sometimes you need cancellation, but the operation you're waiting on doesn't accept a <xref:System.Threading.CancellationToken>. In that case, choose the behavior you need:

- Cancel the operation itself.
- Cancel only your wait.
- Cancel both the operation and your wait.

The right choice depends on who owns the operation and what cleanup guarantees you need.

## Understand the three cancellation meanings

When people say, "cancel this async call," they usually mean one of three different things:

- **Cancel the operation.** Signal the operation to stop work.
- **Cancel the wait.** Stop awaiting and continue your workflow, even if the operation still runs.
- **Cancel both.** Request operation cancellation and also stop waiting promptly.

Treat these meanings as separate design decisions. If you mix them, cancellation behavior becomes hard to reason about.

## Prefer token-aware APIs when available

Before you add a wrapper, check whether the API already supports cancellation tokens. Modern .NET APIs have much broader token support than older .NET Framework code. For example, many stream APIs in .NET now support cancellation, and `NetworkStream` async operations honor cancellation tokens.

Use token overloads whenever they exist:

:::code language="csharp" source="./snippets/cancel-non-cancelable-async-operations/csharp/Program.cs" id="PreferTokenAwareApis":::
:::code language="vb" source="./snippets/cancel-non-cancelable-async-operations/vb/Program.vb" id="PreferTokenAwareApis":::

## Cancel only the wait by using `Task.WhenAny`

When an operation doesn't accept a token, cancel your wait by racing the operation against a token-backed task. This pattern often appears as a `WithCancellation` helper:

:::code language="csharp" source="./snippets/cancel-non-cancelable-async-operations/csharp/Program.cs" id="WithCancellation":::
:::code language="vb" source="./snippets/cancel-non-cancelable-async-operations/vb/Program.vb" id="WithCancellation":::

This pattern uses <xref:System.Threading.Tasks.Task.WhenAny*> to return as soon as either task completes.

Use this approach only when it's safe for the original operation to continue in the background.

## Cancel both operation and wait when you own the operation

If you own the operation and it accepts a token, pass the token and still use a cancelable wait when needed:

:::code language="csharp" source="./snippets/cancel-non-cancelable-async-operations/csharp/Program.cs" id="CancelBoth":::
:::code language="vb" source="./snippets/cancel-non-cancelable-async-operations/vb/Program.vb" id="CancelBoth":::

This combination gives responsive cancellation for callers and cooperative shutdown for the underlying work.

## Handle abandoned operations safely

If you cancel only the wait, the original task might later fault. Keep a reference so you can observe completion and log exceptions. Otherwise, you can miss failures and make troubleshooting harder.

:::code language="csharp" source="./snippets/cancel-non-cancelable-async-operations/csharp/Program.cs" id="ObserveLateFault":::
:::code language="vb" source="./snippets/cancel-non-cancelable-async-operations/vb/Program.vb" id="ObserveLateFault":::

## See also

- [Consume the task-based asynchronous pattern](consuming-the-task-based-asynchronous-pattern.md)
- [Task cancellation](../parallel-programming/task-cancellation.md)
- [Cancellation in managed threads](../threading/cancellation-in-managed-threads.md)
- <xref:System.Threading.CancellationToken>
- <xref:System.Threading.Tasks.Task.WhenAny*>
