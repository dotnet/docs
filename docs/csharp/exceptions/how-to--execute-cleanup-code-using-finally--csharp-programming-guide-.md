---
title: "How to: Execute Cleanup Code Using finally (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "try/finally blocks [C#]"
  - "exceptions [C#], try/finally block"
  - "exception handling [C#], try/finally block"
ms.assetid: 1b1e5aef-3f32-4a88-9d39-b5fffb33bdaf
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Execute Cleanup Code Using finally (C# Programming Guide)
The purpose of a `finally` statement is to ensure that the necessary cleanup of objects, usually objects that are holding external resources, occurs immediately, even if an exception is thrown. One example of such cleanup is calling <xref:System.IO.Stream.Close*> on a <xref:System.IO.FileStream> immediately after use instead of waiting for the object to be garbage collected by the common language runtime, as follows:  
  
 [!code[csProgGuideExceptions#16](../exceptions/codesnippet/CSharp/how-to--execute-cleanup-code-using-finally--csharp-programming-guide-_1.cs)]  
  
## Example  
 To turn the previous code into a `try-catch-finally` statement, the cleanup code is separated from the working code, as follows.  
  
 [!code[csProgGuideExceptions#17](../exceptions/codesnippet/CSharp/how-to--execute-cleanup-code-using-finally--csharp-programming-guide-_2.cs)]  
  
 Because an exception can occur at any time within the `try` block before the `OpenWrite()` call, or the `OpenWrite()` call itself could fail, we are not guaranteed that the file is open when we try to close it. The `finally` block adds a check to make sure that the <xref:System.IO.FileStream> object is not `null` before you call the <xref:System.IO.Stream.Close*> method. Without the `null` check, the `finally` block could throw its own <xref:System.NullReferenceException>, but throwing exceptions in `finally` blocks should be avoided if it is possible.  
  
 A database connection is another good candidate for being closed in a `finally` block. Because the number of connections allowed to a database server is sometimes limited, you should close database connections as quickly as possible. If an exception is thrown before you can close your connection, this is another case where using the `finally` block is better than waiting for garbage collection.  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Exceptions and Exception Handling](../exceptions/exceptions-and-exception-handling--csharp-programming-guide-.md)   
 [Exception Handling](../exceptions/exception-handling--csharp-programming-guide-.md)   
 [using Statement](../keywords/using-statement--csharp-reference-.md)   
 [try-catch](../keywords/try-catch--csharp-reference-.md)   
 [try-finally](../keywords/try-finally--csharp-reference-.md)   
 [try-catch-finally](../keywords/try-catch-finally--csharp-reference-.md)