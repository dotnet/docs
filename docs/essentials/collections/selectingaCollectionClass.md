# Selecting a Collection Class

Be sure to choose your collection class carefully. Using the wrong type can restrict your use of the collection. In general, avoid using the types in the [System.Collections](http://dotnet.github.io/api/System.Collections.html) namespace unless you are specifically targeting .NET Framework version 1.1. The generic and concurrent versions of the collections are to be preferred because of their greater type safety and other improvements.

Consider the following questions:

*   Do you need a sequential list where the element is typically discarded after its value is retrieved?

    *   If yes, consider using the [Queue](http://dotnet.github.io/api/System.Collections.Queue.html) class or the [Queue(Of T)](http://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) generic class if you need first-in, first-out (FIFO) behavior. Consider using the [Stack](http://dotnet.github.io/api/System.Collections.Stack.html) class or the [Stack(Of T)](http://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) generic class if you need last-in, first-out (LIFO) behavior. For safe access from multiple threads, use the concurrent versions [ConcurrentQueue(Of T)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) and [ConcurrentStack(Of T)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html).
    
    *   If not, consider using the other collections.
    
*   Do you need to access the elements in a certain order, such as FIFO, LIFO, or random? 

    *   The [Queue](http://dotnet.github.io/api/System.Collections.Queue.html) class and the [Queue(Of T)](http://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) or [ConcurrentQueue(Of T)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) generic class offer FIFO access.
    
    *   The [Stack](http://dotnet.github.io/api/System.Collections.Stack.html) class and the [Stack(Of T)](http://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) or [ConcurrentStack(Of T)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html) generic class offer LIFO access. 
    
    *   The [LinkedList(Of T)](http://dotnet.github.io/api/System.Collections.Generic.LinkedList%601.html) generic class allows sequential access either from the head to the tail, or from the tail to the head.
    
*   Do you need to access each element by index? 

    *   The [ArrayList](http://dotnet.github.io/api/System.Collections.ArrayList.html) and [StringCollection](http://dotnet.github.io/api/System.Collections.Specialized.StringCollection.html) classes and the [List(Of T)](http://dotnet.github.io/api/System.Collections.Generic.List%601.html) generic class offer access to their elements by the zero-based index of the element.  
    
    *   The [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html), [SortedList](http://dotnet.github.io/api/System.Collections.SortedList.html), [ListDictionary](http://dotnet.github.io/api/System.Collections.Specialized.ListDictionary.htm), and [StringDictionary](http://dotnet.github.io/api/System.Collections.Specialized.StringDictionary.html) classes, and the [Dictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) and [SortedDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) generic classes offer access to their elements by the key of the element. 
    
    *   The [NameObjectCollectionBase](http://dotnet.github.io/api/System.Collections.Specialized.NameObjectCollectionBase.html) and [NameValueCollection](http://dotnet.github.io/api/System.Collections.Specialized.NameValueCollection.html) classes, and the [KeyedCollection(Of TKey, TItem)](http://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) and [SortedList(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes offer access to their elements by either the zero-based index or the key of the element.
    
*   Will each element contain one value, a combination of one key and one value, or a combination of one key and multiple values? 

    *   One value: Use any of the collections based on the [IList](http://dotnet.github.io/api/System.Collections.IList.html) interface or the [IList(Of T)](http://dotnet.github.io/api/System.Collections.Generic.IList%601.html) generic interface.
    
    *   One key and one value: Use any of the collections based on the [IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html) interface or the [IDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html) generic interface.
    
    *   One value with embedded key: Use the [KeyedCollection(Of TKey, TItem)](http://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) generic class.
    
    *   One key and multiple values: Use the [NameValueCollection](http://dotnet.github.io/api/System.Collections.Specialized.NameValueCollection.html) class.
    
*   Do you need to sort the elements differently from how they were entered? 

    *   The  [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html) class sorts its elements by their hash codes.  
    
    *   The [SortedList](http://dotnet.github.io/api/System.Collections.SortedList.html) class and the [SortedDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) and [SortedList(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes sort their elements by the key, based on implementations of the [IComparer](http://dotnet.github.io/api/System.Collections.IComparer.html) interface and the [IComparer(Of T)](http://dotnet.github.io/api/System.Collections.Generic.IComparer%601.html) generic interface.  
    
    *   [ArrayList](http://dotnet.github.io/api/System.Collections.ArrayList.html) provides a **Sort** method that takes an [IComparer](http://dotnet.github.io/api/System.Collections.IComparer.html) implementation as a parameter. Its generic counterpart, the [List(Of T)](http://dotnet.github.io/api/System.Collections.Generic.List%601.html) generic class, provides a **Sort** method that takes an implementation of the [IComparer(Of T)](http://dotnet.github.io/api/System.Collections.Generic.IComparer%601.html) generic interface as a parameter.
    
 *  Do you need fast searches and retrieval of information? 
 
    *   [ListDictionary](http://dotnet.github.io/api/System.Collections.Specialized.ListDictionary.htm) is faster than [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html) for small collections (10 items or fewer). The [IDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html) generic class provides faster lookup than the [SortedDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) generic class. The multi-threaded implementation is [ConcurrentDictionary(Of TKey, TValue)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html). [ConcurrentBag(Of T)](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentBag%601.html) provides fast multi-threaded insertion for unordered data.  

*   Do you need collections that accept only strings? 

    *   [StringCollection](http://dotnet.github.io/api/System.Collections.Specialized.StringCollection.html) (based on [IList](http://dotnet.github.io/api/System.Collections.IList.html)) and [StringDictionary](http://dotnet.github.io/api/System.Collections.Specialized.StringDictionary.html) (based on [IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html)) are in the [System.Collections.Specialized](http://dotnet.github.io/api/System.Collections.Specialized.html) namespace. 
    
    *   In addition, you can use any of the generic collection classes in the [System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html) namespace as strongly typed string collections by specifying the [String](http://dotnet.github.io/api/System.String.html) class for their generic type arguments. 
    
## LINQ to Objects

LINQ to Objects enables developers to use LINQ queries to access in-memory objects as long as the object type implements IEnumerable or IEnumerable(Of T). LINQ queries provide a common pattern for accessing data, are typically more concise and readable than standard foreach loops, and provide filtering, ordering, and grouping capabilities. For more information, see [LINQ](concepts/linq.md).

## See Also

[System.Collections](http://dotnet.github.io/api/System.Collections.html)

[System.Collections.Specialized](http://dotnet.github.io/api/System.Collections.Specialized.html)

[System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html)

[Thread-Safe Collections](thread-safeCollections.md)