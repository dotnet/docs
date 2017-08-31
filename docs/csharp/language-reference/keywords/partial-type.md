---
title: "partial (Type) (C# Reference) | Microsoft Docs"
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
---
# partial (Type) (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Partial type definitions allow for the definition of a class, struct, or interface to be split into multiple files.  
  
 In File1.cs:  
  
 [!code-csharp[csrefKeywordsContextual#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#3)]  
  
 In File2.cs the declaration:  
  
 [!code-csharp[csrefKeywordsContextual#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#4)]  
  
## Remarks  
 Splitting a class, struct or interface type over several files can be useful when you are working with large projects, or with automatically generated code such as that provided by the [Windows Forms Designer](http://msdn.microsoft.com/en-us/3c3d61f8-f36c-4d41-b9c3-398376fabb15). A partial type may contain a [partial method](../../../csharp/language-reference/keywords/partial-method.md). For more information, see [Partial Classes and Methods](../../../csharp/programming-guide/classes-and-structs/partial-classes-and-methods.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)   
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)