---
title: System.Numerics.Complex struct
description: Learn about the System.Numerics.Complex struct.
ms.date: 05/15/2025
dev_langs:
  - CSharp
  - VB
---
# System.Numerics.Complex struct

[!INCLUDE [context](includes/context.md)]

A complex number is a number that comprises a real number part and an imaginary number part. A complex number z is usually written in the form `z = x + yi`, where *x* and *y* are real numbers, and *i* is the imaginary unit that has the property *i*<sup>2</sup> = -1. The real part of the complex number is represented by *x*, and the imaginary part of the complex number is represented by *y*.

The <xref:System.Numerics.Complex> type uses the Cartesian coordinate system (real, imaginary) when instantiating and manipulating complex numbers. A complex number can be represented as a point in a two-dimensional coordinate system, which is known as the complex plane. The real part of the complex number is positioned on the x-axis (the horizontal axis), and the imaginary part is positioned on the y-axis (the vertical axis).

Any point in the complex plane can also be expressed based on its absolute value, by using the polar coordinate system. In polar coordinates, a point is characterized by two numbers:

- Its magnitude, which is the distance of the point from the origin (that is, 0,0, or the point at which the x-axis and the y-axis intersect).
- Its phase, which is the angle between the real axis and the line drawn from the origin to the point.

## Instantiate a complex number

You can assign a value to a complex number in one of the following ways:

- By passing two <xref:System.Double> values to its constructor. The first value represents the real part of the complex number, and the second value represents its imaginary part. These values represent the position of the complex number in the two-dimensional Cartesian coordinate system.

- By calling the static (`Shared` in Visual Basic) <xref:System.Numerics.Complex.FromPolarCoordinates%2A?displayProperty=nameWithType> method to create a complex number from its polar coordinates.

- By assigning a <xref:System.Byte>, <xref:System.SByte>, <xref:System.Int16>, <xref:System.UInt16>, <xref:System.Int32>, <xref:System.UInt32>, <xref:System.Int64>, <xref:System.UInt64>, <xref:System.Single>, or <xref:System.Double> value to a <xref:System.Numerics.Complex> object. The value becomes the real part of the complex number, and its imaginary part equals 0.

- By casting (in C#) or converting (in Visual Basic) a <xref:System.Decimal> or <xref:System.Numerics.BigInteger> value to a <xref:System.Numerics.Complex> object. The value becomes the real part of the complex number, and its imaginary part equals 0.

- By assigning the complex number that is returned by a method or operator to a <xref:System.Numerics.Complex> object. For example, <xref:System.Numerics.Complex.Add%2A?displayProperty=nameWithType> is a static method that returns a complex number that is the sum of two complex numbers, and the <xref:System.Numerics.Complex.op_Addition%2A?displayProperty=nameWithType> operator adds two complex numbers and returns the result.

The following example demonstrates each of these five ways of assigning a value to a complex number.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/create1.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/create1.vb" id="Snippet2":::

## Operations with complex numbers

The <xref:System.Numerics.Complex> structure in .NET includes members that provide the following functionality:

- Methods to compare two complex numbers to determine whether they are equal.
- Operators to perform arithmetic operations on complex numbers. <xref:System.Numerics.Complex> operators enable you to perform addition, subtraction, multiplication, division, and unary negation with complex numbers.
- Methods to perform other numerical operations on complex numbers. In addition to the four basic arithmetic operations, you can raise a complex number to a specified power, find the square root of a complex number, and get the absolute value of a complex number.
- Methods to perform trigonometric operations on complex numbers. For example, you can calculate the tangent of an angle represented by a complex number.

Note that, because the <xref:System.Numerics.Complex.Real%2A> and  <xref:System.Numerics.Complex.Imaginary%2A> properties are read-only, you cannot modify the value of an existing <xref:System.Numerics.Complex> object. All methods that perform an operation on a <xref:System.Numerics.Complex> number, if their return value is of type <xref:System.Numerics.Complex>, return a new <xref:System.Numerics.Complex> number.

## Precision and complex numbers

The real and imaginary parts of a complex number are represented by two double-precision floating-point values. This means that <xref:System.Numerics.Complex> values, like double-precision floating-point values, can lose precision as a result of numerical operations. This means that strict comparisons for equality of two <xref:System.Numerics.Complex> values may fail, even if the difference between the two values is due to a loss of precision. For more information, see <xref:System.Double>.

For example, performing exponentiation on the logarithm of a number should return the original number. However, in some cases, the loss of precision of floating-point values can cause slight differences between the two values, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/precision1.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/precision1.vb" id="Snippet5":::

Similarly, the following example, which calculates the square root of a <xref:System.Numerics.Complex> number, produces slightly different results on the 32-bit and IA64 versions of .NET.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/precision1.cs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/precision1.vb" id="Snippet6":::

## Infinity and NaN

The real and imaginary parts of a complex number are represented by <xref:System.Double> values. In addition to ranging from <xref:System.Double.MinValue?displayProperty=nameWithType> to <xref:System.Double.MaxValue?displayProperty=nameWithType>, the real or imaginary part of a complex number can have a value of <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, or <xref:System.Double.NaN?displayProperty=nameWithType>. <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, and <xref:System.Double.NaN?displayProperty=nameWithType> all propagate in any arithmetic or trigonometric operation.

In the following example, division by <xref:System.Numerics.Complex.Zero> produces a complex number whose real and imaginary parts are both <xref:System.Double.NaN?displayProperty=nameWithType>. As a result, performing multiplication with this value also produces a complex number whose real and imaginary parts are <xref:System.Double.NaN?displayProperty=nameWithType>. Similarly, performing a multiplication that overflows the range of the <xref:System.Double> type produces a complex number whose real part is <xref:System.Double.NaN?displayProperty=nameWithType> and whose imaginary part is <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>. Subsequently performing division with this complex number returns a complex number whose real part is <xref:System.Double.NaN?displayProperty=nameWithType> and whose imaginary part is <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/nan1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/nan1.vb" id="Snippet3":::

Mathematical operations with complex numbers that are invalid or that overflow the range of the <xref:System.Double> data type do not throw an exception. Instead, they return a <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, or <xref:System.Double.NaN?displayProperty=nameWithType> under the following conditions:

- The division of a positive number by zero returns <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.
- Any operation that overflows the upper bound of the <xref:System.Double> data type returns <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.
- The division of a negative number by zero returns <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>.
- Any operation that overflows the lower bound of the <xref:System.Double> data type returns <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>.
- The division of a zero by zero returns <xref:System.Double.NaN?displayProperty=nameWithType>.
- Any operation that is performed on operands whose values are <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, or <xref:System.Double.NaN?displayProperty=nameWithType> returns <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, or <xref:System.Double.NaN?displayProperty=nameWithType>, depending on the specific operation.

Note that this applies to any intermediate calculations performed by a method. For example, the multiplication of `new Complex(9e308, 9e308) and new Complex(2.5, 3.5)` uses the formula (ac - bd) + (ad + bc)i. The calculation of the real component that results from the multiplication evaluates the expression 9e308 *2.5 - 9e308* 3.5. Each intermediate multiplication in this expression returns <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>, and the attempt to subtract <xref:System.Double.PositiveInfinity?displayProperty=nameWithType> from <xref:System.Double.PositiveInfinity?displayProperty=nameWithType> returns <xref:System.Double.NaN?displayProperty=nameWithType>.

## Format a complex number

By default, the string representation of a complex number takes the form `<`*real*`;` *imaginary*`>`, where *real* and *imaginary* are the string representations of the <xref:System.Double> values that form the complex number's real and imaginary components. Some overloads of the <xref:System.Numerics.Complex.ToString%2A> method allow customization of the string representations of these <xref:System.Double> values to reflect the formatting conventions of a particular culture or to appear in a particular format defined by a standard or custom numeric format string. (For more information, see [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).)

One of the more common ways of expressing the string representation of a complex number takes the form `a + bi`, where `a` is the complex number's real component, and `b` is the complex number's imaginary component. In electrical engineering, a complex number is most commonly expressed as `a + bj`. You can return the string representation of a complex number in either of these two forms. To do this, define a custom format provider by implementing the <xref:System.ICustomFormatter> and <xref:System.IFormatProvider> interfaces, and then call the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method.

The following example defines a `ComplexFormatter` class that represents a complex number as a string in the form of either `a + bi` or `a + bj`.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/customfmt1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/customfmt1.vb" id="Snippet1":::

The following example then uses this custom formatter to display the string representation of a complex number.

:::code language="csharp" source="./snippets/System.Numerics/Complex/Overview/csharp/customfmt1.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Numerics/Complex/Overview/vb/customfmt1.vb" id="Snippet4":::
