---
title: "Compiler Error CS0655 | Microsoft Docs"
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
  - "CS0655"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0655"
ms.assetid: 8ce340e2-eeeb-476a-8609-ab4bbaf10c44
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
# Compiler Error CS0655
'parameter' is not a valid named attribute argument because it is not a valid attribute parameter type  
  
 See [Attributes](../Topic/Attributes%20\(C%23%20and%20Visual%20Basic\).md) for a discussion of valid parameter types for an attribute.  
  
## Example  
 The following sample generates CS0655:  
  
```  
// CS0655.cs  
using System;  
  
class MyAttribute : Attribute  
{  
    // decimal is not valid attribute parameter type  
    public decimal d = 0;  
    public int e = 0;  
}  
  
[My(d = 0)]   // CS0655  
// Try the following line instead:  
// [My(e = 0)]  
class C  
{  
    public static void Main()  
    {  
    }  
}  
```