---
title: "Multithreaded Applications (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 02b0444b-2e68-4f2c-bc28-28c046004017
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Multithreaded Applications (Visual Basic)
With Visual Basic, you can write applications that perform multiple tasks at the same time. Tasks with the potential of holding up other tasks can execute on separate threads, a process known as *multithreading* or *free threading*.  
  
 Applications that use multithreading are more responsive to user input because the user interface stays active as processor-intensive tasks execute on separate threads. Multithreading is also useful when you create scalable applications, because you can add threads as the workload increases.  
  
## Creating and Using Threads  
 If you need more control over the behavior of your application's threads, you can manage the threads yourself. However, realize that writing correct multithreaded applications can be difficult: Your application may stop responding or experience transient errors caused by race conditions. For more information, see [Thread-Safe Components](http://msdn.microsoft.com/library/4f7c7377-a782-4bd0-aaa3-9db8c12945ee).  
  
 You create a new thread by declaring a variable of type <xref:System.Threading.Thread> and calling the constructor, providing the name of the procedure or method that you want to execute on the new thread. The following code provides an example.  
  
```vb  
Dim newThread As New System.Threading.Thread(AddressOf AMethod)  
```  
  
### Starting and Stopping Threads  
 To start the execution of a new thread, use the <xref:System.Threading.Thread.Start%2A> method, as shown in the following code.  
  
```vb  
newThread.Start()  
```  
  
 To stop the execution of a thread, use the <xref:System.Threading.Thread.Abort%2A> method, as shown in the following code.  
  
```vb  
newThread.Abort()  
```  
  
 Besides starting and stopping threads, you can also pause threads by calling the <xref:System.Threading.Thread.Sleep%2A> or <xref:System.Threading.Thread.Suspend%2A> method, resume a suspended thread by using the <xref:System.Threading.Thread.Resume%2A> method, and destroy a thread by using the <xref:System.Threading.Thread.Abort%2A> method  
  
### Thread Methods  
 The following table shows some of the methods that you can use to control individual threads.  
  
|Method|Action|  
|------------|------------|  
|<xref:System.Threading.Thread.Start%2A>|Causes a thread to start to run.|  
|<xref:System.Threading.Thread.Sleep%2A>|Pauses a thread for a specified time.|  
|<xref:System.Threading.Thread.Suspend%2A>|Pauses a thread when it reaches a safe point.|  
|<xref:System.Threading.Thread.Abort%2A>|Stops a thread when it reaches a safe point.|  
|<xref:System.Threading.Thread.Resume%2A>|Restarts a suspended thread|  
|<xref:System.Threading.Thread.Join%2A>|Causes the current thread to wait for another thread to finish. If used with a time-out value, this method returns `True` if the thread finishes in the allocated time.|  
  
### Safe Points  
 Most of these methods are self-explanatory, but the concept of *safe points* may be new to you. Safe points are locations in code where it is safe for the common language runtime to perform automatic *garbage collection*, the process of releasing unused variables and reclaiming memory. When you call the <xref:System.Threading.Thread.Abort%2A> or <xref:System.Threading.Thread.Suspend%2A> method of a thread, the common language runtime analyzes the code and determines the location of an appropriate location for the thread to stop running.  
  
### Thread Properties  
 Threads also contain several useful properties, as shown in the following table:  
  
|Property|Value|  
|--------------|-----------|  
|<xref:System.Threading.Thread.IsAlive%2A>|Contains the value `True` if a thread is active.|  
|<xref:System.Threading.Thread.IsBackground%2A>|Gets or sets a Boolean that indicates if a thread is or should be a background thread. Background threads are like foreground threads, but a background thread does not prevent a process from stopping. Once all foreground threads that belong to a process have stopped, the common language runtime ends the process by calling the <xref:System.Threading.Thread.Abort%2A> method on background threads that are still alive.|  
|<xref:System.Threading.Thread.Name%2A>|Gets or sets the name of a thread. Most frequently used to discover individual threads when you debug.|  
|<xref:System.Threading.Thread.Priority%2A>|Gets or sets a value that is used by the operating system to prioritize thread scheduling.|  
|<xref:System.Threading.Thread.ThreadState%2A>|Contains a value that describes a thread's state or states.|  
  
## Thread Priorities  
 Every thread has a priority property that determines how big or small a slice of processor time it has to execute. The operating system allocates longer time slices to high-priority threads and shorter time slices to low-priority threads. New threads are created with the value of `Normal`, but you can change the <xref:System.Threading.Thread.Priority%2A> property to any value in the <xref:System.Threading.ThreadPriority> enumeration.  
  
 See <xref:System.Threading.ThreadPriority> for a detailed description of the various thread priorities.  
  
## Foreground and Background Threads  
 A *foreground thread* runs indefinitely, whereas a *background thread* stops as soon as the last foreground thread has stopped. You can use the <xref:System.Threading.Thread.IsBackground%2A> property to determine or change the background status of a thread.  
  
## See Also  
 <xref:System.Threading.Thread>  
 [Thread Synchronization (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/thread-synchronization.md)  
 [Parameters and Return Values for Multithreaded Procedures (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/parameters-and-return-values-for-multithreaded-procedures.md)  
 [Threading (Visual Basic)](../../../../visual-basic/programming-guide/concepts/threading/index.md)
