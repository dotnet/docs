---
title: "Hashtable and Dictionary Collection Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Hashtable class, grouping data in collections"
  - "Hashtable collection type"
  - "hash tables"
  - "grouping data in collections, Hashtable collection type"
  - "hash function"
  - "collections [.NET Framework], Hashtable collection type"
ms.assetid: bfc20837-3d02-4fc7-8a8f-c5215b6b7913
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Hashtable and Dictionary Collection Types
The <xref:System.Collections.Hashtable?displayProperty=nameWithType> class, and the <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> and <xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType> generic classes, implement the <xref:System.Collections.IDictionary?displayProperty=nameWithType> interface. The <xref:System.Collections.Generic.Dictionary%602> generic class also implements the <xref:System.Collections.Generic.IDictionary%602> generic interface. Therefore, each element in these collections is a key-and-value pair.  
  
 A <xref:System.Collections.Hashtable> object consists of buckets that contain the elements of the collection. A bucket is a virtual subgroup of elements within the <xref:System.Collections.Hashtable>, which makes searching and retrieving easier and faster than in most collections. Each bucket is associated with a hash code, which is generated using a hash function and is based on the key of the element.  
  
 The generic <xref:System.Collections.Generic.HashSet%601> class is an unordered collection for containing unique elements.  
  
 A hash function is an algorithm that returns a numeric hash code based on a key. The key is the value of some property of the object being stored. A hash function must always return the same hash code for the same key. It is possible for a hash function to generate the same hash code for two different keys, but a hash function that generates a unique hash code for each unique key results in better performance when retrieving elements from the hash table.  
  
 Each object that is used as an element in a <xref:System.Collections.Hashtable> must be able to generate a hash code for itself by using an implementation of the <xref:System.Object.GetHashCode%2A> method. However, you can also specify a hash function for all elements in a <xref:System.Collections.Hashtable> by using a <xref:System.Collections.Hashtable> constructor that accepts an <xref:System.Collections.IHashCodeProvider> implementation as one of its parameters.  
  
 When an object is added to a <xref:System.Collections.Hashtable>, it is stored in the bucket that is associated with the hash code that matches the object's hash code. When a value is being searched for in the <xref:System.Collections.Hashtable>, the hash code is generated for that value, and the bucket associated with that hash code is searched.  
  
 For example, a hash function for a string might take the ASCII codes of each character in the string and add them together to generate a hash code. The string "picnic" would have a hash code that is different from the hash code for the string "basket"; therefore, the strings "picnic" and "basket" would be in different buckets. In contrast, "stressed" and "desserts" would have the same hash code and would be in the same bucket.  
  
 The <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Concurrent.ConcurrentDictionary%602> classes have the same functionality as the <xref:System.Collections.Hashtable> class. A <xref:System.Collections.Generic.Dictionary%602> of a specific type (other than <xref:System.Object>) provides better performance than a <xref:System.Collections.Hashtable> for value types. This is because the elements of <xref:System.Collections.Hashtable> are of type <xref:System.Object>; therefore, boxing and unboxing typically occur when you store or retrieve a value type. The <xref:System.Collections.Concurrent.ConcurrentDictionary%602> class should be used when multiple threads might be accessing the collection simultaneously.  
  
## See Also  
 <xref:System.Collections.Hashtable>  
 <xref:System.Collections.IDictionary>  
 <xref:System.Collections.IHashCodeProvider>  
 <xref:System.Collections.Generic.Dictionary%602>  
 <xref:System.Collections.Generic.IDictionary%602?displayProperty=nameWithType>  
 <xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType>  
 [Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md)
