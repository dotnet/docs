---
title: "&amp;= Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.&="
helpviewer_keywords: 
  - "operator &="
  - "assignment statements [Visual Basic], compound"
  - "statements [Visual Basic], compound assignment"
  - "&= operator [Visual Basic]"
  - "compound assignment statements [Visual Basic]"
ms.assetid: 0cf262fc-1a05-419a-a503-60013f111c8a
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# &amp;= Operator (Visual Basic)
Concatenates a `String` expression to a `String` variable or property and assigns the result to the variable or property.  
  
## Syntax  
  
```  
variableorproperty &= expression  
```  
  
## Parts  
 `variableorproperty`  
 Required. Any `String` variable or property.  
  
 `expression`  
 Required. Any `String` expression.  
  
## Remarks  
 The element on the left side of the `&=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md). The `&=` operator concatenates the `String` expression on its right to the `String` variable or property on its left, and assigns the result to the variable or property on its left.  
  
## Overloading  
 The [& Operator](../../../visual-basic/language-reference/operators/concatenation-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `&` operator affects the behavior of the `&=` operator. If your code uses `&=` on a class or structure that overloads `&`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `&=` operator to concatenate two `String` variables and assign the result to the first variable.  
  
 [!code-vb[VbVbalrOperators#3](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/and-assignment-operator_1.vb)]  
  
## See Also  
 [& Operator](../../../visual-basic/language-reference/operators/concatenation-operator.md)  
 [+= Operator](../../../visual-basic/language-reference/operators/addition-assignment-operator.md)  
 [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)  
 [Concatenation Operators](../../../visual-basic/language-reference/operators/concatenation-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
