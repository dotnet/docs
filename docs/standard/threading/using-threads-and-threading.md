---
title: "Using threads and threading"
ms.date: "08/08/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "threading [.NET Framework], about threading"
  - "managed threading"
ms.assetid: 9b5ec2cd-121b-4d49-b075-222cf26f2344
author: "rpetrusha"
ms.author: "ronpet"
---
# Using threads and threading

With .NET, you can write applications that perform multiple operations at the same time. Operations with the potential of holding up other operations can execute on separate threads, a process known as *multithreading* or *free threading*.  
  
Applications that use multithreading are more responsive to user input because the user interface stays active as processor-intensive tasks execute on separate threads. Multithreading is also useful when you create scalable applications, because you can add threads as the workload increases.

> [!NOTE]
> If you need more control over the behavior of the application's threads, you can manage the threads yourself. However, starting with the .NET Framework 4, multithreaded programming is greatly simplified with the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> classes, [Parallel LINQ (PLINQ)](../parallel-programming/parallel-linq-plinq.md), new concurrent collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace, and a new programming model that is based on the concept of tasks rather than threads. For more information, see [Parallel Programming](../parallel-programming/index.md) and [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md).

## How to: Create and start a new thread

You create a new thread by creating a new instance of the <xref:System.Threading.Thread?displayProperty=nameWithType> class and providing the name of the method that you want to execute on a new thread to the constructor. To start a created thread, call the <xref:System.Threading.Thread.Start%2A?displayProperty=nameWithType> method. For more information and examples, see the [Creating threads and passing data at start time](creating-threads-and-passing-data-at-start-time.md) article and the <xref:System.Threading.Thread> API reference.

## How to: Stop a thread

To terminate the execution of a thread, use the <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> method. That method raises a <xref:System.Threading.ThreadAbortException> on the thread on which it's invoked. For more information, see [Destroying threads](destroying-threads.md).

Beginning with the .NET Framework 4, you can use the <xref:System.Threading.CancellationToken?displayProperty=nameWithType> to cancel a thread cooperatively. For more information, see [Canceling threads cooperatively](canceling-threads-cooperatively.md).

Use the <xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType> method to make the calling thread wait for the termination of the thread on which the method is invoked.

## How to: Pause or interrupt a thread

You use the <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> method to pause the current thread for a specified amount of time. You can interrupt a blocked thread by calling the <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> method. For more information, see [Pausing and interrupting threads](pausing-and-resuming-threads.md).

## Thread properties

The following table presents some of the <xref:System.Threading.Thread> properties:  
  
|Property|Description|  
|--------------|-----------|  
|<xref:System.Threading.Thread.IsAlive%2A>|Returns `true` if a thread has been started and has not yet terminated normally or aborted.|  
|<xref:System.Threading.Thread.IsBackground%2A>|Gets or sets a Boolean that indicates if a thread is a background thread. Background threads are like foreground threads, but a background thread doesn't prevent a process from stopping. Once all foreground threads that belong to a process have stopped, the common language runtime ends the process by calling the <xref:System.Threading.Thread.Abort%2A> method on background threads that are still alive. For more information, see [Foreground and Background Threads](foreground-and-background-threads.md).|  
|<xref:System.Threading.Thread.Name%2A>|Gets or sets the name of a thread. Most frequently used to discover individual threads when you debug.|  
|<xref:System.Threading.Thread.Priority%2A>|Gets or sets a <xref:System.Threading.ThreadPriority> value that is used by the operating system to prioritize thread scheduling. For more information, see [Scheduling threads](scheduling-threads.md) and the <xref:System.Threading.ThreadPriority> reference.|  
|<xref:System.Threading.Thread.ThreadState%2A>|Gets a <xref:System.Threading.ThreadState> value containing the current states of a thread.|  

## See also

 <xref:System.Threading.Thread?displayProperty=nameWithType>  
 [Threads and Threading](threads-and-threading.md)  
 [Parallel Programming](../parallel-programming/index.md)  
