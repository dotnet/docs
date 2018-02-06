---
title: "How to: Synchronize Concurrent Operations with a Barrier"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Barrier, how to use"
ms.assetid: e1a253ff-e0fb-4df8-95ff-d01a90d4cb19
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Synchronize Concurrent Operations with a Barrier
The following example shows how to synchronize concurrent tasks with a <xref:System.Threading.Barrier>.  
  
## Example  
 The purpose of the following program is to count how many iterations (or phases) are required for two threads to each find their half of the solution on the same phase by using a randomizing algorithm to reshuffle the words. After each thread has shuffled its words, the barrier post-phase operation compares the two results to see if the complete sentence has been rendered in correct word order.  
  
 [!code-csharp[CDS_Barrier#01](../../../samples/snippets/csharp/VS_Snippets_Misc/cds_barrier/cs/barrier.cs#01)]
 [!code-vb[CDS_Barrier#01](../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_barrier/vb/barrier_vb.vb#01)]  
  
 A <xref:System.Threading.Barrier> is an object that prevents individual tasks in a parallel operation from continuing until all tasks reach the barrier. It is useful when a parallel operation occurs in phases, and each phase requires synchronization between tasks. In this example, there are two phases to the operation. In the first phase, each task fills its section of the buffer with data. When each task finishes filling its section, the task signals the barrier that it is ready to continue, and then waits. When all tasks have signaled the barrier, they are unblocked and the second phase starts. The barrier is necessary because the second phase requires that each task have access to all the data that has been generated to this point. Without the barrier, the first tasks to complete might try to read from buffers that have not been filled in yet by other tasks. You can synchronize any number of phases in this manner.  
  
## See Also  
 [Data Structures for Parallel Programming](../../../docs/standard/parallel-programming/data-structures-for-parallel-programming.md)
