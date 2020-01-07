---
title: "How to: Use Arrays of Blocking Collections in a Pipeline"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "thread-safe collections, blocking collections in pipeline"
ms.assetid: a39c7ec3-3ad7-4f4d-8fe4-b3e9dbabe2ed
---
# How to: Use Arrays of Blocking Collections in a Pipeline
The following example shows how to use arrays of <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> objects with static methods such as <xref:System.Collections.Concurrent.BlockingCollection%601.TryAddToAny%2A> and <xref:System.Collections.Concurrent.BlockingCollection%601.TryTakeFromAny%2A> to implement fast and flexible data transfer between components.  
  
## Example  
 The following example demonstrates a basic pipeline implementation in which each object is concurrently taking data from the input collection, transforming it, and passing it to the output collection.  
  
 [!code-csharp[CDS_BlockingCollection#07](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds_blockingcollection/cs/example07.cs#07)]
 [!code-vb[CDS_BlockingCollection#07](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_blockingcollection/vb/bcpipeline.vb#07)]  
  
## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- [Thread-Safe Collections](../../../../docs/standard/collections/thread-safe/index.md)
