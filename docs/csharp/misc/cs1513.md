---
title: "Compiler Error CS1513 | Microsoft Docs"
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
  - "CS1513"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1513"
ms.assetid: 28dacbb5-bf60-49ac-878e-c0ce469114eb
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
# Compiler Error CS1513
} expected  
  
 The compiler expected a closing curly brace (`}`) that was not found.  
  
 The following sample generates CS1513:  
  
```  
// CS1513  
namespace y   // CS1513, no close curly brace  
{  
   class x  
   {  
      public static void Main()  
      {  
      }  
   }  
```