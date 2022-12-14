---
description: "Raw string literals can contain any arbitrary text without the need for special escape sequences.You begin and end a raw string literal with a minimum of three double-quote characters."
title: "Raw string literals - \"\"\""
f1_keywords: 
  - "RawStringLiteral_CSharpKeyword"
ms.date: 12/08/2022
---
# Raw string literal text - `"""` in string literals

A raw string literal starts and ends with a minimum of three double quote (`"`) characters:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="SingleLine":::

Raw string literals can span multiple lines:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="MultiLine":::

The following rules govern the interpretation of a multi-line raw string literal:

- Both opening and closing quote characters must be on their own line.
- Any whitespace to the left of the closing quotes is removed from all lines of the raw string literal.
- Whitespace following the opening quote on the same line is ignored.
- Whitespace only lines following the opening quote are included in the string literal.

You may need to create a raw string literal that has three or more consecutive double-quote characters. Raw string literals can start and end with a sequence of at least three double-quote characters. When your string literal contains three consecutive double-quotes, you start and end the raw string literal with four double quote characters:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="MoarQuotes":::

If you need to start or end a raw string literal with quote characters, use the multi-line format:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="InitialQuotes":::

Raw strings can also be combined with [interpolated strings](./interpolated.md#special-characters) to embed ther `{` and `}` characters in the output string. You use multiple `$` characters in an interpolated raw string literal to embed `{` and `}` characters in the output string without escaping them.

## See also

- [C# interpolated strings](./interpolated.md)
- [C# Special Characters](./index.md)
- [Raw string literals feature specification](~/_csharplang/proposals/csharp-11.0/raw-string-literal.md)
