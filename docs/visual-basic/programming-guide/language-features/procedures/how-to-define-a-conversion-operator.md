---
title: "How to: Define a Conversion Operator (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "procedures [Visual Basic], defining"
  - "operators [Visual Basic], defining"
  - "procedures [Visual Basic], operator"
  - "operators [Visual Basic], overloading"
  - "return values [Visual Basic], Operator procedures"
  - "operator overloading"
ms.assetid: 54203dfa-c24b-463f-9942-d5153e89e762
---
# How to: Define a Conversion Operator (Visual Basic)
If you have defined a class or structure, you can define a type conversion operator between the type of your class or structure and another data type (such as `Integer`, `Double`, or `String`).  
  
 Define the type conversion as a [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md) procedure within the class or structure. All conversion procedures must be `Public Shared`, and each one must specify either [Widening](../../../../visual-basic/language-reference/modifiers/widening.md) or [Narrowing](../../../../visual-basic/language-reference/modifiers/narrowing.md).  
  
 Defining an operator on a class or structure is also called *overloading* the operator.  
  
## Example  
 The following example defines conversion operators between a structure called `digit` and a `Byte`.  
  
 [!code-vb[VbVbcnProcedures#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#27)]  
  
 You can test the structure `digit` with the following code.  
  
 [!code-vb[VbVbcnProcedures#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#28)]  
  
## See also

- [Operator Procedures](./operator-procedures.md)
- [How to: Define an Operator](./how-to-define-an-operator.md)
- [How to: Call an Operator Procedure](./how-to-call-an-operator-procedure.md)
- [How to: Use a Class that Defines Operators](./how-to-use-a-class-that-defines-operators.md)
- [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)
- [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)
- [How to: Declare a Structure](../../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)
- [Implicit and Explicit Conversions](../../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
- [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)
