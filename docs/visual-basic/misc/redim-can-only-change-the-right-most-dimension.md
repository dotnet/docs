---
title: "&#39;ReDim&#39; can only change the right-most dimension | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrArray_TypeMismatch"
ms.assetid: d53cf41b-7a7a-466c-a29a-920d99698fa9
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent

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
# &#39;ReDim&#39; can only change the right-most dimension
A `ReDim` statement attempted to use the `Preserve` keyword to change a dimension of an array that is not the last dimension. When using `Preserve`, you can resize only the last dimension of an array. For all other dimensions, you must specify the same size as for the existing array.  
  
## To correct this error  
  
-   Remove the `Preserve` keyword.  
  
## See Also  
 [NOTINBUILD Overview of Arrays in Visual Basic](http://msdn.microsoft.com/en-us/ca50e2f2-b4d2-4c57-9169-9abbcc3392d8)   
 [NOTINBUILD Multidimensional Arrays in Visual Basic](http://msdn.microsoft.com/en-us/d92cad25-07e2-4d79-8ea4-ab269700f5de)   
 [ReDim Statement](../../visual-basic/language-reference/statements/redim-statement.md)   
 [Dim Statement](../../visual-basic/language-reference/statements/dim-statement.md)   
 [Preserve - delete](http://msdn.microsoft.com/en-us/91badeab-b4e0-48b6-92c9-9f0c8f995d81)