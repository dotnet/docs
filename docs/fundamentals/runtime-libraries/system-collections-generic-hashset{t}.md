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

The <xref:System.Collections.Generic.HashSet%601> class provides high-performance set operations. A set is a collection that contains no duplicate elements, and whose elements are in no particular order.

The capacity of a <xref:System.Collections.Generic.HashSet%601> object is the number of elements that the object can hold. A <xref:System.Collections.Generic.HashSet%601> object's capacity automatically increases as elements are added to the object.

The <xref:System.Collections.Generic.HashSet%601> class is based on the model of mathematical sets and provides high-performance set operations similar to accessing the keys of the <xref:System.Collections.Generic.Dictionary%602> or <xref:System.Collections.Hashtable> collections. In simple terms, the <xref:System.Collections.Generic.HashSet%601> class can be thought of as a <xref:System.Collections.Generic.Dictionary%602> collection without values.

A <xref:System.Collections.Generic.HashSet%601> collection is not sorted and cannot contain duplicate elements. If order or element duplication is more important than performance for your application, consider using the <xref:System.Collections.Generic.List%601> class together with the <xref:System.Collections.Generic.List%601.Sort%2A> method.

<xref:System.Collections.Generic.HashSet%601> provides many mathematical set operations, such as set addition (unions) and set subtraction. The following table lists the provided <xref:System.Collections.Generic.HashSet%601> operations and their mathematical equivalents.

|HashSet operation|Mathematical equivalent|
|-------------------------------|-----------------------------|
|<xref:System.Collections.Generic.HashSet%601.UnionWith%2A>|Union or set addition|
|<xref:System.Collections.Generic.HashSet%601.IntersectWith%2A>|Intersection|
|<xref:System.Collections.Generic.HashSet%601.ExceptWith%2A>|Set subtraction|
|<xref:System.Collections.Generic.HashSet%601.SymmetricExceptWith%2A>|Symmetric difference|

In addition to the listed set operations, the <xref:System.Collections.Generic.HashSet%601> class also provides methods for determining set equality, overlap of sets, and whether a set is a subset or superset of another set.

**.NET Framework only:** For very large <xref:System.Collections.Generic.HashSet%601> objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the `enabled` attribute of the [`<gcAllowVeryLargeObjects>`](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) configuration element to `true` in the run-time environment.

The <xref:System.Collections.Generic.HashSet%601> class implements the <xref:System.Collections.Generic.ISet%601> interface.

## HashSet and LINQ set operations

LINQ provides access to the `Distinct`, `Union`, `Intersect`, and `Except` set operations on any data source that implements the <xref:System.Collections.IEnumerable> or <xref:System.Linq.IQueryable> interfaces. <xref:System.Collections.Generic.HashSet%601> provides a larger and more robust collection of set operations. For example, <xref:System.Collections.Generic.HashSet%601> provides comparisons such as <xref:System.Collections.Generic.HashSet%601.IsSubsetOf%2A> and <xref:System.Collections.Generic.HashSet%601.IsSupersetOf%2A>.

The primary difference between LINQ set operations and <xref:System.Collections.Generic.HashSet%601> operations is that LINQ set operations always return a new <xref:System.Collections.Generic.IEnumerable%601> collection, whereas the <xref:System.Collections.Generic.HashSet%601> equivalent methods modify the current collection.

Typically, if you must create a new set or if your application needs access only to the provided set operations, using LINQ set operations on any <xref:System.Collections.Generic.IEnumerable%601> collection or array will be sufficient. However, if your application requires access to additional set operations, or if it is not desirable or necessary to create a new collection, use the <xref:System.Collections.Generic.HashSet%601> class.

The following table shows the <xref:System.Collections.Generic.HashSet%601> operations and their equivalent LINQ set operations.

|HashSet operation|LINQ equivalent|
|-------------------------------|---------------------|
|<xref:System.Collections.Generic.HashSet%601.UnionWith%2A>|<xref:System.Linq.Enumerable.Union%2A>|
|<xref:System.Collections.Generic.HashSet%601.IntersectWith%2A>|<xref:System.Linq.Enumerable.Intersect%2A>|
|<xref:System.Collections.Generic.HashSet%601.ExceptWith%2A>|<xref:System.Linq.Enumerable.Except%2A>|
|Not provided.|<xref:System.Linq.Enumerable.Distinct%2A>|
|<xref:System.Collections.Generic.HashSet%601.SymmetricExceptWith%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.Overlaps%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.IsSubsetOf%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.IsProperSubsetOf%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.IsSupersetOf%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.IsProperSupersetOf%2A>|Not provided.|
|<xref:System.Collections.Generic.HashSet%601.SetEquals%2A>|Not provided.|
