---
title: "How to: Use the Try-Catch Block to Catch Exceptions"
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
  - "try blocks"
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: a3ce6dfd-1f64-471b-8ad8-8cfaf406275d
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to use the try/catch block to catch exceptions

Place the sections of code that might throw exceptions in a `try` block and place code that handles exceptions in a `catch` block. The `catch` block is a series of statements beginning with the keyword `catch`, followed by an exception type and an action to be taken.

The following code example uses a `try`/`catch` block to catch a possible exception. The `Main` method contains a `try` block with a <xref:System.IO.StreamReader> statement that opens a data file called `data.txt` and writes a string from the file. Following the `try` block is a `catch` block that catches any exception that results from the `try` block.

 [!code-cpp[CatchException#3](../../../samples/snippets/cpp/VS_Snippets_CLR/CatchException/CPP/catchexception2.cpp#3)]
 [!code-csharp[CatchException#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CatchException/CS/catchexception2.cs#3)]
 [!code-vb[CatchException#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CatchException/VB/catchexception2.vb#3)]  

The common language runtime catches exceptions that are not caught by a catch block. Depending on how the runtime is configured, a debug dialog box appears, or the program stops executing and a dialog box with exception information appears, or an error is printed out to STDERR.

> [!NOTE] 
> Almost any line of code can cause an exception, particularly exceptions that are thrown by the common language runtime itself, such as <xref:System.OutOfMemoryException>. Most applications don't have to deal with these exceptions, but you should be aware of this possibility when writing libraries to be used by others. For suggestions on when to set code in a Try block, see [Best Practices for Exceptions](best-practices-for-exceptions.md).

## See Also  
[Exceptions](index.md)
