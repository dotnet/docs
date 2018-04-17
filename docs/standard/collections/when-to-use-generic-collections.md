---
title: "When to Use Generic Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "collections [.NET Framework], generic"
  - "generic collections [.NET Framework]"
ms.assetid: e7b868b1-11fe-4ac5-bed3-de68aca47739
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# When to Use Generic Collections
Using generic collections is generally recommended, because you gain the immediate benefit of type safety without having to derive from a base collection type and implement type-specific members. Generic collection types also generally perform better than the corresponding nongeneric collection types (and better than types that are derived from nongeneric base collection types) when the collection elements are value types, because with generics there is no need to box the elements.  
  
 For programs that target the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] or later, you should use the generic collection classes in the <xref:System.Collections.Concurrent> namespace when multiple threads might be adding or removing items from the collection concurrently.  
  
 The following generic types correspond to existing collection types:  
  
-   <xref:System.Collections.Generic.List%601> is the generic class that corresponds to <xref:System.Collections.ArrayList>.  
  
-   <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Concurrent.ConcurrentDictionary%602> are the generic classes that correspond to <xref:System.Collections.Hashtable>.  
  
-   <xref:System.Collections.ObjectModel.Collection%601> is the generic class that corresponds to <xref:System.Collections.CollectionBase>. <xref:System.Collections.ObjectModel.Collection%601> can be used as a base class, but unlike <xref:System.Collections.CollectionBase>, it is not abstract. This makes it much easier to use.  
  
-   <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> is the generic class that corresponds to <xref:System.Collections.ReadOnlyCollectionBase>. <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> is not abstract, and has a constructor that makes it easy to expose an existing <xref:System.Collections.Generic.List%601> as a read-only collection.  
  
-   The <xref:System.Collections.Generic.Queue%601>, <xref:System.Collections.Concurrent.ConcurrentQueue%601>, <xref:System.Collections.Generic.Stack%601>, <xref:System.Collections.Concurrent.ConcurrentStack%601>, and <xref:System.Collections.Generic.SortedList%602> generic classes correspond to the respective nongeneric classes with the same names.  
  
## Additional Types  
 Several generic collection types do not have nongeneric counterparts. They include the following:  
  
-   <xref:System.Collections.Generic.LinkedList%601> is a general-purpose linked list that provides O(1) insertion and removal operations.  
  
-   <xref:System.Collections.Generic.SortedDictionary%602> is a sorted dictionary with O(log `n`) insertion and retrieval operations, which makes it a useful alternative to <xref:System.Collections.Generic.SortedList%602>.  
  
-   <xref:System.Collections.ObjectModel.KeyedCollection%602> is a hybrid between a list and a dictionary, which provides a way to store objects that contain their own keys.  
  
-   <xref:System.Collections.Concurrent.BlockingCollection%601> implements a collection class with bounding and blocking functionality.  
  
-   <xref:System.Collections.Concurrent.ConcurrentBag%601> provides fast insertion and removal of unordered elements.  
  
## LINQ to Objects  
 The LINQ to Objects feature enables you to use LINQ queries to access in-memory objects as long as the object type implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard `foreach` loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance. For more information, see [LINQ to Objects](https://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9) and [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md).  
  
## Additional Functionality  
 Some of the generic types have functionality that is not found in the nongeneric collection types. For example, the <xref:System.Collections.Generic.List%601> class, which corresponds to the nongeneric <xref:System.Collections.ArrayList> class, has a number of methods that accept generic delegates, such as the <xref:System.Predicate%601> delegate that allows you to specify methods for searching the list, the <xref:System.Action%601> delegate that represents methods that act on each element of the list, and the <xref:System.Converter%602> delegate that lets you define conversions between types.  
  
 The <xref:System.Collections.Generic.List%601> class allows you to specify your own <xref:System.Collections.Generic.IComparer%601> generic interface implementations for sorting and searching the list. The <xref:System.Collections.Generic.SortedDictionary%602> and <xref:System.Collections.Generic.SortedList%602> classes also have this capability. In addition, these classes let you specify comparers when the collection is created. In similar fashion, the <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.ObjectModel.KeyedCollection%602> classes let you specify your own equality comparers.  
  
## See Also  
 [Collections and Data Structures](../../../docs/standard/collections/index.md)  
 [Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md)  
 [Generics](../../../docs/standard/generics/index.md)
