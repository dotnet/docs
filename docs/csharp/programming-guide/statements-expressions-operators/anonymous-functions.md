---
title: "Anonymous Functions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "lambda expressions [C#], as anonymus functions"
  - "anonymous functions [C#]"
  - "anonymous methods [C#]"
ms.assetid: 6ce3f04d-0c71-4728-9127-634c7e9a8365
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# Anonymous Functions (C# Programming Guide)
An anonymous function is an "inline" statement or expression that can be used wherever a delegate type is expected. You can use it to initialize a named delegate or pass it instead of a named delegate type as a method parameter.  
  
 There are two kinds of anonymous functions, which are discussed individually in the following topics:  
  
-   [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md).  
  
-   [Anonymous Methods](../../../csharp/programming-guide/statements-expressions-operators/anonymous-methods.md)  
  
    > [!NOTE]
    >  Lambda expressions can be bound to expression trees and also to delegates.  
  
## The Evolution of Delegates in C#  
 In C# 1.0, you created an instance of a delegate by explicitly initializing it with a method that was defined elsewhere in the code. C# 2.0 introduced the concept of anonymous methods as a way to write unnamed inline statement blocks that can be executed in a delegate invocation. C# 3.0 introduced lambda expressions, which are similar in concept to anonymous methods but more expressive and concise. These two features are known collectively as *anonymous functions*. In general, applications that target version 3.5 and later of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] should use lambda expressions.  
  
 The following example demonstrates the evolution of delegate creation from C# 1.0 to C# 3.0:  
  
 [!code-csharp[csProgGuideLINQ#65](../../../csharp/programming-guide/arrays/codesnippet/CSharp/anonymous-functions_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [Statements, Expressions, and Operators](../../../csharp/programming-guide/statements-expressions-operators/index.md)  
 [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)  
 [Delegates](../../../csharp/programming-guide/delegates/index.md)  
 [Expression Trees](http://msdn.microsoft.com/library/fb1d3ed8-d5b0-4211-a71f-dd271529294b)
