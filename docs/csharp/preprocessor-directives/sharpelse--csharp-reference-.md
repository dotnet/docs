---
title: "#else (C# Reference)"
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
  - "#else"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "#else directive [C#]"
ms.assetid: 6a347322-cfa2-4a86-98f8-ddfa2cb7d4db
caps.latest.revision: 11
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
# #else (C# Reference)
`#else` lets you create a compound conditional directive, so that, if none of the expressions in the preceding [#if](../preprocessor-directives/sharpif--csharp-reference-.md) or (optional) [#elif](../preprocessor-directives/sharpelif--csharp-reference-.md) directives to `true`, the compiler will evaluate all code between `#else` and the subsequent `#endif`.  
  
## Remarks  
 [#endif](../preprocessor-directives/sharpendif--csharp-reference-.md) must be the next preprocessor directive after `#else`. See [#if](../preprocessor-directives/sharpif--csharp-reference-.md) for an example of how to use `#else`.  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Preprocessor Directives](../preprocessor-directives/csharp-preprocessor-directives.md)