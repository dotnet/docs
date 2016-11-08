---
title: "Compiler Error CS0555 | Microsoft Docs"
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
  - "CS0555"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0555"
ms.assetid: e4b2f890-98b4-4578-b1de-ebaafc8b3da2
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
# Compiler Error CS0555
User-defined operator cannot take an object of the enclosing type and convert to an object of the enclosing type  
  
 User-defined conversions to values of the enclosing class are not allowed; you do not need such an operator.  
  
 The fo3llowing sample generates CS0555:  
  
```  
// CS0555.cs  
public class MyClass  
{  
   // delete the following operator to resolve this CS0555  
   public static implicit operator MyClass(MyClass aa)   // CS0555  
   {  
      return new MyClass();  
   }  
  
   public static void Main()  
   {  
   }  
}  
```