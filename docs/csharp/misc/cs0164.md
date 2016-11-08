---
title: "Compiler Warning (level 2) CS0164 | Microsoft Docs"
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
  - "CS0164"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0164"
ms.assetid: c701265b-ea7d-4d56-ae73-f74e039f1005
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
# Compiler Warning (level 2) CS0164
This label has not been referenced  
  
 A label was declared but never used.  
  
 The following sample generates CS0164:  
  
```  
// CS0164.cs  
// compile with: /W:2  
public class a  
{  
   public int i = 0;  
  
   public static void Main()  
   {  
      int i = 0;   // CS0164  
      l1: i++;  
      // the following lines resolve this error  
      // if(i < 10)  
      //    goto l1;  
   }  
}  
```