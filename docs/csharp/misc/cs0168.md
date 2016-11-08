---
title: "Compiler Warning (level 3) CS0168 | Microsoft Docs"
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
  - "CS0168"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0168"
ms.assetid: 6f5b7fe3-1e91-462f-8a73-b931327ab3f5
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
# Compiler Warning (level 3) CS0168
The variable 'var' is assigned but its value is never used  
  
 The compiler warns when a variable is declared but not used.  
  
 The following sample generates two CS0168 warnings:  
  
```  
// CS0168.cs  
// compile with: /W:3  
public class clx  
{  
   public int i;  
}  
  
public class clz  
{  
   public static void Main()  
   {  
      int j = 0;   // CS0168, uncomment the following line  
      // j++;  
      clx a;       // CS0168, try the following line instead  
      // clx a = new clx();  
   }  
}  
```