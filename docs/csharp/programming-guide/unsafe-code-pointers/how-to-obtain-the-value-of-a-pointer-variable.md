---
title: "How to: Obtain the Value of a Pointer Variable (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "pointer expressions [C#], indirection"
  - "pointers [C#], indirection"
  - "variables [C#], pointers"
  - "pointers [C#], * operator"
ms.assetid: 460a813a-4995-44c1-9de2-213b91dc7668
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Obtain the Value of a Pointer Variable (C# Programming Guide)
Use the pointer indirection operator to obtain the variable at the location pointed to by a pointer. The expression takes the following form, where `p` is a pointer type:  
  
```  
*p;  
```  
  
 You cannot use the unary indirection operator on an expression of any type other than the pointer type. Also, you cannot apply it to a [void](../../../csharp/language-reference/keywords/void.md) pointer.  
  
 When you apply the indirection operator to a [null](../../../csharp/language-reference/keywords/null.md) pointer, the result depends on the implementation.  
  
## Example  
 In the following example, a variable of the type `char` is accessed by using pointers of different types. Note that the address of `theChar` will vary from run to run, because the physical address allocated to a variable can change.  
  
 [!code-csharp[csProgGuidePointers#5](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-obtain-the-value-of-a-pointer-variable_1.cs)]  
  
 [!code-csharp[csProgGuidePointers#6](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/how-to-obtain-the-value-of-a-pointer-variable_2.cs)]  
  
 **Value of theChar = Z**  
**Address of theChar = 12F718**  
**Value of pChar = Z**   
**Value of pInt = 90**    
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)  
 [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)  
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
