---
description: "Verbatim text using the `@` enables C# keywords to be used as identifiers, or indicates that a string literal should be interpreted verbatim, or to distinguish attribute names"
title: "Verbatim text and strings - @"
ms.date: 11/29/2022
f1_keywords: 
  - "@_CSharpKeyword"
  - "@"
helpviewer_keywords: 
  - "@ special character [C#]"
  - "@ language element [C#]"
---
# Verbatim text - `@` in variables, attributes, and string literals

The `@` special character serves as a verbatim identifier. You use it in the following ways:

1. To indicate that a string literal is to be interpreted verbatim. The `@` character in this instance defines a *verbatim string literal*. Simple escape sequences (such as `"\\"` for a backslash), hexadecimal escape sequences (such as `"\x0041"` for an uppercase A), and Unicode escape sequences (such as `"\u0041"` for an uppercase A) are interpreted literally. Only a quote escape sequence (`""`) isn't interpreted literally; it produces one double quotation mark. Additionally, in case of a verbatim [interpolated string](interpolated.md) brace escape sequences (`{{` and `}}`) aren't interpreted literally; they produce single brace characters. The following example defines two identical file paths, one by using a regular string literal and the other by using a verbatim string literal. This is one of the more common uses of verbatim string literals.

   [!code-csharp[verbatim2](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#2)]

   The following example illustrates the effect of defining a regular string literal and a verbatim string literal that contain identical character sequences.

   [!code-csharp[verbatim3](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#3)]

1. To use C# keywords as identifiers. The `@` character prefixes a code element that the compiler is to interpret as an identifier rather than a C# keyword. The following example uses the `@` character to define an identifier named `for` that it uses in a `for` loop.

   [!code-csharp[verbatim1](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#1)]

1. To enable the compiler to distinguish between attributes in cases of a naming conflict. An attribute is a class that derives from <xref:System.Attribute>. Its type name typically includes the suffix **Attribute**, although the compiler doesn't enforce this convention. The attribute can then be referenced in code either by its full type name (for example, `[InfoAttribute]` or its shortened name (for example, `[Info]`). However, a naming conflict occurs if two shortened attribute type names are identical, and one type name includes the **Attribute** suffix but the other doesn't. For example, the following code fails to compile because the compiler can't determine whether the `Info` or `InfoAttribute` attribute is applied to the `Example` class. For more information, see [CS1614](../compiler-messages/cs1614.md).

   [!code-csharp[verbatim4](../../../../samples/snippets/csharp/language-reference/keywords/verbatim2.cs#1)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Special Characters](./index.md)
