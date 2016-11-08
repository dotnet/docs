---
title: "Compiler Error CS0715 | Microsoft Docs"
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
  - "CS0715"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0715"
ms.assetid: e3cd1e46-ccfa-4678-a2ed-69245f3558ba
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
# Compiler Error CS0715
'static class' : static classes cannot contain user defined operators  
  
 User defined operators operate on instances of classes. Static classes cannot be instantiated, so it is not possible to create instances for operators to act upon. Hence, user defined operators are not allowed for static classes.  
  
 The following sample generates CS0715:  
  
```  
// CS0715.cs  
public static class C  
{  
   public static C operator+(C c)  // CS0715  
   {  
   }  
  
   public static void Main()  
   {  
   }  
}  
```