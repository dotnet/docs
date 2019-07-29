---
title: "Integral numeric types - C# reference"
description: "Learn the range, storage size, and uses for each of the integral numeric types."
ms.date: 06/25/2019
f1_keywords:
  - "byte"
  - "byte_CSharpKeyword"
  - "sbyte_CSharpKeyword"
  - "sbyte"
  - "short"
  - "short_CSharpKeyword"
  - "ushort"
  - "ushort_CSharpKeyword"
  - "int_CSharpKeyword"
  - "int"
  - "uint"
  - "uint_CSharpKeyword"
  - "long_CSharpKeyword"
  - "long"
  - "ulong_CSharpKeyword"
  - "ulong"
helpviewer_keywords: 
  - "integral types, C#"
  - "Visual C#, integral types"
  - "types [C#], integral types"
  - "ranges of integral types [C#]"
  - "byte keyword [C#]"
  - "sbyte keyword [C#]"
  - "short keyword [C#]"
  - "ushort keyword [C#]"
  - "int keyword [C#]"
  - "uint keyword [C#]"
  - "long keyword [C#]"
  - "ulong keyword [C#]"
---
# Integral numeric types  (C# reference)

The **integral numeric types** are a subset of the **simple types** and can be initialized with [*literals*](#integral-literals). All integral types are also value types. All integral numeric types support [arithmetic](../operators/arithmetic-operators.md), [bitwise logical](../operators/bitwise-and-shift-operators.md), [comparison, and equality](../operators/equality-operators.md) operators.

## Characteristics of the integral types

C# supports the following predefined integral types:

|C# type/keyword|Range|Size|.NET type|
|----------|-----------|----------|-------------|
|`sbyte`|-128 to 127|Signed 8-bit integer|<xref:System.SByte?displayProperty=nameWithType>|
|`byte`|0 to 255|Unsigned 8-bit integer|<xref:System.Byte?displayProperty=nameWithType>|
|`short`|-32,768 to 32,767|Signed 16-bit integer|<xref:System.Int16?displayProperty=nameWithType>|
|`ushort`|0 to 65,535|Unsigned 16-bit integer|<xref:System.UInt16?displayProperty=nameWithType>|
|`int`|-2,147,483,648 to 2,147,483,647|Signed 32-bit integer|<xref:System.Int32?displayProperty=nameWithType>|
|`uint`|0 to 4,294,967,295|Unsigned 32-bit integer|<xref:System.UInt32?displayProperty=nameWithType>|
|`long`|-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|<xref:System.Int64?displayProperty=nameWithType>|
|`ulong`|0 to 18,446,744,073,709,551,615|Unsigned 64-bit integer|<xref:System.UInt64?displayProperty=nameWithType>|

In the preceding table, each C# type keyword from the leftmost column is an alias for the corresponding .NET type. They are interchangeable. For example, the following declarations declare variables of the same type:

```csharp
int a = 123;
System.Int32 b = 123;
```

The default value of each integral type is zero, `0`. Each of the integral types has the `MinValue` and `MaxValue` constants that provide the minimum and maximum value of that type.

Use the <xref:System.Numerics.BigInteger?displayProperty=nameWithType> structure to represent a signed integer with no upper or lower bounds.

## Integral literals

Integral literals can be specified as *decimal literals*, *hexadecimal literals*, or *binary literals*. An example of each is shown below:

```csharp
var decimalLiteral = 42;
var hexLiteral = 0x2A;
var binaryLiteral = 0b_0010_1010;
```

Decimal literals don't require any prefix. The `x` or `X` prefix signifies a *hexadecimal literal*. The `b` or `B` prefix signifies a *binary literal*. The declaration of `binaryLiteral` demonstrates the use of `_` as a *digit separator*. The digit separator can be used with all numeric literals. Binary literals and the digit separator `_` are supported starting with C# 7.0.

### Literal suffixes

The `l` or `L` suffix specifies that the integral literal should be of the `long` type. The `ul` or `UL` suffix specifies the `ulong` type. If the `L` suffix is used on a literal that is greater than 9,223,372,036,854,775,807 (the maximum value of `long`), the value is converted to the `ulong` type. If the value represented by an integral literal exceeds <xref:System.UInt64.MaxValue?displayProperty=nameWithType>, a compiler error [CS1021](../../misc/cs1021.md) occurs. 

> [!NOTE]
> You can use the lowercase letter "l" as a suffix. However, this generates a compiler warning because the letter "l" is easily confused with the digit "1." Use "L" for clarity.

### Type of an integral literal

If an integral literal has no suffix, its type is the first of the following types in which its value can be represented:

1. `int`
1. `uint`
1. `long`
1. `ulong`

You can convert an integral literal to a type with a smaller range than the default using either an assignment or a cast:

```csharp
byte byteVariable = 42; // type is byte
var signedByte = (sbyte)42; // type is sbyte.
```

You can convert an integral literal to a type with a larger range than the default using either assignment, a cast, or a suffix on the literal:

```csharp
var unsignedLong = 42UL;
var longVariable = 42L;
ulong anotherUnsignedLong = 42;
var anotherLong = (long)42;
```

## Conversions

There's an implicit conversion (called a *widening conversion*) between any two integral types where the destination type can store all values of the source type. For example, there's an implicit conversion from `int` to `long` because the range of `int` values is a proper subset of `long`. There are implicit conversions from a smaller unsigned integral type to a larger signed integral type. There's also an implicit conversion from any integral type to any floating-point type.  There's no implicit conversion from any signed integral type to any unsigned integral type.

You must use an explicit cast to convert one integral type to another integral type when an implicit conversion is not defined from the source type to the destination type. This is called a *narrowing conversion*. The explicit case is required because the conversion can result in data loss.

## See also

- [C# language specification - Integral types](~/_csharplang/spec/types.md#integral-types)
- [C# reference](../index.md)
- [Floating-point types](floating-point-numeric-types.md)
- [Default values table](../keywords/default-values-table.md)
- [Formatting numeric results table](../keywords/formatting-numeric-results-table.md)
- [Built-in types table](../keywords/built-in-types-table.md)
- [Numerics in .NET](../../../standard/numerics.md)
