---
title: "Logical and Bitwise Operators in Visual Basic"
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
  - "operators [Visual Basic], logical"
  - "AndAlso operator [Visual Basic]"
  - "Not operator [Visual Basic], Boolean expressions"
  - "Xor operator [Visual Basic], Boolean expressions"
  - "And operator [Visual Basic], logical operators"
  - "logical operators [Visual Basic]"
  - "expressions [Visual Basic], Boolean"
  - "Or operator [Visual Basic], logical operators"
  - "Visual Basic code, operators"
  - "short-circuiting [Visual Basic], logical operators"
  - "logical operators [Visual Basic], short-circuiting"
  - "Visual Basic code, expressions"
  - "logical operators [Visual Basic], binary"
  - "OrElse operator [Visual Basic]"
  - "logical operators [Visual Basic], unary"
ms.assetid: ca474e13-567d-4b1d-a18b-301433705e57
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Logical and Bitwise Operators in Visual Basic
Logical operators compare `Boolean` expressions and return a `Boolean` result. The `And`, `Or`, `AndAlso`, `OrElse`, and `Xor` operators are *binary* because they take two operands, while the `Not` operator is *unary* because it takes a single operand. Some of these operators can also perform bitwise logical operations on integral values.  
  
## Unary Logical Operator  
 The [Not Operator](../../../../visual-basic/language-reference/operators/not-operator.md) performs logical *negation* on a `Boolean` expression. It yields the logical opposite of its operand. If the expression evaluates to `True`, then `Not` returns `False`; if the expression evaluates to `False`, then `Not` returns `True`. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#77](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/logical-and-bitwise-operators_1.vb)]  
  
## Binary Logical Operators  
 The [And Operator](../../../../visual-basic/language-reference/operators/and-operator.md) performs logical *conjunction* on two `Boolean` expressions. If both expressions evaluate to `True`, then `And` returns `True`. If at least one of the expressions evaluates to `False`, then `And` returns `False`.  
  
 The [Or Operator](../../../../visual-basic/language-reference/operators/or-operator.md) performs logical *disjunction* or *inclusion* on two `Boolean` expressions. If either expression evaluates to `True`, or both evaluate to `True`, then `Or` returns `True`. If neither expression evaluates to `True`, `Or` returns `False`.  
  
 The [Xor Operator](../../../../visual-basic/language-reference/operators/xor-operator.md) performs logical *exclusion* on two `Boolean` expressions. If exactly one expression evaluates to `True`, but not both, `Xor` returns `True`. If both expressions evaluate to `True` or both evaluate to `False`, `Xor` returns `False`.  
  
 The following example illustrates the `And`, `Or`, and `Xor` operators.  
  
 [!code-vb[VbVbalrOperators#78](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/logical-and-bitwise-operators_2.vb)]  
  
## Short-Circuiting Logical Operations  
 The [AndAlso Operator](../../../../visual-basic/language-reference/operators/andalso-operator.md) is very similar to the `And` operator, in that it also performs logical conjunction on two `Boolean` expressions. The key difference between the two is that `AndAlso` exhibits *short-circuiting* behavior. If the first expression in an `AndAlso` expression evaluates to `False`, then the second expression is not evaluated because it cannot alter the final result, and `AndAlso` returns `False`.  
  
 Similarly, the [OrElse Operator](../../../../visual-basic/language-reference/operators/orelse-operator.md) performs short-circuiting logical disjunction on two `Boolean` expressions. If the first expression in an `OrElse` expression evaluates to `True`, then the second expression is not evaluated because it cannot alter the final result, and `OrElse` returns `True`.  
  
### Short-Circuiting Trade-Offs  
 Short-circuiting can improve performance by not evaluating an expression that cannot alter the result of the logical operation. However, if that expression performs additional actions, short-circuiting skips those actions. For example, if the expression includes a call to a `Function` procedure, that procedure is not called if the expression is short-circuited, and any additional code contained in the `Function` does not run. Therefore, the function might run only occasionally, and might not be tested correctly. Or the program logic might depend on the code in the `Function`.  
  
 The following example illustrates the difference between `And`, `Or`, and their short-circuiting counterparts.  
  
 [!code-vb[VbVbalrOperators#81](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/logical-and-bitwise-operators_3.vb)]  
  
 [!code-vb[VbVbalrOperators#80](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/logical-and-bitwise-operators_4.vb)]  
  
 [!code-vb[VbVbalrOperators#79](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/logical-and-bitwise-operators_5.vb)]  
  
 In the preceding example, note that some important code inside `checkIfValid()` does not run when the call is short-circuited. The first `If` statement calls `checkIfValid()` even though `12 > 45` returns `False`, because `And` does not short-circuit. The second `If` statement does not call `checkIfValid()`, because when `12 > 45` returns `False`, `AndAlso` short-circuits the second expression. The third `If` statement calls `checkIfValid()` even though `12 < 45` returns `True`, because `Or` does not short-circuit. The fourth `If` statement does not call `checkIfValid()`, because when `12 < 45` returns `True`, `OrElse` short-circuits the second expression.  
  
## Bitwise Operations  
 Bitwise operations evaluate two integral values in binary (base 2) form. They compare the bits at corresponding positions and then assign values based on the comparison. The following example illustrates the `And` operator.  
  
 [!code-vb[VbVbalrConcepts#2](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/codesnippet/VisualBasic/logical-and-bitwise-operators_6.vb)]  
  
 The preceding example sets the value of `x` to 1. This happens for the following reasons:  
  
-   The values are treated as binary:  
  
     3 in binary form = 011  
  
     5 in binary form = 101  
  
-   The `And` operator compares the binary representations, one binary position (bit) at a time. If both bits at a given position are 1, then a 1 is placed in that position in the result. If either bit is 0, then a 0 is placed in that position in the result. In the preceding example this works out as follows:  
  
     011 (3 in binary form)  
  
     101 (5 in binary form)  
  
     001 (The result, in binary form)  
  
-   The result is treated as decimal. The value 001 is the binary representation of 1, so `x` = 1.  
  
 The bitwise `Or` operation is similar, except that a 1 is assigned to the result bit if either or both of the compared bits is 1. `Xor` assigns a 1 to the result bit if exactly one of the compared bits (not both) is 1. `Not` takes a single operand and inverts all the bits, including the sign bit, and assigns that value to the result. This means that for signed positive numbers, `Not` always returns a negative value, and for negative numbers, `Not` always returns a positive or zero value.  
  
 The `AndAlso` and `OrElse` operators do not support bitwise operations.  
  
> [!NOTE]
>  Bitwise operations can be performed on integral types only. Floating-point values must be converted to integral types before bitwise operation can proceed.  
  
## See Also  
 [Logical/Bitwise Operators (Visual Basic)](../../../../visual-basic/language-reference/operators/logical-bitwise-operators.md)  
 [Boolean Expressions](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/boolean-expressions.md)  
 [Arithmetic Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)  
 [Comparison Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Concatenation Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md)  
 [Efficient Combination of Operators](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/efficient-combination-of-operators.md)
