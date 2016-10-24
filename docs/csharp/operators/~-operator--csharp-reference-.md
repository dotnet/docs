---
title: "~ Operator (C# Reference)"
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
  - "~_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "tilde (~) one's complement operator [C#]"
  - "~ operator [C#]"
  - "~ [C#], bitwise complement operator"
  - "bitwise complement operator [C#]"
ms.assetid: 11bc078a-50e2-4d7e-9896-67ef669dc602
caps.latest.revision: 18
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
# ~ Operator (C# Reference)
The `~` operator performs a bitwise complement operation on its operand, which has the effect of reversing each bit. Bitwise complement operators are predefined for [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), and [ulong](../keywords/ulong--csharp-reference-.md).  
  
> [!NOTE]
>  The `~` symbol also is used to declare destructors. For more information, see [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md).  
  
## Remarks  
 User-defined types can overload the `~` operator. For more information, see [operator](../keywords/operator--csharp-reference-2.md). Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code[csRefOperators#25](../operators/codesnippet/CSharp/~-operator--csharp-reference-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md)