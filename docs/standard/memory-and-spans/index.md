---
description: "Learn more about: Memory- and span-related types"
title: "Memory and spans"
ms.date: "10/03/2018"
helpviewer_keywords:
  - "Memory<T>"
  - "Span<T>"
  - buffers"
  - "pipeline processing"
---
# Memory- and span-related types

Starting with .NET Core 2.1, .NET includes a number of interrelated types that represent a contiguous, strongly typed region of arbitrary memory. These include:

- <xref:System.Span%601?displayProperty=nameWithType>, a type that is used to access a contiguous region of memory. A <xref:System.Span%601> instance can be backed by an array of type `T`, a <xref:System.String>, a buffer allocated with [stackalloc](../../csharp/language-reference/operators/stackalloc.md), or a pointer to unmanaged memory. Because it has to be allocated on the stack, it has a number of restrictions. For example, a field in a class cannot be of type <xref:System.Span%601>, nor can span be used in asynchronous operations.

- <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>, an immutable version of the <xref:System.Span%601> structure.

- <xref:System.Memory%601?displayProperty=nameWithType>, a wrapper over a contiguous region of memory. A <xref:System.Memory%601> instance can be backed by an array of type `T`, or a <xref:System.String>, or a memory manager. As it can be stored on the managed heap, <xref:System.Memory%601> has none of the limitations of <xref:System.Span%601>.

- <xref:System.ReadOnlyMemory%601?displayProperty=nameWithType>, an immutable version of the <xref:System.Memory%601> structure.

- <xref:System.Buffers.MemoryPool%601?displayProperty=nameWithType>, which allocates strongly typed blocks of memory from a memory pool to an owner. <xref:System.Buffers.IMemoryOwner%601> instances can be rented from the pool by calling <xref:System.Buffers.MemoryPool%601.Rent%2A?displayProperty=nameWithType> and released back to the pool by calling <xref:System.Buffers.MemoryPool%601.Dispose?displayProperty=nameWithType>.

- <xref:System.Buffers.IMemoryOwner%601?displayProperty=nameWithType>, which represents the owner of a block of memory and controls its lifetime management.

- <xref:System.Buffers.MemoryManager%601>, an abstract base class that can be used to replace the implementation of <xref:System.Memory%601> so that <xref:System.Memory%601> can be backed by additional types, such as safe handles. <xref:System.Buffers.MemoryManager%601> is intended for advanced scenarios.

- <xref:System.ArraySegment%601>, a wrapper for a particular number of array elements starting at a particular index.

- <xref:System.MemoryExtensions?displayProperty=nameWithType>, a collection of extension methods for converting strings, arrays, and array segments to <xref:System.Memory%601> blocks.

<xref:System.Span%601?displayProperty=nameWithType>, <xref:System.Memory%601?displayProperty=nameWithType>, and their readonly counterparts are designed to allow the creation of algorithms that avoid copying memory or allocating on the managed heap more than necessary. Creating them (either via `Slice` or their constructors) does not involve duplicating the underlying buffers: only the relevant references and offsets, which represent the "view" of the wrapped memory, are updated.

> [!NOTE]
> For earlier frameworks, <xref:System.Span%601> and <xref:System.Memory%601> are available in the [System.Memory NuGet package](https://www.nuget.org/packages/System.Memory/).

For more information, see the <xref:System.Buffers?displayProperty=nameWithType> namespace.

## Working with memory and span

Because the memory- and span-related types are typically used to store data in a processing pipeline, it is important that developers follow a set of best practices when using <xref:System.Span%601>, <xref:System.Memory%601>, and related types. These best practices are documented in [Memory\<T> and Span\<T> usage guidelines](memory-t-usage-guidelines.md).

## See also

- <xref:System.Memory%601?displayProperty=nameWithType>
- <xref:System.ReadOnlyMemory%601?displayProperty=nameWithType>
- <xref:System.Span%601?displayProperty=nameWithType>
- <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>
- <xref:System.Buffers?displayProperty=nameWithType>
