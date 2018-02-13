---
title: "Ansi (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Ansi"
helpviewer_keywords: 
  - "Declare statement [Visual Basic], marshaling strings [Visual Basic]"
  - "ANSI, Visual Basic"
  - "ANSI"
ms.assetid: 4f1fa6ff-5557-41ab-b6da-90baf4c15917
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Ansi (Visual Basic)
Specifies that Visual Basic should marshal all strings to American National Standards Institute (ANSI) values regardless of the name of the external procedure being declared.  
  
 When you call a procedure defined outside your project, the Visual Basic compiler does not have access to the information it needs to call the procedure correctly. This information includes where the procedure is located, how it is identified, its calling sequence and return type, and the string character set it uses. The [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md) creates a reference to an external procedure and supplies this necessary information.  
  
 The `charsetmodifier` part in the `Declare` statement supplies the character set information for marshaling strings during a call to the external procedure. It also affects how Visual Basic searches the external file for the external procedure name. The `Ansi` modifier specifies that Visual Basic should marshal all strings to ANSI values and should look up the procedure without modifying its name during the search.  
  
 If no character set modifier is specified, `Ansi` is the default.  
  
## Remarks  
 The `Ansi` modifier can be used in this context:  
  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
## Smart Device Developer Notes  
 This keyword is not supported.  
  
## See Also  
 [Auto](../../../visual-basic/language-reference/modifiers/auto.md)  
 [Unicode](../../../visual-basic/language-reference/modifiers/unicode.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)
