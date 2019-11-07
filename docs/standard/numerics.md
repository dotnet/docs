---
title: "Numerics in .NET"
ms.date: "10/18/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "SIMD"
  - "System.Numerics.Vectors"
  - "vectors"
  - "scientific computing"
  - "Complex"
  - "numerics"
  - "BigInteger"
ms.assetid: dfebc18e-acde-4510-9fa7-9a0f4aa3bd11
---
# Numerics in .NET

.NET provides a range of numeric integer and floating-point primitives, as well as <xref:System.Numerics.BigInteger?displayProperty=nameWithType>, which is an integral type with no theoretical upper or lower bound, <xref:System.Numerics.Complex?displayProperty=nameWithType>, which represents complex numbers, and a set of SIMD-enabled types in the <xref:System.Numerics> namespace.
  
## Integer types

.NET supports both signed and unsigned 8-, 16-, 32-, and 64-bit integer types, which are listed in the following table:
  
|Type|Signed/Unsigned|Size (in bytes)|Minimum value|Maximum value|  
|----------|----------------------|--------------------|-------------------|-------------------|  
|<xref:System.Byte?displayProperty=nameWithType>|Unsigned|1|0|255|  
|<xref:System.Int16?displayProperty=nameWithType>|Signed|2|-32,768|32,767|  
|<xref:System.Int32?displayProperty=nameWithType>|Signed|4|-2,147,483,648|2,147,483,647|  
|<xref:System.Int64?displayProperty=nameWithType>|Signed|8|-9,223,372,036,854,775,808|9,223,372,036,854,775,807|  
|<xref:System.SByte?displayProperty=nameWithType>|Signed|1|-128|127|  
|<xref:System.UInt16?displayProperty=nameWithType>|Unsigned|2|0|65,535|  
|<xref:System.UInt32?displayProperty=nameWithType>|Unsigned|4|0|4,294,967,295|  
|<xref:System.UInt64?displayProperty=nameWithType>|Unsigned|8|0|18,446,744,073,709,551,615|  
  
Each integer type supports a set of standard arithmetic operators. The <xref:System.Math?displayProperty=nameWithType> class provides methods for a broader set of mathematical functions.

You can also work with the individual bits in an integer value by using the <xref:System.BitConverter?displayProperty=nameWithType> class.  

> [!NOTE]  
> The unsigned integer types are not CLS-compliant. For more information, see [Language Independence and Language-Independent Components](language-independence-and-language-independent-components.md).

## BigInteger

The <xref:System.Numerics.BigInteger?displayProperty=nameWithType> structure is an immutable type that represents an arbitrarily large integer whose value in theory has no upper or lower bounds. The methods of the <xref:System.Numerics.BigInteger> type closely parallel those of the other integral types.
  
## Floating-point types

.NET includes three primitive floating-point types, which are listed in the following table:
  
|Type|Size (in bytes)|Approximate range|Precision|  
|----------|--------|---------------------|--------------------|  
|<xref:System.Single?displayProperty=nameWithType>|4|±1.5 x 10<sup>−45</sup> to ±3.4 x 10<sup>38</sup>|~6-9 digits|  
|<xref:System.Double?displayProperty=nameWithType>|8|±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup>|~15-17 digits|  
|<xref:System.Decimal?displayProperty=nameWithType>|16|±1.0 x 10<sup>-28</sup> to ±7.9228 x 10<sup>28</sup>|28-29 digits|  
  
Both <xref:System.Single> and <xref:System.Double> types support special values that represent not-a-number and infinity. For example, the <xref:System.Double> type provides the following values: <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, and <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>. You use the <xref:System.Double.IsNaN%2A?displayProperty=nameWithType>, <xref:System.Double.IsInfinity%2A?displayProperty=nameWithType>, <xref:System.Double.IsPositiveInfinity%2A?displayProperty=nameWithType>, and <xref:System.Double.IsNegativeInfinity%2A?displayProperty=nameWithType> methods to test for these special values.

Each floating-point type supports a set of standard arithmetic operators. The <xref:System.Math?displayProperty=nameWithType> class provides methods for a broader set of mathematical functions. .NET Core 2.0 and later includes the <xref:System.MathF?displayProperty=nameWithType> class that provides methods which accept arguments of the <xref:System.Single> type.

You can also work with the individual bits in <xref:System.Double> and <xref:System.Single> values by using the <xref:System.BitConverter?displayProperty=nameWithType> class. The <xref:System.Decimal?displayProperty=nameWithType> structure has its own methods, <xref:System.Decimal.GetBits%2A?displayProperty=nameWithType> and <xref:System.Decimal.%23ctor%28System.Int32%5B%5D%29?displayProperty=nameWithType>, for working with a decimal value's individual bits, as well as its own set of methods for performing some additional mathematical operations.
  
The <xref:System.Double> and <xref:System.Single> types are intended to be used for values that by their nature are imprecise (for example, the distance between two stars) and for applications in which a high degree of precision and small rounding error is not required. You should use the <xref:System.Decimal?displayProperty=nameWithType> type for cases in which greater precision is required and rounding errors should be minimized.

> [!NOTE]
> The <xref:System.Decimal> type doesn't eliminate the need for rounding. Rather, it minimizes errors due to rounding.
  
## Complex

The <xref:System.Numerics.Complex?displayProperty=nameWithType> structure represents a complex number, that is, a number with a real number part and an imaginary number part. It supports a standard set of arithmetic, comparison, equality, explicit and implicit conversion operators, as well as mathematical, algebraic, and trigonometric methods.  
  
## SIMD-enabled types

The <xref:System.Numerics> namespace includes a set of .NET SIMD-enabled types. SIMD (Single Instruction Multiple Data) operations can be parallelized at the hardware level. That increases the throughput of the vectorized computations, which are common in mathematical, scientific, and graphics apps.
  
The .NET SIMD-enabled types include the following:

- The <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> types, which represent vectors with 2, 3, and 4 <xref:System.Single> values.

- Two matrix types, <xref:System.Numerics.Matrix3x2>, which represents a 3x2 matrix, and <xref:System.Numerics.Matrix4x4>, which represents a 4x4 matrix.

- The <xref:System.Numerics.Plane> type, which represents a plane in three-dimensional space.

- The <xref:System.Numerics.Quaternion> type, which represents a vector that is used to encode three-dimensional physical rotations.

- The <xref:System.Numerics.Vector%601> type, which represents a vector of a specified numeric type and provides a broad set of operators that benefit from SIMD support. The count of a <xref:System.Numerics.Vector%601> instance is fixed, but its value <xref:System.Numerics.Vector%601.Count%2A?displayProperty=nameWithType> depends on the CPU of the machine, on which code is executed.
  > [!NOTE]
  > The <xref:System.Numerics.Vector%601> type is not included into the .NET Framework. You must install the [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors) NuGet package to get access to this type.
  
The SIMD-enabled types are implemented in such a way that they can be used with non-SIMD-enabled hardware or JIT compilers. To take advantage of SIMD instructions, your 64-bit apps must be run by the runtime that uses the RyuJIT compiler, which is included in .NET Core and in the .NET Framework 4.6 and later versions. It adds SIMD support when targeting 64-bit processors.

## See also

- [Application Essentials](application-essentials.md)
- [Standard Numeric Format Strings](base-types/standard-numeric-format-strings.md)
