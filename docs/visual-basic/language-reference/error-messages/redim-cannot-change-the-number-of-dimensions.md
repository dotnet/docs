---
title: "'ReDim' cannot change the number of dimensions"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrArray_RankMismatch"
ms.assetid: 52505298-9985-4682-8f6e-ff7d56077f34
---
# 'ReDim' cannot change the number of dimensions
An operation attempts to use the `ReDim` statement to change the rank (number of dimensions) of an array. `ReDim` can change the size of one or more dimensions of an array that has already been formally declared, but it cannot change an array's rank.  
  
## To correct this error  
  
- Ensure that you intend to change the array's rank and not the sizes of its dimensions, and if possible, use `Dim` to declare a new array with the desired rank.  
  
## See also

- [Arrays in Visual Basic](../programming-guide/language-features/arrays/index.md)
- [Array dimensions in Visual Basic](../programming-guide/language-features/arrays/array-dimensions.md)
- [ReDim Statement](../../visual-basic/language-reference/statements/redim-statement.md)
- [Dim Statement](../../visual-basic/language-reference/statements/dim-statement.md)
