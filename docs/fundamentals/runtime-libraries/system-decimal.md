---
title: System.Decimal struct
description: Learn about the System.Decimal struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Decimal struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Decimal> value type represents decimal numbers ranging from positive 79,228,162,514,264,337,593,543,950,335 to negative 79,228,162,514,264,337,593,543,950,335. The default value of a `Decimal` is 0. The <xref:System.Decimal> value type is appropriate for financial calculations that require large numbers of significant integral and fractional digits and no round-off errors. The <xref:System.Decimal> type does not eliminate the need for rounding. Rather, it minimizes errors due to rounding. For example, the following code produces a result of 0.9999999999999999999999999999 instead of 1.

:::code language="csharp" source="./snippets/System/Decimal/Overview/csharp/DecimalDivision_46630_1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Decimal/Overview/fsharp/DecimalDivision_46630_1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Decimal/Overview/vb/DecimalDivision_46630_1.vb" id="Snippet1":::

When the result of the division and multiplication is passed to the <xref:System.Math.Round%2A> method, the result suffers no loss of precision, as the following code shows.

:::code language="csharp" source="./snippets/System/Decimal/Overview/csharp/DecimalDivision_46630_1.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Decimal/Overview/fsharp/DecimalDivision_46630_1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Decimal/Overview/vb/DecimalDivision_46630_1.vb" id="Snippet2":::

A decimal number is a floating-point value that consists of a sign, a numeric value where each digit in the value ranges from 0 to 9, and a scaling factor that indicates the position of a floating decimal point that separates the integral and fractional parts of the numeric value.

The binary representation of a `Decimal` value is 128-bits consisting of a 96-bit integer number, and a 32-bit set of flags representing things such as the sign and scaling factor used to specify what portion of it is a decimal fraction. Therefore, the binary representation of a <xref:System.Decimal> value the form, ((-2<sup>96</sup> to 2<sup>96</sup>) / 10<sup>(0 to 28)</sup>), where -(2<sup>96</sup>-1) is equal to <xref:System.Decimal.MinValue>, and 2<sup>96</sup>-1 is equal to <xref:System.Decimal.MaxValue>. For more information about the binary representation of <xref:System.Decimal> values and an example, see the <xref:System.Decimal.%23ctor%28System.Int32%5B%5D%29> constructor and the <xref:System.Decimal.GetBits%2A> method.

The scaling factor also preserves any trailing zeros in a <xref:System.Decimal> number. Trailing zeros do not affect the value of a <xref:System.Decimal> number in arithmetic or comparison operations. However, trailing zeros might be revealed by the <xref:System.Decimal.ToString%2A> method if an appropriate format string is applied.

## Conversion considerations

This type provides methods that convert <xref:System.Decimal> values to and from <xref:System.SByte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.Byte>, <xref:System.UInt16>, <xref:System.UInt32>, and <xref:System.UInt64> values. Conversions from these integral types to <xref:System.Decimal> are widening conversions that never lose information or throw exceptions.

Conversions from <xref:System.Decimal> to any of the integral types are narrowing conversions that round the <xref:System.Decimal> value to the nearest integer value toward zero. Some languages, such as C#, also support the conversion of <xref:System.Decimal> values to <xref:System.Char> values. If the result of these conversions cannot be represented in the destination type, an <xref:System.OverflowException> exception is thrown.

The <xref:System.Decimal> type also provides methods that convert <xref:System.Decimal> values to and from <xref:System.Single> and <xref:System.Double> values. Conversions from <xref:System.Decimal> to <xref:System.Single> or <xref:System.Double> are narrowing conversions that might lose precision but not information about the magnitude of the converted value. The conversion does not throw an exception.

Conversions from <xref:System.Single> or <xref:System.Double> to <xref:System.Decimal> throw an <xref:System.OverflowException> exception if the result of the conversion cannot be represented as a <xref:System.Decimal>.

## Perform operations on Decimal values

The <xref:System.Decimal> type supports standard mathematical operations such as addition, subtraction, division, multiplication, and unary negation. You can also work directly with the binary representation of a <xref:System.Decimal> value by calling the <xref:System.Decimal.GetBits%2A> method.

To compare two <xref:System.Decimal> values, you can use the standard numeric comparison operators, or you can call the <xref:System.Decimal.CompareTo%2A> or <xref:System.Decimal.Equals%2A> method.

You can also call the members of the <xref:System.Math> class to perform a wide range of numeric operations, including getting the absolute value of a number, determining the maximum or minimum value of two <xref:System.Decimal> values, getting the sign of a number, and rounding a number.

## Examples

The following code example demonstrates the use of <xref:System.Decimal>.

:::code language="csharp" source="./snippets/System/Decimal/Overview/csharp/source.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Decimal/Overview/fsharp/source.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Decimal/Overview/vb/source.vb" id="Snippet1":::
