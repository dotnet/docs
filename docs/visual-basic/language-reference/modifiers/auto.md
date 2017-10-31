---
title: "Auto (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Auto"
helpviewer_keywords: 
  - "Auto keyword [Visual Basic], external references"
  - "Declare statement [Visual Basic], marshaling strings"
  - "Auto keyword [Visual Basic]"
  - "Auto keyword [Visual Basic], marshaling strings"
ms.assetid: bf79ba95-a62c-48a5-916f-0ac7a52c13ec
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Auto (Visual Basic)
Specifies that Visual Basic should marshal strings according to .NET Framework rules based on the external name of the external procedure being declared.  
  
 When you call a procedure defined outside your project, the Visual Basic compiler does not have access to the information it must have to call the procedure correctly. This information includes where the procedure is located, how it is identified, its calling sequence and return type, and the string character set it uses. The [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md) creates a reference to an external procedure and supplies this necessary information.  
  
 The `charsetmodifier` part in the `Declare` statement supplies the character set information for marshaling strings during a call to the external procedure. It also affects how Visual Basic searches the external file for the external procedure name. The `Auto` modifier specifies that Visual Basic should marshal strings according to .NET Framework rules, and that it should determine the base character set of the run-time platform and possibly modify the external procedure name if the initial search fails. For more information, see "Character Sets" in [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md).  
  
 If no character set modifier is specified, `Ansi` is the default.  
  
## Remarks  
 The `Auto` modifier can be used in this context:  
  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
## Smart Device Developer Notes  
 This keyword is not supported.  
  
## See Also  
 [Ansi](../../../visual-basic/language-reference/modifiers/ansi.md)  
 [Unicode](../../../visual-basic/language-reference/modifiers/unicode.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)
