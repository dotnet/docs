---
title: "Floating-point numeric types - C# reference"
description: "Learn about the built-in C# floating-point types: float, double, and decimal"
ms.date: 02/04/2021
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
  - "size of floating-point types [C#]"
  - "types [C#], floating-point types"
  - "float keyword [C#]"
  - "floating-point numbers [C#], float keyword"
  - "double data type [C#]"
  - "decimal keyword [C#]"
---
# Floating-point numeric types (C# reference)

The *floating-point numeric types* represent real numbers. All floating-point numeric types are [value types](value-types.md). They are also [simple types](value-types.md#built-in-value-types) and can be initialized with [literals](#real-literals). All floating-point numeric types support [arithmetic](../operators/arithmetic-operators.md), [comparison](../operators/comparison-operators.md), and [equality](../operators/equality-operators.md) operators.

## Characteristics of the floating-point types

C# supports the following predefined floating-point types:
  
|C# type/keyword|Approximate range|Precision|Size|.NET type|
|----------|-----------------------|---------------|--------------|--------------|
|`float`|±1.5 x 10<sup>−45</sup> to ±3.4 x 10<sup>38</sup>|~6-9 digits|4 bytes|<xref:System.Single?displayProperty=nameWithType>|
|`double`|±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup>|~15-17 digits|8 bytes|<xref:System.Double?displayProperty=nameWithType>|
|`decimal`|±1.0 x 10<sup>-28</sup> to ±7.9228 x 10<sup>28</sup>|28-29 digits|16 bytes|<xref:System.Decimal?displayProperty=nameWithType>|

In the preceding table, each C# type keyword from the leftmost column is an alias for the corresponding .NET type. They are interchangeable. For example, the following declarations declare variables of the same type:

```csharp
double a = 12.3;
System.Double b = 12.3;
```

The default value of each floating-point type is zero, `0`. Each of the floating-point types has the `MinValue` and `MaxValue` constants that provide the minimum and maximum finite value of that type. The `float` and `double` types also provide constants that represent not-a-number and infinity values. For example, the `double` type provides the following constants: <xref:System.Double.NaN?displayProperty=nameWithType>, <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>, and <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.

The `decimal` type is appropriate when the required degree of precision is determined by the number of digits to the right of the decimal point. Such numbers are commonly used in financial applications, for currency amounts (for example, $1.00), interest rates (for example, 2.625%), and so forth. Even numbers that are precise to only one decimal digit are handled more accurately by the `decimal` type: 0.1, for example, can be exactly represented by a `decimal` instance, while there's no `double` or `float` instance that exactly represents 0.1. Because of this difference in numeric types, unexpected rounding errors can occur in arithmetic calculations when you use `double` or `float` for decimal data. You can use `double` instead of `decimal` when optimizing performance is more important than ensuring accuracy. However, any difference in performance would go unnoticed by all but the most calculation-intensive applications. Another possible reason to avoid `decimal` is to minimize storage requirements. For example, [ML.NET](../../../machine-learning/how-does-mldotnet-work.md) uses `float` because the difference between 4 bytes and 16 bytes adds up for very large data sets. For more information, see <xref:System.Decimal?displayProperty=nameWithType>.

You can mix [integral](integral-numeric-types.md) types and the `float` and `double` types in an expression. In this case, integral types are implicitly converted to one of the floating-point types and, if necessary, the `float` type is implicitly converted to `double`. The expression is evaluated as follows:

- If there is `double` type in the expression, the expression evaluates to `double`, or to [`bool`](bool.md) in relational and equality comparisons.
- If there is no `double` type in the expression, the expression evaluates to `float`, or to `bool` in relational and equality comparisons.

You can also mix integral types and the `decimal` type in an expression. In this case, integral types are implicitly converted to the `decimal` type and the expression evaluates to `decimal`, or to `bool` in relational and equality comparisons.

You cannot mix the `decimal` type with the `float` and `double` types in an expression. In this case, if you want to perform arithmetic, comparison, or equality operations, you must explicitly convert the operands either from or to the `decimal` type, as the following example shows:

```csharp-interactive
double a = 1.0;
decimal b = 2.1m;
Console.WriteLine(a + (double)b);
Console.WriteLine((decimal)a + b);
```

You can use either [standard numeric format strings](../../../standard/base-types/standard-numeric-format-strings.md) or [custom numeric format strings](../../../standard/base-types/custom-numeric-format-strings.md) to format a floating-point value.

## Real literals

The type of a real literal is determined by its suffix as follows:

- The literal without suffix or with the `d` or `D` suffix is of type `double`
- The literal with the `f` or `F` suffix is of type `float`
- The literal with the `m` or `M` suffix is of type `decimal`

The following code demonstrates an example of each:

```csharp
double d = 3D;
d = 4d;
d = 3.934_001;

float f = 3_000.5F;
f = 5.4f;

decimal myMoney = 3_000.5m;
myMoney = 400.75M;
```

The preceding example also shows the use of `_` as a *digit separator*, which is supported starting with C# 7.0. You can use the digit separator with all kinds of numeric literals.

You can also use scientific notation, that is, specify an exponent part of a real literal, as the following example shows:

```csharp-interactive
double d = 0.42e2;
Console.WriteLine(d);  // output 42

float f = 134.45E-2f;
Console.WriteLine(f);  // output: 1.3445

decimal m = 1.5E6m;
Console.WriteLine(m);  // output: 1500000
```

## Conversions

There is only one implicit conversion between floating-point numeric types: from `float` to `double`. However, you can convert any floating-point type to any other floating-point type with the [explicit cast](../operators/type-testing-and-cast.md#cast-expression). For more information, see [Built-in numeric conversions](numeric-conversions.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Floating-point types](~/_csharpstandard/standard/types.md#937-floating-point-types)
- [The decimal type](~/_csharpstandard/standard/types.md#938-the-decimal-type)
- [Real literals](~/_csharpstandard/standard/lexical-structure.md#7454-real-literals)

## See also

- [C# reference](../index.md)
- [Value types](value-types.md)
- [Integral types](integral-numeric-types.md)
- [Standard numeric format strings](../../../standard/base-types/standard-numeric-format-strings.md)
- [Numerics in .NET](../../../standard/numerics.md)
- <xref:System.Numerics.Complex?displayProperty=nameWithType>
