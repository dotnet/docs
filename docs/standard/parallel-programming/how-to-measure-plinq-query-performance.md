---
title: "How to: Measure PLINQ Query Performance"
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
  - "PLINQ queries, how to measure performance"
ms.assetid: 491ba43b-2c10-473d-9aab-e2cb96446711
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Measure PLINQ Query Performance
This example shows how use the <xref:System.Diagnostics.Stopwatch> class to measure the time it takes for a PLINQ query to execute.  
  
## Example  
 This example uses an empty `foreach` loop (`For Each` in Visual Basic) to measure the time it takes for the query to execute. In real-world code, the loop typically contains additional processing steps that add to the total query execution time. Notice that the stopwatch is not started until just before the loop, because that is when the query execution begins. If you require more fine-grained measurement, you can use the `ElapsedTicks` property instead of `ElapsedMilliseconds`.  
  
 [!code-csharp[PLINQ#19](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/measure2.cs#19)]
 [!code-vb[PLINQ#19](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/measure2.vb#19)]  
  
 The total execution time is a useful metric when you are experimenting with query implementations, but it does not always tell the whole story. To get a deeper and richer view of the interaction of the query threads with one another and with other running processes, use the Concurrency Visualizer. For more information, see [Concurrency Visualizer](/visualstudio/profiling/concurrency-visualizer).  
  
## See Also  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)
