---
title: Pattern matching overview - C# guide
description: Learn about pattern matching expressions in C#
ms.date: 05/14/2021
---

# Pattern matching overview

*Pattern matching* is a technique where you test an expression to determine if it has certain characteristics. C# pattern matching provides more concise syntax for testing expressions and taking action when an expression matches. The "[`is`](../../language-reference/operators/is.md) expression" supports pattern matching to test an expression and conditionally declare a new variable to the result of that expression. The "[`switch`](../../language-reference/operators/switch-expression.md) expression" enables you to perform actions based on the first matching pattern for an expression. These two expressions support a rich vocabulary of [*patterns*](../../language-reference/operators/patterns.md).

This article provides an overview of scenarios where you can use pattern matching. These techniques can improve the readability and correctness of your code. For a full discussion of all the patterns you can apply, see the article on [patterns](../../language-reference/operators/patterns.md) in the language reference.

## Null checks

One of the most common scenarios for pattern matching is to ensure values aren't `null`. You can test and convert a nullable value type to its underlying type while testing for `null` using the following example:

:::code language="csharp" source="snippets/patterns/Program.cs" ID="NullableCheck":::

The preceding code is a [*declaration pattern*](../../language-reference/operators/patterns.md#declaration-and-type-patterns) to test the type of the variable, and assign it to a new variable. The language rules make this technique safer than many others. The variable `number` is only accessible and assigned in the true portion of the `if` clause. If you try to access it elsewhere, either in the `else` clause, or after the `if` block, the compiler issues an error. Secondly, because you're not using the `==` operator, this pattern works when a type overloads the `==` operator. That makes it an ideal way to check null reference values, adding the `not` pattern:

:::code language="csharp" source="snippets/patterns/Program.cs" ID="NullReferenceCheck":::

The preceding example used a [*constant pattern*](../../language-reference/operators/patterns.md#constant-pattern) to compare the variable to `null`. The `not` is a [*logical pattern*](../../language-reference/operators/patterns.md#logical-patterns) that matches when the negated pattern doesn't match.

## Type tests

Another common use for pattern matching is to test a variable to see if it matches a given type. For example, the following code tests if a variable is non-null and implements the <xref:System.Collections.Generic.IList%601?displayProperty=nameWithType> interface. If it does, it uses the <xref:System.Collections.Generic.ICollection%601.Count?displayProperty=nameWithType> property on that list to find the middle index. The declaration pattern doesn't match a `null` value, regardless of the compile-time type of the variable. The code below guards against `null`, in addition to guarding against a type that doesn't implement `IList`.

:::code language="csharp" source="snippets/patterns/Program.cs" ID="MidPoint":::

The same tests can be applied in a `switch` expression to test a variable against multiple different types. You can use that information to create better algorithms based on the specific run-time type.

## Compare discrete values

You can also test a variable to find a match on specific values. The following code shows one example where you test a value against all possible values declared in an enumeration:

:::code language="csharp" source="snippets/patterns/Simulation.cs" ID="PerformOperation":::

The previous example demonstrates a method dispatch based on the value of an enumeration. The final `_` case is a [*discard pattern*](../../language-reference/operators/patterns.md#discard-pattern) that matches all values. It handles any error conditions where the value doesn't match one of the defined `enum` values. If you omit that switch arm, the compiler warns that you haven't handled all possible input values. At run time, the `switch` expression throws an exception if the object being examined doesn't match any of the switch arms. You could use numeric constants instead of a set of enum values. You can also use this similar technique for constant string values that represent the commands:

:::code language="csharp" source="snippets/patterns/Simulation.cs" ID="PerformStringOperation":::

The preceding example shows the same algorithm, but uses string values instead of an enum. You would use this scenario if your application responds to text commands instead of a regular data format. In all these examples, the *discard pattern* ensures that you handle every input. The compiler helps you by making sure every possible input value is handled.

## Relational patterns

You can use [*relational patterns*](../../language-reference/operators/patterns.md#relational-patterns) to test how a value compares to constants. For example, the following code returns the state of water based on the temperature in Fahrenheit:

:::code language="csharp" source="snippets/patterns/Simulation.cs" ID="RelationalPattern":::

The preceding code also demonstrates the conjunctive `and` [*logical pattern*](../../language-reference/operators/patterns.md#logical-patterns) to check that both relational patterns match. You can also use a disjunctive `or` pattern to check that either pattern matches. The two relational patterns are surrounded by parentheses, which you can use around any pattern for clarity. The final two switch arms handle the cases for the melting point and the boiling point. Without those two arms, the compiler warns you that your logic doesn't cover every possible input.

The preceding code also demonstrates another important feature the compiler provides for pattern matching expressions: The compiler warns you if you don't handle every input value. The compiler also issues a warning if a switch arm is already handled by a previous switch arm. That gives you freedom to refactor and reorder switch expressions. Another way to write the same expression could be:

:::code language="csharp" source="snippets/patterns/Simulation.cs" ID="RelationalPattern2":::

The key lesson in this, and any other refactoring or reordering is that the compiler validates that you've covered all inputs.

## Multiple inputs

All the patterns you've seen so far have been checking one input. You can write patterns that examine multiple properties of an object. Consider the following `Order` record:

:::code language="csharp" source="snippets/patterns/OrderProcessor.cs" ID="OrderRecord":::

The preceding positional record type declares two members at explicit positions. Appearing first is the `Items`, then the order's `Cost`. For more information, see [Records](../../language-reference/builtin-types/record.md).

The following code examines the number of items and the value of an order to calculate a discounted price:

:::code language="csharp" source="snippets/patterns/OrderProcessor.cs" ID="PropertyPattern":::

The first two arms examine two properties of the `Order`. The third examines only the cost. The next checks against `null`, and the final matches any other value. If the `Order` type defines a suitable [`Deconstruct`](deconstruct.md) method, you can omit the property names from the pattern and use deconstruction to examine properties:

:::code language="csharp" source="snippets/patterns/OrderProcessor.cs" ID="DeconstructPattern":::

The preceding code demonstrates the [*positional pattern*](../../language-reference/operators/patterns.md#positional-pattern) where the properties are deconstructed for the expression.

This article provided a tour of the kinds of code you can write with pattern matching in C#. The following articles show more examples of using patterns in scenarios, and the full vocabulary of patterns available to use.

## See also

- [Exploration: Use pattern matching to build your class behavior for better code](../../whats-new/tutorials/patterns-objects.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../tutorials/pattern-matching.md)
- [Reference: Pattern matching](../../language-reference/operators/patterns.md)
