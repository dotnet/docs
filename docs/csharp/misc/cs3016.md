---
title: "Compiler Warning (level 1) CS3016 | Microsoft Docs"
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
  - "CS3016"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS3016"
ms.assetid: b2ae721d-13ab-4e9d-a288-741d7825defe
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
# Compiler Warning (level 1) CS3016
Arrays as attribute arguments is not CLS-compliant  
  
 It is not compliant with the Common Language Specification (CLS) to pass an array to an attribute. For more information on CLS Compliance, see [Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3) and [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md).  
  
## Example  
 The following example generates CS3016:  
  
```  
// CS3016.cs  
  
using System;  
  
[assembly : CLSCompliant(true)]  
[C(new int[] {1, 2})]   // CS3016  
// try the following line instead  
// [C()]  
class C : Attribute  
{  
    public C()  
    {  
    }  
  
    public C(int[] a)  
    {  
    }  
  
    public static void Main ()  
    {  
    }  
}  
```