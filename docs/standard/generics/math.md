---
description: "Learn more about interfaces for generic math in .NET."
title: Generic math
titleSuffix: .NET
ms.date: 08/12/2022
---
# Generic math

.NET 7 introduces new math-related generic interfaces to the base class library. The availability of these interfaces means you can constrain a type parameter of a generic type or method to be "number-like". In addition, C# 11 and later lets you define [`static virtual` interface members](../../csharp/language-reference/keywords/interface.md#static-abstract-and-virtual-members). Because operators must be declared as `static`, this new C# feature lets operators be declared in the new interfaces for number-like types.

Together, these innovations allow you to perform mathematical operations generically&mdash;that is, without having to know the exact type you're working with. For example, if you wanted to write a method that adds two numbers, previously you had to add an overload of the method for each type (for example, `static int Add(int first, int second)` and `static float Add(float first, float second)`). Now you can write a single, generic method, where the type parameter is constrained to be a number-like type. For example:

```csharp
static T Add<T>(T left, T right)
    where T : INumber<T>
{
    return left + right;
}
```

In this method, the type parameter `T` is constrained to be a type that implements the new <xref:System.Numerics.INumber%601> interface. <xref:System.Numerics.INumber%601> implements the <xref:System.Numerics.IAdditionOperators%603> interface, which contains the [+ operator](xref:System.Numerics.IAdditionOperators%603.op_Addition(%600,%601)). That allows the method to generically add the two numbers. The method can be used with any of .NET's built-in numeric types, because they've all been updated to implement <xref:System.Numerics.INumber%601> in .NET 7.

Library authors will benefit most from the generic math interfaces, because they can simplify their code base by removing "redundant" overloads. Other developers will benefit indirectly, because the APIs they consume may start supporting more types.

## The interfaces

The interfaces were designed to be both fine-grained enough that users can define their own interfaces on top, while also being granular enough that they're easy to consume. To that extent, there are a few core numeric interfaces that most users will interact with, such as <xref:System.Numerics.INumber%601> and <xref:System.Numerics.IBinaryInteger%601>. The more fine-grained interfaces, such as <xref:System.Numerics.IAdditionOperators%603> and <xref:System.Numerics.ITrigonometricFunctions%601>, support these types and are available for developers who define their own domain-specific numeric interfaces.

- [Numeric interfaces](#numeric-interfaces)
- [Operator interfaces](#operator-interfaces)
- [Function interfaces](#function-interfaces)
- [Parsing and formatting interfaces](#parsing-and-formatting-interfaces)

### Numeric interfaces

This section describes the interfaces in <xref:System.Numerics?displayProperty=fullName> that describe number-like types and the functionality available to them.

| Interface name                                         | Description                                                                                            |
|--------------------------------------------------------|--------------------------------------------------------------------------------------------------------|
| <xref:System.Numerics.IBinaryFloatingPointIeee754%601> | Exposes APIs common to *binary* floating-point types<sup>1</sup> that implement the IEEE 754 standard. |
| <xref:System.Numerics.IBinaryInteger%601>              | Exposes APIs common to binary integers<sup>2</sup>.                                                    |
| <xref:System.Numerics.IBinaryNumber%601>               | Exposes APIs common to binary numbers.                                                                 |
| <xref:System.Numerics.IFloatingPoint%601>              | Exposes APIs common to floating-point types.                                                           |
| <xref:System.Numerics.IFloatingPointIeee754%601>       | Exposes APIs common to floating-point types that implement the IEEE 754 standard.                      |
| <xref:System.Numerics.INumber%601>                     | Exposes APIs common to comparable number types (effectively the "real" number domain).                 |
| <xref:System.Numerics.INumberBase%601>                 | Exposes APIs common to all number types (effectively the "complex" number domain).                     |
| <xref:System.Numerics.ISignedNumber%601>               | Exposes APIs common to all signed number types (such as the concept of `NegativeOne`).                 |
| <xref:System.Numerics.IUnsignedNumber%601>             | Exposes APIs common to all unsigned number types.                                                      |
| <xref:System.Numerics.IAdditiveIdentity%602>           | Exposes the concept of `(x + T.AdditiveIdentity) == x`.                                                |
| <xref:System.Numerics.IMinMaxValue%601>                | Exposes the concept of `T.MinValue` and `T.MaxValue`.                                                  |
| <xref:System.Numerics.IMultiplicativeIdentity%602>     | Exposes the concept of `(x * T.MultiplicativeIdentity) == x`.                                          |

<sup>1</sup>The binary [floating-point types](../../csharp/language-reference/builtin-types/floating-point-numeric-types.md) are <xref:System.Double> (`double`), <xref:System.Half>, and <xref:System.Single> (`float`).

<sup>2</sup>The binary [integer types](../../csharp/language-reference/builtin-types/integral-numeric-types.md) are <xref:System.Byte> (`byte`), <xref:System.Int16> (`short`), <xref:System.Int32> (`int`), <xref:System.Int64> (`long`), <xref:System.Int128>, <xref:System.IntPtr> (`nint`), <xref:System.SByte> (`sbyte`), <xref:System.UInt16> (`ushort`), <xref:System.UInt32> (`uint`), <xref:System.UInt64> (`ulong`), <xref:System.UInt128>, and <xref:System.UIntPtr> (`nuint`).

The interface you're most likely to use directly is <xref:System.Numerics.INumber%601>, which roughly corresponds to a *real* number. If a type implements this interface, it means that a value has a sign (this includes `unsigned` types, which are considered positive) and can be compared to other values of the same type. <xref:System.Numerics.INumberBase%601> confers more advanced concepts, such as *complex* and *imaginary* numbers, for example, the square root of a negative number. Other interfaces, such as <xref:System.Numerics.IFloatingPointIeee754%601>, were created because not all operations make sense for all number types&mdash;for example, calculating the floor of a number only makes sense for floating-point types. In the .NET base class library, the floating-point type <xref:System.Double> implements <xref:System.Numerics.IFloatingPointIeee754%601> but <xref:System.Int32> doesn't.

Several of the interfaces are also implemented by various other types, including <xref:System.Char>, <xref:System.DateOnly>, <xref:System.DateTime>, <xref:System.DateTimeOffset>, <xref:System.Decimal>, <xref:System.Guid>, <xref:System.TimeOnly>, and <xref:System.TimeSpan>.

The following table shows some of the core APIs exposed by each interface.

| Interface                                        | API name             | Description                                                                                              |
|--------------------------------------------------|----------------------|----------------------------------------------------------------------------------------------------------|
| <xref:System.Numerics.IBinaryInteger%601>        | `DivRem`             | Computes the quotient and remainder simultaneously.                                                      |
|                                                  | `LeadingZeroCount`   | Counts the number of leading zero bits in the binary representation.                                     |
|                                                  | `PopCount`           | Counts the number of set bits in the binary representation.                                              |
|                                                  | `RotateLeft`         | Rotates bits left, sometimes also called a circular left shift.                                          |
|                                                  | `RotateRight`        | Rotates bits right, sometimes also called a circular right shift.                                        |
|                                                  | `TrailingZeroCount`  | Counts the number of trailing zero bits in the binary representation.                                    |
| <xref:System.Numerics.IFloatingPoint%601>        | `Ceiling`            | Rounds the value towards positive infinity. +4.5 becomes +5, and -4.5 becomes -4.                        |
|                                                  | `Floor`              | Rounds the value towards negative infinity. +4.5 becomes +4, and -4.5 becomes -5.                        |
|                                                  | `Round`              | Rounds the value using the specified rounding mode.                                                      |
|                                                  | `Truncate`           | Rounds the value towards zero. +4.5 becomes +4, and -4.5 becomes -4.                                     |
| <xref:System.Numerics.IFloatingPointIeee754%601> | `E`                  | Gets a value representing Euler's number for the type.                                                   |
|                                                  | `Epsilon`            | Gets the smallest representable value that's greater than zero for the type.                             |
|                                                  | `NaN`                | Gets a value representing `NaN` for the type.                                                            |
|                                                  | `NegativeInfinity`   | Gets a value representing `-Infinity` for the type.                                                      |
|                                                  | `NegativeZero`       | Gets a value representing `-Zero` for the type.                                                          |
|                                                  | `Pi`                 | Gets a value representing `Pi` for the type.                                                             |
|                                                  | `PositiveInfinity`   | Gets a value representing `+Infinity` for the type.                                                      |
|                                                  | `Tau`                | Gets a value representing `Tau` (`2 * Pi`) for the type.                                                 |
|                                                  | (Other)              | (Implements the full set of interfaces listed under [Function interfaces](#function-interfaces).)        |
| <xref:System.Numerics.INumber%601>               | `Clamp`              | Restricts a value to no more and no less than the specified min and max value.                           |
|                                                  | `CopySign`           | Sets the sign of a specified value to the same as another specified value.                               |
|                                                  | `Max`                | Returns the greater of two values, returning `NaN` if either input is `NaN`.                             |
|                                                  | `MaxNumber`          | Returns the greater of two values, returning the number if one input is `NaN`.                           |
|                                                  | `Min`                | Returns the lesser of two values, returning `NaN` if either input is `NaN`.                              |
|                                                  | `MinNumber`          | Returns the lesser of two values, returning the number if one input is `NaN`.                            |
|                                                  | `Sign`               | Returns -1 for negative values, 0 for zero, and +1 for positive values.                                  |
| <xref:System.Numerics.INumberBase%601>           | `One`                | Gets the value 1 for the type.                                                                           |
|                                                  | `Radix`              | Gets the radix, or base, for the type. <xref:System.Int32> returns 2. <xref:System.Decimal> returns 10.  |
|                                                  | `Zero`               | Gets the value 0 for the type.                                                                           |
|                                                  | `CreateChecked`      | Creates a value, throwing an <xref:System.OverflowException> if the input can't fit.<sup>1</sup>        |
|                                                  | `CreateSaturating`   | Creates a value, clamping to `T.MinValue` or `T.MaxValue` if the input can't fit.<sup>1</sup>           |
|                                                  | `CreateTruncating`   | Creates a value from another value, wrapping around if the input can't fit.<sup>1</sup>                 |
|                                                  | `IsComplexNumber`    | Returns true if the value has a non-zero real part and a non-zero imaginary part.                        |
|                                                  | `IsEvenInteger`      | Returns true if the value is an even integer. 2.0 returns `true`, and 2.2 returns `false`.               |
|                                                  | `IsFinite`           | Returns true if the value is not infinite and not `NaN`.                                                 |
|                                                  | `IsImaginaryNumber`  | Returns true if the value has a zero real part. This means `0` is imaginary and `1 + 1i` isn't.         |
|                                                  | `IsInfinity`         | Returns true if the value represents infinity.                                                           |
|                                                  | `IsInteger`          | Returns true if the value is an integer. 2.0 and 3.0 return `true`, and 2.2 and 3.1 return `false`.      |
|                                                  | `IsNaN`              | Returns true if the value represents `NaN`.                                                              |
|                                                  | `IsNegative`         | Returns true if the value is negative. This includes -0.0.                                               |
|                                                  | `IsPositive`         | Returns true if the value is positive. This includes 0 and +0.0.                                         |
|                                                  | `IsRealNumber`       | Returns true if the value has a zero imaginary part. This means 0 is real as are all `INumber<T>` types. |
|                                                  | `IsZero`             | Returns true if the value represents zero. This includes 0, +0.0, and -0.0.                              |
|                                                  | `MaxMagnitude`       | Returns the value with a greater absolute value, returning `NaN` if either input is `NaN`.               |
|                                                  | `MaxMagnitudeNumber` | Returns the value with a greater absolute value, returning the number if one input is `NaN`.             |
|                                                  | `MinMagnitude`       | Returns the value with a lesser absolute value, returning `NaN` if either input is `NaN`.                |
|                                                  | `MinMagnitudeNumber` | Returns the value with a lesser absolute value, returning the number if one input is `NaN`.              |
| <xref:System.Numerics.ISignedNumber%601>         | `NegativeOne`        | Gets the value -1 for the type.                                                                          |

<sup>1</sup>To help understand the behavior of the three `Create*` methods, consider the following examples.

Example when given a value that's too large:

- `byte.CreateChecked(384)` will throw an <xref:System.OverflowException>.
- `byte.CreateSaturating(384)` returns 255 because 384 is greater than <xref:System.Byte.MaxValue?displayProperty=nameWithType> (which is 255).
- `byte.CreateTruncating(384)` returns 128 because it takes the lowest 8 bits (384 has a hex representation of `0x0180`, and the lowest 8 bits is `0x80`, which is 128).

Example when given a value that's too small:

- `byte.CreateChecked(-384)` will throw an <xref:System.OverflowException>.
- `byte.CreateSaturating(-384)` returns 0 because -384 is smaller than <xref:System.Byte.MinValue?displayProperty=nameWithType> (which is 0).
- `byte.CreateTruncating(-384)` returns 128 because it takes the lowest 8 bits (384 has a hex representation of `0xFE80`, and the lowest 8 bits is `0x80`, which is 128).

The `Create*` methods also have some special considerations for IEEE 754 floating-point types, like `float` and `double`, as they have the special values `PositiveInfinity`, `NegativeInfinity`, and `NaN`. All three `Create*` APIs behave as `CreateSaturating`. Also, while `MinValue` and `MaxValue` represent the largest negative/positive "normal" number, the actual minimum and maximum values are `NegativeInfinity` and `PositiveInfinity`, so they clamp to these values instead.

### Operator interfaces

The operator interfaces correspond to the various operators available to the C# language.

- They explicitly don't pair operations such as multiplication and division since that isn't correct for all types. For example, `Matrix4x4 * Matrix4x4` is valid, but `Matrix4x4 / Matrix4x4` isn't valid.
- They typically allow the input and result types to differ to support scenarios such as dividing two integers to obtain a `double`, for example, `3 / 2 = 1.5`, or calculating the average of a set of integers.

<!-- These produce false positives -->
<!-- markdownlint-disable MD038 -->
| Interface name                                     | Defined operators                        |
|----------------------------------------------------|------------------------------------------|
| <xref:System.Numerics.IAdditionOperators%603>      | `x + y`                                  |
| <xref:System.Numerics.IBitwiseOperators%603>       | `x & y`, 'x &#124; y', `x ^ y`, and `~x` |
| <xref:System.Numerics.IComparisonOperators%603>    | `x < y`, `x > y`, `x <= y`, and `x >= y` |
| <xref:System.Numerics.IDecrementOperators%601>     | `--x` and `x--`                          |
| <xref:System.Numerics.IDivisionOperators%603>      | `x / y`                                  |
| <xref:System.Numerics.IEqualityOperators%603>      | `x == y` and `x != y`                    |
| <xref:System.Numerics.IIncrementOperators%601>     | `++x` and `x++`                          |
| <xref:System.Numerics.IModulusOperators%603>       | `x % y`                                  |
| <xref:System.Numerics.IMultiplyOperators%603>      | `x * y`                                  |
| <xref:System.Numerics.IShiftOperators%603>         | `x << y` and `x >> y`                    |
| <xref:System.Numerics.ISubtractionOperators%603>   | `x - y`                                  |
| <xref:System.Numerics.IUnaryNegationOperators%602> | `-x`                                     |
| <xref:System.Numerics.IUnaryPlusOperators%602>     | `+x`                                     |
<!-- markdownlint-enable MD038 -->

> [!NOTE]
> Some of the interfaces define a checked operator in addition to a regular unchecked operator. Checked operators are called in checked contexts and allow a user-defined type to define overflow behavior. If you implement a checked operator, for example, <xref:System.Numerics.ISubtractionOperators%603.op_CheckedSubtraction(%600,%601)>, you must also implement the unchecked operator, for example, <xref:System.Numerics.ISubtractionOperators%603.op_Subtraction(%600,%601)>.

### Function interfaces

The function interfaces define common mathematical APIs that apply more broadly than to a specific [numeric interface](#numeric-interfaces). These interfaces are all implemented by <xref:System.Numerics.IFloatingPointIeee754%601>, and may get implemented by other relevant types in the future.

| Interface name                                     | Description                                                                                                              |
|----------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------|
| <xref:System.Numerics.IExponentialFunctions%601>   | Exposes exponential functions supporting `e^x`, `e^x - 1`, `2^x`, `2^x - 1`, `10^x`, and `10^x - 1`.                     |
| <xref:System.Numerics.IHyperbolicFunctions%601>    | Exposes hyperbolic functions supporting `acosh(x)`, `asinh(x)`, `atanh(x)`, `cosh(x)`, `sinh(x)`, and `tanh(x)`.         |
| <xref:System.Numerics.ILogarithmicFunctions%601>   | Exposes logarithmic functions supporting `ln(x)`, `ln(x + 1)`, `log2(x)`, `log2(x + 1)`, `log10(x)`, and `log10(x + 1)`. |
| <xref:System.Numerics.IPowerFunctions%601>         | Exposes power functions supporting `x^y`.                                                                                |
| <xref:System.Numerics.IRootFunctions%601>          | Exposes root functions supporting `cbrt(x)` and `sqrt(x)`.                                                               |
| <xref:System.Numerics.ITrigonometricFunctions%601> | Exposes trigonometric functions supporting `acos(x)`, `asin(x)`, `atan(x)`, `cos(x)`, `sin(x)`, and `tan(x)`.            |

### Parsing and formatting interfaces

Parsing and formatting are core concepts in programming. They're commonly used when converting user input to a given type or displaying a type to the user. These interfaces are in the <xref:System> namespace.

| Interface name                     | Description                                                                                      |
|------------------------------------|--------------------------------------------------------------------------------------------------|
| <xref:System.IParsable%601> | Exposes support for `T.Parse(string, IFormatProvider)` and `T.TryParse(string, IFormatProvider, out TSelf)`.  |
| <xref:System.ISpanParsable%601> | Exposes support for `T.Parse(ReadOnlySpan<char>, IFormatProvider)` and `T.TryParse(ReadOnlySpan<char>, IFormatProvider, out TSelf)`. |
| <xref:System.IFormattable><sup>1</sup> | Exposes support for `value.ToString(string, IFormatProvider)`. |
| <xref:System.ISpanFormattable><sup>1</sup> | Exposes support for `value.TryFormat(Span<char>, out int, ReadOnlySpan<char>, IFormatProvider)`. |

<sup>1</sup>This interface isn't new, nor is it generic. However, it's implemented by all number types and represents the inverse operation of `IParsable`.

For example, the following program takes two numbers as input, reading them from the console using a generic method where the type parameter is constrained to be <xref:System.IParsable%601>. It calculates the average using a generic method where the type parameters for the input and result values are constrained to be <xref:System.Numerics.INumber%601>, and then displays the result to the console.

```csharp
using System.Globalization;
using System.Numerics;

static TResult Average<T, TResult>(T first, T second)
    where T : INumber<T>
    where TResult : INumber<TResult>
{
    return TResult.CreateChecked( (first + second) / T.CreateChecked(2) );
}

static T ParseInvariant<T>(string s)
    where T : IParsable<T>
{
    return T.Parse(s, CultureInfo.InvariantCulture);
}

Console.Write("First number: ");
var left = ParseInvariant<float>(Console.ReadLine());

Console.Write("Second number: ");
var right = ParseInvariant<float>(Console.ReadLine());

Console.WriteLine($"Result: {Average<float, float>(left, right)}");

/* This code displays output similar to:

First number: 5.0
Second number: 6
Result: 5.5
*/
```

## See also

- [Generic math in .NET 7 (blog post)](https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/)
