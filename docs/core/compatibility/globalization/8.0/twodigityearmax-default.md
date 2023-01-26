---
title: "Breaking change: TwoDigitYearMax default is 2049"
description: Learn about the globalization breaking change in .NET 8 where the default value of the GregorianCalendar.TwoDigitYearMax property has changed from 2029 to 2049.
ms.date: 01/25/2023
---
# TwoDigitYearMax default is 2049

Calendar classes, such as <xref:System.Globalization.GregorianCalendar>, have a `TwoDigitYearMax` property that defines the last year of a 100-year range that can be represented by a two-digit year. This property is often used to translate a two-digit year to a four-digit year. Previously, <xref:System.Globalization.GregorianCalendar.TwoDigitYearMax?displayProperty=nameWithType> defaulted to 2029. That value meant that two-digit years from 00 to 29 translated to 2000-2029. Two-digit years from 30 to 99 translated to 1930-1999. The default `TwoDigitYearMax` property value for <xref:System.Globalization.GregorianCalendar> has now changed from 2029 to 2049. The new value means that two-digit years from 00 to 49 are translated to 2000-2049. Any year from 50 to 99 will be translated to 1950-1999.

In addition, on Windows, the default value of the `TwoDigitYearMax` property is now obtained from the corresponding Windows setting (the default value for which is now also 2049). This matches the behavior prior to .NET 5.

Date parsing is the functionality that's most affected by this change.

## Previous behavior

In .NET 6 and .NET 7, if you didn't specify a value for <xref:System.Globalization.Calendar.TwoDigitYearMax>, parsing a string like "12/10/35" with the Gregorian calendar produced the date "December 12th, 1935".

## New behavior

Starting in .NET 8, parsing a string like "12/10/35" with the Gregorian calendar produces the date "December 12th, 2035".

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

It's more logical to parse a two-digit year that's relatively close to the two digits of the current year to produce a four-digit year in the current century instead of the previous one. The Windows operating system also changed its default settings to the same number (2049).

## Recommended action

If you don't want your app to depend on the default value when parsing a string to a date, you can control how a two-digit year is translated to a four-digit year by setting the <xref:System.Globalization.GregorianCalendar.TwoDigitYearMax> property. The following code shows how to set it for the invariant culture.

```csharp
CultureInfo clonedInvariantCulture = (CultureInfo)(CultureInfo.InvariantCulture.Clone());
clonedInvariantCulture.DateTimeFormat.Calendar.TwoDigitYearMax = 2039; // Use any desired cutoff value.

DateTime dt = DateTime.Parse("12/25/45", clonedInvariantCulture);
```

## Affected APIs

- <xref:System.DateTime.Parse%2A?displayProperty=fullName>
- <xref:System.DateTime.ParseExact%2A?displayProperty=fullName>
- <xref:System.DateTime.TryParse%2A?displayProperty=fullName>
- <xref:System.DateTime.TryParseExact%2A?displayProperty=fullName>
- <xref:System.DateTimeOffset.Parse%2A?displayProperty=fullName>
- <xref:System.DateTimeOffset.ParseExact%2A?displayProperty=fullName>
- <xref:System.DateTimeOffset.TryParse%2A?displayProperty=fullName>
- <xref:System.DateTimeOffset.TryParseExact%2A?displayProperty=fullName>
- <xref:System.Globalization.GregorianCalendar.TwoDigitYearMax?displayProperty=fullName>
- <xref:System.Globalization.GregorianCalendar.ToDateTime%2A?displayProperty=fullName>
- <xref:System.Globalization.GregorianCalendar.ToFourDigitYear(System.Int32)?displayProperty=fullName>

## See also

- [Parse date and time strings in .NET](../../../../standard/base-types/parsing-datetime.md)
