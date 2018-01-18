---
title: "Attached and Detached Child Tasks"
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
  - "tasks, child tasks"
ms.assetid: c95788bf-90a6-4e96-b7bc-58e36a228cc5
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Attached and Detached Child Tasks
A *child task* (or *nested task*) is a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> instance that is created in the user delegate of another task, which is known as the *parent task*. A child task can be either detached or attached. A *detached child task* is a task that executes independently of its parent. An *attached child task* is a nested task that is created with the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option whose parent does not explicitly or by default prohibit it from being attached. A task may create any number of attached and detached child tasks, limited only by system resources.  
  
 The following table lists the basic differences between the two kinds of child tasks.  
  
|Category|Detached child tasks|Attached child tasks|  
|--------------|--------------------------|--------------------------|  
|Parent waits for child tasks to complete.|No|Yes|  
|Parent propagates exceptions thrown by child tasks.|No|Yes|  
|Status of parent depends on status of child.|No|Yes|  
  
 In most scenarios, we recommend that you use detached child tasks, because their relationships with other tasks are less complex. That is why tasks created inside parent tasks are detached by default, and you must explicitly specify the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option to create an attached child task.  
  
## Detached child tasks  
 Although a child task is created by a parent task, by default it is independent of the parent task. In the following example, a parent task creates one simple child task. If you run the example code multiple times, you may notice that the output from the example differs from that shown, and also that the output may change each time you run the code. This occurs because the parent task and child tasks execute independently of each other; the child is a detached task. The example waits only for the parent task to complete, and the child task may not execute or complete before the console app terminates.  
  
 [!code-csharp[TPL_ChildTasks#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_childtasks/cs/nested1.cs#1)]
 [!code-vb[TPL_ChildTasks#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_childtasks/vb/nested1.vb#1)]  
  
 If the child task is represented by a <xref:System.Threading.Tasks.Task%601> object rather than a <xref:System.Threading.Tasks.Task> object, you can ensure that the parent task will wait for the child to complete by accessing the <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property of the child even if it is a detached child task. The <xref:System.Threading.Tasks.Task%601.Result%2A> property blocks until its task completes, as the following example shows.  
  
 [!code-csharp[TPL_ChildTasks#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_childtasks/cs/childtasks.cs#4)]
 [!code-vb[TPL_ChildTasks#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_childtasks/vb/tpl_childtasks.vb#4)]  
  
## Attached child tasks  
 Unlike detached child tasks, attached child tasks are closely synchronized with the parent. You can change the detached child task in the previous example to an attached child task by using the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option in the task creation statement, as shown in the following example. In this code, the attached child task completes before its parent. As a result, the output from the example is the same each time you run the code.  
  
 [!code-csharp[TPL_ChildTasks#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_childtasks/cs/child1.cs#2)]
 [!code-vb[TPL_ChildTasks#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_childtasks/vb/child1.vb#2)]  
  
 You can use attached child tasks to create tightly synchronized graphs of asynchronous operations.  
  
 However, a child task can attach to its parent only if its parent does not prohibit attached child tasks. Parent tasks can explicitly prevent child tasks from attaching to them by specifying the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option in the parent task's class constructor or the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method. Parent tasks implicitly prevent child tasks from attaching to them if they are created by calling the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> method. The following example illustrates this. It is identical to the previous example, except that the parent task is created by calling the <xref:System.Threading.Tasks.Task.Run%28System.Action%29?displayProperty=nameWithType> method rather than the <xref:System.Threading.Tasks.TaskFactory.StartNew%28System.Action%29?displayProperty=nameWithType> method. Because the child task is not able to attach to its parent, the output from the example is unpredictable. Because the default task creation options for the <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> overloads include <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType>, this example is functionally equivalent to the first example in the "Detached child tasks" section.  
  
 [!code-csharp[TPL_ChildTasks#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_childtasks/cs/child1a.cs#3)]
 [!code-vb[TPL_ChildTasks#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_childtasks/vb/child1a.vb#3)]  
  
## Exceptions in child tasks  
 If a detached child task throws an exception, that exception must be observed or handled directly in the parent task just as with any non-nested task. If an attached child task throws an exception, the exception is automatically propagated to the parent task and back to the thread that waits or tries to access the task's <xref:System.Threading.Tasks.Task%601.Result%2A?displayProperty=nameWithType> property. Therefore, by using attached child tasks, you can handle all exceptions at just one point in the call to <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> on the calling thread. For more information, see [Exception Handling](../../../docs/standard/parallel-programming/exception-handling-task-parallel-library.md).  
  
## Cancellation and child tasks  
 Task cancellation is cooperative. That is, to be cancelable, every attached or detached child task must monitor the status of the cancellation token. If you want to cancel a parent and all its children by using one cancellation request, you pass the same token as an argument to all tasks and provide in each task the logic to respond to the request in each task. For more information, see [Task Cancellation](../../../docs/standard/parallel-programming/task-cancellation.md) and [How to: Cancel a Task and Its Children](../../../docs/standard/parallel-programming/how-to-cancel-a-task-and-its-children.md).  
  
### When the parent cancels  
 If a parent cancels itself before its child task is started, the child never starts. If a parent cancels itself after its child task has already started, the child runs to completion unless it has its own cancellation logic. For more information, see [Task Cancellation](../../../docs/standard/parallel-programming/task-cancellation.md).  
  
### When a detached child task cancels  
 If a detached child task cancels itself by using the same token that was passed to the parent, and the parent does not wait for the child task, no exception is propagated, because the exception is treated as benign cooperation cancellation. This behavior is the same as that of any top-level task.  
  
### When an attached child task cancels  
 When an attached child task cancels itself by using the same token that was passed to its parent task, a <xref:System.Threading.Tasks.TaskCanceledException> is propagated to the joining thread inside an <xref:System.AggregateException>. You must wait for the parent task so that you can handle all benign exceptions in addition to all faulting exceptions that are propagated up through a graph of attached child tasks.  
  
 For more information, see [Exception Handling](../../../docs/standard/parallel-programming/exception-handling-task-parallel-library.md).  
  
## Preventing a child task from attaching to its parent  
 An unhandled exception that is thrown by a child task is propagated to the parent task. You can use this behavior to observe all child task exceptions from one root task instead of traversing a tree of tasks. However, exception propagation can be problematic when a parent task does not expect attachment from other code. For example, consider an app that calls a third-party library component from a <xref:System.Threading.Tasks.Task> object. If the third-party library component also creates a <xref:System.Threading.Tasks.Task> object and specifies <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> to attach it to the parent task, any unhandled exceptions that occur in the child task propagate to the parent. This could lead to unexpected behavior in the main app.  
  
 To prevent a child task from attaching to its parent task, specify the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option when you create the parent <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> object. When a task tries to attach to its parent and the parent specifies the <xref:System.Threading.Tasks.TaskCreationOptions.DenyChildAttach?displayProperty=nameWithType> option, the child task will not be able to attach to a parent and will execute just as if the <xref:System.Threading.Tasks.TaskCreationOptions.AttachedToParent?displayProperty=nameWithType> option was not specified.  
  
 You might also want to prevent a child task from attaching to its parent when the child task does not finish in a timely manner. Because a parent task does not finish until all child tasks finish, a long-running child task can cause the overall app to perform poorly. For an example that shows how to improve app performance by preventing a task from attaching to its parent task, see [How to: Prevent a Child Task from Attaching to its Parent](../../../docs/standard/parallel-programming/how-to-prevent-a-child-task-from-attaching-to-its-parent.md).  
  
## See Also  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)  
 [Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)
