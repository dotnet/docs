---
title: "Compiler Warning (level 2) CS0618"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "error-reference"
f1_keywords: 
  - "CS0618"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0618"
ms.assetid: b6edf0a9-b186-4ed8-9e16-978659b89205
caps.latest.revision: 8
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
# Compiler Warning (level 2) CS0618
'member' is obsolete: 'text'  
  
 A class member was marked with the `Obsolete` attribute, such that a warning will be issued when the class member is referenced. For more information, see [Common Attributes](../Topic/Common%20Attributes%20\(C%23%20and%20Visual%20Basic\).md).  
  
 The following sample generates CS0618:  
  
```  
// CS0618.cs  
// compile with: /W:2  
using System;  
  
public class C  
{  
   [Obsolete("Use newMethod instead", false)]   // warn if referenced  
   public static void m2()  
   {  
   }  
  
   public static void newMethod()  
   {  
   }  
}  
  
class MyClass  
{  
   public static void Main()  
   {  
      C.m2();  // CS0618  
   }  
}  
```