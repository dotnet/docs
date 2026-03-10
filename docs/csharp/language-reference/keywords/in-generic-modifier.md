---
description: "in (Generic Modifier) - C# Reference"
title: "in (Generic Modifier)"
ms.date: 01/21/2026
helpviewer_keywords: 
  - "contravariance, in keyword [C#]"
  - "in keyword [C#]"
---
# `in` (Generic Modifier) (C# Reference)

For generic type parameters, use the `in` keyword to allow contravariant type arguments. Use the `in` keyword in generic interfaces and delegates.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Contravariance enables you to use a less derived type than the type specified by the generic parameter. This feature allows for implicit conversion of classes that implement contravariant interfaces and implicit conversion of delegate types. Reference types support covariance and contravariance in generic type parameters, but value types don't support these features.

You can declare a type as contravariant in a generic interface or delegate only if it defines the type of a method's parameters and not the method's return type. `In`, `ref`, and `out` parameters must be invariant, meaning they're neither covariant nor contravariant.

An interface that has a contravariant type parameter allows its methods to accept arguments of less derived types than those specified by the interface type parameter. For example, in the <xref:System.Collections.Generic.IComparer%601> interface, type T is contravariant. You can assign an object of the `IComparer<Person>` type to an object of the `IComparer<Employee>` type without using any special conversion methods if `Employee` inherits `Person`.

You can assign a contravariant delegate to another delegate of the same type, but with a less derived generic type parameter.

For more information, see [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).

## Contravariant generic interface

The following example shows how to declare, extend, and implement a contravariant generic interface. It also shows how you can use implicit conversion for classes that implement this interface.

:::code language="csharp" source="./snippets/variance.cs" id="1":::

## Contravariant generic delegate

The following example shows how to declare, instantiate, and invoke a contravariant generic delegate. It also shows how you can implicitly convert a delegate type.

:::code language="csharp" source="./snippets/variance.cs" id="2":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [out](out-generic-modifier.md)
- [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md)
- [Modifiers](index.md)
