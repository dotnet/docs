---
title: "throw (C# Reference) | Microsoft Docs"
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
  - "throw"
  - "throw_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "throw statement [C#]"
  - "throw keyword [C#]"
ms.assetid: 5ac4feef-4b1a-4c61-aeb4-61d549e5dd42
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# throw (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `throw` statement is used to signal the occurrence of an anomalous situation (exception) during the program execution.  
  
## Remarks  
 The thrown exception is an object whose class is derived from <xref:System.Exception?displayProperty=fullName>, as shown in the following example.  
  
```  
class MyException : System.Exception {}  
// ...  
throw new MyException();  
```  
  
 Usually the `throw` statement is used with `try-catch` or `try-finally` statements.  A [throw](../../../csharp/language-reference/keywords/throw.md) statement can be used in a `catch` block to re-throw the exception that the `catch` block caught.  In this case, the [throw](../../../csharp/language-reference/keywords/throw.md) statement does not take an exception operand.  For more information and examples, see [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md).  
  
## Example  
 This example demonstrates how to throw an exception using the `throw` statement.  
  
 [!code-csharp[csrefKeywordsExceptions#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsExceptions/CS/csrefKeywordsExceptions.cs#5)]  
  
## Code Example  
 See the examples in [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [try-catch](../../../csharp/language-reference/keywords/try-catch.md)   
 [The try, catch, and throw Statements in C++](../../../csharp/language-reference/keywords/try-catch.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Exception Handling Statements](../../../csharp/language-reference/keywords/exception-handling-statements.md)   
 [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md)