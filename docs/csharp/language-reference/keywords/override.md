---
description: "override modifier - C# Reference"
title: "override modifier"
ms.date: 01/22/2026
f1_keywords: 
  - "override"
  - "override_CSharpKeyword"
helpviewer_keywords: 
  - "override keyword [C#]"
---
# override (C# reference)

Use the `override` modifier to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

In the following example, the `Square` class must provide an overridden implementation of `GetArea` because `GetArea` is inherited from the abstract `Shape` class:

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="1":::

An `override` method provides a new implementation of the method inherited from a base class. An `override` method declaration provides a more specific implementation of the overridden base method. An `override` method must have the same signature as the overridden base method. `override` methods support covariant return types. In particular, the return type of an `override` method can derive from the return type of the corresponding base method.

You can't override a non-virtual or static method. The overridden base method must be `virtual`, `abstract`, or `override`.

An `override` declaration can't change the accessibility of the `virtual` method. Both the `override` method and the `virtual` method must have the same [access level modifier](access-modifiers.md).

You can't use the `new`, `static`, or `virtual` modifiers to modify an `override` method.

An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property. Read-only overriding properties support covariant return types. The overridden property must be `virtual`, `abstract`, or `override`.

For more information about how to use the `override` keyword, see [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing when to use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md). For information about inheritance, see [Inheritance](../../fundamentals/object-oriented/inheritance.md).

## Example

This example defines a base class named `Employee` and a derived class named `SalesEmployee`. The `SalesEmployee` class includes an extra field, `salesbonus`, and overrides the method `CalculatePay` to take the bonus into account.

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="9":::

## C# language specification

For more information, see the [Override methods](~/_csharpstandard/standard/classes.md#1565-override-methods) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about covariant return types, see the [feature proposal note](~/_csharplang/proposals/csharp-9.0/covariant-returns.md).

## See also

- [Inheritance](../../fundamentals/object-oriented/inheritance.md)
- [C# keywords](index.md)
- [Modifiers](index.md)
- [abstract](abstract.md)
- [virtual](virtual.md)
- [new (modifier)](new-modifier.md)
- [Polymorphism](../../fundamentals/object-oriented/polymorphism.md)
