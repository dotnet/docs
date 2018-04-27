---
title: "Selecting a Collection Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "last-in-first-out collections"
  - "first-in-first-out collections"
  - "collections [.NET Framework], selecting collection class"
  - "indexed collections"
  - "Collections classes"
  - "grouping data in collections, selecting collection class"
ms.assetid: ba049f9a-ce87-4cc4-b319-3f75c8ddac8a
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Selecting a Collection Class
Be sure to choose your collection class carefully. Using the wrong type can restrict your use of the collection. In general, avoid using the types in the <xref:System.Collections> namespace unless you are specifically targeting .NET Framework version 1.1. The generic and concurrent versions of the collections are to be preferred because of their greater type safety and other improvements.  
  
 Consider the following questions:  
  
-   Do you need a sequential list where the element is typically discarded after its value is retrieved?  
  
    -   If yes, consider using the <xref:System.Collections.Queue> class or the <xref:System.Collections.Generic.Queue%601> generic class if you need first-in, first-out (FIFO) behavior. Consider using the <xref:System.Collections.Stack> class or the <xref:System.Collections.Generic.Stack%601> generic class if you need last-in, first-out (LIFO) behavior. For safe access from multiple threads, use the concurrent versions <xref:System.Collections.Concurrent.ConcurrentQueue%601> and <xref:System.Collections.Concurrent.ConcurrentStack%601>.  
  
    -   If not, consider using the other collections.  
  
-   Do you need to access the elements in a certain order, such as FIFO, LIFO, or random?  
  
    -   The <xref:System.Collections.Queue> class and the <xref:System.Collections.Generic.Queue%601> or <xref:System.Collections.Concurrent.ConcurrentQueue%601> generic class offer FIFO access. For more information, see [When to Use a Thread-Safe Collection](../../../docs/standard/collections/thread-safe/when-to-use-a-thread-safe-collection.md).  
  
    -   The <xref:System.Collections.Stack> class and the <xref:System.Collections.Generic.Stack%601> or <xref:System.Collections.Concurrent.ConcurrentStack%601> generic class offer LIFO access. For more information, see [When to Use a Thread-Safe Collection](../../../docs/standard/collections/thread-safe/when-to-use-a-thread-safe-collection.md).  
  
    -   The <xref:System.Collections.Generic.LinkedList%601> generic class allows sequential access either from the head to the tail, or from the tail to the head.  
  
-   Do you need to access each element by index?  
  
    -   The <xref:System.Collections.ArrayList> and <xref:System.Collections.Specialized.StringCollection> classes and the <xref:System.Collections.Generic.List%601> generic class offer access to their elements by the zero-based index of the element.  
  
    -   The <xref:System.Collections.Hashtable>, <xref:System.Collections.SortedList>, <xref:System.Collections.Specialized.ListDictionary>, and <xref:System.Collections.Specialized.StringDictionary> classes, and the <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Generic.SortedDictionary%602> generic classes offer access to their elements by the key of the element.  
  
    -   The <xref:System.Collections.Specialized.NameObjectCollectionBase> and <xref:System.Collections.Specialized.NameValueCollection> classes, and the <xref:System.Collections.ObjectModel.KeyedCollection%602> and <xref:System.Collections.Generic.SortedList%602> generic classes offer access to their elements by either the zero-based index or the key of the element.  
  
-   Will each element contain one value, a combination of one key and one value, or a combination of one key and multiple values?  
  
    -   One value: Use any of the collections based on the <xref:System.Collections.IList> interface or the <xref:System.Collections.Generic.IList%601> generic interface.  
  
    -   One key and one value: Use any of the collections based on the <xref:System.Collections.IDictionary> interface or the <xref:System.Collections.Generic.IDictionary%602> generic interface.  
  
    -   One value with embedded key: Use the <xref:System.Collections.ObjectModel.KeyedCollection%602> generic class.  
  
    -   One key and multiple values: Use the <xref:System.Collections.Specialized.NameValueCollection> class.  
  
-   Do you need to sort the elements differently from how they were entered?  
  
    -   The <xref:System.Collections.Hashtable> class sorts its elements by their hash codes.  
  
    -   The <xref:System.Collections.SortedList> class and the <xref:System.Collections.Generic.SortedDictionary%602> and <xref:System.Collections.Generic.SortedList%602> generic classes sort their elements by the key, based on implementations of the <xref:System.Collections.IComparer> interface and the <xref:System.Collections.Generic.IComparer%601> generic interface.  
  
    -   <xref:System.Collections.ArrayList> provides a <xref:System.Collections.ArrayList.Sort%2A> method that takes an <xref:System.Collections.IComparer> implementation as a parameter. Its generic counterpart, the <xref:System.Collections.Generic.List%601> generic class, provides a <xref:System.Collections.Generic.List%601.Sort%2A> method that takes an implementation of the <xref:System.Collections.Generic.IComparer%601> generic interface as a parameter.  
  
-   Do you need fast searches and retrieval of information?  
  
    -   <xref:System.Collections.Specialized.ListDictionary> is faster than <xref:System.Collections.Hashtable> for small collections (10 items or fewer). The <xref:System.Collections.Generic.Dictionary%602> generic class provides faster lookup than the <xref:System.Collections.Generic.SortedDictionary%602> generic class. The multi-threaded implementation is <xref:System.Collections.Concurrent.ConcurrentDictionary%602>. <xref:System.Collections.Concurrent.ConcurrentBag%601> provides fast multi-threaded insertion for unordered data. For more information about both multi-threaded types, see [When to Use a Thread-Safe Collection](../../../docs/standard/collections/thread-safe/when-to-use-a-thread-safe-collection.md).  
  
-   Do you need collections that accept only strings?  
  
    -   <xref:System.Collections.Specialized.StringCollection> (based on <xref:System.Collections.IList>) and <xref:System.Collections.Specialized.StringDictionary> (based on <xref:System.Collections.IDictionary>) are in the <xref:System.Collections.Specialized> namespace.  
  
    -   In addition, you can use any of the generic collection classes in the <xref:System.Collections.Generic> namespace as strongly typed string collections by specifying the <xref:System.String> class for their generic type arguments.  
  
## LINQ to Objects and PLINQ  
 LINQ to Objects enables developers to use LINQ queries to access in-memory objects as long as the object type implements <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601>. LINQ queries provide a common pattern for accessing data, are typically more concise and readable than standard `foreach` loops, and provide filtering, ordering, and grouping capabilities. For more information, see [LINQ to Objects](https://msdn.microsoft.com/library/73cafe73-37cf-46e7-bfa7-97c7eea7ced9).  
  
 PLINQ provides a parallel implementation of LINQ to Objects that can offer faster query execution in many scenarios, through more efficient use of multi-core computers. For more information, see [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md).  
  
## See Also  
 <xref:System.Collections>  
 <xref:System.Collections.Specialized>  
 <xref:System.Collections.Generic>  
 [Thread-Safe Collections](../../../docs/standard/collections/thread-safe/index.md)
