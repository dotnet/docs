---
description: "Learn more about: AndAlso Operator (Visual Basic)"
title: "AndAlso Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.AndAlso"
  - "AndAlso"
helpviewer_keywords: 
  - "short-circuiting"
  - "AndAlso operator [Visual Basic]"
  - "operators [Visual Basic], short-circuiting"
  - "operators [Visual Basic], conjunction"
  - "short-circuit evaluation"
ms.assetid: bbc15191-b374-495b-9b8f-7b8c2f4388eb
---
# AndAlso Operator (Visual Basic)

Performs short-circuiting logical conjunction on two expressions.  
  
## Syntax  
  
```vb
result = expression1 AndAlso expression2  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`result`|Required. Any `Boolean` expression. The result is the `Boolean` result of comparison of the two expressions.|  
|`expression1`|Required. Any `Boolean` expression.|  
|`expression2`|Required. Any `Boolean` expression.|  
  
## Remarks  

 A logical operation is said to be *short-circuiting* if the compiled code can bypass the evaluation of one expression depending on the result of another expression. If the result of the first expression evaluated determines the final result of the operation, there is no need to evaluate the second expression, because it cannot change the final result. Short-circuiting can improve performance if the bypassed expression is complex, or if it involves procedure calls.  
  
 If both expressions evaluate to `True`, `result` is `True`. The following table illustrates how `result` is determined.  
  
|If `expression1` is|And `expression2` is|The value of `result` is|  
|---|---|---|  
|`True`|`True`|`True`|  
|`True`|`False`|`False`|  
|`False`|(not evaluated)|`False`|  

> [!NOTE]
> In a Boolean comparison, the `And` operator always evaluates both expressions, which could include making procedure calls. The [AndAlso Operator](andalso-operator.md) performs *short-circuiting*, which means that if `expression1` is `False`, then `expression2` is not evaluated.

## Data Types  

 The `AndAlso` operator is defined only for the [Boolean Data Type](../data-types/boolean-data-type.md). Visual Basic converts each operand as necessary to `Boolean` before evaluating the expression. If you assign the result to a numeric type, Visual Basic converts it from `Boolean` to that type such that `False` becomes `0` and `True` becomes `-1`.
For more information, see [Boolean Type Conversions](../data-types/boolean-data-type.md#type-conversions).
  
## Overloading  

 The [And Operator](and-operator.md) and the [IsFalse Operator](isfalse-operator.md) can be *overloaded*, which means that a class or structure can redefine their behavior when an operand has the type of that class or structure. Overloading the `And` and `IsFalse` operators affects the behavior of the `AndAlso` operator. If your code uses `AndAlso` on a class or structure that overloads `And` and `IsFalse`, be sure you understand their redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example 1

 The following example uses the `AndAlso` operator to perform a logical conjunction on two expressions. The result is a `Boolean` value that represents whether the entire conjoined expression is true. If the first expression is `False`, the second is not evaluated.  
  
 [!code-vb[VbVbalrOperators#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#24)]  
  
 The preceding example produces results of `True`, `False`, and `False`, respectively. In the calculation of `secondCheck`, the second expression is not evaluated because the first is already `False`. However, the second expression is evaluated in the calculation of `thirdCheck`.  
  
## Example 2  

 The following example shows a `Function` procedure that searches for a given value among the elements of an array. If the array is empty, or if the array length has been exceeded, the `While` statement does not test the array element against the search value.  
  
 [!code-vb[VbVbalrOperators#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#25)]  
  
## See also

- [Logical/Bitwise Operators (Visual Basic)](logical-bitwise-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [And Operator](and-operator.md)
- [IsFalse Operator](isfalse-operator.md)
- [Logical and Bitwise Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
