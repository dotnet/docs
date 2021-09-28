---
description: "Learn more about:  Operator (Visual Basic)"
title: "\\ Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.\\"
  - "\\"
helpviewer_keywords: 
  - "division operator [Visual Basic], integer"
  - "integer division operator [Visual Basic]"
  - "zero, division by zero"
  - "arithmetic operators [Visual Basic], division"
  - "division [Visual Basic], by zero"
  - "backslash (\\) [Visual Basic]"
  - "\\ operator [Visual Basic]"
  - "integer quotient"
  - "math operators [Visual Basic]"
  - "quotients, integer"
  - "truncation [Visual Basic], integer division"
ms.assetid: 4b0ee347-950c-45c9-8e23-54bc85df208e
---
# \ Operator (Visual Basic)

Divides two numbers and returns an integer result.  
  
## Syntax  
  
```vb  
expression1 \ expression2  
```  
  
## Parts  

 `expression1`  
 Required. Any numeric expression.  
  
 `expression2`  
 Required. Any numeric expression.  
  
## Supported Types  

 All numeric types, including the unsigned and floating-point types and `Decimal`.  
  
## Result  

 The result is the integer quotient of `expression1` divided by `expression2`, which discards any remainder and retains only the integer portion. This is known as *truncation*.  
  
 The result data type is a numeric type appropriate for the data types of `expression1` and `expression2`. See the "Integer Arithmetic" tables in [Data Types of Operator Results](data-types-of-operator-results.md).  
  
 The [/ Operator (Visual Basic)](floating-point-division-operator.md) returns the full quotient, which retains the remainder in the fractional portion.  
  
## Remarks  

 Before performing the division, Visual Basic attempts to convert any floating-point numeric expression to `Long`. If `Option Strict` is `On`, a compiler error occurs. If `Option Strict` is `Off`, an <xref:System.OverflowException> is possible if the value is outside the range of the [Long Data Type](../data-types/long-data-type.md). The conversion to `Long` is also subject to *banker's rounding*. For more information, see "Fractional Parts" in [Type Conversion Functions](../functions/type-conversion-functions.md).  
  
 If `expression1` or `expression2` evaluates to [Nothing](../nothing.md), it is treated as zero.  
  
## Attempted Division by Zero  

 If `expression2` evaluates to zero, the `\` operator throws a <xref:System.DivideByZeroException> exception. This is true for all numeric data types of the operands.  
  
> [!NOTE]
> The `\` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example uses the `\` operator to perform integer division. The result is an integer that represents the integer quotient of the two operands, with the remainder discarded.  
  
 [!code-vb[VbVbalrOperators#18](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#18)]  
  
 The expressions in the preceding example return values of 2, 3, 33, and -22, respectively.  
  
## See also

- [\\= Operator](integer-division-assignment-operator.md)
- [/ Operator (Visual Basic)](floating-point-division-operator.md)
- [Option Strict Statement](../statements/option-strict-statement.md)
- [Arithmetic Operators](arithmetic-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Arithmetic Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)
