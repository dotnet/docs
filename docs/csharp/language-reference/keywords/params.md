---
description: "params keyword for parameter arrays - C# reference"
title: "params keyword for parameter arrays - C# reference"
ms.date: 07/20/2015
f1_keywords: 
  - "params_CSharpKeyword"
  - "params"
helpviewer_keywords: 
  - "parameters [C#], params"
  - "params keyword [C#]"
  - "parameter array"
ms.assetid: 1690815e-b52b-4967-8380-5780aff08012
---
# params (C# Reference)

By using the `params` keyword, you can specify a [method parameter](method-parameters.md) that takes a variable number of arguments. The parameter type must be a single-dimensional array.

No additional parameters are permitted after the `params` keyword in a method declaration, and only one `params` keyword is permitted in a method declaration.

If the declared type of the `params` parameter is not a single-dimensional array, compiler error [CS0225](../../misc/cs0225.md) occurs.

When you call a method with a `params` parameter, you can pass in:

- A comma-separated list of arguments of the type of the array elements.
- An array of arguments of the specified type.
- No arguments. If you send no arguments, the length of the `params` list is zero.

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
