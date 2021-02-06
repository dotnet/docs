---
description: "Learn more about: Math Functions (Visual Basic)"
title: Math functions
ms.date: 01/27/2020
helpviewer_keywords: 
  - "math functions, Visual Basic"
  - "arithmetic operations, math functions"
  - "math routines"
  - "Atn function"
ms.assetid: 4d2d82e7-6924-42fe-a4a7-b4dd5bebbd0c
---
# Math Functions (Visual Basic)

The methods of the <xref:System.Math?displayProperty=nameWithType> class provide trigonometric, logarithmic, and other common mathematical functions.

## Remarks

The following table lists methods of the <xref:System.Math?displayProperty=nameWithType> class. You can use these in a Visual Basic program:
  
|.NET method|Description|
|---------------------------|-----------------|
|<xref:System.Math.Abs%2A>|Returns the absolute value of a number.|
|<xref:System.Math.Acos%2A>|Returns the angle whose cosine is the specified number.|
|<xref:System.Math.Asin%2A>|Returns the angle whose sine is the specified number.|
|<xref:System.Math.Atan%2A>|Returns the angle whose tangent is the specified number.|
|<xref:System.Math.Atan2%2A>|Returns the angle whose tangent is the quotient of two specified numbers.|
|<xref:System.Math.BigMul%2A>|Returns the full product of two 32-bit numbers.|
|<xref:System.Math.Ceiling%2A>|Returns the smallest integral value that's greater than or equal to the specified `Decimal` or `Double`.|
|<xref:System.Math.Cos%2A>|Returns the cosine of the specified angle.|
|<xref:System.Math.Cosh%2A>|Returns the hyperbolic cosine of the specified angle.|
|<xref:System.Math.DivRem%2A>|Returns the quotient of two 32-bit or 64-bit signed integers, and also returns the remainder in an output parameter.|
|<xref:System.Math.Exp%2A>|Returns e (the base of natural logarithms) raised to the specified power.|
|<xref:System.Math.Floor%2A>|Returns the largest integer that's less than or equal to the specified `Decimal` or `Double` number.|
|<xref:System.Math.IEEERemainder%2A>|Returns the remainder that results from the division of a specified number by another specified number.|
|<xref:System.Math.Log%2A>|Returns the natural (base e) logarithm of a specified number or the logarithm of a specified number in a specified base.|
|<xref:System.Math.Log10%2A>|Returns the base 10 logarithm of a specified number.|
|<xref:System.Math.Max%2A>|Returns the larger of two numbers.|
|<xref:System.Math.Min%2A>|Returns the smaller of two numbers.|
|<xref:System.Math.Pow%2A>|Returns a specified number raised to the specified power.|
|<xref:System.Math.Round%2A>|Returns a `Decimal` or `Double` value rounded to the nearest integral value or to a specified number of fractional digits.|
|<xref:System.Math.Sign%2A>|Returns an `Integer` value indicating the sign of a number.|
|<xref:System.Math.Sin%2A>|Returns the sine of the specified angle.|
|<xref:System.Math.Sinh%2A>|Returns the hyperbolic sine of the specified angle.|
|<xref:System.Math.Sqrt%2A>|Returns the square root of a specified number.|
|<xref:System.Math.Tan%2A>|Returns the tangent of the specified angle.|
|<xref:System.Math.Tanh%2A>|Returns the hyperbolic tangent of the specified angle.|
|<xref:System.Math.Truncate%2A>|Calculates the integral part of a specified `Decimal` or `Double` number.|

The following table lists methods of the <xref:System.Math?displayProperty=nameWithType> class that don't exist in .NET Framework but are added in .NET Standard or .NET Core:

|.NET method|Description|Available in|
|---------------------------|-----------------|-----------|
|<xref:System.Math.Acosh%2A>|Returns the angle whose hyperbolic cosine is the specified number.|Starting with .NET Core 2.1 and .NET Standard 2.1|
|<xref:System.Math.Asinh%2A>|Returns the angle whose hyperbolic sine is the specified number.|Starting with .NET Core 2.1 and .NET Standard 2.1|
|<xref:System.Math.Atanh%2A>|Returns the angle whose hyperbolic tangent is the specified number.|Starting with .NET Core 2.1 and .NET Standard 2.1|
|<xref:System.Math.BitDecrement%2A>|Returns the next smallest value that compares less than `x`.|Starting with .NET Core 3.0|
|<xref:System.Math.BitIncrement%2A>|Returns the next largest value that compares greater than `x`.|Starting with .NET Core 3.0|
|<xref:System.Math.Cbrt%2A>|Returns the cube root of a specified number.|Starting with .NET Core 2.1 and .NET Standard 2.1|
|<xref:System.Math.Clamp%2A>|Returns `value` clamped to the inclusive range of `min` and `max`.|Starting with .NET Core 2.0 and .NET Standard 2.1|
|<xref:System.Math.CopySign%2A>|Returns a value with the magnitude of `x` and the sign of `y`.|Starting with .NET Core 3.0|
|<xref:System.Math.FusedMultiplyAdd%2A>|Returns (x \* y) + z, rounded as one ternary operation.|Starting with .NET Core 3.0|
|<xref:System.Math.ILogB%2A>|Returns the base 2 integer logarithm of a specified number.|Starting with .NET Core 3.0|
|<xref:System.Math.Log2%2A>|Returns the base 2 logarithm of a specified number.|Starting with .NET Core 3.0|
|<xref:System.Math.MaxMagnitude%2A>|Returns the larger magnitude of two double-precision floating-point numbers.|Starting with .NET Core 3.0|
|<xref:System.Math.MinMagnitude%2A>|Returns the smaller magnitude of two double-precision floating-point numbers.|Starting with .NET Core 3.0|
|<xref:System.Math.ScaleB%2A>|Returns x \* 2^n computed efficiently.|Starting with .NET Core 3.0|

To use these functions without qualification, import the <xref:System.Math?displayProperty=nameWithType> namespace into your project by adding the following code to the top of your source file:

```vb
Imports System.Math
```

## Example - Abs

This example uses the <xref:System.Math.Abs%2A> method of the <xref:System.Math> class to compute the absolute value of a number.

```vb
Dim x As Double = Math.Abs(50.3)
Dim y As Double = Math.Abs(-50.3)
Console.WriteLine(x)
Console.WriteLine(y)
' This example produces the following output:
' 50.3
' 50.3
```  

## Example - Atan

This example uses the <xref:System.Math.Atan%2A> method of the <xref:System.Math> class to calculate the value of pi.

```vb
Public Function GetPi() As Double
    ' Calculate the value of pi.
    Return 4.0 * Math.Atan(1.0)
End Function
```

> [!NOTE]
> The <xref:System.Math?displayProperty=nameWithType> class contains <xref:System.Math.PI?displayProperty=nameWithType> constant field. You can use it rather than calculating it.

## Example - Cos

This example uses the <xref:System.Math.Cos%2A> method of the <xref:System.Math> class to return the cosine of an angle.

```vb
Public Function Sec(angle As Double) As Double
    ' Calculate the secant of angle, in radians.
    Return 1.0 / Math.Cos(angle)
End Function
```

## Example - Exp

This example uses the <xref:System.Math.Exp%2A> method of the <xref:System.Math> class to return e raised to a power.

```vb
Public Function Sinh(angle As Double) As Double
    ' Calculate hyperbolic sine of an angle, in radians.
    Return (Math.Exp(angle) - Math.Exp(-angle)) / 2.0
End Function
```

## Example - Log

This example uses the <xref:System.Math.Log%2A> method of the <xref:System.Math> class to return the natural logarithm of a number.

```vb
Public Function Asinh(value As Double) As Double
    ' Calculate inverse hyperbolic sine, in radians.
    Return Math.Log(value + Math.Sqrt(value * value + 1.0))
End Function
```

## Example - Round

This example uses the <xref:System.Math.Round%2A> method of the <xref:System.Math> class to round a number to the nearest integer.

```vb
Dim myVar2 As Double = Math.Round(2.8)
Console.WriteLine(myVar2)
' The code produces the following output:
' 3
```

## Example - Sign

This example uses the <xref:System.Math.Sign%2A> method of the <xref:System.Math> class to determine the sign of a number.

```vb
Dim mySign1 As Integer = Math.Sign(12)
Dim mySign2 As Integer = Math.Sign(-2.4)
Dim mySign3 As Integer = Math.Sign(0)
Console.WriteLine(mySign1)
Console.WriteLine(mySign2)
Console.WriteLine(mySign3)
' The code produces the following output:
' 1
' -1
' 0
```

## Example - Sin

This example uses the <xref:System.Math.Sin%2A> method of the <xref:System.Math> class to return the sine of an angle.

```vb
Public Function Csc(angle As Double) As Double
    ' Calculate cosecant of an angle, in radians.
    Return 1.0 / Math.Sin(angle)
End Function
```

## Example - Sqrt

This example uses the <xref:System.Math.Sqrt%2A> method of the <xref:System.Math> class to calculate the square root of a number.

```vb
Dim mySqrt1 As Double = Math.Sqrt(4)
Dim mySqrt2 As Double = Math.Sqrt(23)
Dim mySqrt3 As Double = Math.Sqrt(0)
Dim mySqrt4 As Double = Math.Sqrt(-4)
Console.WriteLine(mySqrt1)
Console.WriteLine(mySqrt2)
Console.WriteLine(mySqrt3)
Console.WriteLine(mySqrt4)
' The code produces the following output:
' 2
' 4.79583152331272
' 0
' NaN
```

## Example - Tan

This example uses the <xref:System.Math.Tan%2A> method of the <xref:System.Math> class to return the tangent of an angle.

```vb
Public Function Ctan(angle As Double) As Double
    ' Calculate cotangent of an angle, in radians.
    Return 1.0 / Math.Tan(angle)
End Function
```

## See also

- <xref:Microsoft.VisualBasic.VBMath.Rnd%2A>
- <xref:Microsoft.VisualBasic.VBMath.Randomize%2A>
- <xref:System.Double.NaN>
- [Derived Math Functions](../keywords/derived-math-functions.md)
- [Arithmetic Operators](../operators/arithmetic-operators.md)
