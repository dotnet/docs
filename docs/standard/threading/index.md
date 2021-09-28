---
title: "Managed Threading"
description: See links to articles about managed threading in .NET covering the basics, best practices, threading objects & features, reference pages, & more.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "threading [.NET], about threading"
  - "managed threading"
ms.assetid: 7b46a7d9-c6f1-46d1-a947-ae97471bba87
---
# Managed threading

Whether you're developing for computers with one processor or several, you want your application to provide the most responsive interaction with the user, even if the application is currently doing other work. Using multiple threads of execution is one of the most powerful ways to keep your application responsive to the user and at the same time make use of the processor in between or even during user events. While this section introduces the basic concepts of threading, it focuses on managed threading concepts and using managed threading.  
  
> [!NOTE]
> Starting with .NET Framework 4, multithreaded programming is greatly simplified with the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> classes, [Parallel LINQ (PLINQ)](../parallel-programming/introduction-to-plinq.md), concurrent collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace, and a programming model that is based on the concept of tasks rather than threads. For more information, see [Parallel Programming](../parallel-programming/index.md).  
  
## In This Section  

 [Managed Threading Basics](managed-threading-basics.md)  
 Provides an overview of managed threading and discusses when to use multiple threads.  
  
 [Using Threads and Threading](using-threads-and-threading.md)  
 Explains how to create, start, pause, resume, and abort threads.  
  
 [Managed Threading Best Practices](managed-threading-best-practices.md)  
 Discusses levels of synchronization, how to avoid deadlocks and race conditions, and other threading issues.  
  
 [Threading Objects and Features](threading-objects-and-features.md)  
 Describes the managed classes you can use to synchronize the activities of threads and the data of objects accessed on different threads, and provides an overview of thread pool threads.  
  
## Reference  

 <xref:System.Threading>  
 Contains classes for using and synchronizing managed threads.  
  
 <xref:System.Collections.Concurrent>  
 Contains collection classes that are safe for use with multiple threads.  
  
 <xref:System.Threading.Tasks>  
 Contains classes for creating and scheduling concurrent processing tasks.  
  
## Related Sections  

 [Application Domains](../../framework/app-domains/application-domains.md)  
 Provides an overview of application domains and their use by the Common Language Infrastructure.  
  
 [Asynchronous File I/O](../io/asynchronous-file-i-o.md)  
 Describes the performance advantages and basic operation of asynchronous I/O.  
  
 [Task-based Asynchronous Pattern (TAP)](../asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md)  
 Provides an overview of the recommended pattern for asynchronous programming in .NET.  
  
 [Calling Synchronous Methods Asynchronously](../asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md)  
 Explains how to call methods on thread pool threads using built-in features of delegates.  
  
 [Parallel Programming](../parallel-programming/index.md)  
 Describes the parallel programming libraries, which simplify the use of multiple threads in applications.  
  
 [Parallel LINQ (PLINQ)](../parallel-programming/introduction-to-plinq.md)  
 Describes a system for running queries in parallel, to take advantage of multiple processors.
