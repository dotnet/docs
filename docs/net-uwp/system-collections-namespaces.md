---
title: "System.Collections namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d97ad2aa-c360-4056-856f-19b8134e547c
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# System.Collections namespaces1
`System.Collections` and its child namespaces (`System.Collections.Concurrent`, `System.Collections.Generic`, `System.Collections.ObjectModel`, and `System.Collections.Specialized`) contain types that define various standard, specialized, and generic collection objects.  
  
 This topic displays the types in the `System.Collections` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Collections namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Collections.BitArray>|Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0).|  
|<xref:System.Collections.DictionaryEntry>|Defines a dictionary key/value pair that can be set or retrieved.|  
|<xref:System.Collections.ICollection>|Defines size, enumerators, and synchronization methods for all nongeneric collections.|  
|<xref:System.Collections.IComparer>|Exposes a method that compares two objects.|  
|<xref:System.Collections.IDictionary>|Represents a nongeneric collection of key/value pairs.|  
|<xref:System.Collections.IDictionaryEnumerator>|Enumerates the elements of a nongeneric dictionary.|  
|<xref:System.Collections.IEnumerable>|Exposes the enumerator, which supports a simple iteration over a non-generic collection.|  
|<xref:System.Collections.IEnumerator>|Supports a simple iteration over a nongeneric collection.|  
|<xref:System.Collections.IEqualityComparer>|Defines methods to support the comparison of objects for equality.|  
|<xref:System.Collections.IList>|Represents a non-generic collection of objects that can be individually accessed by index.|  
|<xref:System.Collections.IStructuralComparable>|Supports the structural comparison of collection objects.|  
|<xref:System.Collections.IStructuralEquatable>|Defines methods to support the comparison of objects for structural equality.|  
|<xref:System.Collections.StructuralComparisons>|Provides objects for performing a structural comparison of two collection objects.|  
  
## System.Collections.Concurrent namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Collections.Concurrent.BlockingCollection%601>|Provides blocking and bounding capabilities for thread-safe collections that implement IProducerConsumerCollection<T\>.|  
|<xref:System.Collections.Concurrent.ConcurrentBag%601>|Represents a thread-safe, unordered collection of objects.|  
|<xref:System.Collections.Concurrent.ConcurrentDictionary%602>|Represents a thread-safe collection of key-value pairs that can be accessed by multiple threads concurrently.|  
|<xref:System.Collections.Concurrent.ConcurrentQueue%601>|Represents a thread-safe first in-first out (FIFO) collection.|  
|<xref:System.Collections.Concurrent.ConcurrentStack%601>|Represents a thread-safe last in-first out (LIFO) collection.|  
|<xref:System.Collections.Concurrent.EnumerablePartitionerOptions>|Out-of-the-box partitioners are created with a set of default behaviors. For example, by default, some form of buffering and chunking will be employed to achieve optimal performance in the common scenario where an IEnumerable<T\> implementation is fast and non-blocking. These behaviors can be overridden using this enumeration.|  
|<xref:System.Collections.Concurrent.IProducerConsumerCollection%601>|Defines methods to manipulate thread-safe collections intended for producer/consumer usage. This interface provides a unified representation for producer/consumer collections so that higher level abstractions such as BlockingCollection\<T> can use the collection as the underlying storage mechanism.|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601>|Represents a particular manner of splitting an orderable data source into multiple partitions.|  
|<xref:System.Collections.Concurrent.Partitioner>|Provides common partitioning strategies for arrays, lists, and enumerables.|  
|<xref:System.Collections.Concurrent.Partitioner%601>|Represents a particular manner of splitting a data source into multiple partitions.|  
  
## System.Collections.Generic namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Collections.Generic.Comparer%601>|Provides a base class for implementations of the IComparer<T\> generic interface.|  
|<xref:System.Collections.Generic.Dictionary%602>|Represents a collection of keys and values.|  
|<xref:System.Collections.Generic.Dictionary%602.Enumerator>|Enumerates the elements of a Dictionary<TKey, TValue>.|  
|<xref:System.Collections.Generic.Dictionary%602.KeyCollection>|Represents the collection of keys in a Dictionary\<TKey, TValue>. This class cannot be inherited.|  
|<xref:System.Collections.Generic.Dictionary%602.KeyCollection.Enumerator>|Enumerates the elements of a Dictionary<TKey, TValue>.KeyCollection.|  
|<xref:System.Collections.Generic.Dictionary%602.ValueCollection>|Represents the collection of values in a Dictionary\<TKey, TValue>. This class cannot be inherited.|  
|<xref:System.Collections.Generic.Dictionary%602.ValueCollection.Enumerator>|Enumerates the elements of a Dictionary<TKey, TValue>.ValueCollection.|  
|<xref:System.Collections.Generic.EqualityComparer%601>|Provides a base class for implementations of the IEqualityComparer\<T> generic interface.|  
|<xref:System.Collections.Generic.HashSet%601>|Represents a set of values.|  
|<xref:System.Collections.Generic.HashSet%601.Enumerator>|Enumerates the elements of a HashSet\<T> object.|  
|<xref:System.Collections.Generic.ICollection%601>|Defines methods to manipulate generic collections.|  
|<xref:System.Collections.Generic.IComparer%601>|Defines a method that a type implements to compare two objects.|  
|<xref:System.Collections.Generic.IDictionary%602>|Represents a generic collection of key/value pairs.|  
|<xref:System.Collections.Generic.IEnumerable%601>|Exposes the enumerator, which supports a simple iteration over a collection of a specified type.|  
|<xref:System.Collections.Generic.IEnumerator%601>|Supports a simple iteration over a generic collection.|  
|<xref:System.Collections.Generic.IEqualityComparer%601>|Defines methods to support the comparison of objects for equality.|  
|<xref:System.Collections.Generic.IList%601>|Represents a collection of objects that can be individually accessed by index.|  
|<xref:System.Collections.Generic.IReadOnlyCollection%601>|Represents a strongly-typed, read-only collection of elements.|  
|<xref:System.Collections.Generic.IReadOnlyDictionary%602>|Represents a generic read-only collection of key/value pairs.|  
|<xref:System.Collections.Generic.IReadOnlyList%601>|Represents a read-only collection of elements that can be accessed by index.|  
|<xref:System.Collections.Generic.ISet%601>|Provides the base interface for the abstraction of sets.|  
|<xref:System.Collections.Generic.KeyNotFoundException>|The exception that is thrown when the key specified for accessing an element in a collection does not match any key in the collection.|  
|<xref:System.Collections.Generic.KeyValuePair%602>|Defines a key/value pair that can be set or retrieved.|  
|<xref:System.Collections.Generic.LinkedList%601>|Represents a doubly linked list.|  
|<xref:System.Collections.Generic.LinkedList%601.Enumerator>|Enumerates the elements of a LinkedList\<T>.|  
|<xref:System.Collections.Generic.LinkedListNode%601>|Represents a node in a LinkedList<T\>. This class cannot be inherited.|  
|<xref:System.Collections.Generic.List%601>|Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.|  
|<xref:System.Collections.Generic.List%601.Enumerator>|Enumerates the elements of a List<T\>.|  
|<xref:System.Collections.Generic.Queue%601>|Represents a first-in, first-out collection of objects.|  
|<xref:System.Collections.Generic.Queue%601.Enumerator>|Enumerates the elements of a Queue<T\>.|  
|<xref:System.Collections.Generic.SortedDictionary%602>|Represents a collection of key/value pairs that are sorted on the key.|  
|<xref:System.Collections.Generic.SortedDictionary%602.Enumerator>|Enumerates the elements of a SortedDictionary<TKey, TValue>.|  
|<xref:System.Collections.Generic.SortedDictionary%602.KeyCollection>|Represents the collection of keys in a SortedDictionary\<TKey, TValue>. This class cannot be inherited.|  
|<xref:System.Collections.Generic.SortedDictionary%602.KeyCollection.Enumerator>|Enumerates the elements of a SortedDictionary<TKey, TValue>.KeyCollection.|  
|<xref:System.Collections.Generic.SortedDictionary%602.ValueCollection>|Represents the collection of values in a SortedDictionary\<TKey, TValue>. This class cannot be inherited|  
|<xref:System.Collections.Generic.SortedDictionary%602.ValueCollection.Enumerator>|Enumerates the elements of a SortedDictionary<TKey, TValue>.ValueCollection.|  
|<xref:System.Collections.Generic.SortedSet%601>|Represents a collection of objects that is maintained in sorted order.|  
|<xref:System.Collections.Generic.SortedSet%601.Enumerator>|Enumerates the elements of a SortedSet<T\> object.|  
|<xref:System.Collections.Generic.Stack%601>|Represents a variable size last-in-first-out (LIFO) collection of instances of the same arbitrary type.|  
|<xref:System.Collections.Generic.Stack%601.Enumerator>|Enumerates the elements of a Stack<T\>.|  
  
## System.Collections.ObjectModel namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Collections.ObjectModel.Collection%601>|Provides the base class for a generic collection.|  
|<xref:System.Collections.ObjectModel.KeyedCollection%602>|Provides the abstract base class for a collection whose keys are embedded in the values.|  
|<xref:System.Collections.ObjectModel.ObservableCollection%601>|Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed.|  
|<xref:System.Collections.ObjectModel.ReadOnlyCollection%601>|Provides the base class for a generic read-only collection.|  
|<xref:System.Collections.ObjectModel.ReadOnlyDictionary%602>|Represents a read-only, generic collection of key/value pairs.|  
|<xref:System.Collections.ObjectModel.ReadOnlyDictionary%602.KeyCollection>|Represents a read-only collection of the keys of a ReadOnlyDictionary<TKey, TValue> object.|  
|<xref:System.Collections.ObjectModel.ReadOnlyDictionary%602.ValueCollection>|Represents a read-only collection of the values of a ReadOnlyDictionary\<TKey, TValue> object.|  
|<xref:System.Collections.ObjectModel.ReadOnlyObservableCollection%601>|Represents a read-only ObservableCollection\<T>.|  
  
## System.Collections.Specialized namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Collections.Specialized.INotifyCollectionChanged>|Notifies listeners of dynamic changes, such as when items get added and removed or the whole list is refreshed.|  
|<xref:System.Collections.Specialized.NotifyCollectionChangedAction>|Describes the action that caused a CollectionChanged event.|  
|<xref:System.Collections.Specialized.NotifyCollectionChangedEventArgs>|Provides data for the CollectionChanged event.|  
|<xref:System.Collections.Specialized.NotifyCollectionChangedEventHandler>|Represents the method that handles the CollectionChanged event.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)