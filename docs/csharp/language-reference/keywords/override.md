---
description: "override modifier - C# Reference"
title: "override modifier - C# Reference"
ms.date: 10/22/2020
f1_keywords: 
  - "override"
  - "override_CSharpKeyword"
helpviewer_keywords: 
  - "override keyword [C#]"
ms.assetid: dd1907a8-acf8-46d3-80b9-c2ca4febada8
---
# override (C# reference)

The `override` modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.

In the following example, the `Square` class must provide an overridden implementation of `GetArea` because `GetArea` is inherited from the abstract `Shape` class:

[!code-csharp[csrefKeywordsModifiers#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#1)]

An `override` method provides a new implementation of the method inherited from a base class. The method that is overridden by an `override` declaration is known as the overridden base method. An `override` method must have the same signature as the overridden base method. Beginning with C# 9.0, `override` methods support covariant return types. In particular, the return type of an `override` method can derive from the return type of the corresponding base method. In C# 8.0 and earlier, the return types of an `override` method and the overridden base method must be the same.

You cannot override a non-virtual or static method. The overridden base method must be `virtual`, `abstract`, or `override`.

An `override` declaration cannot change the accessibility of the `virtual` method. Both the `override` method and the `virtual` method must have the same [access level modifier](access-modifiers.md).

You cannot use the `new`, `static`, or `virtual` modifiers to modify an `override` method.

An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property. Beginning with C# 9.0, read-only overriding properties support covariant return types. The overridden property must be `virtual`, `abstract`, or `override`.

For more information about how to use the `override` keyword, see [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing when to use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md). For information about inheritance, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

## Example

This example defines a base class named `Employee`, and a derived class named `SalesEmployee`. The `SalesEmployee` class includes an extra field, `salesbonus`, and overrides the method `CalculatePay` in order to take it into account.

[!code-csharp[csrefKeywordsModifiers#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#9)]

## C# language specification

For more information, see the [Override methods](~/_csharpstandard/standard/classes.md#1565-override-methods) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about covariant return types, see the [feature proposal note](~/_csharplang/proposals/csharp-9.0/covariant-returns.md).

## See also

- [C# reference](../index.md)
- [Inheritance](../../fundamentals/object-oriented/inheritance.md)
- [C# keywords](index.md)
- [Modifiers](index.md)
- [abstract](abstract.md)
- [virtual](virtual.md)
- [new (modifier)](new-modifier.md)
- [Polymorphism](../../fundamentals/object-oriented/polymorphism.md)
