---
title: "How to: Pass Arguments to a Procedure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "arguments [Visual Basic], passing to procedures"
  - "procedures [Visual Basic], arguments"
  - "procedures [Visual Basic], parameters"
  - "procedure arguments"
  - "Visual Basic code, procedures"
  - "procedure parameters"
  - "procedures [Visual Basic], calling"
  - "argument passing [Visual Basic], procedures"
ms.assetid: 08723588-3890-4ddc-8249-79e049e0f241
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Pass Arguments to a Procedure (Visual Basic)
When you call a procedure, you follow the procedure name with an argument list in parentheses. You supply an argument corresponding to every required parameter the procedure defines, and you can optionally supply arguments to the `Optional` parameters. If you do not supply an `Optional` parameter in the call, you must include a comma to mark its place in the argument list if you are supplying any subsequent arguments.  
  
 If you intend to pass an argument of a data type different from that of its corresponding parameter, such as `Byte` to `String`, you can set the type-checking switch ([Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)) to `Off`. If `Option Strict` is `On`, you must use either widening conversions or explicit conversion keywords. For more information, see [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md) and [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md).  
  
 For more information, see [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md).  
  
### To pass one or more arguments to a procedure  
  
1.  In the calling statement, follow the procedure name with parentheses.  
  
2.  Inside the parentheses, put an argument list. Include an argument for each required parameter the procedure defines, and separate the arguments with commas.  
  
3.  Make sure each argument is a valid expression that evaluates to a data type convertible to the type the procedure defines for the corresponding parameter.  
  
4.  If a parameter is defined as [Optional](../../../../visual-basic/language-reference/modifiers/optional.md), you can either include it in the argument list or omit it. If you omit it, the procedure uses the default value defined for that parameter.  
  
5.  If you omit an argument for an `Optional` parameter and there is another parameter after it in the parameter list, you can mark the place of the omitted argument by an extra comma in the argument list.  
  
     The following example calls the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] <xref:Microsoft.VisualBasic.Interaction.MsgBox%2A> function.  
  
     [!code-vb[VbVbcnProcedures#34](./codesnippet/VisualBasic/how-to-pass-arguments-to-a-procedure_1.vb)]  
  
     The preceding example supplies the required first argument, which is the message string to be displayed. It omits an argument for the optional second parameter, which specifies the buttons to be displayed on the message box. Because the call does not supply a value, `MsgBox` uses the default value, `MsgBoxStyle.OKOnly`, which displays only an **OK** button.  
  
     The second comma in the argument list marks the place of the omitted second argument, and the last string is passed to the optional third parameter of `MsgBox`, which is the text to be displayed in the title bar.  
  
## See Also  
 [Sub Procedures](./sub-procedures.md)  
 [Function Procedures](./function-procedures.md)  
 [Property Procedures](./property-procedures.md)  
 [Operator Procedures](./operator-procedures.md)  
 [How to: Define a Parameter for a Procedure](./how-to-define-a-parameter-for-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Recursive Procedures](./recursive-procedures.md)  
 [Procedure Overloading](./procedure-overloading.md)  
 [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Object-Oriented Programming](http://msdn.microsoft.com/library/1cf6e655-3f30-45f1-9a5d-4a88ca24a1c2)
