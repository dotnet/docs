---
title: Hashtable and Dictionary Collection Types
description: Hashtable and Dictionary Collection Types
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 0f18fac7-fd0d-4f25-a046-1d3d51de062e
---

# Hashtable and Dictionary Collection Types

The [System.Collections.Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) class, and the [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) and [System.Collections.Concurrent.ConcurrentDictionary<T>](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2) generic classes implement the [System.Collections.IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary) interface. The `Dictionary<T>` generic class also implements the [IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2) generic interface. Therefore, each element in these collections is a key-and-value pair.

A `Hashtable` object consists of buckets that contain the elements of the collection. A bucket is a virtual subgroup of elements within the `Hashtable`, which makes searching and retrieving easier and faster than in most collections. Each bucket is associated with a hash code, which is generated using a hash function and is based on the key of the element.

The generic [HashSet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.HashSet-1) class is an unordered collection for containing unique elements. 

A hash function is an algorithm that returns a numeric hash code based on a key. The key is the value of some property of the object being stored. A hash function must always return the same hash code for the same key. It is possible for a hash function to generate the same hash code for two different keys, but a hash function that generates a unique hash code for each unique key results in better performance when retrieving elements from the hash table.

Each object that is used as an element in a `Hashtable` must be able to generate a hash code for itself by using an implementation of the `GetHashCode` method. 

When an object is added to a `Hashtable`, it is stored in the bucket that is associated with the hash code that matches the object's hash code. When a value is being searched for in the `Hashtable`, the hash code is generated for that value, and the bucket associated with that hash code is searched.

For example, a hash function for a string might take the ASCII codes of each character in the string and add them together to generate a hash code. The string "picnic" would have a hash code that is different from the hash code for the string "basket"; therefore, the strings "picnic" and "basket" would be in different buckets. In contrast, "stressed" and "desserts" would have the same hash code and would be in the same bucket.

The `Dictionary<T>` and `ConcurrentDictionary<T>` classes have the same functionality as the `Hashtable` class. A `Dictionary<T>` of a specific type (other than `Object`) provides better performance than a `Hashtable` for value types. This is because the elements of `Hashtable` are of type `Object`; therefore, boxing and unboxing typically occur when you store or retrieve a value type. The `ConcurrentDictionary<T>` class should be used when multiple threads might be accessing the collection simultaneously.

## See Also

[Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable)

[IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary)

[Dictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2)

[System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2)

[System.Collections.Concurrent.ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2)

[Commonly Used Collection Types](commonly-used-collection-types.md)

