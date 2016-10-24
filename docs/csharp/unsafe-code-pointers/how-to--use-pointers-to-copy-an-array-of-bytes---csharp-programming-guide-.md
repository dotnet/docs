---
title: "How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "byte arrays [C#]"
  - "arrays [C#], byte"
  - "pointers [C#], to copy bytes"
ms.assetid: ec16fbb4-a24e-45f5-a763-9499d3fabe0a
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Use Pointers to Copy an Array of Bytes  (C# Programming Guide)
The following example uses pointers to copy bytes from one array to another.  
  
 This example uses the [unsafe](../keywords/unsafe--csharp-reference-.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](../keywords/fixed-statement--csharp-reference-.md) statement is used to declare pointers to the source and destination arrays. This *pins* the location of the source and destination arrays in memory so that they will not be moved by garbage collection. The memory blocks for the arrays are unpinned when the `fixed` block is completed. Because the `Copy` method in this example uses the `unsafe` keyword, it must be compiled with the **/unsafe** compiler option. To set the option in Visual Studio, right-click the project name, and then click **Properties**. On the **Build** tab, select **Allow unsafe code**.  
  
## Example  
 [!code[csProgGuidePointers#3](../unsafe-code-pointers/codesnippet/CSharp/how-to--use-pointers-to-copy-an-array-of-bytes---csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#18](../unsafe-code-pointers/codesnippet/CSharp/how-to--use-pointers-to-copy-an-array-of-bytes---csharp-programming-guide-_2.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Unsafe Code and Pointers](../unsafe-code-pointers/unsafe-code-and-pointers--csharp-programming-guide-.md)   
 [/unsafe (C# Compiler Options)](../compiler-options/-unsafe--csharp-compiler-options-.md)   
 [Garbage Collection](../Topic/Garbage%20Collection.md)