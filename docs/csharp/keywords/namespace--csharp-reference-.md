---
title: "namespace (C# Reference)"
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
  - "namespace_CSharpKeyword"
  - "namespace"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "namespace keyword [C#]"
  - "scope [C#]"
ms.assetid: 0a788423-9110-42e0-97d9-bda41ca4870f
caps.latest.revision: 28
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
# namespace (C# Reference)
The `namespace` keyword is used to declare a scope that contains a set of related objects. You can use a namespace to organize code elements and to create globally unique types.  
  
 [!code[csrefKeywordsNamespace#1](../keywords/codesnippet/CSharp/namespace--csharp-reference-_1.cs)]  
  
## Remarks  
 Within a namespace, you can declare one or more of the following types:  
  
-   another namespace  
  
-   [class](../keywords/class--csharp-reference-.md)  
  
-   [interface](../keywords/interface--csharp-reference-.md)  
  
-   [struct](../keywords/struct--csharp-reference-.md)  
  
-   [enum](../keywords/enum--csharp-reference-.md)  
  
-   [delegate](../keywords/delegate--csharp-reference-.md)  
  
 Whether or not you explicitly declare a namespace in a C# source file, the compiler adds a default namespace. This unnamed namespace, sometimes referred to as the global namespace, is present in every file. Any identifier in the global namespace is available for use in a named namespace.  
  
 Namespaces implicitly have public access and this is not modifiable. For a discussion of the access modifiers you can assign to elements in a namespace, see [Access Modifiers](../keywords/access-modifiers--csharp-reference-.md).  
  
 It is possible to define a namespace in two or more declarations. For example, the following example defines two classes as part of the `MyCompany` namespace:  
  
 [!code[csrefKeywordsNamespace#2](../keywords/codesnippet/CSharp/namespace--csharp-reference-_2.cs)]  
  
## Example  
 The following example shows how to call a static method in a nested namespace.  
  
 [!code[csrefKeywordsNamespace#3](../keywords/codesnippet/CSharp/namespace--csharp-reference-_3.cs)]  
  
## For More Information  
 For more information about using namespaces, see the following topics:  
  
-   [Namespaces](../namespaces/namespaces--csharp-programming-guide-.md)  
  
-   [Using Namespaces](../namespaces/using-namespaces--csharp-programming-guide-.md)  
  
-   [How to: Use the Global Namespace Alias](../namespaces/how-to--use-the-global-namespace-alias--csharp-programming-guide-.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Namespace Keywords](../keywords/namespace-keywords--csharp-reference-.md)   
 [using](../keywords/using--csharp-reference-.md)