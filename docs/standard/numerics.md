---
title: "Numerics in the .NET Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "SIMD"
  - "System.Numerics.Vectors"
  - "vectors"
  - "scientific computing"
  - "Complex"
  - "numerics"
  - "BigInteger"
ms.assetid: dfebc18e-acde-4510-9fa7-9a0f4aa3bd11
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Numerics in the .NET Framework
The .NET Framework supports the standard numeric integral and floating-point primitives, as well as <xref:System.Numerics.BigInteger>, an integral type with no theoretical upper or lower bound, <xref:System.Numerics.Complex>, a type that represents complex numbers, and a set of SIMD-enabled vector types in the <xref:System.Numerics> namespace.  
  
 In addition, System.Numerics.Vectors, the SIMD-enabled library of vectory types, was released as a NuGet package.  
  
## Integral types  
 The .NET Framework supports both signed and unsigned integers ranging from one byte to eight bytes in length. The following table lists the integral types and their size, indicates whether they are signed or unsigned, and documents their range. All integers are value types.  
  
|Type|Signed/Unsigned|Size (bytes)|Minimum value|Maximum Value|  
|----------|----------------------|--------------------|-------------------|-------------------|  
|<xref:System.Byte?displayProperty=nameWithType>|Unsigned|1|0|255|  
|<xref:System.Int16?displayProperty=nameWithType>|Signed|2|-32,768|32,767|  
|<xref:System.Int32?displayProperty=nameWithType>|Signed|4|-2,147,483,648|2,147,483,647|  
|<xref:System.Int64?displayProperty=nameWithType>|Signed|8|-9,223,372,036,854,775,808|9,223,372,036,854,775,807|  
|<xref:System.SByte?displayProperty=nameWithType>|Signed|1|-128|127|  
|<xref:System.UInt16?displayProperty=nameWithType>|Unsigned|2|0|65,535|  
|<xref:System.UInt32?displayProperty=nameWithType>|Unsigned|4|0|4,294,967,295|  
|<xref:System.UInt64?displayProperty=nameWithType>|Unsigned|8|0|18,446,744,073,709,551,615|  
  
 Each integral type supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators. Each integer also includes methods to perform equality comparisons and relative comparisons, to convert the string representation of a number to that integer, and to convert an integer to its string representation. Some additional mathematical operations beyond those handled by the standard operators, such as rounding and identifying the smaller or larger value of two integers, are available from the <xref:System.Math> class. You can also work with the individual bits in an integer value by using the <xref:System.BitConverter> class.  
  
 Note that the unsigned integral types are not CLS-compliant. For more information, see [Language Independence and Language-Independent Components](../../docs/standard/language-independence-and-language-independent-components.md).  
  
## Floating-point types  
 The .NET Framework includes three primitive floating point types, which are listed in the following table.  
  
|Type|Size (in bytes)|Minimum|Maximum|  
|----------|-----------------------|-------------|-------------|  
|<xref:System.Double?displayProperty=nameWithType>|8|-1.79769313486232e308|1.79769313486232e308|  
|<xref:System.Single?displayProperty=nameWithType>|4|-3.402823e38|3.402823e38|  
|<xref:System.Decimal?displayProperty=nameWithType>|16|-79,228,162,514,264,337,593,543,950,335|79,228,162,514,264,337,593,543,950,335|  
  
 Each floating-point type supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators. Each also includes methods to perform equality comparisons and relative comparisons, to convert the string representation of a floating-point number, and to convert a floating-point number to its string representation. Some additional mathematical, algebraic, and trigonometric operations are available from the <xref:System.Math> class. You can also work with the individual bits in <xref:System.Double> and <xref:System.Single> values by using the <xref:System.BitConverter> class. The <xref:System.Decimal?displayProperty=nameWithType> structure has its own methods, <xref:System.Decimal.GetBits%2A?displayProperty=nameWithType> and <xref:System.Decimal.%23ctor%28System.Int32%5B%5D%29?displayProperty=nameWithType>, for working with a decimal value's individual bits, as well as its own set of methods for performing some additional mathematical operations.  
  
 The <xref:System.Double> and <xref:System.Single> types are intended to be used for values that by their nature are imprecise (such as the distance between two stars in the solar system) and for applications in which a high degree of precision and small rounding error is not required. You should use the <xref:System.Decimal?displayProperty=nameWithType> type for cases in which greater precision is required and rounding error is undesirable,  
  
## BigInteger  
 <xref:System.Numerics.BigInteger?displayProperty=nameWithType> is an immutable type that represents an arbitrarily large integer whose value in theory has no upper or lower bounds. The methods of the <xref:System.Numerics.BigInteger> type closely parallel those of the other integral types.  
  
## Complex  
 The <xref:System.Numerics.Complex> type represents a complex number, that is, a number with a real number part and an imaginary number part. It supports a standard set of arithmetic, comparison, equality, explicit conversion, and implicit conversion operators, as well as mathematical, algebraic, and trigonometric methods.  
  
## SIMD-enabled vector types  
 The <xref:System.Numerics> namespace includes a set of SIMD-enabled vector types for the .NET Framework. SIMD (Single Instruction Multiple Data operations) allows some operations to be parallelized at the hardware level, which results in huge performance improvements in mathematical, scientific, and graphics apps that perform computations over vectors.  
  
 The SIMD-enabled vector types in the .NET Framework include the following: .  In addition, System.Numerics.Vectors includes a Plane type and a Quaternion type.  
  
-   <xref:System.Numerics.Vector2>,  <xref:System.Numerics.Vector3>, and  <xref:System.Numerics.Vector4> types, which are 2-, 3-, and 4-dimensional vectors of type <xref:System.Single>.  
  
-   Two matrix types, <xref:System.Numerics.Matrix3x2>, which represents a 3x2 matrix; and <xref:System.Numerics.Matrix4x4>, which represents a 4x4 matrix.  
  
-   The <xref:System.Numerics.Plane> and <xref:System.Numerics.Quaternion> types.  
  
 The SimD-enabled vector types are implemented in IL, which allows them to be used on non-SimD-enabled hardware and JIT compilers. To take advantage of SIMD instructions, your 64-bit apps must be compiled by the new 64-bit JIT Compiler for managed code, which is included with the .NET Framework 4.6; it adds SIMD support when targeting x64 processors.  
  
 SIMD can also be downloaded as a [NuGet package](https://www.nuget.org/packages/System.Numerics.Vectors).  The NuGET package also includes a generic <xref:System.Numerics.Vector%601> structure that allows you to create a vector of any primitive numeric type. (The primitive numeric types include all numeric types in the <xref:System> namespace except for <xref:System.Decimal>.) In addition, the <xref:System.Numerics.Vector%601> structure provides a library of convenience methods that you can call when working with vectors.  
  
## See Also  
 [Application Essentials](../../docs/standard/application-essentials.md)
