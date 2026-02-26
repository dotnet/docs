---
title: System.Collections.Generic.HashSet\<T> class
description: Learn about the System.Collections.Generic.HashSet\<T> class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - VB
---
# System.Collections.Generic.HashSet\<T> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Collections.Generic.HashSet`1> class provides high-performance set operations. A set is a collection that contains no duplicate elements, and whose elements are in no particular order.

The capacity of a <xref:System.Collections.Generic.HashSet`1> object is the number of elements that the object can hold. A <xref:System.Collections.Generic.HashSet`1> object's capacity automatically increases as elements are added to the object.

The <xref:System.Collections.Generic.HashSet`1> class is based on the model of mathematical sets and provides high-performance set operations similar to accessing the keys of the <xref:System.Collections.Generic.Dictionary`2> or <xref:System.Collections.Hashtable> collections. In simple terms, the <xref:System.Collections.Generic.HashSet`1> class can be thought of as a <xref:System.Collections.Generic.Dictionary`2> collection without values.

A <xref:System.Collections.Generic.HashSet`1> collection is not sorted and cannot contain duplicate elements. If order or element duplication is more important than performance for your application, consider using the <xref:System.Collections.Generic.List`1> class together with the <xref:System.Collections.Generic.List`1.Sort*> method.

<xref:System.Collections.Generic.HashSet`1> provides many mathematical set operations, such as set addition (unions) and set subtraction. The following table lists the provided <xref:System.Collections.Generic.HashSet`1> operations and their mathematical equivalents.

|HashSet operation|Mathematical equivalent|
|-------------------------------|-----------------------------|
|<xref:System.Collections.Generic.HashSet`1.UnionWith*>|Union or set addition|
|<xref:System.Collections.Generic.HashSet`1.IntersectWith*>|Intersection|
|<xref:System.Collections.Generic.HashSet`1.ExceptWith*>|Set subtraction|
|<xref:System.Collections.Generic.HashSet`1.SymmetricExceptWith*>|Symmetric difference|

In addition to the listed set operations, the <xref:System.Collections.Generic.HashSet`1> class also provides methods for determining set equality, overlap of sets, and whether a set is a subset or superset of another set.

**.NET Framework only:** For very large <xref:System.Collections.Generic.HashSet`1> objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the `enabled` attribute of the [`<gcAllowVeryLargeObjects>`](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) configuration element to `true` in the runtime environment.

The <xref:System.Collections.Generic.HashSet`1> class implements the <xref:System.Collections.Generic.ISet`1> interface.

## HashSet and LINQ set operations

LINQ provides access to the `Distinct`, `Union`, `Intersect`, and `Except` set operations on any data source that implements the <xref:System.Collections.IEnumerable> or <xref:System.Linq.IQueryable> interfaces. <xref:System.Collections.Generic.HashSet`1> provides a larger and more robust collection of set operations. For example, <xref:System.Collections.Generic.HashSet`1> provides comparisons such as <xref:System.Collections.Generic.HashSet`1.IsSubsetOf*> and <xref:System.Collections.Generic.HashSet`1.IsSupersetOf*>.

The primary difference between LINQ set operations and <xref:System.Collections.Generic.HashSet`1> operations is that LINQ set operations always return a new <xref:System.Collections.Generic.IEnumerable`1> collection, whereas the <xref:System.Collections.Generic.HashSet`1> equivalent methods modify the current collection.

Typically, if you must create a new set or if your application needs access only to the provided set operations, using LINQ set operations on any <xref:System.Collections.Generic.IEnumerable`1> collection or array will be sufficient. However, if your application requires access to additional set operations, or if it is not desirable or necessary to create a new collection, use the <xref:System.Collections.Generic.HashSet`1> class.

The following table shows the <xref:System.Collections.Generic.HashSet`1> operations and their equivalent LINQ set operations.

|HashSet operation|LINQ equivalent|
|-------------------------------|---------------------|
|<xref:System.Collections.Generic.HashSet`1.UnionWith*>|<xref:System.Linq.Enumerable.Union*>|
|<xref:System.Collections.Generic.HashSet`1.IntersectWith*>|<xref:System.Linq.Enumerable.Intersect*>|
|<xref:System.Collections.Generic.HashSet`1.ExceptWith*>|<xref:System.Linq.Enumerable.Except*>|
|Not provided.|<xref:System.Linq.Enumerable.Distinct*>|
|<xref:System.Collections.Generic.HashSet`1.SymmetricExceptWith*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.Overlaps*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.IsSubsetOf*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.IsProperSubsetOf*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.IsSupersetOf*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.IsProperSupersetOf*>|Not provided.|
|<xref:System.Collections.Generic.HashSet`1.SetEquals*>|Not provided.|
