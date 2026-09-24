---
title: "List and slice patterns"
description: Learn how C# list patterns describe a sequence's shape through its element count, ordered positions, matched values, and slices.
ms.date: 09/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# List and slice patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete supported-type and language rules, see [list patterns](../../language-reference/operators/patterns.md#list-patterns) in the language reference.

A sequence's *shape* is the set of observable properties that a pattern requires. These properties can include the number of elements, requirements written for every element or for a sequence of elements as a whole, and marker values at specific indexes. For example, a shape might require exactly two elements with `"Name"` at index 0, or it might require a first marker, a last marker, and a nonempty sequence between them.

A *list pattern* describes a shape by combining an element-count requirement with nested patterns at ordered positions. It tests only the requirements written in the pattern: An element subpattern tests its corresponding element, while a *slice pattern* can allow or test a sequence of otherwise unmatched elements. You can use these parts to match an exact count and marker values, capture values at fixed positions, allow an unmatched middle, or apply a nested pattern to that middle.

Choose a list pattern when the input's compile-time type provides a `Length` or `Count` property and indexed element access, which retrieves an element by its position, as in `input[index]`. Arrays, `List<T>`, strings, and spans are common examples. The compiler determines eligibility from the variable's declared, compile-time type because it must resolve these required members before the program runs. The <xref:System.Collections.Generic.IEnumerable%601> interface by itself provides enumeration instead of those members, even when the runtime object is an indexable collection.

List patterns use a length or count and indexed element access instead of enumeration. For common built-in types, matching can check only the positions named by the pattern rather than iterate through every element. The cost of those operations depends on the input type. Iterating a long collection can take time, so use a loop or LINQ when the decision requires examining an arbitrary number of elements rather than specific positions.

## Match an exact shape

The following method recognizes a two-column header:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="ExactListPattern":::

The `columns` expression is the pattern input. `["Name", "Score"]` contains two constant patterns. An exact list pattern omits a slice pattern, requires exactly two elements, and applies each nested pattern to the element at the same index. This pattern describes a shape with an exact count and two marker values: `"Name"` at index 0 and `"Score"` at index 1. Nested element patterns are optional: The empty list pattern `[]` describes, and matches, a sequence with no elements.

Choose a list pattern when the shape combines an element count with requirements at ordered positions. If only the number of elements matters, a `Length` or `Count` property pattern, such as `items is { Count: 0 }`, states that intent more directly.

## Match selected elements with discards

The following method reads the winner and third-place finisher from a three-name finishing order:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="CaptureElements":::

The `var winner` and `var thirdPlace` patterns each declare a variable. When the list pattern matches, C# assigns the matched element value at that position to the corresponding variable, so the result can use `winner` and `thirdPlace`. The discard pattern `_` accepts the second element and discards its value. This shape requires exactly three elements and gives the first and third positions specific meaning, but it doesn't require particular values at any position.

Choose this form when fixed positions have stable meaning. Use a loop or LINQ when you need to inspect an arbitrary number of elements, transform a sequence, search throughout it, or perform aggregation.

## Allow remaining elements with a slice pattern

In this simplified example, a command line can start with `--verbose`, contain other arguments, and is assumed to end with the input file name. The following method recognizes shapes with a file name in the last position and captures that value:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SlicePattern":::

The *slice pattern* `..` allows zero or more remaining elements between the first and last element patterns. A list pattern can contain at most one slice pattern. The first switch arm describes a shape with at least two elements: the marker `"--verbose"` at index 0, a file name in the last position, and any number of unmatched arguments between them. The standalone slice doesn't test those middle arguments. The second arm accepts any nonempty shape and captures its last element, while the empty pattern handles a sequence with no elements.

A slice can appear at the beginning, middle, or end of a list pattern. Use it when a variable-length sequence is part of the shape but only the surrounding positions need element tests. Use ordinary iteration when every element needs processing.

## Apply a pattern to a slice

You can apply another pattern to the part matched by `..`. The following method tests whether an array starts with `"BEGIN"`, ends with `"END"`, and has at least one element between them:

:::code language="csharp" source="snippets/patterns/ListPatterns.cs" ID="SliceSubpattern":::

The outer pattern first requires the marker `"BEGIN"` at index 0 and `"END"` at the last index. The property pattern `{ Length: > 0 }` then adds a requirement for the sequence matched by the slice: It must contain at least one element. Together, these requirements describe the complete shape. The pattern doesn't test the values of the elements inside the slice.

Use a slice subpattern only when the middle portion itself needs a test or capture. If only boundary elements matter, plain `..` is simpler.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [List pattern reference](../../language-reference/operators/patterns.md#list-patterns)
- [Arrays](../../language-reference/builtin-types/arrays.md)
- [Use a `foreach` statement to iterate through a collection](../statements/collections.md)
