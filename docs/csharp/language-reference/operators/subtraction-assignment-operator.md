---
title: "-= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "-=_CSharpKeyword"
helpviewer_keywords: 
  - "subtraction assignment operator (-=) [C#]"
  - "-= operator (subtraction assignment ) [C#]"
ms.assetid: 05c7d68a-423f-4de8-891b-cf24e8fb6ed7
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# -= Operator (C# Reference)
The subtraction assignment operator.  
  
## Remarks  
 An expression using the `-=` assignment operator, such as  
  
```  
x -= y  
```  
  
 is equivalent to  
  
```  
x = x - y  
```  
  
 except that `x` is only evaluated once. The meaning of the [- operator](../../../csharp/language-reference/operators/subtraction-operator.md) is dependent on the types of `x` and `y` (subtraction for numeric operands, delegate removal for delegate operands, and so forth).  
  
 The `-=` operator cannot be overloaded directly, but user-defined types can overload the [- operator](../../../csharp/language-reference/operators/subtraction-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
 The -= operator is also used in C# to unsubscribe from an event. For more information, see [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).  
  
## Example  
 [!code-csharp[csRefOperators#6](codesnippet/CSharp/subtraction-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
