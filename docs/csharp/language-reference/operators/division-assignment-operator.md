---
title: "/= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/=_CSharpKeyword"
helpviewer_keywords: 
  - "division assignment operator (/=) [C#]"
  - "/= (division assignment operator) [C#]"
ms.assetid: 50fc02b0-ee9c-4c3e-b58d-d591282caf1c
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# /= Operator (C# Reference)
The division assignment operator.  
  
## Remarks  
 An expression using the `/=` assignment operator, such as  
  
```  
x /= y  
```  
  
 is equivalent to  
  
```  
x = x / y  
```  
  
 except that `x` is only evaluated once. The [/ operator](../../../csharp/language-reference/operators/division-operator.md) is predefined for numeric types to perform division.  
  
 The `/=` operator cannot be overloaded directly, but user-defined types can overload the [/ operator](../../../csharp/language-reference/operators/division-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)). On all compound assignment operators, overloading the binary operator implicitly overloads the equivalent compound assignment.  
  
## Example  
 [!code-csharp[csRefOperators#5](codesnippet/CSharp/division-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
