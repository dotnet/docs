---
title: System.Globalization.CultureInfo.InvariantCulture property
description: Learn about the System.Globalization.CultureInfo.InvariantCulture property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
---
# System.Globalization.CultureInfo.InvariantCulture property

[!INCLUDE [context](includes/context.md)]

The invariant culture is culture-insensitive; it's associated with the English language but not with any country/region. You specify the invariant culture by name by using an empty string ("") in the call to a <xref:System.Globalization.CultureInfo> instantiation method. This property, <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType>, also retrieves an instance of the invariant culture. It can be used in almost any method in the <xref:System.Globalization> namespace that requires a culture. The objects returned by properties such as <xref:System.Globalization.CultureInfo.CompareInfo%2A>, <xref:System.Globalization.CultureInfo.DateTimeFormat%2A>, and <xref:System.Globalization.CultureInfo.NumberFormat%2A> also reflect the string comparison and formatting conventions of the invariant culture.

Unlike culture-sensitive data, which is subject to change by user customization or by updates to the .NET Framework or the operating system, invariant culture data is stable over time and across installed cultures and cannot be customized by users. This makes the invariant culture particularly useful for operations that require culture-independent results, such as formatting and parsing operations that persist formatted data, or sorting and ordering operations that require that data be displayed in a fixed order regardless of culture.

## String operations

You can use the invariant culture for culture-sensitive string operations that are not affected by the conventions of the current culture and that are consistent across cultures. For example, you may want sorted data to appear in a fixed order or apply a standard set of casing conventions to strings regardless of the current culture. To do this, you pass the <xref:System.Globalization.CultureInfo.InvariantCulture%2A> object to a method that has a <xref:System.Globalization.CultureInfo> parameter, such as <xref:System.String.Compare(System.String,System.String,System.Boolean,System.Globalization.CultureInfo)> and <xref:System.String.ToUpper(System.Globalization.CultureInfo)>.

## Persisting data

The <xref:System.Globalization.CultureInfo.InvariantCulture> property can be used to persist data in a culture-independent format. This provides a known format that does not change and that can be used to serialize and deserialize data across cultures. After the data is deserialized, it can be formatted appropriately based on the cultural conventions of the current user.

For example, if you choose to persist date and time data in string form, you can pass the <xref:System.Globalization.CultureInfo.InvariantCulture%2A> object to the <xref:System.DateTime.ToString(System.String,System.IFormatProvider)?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString(System.IFormatProvider)?displayProperty=nameWithType> method to create the string, and you can pass the <xref:System.Globalization.CultureInfo.InvariantCulture%2A> object to the <xref:System.DateTime.Parse(System.String,System.IFormatProvider)?displayProperty=nameWithType> or <xref:System.DateTimeOffset.Parse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles)?displayProperty=nameWithType> method to convert the string back to a date and time value. This technique ensures that the underlying date and time values do not change when the data is read or written by users from different cultures.

The following example uses the invariant culture to persist a <xref:System.DateTime> value as a string. It then parses the string and displays its value by using the formatting conventions of the French (France) and German (Germany) cultures.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/InvariantCulture/csharp/persist1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/InvariantCulture/vb/persist1.vb" id="Snippet1":::

## Security decisions

If you are making a security decision (such as whether to allow access to a system resource) based on the result of a string comparison or a case change, you should not use the invariant culture. Instead, you should perform a case-sensitive or case-insensitive ordinal comparison by calling a method that includes a <xref:System.StringComparison> parameter and supplying either <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> as an argument. Code that performs culture-sensitive string operations can cause security vulnerabilities if the current culture is changed or if the culture on the computer that is running the code differs from the culture that is used to test the code. In contrast, an ordinal comparison depends solely on the binary value of the compared characters.
