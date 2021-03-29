---
title: "Patterns - C# reference"
description: "Learn about the patterns supported by C# switch and is expressions and C# switch statement - C# reference"
ms.date: 03/25/2021
helpviewer_keywords: 
  - "pattern matching [C#]"
---
# Patterns (C# reference)

Intro.

[Logical](#logical-patterns), [property](#property-pattern), and [positional](#positional-pattern) patterns are recursive patterns. That is, they can contain other patterns.

## Declaration and type patterns

You use the declaration and type patterns to check if the runtime type of an expression is compatible with the given type. With the declaration pattern, you can also declare a new local variable. That variable is assigned a converted expression result when a pattern matches an expression, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="BasicExample":::

Beginning with C# 7.0, a *declaration pattern* with type `T` matches an expression when an expression result is non-null and any of the following conditions are true:

- The runtime type of an expression result is `T`.

- The runtime type of an expression result derives from type `T` or implements interface `T` or another [implicit reference conversion](~/_csharplang/spec/conversions.md#implicit-reference-conversions) exists from it to type `T`. The following example demonstrates two cases when this condition is true:

  :::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="ReferenceConversion":::

  In the preceding example, at the first call to the `GetSourceLabel` method, an argument value is matched by the first pattern because its runtime type `int[]` derives from the <xref:System.Array> type. At the second call to the `GetSourceLabel` method, the runtime type of an argument is <xref:System.Collections.Generic.List%601> that doesn't derive from the <xref:System.Array> type but implements the <xref:System.Collections.Generic.ICollection%601> interface.

- The runtime type of an expression result is a [nullable value type](../builtin-types/nullable-value-types.md) with the underlying type `T`.

- A [boxing](../../programming-guide/types/boxing-and-unboxing.md#boxing) or [unboxing](../../programming-guide/types/boxing-and-unboxing.md#unboxing) conversion exists from the runtime type of an expression result to type `T`.

The following example demonstrates the last two of the preceding conditions:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="NullableAndUnboxing":::

If you want to check only the type of an expression, you can use a discard `_` in place of a variable name, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="DiscardVariable":::

Beginning with C# 9.0, for that purpose you can use a *type pattern*, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="TypePattern":::

Like a declaration pattern, a type pattern matches an expression when an expression result is non-null and its runtime type satisfies any of the conditions listed above.

## Constant pattern

Beginning with C# 7.0, you use the *constant pattern* to test if an expression result equals a specified constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="BasicExample":::

In a constant pattern, you can use any constant expression, such as:

- an [integer](../builtin-types/integral-numeric-types.md) or [floating-point](../builtin-types/floating-point-numeric-types.md) numerical literal
- a [char](../builtin-types/char.md) or a [string](../builtin-types/reference-types.md#the-string-type) literal
- a Boolean value `true` or `false`
- an [enum](../builtin-types/enum.md) value
- the name of a declared [const](../keywords/const.md) field or local
- `null`

Use the constant pattern to check for `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="NullCheck":::

The compiler guarantees that no user-overloaded equality operator `==` is invoked when expression `x is null` is evaluated.

Beginning with C# 9.0, you can use the [negated](#logical-patterns) `null` constant pattern to check for non-null, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="NonNullCheck":::

## Relational patterns

Beginning with C# 9.0, you use a *relational pattern* to compare an expression result with a constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="BasicExample":::

In a relational pattern, you can use any of the [relational operators](comparison-operators.md) `<`, `>`, `<=`, or `>=`. The right-hand part of a relational pattern must be a constant expression. That constant expression can be of an [integral](../builtin-types/integral-numeric-types.md), [floating-point](../builtin-types/floating-point-numeric-types.md), [char](../builtin-types/char.md), or [enum](../builtin-types/enum.md) type.

To check if an expression value is in a certain range, match it against a [conjunctive `and` pattern](#logical-patterns), as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="WithCombinators":::

A relational pattern doesn't match an expression if an expression result is `null` or it fails to convert to the type of a constant by a nullable or unboxing conversion.

## Logical patterns

Beginning with C# 9.0, you use the `not`, `and`, and `or` pattern combinators to create the following *logical patterns*:

- *Negation* `not` pattern that matches an expression when the negated pattern doesn't match the expression. For example, you can negate the [constant](#constant-pattern) `null` pattern to check if an expression is non-null, as the following code shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="NotPattern":::

- *Conjunctive* `and` pattern that matches an expression when both patterns match the expression. For example, you can combine [relational patterns](#relational-patterns) to check if a value is in a certain range, as the following code shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="AndPattern":::

- *Disjunctive* `or` pattern that matches an expression when either of patterns matches the expression, as the following example shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="OrPattern":::

As the preceding example shows, you can repeatedly use the pattern combinators in a pattern. When you use both `and` and `or` combinators within one pattern, `and` has higher precedence than `or`. To explicitly specify the precedence, use parentheses, as the following example shows:

:::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="WithParentheses":::

## Property pattern

Beginning with C# 8.0, you use a *property pattern* to match an expression's properties or fields against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="BasicExample":::

A property pattern matches an expression when an expression result is non-null and every nested pattern matches the corresponding property or field of the expression result.

You can also add a runtime type check and a variable declaration to a property pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="WithTypeCheck":::

A property pattern is a recursive pattern. That is, you can use any pattern as a nested pattern. Use a property pattern to match parts of data against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="RecursivePropertyPattern":::

The preceding example uses two features available in C# 9.0 and later: `or` [pattern combinator](#logical-patterns) and record types.

## Positional pattern

Beginning with C# 8.0, you use a *positional pattern* to deconstruct an expression result and match the resulting values against the corresponding nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="BasicExample":::

At the preceding example, the type of an expression contains the [Deconstruct](../../deconstruct.md) method, which is used to deconstruct an expression result. You can also match expressions of [tuple types](../builtin-types/value-tuples.md) against positional patterns. In that way, you can match multiple inputs against various patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="MatchTuple":::

The preceding example uses [relational](#relational-patterns) and [logical](#logical-patterns) patterns, which are available in C# 9.0 and later.

You can also add a runtime type check and a variable declaration to a positional pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="WithTypeCheck":::

The preceding example uses positional records, which implicitly provide the `Deconstruct` method.

You can also use a [property pattern](#property-pattern) within a positional pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="WithPropertyPattern":::

You can also combine two preceding usages in one pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="CompletePositionalPattern":::

A positional pattern is a recursive pattern. That is, you can use any pattern as a nested pattern.

## `var` pattern

Beginning with C# 7.0, you use a *`var` pattern* to match any expression, including `null`, and assign its result to a declared variable, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="KeepInterimResult":::

As the preceding example shows, a `var` pattern is useful when you need a temporary variable within a Boolean expression to hold the result of intermediate calculations.

You can also use a `var` pattern when you need to perform additional checks in `when` case guards of a `switch` expression or statement, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="WithCaseGuards":::

In the preceding example, pattern `var (x, y)` is equivalent to a [positional pattern](#positional-pattern) `(var x, var y)`.

In a `var` pattern, the type of a declared variable is the compile-time type of the expression that is matched against the pattern.

## Discard pattern

Beginning with C# 8.0, you use a *discard pattern* `_` to match any expression, including `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/DiscardPattern.cs" id="BasicExample":::

In the preceding example, a discard pattern is used to handle `null` and any integer value that doesn't have the corresponding member of the <xref:System.DayOfWeek> enumeration. That guarantees that a `switch` expression in the example handles all possible values of its input. If you don't use a discard pattern in a `switch` expression and none of the expression's patterns matches an input, the runtime [throws an exception](switch-expression.md#non-exhaustive-switch-expressions).The compiler generates a warning if a `switch` expression doesn't handle all possible input values.

A discard pattern cannot be a pattern in an `is` expression or a `switch` statement. In those cases, to match any expression, use a [`var` pattern](#var-pattern) with a discard: `var _`.

## Parenthesized pattern

Beginning with C# 9.0, you can put parentheses around any pattern. Typically, you do that to emphasize or change the precedence in [logical patterns](#logical-patterns), as the following example shows:

:::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="ChangedPrecedence":::

## C# language specification

For more information, see the following feature proposal notes:

- [Pattern matching for C# 7.0](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Recursive pattern matching (introduced in C# 8.0)](~/_csharplang/proposals/csharp-8.0/patterns.md)
- [Pattern-matching changes for C# 9.0](~/_csharplang/proposals/csharp-9.0/patterns3.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../tutorials/pattern-matching.md)
