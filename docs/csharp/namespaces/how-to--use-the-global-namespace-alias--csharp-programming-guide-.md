---
title: "How to: Use the Global Namespace Alias (C# Programming Guide)"
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
  - "aliases [C#]"
  - "namespaces [C#], global namespace qualifier"
  - "global namespace [C#]"
ms.assetid: 98a1d89b-3c5a-44f7-8400-c4a3c0ec22a9
caps.latest.revision: 23
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
# How to: Use the Global Namespace Alias (C# Programming Guide)
The ability to access a member in the global [namespace](../keywords/namespace--csharp-reference-.md) is useful when the member might be hidden by another entity of the same name.  
  
 For example, in the following code, `Console` resolves to `TestApp.Console` instead of to the `Console` type in the <xref:System> namespace.  
  
 [!code[csProgGuide#1](../inside-a-program/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuideNamespaces#1](../namespaces/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_2.cs)]  
  
 Using `System.Console` still results in an error because the `System` namespace is hidden by the class `TestApp.System`:  
  
 [!code[csProgGuideNamespaces#2](../namespaces/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_3.cs)]  
  
 However, you can work around this error by using `global::System.Console`, like this:  
  
 [!code[csProgGuideNamespaces#3](../namespaces/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_4.cs)]  
  
 When the left identifier is `global`, the search for the right identifier starts at the global namespace. For example, the following declaration is referencing `TestApp` as a member of the global space.  
  
 [!code[csProgGuideNamespaces#4](../namespaces/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_5.cs)]  
  
 Obviously, creating your own namespaces called `System` is not recommended, and it is unlikely you will encounter any code in which this has happened. However, in larger projects, it is a very real possibility that namespace duplication may occur in one form or another. In these situations, the global namespace qualifier is your guarantee that you can specify the root namespace.  
  
## Example  
 In this example, the namespace `System` is used to include the class `TestClass` therefore, `global::System.Console` must be used to reference the `System.Console` class, which is hidden by the `System` namespace. Also, the alias `colAlias` is used to refer to the namespace `System.Collections`; therefore, the instance of a <xref:System.Collections.Hashtable?displayProperty=fullName> was created using this alias instead of the namespace.  
  
 [!code[csProgGuideNamespaces#5](../namespaces/codesnippet/CSharp/how-to--use-the-global-namespace-alias--csharp-programming-guide-_6.cs)]  
  
 **A 1**  
**B 2**  
**C 3**   
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Namespaces](../namespaces/namespaces--csharp-programming-guide-.md)   
 [. Operator](../operators/.-operator--csharp-reference-.md)   
 [:: Operator](../operators/---operator--csharp-reference-.md)   
 [extern](../keywords/extern--csharp-reference-.md)