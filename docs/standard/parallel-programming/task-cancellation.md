---
title: "Task Cancellation"
description: Understand task cancellation, which is supported in the Task and Task<TResult> classes through the use of cancellation tokens in .NET.
ms.date: "08/10/2022"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, cancellation"
  - "asynchronous task cancellation"
ms.assetid: 3ecf1ea9-e399-4a6a-a0d6-8475f48dcb28
---
# Task cancellation

The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> classes support cancellation by using cancellation tokens. For more information, see [Cancellation in Managed Threads](../threading/cancellation-in-managed-threads.md). In the Task classes, cancellation involves cooperation between the user delegate, which represents a cancelable operation, and the code that requested the cancellation. A successful cancellation involves the requesting code calling the <xref:System.Threading.CancellationTokenSource.Cancel%2A?displayProperty=nameWithType> method and the user delegate terminating the operation in a timely manner. You can terminate the operation by using one of these options:  
  
- By returning from the delegate. In many scenarios, this option is sufficient. However, a task instance that's canceled in this way transitions to the <xref:System.Threading.Tasks.TaskStatus.RanToCompletion?displayProperty=nameWithType> state, not to the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state.  
  
- By throwing an <xref:System.OperationCanceledException> and passing it the token on which cancellation was requested. The preferred way to perform is to use the <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> method. A task that's canceled in this way transitions to the Canceled state, which the calling code can use to verify that the task responded to its cancellation request.  
  
 The following example shows the basic pattern for task cancellation that throws the exception:

>[!NOTE]
> The token is passed to the user delegate and the task instance.  
  
 [!code-csharp[TPL_Cancellation#02](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_cancellation/cs/snippet02.cs#02)]
 [!code-vb[TPL_Cancellation#02](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_cancellation/vb/module1.vb#02)]  
  
 For a complete example, see [How to: Cancel a Task and Its Children](how-to-cancel-a-task-and-its-children.md).  
  
 When a task instance observes an <xref:System.OperationCanceledException> thrown by the user code, it compares the exception's token to its associated token (the one that was passed to the API that created the Task). If the tokens are same and the token's <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property returns `true`, the task interprets this as acknowledging cancellation and transitions to the Canceled state. If you don't use a <xref:System.Threading.Tasks.Task.Wait%2A> or <xref:System.Threading.Tasks.Task.WaitAll%2A> method to wait for the task, then the task just sets its status to <xref:System.Threading.Tasks.TaskStatus.Canceled>.  
  
 If you're waiting on a Task that transitions to the Canceled state, a <xref:System.Threading.Tasks.TaskCanceledException?displayProperty=nameWithType> exception (wrapped in an <xref:System.AggregateException> exception) is thrown. This exception indicates successful cancellation instead of a faulty situation. Therefore, the task's <xref:System.Threading.Tasks.Task.Exception%2A> property returns `null`.  
  
 If the token's <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property returns `false` or if the exception's token doesn't match the Task's token, the <xref:System.OperationCanceledException> is treated like a normal exception, causing the Task to transition to the Faulted state. The presence of other exceptions will also cause the Task to transition to the Faulted state. You can get the status of the completed task in the <xref:System.Threading.Tasks.Task.Status%2A> property.  
  
 It's possible that a task might continue to process some items after cancellation is requested.  
  
## See also

- [Cancellation in Managed Threads](../threading/cancellation-in-managed-threads.md)
- [How to: Cancel a Task and Its Children](how-to-cancel-a-task-and-its-children.md)
