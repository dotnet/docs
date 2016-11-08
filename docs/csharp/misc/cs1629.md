---
title: "Compiler Error CS1629 | Microsoft Docs"
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
  - "CS1629"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1629"
ms.assetid: 907eae46-0265-4cd0-b27b-ff555d004259
caps.latest.revision: 7
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
# Compiler Error CS1629
Unsafe code may not appear in iterators  
  
 The C# language specification does not allow unsafe code in iterators.  
  
 The following sample generates CS1629:  
  
```  
// CS1629.cs  
// compile with: /unsafe    
using System.Collections.Generic;  
class C   
{  
   IEnumerator<int> IteratorMeth() {  
      int i;  
      unsafe  // CS1629  
      {  
         int *p = &i;  
         yield return *p;  
      }  
   }  
}  
```