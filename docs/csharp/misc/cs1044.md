---
title: "Compiler Error CS1044 | Microsoft Docs"
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
  - "CS1044"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1044"
ms.assetid: 18fc1ff5-8b97-4c31-99a1-5985b8e58024
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
# Compiler Error CS1044
Cannot use more than one type in a for, using, fixed, or declaration statement  
  
 The compiler found an invalid statement.  
  
 The following sample generates CS1044:  
  
```  
// CS1044.cs  
using System;  
  
public class MyClass : IDisposable  
{  
   public void Dispose()  
   {  
      Console.WriteLine("Res1.Dispose()");  
   }  
  
   public static void Main()  
   {  
      using (MyClass mc1 = new MyClass(),  
             MyClass mc2 = new MyClass())   // CS1044, remove an instantiation  
      {  
      }  
   }  
}  
```