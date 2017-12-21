---
title: "Implementing the Task-based Asynchronous Pattern"
ms.date: "06/14/2017"
ms.prod: ".net"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - ".NET Framework, and TAP"
  - "asynchronous design patterns, .NET Framework"
  - "TAP, .NET Framework support for"
  - "Task-based Asynchronous Pattern, .NET Framework support for"
  - ".NET Framework, asynchronous design patterns"
ms.assetid: fab6bd41-91bd-44ad-86f9-d8319988aa78
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Implementing the Task-based Asynchronous Pattern
You can implement the Task-based Asynchronous Pattern (TAP) in three ways: by using the C# and Visual Basic compilers in Visual Studio, manually, or through a combination of the compiler and manual methods. The following sections discuss each method in detail. You can use the TAP pattern to implement both compute-bound and I/O-bound asynchronous operations. The [Workloads](#workloads) section discusses each type of operation.

## Generating TAP methods

### Using the compilers
Starting with [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], any method that is attributed with the `async` keyword (`Async` in Visual Basic) is considered an asynchronous method, and the C# and Visual Basic compilers perform the necessary transformations to implement the method asynchronously by using TAP. An asynchronous method should return either a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> or a <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> object. For the latter, the body of the function should return a `TResult`, and the compiler ensures that this result is made available through the resulting task object. Similarly, any exceptions that go unhandled within the body of the method are marshaled to the output task and cause the resulting task to end in the <xref:System.Threading.Tasks.TaskStatus.Faulted?displayProperty=nameWithType> state. The exception is when an <xref:System.OperationCanceledException> (or derived type) goes unhandled, in which case the resulting task ends in the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state.

### Generating TAP methods manually
You may implement the TAP pattern manually for better control over implementation. The compiler relies on the public surface area exposed from the <xref:System.Threading.Tasks?displayProperty=nameWithType> namespace and supporting types in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace. To implement the TAP yourself, you create a <xref:System.Threading.Tasks.TaskCompletionSource%601> object, perform the asynchronous operation, and when it completes, call the <xref:System.Threading.Tasks.TaskCompletionSource%601.SetResult%2A>, <xref:System.Threading.Tasks.TaskCompletionSource%601.SetException%2A>, or <xref:System.Threading.Tasks.TaskCompletionSource%601.SetCanceled%2A> method, or the `Try` version of one of these methods. When you implement a TAP method manually, you must complete the resulting task when the represented asynchronous operation completes. For example:

[!code-csharp[Conceptual.TAP_Patterns#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#1)]
[!code-vb[Conceptual.TAP_Patterns#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#1)]

### Hybrid approach
 You may find it useful to implement the TAP pattern manually but to delegate the core logic for the implementation to the compiler. For example, you may want to use the hybrid approach when you want to verify arguments outside a compiler-generated asynchronous method so that exceptions can escape to the method’s direct caller rather than being exposed through the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> object:

 [!code-csharp[Conceptual.TAP_Patterns#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#2)]
 [!code-vb[Conceptual.TAP_Patterns#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#2)]

 Another case where such delegation is useful is when you're implementing fast-path optimization and want to return a cached task.

## Workloads
You may implement both compute-bound and I/O-bound asynchronous operations as TAP methods. However, when TAP methods are exposed publicly from a library, they should be provided only for workloads that involve I/O-bound operations (they may also involve computation, but should not be purely computational). If a method is purely compute-bound, it should be exposed only as a synchronous implementation. The code that consumes it may then choose whether to wrap an invocation of that synchronous method into a task to offload the work to another thread or to achieve parallelism. And if a method is IO-bound, it should be exposed only as an asynchronous implementation.

### Compute-bound tasks
The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class is ideally suited for representing computationally intensive operations. By default, it takes advantage of special support within the <xref:System.Threading.ThreadPool> class to provide efficient execution, and it also provides significant control over when, where, and how asynchronous computations execute.

You can generate compute-bound tasks in the following ways:

- In the .NET Framework 4, use the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method, which accepts a delegate (typically an <xref:System.Action%601> or a <xref:System.Func%601>) to be executed asynchronously. If you provide an <xref:System.Action%601> delegate, the method returns a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> object that represents the asynchronous execution of that delegate. If you provide a <xref:System.Func%601> delegate, the method returns a <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> object. Overloads of the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A> method accept a cancellation token (<xref:System.Threading.CancellationToken>), task creation options (<xref:System.Threading.Tasks.TaskCreationOptions>), and a task scheduler (<xref:System.Threading.Tasks.TaskScheduler>), all of which provide fine-grained control over the scheduling and execution of the task. A factory instance that targets the current task scheduler is available as a static property (<xref:System.Threading.Tasks.Task.Factory%2A>) of the <xref:System.Threading.Tasks.Task> class; for example: `Task.Factory.StartNew(…)`.

- In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] and later versions (including .NET Core and .NET Standard), use the static <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method as a shortcut to <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType>. You may use <xref:System.Threading.Tasks.Task.Run%2A> to easily launch a compute-bound task that targets the thread pool. In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] and later versions, this is the preferred mechanism for launching a compute-bound task. Use `StartNew` directly only when you want more fine-grained control over the task.

- Use the constructors of the `Task` type or the `Start` method if you want to generate and schedule the task separately. Public methods must only return tasks that have already been started.

- Use the overloads of the <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> method. This method creates a new task that is scheduled when another task completes. Some of the <xref:System.Threading.Tasks.Task.ContinueWith%2A> overloads accept a cancellation token, continuation options, and a task scheduler for better control over the scheduling and execution of the continuation task.

- Use the <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A?displayProperty=nameWithType> methods. These methods create a new task that is scheduled when all or any of a supplied set of tasks completes. These methods also provide overloads to control the scheduling and execution of these tasks.

In compute-bound tasks, the system can prevent the execution of a scheduled task if it receives a cancellation request before it starts running the task. As such, if you provide a cancellation token (<xref:System.Threading.CancellationToken> object), you can pass that token to the asynchronous code that monitors the token. You can also provide the token to one of the previously mentioned methods such as `StartNew` or `Run` so that the `Task` runtime may also monitor the token.

For example, consider an asynchronous method that renders an image. The body of the task can poll the cancellation token so that the code may exit early if a cancellation request arrives during rendering. In addition, if the cancellation request arrives before rendering starts, you'll want to prevent the rendering operation:

[!code-csharp[Conceptual.TAP_Patterns#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#3)]
[!code-vb[Conceptual.TAP_Patterns#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#3)]

Compute-bound tasks end in a <xref:System.Threading.Tasks.TaskStatus.Canceled> state if at least one of the following conditions is true:

- A cancellation request arrives through the <xref:System.Threading.CancellationToken> object, which is provided as an argument to the creation method (for example, `StartNew` or `Run`) before the task transitions to the <xref:System.Threading.Tasks.TaskStatus.Running> state.

- An <xref:System.OperationCanceledException> exception goes unhandled within the body of such a task, that exception contains the same <xref:System.Threading.CancellationToken> that is passed to the task, and that token shows that cancellation is requested.

If another exception goes unhandled within the body of the task, the task ends in the <xref:System.Threading.Tasks.TaskStatus.Faulted> state, and any attempts to wait on the task or access its result causes an exception to be thrown.

### I/O-bound tasks
To create a task that should not be directly backed by a thread for the entirety of its execution, use the <xref:System.Threading.Tasks.TaskCompletionSource%601> type. This type exposes a <xref:System.Threading.Tasks.TaskCompletionSource%601.Task%2A> property that returns an associated <xref:System.Threading.Tasks.Task%601> instance. The life cycle of this task is controlled by <xref:System.Threading.Tasks.TaskCompletionSource%601> methods such as <xref:System.Threading.Tasks.TaskCompletionSource%601.SetResult%2A>, <xref:System.Threading.Tasks.TaskCompletionSource%601.SetException%2A>, <xref:System.Threading.Tasks.TaskCompletionSource%601.SetCanceled%2A>, and their `TrySet` variants.

Let's say that you want to create a task that will complete after a specified period of time. For example, you may want to delay an activity in the user interface. The <xref:System.Threading.Timer?displayProperty=nameWithType> class already provides the ability to asynchronously invoke a delegate after a specified period of time, and by using <xref:System.Threading.Tasks.TaskCompletionSource%601> you can put a <xref:System.Threading.Tasks.Task%601> front on the timer, for example:

[!code-csharp[Conceptual.TAP_Patterns#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#4)]
[!code-vb[Conceptual.TAP_Patterns#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#4)]

Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], the <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> method is provided for this purpose, and you can use it inside another asynchronous method, for example, to implement an asynchronous polling loop:

[!code-csharp[Conceptual.TAP_Patterns#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#5)]
[!code-vb[Conceptual.TAP_Patterns#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#5)]

The <xref:System.Threading.Tasks.TaskCompletionSource%601> class doesn't have a non-generic counterpart. However, <xref:System.Threading.Tasks.Task%601> derives from <xref:System.Threading.Tasks.Task>, so you can use the generic <xref:System.Threading.Tasks.TaskCompletionSource%601> object for I/O-bound methods that simply return a task. To do this, you can use a source with a dummy `TResult` (<xref:System.Boolean> is a good default choice, but if you're concerned about the user of the <xref:System.Threading.Tasks.Task> downcasting it to a <xref:System.Threading.Tasks.Task%601>, you can use a private `TResult` type instead). For example, the `Delay` method in the previous example returns the current time along with the resulting offset (`Task<DateTimeOffset>`). If such a result value is unnecessary, the method could instead be coded as follows (note the change of return type and the change of argument to <xref:System.Threading.Tasks.TaskCompletionSource%601.TrySetResult%2A>):

[!code-csharp[Conceptual.TAP_Patterns#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#6)]
[!code-vb[Conceptual.TAP_Patterns#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#6)]

### Mixed compute-bound and I/O-bound tasks
Asynchronous methods are not limited to just compute-bound or I/O-bound operations but may represent a mixture of the two. In fact, multiple asynchronous operations are often combined into larger mixed operations. For example, the `RenderAsync` method in a previous example performed a computationally intensive operation to render an image based on some input `imageData`. This `imageData` could come from a web service that you asynchronously access:

[!code-csharp[Conceptual.TAP_Patterns#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.tap_patterns/cs/patterns1.cs#7)]
[!code-vb[Conceptual.TAP_Patterns#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.tap_patterns/vb/patterns1.vb#7)]

This example also demonstrates how a single cancellation token may be threaded through multiple asynchronous operations. For more information, see the cancellation usage section in [Consuming the Task-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md).

## See also
 [Task-based Asynchronous Pattern (TAP)](../../../docs/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md)  
 [Consuming the Task-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md)  
 [Interop with Other Asynchronous Patterns and Types](../../../docs/standard/asynchronous-programming-patterns/interop-with-other-asynchronous-patterns-and-types.md)  
