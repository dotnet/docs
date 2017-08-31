---
title: "* Operator (C# Reference) | Microsoft Docs"
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
  - "*_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "multiplication operator (*) [C#]"
  - "* operator [C#]"
ms.assetid: abd9a5f0-9b24-431e-971a-09ee1c45c50e
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# * Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The multiplication operator (`*`), which computes the product of its operands.  Also, the dereference operator, which allows reading and writing to a pointer.  
  
## Remarks  
 All numeric types have predefined multiplication operators.  
  
 The `*` operator is also used to declare pointer types and to dereference pointers. This operator can only be used in unsafe contexts, denoted by the use of the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword, and requiring the [/unsafe](../../../csharp/language-reference/compiler-options/unsafe-csharp-compiler-options.md) compiler option.  The dereference operator is also known as the indirection operator.  
  
 User-defined types can overload the binary `*` operator (see [operator](../../../csharp/language-reference/keywords/operator-csharp-reference.md)). When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#50](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#50)]  
  
## Example  
 [!code-csharp[csRefOperators#51](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#51)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)