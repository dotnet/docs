---
description: "Learn more about: - Operator (Visual Basic)"
title: "- Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Negate"
  - "vb.-"
helpviewer_keywords: 
  - "operator [Visual Basic]"
  - "operators [Visual Basic], subtraction"
  - "operators [Visual Basic], difference"
  - "negation operator [Visual Basic]"
  - "operators [Visual Basic], arithmetic"
  - "subtraction operator [Visual Basic], syntax"
  - "arithmetic operators [Visual Basic], subtraction"
  - "difference operator [Visual Basic]"
  - "math operators [Visual Basic]"
  - "operators [Visual Basic], negation"
  - "minus operator [Visual Basic]"
ms.assetid: bff2c368-662d-4c92-ac87-1d9bdfd3426a
---
# - Operator (Visual Basic)

Returns the difference between two numeric expressions or the negative value of a numeric expression.  
  
## Syntax  
  
```vb  
expression1 – expression2
```
  
or

```vb  
–expression1  
```  
  
## Parts  

 `expression1`  
 Required. Any numeric expression.  
  
 `expression2`  
 Required unless the `–` operator is calculating a negative value. Any numeric expression.  
  
## Result  

 The result is the difference between `expression1` and `expression2`, or the negated value of `expression1`.  
  
 The result data type is a numeric type appropriate for the data types of `expression1` and `expression2`. See the "Integer Arithmetic" tables in [Data Types of Operator Results](data-types-of-operator-results.md).  
  
## Supported Types  

 All numeric types. This includes the unsigned and floating-point types and `Decimal`.  
  
## Remarks  

 In the first usage shown in the syntax shown previously, the `–` operator is the *binary* arithmetic subtraction operator for the difference between two numeric expressions.  
  
 In the second usage shown in the syntax shown previously, the `–` operator is the *unary* negation operator for the negative value of an expression. In this sense, the negation consists of reversing the sign of `expression1` so that the result is positive if `expression1` is negative.  
  
 If either expression evaluates to [Nothing](../nothing.md), the `–` operator treats it as zero.  
  
> [!NOTE]
> The `–` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, make sure that you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example uses the `–` operator to calculate and return the difference between two numbers, and then to negate a number.  
  
 [!code-vb[VbVbalrOperators#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#10)]  
  
 Following the execution of these statements, `binaryResult` contains 124.45 and `unaryResult` contains –334.90.  
  
## See also

- [-= Operator (Visual Basic)](subtraction-assignment-operator.md)
- [Arithmetic Operators](arithmetic-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Arithmetic Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)
