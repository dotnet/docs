---
title: "public (C# Reference)"
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
  - "public"
  - "public_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "public keyword [C#]"
ms.assetid: 0ae45d16-a551-4b74-9845-57208de1328e
caps.latest.revision: 21
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
# public (C# Reference)
The `public` keyword is an access modifier for types and type members. Public access is the most permissive access level. There are no restrictions on accessing public members, as in this example:  
  
```  
class SampleClass  
{  
    public int x; // No access restrictions.  
}  
```  
  
 See [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md) and [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md) for more information.  
  
## Example  
 In the following example, two classes are declared, `PointTest` and `MainClass`. The public members `x` and `y` of `PointTest` are accessed directly from `MainClass`.  
  
 [!code[csrefKeywordsModifiers#13](../keywords/codesnippet/CSharp/public--csharp-reference-_1.cs)]  
  
 If you change the `public` access level to [private](../keywords/private--csharp-reference-.md) or [protected](../keywords/protected--csharp-reference-.md), you will get the error message:  
  
 'PointTest.y' is inaccessible due to its protection level.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Access Modifiers](../keywords/access-modifiers--csharp-reference-.md)   
 [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [private](../keywords/private--csharp-reference-.md)   
 [protected](../keywords/protected--csharp-reference-.md)   
 [internal](../keywords/internal--csharp-reference-.md)