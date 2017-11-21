---
title: "&gt;&gt;= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - ">>=_CSharpKeyword"
helpviewer_keywords: 
  - "right shift assignment operator (>>=) [C#]"
  - ">>= operator (right-shift assignment) [C#]"
ms.assetid: b593778c-b9b4-440d-8b29-c1ac22cb81c0
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# &gt;&gt;= Operator (C# Reference)
The right-shift assignment operator.  
  
## Remarks  
 An expression of the form  
  
```  
x >>= y  
```  
  
 is evaluated as  
  
```  
x = x >> y  
```  
  
 except that `x` is only evaluated once. The [>> operator](../../../csharp/language-reference/operators/right-shift-operator.md) shifts `x` right by an amount specified by `y`.  
  
 The >>= operator cannot be overloaded directly, but user-defined types can overload the [>> operator](../../../csharp/language-reference/operators/right-shift-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#11](../../../csharp/language-reference/operators/codesnippet/CSharp/right-shift-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
