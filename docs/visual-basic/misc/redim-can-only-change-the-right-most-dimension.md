---
title: "'ReDim' can only change the right-most dimension"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrArray_TypeMismatch"
ms.assetid: d53cf41b-7a7a-466c-a29a-920d99698fa9
---
# 'ReDim' can only change the right-most dimension
A `ReDim` statement attempted to use the `Preserve` keyword to change a dimension of an array that is not the last dimension. When using `Preserve`, you can resize only the last dimension of an array. For all other dimensions, you must specify the same size as for the existing array.  
  
## To correct this error  
  
-   Remove the `Preserve` keyword.  
  
## See also
 [Arrays in Visual Basic](~/docs/visual-basic/programming-guide/language-features/arrays/index.md)  
 [Array dimensions in Visual Basic](~/docs/visual-basic/programming-guide/language-features/arrays/array-dimensions.md)  
 [ReDim Statement](../../visual-basic/language-reference/statements/redim-statement.md)  
 [Dim Statement](../../visual-basic/language-reference/statements/dim-statement.md)  
 [Preserve - delete](https://msdn.microsoft.com/library/91badeab-b4e0-48b6-92c9-9f0c8f995d81)
