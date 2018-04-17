---
title: "Commonly Used Collection Types"
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
  - "objects [.NET Framework], grouping in collections"
  - "generics [.NET Framework], collections"
  - "IList interface, grouping data in collections"
  - "IDictionary interface, grouping data in collections"
  - "grouping data in collections, generic collection types"
  - "Collections classes"
  - "generic collections"
ms.assetid: f5d4c6a4-0d7b-4944-a9fb-3b12d9ebfd55
caps.latest.revision: 29
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Commonly Used Collection Types
Collection types are the common variations of data collections, such as hash tables, queues, stacks, bags, dictionaries, and lists.  
  
 Collections are based on the <xref:System.Collections.ICollection> interface, the <xref:System.Collections.IList> interface, the <xref:System.Collections.IDictionary> interface, or their generic counterparts. The <xref:System.Collections.IList> interface and the <xref:System.Collections.IDictionary> interface are both derived from the <xref:System.Collections.ICollection> interface; therefore, all collections are based on the <xref:System.Collections.ICollection> interface either directly or indirectly. In collections based on the <xref:System.Collections.IList> interface (such as <xref:System.Array>, <xref:System.Collections.ArrayList>, or <xref:System.Collections.Generic.List%601>) or directly on the <xref:System.Collections.ICollection> interface (such as <xref:System.Collections.Queue>, <xref:System.Collections.Concurrent.ConcurrentQueue%601>, <xref:System.Collections.Stack>, <xref:System.Collections.Concurrent.ConcurrentStack%601> or <xref:System.Collections.Generic.LinkedList%601>), every element contains only a value. In collections based on the <xref:System.Collections.IDictionary> interface (such as the <xref:System.Collections.Hashtable> and <xref:System.Collections.SortedList> classes, the <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Generic.SortedList%602> generic classes), or the <xref:System.Collections.Concurrent.ConcurrentDictionary%602> classes, every element contains both a key and a value.  The <xref:System.Collections.ObjectModel.KeyedCollection%602> class is unique because it is a list of values with keys embedded within the values and, therefore, it behaves like a list and like a dictionary.  
  
 Generic collections are the best solution to strong typing. However, if your language does not support generics, the <xref:System.Collections> namespace includes base collections, such as <xref:System.Collections.CollectionBase>, <xref:System.Collections.ReadOnlyCollectionBase>, and <xref:System.Collections.DictionaryBase>, which are abstract base classes that can be extended to create collection classes that are strongly typed. When efficient multi-threaded collection access is required, use the generic collections in the <xref:System.Collections.Concurrent> namespace.  
  
 Collections can vary, depending on how the elements are stored, how they are sorted, how searches are performed, and how comparisons are made. The <xref:System.Collections.Queue> class and the <xref:System.Collections.Generic.Queue%601> generic class provide first-in-first-out lists, while the <xref:System.Collections.Stack> class and the <xref:System.Collections.Generic.Stack%601> generic class provide last-in-first-out lists. The <xref:System.Collections.SortedList> class and the <xref:System.Collections.Generic.SortedList%602> generic class provide sorted versions of the <xref:System.Collections.Hashtable> class and the <xref:System.Collections.Generic.Dictionary%602> generic class. The elements of a <xref:System.Collections.Hashtable> or a <xref:System.Collections.Generic.Dictionary%602> are accessible only by the key of the element, but the elements of a <xref:System.Collections.SortedList> or a <xref:System.Collections.ObjectModel.KeyedCollection%602> are accessible either by the key or by the index of the element. The indexes in all collections are zero-based, except <xref:System.Array>, which allows arrays that are not zero-based.  
  
 The LINQ to Objects feature allows you to use LINQ queries to access in-memory objects as long as the object type implements <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601>. LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard `foreach` loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance. For more information, see [LINQ to Objects](https://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9) and [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Collections and Data Structures](../../../docs/standard/collections/index.md)|Discusses the various collection types available in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], including stacks, queues, lists, arrays, and dictionaries.|  
|[Hashtable and Dictionary Collection Types](../../../docs/standard/collections/hashtable-and-dictionary-collection-types.md)|Describes the features of generic and nongeneric hash-based dictionary types.|  
|[Sorted Collection Types](../../../docs/standard/collections/sorted-collection-types.md)|Describes classes that provide sorting functionality for lists and sets.|  
|[Generics](../../../docs/standard/generics/index.md)|Describes the generics feature, including the generic collections, delegates, and interfaces provided by the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. Provides links to feature documentation for C#, Visual Basic, and Visual C++, and to supporting technologies such as reflection.|  
  
## Reference  
 <xref:System.Collections?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic?displayProperty=nameWithType>  
  
 <xref:System.Collections.ICollection?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.ICollection%601?displayProperty=nameWithType>  
  
 <xref:System.Collections.IList?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.IList%601?displayProperty=nameWithType>  
  
 <xref:System.Collections.IDictionary?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.IDictionary%602?displayProperty=nameWithType>
