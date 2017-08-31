---
title: "+ Operator (C# Reference) | Microsoft Docs"
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
  - "+_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "+ operator [C#]"
  - "concatenation operator [C#]"
  - "addition operator [C#]"
ms.assetid: 93e56486-bb42-43c1-bd43-60af11e64e67
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# + Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `+` operator can function as either a unary or a binary operator.  
  
## Remarks  
 Unary `+` operators are predefined for all numeric types. The result of a unary `+` operation on a numeric type is just the value of the operand.  
  
 Binary `+` operators are predefined for numeric and string types. For numeric types, + computes the sum of its two operands. When one or both operands are of type string, + concatenates the string representations of the operands.  
  
 Delegate types also provide a binary `+` operator, which performs delegate concatenation.  
  
 User-defined types can overload the unary `+` and binary `+` operators. Operations on integral types are generally allowed on enumeration. For more information, see [operator (C# Reference)](../../../csharp/language-reference/keywords/operator-csharp-reference.md).  
  
## Example  
 [!code-csharp[csRefOperators#28](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#28)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [operator (C# Reference)](../../../csharp/language-reference/keywords/operator-csharp-reference.md)