---
description: "Learn more about interfaces for generic math in .NET."
title: Generic math
titleSuffix: .NET
ms.date: 07/26/2022
---
# Generic math

.NET 7 introduces new math-related generic interfaces to the base class library. The availability of these interfaces means you can constrain a type parameter of a generic type or method to be "number-like". In addition, C# 11 and later lets you define [`static abstract` interface members](../../csharp/language-reference/keywords/interface.md#static-abstract-and-virtual-members). Because operators must be declared as `static`, this new C# feature lets operators be declared in the new interfaces for number-like types.

Together, these innovations allow you to perform mathematical operations generically&mdash;that is, without having to know the exact type you're working with. For example, if you wanted to write a method that adds two numbers, previously you had to add an overload of the method for each type (for example, `static int Add(int first, int second)` and `static float Add(float first, float second)`). Now you can write a single, generic method, where the type parameter is constrained to be a number-like type. For example:

```csharp
static T Add<T>(T left, T right)
    where T : INumber<T>
{
    return left + right;
}
```

In this method, the type parameter `T` is constrained to be a type that implements the new <xref:System.Numerics.INumber%601> interface. <xref:System.Numerics.INumber%601> implements the <xref:System.Numerics.IAdditionOperators%603> interface, which contains the [+ operator](xref:System.Numerics.IAdditionOperators%603.op_Addition(%600,%601)). That allows the method to generically add the two numbers. The method can be used with any of .NET's numeric types, because they've all been updated to implement <xref:System.Numerics.INumber%601> in .NET 7.

## Numeric interfaces

This section describes the interfaces in <xref:System.Numerics?displayProperty=fullName> that describe number-lik types and the functionality available to them.

| Interface name                                         | Description                                                                                |
|--------------------------------------------------------|--------------------------------------------------------------------------------------------|
| <xref:System.Numerics.IBinaryFloatingPointIeee754%601> | Exposes APIs common to *binary* floating-point types that implement the IEEE 754 standard. |
| <xref:System.Numerics.IBinaryInteger%601>              | Exposes APIs common to binary integers.                                                    |
| <xref:System.Numerics.IBinaryNumber%601>               | Exposes APIs common to binary numbers.                                                     |
| <xref:System.Numerics.IFloatingPoint%601>              | Exposes APIs common to floating-point types.                                               |
| <xref:System.Numerics.IFloatingPointIeee754%601>       | Exposes APIs common to floating-point types that implement the IEEE 754 standard.          |
| <xref:System.Numerics.INumber%601>                     | Exposes APIs common to comparable number types (effectively the "real" number domain).     |
| <xref:System.Numerics.INumberBase%601>                 | Exposes APIs common to all number types (effectively the "complex" number domain).         |
| <xref:System.Numerics.ISignedNumber%601>               | Exposes APIs common to all signed number types (such as the concept of `NegativeOne`).     |
| <xref:System.Numerics.IUnsignedNumber%601>             | Exposes APIs common to all unsigned number types.                                          |
| <xref:System.Numerics.IAdditiveIdentity%601>           | Exposes the concept of `(x + T.AdditiveIdentity) == x`.                                    |
| <xref:System.Numerics.IMinMaxValue%601>                | Exposes the concept of `T.MinValue` and `T.MaxValue`.                                      |
| <xref:System.Numerics.IMultiplicativeIdentity%601>     | Exposes the concept of `(x * T.MultiplicativeIdentity) == x`.                              |

## Operator interfaces

These `static abstract` interfaces correspond to the various operators available to the C# language.

They explicitly don't pair operations such as multiplication and division since that isn't correct for all types. For example, `Matrix4x4 * Matrix4x4` is valid, but `Matrix4x4 / Matrix4x4` is not valid.

These interfaces typically allow the input and result types to differ to support scenarios such as dividing two integers to obtain a `double`, for example, `3 / 2 = 1.5`.

| Interface name                                     | Defined operators                        |
|----------------------------------------------------|------------------------------------------|
| <xref:System.Numerics.IAdditionOperators%601>      | `x + y`                                  |
| <xref:System.Numerics.IBitwiseOperators%601>       | `x & y`, `x | y`, `x ^ y`, and `~x`      |
| <xref:System.Numerics.IComparisonOperators%601>    | `x < y`, `x > y`, `x <= y`, and `x >= y` |
| <xref:System.Numerics.IDecrementOperators%601>     | `--x` and `x--`                          |
| <xref:System.Numerics.IDivisionOperators%601>      | `x / y`                                  |
| <xref:System.Numerics.IEqualityOperators%601>      | `x == y` and `x != y`                    |
| <xref:System.Numerics.IIncrementOperators%601>     | `++x` and `x++`                          |
| <xref:System.Numerics.IModulusOperators%601>       | `x % y`                                  |
| <xref:System.Numerics.IMultiplyOperators%601>      | `x * y`                                  |
| <xref:System.Numerics.IShiftOperators%601>         | `x << y` and `x >> y`                    |
| <xref:System.Numerics.ISubtractionOperators%601>   | `x - y`                                  |
| <xref:System.Numerics.IUnaryNegationOperators%601> | `-x`                                     |
| <xref:System.Numerics.IUnaryPlusOperators%601>     | `+x`                                     |

## Function interfaces

| Interface name                                     | Description                                                                                                              |
|----------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------|
| <xref:System.Numerics.IExponentialFunctions%601>   | Exposes exponential functions supporting `e^x`, `e^x - 1`, `2^x`, `2^x - 1`, `10^x`, and `10^x - 1`.                     |
| <xref:System.Numerics.IHyperbolicFunctions%601>    | Exposes hyperbolic functions supporting `acosh(x)`, `asinh(x)`, `atanh(x)`, `cosh(x)`, `sinh(x)`, and `tanh(x)`.         |
| <xref:System.Numerics.ILogarithmicFunctions%601>   | Exposes logarithmic functions supporting `ln(x)`, `ln(x + 1)`, `log2(x)`, `log2(x + 1)`, `log10(x)`, and `log10(x + 1)`. |
| <xref:System.Numerics.IPowerFunctions%601>         | Exposes power functions supporting `x^y`.                                                                                |
| <xref:System.Numerics.IRootFunctions%601>          | Exposes root functions supporting `cbrt(x)` and `sqrt(x)`.                                                               |
| <xref:System.Numerics.ITrigonometricFunctions%601> | Exposes trigonometric functions supporting `acos(x)`, `asin(x)`, `atan(x)`, `cos(x)`, `sin(x)`, and `tan(x)`.            |

## Parsing and formatting interfaces

| Interface name                     | Description                                                                                      |
|------------------------------------|--------------------------------------------------------------------------------------------------|
| <xref:System.IFormattable%601>     | Exposes support for `value.ToString(string, IFormatProvider)`.                                   |
| <xref:System.ISpanFormattable%601> | Exposes support for `value.TryFormat(Span<char>, out int, ReadOnlySpan<char>, IFormatProvider)`. |
| <xref:System.IParsable%601>        | Exposes support for `T.Parse(string, IFormatProvider)`.                                          |
| <xref:System.ISpanParsable%601>    | Exposes support for `T.Parse(ReadOnlySpan<char>, IFormatProvider)`.                              |

## See also

- [Generic math in .NET 7 (blog post)](https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/)
