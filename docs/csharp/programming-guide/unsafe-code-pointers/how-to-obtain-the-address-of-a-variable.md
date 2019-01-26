---
title: "How to: obtain the address of a variable - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "variables [C#], address of"
  - "pointers [C#], & operator"
  - "pointer expressions [C#], address-of operator"
ms.assetid: 44fe2cd9-a64f-4ef5-be2a-09ce807c0182
---
# How to: obtain the address of a variable (C# Programming Guide)

To obtain the address of a unary expression, which evaluates to a fixed variable, use the address-of operator `&`:  
  
```csharp  
int number;  
int* p = &number; //address-of operator &  
```  
  
 The address-of operator can only be applied to a variable. If the variable is a moveable variable, you can use the [fixed statement](../../../csharp/language-reference/keywords/fixed-statement.md) to temporarily fix the variable before obtaining its address.  
  
 It's your responsibility to ensure that the variable is initialized. The compiler doesn't issue an error message if the variable is not initialized.  
  
 You can't get the address of a constant or a value.  
  
## Example  
 In this example, a pointer to `int`, `p`, is declared and assigned the address of an integer variable, `number`. The variable `number` is initialized as a result of the assignment to `*p`. If you comment out this assignment statement, the initialization of the variable `number` is removed, but no compile-time error is issued.  

> [!NOTE]
> Compile this example with the [`-unsafe`](../../language-reference/compiler-options/unsafe-compiler-option.md) compiler option.
  
 [!code-csharp[address-of-a-variable](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#8)]  
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)
- [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)
- [Types](../../../csharp/language-reference/keywords/types.md)
- [unsafe](../../../csharp/language-reference/keywords/unsafe.md)
- [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)
- [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
