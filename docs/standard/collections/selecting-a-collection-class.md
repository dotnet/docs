---
title: Selecting a Collection Class
description: Selecting a Collection Class
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 0a60fca7-e082-48d4-9dda-30b0d3e67ec7
---

# Selecting a Collection Class

Be sure to choose your collection class carefully. Using the wrong type can restrict your use of the collection. The generic and concurrent versions of the collections are to be preferred because of their greater type safety and other improvements. In general, avoid using the types in the System.Collections namespace unless you are specifically targeting .NET Framework version 1.1. 

Consider the following questions:

* Do you need a sequential list where the element is typically discarded after its value is retrieved? 

    * If yes, consider using the [System.Collections.Generic.Queue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue-1) generic class if you need first-in, first-out (FIFO) behavior. Consider using the [System.Collections.Generic.Stack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack-1) generic class if you need last-in, first-out (LIFO) behavior. For safe access from multiple threads, use the concurrent versions [System.Collections.Concurrent.ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1) and [System.Collections.Concurrent.ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1).
    
    * If not, consider using the other collections.
    
* Do you need to access the elements in a certain order, such as FIFO, LIFO, or random?

    * The [System.Collections.Generic.Queue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue-1) or [System.Collections.Concurrent.ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1) generic class offer FIFO access. For more information, see [When to Use a Thread-Safe Collection](threadsafe/when-to-use-a-thread-safe-collection.md).
    
    * The [System.Collections.Generic.Stack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack-1) or[System.Collections.Concurrent.ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1) generic class offer LIFO access. For more information, see [When to Use a Thread-Safe Collection](threadsafe/when-to-use-a-thread-safe-collection.md).
    
    * The [System.Collections.Generic.LinkedList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.LinkedList-1) generic class allows sequential access either from the head to the tail, or from the tail to the head.
    
* Do you need to access each element by index? 

    * The [System.Collections.Specialized.StringCollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.StringCollection) class and the [System.Collections.Generic.List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) generic class offer access to their elements by the zero-based index of the element. 
    
    * The [System.Collections.Specialized.ListDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.ListDictionary) and [System.Collections.Specialized.StringDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.StringDictionary) classes, and the [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) and [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) generic classes offer access to their elements by the key of the element.
    
    * The [System.Collections.Specialized.NameObjectCollectionBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.NameObjectCollectionBase) and [System.Collections.Specialized.NameValueCollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.NameValueCollection) classes, and the [System.Collections.ObjectModel.KeyedCollection&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) and [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic classes offer access to their elements by either the zero-based index or the key of the element.
    
* Will each element contain one value, a combination of one key and one value, or a combination of one key and multiple values? 

    * One value: Use any of the collections based on the [System.Collections.Generic.IList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IList-1) generic interface.
    
    * One key and one value: Use any of the collections based on the [System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2) generic interface.
    
    * One value with embedded key: Use the [System.Collections.ObjectModel.KeyedCollection&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) generic class.
    
    * One key and multiple values: Use the [System.Collections.Specialized.NameValueCollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.NameValueCollection) class.
    
* Do you need to sort the elements differently from how they were entered? 

    * The [System.Collections.Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) class sorts its elements by their hash codes.
    
    * The [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) and [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic classes sort their elements by the key, based on implementations of the [System.Collections.IComparer](https://docs.microsoft.com/dotnet/core/api/System.Collections.IComparer) interface and the [System.Collections.Generic.IComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IComparer-1) generic interface.
    
    * [System.Collections.Generic.List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) generic class, provides a `Sort` method that takes an implementation of the `IComparer<T>` generic interface as a parameter.
    
* Do you need collections that accept only strings? 

    * [StringCollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.StringCollection) (based on [System.Collections.IList](https://docs.microsoft.com/dotnet/core/api/System.Collections.IList)) and [StringDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.StringDictionary) (based on [System.Collections.IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary)) are in the [System.Collections.Specialized](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized) namespace. 
    
    * In addition, you can use any of the generic collection classes in the [System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic) namespace as strongly typed string collections by specifying the `String` class for their generic type arguments.
    
## LINQ to Objects

LINQ to Objects enables developers to use LINQ queries to access in-memory objects as long as the object type implements [System.Collections.IEnumerable](https://docs.microsoft.com/dotnet/core/api/System.Collections.IEnumerable) or [System.Collections.Generic.IEnumerable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable-1). LINQ queries provide a common pattern for accessing data, are typically more concise and readable than standard foreach loops, and provide filtering, ordering, and grouping capabilities. For more information, see [Language Integrated Query (LINQ)](../../csharp/linq/index.md).

## See Also

[System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections)

[System.Collections.Specialized](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized)

[System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic)

[Thread-Safe Collections](threadsafe/index.md)
