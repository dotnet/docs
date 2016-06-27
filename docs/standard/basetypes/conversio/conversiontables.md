---
title: Type Conversion Tables
description: Type Conversion Tables
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 741987bb-af39-4895-b2b0-0d94dc240abd
---

# Type Conversion Tables

Widening conversion occurs when a value of one type is converted to another type that is of equal or greater size. A narrowing conversion occurs when a value of one type is converted to a value of another type that is of a smaller size. The tables in this topic illustrate the behaviors exhibited by both types of conversions.

## Widening Conversions

Type | Can be converted without data loss to
---- | -------------------------------------
[Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) | [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte) | [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16) | [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16) | [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[Char](https://docs.microsoft.com/dotnet/core/api/System.Char) | [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) | [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) | [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64) | [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) | [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal)
[Single](https://docs.microsoft.com/dotnet/core/api/System.Single) | [Double](https://docs.microsoft.com/dotnet/core/api/System.Double)

Some widening conversions to [Single](https://docs.microsoft.com/dotnet/core/api/System.Single) or [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) can cause a loss of precision. The following table describes the widening conversions that sometimes result in a loss of information.

Type | Can be converted to
---- | -------------------
[Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) | [Single](https://docs.microsoft.com/dotnet/core/api/System.Single)
[UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) | [Single](https://docs.microsoft.com/dotnet/core/api/System.Single)
[Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64) | [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double)
[UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) | [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double)
[Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal) | [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double)

## Narrowing Conversions

A narrowing conversion to [Single](https://docs.microsoft.com/dotnet/core/api/System.Single) or [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) can cause a loss of information. If the target type cannot properly express the magnitude of the source, the resulting type is set to the constant `PositiveInfinity` or `NegativeInfinity`. `PositiveInfinity` results from dividing a positive number by zero and is also returned when the value of a [Single](https://docs.microsoft.com/dotnet/core/api/System.Single) or [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) exceeds the value of the `MaxValue` field. `NegativeInfinity` results from dividing a negative number by zero and is also returned when the value of a [Single](https://docs.microsoft.com/dotnet/core/api/System.Single) or [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) falls below the value of the `MinValue` field. A conversion from a [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) to a [Single](https://docs.microsoft.com/dotnet/core/api/System.Single) might result in `PositiveInfinity` or `NegativeInfinity`.

A narrowing conversion can also result in a loss of information for other data types. However, an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException) is thrown if the value of a type that is being converted falls outside of the range specified by the target type's `MaxValue` and `MinValue` fields, and the conversion is checked by the runtime to ensure that the value of the target type does not exceed its `MaxValue` or `MinValue`. Conversions that are performed with the [System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class are always checked in this manner.

The following table lists conversions that throw an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException) using [System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) or any checked conversion if the value of the type being converted is outside the defined range of the resulting type.

Type | Can be converted to
---- | -------------------
[Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) | [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte)
[SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)
[Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16)
[UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16)
[Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32)
[UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32)
[Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)
[UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64)
[Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)
[Single](https://docs.microsoft.com/dotnet/core/api/System.Single) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)
[Double](https://docs.microsoft.com/dotnet/core/api/System.Double) | [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)

## See Also

[System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert)


