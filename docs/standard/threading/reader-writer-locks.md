---
title: "Reader-Writer Locks"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ReaderWriterLock class, about ReaderWriterLock class"
  - "threading [.NET Framework], ReaderWriterLock class"
ms.assetid: 8c71acf2-2c18-4f4d-8cdb-0728639265fd
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Reader-Writer Locks
The <xref:System.Threading.ReaderWriterLockSlim> class enables multiple threads to read a resource concurrently, but requires a thread to wait for an exclusive lock in order to write to the resource.  
  
 You might use a <xref:System.Threading.ReaderWriterLockSlim> in your application to provide cooperative synchronization among threads that access a shared resource. Locks are taken on the <xref:System.Threading.ReaderWriterLockSlim> itself.  
  
 As with any thread synchronization mechanism, you must ensure that no threads bypass the locking that is provided by <xref:System.Threading.ReaderWriterLockSlim>. One way to ensure this is to design a class that encapsulates the shared resource. This class would provide members that access the private shared resource and that use a private <xref:System.Threading.ReaderWriterLockSlim> for synchronization. For an example, see the code example for the <xref:System.Threading.ReaderWriterLockSlim> class. <xref:System.Threading.ReaderWriterLockSlim> is efficient enough to be used to synchronize individual objects.  
  
 Structure your application to minimize the duration of read and write operations. Long write operations affect throughput directly because the write lock is exclusive. Long read operations block waiting writers, and if at least one thread is waiting for write access, threads that request read access will be blocked as well.  
  
> [!NOTE]
>  The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] has two reader-writer locks, <xref:System.Threading.ReaderWriterLockSlim> and <xref:System.Threading.ReaderWriterLock>. <xref:System.Threading.ReaderWriterLockSlim> is recommended for all new development. <xref:System.Threading.ReaderWriterLockSlim> is similar to <xref:System.Threading.ReaderWriterLock>, but it has simplified rules for recursion and for upgrading and downgrading lock state. <xref:System.Threading.ReaderWriterLockSlim> avoids many cases of potential deadlock. In addition, the performance of <xref:System.Threading.ReaderWriterLockSlim> is significantly better than <xref:System.Threading.ReaderWriterLock>.  
  
## See Also  
 <xref:System.Threading.ReaderWriterLockSlim>  
 <xref:System.Threading.ReaderWriterLock>  
 [Threading](../../../docs/standard/threading/index.md)  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
