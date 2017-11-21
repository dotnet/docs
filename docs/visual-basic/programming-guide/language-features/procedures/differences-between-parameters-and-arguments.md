---
title: "Differences Between Parameters and Arguments (Visual Basic)"
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
  - "parameters [Visual Basic], and arguments"
  - "procedure arguments"
  - "Visual Basic code, procedures"
  - "arguments [Visual Basic], and parameters"
  - "procedure parameters"
  - "parameters [Visual Basic], definition"
ms.assetid: c237c056-74f4-4749-9f2c-15864f139a31
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Differences Between Parameters and Arguments (Visual Basic)
In most cases, a procedure must have some information about the circumstances in which it has been called. A procedure that performs repeated or shared tasks uses different information for each call. This information consists of variables, constants, and expressions that you pass to the procedure when you call it.  
  
 To communicate this information to the procedure, the procedure defines a *parameter*, and the calling code passes an *argument* to that parameter. You can think of the parameter as a parking space and the argument as an automobile. Just as different automobiles can park in a parking space at different times, the calling code can pass a different argument to the same parameter every time that it calls the procedure.  
  
## Parameters  
 A *parameter* represents a value that the procedure expects you to pass when you call it. The procedure's declaration defines its parameters.  
  
 When you define a `Function` or `Sub` procedure, you specify a *parameter list* in parentheses immediately following the procedure name. For each parameter, you specify a name, a data type, and a passing mechanism ([ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) or [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md)). You can also indicate that a parameter is optional. This means that the calling code does not have to pass a value for it.  
  
 The name of each parameter serves as a *local variable* in the procedure. You use the parameter name the same way you use any other variable.  
  
## Arguments  
 An *argument* represents the value that you pass to a procedure parameter when you call the procedure. The calling code supplies the arguments when it calls the procedure.  
  
 When you call a `Function` or `Sub` procedure, you include an *argument list* in parentheses immediately following the procedure name. Each argument corresponds to the parameter in the same position in the list.  
  
 In contrast to parameter definition, arguments do not have names. Each argument is an expression, which can contain zero or more variables, constants, and literals. The data type of the evaluated expression should typically match the data type defined for the corresponding parameter, and in any case it must be convertible to the parameter type.  
  
## See Also  
 [Procedures](./index.md)  
 [Sub Procedures](./sub-procedures.md)  
 [Function Procedures](./function-procedures.md)  
 [Property Procedures](./property-procedures.md)  
 [Operator Procedures](./operator-procedures.md)  
 [How to: Define a Parameter for a Procedure](./how-to-define-a-parameter-for-a-procedure.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Recursive Procedures](./recursive-procedures.md)  
 [Procedure Overloading](./procedure-overloading.md)
