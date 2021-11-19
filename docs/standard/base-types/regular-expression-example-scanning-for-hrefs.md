---
title: "Regular Expression Example: Scanning for HREFs"
description: See an example of regular expressions in .NET. The example searches an input string and displays all href attribute values and their locations.
ms.date: "07/14/2021"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "searching with regular expressions, examples"
  - "parsing text with regular expressions, examples"
  - "regular expressions, examples"
  - ".NET regular expressions, examples"
  - "regular expressions [.NET], examples"
  - "pattern-matching with regular expressions, examples"
ms.assetid: fae2c15b-7adf-4b15-b118-58eb3906994f
---
# Regular expression example: Scanning for HREFs

The following example searches an input string and displays all the href="…" values and their locations in the string.

[!INCLUDE [regex](../../../includes/regex.md)]

## The Regex object

Because the `DumpHRefs` method can be called multiple times from user code, it uses the `static` (`Shared` in Visual Basic) <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method. This enables the regular expression engine to cache the regular expression and avoids the overhead of instantiating a new <xref:System.Text.RegularExpressions.Regex> object each time the method is called. A <xref:System.Text.RegularExpressions.Match> object is then used to iterate through all matches in the string.

:::code language="csharp" source="snippets/regular-expression-example-scanning-for-hrefs/csharp/Program.cs" id="regex":::
:::code language="vb" source="snippets/regular-expression-example-scanning-for-hrefs/vb/Program.vb" id="regex":::

The following example then illustrates a call to the `DumpHRefs` method.

:::code language="csharp" source="snippets/regular-expression-example-scanning-for-hrefs/csharp/Program.cs" id="main":::
:::code language="vb" source="snippets/regular-expression-example-scanning-for-hrefs/vb/Program.vb" id="main":::

The regular expression pattern `href\s*=\s*(?:["'](?<1>[^"']*)["']|(?<1>[^>\s]+))` is interpreted as shown in the following table.

| Pattern                | Description                                                     |
|------------------------|-----------------------------------------------------------------|
| `href`                 | Match the literal string "href". The match is case-insensitive. |
| `\s*`                  | Match zero or more white-space characters.                      |
| `=`                    | Match the equals sign.                                          |
| `\s*`                  | Match zero or more white-space characters.                      |
| `(?:`                  | Start a non-capturing group.                                    |
| `["'](?<1>[^"']*)["']` | Match a quotation mark or apostrophe, followed by a capturing group that matches any character other than a quotation mark or apostrophe, followed by a quotation mark or apostrophe. The group named `1` is included in this pattern. |
| `|`                    | Boolean OR that matches either the previous expression or the next expression. |
| `(?<1>[^>\s]+)`        | A capturing group that uses a negated set to match any character other than a greater-than sign or a whitespace character. The group named `1` is included in this pattern.|
| `)`                    | End the non-capturing group.                                    |

## Match result class

The results of a search are stored in the <xref:System.Text.RegularExpressions.Match> class, which provides access to all the substrings extracted by the search. It also remembers the string being searched and the regular expression being used, so it can call the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method to perform another search starting where the last one ended.

## Explicitly named captures

In traditional regular expressions, capturing parentheses are automatically numbered sequentially. This leads to two problems. First, if a regular expression is modified by inserting or removing a set of parentheses, all code that refers to the numbered captures must be rewritten to reflect the new numbering. Second, because different sets of parentheses often are used to provide two alternative expressions for an acceptable match, it might be difficult to determine which of the two expressions actually returned a result.

To address these problems, the <xref:System.Text.RegularExpressions.Regex> class supports the syntax `(?<name>…)` for capturing a match into a specified slot (the slot can be named using a string or an integer; integers can be recalled more quickly). Thus, alternative matches for the same string all can be directed to the same place. In case of a conflict, the last match dropped into a slot is the successful match. (However, a complete list of multiple matches for a single slot is available. See the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> collection for details.)

## See also

- [.NET Regular Expressions](regular-expressions.md)
