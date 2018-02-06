---
title: "Sub Procedures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Sub procedures [Visual Basic], about Sub procedures"
  - "statement blocks"
  - "Sub procedures [Visual Basic], calling"
  - "procedures [Visual Basic], calling"
  - "Sub procedures [Visual Basic], syntax"
  - "Sub procedures"
  - "procedures [Visual Basic], Sub"
  - "syntax [Visual Basic], Sub procedures"
ms.assetid: 6a0a4958-ed0a-4d3d-8d31-0772c82bda58
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Sub Procedures (Visual Basic)
A `Sub` procedure is a series of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] statements enclosed by the `Sub` and `End Sub` statements. The `Sub` procedure performs a task and then returns control to the calling code, but it does not return a value to the calling code.  
  
 Each time the procedure is called, its statements are executed, starting with the first executable statement after the `Sub` statement and ending with the first `End Sub`, `Exit Sub`, or `Return` statement encountered.  
  
 You can define a `Sub` procedure in modules, classes, and structures. By default, it is `Public`, which means you can call it from anywhere in your application that has access to the module, class, or structure in which you defined it. The term, *method*, describes a `Sub` or `Function` procedure that is accessed from outside its defining module, class, or structure. For more information, see [Procedures](./index.md).  
  
 A `Sub` procedure can take arguments, such as constants, variables, or expressions, which are passed to it by the calling code.  
  
## Declaration Syntax  
 The syntax for declaring a `Sub` procedure is as follows:  
  
 `[` *modifiers* `] Sub`  *subname* `[(` *parameterlist* `)]`  
  
 `' Statements of the Sub procedure.`  
  
 `End Sub`  
  
 The `modifiers` can specify access level and information about overloading, overriding, sharing, and shadowing. For more information, see [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md).  
  
## Parameter Declaration  
 You declare each procedure parameter similarly to how you declare a variable, specifying the parameter name and data type. You can also specify the passing mechanism, and whether the parameter is optional or a parameter array.  
  
 The syntax for each parameter in the parameter list is as follows:  
  
 `[Optional] [ByVal | ByRef] [ParamArray]`  *parametername*  `As`  *datatype*  
  
 If the parameter is optional, you must also supply a default value as part of its declaration. The syntax for specifying a default value is as follows:  
  
 `Optional [ByVal | ByRef]`  *parametername*  `As`  *datatype*  `=`  *defaultvalue*  
  
### Parameters as Local Variables  
 When control passes to the procedure, each parameter is treated as a local variable. This means that its lifetime is the same as that of the procedure, and its scope is the whole procedure.  
  
## Calling Syntax  
 You invoke a `Sub` procedure explicitly with a stand-alone calling statement. You cannot call it by using its name in an expression. You must provide values for all arguments that are not optional, and you must enclose the argument list in parentheses. If no arguments are supplied, you can optionally omit the parentheses. The use of the `Call` keyword is optional but not recommended.  
  
 The syntax for a call to a `Sub` procedure is as follows:  
  
 `[Call]`  *subname* `[(` *argumentlist* `)]`  
  
 You can call a `Sub` method from outside the class that defines it. First, you have to use the `New` keyword to create an instance of the class, or call a method that returns an instance of the class. For more information, see [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md). Then, you can use the following syntax to call the `Sub` method on the instance object:  
  
 *Object*.*methodname*`[(`*argumentlist*`)]`  
  
### Illustration of Declaration and Call  
 The following `Sub` procedure tells the computer operator which task the application is about to perform, and also displays a time stamp. Instead of duplicating this code at the start of every task, the application just calls `tellOperator` from various locations. Each call passes a string in the `task` argument that identifies the task being started.  
  
 [!code-vb[VbVbcnProcedures#2](./codesnippet/VisualBasic/sub-procedures_1.vb)]  
  
 The following example shows a typical call to `tellOperator`.  
  
 [!code-vb[VbVbcnProcedures#3](./codesnippet/VisualBasic/sub-procedures_2.vb)]  
  
## See Also  
 [Procedures](./index.md)  
 [Function Procedures](./function-procedures.md)  
 [Property Procedures](./property-procedures.md)  
 [Operator Procedures](./operator-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md)  
 [How to: Call a Procedure that Does Not Return a Value](./how-to-call-a-procedure-that-does-not-return-a-value.md)  
 [How to: Call an Event Handler in Visual Basic](./how-to-call-an-event-handler.md)
