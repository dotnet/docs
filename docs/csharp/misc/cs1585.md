---
title: "Compiler Error CS1585 | Microsoft Docs"
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
  - "CS1585"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1585"
ms.assetid: 429268c3-2dae-4c71-9e0d-be1badb3ca68
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
# Compiler Error CS1585
Member modifier 'keyword' must precede the member type and name  
  
 The access specifier in a method signature did not occur in the correct location.  
  
 The following sample generates CS1585:  
  
```  
// CS1585.cs  
public class Class1  
{  
   public void static Main(string[] args)   // CS1585  
   // try the following line instead  
   // public static void Main(string[] args)  
   {  
   }  
}  
```