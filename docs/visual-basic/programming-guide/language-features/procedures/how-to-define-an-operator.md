---
description: "Learn more about: How to: Define an Operator (Visual Basic)"
title: "How to: Define an Operator"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "operators [Visual Basic], defining"
  - "procedures [Visual Basic], operator"
  - "Visual Basic code, operators"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "operator procedures [Visual Basic], about operator procedures"
  - "return values [Visual Basic], Operator procedures"
  - "operator overloading"
ms.assetid: d4b0e253-092a-4e6e-9fe2-01f562140a29
ms.topic: how-to
---
# How to: Define an Operator (Visual Basic)

If you have defined a class or structure, you can define the behavior of a standard operator (such as `*`, `<>`, or `And`) when one or both of the operands is of the type of your class or structure.  
  
 Define the standard operator as an operator procedure within the class or structure. All operator procedures must be `Public` `Shared`.  
  
 Defining an operator on a class or structure is also called *overloading* the operator.  
  
## Example  

 The following example defines the `+` operator for a structure called `height`. The structure uses heights measured in feet and inches. One *inch* is 2.54 centimeters, and one *foot* is 12 inches. To ensure normalized values (inches < 12.0), the constructor performs *modulo* 12 arithmetic. The `+` operator uses the constructor to generate normalized values.  
  
 [!code-vb[VbVbcnProcedures#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#25)]  
  
 You can test the structure `height` with the following code.  
  
 [!code-vb[VbVbcnProcedures#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#26)]  

## See also

- [Operator Procedures](./operator-procedures.md)
- [How to: Define a Conversion Operator](./how-to-define-a-conversion-operator.md)
- [How to: Call an Operator Procedure](./how-to-call-an-operator-procedure.md)
- [How to: Use a Class that Defines Operators](./how-to-use-a-class-that-defines-operators.md)
- [Operator Statement](../../../language-reference/statements/operator-statement.md)
- [Structure Statement](../../../language-reference/statements/structure-statement.md)
- [How to: Declare a Structure](../data-types/how-to-declare-a-structure.md)
- [Mod Operator](../../../language-reference/operators/mod-operator.md)
