---
title: "Common collection types in C#"
description: Store, update, search, and read groups of values by using arrays, lists, dictionaries, collection expressions, indexes, and ranges.
ms.date: 07/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Common collection types

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For more information about collections, see [Collections](../../language-reference/builtin-types/collections.md) in the language reference. For more information about arrays, see [The array reference type](../../language-reference/builtin-types/arrays.md) in the language reference. For more information about collection expressions, see [Collection expressions (Collection literals)](../../language-reference/operators/collection-expressions.md) in the language reference.
>
> **Coming from another language?** C# arrays are fixed-size ordered collections, like arrays in Java or C++. <xref:System.Collections.Generic.List`1> is the everyday growable sequence, like Java's `ArrayList`, JavaScript's arrays, or Python's lists. <xref:System.Collections.Generic.Dictionary`2> stores values by key, like maps or dictionaries in many languages.

A *collection* is an object that stores multiple related values. Each value in a collection is an *element*. Choose an array when the set is fixed, such as the status names your work-item tracker always uses. Choose a <xref:System.Collections.Generic.List`1> when items come and go, such as a backlog that gains new work and drops completed items. Choose a <xref:System.Collections.Generic.Dictionary`2> when you look up values by a key, such as finding a work item by ID or a setting by name. The next section turns those examples into a quick decision model.

## Choose a collection shape

Choose the collection that matches how your code uses the data. A *sequence* stores elements in order so you can reach them by position. Use an *array*, which is represented by <xref:System.Array>, when you know the number of positions the sequence needs. An array's length can't change after you create it, but you can replace the element stored at an existing position. Use <xref:System.Collections.Generic.List`1> when you need a sequence that can add or remove elements. A *dictionary* stores values that you reach by key instead of by position. Use <xref:System.Collections.Generic.Dictionary`2> when each element has a lookup key, such as a name, ID, or code. The examples use a *collection expression*, which creates a collection from expressions between square brackets. The "Create collections with collection expressions" section explains that syntax in more detail.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ChooseCollection":::

<xref:System.Collections.Generic.List`1> and <xref:System.Collections.Generic.Dictionary`2> are *generic types*. A generic type uses a type argument, such as `string` or `int`, to say what kind of values it stores. Generics let you reuse the same collection shape, such as a list or dictionary, with different element types, such as `string`, `int`, or a custom type. They also provide *type safety*: the compiler guarantees every element is the declared type, so you don't need casts and can't accidentally store the wrong type. For more information about generic types, see [Generic types and methods](../types/generics.md) in the fundamentals.

## Store fixed-size data in arrays

An array is an ordered collection with a fixed length. You access an array element by its *index*, which is its zero-based position in the array. Index `0` is the first element, index `1` is the second element, and so on.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="Arrays":::

Use `foreach` when you want to read every element in order. Use an index when the position matters, such as when you need the first element, the last element, or the position returned by <xref:System.Array.IndexOf*?displayProperty=nameWithType>.

The length of an array is fixed, but the elements in that array can change. Assign a new value to an existing index when the position stays the same but the stored value needs an update:

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ArrayElementUpdate":::

## Grow and shrink a sequence with `List<T>`

A <xref:System.Collections.Generic.List`1> stores elements in order and can grow or shrink as your program runs. Use <xref:System.Collections.Generic.List`1.Add*> to append an element, <xref:System.Collections.Generic.List`1.Remove*> to remove a matching element, <xref:System.Collections.Generic.List`1.Contains*> to test whether an element exists, and <xref:System.Collections.Generic.List`1.IndexOf*> to find an element's position. Use the list indexer to replace the value at an existing position.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ListChanges":::

A <xref:System.Collections.Generic.List`1> keeps the remaining elements in order when you add or remove items. When you remove an element, later elements move to lower indexes.

Use <xref:System.Collections.Generic.List`1.Insert*> to add one element at a specific position, <xref:System.Collections.Generic.List`1.InsertRange*> to add several elements at a position, and <xref:System.Collections.Generic.List`1.RemoveAt*> to remove an element by index:

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="ListInsertRemove":::

Adding or removing at the end of a <xref:System.Collections.Generic.List`1> is fast. Adding with <xref:System.Collections.Generic.List`1.Add*> is an O(1) operation on average, and removing the last element with <xref:System.Collections.Generic.List`1.RemoveAt*> is O(1). Inserting or removing at the front or middle is O(n) because every later element shifts to a new index. If your code frequently inserts or removes at the front, a <xref:System.Collections.Generic.List`1> might be the wrong collection shape.

> [!TIP]
> Big-O notation describes how the work grows as the collection size, `n`, grows. O(1), pronounced "order one," means the operation takes about the same amount of work no matter how many elements the collection contains. O(n), pronounced "order n," means the work grows roughly in proportion to the number of elements in the collection.

## Associate a value by key with `Dictionary<TKey,TValue>`

A <xref:System.Collections.Generic.Dictionary`2> stores key/value pairs. A *key/value pair* is one key and the value associated with that key; .NET represents one pair with <xref:System.Collections.Generic.KeyValuePair`2>. Use the dictionary indexer to add or update a value by key, and use <xref:System.Collections.Generic.Dictionary`2.TryGetValue*> when the key might not exist.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="DictionaryLookup":::

An *indexer* lets you use bracket syntax to access a value from an object. The dictionary indexer is useful when the key must exist or when you're assigning a value. <xref:System.Collections.Generic.Dictionary`2.TryGetValue*> checks whether a key exists and gives you the value when it does. For more information about the indexer operator, see [Member access operators](../../language-reference/operators/member-access-operators.md#indexer-operator-) in the language reference.

You can also change the value associated with a key that already exists. Assign through the indexer to add a key or replace the value for an existing key. If the replacement depends on the current value, read the value first, then assign the new value:

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="DictionaryUpdates":::

## Create collections with collection expressions

A *collection expression* creates a collection from expressions between square brackets. Beginning with C# 12, collection expressions can create arrays, lists, and other collection types. A *spread element* copies the elements from another collection into the new collection.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="CollectionExpressions":::

Collection expressions keep initialization concise. A collection expression has no type of its own. The compiler converts the expression into the collection shape the context calls for. The receiving variable or parameter can turn it into an array, a <xref:System.Collections.Generic.List`1>, or other supported collection type.

## Read from positions with indexes and ranges

Indexes answer "which single element?" Ranges answer "which contiguous slice?" Use indexes when your code needs one element and ranges when the subsection is part of the data you're working with. Arrays and `List<T>` support both indexes and ranges.

An <xref:System.Index> can count from the start or from the end of a sequence. Use the number directly to count from the start: `phases[0]` reads the first element, and `phases[1]` reads the second element. Use `^` to count from the end: `phases[^1]` reads the last element, and `phases[^2]` reads the next-to-last element.

An <xref:System.Range> selects a slice with `..` (two dots). The range operator isn't the same as the spread element you saw earlier in collection expressions, even though both use dots. Use a range `a..b` when you want elements from index `a` up to, but ***not including***, index `b`. The expression `phases[1..3]` creates a new array that contains the elements at index `1` and index `2`.

You can omit one or both range indexes. Omit the start index when the slice starts at the beginning, as in `phases[..2]` for the first two elements. Omit the end index when the slice continues through the last element, as in `phases[2..]` for the elements from index `2` to the end. Omit both indexes when you want a copy of the whole array, as in `phases[..]`. A range can mix index kinds. The expression `phases[1..^1]` combines a from-start index and a from-end index to return the middle elements, `code` and `test`.

:::code language="csharp" source="./snippets/collections-statements/Program.cs" id="IndexesAndRanges":::

For more information about indexes and ranges, see [Explore ranges of data using indices and ranges](../../tutorials/ranges-indexes.md) in the tutorials.

## See also

- [Iteration statements](iteration.md)
- [LINQ queries](linq.md)
- [Collections](../../language-reference/builtin-types/collections.md)
- [Arrays](../../language-reference/builtin-types/arrays.md)
- [Collection expressions](../../language-reference/operators/collection-expressions.md)
- [Member access operators](../../language-reference/operators/member-access-operators.md)
- [Explore indexes and ranges](../../tutorials/ranges-indexes.md)
