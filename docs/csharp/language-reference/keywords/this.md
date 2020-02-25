---
title: "this keyword - C# Reference"
description: this keyword (C# Reference)
ms.date: 07/20/2015
f1_keywords: 
  - "this"
  - "this_CSharpKeyword"
helpviewer_keywords: 
  - "this keyword [C#]"
ms.assetid: d4f827fe-4710-410b-89b8-867dad44b8a3
---
# this (C# Reference)

The `this` keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.

> [!NOTE]
> This article discusses the use of `this` with class instances. For more information about its use in extension methods, see [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md).

The following are common uses of `this`:

- To qualify members hidden by similar names, for example:

  [!code-csharp[csrefKeywordsAccess#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#4)]  

- To pass an object as a parameter to other methods, for example:

  ```csharp
  CalcTax(this);
  ```

- To declare indexers, for example:

  [!code-csharp[csrefKeywordsAccess#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#5)]

Static member functions, because they exist at the class level and not as part of an object, do not have a `this` pointer. It is an error to refer to `this` in a static method.

## Example

In this example, `this` is used to qualify the `Employee` class members, `name` and `alias`, which are hidden by similar names. It is also used to pass an object to the method `CalcTax`, which belongs to another class.

[!code-csharp[csrefKeywordsAccess#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#3)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [base](base.md)
- [Methods](../../programming-guide/classes-and-structs/methods.md)
