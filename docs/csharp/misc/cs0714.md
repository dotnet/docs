---
title: "Compiler Error CS0714 | Microsoft Docs"
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
  - "CS0714"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0714"
ms.assetid: fbb5dc55-645c-4980-bf4b-3c2f84a3c6cd
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
# Compiler Error CS0714
'static type' : static classes cannot implement interfaces  
  
 Interfaces may define non-static methods on objects and hence may not be implemented by static classes. To resolve this error, make sure your class does not attempt to implement any interfaces.  
  
## Example  
 The following sample generates CS0714:  
  
```  
// CS0714.cs  
interface I  
{  
}  
  
public static class C : I  // CS0714  
{  
    public static void Main()  
    {  
    }  
}  
```