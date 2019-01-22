---
title: "double keyword - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "double"
  - "double_CSharpKeyword"
helpviewer_keywords: 
  - "double data type [C#]"
ms.assetid: 0980e11b-6004-4102-abcf-cfc280fc6991
---
# double (C# Reference)

The `double` keyword signifies a simple type that stores 64-bit floating-point values. The following table shows the precision and approximate range for the `double` type.

|Type|Approximate range|Precision|.NET type|
|----------|-----------------------|---------------|-------------------------|
|`double`|±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup>|~15-17 digits|<xref:System.Double?displayProperty=nameWithType>|

## Literals

By default, a real numeric literal on the right side of the assignment operator is treated as `double`. However, if you want an integer number to be treated as `double`, use the suffix d or D, for example:

```csharp
double x = 3D;
```

## Conversions

You can mix numeric integral types and floating-point types in an expression. In this case, the integral types are converted to floating-point types. The evaluation of the expression is performed according to the following rules:

- If one of the floating-point types is `double`, the expression evaluates to `double`, or to [bool](../../../csharp/language-reference/keywords/bool.md) in relational comparisons and comparisons for equality.

- If there is no `double` type in the expression, it evaluates to [float](../../../csharp/language-reference/keywords/float.md), or to [bool](../../../csharp/language-reference/keywords/bool.md) in relational comparisons and comparisons for equality.

 A floating-point expression can contain the following sets of values:

- Positive and negative zero.

- Positive and negative infinity.

- Not-a-Number value (NaN).

- The finite set of nonzero values.

For more information about these values, see IEEE Standard for Binary Floating-Point Arithmetic, available on the [IEEE](https://www.ieee.org) Web site.

## Example

In the following example, an [int](../../../csharp/language-reference/keywords/int.md), a [short](../../../csharp/language-reference/keywords/short.md), a [float](../../../csharp/language-reference/keywords/float.md), and a `double` are added together giving a `double` result.

[!code-csharp[csrefKeywordsTypes#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#9)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
- [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md)  
- [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
- [Floating-Point Types Table](../../../csharp/language-reference/keywords/floating-point-types-table.md)  
- [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
- [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)  
