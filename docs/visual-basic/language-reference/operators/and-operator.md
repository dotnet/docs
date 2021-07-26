---
description: "Learn more about: And Operator (Visual Basic)"
title: "And Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.And"
helpviewer_keywords: 
  - "operators [Visual Basic], bitwise"
  - "logical conjunction"
  - "bitwise AND operator [Visual Basic]"
  - "conjunction operator [Visual Basic]"
  - "And operator [Visual Basic]"
  - "bitwise operators [Visual Basic], AND operator"
  - "operators [Visual Basic], conjunction"
  - "bitwise comparison [Visual Basic]"
ms.assetid: 2ea711f3-439a-4c7c-9e3a-1ffe3b0d6046
---
# And Operator (Visual Basic)

Performs a logical conjunction on two `Boolean` expressions, or a bitwise conjunction on two numeric expressions.  
  
## Syntax  
  
```vb  
result = expression1 And expression2  
```  
  
## Parts  

 `result`  
 Required. Any `Boolean` or numeric expression. For Boolean comparison, `result` is the logical conjunction of two `Boolean` values. For bitwise operations, `result` is a numeric value representing the bitwise conjunction of two numeric bit patterns.  
  
 `expression1`  
 Required. Any `Boolean` or numeric expression.  
  
 `expression2`  
 Required. Any `Boolean` or numeric expression.  
  
## Remarks  

 For Boolean comparison, `result` is `True` if and only if both `expression1` and `expression2` evaluate to `True`. The following table illustrates how `result` is determined.  
  
|If `expression1` is|And `expression2` is|The value of `result` is|  
|-------------------------|--------------------------|------------------------------|  
|`True`|`True`|`True`|  
|`True`|`False`|`False`|  
|`False`|`True`|`False`|  
|`False`|`False`|`False`|  
  
> [!NOTE]
> In a Boolean comparison, the `And` operator always evaluates both expressions, which could include making procedure calls. The [AndAlso Operator](andalso-operator.md) performs *short-circuiting*, which means that if `expression1` is `False`, then `expression2` is not evaluated.  
  
 When applied to numeric values, the `And` operator performs a bitwise comparison of identically positioned bits in two numeric expressions and sets the corresponding bit in `result` according to the following table.  
  
|If bit in `expression1` is|And bit in `expression2` is|The bit in `result` is|  
|--------------------------------|---------------------------------|----------------------------|  
|1|1|1|  
|1|0|0|  
|0|1|0|  
|0|0|0|  
  
> [!NOTE]
> Since the logical and bitwise operators have a lower precedence than other arithmetic and relational operators, any bitwise operations should be enclosed in parentheses to ensure accurate results.  
  
## Data Types  

 If the operands consist of one `Boolean` expression and one numeric expression, Visual Basic converts the `Boolean` expression to a numeric value (–1 for `True` and 0 for `False`) and performs a bitwise operation.  
  
 For a Boolean comparison, the data type of the result is `Boolean`. For a bitwise comparison, the result data type is a numeric type appropriate for the data types of `expression1` and `expression2`. See the "Relational and Bitwise Comparisons" table in [Data Types of Operator Results](data-types-of-operator-results.md).  
  
> [!NOTE]
> The `And` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example 1

 The following example uses the `And` operator to perform a logical conjunction on two expressions. The result is a `Boolean` value that represents whether both of the expressions are `True`.  
  
 [!code-vb[VbVbalrOperators#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#22)]  
  
 The preceding example produces results of `True` and `False`, respectively.  
  
## Example 2  

 The following example uses the `And` operator to perform logical conjunction on the individual bits of two numeric expressions. The bit in the result pattern is set if the corresponding bits in the operands are both set to 1.  
  
 [!code-vb[VbVbalrOperators#23](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#23)]  
  
 The preceding example produces results of 8, 2, and 0, respectively.  
  
## See also

- [Logical/Bitwise Operators (Visual Basic)](logical-bitwise-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [AndAlso Operator](andalso-operator.md)
- [Logical and Bitwise Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
