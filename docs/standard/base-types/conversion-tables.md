---
title: Type conversion tables
description: Type conversion tables
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/22/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: d602f260-e7cf-49c8-a37f-731f40e4a538
---

# Type conversion tables

Widening conversion occurs when a value of one type is converted to another type that is of equal or greater size. A narrowing conversion occurs when a value of one type is converted to a value of another type that is of a smaller size. The tables in this topic illustrate the behaviors exhibited by both types of conversions.

## Widening Conversions

Type | Can be converted without data loss to
---- | -------------------------------------
[Byte](xref:System.Byte) | [UInt16](xref:System.UInt16), [Int16](xref:System.Int16), [UInt32](xref:System.UInt32), [Int32](xref:System.Int32), [UInt64](xref:System.UInt64), [Int64](xref:System.Int64), [Single](xref:System.Single), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[SByte](xref:System.SByte) | [Int16](xref:System.Int16), [Int32](xref:System.Int32), [Int64](xref:System.Int64), [Single](xref:System.Single), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[Int16](xref:System.Int16) | [Int32](xref:System.Int32), [Int64](xref:System.Int64), [Single](xref:System.Single), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[UInt16](xref:System.UInt16) | [UInt32](xref:System.UInt32), [Int32](xref:System.Int32), [UInt64](xref:System.UInt64), [Int64](xref:System.Int64), [Single](xref:System.Single), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[Char](xref:System.Char) | [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [Int32](xref:System.Int32), [UInt64](xref:System.UInt64), [Int64](xref:System.Int64), [Single](xref:System.Single), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[Int32](xref:System.Int32) | [Int64](xref:System.Int64), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[UInt32](xref:System.UInt32) | [Int64](xref:System.Int64), [UInt64](xref:System.UInt64), [Double](xref:System.Double), [Decimal](xref:System.Decimal)
[Int64](xref:System.Int64) | [Decimal](xref:System.Decimal)
[UInt64](xref:System.UInt64) | [Decimal](xref:System.Decimal)
[Single](xref:System.Single) | [Double](xref:System.Double)

Some widening conversions to [Single](xref:System.Single) or [Double](xref:System.Double) can cause a loss of precision. The following table describes the widening conversions that sometimes result in a loss of information.

Type | Can be converted to
---- | -------------------
[Int32](xref:System.Int32) | [Single](xref:System.Single)
[UInt32](xref:System.UInt32) | [Single](xref:System.Single)
[Int64](xref:System.Int64) | [Single](xref:System.Single), [Double](xref:System.Double)
[UInt64](xref:System.UInt64) | [Single](xref:System.Single), [Double](xref:System.Double)
[Decimal](xref:System.Decimal) | [Single](xref:System.Single), [Double](xref:System.Double)

## Narrowing Conversions

A narrowing conversion to [Single](xref:System.Single) or [Double](xref:System.Double) can cause a loss of information. If the target type cannot properly express the magnitude of the source, the resulting type is set to the constant `PositiveInfinity` or `NegativeInfinity`. `PositiveInfinity` results from dividing a positive number by zero and is also returned when the value of a [Single](xref:System.Single) or [Double](xref:System.Double) exceeds the value of the `MaxValue` field. `NegativeInfinity` results from dividing a negative number by zero and is also returned when the value of a [Single](xref:System.Single) or [Double](xref:System.Double) falls below the value of the `MinValue` field. A conversion from a [Double](xref:System.Double) to a [Single](xref:System.Single) might result in `PositiveInfinity` or `NegativeInfinity`.

A narrowing conversion can also result in a loss of information for other data types. However, an [OverflowException](xref:System.OverflowException) is thrown if the value of a type that is being converted falls outside of the range specified by the target type's `MaxValue` and `MinValue` fields, and the conversion is checked by the runtime to ensure that the value of the target type does not exceed its `MaxValue` or `MinValue`. Conversions that are performed with the [System.Convert](xref:System.Convert) class are always checked in this manner.

The following table lists conversions that throw an [OverflowException](xref:System.OverflowException) using [System.Convert](xref:System.Convert) or any checked conversion if the value of the type being converted is outside the defined range of the resulting type.

Type | Can be converted to
---- | -------------------
[Byte](xref:System.Byte) | [SByte](xref:System.SByte)
[SByte](xref:System.SByte) | [Byte](xref:System.Byte), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64)
[Int16](xref:System.Int16) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [UInt16](xref:System.UInt16)
[UInt16](xref:System.UInt16) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16)
[Int32](xref:System.Int32) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32)
[UInt32](xref:System.UInt32) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32)
[Int64](xref:System.Int64) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64)
[UInt64](xref:System.UInt64) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32), [UInt32](xref:System.UInt32), [Int64](xref:System.Int64)
[Decimal](xref:System.Decimal) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32), [UInt32](xref:System.UInt32), [Int64](xref:System.Int64), [UInt64](xref:System.UInt64)
[Single](xref:System.Single) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32), [UInt32](xref:System.UInt32), [Int64](xref:System.Int64), [UInt64](xref:System.UInt64)
[Double](xref:System.Double) | [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [UInt16](xref:System.UInt16), [Int32](xref:System.Int32), [UInt32](xref:System.UInt32), [Int64](xref:System.Int64), [UInt64](xref:System.UInt64)

## See Also

[System.Convert](xref:System.Convert)

[Type Conversion](type-conversion.md)

