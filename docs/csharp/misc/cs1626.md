---
title: "Compiler Error CS1626 | Microsoft Docs"
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
  - "CS1626"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1626"
ms.assetid: 3ba03383-eb24-4fd8-bf40-8b0f7d6baf0d
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
# Compiler Error CS1626
Cannot yield a value in the body of a try block with a catch clause  
  
 A yield statement is not allowed in a try block if there is a catch clause associated with the try block. To avoid this error, move the yield statement out of the catch clause.  
  
 The following sample generates CS1626:  
  
```  
// CS1626.cs  
using System.Collections;  
  
class C : IEnumerable  
{  
   public IEnumerator GetEnumerator()  
   {  
      try  
      {  
         yield return this;  // CS1626  
      }  
      catch  
      {  
  
      }  
   }  
}  
  
public class CMain  
{  
   public static void Main() { }  
}  
  
```