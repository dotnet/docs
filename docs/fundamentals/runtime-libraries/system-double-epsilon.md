---
title: System.Double.Epsilon property
description: Learn about the System.Double.Epsilon property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Double.Epsilon property

[!INCLUDE [context](includes/context.md)]

The value of the <xref:System.Double.Epsilon> property reflects the smallest positive <xref:System.Double> value that is significant in numeric operations or comparisons when the value of the <xref:System.Double> instance is zero. For example, the following code shows that zero and <xref:System.Double.Epsilon> are considered to be unequal values, whereas zero and half the value of <xref:System.Double.Epsilon> are considered to be equal.

:::code language="csharp" source="./snippets/System/Double/Epsilon/csharp/epsilon.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Double/Epsilon/fsharp/epsilon.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/Double/Epsilon/vb/epsilon.vb" id="Snippet5":::

More precisely, the floating point format consists of a sign, a 52-bit mantissa or significand, and an 11-bit exponent. As the following example shows, zero has an exponent of -1022 and a mantissa of 0. <xref:System.Double.Epsilon> has an exponent of -1022 and a mantissa of 1. This means that <xref:System.Double.Epsilon> is the smallest positive <xref:System.Double> value greater than zero and represents the smallest possible value and the smallest possible increment for a <xref:System.Double> whose exponent is -1022.

:::code language="csharp" source="./snippets/System/Double/Epsilon/csharp/epsilon1.cs" interactive="try-dotnet" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Double/Epsilon/fsharp/epsilon1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Double/Epsilon/vb/epsilon1.vb" id="Snippet6":::

However, the <xref:System.Double.Epsilon> property is not a general measure of precision of the <xref:System.Double> type; it applies only to <xref:System.Double> instances that have a value of zero or an exponent of -1022.

> [!NOTE]
> The value of the <xref:System.Double.Epsilon> property is not equivalent to machine epsilon, which represents the upper bound of the relative error due to rounding in floating-point arithmetic.

The value of this constant is 4.94065645841247e-324.

Two apparently equivalent floating-point numbers might not compare equal because of differences in their least significant digits. For example, the C# expression, `(double)1/3 == (double)0.33333`, does not compare equal because the division operation on the left side has maximum precision while the constant on the right side is precise only to the specified digits. If you create a custom algorithm that determines whether two floating-point numbers can be considered equal, we do not recommend that you base your algorithm on the value of the <xref:System.Double.Epsilon> constant to establish the acceptable absolute margin of difference for the two values to be considered equal.  (Typically, that margin of difference is many times greater than <xref:System.Double.Epsilon>.) For information about comparing two double-precision floating-point values, see <xref:System.Double> and <xref:System.Double.Equals(System.Double)>.

## Platform notes

On ARM systems, the value of the <xref:System.Double.Epsilon> constant is too small to be detected, so it equates to zero. You can define an alternative epsilon value that equals 2.2250738585072014E-308 instead.
