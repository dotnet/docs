---
title: System.TimeSpan.TryParse methods
description: Learn about the System.TimeSpan.TryParse methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.TimeSpan.TryParse methods

[!INCLUDE [context](includes/context.md)]

## TryParse(System.String,System.TimeSpan@) method

The <xref:System.TimeSpan.TryParse(System.String,System.TimeSpan@)?displayProperty=nameWithType> method is like the <xref:System.TimeSpan.Parse(System.String)?displayProperty=nameWithType> method, except that it doesn't throw an exception if the conversion fails.

The `s` parameter contains a time interval specification in the form:

`[ws][-]{ d | d.hh:mm[:ss[.ff]] | hh:mm[:ss[.ff]] }[ws]`

Elements in square brackets ([ and ]) are optional. One selection from the list of alternatives enclosed in braces ({ and }) and separated by vertical bars (&#124;) is required. The following table describes each element.

| Element | Description                                                                                     |
|---------|-------------------------------------------------------------------------------------------------|
| *ws*    | Optional white space.                                                                           |
| -       | An optional minus sign, which indicates a negative <xref:System.TimeSpan>.                      |
| *d*     | Days, ranging from 0 to 10675199.                                                               |
| .       | A culture-sensitive symbol that separates days from hours. The invariant format uses a period (".") character.|
| *hh*    | Hours, ranging from 0 to 23.                                                                    |
| :       | The culture-sensitive time separator symbol. The invariant format uses a colon (":") character. |
| *mm*    | Minutes, ranging from 0 to 59.                                                                  |
| *ss*    | Optional seconds, ranging from 0 to 59.                                                         |
| .       | A culture-sensitive symbol that separates seconds from fractions of a second. The invariant format uses a period (".") character.|
| *ff*    | Optional fractional seconds, consisting of one to seven decimal digits.                         |

The components of `s` must collectively specify a time interval that's greater than or equal to <xref:System.TimeSpan.MinValue?displayProperty=nameWithType> and less than or equal to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.

The <xref:System.TimeSpan.Parse(System.String)> method tries to parse `s` by using each of the culture-specific formats for the current culture.

## <xref:System.TimeSpan.TryParse(System.String,System.IFormatProvider,System.TimeSpan@)> method

The <xref:System.TimeSpan.TryParse(System.String,System.IFormatProvider,System.TimeSpan@)> method is like the <xref:System.TimeSpan.Parse(System.String,System.IFormatProvider)> method, except that it does not throw an exception if the conversion fails.

The `input` parameter contains a time interval specification in the form:

`[ws][-]{ d | d.hh:mm[:ss[.ff]] | hh:mm[:ss[.ff]] }[ws]`

Elements in square brackets ([ and ]) are optional. One selection from the list of alternatives enclosed in braces ({ and }) and separated by vertical bars (&#124;) is required. The following table describes each element.

| Element | Description                                                                                                    |
|---------|----------------------------------------------------------------------------------------------------------------|
| *ws*    | Optional white space.                                                                                          |
| -       | An optional minus sign, which indicates a negative <xref:System.TimeSpan>.                                     |
| *d*     | Days, ranging from 0 to 10675199.                                                                              |
| .       | A culture-sensitive symbol that separates days from hours. The invariant format uses a period (".") character. |
| *hh*    | Hours, ranging from 0 to 23.                                                                                   |
| :       | The culture-sensitive time separator symbol. The invariant format uses a colon (":") character.                |
| *mm*    | Minutes, ranging from 0 to 59.                                                                                 |
| *ss*    | Optional seconds, ranging from 0 to 59.                                                                        |
| .       | A culture-sensitive symbol that separates seconds from fractions of a second. The invariant format uses a period (".") character. |
| *ff*    | Optional fractional seconds, consisting of one to seven decimal digits. |

The components of `input` must collectively specify a time interval that is greater than or equal to <xref:System.TimeSpan.MinValue?displayProperty=nameWithType> and less than or equal to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.

The <xref:System.TimeSpan.TryParse(System.String,System.IFormatProvider,System.TimeSpan@)> method tries to parse `input` by using each of the culture-specific formats for the culture specified by `formatProvider`.

The `formatProvider` parameter is an <xref:System.IFormatProvider> implementation that provides culture-specific information about the format of the returned string. The `formatProvider` parameter can be any of the following:

- A <xref:System.Globalization.CultureInfo> object that represents the culture whose formatting conventions are to be reflected in the returned string. The <xref:System.Globalization.DateTimeFormatInfo> object returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property defines the formatting of the returned string.
- A <xref:System.Globalization.DateTimeFormatInfo> object that defines the formatting of the returned string.
- A custom object that implements the <xref:System.IFormatProvider> interface. Its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method returns a <xref:System.Globalization.DateTimeFormatInfo> object that provides formatting information.

If `formatProvider` is `null`, the <xref:System.Globalization.DateTimeFormatInfo> object that is associated with the current culture is used.

## Notes to callers

In some cases, when a time interval component in the string to be parsed contains more than seven digits, parsing operations that succeeded and returned `true` in .NET Framework 3.5 and earlier versions may fail and return `false` in .NET Framework 4 and later versions. The following example illustrates this scenario:

:::code language="csharp" source="./snippets/System/TimeSpan/TryParse/csharp/tryparsefailure1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/TimeSpan/TryParse/fsharp/tryparsefailure1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/TimeSpan/TryParse/vb/tryparsefailure1.vb" id="Snippet3":::
