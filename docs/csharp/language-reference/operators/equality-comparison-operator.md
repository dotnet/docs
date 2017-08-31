---
title: "== Operator (C# Reference) | Microsoft Docs"
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
  - "==_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "== operator [C#]"
  - "equality operator [C#]"
ms.assetid: 34c6b597-caa2-4855-a7cd-38ecdd11bd07
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# == Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

For predefined value types, the equality operator (`==`) returns true if the values of its operands are equal, `false` otherwise. For reference types other than [string](../../../csharp/language-reference/keywords/string.md), `==` returns `true` if its two operands refer to the same object. For the `string` type, `==` compares the values of the strings.  
  
## Remarks  
 User-defined value types can overload the `==` operator (see [operator](../../../csharp/language-reference/keywords/operator-csharp-reference.md)). So can user-defined reference types, although by default `==` behaves as described above for both predefined and user-defined reference types. If `==` is overloaded, [!=](../../../csharp/language-reference/operators/not-equal-operator.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#36](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#36)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)