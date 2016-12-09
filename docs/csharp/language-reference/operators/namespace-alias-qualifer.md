---
title: ":: Operator (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "::_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - ":: operator [C#]"
  - "namespaces [C#], :: operator"
  - "namespace alias qualifier operator (::) [C#]"
ms.assetid: 698b5a73-85cf-4e0e-9e8e-6496887f8527
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
# :: Operator (C# Reference)
The namespace alias qualifier (`::`) is used to look up identifiers. It is always positioned between two identifiers, as in this example:  
  
 [!code-cs[csRefOperators#27](../../../csharp/language-reference/operators/codesnippet/CSharp/namespace-alias-qualifer_1.cs)]  
  
## Remarks  
 The namespace alias qualifier can be `global`. This invokes a lookup in the global namespace, rather than an aliased namespace.  
  
## For More Information  
 For an example of how to use the `::` operator, see the following section:  
  
-   [How to: Use the Global Namespace Alias](../../../csharp/programming-guide/namespaces/how-to-use-the-global-namespace-alias.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [Namespace Keywords](../../../csharp/language-reference/keywords/namespace-keywords.md)   
 [. Operator](../../../csharp/language-reference/operators/member-access-operator.md)   
 [extern alias](../../../csharp/language-reference/keywords/extern-alias.md)