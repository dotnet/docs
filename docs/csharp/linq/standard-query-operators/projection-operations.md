---
title: "Projection operations in LINQ"
description: Learn about projection operations. These operations transform an object into a new form that often consists only of properties used later.
ms.date: 05/29/2024
ms.topic: article
---
# Projection operations (C#)

Projection refers to the operation of transforming an object into a new form that often consists only of those properties subsequently used. By using projection, you can construct a new type that is built from each object. You can project a property and perform a mathematical function on it. You can also project the original object without changing it.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

The standard query operator methods that perform projection are listed in the following section.

## Methods

| Method names | Description | C# query expression syntax | More information |
|--|--|--|--|
| Select | Projects values that are based on a transform function. | `select` | <xref:System.Linq.Enumerable.Select%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Select%2A?displayProperty=nameWithType> |
| SelectMany | Projects sequences of values that are based on a transform function and then flattens them into one sequence. | Use multiple `from` clauses | <xref:System.Linq.Enumerable.SelectMany%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.SelectMany%2A?displayProperty=nameWithType> |
| Zip | Produces a sequence of tuples with elements from 2-3 specified sequences. | Not applicable. | <xref:System.Linq.Enumerable.Zip%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Zip%2A?displayProperty=nameWithType> |

## `Select`

The following example uses the `select` clause to project the first letter from each string in a list of strings.

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectSimpleQuery":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectSimpleMethod":::

## `SelectMany`

The following example uses multiple `from` clauses to project each word from each string in a list of strings.

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectManyQuery":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectManyMethod":::

The `SelectMany` method can also form the combination of matching every item in the first sequence with every item in the second sequence:

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectManyQuery2":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectManyMethod2":::

## `Zip`

There are several overloads for the `Zip` projection operator. All of the `Zip` methods work on sequences of two or more possibly heterogenous types. The first two overloads return tuples, with the corresponding positional type from the given sequences.

Consider the following collections:

:::code language="csharp" source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="NumbersAndLetters":::

To project these sequences together, use the <xref:System.Linq.Enumerable.Zip%60%602(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IEnumerable{%60%601})?displayProperty=nameWithType> operator:

:::code source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="ZipTuple":::

> [!IMPORTANT]
> The resulting sequence from a zip operation is never longer in length than the shortest sequence. The `numbers` and `letters` collections differ in length, and the resulting sequence omits the last element from the `numbers` collection, as it has nothing to zip with.

The second overload accepts a `third` sequence. Let's create another collection, namely `emoji`:

:::code source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="Emoji":::

To project these sequences together, use the <xref:System.Linq.Enumerable.Zip%60%603(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IEnumerable{%60%601},System.Collections.Generic.IEnumerable{%60%602})?displayProperty=nameWithType> operator:

:::code source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="ZipTriple":::

Much like the previous overload, the `Zip` method projects a tuple, but this time with three elements.

The third overload accepts a `Func<TFirst, TSecond, TResult>` argument that acts as a results selector. You can project a new resulting sequence from the sequences being zipped.

:::code source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="ZipResultSelector":::

With the preceding `Zip` overload, the specified function is applied to the corresponding elements `numbers` and `letter`, producing a sequence of the `string` results.

## `Select` versus `SelectMany`

The work of both `Select` and `SelectMany` is to produce a result value (or values) from source values. `Select` produces one result value for every source value. The overall result is therefore a collection that has the same number of elements as the source collection. In contrast, `SelectMany` produces a single overall result that contains concatenated subcollections from each source value. The transform function that is passed as an argument to `SelectMany` must return an enumerable sequence of values for each source value. `SelectMany` concatenates these enumerable sequences to create one large sequence.

The following two illustrations show the conceptual difference between the actions of these two methods. In each case, assume that the selector (transform) function selects the array of flowers from each source value.

This illustration depicts how `Select` returns a collection that has the same number of elements as the source collection.

:::image type="content" source="./media/projection-operations/select-action-graphic.png" alt-text="Graphic that shows the action of Select()":::

This illustration depicts how `SelectMany` concatenates the intermediate sequence of arrays into one final result value that contains each value from each intermediate array.

:::image type="content" source="./media/projection-operations/select-many-action-graphic.png" alt-text="Graphic showing the action of SelectMany()":::

### Code example

The following example compares the behavior of `Select` and `SelectMany`. The code creates a "bouquet" of flowers by taking the items from each list of flower names in the source collection. In the following example, the "single value" that the transform function <xref:System.Linq.Enumerable.Select%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29> uses is a collection of values. This example requires the extra `foreach` loop in order to enumerate each string in each subsequence.

:::code source="./snippets/standard-query-operators/SelectProjectionExamples.cs" id="SelectVsSelectMany":::

## See also

- <xref:System.Linq>
- [select clause](../../language-reference/keywords/select-clause.md)
- [How to populate object collections from multiple sources (LINQ) (C#)](../how-to-query-collections.md)
- [How to split a file into many files by using groups (LINQ) (C#)](../how-to-query-files-and-directories.md)
