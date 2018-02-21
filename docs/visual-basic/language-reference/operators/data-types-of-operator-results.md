---
title: "Data Types of Operator Results (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "data types [Visual Basic], operator result data types"
  - "result data types [Visual Basic]"
  - "operator result data types [Visual Basic]"
  - "operators [Visual Basic], data types"
  - "data types [Visual Basic], ranges"
  - "operators [Visual Basic], result data types"
ms.assetid: 9d524533-e1a1-4aa8-b1b8-622068173d06
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# Data Types of Operator Results (Visual Basic)
[!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] determines the result data type of an operation based on the data types of the operands. In some cases this might be a data type with a greater range than that of either operand.  
  
## Data Type Ranges  
 The ranges of the relevant data types, in order from smallest to largest, are as follows:  
  
-   [Boolean](../../../visual-basic/language-reference/data-types/boolean-data-type.md) — two possible values  
  
-   [SByte](../../../visual-basic/language-reference/data-types/sbyte-data-type.md), [Byte](../../../visual-basic/language-reference/data-types/byte-data-type.md) — 256 possible integral values  
  
-   [Short](../../../visual-basic/language-reference/data-types/short-data-type.md), [UShort](../../../visual-basic/language-reference/data-types/ushort-data-type.md) — 65,536 (6.5...E+4) possible integral values  
  
-   [Integer](../../../visual-basic/language-reference/data-types/integer-data-type.md), [UInteger](../../../visual-basic/language-reference/data-types/uinteger-data-type.md) — 4,294,967,296 (4.2...E+9) possible integral values  
  
-   [Long](../../../visual-basic/language-reference/data-types/long-data-type.md), [ULong](../../../visual-basic/language-reference/data-types/ulong-data-type.md) — 18,446,744,073,709,551,615 (1.8...E+19) possible integral values  
  
-   [Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md) — 1.5...E+29 possible integral values, maximum range 7.9...E+28 (absolute value)  
  
-   [Single](../../../visual-basic/language-reference/data-types/single-data-type.md) — maximum range 3.4...E+38 (absolute value)  
  
-   [Double](../../../visual-basic/language-reference/data-types/double-data-type.md) — maximum range 1.7...E+308 (absolute value)  
  
 For more information on [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] data types, see [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md).  
  
 If an operand evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md), the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] arithmetic operators treat it as zero.  
  
## Decimal Arithmetic  
 Note that the [Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md) data type is neither floating-point nor integer.  
  
 If either operand of a `+`, `–`, `*`, `/`, or `Mod` operation is `Decimal` and the other is not `Single` or `Double`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] widens the other operand to `Decimal`. It performs the operation in `Decimal`, and the result data type is `Decimal`.  
  
## Floating-Point Arithmetic  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] performs most floating-point arithmetic in [Double](../../../visual-basic/language-reference/data-types/double-data-type.md), which is the most efficient data type for such operations. However, if one operand is [Single](../../../visual-basic/language-reference/data-types/single-data-type.md) and the other is not `Double`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] performs the operation in `Single`. It widens each operand as necessary to the appropriate data type before the operation, and the result has that data type.  
  
### / and ^ Operators  
 The `/` operator is defined only for the [Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md), [Single](../../../visual-basic/language-reference/data-types/single-data-type.md), and [Double](../../../visual-basic/language-reference/data-types/double-data-type.md) data types. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] widens each operand as necessary to the appropriate data type before the operation, and the result has that data type.  
  
 The following table shows the result data types for the `/` operator. Note that this table is symmetric; for a given combination of operand data types, the result data type is the same regardless of the order of the operands.  
  
||||||  
|---|---|---|---|---|  
||`Decimal`|`Single`|`Double`|Any integer type|  
|`Decimal`|Decimal|Single|Double|Decimal|  
|`Single`|Single|Single|Double|Single|  
|`Double`|Double|Double|Double|Double|  
|Any integer type|Decimal|Single|Double|Double|  
  
 The `^` operator is defined only for the `Double` data type. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] widens each operand as necessary to `Double` before the operation, and the result data type is always `Double`.  
  
## Integer Arithmetic  
 The result data type of an integer operation depends on the data types of the operands. In general, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] uses the following policies for determining the result data type:  
  
-   If both operands of a binary operator have the same data type, the result has that data type. An exception is `Boolean`, which is forced to `Short`.  
  
-   If an unsigned operand participates with a signed operand, the result has a signed type with at least as large a range as either operand.  
  
-   Otherwise, the result usually has the larger of the two operand data types.  
  
 Note that the result data type might not be the same as either operand data type.  
  
> [!NOTE]
>  The result data type is not always large enough to hold all possible values resulting from the operation. An <xref:System.OverflowException> exception can occur if the value is too large for the result data type.  
  
### Unary + and – Operators  
 The following table shows the result data types for the two unary operators, `+` and `–`.  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|Unary `+`|Short|SByte|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
|Unary `–`|Short|SByte|Short|Short|Integer|Integer|Long|Long|Decimal|  
  
### <\< and >> Operators  
 The following table shows the result data types for the two bit-shift operators, `<<` and `>>`. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] treats each bit-shift operator as a unary operator on its left operand (the bit pattern to be shifted).  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|`<<`, `>>`|Short|SByte|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
  
 If the left operand is `Decimal`, `Single`, `Double`, or `String`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert it to `Long` before the operation, and the result data type is `Long`. The right operand (the number of bit positions to shift) must be `Integer` or a type that widens to `Integer`.  
  
### Binary +, –, *, and Mod Operators  
 The following table shows the result data types for the binary `+` and `–` operators and the `*` and `Mod` operators. Note that this table is symmetric; for a given combination of operand data types, the result data type is the same regardless of the order of the operands.  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|`Boolean`|Short|SByte|Short|Short|Integer|Integer|Long|Long|Decimal|  
|`SByte`|SByte|SByte|Short|Short|Integer|Integer|Long|Long|Decimal|  
|`Byte`|Short|Short|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
|`Short`|Short|Short|Short|Short|Integer|Integer|Long|Long|Decimal|  
|`UShort`|Integer|Integer|UShort|Integer|UShort|Integer|UInteger|Long|ULong|  
|`Integer`|Integer|Integer|Integer|Integer|Integer|Integer|Long|Long|Decimal|  
|`UInteger`|Long|Long|UInteger|Long|UInteger|Long|UInteger|Long|ULong|  
|`Long`|Long|Long|Long|Long|Long|Long|Long|Long|Decimal|  
|`ULong`|Decimal|Decimal|ULong|Decimal|ULong|Decimal|ULong|Decimal|ULong|  
  
### \ Operator  
 The following table shows the result data types for the `\` operator. Note that this table is symmetric; for a given combination of operand data types, the result data type is the same regardless of the order of the operands.  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|`Boolean`|Short|SByte|Short|Short|Integer|Integer|Long|Long|Long|  
|`SByte`|SByte|SByte|Short|Short|Integer|Integer|Long|Long|Long|  
|`Byte`|Short|Short|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
|`Short`|Short|Short|Short|Short|Integer|Integer|Long|Long|Long|  
|`UShort`|Integer|Integer|UShort|Integer|UShort|Integer|UInteger|Long|ULong|  
|`Integer`|Integer|Integer|Integer|Integer|Integer|Integer|Long|Long|Long|  
|`UInteger`|Long|Long|UInteger|Long|UInteger|Long|UInteger|Long|ULong|  
|`Long`|Long|Long|Long|Long|Long|Long|Long|Long|Long|  
|`ULong`|Long|Long|ULong|Long|ULong|Long|ULong|Long|ULong|  
  
 If either operand of the `\` operator is [Decimal](../../../visual-basic/language-reference/data-types/decimal-data-type.md), [Single](../../../visual-basic/language-reference/data-types/single-data-type.md), or [Double](../../../visual-basic/language-reference/data-types/double-data-type.md), [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert it to [Long](../../../visual-basic/language-reference/data-types/long-data-type.md) before the operation, and the result data type is `Long`.  
  
## Relational and Bitwise Comparisons  
 The result data type of a relational operation (`=`, `<>`, `<`, `>`, `<=`, `>=`) is always `Boolean`[Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md). The same is true for logical operations (`And`, `AndAlso`, `Not`, `Or`, `OrElse`, `Xor`) on `Boolean` operands.  
  
 The result data type of a bitwise logical operation depends on the data types of the operands. Note that `AndAlso` and `OrElse` are defined only for `Boolean`, and [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] converts each operand as necessary to `Boolean` before performing the operation.  
  
### =, <>, \<, >, \<=, and >= Operators  
 If both operands are `Boolean`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] considers `True` to be less than `False`. If a numeric type is compared with a `String`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert the `String` to `Double` before the operation. A `Char` or `Date` operand can be compared only with another operand of the same data type. The result data type is always `Boolean`.  
  
### Bitwise Not Operator  
 The following table shows the result data types for the bitwise `Not` operator.  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|`Not`|Boolean|SByte|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
  
 If the operand is `Decimal`, `Single`, `Double`, or `String`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert it to `Long` before the operation, and the result data type is `Long`.  
  
### Bitwise And, Or, and Xor Operators  
 The following table shows the result data types for the bitwise `And`, `Or`, and `Xor` operators. Note that this table is symmetric; for a given combination of operand data types, the result data type is the same regardless of the order of the operands.  
  
|||||||||||  
|---|---|---|---|---|---|---|---|---|---|  
||`Boolean`|`SByte`|`Byte`|`Short`|`UShort`|`Integer`|`UInteger`|`Long`|`ULong`|  
|`Boolean`|Boolean|SByte|Short|Short|Integer|Integer|Long|Long|Long|  
|`SByte`|SByte|SByte|Short|Short|Integer|Integer|Long|Long|Long|  
|`Byte`|Short|Short|Byte|Short|UShort|Integer|UInteger|Long|ULong|  
|`Short`|Short|Short|Short|Short|Integer|Integer|Long|Long|Long|  
|`UShort`|Integer|Integer|UShort|Integer|UShort|Integer|UInteger|Long|ULong|  
|`Integer`|Integer|Integer|Integer|Integer|Integer|Integer|Long|Long|Long|  
|`UInteger`|Long|Long|UInteger|Long|UInteger|Long|UInteger|Long|ULong|  
|`Long`|Long|Long|Long|Long|Long|Long|Long|Long|Long|  
|`ULong`|Long|Long|ULong|Long|ULong|Long|ULong|Long|ULong|  
  
 If an operand is `Decimal`, `Single`, `Double`, or `String`, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert it to `Long` before the operation, and the result data type is the same as if that operand had already been `Long`.  
  
## Miscellaneous Operators  
 The `&` operator is defined only for concatenation of `String` operands. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] converts each operand as necessary to `String` before the operation, and the result data type is always `String`. For the purposes of the `&` operator, all conversions to `String` are considered to be widening, even if `Option Strict` is `On`.  
  
 The `Is` and `IsNot` operators require both operands to be of a reference type. The `TypeOf`...`Is` expression requires the first operand to be of a reference type and the second operand to be the name of a data type. In all these cases the result data type is `Boolean`.  
  
 The `Like` operator is defined only for pattern matching of `String` operands. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to convert each operand as necessary to `String` before the operation. The result data type is always `Boolean`.  
  
## See Also  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)  
 [Arithmetic Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)  
 [Comparison Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Operators](../../../visual-basic/language-reference/operators/index.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Arithmetic Operators](../../../visual-basic/language-reference/operators/arithmetic-operators.md)  
 [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md)  
 [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md)
