---
title: "Task Cancellation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, cancellation"
  - "asynchronous task cancellation"
ms.assetid: 3ecf1ea9-e399-4a6a-a0d6-8475f48dcb28
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Task Cancellation
The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> classes support cancellation through the use of cancellation tokens in the .NET Framework. For more information, see [Cancellation in Managed Threads](../../../docs/standard/threading/cancellation-in-managed-threads.md). In the Task classes, cancellation involves cooperation between the user delegate, which represents a cancelable operation and the code that requested the cancellation.  A successful cancellation involves the requesting code calling the <xref:System.Threading.CancellationTokenSource.Cancel%2A?displayProperty=nameWithType> method, and the user delegate terminating the operation in a timely manner. You can terminate the operation by using one of these options:  
  
-   By simply returning from the delegate. In many scenarios this is sufficient; however, a task instance that is canceled in this way transitions to the <xref:System.Threading.Tasks.TaskStatus.RanToCompletion?displayProperty=nameWithType> state, not to the <xref:System.Threading.Tasks.TaskStatus.Canceled?displayProperty=nameWithType> state.  
  
-   By throwing a <xref:System.OperationCanceledException> and passing it the token on which cancellation was requested. The preferred way to do this is to use the <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> method. A task that is canceled in this way transitions to the Canceled state, which the calling code can use to verify that the task responded to its cancellation request.  
  
 The following example shows the basic pattern for task cancellation that throws the exception. Note that the token is passed to the user delegate and to the task instance itself.  
  
 [!code-csharp[TPL_Cancellation#02](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_cancellation/cs/snippet02.cs#02)]
 [!code-vb[TPL_Cancellation#02](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_cancellation/vb/module1.vb#02)]  
  
 For a more complete example, see [How to: Cancel a Task and Its Children](../../../docs/standard/parallel-programming/how-to-cancel-a-task-and-its-children.md).  
  
 When a task instance observes an <xref:System.OperationCanceledException> thrown by user code, it compares the exception's token to its associated token (the one that was passed to the API that created the Task). If they are the same and the token's <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property returns true, the task interprets this as acknowledging cancellation and transitions to the Canceled state. If you do not use a <xref:System.Threading.Tasks.Task.Wait%2A> or <xref:System.Threading.Tasks.Task.WaitAll%2A> method to wait for the task, then the task just sets its status to <xref:System.Threading.Tasks.TaskStatus.Canceled>.  
  
 If you are waiting on a Task that transitions to the Canceled state, a <xref:System.Threading.Tasks.TaskCanceledException?displayProperty=nameWithType> exception (wrapped in an <xref:System.AggregateException> exception) is thrown. Note that this exception indicates successful cancellation instead of a faulty situation. Therefore, the task's <xref:System.Threading.Tasks.Task.Exception%2A> property returns `null`.  
  
 If the token's <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property returns false or if the exception's token does not match the Task's token, the <xref:System.OperationCanceledException> is treated like a normal exception, causing the Task to transition to the Faulted state. Also note that the presence of other exceptions will also cause the Task to transition to the Faulted state. You can get the status of the completed task in the <xref:System.Threading.Tasks.Task.Status%2A> property.  
  
 It is possible that a task may continue to process some items after cancellation is requested.  
  
## See Also  
 [Cancellation in Managed Threads](../../../docs/standard/threading/cancellation-in-managed-threads.md)  
 [How to: Cancel a Task and Its Children](../../../docs/standard/parallel-programming/how-to-cancel-a-task-and-its-children.md)
