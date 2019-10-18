---
title: "Anonymous functions - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "lambda expressions [C#], as anonymous functions"
  - "anonymous functions [C#]"
  - "anonymous methods [C#]"
ms.assetid: 6ce3f04d-0c71-4728-9127-634c7e9a8365
---
# Anonymous functions (C# Programming Guide)

An anonymous function is an "inline" statement or expression that can be used wherever a delegate type is expected. You can use it to initialize a named delegate or pass it instead of a named delegate type as a method parameter.

You can use a [lambda expression](lambda-expressions.md) or an [anonymous method](../../language-reference/operators/delegate-operator.md) to create an anonymous function. We recommend using lambda expressions as they provide more concise and expressive way to write inline code. Unlike anonymous methods, some types of lambda expressions can be converted to the expression tree types.

## The Evolution of Delegates in C\#

 In C# 1.0, you created an instance of a delegate by explicitly initializing it with a method that was defined elsewhere in the code. C# 2.0 introduced the concept of anonymous methods as a way to write unnamed inline statement blocks that can be executed in a delegate invocation. C# 3.0 introduced lambda expressions, which are similar in concept to anonymous methods but more expressive and concise. These two features are known collectively as *anonymous functions*. In general, applications that target version 3.5 and later of the .NET Framework should use lambda expressions.  
  
 The following example demonstrates the evolution of delegate creation from C# 1.0 to C# 3.0:  
  
 [!code-csharp[csProgGuideLINQ#65](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#65)]  
  
## C# language specification

For more information, see the [Anonymous function expressions](~/_csharplang/spec/expressions.md#anonymous-function-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).
  
## See also

- [Statements, Expressions, and Operators](./index.md)
- [Lambda Expressions](./lambda-expressions.md)
- [Delegates](../delegates/index.md)
- [Expression Trees (C#)](../concepts/expression-trees/index.md)
