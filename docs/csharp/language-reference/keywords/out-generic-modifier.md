---
title: "out keyword (generic modifier) - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
helpviewer_keywords: 
  - "covariance, out keyword [C#]"
  - "out keyword [C#]"
ms.assetid: f8c20dec-a8bc-426a-9882-4076b1db1e00
---
# out (generic modifier) (C# Reference)

For generic type parameters, the `out` keyword specifies that the type parameter is covariant. You can use the `out` keyword in generic interfaces and delegates.

Covariance enables you to use a more derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement variant interfaces and implicit conversion of delegate types. Covariance and contravariance are supported for reference types, but they are not supported for value types.

An interface that has a covariant type parameter enables its methods to return more derived types than those specified by the type parameter. For example, because in .NET Framework 4, in <xref:System.Collections.Generic.IEnumerable%601>, type T is covariant, you can assign an object of the `IEnumerable(Of String)` type to an object of the `IEnumerable(Of Object)` type without using any special conversion methods.

A covariant delegate can be assigned another delegate of the same type, but with a more derived generic type parameter.

For more information, see [Covariance and Contravariance](../../programming-guide/concepts/covariance-contravariance/index.md).

## Example - covariant generic interface

The following example shows how to declare, extend, and implement a covariant generic interface. It also shows how to use implicit conversion for classes that implement a covariant interface.

[!code-csharp[csVarianceKeywords#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csvariancekeywords/cs/program.cs#3)]

In a generic interface, a type parameter can be declared covariant if it satisfies the following conditions:

- The type parameter is used only as a return type of interface methods and not used as a type of method arguments.

    > [!NOTE]
    > There is one exception to this rule. If in a covariant interface you have a contravariant generic delegate as a method parameter, you can use the covariant type as a generic type parameter for this delegate. For more information about covariant and contravariant generic delegates, see [Variance in Delegates](../../programming-guide/concepts/covariance-contravariance/variance-in-delegates.md) and [Using Variance for Func and Action Generic Delegates](../../programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).

- The type parameter is not used as a generic constraint for the interface methods.

## Example - covariant generic delegate

The following example shows how to declare, instantiate, and invoke a covariant generic delegate. It also shows how to implicitly convert delegate types.

[!code-csharp[csVarianceKeywords#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csvariancekeywords/cs/program.cs#4)]

In a generic delegate, a type can be declared covariant if it is used only as a method return type and not used for method arguments.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [Variance in Generic Interfaces](../../programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)
- [in](in-generic-modifier.md)
- [Modifiers](modifiers.md)