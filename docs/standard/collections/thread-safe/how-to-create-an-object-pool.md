---
description: "Learn more about: Create an object pool by using a ConcurrentBag"
title: "Create an object pool by using a ConcurrentBag"
ms.date: 05/01/2020
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "object pool, in .NET Framework"
ms.assetid: 0480e7ff-b6f9-480e-a889-2ed4264d8372
---

# Create an object pool by using a ConcurrentBag

This example shows how to use a <xref:System.Collections.Concurrent.ConcurrentBag%601> to implement an object pool. Object pools can improve application performance in situations where you require multiple instances of a class and the class is expensive to create or destroy. When a client program requests a new object, the object pool first attempts to provide one that has already been created and returned to the pool. If none is available, only then is a new object created.

The <xref:System.Collections.Concurrent.ConcurrentBag%601> is used to store the objects because it supports fast insertion and removal, especially when the same thread is both adding and removing items. This example could be further augmented to be built around a <xref:System.Collections.Concurrent.IProducerConsumerCollection%601>, which the bag data structure implements, as do <xref:System.Collections.Concurrent.ConcurrentQueue%601> and <xref:System.Collections.Concurrent.ConcurrentStack%601>.

> [!TIP]
> This article defines how to write your own implementation of an object pool with an underlying concurrent type to store objects for reuse. However, the <xref:Microsoft.Extensions.ObjectPool.ObjectPool%601?displayProperty=nameWithType> type already exists under the <xref:Microsoft.Extensions.ObjectPool?displayProperty=fullName> namespace. Consider using the available type before creating your own implementation, which includes many additional features.

## Example

[!code-csharp[CDS#04](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds/cs/objectpool.cs#04)]
[!code-vb[CDS#04](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds/vb/objectpool04.vb#04)]

## See also

- [Thread-Safe Collections](index.md)
