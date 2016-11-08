---
title: "Compiler Error CS1031 | Microsoft Docs"
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
  - "CS1031"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1031"
ms.assetid: 14196659-aaac-4df2-a4ed-0bebb8097d59
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
# Compiler Error CS1031
Type expected  
  
 A type parameter is expected.  
  
## Example  
 The following sample generates CS1031:  
  
```  
// CS1031.cs  
namespace x  
{  
    public class ii  
    {  
    }  
  
    public class a  
    {  
        public static operator +(a aa)   // CS1031  
        // try the following line instead  
        // public static ii operator +(a aa)  
        {  
            return new ii();  
        }  
  
        public static void Main()  
        {  
            e = new base;   // CS1031, not a type  
            e = new this;   // CS1031, not a type  
            e = new ();     // CS1031, not a type  
        }  
    }  
}  
```