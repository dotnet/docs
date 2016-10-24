---
title: "this (C# Reference)"
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
  - "this"
  - "this_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "this keyword [C#]"
ms.assetid: d4f827fe-4710-410b-89b8-867dad44b8a3
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
# this (C# Reference)
The `this` keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.  
  
> [!NOTE]
>  This article discusses the use of `this` with class instances. For more information about its use in extension methods, see [Extension Methods](../classes-and-structs/extension-methods--csharp-programming-guide-.md).  
  
 The following are common uses of `this`:  
  
-   To qualify members hidden by similar names, for example:  
  
 [!code[csrefKeywordsAccess#4](../keywords/codesnippet/CSharp/this--csharp-reference-_1.cs)]  
  
-   To pass an object as a parameter to other methods, for example:  
  
    ```  
    CalcTax(this);  
    ```  
  
-   To declare indexers, for example:  
  
 [!code[csrefKeywordsAccess#5](../keywords/codesnippet/CSharp/this--csharp-reference-_2.cs)]  
  
 Static member functions, because they exist at the class level and not as part of an object, do not have a `this` pointer. It is an error to refer to `this` in a static method.  
  
## Example  
 In this example, `this` is used to qualify the `Employee` class members, `name` and `alias`, which are hidden by similar names. It is also used to pass an object to the method `CalcTax`, which belongs to another class.  
  
 [!code[csrefKeywordsAccess#3](../keywords/codesnippet/CSharp/this--csharp-reference-_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [base](../keywords/base--csharp-reference-.md)   
 [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)