---
title: "Restricting Accessor Accessibility"
description: The get and set accessors of a property in C# have the same visibility or access level by default as property to which they belong. You can restrict access.
ms.date: 10/30/2024
helpviewer_keywords: 
  - "read-only properties [C#]"
  - "read-only indexers [C#]"
  - "accessors [C#]"
  - "properties [C#], read-only"
  - "asymmetric accessor accessibility [C#]"
  - "indexers [C#], read-only"
---
# Restricting Accessor Accessibility (C# Programming Guide)

The [get](../../language-reference/keywords/get.md) and [set](../../language-reference/keywords/set.md) portions of a property or indexer are called *accessors*. By default these accessors have the same visibility or access level of the property or indexer to which they belong. For more information, see [accessibility levels](../../language-reference/keywords/accessibility-levels.md). However, it's sometimes useful to restrict access to one of these accessors. Typically, you restrict the accessibility of the `set` accessor, while keeping the `get` accessor publicly accessible. For example:

:::code language="csharp" source="./snippets/Properties/accessors.cs" id="Accessor":::

In this example, a property called `Name` defines a `get` and `set` accessor. The `get` accessor receives the accessibility level of the property itself, `public` in this case, while the `set` accessor is explicitly restricted by applying the [protected](../../language-reference/keywords/protected.md) access modifier to the accessor itself.

> [!NOTE]
> The examples in this article don't use [automatically implemented properties](./properties.md#automatically-implemented-properties). *Automatically implemented properties* provide a concise syntax for declaring properties when a custom backing field isn't required.

## Restrictions on Access Modifiers on Accessors

Using the accessor modifiers on properties or indexers is subject to these conditions:

- You can't use accessor modifiers on an interface or an explicit [interface](../../language-reference/keywords/interface.md) member implementation.
- You can use accessor modifiers only if the property or indexer has both `set` and `get` accessors. In this case, the modifier is permitted on only one of the two accessors.
- If the property or indexer has an [override](../../language-reference/keywords/override.md) modifier, the accessor modifier must match the accessor of the overridden accessor, if any.
- The accessibility level on the accessor must be more restrictive than the accessibility level on the property or indexer itself.

## Access Modifiers on Overriding Accessors

When you override a property or indexer, the overridden accessors must be accessible to the overriding code. Also, the accessibility of both the property/indexer and its accessors must match the corresponding overridden property/indexer and its accessors. For example:

:::code language="csharp" source="./snippets/Properties/accessors.cs" id="Hierarchy":::

## Implementing Interfaces

When you use an accessor to implement an interface, the accessor may not have an access modifier. However, if you implement the interface using one accessor, such as `get`, the other accessor can have an access modifier, as in the following example:

:::code language="csharp" source="./snippets/Properties/accessors.cs" id="InterfaceAccessor":::

## Accessor Accessibility Domain

If you use an access modifier on the accessor, the [accessibility domain](../../language-reference/keywords/accessibility-domain.md) of the accessor is determined by this modifier.

If you didn't use an access modifier on the accessor, the accessibility domain of the accessor is determined by the accessibility level of the property or indexer.

## Example

The following example contains three classes, `BaseClass`, `DerivedClass`, and `MainClass`. There are two properties on the `BaseClass`, `Name` and `Id` on both classes. The example demonstrates how the property `Id` on `DerivedClass` can be hidden by the property `Id` on `BaseClass` when you use a restrictive access modifier such as [protected](../../language-reference/keywords/protected.md) or [private](../../language-reference/keywords/private.md). Therefore, when you assign values to this property, the property on the `BaseClass` class is called instead. Replacing the access modifier by [public](../../language-reference/keywords/public.md) will make the property accessible.

The example also demonstrates that a restrictive access modifier, such as `private` or `protected`, on the `set` accessor of the `Name` property in `DerivedClass` prevents access to the accessor in the derived class. It generates an error when you assign to it, or accesses the base class property of the same name, if it's accessible.

:::code language="csharp" source="./snippets/Properties/accessors.cs" id="Example":::

## Comments

Notice that if you replace the declaration `new private string Id` by `new public string Id`, you get the output:

 `Name and ID in the base class: Name-BaseClass, ID-BaseClass`
 `Name and ID in the derived class: John, John123`

## See also

- [Properties](./properties.md)
- [Indexers](../indexers/index.md)
- [Access Modifiers](./access-modifiers.md)
- [Init only properties](../../language-reference/keywords/init.md)
- [Required properties](../../language-reference/keywords/required.md)
