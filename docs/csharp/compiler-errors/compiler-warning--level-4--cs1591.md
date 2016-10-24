---
title: "Compiler Warning (level 4) CS1591"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "error-reference"
f1_keywords: 
  - "CS1591"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1591"
ms.assetid: 53c8599e-3e83-4d17-998b-05c934704283
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Compiler Warning (level 4) CS1591
Missing XML comment for publicly visible type or member 'Type_or_Member'  
  
 The [/doc](../compiler-options/-doc--csharp-compiler-options-.md) compiler option was specified, but one or more constructs did not have comments.  
  
 The following sample generates CS1591:  
  
```  
// CS1591.cs  
// compile with: /W:4 /doc:x.xml  
  
/// text  
public class Test  
{  
   // /// text  
   public static void Main()   // CS1591, remove "//" from previous line  
   {  
   }  
}  
```