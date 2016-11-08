---
title: "Compiler Warning (level 3) CS0169 | Microsoft Docs"
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
  - "CS0169"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0169"
ms.assetid: 04b0015f-658d-440a-b9ba-831178f1a180
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
# Compiler Warning (level 3) CS0169
The private field 'class member' is never used  
  
 A private variable was declared but never referenced. A common way to generate this warning is when you declare a private member of a class and do not use it.  
  
 The following sample generates CS0169:  
  
```  
// compile with: /W:3  
using System;  
public class ClassX  
{  
   int i;   // CS0169, i is not used anywhere  
  
   public static void Main()  
   {  
   }  
}  
```