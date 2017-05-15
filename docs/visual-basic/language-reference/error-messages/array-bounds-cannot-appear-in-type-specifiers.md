---
title: "Array bounds cannot appear in type specifiers | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net

ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc30638"
  - "bc30638"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30638"
ms.assetid: 93b654f4-70fa-4a48-baed-ffae42075550
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
# Array bounds cannot appear in type specifiers
Array sizes cannot be declared as part of a data type specifier.  
  
 **Error ID:** BC30638  
  
## To correct this error  
  
-   Specify the size of the array immediately following the variable name instead of placing the array size after the type, as shown in the following example.  
  
    ```  
    Dim Array(8) As Integer   
    ```  
  
-   Define an array and initialize it with the desired number of elements, as shown in the following example.  
  
    ```  
    Dim Array2() As Integer = New Integer(8) {}  
    ```  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)