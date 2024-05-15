---
description: "public keyword - C# Reference"
title: "public keyword"
ms.date: 07/20/2015
f1_keywords:
  - "public"
  - "public_CSharpKeyword"
helpviewer_keywords:
  - "public keyword [C#]"
ms.assetid: 0ae45d16-a551-4b74-9845-57208de1328e
---
# public (C# Reference)

The `public` keyword is an access modifier for types and type members. Public access is the most permissive access level. There are no restrictions on accessing public members, as in this example:

```csharp
class SampleClass
{
    public int x; // No access restrictions.
}
```

See [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md) and [Accessibility Levels](accessibility-levels.md) for more information.

## Example

In the following example, two classes are declared, `PointTest` and `Program`. The public members `x` and `y` of `PointTest` are accessed directly from `Program`.

[!code-csharp[csrefKeywordsModifiers#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#13)]

If you change the `public` access level to [private](private.md) or [protected](protected.md), you will get the error message:

'PointTest.y' is inaccessible due to its protection level.

## C# language specification  

For more information, see [Declared accessibility](~/_csharpstandard/standard/basic-concepts.md#752-declared-accessibility) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [private](private.md)
- [protected](protected.md)
- [internal](internal.md)
