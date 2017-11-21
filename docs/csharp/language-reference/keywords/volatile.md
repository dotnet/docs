---
title: "volatile (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "volatile_CSharpKeyword"
  - "volatile"
helpviewer_keywords: 
  - "volatile keyword [C#]"
ms.assetid: 78089bc7-7b38-4cfd-9e49-87ac036af009
caps.latest.revision: 29
author: "BillWagner"
ms.author: "wiwagn"
---
# volatile (C# Reference)
The `volatile` keyword indicates that a field might be modified by multiple threads that are executing at the same time. Fields that are declared `volatile` are not subject to compiler optimizations that assume access by a single thread. This ensures that the most up-to-date value is present in the field at all times.  
  
 The `volatile` modifier is usually used for a field that is accessed by multiple threads without using the [lock](../../../csharp/language-reference/keywords/lock-statement.md) statement to serialize access.  
  
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
  
 [!code-csharp[csrefKeywordsModifiers#24](../../../csharp/language-reference/keywords/codesnippet/CSharp/volatile_1.cs)]  
  
## Example  
 The following example demonstrates how an auxiliary or worker thread can be created and used to perform processing in parallel with that of the primary thread. For background information about multithreading, see [Threading](../../../standard/threading/index.md) and [Threading](../../programming-guide/concepts/threading/index.md).  
  
 [!code-csharp[csProgGuideThreading#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/volatile_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)
