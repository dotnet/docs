---
description: Learn about unmanaged types in C#
title: "Unmanaged types - C# reference"
ms.date: 09/06/2019
helpviewer_keywords: 
  - "unmanaged type [C#]"
---
# Unmanaged types (C# reference)

A type is an **unmanaged type** if it's any of the following types:

- `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, `double`, `decimal`, or `bool`
- Any [enum](enum.md) type
- Any [pointer](../unsafe-code.md#pointer-types) type
- Any user-defined [struct](struct.md) type that contains fields of unmanaged types only and, in C# 7.3 and earlier, is not a constructed type (a type that includes at least one type argument)

Beginning with C# 7.3, you can use the [`unmanaged` constraint](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to specify that a type parameter is a non-pointer, non-nullable unmanaged type.

Beginning with C# 8.0, a *constructed* struct type that contains fields of unmanaged types only is also unmanaged, as the following example shows:

[!code-csharp[unmanaged constructed types](snippets/shared/UnmanagedTypes.cs#ProgramExample)]

A generic struct may be the source of both unmanaged and not unmanaged constructed types. The preceding example defines a generic struct `Coords<T>` and presents the examples of unmanaged constructed types. The example of not an unmanaged type is `Coords<object>`. It's not unmanaged because it has the fields of the `object` type, which is not unmanaged. If you want *all* constructed types to be unmanaged types, use the `unmanaged` constraint in the definition of a generic struct:

[!code-csharp[unmanaged constraint in type definition](snippets/shared/UnmanagedTypes.cs#AlwaysUnmanaged)]

## C# language specification

For more information, see the [Pointer types](~/_csharplang/spec/unsafe-code.md#pointer-types) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [sizeof operator](../operators/sizeof.md)
- [stackalloc](../operators/stackalloc.md)
