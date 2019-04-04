---
title: "Statement cannot end a block outside of a line 'If' statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc32005"
  - "bc32005"
helpviewer_keywords: 
  - "BC32005"
ms.assetid: 4039f51b-e0ee-4789-a89b-45d06de06b5d
---
# Statement cannot end a block outside of a line 'If' statement
A single-line `If` statement contains several statements separated by colons (:), one of which is an `End` statement for a control block outside the single-line `If`. Single-line `If` statements do not use the `End If` statement.  
  
 **Error ID:** BC32005  
  
## To correct this error  
  
-   Move the single-line `If` statement outside the control block that contains the `End If` statement.  
  
## See also

- [If...Then...Else Statement](../../../visual-basic/language-reference/statements/if-then-else-statement.md)
