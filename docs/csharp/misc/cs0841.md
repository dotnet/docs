---
title: "Compiler Error CS0841 | Microsoft Docs"
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
  - "CS0841"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0841"
ms.assetid: eb67c244-a930-4291-ae2a-5832e8916ed7
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
# Compiler Error CS0841
Cannot use variable 'name' before it is declared.  
  
 A variable must be declared before it is used.  
  
### To correct this error  
  
1.  Move the variable declaration before the line where the error occurs.  
  
## Example  
 The following example generates CS0841:  
  
```  
// cs0841.cs  
using System;  
  
public class C  
{  
    public static int Main()  
    {  
        j = 5; // CS0841  
        int j; // To fix, move this line up.  
        return 1;  
    }  
}  
```