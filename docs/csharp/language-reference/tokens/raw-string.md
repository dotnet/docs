---
description: "Raw string literals can contain any arbitrary text without the need for special escape sequences. You begin and end a raw string literal with a minimum of three double-quote characters."
title: "Raw string literals - \"\"\""
f1_keywords:
  - "RawStringLiteral_CSharpKeyword"
ms.date: 01/30/2026
---
# Raw string literal text - `"""` in string literals

A raw string literal starts and ends with a minimum of three double quote (`"`) characters:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="SingleLine":::

Raw string literals can span multiple lines:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="MultiLine":::

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following rules govern the interpretation of a multiline raw string literal:

- The opening quotes must be the last non-whitespace characters on their line, and the closing quotes must be the first non-whitespace characters on their line.
- Any whitespace to the left of the closing quotes is removed from all lines of the raw string literal.
- Any whitespace following the opening quotes on the same line is ignored.
- Whitespace-only lines following the opening quote are included in the string literal.
- The newline before the closing quotes isn't included in the literal string.
- When whitespace precedes the end delimiter on the same line, the exact number and kind of whitespace characters (for example, spaces vs. tabs) must exist at the beginning of each content line. Specifically, a space doesn't match a horizontal tab, and vice versa.

The last rule is easy if you're consistent in how you use tabs (`u+009`) or spaces (`u+020`) for indenting your code, including raw string literals. You can use either, but don't mix them in the same multiline raw string literal. For example, the following declarations are legal (whitespace is drawn as `\b` for a space character and `\t` for a tab character:)

```csharp
var xml = """
\b\b\b\b<element attr="content">
\b\b\b\b\b\b<body>
\b\b\b\b\b\b</body>
\b\b\b\b</element>
\b\b\b\b""";

var xmlTabs = """
\t\t\t\t<element attr="content">
\t\t\t\t\t\t<body>
\t\t\t\t\t\t</body>
\t\t\t\t</element>
\t\t\t\t""";
```

However, because the following declaration doesn't use a consistent format for the whitespace to the left of the closing `"""`, the declaration is invalid:

```csharp
var xml = """
\t\b\b\b<element attr="content">
\b\t\b\b\b\b<body>
\b\b\t\b\b\b</body>
\b\b\b\t</element>
\b\b\b\b""";
```

[!INCLUDE[raw-string-tip](../../includes/raw-string-parsing.md)]

You might need to create a raw string literal that has three or more consecutive double-quote characters. Raw string literals can start and end with a sequence of at least three double-quote characters. When your string literal contains three consecutive double-quotes, you start and end the raw string literal with four double quote characters:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="MoarQuotes":::

If you need to start or end a raw string literal with quote characters, use the multiline format:

:::code language="csharp" source="./snippets/raw-string-literal.cs" id="InitialQuotes":::

Raw string literals can also be combined with [interpolated strings](./interpolated.md#interpolated-raw-string-literals) to embed the `{` and `}` characters in the output string. You use multiple `$` characters in an interpolated raw string literal to embed `{` and `}` characters in the output string without escaping them.

The raw string literal's content must not contain a set of contiguous `"` characters whose length is equal to or greater than the raw string literal delimiter length. For example, the strings `"""" """ """"` and `""""""" """""" """"" """" """ """""""` are well-formed. However, the strings `""" """ """` and `""" """" """` aren't well-formed.

## See also

- [C# special characters](./index.md)
- [C# string interpolation](./interpolated.md)
- [Raw string literals feature specification](~/_csharplang/proposals/csharp-11.0/raw-string-literal.md)
