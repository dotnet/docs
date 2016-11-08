---
title: "Compiler Error CS0501 | Microsoft Docs"
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
  - "CS0501"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0501"
ms.assetid: 3ff45208-5b9b-42f6-8a12-1eb38a665f33
caps.latest.revision: 9
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
# Compiler Error CS0501
'member function' must declare a body because it is not marked abstract, extern, or partial  
  
 Nonabstract methods must have implementations.  
  
 The following sample generates CS0501:  
  
```  
// CS0501.cs  
// compile with: /target:library  
public class clx  
{  
   public void f();   // CS0501 declared but not defined  
   public void g() {}   // OK  
}  
```