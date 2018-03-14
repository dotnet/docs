---
title: "This array is fixed or temporarily locked (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID10"
ms.assetid: de6713a6-51d7-4edb-8515-d5fb544e2091
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# This array is fixed or temporarily locked (Visual Basic)
This error has the following possible causes:  
  
-   Using `ReDim` to change the number of elements of a fixed-size array.  
  
-   Redimensioning a module-level dynamic array, in which one element has been passed as an argument to a procedure. If an element is passed, the array is locked to prevent deallocating memory for the reference parameter within the procedure.  
  
-   Attempting to assign a value to a `Variant` variable containing an array, but the `Variant` is currently locked.  
  
## To correct this error  
  
1.  Make the original array dynamic rather than fixed by declaring it with `ReDim` (if the array is declared within a procedure), or by declaring it without specifying the number of elements (if the array is declared at the module level.  
  
2.  Determine whether you really need to pass the element, since it is visible within all procedures in the module.  
  
3.  Determine what is locking the `Variant` and remedy it.  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)
