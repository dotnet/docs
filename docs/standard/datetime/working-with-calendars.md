---
description: "Learn more about: Work with calendars"
title: "Working with calendars"
ms.date: "04/01/2019"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "globalization [.NET], calendars"
  - "calendars, global applications"
  - "global applications, calendars"
  - "world-ready applications, calendars"
  - "international applications [.NET], calendars"
  - "culture, calendars"
ms.assetid: 0c1534e5-979b-4c8a-a588-1c24301aefb3
---
# Work with calendars

Although a date and time value represents a moment in time, its string representation is culture-sensitive and depends both on the conventions used for displaying date and time values by a specific culture and on the calendar used by that culture. This topic explores the support for calendars in .NET and discusses the use of the calendar classes when working with date values.

## Calendars in .NET

All calendars in .NET derive from the <xref:System.Globalization.Calendar?displayProperty=nameWithType> class, which provides the base calendar implementation. One of the classes that inherits from the <xref:System.Globalization.Calendar> class is the <xref:System.Globalization.EastAsianLunisolarCalendar> class, which is the base class for all lunisolar calendars. .NET includes the following calendar implementations:

- <xref:System.Globalization.ChineseLunisolarCalendar>, which represents the Chinese lunisolar calendar.

- <xref:System.Globalization.GregorianCalendar>, which represents the Gregorian calendar. This calendar is further divided into subtypes (such as Arabic and Middle East French) that are defined by the <xref:System.Globalization.GregorianCalendarTypes?displayProperty=nameWithType> enumeration. The <xref:System.Globalization.GregorianCalendar.CalendarType%2A?displayProperty=nameWithType> property specifies the subtype of the Gregorian calendar.

- <xref:System.Globalization.HebrewCalendar>, which represents the Hebrew calendar.

- <xref:System.Globalization.HijriCalendar>, which represents the Hijri calendar.

- <xref:System.Globalization.JapaneseCalendar>, which represents the Japanese calendar.

- <xref:System.Globalization.JapaneseLunisolarCalendar>, which represents the Japanese lunisolar calendar.

- <xref:System.Globalization.JulianCalendar>, which represents the Julian calendar.

- <xref:System.Globalization.KoreanCalendar>, which represents the Korean calendar.

- <xref:System.Globalization.KoreanLunisolarCalendar>, which represents the Korean lunisolar calendar.

- <xref:System.Globalization.PersianCalendar>, which represents the Persian calendar.

- <xref:System.Globalization.TaiwanCalendar>, which represents the Taiwan calendar.

- <xref:System.Globalization.TaiwanLunisolarCalendar>, which represents the Taiwan lunisolar calendar.

- <xref:System.Globalization.ThaiBuddhistCalendar>, which represents the Thai Buddhist calendar.

- <xref:System.Globalization.UmAlQuraCalendar>, which represents the Um Al Qura calendar.

A calendar can be used in one of two ways:

- As the calendar used by a specific culture. Each <xref:System.Globalization.CultureInfo> object has a current calendar, which is the calendar that the object is currently using. The string representations of all date and time values automatically reflect the current culture and its current calendar. Typically, the current calendar is the culture's default calendar. <xref:System.Globalization.CultureInfo> objects also have optional calendars, which include additional calendars that the culture can use.

- As a standalone calendar independent of a specific culture. In this case, <xref:System.Globalization.Calendar> methods are used to express dates as values that reflect the calendar.

Note that six calendar classes – <xref:System.Globalization.ChineseLunisolarCalendar>, <xref:System.Globalization.JapaneseLunisolarCalendar>, <xref:System.Globalization.JulianCalendar>, <xref:System.Globalization.KoreanLunisolarCalendar>, <xref:System.Globalization.PersianCalendar>, and <xref:System.Globalization.TaiwanLunisolarCalendar> – can be used only as standalone calendars. They are not used by any culture as either the default calendar or as an optional calendar.

## Calendars and cultures

Each culture has a default calendar, which is defined by the <xref:System.Globalization.CultureInfo.Calendar%2A?displayProperty=nameWithType> property. The <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> property returns an array of <xref:System.Globalization.Calendar> objects that specifies all the calendars supported by a particular culture, including that culture's default calendar.

The following example illustrates the <xref:System.Globalization.CultureInfo.Calendar%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> properties. It creates `CultureInfo` objects for the Thai (Thailand) and Japanese (Japan) cultures and displays their default and optional calendars. Note that in both cases, the culture's default calendar is also included in the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> collection.

[!code-csharp[Conceptual.Calendars#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/calendarinfo1.cs#1)]
[!code-vb[Conceptual.Calendars#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/calendarinfo1.vb#1)]

The calendar currently in use by a particular <xref:System.Globalization.CultureInfo> object is defined by the culture's <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A?displayProperty=nameWithType> property. A culture's <xref:System.Globalization.DateTimeFormatInfo> object is returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. When a culture is created, its default value is the same as the value of the <xref:System.Globalization.CultureInfo.Calendar%2A?displayProperty=nameWithType> property. However, you can change the culture's current calendar to any calendar contained in the array returned by the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> property. If you try to set the current calendar to a calendar that is not included in the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> property value, an <xref:System.ArgumentException> is thrown.

The following example changes the calendar used by the Arabic (Saudi Arabia) culture. It first instantiates a <xref:System.DateTime> value and displays it using the current culture - which, in this case, is English (United States) - and the current culture's calendar (which, in this case, is the Gregorian calendar). Next, it changes the current culture to Arabic (Saudi Arabia) and displays the date using its default Um Al-Qura calendar. It then calls the `CalendarExists` method to determine whether the Hijri calendar is supported by the Arabic (Saudi Arabia) culture. Because the calendar is supported, it changes the current calendar to Hijri and again displays the date. Note that in each case, the date is displayed using the current culture's current calendar.

[!code-csharp[Conceptual.Calendars#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/changecalendar2.cs#2)]
[!code-vb[Conceptual.Calendars#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/changecalendar2.vb#2)]

## Dates and calendars

With the exception of the constructors that include a parameter of type <xref:System.Globalization.Calendar> and allow the elements of a date (that is, the month, the day, and the year) to reflect values in a designated calendar, both <xref:System.DateTime> and <xref:System.DateTimeOffset> values are always based on the Gregorian calendar. This means, for example, that the <xref:System.DateTime.Year%2A?displayProperty=nameWithType> property returns the year in the Gregorian calendar, and the <xref:System.DateTime.Day%2A?displayProperty=nameWithType> property returns the day of the month in the Gregorian calendar.

> [!IMPORTANT]
> It is important to remember that there is a difference between a date value and its string representation. The former is based on the Gregorian calendar; the latter is based on the current calendar of a specific culture.

The following example illustrates this difference between <xref:System.DateTime> properties and their corresponding <xref:System.Globalization.Calendar> methods. In the example, the current culture is Arabic (Egypt), and the current calendar is Um Al Qura. A <xref:System.DateTime> value is set to the fifteenth day of the seventh month of 2011. It is clear that this is interpreted as a Gregorian date, because these same values are returned by the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> method when it uses the conventions of the invariant culture. The string representation of the date that is formatted using the conventions of the current culture is 14/08/32, which is the equivalent date in the Um Al Qura calendar. Next, members of `DateTime` and `Calendar` are used to return the day, the month, and the year of the <xref:System.DateTime> value. In each case, the values returned by <xref:System.DateTime> members reflect values in the Gregorian calendar, whereas values returned by <xref:System.Globalization.UmAlQuraCalendar> members reflect values in the Uum al-Qura calendar.

[!code-csharp[Conceptual.Calendars#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/datesandcalendars2.cs#3)]
[!code-vb[Conceptual.Calendars#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/datesandcalendars2.vb#3)]

### Instantiate dates based on a calendar

Because <xref:System.DateTime> and <xref:System.DateTimeOffset> values are based on the Gregorian calendar, you must call an overloaded constructor that includes a parameter of type <xref:System.Globalization.Calendar> to instantiate a date value if you want to use the day, month, or year values from a different calendar. You can also call one of the overloads of a specific calendar's <xref:System.Globalization.Calendar.ToDateTime%2A?displayProperty=nameWithType> method to instantiate a <xref:System.DateTime> object based on the values of a particular calendar.

The following example instantiates one <xref:System.DateTime> value by passing a <xref:System.Globalization.HebrewCalendar> object to a <xref:System.DateTime> constructor, and instantiates a second <xref:System.DateTime> value by calling the <xref:System.Globalization.HebrewCalendar.ToDateTime%28System.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%29?displayProperty=nameWithType> method. Because the two values are created with identical values from the Hebrew calendar, the call to the <xref:System.DateTime.Equals%2A?displayProperty=nameWithType> method shows that the two <xref:System.DateTime> values are equal.

[!code-csharp[Conceptual.Calendars#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/instantiatehcdate1.cs#4)]
[!code-vb[Conceptual.Calendars#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/instantiatehcdate1.vb#4)]

### Represent dates in the current calendar

Date and time formatting methods always use the current calendar when converting dates to strings. This means that the string representation of the year, the month, and the day of the month reflect the current calendar, and do not necessarily reflect the Gregorian calendar.

The following example shows how the current calendar affects the string representation of a date. It changes the current culture to Chinese (Traditional, Taiwan), and instantiates a date value. It then displays the current calendar and the date, changes the current calendar to <xref:System.Globalization.TaiwanCalendar>, and displays the current calendar and date once again. The first time the date is displayed, it is represented as a date in the Gregorian calendar. The second time it is displayed, it is represented as a date in the Taiwan calendar.

[!code-csharp[Conceptual.Calendars#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/currentcalendar1.cs#5)]
[!code-vb[Conceptual.Calendars#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/currentcalendar1.vb#5)]

### Represent dates in a non-current calendar

To represent a date using a calendar that is not the current calendar of a particular culture, you must call methods of that <xref:System.Globalization.Calendar> object. For example, the <xref:System.Globalization.Calendar.GetYear%2A?displayProperty=nameWithType>, <xref:System.Globalization.Calendar.GetMonth%2A?displayProperty=nameWithType>, and <xref:System.Globalization.Calendar.GetDayOfMonth%2A?displayProperty=nameWithType> methods convert the year, month, and day to values that reflect a particular calendar.

> [!WARNING]
> Because some calendars are not optional calendars of any culture, representing dates in these calendars always requires that you call calendar methods. This is true of all calendars that derive from the <xref:System.Globalization.EastAsianLunisolarCalendar>, <xref:System.Globalization.JulianCalendar>, and <xref:System.Globalization.PersianCalendar> classes.

The following example uses a <xref:System.Globalization.JulianCalendar> object to instantiate a date, January 9, 1905, in the Julian calendar. When this date is displayed using the default (Gregorian) calendar, it is represented as January 22, 1905. Calls to individual <xref:System.Globalization.JulianCalendar> methods enable the date to be represented in the Julian calendar.

[!code-csharp[Conceptual.Calendars#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/noncurrentcalendar1.cs#6)]
[!code-vb[Conceptual.Calendars#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/noncurrentcalendar1.vb#6)]

### Calendars and date ranges

The earliest date supported by a calendar is indicated by that calendar's <xref:System.Globalization.Calendar.MinSupportedDateTime%2A?displayProperty=nameWithType> property. For the <xref:System.Globalization.GregorianCalendar> class, that date is January 1, 0001 C.E. Most of the other calendars in .NET support a later date. Trying to work with a date and time value that precedes a calendar's earliest supported date throws an <xref:System.ArgumentOutOfRangeException> exception.

However, there is one important exception. The default (uninitialized) value of a <xref:System.DateTime> object and a <xref:System.DateTimeOffset> object is equal to the <xref:System.Globalization.GregorianCalendar.MinSupportedDateTime%2A?displayProperty=nameWithType> value. If you try to format this date in a calendar that does not support January 1, 0001 C.E. and you do not provide a format specifier, the formatting method uses the "s" (sortable date/time pattern) format specifier instead of the "G" (general date/time pattern) format specifier. As a result, the formatting operation does not throw an <xref:System.ArgumentOutOfRangeException> exception. Instead, it returns the unsupported date. This is illustrated in the following example, which displays the value of <xref:System.DateTime.MinValue?displayProperty=nameWithType> when the current culture is set to Japanese (Japan) with the Japanese calendar, and to Arabic (Egypt) with the Um Al Qura calendar. It also sets the current culture to English (United States) and calls the <xref:System.DateTime.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method with each of these <xref:System.Globalization.CultureInfo> objects. In each case, the date is displayed by using the sortable date/time pattern.

[!code-csharp[Conceptual.Calendars#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/minsupporteddatetime1.cs#11)]
[!code-vb[Conceptual.Calendars#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/minsupporteddatetime1.vb#11)]

## Work with eras

Calendars typically divide dates into eras. However, the <xref:System.Globalization.Calendar> classes in .NET do not support every era defined by a calendar, and most of the <xref:System.Globalization.Calendar> classes support only a single era. Only the <xref:System.Globalization.JapaneseCalendar> and <xref:System.Globalization.JapaneseLunisolarCalendar> classes support multiple eras.

> [!IMPORTANT]
> The Reiwa era, a new era in the <xref:System.Globalization.JapaneseCalendar> and <xref:System.Globalization.JapaneseLunisolarCalendar>, begins on May 1, 2019. This change affects all applications that use these calendars. See the following articles for more information:
>
> - [Handling a new era in the Japanese calendar in .NET](https://devblogs.microsoft.com/dotnet/handling-a-new-era-in-the-japanese-calendar-in-net/), which documents features added to .NET to support calendars with multiple eras and discusses best practices to use when handling multi-era calendars.
> - [Prepare your application for the Japanese era change](/windows/uwp/design/globalizing/japanese-era-change), which provides information on testing your applications on Windows to ensure their readiness for the era change.
> - [Summary of new Japanese Era updates for .NET Framework](https://support.microsoft.com/help/4477957/new-japanese-era-updates-for-net-framework), which lists .NET Framework updates for individual Windows versions that are related to the new Japanese calendar era, notes new .NET Framework features for multi-era support, and includes things to look for in testing your applications.

An era in most calendars denotes an extremely long time period. In the Gregorian calendar, for example, the current era spans more than two millennia. For the <xref:System.Globalization.JapaneseCalendar> and the <xref:System.Globalization.JapaneseLunisolarCalendar>, the two calendars that support multiple eras, this is not the case. An era corresponds to the period of an emperor's reign. Support for multiple eras, particularly when the upper limit of the current era is unknown, poses special challenges.

### Eras and era names

In .NET, integers that represent the eras supported by a particular calendar implementation are stored in reverse order in the <xref:System.Globalization.Calendar.Eras%2A?displayProperty=nameWithType> array. The current era (which is the era with the latest time range) is at index zero, and for <xref:System.Globalization.Calendar> classes that support multiple eras, each successive index reflects the previous era. The static <xref:System.Globalization.Calendar.CurrentEra?displayProperty=nameWithType> property defines the index of the current era in the <xref:System.Globalization.Calendar.Eras%2A?displayProperty=nameWithType> array; it is a constant whose value is always zero. Individual <xref:System.Globalization.Calendar> classes also include static fields that return the value of the current era. They are listed in the following table.

| Calendar class                                        | Current era field                                                 |
| ----------------------------------------------------- | ----------------------------------------------------------------- |
| <xref:System.Globalization.ChineseLunisolarCalendar>  | <xref:System.Globalization.ChineseLunisolarCalendar.ChineseEra>   |
| <xref:System.Globalization.GregorianCalendar>         | <xref:System.Globalization.GregorianCalendar.ADEra>               |
| <xref:System.Globalization.HebrewCalendar>            | <xref:System.Globalization.HebrewCalendar.HebrewEra>              |
| <xref:System.Globalization.HijriCalendar>             | <xref:System.Globalization.HijriCalendar.HijriEra>                |
| <xref:System.Globalization.JapaneseLunisolarCalendar> | <xref:System.Globalization.JapaneseLunisolarCalendar.JapaneseEra> |
| <xref:System.Globalization.JulianCalendar>            | <xref:System.Globalization.JulianCalendar.JulianEra>              |
| <xref:System.Globalization.KoreanCalendar>            | <xref:System.Globalization.KoreanCalendar.KoreanEra>              |
| <xref:System.Globalization.KoreanLunisolarCalendar>   | <xref:System.Globalization.KoreanLunisolarCalendar.GregorianEra>  |
| <xref:System.Globalization.PersianCalendar>           | <xref:System.Globalization.PersianCalendar.PersianEra>            |
| <xref:System.Globalization.ThaiBuddhistCalendar>      | <xref:System.Globalization.ThaiBuddhistCalendar.ThaiBuddhistEra>  |
| <xref:System.Globalization.UmAlQuraCalendar>          | <xref:System.Globalization.UmAlQuraCalendar.UmAlQuraEra>          |

The name that corresponds to a particular era number can be retrieved by passing the era number to the <xref:System.Globalization.DateTimeFormatInfo.GetEraName%2A?displayProperty=nameWithType> or <xref:System.Globalization.DateTimeFormatInfo.GetAbbreviatedEraName%2A?displayProperty=nameWithType> method. The following example calls these methods to retrieve information about era support in the <xref:System.Globalization.GregorianCalendar> class. It displays the Gregorian calendar date that corresponds to January 1 of the second year of the current era, as well as the Gregorian calendar date that corresponds to January 1 of the second year of each supported Japanese calendar era.

[!code-csharp[Conceptual.Calendars#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/instantiatewithera1.cs)]
[!code-vb[Conceptual.Calendars#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/instantiatewithera1.vb)]

In addition, the "g" custom date and time format string includes a calendar's era name in the string representation of a date and time. For more information, see [Custom date and time format strings](../base-types/custom-date-and-time-format-strings.md).

### Instantiatie a date with an era

For the two <xref:System.Globalization.Calendar> classes that support multiple eras, a date that consists of a particular year, month, and day of the month value can be ambiguous. For example, all eras supported by the <xref:System.Globalization.JapaneseCalendar> have years whose number is 1. Ordinarily, if an era is not specified, both date and time and calendar methods assume that values belong to the current era. This is true of the <xref:System.DateTime.%23ctor%2A> and <xref:System.DateTimeOffset.%23ctor%2A> constructors that include parameters of type <xref:System.Globalization.Calendar>, as well as the [JapaneseCalendar.ToDateTime](xref:System.Globalization.Calendar.ToDateTime(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)) and [JapaneseLunisolarCalendar.ToDateTime](xref:System.Globalization.Calendar.ToDateTime(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)) methods. The following example instantiates a date that represents January 1 of the second year of an unspecified era. If you execute the example when the Reiwa era is the current era, the date is interpreted as the second year of the Reiwa era. The era, 令和, precedes the year in the string returned by the <xref:System.DateTime.ToString(System.String,System.IFormatProvider)?displayProperty=nameWithType> method and corresponds to January 1, 2020, in the Gregorian calendar. (The Reiwa era begins in the year 2019 of the Gregorian calendar.)

[!code-csharp[A date in the current era](~/samples/snippets/standard/datetime/calendars/current-era/cs/program.cs)]
[!code-vb[A date in the current era](~/samples/snippets/standard/datetime/calendars/current-era/vb/program.vb)]

However, if the era changes, the intent of this code becomes ambiguous. Is the date intended to represent the second year of the current era, or is it intended to represent the second year of the Heisei era? There are two ways to avoid this ambiguity:

- Instantiate the date and time value using the default <xref:System.Globalization.GregorianCalendar> class. You can then use the Japanese calendar or the Japanese Lunisolar calendar for the string representation of dates, as the following example shows.

  [!code-csharp[Insantiating a Gregorian date](~/samples/snippets/standard/datetime/calendars/gregorian/cs/program.cs)]
  [!code-vb[Instantiating a Gregorian date](~/samples/snippets/standard/datetime/calendars/gregorian/vb/program.vb)]

- Call a date and time method that explicitly specifies an era. This includes the following methods:

  - The <xref:System.Globalization.Calendar.ToDateTime(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)> method of the <xref:System.Globalization.JapaneseCalendar> or <xref:System.Globalization.JapaneseLunisolarCalendar> class.

  - A <xref:System.DateTime> or <xref:System.DateTimeOffset> parsing method, such as <xref:System.DateTime.Parse%2A>, <xref:System.DateTime.TryParse%2A>, <xref:System.DateTime.ParseExact%2A>, or <xref:System.DateTime.TryParseExact%2A>, that includes the string to be parsed and optionally a <xref:System.Globalization.DateTimeStyles> argument if the current culture is Japanese-Japan ("ja-JP") and that culture's calendar is the <xref:System.Globalization.JapaneseCalendar>. The string to be parsed must include the era.

  - A <xref:System.DateTime> or <xref:System.DateTimeOffset> parsing method that includes a `provider` parameter of type <xref:System.IFormatProvider>. `provider` must be either a <xref:System.Globalization.CultureInfo> object that represents the Japanese-Japan ("ja-JP") culture whose current calendar is <xref:System.Globalization.JapaneseCalendar> or a <xref:System.Globalization.DateTimeFormatInfo> object whose <xref:System.Globalization.DateTimeFormatInfo.Calendar> property is <xref:System.Globalization.JapaneseCalendar>. The string to be parsed must include the era.

  The following example uses three of these methods to instantiate a date and time in the Meiji era, which began on September 8, 1868, and ended on July 29, 1912.

  [!code-csharp[A date in a specified era](~/samples/snippets/standard/datetime/calendars/specify-era/cs/program.cs)]
  [!code-vb[A date in a specified era](~/samples/snippets/standard/datetime/calendars/specify-era/vb/program.vb)]

> [!TIP]
> When working with calendars that support multiple eras, *always* use the Gregorian date to instantiate a date, or specify the era when you instantiate a date and time based on that calendar.

In specifying an era to the <xref:System.Globalization.Calendar.ToDateTime(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)> method, you provide the index of the era in the calendar's <xref:System.Globalization.Calendar.Eras> property. For calendars whose eras are subject to change, however, these indexes are not constant values; the current era is at index 0, and the oldest era is at index `Eras.Length - 1`. When a new era is added to a calendar, the indexes of the previous eras increase by one. You can supply the appropriate era index as follows:

- For dates in the current era, always use the calendar's <xref:System.Globalization.Calendar.CurrentEra> property.

- For dates in a specified era, use the <xref:System.Globalization.DateTimeFormatInfo.GetEraName%2A?displayProperty=nameWithType> method to retrieve the index that corresponds to a specified era name. This requires that the <xref:System.Globalization.JapaneseCalendar> be the current calendar of the <xref:System.Globalization.CultureInfo> object that represents the ja-JP culture.  (This technique works for the <xref:System.Globalization.JapaneseLunisolarCalendar> as well, since it supports the same eras as the <xref:System.Globalization.JapaneseCalendar>.) The previous example illustrates this approach.

### Calendars, eras, and date ranges: Relaxed range checks

Very much like individual calendars have supported date ranges, eras in the <xref:System.Globalization.JapaneseCalendar> and <xref:System.Globalization.JapaneseLunisolarCalendar> classes also have supported ranges. Previously, .NET used strict era range checks to ensure that an era-specific date was within the range of that era. That is, if a date is outside of the range of the specified era, the method throws an <xref:System.ArgumentOutOfRangeException>. Currently, .NET uses relaxed ranged checking by default. Updates to all versions of .NET introduced relaxed era range checks; the attempt to instantiate an era-specific date that is outside the range of the specified era "overflows" into the following era, and no exception is thrown.

The following example attempts to instantiate a date in the 65th year of the Showa era, which began on December 25, 1926 and ended on January 7, 1989. This date corresponds to January 9, 1990, which is outside the range of the Showa era in the <xref:System.Globalization.JapaneseCalendar>. As the output from the example illustrates, the date displayed by the example is January 9, 1990, in the second year of the Heisei era.

  [!code-csharp[Relaxed range checks](~/samples/snippets/standard/datetime/calendars/relaxed-range/cs/program.cs)]
  [!code-vb[Relaxed range checks](~/samples/snippets/standard/datetime/calendars/relaxed-range/vb/program.vb)]

If relaxed range checks are undesirable, you can restore strict range checks in a number of ways, depending on the version of .NET on which your application is running:

- **.NET Core:** Add the following to the *.netcore.runtime.json* config file:

  ```json
  "runtimeOptions": {
    "configProperties": {
        "Switch.System.Globalization.EnforceJapaneseEraYearRanges": true
    }
  }
  ```

- **.NET Framework 4.6 or later:** Set the following AppContext switch in the *app.config* file:

  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <runtime>
      <AppContextSwitchOverrides value="Switch.System.Globalization.EnforceJapaneseEraYearRanges=true" />
    </runtime>
  </configuration>
  ```

- **.NET Framework 4.5.2 or earlier:** Set the following registry value:

  |           | Value                                                               |
  | --------- | ------------------------------------------------------------------- |
  | **Key**   | **HKEY_LOCAL_MACHINE\Software\Microsoft\\.NETFramework\AppContext** |
  | **Entry** | Switch.System.Globalization.EnforceJapaneseEraYearRanges            |
  | **Type**  | REG_SZ                                                              |
  | **Value** | true                                                                |

With strict range checks enabled, the previous example throws an <xref:System.ArgumentOutOfRangeException> and displays the following output:

```console
Unhandled Exception: System.ArgumentOutOfRangeException: Valid values are between 1 and 64, inclusive.
Parameter name: year
   at System.Globalization.GregorianCalendarHelper.GetYearOffset(Int32 year, Int32 era, Boolean throwOnError)
   at System.Globalization.GregorianCalendarHelper.ToDateTime(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, Int32 millisecond, Int32 era)
   at Example.Main()
```

### Represent dates in calendars with multiple eras

If a <xref:System.Globalization.Calendar> object supports eras and is the current calendar of a <xref:System.Globalization.CultureInfo> object, the era is included in the string representation of a date and time value for the full date and time, long date, and short date patterns. The following example displays these date patterns when the current culture is Japan (Japanese) and the current calendar is the Japanese calendar.

[!code-csharp[Conceptual.Calendars#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/formatstrings1.cs#8)]
[!code-vb[Conceptual.Calendars#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/formatstrings1.vb#8)]

> [!WARNING]
> The <xref:System.Globalization.JapaneseCalendar> class is the only calendar class in .NET that both supports dates in more than one era and that can be the current calendar of a <xref:System.Globalization.CultureInfo> object - specifically, of a <xref:System.Globalization.CultureInfo> object that represents the Japanese (Japan) culture.

For all calendars, the "g" custom format specifier includes the era in the result string. The following example uses the "MM-dd-yyyy g" custom format string to include the era in the result string when the current calendar is the Gregorian calendar.

[!code-csharp[Conceptual.Calendars#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/formatstrings2.cs#9)]
[!code-vb[Conceptual.Calendars#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/formatstrings2.vb#9)]

In cases where the string representation of a date is expressed in a calendar that is not the current calendar, the <xref:System.Globalization.Calendar> class includes a <xref:System.Globalization.Calendar.GetEra%2A?displayProperty=nameWithType> method that can be used along with the <xref:System.Globalization.Calendar.GetYear%2A?displayProperty=nameWithType>, <xref:System.Globalization.Calendar.GetMonth%2A?displayProperty=nameWithType>, and <xref:System.Globalization.Calendar.GetDayOfMonth%2A?displayProperty=nameWithType> methods to unambiguously indicate a date as well as the era to which it belongs. The following example uses the <xref:System.Globalization.JapaneseLunisolarCalendar> class to provide an illustration. However, note that including a meaningful name or abbreviation instead of an integer for the era in the result string requires that you instantiate a <xref:System.Globalization.DateTimeFormatInfo> object and make <xref:System.Globalization.JapaneseCalendar> its current calendar. (The <xref:System.Globalization.JapaneseLunisolarCalendar> calendar cannot be the current calendar of any culture, but in this case the two calendars share the same eras.)

[!code-csharp[Conceptual.Calendars#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.calendars/cs/formatstrings3.cs#10)]
[!code-vb[Conceptual.Calendars#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.calendars/vb/formatstrings3.vb#10)]

In the Japanese calendars, the first year of an era is called Gannen (元年). For example, instead of Heisei 1, the first year of the Heisei era can be described as Heisei Gannen. .NET adopts this convention in formatting operations for dates and times formatted with the following standard or custom date and time format strings when they are used with a <xref:System.Globalization.CultureInfo> object that represents the Japanese-Japan ("ja-JP") culture with the <xref:System.Globalization.JapaneseCalendar> class:

- [The long date pattern](../base-types/standard-date-and-time-format-strings.md#LongDate), indicated by the "D" standard date and time format string.
- [The full date long time pattern](../base-types/standard-date-and-time-format-strings.md#FullDateLongTime), indicated by the "F" standard date and time format string.
- [The full date short time pattern](../base-types/standard-date-and-time-format-strings.md#FullDateShortTime), indicated by the "f" standard date and time format string.
- [The year/month pattern](../base-types/standard-date-and-time-format-strings.md#YearMonth), indicated by the Y" or "y" standard date and time format string.
- [The "ggy'年'" or "ggy年" [custom date and time format string](../base-types/custom-date-and-time-format-strings.md).

For example, the following example displays a date in the first year of the Heisei era in the <xref:System.Globalization.JapaneseCalendar>.

  [!code-csharp[gannen](~/samples/snippets/standard/datetime/calendars/gannen/cs/program.cs)]
  [!code-vb[gannen](~/samples/snippets/standard/datetime/calendars/gannen/vb/gannen-fmt.vb)]

If this behavior is undesirable in formatting operations, you can restore the previous behavior, which always represents the first year of an era as "1" rather than "Gannen", by doing the following, depending on the version of .NET:

- **.NET Core:** Add the following to the *.netcore.runtime.json* config file:

  ```json
  "runtimeOptions": {
    "configProperties": {
        "Switch.System.Globalization.FormatJapaneseFirstYearAsANumber": true
    }
  }
  ```

- **.NET Framework 4.6 or later:** Set the following AppContext switch in the *app.config* file:

  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <runtime>
      <AppContextSwitchOverrides value="Switch.System.Globalization.FormatJapaneseFirstYearAsANumber=true" />
    </runtime>
  </configuration>
  ```

- **.NET Framework 4.5.2 or earlier:** Set the following registry value:

   |           | Value                                                               |
   | --------- | ------------------------------------------------------------------- |
   | **Key**   | **HKEY_LOCAL_MACHINE\Software\Microsoft\\.NETFramework\AppContext** |
   | **Entry** | Switch.System.Globalization.FormatJapaneseFirstYearAsANumber        |
   | **Type**  | REG_SZ                                                              |
   | **Value** | true                                                                |

With gannen support in formatting operations disabled, the previous example displays the following output:

```console
Japanese calendar date: 平成1年8月18日 (Gregorian: Friday, August 18, 1989)
```

.NET has also been updated so that date and time parsing operations support strings that contain the year represented as either "1" or Gannen. Although you should not need to do this, you can restore the previous behavior to recognizes only "1" as the first year of an era. You can do this as follows, depending on the version of .NET:

- **.NET Core:** Add the following to the *.netcore.runtime.json* config file:

  ```json
  "runtimeOptions": {
    "configProperties": {
        "Switch.System.Globalization.EnforceLegacyJapaneseDateParsing": true
    }
  }
  ```

- **.NET Framework 4.6 or later:** Set the following AppContext switch in the *app.config* file:

  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <runtime>
      <AppContextSwitchOverrides value="Switch.System.Globalization.EnforceLegacyJapaneseDateParsing=true" />
    </runtime>
  </configuration>
  ```

- **.NET Framework 4.5.2 or earlier:** Set the following registry value:

   |           | Value                                                               |
   | --------- | ------------------------------------------------------------------- |
   | **Key**   | **HKEY_LOCAL_MACHINE\Software\Microsoft\\.NETFramework\AppContext** |
   | **Entry** | Switch.System.Globalization.EnforceLegacyJapaneseDateParsing        |
   | **Type**  | REG_SZ                                                              |
   | **Value** | true                                                                |

## See also

- [How to: Display dates in non-Gregorian calendars](../base-types/how-to-display-dates-in-non-gregorian-calendars.md)
- [Calendar class](xref:System.Globalization.Calendar)
