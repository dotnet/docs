---
title: "Compiler Error CS1637 | Microsoft Docs"
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
  - "CS1637"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1637"
ms.assetid: 95aa82ab-bd52-4def-b5f3-d65e6dcb3855
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
# Compiler Error CS1637
Iterators cannot have unsafe parameters or yield types  
  
 Check the argument list of the iterator and the type of any yield statements to verify that you are not using any unsafe types.  
  
## Example  
 The following sample generates CS1637:  
  
```  
// CS1637.cs  
// compile with: /unsafe  
using System.Collections;  
  
public unsafe class C  
{  
    public IEnumerator Iterator1(int* p)  // CS1637  
    {  
        yield return null;  
    }  
}  
```