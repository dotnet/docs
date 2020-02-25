---
title: "How to: Perform Action When a Dataflow Block Receives Data"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, receiving data"
ms.assetid: fc2585dc-965e-4632-ace7-73dd02684ed3
---
# How to: Perform Action When a Dataflow Block Receives Data
*Execution dataflow block* types call a user-provided delegate when they receive data. The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602?displayProperty=nameWithType> classes are execution dataflow block types. You can use the `delegate` keyword (`Sub` in Visual Basic), <xref:System.Action%601>, <xref:System.Func%602>, or a lambda expression when you provide a work function to an execution dataflow block. This document describes how to use <xref:System.Func%602> and lambda expressions to perform action in execution blocks.  

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]

## Example  
 The following example uses dataflow to read a file from disk and computes the number of bytes in that file that are equal to zero. It uses <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> to read the file and compute the number of zero bytes, and <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> to print the number of zero bytes to the console. The <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object specifies a <xref:System.Func%602> object to perform work when the blocks receive data. The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object uses a lambda expression to print to the console the number of zero bytes that are read.  
  
 [!code-csharp[TPLDataflow_ExecutionBlocks#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_executionblocks/cs/dataflowexecutionblocks.cs#1)]
 [!code-vb[TPLDataflow_ExecutionBlocks#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_executionblocks/vb/dataflowexecutionblocks.vb#1)]  
  
 Although you can provide a lambda expression to a <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object, this example uses <xref:System.Func%602> to enable other code to use the `CountBytes` method. The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object uses a lambda expression because the work to be performed is specific to this task and is not likely to be useful from other code. For more information about how lambda expressions work in the Task Parallel Library, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
 The section Summary of Delegate Types in the [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md) document summarizes the delegate types that you can provide to <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602> objects. The table also specifies whether the delegate type operates synchronously or asynchronously.  
  
## Robust Programming  
 This example provides a delegate of type <xref:System.Func%602> to the <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object to perform the task of the dataflow block synchronously. To enable the dataflow block to behave asynchronously, provide a delegate of type <xref:System.Func%601> to the dataflow block. When a dataflow block behaves asynchronously, the task of the dataflow block is complete only when the returned <xref:System.Threading.Tasks.Task%601> object finishes. The following example modifies the `CountBytes` method and uses the [async](../../csharp/language-reference/keywords/async.md) and [await](../../csharp/language-reference/operators/await.md) operators ([Async](../../visual-basic/language-reference/modifiers/async.md) and [Await](../../visual-basic/language-reference/operators/await-operator.md) in Visual Basic) to asynchronously compute the total number of bytes that are zero in the provided file. The <xref:System.IO.FileStream.ReadAsync%2A> method performs file read operations asynchronously.  
  
 [!code-csharp[TPLDataflow_ExecutionBlocks#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_executionblocks/cs/dataflowexecutionblocks.cs#2)]
 [!code-vb[TPLDataflow_ExecutionBlocks#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_executionblocks/vb/dataflowexecutionblocks.vb#2)]  
  
 You can also use asynchronous lambda expressions to perform action in an execution dataflow block. The following example modifies the <xref:System.Threading.Tasks.Dataflow.TransformBlock%602> object that is used in the previous example so that it uses a lambda expression to perform the work asynchronously.  
  
 [!code-csharp[TPLDataflow_ExecutionBlocks#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_executionblocks/cs/dataflowexecutionblocks.cs#3)]
 [!code-vb[TPLDataflow_ExecutionBlocks#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_executionblocks/vb/dataflowexecutionblocks.vb#3)]  
  
## See also

- [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
