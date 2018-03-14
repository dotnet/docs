---
title: "ReDim Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ReDim"
  - "vb.Preserve"
helpviewer_keywords: 
  - "fixed-length strings [Visual Basic], declaring"
  - "ReDim statement [Visual Basic], syntax"
  - "dynamic arrays [Visual Basic], ReDim statement"
  - "arrays [Visual Basic], reallocating"
  - "arrays [Visual Basic], reinitializing"
  - "arrays [Visual Basic], dimensions"
  - "scalars, and arrays"
  - "scalars"
  - "declarations [Visual Basic], dynamic arrays"
  - "variables [Visual Basic], scalar"
  - "ReDim statement [Visual Basic]"
  - "data types [Visual Basic], assigning"
  - "As keyword [Visual Basic], in ReDim statement"
  - "To keyword [Visual Basic], ReDim statement"
  - "arrays [Visual Basic], declaring"
  - "Preserve keyword [Visual Basic], ReDim statement"
  - "storage [Visual Basic], allocating"
  - "arrays [Visual Basic], and scalars"
  - "declaration statements [Visual Basic]"
  - "scalar variables [Visual Basic]"
ms.assetid: ad1c5e07-dcd7-4ae1-a79e-ad3f2dcc2083
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
---
# ReDim Statement (Visual Basic)
Reallocates storage space for an array variable.  
  
## Syntax  
  
```  
ReDim [ Preserve ] name(boundlist) [ ,  name(boundlist) [, ... ] ]  
```  
  
## Parts  
  
|Term|Definition|  
|----------|----------------|  
|`Preserve`|Optional. Modifier used to preserve the data in the existing array when you change the size of only the last dimension.|  
|`name`|Required. Name of the array variable. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).|  
|`boundlist`|Required. List of bounds of each dimension of the redefined array.|  
  
## Remarks  
 You can use the `ReDim` statement to change the size of one or more dimensions of an array that has already been declared. If you have a large array and you no longer need some of its elements, `ReDim` can free up memory by reducing the array size. On the other hand, if your array needs more elements, `ReDim` can add them.  
  
 The `ReDim` statement is intended only for arrays. It's not valid on scalars (variables that contain only a single value), collections, or structures. Note that if you declare a variable to be of type `Array`, the `ReDim` statement doesn't have sufficient type information to create the new array.  
  
 You can use `ReDim` only at procedure level. Therefore, the declaration context for the variable must be a procedure; it can't be a source file, a namespace, an interface, a class, a structure, a module, or a block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
## Rules  
  
-   **Multiple Variables.** You can resize several array variables in the same declaration statement and specify the `name` and `boundlist` parts for each variable. Multiple variables are separated by commas.  
  
-   **Array Bounds.** Each entry in `boundlist` can specify the lower and upper bounds of that dimension. The lower bound is always 0 (zero). The upper bound is the highest possible index value for that dimension, not the length of the dimension (which is the upper bound plus one). The index for each dimension can vary from 0 through its upper bound value.  
  
     The number of dimensions in `boundlist` must match the original number of dimensions (rank) of the array.  
  
-   **Data Types.** The `ReDim` statement cannot change the data type of an array variable or its elements.  
  
-   **Initialization.** The `ReDim` statement cannot provide new initialization values for the array elements.  
  
-   **Rank.** The `ReDim` statement cannot change the rank (the number of dimensions) of the array.  
  
-   **Resizing with Preserve.** If you use `Preserve`, you can resize only the last dimension of the array. For every other dimension, you must specify the bound of the existing array.  
  
     For example, if your array has only one dimension, you can resize that dimension and still preserve all the contents of the array, because you are changing the last and only dimension. However, if your array has two or more dimensions, you can change the size of only the last dimension if you use `Preserve`.  
  
-   **Properties.** You can use `ReDim` on a property that holds an array of values.  
  
## Behavior  
  
-   **Array Replacement.** `ReDim` releases the existing array and creates a new array with the same rank. The new array replaces the released array in the array variable.  
  
-   **Initialization without Preserve.** If you do not specify `Preserve`, `ReDim` initializes the elements of the new array by using the default value for their data type.  
  
-   **Initialization with Preserve.** If you specify `Preserve`, Visual Basic copies the elements from the existing array to the new array.  
  
## Example  
 The following example increases the size of the last dimension of a dynamic array without losing any existing data in the array, and then decreases the size with partial data loss. Finally, it decreases the size back to its original value and reinitializes all the array elements.  
  
 [!code-vb[VbVbalrStatements#52](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/redim-statement_1.vb)]  
  
 The `Dim` statement creates a new array with three dimensions. Each dimension is declared with a bound of 10, so the array index for each dimension can range from 0 through 10. In the following discussion, the three dimensions are referred to as layer, row, and column.  
  
 The first `ReDim` creates a new array which replaces the existing array in variable `intArray`. `ReDim` copies all the elements from the existing array into the new array. It also adds 10 more columns to the end of every row in every layer and initializes the elements in these new columns to 0 (the default value of `Integer`, which is the element type of the array).  
  
 The second `ReDim` creates another new array and copies all the elements that fit. However, five columns are lost from the end of every row in every layer. This is not a problem if you have finished using these columns. Reducing the size of a large array can free up memory that you no longer need.  
  
 The third `ReDim` creates another new array and removes another five columns from the end of every row in every layer. This time it does not copy any existing elements. This statement reverts the array to its original size. Because the statement doesn't include the `Preserve` modifier, it sets all array elements to their original default values.  
  
 For additional examples, see [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md).  
  
## See Also  
 <xref:System.IndexOutOfRangeException>  
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
 [Erase Statement](../../../visual-basic/language-reference/statements/erase-statement.md)  
 [Nothing](../../../visual-basic/language-reference/nothing.md)  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)
