---
description: "Learn more about: Operators and Expressions in Visual Basic"
title: "Operators and Expressions"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "operators [Visual Basic], operands"
  - "operators [Visual Basic]"
  - "operands [Visual Basic], definition"
  - "Visual Basic code, operators"
  - "Visual Basic code, expressions"
  - "operands"
  - "expressions [Visual Basic]"
ms.assetid: b86f3131-94ee-448f-96cd-79611e028b26
---
# Operators and Expressions in Visual Basic

An *operator* is a code element that performs an operation on one or more code elements that hold values. Value elements include variables, constants, literals, properties, returns from `Function` and `Operator` procedures, and expressions.  
  
 An *expression* is a series of value elements combined with operators, which yields a new value. The operators act on the value elements by performing calculations, comparisons, or other operations.  
  
## Types of Operators  

 Visual Basic provides the following types of operators:  
  
- [Arithmetic Operators](arithmetic-operators.md) perform familiar calculations on numeric values, including shifting their bit patterns.  
  
- [Comparison Operators](comparison-operators.md) compare two expressions and return a `Boolean` value representing the result of the comparison.  
  
- [Concatenation Operators](concatenation-operators.md) join multiple strings into a single string.  
  
- [Logical and Bitwise Operators in Visual Basic](logical-and-bitwise-operators.md) combine `Boolean` or numeric values and return a result of the same data type as the values.  
  
 The value elements that are combined with an operator are called *operands* of that operator. Operators combined with value elements form expressions, except for the assignment operator, which forms a *statement*. For more information, see [Statements](../statements.md).  
  
## Evaluation of Expressions  

 The end result of an expression represents a value, which is typically of a familiar data type such as `Boolean`, `String`, or a numeric type.  
  
 The following are examples of expressions.  
  
 `5 + 4`  
  
 `' The preceding expression evaluates to 9.`  
  
 `15 * System.Math.Sqrt(9) + x`  
  
 `' The preceding expression evaluates to 45 plus the value of x.`  
  
 `"Concat" & "ena" & "tion"`  
  
 `' The preceding expression evaluates to "Concatenation".`  
  
 `763 < 23`  
  
 `' The preceding expression evaluates to False.`  
  
 Several operators can perform actions in a single expression or statement, as the following example illustrates.  
  
 [!code-vb[VbVbalrOperators#56](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#56)]  
  
 In the preceding example, Visual Basic performs the operations in the expression on the right side of the assignment operator (`=`), then assigns the resulting value to the variable `x` on the left. There is no practical limit to the number of operators that can be combined into an expression, but an understanding of [Operator Precedence in Visual Basic](../../../language-reference/operators/operator-precedence.md) is necessary to ensure that you get the results you expect.  

## See also

- [Operators](../../../language-reference/operators/index.md)
- [Efficient Combination of Operators](efficient-combination-of-operators.md)
- [Statements](../../../language-reference/statements/index.md)
