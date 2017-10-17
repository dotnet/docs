---
title: "Array bounds cannot appear in type specifiers"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30638"
  - "bc30638"
helpviewer_keywords: 
  - "BC30638"
ms.assetid: 93b654f4-70fa-4a48-baed-ffae42075550
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
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
