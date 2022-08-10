---
title: "How to: Return a Value from a Task"
description: See how to use the System.Threading.Tasks.Task<TResult> type to return a value from the Result property in .NET.
ms.date: "08/10/2022"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, how to return a value"
ms.assetid: c4bc0f44-eba2-4e96-9e03-1cc787461e61
---
# How to: Return a Value from a Task

This example shows how to use the <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> class to return a value from the <xref:System.Threading.Tasks.Task%601.Result%2A> property. To use this example, you must ensure that the *C:\Users\Public\Pictures\Sample Pictures* directory exists and that it contains files.  
  
## Example  

 [!code-csharp[TPL#10](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl/cs/returnavalue10.cs#10)]
 [!code-vb[TPL#10](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl/vb/10_returnavalue.vb#10)]  
  
 The <xref:System.Threading.Tasks.Task%601.Result%2A> property blocks the calling thread until the task finishes.  
  
To see how to pass the result of a <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType> class to a continuation task, see [Chaining Tasks by Using Continuation Tasks](chaining-tasks-by-using-continuation-tasks.md).  
  
## See also

- [Task-based Asynchronous Programming](task-based-asynchronous-programming.md)
- [Lambda Expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md)
