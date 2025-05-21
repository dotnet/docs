---
title: System.DateTime.TryParse method
description: Learn about the System.DateTime.TryParse method.
ms.date: 01/24/2024
ms.topic: article
---
# System.DateTime.TryParse method

[!INCLUDE [context](includes/context.md)]

The <xref:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)?displayProperty=nameWithType> method parses a string that can contain date, time, and time zone information. It is similar to the <xref:System.DateTime.Parse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles)?displayProperty=nameWithType> method, except that the <xref:System.DateTime.TryParse(System.String,System.DateTime@)?displayProperty=nameWithType> method does not throw an exception if the conversion fails.

This method attempts to ignore unrecognized data and parse the input string (`s`) completely. If `s` contains a time but no date, the method by default substitutes the current date or, if `styles` includes the <xref:System.Globalization.DateTimeStyles.NoCurrentDateDefault> flag, it substitutes `DateTime.Date.MinValue`. If `s` contains a date but no time, 12:00 midnight is used as the default time. If a date is present but its year component consists of only two digits, it is converted to a year in the `provider` parameter's current calendar based on the value of the <xref:System.Globalization.Calendar.TwoDigitYearMax%2A?displayProperty=nameWithType> property. Any leading, inner, or trailing white space characters in `s` are ignored. The date and time can be bracketed with a pair of leading and trailing NUMBER SIGN characters ('#', U+0023), and can be trailed with one or more NULL characters (U+0000).

Specific valid formats for date and time elements, as well as the names and symbols used in dates and times, are defined by the `provider` parameter, which can be any of the following:

- A <xref:System.Globalization.CultureInfo> object that represents the culture whose formatting is used in the `s` parameter. The <xref:System.Globalization.DateTimeFormatInfo> object returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property defines the formatting used in `s`.
- A <xref:System.Globalization.DateTimeFormatInfo> object that defines the formatting used in `s`.
- A custom <xref:System.IFormatProvider> implementation. Its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method returns a <xref:System.Globalization.DateTimeFormatInfo> object that defines the formatting used in `s`.

If `provider` is `null`, the current culture is used.

If `s` is the string representation of a leap day in a leap year in the current calendar, the method parses `s` successfully. If `s` is the string representation of a leap day in a non-leap year in the current calendar of `provider`, the parse operation fails and the method returns `false`.

The `styles` parameter defines the precise interpretation of the parsed string and how the parse operation should handle it. It can be one or more members of the <xref:System.Globalization.DateTimeStyles> enumeration, as described in the following table.

|DateTimeStyles member|Description|
|---------------------------|-----------------|
|<xref:System.Globalization.DateTimeStyles.AdjustToUniversal>|Parses `s` and, if necessary, converts it to UTC. If `s` includes a time zone offset, or if `s` contains no time zone information but `styles` includes the <xref:System.Globalization.DateTimeStyles.AssumeLocal?displayProperty=nameWithType> flag, the method parses the string, calls <xref:System.DateTime.ToUniversalTime%2A> to convert the returned <xref:System.DateTime> value to UTC, and sets the <xref:System.DateTime.Kind> property to <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>. If `s` indicates that it represents UTC, or if `s` does not contain time zone information but `styles` includes the <xref:System.Globalization.DateTimeStyles.AssumeUniversal?displayProperty=nameWithType> flag, the method parses the string, performs no time zone conversion on the returned <xref:System.DateTime> value, and sets the <xref:System.DateTime.Kind> property to <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>. In all other cases, the flag has no effect.|
|<xref:System.Globalization.DateTimeStyles.AllowInnerWhite>|Although valid, this value is ignored. Inner white space is permitted in the date and time elements of `s`.|
|<xref:System.Globalization.DateTimeStyles.AllowLeadingWhite>|Although valid, this value is ignored. Leading white space is permitted in the date and time elements of `s`.|
|<xref:System.Globalization.DateTimeStyles.AllowTrailingWhite>|Although valid, this value is ignored. Trailing white space is permitted in the date and time elements of `s`.|
|<xref:System.Globalization.DateTimeStyles.AllowWhiteSpaces>|Specifies that `s` may contain leading, inner, and trailing white spaces. This is the default behavior. It cannot be overridden by supplying a more restrictive <xref:System.Globalization.DateTimeStyles> enumeration value such as <xref:System.Globalization.DateTimeStyles.None?displayProperty=nameWithType>.|
|<xref:System.Globalization.DateTimeStyles.AssumeLocal>|Specifies that if `s` lacks any time zone information, it is assumed to represent a local time. Unless the <xref:System.Globalization.DateTimeStyles.AdjustToUniversal?displayProperty=nameWithType> flag is present, the <xref:System.DateTime.Kind> property of the returned <xref:System.DateTime> value is set to <xref:System.DateTimeKind.Local?displayProperty=nameWithType>.|
|<xref:System.Globalization.DateTimeStyles.AssumeUniversal>|Specifies that if `s` lacks any time zone information, it is assumed to represent UTC. Unless the <xref:System.Globalization.DateTimeStyles.AdjustToUniversal?displayProperty=nameWithType> flag is present, the method converts the returned <xref:System.DateTime> value from UTC to local time and sets its <xref:System.DateTime.Kind> property to <xref:System.DateTimeKind.Local?displayProperty=nameWithType>.|
|<xref:System.Globalization.DateTimeStyles.None>|Although valid, this value is ignored.|
|<xref:System.Globalization.DateTimeStyles.RoundtripKind>|For strings that contain time zone information, tries to prevent the conversion of a date and time string to a <xref:System.DateTime> value with its <xref:System.DateTime.Kind> property set to <xref:System.DateTimeKind.Local?displayProperty=nameWithType>. Typically, such a string is created by calling the <xref:System.DateTime.ToString(System.String)?displayProperty=nameWithType> method using either the "o", "r", or "u" standard format specifiers.|

If `s` contains no time zone information, the <xref:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)?displayProperty=nameWithType> method returns a <xref:System.DateTime> value whose <xref:System.DateTime.Kind> property is <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType> unless a `styles` flag indicates otherwise. If `s` includes time zone or time zone offset information, the <xref:System.DateTime.TryParse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)?displayProperty=nameWithType> method performs any necessary time conversion and returns one of the following:

- A <xref:System.DateTime> value whose date and time reflect the local time and whose <xref:System.DateTime.Kind> property is <xref:System.DateTimeKind.Local?displayProperty=nameWithType>.
- Or, if `styles` includes the <xref:System.Globalization.DateTimeStyles.AdjustToUniversal> flag, a <xref:System.DateTime> value whose date and time reflect UTC and whose <xref:System.DateTime.Kind> property is <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>.

This behavior can be overridden by using the <xref:System.Globalization.DateTimeStyles.RoundtripKind?displayProperty=nameWithType> flag.

## Parse custom cultures

If you parse a date and time string generated for a custom culture, use the <xref:System.DateTime.TryParseExact%2A> method instead of the <xref:System.DateTime.TryParse%2A> method to improve the probability that the parse operation will succeed. A custom culture date and time string can be complicated and difficult to parse. The <xref:System.DateTime.TryParse%2A> method attempts to parse a string with several implicit parse patterns, all of which might fail. In contrast, the <xref:System.DateTime.TryParseExact%2A> method  requires you to explicitly designate one or more exact parse patterns that are likely to succeed.

For more information about custom cultures, see the <xref:System.Globalization.CultureAndRegionInfoBuilder?displayProperty=nameWithType> class.
