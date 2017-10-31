---
title: "How to: Define a Parameter for a Procedure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedure parameters [Visual Basic], defining data types for"
  - "procedures [Visual Basic], parameters"
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "procedure parameters [Visual Basic], defining"
ms.assetid: 7962808d-407e-4e84-984e-43e9857c53c9
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Define a Parameter for a Procedure (Visual Basic)
A *parameter* allows the calling code to pass a value to the procedure when it calls it. You declare each parameter for a procedure the same way you declare a variable, specifying its name and data type. You also specify the passing mechanism, and whether the parameter is optional.  
  
 For more information, see [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md).  
  
### To define a procedure parameter  
  
1.  In the procedure declaration, add the parameter name to the procedure's parameter list, separating it from other parameters by commas.  
  
2.  Decide the data type of the parameter.  
  
3.  Follow the parameter name with an `As` clause to specify the data type.  
  
4.  Decide the passing mechanism you want for the parameter. Normally you pass a parameter by value, unless you want the procedure to be able to change its value in the calling code.  
  
5.  Precede the parameter name with [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md) or [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md) to specify the passing mechanism. For more information, see [Differences Between Passing an Argument By Value and By Reference](./differences-between-passing-an-argument-by-value-and-by-reference.md).  
  
6.  If the parameter is optional, precede the passing mechanism with [Optional](../../../../visual-basic/language-reference/modifiers/optional.md) and follow the parameter data type with an equal sign (`=`) and a default value.  
  
     The following example defines the outline of a `Sub` procedure with three parameters. The first two are required and the third is optional. The parameter declarations are separated in the parameter list by commas.  
  
     [!code-vb[VbVbcnProcedures#33](./codesnippet/VisualBasic/how-to-define-a-parameter-for-a-procedure_1.vb)]  
  
     The first parameter accepts a `customer` object, and `updateCustomer` can directly update the variable passed to `c` because the argument is passed [ByRef](../../../../visual-basic/language-reference/modifiers/byref.md). The procedure cannot change the values of the last two arguments because they are passed [ByVal](../../../../visual-basic/language-reference/modifiers/byval.md).  
  
     If the calling code does not supply a value for the `level` parameter, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] sets it to the default value of 0.  
  
     If the type checking switch ([Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)) is `Off`, the `As` clause is optional when you define a parameter. However, if any one parameter uses an `As` clause, all of them must use it. If the type checking switch is `On`, the `As` clause is required for every parameter definition.  
  
     Specifying data types for all your programming elements is known as *strong typing*. When you set `Option Strict On`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] enforces strong typing. This is strongly recommended, for the following reasons:  
  
    -   It enables IntelliSense support for your variables and parameters. This allows you to see their properties and other members as you type in your code.  
  
    -   It allows the compiler to perform type checking. This helps catch statements that can fail at run time due to errors such as overflow. It also catches calls to methods on objects that do not support them.  
  
    -   It results in faster execution of your code. One reason for this is that if you do not specify a data type for a programming element, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler assigns it the `Object` type. Your compiled code might have to convert back and forth between `Object` and other data types, which reduces performance.  
  
## See Also  
 [Procedures](./index.md)  
 [Sub Procedures](./sub-procedures.md)  
 [Function Procedures](./function-procedures.md)  
 [How to: Pass Arguments to a Procedure](./how-to-pass-arguments-to-a-procedure.md)  
 [Passing Arguments by Value and by Reference](./passing-arguments-by-value-and-by-reference.md)  
 [Recursive Procedures](./recursive-procedures.md)  
 [Procedure Overloading](./procedure-overloading.md)  
 [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Object-Oriented Programming](http://msdn.microsoft.com/library/1cf6e655-3f30-45f1-9a5d-4a88ca24a1c2)
