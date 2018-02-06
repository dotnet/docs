---
title: "How to: Use Specific Exceptions in a Catch Block"
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
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: 12af9ff3-8587-4f31-90cf-6c2244e0fdae
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to use specific exceptions in a catch block

In general, it's good programming practice to catch a specific type of exception rather than use a basic `catch` statement.

When an exception occurs, it is passed up the stack and each catch block is given the opportunity to handle it. The order of catch statements is important. Put catch blocks targeted to specific exceptions before a general exception catch block or the compiler might issue an error. The proper catch block is determined by matching the type of the exception to the name of the exception specified in the catch block. If there is no specific catch block, the exception is caught by a general catch block, if one exists.

The following code example uses a `try`/`catch` block to catch an <xref:System.InvalidCastException>. The sample creates a class called `Employee` with a single property, employee level (`Emlevel`). A method, `PromoteEmployee`, takes an object and increments the employee level. An <xref:System.InvalidCastException> occurs when a <xref:System.DateTime> instance is passed to the `PromoteEmployee` method.

[!code-cpp[CatchException#2](../../../samples/snippets/cpp/VS_Snippets_CLR/CatchException/CPP/catchexception1.cpp#2)]
[!code-csharp[CatchException#2](../../../samples/snippets/csharp/VS_Snippets_CLR/CatchException/CS/catchexception1.cs#2)]
[!code-vb[CatchException#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CatchException/VB/catchexception1.vb#2)] 

## See Also  
[Exceptions](index.md)
