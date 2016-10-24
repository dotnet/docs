---
title: "partial (Type) (C# Reference)"
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
  - "partialtype"
  - "partialtype_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "partial types [C#]"
ms.assetid: 27320743-a22e-4c7b-b0b3-53afe3607334
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
# partial (Type) (C# Reference)
Partial type definitions allow for the definition of a class, struct, or interface to be split into multiple files.  
  
 In File1.cs:  
  
 [!code[csrefKeywordsContextual#3](../keywords/codesnippet/CSharp/partial--type---csharp-reference-_1.cs)]  
  
 In File2.cs the declaration:  
  
 [!code[csrefKeywordsContextual#4](../keywords/codesnippet/CSharp/partial--type---csharp-reference-_2.cs)]  
  
## Remarks  
 Splitting a class, struct or interface type over several files can be useful when you are working with large projects, or with automatically generated code such as that provided by the [Windows Forms Designer](http://msdn.microsoft.com/en-us/3c3d61f8-f36c-4d41-b9c3-398376fabb15). A partial type may contain a [partial method](../keywords/partial--method---csharp-reference-.md). For more information, see [Partial Classes and Methods](../classes-and-structs/partial-classes-and-methods--csharp-programming-guide-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [Introduction to Generics](../generics/introduction-to-generics--csharp-programming-guide-.md)