---
description: "unsafe keyword - C# Reference"
title: "unsafe keyword - C# Reference"
ms.date: 07/20/2015
f1_keywords:
  - "unsafe_CSharpKeyword"
  - "unsafe"
helpviewer_keywords:
  - "unsafe keyword [C#]"
ms.assetid: 7e818009-1c6e-4b9e-b769-3728a01586a0
---
# unsafe (C# Reference)

The `unsafe` keyword denotes an unsafe context, which is required for any operation involving pointers. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

You can use the `unsafe` modifier in the declaration of a type or a member. The entire textual extent of the type or member is therefore considered an unsafe context. For example, the following is a method declared with the `unsafe` modifier:

```csharp
unsafe static void FastCopy(byte[] src, byte[] dst, int count)
{
    // Unsafe context: can use pointers here.
}
```

The scope of the unsafe context extends from the parameter list to the end of the method, so pointers can also be used in the parameter list:

```csharp
unsafe static void FastCopy ( byte* ps, byte* pd, int count ) {...}
```

You can also use an unsafe block to enable the use of an unsafe code inside this block. For example:

```csharp
unsafe
{
    // Unsafe context: can use pointers here.
}
```

To compile unsafe code, you must specify the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option. Unsafe code is not verifiable by the common language runtime.

## Example

[!code-csharp[csrefKeywordsModifiers#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#22)]

## C# language specification

For more information, see [Unsafe code](~/_csharplang/spec/unsafe-code.md) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [fixed Statement](fixed-statement.md)
- [Unsafe Code and Pointers](../unsafe-code.md)
- [Fixed Size Buffers](../unsafe-code.md#fixed-size-buffers)
