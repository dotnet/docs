---
description: "Verbatim text using the `@` enables C# keywords to be used as identifiers, or indicates that a string literal should be interpreted verbatim, or to distinguish attribute names"
title: "Verbatim text and strings - @"
ms.date: 01/14/2026
f1_keywords: 
  - "@_CSharpKeyword"
  - "@"
helpviewer_keywords: 
  - "@ special character [C#]"
  - "@ language element [C#]"
---
# Verbatim text - `@` in variables, attributes, and string literals

The `@` special character serves as a verbatim identifier. Use it in the following ways:

1. To indicate that a string literal is to be interpreted verbatim. The `@` character in this instance defines a *verbatim string literal*. Simple escape sequences (such as `"\\"` for a backslash), hexadecimal escape sequences (such as `"\x0041"` for an uppercase A), and Unicode escape sequences (such as `"\u0041"` for an uppercase A) are interpreted literally. Only a quote escape sequence (`""`) isn't interpreted literally; it produces one double quotation mark. Additionally, in case of a verbatim [interpolated string](interpolated.md) brace escape sequences (`{{` and `}}`) aren't interpreted literally; they produce single brace characters. The following example defines two identical file paths, one by using a regular string literal and the other by using a verbatim string literal. This is one of the more common uses of verbatim string literals.

   :::code language="csharp" source="../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs" id="2":::

   The following example illustrates the effect of defining a regular string literal and a verbatim string literal that contain identical character sequences.

   :::code language="csharp" source="../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs" id="3":::

1. To use C# keywords as identifiers. The `@` character prefixes a code element that the compiler interprets as an identifier rather than a C# keyword. The following example uses the `@` character to define an identifier named `for` that it uses in a `for` loop.

   :::code language="csharp" source="../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs" id="1":::

1. To enable the compiler to distinguish between attributes in cases of a naming conflict. An attribute is a class that derives from <xref:System.Attribute>. Its type name typically includes the suffix **Attribute**, although the compiler doesn't enforce this convention. You can reference the attribute in code either by its full type name (for example, `[InfoAttribute]`) or by its shortened name (for example, `[Info]`). However, a naming conflict occurs if two shortened attribute type names are identical, and one type name includes the **Attribute** suffix but the other doesn't. For example, the following code fails to compile because the compiler can't determine whether the `Info` or `InfoAttribute` attribute is applied to the `Example` class. For more information, see [CS1614](../compiler-messages/attribute-usage-errors.md#attribute-class-requirements).

   :::code language="csharp" source="../../../../samples/snippets/csharp/language-reference/keywords/verbatim2.cs" id="1":::

## See also

- [C# Special Characters](./index.md)
