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
# try-catch-finally (C# Reference)
A common usage of `catch` and `finally` together is to obtain and use resources in a `try` block, deal with exceptional circumstances in a `catch` block, and release the resources in the `finally` block.  
  
 For more information and examples on re-throwing exceptions, see [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [Throwing Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md). For more information about the `finally` block, see [try-finally](../../../csharp/language-reference/keywords/try-finally.md).  
  
## Example  
 [!code-cs[csrefKeywordsExceptions#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/try-catch-finally_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [try, throw, and catch Statements (C++)](/visual-cpp/cpp/try-throw-and-catch-statements-cpp)   
 [Exception Handling Statements](../../../csharp/language-reference/keywords/exception-handling-statements.md)   
 [throw](../../../csharp/language-reference/keywords/throw.md)   
 [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md)   
 [using Statement](../../../csharp/language-reference/keywords/using-statement.md)