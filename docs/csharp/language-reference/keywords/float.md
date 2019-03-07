---
title: "float keyword - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "float"
  - "float_CSharpKeyword"
helpviewer_keywords: 
  - "float keyword [C#]"
  - "floating-point numbers [C#], float keyword"
ms.assetid: 1e77db7b-dedb-48b7-8dd1-b055e96a9258
---
# float (C# Reference)

The `float` keyword signifies a simple type that stores 32-bit floating-point values. The following table shows the precision and approximate range for the `float` type.

|Type|Approximate range|Precision|.NET type|  
|----------|-----------------------|---------------|-------------------------|  
|`float`|±1.5 x 10<sup>−45</sup> to ±3.4 x 10<sup>38</sup>|~6-9 digits|<xref:System.Single?displayProperty=nameWithType>|  

## Literals

By default, a real numeric literal on the right side of the assignment operator is treated as [double](double.md). Therefore, to initialize a float variable, use the suffix `f` or `F`, as in the following example:

```csharp
float x = 3.5F;
```

If you do not use the suffix in the previous declaration, you will get a compilation error because you are trying to store a [double](double.md) value into a `float` variable.

## Conversions

You can mix numeric integral types and floating-point types in an expression. In this case, the integral types are converted to floating-point types. The evaluation of the expression is performed according to the following rules:

- If one of the floating-point types is [double](double.md), the expression evaluates to [double](double.md), or to [bool](bool.md) in relational comparisons or comparisons for equality.

- If there is no [double](double.md) type in the expression, the expression evaluates to `float`, or to [bool](bool.md) in relational comparisons or comparisons for equality.

A floating-point expression can contain the following sets of values:

- Positive and negative zero

- Positive and negative infinity

- Not-a-Number value (NaN)

- The finite set of nonzero values

For more information about these values, see IEEE Standard for Binary Floating-Point Arithmetic, available on the [IEEE](https://www.ieee.org) website.

## Example

In the following example, an [int](int.md), a [short](short.md), and a `float` are included in a mathematical expression giving a `float` result. (Remember that `float` is an alias for the <xref:System.Single?displayProperty=nameWithType> type.) Notice that there is no [double](double.md) in the expression.

[!code-csharp[csrefKeywordsTypes#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#13)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Single>
- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Casting and Type Conversions](../../programming-guide/types/casting-and-type-conversions.md)
- [C# Keywords](index.md)
- [Integral Types Table](integral-types-table.md)
- [Built-In Types Table](built-in-types-table.md)
- [Implicit Numeric Conversions Table](implicit-numeric-conversions-table.md)
- [Explicit Numeric Conversions Table](explicit-numeric-conversions-table.md)
