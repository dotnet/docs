---
title: System.Collections.Generic.List\<T> class
description: Learn about the System.Collections.Generic.List\<T> class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Collections.Generic.List\<T> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Collections.Generic.List`1> class is the generic equivalent of the <xref:System.Collections.ArrayList> class. It implements the <xref:System.Collections.Generic.IList`1> generic interface by using an array whose size is dynamically increased as required.

You can add items to a <xref:System.Collections.Generic.List`1> by using the <xref:System.Collections.Generic.List`1.Add*> or <xref:System.Collections.Generic.List`1.AddRange*> methods.

The <xref:System.Collections.Generic.List`1> class uses both an equality comparer and an ordering comparer.

- Methods such as <xref:System.Collections.Generic.List`1.Contains*>, <xref:System.Collections.Generic.List`1.IndexOf*>, <xref:System.Collections.Generic.List`1.LastIndexOf*>, and <xref:System.Collections.Generic.Dictionary`2.Remove*> use an equality comparer for the list elements. The default equality comparer for type `T` is determined as follows. If type `T` implements the <xref:System.IEquatable`1> generic interface, then the equality comparer is the <xref:System.IEquatable`1.Equals(%600)> method of that interface; otherwise, the default equality comparer is <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>.

- Methods such as <xref:System.Collections.Generic.List`1.BinarySearch*> and <xref:System.Collections.Generic.List`1.Sort*> use an ordering comparer for the list elements. The default comparer for type `T` is determined as follows. If type `T` implements the <xref:System.IComparable`1> generic interface, then the default comparer is the <xref:System.IComparable`1.CompareTo(%600)> method of that interface; otherwise, if type `T` implements the nongeneric <xref:System.IComparable> interface, then the default comparer is the <xref:System.IComparable.CompareTo(System.Object)> method of that interface. If type `T` implements neither interface, then there is no default comparer, and a comparer or comparison delegate must be provided explicitly.

The <xref:System.Collections.Generic.List`1> is not guaranteed to be sorted. You must sort the <xref:System.Collections.Generic.List`1> before performing operations (such as <xref:System.Collections.Generic.List`1.BinarySearch*>) that require the <xref:System.Collections.Generic.List`1> to be sorted.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

**.NET Framework only:** For very large <xref:System.Collections.Generic.List`1> objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the `enabled` attribute of the [`<gcAllowVeryLargeObjects>`](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) configuration element to `true` in the runtime environment.

<xref:System.Collections.Generic.List`1> accepts `null` as a valid value for reference types and allows duplicate elements.

For an immutable version of the <xref:System.Collections.Generic.List`1> class, see <xref:System.Collections.Immutable.ImmutableList`1>.

## Performance considerations

In deciding whether to use the <xref:System.Collections.Generic.List`1> or <xref:System.Collections.ArrayList> class, both of which have similar functionality, remember that the <xref:System.Collections.Generic.List`1> class performs better in most cases and is type safe. If a reference type is used for type `T` of the <xref:System.Collections.Generic.List`1> class, the behavior of the two classes is identical. However, if a value type is used for type `T`, you need to consider implementation and boxing issues.

If a value type is used for type `T`, the compiler generates an implementation of the <xref:System.Collections.Generic.List`1> class specifically for that value type. That means a list element of a <xref:System.Collections.Generic.List`1> object does not have to be boxed before the element can be used, and after about 500 list elements are created, the memory saved by not boxing list elements is greater than the memory used to generate the class implementation.

Make certain the value type used for type `T` implements the <xref:System.IEquatable`1> generic interface. If not, methods such as <xref:System.Collections.Generic.List`1.Contains*> must call the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method, which boxes the affected list element. If the value type implements the <xref:System.IComparable> interface and you own the source code, also implement the <xref:System.IComparable`1> generic interface to prevent the <xref:System.Collections.Generic.List`1.BinarySearch*> and <xref:System.Collections.Generic.List`1.Sort*> methods from boxing list elements. If you do not own the source code, pass an <xref:System.Collections.Generic.IComparer`1> object to the <xref:System.Collections.Generic.List`1.BinarySearch*> and <xref:System.Collections.Generic.List`1.Sort*> methods.

It's to your advantage to use the type-specific implementation of the <xref:System.Collections.Generic.List`1> class instead of using the <xref:System.Collections.ArrayList> class or writing a strongly typed wrapper collection yourself. That's because your implementation must do what .NET does for you already, and the .NET runtime can share common intermediate language code and metadata, which your implementation cannot.

## F# considerations

The <xref:System.Collections.Generic.List`1> class is used infrequently in F# code. Instead, [Lists](../../fsharp/language-reference/lists.md), which are immutable, singly-linked lists, are typically preferred. An F# `List` provides an ordered, immutable series of values, and is supported for use in functional-style development. When used from F#, the <xref:System.Collections.Generic.List`1> class is typically referred to by the `ResizeArray<'T>` type abbreviation to avoid naming conflicts with F# Lists.

## Examples

The following example demonstrates how to add, remove, and insert a simple business object in a <xref:System.Collections.Generic.List`1>.

:::code language="csharp" source="./snippets/System.Collections.Generic/ListT/Overview/csharp/program.cs" id="snippet1":::
:::code language="vb" source="./snippets/System.Collections.Generic/List/Overview/vb/module1.vb" id="snippet1":::
:::code language="fsharp" source="./snippets/System.Collections.Generic/ListT/Overview/fsharp/addremoveinsert.fs" id="snippet1":::

The following example demonstrates several properties and methods of the <xref:System.Collections.Generic.List`1> generic class of type string. (For an example of a <xref:System.Collections.Generic.List`1> of complex types, see the <xref:System.Collections.Generic.List`1.Contains*> method.)

The parameterless constructor is used to create a list of strings with the default capacity. The <xref:System.Collections.Generic.List`1.Capacity> property is displayed and then the <xref:System.Collections.Generic.List`1.Add*> method is used to add several items. The items are listed, and the <xref:System.Collections.Generic.List`1.Capacity> property is displayed again, along with the <xref:System.Collections.Generic.List`1.Count> property, to show that the capacity has been increased as needed.

The <xref:System.Collections.Generic.List`1.Contains*> method is used to test for the presence of an item in the list, the <xref:System.Collections.Generic.List`1.Insert*> method is used to insert a new item in the middle of the list, and the contents of the list are displayed again.

The default <xref:System.Collections.Generic.List`1.Item> property (the indexer in C#) is used to retrieve an item, the <xref:System.Collections.Generic.List`1.Remove*> method is used to remove the first instance of the duplicate item added earlier, and the contents are displayed again. The <xref:System.Collections.Generic.List`1.Remove*> method always removes the first instance it encounters.

The <xref:System.Collections.Generic.List`1.TrimExcess*> method is used to reduce the capacity to match the count, and the <xref:System.Collections.Generic.List`1.Capacity*> and <xref:System.Collections.Generic.List`1.Count*> properties are displayed. If the unused capacity had been less than 10 percent of total capacity, the list would not have been resized.

Finally, the <xref:System.Collections.Generic.List`1.Clear*> method is used to remove all items from the list, and the <xref:System.Collections.Generic.List`1.Capacity*> and <xref:System.Collections.Generic.List`1.Count*> properties are displayed.

:::code language="csharp" source="./snippets/System.Collections.Generic/ListT/Overview/csharp/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Collections.Generic/List/Overview/vb/source.vb" id="Snippet1":::
:::code language="fsharp" source="./snippets/System.Collections.Generic/ListT/Overview/fsharp/listclass.fs" id="Snippet1":::
