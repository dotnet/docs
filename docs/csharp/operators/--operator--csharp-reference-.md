---
title: "+ Operator (C# Reference)"
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
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# + Operator (C# Reference)
The `+` operator can function as either a unary or a binary operator.  
  
## Remarks  
 Unary `+` operators are predefined for all numeric types. The result of a unary `+` operation on a numeric type is just the value of the operand.  
  
 Binary `+` operators are predefined for numeric and string types. For numeric types, + computes the sum of its two operands. When one or both operands are of type string, + concatenates the string representations of the operands.  
  
 Delegate types also provide a binary `+` operator, which performs delegate concatenation.  
  
 User-defined types can overload the unary `+` and binary `+` operators. Operations on integral types are generally allowed on enumeration. For more information, see [operator (C# Reference)](../keywords/operator--csharp-reference-2.md).  
  
## Example  
 [!code[csRefOperators#28](../operators/codesnippet/CSharp/--operator--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [operator (C# Reference)](../keywords/operator--csharp-reference-2.md)