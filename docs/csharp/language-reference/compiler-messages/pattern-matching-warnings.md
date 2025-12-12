---
title: Resolve pattern matching errors and warnings
description: There are several pattern matching warnings. Learn how to address these warnings.
f1_keywords:
  - "CS8509" # WRN_SwitchNotAllPossibleValues: The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.
  - "CS8978"
  - "CS8979"
  - "CS8980"
  - "CS8985"
  - "CS9013"
  - "CS9060"
  - "CS9134"
  - "CS9135"
  - "CS9335"
  - "CS9336"
  - "CS9337"
helpviewer_keywords:
  - "CS8509"
  - "CS8978"
  - "CS8979"
  - "CS8980"
  - "CS8985"
  - "CS9013"
  - "CS9060"
  - "CS9134"
  - "CS9335"
  - "CS9336"
  - "CS9337"
ms.date: 11/07/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in pattern matching expressions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8509**](#incomplete-pattern-matching): *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- [**CS8978**](#nullable-pattern-errors): *'...' cannot be made nullable.*
- [**CS8979, CS8985**](#list-pattern-requirements): *List patterns may not be used for a value of type '...'.*
- [**CS8980**](#slice-pattern-errors): *Slice patterns may only be used once and directly inside a list pattern.*
- [**CS9013**](#span-pattern-errors): *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*
- [**CS9060**](#generic-numeric-pattern-errors): *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*
- [**CS9134**](#switch-expression-syntax-errors): *A switch expression arm does not begin with a 'case' keyword.*
- [**CS9135**](#switch-expression-syntax-errors): *A constant value of type is expected*
- [**CS9335, CS9336**](#redundant-patterns): *The pattern is redundant.*
- [**CS9337**](#redundant-patterns): *The pattern is too complex to analyze for redundancy.*

## Switch expression syntax errors

- **CS9134**: *A switch expression arm does not begin with a 'case' keyword.*
- **CS9135**: *A constant value of type is expected*

To write switch expressions correctly, follow the proper syntax rules. For more information, see [Switch expression](../operators/switch-expression.md).

- Don't use the `case` keyword in switch expressions (**CS9134**). The `case` keyword is used in switch statements, not switch expressions. In a switch expression, each arm consists of a pattern, an optional case guard, the `=>` token, and an expression.
- Use constant values in patterns, not variables (**CS9135**). Pattern matching requires compile-time constants for value patterns.

The following example demonstrates the syntax error with `case`:

```csharp
var answer = x switch
{
    // CS9134: remove the keyword "case" from each switch arm:
    case 0 => false,
    case 1 => true,
}
```

To fix this error, remove the `case` keyword:

```csharp
var answer = x switch
{
    0 => false,
    1 => true,
}
```

## Incomplete pattern matching

- **CS8509**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*

To create exhaustive switch expressions, cover all possible input values. For more information, see [Switch expression](../operators/switch-expression.md) and [Switch statement](../statements/selection-statements.md#the-switch-statement).

Add switch arms that handle all possible input values. Use the discard pattern (`_`) to match any remaining values that you don't need to handle explicitly.

The following example generates CS8509:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchNotAllPossibleValues":::

To fix this warning, add a default arm:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchAllPossibleValues":::

The `_` pattern matches all remaining values. You can use this pattern to handle invalid or unexpected values.

## Nullable pattern errors

- **CS8978**: *'...' cannot be made nullable.*

To use nullable types in patterns, use valid nullable type syntax. For more information, see [Nullable value types](../../nullable-value-types.md) and [Patterns](../operators/patterns.md).

Don't attempt to make types nullable that cannot be nullable (**CS8978**). Types like `System.Nullable<T>` itself, pointer types, and ref struct types cannot be made nullable. Use the underlying type directly in the pattern.

## List pattern requirements

- **CS8979**: *List patterns may not be used for a value of type '...'.*
- **CS8985**: *List patterns may not be used for a value of type '...'. No suitable 'Length' or 'Count' property was found.*

To use list patterns, ensure the type supports the required operations. For more information, see [List patterns](../operators/patterns.md#list-patterns).

List patterns require types that are countable and indexable (**CS8979**, **CS8985**). The type must have an accessible `Length` or `Count` property and support indexing. Common types that support list patterns include arrays, `List<T>`, `Span<T>`, and other collection types with appropriate members.

## Slice pattern errors

- **CS8980**: *Slice patterns may only be used once and directly inside a list pattern.*

To use slice patterns correctly, place them properly within list patterns. For more information, see [List patterns](../operators/patterns.md#list-patterns).

Slice patterns (`..`) must appear directly inside a list pattern and can only be used once per list pattern (**CS8980**). They cannot appear in nested patterns or outside of list patterns. Use slice patterns to match zero or more elements in a sequence.

## Span pattern errors

- **CS9013**: *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*

To match span types like `Span<char>` and `ReadOnlySpan<char>`, use appropriate constant patterns. For more information, see [Patterns](../operators/patterns.md).

When matching `Span<char>` or `ReadOnlySpan<char>` types, you cannot use a string `null` constant as a pattern (**CS9013**). Instead, use an empty string `""` to match empty spans, or use other appropriate patterns for your matching logic.

## Generic numeric pattern errors

- **CS9060**: *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*

To match generic numeric types, use type patterns to narrow to specific numeric types. For more information, see [Patterns](../operators/patterns.md) and [Generic math](../../../standard/generics/math.md).

Generic numeric types that implement `INumberBase<T>` cannot be matched directly with numeric constants or relational patterns (**CS9060**). The compiler cannot determine which specific numeric type is being matched. Use a type pattern to first narrow the value to a concrete numeric type like `int`, `double`, or `decimal`, then apply numeric or relational patterns.

## Redundant patterns

- **CS9335, CS9336**: *The pattern is redundant.*
- **CS9337**: *The pattern is too complex to analyze for redundancy.*

To write clear pattern matching expressions, avoid redundant patterns. For more information, see [Patterns](../operators/patterns.md).

- Review patterns that the compiler identifies as redundant (**CS9335**, **CS9336**). Redundant patterns can indicate a logic error where you meant to use `not` or different logical operators.
- Simplify complex patterns that are too difficult for the compiler to analyze (**CS9337**). Break down complex patterns into simpler, more maintainable expressions.

The following example demonstrates a redundant pattern:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="RedundantPattern":::

This warning indicates you likely meant `is not (null or 42)` or `is not (int or string)` instead of using `or` at the top level.
