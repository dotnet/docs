---
title: "How to: Use JoinBlock to Read Data From Multiple Sources"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, joining blocks in"
  - "dataflow blocks, joining in TPL"
ms.assetid: e9c1ada4-ac57-4704-87cb-2f5117f8151d
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Use JoinBlock to Read Data From Multiple Sources
This document explains how to use the <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> class to perform an operation when data is available from multiple sources. It also demonstrates how to use non-greedy mode to enable multiple join blocks to share a data source more efficiently.

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]

## Example  
 The following example defines three resource types, `NetworkResource`, `FileResource`, and `MemoryResource`, and performs operations when resources become available. This example requires a `NetworkResource` and `MemoryResource` pair in order to perform the first operation and a `FileResource` and `MemoryResource` pair in order to perform the second operation. To enable these operations to occur when all required resources are available, this example uses the <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> class. When a <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> object receives data from all sources, it propagates that data to its target, which in this example is an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object. Both <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> objects read from a shared pool of `MemoryResource` objects.  
  
 [!code-csharp[TPLDataflow_NonGreedyJoin#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_nongreedyjoin/cs/nongreedyjoin.cs#1)]
 [!code-vb[TPLDataflow_NonGreedyJoin#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_nongreedyjoin/vb/nongreedyjoin.vb#1)]  
  
 To enable efficient use of the shared pool of `MemoryResource` objects, this example specifies a <xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions> object that has the <xref:System.Threading.Tasks.Dataflow.GroupingDataflowBlockOptions.Greedy%2A> property set to `False` to create <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> objects that act in non-greedy mode. A non-greedy join block postpones all incoming messages until one is available from each source. If any of the postponed messages were accepted by another block, the join block restarts the process. Non-greedy mode enables join blocks that share one or more source blocks to make forward progress as the other blocks wait for data. In this example, if a `MemoryResource` object is added to the `memoryResources` pool, the first join block to receive its second data source can make forward progress. If this example were to use greedy mode, which is the default, one join block might take the `MemoryResource` object and wait for the second resource to become available. However, if the other join block has its second data source available, it cannot make forward progress because the `MemoryResource` object has been taken by the other join block.  
  
## Compiling the Code  
 Copy the example code and paste it in a Visual Studio project, or paste it in a file that is named `DataflowNonGreedyJoin.cs` (`DataflowNonGreedyJoin.vb` for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]), and then run the following command in a Visual Studio Command Prompt window.  
  
 [!INCLUDE[csprcs](../../../includes/csprcs-md.md)]  
  
 **csc.exe /r:System.Threading.Tasks.Dataflow.dll DataflowNonGreedyJoin.cs**  
  
 [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]  
  
 **vbc.exe /r:System.Threading.Tasks.Dataflow.dll DataflowNonGreedyJoin.vb**  
  
## Robust Programming  
 The use of non-greedy joins can also help you prevent deadlock in your application. In a software application, *deadlock* occurs when two or more processes each hold a resource and mutually wait for another process to release some other resource. Consider an application that defines two <xref:System.Threading.Tasks.Dataflow.JoinBlock%602> objects. Both objects each read data from two shared source blocks. In greedy mode, if one join block reads from the first source and the second join block reads from the second source, the application might deadlock because both join blocks mutually wait for the other to release its resource. In non-greedy mode, each join block reads from its sources only when all data is available, and therefore, the risk of deadlock is eliminated.  
  
## See Also  
 [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
