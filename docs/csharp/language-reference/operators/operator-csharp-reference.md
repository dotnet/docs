---
title: "- Operator (C# Reference)2 | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "-_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "- operator [C#]"
  - "subtraction operator (-) [C#]"
ms.assetid: 4de7a4fa-c69d-48e6-aff1-3130af970b2d
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# - Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `-` operator can function as either a unary or a binary operator.  
  
## Remarks  
 Unary `-` operators are predefined for all numeric types. The result of a unary `-` operation on a numeric type is the numeric negation of the operand.  
  
 Binary `-` operators are predefined for all numeric and enumeration types to subtract the second operand from the first.  
  
 Delegate types also provide a binary `-` operator, which performs delegate removal.  
  
 User-defined types can overload the unary `-` and binary `-` operators. For more information, see [operator (C# Reference)](../../../csharp/language-reference/keywords/operator-csharp-reference.md).  
  
## Example  
 [!code-csharp[csRefOperators#40](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#40)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)