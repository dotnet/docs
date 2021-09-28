---
description: "Learn more about: Could not complete operation since target directory is under source directory"
title: "Could not complete operation since target directory is under source directory"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrIO_CyclicOperation"
ms.assetid: 850d3a24-5d51-4ac8-a912-630efcd75278
---
# Could not complete operation since target directory is under source directory

A cyclic operation has failed. Cyclic operations cycle and therefore cannot complete. For example, Object A may attempt to inherit from Object B, which in turn inherits from Object A.  
  
## To correct this error  
  
- When inheriting, make sure that there are no cyclic references.  
  
## See also

- [Error Types](../programming-guide/language-features/error-types.md)
- [Use breakpoints in the Visual Studio debugger](/visualstudio/debugger/using-breakpoints)
