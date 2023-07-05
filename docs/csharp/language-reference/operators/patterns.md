---
title: "Patterns - Pattern matching using the is and switch expressions."
description: "Learn about the patterns supported by the `is` and `switch` expressions. Combine multiple patterns using the `and`, `or`, and `not` operators."
ms.date: 01/30/2023
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
# Pattern matching - the `is` and `switch` expressions, and operators `and`, `or` and `not` in patterns

You use the [`is` expression](is.md), the [switch statement](../statements/selection-statements.md#the-switch-statement) and the [switch expression](switch-expression.md) to match an input expression against any number of characteristics. C# supports multiple patterns, including declaration, type, constant, relational, property, list, var, and discard. Patterns can be combined using Boolean logic keywords `and`, `or`, and `not`.

The following C# expressions and statements support pattern matching:

- [`is` expression](is.md)
- [switch statement](../statements/selection-statements.md#the-switch-statement)
- [switch expression](switch-expression.md)

In those constructs, you can match an input expression against any of the following patterns:

- [Declaration pattern](#declaration-and-type-patterns): to check the run-time type of an expression and, if a match succeeds, assign an expression result to a declared variable.
- [Type pattern](#declaration-and-type-patterns): to check the run-time type of an expression. Introduced in C# 9.0.
- [Constant pattern](#constant-pattern): to test if an expression result equals a specified constant.
- [Relational patterns](#relational-patterns): to compare an expression result with a specified constant. Introduced in C# 9.0.
- [Logical patterns](#logical-patterns): to test if an expression matches a logical combination of patterns. Introduced in C# 9.0.
- [Property pattern](#property-pattern): to test if an expression's properties or fields match nested patterns.
- [Positional pattern](#positional-pattern): to deconstruct an expression result and test if the resulting values match nested patterns.
- [`var` pattern](#var-pattern): to match any expression and assign its result to a declared variable.
- [Discard pattern](#discard-pattern): to match any expression.
- [List patterns](#list-patterns): to test if sequence elements match corresponding nested patterns. Introduced in C# 11.

[Logical](#logical-patterns), [property](#property-pattern), [positional](#positional-pattern), and [list](#list-patterns) patterns are *recursive* patterns. That is, they can contain *nested* patterns.

For the example of how to use those patterns to build a data-driven algorithm, see [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md).

## Declaration and type patterns

You use declaration and type patterns to check if the run-time type of an expression is compatible with a given type. With a declaration pattern, you can also declare a new local variable. When a declaration pattern matches an expression, that variable is assigned a converted expression result, as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="BasicExample":::

A *declaration pattern* with type `T` matches an expression when an expression result is non-null and any of the following conditions are true:

- The run-time type of an expression result is `T`.

- The run-time type of an expression result derives from type `T`, implements interface `T`, or another [implicit reference conversion](~/_csharpstandard/standard/conversions.md#1028-implicit-reference-conversions) exists from it to `T`. The following example demonstrates two cases when this condition is true:

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

To check for non-null, you can use a [negated](#logical-patterns) `null` [constant pattern](#constant-pattern), as the following example shows:

:::code language="csharp" source="snippets/patterns/DeclarationAndTypePatterns.cs" id="NonNullCheck":::

For more information, see the [Declaration pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#declaration-pattern) and [Type pattern](~/_csharplang/proposals/csharp-9.0/patterns3.md#type-patterns) sections of the feature proposal notes.

## Constant pattern

You use a *constant pattern* to test if an expression result equals a specified constant, as the following example shows:

:::code language="csharp" source="snippets/patterns/ConstantPattern.cs" id="BasicExample":::

In a constant pattern, you can use any constant expression, such as:

- an [integer](../builtin-types/integral-numeric-types.md) or [floating-point](../builtin-types/floating-point-numeric-types.md) numerical literal
- a [char](../builtin-types/char.md)
- a [string](../builtin-types/reference-types.md#the-string-type) literal.
- a Boolean value `true` or `false`
- an [enum](../builtin-types/enum.md) value
- the name of a declared [const](../keywords/const.md) field or local
- `null`

The expression must be a type that is convertible to the constant type, with one exception: An expression whose type is `Span<char>` or `ReadOnlySpan<char>` can be matched against constant strings in C# 11 and later versions.

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

- *Disjunctive* `or` pattern that matches an expression when either pattern matches the expression, as the following example shows:

  :::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="OrPattern":::

As the preceding example shows, you can repeatedly use the pattern combinators in a pattern.

### Precedence and order of checking

A pattern that is part of an `is` expression has *relational* precedence. It's the same precedence as the `is` operator. Pattern expressions in the `case` arms of a `switch` statement have the same precedence as the *conditional logical* operators (`||` and `&&`). Pattern expressions inside a `switch` expression have the same precedence as the coalescing operators (`??` and `throw` expressions).

The individual pattern expressions are evaluated in order, except as noted for the pattern combinators. The pattern combinators are ordered from the highest precedence to the lowest as shown in the following list:

- `not`
- `and`
- `or`

To explicitly specify the precedence, use parentheses, as the following example shows:

:::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="WithParentheses":::

> [!NOTE]
> The order in which patterns are checked is undefined. At run time, the right-hand nested patterns of `or` and `and` patterns can be checked first.

For more information, see the [Pattern combinators](~/_csharplang/proposals/csharp-9.0/patterns3.md#pattern-combinators) section of the feature proposal note.

## Property pattern

You use a *property pattern* to match an expression's properties or fields against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="BasicExample":::

A property pattern matches an expression when an expression result is non-null and every nested pattern matches the corresponding property or field of the expression result.

You can also add a run-time type check and a variable declaration to a property pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="WithTypeCheck":::

A property pattern is a recursive pattern. That is, you can use any pattern as a nested pattern. Use a property pattern to match parts of data against nested patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="RecursivePropertyPattern":::

The preceding example uses two features available in C# 9.0 and later: `or` [pattern combinator](#logical-patterns) and [record types](../builtin-types/record.md).

Beginning with C# 10, you can reference nested properties or fields within a property pattern. This capability is known as an *extended property pattern*. For example, you can refactor the method from the preceding example into the following equivalent code:

:::code language="csharp" source="snippets/patterns/PropertyPattern.cs" id="ExtendedPropertyPattern":::

For more information, see the [Property pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#property-pattern) section of the feature proposal note and the [Extended property patterns](~/_csharplang/proposals/csharp-10.0/extended-property-patterns.md) feature proposal note.

> [!TIP]
> You can use the [Simplify property pattern (IDE0170)](../../../fundamentals/code-analysis/style-rules/ide0170.md) style rule to improve code readability by suggesting places to use extended property patterns.

## Positional pattern

You use a *positional pattern* to deconstruct an expression result and match the resulting values against the corresponding nested patterns, as the following example shows:

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

You use a *`var` pattern* to match any expression, including `null`, and assign its result to a new local variable, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="KeepInterimResult":::

A `var` pattern is useful when you need a temporary variable within a Boolean expression to hold the result of intermediate calculations. You can also use a `var` pattern when you need to perform more checks in `when` case guards of a `switch` expression or statement, as the following example shows:

:::code language="csharp" source="snippets/patterns/VarPattern.cs" id="WithCaseGuards":::

In the preceding example, pattern `var (x, y)` is equivalent to a [positional pattern](#positional-pattern) `(var x, var y)`.

In a `var` pattern, the type of a declared variable is the compile-time type of the expression that is matched against the pattern.

For more information, see the [Var pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#var-pattern) section of the feature proposal note.

## Discard pattern

You use a *discard pattern* `_` to match any expression, including `null`, as the following example shows:

:::code language="csharp" source="snippets/patterns/DiscardPattern.cs" id="BasicExample":::

In the preceding example, a discard pattern is used to handle `null` and any integer value that doesn't have the corresponding member of the <xref:System.DayOfWeek> enumeration. That guarantees that a `switch` expression in the example handles all possible input values. If you don't use a discard pattern in a `switch` expression and none of the expression's patterns matches an input, the runtime [throws an exception](switch-expression.md#non-exhaustive-switch-expressions). The compiler generates a warning if a `switch` expression doesn't handle all possible input values.

A discard pattern can't be a pattern in an `is` expression or a `switch` statement. In those cases, to match any expression, use a [`var` pattern](#var-pattern) with a discard: `var _`. A discard pattern can be a pattern in a `switch` expression.

For more information, see the [Discard pattern](~/_csharplang/proposals/csharp-8.0/patterns.md#discard-pattern) section of the feature proposal note.

## Parenthesized pattern

Beginning with C# 9.0, you can put parentheses around any pattern. Typically, you do that to emphasize or change the precedence in [logical patterns](#logical-patterns), as the following example shows:

:::code language="csharp" source="snippets/patterns/LogicalPatterns.cs" id="ChangedPrecedence":::

## List patterns

Beginning with C# 11, you can match an array or a list against a *sequence* of patterns, as the following example shows:

:::code language="csharp" source="snippets/patterns/ListPattern.cs" id="BasicExample":::

As the preceding example shows, a list pattern is matched when each nested pattern is matched by the corresponding element of an input sequence. You can use any pattern within a list pattern. To match any element, use the [discard pattern](#discard-pattern) or, if you also want to capture the element, the [var pattern](#var-pattern), as the following example shows:

:::code language="csharp" source="snippets/patterns/ListPattern.cs" id="MatchAnyElement":::

The preceding examples match a whole input sequence against a list pattern. To match elements only at the start or/and the end of an input sequence, use the *slice pattern* `..`, as the following example shows:

:::code language="csharp" source="snippets/patterns/ListPattern.cs" id="UseSlice":::

A slice pattern matches zero or more elements. You can use at most one slice pattern in a list pattern. The slice pattern can only appear in a list pattern.

You can also nest a subpattern within a slice pattern, as the following example shows:

:::code language="csharp" source="snippets/patterns/ListPattern.cs" id="SliceWithPattern":::

For more information, see the [List patterns](~/_csharplang/proposals/csharp-11.0/list-patterns.md) feature proposal note.

## C# language specification

For more information, see the [Patterns and pattern matching](~/_csharpstandard/standard/patterns.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For information about features added in C# 8 and later, see the following feature proposal notes:

- [C# 8 - Recursive pattern matching](~/_csharplang/proposals/csharp-8.0/patterns.md)
- [C# 9 - Pattern-matching updates](~/_csharplang/proposals/csharp-9.0/patterns3.md)
- [C# 10 - Extended property patterns](~/_csharplang/proposals/csharp-10.0/extended-property-patterns.md)
- [C# 11 - List patterns](~/_csharplang/proposals/csharp-11.0/list-patterns.md)
- [C# 11 - Pattern match `Span<char>` on string literal](~/_csharplang/proposals/csharp-11.0/pattern-match-span-of-char-on-string.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Pattern matching overview](../../fundamentals/functional/pattern-matching.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md)
