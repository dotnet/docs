---
title: Explore ranges of data using indexes and ranges
description: This advanced tutorial teach you to explore data using indexes and ranges to examine slices of a sequential data set.
ms.date: 03/13/2019
ms.custom: mvc
---


# Indices and ranges

Ranges and indices provide a succinct syntax for specifying subranges in an array, `Span<T>`, or `ReadOnlySpan<T>`.

## Language support for indices and ranges

You can specify an index **from the end**. You specify **from the end** using the `^` operator. You are familiar with `array[2]` meaning the element "2 from the start". Now, `array[^2]` means the element "2 from the end". The index `^0` means "the end", or the index that follows the last element.

You can specify a **range** with the **range operator**: `..`. For example, `0..^0` specifies the entire range of the array: 0 from the start up to, but not including 0 from the end. Either operand may use "from the start" or "from the end". Furthermore, either operand may be omitted. The defaults are `0` for the start index, and `^0` for the end index.

Let's look at a few examples. Consider the following array, annotated with its index from the start and from the end:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_Initialization)]

The index of each element reinforces the concept of "from the start", and "from the end", and that ranges are exclusive of the end of the range. The "start" of the entire array is the first element. The "end" of the entire array is *past* the last element.

You can retrieve the last word with the `^1` index:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_LastIndex)]

The following code creates a subrange with the words "quick", "brown", and "fox". It includes `words[1]` through `words[3]`. The element `words[4]` is not in the range.

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_Range)]

The following code creates a subrange with "lazy" and "dog". It includes `words[^2]` and `words[^1]`. The end index `words[^0]` is not included:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_LastRange)]

The following examples create ranges that are open ended for the start, end, or both:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_PartialRanges)]

You can also declare ranges or indices as variables. The variable can then be used inside the `[` and `]` characters:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_RangeIndexTypes)]

The previous examples show two design decisions that caused much debate:

- Ranges are *exclusive*, meaning the element at the last index is not in the range.
- The index `^0` is *the end* of the collection, not *the last element* in the collection.

The following sample shows many of the reasons for those choices. Modify `x` and `y` to try different combinations:

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_Semantics)]

## Scenarios for Indices and Ranges

Add text to explain what's going on here...

[!code-csharp[IsWeekDay](~/samples/csharp/tutorials/RangesIndexes/IndicesAndRanges.cs#IndicesAndRanges_MovingAverage)]
