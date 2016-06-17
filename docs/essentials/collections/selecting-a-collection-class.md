# Selecting a Collection Class

Be sure to choose your collection class carefully. Using the wrong type can restrict your use of the collection. The generic and concurrent versions of the collections are to be preferred because of their greater type safety and other improvements. In general, avoid using the types in the System.Collections namespace unless you are specifically targeting .NET Framework version 1.1. 

Consider the following questions:

* Do you need a sequential list where the element is typically discarded after its value is retrieved? 

    * If yes, consider using the [System.Collections.Generic.Queue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) generic class if you need first-in, first-out (FIFO) behavior. Consider using the [System.Collections.Generic.Stack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) generic class if you need last-in, first-out (LIFO) behavior. For safe access from multiple threads, use the concurrent versions [System.Collections.Concurrent.ConcurrentQueue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) and [System.Collections.Concurrent.ConcurrentStack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html).
    
    * If not, consider using the other collections.
    
* Do you need to access the elements in a certain order, such as FIFO, LIFO, or random?

    * The [System.Collections.Generic.Queue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) or [System.Collections.Concurrent.ConcurrentQueue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) generic class offer FIFO access. For more information, see [When to Use a Thread-Safe Collection](threadsafe/when-to-use-a-thread-safe-collection.md).
    
    * The [System.Collections.Generic.Stack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) or[System.Collections.Concurrent.ConcurrentStack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html) generic class offer LIFO access. For more information, see [When to Use a Thread-Safe Collection](threadsafe/when-to-use-a-thread-safe-collection.md).
    
    * The [System.Collections.Generic.LinkedList&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.LinkedList%601.html) generic class allows sequential access either from the head to the tail, or from the tail to the head.
    
* Do you need to access each element by index? 

    * The [System.Collections.Specialized.StringCollection](http://dotnet.github.io/api/System.Collections.Specialized.StringCollection.html) class and the [System.Collections.Generic.List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html) generic class offer access to their elements by the zero-based index of the element. 
    
    * The [System.Collections.Specialized.ListDictionary](http://dotnet.github.io/api/System.Collections.Specialized.ListDictionary.html) and [System.Collections.Specialized.StringDictionary](http://dotnet.github.io/api/System.Collections.Specialized.StringDictionary.html) classes, and the [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) and [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) generic classes offer access to their elements by the key of the element.
    
    * The [System.Collections.Specialized.NameObjectCollectionBase](http://dotnet.github.io/api/System.Collections.Specialized.NameObjectCollectionBase.html) and [System.Collections.Specialized.NameValueCollection](http://dotnet.github.io/api/System.Collections.Specialized.NameValueCollection.html) classes, and the [System.Collections.ObjectModel.KeyedCollection&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) and [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes offer access to their elements by either the zero-based index or the key of the element.
    
* Will each element contain one value, a combination of one key and one value, or a combination of one key and multiple values? 

    * One value: Use any of the collections based on the [System.Collections.Generic.IList&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IList%601.html) generic interface.
    
    * One key and one value: Use any of the collections based on the [System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html) generic interface.
    
    * One value with embedded key: Use the [System.Collections.ObjectModel.KeyedCollection&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) generic class.
    
    * One key and multiple values: Use the [System.Collections.Specialized.NameValueCollection](http://dotnet.github.io/api/System.Collections.Specialized.NameValueCollection.html) class.
    
* Do you need to sort the elements differently from how they were entered? 

    * The [System.Collections.Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html) class sorts its elements by their hash codes.
    
    * The [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) and [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes sort their elements by the key, based on implementations of the [System.Collections.IComparer](http://dotnet.github.io/api/System.Collections.IComparer.html) interface and the [System.Collections.Generic.IComparer&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IComparer%601.html) generic interface.
    
    * [System.Collections.Generic.List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html) generic class, provides a `Sort` method that takes an implementation of the `IComparer<T>` generic interface as a parameter.
    
* Do you need collections that accept only strings? 

    * [StringCollection](http://dotnet.github.io/api/System.Collections.Specialized.StringCollection.html) (based on [System.Collections.IList](http://dotnet.github.io/api/System.Collections.IList.html)) and [StringDictionary](http://dotnet.github.io/api/System.Collections.Specialized.StringDictionary.html) (based on [System.Collections.IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html)) are in the [System.Collections.Specialized](http://dotnet.github.io/api/System.Collections.Specialized.html) namespace. 
    
    * In addition, you can use any of the generic collection classes in the [System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html) namespace as strongly typed string collections by specifying the `String` class for their generic type arguments.
    
## LINQ to Objects

LINQ to Objects enables developers to use LINQ queries to access in-memory objects as long as the object type implements [System.Collections.IEnumerable](http://dotnet.github.io/api/System.Collections.IEnumerable.html) or [System.Collections.Generic.IEnumerable&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IEnumerable%601.html). LINQ queries provide a common pattern for accessing data, are typically more concise and readable than standard foreach loops, and provide filtering, ordering, and grouping capabilities. For more information, see [Language Integrated Query (LINQ)](../../languages/csharp/linq.md).

## See Also

[System.Collections](http://dotnet.github.io/api/System.Collections.html)

[System.Collections.Specialized](http://dotnet.github.io/api/System.Collections.Specialized.html)

[System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html)

[Thread-Safe Collections](thread-safe-collections.md)
