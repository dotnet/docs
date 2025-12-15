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
  - "CS9336"
  - "CS9337"
ms.date: 12/12/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in pattern matching expressions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8509**](#pattern-completeness-and-redundancy): *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- [**CS8978**](#type-pattern-errors): *'...' cannot be made nullable.*
- [**CS8979**](#list-pattern-errors): *List patterns may not be used for a value of type '...'.*
- [**CS8980**](#list-pattern-errors): *Slice patterns may only be used once and directly inside a list pattern.*
- [**CS8985**](#list-pattern-errors): *List patterns may not be used for a value of type '...'. No suitable 'Length' or 'Count' property was found.*
- [**CS9013**](#list-pattern-errors): *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*
- [**CS9060**](#type-pattern-errors): *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*
- [**CS9134**](#switch-expression-syntax-errors): *A switch expression arm does not begin with a 'case' keyword.*
- [**CS9135**](#switch-expression-syntax-errors): *A constant value of type is expected*
- [**CS9336**](#pattern-completeness-and-redundancy): *The pattern is redundant.*
- [**CS9337**](#pattern-completeness-and-redundancy): *The pattern is too complex to analyze for redundancy.*

## Switch expression syntax errors

- **CS9134**: *A switch expression arm does not begin with a 'case' keyword.*
- **CS9135**: *A constant value of type is expected*

Remove the `case` keyword from switch expression arms. Switch expressions use a different syntax than switch statements (**CS9134**). In switch expressions, each arm consists of a pattern followed by the `=>` token and an expression, without the `case` keyword that's used in switch statements. Use constant values rather than variables in patterns. Pattern matching requires compile-time constants (**CS9135**). Variables can't be used as patterns. The compiler needs to know the exact values at compile time to generate the appropriate matching code.

For more information about the correct syntax, see [Switch expression](../operators/switch-expression.md).

## Pattern completeness and redundancy

- **CS8509**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- **CS9336**: *The pattern is redundant.*
- **CS9337**: *The pattern is too complex to analyze for redundancy.*

Add switch arms that handle all possible input values to create exhaustive switch expressions (**CS8509**). Switch expressions must cover every possible value of the input type. Otherwise the compiler can't guarantee that the expression produces a result for all inputs. Use the discard pattern (`_`) as a final catch-all arm to match any remaining values that you don't need to handle explicitly. The discard pattern ensures that the switch expression handles all possible cases. Review patterns that the compiler identifies as redundant. Redundant patterns can indicate a logic error where you meant to use `not` or different logical operators (**CS9336**). Simplify complex patterns that are too difficult for the compiler to analyze for redundancy. Break them down into simpler, more maintainable expressions (**CS9337**).

For more information about exhaustiveness requirements and pattern optimization, see [Switch expression](../operators/switch-expression.md), [Switch statement](../statements/selection-statements.md#the-switch-statement), and [Patterns](../operators/patterns.md).

## Type pattern errors

- **CS8978**: *'...' cannot be made nullable.*
- **CS9060**: *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*

Use the underlying type directly in patterns when working with types that can't be made nullable (**CS8978**). Types like `System.Nullable<T>`, pointer types, and ref struct types can't be made nullable. You must use the base type in your pattern matching logic.

Use type patterns to narrow generic numeric types to specific numeric types before applying numeric constants or relational patterns (**CS9060**). Generic numeric types that implement `INumberBase<T>` can't be matched directly with numeric constants or relational patterns. The compiler can't determine which specific numeric type is being matched. You must first narrow the value to a concrete numeric type like `int`, `double`, or `decimal`.

For more information about type patterns, see [Nullable value types](../builtin-types/nullable-value-types.md), [Patterns](../operators/patterns.md), and [Generic math](../../../standard/generics/math.md).

## List pattern errors

- **CS8979**: *List patterns may not be used for a value of type '...'.*
- **CS8980**: *Slice patterns may only be used once and directly inside a list pattern.*
- **CS8985**: *List patterns may not be used for a value of type '...'. No suitable 'Length' or 'Count' property was found.*
- **CS9013**: *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*

Ensure the type supports the required operations for list patterns.  List patterns require types that are countable and indexable (**CS8979**, **CS8985**). The type must have an accessible `Length` or `Count` property and support indexing. Runtime types that support list patterns include arrays, `List<T>`, `Span<T>`, and other collection types with appropriate members.

Place slice patterns (`..`) directly inside a list pattern. Use them only once per list pattern because they can't appear in nested patterns or outside of list patterns (**CS8980**).

When matching `Span<char>` or `ReadOnlySpan<char>` types, use an empty string `""` instead of a string null constant. The literal `null` isn't supported as a pattern for span types (**CS9013**).

For more information about list pattern requirements and syntax, see [List patterns](../operators/patterns.md#list-patterns) and [Patterns](../operators/patterns.md).
