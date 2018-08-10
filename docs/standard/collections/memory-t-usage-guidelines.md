---
title: "Memory\<T> usage guidelines"
ms.date: "08/10/2018"
helpviewer_keywords: 
  - "last-in-first-out collections"
  - "first-in-first-out collections"
  - "collections [.NET Framework], selecting collection class"
  - "indexed collections"
  - "Collections classes"
  - "grouping data in collections, selecting collection class"
author: "rpetrusha"
ms.author: "ronpet"
---
# Memory\<T> usage guidelines

.NET Core includes a number of types that represent an arbitrary continguous region of memory. .NET Core 2.0 introduced <xref:System.Span%601> and <xref:System.ReadOnlySpan%601>, which are lightweight memory bufers stored on the stack that can be backed by managed or unmanaged memory. .NET Core 2.1 added a number of types, including <xref:System.Memory%601>, <xref:System.ReadOnlyMemory%601>, <xref:System.Buffers.IMemoryOwner%601>, and <xref:System.Buffers.MemoryPool%601>. Like <xref:System.Span%601>, <xref:Memory%601> and its related types can be backed by both managed and unmanaged memory. Unlike <xref:System.Span%601>, <xref:System.Memory%601> can be stored on the managed heap.

Both <xref:System.Span%601> and <xref:System.Memory%601> are buffers of structured data that can be used in pipelines. That is, they are designed so that they can be efficiently passed to components in a the pipeline, which can process them and optionally modify the buffer. The fact that <xref:System.Memory%601> in particular is intended to be used by multiple components makes it important to use memory buffers in a way that avoids bugs. 