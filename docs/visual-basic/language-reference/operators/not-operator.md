---
description: "Learn more about: Not Operator (Visual Basic)"
title: "Not Operator"
ms.date: 10/27/2023
f1_keywords: 
  - "vb.Not"
helpviewer_keywords: 
  - "Boolean expressions, negating"
  - "operators [Visual Basic], bitwise"
  - "negation operator [Visual Basic]"
  - "inverse bit values in variables [Visual Basic]"
  - "bitwise operators [Visual Basic], NOT operator"
  - "bitwise comparison [Visual Basic]"
  - "Not operator [Visual Basic]"
  - "logical negation"
  - "operators [Visual Basic], negation"
ms.assetid: 8f2ea83c-d2ed-480a-a474-3042a1cad9b5
---
# Not Operator (Visual Basic)

Performs logical negation on a `Boolean` expression, or bitwise negation on a numeric expression.  
  
## Syntax  
  
```vb  
result = Not expression  
```  
  
## Parts  

 `result`  
 Required. Any `Boolean` or numeric expression.  
  
 `expression`  
 Required. Any `Boolean` or numeric expression.  
  
## Remarks  

 For `Boolean` expressions, the following table illustrates how `result` is determined.  
  
|If `expression` is|The value of `result` is|  
|------------------------|------------------------------|  
|`True`|`False`|  
|`False`|`True`|  
  
 For numeric expressions, the `Not` operator inverts the bit values of any numeric expression and sets the corresponding bit in `result` according to the following table.  
  
|If bit in `expression` is|The bit in `result` is|  
|-------------------------------|----------------------------|  
|1|0|  
|0|1|  
  
> [!NOTE]
> Since the logical and bitwise operators have a lower precedence than other arithmetic and relational operators, any bitwise operations should be enclosed in parentheses to ensure accurate execution.  
  
Note that if `Not someStr?.Contains("some string")` or any other value that evaluates as `Boolean?` has the value of `nothing` or `HasValue=false`, the `else` block is run.  The evaluation follows the SQL evaluation where null/nothing doesn't equal anything, not even another null/nothing.

## Data Types  

 For a Boolean negation, the data type of the result is `Boolean`. For a bitwise negation, the result data type is the same as that of `expression`. However, if expression is `Decimal`, the result is `Long`.  
  
## Overloading  

 The `Not` operator can be *overloaded*, which means that a class or structure can redefine its behavior when its operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example 1

 The following example uses the `Not` operator to perform logical negation on a `Boolean` expression. The result is a `Boolean` value that represents the reverse of the value of the expression.  
  
 [!code-vb[VbVbalrOperators#33](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#33)]  
  
 The preceding example produces results of `False` and `True`, respectively.  
  
## Example 2  

 The following example uses the `Not` operator to perform logical negation of the individual bits of a numeric expression. The bit in the result pattern is set to the reverse of the corresponding bit in the operand pattern, including the sign bit.  
  
 [!code-vb[VbVbalrOperators#34](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#34)]  
  
 The preceding example produces results of –11, –9, and –7, respectively.  
  
## See also

- [Logical/Bitwise Operators (Visual Basic)](logical-bitwise-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Logical and Bitwise Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
