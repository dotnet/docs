---
title: "Guidelines for Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 297b8f1d-b11f-4dc6-960a-8e990817304e
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Guidelines for Collections
Any type designed specifically to manipulate a group of objects having some common characteristic can be considered a collection. It is almost always appropriate for such types to implement <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601>, so in this section we only consider types implementing one or both of those interfaces to be collections.  
  
 **X DO NOT** use weakly typed collections in public APIs.  
  
 The type of all return values and parameters representing collection items should be the exact item type, not any of its base types (this applies only to public members of the collection).  
  
 **X DO NOT** use <xref:System.Collections.ArrayList> or <xref:System.Collections.Generic.List%601> in public APIs.  
  
 These types are data structures designed to be used in internal implementation, not in public APIs. `List<T>` is optimized for performance and power at the cost of cleanness of the APIs and flexibility. For example, if you return `List<T>`, you will not ever be able to receive notifications when client code modifies the collection. Also, `List<T>` exposes many members, such as <xref:System.Collections.Generic.List%601.BinarySearch%2A>, that are not useful or applicable in many scenarios. The following two sections describe types (abstractions) designed specifically for use in public APIs.  
  
 **X DO NOT** use `Hashtable` or `Dictionary<TKey,TValue>` in public APIs.  
  
 These types are data structures designed to be used in internal implementation. Public APIs should use <xref:System.Collections.IDictionary>, `IDictionary <TKey, TValue>`, or a custom type implementing one or both of the interfaces.  
  
 **X DO NOT** use <xref:System.Collections.Generic.IEnumerator%601>, <xref:System.Collections.IEnumerator>, or any other type that implements either of these interfaces, except as the return type of a `GetEnumerator` method.  
  
 Types returning enumerators from methods other than `GetEnumerator` cannot be used with the `foreach` statement.  
  
 **X DO NOT** implement both `IEnumerator<T>` and `IEnumerable<T>` on the same type. The same applies to the nongeneric interfaces `IEnumerator` and `IEnumerable`.  
  
## Collection Parameters  
 **✓ DO** use the least-specialized type possible as a parameter type. Most members taking collections as parameters use the `IEnumerable<T>` interface.  
  
 **X AVOID** using <xref:System.Collections.Generic.ICollection%601> or <xref:System.Collections.ICollection> as a parameter just to access the `Count` property.  
  
 Instead, consider using `IEnumerable<T>` or `IEnumerable` and dynamically checking whether the object implements `ICollection<T>` or `ICollection`.  
  
## Collection Properties and Return Values  
 **X DO NOT** provide settable collection properties.  
  
 Users can replace the contents of the collection by clearing the collection first and then adding the new contents. If replacing the whole collection is a common scenario, consider providing the `AddRange` method on the collection.  
  
 **✓ DO** use `Collection<T>` or a subclass of `Collection<T>` for properties or return values representing read/write collections.  
  
 If `Collection<T>` does not meet some requirement (e.g., the collection must not implement <xref:System.Collections.IList>), use a custom collection by implementing `IEnumerable<T>`, `ICollection<T>`, or <xref:System.Collections.Generic.IList%601>.  
  
 **✓ DO** use <xref:System.Collections.ObjectModel.ReadOnlyCollection%601>, a subclass of `ReadOnlyCollection<T>`, or in rare cases `IEnumerable<T>` for properties or return values representing read-only collections.  
  
 In general, prefer `ReadOnlyCollection<T>`. If it does not meet some requirement (e.g., the collection must not implement `IList`), use a custom collection by implementing `IEnumerable<T>`, `ICollection<T>`, or `IList<T>`. If you do implement a custom read-only collection, implement `ICollection<T>.IsReadOnly` to return `true`.  
  
 In cases where you are sure that the only scenario you will ever want to support is forward-only iteration, you can simply use `IEnumerable<T>`.  
  
 **✓ CONSIDER** using subclasses of generic base collections instead of using the collections directly.  
  
 This allows for a better name and for adding helper members that are not present on the base collection types. This is especially applicable to high-level APIs.  
  
 **✓ CONSIDER** returning a subclass of `Collection<T>` or `ReadOnlyCollection<T>` from very commonly used methods and properties.  
  
 This will make it possible for you to add helper methods or change the collection implementation in the future.  
  
 **✓ CONSIDER** using a keyed collection if the items stored in the collection have unique keys (names, IDs, etc.). Keyed collections are collections that can be indexed by both an integer and a key and are usually implemented by inheriting from `KeyedCollection<TKey,TItem>`.  
  
 Keyed collections usually have larger memory footprints and should not be used if the memory overhead outweighs the benefits of having the keys.  
  
 **X DO NOT** return null values from collection properties or from methods returning collections. Return an empty collection or an empty array instead.  
  
 The general rule is that null and empty (0 item) collections or arrays should be treated the same.  
  
### Snapshots Versus Live Collections  
 Collections representing a state at some point in time are called snapshot collections. For example, a collection containing rows returned from a database query would be a snapshot. Collections that always represent the current state are called live collections. For example, a collection of `ComboBox` items is a live collection.  
  
 **X DO NOT** return snapshot collections from properties. Properties should return live collections.  
  
 Property getters should be very lightweight operations. Returning a snapshot requires creating a copy of an internal collection in an O(n) operation.  
  
 **✓ DO** use either a snapshot collection or a live `IEnumerable<T>` (or its subtype) to represent collections that are volatile (i.e., that can change without explicitly modifying the collection).  
  
 In general, all collections representing a shared resource (e.g., files in a directory) are volatile. Such collections are very difficult or impossible to implement as live collections unless the implementation is simply a forward-only enumerator.  
  
## Choosing Between Arrays and Collections  
 **✓ DO** prefer collections over arrays.  
  
 Collections provide more control over contents, can evolve over time, and are more usable. In addition, using arrays for read-only scenarios is discouraged because the cost of cloning the array is prohibitive. Usability studies have shown that some developers feel more comfortable using collection-based APIs.  
  
 However, if you are developing low-level APIs, it might be better to use arrays for read-write scenarios. Arrays have a smaller memory footprint, which helps reduce the working set, and access to elements in an array is faster because it is optimized by the runtime.  
  
 **✓ CONSIDER** using arrays in low-level APIs to minimize memory consumption and maximize performance.  
  
 **✓ DO** use byte arrays instead of collections of bytes.  
  
 **X DO NOT** use arrays for properties if the property would have to return a new array (e.g., a copy of an internal array) every time the property getter is called.  
  
## Implementing Custom Collections  
 **✓ CONSIDER** inheriting from `Collection<T>`, `ReadOnlyCollection<T>`, or `KeyedCollection<TKey,TItem>` when designing new collections.  
  
 **✓ DO** implement `IEnumerable<T>` when designing new collections. Consider implementing `ICollection<T>` or even `IList<T>` where it makes sense.  
  
 When implementing such custom collection, follow the API pattern established by `Collection<T>` and `ReadOnlyCollection<T>` as closely as possible. That is, implement the same members explicitly, name the parameters like these two collections name them, and so on.  
  
 **✓ CONSIDER** implementing nongeneric collection interfaces (`IList` and `ICollection`) if the collection will often be passed to APIs taking these interfaces as input.  
  
 **X AVOID** implementing collection interfaces on types with complex APIs unrelated to the concept of a collection.  
  
 **X DO NOT** inherit from nongeneric base collections such as `CollectionBase`. Use `Collection<T>`, `ReadOnlyCollection<T>`, and `KeyedCollection<TKey,TItem>` instead.  
  
### Naming Custom Collections  
 Collections (types that implement `IEnumerable`) are created mainly for two reasons: (1) to create a new data structure with structure-specific operations and often different performance characteristics than existing data structures (e.g.,  <xref:System.Collections.Generic.List%601>, <xref:System.Collections.Generic.LinkedList%601>, <xref:System.Collections.Generic.Stack%601>), and (2) to create a specialized collection for holding a specific set of items (e.g.,  <xref:System.Collections.Specialized.StringCollection>). Data structures are most often used in the internal implementation of applications and libraries. Specialized collections are mainly to be exposed in APIs (as property and parameter types).  
  
 **✓ DO** use the "Dictionary" suffix in names of abstractions implementing `IDictionary` or `IDictionary<TKey,TValue>`.  
  
 **✓ DO** use the "Collection" suffix in names of types implementing `IEnumerable` (or any of its descendants) and representing a list of items.  
  
 **✓ DO** use the appropriate data structure name for custom data structures.  
  
 **X AVOID** using any suffixes implying particular implementation, such as "LinkedList" or "Hashtable," in names of collection abstractions.  
  
 **✓ CONSIDER** prefixing collection names with the name of the item type. For example, a collection storing items of type `Address` (implementing `IEnumerable<Address>`) should be named `AddressCollection`. If the item type is an interface, the "I" prefix of the item type can be omitted. Thus, a collection of <xref:System.IDisposable> items can be called `DisposableCollection`.  
  
 **✓ CONSIDER** using the "ReadOnly" prefix in names of read-only collections if a corresponding writeable collection might be added or already exists in the framework.  
  
 For example, a read-only collection of strings should be called `ReadOnlyStringCollection`.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Usage Guidelines](../../../docs/standard/design-guidelines/usage-guidelines.md)
