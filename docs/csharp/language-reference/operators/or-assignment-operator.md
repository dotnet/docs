---
title: "|= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "|=_CSharpKeyword"
helpviewer_keywords: 
  - "OR assignment operator (|=) [C#]"
  - "|= operator (OR assignment) [C#]"
ms.assetid: 8315b8cf-dd15-402f-92f0-c7db931696ca
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# |= Operator (C# Reference)
The OR assignment operator.  
  
## Remarks  
 An expression using the `|=` assignment operator, such as  
  
```  
x |= y  
```  
  
 is equivalent to  
  
```  
x = x | y  
```  
  
 except that `x` is only evaluated once. The [&#124; operator](../../../csharp/language-reference/operators/or-operator.md) performs a bitwise logical OR operation on integral operands and logical OR on bool operands.  
  
 The `|=` operator cannot be overloaded directly, but user-defined types can overload the [&#124; operator](../../../csharp/language-reference/operators/or-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#10](../../../csharp/language-reference/operators/codesnippet/CSharp/or-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
