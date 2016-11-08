---
title: "Compiler Error CS1646 | Microsoft Docs"
ms.custom: ""
ms.date: "11/04/2016"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "CS1646"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1646"
ms.assetid: 5e4b0f1e-8de3-42b0-bde6-9f882677a409
caps.latest.revision: 6
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Compiler Error CS1646
Keyword, identifier, or string expected after verbatim specifier: @  
  
 See string literals for the usage of the verbatim specifier '@'. The verbatim specifier is only allowed before a string, keyword or identifier. To resolve this error, remove the @ symbol from any inappropriate place or add the intended string, keyword or identifier.  
  
 The following sample generates CS1646:  
  
```  
// CS1646  
class C  
{  
   int i = @5;  // CS1646  
   // Try this line instead:  
   // int i = 5;  
}  
```