---
title: "'Module' statements can occur only at file or namespace level"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30617"
  - "vbc30617"
helpviewer_keywords: 
  - "BC30617"
ms.assetid: 5e9de8e5-d26b-4fb2-9e28-814413fe9cef
---
# 'Module' statements can occur only at file or namespace level
`Module` statements must appear at the top of your source file immediately after `Option` and `Imports` statements, global attributes, and namespace declarations, but before all other declarations.  
  
 **Error ID:** BC30617  
  
## To correct this error  
  
- Move the `Module` statement to the top of your namespace declaration or source file.  
  
## See also

- [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)
