---
title: "params keyword (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "params_CSharpKeyword"
  - "params"
helpviewer_keywords: 
  - "parameters [C#], params"
  - "params keyword [C#]"
ms.assetid: 1690815e-b52b-4967-8380-5780aff08012
---
# params (C# Reference)

By using the `params` keyword, you can specify a [method parameter](method-parameters.md) that takes a variable number of arguments.

You can send a comma-separated list of arguments of the type specified in the parameter declaration or an array of arguments of the specified type. You also can send no arguments. If you send no arguments, the length of the `params` list is zero.

No additional parameters are permitted after the `params` keyword in a method declaration, and only one `params` keyword is permitted in a method declaration.

The declared type of the `params` parameter must be a single-dimensional array, as the following example shows. Otherwise, a compiler error [CS0225](../../misc/cs0225.md) occurs.

## Example

The following example demonstrates various ways in which arguments can be sent to a `params` parameter.

[!code-csharp[csrefKeywordsMethodParams#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#5)] 

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Method Parameters](method-parameters.md)