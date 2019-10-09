---
title: "System.Buffers in .NET"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "pipes [.NET Framework]"
  - "pipe operations [.NET Framework]"
  - "interprocess communication [.NET Framework], pipes"
  - "I/O [.NET Framework], pipes"
author: rick-anderson
ms.author: riande
---
# Work with Buffers in .NET

<!-- >
- **Writing**
    - [IBufferWriter\<T\>](#ibufferwritert)
       - [Gotchas](#gotchas)
- **Reading**
    - [ReadOnlySequence\<T\>](#readonlysequencet)
       - [Accessing data](#accessing-data)
       - [Gotchas](#gotchas-1)
    - [SequenceReader\<T\>](#sequencereadert)
       - [Accessing data](#accessing-data-1)
       - [Gotchas](#gotchas-2)
   -->
## IBufferWriter\<T\>

<xref:System.Buffers.IBufferWriter`1?displayProperty=fullName> is a contract for synchronous buffered writing. At the lowest level the interface:

* Is basic and not difficult to use.
* Allows access to a <xref:System.Memory\<T>> or <xref:System.Span\<T>>. The `Memory<T>` or `Span<T>` can be written too and you can determine how many `T` items were written.

[!code-csharp[](temp/MyClass.cs?name=snippet)]

The preceding method:

* Requests a buffer of at least 5 bytes from the `IBufferWriter<byte>` using `GetSpan(5)`.
* Writes bytes for the ASCII string "Hello" to the returned `Span<byte>`.
* Calls <xref:System.Buffers.IBufferWriter*> to indicate how many bytes were written to the buffer.

This method of writing uses the `Memory<T>`/`Span<T>` buffer provided by the `IBufferWriter<T>`. Alternatively, the <xref:System.Buffers.BuffersExtensions.Write*> extension method can be used to copy an existing buffer to the `IBufferWriter<T>`. `Write` does the work of calling `GetSpan`/`Advance` as appropriate, so there's no need to call `Advance` after writing.

In the following code, there is no need to call `Advance` because `Write` calls `Advance`:

[!code-csharp[](temp/MyClass.cs?name=snippet2)]

<xref:System.Buffers.ArrayBufferWriter`1> is an implementation of `IBufferWriter<T>` whose backing store is a single contiguous array.

### IBufferWriter common problems

- `GetSpan` and `GetMemory` return a buffer with at least the requested amount of memory. Don't assume exact buffer sizes.
- There is no guarantee that successive calls will return the same buffer or the same-sized buffer.
- A new buffer must be requested after calling `Advance` to continue writing more data. A previously acquired buffer cannot be written to.

## [ReadOnlySequence\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.readonlysequence-1)

![image](https://user-images.githubusercontent.com/95136/64049773-cbd04600-cb2a-11e9-9d37-404488a2d6d5.png)

`ReadOnlySequence<T>` is a struct that can represent a contiguous or discontiguous sequence of T. It can be constructed from:
1. A `T[]`
1. A `ReadOnlyMemory<T>`
1. A pair of linked list node [`ReadOnlySequenceSegment<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.readonlysequencesegment-1?view=netstandard-2.1) and index to represent the start and end position of the sequence

The 3rd representation is the most interesting one as it has performance implications on various operations on the `ReadOnlySequence<T>`:

|Representation|Operation|Complexity|
---|---|---
|`T[]`/`ReadOnlyMemory<T>`|`Length`|`O(1)`
|`T[]`/`ReadOnlyMemory<T>`|`GetPosition(long)`|`O(1)`
|`T[]`/`ReadOnlyMemory<T>`|`Slice(int, int)`|`O(1)`
|`T[]`/`ReadOnlyMemory<T>`|`Slice(SequencePostion,  SequencePostion)`|`O(1)`
|`ReadOnlySequenceSegment<T>`|`Length`|`O(1)`
|`ReadOnlySequenceSegment<T>`|`GetPosition(long)`|`O(number of segments)`
|`ReadOnlySequenceSegment<T>`|`Slice(int, int)`|`O(number of segments)`
|`ReadOnlySequenceSegment<T>`|`Slice(SequencePostion, SequencePostion)`|`O(1)`

Because of this mixed representation, the `ReadOnlySequence<T>` exposes indexes as `SequencePosition` instead of an integer. A `SequencePosition` is an opaque value that represents an index into the `ReadOnlySequence<T>` where it originated. It consists of 2 parts, an integer and an object, what these 2 values represent are tied to the implementation of `ReadOnlySequence<T>`.

### Accessing data

The `ReadOnlySequence<T>` exposes data as an enumerable of `ReadOnlyMemory<T>`. Enumerating each of the segments can be done using a simple foreach:

```C#
long FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
{
    long position = 0;
    
    foreach (ReadOnlyMemory<byte> segment in buffer)
    {
        ReadOnlySpan<byte> span = segment.Span;
        var index = span.IndexOf(data);
        if (index != -1)
        {
            return position + index;
        }
        
        position += span.Length;
    }
    
    return -1;
}
```

The above method searches each segment for a specific byte. If we need to keep track of each segment's `SequencePosition` then [`ReadOnlySequence.TryGet`](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.readonlysequence-1.tryget?view=netcore-3.0) would be more appropriate. Let's change the above code to return a `SequencePosition` instead of an integer. This has the added benefit of allowing the caller to avoid a second scan to get the data at a specific index.

```C#
SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
{
    SequencePosition position = buffer.Start;
    
    while (buffer.TryGet(ref position, out ReadOnlyMemory<byte> segment))
    {
        ReadOnlySpan<byte> span = segment.Span;
        var index = span.IndexOf(data);
        if (index != -1)
        {
            return buffer.GetPosition(position, index);
        }
    }
    return null;
}
```

The combination of `SequencePosition` and `TryGet` act like an enumerator. The position field is modified at the start of each iteration to be start of each segment within the `ReadOnlySequence<T>`. 

The preceding method exists as an extension method on `ReadOnlySequence<T>`. We can use [PositionOf](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.buffersextensions.positionof?view=netstandard-2.1) to simplify the above code:

```C#
SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data) => buffer.PositionOf(data);
```

#### Processing a ReadOnlySequence\<T\> 

Processing a `ReadOnlySequence<T>` can be challenging since data may be split across multiple segments within the sequence. For the best performance, split code into a fast path, that deals with the single segment case, and a slow path that deals with the data split across segments. There are a few approaches that can be used to process data in multi-segmented sequences:

- Use the [`SequenceReader<T>`](#sequencereadert)
- Parse data segment by segment, keeping track of the `SequencePosition` and index within the segment parsed. This avoids unnecessary allocations but may be inefficient (especially for small buffers).
- Copy the `ReadOnlySequence<T>` to a contiguous array and treat it like a single buffer:
  - If the `ReadOnlySequence<T>` has a length less then 256, it may be reasonable to copy the data into a stack-allocated buffer (using the `stackalloc` keyword).
  - Copy the `ReadOnlySequence<T>` into a pooled array using `ArrayPool<T>.Shared`.
  - Use `ReadOnlySequence<T>.ToArray()`. This is not recommended in hot paths as it allocates a new `T[]` on the heap.

The following examples demonstrate some common cases for processing `ReadOnlySequence<byte>`:

##### Processing Binary Data

This example parses a 4 byte big-endian integer length from the start of the `ReadOnlySequence<byte>`.

```C#
bool TryParseHeaderLength(ref ReadOnlySequence<byte> buffer, out int length)
{
    // If we don't have enough space, we can't get the length
    if (buffer.Length < 4)
    {
        length = 0;
        return false;
    }
    
    // Grab the first 4 bytes of the buffer
    var lengthSlice = buffer.Slice(buffer.Start, 4);
    if (lengthSlice.IsSingleSegment)
    {
        // Fast path since it's a single segment
        length = BinaryPrimitives.ReadInt32BigEndian(lengthSlice.First.Span);
    }
    else
    {
        // We have 4 bytes split across multiple segments, since it's so small we can copy it to a
        // stack allocated buffer, this avoids a heap allocation.
        Span<byte> stackBuffer = stackalloc byte[4];
        lengthSlice.CopyTo(stackBuffer);
        length = BinaryPrimitives.ReadInt32BigEndian(stackBuffer);
    }
    
    // Move the buffer 4 bytes ahead
    buffer = buffer.Slice(lengthSlice.End);
    
    return true;
}
```

##### Processing Text Data

This example finds the first newline (`\r\n`) in the `ReadOnlySequence<byte>` and returns it via the out 'line' parameter. It also trims that line (excluding the `\r\n` from the input buffer).

```C#
static bool TryParseLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
{
    SequencePosition position = buffer.Start;
    SequencePosition previous = position;
    var index = -1;
    line = default;

    while (buffer.TryGet(ref position, out ReadOnlyMemory<byte> segment))
    {
        ReadOnlySpan<byte> span = segment.Span;

        // Look for \r in the current segment
        index = span.IndexOf((byte)'\r');

        if (index != -1)
        {
            // Check next segment for \n
            if (index + 1 >= span.Length)
            {
                var next = position;
                if (!buffer.TryGet(ref next, out ReadOnlyMemory<byte> nextSegment))
                {
                    // We're at the end of the sequence
                    return false;
                }
                else if (nextSegment.Span[0] == (byte)'\n')
                {
                    //  We found a match
                    break;
                }
            }
            // Check the current segment of \n
            else if (span[index + 1] == (byte)'\n')
            {
                // Found it
                break;
            }
        }

        previous = position;
    }

    if (index != -1)
    {
        // Get the position just before the \r\n
        var delimeter = buffer.GetPosition(index, previous);
        
        // Slice the line (excluding \r\n)
        line = buffer.Slice(buffer.Start, delimeter);
        
        // Slice the buffer to get the renamining data after the line
        buffer = buffer.Slice(buffer.GetPosition(2, delimeter));
        return true;
    }

    return false;
}
```

##### Empty segments

It is valid to store empty segments inside of a `ReadOnlySequence<T>` and it may show up while enumerating segments explicitly:

```C#
static void EmptySegments()
{
    // This logic creates a ReadOnlySequence<byte> with 4 segments but with a length of 2
    // 2 of those segments are empty
    var first = new BufferSegment(new byte[0]);
    var last = first.Append(new byte[] { 97 }).Append(new byte[0]).Append(new byte[] { 98 });
    
    // Construct the ReadOnlySequence<byte> from the linked list segments
    var data = new ReadOnlySequence<byte>(first, 0, last, 1);

    // Slice using numbers
    var sequence1 = data.Slice(0, 2);
    
    // Slice using SequencePosition pointing at the empty segment
    var sequence2 = data.Slice(data.Start, 2);

    Console.WriteLine($"sequence1.Length={sequence1.Length}"); // sequence1.Length=2
    Console.WriteLine($"sequence2.Length={sequence2.Length}"); // sequence2.Length=2

    Console.WriteLine($"sequence1.FirstSpan.Length={sequence1.FirstSpan.Length}"); // sequence1.FirstSpan.Length=1
    
    // Slicing using SequencePosition will Slice the ReadOnlySequence<byte> directly on the empty segment!
    Console.WriteLine($"sequence2.FirstSpan.Length={sequence2.FirstSpan.Length}"); // sequence2.FirstSpan.Length=0

    // This prints 0, 1, 0, 1
    SequencePosition position = data.Start;
    while (data.TryGet(ref position, out ReadOnlyMemory<byte> memory))
    {
        Console.WriteLine(memory.Length);
    }
}

class BufferSegment : ReadOnlySequenceSegment<byte>
{
    public BufferSegment(Memory<byte> memory)
    {
        Memory = memory;
    }

    public BufferSegment Append(Memory<byte> memory)
    {
        var segment = new BufferSegment(memory)
        {
            RunningIndex = RunningIndex + Memory.Length
        };
        Next = segment;
        return segment;
    }
}
```

The preceding logic creates a `ReadOnlySequence<byte>` with empty segments and shows how those empty segments affect the various APIs:
- `ReadOnlySequence<T>.Slice` with a `SequencePosition` pointing to an empty segment will preserve that segment.
- `ReadOnlySequence<T>.Slice` with an int will skip over the empty segments.
- Enumerating the `ReadOnlySequence<T>` will enumerate the empty segments as well.

### Gotchas

There are several quirks when dealing with a `ReadOnlySequence<T>`/`SequencePosition` vs. a normal `ReadOnlySpan<T>`/`ReadOnlyMemory<T>`/`T[]`/`int`:
- `SequencePosition` is a position marker for a specific `ReadOnlySequence<T>`, not an absolute position. As it is relative to a specific `ReadOnlySequence<T>`, it doesn't have meaning if used outside of the `ReadOnlySequence<T>` where it originated.
- Arithmetic cannot be performed on `SequencePosition` without the `ReadOnlySequence<T>`. This means doing simple things like `position++` looks like `ReadOnlySequence<T>.GetPosition(position, 1)`.
- `GetPosition(long)` does **not** support negative indexes. This means it's impossible to get the second to last character without walking all segments.
- `SequencePosition`(s) cannot be compared. This makes it hard to know if one position is greater than or less than another position and makes it hard to write some parsing algorithms.
- `ReadOnlySequence<T>` is bigger than an object reference and should be passed by `in` or `ref` where possible. This reduces copies of the struct.
- Empty segments are valid within a `ReadOnlySequence<T>` and can appear when iterating using `ReadOnlySequence<T>.TryGet` or slicing the sequence using `ReadOnlySequence<T>.Slice()` with `SequencePosition`(s).

## [SequenceReader\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.sequencereader-1?view=netcore-3.0)

`SequenceReader<T>` is a new type that was introduced in .NET Core 3.0 to simplify the processing of a `ReadOnlySequence<T>`. It unifies the differences between a single segment `ReadOnlySequence<T>` and multi-segment `ReadOnlySequence<T>`. It also provides helpers for reading binary and text data (byte and char) that may or may not be split across segments. 

There are built-in methods for dealing with processing both binary and delimited data. Let's take a look at what those same methods look like with the `SequenceReader<T>`:

#### Accessing data

`SequenceReader<T>` has methods for enumerating data inside of the `ReadOnlySequence<T>` directly. Below is an example of processing a `ReadOnlySequence<byte>` a `byte` at a time:

```C#
while (!reader.End)
{
    var b = reader.CurrentSpan[reader.CurrentSpanIndex];
    Process(b);
    reader.Advance(1);
}
```

The `CurrentSpan` exposes the current segment's `Span` (similar to what we do in the method manually).

#### Position

Here's an example implementation of `FindIndexOf` using the `SequenceReader<T>`:

```C#
SequencePosition? FindIndexOf(in ReadOnlySequence<byte> buffer, byte data)
{
    var reader = new SequenceReader<byte>(buffer);

    while (!reader.End)
    {
        // Search for the byte in the current span
        var index = reader.CurrentSpan.IndexOf(data);
        if (index != -1)
        {
            // We found it so advance to the position
            reader.Advance(index);
            
            // Return the position
            return reader.Position;
        }
        // Skip the current segment since there's nothing in it
        reader.Advance(reader.CurrentSpan.Length);
    }

    return null;
}
```

#### Processing Binary Data

This example parses a 4 byte big-endian integer length from the start of the `ReadOnlySequence<byte>`.

```C#
bool TryParseHeaderLength(ref ReadOnlySequence<byte> buffer, out int length)
{
    var reader = new SequenceReader<byte>(buffer);
    return reader.TryReadBigEndian(out length);
}
```

#### Processing Text Data

```C#
static ReadOnlySpan<byte> NewLine => new byte[] { (byte)'\r', (byte)'\n' };

static bool TryParseLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
{
    var reader = new SequenceReader<byte>(buffer);

    if (reader.TryReadTo(out line, NewLine))
    {
        buffer = buffer.Slice(reader.Position);

        return true;
    }

    line = default;
    return false;
}
```

### Gotchas
- `SequenceReader<T>` is a mutable struct; it should always be passed by reference (ref keyword).
- `SequenceReader<T>` is a ref-struct so it can only be used in synchronous methods and cannot be stored in fields.
- `SequenceReader<T>` is a forward-only reader, and `Advance` does not support negative numbers.
