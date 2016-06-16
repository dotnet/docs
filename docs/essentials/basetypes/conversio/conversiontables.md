# Type Conversion Tables

Widening conversion occurs when a value of one type is converted to another type that is of equal or greater size. A narrowing conversion occurs when a value of one type is converted to a value of another type that is of a smaller size. The tables in this topic illustrate the behaviors exhibited by both types of conversions.

## Widening Conversions

Type | Can be converted without data loss to
---- | -------------------------------------
[Byte](http://dotnet.github.io/api/System.Byte.html) | [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[SByte](http://dotnet.github.io/api/System.SByte.html) | [Int16](http://dotnet.github.io/api/System.Int16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[Int16](http://dotnet.github.io/api/System.Int16.html) | [Int32](http://dotnet.github.io/api/System.Int32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[UInt16](http://dotnet.github.io/api/System.UInt16.html) | [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[Char](http://dotnet.github.io/api/System.Char.html) | [UInt16](http://dotnet.github.io/api/System.UInt16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[Int32](http://dotnet.github.io/api/System.Int32.html) | [Int64](http://dotnet.github.io/api/System.Int64.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[UInt32](http://dotnet.github.io/api/System.UInt32.html) | [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), [Double](http://dotnet.github.io/api/System.Double.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[Int64](http://dotnet.github.io/api/System.Int64.html) | [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[UInt64](http://dotnet.github.io/api/System.UInt64.html) | [Decimal](http://dotnet.github.io/api/System.Decimal.html)
[Single](http://dotnet.github.io/api/System.Single.html) | [Double](http://dotnet.github.io/api/System.Double.html)

Some widening conversions to [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) can cause a loss of precision. The following table describes the widening conversions that sometimes result in a loss of information.

Type | Can be converted to
---- | -------------------
[Int32](http://dotnet.github.io/api/System.Int32.html) | [Single](http://dotnet.github.io/api/System.Single.html)
[UInt32](http://dotnet.github.io/api/System.UInt32.html) | [Single](http://dotnet.github.io/api/System.Single.html)
[Int64](http://dotnet.github.io/api/System.Int64.html) | [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html)
[UInt64](http://dotnet.github.io/api/System.UInt64.html) | [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html)
[Decimal](http://dotnet.github.io/api/System.Decimal.html) | [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html)

## Narrowing Conversions

A narrowing conversion to [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) can cause a loss of information. If the target type cannot properly express the magnitude of the source, the resulting type is set to the constant `PositiveInfinity` or `NegativeInfinity`. `PositiveInfinity` results from dividing a positive number by zero and is also returned when the value of a [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) exceeds the value of the `MaxValue` field. `NegativeInfinity` results from dividing a negative number by zero and is also returned when the value of a [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) falls below the value of the `MinValue` field. A conversion from a [Double](http://dotnet.github.io/api/System.Double.html) to a [Single](http://dotnet.github.io/api/System.Single.html) might result in `PositiveInfinity` or `NegativeInfinity`.

A narrowing conversion can also result in a loss of information for other data types. However, an [OverflowException](http://dotnet.github.io/api/System.OverflowException.html) is thrown if the value of a type that is being converted falls outside of the range specified by the target type's `MaxValue` and `MinValue` fields, and the conversion is checked by the runtime to ensure that the value of the target type does not exceed its `MaxValue` or `MinValue`. Conversions that are performed with the [System.Convert](http://dotnet.github.io/api/System.Convert.html) class are always checked in this manner.

The following table lists conversions that throw an [OverflowException](http://dotnet.github.io/api/System.OverflowException.html) using [System.Convert](http://dotnet.github.io/api/System.Convert.html) or any checked conversion if the value of the type being converted is outside the defined range of the resulting type.

Type | Can be converted to
---- | -------------------
[Byte](http://dotnet.github.io/api/System.Byte.html) | [SByte](http://dotnet.github.io/api/System.SByte.html)
[SByte](http://dotnet.github.io/api/System.SByte.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html)
[Int16](http://dotnet.github.io/api/System.Int16.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html)
[UInt16](http://dotnet.github.io/api/System.UInt16.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html)
[Int32](http://dotnet.github.io/api/System.Int32.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html)
[UInt32](http://dotnet.github.io/api/System.UInt32.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html)
[Int64](http://dotnet.github.io/api/System.Int64.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html)
[UInt64](http://dotnet.github.io/api/System.UInt64.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int64](http://dotnet.github.io/api/System.Int64.html)
[Decimal](http://dotnet.github.io/api/System.Decimal.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html)
[Single](http://dotnet.github.io/api/System.Single.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html)
[Double](http://dotnet.github.io/api/System.Double.html) | [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html)

## See Also

[System.Convert](http://dotnet.github.io/api/System.Convert.html)

[Type Conversion](../typeconversion.md)


