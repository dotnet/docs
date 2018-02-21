---
title: "How to: Change the Value of a Procedure Argument (Visual Basic)"
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
  - "arguments [Visual Basic], ByRef"
  - "arguments [Visual Basic], changing value"
ms.assetid: 6fad2368-5da7-4c07-8bf8-0f4e65a1be67
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Change the Value of a Procedure Argument (Visual Basic)
When you call a procedure, each argument you supply corresponds to one of the parameters defined in the procedure. In some cases, the procedure code can change the value underlying an argument in the calling code. In other cases, the procedure can change only its local copy of an argument.  
  
 When you call the procedure, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes a local copy of every argument that is passed [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md). For each argument passed [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md), [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] gives the procedure code a direct reference to the programming element underlying the argument in the calling code.  
  
 If the underlying element in the calling code is a modifiable element and the argument is passed `ByRef`, the procedure code can use the direct reference to change the element's value in the calling code.  
  
## Changing the Underlying Value  
  
#### To change the underlying value of a procedure argument in the calling code  
  
1.  In the procedure declaration, specify [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) for the parameter corresponding to the argument.  
  
2.  In the calling code, pass a modifiable programming element as the argument.  
  
3.  In the calling code, do not enclose the argument in parentheses in the argument list.  
  
4.  In the procedure code, use the parameter name to assign a value to the underlying element in the calling code.  
  
 See the example further down for a demonstration.  
  
## Changing Local Copies  
 If the underlying element in the calling code is a nonmodifiable element, or if the argument is passed `ByVal`, the procedure cannot change its value in the calling code. However, the procedure can change its local copy of such an argument.  
  
#### To change the copy of a procedure argument in the procedure code  
  
1.  In the procedure declaration, specify [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) for the parameter corresponding to the argument.  
  
     -or-  
  
     In the calling code, enclose the argument in parentheses in the argument list. This forces [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] to pass the argument by value, even if the corresponding parameter specifies `ByRef`.  
  
2.  In the procedure code, use the parameter name to assign a value to the local copy of the argument. The underlying value in the calling code is not changed.  
  
## Example  
 The following example shows two procedures that take an array variable and operate on its elements. The `increase` procedure simply adds one to each element. The `replace` procedure assigns a new array to the parameter `a()` and then adds one to each element.  
  
 [!code-vb[VbVbcnProcedures#35](./codesnippet/VisualBasic/how-to-change-the-value-of-a-procedure-argument_1.vb)]  
  
 [!code-vb[VbVbcnProcedures#36](./codesnippet/VisualBasic/how-to-change-the-value-of-a-procedure-argument_2.vb)]  
  
 [!code-vb[VbVbcnProcedures#37](./codesnippet/VisualBasic/how-to-change-the-value-of-a-procedure-argument_3.vb)]  
  
 The first `MsgBox` call displays "After increase(n): 11, 21, 31, 41". Because the array `n` is a reference type, `replace` can change its members, even though the passing mechanism is `ByVal`.  
  
 The second `MsgBox` call displays "After replace(n): 101, 201, 301". Because `n` is passed `ByRef`, `replace` can modify the variable `n` in the calling code and assign a new array to it. Because `n` is a reference type, `replace` can also change its members.  
  
 You can prevent the procedure from modifying the variable itself in the calling code. See [How to: Protect a Procedure Argument Against Value Changes](./how-to-protect-a-procedure-argument-against-value-changes.md).  
  
## Compiling the Code  
 When you pass a variable by reference, you must use the `ByRef` keyword to specify this mechanism.  
  
 The default in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is to pass arguments by value. However, it is good programming practice to include either the [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) or [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) keyword with every declared parameter. This makes your code easier to read.  
  
## .NET Framework Security  
 There is always a potential risk in allowing a procedure to change the value underlying an argument in the calling code. Make sure you expect this value to be changed, and be prepared to check it for validity before using it.  
  
## See Also  
 [Procedures](./index.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Differences Between Modifiable and Nonmodifiable Arguments](./differences-between-modifiable-and-nonmodifiable-arguments.md)  
 [Differences Between Passing an Argument By Value and By Reference](./differences-between-passing-an-argument-by-value-and-by-reference.md)  
 [How to: Protect a Procedure Argument Against Value Changes](./how-to-protect-a-procedure-argument-against-value-changes.md)  
 [How to: Force an Argument to Be Passed by Value](./how-to-force-an-argument-to-be-passed-by-value.md)  
 [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)
