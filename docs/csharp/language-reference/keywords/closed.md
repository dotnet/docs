---
title: "closed modifier"
description: "Learn about the closed class modifier in C#. A closed class restricts derivation to its declaring assembly so consumers can write exhaustive switch expressions over its direct descendants."
ms.date: 06/02/2026
f1_keywords:
  - "closed"
  - "closed_CSharpKeyword"
helpviewer_keywords:
  - "closed keyword [C#]"
  - "closed class [C#]"
  - "closed hierarchy [C#]"
ai-usage: ai-assisted
---
# closed (C# Reference)

Starting in C# 15, you can apply the `closed` modifier to a class to declare a *closed hierarchy*. A closed class can only be derived from within its declaring assembly. Because the set of direct descendants is fixed, a `switch` expression that handles each direct descendant exhausts the closed base type and doesn't need a default arm.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

```csharp
// Assembly 1
public closed record class JobStatus;
public record class Queued : JobStatus;
public record class Running(int PercentComplete) : JobStatus;
public record class Completed(TimeSpan Elapsed) : JobStatus;
public record class Failed(string Error) : JobStatus;

// Assembly 2
public record class Paused : JobStatus; // Error: 'JobStatus' is a closed class
```

The same-assembly restriction applies only to *direct* descendants of the closed class. A class that derives from a closed class isn't itself closed unless you also mark it `closed`. Because `Failed` in the previous example is a plain record, another assembly can derive from it:

```csharp
// Assembly 2
public record class RetryableFailed(string Error, int Attempts) : Failed(Error); // OK: 'Failed' isn't sealed or closed
```

If you want to prevent derivation from `Failed` as well, declare it as `sealed` or `closed`.

## Declaration rules

The `closed` modifier is a class modifier:

- A `closed` class is implicitly [`abstract`](abstract.md). You can't combine `closed` with `sealed`, `static`, or an explicit `abstract` modifier.
- A direct subtype of a closed class must be declared in the same assembly and module as the closed base class.
- A class that derives from a closed class isn't itself closed. Apply the `closed` modifier again if you want a derived class to also be closed.

If a generic class directly derives from a `closed` class, every type parameter on the derived class must be used in the base class specification. This rule isn't about the `closed` modifier itself: a *closed constructed type* is a generic type whose type arguments are fully specified (such as `Tree<int>`), as opposed to an *open type* like `Tree<T>`. The rule ensures that each closed constructed type of the base class has exactly one corresponding closed constructed type among its direct descendants, so the compiler can reason about exhaustiveness.

:::code language="csharp" source="./snippets/shared/Closed.cs" id="GenericRule":::

## Exhaustive switch expressions

When a `switch` expression handles every direct descendant of a closed class, the compiler considers the switch exhaustive and doesn't generate a non-exhaustiveness warning:

:::code language="csharp" source="./snippets/shared/Closed.cs" id="ExhaustiveSwitch":::

When the switch governing expression is nullable, `null` becomes another possible value that the switch must handle. A switch over `JobStatus?` is exhaustive only when it also covers `null`:

:::code language="csharp" source="./snippets/shared/Closed.cs" id="NullableSwitch":::

If you omit the `null` arm, the compiler warns that the pattern `null` isn't handled. The same rule applies whether the closed type is a class or a struct lifted to a nullable type.

For more information about how the compiler determines exhaustiveness, including how closed hierarchies interact with generic constraints and accessibility, see [Closed hierarchy patterns](../operators/patterns.md#closed-hierarchy-patterns).

## Type parameters constrained to a closed type

A type parameter constrained to a closed class is treated as that closed class for exhaustiveness checks. A `switch` expression whose governing value has such a type parameter is exhaustive when it handles every direct descendant of the closed constraint:

:::code language="csharp" source="./snippets/shared/Closed.cs" id="TypeParameterConstrained":::

This rule applies whether the type parameter appears on a method or on the containing type.

## Contextual keyword

`closed` is a contextual keyword. It has special meaning only when it appears as a modifier on a class declaration. You can continue to use `closed` as an identifier in other contexts. If you need to use `closed` as an identifier in a position where the modifier would also be valid, prefix it with `@` (for example, `@closed`) to tell the compiler to treat it as an identifier rather than the modifier.

## C# language specification

For more information, see the [Closed hierarchies](~/_csharplang/proposals/closed-hierarchies.md) feature specification.

## See also

- [Inheritance](../../fundamentals/object-oriented/inheritance.md)
- [sealed](sealed.md)
- [abstract](abstract.md)
- [Pattern matching](../operators/patterns.md)
- [Switch expression](../operators/switch-expression.md)
