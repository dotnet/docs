---
title: "! Operator (C# Reference) | Microsoft Docs"
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
  - "!_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "! operator [C#]"
  - "logical negation operator (!) [C#]"
  - "NOT operator [C#]"
ms.assetid: f5ae133f-8f64-4560-b34f-cd9cd5eed4ad
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# ! Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The logical negation operator (`!`) is a unary operator that negates its operand. It is defined for `bool` and returns `true` if and only if its operand is `false`.  
  
## Remarks  
 User-defined types can overload the `!` operator (see [operator](../../../csharp/language-reference/keywords/operator-csharp-reference.md)).  
  
## Example  
 [!code-csharp[csRefOperators#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#7)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)