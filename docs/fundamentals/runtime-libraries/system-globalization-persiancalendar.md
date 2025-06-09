---
title: System.Globalization.PersianCalendar class
description: Learn more about the System.Globalization.PersianCalendar class.
ms.date: 04/09/2025
ms.topic: conceptual
---
# <xref:System.Globalization.PersianCalendar> class

[!INCLUDE [context](includes/context.md)]

The Persian calendar is used in most countries/regions where Persian is spoken, although some regions use different month names. The Persian calendar is the official calendar of Iran and Afghanistan, and it is one of the alternative calendars in regions such as Kazakhstan and Tajikistan.

> [!NOTE]
> For information about using the <xref:System.Globalization.PersianCalendar> class and the other calendar classes in .NET, see [Working with Calendars](../../standard/datetime/working-with-calendars.md).

The Persian calendar is a solar Hijri calendar, and starts from the year of the Hijra, which corresponds to 622 C.E. the year when Muhammad (PBUH) migrated from Mecca to Medina.

The Persian calendar is based on a solar year and is approximately 365 days long. A year cycles through four seasons, and a new year begins when the sun appears to cross the equator from the southern hemisphere to the northern hemisphere as viewed from the center of the Earth. The new year marks the first day of the month of Farvardeen, which is the first day of spring in the northern hemisphere. For example, the date March 21, 2002 C.E. corresponds to the first day of the month of Farvardeen in the year 1381 Anno Persico.

Each of the first six months in the Persian calendar has 31 days, each of the next five months has 30 days, and the last month has 29 days in a common year and 30 days in a leap year. A leap year is a year that, when divided by 33, has a remainder of 1, 5, 9, 13, 17, 22, 26, or 30. For example, the year 1370 is a leap year because dividing it by 33 yields a remainder of 17. There are approximately eight leap years in every 33-year cycle.

## The PersianCalendar class and .NET versions

Starting with .NET Framework 4.6, the <xref:System.Globalization.PersianCalendar> class uses the Hijri solar astronomical algorithm rather than an observational algorithm to calculate dates. This makes the <xref:System.Globalization.PersianCalendar> implementation consistent with the Persian calendar in use in Iran and Afghanistan, the two countries in which the Persian calendar is in most widespread use. The change affects all apps running on .NET Framework 4 or later if .NET Framework 4.6 is installed.

As a result of the changed algorithm:

- The two algorithms should return identical results when converting dates between 1800 and 2123 in the Gregorian calendar.
- The two algorithms might return different results when converting dates before 1800 and after 2123 in the Gregorian calendar.
- The <xref:System.Globalization.PersianCalendar.MinSupportedDateTime> property value has changed from March 21, 0622 in the Gregorian calendar to March 22, 0622 in the Gregorian calendar.
- The <xref:System.Globalization.PersianCalendar.MaxSupportedDateTime> property value has changed from the 10th day of the 10th month of the year 9378 in the Persian calendar to the 13th day of the 10th month of the year 9378 in the Persian calendar.
- The <xref:System.Globalization.PersianCalendar.IsLeapYear%2A> method might return a different result than it did previously.

## Use the PersianCalendar class

You can use a <xref:System.Globalization.PersianCalendar> object to calculate dates in the Persian calendar or convert Persian dates to and from Gregorian dates. The Persian calendar is the [default calendar](xref:System.Globalization.CultureInfo.Calendar) for cultures such as Persian (Afghanistan) and Central Kurdish (Iran).
