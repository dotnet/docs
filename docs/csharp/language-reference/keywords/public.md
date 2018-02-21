---
title: "public (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "public"
  - "public_CSharpKeyword"
helpviewer_keywords: 
  - "public keyword [C#]"
ms.assetid: 0ae45d16-a551-4b74-9845-57208de1328e
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
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
  
 [!code-csharp[csrefKeywordsModifiers#13](../../../csharp/language-reference/keywords/codesnippet/CSharp/public_1.cs)]  
  
 If you change the `public` access level to [private](../../../csharp/language-reference/keywords/private.md) or [protected](../../../csharp/language-reference/keywords/protected.md), you will get the error message:  
  
 'PointTest.y' is inaccessible due to its protection level.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
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
