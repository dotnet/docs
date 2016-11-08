---
title: "Compiler Error CS1934 | Microsoft Docs"
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
  - "CS1934"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1934"
ms.assetid: 18624be3-d534-4695-bafd-cc664fcde15e
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
# Compiler Error CS1934
Could not find an implementation of the query pattern for source type 'type'. 'method' not found. Consider explicitly specifying the type of the range variable 'name'.  
  
 This error is produced if a query expression specifies a data source for which no standard query operators are implemented. One way to produce this error is to specify an `ArrayList` without giving an explicit type for the range variable.  
  
### To correct this error  
  
1.  In the following example, the solution is to just specify the type of the range variable:  
  
    ```  
    var q = from int x in list  
    ```  
  
## Example  
 The following example shows one way to produce CS1934:  
  
```  
// cs1934.cs  
using System.Linq;  
using System.Collections;  
static class Test  
{  
    public static void Main()  
    {  
        var list = new ArrayList { 0, 1, 2, 3, 4, 5 };  
        var q = from x in list // CS1934  
                select x + 1;  
    }  
}  
```  
  
## See Also  
 [How to: Query an ArrayList with LINQ](../Topic/How%20to:%20Query%20an%20ArrayList%20with%20LINQ.md)