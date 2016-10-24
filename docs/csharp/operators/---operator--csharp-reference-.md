---
title: "&gt;&gt; Operator (C# Reference)"
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
  - ">>_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - ">> operator [C#]"
  - "right shift operator (>>) [C#]"
ms.assetid: a07f8679-d318-4ef8-b38b-65903efb8056
caps.latest.revision: 15
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
# &gt;&gt; Operator (C# Reference)
The right-shift operator (`>>`) shifts its first operand right by the number of bits specified by its second operand.  
  
## Remarks  
 If the first operand is an [int](../keywords/int--csharp-reference-.md) or [uint](../keywords/uint--csharp-reference-.md) (32-bit quantity), the shift count is given by the low-order five bits of the second operand (second operand & 0x1f).  
  
 If the first operand is a [long](../keywords/long--csharp-reference-.md) or [ulong](../keywords/ulong--csharp-reference-.md) (64-bit quantity), the shift count is given by the low-order six bits of the second operand (second operand & 0x3f).  
  
 If the first operand is an [int](../keywords/int--csharp-reference-.md) or [long](../keywords/long--csharp-reference-.md), the right-shift is an arithmetic shift (high-order empty bits are set to the sign bit). If the first operand is of type [uint](../keywords/uint--csharp-reference-.md) or [ulong](../keywords/ulong--csharp-reference-.md), the right-shift is a logical shift (high-order bits are zero-filled).  
  
 User-defined types can overload the `>>` operator; the type of the first operand must be the user-defined type, and the type of the second operand must be [int](../keywords/int--csharp-reference-.md). For more information, see [operator](../keywords/operator--csharp-reference-2.md). When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code[csRefOperators#26](../operators/codesnippet/CSharp/---operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)