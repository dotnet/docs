---
title: "Memory and spans"
ms.date: "10/03/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "Memory<T>"
  - "Span<T>"
  - buffers"
  - "pipeline processing"
author: "rpetrusha"
ms.author: "ronpet"
---
# Memory- and span-related types

Starting with .NET Core 2.1, .NET includes a number of interrelated types that represent a contiguous, strongly-typed region of arbitrary memory. These include:

- <xref:System.Span%601?displayProperty=nameWithType>, a contiguous region of memory that is allocated on the stack rather than the managed heap. This allows for enhanced performance.

- <xref:System.ReadOnlySpan%601?displayProperty=nameWithtype>, an immutable version of the <xref:System.Span%601> structure.

- <xref:System.Memory%601?displayProperty=nameWithType>, a contiguous region of memory that is allocated on the managed heap rather than the stack. Unlike <xref:System.Span%601>, it can be used in asynchronous operations.

- <xref:System.ReadOnlyMemory%601?displayProperty=nameWithtype>, an immutable version of the <xref:System.Memory%601> structure.

- <xref:System.Buffers.MemoryPool%601?displayProperty=nameWithType>, which contains a number of static functions that return a strongly-typed pool of memory blocks.

- <xref:System.Buffers.IMemoryOwner%601?displayProperty=nameWithType>, which represents the owner of a block of memory.

- <xref:System.ArraySegment%601>, a wrapper for a particular number of array elements starting at a particular index.

- <xref:System.MemoryExtensions?displayProperty=nameWithType>, a collection of extensions methods for converting strings, arrays, and array segments to <xref:System.Memory%601> blocks.

For more information, see the <xref:System.Buffers?displayProperty=nameWithType> namespace.

## Working with memory and span

Because the memory- and span-related types are typically used to store data in a processing pipeline, it is important that developers follow a set of best practices when using <xref:System.Span%601>, <xref:System.Memory%601>, and related types. These best practices are documented in [Memory\<T> and Span\<T> usage guidelines](memory-t-usage-guidelines.md).

## See also

- <xref:System.Memory%601?displayProperty=nameWithType>
- <xref:System.ReadOnlyMemory%601?displayProperty=nameWithType>
- <xref:System.Span%601?displayProperty=nameWithType>
- <xref:System.ReadOnlySpan%601?displayProperty=nameWithType>
- <xref:System.Buffers?displayProperty=nameWithType>