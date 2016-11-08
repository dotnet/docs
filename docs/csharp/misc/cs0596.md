---
title: "Compiler Error CS0596 | Microsoft Docs"
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
  - "CS0596"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0596"
ms.assetid: 7cbf0db1-bb0b-4c50-b71e-16599a7e37d0
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
# Compiler Error CS0596
The Guid attribute must be specified with the ComImport attribute  
  
 The **Guid** attribute must be present when using the **ComImport** attribute.  
  
 The following sample generates CS0596:  
  
```  
// CS0596.cs  
using System.Runtime.InteropServices;  
  
namespace x  
{  
   [ComImport]   // CS0596  
   // try the following line to resolve this CS0596  
   // [ComImport, Guid("00000000-0000-0000-0000-000000000001")]  
   public class a  
   {  
   }  
  
   public class b  
   {  
      public static void Main()  
      {  
      }  
   }  
}  
```