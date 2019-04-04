---
title: "'Loop' cannot have a condition if matching 'Do' has one"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc30238"
  - "bc30238"
helpviewer_keywords: 
  - "BC30238"
ms.assetid: 81513cb5-69e7-4d62-b33e-e54cb8c5e8bf
---
# 'Loop' cannot have a condition if matching 'Do' has one
A `Loop` statement contains a `While` or `Until` clause, and the corresponding `Do` statement also contains such a clause. Only one of the `Do` and `Loop` statements in a loop can specify a condition.  
  
 **Error ID:** BC30238  
  
## To correct this error  
  
-   Remove the `While` or `Until` clause from either the `Do` statement or the `Loop` statement.  
  
## See also

- [Do...Loop Statement](../../visual-basic/language-reference/statements/do-loop-statement.md)
