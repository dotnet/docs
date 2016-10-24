---
title: "protected (C# Reference)"
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
  - "protected"
  - "protected_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "protected keyword [C#]"
ms.assetid: 05ce3794-6675-4025-bddb-eaaa0ec22892
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
# protected (C# Reference)
The `protected` keyword is a member access modifier. A protected member is accessible within its class and by derived class instances. For a comparison of `protected` with the other access modifiers, see [Accessibility Levels](../keywords/accessibility-levels--csharp-reference-.md).  
  
## Example  
 A protected member of a base class is accessible in a derived class only if the access occurs through the derived class type. For example, consider the following code segment:  
  
 [!code[csrefKeywordsModifiers#11](../keywords/codesnippet/CSharp/protected--csharp-reference-_1.cs)]  
  
 The statement `a.x = 10` generates an error because it is made within the static method Main, and not an instance of class B.  
  
 Struct members cannot be protected because the struct cannot be inherited.  
  
## Example  
 In this example, the class `DerivedPoint` is derived from `Point`. Therefore, you can access the protected members of the base class directly from the derived class.  
  
 [!code[csrefKeywordsModifiers#12](../keywords/codesnippet/CSharp/protected--csharp-reference-_2.cs)]  
  
 If you change the access levels of `x` and `y` to [private](../keywords/private--csharp-reference-.md), the compiler will issue the error messages:  
  
 `'Point.y' is inaccessible due to its protection level.`  
  
 `'Point.x' is inaccessible due to its protection level.`  
  
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
 [private](../keywords/private--csharp-reference-.md)   
 [internal](../keywords/internal--csharp-reference-.md)