---
description: Learn about the built-in character type in C#
title: "The char type"
ms.date: 01/14/2026
f1_keywords:
  - "char"
  - "char_CSharpKeyword"
helpviewer_keywords:
  - "char data type [C#]"
---
# char (C# reference)

The `char` type keyword is an alias for the .NET <xref:System.Char?displayProperty=nameWithType> structure type. It represents a Unicode UTF-16 code unit, typically a UTF-16 character.

| Type   | Range            | Size   | .NET type                                       |
|--------|------------------|--------|-------------------------------------------------|
| `char` | U+0000 to U+FFFF | 16 bit | <xref:System.Char?displayProperty=nameWithType> |

The default value of the `char` type is `\0`, which is U+0000.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The `char` type supports [comparison](../operators/comparison-operators.md), [equality](../operators/equality-operators.md), [increment](../operators/arithmetic-operators.md#increment-operator-), and [decrement](../operators/arithmetic-operators.md#decrement-operator---) operators. For `char` operands, [arithmetic](../operators/arithmetic-operators.md) and [bitwise logical](../operators/bitwise-and-shift-operators.md) operators perform an operation on the corresponding code points and produce the result as an `int` value.

The [string](reference-types.md#the-string-type) type represents text as a sequence of `char` values.

## Literals

You can specify a `char` value by using:

- a character literal.
- a Unicode escape sequence, which is `\u` followed by the four-symbol hexadecimal representation of a character code.
- a hexadecimal escape sequence, which is `\x` followed by the hexadecimal representation of a character code.

:::code language="csharp" source="snippets/shared/CharType.cs" id="Literals":::

As the preceding example shows, you can also cast the value of a character code into the corresponding `char` value.

> [!NOTE]
> In a Unicode escape sequence, you must specify all four hexadecimal digits. That is, `\u006A` is a valid escape sequence, while `\u06A` and `\u6A` are invalid.
>
> In a hexadecimal escape sequence, you can omit the leading zeros. That is, the `\x006A`, `\x06A`, and `\x6A` escape sequences are valid and correspond to the same character.

## Conversions

The `char` type implicitly converts to the following [integral](integral-numeric-types.md) types: `ushort`, `int`, `uint`, `long`, `ulong`, `nint`, and `nuint`. It also implicitly converts to the built-in [floating-point](floating-point-numeric-types.md) numeric types: `float`, `double`, and `decimal`. It explicitly converts to `sbyte`, `byte`, and `short` integral types.

No implicit conversions exist from other types to the `char` type. However, you can explicitly convert any [integral](integral-numeric-types.md) or [floating-point](floating-point-numeric-types.md) numeric type to `char`.

## C# language specification

For more information, see the [Integral types](~/_csharpstandard/standard/types.md#836-integral-types) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Value types](value-types.md)
- [Strings](../../programming-guide/strings/index.md)
- <xref:System.Text.Rune?displayProperty=nameWithType>
- [Character encoding in .NET](../../../standard/base-types/character-encoding-introduction.md)
