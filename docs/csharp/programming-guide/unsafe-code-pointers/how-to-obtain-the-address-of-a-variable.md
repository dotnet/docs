---
title: "How to: Obtain the Address of a Variable (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "variables [C#], address of"
  - "pointers [C#], & operator"
  - "pointer expressions [C#], address-of operator"
ms.assetid: 44fe2cd9-a64f-4ef5-be2a-09ce807c0182
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Obtain the Address of a Variable (C# Programming Guide)
To obtain the address of a unary expression, which evaluates to a fixed variable, use the address-of operator:  
  
```  
int number;  
int* p = &number; //address-of operator &  
```  
  
 The address-of operator can only be applied to a variable. If the variable is a moveable variable, you can use the [fixed statement](../../../csharp/language-reference/keywords/fixed-statement.md) to temporarily fix the variable before obtaining its address.  
  
 It is your responsibility to ensure that the variable is initialized. The compiler will not issue an error message if the variable is not initialized.  
  
 You cannot get the address of a constant or a value.  
  
## Example  
 In this example, a pointer to `int`, `p`, is declared and assigned the address of an integer variable, `number`. The variable `number` is initialized as a result of the assignment to *p. If you make this assignment statement a comment, the initialization of the variable `number` will be removed, but no compile-time error is issued. Notice the use of the [Member Access](../../../csharp/programming-guide/unsafe-code-pointers/how-to-access-a-member-with-a-pointer.md) operator `->` to obtain and display the address stored in the pointer.  
  
 [!code-csharp[csProgGuidePointers#7](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-obtain-the-address-of-a-variable_1.cs)]  
  
 [!code-csharp[csProgGuidePointers#8](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-obtain-the-address-of-a-variable_2.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)  
 [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)  
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
