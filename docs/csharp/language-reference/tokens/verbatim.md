---
description: "@ - C# Reference"
title: "@ - C# Reference"
ms.date: 02/09/2017
f1_keywords: 
  - "@_CSharpKeyword"
  - "@"
helpviewer_keywords: 
  - "@ special character [C#]"
  - "@ language element [C#]"
ms.assetid: 89bc7e53-85f5-478a-866d-1cca003c4e8c
---
# @ (C# Reference)

The `@` special character serves as a verbatim identifier. It can be used in the following ways:

1. To enable C# keywords to be used as identifiers. The `@` character prefixes a code element that the compiler is to interpret as an identifier rather than a C# keyword. The following example uses the `@` character to define an identifier named `for` that it uses in a `for` loop.

   [!code-csharp[verbatim1](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#1)]

1. To indicate that a string literal is to be interpreted verbatim. The `@` character in this instance defines a *verbatim string literal*. Simple escape sequences (such as `"\\"` for a backslash), hexadecimal escape sequences (such as `"\x0041"` for an uppercase A), and Unicode escape sequences (such as `"\u0041"` for an uppercase A) are interpreted literally. Only a quote escape sequence (`""`) is not interpreted literally; it produces one double quotation mark. Additionally, in case of a verbatim [interpolated string](interpolated.md) brace escape sequences (`{{` and `}}`) are not interpreted literally; they produce single brace characters. The following example defines two identical file paths, one by using a regular string literal and the other by using a verbatim string literal. This is one of the more common uses of verbatim string literals.

   [!code-csharp[verbatim2](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#2)]

   The following example illustrates the effect of defining a regular string literal and a verbatim string literal that contain identical character sequences.

   [!code-csharp[verbatim3](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#3)]

1. To enable the compiler to distinguish between attributes in cases of a naming conflict. An attribute is a class that derives from <xref:System.Attribute>. Its type name typically includes the suffix **Attribute**, although the compiler does not enforce this convention. The attribute can then be referenced in code either by its full type name (for example, `[InfoAttribute]` or its shortened name (for example, `[Info]`). However, a naming conflict occurs if two shortened attribute type names are identical, and one type name includes the **Attribute** suffix but the other does not. For example, the following code fails to compile because the compiler cannot determine whether the `Info` or `InfoAttribute` attribute is applied to the `Example` class. See [CS1614](../compiler-messages/cs1614.md) for more information.

   [!code-csharp[verbatim4](../../../../samples/snippets/csharp/language-reference/keywords/verbatim2.cs#1)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Special Characters](./index.md)
