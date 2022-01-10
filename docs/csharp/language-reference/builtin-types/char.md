---
description: Learn about the built-in character type in C#
title: "char type - C# reference"
ms.date: 05/11/2020
f1_keywords:
  - "char"
  - "char_CSharpKeyword"
helpviewer_keywords:
  - "char data type [C#]"
ms.assetid: b51cf4fb-124c-4067-af48-afbac122b228
---
# char (C# reference)

The `char` type keyword is an alias for the .NET <xref:System.Char?displayProperty=nameWithType> structure type that represents a Unicode UTF-16 character.

|Type|Range|Size|.NET type|
|----------|-----------|----------|-------------------------|
|`char`|U+0000 to U+FFFF|16 bit|<xref:System.Char?displayProperty=nameWithType>|

The default value of the `char` type is `\0`, that is, U+0000.

The `char` type supports [comparison](../operators/comparison-operators.md), [equality](../operators/equality-operators.md), [increment](../operators/arithmetic-operators.md#increment-operator-), and [decrement](../operators/arithmetic-operators.md#decrement-operator---) operators. Moreover, for `char` operands, [arithmetic](../operators/arithmetic-operators.md) and [bitwise logical](../operators/bitwise-and-shift-operators.md) operators perform an operation on the corresponding character codes and produce the result of the `int` type.

The [string](reference-types.md#the-string-type) type represents text as a sequence of `char` values.

## Literals

You can specify a `char` value with:

- a character literal.
- a Unicode escape sequence, which is `\u` followed by the four-symbol hexadecimal representation of a character code.
- a hexadecimal escape sequence, which is `\x` followed by the hexadecimal representation of a character code.

[!code-csharp-interactive[char literals](snippets/shared/CharType.cs#Literals)]

As the preceding example shows, you can also cast the value of a character code into the corresponding `char` value.

> [!NOTE]
> In the case of a Unicode escape sequence, you must specify all four hexadecimal digits. That is, `\u006A` is a valid escape sequence, while `\u06A` and `\u6A` are not valid.
>
> In the case of a hexadecimal escape sequence, you can omit the leading zeros. That is, the `\x006A`, `\x06A`, and `\x6A` escape sequences are valid and correspond to the same character.

## Conversions

The `char` type is implicitly convertible to the following [integral](integral-numeric-types.md) types: `ushort`, `int`, `uint`, `long`, and `ulong`. It's also implicitly convertible to the built-in [floating-point](floating-point-numeric-types.md) numeric types: `float`, `double`, and `decimal`. It's explicitly convertible to `sbyte`, `byte`, and `short` integral types.

There are no implicit conversions from other types to the `char` type. However, any [integral](integral-numeric-types.md) or [floating-point](floating-point-numeric-types.md) numeric type is explicitly convertible to `char`.

## C# language specification

For more information, see the [Integral types](~/_csharpstandard/standard/types.md#936-integral-types) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# reference](../index.md)
- [Value types](value-types.md)
- [Strings](../../programming-guide/strings/index.md)
- <xref:System.Text.Rune?displayProperty=nameWithType>
- [Character encoding in .NET](../../../standard/base-types/character-encoding-introduction.md)
