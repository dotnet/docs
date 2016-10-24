---
title: "operator (C# Reference)2"
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
  - "operator_CSharpKeyword"
  - "operator"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "operator keyword [C#]"
ms.assetid: 59218cce-e90e-42f6-a6bb-30300981b86a
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
# operator (C# Reference)
Use the `operator` keyword to overload a built-in operator or to provide a user-defined conversion in a class or struct declaration.  
  
## Example  
 The following is a very simplified class for fractional numbers. It overloads the + and * operators to perform fractional addition and multiplication, and also provides a conversion operator that converts a Fraction type to a double type.  
  
 [!code[csrefKeywordsConversion#6](../keywords/codesnippet/CSharp/operator--csharp-reference-2_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [implicit](../keywords/implicit--csharp-reference-.md)   
 [explicit](../keywords/explicit--csharp-reference-.md)   
 [How to: Implement User-Defined Conversions Between Structs](../statements-expressions-operators/97839aef-8fbc-40d5-9769-6b569bc2710b.md)