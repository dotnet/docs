---
title: "Arithmetic Operators in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "type safety"
  - "operators [Visual Basic], bitwise"
  - "operators [Visual Basic], bit-shift"
  - "bitwise operators [Visual Basic]"
  - "bit-shift operators [Visual Basic]"
  - "zero, division by zero"
  - "operators [Visual Basic], arithmetic"
  - "division [Visual Basic], by zero"
  - "Visual Basic code, operators"
  - "arithmetic operators [Visual Basic], about arithmetic operators"
ms.assetid: 325dac7a-ea4f-41d5-8b48-f6e904211569
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Arithmetic Operators in Visual Basic
Arithmetic operators are used to perform many of the familiar arithmetic operations that involve the calculation of numeric values represented by literals, variables, other expressions, function and property calls, and constants. Also classified with arithmetic operators are the bit-shift operators, which act at the level of the individual bits of the operands and shift their bit patterns to the left or right.  
  
## Arithmetic Operations  
 You can add two values in an expression together with the [+ Operator](../../../../visual-basic/language-reference/operators/addition-operator.md), or subtract one from another with the [- Operator (Visual Basic)](../../../../visual-basic/language-reference/operators/subtraction-operator.md), as the following example demonstrates.  
  
 [!code-vb[VbVbalrOperators#57](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_1.vb)]  
  
 Negation also uses the [- Operator (Visual Basic)](../../../../visual-basic/language-reference/operators/subtraction-operator.md), but with only one operand, as the following example demonstrates.  
  
 [!code-vb[VbVbalrOperators#58](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_2.vb)]  
  
 Multiplication and division use the [* Operator](../../../../visual-basic/language-reference/operators/multiplication-operator.md) and [/ Operator (Visual Basic)](../../../../visual-basic/language-reference/operators/floating-point-division-operator.md), respectively, as the following example demonstrates.  
  
 [!code-vb[VbVbalrOperators#59](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_3.vb)]  
  
 Exponentiation uses the [^ Operator](../../../../visual-basic/language-reference/operators/exponentiation-operator.md), as the following example demonstrates.  
  
 [!code-vb[VbVbalrOperators#60](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_4.vb)]  
  
 Integer division is carried out using the [\ Operator (Visual Basic)](../../../../visual-basic/language-reference/operators/integer-division-operator.md). Integer division returns the quotient, that is, the integer that represents the number of times the divisor can divide into the dividend without consideration of any remainder. Both the divisor and the dividend must be integral types (`SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, and `ULong`) for this operator. All other types must be converted to an integral type first. The following example demonstrates integer division.  
  
 [!code-vb[VbVbalrOperators#61](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_5.vb)]  
  
 Modulus arithmetic is performed using the [Mod Operator](../../../../visual-basic/language-reference/operators/mod-operator.md). This operator returns the remainder after dividing the divisor into the dividend an integral number of times. If both divisor and dividend are integral types, the returned value is integral. If divisor and dividend are floating-point types, the returned value is also floating-point. The following example demonstrates this behavior.  
  
 [!code-vb[VbVbalrOperators#62](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_6.vb)]  
  
 [!code-vb[VbVbalrOperators#63](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_7.vb)]  
  
### Attempted Division by Zero  
 Division by zero has different results depending on the data types involved. In integral divisions (`SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, `ULong`), the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] throws a <xref:System.DivideByZeroException> exception. In division operations on the `Decimal` or `Single` data type, the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] also throws a <xref:System.DivideByZeroException> exception.  
  
 In floating-point divisions involving the `Double` data type, no exception is thrown, and the result is the class member representing <xref:System.Double.NaN>, <xref:System.Double.PositiveInfinity>, or <xref:System.Double.NegativeInfinity>, depending on the dividend. The following table summarizes the various results of attempting to divide a `Double` value by zero.  
  
|Dividend data type|Divisor data type|Dividend value|Result|  
|---|---|---|---|  
|`Double`|`Double`|0|<xref:System.Double.NaN> (not a mathematically defined number)|  
|`Double`|`Double`|> 0|<xref:System.Double.PositiveInfinity>|  
|`Double`|`Double`|\< 0|<xref:System.Double.NegativeInfinity>|  
  
 When you catch a <xref:System.DivideByZeroException> exception, you can use its members to help you handle it. For example, the <xref:System.Exception.Message%2A> property holds the message text for the exception. For more information, see [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
## Bit-Shift Operations  
 A bit-shift operation performs an arithmetic shift on a bit pattern. The pattern is contained in the operand on the left, while the operand on the right specifies the number of positions to shift the pattern. You can shift the pattern to the right with the [>> Operator](../../../../visual-basic/language-reference/operators/right-shift-operator.md) or to the left with the [<< Operator](../../../../visual-basic/language-reference/operators/left-shift-operator.md).  
  
 The data type of the pattern operand must be `SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, or `ULong`. The data type of the shift amount operand must be `Integer` or must widen to `Integer`.  
  
 Arithmetic shifts are not circular, which means the bits shifted off one end of the result are not reintroduced at the other end. The bit positions vacated by a shift are set as follows:  
  
-   0 for an arithmetic left shift  
  
-   0 for an arithmetic right shift of a positive number  
  
-   0 for an arithmetic right shift of an unsigned data type (`Byte`, `UShort`, `UInteger`, `ULong`)  
  
-   1 for an arithmetic right shift of a negative number (`SByte`, `Short`, `Integer`, or `Long`)  
  
 The following example shifts an `Integer` value both left and right.  
  
 [!code-vb[VbVbalrOperators#64](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/arithmetic-operators_8.vb)]  
  
 Arithmetic shifts never generate overflow exceptions.  
  
## Bitwise Operations  
 In addition to being logical operators, `Not`, `Or`, `And`, and `Xor` also perform bitwise arithmetic when used on numeric values. For more information, see "Bitwise Operations" in [Logical and Bitwise Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md).  
  
## Type Safety  
 Operands should normally be of the same type. For example, if you are doing addition with an `Integer` variable, you should add it to another `Integer` variable, and you should assign the result to a variable of type `Integer` as well.  
  
 One way to ensure good type-safe coding practice is to use the [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md). If you set `Option Strict On`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically performs *type-safe* conversions. For example, if you try to add an `Integer` variable to a `Double` variable and assign the value to a `Double` variable, the operation proceeds normally, because an `Integer` value can be converted to `Double` without loss of data. Type-unsafe conversions, on the other hand, cause a compiler error with `Option Strict On`. For example, if you try to add an `Integer` variable to a `Double` variable and assign the value to an `Integer` variable, a compiler error results, because a `Double` variable cannot be implicitly converted to type `Integer`.  
  
 If you set `Option Strict Off`, however, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] allows implicit narrowing conversions to take place, although they can result in the unexpected loss of data or precision. For this reason, we recommend that you use `Option Strict On` when writing production code. For more information, see [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md).  
  
## See Also  
 [Arithmetic Operators](../../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Bit Shift Operators](../../../../visual-basic/language-reference/operators/bit-shift-operators.md)  
 [Comparison Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Concatenation Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md)  
 [Logical and Bitwise Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)  
 [Efficient Combination of Operators](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/efficient-combination-of-operators.md)
