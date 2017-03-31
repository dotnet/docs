---
title: "How to: Use the Try-Catch Block to Catch Exceptions | Microsoft Docs"
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
  - "try blocks"
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: a3ce6dfd-1f64-471b-8ad8-8cfaf406275d
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# How to: Use the Try-Catch Block to Catch Exceptions
Place the sections of code that might throw exceptions in a try block and place code that handles exceptions in a catch block. The catch block is a series of statements beginning with the keyword **catch**, followed by an exception type and an action to be taken.  
  
> [!NOTE]
>  Almost any line of code can cause an exception, particularly exceptions that are thrown by the common language runtime itself, such as <xref:System.OutOfMemoryException> and <xref:System.StackOverflowException>. Most applications do not have to deal with these exceptions, but you should be aware of this possibility when writing libraries to be used by others. For suggestions on when to set code in a try block, see [Best Practices for Handling Exceptions](../../../docs/standard/exceptions/best-practices-for-exceptions.md).  
  
 The following code example uses a try/catch block to catch a possible exception. The `Main` method contains a try block with a **StreamReader** statement that opens a data file called `data.txt` and writes a string from the file. Following the try block is a catch block that catches any exception that results from the try block.  
  
## Example  
 [!code-cpp[CatchException#3](../../../samples/snippets/cpp/VS_Snippets_CLR/CatchException/CPP/catchexception2.cpp#3)]
 [!code-csharp[CatchException#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CatchException/CS/catchexception2.cs#3)]
 [!code-vb[CatchException#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CatchException/VB/catchexception2.vb#3)]  
  
 This example illustrates a basic catch statement that will catch any exception. In general, it is good programming practice to catch a specific type of exception rather than use the basic catch statement. For more information about catching specific exceptions, see [Using Specific Exceptions in a Catch Block](../../../docs/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block.md).  
  
## See Also  
 [How to: Use Specific Exceptions in a Catch Block](../../../docs/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block.md)   
 [How to: Explicitly Throw Exceptions](../../../docs/standard/exceptions/how-to-explicitly-throw-exceptions.md)   
 [How to: Create User-Defined Exceptions](../../../docs/standard/exceptions/how-to-create-user-defined-exceptions.md)   
 [How to: Use Finally Blocks](../../../docs/standard/exceptions/how-to-use-finally-blocks.md)   
 [Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)