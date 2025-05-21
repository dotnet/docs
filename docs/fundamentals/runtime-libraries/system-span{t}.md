---
title: System.Span<T> struct
description: Learn about the System.Span\<T> struct.
ms.date: 05/21/2025
dev_langs:
  - CSharp
  - FSharp
---
# System.Span\<T> struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Span%601> type is a [ref struct](../../csharp/language-reference/builtin-types/ref-struct.md) that is allocated on the stack rather than on the managed heap. Ref struct types have a number of restrictions to ensure that they cannot be promoted to the managed heap, including that they can't be boxed, they can't be assigned to variables of type <xref:System.Object>, `dynamic` or to any interface type, they can't be fields in a reference type, and they can't be used across `await` and `yield` boundaries. In addition, calls to two methods, <xref:System.Span%601.Equals(System.Object)> and <xref:System.Span%601.GetHashCode%2A>, throw a <xref:System.NotSupportedException>.

> [!IMPORTANT]
> Because it is a stack-only type, `Span<T>` is unsuitable for many scenarios that require storing references to buffers on the heap. This is true, for example, of routines that make asynchronous method calls. For such scenarios, you can use the complementary <xref:System.Memory%601?displayProperty=nameWithType> and <xref:System.ReadOnlyMemory%601?displayProperty=nameWithType> types.

For spans that represent immutable or read-only structures, use <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>.

## Memory

A `Span<T>` represents a contiguous region of arbitrary memory. A `Span<T>` instance is often used to hold the elements of an array or a portion of an array. Unlike an array, however, a `Span<T>` instance can point to managed memory, native memory, or memory managed on the stack. The following example creates a `Span<Byte>` from an array:

:::code language="csharp" source="./snippets/System/Span/Overview/csharp/program.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Span/Overview/fsharp/program.fs" id="Snippet1":::

The following example creates a `Span<Byte>` from 100 bytes of native memory:

:::code language="csharp" source="./snippets/System/Span/Overview/csharp/program.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Span/Overview/fsharp/program.fs" id="Snippet2":::

The following example uses the C# [stackalloc](/dotnet/csharp/language-reference/keywords/stackalloc) keyword to allocate 100 bytes of memory on the stack:

:::code language="csharp" source="./snippets/System/Span/Overview/csharp/program.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Span/Overview/fsharp/program.fs" id="Snippet3":::

Because `Span<T>` is an abstraction over an arbitrary block of memory, methods of the `Span<T>` type and methods with `Span<T>` parameters operate on any `Span<T>` object regardless of the kind of memory it encapsulates. For example, each of the separate sections of code that initialize the span and calculate the sum of its elements can be refactored into single initialization and calculation methods, as the following example illustrates.

:::code language="csharp" source="./snippets/System/Span/Overview/csharp/program.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Span/Overview/fsharp/program.fs" id="Snippet4":::

## Arrays

When it wraps an array, `Span<T>` can wrap an entire array, as it did in the examples in the [Memory](#memory) section. Because it supports slicing, `Span<T>` can also point to any contiguous range within the array.

The following example creates a slice of the middle five elements of a 10-element integer array. Note that the code doubles the values of each integer in the slice. As the output shows, the changes made by the span are reflected in the values of the array.

:::code language="csharp" source="./snippets/System/Span/Slice/csharp/Program.cs":::
:::code language="fsharp" source="./snippets/System/Span/Slice/fsharp/Program.fs":::

## Slices

`Span<T>` includes two overloads of the <xref:System.Span%601.Slice%2A> method that form a slice out of the current span that starts at a specified index. This makes it possible to treat the data in a `Span<T>` as a set of logical chunks that can be processed as needed by portions of a data processing pipeline with minimal performance impact. For example, since modern server protocols are often text-based, manipulation of strings and substrings is particularly important. In the <xref:System.String> class, the major method for extracting substrings is <xref:System.String.Substring%2A>. For data pipelines that rely on extensive string manipulation, its use offers some performance penalties, since it:

1. Creates a new string to hold the substring.
2. Copies a subset of the characters from the original string to the new string.

This allocation and copy operation can be eliminated by using either `Span<T>` or <xref:System.ReadOnlySpan%601>, as the following example shows:

:::code language="csharp" source="./snippets/System/Span/Slice/csharp/Program2.cs":::
:::code language="fsharp" source="./snippets/System/Span/Slice/fsharp/Program2.fs":::
