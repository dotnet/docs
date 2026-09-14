---
title: Discards - unassigned discardable variables
description: Describes C#'s support for discards, which are unassigned, discardable variables, and the ways in which discards can be used.
ms.date: 09/14/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# Discards - C# Fundamentals

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to pattern matching, start with the [pattern matching overview](pattern-matching.md). For the complete discard-pattern syntax, see the [patterns reference](../../language-reference/operators/patterns.md#discard-pattern).

The underscore token (`_`) can mean related but distinct things in C#. In a switch expression, a *discard pattern* is a pattern that matches every input. In declarations, deconstruction, and `out` arguments, a *discard* is an unnamed local variable whose value your code intentionally ignores. In a lambda parameter list, two or more parameters named `_` are *discard parameters*. A single `_` remains an ordinary parameter name for backward compatibility.

This article groups these uses because they share the same intent: the value isn't needed. Their language ownership differs:

| Context | Meaning of `_` | Primary concept |
| --- | --- | --- |
| A switch expression arm or nested pattern | A discard pattern that matches every input | Patterns |
| A declaration, deconstruction, or `out` argument | An unnamed local variable whose value can't be read | Variables and deconstruction |
| An assignment such as `_ = expression` | A discard assignment that ignores the expression result | Assignment |
| A lambda parameter list with two or more `_` parameters | Discard parameters that communicate that the inputs aren't used | Lambda expressions |

For example, the following deconstruction returns a tuple in which the first and second values are discards. `area` is a previously declared variable set to the third component returned by `GetCityInformation`:

```csharp
(_, _, area) = city.GetCityInformation(cityName);
```

You can use two or more `_` parameters for unused inputs to a lambda expression. For more information, see [Input parameters of a lambda expression](../../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression).

A discard local has no name. The expression that introduces it is its only reference, and its value can't be read. If `_` is instead declared as an ordinary identifier in a context where a discard isn't recognized, normal variable rules apply.

## Tuple and object deconstruction

Discards are useful in working with tuples when your application code uses some tuple elements but ignores others. For example, the following `QueryCityDataForYears` method returns a tuple with the name of a city, its area, a year, the city's population for that year, a second year, and the city's population for that second year. The example shows the change in population between those two years. Of the data available from the tuple, we're unconcerned with the city area, and we know the city name and the two dates at design-time. As a result, we're only interested in the two population values stored in the tuple, and can handle its remaining values as discards.

:::code language="csharp" source="snippets/discards/discard-tuple.cs" ID="DiscardTupleMember" :::

For more information on deconstructing tuples with discards, see [Deconstructing tuples and other types](../functional/deconstruct.md#tuple-elements-with-discards).

The `Deconstruct` method of a class, structure, or interface also allows you to retrieve and deconstruct a specific set of data from an object. You can use discards when you're interested in working with only a subset of the deconstructed values. The following example deconstructs a `Person` object into four strings (the first and last names, the city, and the state), but discards the last name and the state.

:::code language="csharp" source="snippets/discards/discard-class.cs" :::

For more information on deconstructing user-defined types with discards, see [Deconstructing tuples and other types](../functional/deconstruct.md#user-defined-type-with-discards).

## Pattern matching with `switch`

The *discard pattern* can be used as a catch-all arm in a [switch expression](../../language-reference/operators/switch-expression.md). Every input, including `null`, matches the discard pattern. Put it last because an unguarded discard arm subsumes every arm that follows it.

The following example defines a `ProvidesFormatInfo` method that uses a `switch` expression to determine whether an object provides an <xref:System.IFormatProvider> implementation and tests whether the object is `null`. It also uses the discard pattern to handle non-null objects of any other type.

:::code language="csharp" source="snippets/discards/discard-pattern2.cs" ID="DiscardSwitchExample" :::

A standalone discard pattern isn't permitted as the complete pattern after `is` or in a `switch` statement `case` label. Use `var _` after `is`, and use `default` as the catch-all label in a switch statement. A discard pattern can appear inside another pattern, such as a positional pattern.

> [!NOTE]
> In a pattern context, an accessible constant or type named `_` can cause `_` to be interpreted as that constant or type instead of as a discard pattern. Avoid declaring constants or types named `_`.

## Calls to methods with `out` parameters

When calling the `Deconstruct` method to deconstruct a user-defined type (an instance of a class, structure, or interface), you can discard the values of individual `out` arguments. But you can also discard the value of `out` arguments when calling any method with an `out` parameter.

The following example calls the [DateTime.TryParse(String, out DateTime)](<xref:System.DateTime.TryParse(System.String,System.DateTime@)>) method to determine whether the string representation of a date is valid in the current culture. Because the example is concerned only with validating the date string and not with parsing it to extract the date, the `out` argument to the method is a discard.

:::code language="csharp" source="snippets/discards/discard-out1.cs" ID="DiscardOutParameter" :::

## A standalone discard

You can use a standalone discard to indicate any variable that you choose to ignore. One typical use is to use an assignment to ensure that an argument isn't null. The following code uses a discard to force an assignment. The right side of the assignment uses the [null coalescing operator](../../language-reference/operators/null-coalescing-operator.md) to throw an <xref:System.ArgumentNullException?displayProperty=nameWithType> when the argument is `null`. The code doesn't need the result of the assignment, so it's discarded. The expression forces a null check. The discard clarifies your intent: the result of the assignment isn't needed or used.

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="ArgNullCheck" :::

The following example uses a standalone discard to ignore the <xref:System.Threading.Tasks.Task> object returned by an asynchronous operation. Assigning the task suppresses the compiler warning that the call isn't awaited. It makes your intent clear: the operation starts, but this code doesn't wait for it to finish.

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="SnippetDiscardTask" :::

Without assigning the task to a discard, the following code generates a compiler warning:

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="SnippetNoDiscardTask" :::

> [!NOTE]
> Discarding a task doesn't observe its exceptions or propagate them to the caller. Use this technique only when the application has another deliberate way to observe and report failures from the operation.

`_` is also a valid identifier. When used outside of a supported discard context, `_` is treated as a variable name. If an identifier named `_` is already in scope, an intended discard assignment can result in:

- Accidental modification of the value of the in-scope `_` variable by assigning it the value of the intended discard. For example:
   :::code language="csharp" source="snippets/discards/standalone-discard2.cs" ID="VariableIdentifier" :::
- A compiler error for violating type safety. For example:
   :::code language="csharp" source="snippets/discards/standalone-discard2.cs" ID="VariableTypeInference" :::

## See also

- [Remove unnecessary expression value (style rule IDE0058)](../../../fundamentals/code-analysis/style-rules/ide0058.md)
- [Remove unnecessary value assignment (style rule IDE0059)](../../../fundamentals/code-analysis/style-rules/ide0059.md)
- [Remove unused parameter (style rule IDE0060)](../../../fundamentals/code-analysis/style-rules/ide0060.md)
- [Pattern matching overview](pattern-matching.md)
- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [`is` operator](../../language-reference/operators/is.md)
- [`switch` expression](../../language-reference/operators/switch-expression.md)
