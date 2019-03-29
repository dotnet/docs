---
title: "Class does not support Automation or does not support expected interface"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID430"
ms.assetid: d985bb7e-e48e-443e-86f2-ddb86758757c
---
# Class does not support Automation or does not support expected interface
Either the class you specified in the `GetObject` or `CreateObject` function call has not exposed a programmability interface, or you changed a project from .dll to .exe, or vice versa.  
  
## To correct this error  
  
1.  Check the documentation of the application that created the object for limitations on the use of automation with this class of object.  
  
2.  If you changed a project from .dll to .exe or vice versa, you must manually unregister the old .dll or .exe.  
  
## See also
- [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)
- [Talk to Us](/visualstudio/ide/talk-to-us)
