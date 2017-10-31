---
title: "Arrays declared as structure members cannot be declared with an initial size"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc31043"
  - "bc31043"
helpviewer_keywords: 
  - "BC31043"
ms.assetid: 5bd90c71-1b78-444b-91e1-4789451ef085
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Arrays declared as structure members cannot be declared with an initial size
An array in a structure is declared with an initial size. You cannot initialize any structure element, and declaring an array size is one form of initialization.  
  
 **Error ID:** BC31043  
  
## To correct this error  
  
1.  Define the array in your structure as dynamic (no initial size).  
  
2.  If you require a certain size of array, you can redimension a dynamic array with a [ReDim Statement](../../../visual-basic/language-reference/statements/redim-statement.md) when your code is running. The following example illustrates this.  
  
    ```  
    Structure demoStruct  
        Public demoArray() As Integer  
    End Structure  
    Sub useStruct()  
        Dim struct As demoStruct  
        ReDim struct.demoArray(9)  
        Struct.demoArray(2) = 777  
    End Sub  
    ```  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)  
 [How to: Declare a Structure](../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)
