---
title: "Pointer Conversions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "pointers [C#], conversions"
ms.assetid: f0e87502-477a-4ede-a31f-7a3e262e46fb
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# Pointer Conversions (C# Programming Guide)
The following table shows the predefined implicit pointer conversions. Implicit conversions might occur in many situations, including method invoking and assignment statements.  
  
## Implicit pointer conversions  
  
|From|To|  
|----------|--------|  
|Any pointer type|void*|  
|null|Any pointer type|  
  
 Explicit pointer conversion is used to perform conversions, for which there is no implicit conversion, by using a cast expression. The following table shows these conversions.  
  
## Explicit pointer conversions  
  
|From|To|  
|----------|--------|  
|Any pointer type|Any other pointer type|  
|sbyte, byte, short, ushort, int, uint, long, or ulong|Any pointer type|  
|Any pointer type|sbyte, byte, short, ushort, int, uint, long, or ulong|  
  
## Example  
 In the following example, a pointer to `int` is converted to a pointer to `byte`. Notice that the pointer points to the lowest addressed byte of the variable. When you successively increment the result, up to the size of `int` (4 bytes), you can display the remaining bytes of the variable.  
  
 [!code-csharp[csProgGuidePointers#3](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/pointer-conversions_1.cs)]  
  
 [!code-csharp[csProgGuidePointers#4](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/pointer-conversions_2.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)  
 [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)  
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
