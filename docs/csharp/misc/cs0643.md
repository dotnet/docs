---
title: "Compiler Error CS0643 | Microsoft Docs"
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
  - "CS0643"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0643"
ms.assetid: beae30ff-15c2-413f-8f5c-504cdba2e57a
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
# Compiler Error CS0643
'arg' duplicate named attribute argument  
  
 A parameter, `arg`, on a user-defined attribute was specified twice. For more information, see [Attributes](../Topic/Attributes%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Example  
 The following sample generates CS0643:  
  
```  
// CS0643.cs  
using System;  
using System.Runtime.InteropServices;  
  
[AttributeUsage(AttributeTargets.Class)]  
public class MyAttribute : Attribute  
{  
    public MyAttribute()  
    {  
    }  
  
    public int x;  
}  
  
[MyAttribute(x = 5, x = 6)]   // CS0643, error setting x twice  
// try the following line instead  
// [MyAttribute(x = 5)]  
class MyClass  
{  
}  
  
public class MainClass  
{  
    public static void Main ()  
    {  
    }  
}  
```