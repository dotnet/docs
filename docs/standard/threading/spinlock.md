---
title: "SpinLock"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "synchronization primitives, SpinLock"
ms.assetid: f9af93bb-7a0d-4ba5-afe8-74f48b6b6958
author: "rpetrusha"
ms.author: "ronpet"
---
# SpinLock
The <xref:System.Threading.SpinLock> structure is a low-level, mutual-exclusion synchronization primitive that spins while it waits to acquire a lock. On multicore computers, when wait times are expected to be short and when contention is minimal, <xref:System.Threading.SpinLock> can perform better than other kinds of locks. However, we recommend that you use <xref:System.Threading.SpinLock> only when you determine by profiling that the <xref:System.Threading.Monitor?displayProperty=nameWithType> method or the <xref:System.Threading.Interlocked> methods are significantly slowing the performance of your program.  
  
 <xref:System.Threading.SpinLock> may yield the time slice of the thread even if it has not yet acquired the lock. It does this to avoid thread-priority inversion, and to enable the garbage collector to make progress. When you use a <xref:System.Threading.SpinLock>, ensure that no thread can hold the lock for more than a very brief time span, and that no thread can block while it holds the lock.  
  
 Because SpinLock is a value type, you must explicitly pass it by reference if you intend the two copies to refer to the same lock.  
  
 For more information about how to use this type, see <xref:System.Threading.SpinLock?displayProperty=nameWithType>. For an example, see [How to: Use SpinLock for Low-Level Synchronization](../../../docs/standard/threading/how-to-use-spinlock-for-low-level-synchronization.md).  
  
 <xref:System.Threading.SpinLock> supports a *thread*-*tracking* mode that you can use during the development phase to help track the thread that is holding the lock at a specific time. Thread-tracking mode is very useful for debugging, but we recommend that you turn it off in the release version of your program because it may slow performance. For more information, see [How to: Enable Thread-Tracking Mode in SpinLock](../../../docs/standard/threading/how-to-enable-thread-tracking-mode-in-spinlock.md).  
  
## See also

- [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
