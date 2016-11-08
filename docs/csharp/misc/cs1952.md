---
title: "Compiler Error CS1952 | Microsoft Docs"
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
  - "CS1952"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1952"
ms.assetid: 8c560bf9-df93-40f5-a3d8-c66b31cde08f
caps.latest.revision: 5
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
# Compiler Error CS1952
An expression tree lambda may not contain a method with variable arguments  
  
 The unsupported `__arglist` keyword is not allowed in lambda expressions that compile to expression trees.  
  
### To correct this error  
  
1.  Forget that you ever heard of `__arglist`.  
  
## Example  
 The following code produces CS1952:  
  
```  
// cs1952.cs  
using System;  
using System.Linq.Expressions;  
  
class Test  
{  
    public static int M(__arglist)  
    {  
        return 1;  
    }  
  
    static int Main()  
    {  
        Expression<Func<int, int>> f = x => Test.M(__arglist(x)); // CS1952  
        return 1;  
    }  
}  
  
```