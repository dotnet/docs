---
description: "Learn more about: How to: use SpinLock for low-level synchronization"
title: "How to: use SpinLock for low-level synchronization"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "SpinLock, how to use"
ms.assetid: a9ed3e4e-4f29-4207-b730-ed0a51ecbc19
---
# How to: use SpinLock for low-level synchronization

The following example demonstrates how to use a <xref:System.Threading.SpinLock>. In this example, the critical section performs a minimal amount of work, which makes it a good candidate for a <xref:System.Threading.SpinLock>. Increasing the work a small amount increases the performance of the <xref:System.Threading.SpinLock> compared to a standard lock. However, there is a point at which a SpinLock becomes more expensive than a standard lock. You can use the concurrency profiling functionality in the profiling tools to see which type of lock provides better performance in your program. For more information, see [Concurrency Visualizer](/visualstudio/profiling/concurrency-visualizer).  
  
 [!code-csharp[CDS_SpinLock#02](../../../samples/snippets/csharp/VS_Snippets_Misc/cds_spinlock/cs/spinlockdemo.cs#02)]
 [!code-vb[CDS_SpinLock#02](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_spinlock/vb/spinlock_vb.vb#02)]  
  
 <xref:System.Threading.SpinLock> might be useful when a lock on a shared resource is not going to be held for very long. In such cases, on multi-core computers it can be efficient for the blocked thread to spin for a few cycles until the lock is released. By spinning, the thread does not become blocked, which is a CPU-intensive process. <xref:System.Threading.SpinLock> will stop spinning under certain conditions to prevent starvation of logical processors or priority inversion on systems with Hyper-Threading.  
  
 This example uses the <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType> class, which requires user synchronization for multi-threaded access. Another option is to use the <xref:System.Collections.Concurrent.ConcurrentQueue%601?displayProperty=nameWithType>, which does not require any user locks.  
  
 Note the use of `false` in the call to <xref:System.Threading.SpinLock.Exit%2A?displayProperty=nameWithType>. This provides the best performance. Specify `true` on IA64 architectures to use the memory fence, which flushes the write buffers to ensure that the lock is now available for other threads to enter.
  
## See also

- [Threading objects and features](threading-objects-and-features.md)
- [lock statement (C#)](../../csharp/language-reference/keywords/lock-statement.md)
- [SyncLock statement (Visual Basic)](../../visual-basic/language-reference/statements/synclock-statement.md)
