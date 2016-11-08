---
title: "Compiler Error CS0463 | Microsoft Docs"
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
  - "CS0463"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0463"
ms.assetid: 0cb4be4e-86ea-4ade-8817-b17d4cacd4d5
caps.latest.revision: 11
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
# Compiler Error CS0463
Evaluation of the decimal constant expression failed with error: 'error'  
  
 This errors occurs when a constant decimal expression overflows at compile time.  
  
 Typically you get overflow errors at run time. In this case, you defined the constant expression in such a way that the compiler could evaluate the result and know that an overflow would happen.  
  
## Example  
 The following code generates error CS0463.  
  
```  
// CS0463.cs   
using System;   
class MyClass   
{  
    public static void Main()      
    {  
        const decimal myDec = 79000000000000000000000000000.0m + 79000000000000000000000000000.0m; // CS0463  
        Console.WriteLine(myDec.ToString());  
    }  
}  
```