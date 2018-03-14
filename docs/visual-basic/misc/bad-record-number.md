---
title: "Bad record number"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID63"
ms.assetid: 1fcc33f8-822a-4de9-a6e3-228ddb5824a6
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Bad record number
The record number in `a FileGet`, `FilePut`, `FileGetObject`, or `FilePutObject` statement is less than or equal to zero.  
  
## To correct this error  
  
1.  Check the calculations used in generating the record number. Verify spelling of the variables containing the record number or used in calculating record numbers. A misspelled variable name is implicitly declared and initialized to zero, unless you used `Option Explicit On` in the module.  
  
## See Also  
 [Option Explicit Statement](../../visual-basic/language-reference/statements/option-explicit-statement.md)
