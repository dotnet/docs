---
title: SIMD in .NET
description: This tutorial demonstrates how to use SIMD in C#.
author: FIVIL
#ms.author: [MICROSOFT ALIAS OF INTERNAL OWNER]
ms.date: 07/05/2019
#ms.topic: [TOPIC TYPE]
#ms.prod: [PRODUCT VALUE]
ms.technology: dotnet-standard
---

# Overview

SIMD (Single instruction, multiple data) provides the functionality to do multiple processes on a single core to achieve peak performance. In .NET there is set of SIMD-enabled types under <xref:System.Numerics> namespace. SIMD operations can be parallelized at the hardware level. That increases the throughput of the vectorized computations, which are common in mathematical, scientific, and graphics apps.

# .NET SIMD-enabled types

The .NET SIMD-enabled types include the following:

- The <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> types, which represent vectors with 2, 3, and 4 <xref:System.Single> values.

- Two matrix types, <xref:System.Numerics.Matrix3x2>, which represents a 3x2 matrix, and <xref:System.Numerics.Matrix4x4>, which represents a 4x4 matrix.

- The <xref:System.Numerics.Plane> type, which represents a plane in three-dimensional space.

- The <xref:System.Numerics.Quaternion> type, which represents a vector that is used to encode three-dimensional physical rotations.

- The <xref:System.Numerics.Vector%601> type, which represents a vector of a specified numeric type and provides a broad set of operators that benefit from SIMD support. The count of a <xref:System.Numerics.Vector%601> instance is fixed, but its value <xref:System.Numerics.Vector%601.Count%2A?displayProperty=nameWithType> depends on the CPU of the machine, on which code is executed.
  > [!NOTE]
  > The <xref:System.Numerics.Vector%601> type is not included into the .NET Framework. You must install the [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors) NuGet package to get access to this type.
  
The SIMD-enabled types are implemented in such a way that they can be used with non-SIMD-enabled hardware or JIT compilers. To take advantage of SIMD instructions, your 64-bit apps must be run by the runtime that uses the RyuJIT compiler, which is included in .NET Core and in the .NET Framework 4.6 and later versions. It adds SIMD support when targeting 64-bit processors.
