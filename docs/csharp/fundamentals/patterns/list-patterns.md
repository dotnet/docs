---
title: "List and slice patterns"
description: Learn when to use C# list patterns to test a sequence's shape and selected elements, and slice patterns to allow unmatched elements.
ms.date: 09/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# List and slice patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete supported-type and language rules, see [list patterns](../../language-reference/operators/patterns.md#list-patterns) in the language reference.

A *list pattern* tests a sequence's length and selected elements. Use one when the sequence's shape contributes to a decision. You can begin with an exact shape, capture values at fixed positions, allow an unmatched middle, and then apply a nested pattern to that middle.

Choose a list pattern when the input's compile-time type provides a `Length` or `Count` property and indexed element access, which retrieves an element by its position, as in `input[index]`. Arrays, `List<T>`, strings, and spans are common examples. The compiler determines eligibility from the variable's declared, compile-time type because it must resolve these required members before the program runs. The <xref:System.Collections.Generic.IEnumerable%601> interface by itself provides enumeration instead of those members, even when the runtime object is an indexable collection.

List patterns use a length or count and indexed element access instead of enumeration. For common built-in types, matching can check only the positions named by the pattern rather than iterate through every element. The cost of those operations depends on the input type. Iterating a long collection can take time, so use a loop or LINQ when the decision requires examining an arbitrary number of elements rather than specific positions.

## Match an exact shape

The following method recognizes a two-column header:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="ExactListPattern":::

The `columns` expression is the pattern input. `["Name", "Score"]` contains two constant patterns. An exact list pattern omits a *slice pattern*, requires exactly two elements, and applies each nested pattern to the element in the same position. This pattern therefore matches only a two-element array with these values. Nested element patterns are optional: The empty list pattern `[]` matches an empty sequence.

Choose a list pattern when both the sequence shape and selected element values express the decision. If only the number of elements matters, a `Length` or `Count` property pattern, such as `items is { Count: 0 }`, states that intent more directly.

## Match selected elements with discards

The following method reads the winner and third-place finisher from a three-name finishing order:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="CaptureElements":::

The `var winner` and `var thirdPlace` patterns each declare a variable. When the list pattern matches, C# assigns the matched element value to the corresponding variable, so the result can use `winner` and `thirdPlace`. The discard pattern `_` accepts the second element and discards its value. This exact pattern requires three elements.

Choose this form when fixed positions have stable meaning. Use a loop or LINQ when you need to inspect an arbitrary number of elements, transform a sequence, search throughout it, or perform aggregation.

## Allow remaining elements with a slice pattern

In this simplified example, a command line can start with `--verbose`, contain other arguments, and is assumed to end with the input file name. The following method recognizes that shape and captures the file name:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SlicePattern":::

The *slice pattern* `..` allows zero or more remaining elements between the first and last elements. A list pattern can contain at most one slice pattern. In this example, only the boundary arguments contribute to the decision, so the slice stands alone.

A slice can appear at the beginning, middle, or end of a list pattern. Use it when the elements around the slice are the meaningful part of the shape. Use ordinary iteration when every element needs processing.

## Apply a pattern to a slice

You can apply another pattern to the part matched by `..`. The following method tests whether an array starts with `"BEGIN"`, ends with `"END"`, and has at least one element between them:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SliceSubpattern":::

The outer pattern first requires `"BEGIN"` and `"END"` at the boundaries. The property pattern `{ Length: > 0 }` then tests the slice between them.

Use a slice subpattern only when the middle portion itself needs a test or capture. If only boundary elements matter, plain `..` is simpler.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [List pattern reference](../../language-reference/operators/patterns.md#list-patterns)
- [Arrays](../../language-reference/builtin-types/arrays.md)
- [Use a `foreach` statement to iterate through a collection](../statements/collections.md)
