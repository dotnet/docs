---
title: "Patterns - C# reference"
description: "Learn about the patterns supported by C# pattern matching expressions and statements."
ms.date: 08/23/2021
f1_keywords: 
  - "and_CSharpKeyword"
  - "or_CSharpKeyword"
  - "not_CSharpKeyword"
helpviewer_keywords: 
  - "pattern matching [C#]"
  - "and keyword [C#]"
  - "or keyword [C#]"
  - "not keyword [C#]"
---
# Patterns (C# reference)

C# introduced pattern matching in C# 7.0. Since then, each major C# version extends pattern matching capabilities. The following C# expressions and statements support pattern matching:

- [`is` expression](is.md)
- `switch` [statement](../statements/selection-statements.md#the-switch-statement)
- `switch` [expression](switch-expression.md) (introduced in C# 8.0)

In those constructs, you can match an input expression against any of the following patterns:

- [Declaration pattern](#declaration-and-type-patterns): to check the run-time type of an expression and, if a match succeeds, assign an expression result to a declared variable. Introduced in C# 7.0.
- [Type pattern](#declaration-and-type-patterns): to check the run-time type of an expression. Introduced in C# 9.0.
- [Constant pattern](#constant-pattern): to test if an expression result equals a specified constant. Introduced in C# 7.0.
- [Relational patterns](#relational-patterns): to compare an expression result with a specified constant. Introduced in C# 9.0.
- [Logical patterns](#logical-patterns): to test if an expression matches a logical combination of patterns. Introduced in C# 9.0.
- [Property pattern](#property-pattern): to test if an expression's properties or fields match nested patterns. Introduced in C# 8.0.
- [Positional pattern](#positional-pattern): to deconstruct an expression result and test if the resulting values match nested patterns. Introduced in C# 8.0.
- [`var` pattern](#var-pattern): to match any expression and assign its result to a declared variable. Introduced in C# 7.0.
- [Discard pattern](#discard-pattern): to match any expression. Introduced in C# 8.0.

[Logical](#logical-patterns), [property](#property-pattern), and [positional](#positional-pattern) patterns are *recursive* patterns. That is, they can contain *nested* patterns.

For the example of how to use those patterns to build a data-driven algorithm, see [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md).

## Declaration and type patterns

You use declaration and type patterns to check if the run-time type of an expression is compatible with a given type. With a declaration pattern, you can also declare a new local variable. When a declaration pattern matches an expression, that variable is assigned a converted expression result, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="BasicExample":::

Beginning with C# 7.0, a *declaration pattern* with type `T` matches an expression when an expression result is non-null and any of the following conditions are true:

- The run-time type of an expression result is `T`.

- The run-time type of an expression result derives from type `T`, implements interface `T`, or another [implicit reference conversion](~/_csharplang/spec/conversions.md#implicit-reference-conversions) exists from it to `T`. The following example demonstrates two cases when this condition is true:

  :::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="ReferenceConversion":::

  In the preceding example, at the first call to the `GetSourceLabel` method, the first pattern matches an argument value because the argument's run-time type `int[]` derives from the <xref:System.Array> type. At the second call to the `GetSourceLabel` method, the argument's run-time type <xref:System.Collections.Generic.List%601> doesn't derive from the <xref:System.Array> type but implements the <xref:System.Collections.Generic.ICollection%601> interface.

- The run-time type of an expression result is a [nullable value type](../builtin-types/nullable-value-types.md) with the underlying type `T`.

- A [boxing](../../programming-guide/types/boxing-and-unboxing.md#boxing) or [unboxing](../../programming-guide/types/boxing-and-unboxing.md#unboxing) conversion exists from the run-time type of an expression result to type `T`.

The following example demonstrates the last two conditions:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="NullableAndUnboxing":::

If you want to check only the type of an expression, you can use a discard `_` in place of a variable's name, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="DiscardVariable":::

Beginning with C# 9.0, for that purpose you can use a *type pattern*, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="TypePattern":::

Like a declaration pattern, a type pattern matches an expression when an expression result is non-null and its run-time type satisfies any of the conditions listed above.

For more information, see the [Declaration pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#declaration-pattern) and [Type pattern](~/_csharplang/proposals/csharp-9.0/patterns3.md#type-patterns) sections of the feature proposal notes.

## Constant pattern

Beginning with C# 7.0, you use a *constant pattern* to test if an expression result equals a specified constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="BasicExample":::

In a constant pattern, you can use any constant expression, such as:

- an [integer](../builtin-types/integral-numeric-types.md) or [floating-point](../builtin-types/floating-point-numeric-types.md) numerical literal
- a [char](../builtin-types/char.md) or a [string](../builtin-types/reference-types.md#the-string-type) literal
- a Boolean value `true` or `false`
- an [enum](../builtin-types/enum.md) value
- the name of a declared [const](../keywords/const.md) field or local
- `null`

Use a constant pattern to check for `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="NullCheck":::

The compiler guarantees that no user-overloaded equality operator `==` is invoked when expression `x is null` is evaluated.

Beginning with C# 9.0, you can use a [negated](#logical-patterns) `null` constant pattern to check for non-null, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="NonNullCheck":::

For more information, see the [Constant pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#constant-pattern) section of the feature proposal note.

## Relational patterns

Beginning with C# 9.0, you use a *relational pattern* to compare an expression result with a constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="BasicExample":::

In a relational pattern, you can use any of the [relational operators](comparison-operators.md) `<`, `>`, `<=`, or `>=`. The right-hand part of a relational pattern must be a constant expression. The constant expression can be of an [integer](../builtin-types/integral-numeric-types.md), [floating-point](../builtin-types/floating-point-numeric-types.md), [char](../builtin-types/char.md), or [enum](../builtin-types/enum.md) type.

To check if an expression result is in a certain range, match it against a [conjunctive `and` pattern](#logical-patterns), as the following example shows:

:::code language="csharp" source="snippets/patterns/RelationalPatterns.cs" id="WithCombinators":::

If an expression result is `null` or fails to convert to the type of a constant by a nullable or unboxing conversion, a relational pattern doesn't match an expression.

For more information, see the [Relational patterns](~/_csharplang/proposals/csharp-9.0/patterns3.md#relational-patterns) section of the feature proposal note.

## Logical patterns

Beginning with C# 9.0, you use the `not`, `and`, and `or` pattern combinators to create the following *logical patterns*:

- *Negation* `not` pattern that matches an expression when the negated pattern doesn't match the expression. The following example shows how you can negate a [constant](#constant-pattern) `null` pattern to check if an expression is non-null:

  :::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="NotPattern":::

- *Conjunctive* `and` pattern that matches an expression when both patterns match the expression. The following example shows how you can combine [relational patterns](#relational-patterns) to check if a value is in a certain range:

  :::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="AndPattern":::

- *Disjunctive* `or` pattern that matches an expression when either of patterns matches the expression, as the following example shows:

  :::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="OrPattern":::

As the preceding example shows, you can repeatedly use the pattern combinators in a pattern.

### Precedence and order of checking

The following list orders pattern combinators starting from the highest precedence to the lowest:

- `not`
- `and`
- `or`

To explicitly specify the precedence, use parentheses, as the following example shows:

:::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="WithParentheses":::

> [!NOTE]
> The order in which patterns are checked is undefined. At run time, the right-hand nested patterns of `or` and `and` patterns can be checked first.

For more information, see the [Pattern combinators](~/_csharplang/proposals/csharp-9.0/patterns3.md#pattern-combinators) section of the feature proposal note.

## Property pattern

Beginning with C# 8.0, you use a *property pattern* to match an expression's properties or fields against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="BasicExample":::

A property pattern matches an expression when an expression result is non-null and every nested pattern matches the corresponding property or field of the expression result.

You can also add a run-time type check and a variable declaration to a property pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="WithTypeCheck":::

A property pattern is a recursive pattern. That is, you can use any pattern as a nested pattern. Use a property pattern to match parts of data against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="RecursivePropertyPattern":::

The preceding example uses two features available in C# 9.0 and later: `or` [pattern combinator](#logical-patterns) and [record types](../builtin-types/record.md).

Beginning with C# 10, you can reference nested properties or fields within a property pattern. For example, you can refactor the method from the preceding example into the following equivalent code:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="ExtendedPropertyPattern":::

For more information, see the [Property pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#property-pattern) section of the feature proposal note and the [Extended property patterns](~/_csharplang/proposals/csharp-10.0/extended-property-patterns.md) feature proposal note.

## Positional pattern

Beginning with C# 8.0, you use a *positional pattern* to deconstruct an expression result and match the resulting values against the corresponding nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="BasicExample":::

At the preceding example, the type of an expression contains the [Deconstruct](../../fundamentals/functional/deconstruct.md) method, which is used to deconstruct an expression result. You can also match expressions of [tuple types](../builtin-types/value-tuples.md) against positional patterns. In that way, you can match multiple inputs against various patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="MatchTuple":::

The preceding example uses [relational](#relational-patterns) and [logical](#logical-patterns) patterns, which are available in C# 9.0 and later.

You can use the names of tuple elements and `Deconstruct` parameters in a positional pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="UseIdentifiers":::

You can also extend a positional pattern in any of the following ways:

- Add a run-time type check and a variable declaration, as the following example shows:

  :::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="WithTypeCheck":::

  The preceding example uses [positional records](../builtin-types/record.md#positional-syntax-for-property-definition) that implicitly provide the `Deconstruct` method.

- Use a [property pattern](#property-pattern) within a positional pattern, as the following example shows:

  :::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="WithPropertyPattern":::

- Combine two preceding usages, as the following example shows:

  :::code language="csharp" source="snippets/patterns/PositionalPattern.cs" id="CompletePositionalPattern":::

A positional pattern is a recursive pattern. That is, you can use any pattern as a nested pattern.

For more information, see the [Positional pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#positional-pattern) section of the feature proposal note.

## `var` pattern

Beginning with C# 7.0, you use a *`var` pattern* to match any expression, including `null`, and assign its result to a new local variable, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="KeepInterimResult":::

A `var` pattern is useful when you need a temporary variable within a Boolean expression to hold the result of intermediate calculations. You can also use a `var` pattern when you need to perform additional checks in `when` case guards of a `switch` expression or statement, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="WithCaseGuards":::

In the preceding example, pattern `var (x, y)` is equivalent to a [positional pattern](#positional-pattern) `(var x, var y)`.

In a `var` pattern, the type of a declared variable is the compile-time type of the expression that is matched against the pattern.

For more information, see the [Var pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#var-pattern) section of the feature proposal note.

## Discard pattern

Beginning with C# 8.0, you use a *discard pattern* `_` to match any expression, including `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/DiscardPattern.cs" id="BasicExample":::

In the preceding example, a discard pattern is used to handle `null` and any integer value that doesn't have the corresponding member of the <xref:System.DayOfWeek> enumeration. That guarantees that a `switch` expression in the example handles all possible input values. If you don't use a discard pattern in a `switch` expression and none of the expression's patterns matches an input, the runtime [throws an exception](switch-expression.md#non-exhaustive-switch-expressions). The compiler generates a warning if a `switch` expression doesn't handle all possible input values.

A discard pattern cannot be a pattern in an `is` expression or a `switch` statement. In those cases, to match any expression, use a [`var` pattern](#var-pattern) with a discard: `var _`.

For more information, see the [Discard pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#discard-pattern) section of the feature proposal note.

## Parenthesized pattern

Beginning with C# 9.0, you can put parentheses around any pattern. Typically, you do that to emphasize or change the precedence in [logical patterns](#logical-patterns), as the following example shows:

:::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="ChangedPrecedence":::

## C# language specification

For more information, see the following feature proposal notes:

- [Pattern matching for C# 7.0](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Recursive pattern matching (introduced in C# 8.0)](~/_csharplang/proposals/csharp-8.0/patterns.md)
- [Pattern-matching changes for C# 9.0](~/_csharplang/proposals/csharp-9.0/patterns3.md)
- [Extended property patterns (C# 10)](~/_csharplang/proposals/csharp-10.0/extended-property-patterns.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md)
