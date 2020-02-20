---
title: "Built-in numeric conversions - C# reference"
ms.date: 10/22/2019
helpviewer_keywords: 
  - "implicit numeric conversions [C#]"
  - "explicit numeric conversion [C#]"
  - "numeric conversions [C#], implicit"
  - "numeric conversions [C#], explicit"
  - "conversions [C#], implicit numeric"
  - "conversions [C#], explicit numeric"
---
# Built-in numeric conversions (C# reference)

C# provides a set of [integral](integral-numeric-types.md) and [floating-point](floating-point-numeric-types.md) numeric types. There exists a conversion between any two numeric types, either implicit or explicit. You must use the [cast operator `()`](../operators/type-testing-and-cast.md#cast-operator-) to invoke an explicit conversion.

## Implicit numeric conversions

The following table shows the predefined implicit conversions between the built-in numeric types:

|From|To|
|----------|--------|
|[sbyte](integral-numeric-types.md)|`short`, `int`, `long`, `float`, `double`, or `decimal`|
|[byte](integral-numeric-types.md)|`short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|
|[short](integral-numeric-types.md)|`int`, `long`, `float`, `double`, or `decimal`|
|[ushort](integral-numeric-types.md)|`int`, `uint`, `long`, `ulong`, `float`, `double`, or `decimal`|
|[int](integral-numeric-types.md)|`long`, `float`, `double`, or `decimal`|
|[uint](integral-numeric-types.md)|`long`, `ulong`, `float`, `double`, or `decimal`|
|[long](integral-numeric-types.md)|`float`, `double`, or `decimal`|
|[ulong](integral-numeric-types.md)|`float`, `double`, or `decimal`|
|[float](floating-point-numeric-types.md)|`double`|

> [!NOTE]
> The implicit conversions from `int`, `uint`, `long`, or `ulong` to `float` and from `long` or `ulong` to `double` may cause a loss of precision, but never a loss of an order of magnitude. The other implicit numeric conversions never lose any information.

Also note that

- Any [integral numeric type](integral-numeric-types.md) is implicitly convertible to any [floating-point numeric type](floating-point-numeric-types.md).

- There are no implicit conversions to the `byte` and `sbyte` types. There are no implicit conversions from the `double` and `decimal` types.

- There are no implicit conversions between the `decimal` type and the `float` or `double` types.

- A value of a constant expression of type `int` (for example, a value represented by an integer literal) can be implicitly converted to `sbyte`, `byte`, `short`, `ushort`, `uint`, or `ulong`, if it's within the range of the destination type:

  ```csharp
  byte a = 13;
  byte b = 300;  // CS0031: Constant value '300' cannot be converted to a 'byte'
  ```

  As the preceding example shows, if the constant value is not within the range of the destination type, a compiler error [CS0031](../../misc/cs0031.md) occurs.

## Explicit numeric conversions

The following table shows the predefined explicit conversions between the built-in numeric types for which there is no [implicit conversion](#implicit-numeric-conversions):

|From|To|
|----------|--------|
|[sbyte](integral-numeric-types.md)|`byte`, `ushort`, `uint`, or `ulong`|
|[byte](integral-numeric-types.md)|`sbyte`|
|[short](integral-numeric-types.md)|`sbyte`, `byte`, `ushort`, `uint`, or `ulong`|
|[ushort](integral-numeric-types.md)|`sbyte`, `byte`, or `short`|
|[int](integral-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `uint`, or `ulong`|
|[uint](integral-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, or `int`|
|[long](integral-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, or `ulong`|
|[ulong](integral-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, or `long`|
|[float](floating-point-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, or `decimal`|
|[double](floating-point-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, or `decimal`|
|[decimal](floating-point-numeric-types.md)|`sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, or `double`|

> [!NOTE]
> An explicit numeric conversion might result in data loss or throw an exception, typically an <xref:System.OverflowException>.

Also note that

- When you convert a value of an integral type to another integral type, the result depends on the overflow [checking context](../keywords/checked-and-unchecked.md). In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an <xref:System.OverflowException> is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:

  - If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.

  - If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it's of the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.

  - If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.

- When you convert a `decimal` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, an <xref:System.OverflowException> is thrown.

- When you convert a `double` or `float` value to an integral type, this value is rounded towards zero to the nearest integral value. If the resulting integral value is outside the range of the destination type, the result depends on the overflow [checking context](../keywords/checked-and-unchecked.md). In a checked context, an <xref:System.OverflowException> is thrown, while in an unchecked context, the result is an unspecified value of the destination type.

- When you convert `double` to `float`, the `double` value is rounded to the nearest `float` value. If the `double` value is too small or too large to fit into the `float` type, the result is zero or infinity.

- When you convert `float` or `double` to `decimal`, the source value is converted to `decimal` representation and rounded to the nearest number after the 28th decimal place if required. Depending on the value of the source value, one of the following results may occur:

  - If the source value is too small to be represented as a `decimal`, the result becomes zero.

  - If the source value is NaN (not a number), infinity, or too large to be represented as a `decimal`, an <xref:System.OverflowException> is thrown.

- When you convert `decimal` to `float` or `double`, the source value is rounded to the nearest `float` or `double` value, respectively.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Implicit numeric conversions](~/_csharplang/spec/conversions.md#implicit-numeric-conversions)
- [Explicit numeric conversions](~/_csharplang/spec/conversions.md#explicit-numeric-conversions)

## See also

- [C# reference](../index.md)
- [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md)
