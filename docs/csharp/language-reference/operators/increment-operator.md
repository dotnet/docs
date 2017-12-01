---
title: "++ Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "++_CSharpKeyword"
helpviewer_keywords: 
  - "increment operator (++) [C#]"
  - "++ operator [C#]"
ms.assetid: e9dec353-070b-44fb-98ed-eb8fdf753feb
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# ++ Operator (C# Reference)
The increment operator (`++`) increments its operand by 1. The increment operator can appear before or after its operand: `++variable` and `variable++`.  
  
## Remarks  
 The first form is a prefix increment operation. The result of the operation is the value of the operand after it has been incremented.  
  
 The second form is a postfix increment operation. The result of the operation is the value of the operand before it has been incremented.  
  
 Numeric and enumeration types have predefined increment operators. User-defined types can overload the `++` operator. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#3](../../../csharp/language-reference/operators/codesnippet/CSharp/increment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
