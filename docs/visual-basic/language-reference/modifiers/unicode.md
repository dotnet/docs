---
description: "Learn more about: Unicode (Visual Basic)"
title: "Unicode"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Unicode"
helpviewer_keywords: 
  - "Unicode, external references"
  - "Declare statement [Visual Basic], marshaling strings"
  - "Unicode keyword [Visual Basic]"
  - "Unicode, marshaling strings"
ms.assetid: 0021d5ff-3209-444e-8497-420f3e6ee075
---
# Unicode (Visual Basic)

Specifies that Visual Basic should marshal all strings to Unicode values regardless of the name of the external procedure being declared.  
  
 When you call a procedure defined outside your project, the Visual Basic compiler does not have access to the information it must have in order to call the procedure correctly. This information includes where the procedure is located, how it is identified, its calling sequence and return type, and the string character set it uses. The [Declare Statement](../statements/declare-statement.md) creates a reference to an external procedure and supplies this necessary information.  
  
 The `charsetmodifier` part in the `Declare` statement supplies the character set information to marshal strings during a call to the external procedure. It also affects how Visual Basic searches the external file for the external procedure name. The `Unicode` modifier specifies that Visual Basic should marshal all strings to Unicode values and should look up the procedure without modifying its name during the search.  
  
 If no character set modifier is specified, `Ansi` is the default.  
  
## Remarks  

 The `Unicode` modifier can be used in this context:  
  
 [Declare Statement](../statements/declare-statement.md)  
  
## Smart Device Developer Notes  

 This keyword is not supported.  
  
## See also

- [Ansi](ansi.md)
- [Auto](auto.md)
- [Keywords](../keywords/index.md)
