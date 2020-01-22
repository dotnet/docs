---
title: "protected keyword - C# Reference"
ms.date: 07/20/2015
f1_keywords:
  - "protected"
  - "protected_CSharpKeyword"
helpviewer_keywords:
  - "protected keyword [C#]"
ms.assetid: 05ce3794-6675-4025-bddb-eaaa0ec22892
---
# protected (C# Reference)

The `protected` keyword is a member access modifier.

 > This page covers `protected` access. The `protected` keyword is also part of the [`protected internal`](protected-internal.md) and [`private protected`](private-protected.md) access modifiers.

A protected member is accessible within its class and by derived class instances.

For a comparison of `protected` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

## Example

A protected member of a base class is accessible in a derived class only if the access occurs through the derived class type. For example, consider the following code segment:

[!code-csharp[csrefKeywordsModifiers#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#11)]

The statement `a.x = 10` generates an error because it is made within the static method Main, and not an instance of class B.

Struct members cannot be protected because the struct cannot be inherited.

## Example

In this example, the class `DerivedPoint` is derived from `Point`. Therefore, you can access the protected members of the base class directly from the derived class.

[!code-csharp[csrefKeywordsModifiers#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#12)]  

If you change the access levels of `x` and `y` to [private](private.md), the compiler will issue the error messages:

`'Point.y' is inaccessible due to its protection level.`

`'Point.x' is inaccessible due to its protection level.`

## C# language specification  

For more information, see [Declared accessibility](~/_csharplang/spec/basic-concepts.md#declared-accessibility) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [private](private.md)
- [internal](internal.md)
- [Security concerns for internal virtual keywords](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/heyd8kky(v=vs.100))
