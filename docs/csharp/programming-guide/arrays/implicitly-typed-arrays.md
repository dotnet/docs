---
title: "Implicitly Typed Arrays - C# Programming Guide"
description: The type of an implicitly-typed array in C# is inferred from the elements in the array initializer. Use implicitly-typed arrays in query expressions.
ms.date: 07/20/2015
helpviewer_keywords:
  - "arrays [C#], implicitly-typed"
  - "implicitly-typed arrays [C#]"
  - "C# language, implicitly typed arrays"
ms.assetid: e05be95c-6732-403d-ae42-b35f057cbbea
---

# Implicitly Typed Arrays (C# Programming Guide)

You can create an implicitly-typed array in which the type of the array instance is inferred from the elements specified in the array initializer. The rules for any implicitly-typed variable also apply to implicitly-typed arrays. For more information, see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables.md).

Implicitly-typed arrays are usually used in query expressions together with anonymous types and object and collection initializers.

The following examples show how to create an implicitly-typed array:

[!code-csharp[csProgGuideLINQ#37](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#37)]

In the previous example, notice that with implicitly-typed arrays, no square brackets are used on the left side of the initialization statement. Note also that jagged arrays are initialized by using `new []` just like single-dimension arrays.

## Implicitly-typed Arrays in Object Initializers

When you create an anonymous type that contains an array, the array must be implicitly typed in the type's object initializer. In the following example, `contacts` is an implicitly-typed array of anonymous types, each of which contains an array named `PhoneNumbers`. Note that the `var` keyword is not used inside the object initializers.

[!code-csharp[csProgGuideLINQ#38](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#38)]

## See also

- [C# Programming Guide](../index.md)
- [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables.md)
- [Arrays](./index.md)
- [Anonymous Types](../../fundamentals/types/anonymous-types.md)
- [Object and Collection Initializers](../classes-and-structs/object-and-collection-initializers.md)
- [var](../../language-reference/keywords/var.md)
- [LINQ in C#](../../linq/index.md)
