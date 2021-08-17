---
title: Workstation vs. server garbage collection (GC)
description: Learn about workstation and server garbage collection in .NET.
ms.date: 04/21/2020
helpviewer_keywords:
  - garbage collection, workstation
  - garbage collection, server
  - workstation garbage collection
  - server garbage collection
---
# Workstation and server garbage collection

The garbage collector is self-tuning and can work in a wide variety of scenarios. However, you can [set the type of garbage collection](../../core/run-time-config/garbage-collector.md#flavors-of-garbage-collection) based on the characteristics of the workload. The CLR provides the following types of garbage collection:

- Workstation garbage collection (GC), which is designed for client apps. It's the default GC flavor for standalone apps. For hosted apps, for example, those hosted by ASP.NET, the host determines the default GC flavor.

  Workstation garbage collection can be concurrent or non-concurrent. Concurrent (or *background*) garbage collection enables managed threads to continue operations during a garbage collection. [Background garbage collection](background-gc.md) replaces [concurrent garbage collection](background-gc.md#concurrent-garbage-collection) in .NET Framework 4 and later versions.

- Server garbage collection, which is intended for server applications that need high throughput and scalability.

  - In .NET Core, server garbage collection can be non-concurrent or background.

  - In .NET Framework 4.5 and later versions, server garbage collection can be non-concurrent or background. In .NET Framework 4 and previous versions, server garbage collection is non-concurrent.

The following illustration shows the dedicated threads that perform the garbage collection on a server:

![Server Garbage Collection Threads](media/gc-server.png)

## Performance considerations

### Workstation GC

The following are threading and performance considerations for workstation garbage collection:

- The collection occurs on the user thread that triggered the garbage collection and remains at the same priority. Because user threads typically run at normal priority, the garbage collector (which runs on a normal priority thread) must compete with other threads for CPU time. (Threads that run native code are not suspended on either server or workstation garbage collection.)

- Workstation garbage collection is always used on a computer that has only one processor, regardless of the [configuration setting](../../core/run-time-config/garbage-collector.md#workstation-vs-server).

### Server GC

The following are threading and performance considerations for server garbage collection:

- The collection occurs on multiple dedicated threads that are running at `THREAD_PRIORITY_HIGHEST` priority level.

- A heap and a dedicated thread to perform garbage collection are provided for each CPU, and the heaps are collected at the same time. Each heap contains a small object heap and a large object heap, and all heaps can be accessed by user code. Objects on different heaps can refer to each other.

- Because multiple garbage collection threads work together, server garbage collection is faster than workstation garbage collection on the same size heap.

- Server garbage collection often has larger size segments. However, this is only a generalization: segment size is implementation-specific and is subject to change. Don't make assumptions about the size of segments allocated by the garbage collector when tuning your app.

- Server garbage collection can be resource-intensive. For example, imagine that there are 12 processes that use server GC running on a computer that has four processors. If all the processes happen to collect garbage at the same time, they would interfere with each other, as there would be 12 threads scheduled on the same processor. If the processes are active, it's not a good idea to have them all use server GC.

If you're running hundreds of instances of an application, consider using workstation garbage collection with concurrent garbage collection disabled. This will result in less context switching, which can improve performance.

## See also

- [Background garbage collection](background-gc.md)
- [Runtime configuration options for garbage collection](../../core/run-time-config/garbage-collector.md)
