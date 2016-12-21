---
title: "Compiler Error CS0226 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS0226"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0226"
ms.assetid: 9f8c74c4-de21-41fb-84e1-ef32a4b23ced
caps.latest.revision: 6
author: "BillWagner"
ms.author: "wiwagn"

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
# Compiler Error CS0226
An __arglist expression may only appear inside of a call or new expression.  
  
 The unsupported keyword `__arglist` can only appear in a method call or a new expression.  
  
## Example  
 The following code generates CS0226:  
  
```  
// cs0226.cs  
using System;  
  
public class C  
    {  
    public static int Main ()  
        {  
        __arglist(1,"This is a string"); // CS0226  
        return 0;  
        }  
    }  
```