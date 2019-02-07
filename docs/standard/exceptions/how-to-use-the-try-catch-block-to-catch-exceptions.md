---
title: "How to: Use the Try-Catch Block to Catch Exceptions"
ms.date: "02/06/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "exceptions, try/catch blocks"
  - "try blocks"
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: a3ce6dfd-1f64-471b-8ad8-8cfaf406275d
author: "mairaw"
ms.author: "mairaw"
---
# How to use the try/catch block to catch exceptions

Any code statements that might raise or throw an exception are placed in a `try` block and statements used to handle the exception are set in a `catch` block, below the `try` block. The `catch` block must include the exception type and can contain additional blocks per each exception type handled.

In the following example, the <xref:System.IO.StreamReader> statement opens a file called *data.txt* and writes a string from the file. Since the code might throw an exception, it's placed in a `try` block. Next, a `catch` block placed to catch the exception and handles it by printing the results to console.

 <!--[!code-cpp[CatchException#3](../../../samples/snippets/cpp/VS_Snippets_CLR/CatchException/CPP/catchexception2.cpp#3)]-->
 [!code-csharp[CatchException#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CatchException/CS/catchexception2.cs#3)]
 [!code-vb[CatchException#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CatchException/VB/catchexception2.vb#3)]  

The Common Language Runtime (CLR) will catch exceptions missed by `catch` blocks. If an exception is caught by the CLR, one of the following results may occur depending on your CLR configuration:

- a **Debug** dialog box will appear
- the program will stop execution and a dialog box with exception information will appear
- an error will print out to STDERR

> [!NOTE]
> Most code can cause an exception and some exceptions, like <xref:System.OutOfMemoryException>, are thrown by the CLR itself. While applications aren't required to deal with these exceptions, be aware of the possibility when writing libraries to be used by others. For suggestions on when to set code in a `try` block, see [Best Practices for Exceptions](best-practices-for-exceptions.md).

## See also

- [Exceptions](index.md)
