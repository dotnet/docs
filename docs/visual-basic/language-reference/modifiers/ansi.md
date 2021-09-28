---
description: "Learn more about: Ansi (Visual Basic)"
title: "Ansi"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Ansi"
helpviewer_keywords: 
  - "Declare statement [Visual Basic], marshaling strings [Visual Basic]"
  - "ANSI, Visual Basic"
  - "ANSI"
ms.assetid: 4f1fa6ff-5557-41ab-b6da-90baf4c15917
---
# Ansi (Visual Basic)

Specifies that Visual Basic should marshal all strings to American National Standards Institute (ANSI) values regardless of the name of the external procedure being declared.  
  
 When you call a procedure defined outside your project, the Visual Basic compiler does not have access to the information it needs to call the procedure correctly. This information includes where the procedure is located, how it is identified, its calling sequence and return type, and the string character set it uses. The [Declare Statement](../statements/declare-statement.md) creates a reference to an external procedure and supplies this necessary information.  
  
 The `charsetmodifier` part in the `Declare` statement supplies the character set information for marshaling strings during a call to the external procedure. It also affects how Visual Basic searches the external file for the external procedure name. The `Ansi` modifier specifies that Visual Basic should marshal all strings to ANSI values and should look up the procedure without modifying its name during the search.  
  
 If no character set modifier is specified, `Ansi` is the default.  
  
## Remarks  

 The `Ansi` modifier can be used in this context:  
  
 [Declare Statement](../statements/declare-statement.md)  
  
## Smart Device Developer Notes  

 This keyword is not supported.  
  
## See also

- [Auto](auto.md)
- [Unicode](unicode.md)
- [Keywords](../keywords/index.md)
