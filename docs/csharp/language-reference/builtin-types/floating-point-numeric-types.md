---
title: "Floating-point numeric types - C# Reference"
description: "Overview of the built-in C# floating-point types"
ms.date: 06/30/2019
f1_keywords: 
  - "float"
  - "float_CSharpKeyword"
  - "double"
  - "double_CSharpKeyword"
  - "decimal_CSharpKeyword"
  - "decimal"
helpviewer_keywords: 
  - "floating-point numbers [C#]"
  - "ranges of floating-point types [C#]"
  - "types [C#], floating-point types"
  - "float keyword [C#]"
  - "floating-point numbers [C#], float keyword"
  - "double data type [C#]"
  - "decimal keyword [C#]"
---
# Floating-point types

The **floating-point types** are a subset of the **simple types** and can be initialized with [*literals*](#floating-point-literals). All floating-point types are also value types. All floating point numeric types support [arithmetic](../operators/arithmetic-operators.md) [comparison, and equality](../operators/equality-operators.md) operators.

The following table shows the precision and approximate ranges for the floating-point types.  
  
|Type|Approximate range|Precision|  
|----------|-----------------------|---------------|  
|`float`|±1.5 x 10<sup>−45</sup> to ±3.4 x 10<sup>38</sup>|~6-9 digits|  
|`double`|±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup>|~15-17 digits|  
|`decimal`|±1.0 x 10<sup>-28</sup> to ±7.9228 x 10<sup>28</sup>|28-29 digits|  

The default value for all floating-point types is `0`. Each of the floating-point types has constants named `MinValue` and `MaxValue` for the minimum and maximum value for that type. The `float` and `double` types have additional constants for `PositiveInfinity`, `NegativeInfinity`, and `NaN` (for "Not a Number"). The `decimal` type includes constants for `Zero`, `One`, and `MinusOne`.

The `decimal` type has more precision and a smaller range than both `float` and `double`, which makes it appropriate for financial and monetary calculations.

You can mix numeric integral types and floating-point types in an expression. In this case, the integral types are converted to floating-point types. The evaluation of the expression is performed according to the following rules:

- If one of the floating-point types is `double`, the expression evaluates to `double`, or to [bool](../keywords/bool.md) in relational comparisons or comparisons for equality.
- If there is no `double` type in the expression, the expression evaluates to `float`, or to [bool](../keywords/bool.md) in relational comparisons or comparisons for equality.

A floating-point expression can contain the following sets of values:

- Positive and negative zero
- Positive and negative infinity
- Not-a-Number value (NaN)
- The finite set of nonzero values

For more information about these values, see IEEE Standard for Binary Floating-Point Arithmetic, available on the [IEEE](https://www.ieee.org) website.

## floating point literals

By default, a real numeric literal on the right side of the assignment operator is treated as `double`. You can use suffixes to convert a literal to a specific type. 

- The `d` or `D` suffix converts an integral literal to a `double`.
- The `f` or `F` suffix converts a real or integral literal to a `float`.
- The `m` or `M` suffix converts a real or integral literal to a `decimal`.

The following examples show each suffix:

```csharp
double d = 3D;
d = 4d;
float f = 3.5F;
f = 5.4f;
decimal myMoney = 300.5m;
myMoney = 400.75M;
```

## Conversions

There's an implicit conversion (called a *widening conversion*) between any two floating-point types where the destination type can store all values of the source type. For example, there's an implicit conversion from `float` to `double` because the range of `float` values is a proper subset of `double`. 

You must use an explicit cast to convert one floating-point type to another floating-point type when an implicit conversion isn't defined from the source type to the destination type. This is called a *narrowing conversion*. The explicit case is required because the conversion can result in data loss. There's no implicit conversion between other floating-point types and the `decimal` type because the `decimal` type has greater precision than either `float` or `double`.

For more information about implicit numeric conversions, see [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table.md).

For more information about explicit numeric conversions, see [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table.md).

## Formatting decimal output

You can format the results by using the `String.Format` method, or through the <xref:System.Console.Write%2A?displayProperty=nameWithType> method, which calls `String.Format()`. The currency format is specified by using the standard currency format string "C" or "c,". For more information about the `String.Format` method, see <xref:System.String.Format%2A?displayProperty=nameWithType>.

## See also

- [C# Reference](../index.md)
- [Integral types](integral-numeric-types.md)
- [Default values table](../keywords/default-values-table.md)
- [Formatting numeric results table](../keywords/formatting-numeric-results-table.md)
- [Built-in types table](../keywords/built-in-types-table.md)
- [Numerics in .NET](../../../standard/numerics.md)
- [Casting and Type Conversions](../../programming-guide/types/casting-and-type-conversions.md)
- [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table.md)
- [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table.md)
- <xref:System.Single?displayProperty=nameWithType>
- <xref:System.Double?displayProperty=nameWithType>
- <xref:System.Decimal?displayProperty=nameWithType>
- <xref:System.Numerics.Complex?displayProperty=nameWithType>
- [Standard Numeric Format Strings](../../../standard/base-types/standard-numeric-format-strings.md)
