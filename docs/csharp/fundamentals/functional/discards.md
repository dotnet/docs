---
title: Discards - unassigned discardable variables
description: Describes C#'s support for discards, which are unassigned, discardable variables, and the ways in which discards can be used.
ms.date: 05/14/2021
---
# Discards - C# Fundamentals

Starting with C# 7.0, C# supports discards, which are placeholder variables that are intentionally unused in application code. Discards are equivalent to unassigned variables; they don't have a value. A discard communicates intent to the compiler and others that read your code: You intended to ignore the result of an expression. You may want to ignore the result of an expression, one or more members of a tuple expression, an `out` parameter to a method, or the target of a pattern matching expression.

Because there's only a single discard variable, that variable may not even be allocated storage. Discards can reduce memory allocations. Discards make the intent of your code clear. They enhance its readability and maintainability.

You indicate that a variable is a discard by assigning it the underscore (`_`) as its name. For example, the following method call returns a tuple in which the first and second values are discards. `area` is a previously declared variable set to the third component returned by `GetCityInformation`:

```csharp
(_, _, area) = city.GetCityInformation(cityName);
```

Beginning with C# 9.0, you can use discards to specify unused input parameters of a lambda expression. For more information, see the [Input parameters of a lambda expression](../../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) section of the [Lambda expressions](../../language-reference/operators/lambda-expressions.md) article.

When `_` is a valid discard, attempting to retrieve its value or use it in an assignment operation generates compiler error CS0301, "The name '\_' doesn't exist in the current context". This error is because `_` isn't assigned a value, and may not even be assigned a storage location. If it were an actual variable, you couldn't discard more than one value, as the previous example did.

## Tuple and object deconstruction

Discards are useful in working with tuples when your application code uses some tuple elements but ignores others. For example, the following `QueryCityDataForYears` method returns a tuple with the name of a city, its area, a year, the city's population for that year, a second year, and the city's population for that second year. The example shows the change in population between those two years. Of the data available from the tuple, we're unconcerned with the city area, and we know the city name and the two dates at design-time. As a result, we're only interested in the two population values stored in the tuple, and can handle its remaining values as discards.  

:::code language="csharp" source="snippets/discards/discard-tuple.cs" ID="DiscardTupleMember" :::

For more information on deconstructing tuples with discards, see [Deconstructing tuples and other types](deconstruct.md#tuple-elements-with-discards).

The `Deconstruct` method of a class, structure, or interface also allows you to retrieve and deconstruct a specific set of data from an object. You can use discards when you're interested in working with only a subset of the deconstructed values. The following example deconstructs a `Person` object into four strings (the first and last names, the city, and the state), but discards the last name and the state.

:::code language="csharp" source="snippets/discards/discard-class.cs" :::

For more information on deconstructing user-defined types with discards, see [Deconstructing tuples and other types](deconstruct.md#user-defined-type-with-discards).

## Pattern matching with `switch`

The *discard pattern* can be used in pattern matching with the [switch expression](../../language-reference/operators/switch-expression.md). Every expression, including `null`,  always matches the discard pattern.

The following example defines a `ProvidesFormatInfo` method that uses a `switch` expression to determine whether an object provides an <xref:System.IFormatProvider> implementation and tests whether the object is `null`. It also uses the discard pattern to handle non-null objects of any other type.

:::code language="csharp" source="snippets/discards/discard-pattern2.cs" ID="DiscardSwitchExample" :::

## Calls to methods with `out` parameters

When calling the `Deconstruct` method to deconstruct a user-defined type (an instance of a class, structure, or interface), you can discard the values of individual `out` arguments. But you can also discard the value of `out` arguments when calling any method with an `out` parameter.

The following example calls the [DateTime.TryParse(String, out DateTime)](<xref:System.DateTime.TryParse(System.String,System.DateTime@)>) method to determine whether the string representation of a date is valid in the current culture. Because the example is concerned only with validating the date string and not with parsing it to extract the date, the `out` argument to the method is a discard.

:::code language="csharp" source="snippets/discards/discard-out1.cs" ID="DiscardOutParameter" :::

## A standalone discard

You can use a standalone discard to indicate any variable that you choose to ignore. One typical use is to use an assignment to ensure that an argument isn't null. The following code uses a discard to force an assignment. The right side of the assignment uses the [null coalescing operator](../../language-reference/operators/null-coalescing-operator.md) to throw an <xref:System.ArgumentNullException?displayProperty=nameWithType> when the argument is `null`. The code doesn't need the result of the assignment, so it's discarded. The expression forces a null check. The discard clarifies your intent: the result of the assignment isn't needed or used.

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="ArgNullCheck" :::

The following example uses a standalone discard to ignore the <xref:System.Threading.Tasks.Task> object returned by an asynchronous operation. Assigning the task has the effect of suppressing the exception that the operation throws as it is about to complete. It makes your intent clear: You want to discard the `Task`, and ignore any errors generated from that asynchronous operation.

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="SnippetDiscardTask" :::

Without assigning the task to a discard, the following code generates a compiler warning:

:::code language="csharp" source="snippets/discards/standalone-discard1.cs" ID="SnippetNoDiscardTask" :::

> [!NOTE]
> If you run either of the preceding two samples using a debugger, the debugger will stop the program when the exception is thrown. Without a debugger attached, the exception is silently ignored in both cases.

`_` is also a valid identifier. When used outside of a supported context, `_` is treated not as a discard but as a valid variable. If an identifier named `_` is already in scope, the use of `_` as a standalone discard can result in:

- Accidental modification of the value of the in-scope `_` variable by assigning it the value of the intended discard. For example:
   :::code language="csharp" source="snippets/discards/standalone-discard2.cs" ID="VariableIdentifier" :::
- A compiler error for violating type safety. For example:
   :::code language="csharp" source="snippets/discards/standalone-discard2.cs" ID="VariableTypeInference" :::
- Compiler error CS0136, "A local or parameter named '\_' cannot be declared in this scope because that name is used in an enclosing local scope to define a local or parameter." For example:
   :::code language="csharp" source="snippets/discards/standalone-discard2.cs" ID="CannotRedeclare" :::

## See also

- [Deconstructing tuples and other types](deconstruct.md)
- [`is` operator](../../language-reference/operators/is.md)
- [`switch` expression](../../language-reference/operators/switch-expression.md)
