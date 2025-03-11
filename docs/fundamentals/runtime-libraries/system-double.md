---
title: System.Double struct
description: Learn about the System.Double struct.
ms.date: 02/21/2025
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Double struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Double> value type represents a double-precision 64-bit number with values ranging from negative 1.79769313486232e308 to positive 1.79769313486232e308, as well as positive or negative zero, <xref:System.Double.PositiveInfinity>, <xref:System.Double.NegativeInfinity>, and not a number (<xref:System.Double.NaN>). It is intended to represent values that are extremely large (such as distances between planets or galaxies) or extremely small (such as the molecular mass of a substance in kilograms) and that often are imprecise (such as the distance from earth to another solar system). The <xref:System.Double> type complies with the IEC 60559:1989 (IEEE 754) standard for binary floating-point arithmetic.

## Floating-point representation and precision

The <xref:System.Double> data type stores double-precision floating-point values in a 64-bit binary format, as shown in the following table:

| Part                              | Bits  |
|-----------------------------------|-------|
| Significand or mantissa           | 0-51  |
| Exponent                          | 52-62 |
| Sign (0 = Positive, 1 = Negative) | 63    |

Just as decimal fractions are unable to precisely represent some fractional values (such as 1/3 or <xref:System.Math.PI?displayProperty=nameWithType>), binary fractions are unable to represent some fractional values. For example, 1/10, which is represented precisely by .1 as a decimal fraction, is represented by .001100110011 as a binary fraction, with the pattern "0011" repeating to infinity. In this case, the floating-point value provides an imprecise representation of the number that it represents. Performing additional mathematical operations on the original floating-point value often tends to increase its lack of precision. For example, if we compare the result of multiplying .1 by 10 and adding .1 to .1 nine times, we see that addition, because it has involved eight more operations, has produced the less precise result. Note that this disparity is apparent only if we display the two <xref:System.Double> values by using the "R" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md), which if necessary displays all 17 digits of precision supported by the <xref:System.Double> type.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/representation1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/representation1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/representation1.vb" id="Snippet3":::

Because some numbers cannot be represented exactly as fractional binary values, floating-point numbers can only approximate real numbers.

All floating-point numbers also have a limited number of significant digits, which also determines how accurately a floating-point value approximates a real number. A <xref:System.Double> value has up to 15 decimal digits of precision, although a maximum of 17 digits is maintained internally. This means that some floating-point operations may lack the precision to change a floating point value. The following example provides an illustration. It defines a very large floating-point value, and then adds the product of <xref:System.Double.Epsilon?displayProperty=nameWithType> and one quadrillion to it. The product, however, is too small to modify the original floating-point value. Its least significant digit is thousandths, whereas the most significant digit in the product is 10<sup>-309</sup>.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/representation2.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/representation2.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/representation2.vb" id="Snippet4":::

The limited precision of a floating-point number has several consequences:

- Two floating-point numbers that appear equal for a particular precision might not compare equal because their least significant digits are different. In the following example, a series of numbers are added together, and their total is compared with their expected total. Although the two values appear to be the same, a call to the `Equals` method indicates that they are not.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/precisionlist3.cs" id="Snippet6":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precisionlist3.fs" id="Snippet6":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/precisionlist3.vb" id="Snippet6":::

  If you change the format items in the <xref:System.Console.WriteLine%28System.String%2CSystem.Object%2CSystem.Object%29?displayProperty=nameWithType> statement from `{0}` and `{1}` to `{0:R}` and `{1:R}` to display all significant digits of the two <xref:System.Double> values, it is clear that the two values are unequal because of a loss of precision during the addition operations. In this case, the issue can be resolved by calling the <xref:System.Math.Round%28System.Double%2CSystem.Int32%29?displayProperty=nameWithType> method to round the <xref:System.Double> values to the desired precision before performing the comparison.

- A mathematical or comparison operation that uses a floating-point number might not yield the same result if a decimal number is used, because the binary floating-point number might not equal the decimal number. A previous example illustrated this by displaying the result of multiplying .1 by 10 and adding .1 times.

  When accuracy in numeric operations with fractional values is important, you can use the <xref:System.Decimal> rather than the <xref:System.Double> type. When accuracy in numeric operations with integral values beyond the range of the <xref:System.Int128> <xref:System.UInt128> types is important, use the <xref:System.Numerics.BigInteger> type.

- A value might not round-trip if a floating-point number is involved. A value is said to round-trip if an operation converts an original floating-point number to another form, an inverse operation transforms the converted form back to a floating-point number, and the final floating-point number is not equal to the original floating-point number. The round trip might fail because one or more least significant digits are lost or changed in a conversion. In the following example, three <xref:System.Double> values are converted to strings and saved in a file. As the output shows, however, even though the values appear to be identical, the restored values are not equal to the original values.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/precisionlist4.cs" id="Snippet7":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precisionlist4.fs" id="Snippet7":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/precisionlist4.vb" id="Snippet7":::

  In this case, the values can be successfully round-tripped by using the "G17" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md) to preserve the full precision of <xref:System.Double> values, as the following example shows.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/precisionlist5.cs" id="Snippet8":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precisionlist5.fs" id="Snippet8":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/precisionlist5.vb" id="Snippet8":::

  > [!IMPORTANT]
  > When used with a <xref:System.Double> value, the "R" format specifier in some cases fails to successfully round-trip the original value. To ensure that <xref:System.Double> values successfully round-trip, use the "G17" format specifier.

- <xref:System.Single> values have less precision than <xref:System.Double> values. A <xref:System.Single> value that is converted to a seemingly equivalent <xref:System.Double> often does not equal the <xref:System.Double> value because of differences in precision. In the following example, the result of identical division operations is assigned to a <xref:System.Double> and a <xref:System.Single> value. After the <xref:System.Single> value is cast to a <xref:System.Double>, a comparison of the two values shows that they are unequal.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/precisionlist1.cs" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precisionlist1.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/precisionlist1.vb" id="Snippet5":::

  To avoid this problem, use either the <xref:System.Double> in place of the <xref:System.Single> data type, or use the <xref:System.Math.Round%2A> method so that both values have the same precision.

In addition, the result of arithmetic and assignment operations with <xref:System.Double> values may differ slightly by platform because of the loss of precision of the <xref:System.Double> type. For example, the result of assigning a literal <xref:System.Double> value may differ in the 32-bit and 64-bit versions of .NET. The following example illustrates this difference when the literal value -4.42330604244772E-305 and a variable whose value is -4.42330604244772E-305 are assigned to a <xref:System.Double> variable. Note that the result of the <xref:System.Double.Parse%28System.String%29> method in this case does not suffer from a loss of precision.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/precision1.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precision1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/precision1.vb" id="Snippet1":::

## Test for equality

To be considered equal, two <xref:System.Double> values must represent identical values. However, because of differences in precision between values, or because of a loss of precision by one or both values, floating-point values that are expected to be identical often turn out to be unequal because of differences in their least significant digits. As a result, calls to the <xref:System.Double.Equals%2A> method to determine whether two values are equal, or calls to the <xref:System.Double.CompareTo%2A> method to determine the relationship between two <xref:System.Double> values, often yield unexpected results. This is evident in the following example, where two apparently equal <xref:System.Double> values turn out to be unequal because the first has 15 digits of precision, while the second has 17.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/comparison1.cs" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/comparison1.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/comparison1.vb" id="Snippet9":::

Calculated values that follow different code paths and that are manipulated in different ways often prove to be unequal. In the following example, one <xref:System.Double> value is squared, and then the square root is calculated to restore the original value. A second <xref:System.Double> is multiplied by 3.51 and squared before the square root of the result is divided by 3.51 to restore the original value. Although the two values appear to be identical, a call to the <xref:System.Double.Equals%28System.Double%29> method indicates that they are not equal. Using the "R" standard format string to return a result string that displays all the significant digits of each Double value shows that the second value is .0000000000001 less than the first.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/comparison2.cs" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/comparison2.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/comparison2.vb" id="Snippet10":::

In cases where a loss of precision is likely to affect the result of a comparison, you can adopt any of the following alternatives to calling the <xref:System.Double.Equals%2A> or <xref:System.Double.CompareTo%2A> method:

- Call the <xref:System.Math.Round%2A?displayProperty=nameWithType> method to ensure that both values have the same precision. The following example modifies a previous example to use this approach so that two fractional values are equivalent.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/comparison3.cs" id="Snippet11":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/comparison3.fs" id="Snippet11":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/comparison3.vb" id="Snippet11":::

  The problem of precision still applies to rounding of midpoint values. For more information, see the <xref:System.Math.Round%28System.Double%2CSystem.Int32%2CSystem.MidpointRounding%29?displayProperty=nameWithType> method.

- Test for approximate equality rather than equality. This requires that you define either an absolute amount by which the two values can differ but still be equal, or that you define a relative amount by which the smaller value can diverge from the larger value.

  > [!WARNING]
  > <xref:System.Double.Epsilon?displayProperty=nameWithType> is sometimes used as an absolute measure of the distance between two <xref:System.Double> values when testing for equality. However, <xref:System.Double.Epsilon?displayProperty=nameWithType> measures the smallest possible value that can be added to, or subtracted from, a <xref:System.Double> whose value is zero. For most positive and negative <xref:System.Double> values, the value of <xref:System.Double.Epsilon?displayProperty=nameWithType> is too small to be detected. Therefore, except for values that are zero, we do not recommend its use in tests for equality.

  The following example uses the latter approach to define an `IsApproximatelyEqual` method that tests the relative difference between two values. It also contrasts the result of calls to the `IsApproximatelyEqual` method and the <xref:System.Double.Equals%28System.Double%29> method.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/comparison4.cs" id="Snippet12":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/comparison4.fs" id="Snippet12":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/comparison4.vb" id="Snippet12":::

## Floating-point values and exceptions

Unlike operations with integral types, which throw exceptions in cases of overflow or illegal operations such as division by zero, operations with floating-point values do not throw exceptions. Instead, in exceptional situations, the result of a floating-point operation is zero, positive infinity, negative infinity, or not a number (NaN):

- If the result of a floating-point operation is too small for the destination format, the result is zero. This can occur when two very small numbers are multiplied, as the following example shows.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/exceptional1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/exceptional1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/exceptional1.vb" id="Snippet1":::

- If the magnitude of the result of a floating-point operation exceeds the range of the destination format, the result of the operation is <xref:System.Double.PositiveInfinity> or <xref:System.Double.NegativeInfinity>, as appropriate for the sign of the result. The result of an operation that overflows <xref:System.Double.MaxValue?displayProperty=nameWithType> is <xref:System.Double.PositiveInfinity>, and the result of an operation that overflows <xref:System.Double.MinValue?displayProperty=nameWithType> is <xref:System.Double.NegativeInfinity>, as the following example shows.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/exceptional2.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/exceptional2.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/exceptional2.vb" id="Snippet2":::

  <xref:System.Double.PositiveInfinity> also results from a division by zero with a positive dividend, and <xref:System.Double.NegativeInfinity> results from a division by zero with a negative dividend.

- If a floating-point operation is invalid, the result of the operation is <xref:System.Double.NaN>. For example, <xref:System.Double.NaN> results from the following operations:

  - Division by zero with a dividend of zero. Note that other cases of division by zero result in either <xref:System.Double.PositiveInfinity> or <xref:System.Double.NegativeInfinity>.

  - Any floating-point operation with an invalid input. For example, calling the <xref:System.Math.Sqrt%2A?displayProperty=nameWithType> method with a negative value returns <xref:System.Double.NaN>, as does calling the <xref:System.Math.Acos%2A?displayProperty=nameWithType> method with a value that is greater than one or less than negative one.

  - Any operation with an argument whose value is <xref:System.Double.NaN?displayProperty=nameWithType>.

## Type conversions

The <xref:System.Double> structure does not define any explicit or implicit conversion operators; instead, conversions are implemented by the compiler.

The conversion of the value of any primitive numeric type to a <xref:System.Double> is a widening conversion and therefore does not require an explicit cast operator or call to a conversion method unless a compiler explicitly requires it. For example, the C# compiler requires a casting operator for conversions from <xref:System.Decimal> to <xref:System.Double>, while the Visual Basic compiler does not. The following example converts the minimum or maximum value of other primitive numeric types to a <xref:System.Double>.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/convert1.cs" id="Snippet20":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/convert1.fs" id="Snippet20":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/convert1.vb" id="Snippet20":::

In addition, the <xref:System.Single> values <xref:System.Single.NaN?displayProperty=nameWithType>, <xref:System.Single.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Single.NegativeInfinity?displayProperty=nameWithType> convert to <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, respectively.

Note that the conversion of the value of some numeric types to a <xref:System.Double> value can involve a loss of precision. As the example illustrates, a loss of precision is possible when converting <xref:System.Decimal>, <xref:System.Int64>, and <xref:System.UInt64> values to <xref:System.Double> values.

The conversion of a <xref:System.Double> value to a value of any other primitive numeric data type is a narrowing conversion and requires a cast operator (in C#), a conversion method (in Visual Basic), or a call to a <xref:System.Convert> method. Values that are outside the range of the target data type, which are defined by the target type's `MinValue` and `MaxValue` properties, behave as shown in the following table.

|Target type|Result|
|-----------------|------------|
|Any integral type|An <xref:System.OverflowException> exception if the conversion occurs in a checked context.<br /><br />If the conversion occurs in an unchecked context (the default in C#), the conversion operation succeeds but the value overflows.|
|<xref:System.Decimal>|An <xref:System.OverflowException> exception.|
|<xref:System.Single>|<xref:System.Single.NegativeInfinity?displayProperty=nameWithType> for negative values.<br /><br /><xref:System.Single.PositiveInfinity?displayProperty=nameWithType> for positive values.|

In addition, <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Double.NegativeInfinity?displayProperty=nameWithType> throw an <xref:System.OverflowException> for conversions to integers in a checked context, but these values overflow when converted to integers in an unchecked context. For conversions to <xref:System.Decimal>, they always throw an <xref:System.OverflowException>. For conversions to <xref:System.Single>, they convert to <xref:System.Single.NaN?displayProperty=nameWithType>, <xref:System.Single.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Single.NegativeInfinity?displayProperty=nameWithType>, respectively.

A loss of precision may result from converting a <xref:System.Double> value to another numeric type. In the case of converting to any of the integral types, as the output from the example shows, the fractional component is lost when the <xref:System.Double> value is either rounded (as in Visual Basic) or truncated (as in C#). For conversions to <xref:System.Decimal> and <xref:System.Single> values, the <xref:System.Double> value may not have a precise representation in the target data type.

The following example converts a number of <xref:System.Double> values to several other numeric types. The conversions occur in a checked context in Visual Basic (the default), in C# (because of the [checked](/dotnet/csharp/language-reference/keywords/checked) keyword), and in F# (because of the [Checked](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators-checked.html) module). The output from the example shows the result for conversions in both a checked an unchecked context. You can perform conversions in an unchecked context in Visual Basic by compiling with the `/removeintchecks+` compiler switch, in C# by commenting out the `checked` statement, and in F# by commenting out the `open Checked` statement.

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/convert2.cs" id="Snippet21":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/convert2.fs" id="Snippet21":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/convert2.vb" id="Snippet21":::

For more information on the conversion of numeric types, see [Type Conversion in .NET](../../standard/base-types/type-conversion.md) and [Type Conversion Tables](../../standard/base-types/conversion-tables.md).

## Floating-point functionality

The <xref:System.Double> structure and related types provide methods to perform operations in the following areas:

- **Comparison of values**. You can call the <xref:System.Double.Equals%2A> method to determine whether two <xref:System.Double> values are equal, or the <xref:System.Double.CompareTo%2A> method to determine the relationship between two values.

  The <xref:System.Double> structure also supports a complete set of comparison operators. For example, you can test for equality or inequality, or determine whether one value is greater than or equal to another. If one of the operands is a numeric type other than a <xref:System.Double>, it is converted to a <xref:System.Double> before performing the comparison.

  > [!WARNING]
  > Because of differences in precision, two <xref:System.Double> values that you expect to be equal may turn out to be unequal, which affects the result of the comparison. See the [Test for equality](#test-for-equality) section for more information about comparing two <xref:System.Double> values.

  You can also call the <xref:System.Double.IsNaN%2A>, <xref:System.Double.IsInfinity%2A>, <xref:System.Double.IsPositiveInfinity%2A>, and <xref:System.Double.IsNegativeInfinity%2A> methods to test for these special values.

- **Mathematical operations**. Common arithmetic operations, such as addition, subtraction, multiplication, and division, are implemented by language compilers and Common Intermediate Language (CIL) instructions, rather than by <xref:System.Double> methods. If one of the operands in a mathematical operation is a numeric type other than a <xref:System.Double>, it is converted to a <xref:System.Double> before performing the operation. The result of the operation is also a <xref:System.Double> value.

  Other mathematical operations can be performed by calling `static` (`Shared` in Visual Basic) methods in the <xref:System.Math?displayProperty=nameWithType> class. It includes additional methods commonly used for arithmetic (such as <xref:System.Math.Abs%2A?displayProperty=nameWithType>, <xref:System.Math.Sign%2A?displayProperty=nameWithType>, and <xref:System.Math.Sqrt%2A?displayProperty=nameWithType>), geometry (such as <xref:System.Math.Cos%2A?displayProperty=nameWithType> and <xref:System.Math.Sin%2A?displayProperty=nameWithType>), and calculus (such as <xref:System.Math.Log%2A?displayProperty=nameWithType>).

  You can also manipulate the individual bits in a <xref:System.Double> value. The <xref:System.BitConverter.DoubleToInt64Bits%2A?displayProperty=nameWithType> method preserves a <xref:System.Double> value's bit pattern in a 64-bit integer. The <xref:System.BitConverter.GetBytes%28System.Double%29?displayProperty=nameWithType> method returns its bit pattern in a byte array.

- **Rounding**. Rounding is often used as a technique for reducing the impact of differences between values caused by problems of floating-point representation and precision. You can round a <xref:System.Double> value by calling the <xref:System.Math.Round%2A?displayProperty=nameWithType> method.

- **Formatting**. You can convert a <xref:System.Double> value to its string representation by calling the <xref:System.Double.ToString%2A> method or by using the composite formatting feature. For information about how format strings control the string representation of floating-point values, see the [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md) topics.

- **Parsing strings**. You can convert the string representation of a floating-point value to a <xref:System.Double> value by calling either the <xref:System.Double.Parse%2A> or <xref:System.Double.TryParse%2A> method. If the parse operation fails, the <xref:System.Double.Parse%2A> method throws an exception, whereas the <xref:System.Double.TryParse%2A> method returns `false`.

- **Type conversion**. The <xref:System.Double> structure provides an explicit interface implementation for the <xref:System.IConvertible> interface, which supports conversion between any two standard .NET data types. Language compilers also support the implicit conversion of values of all other standard numeric types to <xref:System.Double> values. Conversion of a value of any standard numeric type to a <xref:System.Double> is a widening conversion and does not require the user of a casting operator or conversion method,

  However, conversion of <xref:System.Int64> and <xref:System.Single> values can involve a loss of precision. The following table lists the differences in precision for each of these types:

  | Type                 | Maximum precision | Internal precision |
  |----------------------|-------------------|--------------------|
  | <xref:System.Double> | 15                | 17                 |
  | <xref:System.Int64>  | 19 decimal digits | 19 decimal digits  |
  | <xref:System.Single> | 7 decimal digits  | 9 decimal digits   |

  The problem of precision most frequently affects <xref:System.Single> values that are converted to <xref:System.Double> values. In the following example, two values produced by identical division operations are unequal because one of the values is a single-precision floating point value converted to a <xref:System.Double>.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/representation1.cs" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/representation1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/representation1.vb" id="Snippet3":::

## Examples

The following code example illustrates the use of <xref:System.Double>:

:::code language="csharp" source="./snippets/System/Double/Overview/csharp/source.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/source.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Double/Overview/vb/source.vb" id="Snippet1":::
