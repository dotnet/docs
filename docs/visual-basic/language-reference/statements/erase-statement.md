---
title: "Erase Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Erase"
helpviewer_keywords: 
  - "Erase keyword [Visual Basic]"
  - "Erase statement [Visual Basic]"
ms.assetid: 7a8133d7-b750-4d74-8b66-ba1dd9778d4b
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Erase Statement (Visual Basic)
Used to release array variables and deallocate the memory used for their elements.  
  
## Syntax  
  
```  
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
  
 [!code-vb[VbVbalrStatements#19](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/erase-statement_1.vb)]  
  
## See Also  
 [Nothing](../../../visual-basic/language-reference/nothing.md)  
 [ReDim Statement](../../../visual-basic/language-reference/statements/redim-statement.md)
