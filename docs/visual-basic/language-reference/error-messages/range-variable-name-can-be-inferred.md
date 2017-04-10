---
title: "Range variable name can be inferred only from a simple or qualified name with no arguments | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc36599"
  - "bc36599"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC36599"
ms.assetid: 17763dbe-f74f-4ccb-8086-cb7e45ec4d12
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Range variable name can be inferred only from a simple or qualified name with no arguments
A programming element that takes one or more arguments is included in a LINQ query. The compiler is unable to infer a range variable from that programming element.  
  
 **Error ID:** BC36599  
  
## To correct this error  
  
1.  Supply an explicit variable name for the programming element, as shown in the following code:  
  
```  
Dim query = From var1 In collection1   
            Select VariableAlias= SampleFunction(var1), var1  
```  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)   
 [Select Clause](../../../visual-basic/language-reference/queries/select-clause.md)