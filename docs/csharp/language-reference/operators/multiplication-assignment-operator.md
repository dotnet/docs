---
title: "*= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "*=_CSharpKeyword"
helpviewer_keywords: 
  - "*= operator [C#]"
  - "binary multiplication assignment operator (*=) [C#]"
ms.assetid: 2e472155-59db-4dbf-bb94-bcccfa1a794d
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# *= Operator (C# Reference)
The binary multiplication assignment operator.  
  
## Remarks  
 An expression using the `*=` assignment operator, such as  
  
```  
x *= y  
```  
  
 is equivalent to  
  
```  
x = x * y  
```  
  
 except that `x` is only evaluated once. The [* operator](../../../csharp/language-reference/operators/multiplication-operator.md) is predefined for numeric types to perform multiplication.  
  
 The `*=` operator cannot be overloaded directly, but user-defined types can overload the [* operator](../../../csharp/language-reference/operators/multiplication-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#13](../../../csharp/language-reference/operators/codesnippet/CSharp/multiplication-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
