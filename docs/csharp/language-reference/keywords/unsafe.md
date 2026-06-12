---
description: "unsafe keyword - C# Reference"
title: "unsafe keyword"
ms.date: 06/16/2026
f1_keywords:
  - "unsafe_CSharpKeyword"
  - "unsafe"
helpviewer_keywords:
  - "unsafe keyword [C#]"
---
# unsafe (C# Reference)

The `unsafe` keyword denotes an unsafe context, which is required for any operation involving pointers. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Use the `unsafe` modifier in the declaration of a type or a member. The entire textual extent of the type or member is an unsafe context. For example, the following method is declared with the `unsafe` modifier:

```csharp
unsafe static void FastCopy(byte[] src, byte[] dst, int count)
{
    // Unsafe context: can use pointers here.
}
```

The scope of the unsafe context extends from the parameter list to the end of the method, so you can also use pointers in the parameter list:

```csharp
unsafe static void FastCopy ( byte* ps, byte* pd, int count ) {...}
```

You can also use an unsafe block to enable the use of unsafe code inside this block. For example:

```csharp
unsafe
{
    // Unsafe context: can use pointers here.
}
```

To compile unsafe code, you must specify the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option. The common language runtime can't verify unsafe code.

> [!NOTE]
> Beginning with C# 15, the [memory safety](../unsafe-code.md#memory-safety-preview) preview feature narrows the operations that require an `unsafe` context. Creating a pointer, the `fixed` statement, and converting a `stackalloc` to a pointer no longer require an `unsafe` context. Only operations that access the pointed-to memory, such as pointer indirection, do. A later preview also changes `unsafe` on a member to mark it as *requires-unsafe*, so callers must use the member from an `unsafe` context.

## Example

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="22":::

## C# language specification

For more information, see [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# keywords](index.md)
- [`fixed` statement](../statements/fixed.md)
- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
- [Pointer related operators](../operators/pointer-related-operators.md)
