---
title: "Collections"
description: Learn about collections in C#, which are used to work with groups of objects. Collections have different characteristics regarding adding and removing elements, modifying elements, and enumerating the collection elements.
ms.date: 08/22/2023
---
# Collections

The .NET runtime provides many collection types that store and manage groups of related objects. Some of the collection types, such as <xref:System.Array?displayProperty=nameWithType>, <xref:System.Span%601?displayProperty=nameWithType>, and <xref:System.Memory%601?displayProperty=nameWithType> are recognized in the C# language. In addition, interfaces like <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> are recognized in the language for enumerating the elements of a collection.

Collections provide a flexible way to work with groups of objects. You can classify different collections by these characteristics:

- **Element access**: Every collection can be enumerated to access each element in order. Some collections access elements by *index*, the element's position in an ordered collection. The most common example is <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. Other collections access elements by *key*, where a *value* is associated with a single *key*. The most common example is <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>. You choose between these collection types based on how your app accesses elements.
- **Performance profile**: Every collection has different performance profiles for actions like adding an element, finding an element, or removing an element. You can pick a collection type based on the operations used most in your app.
- **Grow and shrink dynamically**: Most collections supporting adding or removing elements dynamically. Notably, <xref:System.Array>, <xref:System.Span%601?displayProperty=nameWithType>, and <xref:System.Memory%601?displayProperty=nameWithType> don't.

In addition to those characteristics, the runtime provides specialized collections that prevent adding or removing elements or modifying the elements of the collection. Other specialized collections provide safety for concurrent access in multi-threaded apps.

You can find all the collection types in the [.NET API reference](/dotnet/api/?term=collection). For more information, see [Commonly Used Collection Types](../../../standard/collections/commonly-used-collection-types.md) and [Selecting a Collection Class](../../../standard/collections/selecting-a-collection-class.md).

> [!NOTE]
> For the examples in this article, you might need to add [using directives](../keywords/using-directive.md) for the `System.Collections.Generic` and `System.Linq` namespaces.

[Arrays](./arrays.md) are represented by <xref:System.Array?displayProperty=fullName> and have syntax support in the C# language. This syntax provides more concise declarations for array variables.

<xref:System.Span%601?displayProperty=nameWithType> is a [`ref struct`](./ref-struct.md) type that provides a snapshot over a sequence of elements without copying those elements. The compiler enforces safety rules to ensure the `Span` can't be accessed after the sequence it references is no longer in scope. It's used in many .NET APIs to improve performance. <xref:System.Memory%601> provides similar behavior when you can't use a `ref struct` type.

Beginning with C# 12, all of the collection types can be initialized using a [Collection expression](../operators/collection-expressions.md).

## Indexable collections

An *indexable collection* is one where you can access each element using its index. Its *index* is the number of elements before it in the sequence. Therefore, the element reference by index `0` is the first element, index `1` is the second, and so on. These examples use the <xref:System.Collections.Generic.List%601> class. It's the most common indexable collection.

The following example creates and initializes a list of strings, removes an element, and adds an element to the end of the list. After each modification, it iterates through the strings by using a [foreach](../statements/iteration-statements.md#the-foreach-statement) statement or a `for` loop:

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetCreateList":::

The following example removes elements from a list by index. Instead of a `foreach` statement, it uses a `for` statement that iterates in descending order. The <xref:System.Collections.Generic.List%601.RemoveAt%2A> method causes elements after a removed element to have a lower index value.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetRemoveItemByIndex":::

For the type of elements in the <xref:System.Collections.Generic.List%601>, you can also define your own class. In the following example, the `Galaxy` class that is used by the <xref:System.Collections.Generic.List%601> is defined in the code.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetCustomList":::

## Key/value pair collections

These examples use the <xref:System.Collections.Generic.Dictionary%602> class. It's the most common dictionary collection. A dictionary collection enables you to access elements in the collection by using the key of each element. Each addition to the dictionary consists of a value and its associated key.

The following example creates a `Dictionary` collection and iterates through the dictionary by using a `foreach` statement.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetDictionary":::

The following example uses the <xref:System.Collections.Generic.Dictionary%602.ContainsKey%2A> method and the <xref:System.Collections.Generic.Dictionary%602.Item%2A> property of `Dictionary` to quickly find an item by key. The `Item` property enables you to access an item in the `elements` collection by using the `elements[symbol]` in C#.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetFindInDictionary":::

The following example instead uses the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method to quickly find an item by key.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetFindInDictionary2":::

## Iterators

An *iterator* is used to perform a custom iteration over a collection. An iterator can be a method or a `get` accessor. An iterator uses a [yield return](../statements/yield.md) statement to return each element of the collection one at a time.

You call an iterator by using a [foreach](../statements/iteration-statements.md#the-foreach-statement) statement. Each iteration of the `foreach` loop calls the iterator. When a `yield return` statement is reached in the iterator, an expression is returned, and the current location in code is retained. Execution is restarted from that location the next time that the iterator is called.

For more information, see [Iterators (C#)](../../programming-guide/concepts/iterators.md).

The following example uses an iterator method. The iterator method has a `yield return` statement that is inside a `for` loop. In the `ListEvenNumbers` method, each iteration of the `foreach` statement body creates a call to the iterator method, which proceeds to the next `yield return` statement.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetIteratorMethod":::

## LINQ and collections

Language-integrated query (LINQ) can be used to access collections. LINQ queries provide filtering, ordering, and grouping capabilities. For more information, see [Getting Started with LINQ in C#](../../linq/index.md).

The following example runs a LINQ query against a generic `List`. The LINQ query returns a different collection that contains the results.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="ShowLINQ":::
