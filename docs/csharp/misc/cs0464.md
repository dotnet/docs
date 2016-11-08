---
title: "Compiler Warning (level 2) CS0464 | Microsoft Docs"
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
  - "CS0464"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0464"
ms.assetid: 3dff97d4-e1f6-4a71-91e2-68cffc38d49a
caps.latest.revision: 15
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
# Compiler Warning (level 2) CS0464
Comparing with null of type 'type' always produces 'false'  
  
 This warning is produced when you perform a comparison between a nullable variable and null, and the comparison is not `==` or `!=`. To resolve this error, verify if you really want to check a value for `null`. A comparison like `i == null` can be either true of false. A comparison like `i > null` is always false.  
  
## Example  
 The following sample generates CS0464.  
  
```  
// CS0464.cs  
class MyClass  
{  
   public static void Main()  
   {  
      int? i = 0;  
      if (i < null) ;   // CS0464  
  
      i++;  
   }  
}  
```