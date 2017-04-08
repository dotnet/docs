---
title: "How to: Use Finally Blocks | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
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
---
# How to: Use Finally Blocks
When an exception occurs, execution stops and control is given to the closest exception handler. This often means that lines of code you expect to always be called are not executed. Some resource cleanup, such as closing a file, must always be executed even if an exception is thrown. To accomplish this, you can use a finally block. A finally block is always executed, regardless of whether an exception is thrown.  
  
 The following code example uses a try/catch block to catch an <xref:System.ArgumentOutOfRangeException>. The `Main` method creates two arrays and attempts to copy one to the other. The action generates an **ArgumentOutOfRangeException** and the error is written to the console. The finally block executes regardless of the outcome of the copy action.  
  
## Example  
 [!code-cpp[CodeTryCatchFinallyExample#3](../../../samples/snippets/cpp/VS_Snippets_CLR/CodeTryCatchFinallyExample/CPP/source2.cpp#3)]
 [!code-csharp[CodeTryCatchFinallyExample#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CodeTryCatchFinallyExample/CS/source2.cs#3)]
 [!code-vb[CodeTryCatchFinallyExample#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CodeTryCatchFinallyExample/VB/source2.vb#3)]  
  
## See Also  
    
 [How to: Explicitly Throw Exceptions](../../../docs/standard/exceptions/how-to-explicitly-throw-exceptions.md)   
 [How to: Create User-Defined Exceptions](../../../docs/standard/exceptions/how-to-create-user-defined-exceptions.md)   
 [Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)