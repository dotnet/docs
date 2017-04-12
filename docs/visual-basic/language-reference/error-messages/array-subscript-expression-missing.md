---
title: "Array subscript expression missing | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net

ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc30306"
  - "vbc30306"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30306"
ms.assetid: 3c0d9732-ee37-436f-a1df-29d65712f48a
caps.latest.revision: 9
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
# Array subscript expression missing
An array initialization leaves out one or more of the subscripts that define the array bounds. For example, the statement might contain the expression `myArray (5,5,,10)`, which leaves out the third subscript.  
  
 **Error ID:** BC30306  
  
## To correct this error  
  
-   Supply the missing subscript.  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)