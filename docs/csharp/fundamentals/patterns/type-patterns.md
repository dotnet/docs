---
title: "Type patterns"
description: Learn when to use a C# type pattern for a yes-or-no run-time type test without declaring a variable.
ms.date: 09/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Type patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete compatibility rules, see [declaration and type patterns](../../language-reference/operators/patterns.md#declaration-and-type-patterns) in the language reference.

A *type pattern* is applied to an input expression. C# evaluates the expression, then tests whether the resulting value is non-null and its run-time type is compatible with the specified type. A type pattern reports only whether the type test succeeds. It doesn't declare a variable.

## Ask a yes-or-no type question

Suppose a delivery service receives several kinds of destinations. It needs to determine whether an object can be used as a route stop, but it doesn't need any route-stop members yet:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePattern":::

The input expression is `destination`, and `IRouteStop` is the type being tested. Choose a type pattern when the answer is only yes or no. If the matching branch needs to read an address or call another member through `IRouteStop`, choose a [declaration pattern](declaration-constant-var-patterns.md#test-and-capture-a-type-with-a-declaration-pattern) instead so the branch has a variable of that type.

> [!NOTE]
> You might also see `destination is IRouteStop _`. That syntax is a declaration pattern whose designation is a discard. It performs the same type test when both forms are valid, but `destination is IRouteStop` states the test-only intent more directly.

## Route several types

Type patterns also fit a switch expression when the result depends on an object's type but doesn't need data from that object:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePatternSwitch":::

Each arm answers a type question and returns the team that handles that request. No arm declares a variable because no branch reads request-specific members.

Switch arms are considered from top to bottom. Put a more specific derived class before its base class. Otherwise, the base-class arm can match every instance of the derived class, which makes the later arm unreachable.

## Match classes and interfaces

A type pattern can match the value's exact class, one of its base classes, or an interface that the class implements:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="ClassAndInterface":::

The evaluated value is an `ExpressRouteStop`. It also matches `RouteStop` because that class is its base class, and it matches `IRouteStop` because the class implements that interface. This behavior lets code ask about the capability it needs instead of requiring one exact class.

Type patterns don't use user-defined conversions. The compiler also rejects a type pattern when the expression's compile-time type could never be compatible with the tested type. For all supported reference, boxing, nullable, and open-type cases, see the [type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns).

## Optional: use a type parameter as the tested type

This section builds on [generic types and methods](../types/generics.md). Skip it if type parameters are new to you.

A generic inventory can ask whether a mixed collection contains a requested kind of item:

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="GenericTypePattern":::

`TItem` is a *type parameter*, a placeholder for the type supplied by the caller. The type pattern `item is TItem` is a good fit because the method needs only a yes-or-no result for each item. If it needed to use the matching item as `TItem`, a declaration pattern such as `item is TItem match` would declare that variable.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Generic types and methods](../types/generics.md)
- [Type-testing and cast operators](../../language-reference/operators/type-testing-and-cast.md)
- [Type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns)
