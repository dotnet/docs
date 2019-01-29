---
title: "Threading objects and features"
ms.date: "10/01/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "threading [.NET Framework], features"
  - "managed threading"
ms.assetid: 239b2e8d-581b-4ca3-992b-0e8525b9321c
author: "rpetrusha"
ms.author: "ronpet"
---
# Threading objects and features

Along with the <xref:System.Threading.Thread?displayProperty=nameWithType> class, .NET provides a number of classes that help you develop multithreaded applications. The following articles provide overview of those classes:

|Title|Description|  
|-----------|-----------------|  
|[The managed thread pool](the-managed-thread-pool.md)|Describes the <xref:System.Threading.ThreadPool?displayProperty=nameWithType> class, which provides a pool of worker threads that are managed by .NET.|  
|[Timers](timers.md)|Describes .NET timers that can be used in a multithreaded environment.|
|[Overview of synchronization primitives](overview-of-synchronization-primitives.md)|Describes types that can be used to synchronize access to a shared resource or control thread interaction.|
|[EventWaitHandle, CountdownEvent, ManualResetEvent](eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)|Describes managed event wait handles, which are used to synchronize thread activities by signaling and waiting for signals.|
|[Mutexes](mutexes.md)|Describes <xref:System.Threading.Mutex?displayProperty=nameWithType>, which grants exclusive access to a shared resource.|
|[Semaphore and SemaphoreSlim](semaphore-and-semaphoreslim.md)|Describes the <xref:System.Threading.Semaphore?displayProperty=nameWithType> class, which limits number of threads that can access a shared resource or a pool of resources concurrently.|
|[Barrier](barrier.md)|Describes the <xref:System.Threading.Barrier?displayProperty=nameWithType> class that implements the barrier pattern for coordination of threads in phased operations.|
|[SpinLock](spinlock.md)|Describes the <xref:System.Threading.SpinLock?displayProperty=nameWithType> structure, which is a lightweight alternative to the <xref:System.Threading.Monitor?displayProperty=nameWithType> class for certain low-level locking scenarios.|
|[SpinWait](spinwait.md)|Describes the <xref:System.Threading.SpinWait?displayProperty=nameWithType> structure, which provides support for spin-based waiting.|

## See also

- <xref:System.Threading.Monitor?displayProperty=nameWithType>
- <xref:System.Threading.WaitHandle?displayProperty=nameWithType>
- <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType>
- <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType>
- <xref:System.Threading.Tasks.Task?displayProperty=nameWithType>
- [Using threads and threading](using-threads-and-threading.md)
- [Asynchronous File I/O](../io/asynchronous-file-i-o.md)
- [Parallel Programming](../parallel-programming/index.md)
- [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md)
