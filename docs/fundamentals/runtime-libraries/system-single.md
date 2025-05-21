---
title: System.Single struct
description: Learn about the System.Single struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Single struct

[!INCLUDE [context](includes/context.md)]

The <xref:System.Single> value type represents a single-precision 32-bit number with values ranging from negative 3.402823e38 to positive 3.402823e38, as well as positive or negative zero, <xref:System.Single.PositiveInfinity>, <xref:System.Single.NegativeInfinity>, and not a number (<xref:System.Single.NaN>). It is intended to represent values that are extremely large (such as distances between planets or galaxies) or extremely small (such as the molecular mass of a substance in kilograms) and that often are imprecise (such as the distance from earth to another solar system). The <xref:System.Single> type complies with the IEC 60559:1989 (IEEE 754) standard for binary floating-point arithmetic.

<xref:System.Single?displayProperty=nameWithType> provides methods to compare instances of this type, to convert the value of an instance to its string representation, and to convert the string representation of a number to an instance of this type. For information about how format specification codes control the string representation of value types, see [Formatting Types](../../standard/base-types/formatting-types.md), [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md), and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).

## Floating-point representation and precision

The <xref:System.Single> data type stores single-precision floating-point values in a 32-bit binary format, as shown in the following table:

| Part                              | Bits  |
|-----------------------------------|-------|
| Significand or mantissa           | 0-22  |
| Exponent                          | 23-30 |
| Sign (0 = positive, 1 = negative) | 31    |

Just as decimal fractions are unable to precisely represent some fractional values (such as 1/3 or <xref:System.Math.PI?displayProperty=nameWithType>), binary fractions are unable to represent some fractional values. For example, 2/10, which is represented precisely by .2 as a decimal fraction, is represented by .0011111001001100 as a binary fraction, with the pattern "1100" repeating to infinity. In this case, the floating-point value provides an imprecise representation of the number that it represents. Performing additional mathematical operations on the original floating-point value often increases its lack of precision. For example, if you compare the results of multiplying .3 by 10 and adding .3 to .3 nine times, you will see that addition produces the less precise result, because it involves eight more operations than multiplication. Note that this disparity is apparent only if you display the two <xref:System.Single> values by using the "R" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md), which, if necessary, displays all 9 digits of precision supported by the <xref:System.Single> type.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/representation1.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/representation1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/representation1.vb" id="Snippet3":::

Because some numbers cannot be represented exactly as fractional binary values, floating-point numbers can only approximate real numbers.

All floating-point numbers have a limited number of significant digits, which also determines how accurately a floating-point value approximates a real number. A <xref:System.Single> value has up to 7 decimal digits of precision, although a maximum of 9 digits is maintained internally. This means that some floating-point operations may lack the precision to change a floating-point value. The following example defines a large single-precision floating-point value, and then adds the product of <xref:System.Single.Epsilon?displayProperty=nameWithType> and one quadrillion to it. However, the product is too small to modify the original floating-point value. Its least significant digit is thousandths, whereas the most significant digit in the product is 10<sup>-30</sup>.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/representation2.cs" interactive="try-dotnet" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/representation2.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/representation2.vb" id="Snippet4":::

The limited precision of a floating-point number has several consequences:

- Two floating-point numbers that appear equal for a particular precision might not compare equal because their least significant digits are different. In the following example, a series of numbers are added together, and their total is compared with their expected total. Although the two values appear to be the same, a call to the `Equals` method indicates that they are not.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/precisionlist3.cs" interactive="try-dotnet" id="Snippet6":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/precisionlist3.fs" id="Snippet6":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/precisionlist3.vb" id="Snippet6":::

  If you change the format items in the <xref:System.Console.WriteLine%28System.String%2CSystem.Object%2CSystem.Object%29?displayProperty=nameWithType> statement from `{0}` and `{1}` to `{0:R}` and `{1:R}` to display all significant digits of the two <xref:System.Single> values, it is clear that the two values are unequal because of a loss of precision during the addition operations. In this case, the issue can be resolved by calling the <xref:System.Math.Round%28System.Double%2CSystem.Int32%29?displayProperty=nameWithType> method to round the <xref:System.Single> values to the desired precision before performing the comparison.

- A mathematical or comparison operation that uses a floating-point number might not yield the same result if a decimal number is used, because the binary floating-point number might not equal the decimal number. A previous example illustrated this by displaying the result of multiplying .3 by 10 and adding .3 to .3 nine times.

  When accuracy in numeric operations with fractional values is important, use the <xref:System.Decimal> type instead of the <xref:System.Single> type. When accuracy in numeric operations with integral values beyond the range of the <xref:System.Int64> or <xref:System.UInt64> types is important, use the <xref:System.Numerics.BigInteger> type.

- A value might not *round-trip* if a floating-point number is involved. A value is said to round-trip if an operation converts an original floating-point number to another form, an inverse operation transforms the converted form back to a floating-point number, and the final floating-point number is equal to the original floating-point number. The round trip might fail because one or more least significant digits are lost or changed in a conversion.

  In the following example, three <xref:System.Single> values are converted to strings and saved in a file. If you run this example on .NET Framework, even though the values appear to be identical, the restored values are not equal to the original values. (This has since been addressed in .NET, where the values round-trip correctly.)

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/precisionlist4a.cs" id="Snippet17":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/precisionlist4a.fs" id="Snippet17":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/PrecisionList4a.vb" id="Snippet17":::

  If you're targeting .NET Framework, the values can be successfully round-tripped by using the "G9" [standard numeric format string](../../standard/base-types/standard-numeric-format-strings.md) to preserve the full precision of <xref:System.Single> values.

- <xref:System.Single> values have less precision than <xref:System.Double> values. A <xref:System.Single> value that is converted to a seemingly equivalent <xref:System.Double> often does not equal the <xref:System.Double> value because of differences in precision. In the following example, the result of identical division operations is assigned to a <xref:System.Double> value and a <xref:System.Single> value. After the <xref:System.Single> value is cast to a <xref:System.Double>, a comparison of the two values shows that they are unequal.

  :::code language="csharp" source="./snippets/System/Double/Overview/csharp/precisionlist1.cs" interactive="try-dotnet" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Double/Overview/fsharp/precisionlist1.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Double/Overview/vb/precisionlist1.vb" id="Snippet5":::

  To avoid this problem, either use the <xref:System.Double> data type in place of the <xref:System.Single> data type, or use the <xref:System.Math.Round%2A> method so that both values have the same precision.

## Test for equality

To be considered equal, two <xref:System.Single> values must represent identical values. However, because of differences in precision between values, or because of a loss of precision by one or both values, floating-point values that are expected to be identical often turn out to be unequal due to differences in their least significant digits. As a result, calls to the <xref:System.Single.Equals%2A> method to determine whether two values are equal, or calls to the <xref:System.Single.CompareTo%2A> method to determine the relationship between two <xref:System.Single> values, often yield unexpected results. This is evident in the following example, where two apparently equal <xref:System.Single> values turn out to be unequal, because the first value has 7 digits of precision, whereas the second value has 9.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/comparison1.cs" interactive="try-dotnet" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/comparison1.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/comparison1.vb" id="Snippet9":::

Calculated values that follow different code paths and that are manipulated in different ways often prove to be unequal. In the following example, one <xref:System.Single> value is squared, and then the square root is calculated to restore the original value. A second <xref:System.Single> is multiplied by 3.51 and squared before the square root of the result is divided by 3.51 to restore the original value. Although the two values appear to be identical, a call to the <xref:System.Single.Equals%28System.Single%29> method indicates that they are not equal. Using the "G9" standard format string to return a result string that displays all the significant digits of each <xref:System.Single> value shows that the second value is .0000000000001 less than the first.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/comparison2.cs" interactive="try-dotnet" id="Snippet10":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/comparison2.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/comparison2.vb" id="Snippet10":::

In cases where a loss of precision is likely to affect the result of a comparison, you can use the following techniques instead of calling the <xref:System.Single.Equals%2A> or <xref:System.Single.CompareTo%2A> method:

- Call the <xref:System.Math.Round%2A?displayProperty=nameWithType> method to ensure that both values have the same precision. The following example modifies a previous example to use this approach so that two fractional values are equivalent.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/comparison3.cs" interactive="try-dotnet" id="Snippet11":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/comparison3.fs" id="Snippet11":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/comparison3.vb" id="Snippet11":::

  The problem of precision still applies to rounding of midpoint values. For more information, see the <xref:System.Math.Round%28System.Double%2CSystem.Int32%2CSystem.MidpointRounding%29?displayProperty=nameWithType> method.

- Test for approximate equality instead of equality. This technique requires that you define either an absolute amount by which the two values can differ but still be equal, or that you define a relative amount by which the smaller value can diverge from the larger value.

  > [!WARNING]
  > <xref:System.Single.Epsilon?displayProperty=nameWithType> is sometimes used as an absolute measure of the distance between two <xref:System.Single> values when testing for equality. However, <xref:System.Single.Epsilon?displayProperty=nameWithType> measures the smallest possible value that can be added to, or subtracted from, a <xref:System.Single> whose value is zero. For most positive and negative <xref:System.Single> values, the value of <xref:System.Single.Epsilon?displayProperty=nameWithType> is too small to be detected. Therefore, except for values that are zero, we do not recommend its use in tests for equality.

  The following example uses the latter approach to define an `IsApproximatelyEqual` method that tests the relative difference between two values. It also contrasts the result of calls to the `IsApproximatelyEqual` method and the <xref:System.Single.Equals%28System.Single%29> method.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/comparison4.cs" interactive="try-dotnet" id="Snippet12":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/comparison4.fs" id="Snippet12":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/comparison4.vb" id="Snippet12":::

## Floating-point values and exceptions

Operations with floating-point values do not throw exceptions, unlike operations with integral types, which throw exceptions in cases of illegal operations such as division by zero or overflow. Instead, in these situations, the result of a floating-point operation is zero, positive infinity, negative infinity, or not a number (NaN):

- If the result of a floating-point operation is too small for the destination format, the result is zero. This can occur when two very small floating-point numbers are multiplied, as the following example shows.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/exceptional1.cs" interactive="try-dotnet" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/exceptional1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/exceptional1.vb" id="Snippet1":::

- If the magnitude of the result of a floating-point operation exceeds the range of the destination format, the result of the operation is <xref:System.Single.PositiveInfinity> or <xref:System.Single.NegativeInfinity>, as appropriate for the sign of the result. The result of an operation that overflows <xref:System.Single.MaxValue?displayProperty=nameWithType> is <xref:System.Single.PositiveInfinity>, and the result of an operation that overflows <xref:System.Single.MinValue?displayProperty=nameWithType> is <xref:System.Single.NegativeInfinity>, as the following example shows.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/exceptional2.cs" interactive="try-dotnet" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/exceptional2.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/exceptional2.vb" id="Snippet2":::

     <xref:System.Single.PositiveInfinity> also results from a division by zero with a positive dividend, and <xref:System.Single.NegativeInfinity> results from a division by zero with a negative dividend.

- If a floating-point operation is invalid, the result of the operation is <xref:System.Single.NaN>. For example, <xref:System.Single.NaN> results from the following operations:

  - Division by zero with a dividend of zero. Note that other cases of division by zero result in either <xref:System.Single.PositiveInfinity> or <xref:System.Single.NegativeInfinity>.
  - Any floating-point operation with invalid input. For example, attempting to find the square root of a negative value returns <xref:System.Single.NaN>.
  - Any operation with an argument whose value is <xref:System.Single.NaN?displayProperty=nameWithType>.

## Type conversions

The <xref:System.Single> structure does not define any explicit or implicit conversion operators; instead, conversions are implemented by the compiler.

The following table lists the possible conversions of a value of the other primitive numeric types to a <xref:System.Single> value, It also indicates whether the conversion is widening or narrowing and whether the resulting <xref:System.Single> may have less precision than the original value.

|Conversion from|Widening/narrowing|Possible loss of precision|
|---------------------|-------------------------|--------------------------------|
|<xref:System.Byte>|Widening|No|
|<xref:System.Decimal>|Widening<br /><br />Note that C# requires a cast operator.|Yes. <xref:System.Decimal> supports 29 decimal digits of precision; <xref:System.Single> supports 9.|
|<xref:System.Double>|Narrowing; out-of-range values are converted to <xref:System.Double.NegativeInfinity?displayProperty=nameWithType> or <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.|Yes. <xref:System.Double> supports 17 decimal digits of precision; <xref:System.Single> supports 9.|
|<xref:System.Int16>|Widening|No|
|<xref:System.Int32>|Widening|Yes. <xref:System.Int32> supports 10 decimal digits of precision; <xref:System.Single> supports 9.|
|<xref:System.Int64>|Widening|Yes. <xref:System.Int64> supports 19 decimal digits of precision; <xref:System.Single> supports 9.|
|<xref:System.SByte>|Widening|No|
|<xref:System.UInt16>|Widening|No|
|<xref:System.UInt32>|Widening|Yes. <xref:System.UInt32> supports 10 decimal digits of precision; <xref:System.Single> supports 9.|
|<xref:System.UInt64>|Widening|Yes. <xref:System.Int64> supports 20 decimal digits of precision; <xref:System.Single> supports 9.|

The following example converts the minimum or maximum value of other primitive numeric types to a <xref:System.Single> value.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/convert1.cs" id="Snippet20":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/convert1.fs" id="Snippet20":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/convert1.vb" id="Snippet20":::

In addition, the <xref:System.Double> values <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Double.NegativeInfinity?displayProperty=nameWithType> convert to <xref:System.Single.NaN?displayProperty=nameWithType>, <xref:System.Single.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Single.NegativeInfinity?displayProperty=nameWithType>, respectively.

Note that the conversion of the value of some numeric types to a <xref:System.Single> value can involve a loss of precision. As the example illustrates, a loss of precision is possible when converting <xref:System.Decimal>, <xref:System.Double>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.UInt32>, and <xref:System.UInt64> values to <xref:System.Single> values.

The conversion of a <xref:System.Single> value to a <xref:System.Double> is a widening conversion. The conversion may result in a loss of precision if the <xref:System.Double> type does not have a precise representation for the <xref:System.Single> value.

The conversion of a <xref:System.Single> value to a value of any primitive numeric data type other than a <xref:System.Double> is a narrowing conversion and requires a cast operator (in C#) or a conversion method (in Visual Basic). Values that are outside the range of the target data type, which are defined by the target type's `MinValue` and `MaxValue` properties, behave as shown in the following table.

|Target type|Result|
|-----------------|------------|
|Any integral type|An <xref:System.OverflowException> exception if the conversion occurs in a checked context.<br /><br />If the conversion occurs in an unchecked context (the default in C#), the conversion operation succeeds but the value overflows.|
|<xref:System.Decimal>|An <xref:System.OverflowException> exception,|

In addition, <xref:System.Single.NaN?displayProperty=nameWithType>, <xref:System.Single.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Single.NegativeInfinity?displayProperty=nameWithType> throw an <xref:System.OverflowException> for conversions to integers in a checked context, but these values overflow when converted to integers in an unchecked context. For conversions to <xref:System.Decimal>, they always throw an <xref:System.OverflowException>. For conversions to <xref:System.Double>, they convert to <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, and <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, respectively.

Note that a loss of precision may result from converting a <xref:System.Single> value to another numeric type. In the case of converting non-integral <xref:System.Single> values, as the output from the example shows, the fractional component is lost when the <xref:System.Single> value is either rounded (as in Visual Basic) or truncated (as in C# and F#). For conversions to <xref:System.Decimal> values, the <xref:System.Single> value may not have a precise representation in the target data type.

The following example converts a number of <xref:System.Single> values to several other numeric types. The conversions occur in a checked context in Visual Basic (the default), in C# (because of the [checked](/dotnet/csharp/language-reference/keywords/checked) keyword), and in F# (because of the `open Checked` statement). The output from the example shows the result for conversions in both a checked an unchecked context. You can perform conversions in an unchecked context in Visual Basic by compiling with the `/removeintchecks+` compiler switch, in C# by commenting out the `checked` statement, and in F# by commenting out the `open Checked` statement.

:::code language="csharp" source="./snippets/System/Single/Overview/csharp/convert2.cs" id="Snippet21":::
:::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/convert2.fs" id="Snippet21":::
:::code language="vb" source="./snippets/System/Single/Overview/vb/convert2.vb" id="Snippet21":::

For more information on the conversion of numeric types, see [Type Conversion in .NET](../../standard/base-types/type-conversion.md) and [Type Conversion Tables](../../standard/base-types/conversion-tables.md).

## Floating-point functionality

The <xref:System.Single> structure and related types provide methods to perform the following categories of operations:

- **Comparison of values**. You can call the <xref:System.Single.Equals%2A> method to determine whether two <xref:System.Single> values are equal, or the <xref:System.Single.CompareTo%2A> method to determine the relationship between two values.

  The <xref:System.Single> structure also supports a complete set of comparison operators. For example, you can test for equality or inequality, or determine whether one value is greater than or equal to another value. If one of the operands is a <xref:System.Double>, the <xref:System.Single> value is converted to a <xref:System.Double> before performing the comparison. If one of the operands is an integral type, it is converted to a <xref:System.Single> before performing the comparison. Although these are widening conversions, they may involve a loss of precision.

  > [!WARNING]
  > Because of differences in precision, two <xref:System.Single> values that you expect to be equal may turn out to be unequal, which affects the result of the comparison. See the [Test for equality](#test-for-equality) section for more information about comparing two <xref:System.Single> values.

  You can also call the <xref:System.Single.IsNaN%2A>, <xref:System.Single.IsInfinity%2A>, <xref:System.Single.IsPositiveInfinity%2A>, and <xref:System.Single.IsNegativeInfinity%2A> methods to test for these special values.

- **Mathematical operations**. Common arithmetic operations such as addition, subtraction, multiplication, and division are implemented by language compilers and Common Intermediate Language (CIL) instructions rather than by <xref:System.Single> methods. If the other operand in a mathematical operation is a <xref:System.Double>, the <xref:System.Single> is converted to a <xref:System.Double> before performing the operation, and the result of the operation is also a <xref:System.Double> value. If the other operand is an integral type, it is converted to a <xref:System.Single> before performing the operation, and the result of the operation is also a <xref:System.Single> value.

  You can perform other mathematical operations by calling `static` (`Shared` in Visual Basic) methods in the <xref:System.Math?displayProperty=nameWithType> class. These include additional methods commonly used for arithmetic (such as <xref:System.Math.Abs%2A?displayProperty=nameWithType>, <xref:System.Math.Sign%2A?displayProperty=nameWithType>, and <xref:System.Math.Sqrt%2A?displayProperty=nameWithType>), geometry (such as <xref:System.Math.Cos%2A?displayProperty=nameWithType> and <xref:System.Math.Sin%2A?displayProperty=nameWithType>), and calculus (such as <xref:System.Math.Log%2A?displayProperty=nameWithType>). In all cases, the <xref:System.Single> value is converted to a <xref:System.Double>.

  You can also manipulate the individual bits in a <xref:System.Single> value. The <xref:System.BitConverter.GetBytes%28System.Single%29?displayProperty=nameWithType> method returns its bit pattern in a byte array. By passing that byte array to the <xref:System.BitConverter.ToInt32%2A?displayProperty=nameWithType> method, you can also preserve the <xref:System.Single> value's bit pattern in a 32-bit integer.

- **Rounding**. Rounding is often used as a technique for reducing the impact of differences between values caused by problems of floating-point representation and precision. You can round a <xref:System.Single> value by calling the <xref:System.Math.Round%2A?displayProperty=nameWithType> method. However, note that the <xref:System.Single> value is converted to a <xref:System.Double> before the method is called, and the conversion can involve a loss of precision.

- **Formatting**. You can convert a <xref:System.Single> value to its string representation by calling the <xref:System.Single.ToString%2A> method or by using the [composite formatting](../../standard/base-types/composite-formatting.md) feature. For information about how format strings control the string representation of floating-point values, see [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).

- **Parsing strings**. You can convert the string representation of a floating-point value to a <xref:System.Single> value by calling the <xref:System.Single.Parse%2A> or <xref:System.Single.TryParse%2A> method. If the parse operation fails, the <xref:System.Single.Parse%2A> method throws an exception, whereas the <xref:System.Single.TryParse%2A> method returns `false`.

- **Type conversion**. The <xref:System.Single> structure provides an explicit interface implementation for the <xref:System.IConvertible> interface, which supports conversion between any two standard .NET data types. Language compilers also support the implicit conversion of values for all other standard numeric types except for the conversion of <xref:System.Double> to <xref:System.Single> values. Conversion of a value of any standard numeric type other than a <xref:System.Double> to a <xref:System.Single> is a widening conversion and does not require the use of a casting operator or conversion method.

  However, conversion of 32-bit and 64-bit integer values can involve a loss of precision. The following table lists the differences in precision for 32-bit, 64-bit, and <xref:System.Double> types:

  |Type|Maximum precision (in decimal digits)|Internal precision (in decimal digits)|
  |----------|---------------------------------------------|----------------------------------------------|
  |<xref:System.Double>|15|17|
  |<xref:System.Int32> and <xref:System.UInt32>|10|10|
  |<xref:System.Int64> and <xref:System.UInt64>|19|19|
  |<xref:System.Single>|7|9|

  The problem of precision most frequently affects <xref:System.Single> values that are converted to <xref:System.Double> values. In the following example, two values produced by identical division operations are unequal, because one of the values is a single-precision floating point value that is converted to a <xref:System.Double>.

  :::code language="csharp" source="./snippets/System/Single/Overview/csharp/precisionlist1.cs" interactive="try-dotnet" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Single/Overview/fsharp/precisionlist1.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Single/Overview/vb/precisionlist1.vb" id="Snippet5":::
