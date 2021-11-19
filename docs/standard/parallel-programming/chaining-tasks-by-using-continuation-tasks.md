---
title: "Chaining tasks using continuation tasks"
description: Learn to chain task by using continuation tasks in .NET. A continuation task is an asynchronous task that's invoked by another task.
ms.date: 01/06/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "tasks, continuations"
ms.assetid: 0b45e9a2-de28-46ce-8212-1817280ed42d
---

# Chaining tasks using continuation tasks

In asynchronous programming, it's common for one asynchronous operation, on completion, to invoke a second operation. Continuations allow descendant operations to consume the results of the first operation. Traditionally, continuations have been done by using callback methods. In the Task Parallel Library, the same functionality is provided by _continuation tasks_. A continuation task (also known just as a continuation) is an asynchronous task that's invoked by another task, known as the _antecedent_, when the antecedent finishes.

Continuations are relatively easy to use, but are nevertheless powerful and flexible. For example, you can:

- Pass data from the antecedent to the continuation.
- Specify the precise conditions under which the continuation will be invoked or not invoked.
- Cancel a continuation either before it starts or cooperatively as it is running.
- Provide hints about how the continuation should be scheduled.
- Invoke multiple continuations from the same antecedent.
- Invoke one continuation when all or any one of multiple antecedents complete.
- Chain continuations one after another to any arbitrary length.
- Use a continuation to handle exceptions thrown by the antecedent.

## About continuations

A continuation is a task that is created in the <xref:System.Threading.Tasks.TaskStatus.WaitingForActivation> state. It is activated automatically when its antecedent task or tasks complete. Calling <xref:System.Threading.Tasks.Task.Start%2A?displayProperty=nameWithType> on a continuation in user code throws an <xref:System.InvalidOperationException?displayProperty=nameWithType> exception.

A continuation is itself a <xref:System.Threading.Tasks.Task> and does not block the thread on which it is started. Call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method to block until the continuation task finishes.

## Create a continuation for a single antecedent

You create a continuation that executes when its antecedent has completed by calling the <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> method. The following example shows the basic pattern (for clarity, exception handling is omitted). It executes an antecedent task, `taskA`, that returns a <xref:System.DayOfWeek> object that indicates the name of the current day of the week. When the antecedent completes, the continuation task, `continuation`, is passed the antecedent and displays a string that includes its result.

> [!NOTE]
> The C# samples in this article make use of the `async` modifier on the `Main` method. That feature is available in C# 7.1 and later. Previous versions generate [`CS5001`](../../csharp/misc/cs5001.md) when compiling this sample code. You'll need to set the language version to C# 7.1 or newer. You can learn how to configure the language version in the article on [configure language version](../../csharp/language-reference/configure-language-version.md).

:::code language="csharp" source="snippets/cs/simple1.cs":::

[!code-vb[TPL_Continuations#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/simple1.vb#1)]

## Create a continuation for multiple antecedents

You can also create a continuation that will run when any or all of a group of tasks has completed. To execute a continuation when all antecedent tasks have completed, you call the static (`Shared` in Visual Basic) <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> method or the instance <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A?displayProperty=nameWithType> method. To execute a continuation when any of the antecedent tasks has completed, you call the static (`Shared` in Visual Basic) <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType> method or the instance <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAny%2A?displayProperty=nameWithType> method.

Calls to the <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType> overloads do not block the calling thread. However, you typically call all but the <xref:System.Threading.Tasks.Task.WhenAll%28System.Collections.Generic.IEnumerable%7BSystem.Threading.Tasks.Task%7D%29?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WhenAll%28System.Threading.Tasks.Task%5B%5D%29?displayProperty=nameWithType> methods to retrieve the returned <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property, which does block the calling thread.

The following example calls the <xref:System.Threading.Tasks.Task.WhenAll%28System.Collections.Generic.IEnumerable%7BSystem.Threading.Tasks.Task%7D%29?displayProperty=nameWithType> method to create a continuation task that reflects the results of its 10 antecedent tasks. Each antecedent task squares an index value that ranges from one to 10. If the antecedents complete successfully (their <xref:System.Threading.Tasks.Task.Status%2A?displayProperty=nameWithType> property is <xref:System.Threading.Tasks.TaskStatus.RanToCompletion?displayProperty=nameWithType>), the <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property of the continuation is an array of the <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> values returned by each antecedent. The example adds them to compute the sum of squares for all numbers between one and 10.

:::code language="csharp" source="snippets/cs/whenall1.cs":::

[!code-vb[TPL_Continuations#5](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/whenall1.vb#5)]

## Continuation options

When you create a single-task continuation, you can use a <xref:System.Threading.Tasks.Task.ContinueWith%2A> overload that takes a <xref:System.Threading.Tasks.TaskContinuationOptions?displayProperty=nameWithType> enumeration value to specify the conditions under which the continuation starts. For example, you can specify that the continuation is to run only if the antecedent completes successfully, or only if it completes in a faulted state. If the condition is not true when the antecedent is ready to invoke the continuation, the continuation transitions directly to the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state and subsequently cannot be started.

A number of multi-task continuation methods, such as overloads of the <xref:System.Threading.Tasks.TaskFactory.ContinueWhenAll%2A?displayProperty=nameWithType> method, also include a <xref:System.Threading.Tasks.TaskContinuationOptions?displayProperty=nameWithType> parameter. Only a subset of all <xref:System.Threading.Tasks.TaskContinuationOptions?displayProperty=nameWithType> enumeration members are valid, however. You can specify <xref:System.Threading.Tasks.TaskContinuationOptions?displayProperty=nameWithType> values that have counterparts in the <xref:System.Threading.Tasks.TaskCreationOptions?displayProperty=nameWithType> enumeration, such as <xref:System.Threading.Tasks.TaskContinuationOptions.AttachedToParent?displayProperty=nameWithType>, <xref:System.Threading.Tasks.TaskContinuationOptions.LongRunning?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.TaskContinuationOptions.PreferFairness?displayProperty=nameWithType>. If you specify any of the `NotOn` or `OnlyOn` options with a multi-task continuation, an <xref:System.ArgumentOutOfRangeException> exception will be thrown at run time.

For more information on task continuation options, see the <xref:System.Threading.Tasks.TaskContinuationOptions> topic.

## Pass data to a continuation

The <xref:System.Threading.Tasks.Task.ContinueWith%2A?displayProperty=nameWithType> method passes a reference to the antecedent to the user delegate of the continuation as an argument. If the antecedent is a <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> object, and the task ran until it was completed, then the continuation can access the <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property of the task.

The <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property blocks until the task has completed. However, if the task was canceled or faulted, attempting to access the <xref:System.Threading.Tasks.Task%601.Result%2A> property throws an <xref:System.AggregateException> exception. You can avoid this problem by using the <xref:System.Threading.Tasks.TaskContinuationOptions.OnlyOnRanToCompletion> option, as shown in the following example.

:::code language="csharp" source="snippets/cs/result1.cs":::

[!code-vb[TPL_Continuations#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/result1.vb#2)]

If you want the continuation to run even if the antecedent did not run to successful completion, you must guard against the exception. One approach is to test the <xref:System.Threading.Tasks.Task.Status%2A?displayProperty=nameWithType> property of the antecedent, and only attempt to access the <xref:System.Threading.Tasks.Task%601.Result%2A> property if the status is not <xref:System.Threading.Tasks.TaskStatus.Faulted> or <xref:System.Threading.Tasks.TaskStatus.Canceled>. You can also examine the <xref:System.Threading.Tasks.Task.Exception%2A> property of the antecedent. For more information, see [Exception Handling](exception-handling-task-parallel-library.md). The following example modifies the previous example to access antecedent's <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property only if its status is <xref:System.Threading.Tasks.TaskStatus.RanToCompletion?displayProperty=nameWithType>.

:::code language="csharp" source="snippets/cs/result2.cs":::

[!code-vb[TPL_Continuations#7](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/result2.vb#7)]

## Cancel a continuation

The <xref:System.Threading.Tasks.Task.Status%2A?displayProperty=nameWithType> property of a continuation is set to <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> in the following situations:

- It throws an <xref:System.OperationCanceledException> exception in response to a cancellation request. As with any task, if the exception contains the same token that was passed to the continuation, it is treated as an acknowledgment of cooperative cancellation.
- The continuation is passed a <xref:System.Threading.CancellationToken?displayProperty=nameWithType> whose <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property is `true`. In this case, the continuation does not start, and it transitions to the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state.
- The continuation never runs because the condition set by its <xref:System.Threading.Tasks.TaskContinuationOptions> argument was not met. For example, if an antecedent goes into a <xref:System.Threading.Tasks.TaskStatus.Faulted?displayProperty=nameWithType> state, its continuation that was passed the <xref:System.Threading.Tasks.TaskContinuationOptions.NotOnFaulted?displayProperty=nameWithType> option will not run but will transition to the <xref:System.Threading.Tasks.TaskStatus.Canceled> state.

If a task and its continuation represent two parts of the same logical operation, you can pass the same cancellation token to both tasks, as shown in the following example. It consists of an antecedent that generates a list of integers that are divisible by 33, which it passes to the continuation. The continuation in turn displays the list. Both the antecedent and the continuation pause regularly for random intervals. In addition, a <xref:System.Threading.Timer?displayProperty=nameWithType> object is used to execute the `Elapsed` method after a five-second timeout interval. This example calls the <xref:System.Threading.CancellationTokenSource.Cancel%2A?displayProperty=nameWithType> method, which causes the currently executing task to call the <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A?displayProperty=nameWithType> method. Whether the <xref:System.Threading.CancellationTokenSource.Cancel%2A?displayProperty=nameWithType> method is called when the antecedent or its continuation is executing depends on the duration of the randomly generated pauses. If the antecedent is canceled, the continuation will not start. If the antecedent is not canceled, the token can still be used to cancel the continuation.

:::code language="csharp" source="snippets/cs/cancellation1.cs":::

[!code-vb[TPL_Continuations#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/cancellation1.vb#3)]

You can also prevent a continuation from executing if its antecedent is canceled without supplying the continuation a cancellation token by specifying the <xref:System.Threading.Tasks.TaskContinuationOptions.NotOnCanceled?displayProperty=nameWithType> option when you create the continuation. The following is a simple example.

:::code language="csharp" source="snippets/cs/cancellation2.cs":::

[!code-vb[TPL_Continuations#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/cancellation2.vb#8)]

After a continuation goes into the <xref:System.Threading.Tasks.TaskStatus.Canceled> state, it may affect continuations that follow, depending on the <xref:System.Threading.Tasks.TaskContinuationOptions> that were specified for those continuations.

Continuations that are disposed will not start.

## Continuations and child tasks

A continuation does not run until the antecedent and all of its attached child tasks have completed. The continuation does not wait for detached child tasks to finish. The following two examples illustrate child tasks that are attached to and detached from an antecedent that creates a continuation. In the following example, the continuation runs only after all child tasks have completed, and running the example multiple times produces identical output each time. The example launches the antecedent by calling the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method, since by default the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method creates a parent task whose default task creation option is <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType>.

:::code language="csharp" source="snippets/cs/attached1.cs":::

[!code-vb[TPL_Continuations#9](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/attached1.vb#9)]

If child tasks are detached from the antecedent, however, the continuation runs as soon as the antecedent has terminated, regardless of the state of the child tasks. As a result, multiple runs of the following example can produce variable output that depends on how the task scheduler handled each child task.

:::code language="csharp" source="snippets/cs/detached1.cs":::

[!code-vb[TPL_Continuations#10](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/detached1.vb#10)]

The final status of the antecedent task depends on the final status of any attached child tasks. The status of detached child tasks does not affect the parent. For more information, see [Attached and Detached Child Tasks](attached-and-detached-child-tasks.md).

## Associate state with continuations

You can associate arbitrary state with a task continuation. The <xref:System.Threading.Tasks.Task.ContinueWith%2A> method provides overloaded versions that each take an <xref:System.Object> value that represents the state of the continuation. You can later access this state object by using the <xref:System.Threading.Tasks.Task.AsyncState%2A?displayProperty=nameWithType> property. This state object is `null` if you do not provide a value.

Continuation state is useful when you convert existing code that uses the [Asynchronous Programming Model (APM)](../asynchronous-programming-patterns/asynchronous-programming-model-apm.md) to use the TPL. In the APM, you typically provide object state in the **Begin**_Method_ method and later access that state by using the <xref:System.IAsyncResult.AsyncState%2A?displayProperty=nameWithType> property. By using the <xref:System.Threading.Tasks.Task.ContinueWith%2A> method, you can preserve this state when you convert code that uses the APM to use the TPL.

Continuation state can also be useful when you work with <xref:System.Threading.Tasks.Task> objects in the Visual Studio debugger. For example, in the **Parallel Tasks** window, the **Task** column displays the string representation of the state object for each task. For more information about the **Parallel Tasks** window, see [Using the Tasks Window](/visualstudio/debugger/using-the-tasks-window).

The following example shows how to use continuation state. It creates a chain of continuation tasks. Each task provides the current time, a <xref:System.DateTime> object, for the `state` parameter of the <xref:System.Threading.Tasks.Task.ContinueWith%2A> method. Each <xref:System.DateTime> object represents the time at which the continuation task is created. Each task produces as its result a second <xref:System.DateTime> object that represents the time at which the task finishes. After all tasks finish, this example displays the creation time and the time at which each continuation task finishes.

:::code language="csharp" source="snippets/cs/continuationstate.cs":::

[!code-vb[TPL_ContinuationState#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuationstate/vb/continuationstate.vb#1)]

## Continuations that return Task types

Sometimes you may need to chain a continuation that returns a <xref:System.Threading.Tasks.Task> type. These are referred to as nested tasks, and they are common. When a parent task calls <xref:System.Threading.Tasks.Task%601.ContinueWith%2A?displayProperty=nameWithType>, and provides a `continuationFunction` that is task returning you call <xref:System.Threading.Tasks.TaskExtensions.Unwrap%2A> to create a proxy task that represents the asynchronous operation of the `<Task<Task<T>>>` or `Task(Of Task(Of T))` (Visual Basic).

The following example shows how to use continuations that wrap additional task returning functions. Each continuation can be unwrapped, exposing the inner task that was wrapped.

:::code language="csharp" source="snippets/cs/unwrap.cs":::
:::code language="vb" source="snippets/vb/unwrap.vb":::

For more information on using <xref:System.Threading.Tasks.TaskExtensions.Unwrap%2A>, see [How to: Unwrap a nested Task](how-to-unwrap-a-nested-task.md).

## Handle exceptions thrown from continuations

An antecedent-continuation relationship is not a parent-child relationship. Exceptions thrown by continuations are not propagated to the antecedent. Therefore, handle exceptions thrown by continuations as you would handle them in any other task, as follows:

- You can use the <xref:System.Threading.Tasks.Task.Wait%2A>, <xref:System.Threading.Tasks.Task.WaitAll%2A>, or <xref:System.Threading.Tasks.Task.WaitAny%2A> method, or its generic counterpart, to wait on the continuation. You can wait for an antecedent and its continuations in the same `try` statement, as shown in the following example.

:::code language="csharp" source="snippets/cs/exception1.cs":::

[!code-vb[TPL_Continuations#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/exception1.vb#6)]

- You can use a second continuation to observe the <xref:System.Threading.Tasks.Task.Exception%2A> property of the first continuation. In the following example, a task attempts to read from a non-existent file. The continuation then displays information about the exception in the antecedent task.

:::code language="csharp" source="snippets/cs/exception2.cs" id="example":::

[!code-vb[TPL_Continuations#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/exception2.vb#4)]

Because it was run with the <xref:System.Threading.Tasks.TaskContinuationOptions.OnlyOnFaulted?displayProperty=nameWithType> option, the continuation executes only if an exception occurs in the antecedent, and therefore it can assume that the antecedent's <xref:System.Threading.Tasks.Task.Exception%2A> property is not `null`. If the continuation executes whether or not an exception is thrown in the antecedent, it would have to check whether the antecedent's <xref:System.Threading.Tasks.Task.Exception%2A> property is not `null` before attempting to handle the exception, as the following code fragment shows.

:::code language="csharp" source="snippets/cs/exception2.cs" id="exception":::

[!code-vb[TPL_Continuations#11](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_continuations/vb/exception2.vb#11)]

For more information, see [Exception Handling](exception-handling-task-parallel-library.md).

- If the continuation is an attached child task that was created by using the <xref:System.Threading.Tasks.TaskContinuationOptions.AttachedToParent?displayProperty=nameWithType> option, its exceptions will be propagated by the parent back to the calling thread, as is the case in any other attached child. For more information, see [Attached and Detached Child Tasks](attached-and-detached-child-tasks.md).

## See also

- [Task Parallel Library (TPL)](task-parallel-library-tpl.md)
