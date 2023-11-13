---
title: Group results by contiguous keys (LINQ in C#)
description: How to group results by contiguous keys using LINQ in C#.
ms.date: 08/14/2018
ms.assetid: cbda9c08-151b-4c9e-82f7-c3d7f3dac66b
---
# Group results by contiguous keys

The following example shows how to group elements into chunks that represent subsequences of contiguous keys. For example, assume that you are given the following sequence of key-value pairs:

|Key|Value|
|---------|-----------|
|A|We|
|A|think|
|A|that|
|B|Linq|
|C|is|
|A|really|
|B|cool|
|B|!|

The following groups will be created in this order:

1. We, think, that  
2. Linq  
3. is  
4. really  
5. cool, !

The solution is implemented as an extension method that is thread-safe and that returns its results in a streaming manner. In other words, it produces its groups as it moves through the source sequence. Unlike the `group` or `orderby` operators, it can begin returning groups to the caller before all of the sequence has been read.

Thread-safety is accomplished by making a copy of each group or chunk as the source sequence is iterated, as explained in the source code comments. If the source sequence has a large sequence of contiguous items, the common language runtime may throw an <xref:System.OutOfMemoryException>.

## Example

The following example shows both the extension method and the client code that uses it:

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_chunkextensions":::

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupByContiguousKeys.cs" id="group_by_contiguous_keys_client_code":::

### `ChunkExtensions` class

In the presented code, of `ChunkExtensions` class implementation, the `while(true)`, loop in the `ChunkBy` method, iterates through source sequence and create a copy of each Chunk. On each pass, the iterator advances to the first element of the next "Chunk"
<br/>(The chunk is represented by [`Chunk`](#chunk-class) class.)
<br/>in the source sequence. This loop corresponds to the outer foreach loop that executes the query.
What happens in that loop is:

1. Get the key for the current Chunk, by assigning it to `key` variable: `var key = keySelector(enumerator.Current);`. The source iterator will churn through the source sequence until it finds an element with a key that doesn't match.
2. Make a new Chunk (group) object, and store it in `current` variable, that initially has one GroupItem, which is a copy of the current source element.
3. Return that Chunk. A Chunk is an `IGrouping<TKey,TSource>`, which is the return value of the [`ChunkBy`](#chunk-class) method. At this point the Chunk only has the first element in its source sequence. The remaining elements will be returned only when the client code foreach's over this chunk. See `Chunk.GetEnumerator` for more info.
4. Check to see whether
<br/>(a) the chunk has made a copy of all its source elements or
<br/>(b) the iterator has reached the end of the source sequence.
<br/>If the caller uses an inner foreach loop to iterate the chunk items, and that loop ran to completion, then the `Chunk.GetEnumerator` method will already have made copies of all chunk items before we get here. If the `Chunk.GetEnumerator` loop did not enumerate all elements in the chunk, we need to do it here to avoid corrupting the iterator for clients that may be calling us on a separate thread.

### `Chunk` class

The `Chunk` class is a contiguous group of one or more source elements that have the same key. A Chunk has a key and a list of ChunkItem objects, which are copies of the elements in the source sequence.
<br/>A Chunk has a linked list of `ChunkItem`s, which represent the elements in the current chunk. Each `ChunkItem` (represented by `ChunkItem` class) has a reference to the next `ChunkItem` in the list.
The list consists of it's `head` - which stores the contents of the first source element that belongs with this chunk, and it's `tail` - which is an end of the list. It is repositioned each time a new `ChunkItem` is added.
<br/>The `Chunk` class contains the private boolean field: `DoneCopyingChunk`, which indicates that all chunk elements have been copied to the list of ChunkItems, and the source enumerator is either at the end, or else on an element with a new key.
The tail of the linked list is set to `null` in the `CopyNextChunkElement` method if the key of the next element does not match the current chunk's key, or there are no more elements in the source.

The `CopyNextChunkElement` method of the `Chunk` class adds one `ChunkItem` to the current group of items.
<br/>By using `enumerator.MoveNext()` method, it tries to advance the iterator on the source sequence. If `MoveNext()` method returns `false` it means that iteration is at the end, and `isLastSourceElement` is set to `true`.
Then, if iteration is at the end of the source, or at the end of the current chunk then the `enumerator` and `predicate` is null out for reuse with the next chunk.

The `CopyAllChunkElements` method is called after the end of the last chunk was reached. It first checks whether there are more elements in the source sequence. If there are, it returns `true` if enumerator for this chunk was exhausted. In this method, when private `DoneCopyingChunk` field is checked for `true`, if isLastSourceElement is `false`, it signals to the outer iterator to continue iterating.

The `GetEnumerator` method of the `Chunk` class is invoked by the inner foreach loop. This method stays just one step ahead of the client requests. It adds the next element of the chunk only after the clients requests the last element in the list so far.

## See also

- [Language Integrated Query (LINQ)](index.md)
