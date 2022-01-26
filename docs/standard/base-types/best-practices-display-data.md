---
title: Best practices for displaying and persisting formatted data in .NET
description: Learn how to display and persist numeric and date data effectively in .NET applications.
ms.date: 05/01/2019
ms.topic: conceptual
dev_langs:
  - "csharp"
  - "vb"
---
# Best practices for displaying and persisting formatted data

This article examines how formatted data, such as numeric data and date-and-time data, is handled for display and for storage.

When you develop with .NET, use culture-sensitive formatting to display non-string data, such as numbers and dates, in a user interface. Use formatting with the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture) to persist non-string data in string form. Do not use culture-sensitive formatting to persist numeric or date-and-time data in string form.

## Display formatted data

When you display non-string data such as numbers and dates and times to users, format them by using the user's cultural settings. By default, the following all use the current culture in formatting operations:

- Interpolated strings supported by the [C#](../../csharp/language-reference/tokens/interpolated.md) and [Visual Basic](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md) compilers.
- String concatenation operations that use the [C#](../../csharp/language-reference/operators/addition-operator.md#string-concatenation) or [Visual Basic](../../visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md) concatenation operators or that call the <xref:System.String.Concat%2A?displayProperty=nameWithType> method directly.
- The <xref:System.String.Format%2A?displayProperty=nameWithType> method.
- The `ToString` methods of the numeric types and the date and time types.

To explicitly specify that a string should be formatted by using the conventions of a designated culture or the [invariant culture](xref:System.Globalization.CultureInfo.InvariantCulture), you can do the following:

- When using the <xref:System.String.Format%2A?displayProperty=nameWithType> and `ToString` methods, call an overload that has a `provider` parameter, such as <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> or <xref:System.DateTime.ToString%28System.IFormatProvider%29?displayProperty=nameWithType>, and pass it the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property, a <xref:System.Globalization.CultureInfo> instance that represents the desired culture, or the <xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> property.

- For string concatenation, do not allow the compiler to perform any implicit conversions. Instead, perform an explicit conversion by calling a `ToString` overload that has a `provider` parameter. For example, the compiler implicitly uses the current culture when converting a <xref:System.Double> value to a string in the following code:

  [!code-csharp[Implicit String Conversion](./snippets/best-practices-strings/csharp/tostring/Program.cs#1)]
  [!code-vb[Implicit String Conversion](./snippets/best-practices-strings/vb/tostring/Program.vb#1)]

  Instead, you can explicitly specify the culture whose formatting conventions are used in the conversion by calling the <xref:System.Double.ToString(System.IFormatProvider)?displayProperty=nameWithType> method, as the following code does:

  [!code-csharp[Explicit String Conversion](./snippets/best-practices-strings/csharp/tostring/Program.cs#2)]
  [!code-vb[Implicit String Conversion](./snippets/best-practices-strings/vb/tostring/Program.vb#2)]

- For string interpolation, rather than assigning an interpolated string to a <xref:System.String> instance, assign it to a <xref:System.FormattableString>. You can then call its <xref:System.FormattableString.ToString?displayProperty=nameWithType> method produce a result string that reflects the conventions of the current culture, or you can call the <xref:System.FormattableString.ToString(System.IFormatProvider)?displayProperty=nameWithType> method to produce a result string that reflects the conventions of a specified culture. You can also pass the formattable string to the static <xref:System.FormattableString.Invariant%2A?displayProperty=nameWithType> method to produce a result string that reflects the conventions of the invariant culture. The following example illustrates this approach. (The output from the example reflects a current culture of en-US.)

  [!code-csharp[String interpolation](./snippets/best-practices-strings/csharp/formattable/Program.cs)]
  [!code-vb[String interpolation](./snippets/best-practices-strings/vb/formattable/Program.vb)]

## Persist formatted data

You can persist non-string data either as binary data or as formatted data. If you choose to save it as formatted data, you should call a formatting method overload that includes a `provider` parameter and pass it the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. The invariant culture provides a consistent format for formatted data that is independent of culture and machine. In contrast, persisting data that is formatted by using cultures other than the invariant culture has a number of limitations:

- The data is likely to be unusable if it is retrieved on a system that has a different culture, or if the user of the current system changes the current culture and tries to retrieve the data.
- The properties of a culture on a specific computer can differ from standard values. At any time, a user can customize culture-sensitive display settings. Because of this, formatted data that is saved on a system may not be readable after the user customizes cultural settings. The portability of formatted data across computers is likely to be even more limited.
- International, regional, or national standards that govern the formatting of numbers or dates and times change over time, and these changes are incorporated into Windows operating system updates. When formatting conventions change, data that was formatted by using the previous conventions may become unreadable.

The following example illustrates the limited portability that results from using culture-sensitive formatting to persist data. The example saves an array of date and time values to a file. These are formatted by using the conventions of the English (United States) culture. After the application changes the current culture to French (Switzerland), it tries to read the saved values by using the formatting conventions of the current culture. The attempt to read two of the data items throws a <xref:System.FormatException> exception, and the array of dates now contains two incorrect elements that are equal to <xref:System.DateTime.MinValue>.

[!code-csharp[Conceptual.Strings.BestPractices#21](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/persistence.cs#21)]
[!code-vb[Conceptual.Strings.BestPractices#21](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/persistence.vb#21)]

However, if you replace the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property with <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> in the calls to <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> and <xref:System.DateTime.Parse%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType>, the persisted date and time data is successfully restored, as the following output shows:

```console
06.05.1758 21:26
05.05.1818 07:19
22.04.1870 23:54
08.09.1890 06:47
18.02.1905 15:12
```
