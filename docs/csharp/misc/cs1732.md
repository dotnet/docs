---
title: "Compiler Error CS1732 | Microsoft Docs"
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
  - "CS1732"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1732"
ms.assetid: 72c7f7fc-d5f2-4538-9b02-50dda54d3b1e
caps.latest.revision: 8
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
# Compiler Error CS1732
Expected parameter.  
  
 This error is produced when a lambda expression contains a comma following an input parameter but does not specify the following parameter.  
  
### To correct this error  
  
1.  Either remove the comma, or add the input parameter that the compiler expects to find after the comma.  
  
## Example  
 The following example produces CS1732:  
  
```  
// cs1732.cs  
// compile with: /target:library  
class Test  
    {  
        delegate void D(int x, int y);  
        static void Main()  
        {  
        D d = (x,) => { }; // CS1732  
      }  
    }  
```