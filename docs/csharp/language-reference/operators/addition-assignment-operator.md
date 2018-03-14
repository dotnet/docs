---
title: "+= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "+=_CSharpKeyword"
helpviewer_keywords: 
  - "+= operator [C#]"
  - "addition assignment operator (+=) [C#]"
ms.assetid: 9cdf97e6-331d-492b-85e1-3ec3171484e9
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# += Operator (C# Reference)
The addition assignment operator.  
  
## Remarks  
 An expression using the `+=` assignment operator, such as  
  
```  
x += y  
```  
  
 is equivalent to  
  
```  
x = x + y  
```  
  
 except that `x` is only evaluated once. The meaning of the [+ operator](../../../csharp/language-reference/operators/addition-operator.md) depends on the types of `x` and `y` (addition for numeric operands, concatenation for string operands, and so forth).  
  
 The `+=` operator cannot be overloaded directly, but user-defined types can overload the [+ operator](../../../csharp/language-reference/operators/addition-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
 The `+=` operator is also used to specify a method that will be called in response to an event; such methods are called event handlers. The use of the `+=` operator in this context is referred to as *subscribing to an event*. For more information, see [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md) and [Delegates](../../../csharp/programming-guide/delegates/index.md).  
  
## Example  
 [!code-csharp[csRefOperators#35](../../../csharp/language-reference/operators/codesnippet/CSharp/addition-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
