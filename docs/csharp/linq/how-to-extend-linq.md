---
title: "How to: Write your own extensions to LINQ"
description: Learn techniques to extend the standard LINQ methods. Query based on runtime state, modify query objects, and extend LINQ capabilities.
ms.topic: how-to
ms.date: 04/19/2024
---
# How to extend LINQ

LINQ libraries are extensible.

## Group results by contiguous keys

The following example shows how to group elements into chunks that represent subsequences of contiguous keys. For example, assume that you are given the following sequence of key-value pairs:

|Key | Value |
|---------|-----------|
| A | We |
| A | think |
| A | that |
| B | Linq |
| C | is |
| A | really |
| B | cool |
| B | ! |

The following groups will be created in this order:

1. We, think, that
1. Linq
1. is
1. really
1. cool, !

The solution is implemented as a thread-safe extension method that returns its results in a streaming manner. In other words, it produces its groups as it moves through the source sequence. Unlike the `group` or `orderby` operators, it can begin returning groups to the caller before all of the sequence has been read.

Thread-safety is accomplished by making a copy of each group or chunk as the source sequence is iterated, as explained in the source code comments. If the source sequence has a large sequence of contiguous items, the common language runtime may throw an <xref:System.OutOfMemoryException>.

The following example shows both the extension method and the client code that uses it:

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunkextensions":::

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_client_code":::

### `ChunkExtensions` class

In the presented code, of `ChunkExtensions` class implementation, the `while(true)`, loop in the `ChunkBy` method, iterates through source sequence and create a copy of each Chunk. On each pass, the iterator advances to the first element of the next "Chunk"
<br/>(The chunk is represented by [`Chunk`](#chunk-class) class.)
<br/>in the source sequence. This loop corresponds to the outer foreach loop that executes the query.
What happens in that loop is:

1. Get the key for the current Chunk, by assigning it to `key` variable: `var key = keySelector(enumerator.Current);`. The source iterator will churn through the source sequence until it finds an element with a key that doesn't match.
1. Make a new Chunk (group) object, and store it in `current` variable, that initially has one GroupItem, which is a copy of the current source element.
1. Return that Chunk. A Chunk is an `IGrouping<TKey,TSource>`, which is the return value of the [`ChunkBy`](#chunk-class) method. At this point the Chunk only has the first element in its source sequence. The remaining elements will be returned only when the client code foreach's over this chunk. See `Chunk.GetEnumerator` for more info.
1. Check to see whether
   1. the chunk has made a copy of all its source elements or
   1. the iterator has reached the end of the source sequence.
1. If the caller uses an inner foreach loop to iterate the chunk items, and that loop ran to completion, then the `Chunk.GetEnumerator` method will already have made copies of all chunk items before we get here. If the `Chunk.GetEnumerator` loop did not enumerate all elements in the chunk, we need to do it here to avoid corrupting the iterator for clients that may be calling us on a separate thread.

### `Chunk` class

The `Chunk` class is a contiguous group of one or more source elements that have the same key. A Chunk has a key and a list of ChunkItem objects, which are copies of the elements in the source sequence:

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunk_class":::

A Chunk has a linked list of `ChunkItem`s, which represent the elements in the current chunk. Each `ChunkItem` (represented by `ChunkItem` class) has a reference to the next `ChunkItem` in the list.
The list consists of it's `head` - which stores the contents of the first source element that belongs with this chunk, and it's `tail` - which is an end of the list. It is repositioned each time a new `ChunkItem` is added.
<br/>The `Chunk` class contains the private boolean field: `DoneCopyingChunk`, which indicates that all chunk elements have been copied to the list of ChunkItems, and the source enumerator is either at the end, or else on an element with a new key.
The tail of the linked list is set to `null` in the `CopyNextChunkElement` method if the key of the next element does not match the current chunk's key, or there are no more elements in the source.

The `CopyNextChunkElement` method of the `Chunk` class adds one `ChunkItem` to the current group of items.
<br/>By using `enumerator.MoveNext()` method, it tries to advance the iterator on the source sequence. If `MoveNext()` method returns `false` it means that iteration is at the end, and `isLastSourceElement` is set to `true`.
Then, if iteration is at the end of the source, or at the end of the current chunk then the `enumerator` and `predicate` is null out for reuse with the next chunk.

The `CopyAllChunkElements` method is called after the end of the last chunk was reached. It first checks whether there are more elements in the source sequence. If there are, it returns `true` if enumerator for this chunk was exhausted. In this method, when private `DoneCopyingChunk` field is checked for `true`, if isLastSourceElement is `false`, it signals to the outer iterator to continue iterating.

The `GetEnumerator` method of the `Chunk` class is invoked by the inner foreach loop. This method stays just one step ahead of the client requests. It adds the next element of the chunk only after the clients requests the last element in the list so far.

## Add custom methods for LINQ queries

You extend the set of methods that you use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, in addition to the standard average or maximum operations, you create a custom aggregate method to compute a single value from a sequence of values. You also create a method that works as a custom filter or a specific data transform for a sequence of values and returns a new sequence. Examples of such methods are <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Skip%2A>, and <xref:System.Linq.Enumerable.Reverse%2A>.

When you extend the <xref:System.Collections.Generic.IEnumerable%601> interface, you can apply your custom methods to any enumerable collection. For more information, see [Extension Methods](../programming-guide/classes-and-structs/extension-methods.md).

An *aggregate* method computes a single value from a set of values. LINQ provides several aggregate methods, including <xref:System.Linq.Enumerable.Average%2A>, <xref:System.Linq.Enumerable.Min%2A>, and <xref:System.Linq.Enumerable.Max%2A>. You can create your own aggregate method by adding an extension method to the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to create an extension method called `Median` to compute a median for a sequence of numbers of type `double`.

:::code language="csharp" source="./snippets/HowToExtend/LinqExtensions.cs" ID="LinqExtensionClass":::

You call this extension method for any enumerable collection in the same way you call other aggregate methods from the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to use the `Median` method for an array of type `double`.

:::code language="csharp" source="./snippets/HowToExtend/Program.cs" ID="MedianUsage":::

You can *overload your aggregate method* so that it accepts sequences of various types. The standard approach is to create an overload for each type. Another approach is to create an overload that will take a generic type and convert it to a specific type by using a delegate. You can also combine both approaches.

You can create a specific overload for each type that you want to support. The following code example shows an overload of the `Median` method for the `int` type.

:::code language="csharp" source="./snippets/HowToExtend/LinqExtensions.cs" ID="IntOverload":::

You can now call the `Median` overloads for both `integer` and `double` types, as shown in the following code:

:::code language="csharp" source="./snippets/HowToExtend/Program.cs" ID="OverloadUsage":::

You can also create an overload that accepts a *generic sequence* of objects. This overload takes a delegate as a parameter and uses it to convert a sequence of objects of a generic type to a specific type.

The following code shows an overload of the `Median` method that takes the <xref:System.Func%602> delegate as a parameter. This delegate takes an object of generic type T and returns an object of type `double`.

:::code language="csharp" source="./snippets/HowToExtend/LinqExtensions.cs" ID="GenericOverload":::

You can now call the `Median` method for a sequence of objects of any type. If the type doesn't have its own method overload, you have to pass a delegate parameter. In C#, you can use a lambda expression for this purpose. Also, in Visual Basic only, if you use the `Aggregate` or `Group By` clause instead of the method call, you can pass any value or expression that is in the scope this clause.

The following example code shows how to call the `Median` method for an array of integers and an array of strings. For strings, the median for the lengths of strings in the array is calculated. The example shows how to pass the <xref:System.Func%602> delegate parameter to the `Median` method for each case.

:::code language="csharp" source="./snippets/HowToExtend/Program.cs" ID="GenericUsage":::

You can extend the <xref:System.Collections.Generic.IEnumerable%601> interface with a custom query method that returns a *sequence of values*. In this case, the method must return a collection of type <xref:System.Collections.Generic.IEnumerable%601>. Such methods can be used to apply filters or data transforms to a sequence of values.

The following example shows how to create an extension method named `AlternateElements` that returns every other element in a collection, starting from the first element.

:::code language="csharp" source="./snippets/HowToExtend/LinqExtensions.cs" ID="SequenceElement":::

You can call this extension method for any enumerable collection just as you would call other methods from the <xref:System.Collections.Generic.IEnumerable%601> interface, as shown in the following code:

:::code language="csharp" source="./snippets/HowToExtend/Program.cs" ID="SequenceUsage":::
