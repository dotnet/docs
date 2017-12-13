---
title: "Boolean Expressions (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "short-circuiting"
  - "Boolean expressions"
  - "logical operators [Visual Basic], Boolean expressions"
  - "expressions [Visual Basic], Boolean"
  - "expression evaluation [Visual Basic], Boolean expressions"
  - "operators [Visual Basic], short-circuiting"
  - "Visual Basic code, operators"
  - "short-circuit evaluation"
  - "logical operators [Visual Basic], short-circuiting"
  - "operators [Visual Basic], Boolean"
  - "Visual Basic code, expressions"
ms.assetid: d3d90406-55c8-4404-8143-50fd7f0d0d1a
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Boolean Expressions (Visual Basic)
A *Boolean expression* is an expression that evaluates to a value of the [Boolean Data Type](../../../../visual-basic/language-reference/data-types/boolean-data-type.md): `True` or `False`. `Boolean` expressions can take several forms. The simplest is the direct comparison of the value of a `Boolean` variable to a `Boolean` literal, as shown in the following example.  
  
 [!code-vb[VbVbalrOperators#87](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/boolean-expressions_1.vb)]  
  
## Two Meanings of the = Operator  
 Notice that the assignment statement `newCustomer = True` looks the same as the expression in the preceding example, but it performs a different function and is used differently. In the preceding example, the expression `newCustomer = True` represents a Boolean value, and the `=` sign is interpreted as a comparison operator. In a stand-alone statement, the `=` sign is interpreted as an assignment operator and assigns the value on the right to the variable on the left. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#88](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/boolean-expressions_2.vb)]  
  
 For further information, see [Value Comparisons](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/value-comparisons.md) and [Statements](../../../../visual-basic/language-reference/statements/index.md).  
  
## Comparison Operators  
 Comparison operators such as `=`, `<`, `>`, `<>`, `<=`, and `>=` produce Boolean expressions by comparing the expression on the left side of the operator to the expression on the right side of the operator and evaluating the result as `True` or `False`. The following example illustrates this.  
  
 `42 < 81`  
  
 Because 42 is less than 81, the Boolean expression in the preceding example evaluates to `True`. For more information on this kind of expression, see [Value Comparisons](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/value-comparisons.md).  
  
### Comparison Operators Combined with Logical Operators  
 Comparison expressions can be combined using logical operators to produce more complex Boolean expressions. The following example demonstrates the use of comparison operators in conjunction with a logical operator.  
  
 `x > y And x < 1000`  
  
 In the preceding example, the value of the overall expression depends on the values of the expressions on each side of the `And` operator. If both expressions are `True`, then the overall expression evaluates to `True`. If either expression is `False`, then the entire expression evaluates to `False`.  
  
## Short-Circuiting Operators  
 The logical operators `AndAlso` and `OrElse` exhibit behavior known as *short-circuiting*. A short-circuiting operator evaluates the left operand first. If the left operand determines the value of the entire expression, then program execution proceeds without evaluating the right expression. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#89](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/boolean-expressions_3.vb)]  
  
 In the preceding example, the operator evaluates the left expression, `45 < 12`. Because the left expression evaluates to `False`, the entire logical expression must evaluate to `False`. Program execution thus skips execution of the code within the `If` block without evaluating the right expression, `testFunction(3)`. This example does not call `testFunction()` because the left expression falsifies the entire expression.  
  
 Similarly, if the left expression in a logical expression using `OrElse` evaluates to `True`, execution proceeds to the next line of code without evaluating the right expression, because the left expression has already validated the entire expression.  
  
### Comparison with Non-Short-Circuiting Operators  
 By contrast, both sides of the logical operator are evaluated when the logical operators `And` and `Or` are used. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#90](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/boolean-expressions_4.vb)]  
  
 The preceding example calls `testFunction()` even though the left expression evaluates to `False`.  
  
## Parenthetical Expressions  
 You can use parentheses to control the order of evaluation of Boolean expressions. Expressions enclosed by parentheses evaluate first. For multiple levels of nesting, precedence is granted to the most deeply nested expressions. Within parentheses, evaluation proceeds according to the rules of operator precedence. For more information, see [Operator Precedence in Visual Basic](../../../../visual-basic/language-reference/operators/operator-precedence.md).  
  
## See Also  
 [Logical and Bitwise Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)  
 [Value Comparisons](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/value-comparisons.md)  
 [Statements](../../../../visual-basic/programming-guide/language-features/statements.md)  
 [Comparison Operators](../../../../visual-basic/language-reference/operators/comparison-operators.md)  
 [Efficient Combination of Operators](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/efficient-combination-of-operators.md)  
 [Operator Precedence in Visual Basic](../../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Boolean Data Type](../../../../visual-basic/language-reference/data-types/boolean-data-type.md)
