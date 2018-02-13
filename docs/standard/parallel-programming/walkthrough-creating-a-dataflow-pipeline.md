---
title: "Walkthrough: Creating a Dataflow Pipeline"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dataflow pipelines, creating with TPL"
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, creating dataflow pipeline"
ms.assetid: 69308f82-aa22-4ac5-833d-e748533b58e8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Walkthrough: Creating a Dataflow Pipeline
Although you can use the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Receive%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Dataflow.DataflowBlock.ReceiveAsync%2A?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.DataflowBlock.TryReceive%2A?displayProperty=nameWithType> methods to receive messages from source blocks, you can also connect message blocks to form a *dataflow pipeline*. A dataflow pipeline is a series of components, or *dataflow blocks*, each of which performs a specific task that contributes to a larger goal. Every dataflow block in a dataflow pipeline performs work when it receives a message from another dataflow block. An analogy to this is an assembly line for automobile manufacturing. As each vehicle passes through the assembly line, one station assembles the frame, the next one installs the engine, and so on. Because an assembly line enables multiple vehicles to be assembled at the same time, it provides better throughput than assembling complete vehicles one at a time.

 This document demonstrates a dataflow pipeline that downloads the book *The Iliad of Homer* from a website and searches the text to match individual words with words that reverse the first word's characters. The formation of the dataflow pipeline in this document consists of the following steps:  
  
1.  Create the dataflow blocks that participate in the pipeline.  
  
2.  Connect each dataflow block to the next block in the pipeline. Each block receives as input the output of the previous block in the pipeline.  
  
3.  For each dataflow block, create a continuation task that sets the next block to the completed state after the previous block finishes.  
  
4.  Post data to the head of the pipeline.  
  
5.  Mark the head of the pipeline as completed.  
  
6.  Wait for the pipeline to complete all work.  
  
## Prerequisites  
 Read [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md) before you start this walkthrough.  
  
## Creating a Console Application  
 In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], create a [!INCLUDE[csprcs](../../../includes/csprcs-md.md)] or [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] Console Application project. Install the System.Threading.Tasks.Dataflow NuGet package.

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]

 Add the following code to your project to create the basic application.  
  
 [!code-csharp[TPLDataflow_Palindromes#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#2)]
 [!code-vb[TPLDataflow_Palindromes#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromesemptymain.vb#2)]  
  
## Creating the Dataflow Blocks  
 Add the following code to the `Main` method to create the dataflow blocks that participate in the pipeline. The table that follows summarizes the role of each member of the pipeline.  
  
 [!code-csharp[TPLDataflow_Palindromes#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#3)]
 [!code-vb[TPLDataflow_Palindromes#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#3)]  
  
|Member|Type|Description|  
|------------|----------|-----------------|  
|`downloadString`|<xref:System.Threading.Tasks.Dataflow.TransformBlock%602>|Downloads the book text from the Web.|  
|`createWordList`|<xref:System.Threading.Tasks.Dataflow.TransformBlock%602>|Separates the book text into an array of words.|  
|`filterWordList`|<xref:System.Threading.Tasks.Dataflow.TransformBlock%602>|Removes short words and duplicates from the word array.|  
|`findReversedWords`|<xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602>|Finds all words in the filtered word array collection whose reverse also occurs in the word array.|  
|`printReversedWords`|<xref:System.Threading.Tasks.Dataflow.ActionBlock%601>|Displays words and the corresponding reverse words to the console.|  
  
 Although you could combine multiple steps in the dataflow pipeline in this example into one step, the example illustrates the concept of composing multiple independent dataflow tasks to perform a larger task. The example uses <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> to enable each member of the pipeline to perform an operation on its input data and send the results to the next step in the pipeline. The `findReversedWords` member of the pipeline is a <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> object because it produces multiple independent outputs for each input. The tail of the pipeline, `printReversedWords`, is an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object because it performs an action on its input, and does not produce a result.  
  
## Forming the Pipeline  
 Add the following code to connect each block to the next block in the pipeline.  
  
 When you call the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.LinkTo%2A> method to connect a source dataflow block to a target dataflow block, the source dataflow block propagates data to the target block as data becomes available. If you also provide <xref:System.Threading.Tasks.Dataflow.DataflowLinkOptions> with <xref:System.Threading.Tasks.Dataflow.DataflowLinkOptions.PropagateCompletion> set to true, successful or unsuccessful completion of one block in the pipeline will cause completion of the next block in the pipeline.
  
 [!code-csharp[TPLDataflow_Palindromes#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#4)]
 [!code-vb[TPLDataflow_Palindromes#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#4)]  
  
## Posting Data to the Pipeline  
 Add the following code to post the URL of the book *The Iliad of Homer* to the head of the dataflow pipeline.  
  
 [!code-csharp[TPLDataflow_Palindromes#6](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#6)]
 [!code-vb[TPLDataflow_Palindromes#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#6)]  
  
 This example uses <xref:System.Threading.Tasks.Dataflow.DataflowBlock.Post%2A?displayProperty=nameWithType> to synchronously send data to the head of the pipeline. Use the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.SendAsync%2A?displayProperty=nameWithType> method when you must asynchronously send data to a dataflow node.  
  
## Completing Pipeline Activity  
 Add the following code to mark the head of the pipeline as completed. The head of the pipeline propagates its completion after it processes all buffered messages.
  
 [!code-csharp[TPLDataflow_Palindromes#7](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#7)]
 [!code-vb[TPLDataflow_Palindromes#7](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#7)]  
  
 This example sends one URL through the dataflow pipeline to be processed. If you send more than one input through a pipeline, call the <xref:System.Threading.Tasks.Dataflow.IDataflowBlock.Complete%2A?displayProperty=nameWithType> method after you submit all the input. You can omit this step if your application has no well-defined point at which data is no longer available or the application does not have to wait for the pipeline to finish.  
  
## Waiting for the Pipeline to Finish  
 Add the following code to wait for the pipeline to finish. The overall operation is finished when the tail of the pipeline finishes.  
  
 [!code-csharp[TPLDataflow_Palindromes#8](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#8)]
 [!code-vb[TPLDataflow_Palindromes#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#8)]  
  
 You can wait for dataflow completion from any thread or from multiple threads at the same time.  
  
## The Complete Example  
 The following example shows the complete code for this walkthrough.  
  
 [!code-csharp[TPLDataflow_Palindromes#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_palindromes/cs/dataflowpalindromes.cs#1)]
 [!code-vb[TPLDataflow_Palindromes#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_palindromes/vb/dataflowpalindromes.vb#1)]  
  
## Next Steps  
 This example sends one URL to process through the dataflow pipeline. If you send more than one input value through a pipeline, you can introduce a form of parallelism into your application that resembles how parts might move through an automobile factory. When the first member of the pipeline sends its result to the second member, it can process another item in parallel as the second member processes the first result.  
  
 The parallelism that is achieved by using dataflow pipelines is known as *coarse-grained parallelism* because it typically consists of fewer, larger tasks. You can also use a more *fine-grained parallelism* of smaller, short-running tasks in a dataflow pipeline. In this example, the `findReversedWords` member of the pipeline uses [PLINQ](parallel-linq-plinq.md) to process multiple items in the work list in parallel. The use of fine-grained parallelism in a coarse-grained pipeline can improve overall throughput.  
  
 You can also connect a source dataflow block to multiple target blocks to create a *dataflow network*. The overloaded version of the <xref:System.Threading.Tasks.Dataflow.DataflowBlock.LinkTo%2A> method takes a <xref:System.Predicate%601> object that defines whether the target block accepts each message based on its value. Most dataflow block types that act as sources offer messages to all connected target blocks, in the order in which they were connected, until one of the blocks accepts that message. By using this filtering mechanism, you can create systems of connected dataflow blocks that direct certain data through one path and other data through another path. For an example that uses filtering to create a dataflow network, see [Walkthrough: Using Dataflow in a Windows Forms Application](../../../docs/standard/parallel-programming/walkthrough-using-dataflow-in-a-windows-forms-application.md).  
  
## See Also  
 [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
