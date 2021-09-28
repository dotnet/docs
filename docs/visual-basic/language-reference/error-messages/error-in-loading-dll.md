---
description: "Learn more about: Error in loading DLL (Visual Basic)"
title: "Error in loading DLL"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID48"
ms.assetid: 4226cd1f-028c-477d-88a5-cb57f7e0cdc8
---
# Error in loading DLL (Visual Basic)

A dynamic-link library (DLL) is a library specified in the `Lib` clause of a `Declare` statement. Possible causes for this error include:  
  
- The file is not DLL executable.  
  
- The file is not a Microsoft Windows DLL.  
  
- The DLL references another DLL that is not present.  
  
- The DLL or referenced DLL is not in a directory specified in the path.  
  
## To correct this error  
  
- If the file is a source-text file and therefore not DLL executable, it must be compiled and linked to a DLL-executable form.  
  
- If the file is not a Microsoft Windows DLL, obtain the Microsoft Windows equivalent.  
  
- If the DLL references another DLL that is not present, obtain the referenced DLL and make it available.  
  
- If the DLL or referenced DLL is not in a directory specified by the path, move the DLL to a referenced directory.  
  
## See also

- [Declare Statement](../statements/declare-statement.md)
