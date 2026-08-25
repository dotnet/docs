---
description: Learn about unmanaged types in C#
title: "Unmanaged types"
ms.date: 01/14/2026
helpviewer_keywords: 
  - "unmanaged type [C#]"
---
# Unmanaged types (C# reference)

A type is an **unmanaged type** if it's any of the following types:

- `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `nint`, `nuint`, `char`, `float`, `double`, `decimal`, or `bool`
- Any [enum](enum.md) type
- Any [pointer](../unsafe-code.md#pointer-types) type
- A [tuple](value-tuples.md) whose members are all of an unmanaged type
- Any user-defined [struct](struct.md) type that contains fields of unmanaged types only.

You can use the [`unmanaged` constraint](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to specify that a type parameter is a non-pointer, non-nullable unmanaged type.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

A *constructed* struct type that contains fields of unmanaged types only is also unmanaged, as the following example shows:

:::code language="csharp" source="snippets/shared/UnmanagedTypes.cs" id="ProgramExample":::

A generic struct can define both unmanaged and managed constructed types. The preceding example defines a generic struct `Coords<T>` and presents examples of unmanaged constructed types. The example of a managed type is `Coords<object>`. It's managed because it has the fields of the `object` type, which is managed. If you want *all* constructed types to be unmanaged types, use the `unmanaged` constraint in the definition of a generic struct:

:::code language="csharp" source="snippets/shared/UnmanagedTypes.cs" id="AlwaysUnmanaged":::

## C# language specification

For more information, see the [Pointer types](~/_csharpstandard/standard/unsafe-code.md#243-pointer-types) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [sizeof operator](../operators/sizeof.md)
- [stackalloc](../operators/stackalloc.md)
