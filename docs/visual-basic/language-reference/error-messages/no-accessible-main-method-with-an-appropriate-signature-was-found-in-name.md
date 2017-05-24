---
title: "No accessible &#39;Main&#39; method with an appropriate signature was found in &#39;&lt;name&gt;&#39; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc30737"
  - "vbc30737"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30737"
ms.assetid: 3f40bacd-3fac-4741-b204-852f693d4340
caps.latest.revision: 11
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
# No accessible &#39;Main&#39; method with an appropriate signature was found in &#39;&lt;name&gt;&#39;
Command-line applications must have a `Sub Main` defined. `Main` must be declared as `Public Shared` if it is defined in a class, or as `Public` if defined in a module.  
  
 For more information on `Main`, see [NIB: Visual Basic Version of Hello, World](http://msdn.microsoft.com/en-us/9d030b60-e148-4366-a462-69532f02294c).  
  
 **Error ID:** BC30737  
  
## To correct this error  
  
-   Define a `Public Sub Main` procedure for your project. Declare it as `Shared` if and only if you define it inside a class.  
  
## See Also  
 [NIB: Visual Basic Version of Hello, World](http://msdn.microsoft.com/en-us/9d030b60-e148-4366-a462-69532f02294c)   
 [Structure of a Visual Basic Program](../../../visual-basic/programming-guide/program-structure/structure-of-a-visual-basic-program.md)   
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)