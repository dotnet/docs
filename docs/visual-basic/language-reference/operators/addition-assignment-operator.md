---
title: "+= Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.+="
helpviewer_keywords: 
  - "+= operator [Visual Basic]"
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "+= operator [Visual Basic], appending strings"
  - "compound assignment statements [Visual Basic]"
ms.assetid: d3e959f4-85d4-4e47-87c4-77b62335a5b3
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# += Operator (Visual Basic)
Adds the value of a numeric expression to the value of a numeric variable or property and assigns the result to the variable or property. Can also be used to concatenate a `String` expression to a `String` variable or property and assign the result to the variable or property.  
  
## Syntax  
  
```  
variableorproperty += expression  
```  
  
## Parts  
 `variableorproperty`  
 Required. Any numeric or `String` variable or property.  
  
 `expression`  
 Required. Any numeric or `String` expression.  
  
## Remarks  
 The element on the left side of the `+=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md).  
  
 The `+=` operator adds the value on its right to the variable or property on its left, and assigns the result to the variable or property on its left. The `+=` operator can also be used to concatenate the `String` expression on its right to the `String` variable or property on its left, and assign the result to the variable or property on its left.  
  
> [!NOTE]
>  When you use the `+=` operator, you might not be able to determine whether addition or string concatenation will occur. Use the `&=` operator for concatenation to eliminate ambiguity and to provide self-documenting code.  
  
 This assignment operator implicitly performs widening but not narrowing conversions if the compilation environment enforces strict semantics. For more information on these conversions, see [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md). For more information on strict and permissive semantics, see [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md).  
  
 If permissive semantics are allowed, the `+=` operator implicitly performs a variety of string and numeric conversions identical to those performed by the `+` operator. For details on these conversions, see [+ Operator](../../../visual-basic/language-reference/operators/addition-operator.md).  
  
## Overloading  
 The `+` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `+` operator affects the behavior of the `+=` operator. If your code uses `+=` on a class or structure that overloads `+`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `+=` operator to combine the value of one variable with another. The first part uses `+=` with numeric variables to add one value to another. The second part uses `+=` with `String` variables to concatenate one value with another. In both cases, the result is assigned to the first variable.  
  
 [!code-vb[VbVbalrOperators#7](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-assignment-operator_1.vb)]  
  
 [!code-vb[VbVbalrOperators#8](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/addition-assignment-operator_2.vb)]  
  
 The value of `num1` is now 13, and the value of `str1` is now "103".  
  
## See Also  
 [+ Operator](../../../visual-basic/language-reference/operators/addition-operator.md)  
 [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Concatenation Operators](../../../visual-basic/language-reference/operators/concatenation-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
