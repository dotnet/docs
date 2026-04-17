---
title: "Implementing the Task-based Asynchronous Pattern"
description: This article explains how to implement the Task-based Asynchronous Pattern. You can use it to implement compute-bound and I/O-bound asynchronous operations.
ms.date: "04/17/2026"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "asynchronous design patterns, .NET"
  - "TAP, .NET support for"
  - "Task-based Asynchronous Pattern, .NET support for"
  - ".NET, asynchronous design patterns"
---
# Implementing the task-based asynchronous pattern

You can implement the task-based asynchronous pattern (TAP) in three ways: by using the C# and Visual Basic compilers in Visual Studio, manually, or through a combination of the compiler and manual methods. The following sections discuss each method in detail. You can use the TAP pattern to implement both compute-bound and I/O-bound asynchronous operations. The [Workloads](#workloads) section discusses each type of operation.

## Generating TAP methods

### Using the compilers

Starting with .NET Framework 4.5, any method that is attributed with the `async` keyword (`Async` in Visual Basic) is considered an asynchronous method. The C# and Visual Basic compilers perform the necessary transformations to implement the method asynchronously by using TAP. An asynchronous method should return either a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> or a <xref:System.Threading.Tasks.Task`1?displayProperty=nameWithType> object. For the latter, the body of the function should return a `TResult`, and the compiler ensures that this result is made available through the resulting task object. Similarly, any exceptions that go unhandled within the body of the method are marshalled to the output task and cause the resulting task to end in the <xref:System.Threading.Tasks.TaskStatus.Faulted?displayProperty=nameWithType> state. The exception to this rule is when an <xref:System.OperationCanceledException> (or derived type) goes unhandled, in which case the resulting task ends in the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state.

### Task.Start and task disposal

Use <xref:System.Threading.Tasks.Task.Start*> only for tasks explicitly created with a <xref:System.Threading.Tasks.Task> constructor that are still in the `Created` state. Public TAP methods should return active tasks, so callers shouldn't need to call `Start`.

In most TAP code, don't dispose tasks. A <xref:System.Threading.Tasks.Task> doesn't hold unmanaged resources in the typical case, and disposing every task adds overhead without practical benefit. Dispose only when specific APIs or measurements show a need.

If you start background work that outlives the immediate call path, keep ownership explicit and track completion. For more guidance, see [Keeping async methods alive](keeping-async-methods-alive.md).

### Generating TAP methods manually

You might implement the TAP pattern manually for better control over implementation. The compiler relies on the public surface area exposed from the <xref:System.Threading.Tasks?displayProperty=nameWithType> namespace and supporting types in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace. To implement the TAP yourself, you create a <xref:System.Threading.Tasks.TaskCompletionSource`1> object, perform the asynchronous operation, and when it completes, call the <xref:System.Threading.Tasks.TaskCompletionSource`1.SetResult*>, <xref:System.Threading.Tasks.TaskCompletionSource`1.SetException*>, or <xref:System.Threading.Tasks.TaskCompletionSource`1.SetCanceled*> method, or the `Try` version of one of these methods. When you implement a TAP method manually, you must complete the resulting task when the represented asynchronous operation completes. For example:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="ManualTapImplementation":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="ManualTapImplementation":::

### Hybrid approach

 You might find it useful to implement the TAP pattern manually but delegate the core logic for the implementation to the compiler. For example, you might want to use the hybrid approach when you want to verify arguments outside a compiler-generated asynchronous method so that exceptions can escape to the method's direct caller rather than being exposed through the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> object:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="HybridApproach":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="HybridApproach":::

 Another case where such delegation is useful is when you're implementing fast-path optimization and want to return a cached task.

## Workloads

You can implement both compute-bound and I/O-bound asynchronous operations as TAP methods. However, when you expose TAP methods publicly from a library, provide them only for workloads that involve I/O-bound operations. These operations might also involve computation, but they shouldn't be purely computational. If a method is purely compute-bound, expose it only as a synchronous implementation. The code that consumes it can then choose whether to wrap an invocation of that synchronous method into a task to offload the work to another thread or to achieve parallelism. If a method is I/O-bound, expose it only as an asynchronous implementation.

### Compute-bound tasks

The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class works well for representing computationally intensive operations. By default, it takes advantage of special support within the <xref:System.Threading.ThreadPool> class to provide efficient execution. It also provides significant control over when, where, and how asynchronous computations execute.

Generate compute-bound tasks in the following ways:

- In .NET Framework 4.5 and later versions (including .NET Core and .NET 5+), use the static <xref:System.Threading.Tasks.Task.Run*?displayProperty=nameWithType> method as a shortcut to <xref:System.Threading.Tasks.TaskFactory.StartNew*?displayProperty=nameWithType>. Use <xref:System.Threading.Tasks.Task.Run*> to easily launch a compute-bound task that targets the thread pool. This method is the preferred mechanism for launching a compute-bound task. Use `StartNew` directly only when you want more fine-grained control over the task.

- In .NET Framework 4, use the <xref:System.Threading.Tasks.TaskFactory.StartNew*?displayProperty=nameWithType> method. It accepts a delegate (typically an <xref:System.Action`1> or a <xref:System.Func`1>) to execute asynchronously. If you provide an <xref:System.Action`1> delegate, the method returns a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> object that represents the asynchronous execution of that delegate. If you provide a <xref:System.Func`1> delegate, the method returns a <xref:System.Threading.Tasks.Task`1?displayProperty=nameWithType> object. Overloads of the <xref:System.Threading.Tasks.TaskFactory.StartNew*> method accept a cancellation token (<xref:System.Threading.CancellationToken>), task creation options (<xref:System.Threading.Tasks.TaskCreationOptions>), and a task scheduler (<xref:System.Threading.Tasks.TaskScheduler>). These parameters provide fine-grained control over the scheduling and execution of the task. A factory instance that targets the current task scheduler is available as a static property (<xref:System.Threading.Tasks.Task.Factory*>) of the <xref:System.Threading.Tasks.Task> class. For example: `Task.Factory.StartNew(…)`.

- Use the constructors of the `Task` type and the `Start` method if you want to generate and schedule the task separately. Public methods must only return tasks that are already started.

- Use the overloads of the <xref:System.Threading.Tasks.Task.ContinueWith*?displayProperty=nameWithType> method. This method creates a new task that is scheduled when another task completes. Some of the <xref:System.Threading.Tasks.Task.ContinueWith*> overloads accept a cancellation token, continuation options, and a task scheduler for better control over the scheduling and execution of the continuation task.

- Use the <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll*?displayProperty=nameWithType> and <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny*?displayProperty=nameWithType> methods. These methods create a new task that is scheduled when all or any of a supplied set of tasks completes. These methods also provide overloads to control the scheduling and execution of these tasks.

In compute-bound tasks, the system can prevent the execution of a scheduled task if it receives a cancellation request before it starts running the task. As such, if you provide a cancellation token (<xref:System.Threading.CancellationToken> object), you can pass that token to the asynchronous code that monitors the token. You can also provide the token to one of the previously mentioned methods such as `StartNew` or `Run` so that the `Task` runtime can also monitor the token.

For example, consider an asynchronous method that renders an image. The body of the task can poll the cancellation token so that the code exits early if a cancellation request arrives during rendering. In addition, if the cancellation request arrives before rendering starts, you want to prevent the rendering operation:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="ComputeBoundTask":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="ComputeBoundTask":::

Compute-bound tasks end in a <xref:System.Threading.Tasks.TaskStatus.Canceled> state if at least one of the following conditions is true:

- A cancellation request arrives through the <xref:System.Threading.CancellationToken> object, which is provided as an argument to the creation method (for example, `StartNew` or `Run`) before the task transitions to the <xref:System.Threading.Tasks.TaskStatus.Running> state.

- An <xref:System.OperationCanceledException> exception goes unhandled within the body of such a task. That exception contains the same <xref:System.Threading.CancellationToken> that is passed to the task, and that token shows that cancellation is requested.

If another exception goes unhandled within the body of the task, the task ends in the <xref:System.Threading.Tasks.TaskStatus.Faulted> state. Any attempts to wait on the task or access its result causes an exception to be thrown.

### I/O-bound tasks

To create a task that shouldn't directly use a thread for the entire execution, use the <xref:System.Threading.Tasks.TaskCompletionSource`1> type. This type exposes a <xref:System.Threading.Tasks.TaskCompletionSource`1.Task> property that returns an associated <xref:System.Threading.Tasks.Task`1> instance. You control the life cycle of this task by using <xref:System.Threading.Tasks.TaskCompletionSource`1> methods such as <xref:System.Threading.Tasks.TaskCompletionSource`1.SetResult*>, <xref:System.Threading.Tasks.TaskCompletionSource`1.SetException*>, <xref:System.Threading.Tasks.TaskCompletionSource`1.SetCanceled*>, and their `TrySet` variants.

Suppose you want to create a task that completes after a specified period of time. For example, you might want to delay an activity in the user interface. The <xref:System.Threading.Timer?displayProperty=nameWithType> class already provides the ability to asynchronously invoke a delegate after a specified period of time. By using <xref:System.Threading.Tasks.TaskCompletionSource`1>, you can put a <xref:System.Threading.Tasks.Task`1> front on the timer. For example:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="DelayWithTimer":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="DelayWithTimer":::

The <xref:System.Threading.Tasks.Task.Delay*?displayProperty=nameWithType> method is provided for this purpose. You can use it inside another asynchronous method, for example, to implement an asynchronous polling loop:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="PollingLoop":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="PollingLoop":::

The <xref:System.Threading.Tasks.TaskCompletionSource`1> class doesn't have a non-generic counterpart. However, <xref:System.Threading.Tasks.Task`1> derives from <xref:System.Threading.Tasks.Task>, so you can use the generic <xref:System.Threading.Tasks.TaskCompletionSource`1> object for I/O-bound methods that simply return a task. To do this, use a source with a dummy `TResult` (<xref:System.Boolean> is a good default choice, but if you're concerned about the user of the <xref:System.Threading.Tasks.Task> downcasting it to a <xref:System.Threading.Tasks.Task`1>, you can use a private `TResult` type instead). For example, the `Delay` method in the previous example returns the current time along with the resulting offset (`Task<DateTimeOffset>`). If such a result value is unnecessary, the method could instead be coded as follows (note the change of return type and the change of argument to <xref:System.Threading.Tasks.TaskCompletionSource`1.TrySetResult*>):

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="DelayBoolResult":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="DelayBoolResult":::

### Mixed compute-bound and I/O-bound tasks

Asynchronous methods aren't limited to just compute-bound or I/O-bound operations. They can represent a mixture of the two. In fact, you often combine multiple asynchronous operations into larger mixed operations. For example, the `RenderAsync` method in a previous example performs a computationally intensive operation to render an image based on some input `imageData`. This `imageData` could come from a web service that you asynchronously access:

:::code language="csharp" source="./snippets/implementing-the-task-based-asynchronous-pattern/csharp/Program.cs" id="MixedBoundTask":::
:::code language="vb" source="./snippets/implementing-the-task-based-asynchronous-pattern/vb/Program.vb" id="MixedBoundTask":::

This example also demonstrates how a single cancellation token can be threaded through multiple asynchronous operations. For more information, see the cancellation usage section in [Consuming the Task-based Asynchronous Pattern](consuming-the-task-based-asynchronous-pattern.md).

## See also

- [Task-based Asynchronous Pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Consuming the Task-based Asynchronous Pattern](consuming-the-task-based-asynchronous-pattern.md)
- [Interop with Other Asynchronous Patterns and Types](interop-with-other-asynchronous-patterns-and-types.md)
