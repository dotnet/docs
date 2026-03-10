---
description: "unsafe keyword - C# Reference"
title: "unsafe keyword"
ms.date: 01/22/2026
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

## Example

:::code language="csharp" source="./snippets/csrefKeywordsModifiers.cs" id="22":::

## C# language specification

For more information, see [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# keywords](index.md)
- [`fixed` statement](../statements/fixed.md)
- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
- [Pointer related operators](../operators/pointer-related-operators.md)
