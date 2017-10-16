---
title: "Number of indices exceeds the number of dimensions of the indexed array"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30106"
  - "vbc30106"
helpviewer_keywords: 
  - "BC30106"
ms.assetid: 2c5363e1-62c2-4f5a-b675-c7337aeb363d
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Number of indices exceeds the number of dimensions of the indexed array
The number of indices used to access an array element must be exactly the same as the rank of the array, that is, the number of dimensions declared for it.  
  
 **Error ID:** BC30106  
  
## To correct this error  
  
-   Remove subscripts from the array reference until the total number of subscripts equals the rank of the array. For example:  
  
    ```vb  
    Dim gameBoard(3, 3) As String  
  
    ' Incorrect code. The array has two dimensions.  
    gameBoard(1, 1, 1) = "X"  
    gameBoard(2, 1, 1) = "O"  
  
    ' Correct code.  
    gameBoard(0, 0) = "X"  
    gameBoard(1, 0) = "O"  
    ```  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)
