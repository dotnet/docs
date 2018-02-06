---
title: "How to: Use Parallel.Invoke to Execute Parallel Operations"
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
  - "task parallelism in .NET"
  - "parallel programming, task parallelism"
ms.assetid: 6b3ecd79-dec9-4ce1-abf4-62e5392a59c6
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Use Parallel.Invoke to Execute Parallel Operations
This example shows how to parallelize operations by using <xref:System.Threading.Tasks.Parallel.Invoke%2A> in the Task Parallel Library. Three operations are performed on a shared data source. Because none of the operations modifies the source, they can be executed in parallel in a straightforward manner.  
  
> [!NOTE]
>  This documentation uses lambda expressions to define delegates in TPL. If you are not familiar with lambda expressions in C# or Visual Basic, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
## Example  
 [!code-csharp[TPL_Parallel#06](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/parallelinvoke.cs#06)]
 [!code-vb[TPL_Parallel#06](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/parallelinvoke.vb#06)]  
  
 Note that with <xref:System.Threading.Tasks.Parallel.Invoke%2A>, you simply express which actions you want to run concurrently, and the runtime handles all thread scheduling details, including scaling automatically to the number of cores on the host computer.  
  
 This example parallelizes the operations, not the data. As an alternate approach, you can parallelize the LINQ queries by using PLINQ and run the queries sequentially. Alternatively, you could parallelize the data by using PLINQ. Another option is to parallelize both the queries and the tasks. Although the resulting overhead might degrade performance on host computers with relatively few processors, it would scale much better on computers with many processors.  
  
## Compiling the Code  
  
-   Copy and paste the entire example into a Microsoft Visual Studio 2010 project and press F5.  
  
## See Also  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)  
 [How to: Cancel a Task and Its Children](../../../docs/standard/parallel-programming/how-to-cancel-a-task-and-its-children.md)  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)
