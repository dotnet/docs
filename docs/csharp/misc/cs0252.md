---
title: "Compiler Warning (level 2) CS0252 | Microsoft Docs"
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
  - "CS0252"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0252"
ms.assetid: ff82fbac-01cf-4ae9-b6a0-3aa990096b46
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
# Compiler Warning (level 2) CS0252
Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'type'  
  
 The compiler is doing a reference comparison. If you want to compare the value of strings, cast the left side of the expression to `type`.  
  
 The following sample generates CS0252:  
  
```  
// CS0252.cs  
// compile with: /W:2  
using System;  
  
class MyClass  
{  
   public static void Main()  
   {  
      string s = "11";  
      object o = s + s;  
  
      bool b = o == s;   // CS0252  
      // try the following line instead  
      // bool b = (string)o == s;  
   }  
}  
```