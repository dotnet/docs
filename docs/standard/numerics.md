---
title: Numerics in .NET Core
description: Numerics in .NET Core
keywords: .NET, .NET Core
author: rpetrusha
ms.author: ronpet
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6b8696be-55f5-4b66-98f3-69ff827c2c49
---

# Numerics in .NET Core

.NET Core supports the standard numeric integral and floating-point primitives, as well as [System.Numerics.BigInteger](https://docs.microsoft.com/dotnet/core/api/System.Numerics.BigInteger), an integral type with no theoretical upper or lower bound, [System.Numerics.Complex](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Complex), a type that represents complex numbers, and a set of Single Instruction Multiple Data ([SIMD](https://en.wikipedia.org/wiki/SIMD))-enabled vector types in the [System.Numerics](https://docs.microsoft.com/dotnet/core/api/System.Numerics) namespace. 

## Integral types

.NET Core supports both signed and unsigned integers ranging from one byte to eight bytes in length. The following table lists the integral types and their size, indicates whether they are signed or unsigned, and documents their range. All integers are value types. 

Type | Signed/Unsigned | Size (bytes) | Minimum Value | Maximum Value
---- | --------------- | ------------ | ------------- | -------------
[System.Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) | Unsigned | 1 | 0 | 255
[System.Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16) | Signed | 2 | -32,768 | 32,767
[System.Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) | Signed | 4 | -2,147,483,648 | 2,147,483,647
[System.Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64) | Signed | 8 | -9,223,372,036,854,775,808 | 9,223,372,036,854,775,807
[System.SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte) | Signed | 1 | -128 | 127
[System.UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16) | Unsigned | 2 | 0 | 65,535
[System.UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) | Unsigned | 4 | 0 | 4,294,967,295
[System.UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) | Unsigned | 8 | 0 | 18,446,744,073,709,551,615

Each integral type supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators. Each integer also includes methods to perform equality comparisons and relative comparisons, to convert the string representation of a number to that integer, and to convert an integer to its string representation. Some additional mathematical operations beyond those handled by the standard operators, such as rounding and identifying the smaller or larger value of two integers, are available from the [System.Math](https://docs.microsoft.com/dotnet/core/api/System.Math) class. You can also work with the individual bits in an integer value by using the [System.BitConverter](https://docs.microsoft.com/dotnet/core/api/System.BitConverter) class. 
     
Note that the unsigned integral types are not CLS-compliant. For more information, see [.NET Common Type System & Common Language Specification](common-type-system.md).

## Floating-point types

.NET Core includes three primitive floating point types, which are listed in the following table. 

Type | Size (bytes) | Minimum Value | Maximum Value
---- | ------------ | ------------- | -------------
[System.Double](https://docs.microsoft.com/dotnet/core/api/System.Double) | 8 | -1.79769313486232e308 | 1.79769313486232e308
[System.Single](https://docs.microsoft.com/dotnet/core/api/System.Single) | 4 | -3.402823e38 | 3.402823e38
[System.Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal) | 16 | -79,228,162,514,264,337,593,543,950,335 | 79,228,162,514,264,337,593,543,950,335
   
Each floating-point type supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators. Each also includes methods to perform equality comparisons and relative comparisons, to convert the string representation of a floating-point number, and to convert a floating-point number to its string representation. Some additional mathematical, algebraic, and trigonometric operations are available from the `Math` class. You can also work with the individual bits in `Double` and `Single` values by using the `BitConverter` class. The `Decimal` structure has its own methods, `Decimal.GetBits` and `Decimal.Decimal(Int32())`, for working with a decimal value's individual bits, as well as its own set of methods for performing some additional mathematical operations. 

The `Double` and `Single` types are intended to be used for values that by their nature are imprecise (such as the distance between two stars in the solar system) and for applications in which a high degree of precision and small rounding error is not required. You should use the `Decimal` type for cases in which greater precision is required and rounding error is undesirable.

## BigInteger

[System.Numerics.BigInteger](https://docs.microsoft.com/dotnet/core/api/System.Numerics.BigInteger) is an immutable type that represents an arbitrarily large integer whose value in theory has no upper or lower bounds. The methods of the `BigInteger` type closely parallel those of the other integral types.  

## Complex

The [System.Numerics.Complex](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Complex) type represents a complex number, that is, a number with a real number part and an imaginary number part. It supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators, as well as mathematical, algebraic, and trigonometric methods. 

## SIMD-enabled vector types

The `System.Numerics` namespace includes a set of SIMD-enabled vector types for .NET Core. SIMD allows some operations to be parallelized at the hardware level, which results in huge performance improvements in mathematical, scientific, and graphics apps that perform computations over vectors. 

The SIMD-enabled vector types in .NET Core include the following: 

* [System.Numerics.Vector2](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Vector2), [System.Numerics.Vector3](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Vector3), and [System.Numerics.Vector4](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Vector4) types, which are 2-, 3-, and 4-dimensional vectors of type `Single`.

* The [Vector&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Vector-1) structure that allows you to create a vector of any primitive numeric type. The primitive numeric types include all numeric types in the System namespace except for Decimal.

* Two matrix types, [System.Numerics.Matrix3x2](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Matrix3x2), which represents a 3x2 matrix; and [System.Numerics.Matrix4x4](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Matrix4x4), which represents a 4x4 matrix. 

* The [System.Numerics.Plane](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Plane) type, which represents a three-dimensional plane, and the [System.Numerics.Quaternion](https://docs.microsoft.com/dotnet/core/api/System.Numerics.Quaternion) type, which represents a vector that is used to encode three-dimensional physical rotations.
