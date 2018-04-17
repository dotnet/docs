---
title: "Threads and Threading"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "multiple threads"
  - "threading [.NET Framework]"
  - "threading [.NET Framework], multiple threads"
ms.assetid: 5baac3aa-e603-4fa6-9f89-0f2c1084e6b1
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Threads and Threading
Operating systems use processes to separate the different applications that they are executing. Threads are the basic unit to which an operating system allocates processor time, and more than one thread can be executing code inside that process. Each thread maintains exception handlers, a scheduling priority, and a set of structures the system uses to save the thread context until it is scheduled. The thread context includes all the information the thread needs to seamlessly resume execution, including the thread's set of CPU registers and stack, in the address space of the thread's host process.  
  
 The .NET Framework further subdivides an operating system process into lightweight managed subprocesses, called application domains, represented by <xref:System.AppDomain?displayProperty=nameWithType>. One or more managed threads (represented by <xref:System.Threading.Thread?displayProperty=nameWithType>) can run in one or any number of application domains within the same managed process. Although each application domain is started with a single thread, code in that application domain can create additional application domains and additional threads. The result is that a managed thread can move freely between application domains inside the same managed process; you might have only one thread moving among several application domains.  
  
 An operating system that supports preemptive multitasking creates the effect of simultaneous execution of multiple threads from multiple processes. It does this by dividing the available processor time among the threads that need it, allocating a processor time slice to each thread one after another. The currently executing thread is suspended when its time slice elapses, and another thread resumes running. When the system switches from one thread to another, it saves the thread context of the preempted thread and reloads the saved thread context of the next thread in the thread queue.  
  
 The length of the time slice depends on the operating system and the processor. Because each time slice is small, multiple threads appear to be executing at the same time, even if there is only one processor. This is actually the case on multiprocessor systems, where the executable threads are distributed among the available processors.  
  
## When To Use Multiple Threads  
 Software that requires user interaction must react to the user's activities as rapidly as possible to provide a rich user experience. At the same time, however, it must do the calculations necessary to present data to the user as fast as possible. If your application uses only one thread of execution, you can combine [asynchronous programming](../../../docs/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md) with[.NET Framework remoting](https://msdn.microsoft.com/library/eccb1d31-0a22-417a-97fd-f4f1f3aa4462) or [XML Web services](https://msdn.microsoft.com/library/1e64af78-d705-4384-b08d-591a45f4379c) created using ASP.NET to use the processing time of other computers in addition to that of your own to increase responsiveness to the user and decrease the data processing time of your application. If you are doing intensive input/output work, you can also use I/O completion ports to increase your application's responsiveness.  
  
### Advantages of Multiple Threads  
 Using more than one thread, however, is the most powerful technique available to increase responsiveness to the user and process the data necessary to get the job done at almost the same time. On a computer with one processor, multiple threads can create this effect, taking advantage of the small periods of time in between user events to process the data in the background. For example, a user can edit a spreadsheet while another thread is recalculating other parts of the spreadsheet within the same application.  
  
 Without modification, the same application would dramatically increase user satisfaction when run on a computer with more than one processor. Your single application domain could use multiple threads to accomplish the following tasks:  
  
-   Communicate over a network, to a Web server, and to a database.  
  
-   Perform operations that take a large amount of time.  
  
-   Distinguish tasks of varying priority. For example, a high-priority thread manages time-critical tasks, and a low-priority thread performs other tasks.  
  
-   Allow the user interface to remain responsive, while allocating time to background tasks.  
  
### Disadvantages of Multiple Threads  
 It is recommended that you use as few threads as possible, thereby minimizing the use of operating-system resources and improving performance. Threading also has resource requirements and potential conflicts to be considered when designing your application. The resource requirements are as follows:  
  
-   The system consumes memory for the context information required by processes, **AppDomain** objects, and threads. Therefore, the number of processes, **AppDomain** objects, and threads that can be created is limited by available memory.  
  
-   Keeping track of a large number of threads consumes significant processor time. If there are too many threads, most of them will not make significant progress. If most of the current threads are in one process, threads in other processes are scheduled less frequently.  
  
-   Controlling code execution with many threads is complex, and can be a source of many bugs.  
  
-   Destroying threads requires knowing what could happen and handling those issues.  
  
 Providing shared access to resources can create conflicts. To avoid conflicts, you must synchronize, or control the access to, shared resources. Failure to synchronize access properly (in the same or different application domains) can lead to problems such as deadlocks (in which two threads stop responding while each waits for the other to complete) and race conditions (when an anomalous result occurs due to an unexpected critical dependence on the timing of two events). The system provides synchronization objects that can be used to coordinate resource sharing among multiple threads. Reducing the number of threads makes it easier to synchronize resources.  
  
 Resources that require synchronization include:  
  
-   System resources (such as communications ports).  
  
-   Resources shared by multiple processes (such as file handles).  
  
-   The resources of a single application domain (such as global, static, and instance fields) accessed by multiple threads.  
  
### Threading and Application Design  
 In general, using the <xref:System.Threading.ThreadPool> class is the easiest way to handle multiple threads for relatively short tasks that will not block other threads and when you do not expect any particular scheduling of the tasks. However, there are a number of reasons to create your own threads:  
  
-   If you need a task to have a particular priority.  
  
-   If you have a task that might run a long time (and therefore block other tasks).  
  
-   If you need to place threads into a single-threaded apartment (all **ThreadPool** threads are in the multithreaded apartment).  
  
-   If you need a stable identity associated with the thread. For example, you should use a dedicated thread to abort that thread, suspend it, or discover it by name.  
  
-   If you need to run background threads that interact with the user interface, the .NET Framework version 2.0 provides a <xref:System.ComponentModel.BackgroundWorker> component that communicates using events, with cross-thread marshaling to the user-interface thread.  
  
### Threading and Exceptions  
 Do handle exceptions in threads. Unhandled exceptions in threads, even background threads, generally terminate the process. There are three exceptions to this rule:  
  
-   A <xref:System.Threading.ThreadAbortException> is thrown in a thread because <xref:System.Threading.Thread.Abort%2A> was called.  
  
-   An <xref:System.AppDomainUnloadedException> is thrown in a thread because the application domain is being unloaded.  
  
-   The common language runtime or a host process terminates the thread.  
  
 For more information, see [Exceptions in Managed Threads](../../../docs/standard/threading/exceptions-in-managed-threads.md).  
  
> [!NOTE]
>  In the .NET Framework versions 1.0 and 1.1, the common language runtime silently traps some exceptions, for example in thread pool threads. This may corrupt application state and eventually cause applications to hang, which might be very difficult to debug.  
  
## See Also  
 <xref:System.Threading.ThreadPool>  
 <xref:System.ComponentModel.BackgroundWorker>  
 [Synchronizing Data for Multithreading](../../../docs/standard/threading/synchronizing-data-for-multithreading.md)  
 [The Managed Thread Pool](../../../docs/standard/threading/the-managed-thread-pool.md)
