---
title: "/= Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb./="
helpviewer_keywords: 
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "/= operator [Visual Basic]"
  - "operator /="
  - "compound assignment statements [Visual Basic]"
ms.assetid: a1e22d0e-8380-4761-9da1-84fb51c34821
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# /= Operator (Visual Basic)
Divides the value of a variable or property by the value of an expression and assigns the floating-point result to the variable or property.  
  
## Syntax  
  
```  
variableorproperty /= expression  
```  
  
## Parts  
 `variableorproperty`  
 Required. Any numeric variable or property.  
  
 `expression`  
 Required. Any numeric expression.  
  
## Remarks  
 The element on the left side of the `/=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md).  
  
 The `/=` operator first divides the value of the variable or property (on the left-hand side of the operator) by the value of the expression (on the right-hand side of the operator). The operator then assigns the floating-point result of that operation to the variable or property.  
  
 This statement assigns a `Double` value to the variable or property on the left. If `Option Strict` is `On`, `variableorproperty` must be a `Double`. If `Option Strict` is `Off`, Visual Basic performs an implicit conversion and assigns the resulting value to `variableorproperty`, with a possible error at run time. For more information, see [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md) and [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md).  
  
## Overloading  
 The [/ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/floating-point-division-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `/` operator affects the behavior of the `/=` operator. If your code uses `/=` on a class or structure that overloads `/`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `/=` operator to divide one `Integer` variable by a second and assign the quotient to the first variable.  
  
 [!code-vb[VbVbalrOperators#17](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/floating-point-division-assignment-operator_1.vb)]  
  
## See Also  
 [/ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/floating-point-division-operator.md)  
 [\\= Operator](../../../visual-basic/language-reference/operators/integer-division-assignment-operator.md)  
 [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
