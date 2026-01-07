---
title: "Breaking change - Japanese Calendar minimum supported date corrected"
description: "Learn about the breaking change in .NET 11 Preview 1 where the Japanese Calendar minimum supported date was corrected from 1868-09-08 to 1868-10-23."
ms.date: 01/07/2026
ai-usage: ai-assisted
---

# Japanese Calendar minimum supported date corrected

The start date of the Japanese Meiji era has been updated from `1868-09-08` to `1868-10-23` to reflect the latest Unicode CLDR (Common Locale Data Repository) data and improved historical accuracy. This date also serves as the minimum supported date in the Japanese calendar.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, <xref:System.Globalization.JapaneseCalendar.MinSupportedDateTime?displayProperty=nameWithType> returned `1868-09-08`. <xref:System.Globalization.JapaneseCalendar> accepted dates between `1868-09-08` and `1868-10-23` as valid.

## New behavior

Starting in .NET 11, <xref:System.Globalization.JapaneseCalendar.MinSupportedDateTime?displayProperty=nameWithType> returns `1868-10-23` instead. <xref:System.Globalization.JapaneseCalendar> now rejects dates between `1868-09-08` and `1868-10-23` as invalid.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was made to reflect the latest Unicode CLDR (Common Locale Data Repository) data ([CLDR-11375](https://unicode-org.atlassian.net/browse/CLDR-11375)) and improved historical accuracy regarding the start of the Meiji era in Japan.

## Recommended action

Update any code that depends on the old value of <xref:System.Globalization.JapaneseCalendar.MinSupportedDateTime?displayProperty=nameWithType>. Avoid using Gregorian dates before `1868-10-23` with the <xref:System.Globalization.JapaneseCalendar>.

If your code attempts to work with dates in the affected range (`1868-09-08` through `1868-10-22`), add validation to ensure dates are on or after `1868-10-23` before using them with the Japanese calendar.

## Affected APIs

- <xref:System.Globalization.JapaneseCalendar?displayProperty=fullName>
- <xref:System.Globalization.JapaneseCalendar.MinSupportedDateTime?displayProperty=fullName>
