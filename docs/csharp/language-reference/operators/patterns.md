---
title: "Patterns - C# reference"
description: "Learn about the patterns supported by C# switch and is expressions and C# switch statement - C# reference"
ms.date: 03/10/2021
helpviewer_keywords: 
  - "pattern matching [C#]"
---
# Patterns (C# reference)

Intro.

## Declaration and type patterns

You use the declaration and type patterns to check if the runtime type of an expression is compatible with the given type. With the declaration pattern, you can also declare a new local variable. That variable is assigned a converted expression result when a pattern matches an expression.

Beginning with C# 7.0, *declaration pattern* `T v` matches expression `E` when the result of `E` is non-null and any of the following conditions are true:

- The runtime type of `E` is `T`.

- The runtime type of `E` derives from type `T` or implements interface `T` or there exists another [implicit reference conversion](~/_csharplang/spec/conversions.md#implicit-reference-conversions) from it to type `T`. The following example demonstrates two cases when this condition is true:

  :::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="ReferenceConversion":::

  In the preceding example, at the first call to the `GetSourceLabel` method, an argument value is matched by the first pattern because its runtime type `int[]` derives from the <xref:System.Array> type. At the second call to the `GetSourceLabel` method, the runtime type of an argument is <xref:System.Collections.Generic.List%601> that doesn't derive from the <xref:System.Array> type but implements the <xref:System.Collections.Generic.ICollection%601> interface.

- The runtime type of `E` is a [nullable value type](../builtin-types/nullable-value-types.md) with the underlying type `T`.

- A [boxing](../../programming-guide/types/boxing-and-unboxing.md#boxing) or [unboxing](../../programming-guide/types/boxing-and-unboxing.md#unboxing) conversion exists from the runtime type of `E` to type `T`.

The following example demonstrates the last two of the preceding conditions:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="NullableAndUnboxing":::

If you want to check only the type of an expression, you can use a discard `_` in place of a variable name as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="DiscardVariable":::

Beginning with C# 9.0, for that purpose you can use the *type pattern* as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePattern.cs" id="TypePattern":::

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

Beginning with C# 9.0, you can use the [negated](#pattern-combinators) `null` constant pattern to check for non-null, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="NonNullCheck":::

## Discard pattern

Beginning with C# 8.0, you use the *discard pattern* `_` to match any expression, including `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/DiscardPattern.cs" id="BasicExample":::

The discard pattern is useful in `switch` expressions. If none of a `switch` expression's patterns matches an input, the runtime throws an exception. To guarantee that a `switch` expression handles all possible values of its input as you want, provide an arm with the discard pattern. As a `switch` expression evaluates its arms in text order, the arm with the discard pattern must be last.

The discard pattern cannot be a pattern in an `is` expression or a `switch` statement.

## Relational patterns

Beginning with C# 9.0, you use a *relational pattern* to compare an expression result with a constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="BasicExample":::

In a relational pattern, you can use any of the [relational operators](comparison-operators.md) `<`, `>`, `<=`, or `>=`. A constant to compare with can be of an [integral](../builtin-types/integral-numeric-types.md), [floating-point](../builtin-types/floating-point-numeric-types.md), [char](../builtin-types/char.md), or [enum](../builtin-types/enum.md) type.

To check if an expression value is at a certain range, match it against a [combined pattern](#pattern-combinators), as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="WithCombinators":::

A relational pattern doesn't match an expression if an expression result is `null` or it fails to convert to the type of a constant by a nullable or unboxing conversion.

## Pattern combinators

Beginning with C# 9.0, you use the `not`, `and`, and `or` pattern combinators to create the following patterns from other patterns:

- *Negation* `not` pattern that matches an expression when the negated pattern doesn't match the expression. For example, you can negate the [constant](#constant-pattern) `null` pattern to check if an expression is non-null, as the following code shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="NotPattern":::

- *Conjunctive* `and` pattern that matches an expression when both patterns match the expression. For example, you can combine [relational patterns](#relational-patterns) to check if a value is in a certain range, as the following code shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="AndPattern":::

- *Disjunctive* `or` pattern that matches an expression when either of patterns matches the expression, as the following example shows:

  :::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="OrPattern":::

As the preceding example shows, you can repeatedly use the pattern combinators in a pattern. When you use both `and` and `or` pattern combinators within one pattern, `and` has higher precedence than `or`. To explicitly specify the precedence, use parentheses, as the following example shows:

:::code language="csharp" source="snippets/patterns/PatternCombinators.cs" id="WithParentheses":::

## C# language specification

For more information, see the following feature proposal notes:

- [Pattern matching for C# 7.0](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Recursive pattern matching (introduced in C# 8.0)](~/_csharplang/proposals/csharp-8.0/patterns.md)
- [Pattern-matching changes for C# 9.0](~/_csharplang/proposals/csharp-9.0/patterns3.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../tutorials/pattern-matching.md)
