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

The <xref:System.Collections.Generic.List%601> class is the generic equivalent of the <xref:System.Collections.ArrayList> class. It implements the <xref:System.Collections.Generic.IList%601> generic interface by using an array whose size is dynamically increased as required.

You can add items to a <xref:System.Collections.Generic.List%601> by using the <xref:System.Collections.Generic.List%601.Add%2A> or <xref:System.Collections.Generic.List%601.AddRange%2A> methods.

The <xref:System.Collections.Generic.List%601> class uses both an equality comparer and an ordering comparer.

- Methods such as <xref:System.Collections.Generic.List%601.Contains%2A>, <xref:System.Collections.Generic.List%601.IndexOf%2A>, <xref:System.Collections.Generic.List%601.LastIndexOf%2A>, and <xref:System.Collections.Generic.Dictionary%602.Remove%2A> use an equality comparer for the list elements. The default equality comparer for type `T` is determined as follows. If type `T` implements the <xref:System.IEquatable%601> generic interface, then the equality comparer is the <xref:System.IEquatable%601.Equals%28%600%29> method of that interface; otherwise, the default equality comparer is <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType>.

- Methods such as <xref:System.Collections.Generic.List%601.BinarySearch%2A> and <xref:System.Collections.Generic.List%601.Sort%2A> use an ordering comparer for the list elements. The default comparer for type `T` is determined as follows. If type `T` implements the <xref:System.IComparable%601> generic interface, then the default comparer is the <xref:System.IComparable%601.CompareTo%28%600%29> method of that interface; otherwise, if type `T` implements the nongeneric <xref:System.IComparable> interface, then the default comparer is the <xref:System.IComparable.CompareTo%28System.Object%29> method of that interface. If type `T` implements neither interface, then there is no default comparer, and a comparer or comparison delegate must be provided explicitly.

The <xref:System.Collections.Generic.List%601> is not guaranteed to be sorted. You must sort the <xref:System.Collections.Generic.List%601> before performing operations (such as <xref:System.Collections.Generic.List%601.BinarySearch%2A>) that require the <xref:System.Collections.Generic.List%601> to be sorted.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

**.NET Framework only:** For very large <xref:System.Collections.Generic.List%601> objects, you can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the `enabled` attribute of the [`<gcAllowVeryLargeObjects>`](../../framework/configure-apps/file-schema/runtime/gcallowverylargeobjects-element.md) configuration element to `true` in the run-time environment.

<xref:System.Collections.Generic.List%601> accepts `null` as a valid value for reference types and allows duplicate elements.

For an immutable version of the <xref:System.Collections.Generic.List%601> class, see <xref:System.Collections.Immutable.ImmutableList%601>.

## Performance considerations

In deciding whether to use the <xref:System.Collections.Generic.List%601> or <xref:System.Collections.ArrayList> class, both of which have similar functionality, remember that the <xref:System.Collections.Generic.List%601> class performs better in most cases and is type safe. If a reference type is used for type `T` of the <xref:System.Collections.Generic.List%601> class, the behavior of the two classes is identical. However, if a value type is used for type `T`, you need to consider implementation and boxing issues.

If a value type is used for type `T`, the compiler generates an implementation of the <xref:System.Collections.Generic.List%601> class specifically for that value type. That means a list element of a <xref:System.Collections.Generic.List%601> object does not have to be boxed before the element can be used, and after about 500 list elements are created, the memory saved by not boxing list elements is greater than the memory used to generate the class implementation.

Make certain the value type used for type `T` implements the <xref:System.IEquatable%601> generic interface. If not, methods such as <xref:System.Collections.Generic.List%601.Contains%2A> must call the <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method, which boxes the affected list element. If the value type implements the <xref:System.IComparable> interface and you own the source code, also implement the <xref:System.IComparable%601> generic interface to prevent the <xref:System.Collections.Generic.List%601.BinarySearch%2A> and <xref:System.Collections.Generic.List%601.Sort%2A> methods from boxing list elements. If you do not own the source code, pass an <xref:System.Collections.Generic.IComparer%601> object to the <xref:System.Collections.Generic.List%601.BinarySearch%2A> and <xref:System.Collections.Generic.List%601.Sort%2A> methods.

It's to your advantage to use the type-specific implementation of the <xref:System.Collections.Generic.List%601> class instead of using the <xref:System.Collections.ArrayList> class or writing a strongly typed wrapper collection yourself. That's because your implementation must do what .NET does for you already, and the .NET runtime can share common intermediate language code and metadata, which your implementation cannot.

## F# considerations

The <xref:System.Collections.Generic.List%601> class is used infrequently in F# code. Instead, [Lists](../../fsharp/language-reference/lists.md), which are immutable, singly-linked lists, are typically preferred. An F# `List` provides an ordered, immutable series of values, and is supported for use in functional-style development. When used from F#, the <xref:System.Collections.Generic.List%601> class is typically referred to by the `ResizeArray<'T>` type abbreviation to avoid naming conflicts with F# Lists.

## Examples

The following example demonstrates how to add, remove, and insert a simple business object in a <xref:System.Collections.Generic.List%601>.

:::code language="csharp" source="./snippets/System.Collections.Generic/ListT/Overview/csharp/program.cs" interactive="try-dotnet" id="snippet1":::
:::code language="vb" source="./snippets/System.Collections.Generic/List/Overview/vb/module1.vb" id="snippet1":::
:::code language="fsharp" source="./snippets/System.Collections.Generic/ListT/Overview/fsharp/addremoveinsert.fs" id="snippet1":::

The following example demonstrates several properties and methods of the <xref:System.Collections.Generic.List%601> generic class of type string. (For an example of a <xref:System.Collections.Generic.List%601> of complex types, see the <xref:System.Collections.Generic.List%601.Contains%2A> method.)

The parameterless constructor is used to create a list of strings with the default capacity. The <xref:System.Collections.Generic.List%601.Capacity%2A> property is displayed and then the <xref:System.Collections.Generic.List%601.Add%2A> method is used to add several items. The items are listed, and the <xref:System.Collections.Generic.List%601.Capacity%2A> property is displayed again, along with the <xref:System.Collections.Generic.List%601.Count%2A> property, to show that the capacity has been increased as needed.

The <xref:System.Collections.Generic.List%601.Contains%2A> method is used to test for the presence of an item in the list, the <xref:System.Collections.Generic.List%601.Insert%2A> method is used to insert a new item in the middle of the list, and the contents of the list are displayed again.

The default <xref:System.Collections.Generic.List%601.Item%2A> property (the indexer in C#) is used to retrieve an item, the <xref:System.Collections.Generic.List%601.Remove%2A> method is used to remove the first instance of the duplicate item added earlier, and the contents are displayed again. The <xref:System.Collections.Generic.List%601.Remove%2A> method always removes the first instance it encounters.

The <xref:System.Collections.Generic.List%601.TrimExcess%2A> method is used to reduce the capacity to match the count, and the <xref:System.Collections.Generic.List%601.Capacity%2A> and <xref:System.Collections.Generic.List%601.Count%2A> properties are displayed. If the unused capacity had been less than 10 percent of total capacity, the list would not have been resized.

Finally, the <xref:System.Collections.Generic.List%601.Clear%2A> method is used to remove all items from the list, and the <xref:System.Collections.Generic.List%601.Capacity%2A> and <xref:System.Collections.Generic.List%601.Count%2A> properties are displayed.

:::code language="csharp" source="./snippets/System.Collections.Generic/ListT/Overview/csharp/source.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="vb" source="./snippets/System.Collections.Generic/List/Overview/vb/source.vb" id="Snippet1":::
:::code language="fsharp" source="./snippets/System.Collections.Generic/ListT/Overview/fsharp/listclass.fs" id="Snippet1":::
