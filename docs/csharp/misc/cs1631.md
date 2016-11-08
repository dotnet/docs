---
title: "Compiler Error CS1631 | Microsoft Docs"
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
  - "CS1631"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1631"
ms.assetid: bf0c5ff9-90a3-4db6-b4ee-0b93e31614e0
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
# Compiler Error CS1631
Cannot yield a value in the body of a catch clause  
  
 The yield statement is not allowed from within the body of a catch clause. To avoid this error, move the yield statement outside the body of the catch clause.  
  
 The following sample generates CS1631:  
  
```  
// CS1631.cs  
using System;  
using System.Collections;  
  
public class C : IEnumerable  
{  
   public IEnumerator GetEnumerator()   
   {  
      try  
      {  
      }  
      catch(Exception e)  
      {  
        yield return this;  // CS1631  
      }  
   }    
  
   public static void Main()   
   {  
   }  
}  
```