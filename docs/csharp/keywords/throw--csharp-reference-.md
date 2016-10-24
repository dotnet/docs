---
title: "throw (C# Reference)"
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
# throw (C# Reference)
The `throw` statement is used to signal the occurrence of an anomalous situation (exception) during the program execution.  
  
## Remarks  
 The thrown exception is an object whose class is derived from <xref:System.Exception?displayProperty=fullName>, as shown in the following example.  
  
```  
class MyException : System.Exception {}  
// ...  
throw new MyException();  
```  
  
 Usually the `throw` statement is used with `try-catch` or `try-finally` statements.  A [throw](../keywords/throw--csharp-reference-.md) statement can be used in a `catch` block to re-throw the exception that the `catch` block caught.  In this case, the [throw](../keywords/throw--csharp-reference-.md) statement does not take an exception operand.  For more information and examples, see [try-catch](../keywords/try-catch--csharp-reference-.md) and [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md).  
  
## Example  
 This example demonstrates how to throw an exception using the `throw` statement.  
  
 [!code[csrefKeywordsExceptions#5](../keywords/codesnippet/CSharp/throw--csharp-reference-_1.cs)]  
  
## Code Example  
 See the examples in [try-catch](../keywords/try-catch--csharp-reference-.md) and [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [try-catch](../keywords/try-catch--csharp-reference-.md)   
 [The try, catch, and throw Statements in C++](../keywords/try-catch--csharp-reference-.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Exception Handling Statements](../keywords/exception-handling-statements--csharp-reference-.md)   
 [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md)