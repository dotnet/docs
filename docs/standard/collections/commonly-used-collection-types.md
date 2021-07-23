---
title: "Commonly Used Collection Types"
description: Learn about commonly used collection types in .NET, such as hash tables, queues, stacks, bags, dictionaries, and lists.
ms.date: "06/09/2021"
helpviewer_keywords: 
  - "collections [.NET], generic"
  - "objects [.NET], grouping in collections"
  - "generics [.NET], collections"
  - "IList interface, grouping data in collections"
  - "IDictionary interface, grouping data in collections"
  - "grouping data in collections, generic collection types"
  - "Collections classes"
  - "generic collections"
ms.assetid: f5d4c6a4-0d7b-4944-a9fb-3b12d9ebfd55
---
# Commonly used collection types

Collection types represent different ways to collect data, such as hash tables, queues, stacks, bags, dictionaries, and lists.

All collections are based on the <xref:System.Collections.ICollection> or <xref:System.Collections.Generic.ICollection%601> interfaces, either directly or indirectly. <xref:System.Collections.IList> and <xref:System.Collections.IDictionary> and their generic counterparts all derive from these two interfaces.

In collections based on <xref:System.Collections.IList> or directly on <xref:System.Collections.ICollection>, every element contains only a value. These types include:

- <xref:System.Array>
- <xref:System.Collections.ArrayList>
- <xref:System.Collections.Generic.List%601>
- <xref:System.Collections.Queue>
- <xref:System.Collections.Concurrent.ConcurrentQueue%601>
- <xref:System.Collections.Stack>
- <xref:System.Collections.Concurrent.ConcurrentStack%601>
- <xref:System.Collections.Generic.LinkedList%601>

In collections based on the <xref:System.Collections.IDictionary> interface, every element contains both a key and a value. These types include:

- <xref:System.Collections.Hashtable>
- <xref:System.Collections.SortedList>
- <xref:System.Collections.Generic.SortedList%602>
- <xref:System.Collections.Generic.Dictionary%602>
- <xref:System.Collections.Concurrent.ConcurrentDictionary%602>

The <xref:System.Collections.ObjectModel.KeyedCollection%602> class is unique because it is a list of values with keys embedded within the values. As a result, it behaves both like a list and like a dictionary.  

When you need efficient multi-threaded collection access, use the generic collections in the <xref:System.Collections.Concurrent> namespace.

The <xref:System.Collections.Queue> and <xref:System.Collections.Generic.Queue%601> classes provide first-in-first-out lists. The <xref:System.Collections.Stack> and <xref:System.Collections.Generic.Stack%601> classes provide last-in-first-out lists.

## Strong typing

Generic collections are the best solution to strong typing. For example, adding an element of any type other than an <xref:System.Int32> to a `List<Int32>` collection causes a compile-time error. However, if your language does not support generics, the <xref:System.Collections> namespace includes abstract base classes that you can extend to create collection classes that are strongly typed. These base classes include:

- <xref:System.Collections.CollectionBase>
- <xref:System.Collections.ReadOnlyCollectionBase>
- <xref:System.Collections.DictionaryBase>

## How collections vary
  
Collections vary in how they store, sort, and compare elements, and how they perform searches.

The <xref:System.Collections.SortedList> class and the <xref:System.Collections.Generic.SortedList%602> generic class provide sorted versions of the <xref:System.Collections.Hashtable> class and the <xref:System.Collections.Generic.Dictionary%602> generic class.

All collections use zero-based indexes except <xref:System.Array>, which allows arrays that are not zero-based.

You can access the elements of a <xref:System.Collections.SortedList> or a <xref:System.Collections.ObjectModel.KeyedCollection%602> by either the key or the element's index. You can only access the elements of a <xref:System.Collections.Hashtable> or a <xref:System.Collections.Generic.Dictionary%602> by the element's key.

## Use LINQ with collection types
  
The LINQ to Objects feature provides a common pattern for accessing in-memory objects of any type that implements <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601>. LINQ queries have several benefits over standard constructs like `foreach` loops:

- They are concise and easier to understand.
- They can filter, order, and group data.
- They can improve performance.
  
For more information, see [LINQ to Objects (C#)](../../csharp/programming-guide/concepts/linq/linq-to-objects.md), [LINQ to Objects (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/linq-to-objects.md), and [Parallel LINQ (PLINQ)](../parallel-programming/introduction-to-plinq.md).  
  
## Related topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Collections and Data Structures](index.md)|Discusses the various collection types available in .NET, including stacks, queues, lists, arrays, and dictionaries.|  
|[Hashtable and Dictionary Collection Types](hashtable-and-dictionary-collection-types.md)|Describes the features of generic and nongeneric hash-based dictionary types.|  
|[Sorted Collection Types](sorted-collection-types.md)|Describes classes that provide sorting functionality for lists and sets.|  
|[Generics](../generics/index.md)|Describes the generics feature, including the generic collections, delegates, and interfaces provided by .NET. Provides links to feature documentation for C#, Visual Basic, and Visual C++, and to supporting technologies such as reflection.|  
  
## Reference  

 <xref:System.Collections?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic?displayProperty=nameWithType>  
  
 <xref:System.Collections.ICollection?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.ICollection%601?displayProperty=nameWithType>  
  
 <xref:System.Collections.IList?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.IList%601?displayProperty=nameWithType>  
  
 <xref:System.Collections.IDictionary?displayProperty=nameWithType>  
  
 <xref:System.Collections.Generic.IDictionary%602?displayProperty=nameWithType>
