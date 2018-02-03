---
title: "How to: Protect a Procedure Argument Against Value Changes (Visual Basic)"
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
  - "procedures [Visual Basic], parameters"
  - "procedure arguments"
  - "arguments [Visual Basic], passing by reference"
  - "Visual Basic code, procedures"
  - "arguments [Visual Basic], ByVal"
  - "arguments [Visual Basic], passing by value"
  - "procedure parameters"
  - "procedures [Visual Basic], calling"
  - "arguments [Visual Basic], ByRef"
  - "arguments [Visual Basic], changing value"
ms.assetid: d2b7c766-ce16-4d2c-8d79-3fc0e7ba2227
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Protect a Procedure Argument Against Value Changes (Visual Basic)
If a procedure declares a parameter as [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md), [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] gives the procedure code a direct reference to the programming element underlying the argument in the calling code. This permits the procedure to change the value underlying the argument in the calling code. In some cases the calling code might want to protect against such a change.  
  
 You can always protect an argument from change by declaring the corresponding parameter [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) in the procedure. If you want to be able to change a given argument in some cases but not others, you can declare it `ByRef` and let the calling code determine the passing mechanism in each call. It does this by enclosing the corresponding argument in parentheses to pass it by value, or not enclosing it in parentheses to pass it by reference. For more information, see [How to: Force an Argument to Be Passed by Value](./how-to-force-an-argument-to-be-passed-by-value.md).  
  
## Example  
 The following example shows two procedures that take an array variable and operate on its elements. The `increase` procedure simply adds one to each element. The `replace` procedure assigns a new array to the parameter `a()` and then adds one to each element. However, the reassignment does not affect the underlying array variable in the calling code.  
  
 [!code-vb[VbVbcnProcedures#35](./codesnippet/VisualBasic/how-to-protect-a-procedure-argument-against-value-changes_1.vb)]  
  
 [!code-vb[VbVbcnProcedures#38](./codesnippet/VisualBasic/how-to-protect-a-procedure-argument-against-value-changes_2.vb)]  
  
 [!code-vb[VbVbcnProcedures#37](./codesnippet/VisualBasic/how-to-protect-a-procedure-argument-against-value-changes_3.vb)]  
  
 The first `MsgBox` call displays "After increase(n): 11, 21, 31, 41". Because the array `n` is a reference type, `replace` can change its members, even though the passing mechanism is `ByVal`.  
  
 The second `MsgBox` call displays "After replace(n): 11, 21, 31, 41". Because `n` is passed `ByVal`, `replace` cannot modify the variable `n` in the calling code by assigning a new array to it. When `replace` creates the new array instance `k` and assigns it to the local variable `a`, it loses the reference to `n` passed in by the calling code. When it changes the members of `a`, only the local array `k` is affected. Therefore, `replace` does not increment the values of array `n` in the calling code.  
  
## Compiling the Code  
 The default in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is to pass arguments by value. However, it is good programming practice to include either the [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) or [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) keyword with every declared parameter. This makes your code easier to read.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Differences Between Modifiable and Nonmodifiable Arguments](./differences-between-modifiable-and-nonmodifiable-arguments.md)  
 [Differences Between Passing an Argument By Value and By Reference](./differences-between-passing-an-argument-by-value-and-by-reference.md)  
 [How to: Change the Value of a Procedure Argument](./how-to-change-the-value-of-a-procedure-argument.md)  
 [How to: Force an Argument to Be Passed by Value](./how-to-force-an-argument-to-be-passed-by-value.md)  
 [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)
