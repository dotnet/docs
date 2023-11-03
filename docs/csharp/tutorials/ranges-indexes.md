---
title: Explore ranges of data using indices and ranges
description: This advanced tutorial teaches you to explore data using indices and ranges to examine a continuous range of a sequential data set.
ms.date: 11/01/2022
ms.technology: csharp-fundamentals
ms.custom: mvc
---
# Indices and ranges

Ranges and indices provide a succinct syntax for accessing single elements or ranges in a sequence.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Use the syntax for ranges in a sequence.
> - Implicitly define a <xref:System.Range>.
> - Understand the design decisions for the start and end of each sequence.
> - Learn scenarios for the <xref:System.Index> and <xref:System.Range> types.

## Language support for indices and ranges

Indices and ranges provide a succinct syntax for accessing single elements or ranges in a sequence.

This language support relies on two new types and two new operators:

- <xref:System.Index?displayProperty=nameWithType> represents an index into a sequence.
- The [index from end operator `^`](../language-reference/operators/member-access-operators.md#index-from-end-operator-), which specifies that an index is relative to the end of a sequence.
- <xref:System.Range?displayProperty=nameWithType> represents a sub range of a sequence.
- The [range operator `..`](../language-reference/operators/member-access-operators.md#range-operator-), which specifies the start and end of a range as its operands.

Let's start with the rules for indices. Consider an array `sequence`. The `0` index is the same as `sequence[0]`. The `^0` index is the same as `sequence[sequence.Length]`. The expression `sequence[^0]` does throw an exception, just as `sequence[sequence.Length]` does. For any number `n`, the index `^n` is the same as `sequence.Length - n`.

```csharp
string[] words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumps",    // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0
```

You can retrieve the last word with the `^1` index. Add the following code below the initialization:

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_LastIndex":::

A range specifies the *start* and *end* of a range. The start of the range is inclusive, but the end of the range is exclusive, meaning the *start* is included in the range but the *end* isn't included in the range. The range `[0..^0]` represents the entire range, just as `[0..sequence.Length]` represents the entire range.

The following code creates a subrange with the words "quick", "brown", and "fox". It includes `words[1]` through `words[3]`. The element `words[4]` isn't in the range.

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_Range":::

The following code returns the range with "lazy" and "dog". It includes `words[^2]` and `words[^1]`. The end index `words[^0]` isn't included. Add the following code as well:

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_LastRange":::

The following examples create ranges that are open ended for the start, end, or both:

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_PartialRanges":::

You can also declare ranges or indices as variables. The variable can then be used inside the `[` and `]` characters:

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_RangeIndexTypes":::

The following sample shows many of the reasons for those choices. Modify `x`, `y`, and `z` to try different combinations. When you experiment, use values where `x` is less than `y`, and `y` is less than `z` for valid combinations. Add the following code in a new method. Try different combinations:

:::code language="csharp" source="snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_Semantics":::

Not only arrays support indices and ranges. You can also use indices and ranges with [string](../language-reference/builtin-types/reference-types.md#the-string-type), <xref:System.Span%601>, or <xref:System.ReadOnlySpan%601>.

### Implicit range operator expression conversions

When using the range operator expression syntax, the compiler implicitly converts the start and end values to an <xref:System.Index> and from them, creates a new <xref:System.Range> instance. The following code shows an example implicit conversion from the range operator expression syntax, and its corresponding explicit alternative:

:::code language="csharp" source="./snippets/RangesIndexes/IndicesAndRanges.cs" id="ImplicitRangeOperatorConversion":::

> [!IMPORTANT]
> Implicit conversions from <xref:System.Int32> to <xref:System.Index> throw an <xref:System.ArgumentOutOfRangeException> when the value is negative. Likewise, the `Index` constructor throws an `ArgumentOutOfRangeException` when the `value` parameter is negative.

## Type support for indices and ranges

Indexes and ranges provide clear, concise syntax to access a single element or a range of elements in a sequence. An index expression typically returns the type of the elements of a sequence. A range expression typically returns the same sequence type as the source sequence.

Any type that provides an [indexer](../programming-guide/indexers/index.md) with an <xref:System.Index> or <xref:System.Range> parameter explicitly supports indices or ranges respectively. An indexer that takes a single <xref:System.Range> parameter may return a different sequence type, such as <xref:System.Span%601?displayProperty=nameWithType>.

> [!IMPORTANT]
> The performance of code using the range operator depends on the type of the sequence operand.
>
> The time complexity of the range operator depends on the sequence type. For example, if the sequence is a `string` or an array, then the result is a copy of the specified section of the input, so the time complexity is *O(N)* (where N is the length of the range). On the other hand, if it's a <xref:System.Span%601?displayProperty=nameWithType> or a <xref:System.Memory%601?displayProperty=nameWithType>, the result references the same backing store, which means there is no copy and the operation is *O(1)*.
>
> In addition to the time complexity, this causes extra allocations and copies, impacting performance. In performance sensitive code, consider using `Span<T>` or `Memory<T>` as the sequence type, since the range operator does not allocate for them.

A type is **countable** if it has a property named `Length` or `Count` with an accessible getter and a return type of `int`. A countable type that doesn't explicitly support indices or ranges may provide an implicit support for them. For more information, see the [Implicit Index support](~/_csharplang/proposals/csharp-8.0/ranges.md#implicit-index-support) and [Implicit Range support](~/_csharplang/proposals/csharp-8.0/ranges.md#implicit-range-support) sections of the [feature proposal note](~/_csharplang/proposals/csharp-8.0/ranges.md). Ranges using implicit range support return the same sequence type as the source sequence.

For example, the following .NET types support both indices and ranges: <xref:System.String>, <xref:System.Span%601>, and <xref:System.ReadOnlySpan%601>. The <xref:System.Collections.Generic.List%601> supports indices but doesn't support ranges.

<xref:System.Array> has more nuanced behavior. Single dimension arrays support both indices and ranges. Multi-dimensional arrays don't support indexers or ranges. The indexer for a multi-dimensional array has multiple parameters, not a single parameter. Jagged arrays, also referred to as an array of arrays, support both ranges and indexers. The following example shows how to iterate a rectangular subsection of a jagged array. It iterates the section in the center, excluding the first and last three rows, and the first and last two columns from each selected row:

:::code language="csharp" source="./snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_JaggedArrays":::

In all cases, the range operator for <xref:System.Array> allocates an array to store the elements returned.

## Scenarios for indices and ranges

You'll often use ranges and indices when you want to analyze a portion of a larger sequence. The new syntax is clearer in reading exactly what portion of the sequence is involved. The local function `MovingAverage` takes a <xref:System.Range> as its argument. The method then enumerates just that range when calculating the min, max, and average. Try the following code in your project:

:::code language="csharp" source="./snippets/RangesIndexes/IndicesAndRanges.cs" id="SnippetIndicesAndRanges_MovingAverage":::

## A Note on Range Indices and Arrays

When taking a range from an array, the result is an array that is copied from the initial array, rather than referenced. Modifying values in the resulting array will not change values in the initial array.

For example:

```csharp
var arrayOfFiveItems = new[] { 1, 2, 3, 4, 5 };

var firstThreeItems = arrayOfFiveItems[..3]; // contains 1,2,3
firstThreeItems[0] =  11; // now contains 11,2,3

Console.WriteLine(string.Join(",", firstThreeItems));
Console.WriteLine(string.Join(",", arrayOfFiveItems));

// output:
// 11,2,3
// 1,2,3,4,5
```

## See also

* [Member access operators and expressions](../language-reference/operators/member-access-operators.md)
