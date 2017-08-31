---
title: "try-catch-finally (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "catch-finally_CSharpKeyword"
  - "catch-finally"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "finally blocks [C#]"
  - "try-catch statement [C#]"
ms.assetid: a1b443b0-ff7a-43ab-b835-0cc9bfbd15ca
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# try-catch-finally (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A common usage of `catch` and `finally` together is to obtain and use resources in a `try` block, deal with exceptional circumstances in a `catch` block, and release the resources in the `finally` block.  
  
 For more information and examples on re-throwing exceptions, see [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [Throwing Exceptions](~/docs/standard/exceptions/how-to-explicitly-throw-exceptions.md). For more information about the `finally` block, see [try-finally](../../../csharp/language-reference/keywords/try-finally.md).  
  
## Example  
 [!code-csharp[csrefKeywordsExceptions#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsExceptions/CS/csrefKeywordsExceptions.cs#1)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [try, throw, and catch Statements (C++)](/visual-cpp/cpp/try-throw-and-catch-statements-cpp)   
 [Exception Handling Statements](../../../csharp/language-reference/keywords/exception-handling-statements.md)   
 [throw](../../../csharp/language-reference/keywords/throw.md)   
 [How to: Explicitly Throw Exceptions](~/docs/standard/exceptions/how-to-explicitly-throw-exceptions.md)   
 [using Statement](../../../csharp/language-reference/keywords/using-statement.md)