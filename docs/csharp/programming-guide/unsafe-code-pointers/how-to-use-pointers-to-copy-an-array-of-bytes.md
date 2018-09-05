---
title: "How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)"
ms.date: 04/20/2018
helpviewer_keywords: 
  - "byte arrays [C#]"
  - "arrays [C#], byte"
  - "pointers [C#], to copy bytes"
---
# How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)

The following example uses pointers to copy bytes from one array to another.

This example uses the [unsafe](../../language-reference/keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](../../language-reference/keywords/fixed-statement.md) statement is used to declare pointers to the source and destination arrays. The `fixed` statement *pins* the location of the source and destination arrays in memory so that they will not be moved by garbage collection. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the [-unsafe](../../language-reference/compiler-options/unsafe-compiler-option.md) compiler option.

This example accesses the elements of both arrays using indices rather than a second unmanaged pointer. The declaration of the `pSource` and `pTarget` pointers pins the arrays. This feature is available starting with C# 7.3.

## Example

[!code-csharp[Struct with embedded inline array](../../../../samples/snippets/csharp/keywords/FixedKeywordExamples.cs#8)]

## See Also

- [C# Programming Guide](../index.md)  
- [Unsafe Code and Pointers](index.md)  
- [-unsafe (C# Compiler Options)](../../language-reference/compiler-options/unsafe-compiler-option.md)  
- [Garbage Collection](../../../standard/garbage-collection/index.md)  
