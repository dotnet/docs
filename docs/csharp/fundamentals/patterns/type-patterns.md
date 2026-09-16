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

In a delivery system, `IRouteStop` is a capability contract for destinations accepted by route planning. `CanRoute` tests whether the evaluated destination has that capability, and its Boolean result determines whether the destination enters the route-planning workflow. The workflow needs only a yes-or-no answer and doesn't read any route-stop members, so a type pattern without a captured variable fits.

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePattern":::

The input expression is `destination`, and `IRouteStop` is the type being tested. Choose a type pattern when the answer is only yes or no. If the matching branch needs to read an address or call another member through `IRouteStop`, choose a [declaration pattern](declaration-constant-var-patterns.md#test-and-capture-a-type-with-a-declaration-pattern) instead so the branch has a variable of that type.

> [!NOTE]
> You might also see `destination is IRouteStop _`. That syntax is a declaration pattern in which `_` means that no variable is retained. It performs the same type test when both forms are valid, but `destination is IRouteStop` states the test-only intent more directly.

## Match classes and interfaces

In the delivery system, `IRouteStop` defines the capability contract for route-planning destinations, while `RouteStop` is a base class that provides common route-stop data and implementation. `ExpressRouteStop` is a specialized class derived from `RouteStop`. The example tests one evaluated value so its output can demonstrate all three compatible types. Each test needs only a Boolean result, so no captured variable is needed.

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="ClassAndInterface":::

The evaluated value is an `ExpressRouteStop`. The output shows that it matches its exact class, its `RouteStop` base class, and the `IRouteStop` interface that `RouteStop` implements.

For detailed compatibility rules and edge cases, see the [type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns).

## Route several types

In a support system, `SupportRequest` is the base class for specialized request classes such as `PasswordResetRequest` and `BillingQuestion`. A *switch arm* pairs a pattern with the result to return when that pattern matches. Each arm returns the name of a processing queue, and the final arm provides a fallback queue for other evaluated values. The selected queue depends only on the run-time type of the evaluated value, so type patterns fit because no request member is read.

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="TypePatternSwitch":::

Each arm answers a type question and returns the queue that handles that request. If an arm needed to read request members, use a declaration pattern to capture the matching value in a variable.

Switch arms are considered from top to bottom. Put a specialized class before its base class. Otherwise, the base-class arm can match every instance of the specialized class, which makes the later arm unreachable.

## Optional: use a type parameter as the tested type

This optional example builds on [generic types and methods](../types/generics.md). A *type parameter* such as `TRequest` is a placeholder for a type that the caller supplies. An incoming-request batch can contain several request types, and the caller supplies `ConfidentialRequest` to test whether any request requires confidential handling. The Boolean result selects confidential handling for the entire batch and produces a visible status message. A type pattern with a type parameter fits because only the existence of a matching request matters, so the matching object doesn't need to be retained.

:::code language="csharp" source="snippets/patterns/TypePatterns.cs" ID="GenericTypePattern":::

If the caller needed the matching request itself, a search or filter operation that returns matching items would be more appropriate.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Generic types and methods](../types/generics.md)
- [Type-testing and cast operators](../../language-reference/operators/type-testing-and-cast.md)
- [Type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns)
