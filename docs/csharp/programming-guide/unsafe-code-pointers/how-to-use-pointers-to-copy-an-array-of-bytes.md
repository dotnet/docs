---
title: "How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "byte arrays [C#]"
  - "arrays [C#], byte"
  - "pointers [C#], to copy bytes"
ms.assetid: ec16fbb4-a24e-45f5-a763-9499d3fabe0a
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)
The following example uses pointers to copy bytes from one array to another.  
  
 This example uses the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](../../../csharp/language-reference/keywords/fixed-statement.md) statement is used to declare pointers to the source and destination arrays. This *pins* the location of the source and destination arrays in memory so that they will not be moved by garbage collection. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the **/unsafe** compiler option. To set the option in Visual Studio, right-click the project name, and then click **Properties**. On the **Build** tab, select **Allow unsafe code**.  
  
## Example  
 [!code-csharp[csProgGuidePointers#3](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-use-pointers-to-copy-an-array-of-bytes_1.cs)]  
  
 [!code-csharp[csProgGuidePointers#18](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-use-pointers-to-copy-an-array-of-bytes_2.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)  
 [/unsafe (C# Compiler Options)](../../../csharp/language-reference/compiler-options/unsafe-compiler-option.md)  
 [Garbage Collection](../../../standard/garbage-collection/index.md)
