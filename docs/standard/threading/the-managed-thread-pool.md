---
title: "The Managed Thread Pool"
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
  - "cpp"
helpviewer_keywords: 
  - "thread pooling [.NET Framework]"
  - "thread pools [.NET Framework]"
  - "threading [.NET Framework], thread pool"
  - "threading [.NET Framework], pooling"
ms.assetid: 2be05b06-a42e-4c9d-a739-96c21d673927
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# The Managed Thread Pool
The <xref:System.Threading.ThreadPool> class provides your application with a pool of worker threads that are managed by the system, allowing you to concentrate on application tasks rather than thread management. If you have short tasks that require background processing, the managed thread pool is an easy way to take advantage of multiple threads. For example, beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] you can create <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects, which perform asynchronous tasks on thread pool threads.  
  
> [!NOTE]
>  Starting with the [!INCLUDE[net_v20SP1_long](../../../includes/net-v20sp1-long-md.md)], the throughput of the thread pool is significantly improved in three key areas that were identified as bottlenecks in previous releases of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]: queuing tasks, dispatching thread pool threads, and dispatching I/O completion threads. To use this functionality, your application should target the [!INCLUDE[net_v35_long](../../../includes/net-v35-long-md.md)] or later.  
  
 For background tasks that interact with the user interface, the .NET Framework version 2.0 also provides the <xref:System.ComponentModel.BackgroundWorker> class, which communicates using events raised on the user interface thread.  
  
 The .NET Framework uses thread pool threads for many purposes, including asynchronous I/O completion, timer callbacks, registered wait operations, asynchronous method calls using delegates, and <xref:System.Net> socket connections.  
  
## When Not to Use Thread Pool Threads  
 There are several scenarios in which it is appropriate to create and manage your own threads instead of using thread pool threads:  
  
-   You require a foreground thread.  
  
-   You require a thread to have a particular priority.  
  
-   You have tasks that cause the thread to block for long periods of time. The thread pool has a maximum number of threads, so a large number of blocked thread pool threads might prevent tasks from starting.  
  
-   You need to place threads into a single-threaded apartment. All <xref:System.Threading.ThreadPool> threads are in the multithreaded apartment.  
  
-   You need to have a stable identity associated with the thread, or to dedicate a thread to a task.  
  
## Thread Pool Characteristics  
 Thread pool threads are background threads. See [Foreground and Background Threads](../../../docs/standard/threading/foreground-and-background-threads.md). Each thread uses the default stack size, runs at the default priority, and is in the multithreaded apartment.  
  
 There is only one thread pool per process.  
  
### Exceptions in Thread Pool Threads  
 Unhandled exceptions on thread pool threads terminate the process. There are three exceptions to this rule:  
  
-   A <xref:System.Threading.ThreadAbortException> is thrown in a thread pool thread, because <xref:System.Threading.Thread.Abort%2A> was called.  
  
-   An <xref:System.AppDomainUnloadedException> is thrown in a thread pool thread, because the application domain is being unloaded.  
  
-   The common language runtime or a host process terminates the thread.  
  
 For more information, see [Exceptions in Managed Threads](../../../docs/standard/threading/exceptions-in-managed-threads.md).  
  
> [!NOTE]
>  In the .NET Framework versions 1.0 and 1.1, the common language runtime silently traps unhandled exceptions in thread pool threads. This might corrupt application state and eventually cause applications to hang, which might be very difficult to debug.  
  
### Maximum Number of Thread Pool Threads  
 The number of operations that can be queued to the thread pool is limited only by available memory; however, the thread pool limits the number of threads that can be active in the process simultaneously. Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the default size of the thread pool for a process depends on several factors, such as the size of the virtual address space. A process can call the <xref:System.Threading.ThreadPool.GetMaxThreads%2A> method to determine the number of threads.  
  
 You can control the maximum number of threads by using the <xref:System.Threading.ThreadPool.GetMaxThreads%2A> and <xref:System.Threading.ThreadPool.SetMaxThreads%2A> methods.  
  
> [!NOTE]
>  In the .NET Framework versions 1.0 and 1.1, the size of the thread pool cannot be set from managed code. Code that hosts the common language runtime can set the size using `CorSetMaxThreads`, defined in mscoree.h.  
  
### Thread Pool Minimums  
 The thread pool provides new worker threads or I/O completion threads on demand until it reaches a specified minimum for each category. You can use the <xref:System.Threading.ThreadPool.GetMinThreads%2A> method to obtain these minimum values.  
  
> [!NOTE]
>  When demand is low, the actual number of thread pool threads can fall below the minimum values.  
  
 When a minimum is reached, the thread pool can create additional threads or wait until some tasks complete. Beginning with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the thread pool creates and destroys worker threads in order to optimize throughput, which is defined as the number of tasks that complete per unit of time. Too few threads might not make optimal use of available resources, whereas too many threads could increase resource contention.  
  
> [!CAUTION]
>  You can use the <xref:System.Threading.ThreadPool.SetMinThreads%2A> method to increase the minimum number of idle threads. However, unnecessarily increasing these values can cause performance problems. If too many tasks start at the same time, all of them might appear to be slow. In most cases the thread pool will perform better with its own algorithm for allocating threads.  
  
## Skipping Security Checks  
 The thread pool also provides the <xref:System.Threading.ThreadPool.UnsafeQueueUserWorkItem%2A?displayProperty=nameWithType> and <xref:System.Threading.ThreadPool.UnsafeRegisterWaitForSingleObject%2A?displayProperty=nameWithType> methods. Use these methods only when you are certain that the caller's stack is irrelevant to any security checks performed during the execution of the queued task. <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A> and <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A> both capture the caller's stack, which is merged into the stack of the thread pool thread when the thread begins to execute a task. If a security check is required, the entire stack must be checked. Although the check provides safety, it also has a performance cost.  
  
## Using the Thread Pool  
 Beginning with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the easiest way to use the thread pool is to use the [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md). By default, parallel library types like <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> use thread pool threads to run tasks. You can also use the thread pool by calling <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> from managed code (or `CorQueueUserWorkItem` from unmanaged code) and passing a <xref:System.Threading.WaitCallback> delegate representing the method that performs the task. Another way to use the thread pool is to queue work items that are related to a wait operation by using the <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A?displayProperty=nameWithType> method and passing a <xref:System.Threading.WaitHandle> that, when signaled or when timed out, calls the method represented by the <xref:System.Threading.WaitOrTimerCallback> delegate. Thread pool threads are used to invoke callback methods.  
  
## ThreadPool Examples  
 The code examples in this section demonstrate the thread pool by using the <xref:System.Threading.Tasks.Task> class, the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> method, and the <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A?displayProperty=nameWithType> method.  
  
-   [Executing Asynchronous Tasks with the Task Parallel Library](#TaskParallelLibrary)  
  
-   [Executing Code Asynchronously with QueueUserWorkItem](#ExecuteCodeWithQUWI)  
  
-   [Supplying Task Data for QueueUserWorkItem](#TaskDataForQUWI)  
  
-   [Using RegisterWaitForSingleObject](#RegisterWaitForSingleObject)  
  
<a name="TaskParallelLibrary"></a>   
### Executing Asynchronous Tasks with the Task Parallel Library  
 The following example shows how to create and use a <xref:System.Threading.Tasks.Task> object by calling the <xref:System.Threading.Tasks.TaskFactory.StartNew%2A?displayProperty=nameWithType> method. For an example that uses the <xref:System.Threading.Tasks.Task%601> class to return a value from an asynchronous task, see [How to: Return a Value from a Task](../../../docs/standard/parallel-programming/how-to-return-a-value-from-a-task.md).  
  
 [!code-csharp[System.Threading.Tasks.Task#01](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.threading.tasks.task/cs/startnew.cs#01)]
 [!code-vb[System.Threading.Tasks.Task#01](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.threading.tasks.task/vb/startnew.vb#01)]  
  
<a name="ExecuteCodeWithQUWI"></a>   
### Executing Code Asynchronously with QueueUserWorkItem  
 The following example queues a very simple task, represented by the `ThreadProc` method, using the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A> method.  
  
 [!code-cpp[Conceptual.ThreadPool#1](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.threadpool/cpp/source1.cpp#1)]
 [!code-csharp[Conceptual.ThreadPool#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.threadpool/cs/source1.cs#1)]
 [!code-vb[Conceptual.ThreadPool#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.threadpool/vb/source1.vb#1)]  
  
<a name="TaskDataForQUWI"></a>   
### Supplying Task Data for QueueUserWorkItem  
 The following code example uses the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A> method to queue a task and supply the data for the task.  
  
 [!code-cpp[Conceptual.ThreadPool#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.threadpool/cpp/source2.cpp#2)]
 [!code-csharp[Conceptual.ThreadPool#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.threadpool/cs/source2.cs#2)]
 [!code-vb[Conceptual.ThreadPool#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.threadpool/vb/source2.vb#2)]  
  
<a name="RegisterWaitForSingleObject"></a>   
### Using RegisterWaitForSingleObject  
 The following example demonstrates several threading features.  
  
-   Queuing a task for execution by <xref:System.Threading.ThreadPool> threads, with the <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A> method.  
  
-   Signaling a task to execute, with <xref:System.Threading.AutoResetEvent>. See [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md).  
  
-   Handling both time-outs and signals with a <xref:System.Threading.WaitOrTimerCallback> delegate.  
  
-   Canceling a queued task with <xref:System.Threading.RegisteredWaitHandle>.  
  
 [!code-cpp[Conceptual.ThreadPool#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.threadpool/cpp/source3.cpp#3)]
 [!code-csharp[Conceptual.ThreadPool#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.threadpool/cs/source3.cs#3)]
 [!code-vb[Conceptual.ThreadPool#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.threadpool/vb/source3.vb#3)]  
  
## See Also  
 <xref:System.Threading.ThreadPool>  
 <xref:System.Threading.Tasks.Task>  
 <xref:System.Threading.Tasks.Task%601>  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 [How to: Return a Value from a Task](../../../docs/standard/parallel-programming/how-to-return-a-value-from-a-task.md)  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)  
 [Threads and Threading](../../../docs/standard/threading/threads-and-threading.md)  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
 [Timers](../../../docs/standard/threading/timers.md)
