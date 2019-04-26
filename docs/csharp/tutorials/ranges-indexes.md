---
title: Explore ranges of data using indices and ranges
description: This advanced tutorial teaches you to explore data using indices and ranges to examine slices of a sequential data set.
ms.date: 04/19/2019
ms.custom: mvc
---
# Indices and ranges

Ranges and indices provide a succinct syntax for accessing single elements or ranges in an <xref:System.Array>, <xref:System.Span%601>, or <xref:System.ReadOnlySpan%601>. These features enable more concise, clear syntax to access single elements or ranges of elements in a sequence.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Use the syntax for ranges in a sequence.
> * Understand the design decisions for the start and end of each sequence.
> * Learn scenarios for the <xref:System.Index> and <xref:System.Range> types.

## Language support for indices and ranges

You can specify an index **from the end** using the `^` character before the index. Indexing from the end starts from the rule that `0..^0` specifies the entire range. To enumerate an entire array, you start *at the first element*, and continue until you are *past the last element*. Think of the behavior of the `MoveNext` method on an enumerator: it returns false when the enumeration passes the last element. The index `^0` means "the end", `array[array.Length]`, or the index that follows the last element. You are familiar with `array[2]` meaning the element "2 from the start". Now, `array[^2]` means the element "2 from the end". 

You can specify a **range** with the **range operator**: `..`. For example, `0..^0` specifies the entire range of the array: 0 from the start up to, but not including 0 from the end. Either operand may use "from the start" or "from the end". Furthermore, either operand may be omitted. The defaults are `0` for the start index, and `^0` for the end index.

```csharp-interactive
string[] words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0
```

The index of each element reinforces the concept of "from the start", and "from the end", and that ranges are exclusive of the end of the range. The "start" of the entire array is the first element. The "end" of the entire array is *past* the last element.

You can retrieve the last word with the `^1` index. Add the following code below the initialization:

[!code-csharp[LastIndex](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_LastIndex)]

The following code creates a subrange with the words "quick", "brown", and "fox". It includes `words[1]` through `words[3]`. The element `words[4]` isn't in the range. Add the following code to the same method. Copy and paste it at the bottom of the interactive window.

[!code-csharp[Range](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_Range)]

The following code creates a subrange with "lazy" and "dog". It includes `words[^2]` and `words[^1]`. The end index `words[^0]` isn't included. Add the following code as well:

[!code-csharp[LastRange](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_LastRange)]

The following examples create ranges that are open ended for the start, end, or both:

[!code-csharp[PartialRange](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_PartialRanges)]

You can also declare ranges or indices as variables. The variable can then be used inside the `[` and `]` characters:

[!code-csharp[IndexRangeTypes](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_RangeIndexTypes)]

The previous examples show two design decisions that require more explanation:

- Ranges are *exclusive*, meaning the element at the last index isn't in the range.
- The index `^0` is *the end* of the collection, not *the last element* in the collection.

The following sample shows many of the reasons for those choices. Modify `x`, `y`, and `z` to try different combinations. When you experiment, use values where `x` is less than `y`, and `y` is less than `z` for valid combinations. Add the following code in a new method. Try different combinations:

[!code-csharp[SemanticsExamples](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_Semantics)]

## Scenarios for Indices and Ranges

You'll often use ranges and indices when you want to perform some analysis on subrange of an entire sequence. The new syntax is clearer in reading exactly what subrange is involved. The local function `MovingAverage` takes a <xref:System.Range> as its argument. The method then enumerates just that range when calculating the min, max, and average. Try the following code in your project:

[!code-csharp[MovingAverages](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_MovingAverage)]

You can download the completed code from the [dotnet/samples](https://github.com/dotnet/samples/tree/master/csharp/tutorials/RangesIndexes) repository.
