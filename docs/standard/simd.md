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

## .NET SIMD-enabled types

The .NET SIMD-enabled types include the following:

- The <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> types, which represent vectors with 2, 3, and 4 <xref:System.Single> values.

- Two matrix types, <xref:System.Numerics.Matrix3x2>, which represents a 3x2 matrix, and <xref:System.Numerics.Matrix4x4>, which represents a 4x4 matrix.

- The <xref:System.Numerics.Plane> type, which represents a plane in three-dimensional space.

- The <xref:System.Numerics.Quaternion> type, which represents a vector that is used to encode three-dimensional physical rotations.

- The <xref:System.Numerics.Vector%601> type, which represents a vector of a specified numeric type and provides a broad set of operators that benefit from SIMD support. The count of a <xref:System.Numerics.Vector%601> instance is fixed, but its value <xref:System.Numerics.Vector%601.Count%2A?displayProperty=nameWithType> depends on the CPU of the machine, on which code is executed.
  > [!NOTE]
  > The <xref:System.Numerics.Vector%601> type is not included into the .NET Framework. You must install the [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors) NuGet package to get access to this type.
  
The SIMD-enabled types are implemented in such a way that they can be used with non-SIMD-enabled hardware or JIT compilers. To take advantage of SIMD instructions, your 64-bit apps must be run by the runtime that uses the RyuJIT compiler, which is included in .NET Core and in the .NET Framework 4.6 and later versions. It adds SIMD support when targeting 64-bit processors.

## How to use SIMD?

 Before executing custom SIMD algorithms, it is possible to check if the host machine supports SIMD using <xref:System.Numerics.Vector.IsHardwareAccelerated?displayProperty=nameWithType>, which returns a <xref:System.Boolean>.

## Simple Vectors

The most primitive SIMD-enabled types in .NET are <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> types, which represent vectors with 2, 3, and 4 <xref:System.Single> values. The example blew uses <xref:System.Numerics.Vector2> to add two vectors.

```csharp
  var v1 = new Vector2(0.1f, 0.2f);
  var v2 = new Vector2(1.1f, 2.2f);
  var vResutl = v1 + v2;
```

It is also possible to use .NET vectors in order to calculate other mathematical properties of vectors such as `Dot product`, `Transform`, `Clamp` etc.

```csharp
   var v1 = new Vector2(0.1f, 0.2f);
   var v2 = new Vector2(1.1f, 2.2f);
   var vResutl1 = Vector2.Dot(v1, v2);
   var vResutl2 = Vector2.Distance(v1, v2);
   var vResutl3 = Vector2.Clamp(v1, Vector2.Zero, Vector2.One);
```

## Matrix

<xref:System.Numerics.Matrix3x2>, which represents a 3x2 matrix, and <xref:System.Numerics.Matrix4x4>, which represents a 4x4 matrix. Can be used for matrix related calculations. The example below demonstrates multiplication of a matrix to it's corespondent transpose matrix using SIMD.

```csharp
    var m1 = new Matrix4x4(
                1.1f, 1.2f, 1.3f, 1.4f,
                2.1f, 2.2f, 3.3f, 4.4f,
                3.1f, 3.2f, 3.3f, 3.4f,
                4.1f, 4.2f, 4.3f, 4.4f);

    var m2 = Matrix4x4.Transpose(m1);
    var mResult = Matrix4x4.Multiply(m1, m2);
```

## Vector<T>

The <xref:System.Numerics.Vector%601> gives the ability to utilize and longer vectors, The count of a <xref:System.Numerics.Vector%601> instance is fixed, but its value <xref:System.Numerics.Vector%601.Count%2A?displayProperty=nameWithType> depends on the CPU of the machine, on which code is executed.

The example below demonstrates adding long arrays elements using <xref:System.Numerics.Vector%601>.

```csharp
  double[] SimdVectorProd(double[] left, double[] right)
        {
            var offset = Vector<double>.Count;
            double[] result = new double[left.Length];
            int i = 0;
            for (i = 0; i < left.Length; i += offset)
            {
                var v1 = new Vector<double>(left, i);
                var v2 = new Vector<double>(right, i);
                (v1 * v2).CopyTo(result, i);
            }

            //remaining items
            for (; i < left.Length; ++i)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
```

## Remarks

SIMD is more likely to remove one bottleneck and expose the next, for example memory throughput. In general the performance benefit of using SIMD varies depending on the specific scenario, and in some cases it can even perform worse than simpler non-SIMD equivalent code. 
