---
title: "Threads and threading"
ms.date: "11/08/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "multiple threads"
  - "threading [.NET]"
  - "threading [.NET], multiple threads"
ms.assetid: 5baac3aa-e603-4fa6-9f89-0f2c1084e6b1
author: "rpetrusha"
ms.author: "ronpet"
---
# Threads and threading

Multithreading allows you to increase the responsiveness of your application and, if your application runs on a multiprocessor or multi-core system, increase its throughput.

## Processes and threads

A *process* is an executing program. An operating system uses processes to separate the applications that are being executed. A *thread* is the basic unit to which an operating system allocates processor time. Each thread has a [scheduling priority](scheduling-threads.md) and maintains a set of structures the system uses to save the thread context when the thread's execution is paused. The thread context includes all the information the thread needs to seamlessly resume execution, including the thread's set of CPU registers and stack. Multiple threads can run in the context of a process. All threads of a process share its virtual address space. A thread can execute any part of the program code, including parts currently being executed by another thread.

> [!NOTE]
> The .NET Framework provides a way to isolate applications within a process with the use of *application domains*. (Application domains are not available on .NET Core.) For more information, see the [Application domains and threads](../../framework/app-domains/application-domains.md#application-domains-and-threads) section of the [Application domains](../../framework/app-domains/application-domains.md) article.

By default, a .NET program is started with a single thread, often called the *primary* thread. However, it can create additional threads to execute code in parallel or concurrently with the primary thread. These threads are often called *worker* threads.

## When to use multiple threads

You use multiple threads to increase the responsiveness of your application and to take advantage of a multiprocessor or multi-core system to increase the application's throughput.

Consider a desktop application, in which the primary thread is responsible for user interface elements and responds to user actions. Use worker threads to perform time-consuming operations that, otherwise, would occupy the primary thread and make the user interface non-responsive. You also can use a dedicated thread for network or device communication to be more responsive to incoming messages or events.

If your program performs operations that can be done in parallel, the total execution time can be decreased by performing those operations in separate threads and running the program on a multiprocessor or multi-core system. On such a system, use of multithreading might increase throughput along with the increased responsiveness.

## How to use multithreading in .NET

Starting with the .NET Framework 4, the recommended way to utilize multithreading is to use [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md) and [Parallel LINQ (PLINQ)](../parallel-programming/parallel-linq-plinq.md). For more information, see [Parallel programming](../parallel-programming/index.md).

Both TPL and PLINQ rely on the <xref:System.Threading.ThreadPool> threads. The <xref:System.Threading.ThreadPool?displayProperty=nameWithType> class provides a .NET application with a pool of worker threads. You also can use thread pool threads. For more information, see [The managed thread pool](the-managed-thread-pool.md).

At last, you can use the <xref:System.Threading.Thread?displayProperty=nameWithType> class that represents a managed thread. For more information, see [Using threads and threading](using-threads-and-threading.md).

Multiple threads might need to access a shared resource. To keep the resource in a uncorrupted state and avoid race conditions, you must synchronize the thread access to it. You also might want to coordinate the interaction of multiple threads. .NET provides a range of types that you can use to synchronize access to a shared resource or coordinate thread interaction. For more information, see [Overview of synchronization primitives](overview-of-synchronization-primitives.md).

Do handle exceptions in threads. Unhandled exceptions in threads generally terminate the process. For more information, see [Exceptions in managed threads](exceptions-in-managed-threads.md).

## See also

- [Threading objects and features](threading-objects-and-features.md)
- [Managed threading best practices](managed-threading-best-practices.md)
- [Parallel Processing, Concurrency, and Async Programming in .NET](../parallel-processing-and-concurrency.md)
- [About Processes and Threads](/windows/desktop/procthread/about-processes-and-threads)