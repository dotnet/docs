---
title: "Or Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Or"
helpviewer_keywords: 
  - "Or operator [Visual Basic]"
  - "operators [Visual Basic], bitwise"
  - "inclusive Or operator [Visual Basic]"
  - "bitwise operators [Visual Basic], OR operator"
  - "Or keyword [Visual Basic]"
  - "operators [Visual Basic], inclusive or"
  - "operators [Visual Basic], disjunction"
  - "bitwise comparison [Visual Basic]"
  - "logical disjunction"
  - "disjunction operator [Visual Basic]"
ms.assetid: 41ed6905-bf3d-468a-9e3b-03c10d461891
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Or Operator (Visual Basic)
Performs a logical disjunction on two `Boolean` expressions, or a bitwise disjunction on two numeric expressions.  
  
## Syntax  
  
```  
result = expression1 Or expression2  
```  
  
## Parts  
 `result`  
 Required. Any `Boolean` or numeric expression. For `Boolean` comparison, `result` is the inclusive logical disjunction of two `Boolean` values. For bitwise operations, `result` is a numeric value representing the inclusive bitwise disjunction of two numeric bit patterns.  
  
 `expression1`  
 Required. Any `Boolean` or numeric expression.  
  
 `expression2`  
 Required. Any `Boolean` or numeric expression.  
  
## Remarks  
 For `Boolean` comparison, `result` is `False` if and only if both `expression1` and `expression2` evaluate to `False`. The following table illustrates how `result` is determined.  
  
|If `expression1` is|And `expression2` is|The value of `result` is|  
|-------------------------|--------------------------|------------------------------|  
|`True`|`True`|`True`|  
|`True`|`False`|`True`|  
|`False`|`True`|`True`|  
|`False`|`False`|`False`|  
  
> [!NOTE]
>  In a `Boolean` comparison, the `Or` operator always evaluates both expressions, which could include making procedure calls. The [OrElse Operator](../../../visual-basic/language-reference/operators/orelse-operator.md) performs *short-circuiting*, which means that if `expression1` is `True`, then `expression2` is not evaluated.  
  
 For bitwise operations, the `Or` operator performs a bitwise comparison of identically positioned bits in two numeric expressions and sets the corresponding bit in `result` according to the following table.  
  
|If bit in `expression1` is|And bit in `expression2` is|The bit in `result` is|  
|--------------------------------|---------------------------------|----------------------------|  
|1|1|1|  
|1|0|1|  
|0|1|1|  
|0|0|0|  
  
> [!NOTE]
>  Since the logical and bitwise operators have a lower precedence than other arithmetic and relational operators, any bitwise operations should be enclosed in parentheses to ensure accurate execution.  
  
## Data Types  
 If the operands consist of one `Boolean` expression and one numeric expression, Visual Basic converts the `Boolean` expression to a numeric value (–1 for `True` and 0 for `False`) and performs a bitwise operation.  
  
 For a `Boolean` comparison, the data type of the result is `Boolean`. For a bitwise comparison, the result data type is a numeric type appropriate for the data types of `expression1` and `expression2`. See the "Relational and Bitwise Comparisons" table in [Data Types of Operator Results](../../../visual-basic/language-reference/operators/data-types-of-operator-results.md).  
  
## Overloading  
 The `Or` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following example uses the `Or` operator to perform an inclusive logical disjunction on two expressions. The result is a `Boolean` value that represents whether either of the two expressions is `True`.  
  
 [!code-vb[VbVbalrOperators#35](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/or-operator_1.vb)]  
  
 The preceding example produces results of `True`, `True`, and `False`, respectively.  
  
## Example  
 The following example uses the `Or` operator to perform inclusive logical disjunction on the individual bits of two numeric expressions. The bit in the result pattern is set if either of the corresponding bits in the operands is set to 1.  
  
 [!code-vb[VbVbalrOperators#36](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/or-operator_2.vb)]  
  
 The preceding example produces results of 10, 14, and 14, respectively.  
  
## See Also  
 [Logical/Bitwise Operators (Visual Basic)](../../../visual-basic/language-reference/operators/logical-bitwise-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [OrElse Operator](../../../visual-basic/language-reference/operators/orelse-operator.md)  
 [Logical and Bitwise Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
