---
title: System.Globalization.CompareInfo class
description: Learn more about the System.Globalization.CompareInfo class.
ms.date: 12/28/2023
ms.topic: concept-article
---
# <xref:System.Globalization.CompareInfo> class

[!INCLUDE [context](includes/context.md)]

Conventions for comparing and sorting data vary from culture to culture. For example, sort order may be based on phonetics or on the visual representation of characters. In East Asian languages, characters are sorted by the stroke and radical of ideographs. Sorting also depends on the order languages and cultures use for the alphabet. For example, the Danish language has an "Æ" character that it sorts after "Z" in the alphabet. In addition, comparisons may be case-sensitive or case-insensitive, and casing rules may also differ by culture. The <xref:System.Globalization.CompareInfo> class is responsible for maintaining this culture-sensitive string comparison data and for performing culture-sensitive string operations.

Typically, you do not have to instantiate a <xref:System.Globalization.CompareInfo> object directly, because one is used implicitly by all non-ordinal string comparison operations, including calls to the <xref:System.String.Compare%2A?displayProperty=nameWithType> method. However, if you do want to retrieve a <xref:System.Globalization.CompareInfo> object, you can do it in one of these ways:

- By retrieving the value of the <xref:System.Globalization.CultureInfo.CompareInfo%2A?displayProperty=nameWithType> property for a particular culture.

- By calling the static <xref:System.Globalization.CompareInfo.GetCompareInfo%2A> method with a culture name. This allows for late-bound access to a <xref:System.Globalization.CompareInfo> object.

## Ignored search values

Character sets include ignorable characters, which are characters that are not considered when performing a linguistic or culture-sensitive comparison. Comparison methods such as <xref:System.Globalization.CompareInfo.IndexOf%2A> and <xref:System.Globalization.CompareInfo.LastIndexOf%2A> do not consider such characters when they perform a culture-sensitive comparison. Ignorable characters include:

- <xref:System.String.Empty?displayProperty=nameWithType>. Culture-sensitive comparison methods will always find an empty string at the beginning (index zero) of the string being searched.

- A character or string consisting of characters with code points that are not considered in the operation because of comparison options, In particular, the  <xref:System.Globalization.CompareOptions.IgnoreNonSpace?displayProperty=nameWithType> and <xref:System.Globalization.CompareOptions.IgnoreSymbols?displayProperty=nameWithType> options produce searches in which symbols and nonspacing combining characters are ignored.

- A string with code points that have no linguistic significance. For example, a soft hyphen (U+00AD) is always ignored in a culture-sensitive string comparison.

## Security considerations

If a security decision depends on a string comparison or a case change, you should use the <xref:System.Globalization.CultureInfo.InvariantCulture%2A> property to ensure that the behavior is consistent, regardless of the culture settings of the operating system.

> [!NOTE]
> When possible, you should use string comparison methods that have a parameter of type <xref:System.Globalization.CompareOptions> to specify the kind of comparison expected. As a general rule, use linguistic options (using the current culture) for comparing strings displayed in the user interface and specify <xref:System.Globalization.CompareOptions.Ordinal> or <xref:System.Globalization.CompareOptions.OrdinalIgnoreCase> for security comparisons.
