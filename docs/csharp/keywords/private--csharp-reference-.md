---
title: "private (C# Reference)"
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
  - "private_CSharpKeyword"
  - "private"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "private keyword [C#]"
ms.assetid: 654c0bb8-e6ac-4086-bf96-7474fa6aa1c8
caps.latest.revision: 17
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
# private (C# Reference)
The `private` keyword is a member access modifier. Private access is the least permissive access level. Private members are accessible only within the body of the class or the struct in which they are declared, as in this example:  
  
```  
class Employee  
{  
    private int i;  
    double d;   // private access by default  
}  
```  
  
 Nested types in the same body can also access those private members.  
  
 It is a compile-time error to reference a private member outside the class or the struct in which it is declared.  
  
 For a comparison of `private` with the other access modifiers, see [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md) and [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
## Example  
 In this example, the `Employee` class contains two private data members, `name` and `salary`. As private members, they cannot be accessed except by member methods. Public methods named `GetName` and `Salary` are added to allow controlled access to the private members. The `name` member is accessed by way of a public method, and the `salary` member is accessed by way of a public read-only property. (See [Properties](../classes-and-structs/properties--csharp-programming-guide-.md) for more information.)  
  
 [!code[csrefKeywordsModifiers#10](../keywords/codesnippet/CSharp/private--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Access Modifiers](../keywords/access-modifiers--csharp-reference-.md)   
 [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [public](../keywords/public--csharp-reference-.md)   
 [protected](../keywords/protected--csharp-reference-.md)   
 [internal](../keywords/internal--csharp-reference-.md)