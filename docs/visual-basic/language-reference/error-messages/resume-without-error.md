---
description: "Learn more about: Resume without error"
title: "Resume without error"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID20"
ms.assetid: f9631804-fd36-4443-b36c-30db827e6176
---
# Resume without error

A `Resume` statement appeared outside error-handling code, or the code jumped into an error handler even though there was no error.  
  
## To correct this error  
  
1. Move the `Resume` statement into an error handler, or delete it.  
  
2. Jumps to labels cannot occur across procedures, so search the procedure for the label that identifies the error handler. If you find a duplicate label specified as the target of a `GoTo` statement that isn't an `On Error GoTo` statement, change the line label to agree with its intended target.  
  
## See also

- [Resume Statement](../statements/resume-statement.md)
- [On Error Statement](../statements/on-error-statement.md)
