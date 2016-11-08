---
title: "Operator (C# Reference)1 | Microsoft Docs"
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
  - "[]_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "subscript operator [C#]"
  - "square brackets [ ] operator [C#]"
  - "[] operator [C#]"
  - "indexing operator [C#]"
ms.assetid: 5c16bb45-88f7-45ff-b42c-1af1972b042c
caps.latest.revision: 20
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
# Operator (C# Reference)
Square brackets (`[]`) are used for arrays, indexers, and attributes. They can also be used with pointers.  
  
## Remarks  
 An array type is a type followed by `[]`:  
  
 [!code-cs[csRefOperators#43](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_1.cs)]  
  
 To access an element of an array, the index of the desired element is enclosed in brackets:  
  
 [!code-cs[csRefOperators#44](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_2.cs)]  
  
 An exception is thrown if an array index is out of range.  
  
 The array indexing operator cannot be overloaded; however, types can define indexers, and properties that take one or more parameters. Indexer parameters are enclosed in square brackets, just like array indexes, but indexer parameters can be declared to be of any type, unlike array indexes, which must be integral.  
  
 For example, the .NET Framework defines a `Hashtable` type that associates keys and values of arbitrary type:  
  
 [!code-cs[csRefOperators#45](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_3.cs)]  
  
 Square brackets are also used to specify [Attributes](../Topic/Attributes%20\(C%23%20and%20Visual%20Basic\).md):  
  
 [!code-cs[csRefOperators#46](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_4.cs)]  
  
 You can use square brackets to index off a pointer:  
  
 [!code-cs[csRefOperators#47](../../../csharp/language-reference/operators/codesnippet/CSharp/index-operator_5.cs)]  
  
 No bounds checking is performed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [Arrays](../../../csharp/programming-guide/arrays/index.md)   
 [Indexers](../../../csharp/programming-guide/indexers/index.md)   
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)   
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)