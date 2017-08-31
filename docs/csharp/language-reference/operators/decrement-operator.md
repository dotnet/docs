---
title: "-- Operator (C# Reference) | Microsoft Docs"
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
  - "--_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "-- operator [C#]"
  - "decrement operator (--) [C#]"
ms.assetid: 6b9cfe86-63c7-421f-9379-c9690fea8720
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# -- Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The decrement operator (`--`) decrements its operand by 1. The decrement operator can appear before or after its operand: `--variable` and `variable--`. The first form is a prefix decrement operation. The result of the operation is the value of the operand "after" it has been decremented. The second form is a postfix decrement operation. The result of the operation is the value of the operand "before" it has been decremented.  
  
## Remarks  
 Numeric and enumeration types have predefined decrement operators.  
  
 User-defined types can overload the `--` operator (see [operator](../../../csharp/language-reference/keywords/operator-csharp-reference.md)). Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#8](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#8)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)