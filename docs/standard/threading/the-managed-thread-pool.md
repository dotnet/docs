---
title: "The managed thread pool"
description: Learn about the .NET thread pool that provides background worker threads
ms.date: "08/02/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "thread pooling [.NET]"
  - "thread pools [.NET]"
  - "threading [.NET], thread pool"
  - "threading [.NET], pooling"
ms.assetid: 2be05b06-a42e-4c9d-a739-96c21d673927
author: "rpetrusha"
ms.author: "ronpet"
---
# The managed thread pool

The <xref:System.Threading.ThreadPool?displayProperty=nameWithType> class provides your application with a pool of worker threads that are managed by the system, allowing you to concentrate on application tasks rather than thread management. If you have short tasks that require background processing, the managed thread pool is an easy way to take advantage of multiple threads. Use of the thread pool is significantly easier in Framework 4 and later, since you can create <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> objects that perform asynchronous tasks on thread pool threads.  
  
.NET uses thread pool threads for many purposes, including [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md) operations, asynchronous I/O completion, [timer](timers.md) callbacks, registered wait operations, asynchronous method calls using delegates, and <xref:System.Net?displayProperty=nameWithType> socket connections.  

## Thread pool characteristics

Thread pool threads are [background](foreground-and-background-threads.md) threads. Each thread uses the default stack size, runs at the default priority, and is in the multithreaded apartment. Once a thread in the thread pool completes its task, it's returned to a queue of waiting threads. From this moment it can be reused. This reuse enables applications to avoid the cost of creating a new thread for each task.
  
There is only one thread pool per process.  
  
### Exceptions in thread pool threads

Unhandled exceptions in thread pool threads terminate the process. There are three exceptions to this rule:  
  
- A <xref:System.Threading.ThreadAbortException?displayProperty=nameWithType> is thrown in a thread pool thread because <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> was called.  
- A <xref:System.AppDomainUnloadedException?displayProperty=nameWithType> is thrown in a thread pool thread because the application domain is being unloaded.  
- The common language runtime or a host process terminates the thread.  
  
For more information, see [Exceptions in Managed Threads](exceptions-in-managed-threads.md).  
  
### Maximum number of thread pool threads

The number of operations that can be queued to the thread pool is limited only by available memory. However, the thread pool limits the number of threads that can be active in the process simultaneously. If all thread pool threads are busy, additional work items are queued until threads to execute them become available. Beginning with the .NET Framework 4, the default size of the thread pool for a process depends on several factors, such as the size of the virtual address space. A process can call the <xref:System.Threading.ThreadPool.GetMaxThreads%2A?displayProperty=nameWithType> method to determine the number of threads.  
  
You can control the maximum number of threads by using the <xref:System.Threading.ThreadPool.GetMaxThreads%2A?displayProperty=nameWithType> and <xref:System.Threading.ThreadPool.SetMaxThreads%2A?displayProperty=nameWithType> methods.  

> [!NOTE]
> Code that hosts the common language runtime can set the size using the [`ICorThreadpool::CorSetMaxThreads`](../../framework/unmanaged-api/hosting/icorthreadpool-corsetmaxthreads-method.md) method.  
  
### Thread pool minimums

The thread pool provides new worker threads or I/O completion threads on demand until it reaches a specified minimum for each category. You can use the <xref:System.Threading.ThreadPool.GetMinThreads%2A?displayProperty=nameWithType> method to obtain these minimum values.  
  
> [!NOTE]
> When demand is low, the actual number of thread pool threads can fall below the minimum values.  
  
When a minimum is reached, the thread pool can create additional threads or wait until some tasks complete. Beginning with the .NET Framework 4, the thread pool creates and destroys worker threads in order to optimize throughput, which is defined as the number of tasks that complete per unit of time. Too few threads might not make optimal use of available resources, whereas too many threads could increase resource contention.  
  
> [!CAUTION]
> You can use the <xref:System.Threading.ThreadPool.SetMinThreads%2A?displayProperty=nameWithType> method to increase the minimum number of idle threads. However, unnecessarily increasing these values can cause performance problems. If too many tasks start at the same time, all of them might appear to be slow. In most cases the thread pool will perform better with its own algorithm for allocating threads.  

## Using the thread pool

Beginning with the .NET Framework 4, the easiest way to use the thread pool is to use the [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md). By default, TPL types like <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> use thread pool threads to run tasks.

You can also use the thread pool by calling <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> from managed code (or [`ICorThreadpool::CorQueueUserWorkItem`](../../framework/unmanaged-api/hosting/icorthreadpool-corqueueuserworkitem-method.md) from unmanaged code) and passing a <xref:System.Threading.WaitCallback?displayProperty=nameWithType> delegate representing the method that performs the task.

Another way to use the thread pool is to queue work items that are related to a wait operation by using the <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A?displayProperty=nameWithType> method and passing a <xref:System.Threading.WaitHandle?displayProperty=nameWithType> that, when signaled or when timed out, calls the method represented by the <xref:System.Threading.WaitOrTimerCallback?displayProperty=nameWithType> delegate. Thread pool threads are used to invoke callback methods.  

For the examples, check the referenced API pages.
  
## Skipping security checks

The thread pool also provides the <xref:System.Threading.ThreadPool.UnsafeQueueUserWorkItem%2A?displayProperty=nameWithType> and <xref:System.Threading.ThreadPool.UnsafeRegisterWaitForSingleObject%2A?displayProperty=nameWithType> methods. Use these methods only when you are certain that the caller's stack is irrelevant to any security checks performed during the execution of the queued task. <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> and <xref:System.Threading.ThreadPool.RegisterWaitForSingleObject%2A?displayProperty=nameWithType> both capture the caller's stack, which is merged into the stack of the thread pool thread when the thread begins to execute a task. If a security check is required, the entire stack must be checked. Although the check provides safety, it also has a performance cost.  

## When not to use thread pool threads

There are several scenarios in which it's appropriate to create and manage your own threads instead of using thread pool threads:  
  
- You require a foreground thread.  
- You require a thread to have a particular priority.  
- You have tasks that cause the thread to block for long periods of time. The thread pool has a maximum number of threads, so a large number of blocked thread pool threads might prevent tasks from starting.  
- You need to place threads into a single-threaded apartment. All <xref:System.Threading.ThreadPool> threads are in the multithreaded apartment.  
- You need to have a stable identity associated with the thread, or to dedicate a thread to a task.  
  
## See also

- <xref:System.Threading.ThreadPool?displayProperty=nameWithType>  
- <xref:System.Threading.Tasks.Task?displayProperty=nameWithType>  
- <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType>  
- [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md)  
- [How to: Return a Value from a Task](../parallel-programming/how-to-return-a-value-from-a-task.md)  
- [Threading Objects and Features](threading-objects-and-features.md)  
- [Threads and Threading](threads-and-threading.md)  
- [Asynchronous File I/O](../io/asynchronous-file-i-o.md)  
- [Timers](timers.md)  
