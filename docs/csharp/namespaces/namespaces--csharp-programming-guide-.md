---
title: "Namespaces (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "C# language, namespaces"
  - "namespaces [C#]"
ms.assetid: b1c4ab46-3fad-4ffa-9deb-dd50a2d8c65a
caps.latest.revision: 27
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
# Namespaces (C# Programming Guide)
Namespaces are heavily used in C# programming in two ways. First, the .NET Framework uses namespaces to organize its many classes, as follows:  
  
 [!code[csProgGuide#22](../inside-a-program/codesnippet/CSharp/namespaces--csharp-programming-guide-_1.cs)]  
  
 `System` is a namespace and `Console` is a class in that namespace. The `using` keyword can be used so that the complete name is not required, as in the following example:  
  
 [!code[csProgGuide#1](../inside-a-program/codesnippet/CSharp/namespaces--csharp-programming-guide-_2.cs)]  
  
 [!code[csProgGuide#25](../inside-a-program/codesnippet/CSharp/namespaces--csharp-programming-guide-_3.cs)]  
  
 For more information, see [using Directive](../keywords/using-directive--csharp-reference-.md).  
  
 Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects. Use the [namespace](../keywords/namespace--csharp-reference-.md) keyword to declare a namespace, as in the following example:  
  
 [!code[csProgGuideNamespaces#6](../namespaces/codesnippet/CSharp/namespaces--csharp-programming-guide-_4.cs)]  
  
## Namespaces Overview  
 Namespaces have the following properties:  
  
-   They organize large code projects.  
  
-   They are delimited by using the `.` operator.  
  
-   The `using directive` obviates the requirement to specify the name of the namespace for every class.  
  
-   The `global` namespace is the "root" namespace: `global::System` will always refer to the .NET Framework namespace `System`.  
  
## Related Sections  
 See the following topics for more information about namespaces:  
  
-   [Using Namespaces](../namespaces/using-namespaces--csharp-programming-guide-.md)  
  
-   [How to: Use the Global Namespace Alias](../namespaces/how-to--use-the-global-namespace-alias--csharp-programming-guide-.md)  
  
-   [How to: Use the My Namespace](../namespaces/how-to--use-the-my-namespace--csharp-programming-guide-.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Namespace Keywords](../keywords/namespace-keywords--csharp-reference-.md)   
 [using Directive](../keywords/using-directive--csharp-reference-.md)   
 [:: Operator](../operators/---operator--csharp-reference-.md)   
 [. Operator](../operators/.-operator--csharp-reference-.md)