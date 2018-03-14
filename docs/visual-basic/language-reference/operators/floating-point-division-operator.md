---
title: "/ Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb./"
helpviewer_keywords: 
  - "division operator [Visual Basic], floating point"
  - "floating-point numbers [Visual Basic], division operator"
  - "slash (/) operator"
  - "zero, division by zero"
  - "operators [Visual Basic], arithmetic"
  - "arithmetic operators [Visual Basic], division"
  - "division [Visual Basic], by zero"
  - "operators [Visual Basic], division"
  - "division operator [Visual Basic], syntax"
  - "/ operator [Visual Basic]"
  - "math operators [Visual Basic]"
ms.assetid: 335e97f2-c434-439e-9064-76973a051101
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# / Operator (Visual Basic)
Divides two numbers and returns a floating-point result.  
  
## Syntax  
  
```  
expression1 / expression2  
```  
  
## Parts  
 `expression1`  
 Required. Any numeric expression.  
  
 `expression2`  
 Required. Any numeric expression.  
  
## Supported Types  
 All numeric types, including the unsigned and floating-point types and `Decimal`.  
  
## Result  
 The result is the full quotient of `expression1` divided by `expression2`, including any remainder.  
  
 The [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md) returns the integer quotient, which drops the remainder.  
  
## Remarks  
 The data type of the result depends on the types of the operands. The following table shows how the data type of the result is determined.  
  
|Operand data types|Result data type|  
|------------------------|----------------------|  
|Both expressions are integral data types ([SByte](../../../visual-basic/language-reference/data-types/sbyte-data-type.md), [Byte](../../../visual-basic/language-reference/data-types/byte-data-type.md), [Short](../../../visual-basic/language-reference/data-types/short-data-type.md), [UShort](../../../visual-basic/language-reference/data-types/ushort-data-type.md), [Integer](../../../visual-basic/language-reference/data-types/integer-data-type.md), [UInteger](../../../visual-basic/language-reference/data-types/uinteger-data-type.md), [Long](../../../visual-basic/language-reference/data-types/long-data-type.md), [ULong](../../../visual-basic/language-reference/data-types/ulong-data-type.md))|`Double`|  
|One expression is a [Single](../../../visual-basic/language-reference/data-types/single-data-type.md) data type and the other is not a [Double](../../../visual-basic/language-reference/data-types/double-data-type.md)|`Single`|  
|One expression is a [Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md) data type and the other is not a [Single](../../../visual-basic/language-reference/data-types/single-data-type.md) or a [Double](../../../visual-basic/language-reference/data-types/double-data-type.md)|`Decimal`|  
|Either expression is a [Double](../../../visual-basic/language-reference/data-types/double-data-type.md) data type|`Double`|  
  
 Before division is performed, any integral numeric expressions are widened to `Double`. If you assign the result to an integral data type, Visual Basic attempts to convert the result from `Double` to that type. This can throw an exception if the result does not fit in that type. In particular, see "Attempted Division by Zero" on this Help page.  
  
 If `expression1` or `expression2` evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md), it is treated as zero.  
  
## Attempted Division by Zero  
 If `expression2` evaluates to zero, the `/` operator behaves differently for different operand data types. The following table shows the possible behaviors.  
  
|Operand data types|Behavior if `expression2` is zero|  
|------------------------|---------------------------------------|  
|Floating-point (`Single` or `Double`)|Returns infinity (<xref:System.Double.PositiveInfinity> or <xref:System.Double.NegativeInfinity>), or <xref:System.Double.NaN> (not a number) if `expression1` is also zero|  
|`Decimal`|Throws <xref:System.DivideByZeroException>|  
|Integral (signed or unsigned)|Attempted conversion back to integral type throws <xref:System.OverflowException> because integral types cannot accept <xref:System.Double.PositiveInfinity>, <xref:System.Double.NegativeInfinity>, or <xref:System.Double.NaN>|  
  
> [!NOTE]
>  The `/` operator can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 This example uses the `/` operator to perform floating-point division. The result is the quotient of the two operands.  
  
 [!code-vb[VbVbalrOperators#16](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/floating-point-division-operator_1.vb)]  
  
 The expressions in the preceding example return values of 2.5 and 3.333333. Note that the result is always floating-point (`Double`), even though both operands are integer constants.  
  
## See Also  
 [/= Operator (Visual Basic)](../../../visual-basic/language-reference/operators/floating-point-division-assignment-operator.md)  
 [\ Operator (Visual Basic)](../../../visual-basic/language-reference/operators/integer-division-operator.md)  
 [Data Types of Operator Results](../../../visual-basic/language-reference/operators/data-types-of-operator-results.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Arithmetic Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)
