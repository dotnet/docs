---
title: "Differences Between Modifiable and Nonmodifiable Arguments (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedures [Visual Basic], arguments"
  - "procedure arguments"
  - "arguments [Visual Basic], nonmodifiable"
  - "Visual Basic code, procedures"
  - "arguments [Visual Basic], modifiable"
ms.assetid: 87b2df69-e1f7-4657-9caf-b3f48d693428
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Differences Between Modifiable and Nonmodifiable Arguments (Visual Basic)
When you call a procedure, you typically pass one or more arguments to it. Each argument corresponds to an underlying programming element. Both the underlying elements and the arguments themselves can be either modifiable or nonmodifiable.  
  
## Modifiable and Nonmodifiable Elements  
 A programming element can be either a *modifiable element*, which can have its value changed, or a *nonmodifiable element*, which has a fixed value once it has been created.  
  
 The following table lists modifiable and nonmodifiable programming elements.  
  
|Modifiable elements|Nonmodifiable elements|  
|-------------------------|----------------------------|  
|Local variables (declared inside procedures), including object variables, except for read-only|Read-only variables, fields, and properties|  
|Fields (member variables of modules, classes, and structures), except for read-only|Constants and literals|  
|Properties, except for read-only|Enumeration members|  
|Array elements|Expressions (even if their elements are modifiable)|  
  
## Modifiable and Nonmodifiable Arguments  
 A *modifiable argument* is one with a modifiable underlying element. The calling code can store a new value at any time, and if you pass the argument [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md), the code in the procedure can also modify the underlying element in the calling code.  
  
 A *nonmodifiable argument* either has a nonmodifiable underlying element or is passed [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md). The procedure cannot modify the underlying element in the calling code, even if it is a modifiable element. If it is a nonmodifiable element, the calling code itself cannot modify it.  
  
 The called procedure might modify its local copy of a nonmodifiable argument, but that modification does not affect the underlying element in the calling code.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Differences Between Passing an Argument By Value and By Reference](./differences-between-passing-an-argument-by-value-and-by-reference.md)  
 [How to: Change the Value of a Procedure Argument](./how-to-change-the-value-of-a-procedure-argument.md)  
 [How to: Protect a Procedure Argument Against Value Changes](./how-to-protect-a-procedure-argument-against-value-changes.md)  
 [How to: Force an Argument to Be Passed by Value](./how-to-force-an-argument-to-be-passed-by-value.md)  
 [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)
