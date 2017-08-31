---
title: "&amp; Operator (C# Reference) | Microsoft Docs"
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
  - "&_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "bitwise AND operator [C#]"
  - "ampersand operator (&) [C#]"
  - "& operator [C#]"
  - "AND operator (&) [C#]"
ms.assetid: afa346d5-90ec-4b1f-a2c8-3881f018741d
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# &amp; Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The & operator can function as either a unary or a binary operator.  
  
## Remarks  
 The unary & operator returns the address of its operand (requires [unsafe](../../../csharp/language-reference/keywords/unsafe.md) context).  
  
 Binary & operators are predefined for the integral types and `bool`. For integral types, & computes the logical bitwise AND of its operands. For `bool` operands, & computes the logical AND of its operands; that is, the result is `true` if and only if both its operands are `true`.  
  
 The `&` operator evaluates both operators regardless of the first one's value. For example:  
  
 [!code-csharp[csRefOperators#37](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#37)]  
  
 User-defined types can overload the binary `&` operator (see [operator](../../../csharp/language-reference/keywords/operator-csharp-reference.md)). Operations on integral types are generally allowed on enumeration. When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#38](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#38)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)