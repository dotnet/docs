---
title: "Sorted Collection Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "SortedDictionary collection type"
  - "SortedList class, grouping data in collections"
  - "grouping data in collections, SortedList collection type"
  - "SortedList collection type"
  - "collections [.NET Framework], SortedList collection type"
ms.assetid: 3db965b2-36a6-4b12-b76e-7f074ff7275a
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Sorted Collection Types
The <xref:System.Collections.SortedList?displayProperty=nameWithType> class, the <xref:System.Collections.Generic.SortedList%602?displayProperty=nameWithType> generic class, and the <xref:System.Collections.Generic.SortedDictionary%602?displayProperty=nameWithType> generic class are similar to the <xref:System.Collections.Hashtable> class and the <xref:System.Collections.Generic.Dictionary%602> generic class in that they implement the <xref:System.Collections.IDictionary> interface, but they maintain their elements in sort order by key, and they do not have the O(1) insertion and retrieval characteristic of hash tables. The three classes have several features in common:  
  
-   All three classes implement the <xref:System.Collections.IDictionary?displayProperty=nameWithType> interface. The two generic classes also implement the <xref:System.Collections.Generic.IDictionary%602?displayProperty=nameWithType> generic interface.  
  
-   Each element is a key/value pair for enumeration purposes.  
  
    > [!NOTE]
    >  The nongeneric <xref:System.Collections.SortedList> class returns <xref:System.Collections.DictionaryEntry> objects when enumerated, although the two generic types return <xref:System.Collections.Generic.KeyValuePair%602> objects.  
  
-   Elements are sorted according to a <xref:System.Collections.IComparer?displayProperty=nameWithType> implementation (for nongeneric <xref:System.Collections.SortedList>) or a <xref:System.Collections.Generic.IComparer%601?displayProperty=nameWithType> implementation (for the two generic classes).  
  
-   Each class provides properties that return collections containing only the keys or only the values.  
  
 The following table lists some of the differences between the two sorted list classes and the <xref:System.Collections.Generic.SortedDictionary%602> class.  
  
|<xref:System.Collections.SortedList> nongeneric class and <xref:System.Collections.Generic.SortedList%602> generic class|<xref:System.Collections.Generic.SortedDictionary%602> generic class|  
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|The properties that return keys and values are indexed, allowing efficient indexed retrieval.|No indexed retrieval.|  
|Retrieval is O(log `n`).|Retrieval is O(log `n`).|  
|Insertion and removal are generally O(`n`); however, insertion is O(log `n`) for data that are already in sort order, so that each element is added to the end of the list. (This assumes that a resize is not required.)|Insertion and removal are O(log `n`).|  
|Uses less memory than a <xref:System.Collections.Generic.SortedDictionary%602>.|Uses more memory than the <xref:System.Collections.SortedList> nongeneric class and the <xref:System.Collections.Generic.SortedList%602> generic class.|  
  
 For sorted lists or dictionaries that must be accessible concurrently from multiple threads, you can add sorting logic to a class that derives from <xref:System.Collections.Concurrent.ConcurrentDictionary%602>.  
  
> [!NOTE]
>  For values that contain their own keys (for example, employee records that contain an employee ID number), you can create a keyed collection that has some characteristics of a list and some characteristics of a dictionary by deriving from the <xref:System.Collections.ObjectModel.KeyedCollection%602> generic class.  
  
 Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the <xref:System.Collections.Generic.SortedSet%601> class provides a self-balancing tree that maintains data in sorted order after insertions, deletions, and searches. This class and the <xref:System.Collections.Generic.HashSet%601> class implement the <xref:System.Collections.Generic.ISet%601> interface.  
  
## See Also  
 <xref:System.Collections.IDictionary?displayProperty=nameWithType>  
 <xref:System.Collections.Generic.IDictionary%602?displayProperty=nameWithType>  
 <xref:System.Collections.Concurrent.ConcurrentDictionary%602>  
 [Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md)
