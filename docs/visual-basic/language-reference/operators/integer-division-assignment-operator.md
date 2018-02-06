---
title: "\\= Operator"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "\\="
  - "vb.\\="
helpviewer_keywords: 
  - "\\= operator [Visual Basic]"
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "operator \\= [Visual Basic]"
  - "compound assignment statements [Visual Basic]"
ms.assetid: 6f39915d-e398-4045-afcc-da6885e57b9c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# \\= Operator
Divides the value of a variable or property by the value of an expression and assigns the integer result to the variable or property.  
  
## Syntax  
  
```  
variableorproperty \= expression  
```  
  
## Parts  
 `variableorproperty`  
 Required. Any numeric variable or property.  
  
 `expression`  
 Required. Any numeric expression.  
  
## Remarks  
 The element on the left side of the `\=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md).  
  
 The `\=` operator divides the value of a variable or property on its left by the value on its right, and assigns the integer result to the variable or property on its left  
  
 For further information on integer division, see [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md).  
  
## Overloading  
 The `\` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `\` operator affects the behavior of the `\=` operator. If your code uses `\=` on a class or structure that overloads `\`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `\=` operator to divide one `Integer` variable by a second and assign the integer result to the first variable.  
  
 [!code-vb[VbVbalrOperators#19](codesnippet/VisualBasic/integer-division-assignment-operator_1.vb)]  
  
## See Also  
 [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md)  
 [/= Operator (Visual Basic)](../../../visual-basic/language-reference/operators/floating-point-division-assignment-operator.md)  
 [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
