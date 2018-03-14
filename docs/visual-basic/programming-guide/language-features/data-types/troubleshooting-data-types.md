---
title: "Troubleshooting Data Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Char data type [Visual Basic], converting"
  - "Decimal data type [Visual Basic], conversions"
  - "data types [Visual Basic], troubleshooting"
  - "literals [Visual Basic], default types"
  - "type characters [Visual Basic], literal"
  - "Mod operator [Visual Basic], in floating-point operations"
  - "troubleshooting Visual Basic, data types"
  - "troubleshooting data types [Visual Basic]"
  - "floating-point numbers [Visual Basic], precision"
  - "Boolean data type [Visual Basic], converting"
  - "literal types [Visual Basic]"
  - "literal type characters [Visual Basic]"
  - "floating-point numbers [Visual Basic], imprecision"
  - "String data type [Visual Basic], converting"
  - "floating-point numbers [Visual Basic], comparison"
  - "floating-point numbers"
ms.assetid: 90040d67-b630-4125-a6ae-37195b079042
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
---
# Troubleshooting Data Types (Visual Basic)
This page lists some common problems that can occur when you perform operations on intrinsic data types.  
  
## Floating-Point Expressions Do Not Compare as Equal  
 When you work with floating-point numbers ([Single Data Type](../../../../visual-basic/language-reference/data-types/single-data-type.md) and [Double Data Type](../../../../visual-basic/language-reference/data-types/double-data-type.md)), remember that they are stored as binary fractions. This means they cannot hold an exact representation of any quantity that is not a binary fraction (of the form k / (2 ^ n) where k and n are integers). For example, 0.5 (= 1/2) and 0.3125 (= 5/16) can be held as precise values, whereas 0.2 (= 1/5) and 0.3 (= 3/10) can be only approximations.  
  
 Because of this imprecision, you cannot rely on exact results when you operate on floating-point values. In particular, two values that are theoretically equal might have slightly different representations.  
  
| To compare floating-point quantities | 
|---| 
|1.  Calculate the absolute value of their difference by using the <xref:System.Math.Abs%2A> method of the <xref:System.Math> class in the <xref:System> namespace.<br />2.  Determine an acceptable maximum difference, such that you can consider the two quantities to be equal for practical purposes if their difference is no larger.<br />3.  Compare the absolute value of the difference to the acceptable difference.|  
  
 The following example demonstrates both incorrect and correct comparison of two `Double` values.  
  
 [!code-vb[VbVbalrDataTypes#10](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/troubleshooting-data-types_1.vb)]  
  
 The previous example uses the <xref:System.Double.ToString%2A> method of the <xref:System.Double> structure so that it can specify better  precision than the `CStr` keyword uses. The default is 15 digits, but the "G17" format extends it to 17 digits.  
  
## Mod Operator Does Not Return Accurate Result  
 Because of the imprecision of floating-point storage, the [Mod Operator](../../../../visual-basic/language-reference/operators/mod-operator.md) can return an unexpected result when at least one of the operands is floating-point.  
  
 The [Decimal Data Type](../../../../visual-basic/language-reference/data-types/decimal-data-type.md) does not use floating-point representation. Many numbers that are inexact in `Single` and `Double` are exact in `Decimal` (for example 0.2 and 0.3). Although arithmetic is slower in `Decimal` than in floating-point, it might be worth the performance decrease to achieve better precision.  
  
|To find the integer remainder of floating-point quantities|  
|---|  
|1.  Declare variables as `Decimal`.<br />2.  Use the literal type character `D` to force literals to `Decimal`, in case their values are too large for the `Long` data type.|  
  
 The following example demonstrates the potential imprecision of floating-point operands.  
  
 [!code-vb[VbVbalrDataTypes#11](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/troubleshooting-data-types_2.vb)]  
  
 The previous example uses the <xref:System.Double.ToString%2A> method of the <xref:System.Double> structure so that it can specify better precision than the `CStr` keyword uses. The default is 15 digits, but the "G17" format extends it to 17 digits.  
  
 Because `zeroPointTwo` is `Double`, its value for 0.2 is an infinitely repeating binary fraction with a stored value of 0.20000000000000001. Dividing 2.0 by this quantity yields 9.9999999999999995 with a remainder of 0.19999999999999991.  
  
 In the expression for `decimalRemainder`, the literal type character `D` forces both operands to `Decimal`, and 0.2 has a precise representation. Therefore the `Mod` operator yields the expected remainder of 0.0.  
  
 Note that it is not sufficient to declare `decimalRemainder` as `Decimal`. You must also force the literals to `Decimal`, or they use `Double` by default and `decimalRemainder` receives the same inaccurate value as `doubleRemainder`.  
  
## Boolean Type Does Not Convert to Numeric Type Accurately  
 [Boolean Data Type](../../../../visual-basic/language-reference/data-types/boolean-data-type.md) values are not stored as numbers, and the stored values are not intended to be equivalent to numbers. For compatibility with earlier versions, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides conversion keywords ([CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md), `CBool`, `CInt`, and so on) to convert between `Boolean` and numeric types. However, other languages sometimes perform these conversions differently, as do the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] methods.  
  
 You should never write code that relies on equivalent numeric values for `True` and `False`. Whenever possible, you should restrict usage of `Boolean` variables to the logical values for which they are designed. If you must mix `Boolean` and numeric values, make sure that you understand the conversion method that you select.  
  
### Conversion in Visual Basic  
 When you use the `CType` or `CBool` conversion keywords to convert numeric data types to `Boolean`, 0 becomes `False` and all other values become `True`. When you convert `Boolean` values to numeric types by using the conversion keywords, `False` becomes 0 and `True` becomes -1.  
  
### Conversion in the Framework  
 The <xref:System.Convert.ToInt32%2A> method of the <xref:System.Convert> class in the <xref:System> namespace converts `True` to +1.  
  
 If you must convert a `Boolean` value to a numeric data type, be careful about which conversion method you use.  
  
## Character Literal Generates Compiler Error  
 In the absence of any type characters, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] assumes default data types for literals. The default type for a character literal — enclosed in quotation marks (`" "`) — is `String`.  
  
 The `String` data type does not widen to the [Char Data Type](../../../../visual-basic/language-reference/data-types/char-data-type.md). This means that if you want to assign a literal to a `Char` variable, you must either make a narrowing conversion or force the literal to the `Char` type.  

|To create a Char literal to assign to a variable or constant|
|---|  
|1.  Declare the variable or constant as `Char`.<br />2.  Enclose the character value in quotation marks (`" "`).<br />3.  Follow the closing double quotation mark with the literal type character `C` to force the literal to `Char`. This is necessary if the type checking switch ([Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)) is `On`, and it is desirable in any case.|  
  
 The following example demonstrates both unsuccessful and successful assignments of a literal to a `Char` variable.  
  
 [!code-vb[VbVbalrDataTypes#12](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/troubleshooting-data-types_3.vb)]  
  
 There is always a risk in using narrowing conversions, because they can fail at run time. For example, a conversion from `String` to `Char` can fail if the `String` value contains more than one character. Therefore, it is better programming to use the `C` type character.  
  
## String Conversion Fails at Run Time  
 The [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md) participates in very few widening conversions. `String` widens only to itself and `Object`, and only `Char` and `Char()` (a `Char` array) widen to `String`. This is because `String` variables and constants can contain values that other data types cannot contain.  
  
 When the type checking switch ([Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)) is `On`, the compiler disallows all implicit narrowing conversions. This includes those involving `String`. Your code can still use conversion keywords such as `CStr` and [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md), which direct the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] to attempt the conversion.  
  
> [!NOTE]
>  The narrowing-conversion error is suppressed for conversions from the elements in a `For Each…Next` collection to the loop control variable. For more information and examples, see the "Narrowing Conversions" section in [For Each...Next Statement](../../../../visual-basic/language-reference/statements/for-each-next-statement.md).  
  
### Narrowing Conversion Protection  
 The disadvantage of narrowing conversions is that they can fail at run time. For example, if a `String` variable contains anything other than "True" or "False," it cannot be converted to `Boolean`. If it contains punctuation characters, conversion to any numeric type fails. Unless you know that your `String` variable always holds values that the destination type can accept, you should not try a conversion.  
  
 If you must convert from `String` to another data type, the safest procedure is to enclose the attempted conversion in the [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md). This lets you deal with a run-time failure.  
  
### Character Arrays  
 A single `Char` and an array of `Char` elements both widen to `String`. However, `String` does not widen to `Char()`. To convert a `String` value to a `Char` array, you can use the <xref:System.String.ToCharArray%2A> method of the <xref:System.String?displayProperty=nameWithType> class.  
  
### Meaningless Values  
 In general, `String` values are not meaningful in other data types, and conversion is highly artificial and dangerous. Whenever possible, you should restrict usage of `String` variables to the character sequences for which they are designed. You should never write code that relies on equivalent values in other types.  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Efficient Use of Data Types](../../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
