---
description: "Learn more about: Value Comparisons (Visual Basic)"
title: "Value Comparisons"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "variables [Visual Basic], comparing values"
  - "Visual Basic code, operators"
  - "Visual Basic code, expressions"
  - "comparison operators [Visual Basic], comparing expressions"
  - "numeric expressions"
  - "operators [Visual Basic], comparison"
  - "expressions [Visual Basic], comparing"
ms.assetid: 60da0c76-9458-4afc-97e9-44a7939c064c
---
# Value Comparisons (Visual Basic)

Comparison operators can be used to construct expressions that compare the values of numeric variables. These expressions return a `Boolean` value based on whether the comparison is true or false. Examples of such an expression are as follows.  
  
 `45 > 26`  
  
 `26 > 45`  
  
 The first expression evaluates to `True`, because 45 is greater than 26. The second example evaluates to `False`, because 26 is not greater than 45.  
  
 You can also compare numeric expressions in this fashion. The expressions you compare can themselves be complex expressions, as in the following example.  
  
 `x / 45 * (y +17) >= System.Math.Sqrt(z) / (p - (x * 16))`  
  
 The preceding complex expression includes literals, variables, and function calls. The expressions on both sides of the comparison operator are evaluated, and the resulting values are then compared using the `>=` comparison operator. If the value of the expression on the left side is greater than or equal to the value of the expression on the right, the entire expression evaluates to `True`; otherwise, it evaluates to `False`.  
  
 Expressions that compare values are most commonly used in `If...Then` constructions, as in the following example.  
  
 [!code-vb[VbVbalrOperators#84](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#84)]  
  
 The `=` sign is a comparison operator as well as an assignment operator. When used as a comparison operator, it evaluates whether the value on the left is equal to the value on the right, as shown in the following example.  
  
 [!code-vb[VbVbalrOperators#85](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#85)]  
  
 You can also use a comparison expression anywhere a `Boolean` value is needed, such as in an `If`, `While`, `Loop`, or `ElseIf` statement, or when assigning to or passing a value to a `Boolean` variable. In the following example, the value returned by the comparison expression is assigned to a `Boolean` variable.  
  
 [!code-vb[VbVbalrOperators#86](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#86)]  
  
## See also

- [Boolean Expressions](boolean-expressions.md)
- [Operators and Expressions](index.md)
- [Comparison Operators in Visual Basic](comparison-operators.md)
- [How to: Calculate Numeric Values](how-to-calculate-numeric-values.md)
- [Operator Precedence in Visual Basic](../../../language-reference/operators/operator-precedence.md)
