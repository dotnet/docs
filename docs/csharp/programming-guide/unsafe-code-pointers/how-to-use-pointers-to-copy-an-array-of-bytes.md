---
title: "How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)"
ms.date: 04/20/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "byte arrays [C#]"
  - "arrays [C#], byte"
  - "pointers [C#], to copy bytes"
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)

The following example uses pointers to copy bytes from one array to another.

This example uses the [unsafe](../../language-reference/keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](../../language-reference/keywords/fixed-statement.md) statement is used to declare pointers to the source and destination arrays. This *pins* the location of the source and destination arrays in memory so that they will not be moved by garbage collection. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the **/unsafe** compiler option. To set the option in Visual Studio, right-click the project name, and then click **Properties**. On the **Build** tab, select **Allow unsafe code**.

## Example

[!code-csharp[Struct with embedded inline array](../../../../samples/snippets/csharp/keywords/FixedKeywordExamples.cs#8)]

## See Also
 [C# Programming Guide](../index.md)  
 [Unsafe Code and Pointers](index.md)  
 [/unsafe (C# Compiler Options)](../../language-reference/compiler-options/unsafe-compiler-option.md)  
 [Garbage Collection](../../../standard/garbage-collection/index.md)  
