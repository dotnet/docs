---
title: "Exception Handling (Task Parallel Library)"
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
  - "tasks, exceptions"
ms.assetid: beb51e50-9061-4d3d-908c-56a4f7c2e8c1
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Exception Handling (Task Parallel Library)
Unhandled exceptions that are thrown by user code that is running inside a task are propagated back to the calling thread, except in certain scenarios that are described later in this topic. Exceptions are propagated when you use one of the static or instance <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> or <!--zz <xref:System.Threading.Tasks.Task%601.Wait%2A?displayProperty=nameWithType>  --> `Wait` methods, and you handle them by enclosing the call in a `try`/`catch` statement. If a task is the parent of attached child tasks, or if you are waiting on multiple tasks, multiple exceptions could be thrown.  
  
 To propagate all the exceptions back to the calling thread, the Task infrastructure wraps them in an <xref:System.AggregateException> instance. The <xref:System.AggregateException> exception has an <xref:System.AggregateException.InnerExceptions%2A> property that can be enumerated to examine all the original exceptions that were thrown, and handle (or not handle) each one individually. You can also handle the original exceptions by using the <xref:System.AggregateException.Handle%2A?displayProperty=nameWithType> method.  
  
 Even if only one exception is thrown, it is still wrapped in an <xref:System.AggregateException> exception, as the following example shows.  
  
 [!code-csharp[TPL_Exceptions#21](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/handling21.cs#21)]
 [!code-vb[TPL_Exceptions#21](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/handling21.vb#21)]  
  
 You could avoid an unhandled exception by just catching the <xref:System.AggregateException> and not observing any of the inner exceptions. However, we recommend that you do not do this because it is analogous to catching the base <xref:System.Exception> type in non-parallel scenarios. To catch an exception without taking specific actions to recover from it can leave your program in an indeterminate state.  
  
 If you do not want to call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> or <!--zz <xref:System.Threading.Tasks.Task%601.Wait%2A?displayProperty=nameWithType>  --> `Wait` method to wait for a task's completion, you can also retrieve the <xref:System.AggregateException> exception from the task's <xref:System.Threading.Tasks.Task.Exception%2A> property, as the following example shows. For more information, see the [Observing Exceptions By Using the Task.Exception Property](#ExceptionProp) section in this topic.  
  
 [!code-csharp[TPL_Exceptions#29](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/handling22.cs#29)]
 [!code-vb[TPL_Exceptions#29](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/handling22.vb#29)]  
  
 If you do not wait on a task that propagates an exception, or access its <xref:System.Threading.Tasks.Task.Exception%2A> property, the exception is escalated according to the .NET exception policy when the task is garbage-collected.  
  
 When exceptions are allowed to bubble up back to the joining thread, it is possible that a task may continue to process some items after the exception is raised.  
  
> [!NOTE]
>  When "Just My Code" is enabled, Visual Studio in some cases will break on the line that throws the exception and display an error message that says "exception not handled by user code." This error is benign. You can press F5 to continue and see the exception-handling behavior that is demonstrated in these examples. To prevent Visual Studio from breaking on the first error, just uncheck the **Enable Just My Code** checkbox under **Tools, Options, Debugging, General**.  
  
## Attached Child Tasks and Nested AggregateExceptions  
 If a task has an attached child task that throws an exception, that exception is wrapped in an <xref:System.AggregateException> before it is propagated to the parent task, which wraps that exception in its own <xref:System.AggregateException> before it propagates it back to the calling thread. In such cases, the <xref:System.AggregateException.InnerExceptions%2A> property of the <xref:System.AggregateException> exception that is caught at the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> or <!--zz <xref:System.Threading.Tasks.Task%601.Wait%2A?displayProperty=nameWithType>  --> `Wait` or <xref:System.Threading.Tasks.Task.WaitAny%2A> or <xref:System.Threading.Tasks.Task.WaitAll%2A> method contains one or more <xref:System.AggregateException> instances, not the original exceptions that caused the fault. To avoid having to iterate over nested <xref:System.AggregateException> exceptions, you can use the <xref:System.AggregateException.Flatten%2A> method to remove all the nested <xref:System.AggregateException> exceptions, so that the <xref:System.AggregateException.InnerExceptions%2A?displayProperty=nameWithType> property contains the original exceptions. In the following example, nested <xref:System.AggregateException> instances are flattened and handled in just one loop.  
  
 [!code-csharp[TPL_Exceptions#22](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/flatten2.cs#22)]
 [!code-vb[TPL_Exceptions#22](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/flatten2.vb#22)]  
  
 You can also use the <xref:System.AggregateException.Flatten%2A?displayProperty=nameWithType> method to rethrow the inner exceptions from multiple <xref:System.AggregateException> instances thrown by multiple tasks in a single <xref:System.AggregateException> instance, as the following example shows.  
  
 [!code-csharp[TPL_Exceptions#13](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/taskexceptions2.cs#13)]
 [!code-vb[TPL_Exceptions#13](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/taskexceptions2.vb#13)]  
  
## Exceptions from Detached Child Tasks  
 By default, child tasks are created as detached. Exceptions thrown from detached tasks must be handled or rethrown in the immediate parent task; they are not propagated back to the calling thread in the same way as attached child tasks propagated back. The topmost parent can manually rethrow an exception from a detached child to cause it to be wrapped in an <xref:System.AggregateException> and propagated back to the calling thread.  
  
 [!code-csharp[TPL_Exceptions#23](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/detached21.cs#23)]
 [!code-vb[TPL_Exceptions#23](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/detached21.vb#23)]  
  
 Even if you use a continuation to observe an exception in a child task, the exception still must be observed by the parent task.  
  
## Exceptions That Indicate Cooperative Cancellation  
 When user code in a task responds to a cancellation request, the correct procedure is to throw an <xref:System.OperationCanceledException> passing in the cancellation token on which the request was communicated. Before it attempts to propagate the exception, the task instance compares the token in the exception to the one that was passed to it when it was created. If they are the same, the task propagates a <xref:System.Threading.Tasks.TaskCanceledException> wrapped in the <xref:System.AggregateException>, and it can be seen when the inner exceptions are examined. However, if the calling thread is not waiting on the task, this specific exception will not be propagated. For more information, see [Task Cancellation](../../../docs/standard/parallel-programming/task-cancellation.md).  
  
 [!code-csharp[TPL_Exceptions#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/exceptions.cs#4)]
 [!code-vb[TPL_Exceptions#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/tpl_exceptions.vb#4)]  
  
## Using the Handle Method to Filter Inner Exceptions  
 You can use the <xref:System.AggregateException.Handle%2A?displayProperty=nameWithType> method to filter out exceptions that you can treat as "handled" without using any further logic. In the user delegate that is supplied to the <xref:System.AggregateException.Handle%28System.Func%7BSystem.Exception%2CSystem.Boolean%7D%29?displayProperty=nameWithType> method, you can examine the exception type, its <xref:System.Exception.Message%2A> property, or any other information about it that will let you determine whether it is benign. Any exceptions for which the delegate returns `false` are rethrown in a new <xref:System.AggregateException> instance immediately after the <xref:System.AggregateException.Handle%2A?displayProperty=nameWithType> method returns.  
  
 The following example is functionally equivalent to the first example in this topic, which examines each exception in the <xref:System.AggregateException.InnerExceptions%2A?displayProperty=nameWithType> collection.  Instead, this exception handler calls the <xref:System.AggregateException.Handle%2A?displayProperty=nameWithType> method object for each exception, and only rethrows exceptions that are not `CustomException` instances.  
  
 [!code-csharp[TPL_Exceptions#26](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/handlemethod21.cs#26)]
 [!code-vb[TPL_Exceptions#26](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/handlemethod21.vb#26)]  
  
 The following is a more complete example that uses the <xref:System.AggregateException.Handle%2A?displayProperty=nameWithType> method to provide special handling for an <xref:System.UnauthorizedAccessException> exception when enumerating files.  
  
 [!code-csharp[TPL_Exceptions#12](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/taskexceptions.cs#12)]
 [!code-vb[TPL_Exceptions#12](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/taskexceptions.vb#12)]  
  
<a name="ExceptionProp"></a>   
## Observing Exceptions by Using the Task.Exception Property  
 If a task completes in the <xref:System.Threading.Tasks.TaskStatus.Faulted?displayProperty=nameWithType> state, its <xref:System.Threading.Tasks.Task.Exception%2A> property can be examined to discover which specific exception caused the fault. A good way to observe the <xref:System.Threading.Tasks.Task.Exception%2A> property is to use a continuation that runs only if the antecedent task faults, as shown in the following example.  
  
 [!code-csharp[TPL_Exceptions#27](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_exceptions/cs/exceptionprop21.cs#27)]
 [!code-vb[TPL_Exceptions#27](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_exceptions/vb/exceptionprop21.vb#27)]  
  
 In a real application, the continuation delegate could log detailed information about the exception and possibly spawn new tasks to recover from the exception.  
  
## UnobservedTaskException Event  
 In some scenarios, such as when hosting untrusted plug-ins, benign exceptions might be common, and it might be too difficult to manually observe them all. In these cases, you can handle the <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=nameWithType> event. The <xref:System.Threading.Tasks.UnobservedTaskExceptionEventArgs?displayProperty=nameWithType> instance that is passed to your handler can be used to prevent the unobserved exception from being propagated back to the joining thread.  
  
## See Also  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)
