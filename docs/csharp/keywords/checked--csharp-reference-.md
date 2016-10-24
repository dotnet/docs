---
title: "checked (C# Reference)"
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
  - "checked_CSharpKeyword"
  - "checked"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "checked keyword [C#]"
ms.assetid: 718a1194-988d-48a3-b089-d6ee8bd1608d
caps.latest.revision: 24
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
# checked (C# Reference)
The `checked` keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.  
  
 By default, an expression that contains only constant values causes a compiler error if the expression produces a value that is outside the range of the destination type. If the expression contains one or more non-constant values, the compiler does not detect the overflow. Evaluating the expression assigned to `i2` in the following example does not cause a compiler error.  
  
 [!code[csrefKeywordsChecked#3](../keywords/codesnippet/CSharp/checked--csharp-reference-_1.cs)]  
  
 By default, these non-constant expressions are not checked for overflow at run time either, and they do not raise overflow exceptions. The previous example displays -2,147,483,639 as the sum of two positive integers.  
  
 Overflow checking can be enabled by compiler options, environment configuration, or use of the `checked` keyword. The following examples demonstrate how to use a `checked` expression or a `checked` block to detect the overflow that is produced by the previous sum at run time. Both examples raise an overflow exception.  
  
 [!code[csrefKeywordsChecked#4](../keywords/codesnippet/CSharp/checked--csharp-reference-_2.cs)]  
  
 The [unchecked](../keywords/unchecked--csharp-reference-.md) keyword can be used to prevent overflow checking.  
  
## Example  
 This sample shows how to use `checked` to enable overflow checking at run time.  
  
 [!code[csrefKeywordsChecked#1](../keywords/codesnippet/CSharp/checked--csharp-reference-_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Checked and Unchecked](../keywords/checked-and-unchecked--csharp-reference-.md)   
 [unchecked](../keywords/unchecked--csharp-reference-.md)