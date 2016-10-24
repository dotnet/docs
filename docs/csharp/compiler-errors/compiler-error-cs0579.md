---
title: "Compiler Error CS0579"
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
  - "CS0579"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0579"
ms.assetid: 1a15af7e-60ad-4418-a493-15fdfe08e7db
caps.latest.revision: 10
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
# Compiler Error CS0579
Duplicate 'attribute' attribute  
  
 It is not possible to specify the same attribute more than once unless the attribute specifies **AllowMultiple=true** in its [AttributeUsage](../Topic/AttributeUsage%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Example  
 The following example generates CS0579.  
  
```c#  
// CS0579.cs  
using System;  
public class MyAttribute : Attribute  
{  
}  
  
[AttributeUsage(AttributeTargets.All,AllowMultiple=true)]  
public class MyAttribute2 : Attribute  
{  
}  
  
public class z  
{  
    [MyAttribute, MyAttribute]     // CS0579  
    public void zz()  
    {  
    }  
  
    [MyAttribute2, MyAttribute2]   // OK  
    public void zzz()  
    {  
    }  
  
    public static void Main()  
    {  
    }  
}  
```