---
title: "Compiler Error CS0723 | Microsoft Docs"
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
  - "CS0723"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0723"
ms.assetid: b9f6aebc-e959-407d-8d5c-6a6dcabcfe0f
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
# Compiler Error CS0723
Cannot declare variable of static type 'type'  
  
 Instances of static types cannot be created.  
  
 The following sample generates CS0723:  
  
```  
// CS0723.cs  
public static class SC  
{  
}  
  
public class CMain  
{  
   public static void Main()  
   {  
      SC sc = null;  // CS0723  
   }  
}  
```