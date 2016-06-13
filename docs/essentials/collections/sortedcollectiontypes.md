# Sorted Collection Types  
 
 The [System.Collections.SortedList](http://dotnet.github.io/api/System.Collections.SortedList.html) class, the [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic class, and the [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) generic class are similar to the [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html) class and the [Dictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) generic class in that they implement the [IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html) interface, but they maintain their elements in sort order by key, and they do not have the O(1) insertion and retrieval characteristic of hash tables. The three classes have several features in common:  

 *   All three classes implement the [System.Collections.IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html) interface. The two generic classes also implement the [System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html) generic interface.  
 
 *   Each element is a key/value pair for enumeration purposes.   
  
> **Note**  
 >   
>The nongeneric [SortedList](http://dotnet.github.io/api/System.Collections.SortedList.html) class returns [DictionaryEntry](http://dotnet.github.io/api/System.Collections.DictionaryEntry.html) objects when enumerated, although the two generic types return [KeyValuePair&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.KeyValuePair%602.html) objects.  
   
*   Elements are sorted according to a [System.Collections.IComparer](http://dotnet.github.io/api/System.Collections.IComparer.html) implementation (for nongeneric `SortedList`) or a [System.Collections.Generic.IComparer&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IComparer%601.html) implementation (for the two generic classes).  
   
 *   Each class provides properties that return collections containing only the keys or only the values.  
   
The following table lists some of the differences between the two sorted list classes and the [SortedDictionary<TKey, TValue>](http://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) class.  
   
 `SortedList` nongeneric class and `SortedList<TKey, TValue>` generic class | `SortedDictionary<TKey, TValue>` generic class  
 --------------------------------------------------------------------------------- | ------------------------------  
 The properties that return keys and values are indexed, allowing efficient indexed retrieval. | No indexed retrieval.  
 Retrieval is O(log n). | Retrieval is O(log n).  
 Insertion and removal are generally O(n); however, insertion is O(1) for data that are already in sort order, so that each element is added to the end of the list. (This assumes that a resize is not required.) | Insertion and removal are O(log n).  
 Uses less memory than a `SortedDictionary<TKey, TValue>`. | Uses more memory than the `SortedList` nongeneric class and the `SortedList<TKey, TValue>` generic class.  
  
 For sorted lists or dictionaries that must be accessible concurrently from multiple threads, you can add sorting logic to a class that derives from [ConcurrentDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html).  
  
 > **Note**  
 >   
 >For values that contain their own keys (for example, employee records that contain an employee ID number), you can create a keyed collection that has some characteristics of a list and some characteristics of a dictionary by deriving from the [KeyedCollection&lt;TKey, TItem&gt;]() generic class.  
   
 The [SortedSet&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedSet%601.html) class provides a self-balancing tree that maintains data in sorted order after insertions, deletions, and searches. This class and the [HashSet&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.HashSet%601.html) class implement the [ISet&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.ISet%601.html) interface.  
   
## See Also  
  
[System.Collections.IDictionary](http://dotnet.github.io/api/System.Collections.IDictionary.html)  
   
[System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html)  
   
[ConcurrentDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html)  
 
[Commonly Used Collection Types](commonlyUsedCollectionTypes.md) 
