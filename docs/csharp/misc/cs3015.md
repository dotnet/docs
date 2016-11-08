---
title: "Compiler Warning (level 1) CS3015 | Microsoft Docs"
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
  - "CS3015"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS3015"
ms.assetid: 58182215-0c2f-4497-8baf-ffb29f18d6c7
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
# Compiler Warning (level 1) CS3015
'method signature' has no accessible constructors which use only CLS-compliant types  
  
 To be compliant with the Common Language Specification (CLS), the argument list of an attribute class cannot contain an array. For more information on CLS Compliance, see [Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3) and [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md).  
  
## Example  
 The following sample generates C3015.  
  
```  
// CS3015.cs  
// compile with: /target:library  
using System;  
  
[assembly:CLSCompliant(true)]  
public class MyAttribute : Attribute  
{  
   public MyAttribute(int[] ai) {}   // CS3015  
   // try the following line instead  
   // public MyAttribute(int ai) {}  
}  
```