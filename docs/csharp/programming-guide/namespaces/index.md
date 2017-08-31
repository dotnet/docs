---
title: "Namespaces (C# Programming Guide) | Microsoft Docs"
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
---
# Namespaces (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Namespaces are heavily used in C# programming in two ways. First, the .NET Framework uses namespaces to organize its many classes, as follows:  
  
 [!code-csharp[csProgGuide#22](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#22)]  
  
 `System` is a namespace and `Console` is a class in that namespace. The `using` keyword can be used so that the complete name is not required, as in the following example:  
  
 [!code-csharp[csProgGuide#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/using.cs#1)]  
  
 [!code-csharp[csProgGuide#25](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#25)]  
  
 For more information, see [using Directive](../../../csharp/language-reference/keywords/using-directive.md).  
  
 Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects. Use the [namespace](../../../csharp/language-reference/keywords/namespace.md) keyword to declare a namespace, as in the following example:  
  
 [!code-csharp[csProgGuideNamespaces#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideNamespaces/CS/Namespaces.cs#6)]  
  
## Namespaces Overview  
 Namespaces have the following properties:  
  
-   They organize large code projects.  
  
-   They are delimited by using the `.` operator.  
  
-   The `using directive` obviates the requirement to specify the name of the namespace for every class.  
  
-   The `global` namespace is the "root" namespace: `global::System` will always refer to the .NET Framework namespace `System`.  
  
## Related Sections  
 See the following topics for more information about namespaces:  
  
-   [Using Namespaces](../../../csharp/programming-guide/namespaces/using-namespaces.md)  
  
-   [How to: Use the Global Namespace Alias](../../../csharp/programming-guide/namespaces/how-to-use-the-global-namespace-alias.md)  
  
-   [How to: Use the My Namespace](../../../csharp/programming-guide/namespaces/how-to-use-the-my-namespace.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Namespace Keywords](../../../csharp/language-reference/keywords/namespace-keywords.md)   
 [using Directive](../../../csharp/language-reference/keywords/using-directive.md)   
 [:: Operator](../../../csharp/language-reference/operators/namespace-alias-qualifer.md)   
 [. Operator](../../../csharp/language-reference/operators/member-access-operator.md)