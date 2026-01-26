---
description: "protected keyword - C# Reference"
title: "protected keyword"
ms.date: 01/22/2026
f1_keywords:
  - "protected"
  - "protected_CSharpKeyword"
helpviewer_keywords:
  - "protected keyword [C#]"
---
# protected (C# Reference)

The `protected` keyword is a member access modifier.

> [!NOTE]
> This article covers `protected` access. The `protected` keyword is also part of the [`protected internal`](protected-internal.md) and [`private protected`](private-protected.md) access modifiers.

You can access a protected member within its class and by derived class instances.

For a comparison of `protected` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

You can access a protected member of a base class in a derived class only if the access occurs through the derived class type. For example, consider the following code segment:

:::code language="csharp" source="./snippets/protected/Example1.cs" id="snippet1":::

The statement `baseObject.myValue = 10` generates an error because it accesses the protected member through a base class reference (`baseObject` is of type `BaseClass`). You can only access protected members through the derived class type or types derived from it.

Unlike `private protected`, the `protected` access modifier allows access from derived classes **in any assembly**. Unlike `protected internal`, it doesn't allow access from non-derived classes within the same assembly.

You can't declare struct members as protected because structs can't be inherited.

In this example, the class `DerivedPoint` is derived from `Point`. Therefore, you can access the protected members of the base class directly from the derived class.

:::code language="csharp" source="./snippets/protected/Example2.cs" id="snippet1":::  

If you change the access levels of `x` and `y` to [private](private.md), the compiler returns the error messages:

`'Point.y' is inaccessible due to its protection level.`

`'Point.x' is inaccessible due to its protection level.`

The following example demonstrates that `protected` members are accessible from derived classes even when they're in different assemblies:

:::code language="csharp" source="./snippets/protected/Assembly1.cs" id="snippet1":::

:::code language="csharp" source="./snippets/protected/Assembly2.cs" id="snippet1":::

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
