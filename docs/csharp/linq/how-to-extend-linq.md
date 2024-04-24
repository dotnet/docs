---
title: "How to: Write your own extensions to LINQ"
description: Learn techniques to extend the standard LINQ methods. Query based on runtime state, modify query objects, and extend LINQ capabilities.
ms.topic: how-to
ms.date: 04/22/2024
---
# How to extend LINQ

All LINQ based methods follow one of two similar patterns. They take an enumerable sequence. They return either a different sequence, or a single value. The consistency of the shape enables you to extend LINQ by writing methods with a similar shape. In fact, the .NET libraries have gained new methods in many .NET releases since LINQ was first introduced. In this article, you see examples of extending LINQ by writing your own methods that follow the same pattern.

## Add custom methods for LINQ queries

You extend the set of methods that you use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, in addition to the standard average or maximum operations, you create a custom aggregate method to compute a single value from a sequence of values. You also create a method that works as a custom filter or a specific data transform for a sequence of values and returns a new sequence. Examples of such methods are <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Skip%2A>, and <xref:System.Linq.Enumerable.Reverse%2A>.

When you extend the <xref:System.Collections.Generic.IEnumerable%601> interface, you can apply your custom methods to any enumerable collection. For more information, see [Extension Methods](../programming-guide/classes-and-structs/extension-methods.md).

An *aggregate* method computes a single value from a set of values. LINQ provides several aggregate methods, including <xref:System.Linq.Enumerable.Average%2A>, <xref:System.Linq.Enumerable.Min%2A>, and <xref:System.Linq.Enumerable.Max%2A>. You can create your own aggregate method by adding an extension method to the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to create an extension method called `Median` to compute a median for a sequence of numbers of type `double`.

:::code language="csharp" source="./snippets/HowToExtend/LinqExtensions.cs" ID="LinqExtensionClass":::

You call this extension method for any enumerable collection in the same way you call other aggregate methods from the <xref:System.Collections.Generic.IEnumerable%601> interface.

The following code example shows how to use the `Median` method for an array of type `double`.

:::code language="csharp" source="./snippets/HowToExtend/Program.cs" ID="MedianUsage":::

You can *overload your aggregate method* so that it accepts sequences of various types. The standard approach is to create an overload for each type. Another approach is to create an overload that takes a generic type and convert it to a specific type by using a delegate. You can also combine both approaches.

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

## Group results by contiguous keys

The following example shows how to group elements into chunks that represent subsequences of contiguous keys. For example, assume that you're given the following sequence of key-value pairs:

|Key | Value  |
|----|--------|
| A  | We     |
| A  | think  |
| A  | that   |
| B  | Linq   |
| C  | is     |
| A  | really |
| B  | cool   |
| B  | !      |

The following groups are created in this order:

1. We, think, that
1. Linq
1. is
1. really
1. cool, !

The solution is implemented as a thread-safe extension method that returns its results in a streaming manner. It produces its groups as it moves through the source sequence. Unlike the `group` or `orderby` operators, it can begin returning groups to the caller before reading the entire sequence. The following example shows both the extension method and the client code that uses it:

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunkextensions":::

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_client_code":::

### `ChunkExtensions` class

In the presented code of the `ChunkExtensions` class implementation, the `while(true)` loop in the `ChunkBy` method iterates through source sequence and creates a copy of each Chunk. On each pass, the iterator advances to the first element of the next "Chunk", represented by a [`Chunk`](#chunk-class) object, in the source sequence. This loop corresponds to the outer foreach loop that executes the query. In that loop, the code does the following actions:

1. Get the key for the current Chunk and assign it to `key` variable. The source iterator consumes the source sequence until it finds an element with a key that doesn't match.
1. Make a new Chunk (group) object, and store it in `current` variable. It has one GroupItem, a copy of the current source element.
1. Return that Chunk. A Chunk is an `IGrouping<TKey,TSource>`, which is the return value of the [`ChunkBy`](#chunk-class) method. The Chunk only has the first element in its source sequence. The remaining elements are returned only when the client code foreach's over this chunk. See `Chunk.GetEnumerator` for more info.
1. Check to see if:
   - The chunk has a copy of all its source elements, or
   - The iterator reached the end of the source sequence.
1. When the caller has enumerated all the chunk items, the `Chunk.GetEnumerator` method has copied all chunk items. If the `Chunk.GetEnumerator` loop didn't enumerate all elements in the chunk, do it now to avoid corrupting the iterator for clients that might be calling it on a separate thread.

### `Chunk` class

The `Chunk` class is a contiguous group of one or more source elements that have the same key. A Chunk has a key and a list of ChunkItem objects, which are copies of the elements in the source sequence:

:::code language="csharp" source="./snippets/HowToExtend/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunk_class":::

Each `ChunkItem` (represented by `ChunkItem` class) has a reference to the next `ChunkItem` in the list. The list consists of its `head` - which stores the contents of the first source element that belongs with this chunk, and its `tail` - which is an end of the list. The tail is repositioned each time a new `ChunkItem` is added. The tail of the linked list is set to `null` in the `CopyNextChunkElement` method if the key of the next element doesn't match the current chunk's key, or there are no more elements in the source.

The `CopyNextChunkElement` method of the `Chunk` class adds one `ChunkItem` to the current group of items. It tries to advance the iterator on the source sequence. If the `MoveNext()` method returns `false` the iteration is at the end, and `isLastSourceElement` is set to `true`.

The `CopyAllChunkElements` method is called after the end of the last chunk was reached. It checks whether there are more elements in the source sequence. If there are, it returns `true` if the enumerator for this chunk was exhausted. In this method, when the private `DoneCopyingChunk` field is checked for `true`, if isLastSourceElement is `false`, it signals to the outer iterator to continue iterating.

The inner foreach loop invokes the `GetEnumerator` method of the `Chunk` class. This method stays one element ahead of the client requests. It adds the next element of the chunk only after the client requests the previous last element in the list.
