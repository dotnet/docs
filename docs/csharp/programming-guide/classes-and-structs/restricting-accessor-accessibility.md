---
title: "Accessor accessibility examples"
description: Explore restricted property accessors in inheritance and interface implementations, and public read/private write contracts.
ms.date: 11/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords: 
  - "read-only properties [C#]"
  - "read-only indexers [C#]"
  - "accessors [C#]"
  - "properties [C#], read-only"
  - "asymmetric accessor accessibility [C#]"
  - "indexers [C#], read-only"
---
# Accessor accessibility examples

For the everyday rules and a runnable `private set` example, see [Declare and initialize properties](../../fundamentals/classes/properties.md#restrict-accessor-access). The examples here explore restricted accessors in inheritance and interface implementations.

The following property lets callers read `Name` while the containing class and derived classes control assignments through a `protected` setter:

:::code language="csharp" source="./snippets/properties/accessors.cs" id="Accessor":::

See [Access modifiers](../../fundamentals/classes/access-modifiers.md) for accessibility levels.

## Restrictions on access modifiers on accessors

For the basic placement and relative accessibility rules, see [Accessor accessibility](../../fundamentals/classes/properties.md#restrict-accessor-access). Additional conditions apply to explicit implementations and overrides:

- You can't use accessor modifiers on an explicit [interface](../../language-reference/keywords/interface.md) member implementation.
- If the property or indexer has an [override](../../language-reference/keywords/override.md) modifier, the accessor modifier must match the accessor of the overridden accessor, if any.

## Access modifiers on overriding accessors

When you override a property or indexer, the overridden accessors must be accessible to the overriding code. Also, the accessibility of both the property/indexer and its accessors must match the corresponding overridden property/indexer and its accessors. For example:

:::code language="csharp" source="./snippets/properties/accessors.cs" id="Hierarchy":::

## Interface implementations

When you use an accessor to implement an interface, the accessor may not have an access modifier. However, if you implement the interface using one accessor, such as `get`, the other accessor can have an access modifier, as in the following example:

:::code language="csharp" source="./snippets/properties/accessors.cs" id="InterfaceAccessor":::

## Accessor accessibility domain

If you use an access modifier on the accessor, the [accessibility domain](../../language-reference/keywords/accessibility-domain.md) of the accessor is determined by this modifier.

If you didn't use an access modifier on the accessor, the accessibility domain of the accessor is determined by the accessibility level of the property or indexer.

## Example

The following example contains three classes, `BaseClass`, `DerivedClass`, and `MainClass`. There are two properties on the `BaseClass`, `Name` and `Id` on both classes. The example demonstrates how the property `Id` on `DerivedClass` can be hidden by the property `Id` on `BaseClass` when you use a restrictive access modifier such as [protected](../../language-reference/keywords/protected.md) or [private](../../language-reference/keywords/private.md). Therefore, when you assign values to this property, the property on the `BaseClass` class is called instead. Replacing the access modifier by [public](../../language-reference/keywords/public.md) will make the property accessible.

The example also demonstrates that a restrictive access modifier, such as `private` or `protected`, on the `set` accessor of the `Name` property in `DerivedClass` prevents access to the accessor in the derived class. It generates an error when you assign to it, or accesses the base class property of the same name, if it's accessible.

:::code language="csharp" source="./snippets/properties/accessors.cs" id="Example":::

## Comments

Notice that if you replace the declaration `new private string Id` by `new public string Id`, you get the output:

 `Name and ID in the base class: Name-BaseClass, ID-BaseClass`
 `Name and ID in the derived class: John, John123`

## See also

- [Properties](../../fundamentals/classes/properties.md)
- [Indexers](../indexers/index.md)
- [Access Modifiers](./access-modifiers.md)
- [Init only properties](../../language-reference/keywords/init.md)
- [Required properties](../../language-reference/keywords/required.md)
