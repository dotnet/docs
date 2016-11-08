---
title: "Compiler Error CS0590 | Microsoft Docs"
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
  - "CS0590"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0590"
ms.assetid: 6df9461f-2de6-4032-b18f-96121db1e4af
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
# Compiler Error CS0590
User-defined operators cannot return void  
  
 The purpose of a user-defined operator is to return an object.  
  
 The following sample generates CS0590:  
  
```  
// CS0590.cs  
namespace x  
{  
   public class a  
   {  
      public static void operator+(a A1, a A2)   // CS0590  
      {  
      }  
  
      // try the following user-defined operator  
      /*  
      public static a operator+(a A1, a A2)  
      {  
         return A2;  
      }  
      */  
  
      public static int Main()  
      {  
         return 1;  
      }  
   }  
}  
```