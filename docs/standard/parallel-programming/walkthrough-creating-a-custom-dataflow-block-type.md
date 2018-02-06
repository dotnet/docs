---
title: "Walkthrough: Creating a Custom Dataflow Block Type"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, creating custom dataflow blocks"
  - "dataflow blocks, creating custom in TPL"
ms.assetid: a6147146-0a6a-4d9b-ab0f-237b3c1ac691
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Walkthrough: Creating a Custom Dataflow Block Type
Although the TPL Dataflow Library provides several dataflow block types that enable a variety of functionality, you can also create custom block types. This document describes how to create a dataflow block type that implements custom behavior.  
  
## Prerequisites  
 Read [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md) before you read this document.  

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]
  
## Defining the Sliding Window Dataflow Block  
 Consider a dataflow application that requires that input values be buffered and then output in a sliding window manner. For example, for the input values {0, 1, 2, 3, 4, 5} and a window size of three, a sliding window dataflow block produces the output arrays {0, 1, 2}, {1, 2, 3}, {2, 3, 4}, and {3, 4, 5}. The following sections describe two ways to create a dataflow block type that implements this custom behavior. The first technique uses the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Encapsulate%2A> method to combine the functionality of an <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601> object and an <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601> object into one propagator block. The second technique defines a class that derives from <xref:System.Threading.Tasks.Dataflow.IPropagatorBlock%602> and combines existing functionality to perform custom behavior.  
  
## Using the Encapsulate Method to Define the Sliding Window Dataflow Block  
 The following example uses the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Encapsulate%2A> method to create a propagator block from a target and a source. A propagator block enables a source block and a target block to act as a receiver and sender of data.  
  
 This technique is useful when you require custom dataflow functionality, but you do not require a type that provides additional methods, properties, or fields.  
  
 [!code-csharp[TPLDataflow_SlidingWindowBlock#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_slidingwindowblock/cs/slidingwindowblock.cs#1)]
 [!code-vb[TPLDataflow_SlidingWindowBlock#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_slidingwindowblock/vb/slidingwindowblock.vb#1)]  
  
## Deriving from IPropagatorBlock to Define the Sliding Window Dataflow Block  
 The following example shows the `SlidingWindowBlock` class. This class derives from <xref:System.Threading.Tasks.Dataflow.IPropagatorBlock%602> so that it can act as both a source and a target of data. As in the previous example, the `SlidingWindowBlock` class is built on existing dataflow block types. However, the `SlidingWindowBlock` class also implements the methods that are required by the <xref:System.Threading.Tasks.Dataflow.ISourceBlock%601>, <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601>, and <xref:System.Threading.Tasks.Dataflow.IDataflowBlock> interfaces. These methods all forward work to the predefined dataflow block type members. For example, the `Post` method defers work to the `m_target` data member, which is also an <xref:System.Threading.Tasks.Dataflow.ITargetBlock%601> object.  
  
 This technique is useful when you require custom dataflow functionality, and also require a type that provides additional methods, properties, or fields. For example, the `SlidingWindowBlock` class also derives from <xref:System.Threading.Tasks.Dataflow.IReceivableSourceBlock%601> so that it can provide the <xref:System.Threading.Tasks.Dataflow.IReceivableSourceBlock%601.TryReceive%2A> and <xref:System.Threading.Tasks.Dataflow.IReceivableSourceBlock%601.TryReceiveAll%2A> methods. The `SlidingWindowBlock` class also demonstrates extensibility by providing the `WindowSize` property, which retrieves the number of elements in the sliding window.  
  
 [!code-csharp[TPLDataflow_SlidingWindowBlock#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_slidingwindowblock/cs/slidingwindowblock.cs#2)]
 [!code-vb[TPLDataflow_SlidingWindowBlock#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_slidingwindowblock/vb/slidingwindowblock.vb#2)]  
  
## The Complete Example  
 The following example shows the complete code for this walkthrough. It also demonstrates how to use the both sliding window blocks in a method that writes to the block, reads from it, and prints the results to the console.  
  
 [!code-csharp[TPLDataflow_SlidingWindowBlock#100](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_slidingwindowblock/cs/slidingwindowblock.cs#100)]
 [!code-vb[TPLDataflow_SlidingWindowBlock#100](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_slidingwindowblock/vb/slidingwindowblock.vb#100)]  
  
## Compiling the Code  
 Copy the example code and paste it in a Visual Studio project, or paste it in a file that is named `SlidingWindowBlock.cs` (`SlidingWindowBlock.vb` for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) and then run the following command in a Visual Studio Command Prompt window.  
  
 [!INCLUDE[csprcs](../../../includes/csprcs-md.md)]  
  
 **csc.exe /r:System.Threading.Tasks.Dataflow.dll SlidingWindowBlock.cs**  
  
 [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]  
  
 **vbc.exe /r:System.Threading.Tasks.Dataflow.dll SlidingWindowBlock.vb**  

## See Also  
 [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
