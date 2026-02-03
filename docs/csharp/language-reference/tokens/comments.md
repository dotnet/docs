---
title: "// and /* */ - comments"
description: You use \"//\" for single-line comments. You use \"/*\" to start multi-line comments that end with \"*/\". You add comments to explain your code.
ms.date: 01/14/2026
---
# Code comments - `//` and `/*` - `*/`

C# supports two different forms of comments. Single line comments start with `//` and end at the end of that line of code. Multiline comments start with `/*` and end with `*/`.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following code shows an example of each form:

:::code language="csharp" source="./snippets/comments.cs" id="ExampleComments":::

You can use a multiline comment to insert text in a line of code. Because these comments have an explicit closing character, you can include more executable code after the comment:

:::code language="csharp" source="./snippets/comments.cs" id="InlineComment":::

A single line comment can appear after executable code on the same line. The comment ends at the end of the text line:

:::code language="csharp" source="./snippets/comments.cs" id="LineEndingComment":::

Some comments start with three slashes: `///`. *Triple-slash comments* are *XML documentation comments*. The compiler reads these comments to produce human documentation. You can read more about [XML doc comments](../xmldoc/index.md) in the section on triple-slash comments.
