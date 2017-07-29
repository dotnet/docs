---
title: F# Collection Types
description: Learn about F# collection types and how they differ from collection types in the .NET Framework.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: cdf6a7e6-6b3d-4c44-b7b6-773a2b700331 
---

# F# Collection Types

By reviewing this topic, you can determine which F# collection type best suits a particular need. These collection types differ from the collection types in the .NET Framework, such as those in the `System.Collections.Generic` namespace, in that the F# collection types are designed from a functional programming perspective rather than an object-oriented perspective. More specifically, only the array collection has mutable elements. Therefore, when you modify a collection, you create an instance of the modified collection instead of altering the original collection.

Collection types also differ in the type of data structure in which objects are stored. Data structures such as hash tables, linked lists, and arrays have different performance characteristics and a different set of available operations.


## F# Collection Types
The following table shows F# collection types.



|Type|Description|Related Links|
|----|-----------|-------------|
|[List](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)|An ordered, immutable series of elements of the same type. Implemented as a linked list.|[Lists](lists.md)<br /><br />[List Module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788)|
|[Array](https://msdn.microsoft.com/library/0cda8040-9396-40dd-8dcd-cf48542165a1)|A fixed-size, zero-based, mutable collection of consecutive data elements that are all of the same type.|[Arrays](arrays.md)<br /><br />[Array Module](https://msdn.microsoft.com/library/0cda8040-9396-40dd-8dcd-cf48542165a1)<br /><br />[Array2D Module](https://msdn.microsoft.com/library/ae1a9746-7817-4430-bcdb-a79c2411bbd3)<br /><br />[Array3D Module](https://msdn.microsoft.com/library/c8355e2d-add8-48a4-8aa6-1c57ae74c560)|
|[seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)|A logical series of elements that are all of one type. Sequences are particularly useful when you have a large, ordered collection of data but don't necessarily expect to use all the elements. Individual sequence elements are computed only as required, so a sequence can perform better than a list if not all the elements are used. Sequences are represented by the `seq<'T>` type, which is an alias for `IEnumerable<T>`. Therefore, any .NET Framework type that implements `System.Collections.Generic.IEnumerable<'T>` can be used as a sequence.|[Sequences](sequences.md)<br /><br />[Seq Module](https://msdn.microsoft.com/library/54e8f059-ca52-4632-9ae9-49685ee9b684)|
|[Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)|An immutable dictionary of elements. Elements are accessed by key.|[Map Module](https://msdn.microsoft.com/library/bfe61ead-f16c-416f-af98-56dbcbe23e4f)|
|[Set](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8)|An immutable set that's based on binary trees, where comparison is the F# structural comparison function, which potentially uses implementations of the `System.IComparable` interface on key values.|[Set Module](https://msdn.microsoft.com/library/61efa732-d55d-4c32-993f-628e2f98e6a0)|

### Table of Functions
This section compares the functions that are available on F# collection types. The computational complexity of the function is given, where N is the size of the first collection, and M is the size of the second collection, if any. A dash (-) indicates that this function isn't available on the collection. Because sequences are lazily evaluated, a function such as Seq.distinct may be O(1) because it returns immediately, although it still affects the performance of the sequence when enumerated.



|Function|Array|List|Sequence|Map|Set|Description|
|--------|-----|----|--------|---|---|-----------|
|append|O(M)|O(N)|O(N)|-|-|Returns a new collection that contains the elements of the first collection followed by elements of the second collection.|
|add|-|-|-|O(log N)|O(log N)|Returns a new collection with the element added.|
|average|O(N)|O(N)|O(N)|-|-|Returns the average of the elements in the collection.|
|averageBy|O(N)|O(N)|O(N)|-|-|Returns the average of the results of the provided function applied to each element.|
|blit|O(N)|-|-|-|-|Copies a section of an array.|
|cache|-|-|O(N)|-|-|Computes and stores elements of a sequence.|
|cast|-|-|O(N)|-|-|Converts the elements to the specified type.|
|choose|O(N)|O(N)|O(N)|-|-|Applies the given function `f` to each element `x` of the list. Returns the list that contains the results for each element where the function returns `Some(f(x))`.|
|collect|O(N)|O(N)|O(N)|-|-|Applies the given function to each element of the collection, concatenates all the results, and returns the combined list.|
|compareWith|-|-|O(N)|-|-|Compares two sequences by using the given comparison function, element by element.|
|concat|O(N)|O(N)|O(N)|-|-|Combines the given enumeration-of-enumerations as a single concatenated enumeration.|
|contains|-|-|-|-|O(log N)|Returns true if the set contains the specified element.|
|containsKey|-|-|-|O(log N)|-|Tests whether an element is in the domain of a map.|
|count|-|-|-|-|O(N)|Returns the number of elements in the set.|
|countBy|-|-|O(N)|-|-|Applies a key-generating function to each element of a sequence, and returns a sequence that yields unique keys and their number of occurrences in the original sequence.|
|copy|O(N)|-|O(N)|-|-|Copies the collection.|
|create|O(N)|-|-|-|-|Creates an array of whole elements that are all initially the given value.|
|delay|-|-|O(1)|-|-|Returns a sequence that's built from the given delayed specification of a sequence.|
|difference|-|-|-|-|O(M &#42; log N)|Returns a new set with the elements of the second set removed from the first set.|
|distinct|||O(1)&#42;|||Returns a sequence that contains no duplicate entries according to generic hash and equality comparisons on the entries. If an element occurs multiple times in the sequence, later occurrences are discarded.|
|distinctBy|||O(1)&#42;|||Returns a sequence that contains no duplicate entries according to the generic hash and equality comparisons on the keys that the given key-generating function returns. If an element occurs multiple times in the sequence, later occurrences are discarded.|
|empty|O(1)|O(1)|O(1)|O(1)|O(1)|Creates an empty collection.|
|exists|O(N)|O(N)|O(N)|O(log N)|O(log N)|Tests whether any element of the sequence satisfies the given predicate.|
|exists2|O(min(N,M))|-|O(min(N,M))|||Tests whether any pair of corresponding elements of the input sequences satisfies the given predicate.|
|fill|O(N)|||||Sets a range of elements of the array to the given value.|
|filter|O(N)|O(N)|O(N)|O(N)|O(N)|Returns a new collection that contains only the elements of the collection for which the given predicate returns `true`.|
|find|O(N)|O(N)|O(N)|O(log N)|-|Returns the first element for which the given function returns `true`. Returns `System.Collections.Generic.KeyNotFoundException` if no such element exists.|
|findIndex|O(N)|O(N)|O(N)|-|-|Returns the index of the first element in the array that satisfies the given predicate. Raises `System.Collections.Generic.KeyNotFoundException` if no element satisfies the predicate.|
|findKey|-|-|-|O(log N)|-|Evaluates the function on each mapping in the collection, and returns the key for the first mapping where the function returns `true`. If no such element exists, this function raises `System.Collections.Generic.KeyNotFoundException`.|
|fold|O(N)|O(N)|O(N)|O(N)|O(N)|Applies a function to each element of the collection, threading an accumulator argument through the computation. If the input function is f and the elements are i0...iN, this function computes f (... (f s i0)...) iN.|
|fold2|O(N)|O(N)|-|-|-|Applies a function to corresponding elements of two collections, threading an accumulator argument through the computation. The collections must have identical sizes. If the input function is f and the elements are i0...iN and j0...jN, this function computes f (... (f s i0 j0)...) iN jN.|
|foldBack|O(N)|O(N)|-|O(N)|O(N)|Applies a function to each element of the collection, threading an accumulator argument through the computation. If the input function is f and the elements are i0...iN, this function computes f i0 (...(f iN s)).|
|foldBack2|O(N)|O(N)|-|-|-|Applies a function to corresponding elements of two collections, threading an accumulator argument through the computation. The collections must have identical sizes. If the input function is f and the elements are i0...iN and j0...jN, this function computes f i0 j0 (...(f iN jN s)).|
|forall|O(N)|O(N)|O(N)|O(N)|O(N)|Tests whether all elements of the collection satisfy the given predicate.|
|forall2|O(N)|O(N)|O(N)|-|-|Tests whether all corresponding elements of the collection satisfy the given predicate pairwise.|
|get / nth|O(1)|O(N)|O(N)|-|-|Returns an element from the collection given its index.|
|head|-|O(1)|O(1)|-|-|Returns the first element of the collection.|
|init|O(N)|O(N)|O(1)|-|-|Creates a collection given the dimension and a generator function to compute the elements.|
|initInfinite|-|-|O(1)|-|-|Generates a sequence that, when iterated, returns successive elements by calling the given function.|
|intersect|-|-|-|-|O(log N &#42; log M)|Computes the intersection of two sets.|
|intersectMany|-|-|-|-|O(N1 &#42; N2 ...)|Computes the intersection of a sequence of sets. The sequence must not be empty.|
|isEmpty|O(1)|O(1)|O(1)|O(1)|-|Returns `true` if the collection is empty.|
|isProperSubset|-|-|-|-|O(M &#42; log N)|Returns `true` if all elements of the first set are in the second set, and at least one element of the second set isn't in the first set.|
|isProperSuperset|-|-|-|-|O(M &#42; log N)|Returns `true` if all elements of the second set are in the first set, and at least one element of the first set isn't in the second set.|
|isSubset|-|-|-|-|O(M &#42; log N)|Returns `true` if all elements of the first set are in the second set.|
|isSuperset|-|-|-|-|O(M &#42; log N)|Returns `true` if all elements of the second set are in the first set.|
|iter|O(N)|O(N)|O(N)|O(N)|O(N)|Applies the given function to each element of the collection.|
|iteri|O(N)|O(N)|O(N)|-|-|Applies the given function to each element of the collection. The integer that's passed to the function indicates the index of the element.|
|iteri2|O(N)|O(N)|-|-|-|Applies the given function to a pair of elements that are drawn from matching indices in two arrays. The integer that's passed to the function indicates the index of the elements. The two arrays must have the same length.|
|iter2|O(N)|O(N)|O(N)|-|-|Applies the given function to a pair of elements that are drawn from matching indices in two arrays. The two arrays must have the same length.|
|length|O(1)|O(N)|O(N)|-|-|Returns the number of elements in the collection.|
|map|O(N)|O(N)|O(1)|-|-|Builds a collection whose elements are the results of applying the given function to each element of the array.|
|map2|O(N)|O(N)|O(1)|-|-|Builds a collection whose elements are the results of applying the given function to the corresponding elements of the two collections pairwise. The two input arrays must have the same length.|
|map3|-|O(N)|-|-|-|Builds a collection whose elements are the results of applying the given function to the corresponding elements of the three collections simultaneously.|
|mapi|O(N)|O(N)|O(N)|-|-|Builds an array whose elements are the results of applying the given function to each element of the array. The integer index that's passed to the function indicates the index of the element that's being transformed.|
|mapi2|O(N)|O(N)|-|-|-|Builds a collection whose elements are the results of applying the given function to the corresponding elements of the two collections pairwise, also passing the index of the elements. The two input arrays must have the same length.|
|max|O(N)|O(N)|O(N)|-|-|Returns the greatest element in the collection, compared by using the [max](https://msdn.microsoft.com/library/9a988328-00e9-467b-8dfa-e7a6990f6cce) operator.|
|maxBy|O(N)|O(N)|O(N)|-|-|Returns the greatest element in the collection, compared by using [max](https://msdn.microsoft.com/library/9a988328-00e9-467b-8dfa-e7a6990f6cce) on the function result.|
|maxElement|-|-|-|-|O(log N)|Returns the greatest element in the set according to the ordering that's used for the set.|
|min|O(N)|O(N)|O(N)|-|-|Returns the least element in the collection, compared by using the [min](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed) operator.|
|minBy|O(N)|O(N)|O(N)|-|-|Returns the least element in the collection, compared by using the [min](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed) operator on the function result.|
|minElement|-|-|-|-|O(log N)|Returns the lowest element in the set according to the ordering that's used for the set.|
|ofArray|-|O(N)|O(1)|O(N)|O(N)|Creates a collection that contains the same elements as the given array.|
|ofList|O(N)|-|O(1)|O(N)|O(N)|Creates a collection that contains the same elements as the given list.|
|ofSeq|O(N)|O(N)|-|O(N)|O(N)|Creates a collection that contains the same elements as the given sequence.|
|pairwise|-|-|O(N)|-|-|Returns a sequence of each element in the input sequence and its predecessor except for the first element, which is returned only as the predecessor of the second element.|
|partition|O(N)|O(N)|-|O(N)|O(N)|Splits the collection into two collections. The first collection contains the elements for which the given predicate returns `true`, and the second collection contains the elements for which the given predicate returns `false`.|
|permute|O(N)|O(N)|-|-|-|Returns an array with all elements permuted according to the specified permutation.|
|pick|O(N)|O(N)|O(N)|O(log N)|-|Applies the given function to successive elements, returning the first result where the function returns Some. If the function never returns Some, `System.Collections.Generic.KeyNotFoundException` is raised.|
|readonly|-|-|O(N)|-|-|Creates a sequence object that delegates to the given sequence object. This operation ensures that a type cast can't rediscover and mutate the original sequence. For example, if given an array, the returned sequence will return the elements of the array, but you can't cast the returned sequence object to an array.|
|reduce|O(N)|O(N)|O(N)|-|-|Applies a function to each element of the collection, threading an accumulator argument through the computation. This function starts by applying the function to the first two elements, passes this result into the function along with the third element, and so on. The function returns the final result.|
|reduceBack|O(N)|O(N)|-|-|-|Applies a function to each element of the collection, threading an accumulator argument through the computation. If the input function is f and the elements are i0...iN, this function computes f i0 (...(f iN-1 iN)).|
|remove|-|-|-|O(log N)|O(log N)|Removes an element from the domain of the map. No exception is raised if the element isn't present.|
|replicate|-|O(N)|-|-|-|Creates a list of a specified length with every element set to the given value.|
|rev|O(N)|O(N)|-|-|-|Returns a new list with the elements in reverse order.|
|scan|O(N)|O(N)|O(N)|-|-|Applies a function to each element of the collection, threading an accumulator argument through the computation. This operation applies the function to the second argument and the first element of the list. The operation then passes this result into the function along with the second element and so on. Finally, the operation returns the list of intermediate results and the final result.|
|scanBack|O(N)|O(N)|-|-|-|Resembles the foldBack operation but returns both the intermediate and final results.|
|singleton|-|-|O(1)|-|O(1)|Returns a sequence that yields only one item.|
|set|O(1)|-|-|-|-|Sets an element of an array to the specified value.|
|skip|-|-|O(N)|-|-|Returns a sequence that skips N elements of the underlying sequence and then yields the remaining elements of the sequence.|
|skipWhile|-|-|O(N)|-|-|Returns a sequence that, when iterated, skips elements of the underlying sequence while the given predicate returns `true` and then yields the remaining elements of the sequence.|
|sort|O(N log N) average<br /><br />O(N^2) worst case|O(N log N)|O(N log N)|-|-|Sorts the collection by element value. Elements are compared using [compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).|
|sortBy|O(N log N) average<br /><br />O(N^2) worst case|O(N log N)|O(N log N)|-|-|Sorts the given list by using keys that the given projection provides. Keys are compared using [compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).|
|sortInPlace|O(N log N) average<br /><br />O(N^2) worst case|-|-|-|-|Sorts the elements of an array by mutating it in place and using the given comparison function. Elements are compared by using [compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).|
|sortInPlaceBy|O(N log N) average<br /><br />O(N^2) worst case|-|-|-|-|Sorts the elements of an array by mutating it in place and using the given projection for the keys. Elements are compared by using [compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c).|
|sortInPlaceWith|O(N log N) average<br /><br />O(N^2) worst case|-|-|-|-|Sorts the elements of an array by mutating it in place and using the given comparison function as the order.|
|sortWith|O(N log N) average<br /><br />O(N^2) worst case|O(N log N)|-|-|-|Sorts the elements of a collection, using the given comparison function as the order and returning a new collection.|
|sub|O(N)|-|-|-|-|Builds an array that contains the given subrange that's specified by starting index and length.|
|sum|O(N)|O(N)|O(N)|-|-|Returns the sum of the elements in the collection.|
|sumBy|O(N)|O(N)|O(N)|-|-|Returns the sum of the results that are generated by applying the function to each element of the collection.|
|tail|-|O(1)|-|-|-|Returns the list without its first element.|
|take|-|-|O(N)|-|-|Returns the elements of the sequence up to a specified count.|
|takeWhile|-|-|O(1)|-|-|Returns a sequence that, when iterated, yields elements of the underlying sequence while the given predicate returns `true` and then returns no more elements.|
|toArray|-|O(N)|O(N)|O(N)|O(N)|Creates an array from the given collection.|
|toList|O(N)|-|O(N)|O(N)|O(N)|Creates a list from the given collection.|
|toSeq|O(1)|O(1)|-|O(1)|O(1)|Creates a sequence from the given collection.|
|truncate|-|-|O(1)|-|-|Returns a sequence that, when enumerated, returns no more than N elements.|
|tryFind|O(N)|O(N)|O(N)|O(log N)|-|Searches for an element that satisfies a given predicate.|
|tryFindIndex|O(N)|O(N)|O(N)|-|-|Searches for the first element that satisfies a given predicate and returns the index of the matching element, or `None` if no such element exists.|
|tryFindKey|-|-|-|O(log N)|-|Returns the key of the first mapping in the collection that satisfies the given predicate, or returns `None` if no such element exists.|
|tryPick|O(N)|O(N)|O(N)|O(log N)|-|Applies the given function to successive elements, returning the first result where the function returns `Some` for some value. If no such element exists, the operation returns `None`.|
|unfold|-|-|O(N)|-|-|Returns a sequence that contains the elements that the given computation generates.|
|union|-|-|-|-|O(M &#42; log N)|Computes the union of the two sets.|
|unionMany|-|-|-|-|O(N1 &#42; N2 ...)|Computes the union of a sequence of sets.|
|unzip|O(N)|O(N)|O(N)|-|-|Splits a list of pairs into two lists.|
|unzip3|O(N)|O(N)|O(N)|-|-|Splits a list of triples into three lists.|
|windowed|-|-|O(N)|-|-|Returns a sequence that yields sliding windows of containing elements that are drawn from the input sequence. Each window is returned as a fresh array.|
|zip|O(N)|O(N)|O(N)|-|-|Combines the two collections into a list of pairs. The two lists must have equal lengths.|
|zip3|O(N)|O(N)|O(N)|-|-|Combines the three collections into a list of triples. The lists must have equal lengths.|

## See Also
[F# Types](fsharp-types.md)

[F# Language Reference](index.md)

