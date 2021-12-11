---
title: "How to: Display Milliseconds in Date and Time Values"
description: In this article, learn how to include a date and time's millisecond component in formatted date and time strings in .NET.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DateTime.ToString method"
  - "displaying date and time data"
  - "time [.NET], milliseconds"
  - "dates [.NET], milliseconds"
  - "milliseconds [.NET]"
ms.assetid: ae1a0610-90b9-4877-8eb6-4e30bc5e00cf
---
# How to: Display Milliseconds in Date and Time Values

The default date and time formatting methods, such as <xref:System.DateTime.ToString?displayProperty=nameWithType>, include the hours, minutes, and seconds of a time value but exclude its milliseconds component. This article shows how to include a date and time's millisecond component in formatted date and time strings.

## To display the millisecond component of a DateTime value

1. If you're working with the string representation of a date, convert it to a <xref:System.DateTime> or a <xref:System.DateTimeOffset> value by using the static <xref:System.DateTime.Parse%28System.String%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.Parse%28System.String%29?displayProperty=nameWithType> method.

2. To extract the string representation of a time's millisecond component, call the date and time value's <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%2A> method, and pass the `fff` or `FFF` custom format pattern either alone or with other custom format specifiers as the `format` parameter.

> [!TIP]
> The millisecond separator is specified by the <xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A?displayProperty=fullName> property.

## Example

The example displays the millisecond component of a <xref:System.DateTime> and a <xref:System.DateTimeOffset> value to the console, both alone and included in a longer date and time string.

:::code language="csharp" source="snippets/how-to-display-milliseconds-in-date-and-time-values/csharp/Program.cs" id="Main":::
:::code language="vb" source="snippets/how-to-display-milliseconds-in-date-and-time-values/vb/Program.vb" id="Main":::

The `fff` format pattern includes any trailing zeros in the millisecond value. The `FFF` format pattern suppresses them. The difference is illustrated in the following example.

:::code language="csharp" source="snippets/how-to-display-milliseconds-in-date-and-time-values/csharp/Program.cs" id="TrailingZero":::
:::code language="vb" source="snippets/how-to-display-milliseconds-in-date-and-time-values/vb/Program.vb" id="TrailingZero":::

A problem with defining a complete custom format specifier that includes the millisecond component of a date and time is that it defines a hard-coded format that may not correspond to the arrangement of time elements in the application's current culture. A better alternative is to retrieve one of the date and time display patterns defined by the current culture's <xref:System.Globalization.DateTimeFormatInfo> object and modify it to include milliseconds. The example also illustrates this approach. It retrieves the current culture's full date and time pattern from the <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A?displayProperty=nameWithType> property, and then inserts the custom pattern `fff` along with the current culture's millisecond separator. The example uses a regular expression to do this operation in a single method call.

You can also use a custom format specifier to display a fractional part of seconds other than milliseconds. For example, the `f` or `F` custom format specifier displays tenths of a second, the `ff` or `FF` custom format specifier displays hundredths of a second, and the `ffff` or `FFFF` custom format specifier displays ten thousandths of a second. Fractional parts of a millisecond are truncated instead of rounded in the returned string. These format specifiers are used in the following example.

:::code language="csharp" source="snippets/how-to-display-milliseconds-in-date-and-time-values/csharp/Program.cs" id="Fraction":::
:::code language="vb" source="snippets/how-to-display-milliseconds-in-date-and-time-values/vb/Program.vb" id="Fraction":::

> [!NOTE]
> It is possible to display very small fractional units of a second, such as ten thousandths of a second or hundred-thousandths of a second. However, these values may not be meaningful. The precision of a date and time value depends on the resolution of the operating system clock. For more information, see the API your operating system uses:
>
> - Windows 7: [GetSystemTimeAsFileTime](/windows/win32/api/sysinfoapi/nf-sysinfoapi-GetSystemTimeAsFileTime)
> - Windows 8 and above: [GetSystemTimePreciseAsFileTime](/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemtimepreciseasfiletime)
> - Linux and macOS: [clock_gettime](https://linux.die.net/man/3/clock_gettime)

## See also

- <xref:System.Globalization.DateTimeFormatInfo>
- [Custom Date and Time Format Strings](custom-date-and-time-format-strings.md)
