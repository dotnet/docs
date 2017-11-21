---
title: "&amp;= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "&=_CSharpKeyword"
helpviewer_keywords: 
  - "AND assignment operator (&=) [C#]"
  - "&= operator [C#]"
ms.assetid: e8d58f3f-72dd-4b5a-b995-452fcce7e6bb
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# &amp;= Operator (C# Reference)
The AND assignment operator.  
  
## Remarks  
 An expression using the `&=` assignment operator, such as  
  
```  
x &= y  
```  
  
 is equivalent to  
  
```  
x = x & y  
```  
  
 except that `x` is only evaluated once. The [& operator](../../../csharp/language-reference/operators/and-operator.md) performs a bitwise logical AND operation on integral operands and logical AND on `bool` operands.  
  
 The `&=` operator cannot be overloaded directly, but user-defined types can overload the binary [& operator](../../../csharp/language-reference/operators/and-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#34](../../../csharp/language-reference/operators/codesnippet/CSharp/and-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
