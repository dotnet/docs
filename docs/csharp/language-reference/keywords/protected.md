---
description: "protected keyword - C# Reference"
title: "protected keyword"
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

> [!NOTE]
> This page covers `protected` access. The `protected` keyword is also part of the [`protected internal`](protected-internal.md) and [`private protected`](private-protected.md) access modifiers.

A protected member is accessible within its class and by derived class instances.

For a comparison of `protected` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

## Example 1

A protected member of a base class is accessible in a derived class only if the access occurs through the derived class type. For example, consider the following code segment:

[!code-csharp[snippet1](~/docs/csharp/language-reference/keywords/snippets/protected/Example1.cs#snippet1)]

The statement `baseObject.myValue = 10` generates an error because it accesses the protected member through a base class reference (`baseObject` is of type `BaseClass`). Protected members can only be accessed through the derived class type or types derived from it.

Unlike `private protected`, the `protected` access modifier allows access from derived classes **in any assembly**. Unlike `protected internal`, it does **not** allow access from non-derived classes within the same assembly.

Struct members cannot be protected because the struct cannot be inherited.

## Example 2

In this example, the class `DerivedPoint` is derived from `Point`. Therefore, you can access the protected members of the base class directly from the derived class.

[!code-csharp[csrefKeywordsModifiers#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#12)]  

If you change the access levels of `x` and `y` to [private](private.md), the compiler will issue the error messages:

`'Point.y' is inaccessible due to its protection level.`

`'Point.x' is inaccessible due to its protection level.`

## Cross-assembly access

The following example demonstrates that `protected` members are accessible from derived classes even when they're in different assemblies:

[!code-csharp[snippet1](~/docs/csharp/language-reference/keywords/snippets/protected/Assembly1.cs#snippet1)]

[!code-csharp[snippet1](~/docs/csharp/language-reference/keywords/snippets/protected/Assembly2.cs#snippet1)]

This cross-assembly accessibility is what distinguishes `protected` from `private protected` (which restricts access to the same assembly) but is similar to `protected internal` (though `protected internal` also allows same-assembly access from non-derived classes).

## C# language specification  

For more information, see [Declared accessibility](~/_csharpstandard/standard/basic-concepts.md#752-declared-accessibility) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [private](private.md)
- [internal](internal.md)
- [Security concerns for internal virtual keywords](/previous-versions/dotnet/netframework-4.0/heyd8kky(v=vs.100))
