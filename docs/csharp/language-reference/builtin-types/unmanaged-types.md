---
title: "Unmanaged types - C# reference"
ms.date: 07/23/2019
helpviewer_keywords: 
  - "unmanaged type [C#]"
---
# Unmanaged types (C# reference)

An **unmanaged type** is any type that isn't a reference type or constructed type (a type that includes at least one type argument), and doesn't contain reference type or constructed type fields at any level of nesting. In other words, an unmanaged type is one of the following:

- `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, `double`, `decimal`, or `bool`
- Any [enum](../keywords/enum.md) type
- Any [pointer](../../programming-guide/unsafe-code-pointers/pointer-types.md) type
- Any user-defined [struct](../keywords/struct.md) type that is not a constructed type and contains fields of unmanaged types only

Beginning with C# 7.3, you can use the [`unmanaged` constraint](../../programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint) to specify that a type parameter is a non-pointer unmanaged type.

## C# language specification

For more information, see the [Pointer types](~/_csharplang/spec/unsafe-code.md#pointer-types) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
- [Memory and span-related types](../../../standard/memory-and-spans/index.md)
- [sizeof operator](../operators/sizeof.md)
- [stackalloc operator](../operators/stackalloc.md)
