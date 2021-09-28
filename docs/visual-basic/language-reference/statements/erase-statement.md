---
description: "Learn more about: Erase Statement (Visual Basic)"
title: "Erase Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Erase"
helpviewer_keywords: 
  - "Erase keyword [Visual Basic]"
  - "Erase statement [Visual Basic]"
ms.assetid: 7a8133d7-b750-4d74-8b66-ba1dd9778d4b
---
# Erase Statement (Visual Basic)

Used to release array variables and deallocate the memory used for their elements.  
  
## Syntax  
  
```vb  
Erase arraylist  
```  
  
## Parts  

 `arraylist`  
 Required. List of array variables to be erased. Multiple variables are separated by commas.  
  
## Remarks  

 The `Erase` statement can appear only at procedure level. This means you can release arrays inside a procedure but not at class or module level.  
  
 The `Erase` statement is equivalent to assigning `Nothing` to each array variable.  
  
## Example  

 The following example uses the `Erase` statement to clear two arrays and free their memory (1000 and 100 storage elements, respectively). The `ReDim` statement then assigns a new array instance to the three-dimensional array.  
  
 [!code-vb[VbVbalrStatements#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#19)]  
  
## See also

- [Nothing](../nothing.md)
- [ReDim Statement](redim-statement.md)
