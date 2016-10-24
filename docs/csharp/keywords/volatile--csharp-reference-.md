---
title: "volatile (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "volatile_CSharpKeyword"
  - "volatile"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "volatile keyword [C#]"
ms.assetid: 78089bc7-7b38-4cfd-9e49-87ac036af009
caps.latest.revision: 29
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
# volatile (C# Reference)
The `volatile` keyword indicates that a field might be modified by multiple threads that are executing at the same time. Fields that are declared `volatile` are not subject to compiler optimizations that assume access by a single thread. This ensures that the most up-to-date value is present in the field at all times.  
  
 The `volatile` modifier is usually used for a field that is accessed by multiple threads without using the [lock](../keywords/lock-statement--csharp-reference-.md) statement to serialize access.  
  
 The `volatile` keyword can be applied to fields of these types:  
  
-   Reference types.  
  
-   Pointer types (in an unsafe context). Note that although the pointer itself can be volatile, the object that it points to cannot. In other words, you cannot declare a "pointer to volatile."  
  
-   Types such as sbyte, byte, short, ushort, int, uint, char, float, and bool.  
  
-   An enum type with one of the following base types: byte, sbyte, short, ushort, int, or uint.  
  
-   Generic type parameters known to be reference types.  
  
-   <xref:System.IntPtr> and <xref:System.UIntPtr>.  
  
 The volatile keyword can only be applied to fields of a class or struct. Local variables cannot be declared `volatile`.  
  
## Example  
 The following example shows how to declare a public field variable as `volatile`.  
  
 [!code[csrefKeywordsModifiers#24](../keywords/codesnippet/CSharp/volatile--csharp-reference-_1.cs)]  
  
## Example  
 The following example demonstrates how an auxiliary or worker thread can be created and used to perform processing in parallel with that of the primary thread. For background information about multithreading, see [Threading](../Topic/Managed%20Threading.md) and [Threading](../Topic/Threading%20\(C%23%20and%20Visual%20Basic\).md).  
  
 [!code[csProgGuideThreading#1](../keywords/codesnippet/CSharp/volatile--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)