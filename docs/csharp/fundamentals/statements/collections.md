---
title: "Collections in C#"
description: Store, update, search, and read groups of values by using arrays, lists, dictionaries, collection expressions, indexes, and ranges.
ms.date: 07/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Collections

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete syntax, see [collections](../../language-reference/builtin-types/collections.md), [arrays](../../language-reference/builtin-types/arrays.md), and [collection expressions](../../language-reference/operators/collection-expressions.md) in the language reference.
>
> **Coming from another language?** C# arrays are fixed-size ordered collections, like arrays in Java or C++. <xref:System.Collections.Generic.List`1> is the everyday growable sequence, like Java's `ArrayList`, JavaScript's arrays, or Python's lists. <xref:System.Collections.Generic.Dictionary`2> stores values by key, like maps or dictionaries in many languages.

A *collection* is an object that stores multiple related values. Each value in a collection is an *element*. C# developers commonly start with three collection shapes: arrays for fixed-size ordered data, <xref:System.Collections.Generic.List`1> for ordered data that grows or shrinks, and <xref:System.Collections.Generic.Dictionary`2> for values that you find by key.

## Choose a collection shape

Choose the collection that matches how your code uses the data. A *sequence* stores elements in order so you can reach them by position. Use an *array*, which is represented by <xref:System.Array>, when you need a fixed-size sequence. Use <xref:System.Collections.Generic.List`1> when you need a sequence that can add or remove elements. A *map* stores values that you reach by key instead of by position. Use <xref:System.Collections.Generic.Dictionary`2> when each element has a lookup key, such as a name, ID, or code. The examples use a *collection expression*, which creates a collection from values between square brackets; [later in this article](#create-collections-with-collection-expressions), you learn the syntax in more detail.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ChooseCollection":::

<xref:System.Collections.Generic.List`1> and <xref:System.Collections.Generic.Dictionary`2> are *generic types*. A generic type uses a type argument, such as `string` or `int`, to say what kind of values it stores. Generics let you reuse the same collection shape, such as a list or dictionary, with different element types, such as `string`, `int`, or a custom type. They also provide *type safety*: the compiler guarantees every element is the declared type, so you don't need casts and can't accidentally store the wrong type. For more information, see [Generic classes and methods](../types/generics.md).

## Store fixed-size data in arrays

An array is an ordered collection with a fixed length. You access an array element by its *index*, which is its zero-based position in the array. Index `0` is the first element, index `1` is the second element, and so on.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="Arrays":::

Use `foreach` when you want to read every element in order. Use an index when the position matters, such as when you need the first element, the last element, or the position returned by <xref:System.Array.IndexOf*?displayProperty=nameWithType>.

## Grow a sequence with `List<T>`

A <xref:System.Collections.Generic.List`1> stores elements in order and can grow or shrink as your program runs. Use <xref:System.Collections.Generic.List`1.Add*> to append an element, <xref:System.Collections.Generic.List`1.Remove*> to remove a matching element, <xref:System.Collections.Generic.List`1.Contains*> to test whether an element exists, and <xref:System.Collections.Generic.List`1.IndexOf*> to find an element's position.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ListChanges":::

A <xref:System.Collections.Generic.List`1> keeps the remaining elements in order when you add or remove items. When you remove an element, later elements move to lower indexes.

## Look up items by key with `Dictionary<TKey,TValue>`

A <xref:System.Collections.Generic.Dictionary`2> stores key/value pairs. A *key/value pair* is one key and the value associated with that key; .NET represents one pair with <xref:System.Collections.Generic.KeyValuePair`2>. Use the dictionary indexer to add or update a value by key, and use <xref:System.Collections.Generic.Dictionary`2.TryGetValue*> when the key might not exist.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="DictionaryLookup":::

An *indexer* lets you use bracket syntax to access a value from an object. The dictionary indexer is useful when the key must exist or when you're assigning a value. <xref:System.Collections.Generic.Dictionary`2.TryGetValue*> is safer for reads when the key might be missing because it reports both outcomes without throwing an exception. For more information about bracket access, see the [member access operators](../../language-reference/operators/member-access-operators.md#indexer-operator-).

## Create collections with collection expressions

A *collection expression* creates a collection from values between square brackets. Beginning with C# 12, collection expressions can create arrays, lists, and other collection types. A *spread element* copies the elements from another collection into the new collection.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="CollectionExpressions":::

Collection expressions keep initialization concise. A collection expression has no type of its own. Because `[...]` is typeless by itself, the compiler converts the same expression into the collection shape the context calls for. The receiving variable or parameter can turn it into an array, a <xref:System.Collections.Generic.List`1>, or another supported collection type.

## Read from positions with indexes and ranges

Beginning with C# 8, an <xref:System.Index> can count from the end of a sequence with `^`, and a <xref:System.Range> can select a slice with `..`. Arrays support both indexes and ranges. <xref:System.Collections.Generic.List`1> supports indexes, including from-end indexes, but it doesn't support the range operator directly.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="IndexesAndRanges":::

Use ranges when the subsection is part of the data you're working with. Use a <xref:System.Collections.Generic.List`1> index when you need one item by position. For more range examples, see [Explore indexes and ranges](../../tutorials/ranges-indexes.md).

## See also

- [Iteration statements](iteration.md)
- [LINQ queries](linq.md)
- [Collections](../../language-reference/builtin-types/collections.md)
- [Arrays](../../language-reference/builtin-types/arrays.md)
- [Collection expressions](../../language-reference/operators/collection-expressions.md)
- [Member access operators](../../language-reference/operators/member-access-operators.md)
- [Explore indexes and ranges](../../tutorials/ranges-indexes.md)


