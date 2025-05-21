---
title: System.Object.GetHashCode method
description: Learn about the System.Object.GetHashCode method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Object.GetHashCode method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Object.GetHashCode%2A> method provides a hash code for algorithms that need quick checks of object equality. A hash code is a numeric value that is used to insert and identify an object in a hash-based collection, such as the <xref:System.Collections.Generic.Dictionary%602> class, the <xref:System.Collections.Hashtable> class, or a type derived from the <xref:System.Collections.DictionaryBase> class.

> [!NOTE]
> For information about how hash codes are used in hash tables and for some additional hash code algorithms, see the [Hash Function](https://en.wikipedia.org/wiki/Hash_function) entry in Wikipedia.

Two objects that are equal return hash codes that are equal. However, the reverse is not true: equal hash codes do not imply object equality, because different (unequal) objects can have identical hash codes. Furthermore, .NET does not guarantee the default implementation of the <xref:System.Object.GetHashCode%2A> method, and the value this method returns may differ between .NET implementations, such as different versions of .NET Framework and .NET Core, and platforms, such as 32-bit and 64-bit platforms. For these reasons, do not use the default implementation of this method as a unique object identifier for hashing purposes. Two consequences follow from this:

- You should not assume that equal hash codes imply object equality.
- You should never persist or use a hash code outside the application domain in which it was created, because the same object may hash across application domains, processes, and platforms.

> [!WARNING]
> A hash code is intended for efficient insertion and lookup in collections that are based on a hash table. A hash code is not a permanent value. For this reason:
>
> - Do not serialize hash code values or store them in databases.
> - Do not use the hash code as the key to retrieve an object from a keyed collection.
> - Do not send hash codes across application domains or processes. In some cases, hash codes may be computed on a per-process or per-application domain basis.
> - Do not use the hash code instead of a value returned by a cryptographic hashing function if you need a cryptographically strong hash. For cryptographic hashes, use a class derived from the <xref:System.Security.Cryptography.HashAlgorithm?displayProperty=nameWithType> or <xref:System.Security.Cryptography.KeyedHashAlgorithm?displayProperty=nameWithType> class.
> - Do not test for equality of hash codes to determine whether two objects are equal. (Unequal objects can have identical hash codes.) To test for equality, call the <xref:System.Object.ReferenceEquals%2A> or <xref:System.Object.Equals%2A> method.

The <xref:System.Object.GetHashCode%2A> method can be overridden by a derived type. If <xref:System.Object.GetHashCode%2A> is not overridden, hash codes for reference types are computed by calling the <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> method of the base class, which computes a hash code based on an object's reference; for more information, see <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode%2A?displayProperty=nameWithType>. In other words, two objects for which the <xref:System.Object.ReferenceEquals%2A> method returns `true` have identical hash codes. If value types do not override <xref:System.Object.GetHashCode%2A>, the <xref:System.ValueType.GetHashCode%2A?displayProperty=nameWithType> method of the base class uses reflection to compute the hash code based on the values of the type's fields. In other words, value types whose fields have equal values have equal hash codes. For more information about overriding <xref:System.Object.GetHashCode%2A>, see the "Notes to Inheritors" section.

> [!WARNING]
> If you override the <xref:System.Object.GetHashCode%2A> method, you should also override <xref:System.Object.Equals%2A>, and vice versa. If your overridden <xref:System.Object.Equals%2A> method returns `true` when two objects are tested for equality, your overridden <xref:System.Object.GetHashCode%2A> method must return the same value for the two objects.

If an object that is used as a key in a hash table does not provide a useful implementation of <xref:System.Object.GetHashCode%2A>, you can specify a hash code provider by supplying an <xref:System.Collections.IEqualityComparer> implementation to one of the overloads of the <xref:System.Collections.Hashtable> class constructor.

## Notes for the Windows Runtime

When you call the <xref:System.Object.GetHashCode%2A> method on a class in the Windows Runtime, it provides the default behavior for classes that don't override <xref:System.Object.GetHashCode%2A>. This is part of the support that .NET provides for the Windows Runtime (see [.NET Support for Windows Store Apps and Windows Runtime](/dotnet/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime)). Classes in the Windows Runtime don't inherit <xref:System.Object>, and currently don't implement a <xref:System.Object.GetHashCode%2A>. However, they appear to have <xref:System.Object.ToString%2A>, <xref:System.Object.Equals(System.Object)>, and <xref:System.Object.GetHashCode%2A> methods when you use them in your C# or Visual Basic code, and the .NET Framework provides the default behavior for these methods.

> [!NOTE]
> Windows Runtime classes that are written in C# or Visual Basic can override the <xref:System.Object.GetHashCode%2A> method.

## Examples

One of the simplest ways to compute a hash code for a numeric value that has the same or a smaller range than the <xref:System.Int32> type is to simply return that value. The following example shows such an implementation for a `Number` structure.

:::code language="csharp" source="./snippets/System/Object/GetHashCode/csharp/direct1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Object/GetHashCode/fsharp/direct1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Object/GetHashCode/vb/direct1.vb" id="Snippet1":::

Frequently, a type has multiple data fields that can participate in generating the hash code. One way to generate a hash code is to combine these fields using an `XOR (eXclusive OR)` operation, as shown in the following example.

:::code language="csharp" source="./snippets/System/Object/GetHashCode/csharp/xor1.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Object/GetHashCode/fsharp/xor1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Object/GetHashCode/vb/xor1.vb" id="Snippet2":::

The previous example returns the same hash code for (n1, n2) and (n2, n1), and so may generate more collisions than are desirable. A number of solutions are available so that hash codes in these cases are not identical. One is to return the hash code of a `Tuple` object that reflects the order of each field. The following example shows a possible implementation that uses the <xref:System.Tuple%602> class. Note, though, that the performance overhead of instantiating a `Tuple` object may significantly impact the overall performance of an application that stores large numbers of objects in hash tables.

:::code language="csharp" source="./snippets/System/Object/GetHashCode/csharp/xor2.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Object/GetHashCode/fsharp/xor2.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Object/GetHashCode/vb/xor2.vb" id="Snippet3":::

A second alternative solution involves weighting the individual hash codes by left-shifting the hash codes of successive fields by two or more bits. Optimally, bits shifted beyond bit 31 should wrap around rather than be discarded. Since bits are discarded by the left-shift operators in both C# and Visual Basic, this requires creating a left shift-and-wrap method like the following:

:::code language="csharp" source="./snippets/System/Object/GetHashCode/csharp/shift1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Object/GetHashCode/fsharp/shift1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Object/GetHashCode/vb/shift1.vb" id="Snippet4":::

The following example then uses this shift-and-wrap method to compute the hash code of the `Point` structure used in the previous examples.

:::code language="csharp" source="./snippets/System/Object/GetHashCode/csharp/shift1.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Object/GetHashCode/fsharp/shift1.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/Object/GetHashCode/vb/shift1.vb" id="Snippet5":::
