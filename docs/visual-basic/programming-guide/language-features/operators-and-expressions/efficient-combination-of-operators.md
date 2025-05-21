---
description: "Learn more about: Efficient Combination of Operators (Visual Basic)"
title: "Efficient Combination of Operators"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "expressions [Visual Basic], parentheses"
  - "operators [Visual Basic], associativity"
  - "expressions [Visual Basic], operators"
  - "operators [Visual Basic], precedence"
  - "Visual Basic code, operators"
  - "Visual Basic code, expressions"
  - "operators [Visual Basic], complex expressions"
  - "expressions [Visual Basic], complex"
  - "parentheses [Visual Basic], complex expressions"
  - "numeric expressions"
ms.assetid: bd22340e-b5be-458b-8772-3916c02309a4
ms.topic: article
---
# Efficient Combination of Operators (Visual Basic)

Complex expressions can contain many different operators. The following example illustrates this.  
  
 `x = (45 * (y + z)) ^ (2 / 85) * 5 + z`  
  
 Creating complex expressions such as the one in the preceding example requires a thorough understanding of the rules of operator precedence. For more information, see [Operator Precedence in Visual Basic](../../../language-reference/operators/operator-precedence.md).  
  
## Parenthetical Expressions  

 Often you want operations to proceed in a different order from that determined by operator precedence. Consider the following example.  
  
 `x = z * y + 4`  
  
 The preceding example multiplies `z` by `y`, then adds the result to `4`. But if you want to add `y` and `4` before multiplying the result by `z`, you can override normal operator precedence by using parentheses. By enclosing an expression in parentheses, you force that expression to be evaluated first, regardless of operator precedence. To force the preceding example to do the addition first, you could rewrite it as in the following example.  
  
 `x = z * (y + 4)`  
  
 The preceding example adds `y` and `4`, then multiplies that sum by `z`.  
  
### Nested Parenthetical Expressions  

 You can nest expressions in multiple levels of parentheses to override precedence even further. The expressions most deeply nested in parentheses are evaluated first, followed by the next most deeply nested, and so on to the least deeply nested, and finally the expressions outside parentheses. The following example illustrates this.  
  
 `x = (z * 4) ^ (y * (z + 2))`  
  
 In the preceding example, `z + 2` is evaluated first, then the other parenthetical expressions. Exponentiation, which normally has higher precedence than addition or multiplication, is evaluated last in this example because the other expressions are enclosed in parentheses.  
  
## See also

- [Arithmetic Operators in Visual Basic](arithmetic-operators.md)
- [Comparison Operators in Visual Basic](comparison-operators.md)
- [Logical and Bitwise Operators in Visual Basic](logical-and-bitwise-operators.md)
- [Logical/Bitwise Operators (Visual Basic)](../../../language-reference/operators/logical-bitwise-operators.md)
- [Boolean Expressions](boolean-expressions.md)
- [Value Comparisons](value-comparisons.md)
- [How to: Calculate Numeric Values](how-to-calculate-numeric-values.md)
- [Operator Precedence in Visual Basic](../../../language-reference/operators/operator-precedence.md)
