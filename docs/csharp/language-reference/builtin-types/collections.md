---
title: "Collections"
description: Learn about collections in C#, which are used to work with groups of objects. Collections have different characteristics regarding adding and removing elements, modifying elements, and enumerating the collection elements.
ms.date: 08/22/2023
---
# Collections

Updated outline for this article:

- characteristics to distinguish collections
  - indexable vs. dictionary
  - perf metrics on add, remove, iterate, search
  - mutation of collection (add / remove elements)
  - mutation of elements (modify existing contents)
  - concurrency
- Language behavior for some collections
  - arrays
  - span
  - memory
- iterators and LINQ
- collection expressions
- indexers

For many applications, you want to create and manage groups of related objects. There are two ways to group objects: by creating arrays of objects, and by creating collections of objects.

Arrays are most useful for creating and working with a fixed number of strongly typed objects. For information about arrays, see [Arrays](arrays.md).

Collections provide a more flexible way to work with groups of objects. Unlike arrays, the group of objects you work with can grow and shrink dynamically as the needs of the application change. For some collections, you can assign a key to any object that you put into the collection so that you can quickly retrieve the object by using the key.

A collection is a class, so you must declare an instance of the class before you can add elements to that collection.

If your collection contains elements of only one data type, you can use one of the classes in the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace. A generic collection enforces type safety so that no other data type can be added to it. When you retrieve an element from a generic collection, you do not have to determine its data type or convert it.

> [!NOTE]
> For the examples in this topic, include [using](../keywords/using-directive.md) directives for the `System.Collections.Generic` and `System.Linq` namespaces.

## Using a Simple Collection

The examples in this section use the generic <xref:System.Collections.Generic.List%601> class, which enables you to work with a strongly typed list of objects.

The following example creates a list of strings and then iterates through the strings by using a [foreach](../statements/iteration-statements.md#the-foreach-statement) statement.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetCreateList":::

If the contents of a collection are known in advance, you can use a *collection initializer* to initialize the collection. For more information, see [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md).

The following example is the same as the previous example, except a collection initializer is used to add elements to the collection.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetCreateListInitializer":::

You can use a [for](../statements/iteration-statements.md#the-for-statement) statement instead of a `foreach` statement to iterate through a collection. You accomplish this by accessing the collection elements by the index position. The index of the elements starts at 0 and ends at the element count minus 1.

The following example iterates through the elements of a collection by using `for` instead of `foreach`.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetForLoop":::

The following example removes an element from the collection by specifying the object to remove.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetRemoveItemByContent":::

The following example removes elements from a generic list. Instead of a `foreach` statement, a `for` statement that iterates in descending order is used. This is because the <xref:System.Collections.Generic.List%601.RemoveAt%2A> method causes elements after a removed element to have a lower index value.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetRemoveItemByIndex":::

For the type of elements in the <xref:System.Collections.Generic.List%601>, you can also define your own class. In the following example, the `Galaxy` class that is used by the <xref:System.Collections.Generic.List%601> is defined in the code.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetCustomList":::

## Kinds of Collections

Many common collections are provided by .NET. Each type of collection is designed for a specific purpose. You can find all the collection types in the [.NET API reference](/dotnet/api/?term=collection).

Some of the common collection classes are described in this section:

- <xref:System.Collections.Generic> classes
- <xref:System.Collections.Concurrent> classes
- <xref:System.Collections> classes

### System.Collections.Generic Classes

You can create a generic collection by using one of the classes in the <xref:System.Collections.Generic> namespace. A generic collection is useful when every item in the collection has the same data type. A generic collection enforces strong typing by allowing only the desired data type to be added.

The following table lists some of the frequently used classes of the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace:

| Class                                            | Description |
|--------------------------------------------------|-------------|
| <xref:System.Collections.Generic.Dictionary%602> | Represents a collection of key/value pairs that are organized based on the key. |
| <xref:System.Collections.Generic.List%601>       | Represents a list of objects that can be accessed by index. Provides methods to search, sort, and modify lists. |
| <xref:System.Collections.Generic.Queue%601>      | Represents a first in, first out (FIFO) collection of objects. |
| <xref:System.Collections.Generic.SortedList%602> | Represents a collection of key/value pairs that are sorted by key based on the associated <xref:System.Collections.Generic.IComparer%601> implementation. |
| <xref:System.Collections.Generic.Stack%601>      | Represents a last in, first out (LIFO) collection of objects. |

For additional information, see [Commonly Used Collection Types](../../../standard/collections/commonly-used-collection-types.md), [Selecting a Collection Class](../../../standard/collections/selecting-a-collection-class.md), and <xref:System.Collections.Generic>.

### System.Collections.Concurrent Classes

In .NET Framework 4 and later versions, the collections in the <xref:System.Collections.Concurrent> namespace provide efficient thread-safe operations for accessing collection items from multiple threads.

The classes in the <xref:System.Collections.Concurrent> namespace should be used instead of the corresponding types in the <xref:System.Collections.Generic?displayProperty=nameWithType> and <xref:System.Collections?displayProperty=nameWithType> namespaces whenever multiple threads are accessing the collection concurrently. For more information, see [Thread-Safe Collections](../../../standard/collections/thread-safe/index.md) and <xref:System.Collections.Concurrent>.

Some classes included in the <xref:System.Collections.Concurrent> namespace are <xref:System.Collections.Concurrent.BlockingCollection%601>, <xref:System.Collections.Concurrent.ConcurrentDictionary%602>, <xref:System.Collections.Concurrent.ConcurrentQueue%601>, and <xref:System.Collections.Concurrent.ConcurrentStack%601>.

### System.Collections Classes

The classes in the <xref:System.Collections?displayProperty=nameWithType> namespace do not store elements as specifically typed objects, but as objects of type `Object`.

Whenever possible, you should use the generic collections in the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace or the <xref:System.Collections.Concurrent> namespace instead of the legacy types in the `System.Collections` namespace.

The following table lists some of the frequently used classes in the `System.Collections` namespace:

| Class                               | Description                                                                                      |
|-------------------------------------|--------------------------------------------------------------------------------------------------|
| <xref:System.Collections.ArrayList> | Represents an array of objects whose size is dynamically increased as required.                  |
| <xref:System.Collections.Hashtable> | Represents a collection of key/value pairs that are organized based on the hash code of the key. |
| <xref:System.Collections.Queue>     | Represents a first in, first out (FIFO) collection of objects.                                   |
| <xref:System.Collections.Stack>     | Represents a last in, first out (LIFO) collection of objects.                                    |

The <xref:System.Collections.Specialized> namespace provides specialized and strongly typed collection classes, such as string-only collections and linked-list and hybrid dictionaries.

## Implementing a Collection of Key/Value Pairs

The <xref:System.Collections.Generic.Dictionary%602> generic collection enables you to access to elements in a collection by using the key of each element. Each addition to the dictionary consists of a value and its associated key. Retrieving a value by using its key is fast because the `Dictionary` class is implemented as a hash table.

The following example creates a `Dictionary` collection and iterates through the dictionary by using a `foreach` statement.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetDictionaryOldStyle":::

To instead use a collection initializer to build the `Dictionary` collection, you can replace the `BuildDictionary` and `AddToDictionary` methods with the following method.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetDictionaryBetter":::

The following example uses the <xref:System.Collections.Generic.Dictionary%602.ContainsKey%2A> method and the <xref:System.Collections.Generic.Dictionary%602.Item%2A> property of `Dictionary` to quickly find an item by key. The `Item` property enables you to access an item in the `elements` collection by using the `elements[symbol]` in C#.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetFindInDictionary":::

The following example instead uses the <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A> method quickly find an item by key.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetFindInDictionary2":::

## Using LINQ to Access a Collection

LINQ (Language-Integrated Query) can be used to access collections. LINQ queries provide filtering, ordering, and grouping capabilities. For more information, see [Getting Started with LINQ in C#](/dotnet/csharp/linq/).

The following example runs a LINQ query against a generic `List`. The LINQ query returns a different collection that contains the results.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="ShowLINQ":::

## Sorting a Collection

The following example illustrates a procedure for sorting a collection. The example sorts instances of the `Car` class that are stored in a <xref:System.Collections.Generic.List%601>. The `Car` class implements the <xref:System.IComparable%601> interface, which requires that the <xref:System.IComparable%601.CompareTo%2A> method be implemented.

Each call to the <xref:System.IComparable%601.CompareTo%2A> method makes a single comparison that is used for sorting. User-written code in the `CompareTo` method returns a value for each comparison of the current object with another object. The value returned is less than zero if the current object is less than the other object, greater than zero if the current object is greater than the other object, and zero if they are equal. This enables you to define in code the criteria for greater than, less than, and equal.

In the `ListCars` method, the `cars.Sort()` statement sorts the list. This call to the <xref:System.Collections.Generic.List%601.Sort%2A> method of the <xref:System.Collections.Generic.List%601> causes the `CompareTo` method to be called automatically for the `Car` objects in the `List`.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetSortList":::

## Defining a Custom Collection

You can define a collection by implementing the <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Collections.IEnumerable> interface.

Although you can define a custom collection, it is usually better to instead use the collections that are included in .NET, which are described in [Kinds of Collections](#kinds-of-collections) earlier in this article.

The following example defines a custom collection class named `AllColors`. This class implements the <xref:System.Collections.IEnumerable> interface, which requires that the <xref:System.Collections.IEnumerable.GetEnumerator%2A> method be implemented.

The `GetEnumerator` method returns an instance of the `ColorEnumerator` class. `ColorEnumerator` implements the <xref:System.Collections.IEnumerator> interface, which requires that the <xref:System.Collections.IEnumerator.Current%2A> property, <xref:System.Collections.IEnumerator.MoveNext%2A> method, and <xref:System.Collections.IEnumerator.Reset%2A> method be implemented.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetEnumeration":::

## Iterators

An *iterator* is used to perform a custom iteration over a collection. An iterator can be a method or a `get` accessor. An iterator uses a [yield return](../statements/yield.md) statement to return each element of the collection one at a time.

You call an iterator by using a [foreach](../statements/iteration-statements.md#the-foreach-statement) statement. Each iteration of the `foreach` loop calls the iterator. When a `yield return` statement is reached in the iterator, an expression is returned, and the current location in code is retained. Execution is restarted from that location the next time that the iterator is called.

For more information, see [Iterators (C#)](../../programming-guide/concepts/iterators.md).

The following example uses an iterator method. The iterator method has a `yield return` statement that is inside a `for` loop. In the `ListEvenNumbers` method, each iteration of the `foreach` statement body creates a call to the iterator method, which proceeds to the next `yield return` statement.

:::code language="csharp" source="./snippets/shared/Collections.cs" id="SnippetIteratorMethod":::
