---
title: "Operator Procedures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], operator"
  - "Visual Basic code, operators"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "overloaded operators [Visual Basic]"
  - "operator overloading"
  - "operator procedures"
ms.assetid: 8c513d38-246b-4fb7-8b75-29e1364e555b
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Operator Procedures (Visual Basic)
An operator procedure is a series of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] statements that define the behavior of a standard operator (such as `*`, `<>`, or `And`) on a class or structure you have defined. This is also called *operator overloading*.  
  
## When to Define Operator Procedures  
 When you have defined a class or structure, you can declare variables to be of the type of that class or structure. Sometimes such a variable needs to participate in an operation as part of an expression. To do this, it must be an operand of an operator.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] defines operators only on its fundamental data types. You can define the behavior of an operator when one or both of the operands are of the type of your class or structure.  
  
 For more information, see [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md).  
  
## Types of Operator Procedure  
 An operator procedure can be one of the following types:  
  
-   A definition of a unary operator where the argument is of the type of your class or structure.  
  
-   A definition of a binary operator where at least one of the arguments is of the type of your class or structure.  
  
-   A definition of a conversion operator where the argument is of the type of your class or structure.  
  
-   A definition of a conversion operator that returns the type of your class or structure.  
  
 Conversion operators are always unary, and you always use `CType` as the operator you are defining.  
  
## Declaration Syntax  
 The syntax for declaring an operator procedure is as follows:  
  
 `Public Shared`   `[Widening | Narrowing]`   `Operator`  *operatorsymbol*  `(` *operand1*  `[,`  *operand2* `]) As`  *datatype*  
  
 `' Statements of the operator procedure.`  
  
 `End Operator`  
  
 You use the `Widening` or `Narrowing` keyword only on a type conversion operator. The operator symbol is always [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md) for a type conversion operator.  
  
 You declare two operands to define a binary operator, and you declare one operand to define a unary operator, including a type conversion operator. All operands must be declared `ByVal`.  
  
 You declare each operand the same way you declare parameters for [Sub Procedures](./sub-procedures.md).  
  
### Data Type  
 Because you are defining an operator on a class or structure you have defined, at least one of the operands must be of the data type of that class or structure. For a type conversion operator, either the operand or the return type must be of the data type of the class or structure.  
  
 For more details, see [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md).  
  
## Calling Syntax  
 You invoke an operator procedure implicitly by using the operator symbol in an expression. You supply the operands the same way you do for predefined operators.  
  
 The syntax for an implicit call to an operator procedure is as follows:  
  
 `Dim testStruct As`  *structurename*  
  
 `Dim testNewStruct As`  *structurename*  `= testStruct`  *operatorsymbol*  `10`  
  
### Illustration of Declaration and Call  
 The following structure stores a signed 128-bit integer value as the constituent high-order and low-order parts. It defines the `+` operator to add two `veryLong` values and generate a resulting `veryLong` value.  
  
 [!code-vb[VbVbcnProcedures#23](./codesnippet/VisualBasic/operator-procedures_1.vb)]  
  
 The following example shows a typical call to the `+` operator defined on `veryLong`.  
  
 [!code-vb[VbVbcnProcedures#24](./codesnippet/VisualBasic/operator-procedures_2.vb)]  
  
 For more information and examples, see [Operator Overloading in Visual Basic 2005](http://go.microsoft.com/fwlink/?LinkId=101703).  
  
## See Also  
 [Procedures](./index.md)  
 [Sub Procedures](./sub-procedures.md)  
 [Function Procedures](./function-procedures.md)  
 [Property Procedures](./property-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)  
 [How to: Define an Operator](./how-to-define-an-operator.md)  
 [How to: Define a Conversion Operator](./how-to-define-a-conversion-operator.md)  
 [How to: Call an Operator Procedure](./how-to-call-an-operator-procedure.md)  
 [How to: Use a Class that Defines Operators](./how-to-use-a-class-that-defines-operators.md)
