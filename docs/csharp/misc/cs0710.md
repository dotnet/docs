---
title: "Compiler Error CS0710 | Microsoft Docs"
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
  - "CS0710"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0710"
ms.assetid: 753a1a87-f5e5-4758-a960-515069a6c7b0
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
# Compiler Error CS0710
Static classes cannot have instance constructors  
  
 A static class cannot be instantiated, hence it has no need for constructors. To avoid this error, remove any constructors from static classes, or if you really want to construct instances, make the class non-static.  
  
 The following sample generates CS0710:  
  
```  
// CS0710.cs  
public static class C  
{  
   public C()  // CS0710  
   {  
   }  
  
   public static void Main()  
   {  
   }  
}  
```