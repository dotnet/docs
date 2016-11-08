---
title: "Compiler Error CS1951 | Microsoft Docs"
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
  - "CS1951"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1951"
ms.assetid: 799ba212-a000-44d9-b7da-a8c00eae63fa
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
# Compiler Error CS1951
An expression tree lambda may not contain an out or ref parameter.  
  
 An expression tree just represents expressions as data structures. There is no way to represent specific memory locations as is required when you pass a parameter by reference.  
  
### To correct this error  
  
1.  The only option is to remove the `ref` modifier in the delegate definition and pass in the parameter by value.  
  
## Example  
 The following example generates CS1951:  
  
```  
// cs1951.cs  
using System.Linq;  
public delegate int TestDelegate(ref int i);  
class Test  
{  
    static void Main()  
    {  
        System.Linq.Expressions.Expression<TestDelegate> tree1 = (ref int x) => x; // CS1951  
    }  
}  
```  
  
## See Also  
 [Expression Trees](../Topic/Expression%20Trees%20\(C%23%20and%20Visual%20Basic\).md)