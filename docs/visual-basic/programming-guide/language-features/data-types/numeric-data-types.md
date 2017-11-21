---
title: "Numeric Data Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "integral types [Visual Basic], Visual Basic"
  - "Short data type [Visual Basic], numeric data types"
  - "Double data type [Visual Basic], numeric data types"
  - "Long data type [Visual Basic], Visual Basic numeric data types"
  - "numbers [Visual Basic], whole"
  - "fractions"
  - "numbers"
  - "whole numbers"
  - "integer numbers"
  - "numbers [Visual Basic], integer"
  - "fractional data types [Visual Basic]"
  - "mantissas, of fractional numbers"
  - "mantissas"
  - "data types [Visual Basic], numeric"
  - "Integer data type [Visual Basic], numeric data types"
  - "exponent, of fractional numbers"
  - "integers [Visual Basic]"
  - "numeric data types [Visual Basic], Visual Basic"
  - "Single data type [Visual Basic], numeric types"
  - "Decimal data type [Visual Basic], numeric data types"
ms.assetid: a27bd4d0-7e14-43eb-9cc4-b42eaab323c9
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
---
# Numeric Data Types (Visual Basic)
[!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supplies several *numeric data types* for handling numbers in various representations. *Integral* types represent only whole numbers (positive, negative, and zero), and *nonintegral* types represent numbers with both integer and fractional parts.  
  
 For a table showing a side-by-side comparison of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] data types, see [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md).  
  
## Integral Numeric Types  
 *Integral data types* are those that represent only numbers without fractional parts.  
  
 The *signed* integral data types are [SByte Data Type](../../../../visual-basic/language-reference/data-types/sbyte-data-type.md) (8-bit), [Short Data Type](../../../../visual-basic/language-reference/data-types/short-data-type.md) (16-bit), [Integer Data Type](../../../../visual-basic/language-reference/data-types/integer-data-type.md) (32-bit), and [Long Data Type](../../../../visual-basic/language-reference/data-types/long-data-type.md) (64-bit). If a variable always stores integers rather than fractional numbers, declare it as one of these types.  
  
 The *unsigned* integral types are [Byte Data Type](../../../../visual-basic/language-reference/data-types/byte-data-type.md) (8-bit), [UShort Data Type](../../../../visual-basic/language-reference/data-types/ushort-data-type.md) (16-bit), [UInteger Data Type](../../../../visual-basic/language-reference/data-types/uinteger-data-type.md) (32-bit), and [ULong Data Type](../../../../visual-basic/language-reference/data-types/ulong-data-type.md) (64-bit). If a variable contains binary data, or data of unknown nature, declare it as one of these types.  
  
### Performance  
 Arithmetic operations are faster with integral types than with other data types. They are fastest with the `Integer` and `UInteger` types in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
### Large Integers  
 If you need to hold an integer larger than the `Integer` data type can hold, you can use the `Long` data type instead. `Long` variables can hold numbers from -9,223,372,036,854,775,808 through 9,223,372,036,854,775,807. Operations with `Long` are slightly slower than with `Integer`.  
  
 If you need even larger values, you can use the [Decimal Data Type](../../../../visual-basic/language-reference/data-types/decimal-data-type.md). You can hold numbers from -79,228,162,514,264,337,593,543,950,335 through 79,228,162,514,264,337,593,543,950,335 in a `Decimal` variable if you do not use any decimal places. However, operations with `Decimal` numbers are considerably slower than with any other numeric data type.  
  
### Small Integers  
 If you do not need the full range of the `Integer` data type, you can use the `Short` data type, which can hold integers from -32,768 through 32,767. For the smallest integer range, the `SByte` data type holds integers from -128 through 127. If you have a very large number of variables that hold small integers, the common language runtime can sometimes store your `Short` and `SByte` variables more efficiently and save memory consumption. However, operations with `Short` and `SByte` are somewhat slower than with `Integer`.  
  
### Unsigned Integers  
 If you know that your variable never needs to hold a negative number, you can use the *unsigned types*`Byte`, `UShort`, `UInteger`, and `ULong`. Each of these data types can hold a positive integer twice as large as its corresponding signed type (`SByte`, `Short`, `Integer`, and `Long`). In terms of performance, each unsigned type is exactly as efficient as its corresponding signed type. In particular, `UInteger` shares with `Integer` the distinction of being the most efficient of all the elementary numeric data types.  
  
## Nonintegral Numeric Types  
 *Nonintegral data types* are those that represent numbers with both integer and fractional parts.  
  
 The nonintegral numeric data types are `Decimal` (128-bit fixed point), [Single Data Type](../../../../visual-basic/language-reference/data-types/single-data-type.md) (32-bit floating point), and [Double Data Type](../../../../visual-basic/language-reference/data-types/double-data-type.md) (64-bit floating point). They are all signed types. If a variable can contain a fraction, declare it as one of these types.  
  
 `Decimal` is not a floating-point data type. `Decimal` numbers have a binary integer value and an integer scaling factor that specifies what portion of the value is a decimal fraction.  
  
 You can use `Decimal` variables for money values. The advantage is the precision of the values. The `Double` data type is faster and requires less memory, but it is subject to rounding errors. The `Decimal` data type retains complete accuracy to 28 decimal places.  
  
 Floating-point (`Single` and `Double`) numbers have larger ranges than `Decimal` numbers but can be subject to rounding errors. Floating-point types support fewer significant digits than `Decimal` but can represent values of greater magnitude.  
  
 Nonintegral number values can be expressed as mmmEeee, in which mmm is the *mantissa* (the significant digits) and eee is the *exponent* (a power of 10). The highest positive values of the nonintegral types are 7.9228162514264337593543950335E+28 for `Decimal`, 3.4028235E+38 for `Single`, and 1.79769313486231570E+308 for `Double`.  
  
### Performance  
 `Double` is the most efficient of the fractional data types, because the processors on current platforms perform floating-point operations in double precision. However, operations with `Double` are not as fast as with the integral types such as `Integer`.  
  
### Small Magnitudes  
 For numbers with the smallest possible magnitude (closest to 0), `Double` variables can hold numbers as small as -4.94065645841246544E-324 for negative values and 4.94065645841246544E-324 for positive values.  
  
### Small Fractional Numbers  
 If you do not need the full range of the `Double` data type, you can use the `Single` data type, which can hold floating-point numbers from -3.4028235E+38 through 3.4028235E+38. The smallest magnitudes for `Single` variables are -1.401298E-45 for negative values and 1.401298E-45 for positive values. If you have a very large number of variables that hold small floating-point numbers, the common language runtime can sometimes store your `Single` variables more efficiently and save memory consumption.  
  
## See Also  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Character Data Types](../../../../visual-basic/programming-guide/language-features/data-types/character-data-types.md)  
 [Miscellaneous Data Types](../../../../visual-basic/programming-guide/language-features/data-types/miscellaneous-data-types.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [How to: Call a Windows Function that Takes Unsigned Types](../../../../visual-basic/programming-guide/com-interop/how-to-call-a-windows-function-that-takes-unsigned-types.md)
