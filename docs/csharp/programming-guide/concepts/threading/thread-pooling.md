---
title: "Thread Pooling (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 98ae68c1-ace8-44b9-9317-8920ac9ef2b6
caps.latest.revision: 5
author: "BillWagner"
ms.author: "wiwagn"
---
# Thread Pooling (C#)
A *thread pool* is a collection of threads that can be used to perform several tasks in the background. (See [Threading (C#)](../../../../csharp/programming-guide/concepts/threading/index.md) for background information.) This leaves the primary thread free to perform other tasks asynchronously.  
  
 Thread pools are often employed in server applications. Each incoming request is assigned to a thread from the thread pool, so that the request can be processed asynchronously, without tying up the primary thread or delaying the processing of subsequent requests.  
  
 Once a thread in the pool completes its task, it is returned to a queue of waiting threads, where it can be reused. This reuse enables applications to avoid the cost of creating a new thread for each task.  
  
 Thread pools typically have a maximum number of threads. If all the threads are busy, additional tasks are put in queue until they can be serviced as threads become available.  
  
 You can implement your own thread pool, but it is easier to use the thread pool provided by the .NET Framework through the <xref:System.Threading.ThreadPool> class.  
  
 With thread pooling, you call the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A?displayProperty=nameWithType> method with a delegate for the procedure you want to run, and C# creates the thread and runs your procedure.  
  
## Thread Pooling Example  
 The following example shows how you can use thread pooling to start several tasks.  
  
```csharp  
public void DoWork()  
{  
    // Queue a task.  
    System.Threading.ThreadPool.QueueUserWorkItem(  
        new System.Threading.WaitCallback(SomeLongTask));  
    // Queue another task.  
    System.Threading.ThreadPool.QueueUserWorkItem(  
        new System.Threading.WaitCallback(AnotherLongTask));  
}  
  
private void SomeLongTask(Object state)  
{  
    // Insert code to perform a long task.  
}  
  
private void AnotherLongTask(Object state)  
{  
    // Insert code to perform a long task.  
}  
```  
  
 One advantage of thread pooling is that you can pass arguments in a state object to the task procedure. If the procedure you are calling requires more than one argument, you can cast a structure or an instance of a class into an `Object` data type.  
  
## Thread Pool Parameters and Return Values  
 Returning values from a thread-pool thread is not straightforward. The standard way of returning values from a function call is not allowed because `Sub` procedures are the only type of procedure that can be queued to a thread pool. One way you can provide parameters and return values is by wrapping the parameters, return values, and methods in a wrapper class as described in [Parameters and Return Values for Multithreaded Procedures (C#)](../../../../csharp/programming-guide/concepts/threading/parameters-and-return-values-for-multithreaded-procedures.md).  
  
 An easier way to provide parameters and return values is by using the optional `ByVal` state object variable of the <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A> method. If you use this variable to pass a reference to an instance of a class, the members of the instance can be modified by the thread-pool thread and used as return values.  
  
 At first it may not be obvious that you can modify an object referred to by a variable that is passed by value. You can do this because only the object reference is passed by value. When you make changes to members of the object referred to by the object reference, the changes apply to the actual class instance.  
  
 Structures cannot be used to return values inside state objects. Because structures are value types, changes that the asynchronous process makes do not change the members of the original structure. Use structures to provide parameters when return values are not needed.  
  
## See Also  
 <xref:System.Threading.ThreadPool.QueueUserWorkItem%2A>  
 <xref:System.Threading>  
 <xref:System.Threading.ThreadPool>  
 [How to: Use a Thread Pool (C#)](../../../../csharp/programming-guide/concepts/threading/how-to-use-a-thread-pool.md)  
 [Threading (C#)](../../../../csharp/programming-guide/concepts/threading/index.md)  
 [Multithreaded Applications (C#)](../../../../csharp/programming-guide/concepts/threading/multithreaded-applications.md)  
 [Thread Synchronization (C#)](../../../../csharp/programming-guide/concepts/threading/thread-synchronization.md)
