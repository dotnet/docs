---
description: "Learn more about: OrElse Operator (Visual Basic)"
title: "OrElse Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "OrElse"
  - "vb.OrElse"
helpviewer_keywords: 
  - "short-circuiting"
  - "operators [Visual Basic], short-circuiting"
  - "operators [Visual Basic], disjunction"
  - "short-circuit evaluation"
  - "OrElse operator [Visual Basic]"
ms.assetid: 253803d8-05b0-47d7-b213-abd222847779
---
# OrElse Operator (Visual Basic)

Performs short-circuiting inclusive logical disjunction on two expressions.  
  
## Syntax  
  
```vb
result = expression1 OrElse expression2  
```  
  
## Parts  

 `result`  
 Required. Any `Boolean` expression.  
  
 `expression1`  
 Required. Any `Boolean` expression.  
  
 `expression2`  
 Required. Any `Boolean` expression.  
  
## Remarks  

 A logical operation is said to be *short-circuiting* if the compiled code can bypass the evaluation of one expression depending on the result of another expression. If the result of the first expression evaluated determines the final result of the operation, there is no need to evaluate the second expression, because it cannot change the final result. Short-circuiting can improve performance if the bypassed expression is complex, or if it involves procedure calls.  
  
 If either or both expressions evaluate to `True`, `result` is `True`. The following table illustrates how `result` is determined.  
  
|If `expression1` is|And `expression2` is|The value of `result` is|  
|-------------------------|--------------------------|------------------------------|  
|`True`|(not evaluated)|`True`|  
|`False`|`True`|`True`|  
|`False`|`False`|`False`|  
  
## Data Types  

 The `OrElse` operator is defined only for the [Boolean Data Type](../data-types/boolean-data-type.md). Visual Basic converts each operand as necessary to `Boolean` before evaluating the expression. If you assign the result to a numeric type, Visual Basic converts it from `Boolean` to that type such that `False` becomes `0` and `True` becomes `-1`.
For more information, see [Boolean Type Conversions](../data-types/boolean-data-type.md#type-conversions).
  
## Overloading  

 The [Or Operator](or-operator.md) and the [IsTrue Operator](istrue-operator.md) can be *overloaded*, which means that a class or structure can redefine their behavior when an operand has the type of that class or structure. Overloading the `Or` and `IsTrue` operators affects the behavior of the `OrElse` operator. If your code uses `OrElse` on a class or structure that overloads `Or` and `IsTrue`, be sure you understand their redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example 1

 The following example uses the `OrElse` operator to perform logical disjunction on two expressions. The result is a `Boolean` value that represents whether either of the two expressions is true. If the first expression is `True`, the second is not evaluated.  
  
 [!code-vb[VbVbalrOperators#37](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#37)]  
  
 The preceding example produces results of `True`, `True`, and `False` respectively. In the calculation of `firstCheck`, the second expression is not evaluated because the first is already `True`. However, the second expression is evaluated in the calculation of `secondCheck`.  
  
## Example 2  

 The following example shows an `If`...`Then` statement containing two procedure calls. If the first call returns `True`, the second procedure is not called. This could produce unexpected results if the second procedure performs important tasks that should always be performed when this section of the code runs.  
  
 [!code-vb[VbVbalrOperators#38](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#38)]  
  
## See also

- [Logical/Bitwise Operators (Visual Basic)](logical-bitwise-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Or Operator](or-operator.md)
- [IsTrue Operator](istrue-operator.md)
- [Logical and Bitwise Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
