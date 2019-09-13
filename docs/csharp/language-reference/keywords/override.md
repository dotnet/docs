---
title: "override modifier - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "override"
  - "override_CSharpKeyword"
helpviewer_keywords: 
  - "override keyword [C#]"
ms.assetid: dd1907a8-acf8-46d3-80b9-c2ca4febada8
---
# override (C# Reference)

The `override` modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.

## Example

In this example, the `Square` class must provide an overridden implementation of `GetArea` because `GetArea` is inherited from the abstract `Shape` class:

[!code-csharp[csrefKeywordsModifiers#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#1)]

An `override` method provides a new implementation of a member that is inherited from a base class. The method that is overridden by an `override` declaration is known as the overridden base method. The overridden base method must have the same signature as the `override` method. For information about inheritance, see [Inheritance](../../programming-guide/classes-and-structs/inheritance.md).

You cannot override a non-virtual or static method. The overridden base method must be `virtual`, `abstract`, or `override`.

An `override` declaration cannot change the accessibility of the `virtual` method. Both the `override` method and the `virtual` method must have the same [access level modifier](access-modifiers.md).

You cannot use the `new`, `static`, or `virtual` modifiers to modify an `override` method.

An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property, and the overridden property must be `virtual`, `abstract`, or `override`.

For more information about how to use the `override` keyword, see [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing when to use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).

## Example

This example defines a base class named `Employee`, and a derived class named `SalesEmployee`. The `SalesEmployee` class includes an extra field, `salesbonus`, and overrides the method `CalculatePay` in order to take it into account.

[!code-csharp[csrefKeywordsModifiers#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#9)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Inheritance](../../programming-guide/classes-and-structs/inheritance.md)
- [C# Keywords](index.md)
- [Modifiers](modifiers.md)
- [abstract](abstract.md)
- [virtual](virtual.md)
- [new (modifier)](new-modifier.md)
- [Polymorphism](../../programming-guide/classes-and-structs/polymorphism.md)
