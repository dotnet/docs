---
title: "public (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
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
  
 See [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md) and [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md) for more information.  
  
## Example  
 In the following example, two classes are declared, `PointTest` and `MainClass`. The public members `x` and `y` of `PointTest` are accessed directly from `MainClass`.  
  
 [!code-cs[csrefKeywordsModifiers#13](../../../csharp/language-reference/keywords/codesnippet/CSharp/public_1.cs)]  
  
 If you change the `public` access level to [private](../../../csharp/language-reference/keywords/private.md) or [protected](../../../csharp/language-reference/keywords/protected.md), you will get the error message:  
  
 'PointTest.y' is inaccessible due to its protection level.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Access Modifiers](../../../csharp/language-reference/keywords/access-modifiers.md)   
 [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md)   
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)   
 [private](../../../csharp/language-reference/keywords/private.md)   
 [protected](../../../csharp/language-reference/keywords/protected.md)   
 [internal](../../../csharp/language-reference/keywords/internal.md)