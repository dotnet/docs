---
title: "Integral numeric types - C# Reference"
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
# Integral types  (C# Reference)

The **integral types** are a subset of the **numeric types**. The **numeric types** are a subset of the **simple types**. The integral types are all value types, and generally follow the mathematical rules for integer types. All integral types can be initialized by *literal constants*, for example "24".

## Sizes and ranges

The following table shows the sizes and ranges of the integral types:

|Type|Range|Size|  
|----------|-----------|----------|  
|`sbyte`|-128 to 127|Signed 8-bit integer|  
|`byte`|0 to 255|Unsigned 8-bit integer|  
|`short`|-32,768 to 32,767|Signed 16-bit integer|  
|`ushort`|0 to 65,535|Unsigned 16-bit integer|  
|`int`|-2,147,483,648 to 2,147,483,647|Signed 32-bit integer|  
|`uint`|0 to 4,294,967,295|Unsigned 32-bit integer|  
|`long`|-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807|Signed 64-bit integer|  
|`ulong`|0 to 18,446,744,073,709,551,615|Unsigned 64-bit integer|  

The default value for all integral types is `0`. Each of the integral types has constants named `MinValue` and `MaxValue` for the minimum and maximum value for that type.

## Integral literals

Integral literals can be specified as *decimal literals*, *hexadecimal literals*, or *binary literals*. An example of each is shown below:

```csharp
var decimalLiteral = 42
var hexLiteral = 0x2A;
var binaryLiteral = 0b_0010_1010;
```

Decimal literals do not require any prefix. The `x` or `X` prefix signifies a *hexadecimal literal*. The `b` or `B` prefix signifies a *binary literal*.  The declarations of `binaryLiteral` demonstrates the use of `_` as a digit separator.

## Types to an integer literal

If an integer literal has no suffix, its type is the first of the following types in which its value can be represented:

1. `int`
1. `uint`
1. `long`
1. `ulong`

You can force an integral literal to a type with a smaller range than the default using either an assignment or a cast:

```csharp
byte byteVariable = 42; // type is byte
var signedByte = (sbyte)42; // type is sbyte.
```

You can force an integral literal to a type with a larger range than the default using either assignment, a cast, or a suffix on the literal:

```csharp
var unsignedLong = 42UL;
var longVariable = 42L;
ulong anotherUnsignedLong = 42;
var anotherLong = (long)42;
```

The `l` or `L` suffix specifies that the integer literal should a `long`. The `ul` or `UL` suffix specifies a `ulong` type. If the `L` suffix is used on a literal that is larger than 9,223,372,036,854,775,807 (the maximum value of a `long`), the value is a `ulong`.

> [!NOTE]
> You can use the lowercase letter "l" as a suffix. However, this generates a compiler warning because the letter "l" is easily confused with the digit "1." Use "L" for clarity.

## Conversions

There is an implicit conversion (called a *widening conversion*) between any two integral types where the destination type can store all values of the source type. For example, there is an implicit conversion from `int` to `long` because the range of `int` values is a proper subset of `long`. There is no implicit conversion from any signed integral type to any unsigned integral type. There are implicit conversions from a smaller unsigned integral type to a larger signed integral type. There is also an implicit conversion from any integral type to any floating point type.

You must use an explict cast to convert one integral type to another integral type when an implicit conversion is not defined from the source type to the destination type.

If the value represented by an integer literal exceeds <xref:System.UInt64.MaxValue?displayProperty=nameWithType>, a compiler error [CS1021](../../misc/cs1021.md) occurs.

Use the <xref:System.Numerics.BigInteger?displayProperty=nameWithType> structure to represent an arbitrarily large signed integer.

OTHER TASKS:

1. incorporate implicit and explicit conversion tables.
1. Consider related "table" consolidation.

## See also

- [C# Language Specification - Integral types](~/_csharplang/spec/types.md#integral-types.md)
- [C# Reference](../index.md)
- [C# Keywords](index.md)
- [Floating-point types table](floating-point-types-table.md)
- [Default values table](default-values-table.md)
- [Formatting numeric results table](formatting-numeric-results-table.md)
- [Built-in types table](built-in-types-table.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Numerics in .NET](../../../standard/numerics.md)
