---
title: "List and slice patterns"
description: Learn when to use C# list patterns to test a sequence's shape and selected elements, and slice patterns to allow unmatched elements.
ms.date: 09/17/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# List and slice patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete supported-type and language rules, see [list patterns](../../language-reference/operators/patterns.md#list-patterns) in the language reference.

A *list pattern* tests the shape of an array, list, or another supported sequence and applies nested patterns to selected elements. Shape includes the number and positions of elements. A *slice pattern*, written `..`, allows a list pattern to contain zero or more elements that aren't tested individually.

List patterns don't make every <xref:System.Collections.Generic.IEnumerable%601> input matchable. The input's compile-time type must support the length or count and element access required by list-pattern rules. Arrays, `List<T>`, strings, and spans are common examples.

## Match an exact shape

A card reader receives command bytes from a device. A valid reset command contains exactly three bytes: a start marker, the reset operation code, and an end marker. The program must validate the complete command before resetting the device:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="ExactListPattern":::

The `command` expression is the pattern input. `[0x02, 0x52, 0x03]` contains three constant patterns. Without a slice pattern, the length must be exactly three, and each nested pattern must match the element in the same position. A longer command doesn't match even if its first three bytes are the same.

Choose a list pattern when both the sequence shape and selected element values express the decision. If only the number of elements matters, a `Length` or `Count` property pattern, such as `items is { Count: 0 }`, states that intent more directly.

## Match selected elements with discards

A race application receives the finishing order as a list of runner names. It needs the winner and third-place finisher to prepare two separate announcements:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="CaptureElements":::

`var winner` and `var thirdPlace` capture elements that the result uses. The discard pattern `_` accepts the second element without retaining it. Because there's no `..`, the list must contain exactly three elements.

Choose this form when fixed positions have stable meaning. Use a loop or LINQ when you need to inspect an arbitrary number of elements, transform a sequence, search throughout it, or perform aggregation.

## Allow remaining elements with a slice pattern

An application command line can start with `--verbose`, continue with zero or more other arguments, and end with the input file name. The program needs to recognize that shape and capture the file name:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SlicePattern":::

The slice pattern `..` matches zero or more elements between the first and last elements. A list pattern can contain at most one slice pattern. In this example, the program doesn't need the middle arguments, so the slice has no nested pattern or variable.

A slice can appear at the beginning, middle, or end of a list pattern. Use it when the elements around the slice are the meaningful part of the shape. Don't use a list pattern to replace ordinary iteration when every element needs processing.

## Apply a pattern to a slice

You can apply another pattern to the part matched by `..`. A message-processing service treats the first and last entries as protocol markers and needs to know whether the payload between them is empty:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SliceSubpattern":::

The outer pattern first requires `"BEGIN"` and `"END"` at the boundaries. The property pattern `{ Length: 0 }` then tests the slice between them. The result tells the service to reject an empty payload instead of sending it for processing.

Use a slice subpattern only when the middle portion itself needs a test or capture. If only boundary elements matter, plain `..` is simpler.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [List pattern reference](../../language-reference/operators/patterns.md#list-patterns)
- [Arrays](../../language-reference/builtin-types/arrays.md)
- [Use a `foreach` statement to iterate through a collection](../statements/collections.md)
