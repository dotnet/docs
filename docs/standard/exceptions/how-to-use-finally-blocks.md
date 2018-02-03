---
title: "How to: Use Finally Blocks"
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
  - "cpp"
helpviewer_keywords: 
  - "exceptions, try/catch blocks"
  - "exceptions, finally blocks"
  - "try/catch blocks"
  - "finally blocks"
  - "ArgumentOutOfRangeException class"
ms.assetid: 4b9c0137-04af-4468-91d1-b9014df8ddd2
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to use finally blocks

When an exception occurs, execution stops and control is given to the appropriate exception handler. This often means that lines of code you expect to be executed are bypassed. Some resource cleanup, such as closing a file, needs to be done even if an exception is thrown. To do this, you can use a `finally` block. A `finally` block always executes, regardless of whether an exception is thrown.

The following code example uses a `try`/`catch` block to catch an <xref:System.ArgumentOutOfRangeException>. The `Main` method creates two arrays and attempts to copy one to the other. The action generates an <xref:System.ArgumentOutOfRangeException> and the error is written to the console. The `finally` block executes regardless of the outcome of the copy action.

[!code-cpp[CodeTryCatchFinallyExample#3](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeTryCatchFinallyExample/CPP/source2.cpp#3)]
[!code-csharp[CodeTryCatchFinallyExample#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeTryCatchFinallyExample/CS/source2.cs#3)]
[!code-vb[CodeTryCatchFinallyExample#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeTryCatchFinallyExample/VB/source2.vb#3)]  

## See Also  
[Exceptions](index.md)   
