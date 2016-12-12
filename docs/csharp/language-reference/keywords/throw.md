---
title: "throw (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
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
  
 Usually the `throw` statement is used with `try-catch` or `try-finally` statements.  A [throw](../../../csharp/language-reference/keywords/throw.md) statement can be used in a `catch` block to re-throw the exception that the `catch` block caught.  In this case, the [throw](../../../csharp/language-reference/keywords/throw.md) statement does not take an exception operand.  For more information and examples, see [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [How to: Explicitly Throw Exceptions](https://msdn.microsoft.com/library/xhcbs8fz).  
  
## Example  
 This example demonstrates how to throw an exception using the `throw` statement.  
  
 [!code-cs[csrefKeywordsExceptions#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/throw_1.cs)]  
  
## Code Example  
 See the examples in [try-catch](../../../csharp/language-reference/keywords/try-catch.md) and [How to: Explicitly Throw Exceptions](https://msdn.microsoft.com/library/xhcbs8fz).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [try-catch](../../../csharp/language-reference/keywords/try-catch.md)   
 [The try, catch, and throw Statements in C++](../../../csharp/language-reference/keywords/try-catch.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Exception Handling Statements](../../../csharp/language-reference/keywords/exception-handling-statements.md)   
 [How to: Explicitly Throw Exceptions](https://msdn.microsoft.com/library/xhcbs8fz)