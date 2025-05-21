---
title: System.Single.Epsilon property
description: Learn about the System.Single.Epsilon property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Single.Epsilon property

[!INCLUDE [context](includes/context.md)]

The value of the <xref:System.Single.Epsilon> property reflects the smallest positive <xref:System.Single> value that is significant in numeric operations or comparisons when the value of the <xref:System.Single> instance is zero. For example, the following code shows that zero and <xref:System.Single.Epsilon> are considered to be unequal values, whereas zero and half the value of <xref:System.Single.Epsilon> are considered to be equal.

:::code language="csharp" source="./snippets/System/Single/Epsilon/csharp/epsilon.cs"  interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Single/Epsilon/fsharp/epsilon.fs"  id="Snippet5":::
:::code language="vb" source="./snippets/System/Single/Epsilon/vb/epsilon.vb" id="Snippet5":::

More precisely, the single-precision floating-point format consists of a sign, a 23-bit mantissa or significand, and an 8-bit exponent. As the following example shows, zero has an exponent of -126 and a mantissa of 0. <xref:System.Single.Epsilon> has an exponent of -126 and a mantissa of 1. This means that <xref:System.Single.Epsilon?displayProperty=nameWithType> is the smallest positive <xref:System.Single> value that is greater than zero and represents the smallest possible value and the smallest possible increment for a <xref:System.Single> whose exponent is -126.

:::code language="csharp" source="./snippets/System/Single/Epsilon/csharp/epsilon1.cs"  interactive="try-dotnet" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Single/Epsilon/fsharp/epsilon1.fs"  id="Snippet6":::
:::code language="vb" source="./snippets/System/Single/Epsilon/vb/epsilon1.vb" id="Snippet6":::

However, the <xref:System.Single.Epsilon> property is not a general measure of precision of the <xref:System.Single> type; it applies only to <xref:System.Single> instances that have a value of zero.

> [!NOTE]
> The value of the <xref:System.Single.Epsilon> property is not equivalent to machine epsilon, which represents the upper bound of the relative error due to rounding in floating-point arithmetic.

The value of this constant is 1.4e-45.

Two apparently equivalent floating-point numbers might not compare equal because of differences in their least significant digits. For example, the C# expression, `(float)1/3 == (float)0.33333`, does not compare equal because the division operation on the left side has maximum precision while the constant on the right side is precise only to the specified digits. If you create a custom algorithm that determines whether two floating-point numbers can be considered equal, you must use a value that is greater than the <xref:System.Single.Epsilon> constant to establish the acceptable absolute margin of difference for the two values to be considered equal. (Typically, that margin of difference is many times greater than <xref:System.Single.Epsilon>.)

## Platform notes

On ARM systems, the value of the <xref:System.Single.Epsilon> constant is too small to be detected, so it equates to zero. You can define an alternative epsilon value that equals 1.175494351E-38 instead.
