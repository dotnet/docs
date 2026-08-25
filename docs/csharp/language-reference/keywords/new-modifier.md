---
description: "new modifier - C# Reference"
title: "new modifier"
ms.date: 01/22/2026
helpviewer_keywords: 
  - "new modifier keyword [C#]"
---
# new modifier (C# Reference)

When you use the `new` keyword as a declaration modifier, you explicitly hide a member that a base class provides. When you hide an inherited member, the derived version of the member replaces the base class version. You can hide a member when the base class version is visible in the derived class. The base class version isn't visible if it's marked as `private` or, in some cases, `internal`. Although you can hide `public` or `protected` members without using the `new` modifier, you get a compiler warning. If you use `new` to explicitly hide a member, it suppresses this warning.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

You can also use the `new` keyword to [create an instance of a type](../operators/new-operator.md) or as a [generic type constraint](./new-constraint.md).

To hide an inherited member, declare it in the derived class by using the same member name, and modify it with the `new` keyword. For example:

:::code language="csharp" source="./snippets/csrefKeywordsOperators.cs" id="8":::

In this example, `BaseC.Invoke` is hidden by `DerivedC.Invoke`. The field `x` isn't affected because it isn't hidden by a similar name.

Name hiding through inheritance takes one of the following forms:

- Generally, a constant, field, property, or type that you introduce in a class or struct hides all base class members that share its name. However, some special cases exist. For example, if you declare a new field with name `N` to have a type that isn't invocable, and a base type declares `N` to be a method, the new field doesn't hide the base declaration in invocation syntax. For more information, see the [Member lookup](~/_csharpstandard/standard/expressions.md#125-member-lookup) section of the [C# language specification](~/_csharpstandard/standard/README.md).

- A method that you introduce in a class or struct hides properties, fields, and types that share that name in the base class. It also hides all base class methods that have the same signature.

- An indexer that you introduce in a class or struct hides all base class indexers that have the same signature.

It's an error to use both `new` and [override](override.md) on the same member, because the two modifiers have mutually exclusive meanings. The `new` modifier creates a new member with the same name and causes the original member to become hidden. The `override` modifier extends the implementation for an inherited member.

Using the `new` modifier in a declaration that doesn't hide an inherited member generates a warning.

## Examples

In this example, a base class, `BaseC`, and a derived class, `DerivedC`, use the same field name `x`, which hides the value of the inherited field. The example demonstrates the use of the `new` modifier. It also demonstrates how to access the hidden members of the base class by using their fully qualified names.

:::code language="csharp" source="./snippets/csrefKeywordsOperators.cs" id="9":::

In this example, a nested class hides a class that has the same name in the base class. The example demonstrates how to use the `new` modifier to eliminate the warning message and how to access the hidden class members by using their fully qualified names.

:::code language="csharp" source="./snippets/csrefKeywordsOperators.cs" id="10":::

If you remove the `new` modifier, the program still compiles and runs, but you get the following warning:

```text
The keyword new is required on 'MyDerivedC.x' because it hides inherited member 'MyBaseC.x'.
```

## C# language specification

For more information, see [The new modifier](~/_csharpstandard/standard/classes.md#1535-the-new-modifier) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# Keywords](index.md)
- [Modifiers](index.md)
- [Versioning with the Override and New Keywords](../../programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md)
- [Knowing When to Use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md)
