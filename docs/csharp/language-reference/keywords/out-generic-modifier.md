---
description: "out keyword (generic modifier) - C# Reference"
title: "out keyword (generic modifier)"
ms.date: 01/22/2026
helpviewer_keywords: 
  - "covariance, out keyword [C#]"
  - "out keyword [C#]"
---
# out (generic modifier) (C# Reference)

For generic type parameters, the `out` keyword specifies that the type parameter is covariant. Use the `out` keyword in generic interfaces and delegates.

Covariance enables you to use a more derived type than the generic parameter specifies. This feature allows for implicit conversion of classes that implement covariant interfaces and implicit conversion of delegate types. Covariance and contravariance support reference types, but they don't support value types.

An interface with a covariant type parameter enables its methods to return more derived types than those specified by the type parameter. For example, because in .NET, in <xref:System.Collections.Generic.IEnumerable%601>, type T is covariant, you can assign an object of the `IEnumerable<string>` type to an object of the `IEnumerable<object>` type without using any special conversion methods.

You can assign a covariant delegate to another delegate of the same type, but with a more derived generic type parameter.

For more information, see [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following example shows how to declare, extend, and implement a covariant generic interface. It also shows how to use implicit conversion for classes that implement a covariant interface.

:::code language="csharp" source="./snippets/variance.cs" id="3":::

In a generic interface, declare a type parameter covariant if it satisfies the following conditions:

- You use the type parameter only as a return type of interface methods and don't use it as a type of method arguments.

  > [!NOTE]
  > There's one exception to this rule. If a covariant interface has a contravariant generic delegate as a method parameter, you can use the covariant type as a generic type parameter for this delegate. For more information about covariant and contravariant generic delegates, see [Variance in Delegates](../../programming-guide/concepts/covariance-contravariance/variance-in-delegates.md) and [Using Variance for Func and Action Generic Delegates](../../programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).

- You don't use the type parameter as a generic constraint for the interface methods.

The following example shows how to declare, instantiate, and invoke a covariant generic delegate. It also shows how to implicitly convert delegate types.

:::code language="csharp" source="./snippets/variance.cs" id="4":::

In a generic delegate, declare a type covariant if you use it only as a method return type and not for method arguments.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Variance in Generic Interfaces](../../programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)
- [in](in-generic-modifier.md)
- [Modifiers](index.md)
