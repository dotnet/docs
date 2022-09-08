---
title: "Managed Threading Basics"
description: See links to other managed threading articles, covering topics such as exceptions, synchronizing data, foreground & background threads, local storage, and more.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "multiple threads"
  - "threading [.NET], multiple threads"
  - "threading [.NET], about threading"
  - "managed threading"
ms.assetid: b2944911-0e8f-427d-a8bb-077550618935
---
# Managed threading basics

The first five articles of this section are designed to help you determine when to use managed threading and to explain some basic features. For information on classes that provide additional features, see [Threading Objects and Features](threading-objects-and-features.md) and [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md).

 The remaining articles in this section cover advanced topics, including the interaction of managed threading with the Windows operating system.

> [!NOTE]
> Starting with .NET Framework 4, the Task Parallel Library and PLINQ provide APIs for task and data parallelism in multi-threaded programs. For more information, see [Parallel Programming](../parallel-programming/index.md).

## In this section

 [Threads and Threading](threads-and-threading.md)\
 Discusses the advantages and drawbacks of multiple threads, and outlines the scenarios in which you might create threads or use thread pool threads.

 [Exceptions in Managed Threads](exceptions-in-managed-threads.md)\
 Describes the behavior of unhandled exceptions in threads for different versions of .NET, in particular the situations in which they result in termination of the application.

 [Synchronizing Data for Multithreading](synchronizing-data-for-multithreading.md)\
 Describes strategies for synchronizing data in classes that will be used with multiple threads.

 [Foreground and Background Threads](foreground-and-background-threads.md)\
 Explains the differences between foreground and background threads.

 [Managed and Unmanaged Threading in Windows](managed-and-unmanaged-threading-in-windows.md)\
 Discusses the relationship between managed and unmanaged threading, lists managed equivalents for Windows threading APIs, and discusses the interaction of COM apartments and managed threads.

 [Thread Local Storage: Thread-Relative Static Fields and Data Slots](thread-local-storage-thread-relative-static-fields-and-data-slots.md)\
 Describes thread-relative storage mechanisms.

## Reference

 <xref:System.Threading.Thread>
 Provides reference documentation for the **Thread** class, which represents a managed thread, whether it came from unmanaged code or was created in a managed application.

 <xref:System.ComponentModel.BackgroundWorker>
 Provides a safe way to implement multithreading in conjunction with user-interface objects.

## Related sections

[Overview of Synchronization Primitives](overview-of-synchronization-primitives.md)\
Describes the managed classes used to synchronize the activities of multiple threads.

[Managed Threading Best Practices](managed-threading-best-practices.md)\
Describes common problems with multithreading and strategies for avoiding problems.

[Parallel Programming](../parallel-programming/index.md)\
Describes the Task Parallel Library and PLINQ, which greatly simplify the work of creating asynchronous and multi-threaded .NET applications.

[System.Threading.Channels library](../../core/extensions/channels.md)\
Describes the System.Threading.Channels library, which provides a set of synchronization data structures for passing data between producers and consumers asynchronously.
