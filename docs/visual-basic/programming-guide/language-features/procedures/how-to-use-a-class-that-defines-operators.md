---
description: "Learn more about: How to: Use a Class that Defines Operators (Visual Basic)"
title: "How to: Use a Class that Defines Operators"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "operator procedures [Visual Basic], calling"
  - "procedures [Visual Basic], operator"
  - "procedures [Visual Basic], calling"
  - "examples [Visual Basic], CType"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "return values [Visual Basic], Operator procedures"
  - "operator overloading"
ms.assetid: 7ccce94a-6ca0-47d1-9f3f-13385d34f5d5
ms.topic: how-to
---
# How to: Use a Class that Defines Operators (Visual Basic)

If you are using a class or structure that defines its own operators, you can access those operators from Visual Basic.  
  
 Defining an operator on a class or structure is also called *overloading* the operator.  
  
## Example  

 The following example accesses the SQL structure <xref:System.Data.SqlTypes.SqlString>, which defines the conversion operators ([CType Function](../../../language-reference/functions/ctype-function.md)) in both directions between a SQL string and a Visual Basic string. Use `CType(`*SQL string expression*, `String)` to convert a SQL string to a Visual Basic string, and `CType(`*Visual Basic string expression*, <xref:System.Data.SqlTypes.SqlString>`)` to convert in the other direction.  
  
 [!code-vb[VbVbcnProcedures#30](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#30)]  
  
 [!code-vb[VbVbcnProcedures#31](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#31)]  
  
 The <xref:System.Data.SqlTypes.SqlString> structure defines a conversion operator ([CType Function](../../../language-reference/functions/ctype-function.md)) from `String` to <xref:System.Data.SqlTypes.SqlString> and another from <xref:System.Data.SqlTypes.SqlString> to `String`. The statement that assigns `title` to `jobTitle` makes use of the first operator, and the <xref:Microsoft.VisualBasic.Interaction.MsgBox%2A> function call uses the second.  
  
## Compile the code  

 Be sure the class or structure you are using defines the operator you want to use. Do not assume that the class or structure has defined every operator available for overloading. For a list of available operators, see [Operator Statement](../../../language-reference/statements/operator-statement.md).  
  
 Include the appropriate `Imports` statement for the SQL string at the beginning of your source file (in this case <xref:System.Data.SqlTypes>).  
  
 Your project must have references to System.Data and System.XML.  
  
## See also

- [Operator Procedures](./operator-procedures.md)
- [How to: Define an Operator](./how-to-define-an-operator.md)
- [How to: Define a Conversion Operator](./how-to-define-a-conversion-operator.md)
- [How to: Call an Operator Procedure](./how-to-call-an-operator-procedure.md)
- [Widening](../../../language-reference/modifiers/widening.md)
- [Narrowing](../../../language-reference/modifiers/narrowing.md)
- [Structure Statement](../../../language-reference/statements/structure-statement.md)
- [How to: Declare a Structure](../data-types/how-to-declare-a-structure.md)
- [Implicit and Explicit Conversions](../data-types/implicit-and-explicit-conversions.md)
- [Widening and Narrowing Conversions](../data-types/widening-and-narrowing-conversions.md)
