---
title: System.TimeSpan.Parse method
description: Learn about the System.TimeSpan.Parse method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.TimeSpan.Parse method

[!INCLUDE [context](includes/context.md)]

The input string to the <xref:System.TimeSpan.Parse%2A> methods contains a time interval specification in the form:

`[ws][-]{ d | [d.]hh:mm[:ss[.ff]] }[ws]`

Elements in square brackets (`[` and `]`) are optional. One selection from the list of alternatives enclosed in braces (`{` and `}`) and separated by vertical bars (&#124;) is required. The following table describes each element.

| Element | Description                                                                                                    |
|---------|----------------------------------------------------------------------------------------------------------------|
| *ws*    | Optional white space.                                                                                          |
| -     | An optional minus sign, which indicates a negative <xref:System.TimeSpan>.                                     |
| *d*     | Days, ranging from 0 to 10675199.                                                                              |
| .       | A culture-sensitive symbol that separates days from hours. The invariant format uses a period (".") character. |
| *hh*    | Hours, ranging from 0 to 23.                                                                                   |
| :       | The culture-sensitive time separator symbol. The invariant format uses a colon (":") character.                |
| *mm*    | Minutes, ranging from 0 to 59.                                                                                 |
| *ss*    | Optional seconds, ranging from 0 to 59.                                                                        |
| *.*     | A culture-sensitive symbol that separates seconds from fractions of a second. The invariant format uses a period (".") character. |
| *ff*    | Optional fractional seconds, consisting of one to seven decimal digits. |

If the input string is not a day value only, it must include an hours and a minutes component; other components are optional. If they are present, the values of each time component must fall within a specified range. For example, the value of *hh*, the hours component, must be between 0 and 23. Because of this, passing "23:00:00" to the <xref:System.TimeSpan.Parse%2A> method returns a time interval of 23 hours. On the other hand, passing "24:00:00" returns a time interval of 24 days. Because "24" is outside the range of the hours component, it is interpreted as the days component.

The components of the input string must collectively specify a time interval that is greater than or equal to <xref:System.TimeSpan.MinValue?displayProperty=nameWithType> and less than or equal to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.

The <xref:System.TimeSpan.Parse(System.String)> method tries to parse the input string by using each of the culture-specific formats for the current culture.

## Notes to callers

When a time interval component in the string to be parsed contains more than seven digits, parsing operations in .NET Framework 3.5 and earlier versions may behave differently from parsing operations in .NET Framework 4 and later versions. In some cases, parsing operations that succeed in .NET Framework 3.5 and earlier versions may fail and throw an <xref:System.OverflowException> in .NET Framework 4 and later. In other cases, parsing operations that throw a <xref:System.FormatException> in .NET Framework 3.5 and earlier versions may fail and throw an <xref:System.OverflowException> in .NET Framework 4 and later. The following example illustrates both scenarios.

:::code language="csharp" source="./snippets/System/TimeSpan/Parse/csharp/parsefailure1.cs" interactive="try-dotnet-method" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/TimeSpan/Parse/fsharp/parsefailure1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/TimeSpan/Parse/vb/parsefailure1.vb" id="Snippet3":::
