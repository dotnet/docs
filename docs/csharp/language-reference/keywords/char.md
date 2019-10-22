---
title: "char keyword - C# reference"
ms.custom: seodec18
ms.date: 10/22/2019
f1_keywords:
  - "char"
  - "char_CSharpKeyword"
helpviewer_keywords:
  - "char data type [C#]"
ms.assetid: b51cf4fb-124c-4067-af48-afbac122b228
---
# char (C# reference)

The `char` type keyword is an alias for the .NET <xref:System.Char?displayProperty=nameWithType> structure type that represents a Unicode UTF-16 character:

|Type|Range|Size|.NET type|
|----------|-----------|----------|-------------------------|
|`char`|U+0000 to U+FFFF|16 bit|<xref:System.Char?displayProperty=nameWithType>|

## Literals

Constants of the `char` type can be written as character literals, hexadecimal escape sequence, or Unicode representation. You can also cast an integral character code into the corresponding `char` value. In the following example, the four elements of an array of `char` are initialized with the same character `X`:

[!code-csharp[csrefKeywordsTypes#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#19)]

## Conversions

The `char` type is implicitly convertible to the following [integral](../builtin-types/integral-numeric-types.md) types: `ushort`, `int`, `uint`, `long`, and `ulong`. It's also implicitly convertible to the built-in [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types: `float`, `double`, and `decimal`. It's explicitly convertible to `sbyte`, `byte`, and `short` integral types.

There are no implicit conversions from other types to the `char` type. However, any [integral](../builtin-types/integral-numeric-types.md) or [floating-point](../builtin-types/floating-point-numeric-types.md) numeric type is explicitly convertible to `char`.

## C# language specification

For more information, see the [Integral types](~/_csharplang/spec/types.md#integral-types) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# keywords](./index.md)
- [Built-in types table](./built-in-types-table.md)
- [Strings](../../programming-guide/strings/index.md)
- <xref:System.Char?displayProperty=nameWithType>
