---
title: "Collections and Data Structures"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
helpviewer_keywords: 
  - "grouping data in collections"
  - "objects [.NET Framework], grouping in collections"
  - "Array class, grouping data in collections"
  - "threading [.NET Framework], safety"
  - "Collections classes"
  - "collections [.NET Framework]"
ms.assetid: 60cc581f-1db5-445b-ba04-a173396bf872
caps.latest.revision: 36
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Collections and Data Structures
Similar data can often be handled more efficiently when stored and manipulated as a collection. You can use the <xref:System.Array?displayProperty=nameWithType> class or the classes in the <xref:System.Collections>, <xref:System.Collections.Generic>, <xref:System.Collections.Concurrent>, System.Collections.Immutable namespaces to add, remove, and modify either individual elements or a range of elements in a collection.  
  
 There are two main types of collections; generic collections and non-generic collections. Generic collections were added in the .NET Framework 2.0 and provide collections that are type-safe at compile time. Because of this, generic collections typically offer better performance. Generic collections accept a type parameter when they are constructed and do not require that you cast to and from the <xref:System.Object> type when you add or remove items from the collection.  In addition, most generic collections are supported in [!INCLUDE[win8_appstore_long](../../../includes/win8-appstore-long-md.md)] apps. Non-generic collections store items as <xref:System.Object>, require casting, and most are not supported for [!INCLUDE[win8_appstore_long](../../../includes/win8-appstore-long-md.md)] app development. However, you may see non-generic collections in older code.  
  
 Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the collections in the <xref:System.Collections.Concurrent> namespace provide efficient thread-safe operations for accessing collection items from multiple threads. The immutable collection classes in the System.Collections.Immutable namespace ([NuGet package](https://www.nuget.org/packages/System.Collections.Immutable)) are inherently thread-safe because operations are performed on a copy of the original collection and the original collection cannot be modified.  
  
  
<a name="BKMK_Commoncollectionfeatures"></a>   
## Common collection features  
 All collections provide methods for adding, removing or finding items in the collection. In addition, all collections that directly or indirectly implement the <xref:System.Collections.ICollection> interface or the <xref:System.Collections.Generic.ICollection%601> interface share these features:  
  
-   **The ability to enumerate the collection**  
  
     .NET Framework collections either implement <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> to enable the collection to be iterated through. An enumerator can be thought of as a movable pointer to any element in the collection. The [foreach, in](~/docs/csharp/language-reference/keywords/foreach-in.md) statement  and the [For Each...Next Statement](~/docs/visual-basic/language-reference/statements/for-each-next-statement.md) use the enumerator exposed by the <xref:System.Collections.IEnumerable.GetEnumerator%2A> method and hide the complexity of manipulating the enumerator. In addition, any collection that implements <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> is considered a *queryable type* and can be queried with LINQ. LINQ queries provide a common pattern for accessing data. They are typically more concise and readable than standard `foreach` loops, and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance. For more information, see [LINQ to Objects](https://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9), [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md) and [Introduction to LINQ Queries (C#)](~/docs/csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
-   **The ability to copy the collection contents to an array**  
  
     All collections can be copied to an array using the **CopyTo** method; however, the order of the elements in the new array is based on the sequence in which the enumerator returns them. The resulting array is always one-dimensional with a lower bound of zero.  
  
 In addition, many collection classes contain the following features:  
  
-   **Capacity and Count properties**  
  
     The capacity of a collection is the number of elements it can contain. The count of a collection is the number of elements it actually contains. Some collections hide the capacity or the count or both.  
  
     Most collections automatically expand in capacity when the current capacity is reached. The memory is reallocated, and the elements are copied from the old collection to the new one. This reduces the code required to use the collection; however, the performance of the collection might be negatively affected. For example, for <xref:System.Collections.Generic.List%601>, If <xref:System.Collections.Generic.List%601.Count%2A> is less than <xref:System.Collections.Generic.List%601.Capacity%2A>, adding an item is an O(1) operation. If the capacity needs to be increased to accommodate the new element, adding an item becomes an O(n) operation, where n is <xref:System.Collections.Generic.List%601.Count%2A>. The best way to avoid poor performance caused by multiple reallocations is to set the initial capacity to be the estimated size of the collection.  
  
     A <xref:System.Collections.BitArray> is a special case; its capacity is the same as its length, which is the same as its count.  
  
-   **A consistent lower bound**  
  
     The lower bound of a collection is the index of its first element. All indexed collections in the <xref:System.Collections> namespaces have a lower bound of zero, meaning they are 0-indexed. <xref:System.Array> has a lower bound of zero by default, but a different lower bound can be defined when creating an instance of the **Array** class using <xref:System.Array.CreateInstance%2A?displayProperty=nameWithType>.  
  
-   **Synchronization for access from multiple threads** (<xref:System.Collections> classes only).  
  
     Non-generic collection types in the <xref:System.Collections> namespace provide some thread safety with synchronization; typically exposed through the <xref:System.Collections.ICollection.SyncRoot%2A> and  <xref:System.Collections.ICollection.IsSynchronized%2A> members. These collections are not thread-safe by default. If you require scalable and efficient multi-threaded access to a collection, use one of the classes in the <xref:System.Collections.Concurrent> namespace or consider using an immutable collection. For more information, see [Thread-Safe Collections](../../../docs/standard/collections/thread-safe/index.md).  
  
<a name="BKMK_Choosingacollection"></a>   
## Choosing a collection  
 In general, you should use generic collections. The following table describes some common collection scenarios and the collection classes you can use for those scenarios. If you are new to generic collections, this table will help you choose the generic collection that works the best for your task.  
|I want to…|Generic collection options|Non-generic collection options|Thread-safe or immutable collection options|  
|-|-|-|-|  
|Store items as key/value pairs for quick look-up by key|<xref:System.Collections.Generic.Dictionary%602>|<xref:System.Collections.Hashtable><br /><br /> (A collection of key/value pairs that are organize based on the hash code of the key.)|<xref:System.Collections.Concurrent.ConcurrentDictionary%602><br /><br /> <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602><br /><br /> <xref:System.Collections.Immutable.ImmutableDictionary%602>|  
|Access items by index|<xref:System.Collections.Generic.List%601>|<xref:System.Array><br /><br /> <xref:System.Collections.ArrayList>|<xref:System.Collections.Immutable.ImmutableList%601><br /><br /> <xref:System.Collections.Immutable.ImmutableArray>|  
|Use items first-in-first-out (FIFO)|<xref:System.Collections.Generic.Queue%601>|<xref:System.Collections.Queue>|<xref:System.Collections.Concurrent.ConcurrentQueue%601><br /><br /> <xref:System.Collections.Immutable.ImmutableQueue%601>|  
|Use data Last-In-First-Out (LIFO)|<xref:System.Collections.Generic.Stack%601>|<xref:System.Collections.Stack>|<xref:System.Collections.Concurrent.ConcurrentStack%601><br /><br /> <xref:System.Collections.Immutable.ImmutableStack%601>|  
|Access items sequentially|<xref:System.Collections.Generic.LinkedList%601>|No recommendation|No recommendation|  
|Receive notifications when items are removed or added to the collection. (implements <xref:System.ComponentModel.INotifyPropertyChanged> and <xref:System.Collections.Specialized.INotifyCollectionChanged>)|<xref:System.Collections.ObjectModel.ObservableCollection%601>|No recommendation|No recommendation|  
|A sorted collection|<xref:System.Collections.Generic.SortedList%602>|<xref:System.Collections.SortedList>|<xref:System.Collections.Immutable.ImmutableSortedDictionary%602><br /><br /> <xref:System.Collections.Immutable.ImmutableSortedSet%601>|  
|A set for mathematical functions|<xref:System.Collections.Generic.HashSet%601><br /><br /> <xref:System.Collections.Generic.SortedSet%601>|No recommendation|<xref:System.Collections.Immutable.ImmutableHashSet%601><br /><br /> <xref:System.Collections.Immutable.ImmutableSortedSet%601>|  
  
<a name="BKMK_RelatedTopics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Selecting a Collection Class](../../../docs/standard/collections/selecting-a-collection-class.md)|Describes the different collections and helps you select one for your scenario.|  
|[Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md)|Describes commonly used generic and nongeneric collection types such as <xref:System.Array?displayProperty=nameWithType>, <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>, and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.|  
|[When to Use Generic Collections](../../../docs/standard/collections/when-to-use-generic-collections.md)|Discusses the use of generic collection types.|  
|[Comparisons and Sorts Within Collections](../../../docs/standard/collections/comparisons-and-sorts-within-collections.md)|Discusses the use of equality comparisons and sorting comparisons in collections.|  
|[Sorted Collection Types](../../../docs/standard/collections/sorted-collection-types.md)|Describes sorted collections performance and characteristics|  
|[Hashtable and Dictionary Collection Types](../../../docs/standard/collections/hashtable-and-dictionary-collection-types.md)|Describes the features of generic and non-generic hash-based dictionary types.|  
|[Thread-Safe Collections](../../../docs/standard/collections/thread-safe/index.md)|Describes collection types such as <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> and <xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType> that support safe and efficient concurrent access from multiple threads.|  
|System.Collections.Immutable|Introduces the immutable collections and provides links to the collection types.|  
  
<a name="BKMK_Reference"></a>   
## Reference  
 <xref:System.Array?displayProperty=nameWithType>  
 <xref:System.Collections?displayProperty=nameWithType>  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>  
 <xref:System.Collections.Generic?displayProperty=nameWithType>  
 <xref:System.Collections.Specialized?displayProperty=nameWithType>  
 <xref:System.Linq?displayProperty=nameWithType>  
 <xref:System.Collections.Immutable>
