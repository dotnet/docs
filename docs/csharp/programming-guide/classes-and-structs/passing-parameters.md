---
title: "Passing Parameters - C# Programming Guide"
description: You can pass an argument to a parameter in C# by value or reference. Changes to an argument passed by reference persist. Use ref or out to pass by reference.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "parameters [C#], passing"
  - "passing parameters [C#]"
  - "arguments [C#]"
  - "methods [C#], passing parameters"
  - "C# language, method parameters"
ms.assetid: a5c3003f-7441-4710-b8b1-c79de77e0b77
---
# Passing Parameters (C# Programming Guide)

In C#, arguments can be passed to parameters either by value or by reference. Passing by reference enables function members, methods, properties, indexers, operators, and constructors to change the value of the parameters and have that change persist in the calling environment. To pass a parameter by reference with the intent of changing the value, use the `ref`, or `out` keyword. To pass by reference with the intent of avoiding copying but not changing the value, use the `in` modifier. For simplicity, only the `ref` keyword is used in the examples in this topic. For more information about the difference between `in`, `ref`, and `out`, see [in](../../language-reference/keywords/in-parameter-modifier.md), [ref](../../language-reference/keywords/ref.md), and [out](../../language-reference/keywords/out-parameter-modifier.md).  
  
 The following example illustrates the difference between value and reference parameters.  
  
 [!code-csharp[csProgGuideParameters#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideParameters/CS/Parameters.cs#10)]  
  
 For more information, see the following topics:  
  
- [Passing Value-Type Parameters](./passing-value-type-parameters.md)  
  
- [Passing Reference-Type Parameters](./passing-reference-type-parameters.md)  
  
## C# Language Specification  

For more information, see [Argument lists](~/_csharplang/spec/expressions.md#argument-lists) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.
  
## See also

- [C# Programming Guide](../index.md)
- [Methods](./methods.md)
