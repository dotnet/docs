---
title: "Compiler Error CS1108 | Microsoft Docs"
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
  - "CS1108"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1108"
ms.assetid: 26e82d6a-6ebf-4beb-912e-1bcb86b668aa
caps.latest.revision: 8
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
# Compiler Error CS1108
A parameter cannot have all the specified modifiers; there are too many modifiers on the parameter.  
  
 Certain combinations of parameter modifiers, such as `ref` and `out`, are not allowed because they have mutually exclusive meanings for the compiler.  
  
## Example  
 The following example generates CS1108:  
  
```  
// cs1108.cs  
// Compile with: /target:library  
public class Test  
{  
    // Regular Instance Method.  
        public void TestMethod(ref out int i) {} // CS1108  
  
}  
```