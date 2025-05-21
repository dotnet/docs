---
title: System.DateTime struct
description: Learn about the System.DateTime struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.DateTime struct

[!INCLUDE [context](includes/context.md)]

[!INCLUDE[japanese-era-note](./includes/calendar-era.md)]

## Overview

The <xref:System.DateTime> value type represents dates and times with values ranging from 00:00:00 (midnight), January 1, 0001 Anno Domini (Common Era) through 11:59:59 P.M., December 31, 9999 A.D. (C.E.) in the Gregorian calendar.

Time values are measured in 100-nanosecond units called ticks. A particular date is the number of ticks since 12:00 midnight, January 1, 0001 A.D. (C.E.) in the <xref:System.Globalization.GregorianCalendar> calendar. The number excludes ticks that would be added by leap seconds. For example, a ticks value of 31241376000000000L represents the date Friday, January 01, 0100 12:00:00 midnight. A <xref:System.DateTime> value is always expressed in the context of an explicit or default calendar.

> [!NOTE]
> If you're working with a ticks value that you want to convert to some other time interval, such as minutes or seconds, you should use the <xref:System.TimeSpan.TicksPerDay?displayProperty=nameWithType>, <xref:System.TimeSpan.TicksPerHour?displayProperty=nameWithType>, <xref:System.TimeSpan.TicksPerMinute?displayProperty=nameWithType>, <xref:System.TimeSpan.TicksPerSecond?displayProperty=nameWithType>, or <xref:System.TimeSpan.TicksPerMillisecond?displayProperty=nameWithType> constant to perform the conversion. For example, to add the number of seconds represented by a specified number of ticks to the <xref:System.DateTime.Second> component of a <xref:System.DateTime> value, you can use the expression `dateValue.Second + nTicks/Timespan.TicksPerSecond`.

You can view the source for the entire set of examples from this article in either [Visual Basic](https://github.com/dotnet/dotnet-api-docs/tree/main/snippets/visualbasic/System.DateTime/), [F#](https://github.com/dotnet/dotnet-api-docs/tree/main/snippets/fsharp/System.DateTime/), or [C#](https://github.com/dotnet/dotnet-api-docs/tree/main/snippets/csharp/System.DateTime/).

> [!NOTE]
> An alternative to the <xref:System.DateTime> structure for working with date and time values in particular time zones is the <xref:System.DateTimeOffset> structure. The <xref:System.DateTimeOffset> structure stores date and time information in a private <xref:System.DateTime> field and the number of minutes by which that date and time differs from UTC in a private <xref:System.Int16> field. This makes it possible for a <xref:System.DateTimeOffset> value to reflect the time in a particular time zone, whereas a <xref:System.DateTime> value can unambiguously reflect only UTC and the local time zone's time. For a discussion about when to use the <xref:System.DateTime> structure or the <xref:System.DateTimeOffset> structure when working with date and time values, see [Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](../../standard/datetime/choosing-between-datetime.md).

## Quick links to example code

[!INCLUDE[interactive-note](./includes/csharp-interactive-with-utc-note.md)]

This article includes several examples that use the `DateTime` type:

### Initialization examples

- [Invoke a constructor](#initialization-01)
- [Invoke the implicit parameterless constructor](#initialization-02)
- [Assignment from return value](#initialization-03)
- [Parsing a string that represents a date and time](#initialization-04)
- [Visual Basic syntax to initialize a date and time](#initialization-05)

### Format `DateTime` objects as strings examples

- [Use the default date time format](#formatting-01)
- [Format a date and time using a specific culture](#formatting-02)
- [Format a date time using a standard or custom format string](#formatting-03)
- [Specify both a format string and a specific culture](#formatting-04)
- [Format a date time using the ISO 8601 standard for web services](#formatting-05)

### Parse strings as `DateTime` objects examples

- [Use `Parse` or `TryParse` to convert a string to a date and time](#parsing-01)
- [Use `ParseExact` or `TryParseExact` to convert a string in a known format](#parsing-02)
- [Convert from the ISO 8601 string representation to a date and time](#parsing-03)

### `DateTime` resolution examples

- [Explore the resolution of date and time values](#resolution-01)
- [Comparing for equality within a tolerance](#comparison-01)

### Culture and calendars examples

- [Display date and time values using culture specific calendars](#calendars-01)
- [Parse strings according to a culture specific calendar](#calendars-02)
- [Initialize a date and time from a specific culture's calendar](#calendars-03)
- [Accessing date and time properties using a specific culture's calendar](#calendars-04)
- [Retrieving the week of the year using culture specific calendars](#calendars-05)

### Persistence examples

- [Persisting date and time values as strings in the local time zone](#persistence-01)
- [Persisting date and time values as strings in a culture and time invariant format](#persistence-02)
- [Persisting date and time values as integers](#persistence-03)
- [Persisting date and time values using the `XmlSerializer`](#persistence-04)

## Initialize a DateTime object

You can assign an initial value to a new `DateTime` value in many different ways:

- Calling a constructor, either one where you specify arguments for values, or use the implicit parameterless constructor.
- Assigning a `DateTime` to the return value of a property or method.
- Parsing a `DateTime` value from its string representation.
- Using Visual Basic-specific language features to instantiate a `DateTime`.

The following code snippets show examples of each.

### Invoke constructors

You call any of the overloads of the <xref:System.DateTime> constructor that specify elements of the date and time value (such as the year, month, and day, or the number of ticks). The following code creates a specific date using the <xref:System.DateTime> constructor specifying the year, month, day, hour, minute, and second.

<a name="initialization-01"></a>
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Instantiation.vb" id="Snippet1":::
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Instantiation.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Instantiation.fs" id="Snippet1":::

You invoke the `DateTime` structure's implicit parameterless constructor when you want a `DateTime` initialized to its default value. (For details on the implicit parameterless constructor of a value type, see [Value Types](/dotnet/csharp/language-reference/keywords/value-types).) Some compilers also support declaring a <xref:System.DateTime> value without explicitly assigning a value to it. Creating a value without an explicit initialization also results in the default value. The following example illustrates the <xref:System.DateTime> implicit parameterless constructor in C# and Visual Basic, as well as a <xref:System.DateTime> declaration without assignment in Visual Basic.

<a name="initialization-02"></a>
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Instantiation.vb" id="Snippet5":::
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Instantiation.cs" interactive="try-dotnet-method" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Instantiation.fs" id="Snippet5":::

### Assign a computed value

You can assign the <xref:System.DateTime> object a date and time value returned by a property or method. The following example assigns the current date and time, the current Coordinated Universal Time (UTC) date and time, and the current date to three new <xref:System.DateTime> variables.

<a name="initialization-03"></a>
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Instantiation.vb" id="Snippet3":::
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Instantiation.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Instantiation.fs" id="Snippet3":::

### Parse a string that represents a DateTime

The <xref:System.DateTime.Parse%2A>, <xref:System.DateTime.ParseExact%2A>, <xref:System.DateTime.TryParse%2A>, and <xref:System.DateTime.TryParseExact%2A> methods all convert a string to its equivalent date and time value. The following examples use the <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.ParseExact%2A> methods to parse a string and convert it to a <xref:System.DateTime> value. The second format uses a form supported by the [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) standard for a representing date and time in string format. This standard representation is often used to transfer date information in web services.

<a name="initialization-04"></a>
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Instantiation.vb" id="Snippet4":::
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Instantiation.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Instantiation.fs" id="Snippet4":::

The <xref:System.DateTime.TryParse%2A> and <xref:System.DateTime.TryParseExact%2A> methods indicate whether a string is a valid representation of a <xref:System.DateTime> value and, if it is, performs the conversion.

### Language-specific syntax for Visual Basic

The following Visual Basic statement initializes a new <xref:System.DateTime> value.

<a name="initialization-05"></a>
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Instantiation.vb" id="Snippet2":::

## DateTime values and their string representations

Internally, all <xref:System.DateTime> values are represented as the number of ticks (the number of 100-nanosecond intervals) that have elapsed since 12:00:00 midnight, January 1, 0001. The actual <xref:System.DateTime> value is independent of the way in which that value appears when displayed. The appearance of a <xref:System.DateTime> value is the result of a formatting operation that converts a value to its string representation.

The appearance of date and time values is dependent on culture, international standards, application requirements, and personal preference. The <xref:System.DateTime> structure offers flexibility in formatting date and time values through overloads of  <xref:System.DateTime.ToString%2A>. The default <xref:System.DateTime.ToString?displayProperty=nameWithType> method returns the string representation of a date and time value using the current culture's short date and long time pattern. The following example uses the default <xref:System.DateTime.ToString?displayProperty=nameWithType> method. It displays the date and time using the short date and long time pattern for the current culture. The en-US culture is the current culture on the computer on which the example was run.

<a name="formatting-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/StringFormat.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/StringFormat.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/StringFormat.vb" id="Snippet1":::

You may need to format dates in a specific culture to support web scenarios where the server may be in a different culture from the client. You specify the culture using the <xref:System.DateTime.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method to create the short date and long time representation in a specific culture. The following example uses the <xref:System.DateTime.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method to display the date and time using the short date and long time pattern for the fr-FR culture.

<a name="formatting-02"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/StringFormat.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/StringFormat.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/StringFormat.vb" id="Snippet2":::

Other applications may require different string representations of a date. The <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> method returns the string representation defined by a standard or custom format specifier using the formatting conventions of the current culture. The following example uses the <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> method to display the full date and time pattern for the en-US culture, the current culture on the computer on which the example was run.

<a name="formatting-03"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/StringFormat.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/StringFormat.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/StringFormat.vb" id="Snippet3":::

Finally, you can specify both the culture and the format using the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> method. The following example uses the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> method to display the full date and time pattern for the fr-FR culture.

<a name="formatting-04"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/StringFormat.cs" interactive="try-dotnet-method" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/StringFormat.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/StringFormat.vb" id="Snippet4":::

The <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> overload can also be used with a custom format string to specify other formats. The following example shows how to format a string using the [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) standard format often used for web services. The Iso 8601 format does not have a corresponding standard format string.

<a name="formatting-05"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/StringFormat.cs" interactive="try-dotnet-method" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/StringFormat.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/StringFormat.vb" id="Snippet5":::

For more information about formatting <xref:System.DateTime> values, see  [Standard Date and Time Format Strings](../../standard/base-types/standard-date-and-time-format-strings.md) and [Custom Date and Time Format Strings](../../standard/base-types/custom-date-and-time-format-strings.md).

## Parse DateTime values from strings

Parsing converts the string representation of a date and time to a <xref:System.DateTime> value. Typically, date and time strings have two different usages in applications:

- A date and time takes a variety of forms and reflects the conventions of either the current culture or a specific culture. For example, an application allows a user whose current culture is en-US to input a date value as "12/15/2013" or "December 15, 2013". It allows a user whose current culture is en-gb to input a date value as "15/12/2013" or "15 December 2013."

- A date and time is represented in a predefined format. For example, an application serializes a date as "20130103" independently of the culture on which the app is running. An application may require dates be input in the current culture's short date format.

You use the <xref:System.DateTime.Parse%2A> or <xref:System.DateTime.TryParse%2A> method to convert a string from one of the common date and time formats used by a culture to a <xref:System.DateTime> value. The following example shows how you can use <xref:System.DateTime.TryParse%2A> to convert date strings in different culture-specific formats to a <xref:System.DateTime> value. It changes the current culture to English (United Kingdom) and calls the <xref:System.DateTime.GetDateTimeFormats> method to generate an array of date and time strings. It then passes each element in the array to the <xref:System.DateTime.TryParse%2A> method. The output from the example shows the parsing method was able to successfully convert each of the culture-specific date and time strings.

<a name="parsing-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Parsing.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Parsing.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Parsing.vb" id="Snippet1":::

You use the <xref:System.DateTime.ParseExact%2A> and <xref:System.DateTime.TryParseExact%2A> methods to convert a string that must match a particular format or formats to a <xref:System.DateTime> value. You specify one or more date and time format strings as a parameter to the parsing method. The following example uses the <xref:System.DateTime.TryParseExact%28System.String%2CSystem.String%5B%5D%2CSystem.IFormatProvider%2CSystem.Globalization.DateTimeStyles%2CSystem.DateTime%40%29> method to convert strings that must be either in a "yyyyMMdd" format or a "HHmmss" format to <xref:System.DateTime> values.

<a name="parsing-02"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Parsing.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Parsing.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Parsing.vb" id="Snippet2":::

One common use for <xref:System.DateTime.ParseExact%2A> is to convert a string representation from a web service, usually in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) standard format. The following code shows the correct format string to use:

<a name="parsing-03"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Parsing.cs" interactive="try-dotnet-method" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Parsing.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Parsing.vb" id="Snippet3":::

If a string cannot be parsed, the <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.ParseExact%2A> methods throw an exception. The <xref:System.DateTime.TryParse%2A> and <xref:System.DateTime.TryParseExact%2A> methods return a <xref:System.Boolean> value that indicates whether the conversion succeeded or failed. You should use the <xref:System.DateTime.TryParse%2A> or <xref:System.DateTime.TryParseExact%2A> methods in scenarios where performance is important. The parsing operation for date and time strings tends to have a high failure rate, and exception handling is expensive. Use these methods if strings are input by users or coming from an unknown source.

For more information about parsing date and time values, see [Parsing Date and Time Strings](../../standard/base-types/parsing-datetime.md).

## DateTime values

Descriptions of time values in the <xref:System.DateTime> type are often expressed using the Coordinated Universal Time (UTC) standard. Coordinated Universal Time is the internationally recognized name for Greenwich Mean Time (GMT). Coordinated Universal Time is the time as measured at zero degrees longitude, the UTC origin point. Daylight saving time is not applicable to UTC.

Local time is relative to a particular time zone. A time zone is associated with a time zone offset. A time zone offset is the displacement of the time zone measured in hours from the UTC origin point. In addition, local time is optionally affected by daylight saving time, which adds or subtracts a time interval adjustment. Local time is calculated by adding the time zone offset to UTC and adjusting for daylight saving time if necessary. The time zone offset at the UTC origin point is zero.

UTC time is suitable for calculations, comparisons, and storing dates and time in files. Local time is appropriate for display in user interfaces of desktop applications. Time zone-aware applications (such as many Web applications) also need to work with a number of other time zones.

If the <xref:System.DateTime.Kind> property of a <xref:System.DateTime> object is <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>, it is unspecified whether the time represented is local time, UTC time, or a time in some other time zone.

## DateTime resolution

> [!NOTE]
> As an alternative to performing date and time arithmetic on <xref:System.DateTime> values to measure elapsed time, you can use the <xref:System.Diagnostics.Stopwatch> class.

The <xref:System.DateTime.Ticks> property expresses date and time values in units of one ten-millionth of a second. The <xref:System.DateTime.Millisecond> property returns the thousandths of a second in a date and time value. Using repeated calls to the <xref:System.DateTime.Now?displayProperty=nameWithType> property to measure elapsed time is dependent on the system clock. The system clock on Windows 7 and Windows 8 systems has a resolution of approximately 15 milliseconds. This resolution affects small time intervals less than 100 milliseconds.

The following example illustrates the dependence of current date and time values on the resolution of the system clock. In the example, an outer loop repeats 20 times, and an inner loop serves to delay the outer loop. If the value of the outer loop counter is 10, a call to the <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> method introduces a five-millisecond delay. The following example shows the number of milliseconds returned by the `DateTime.Now.Milliseconds` property changes only after the call to <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.

<a name="resolution-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Resolution.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Resolution.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Resolution.vb" id="Snippet1":::

## DateTime operations

A calculation using a <xref:System.DateTime> structure, such as <xref:System.DateTime.Add%2A> or <xref:System.DateTime.Subtract%2A>, does not modify the value of the structure. Instead, the calculation returns a new <xref:System.DateTime> structure whose value is the result of the calculation.

Conversion operations between time zones (such as between UTC and local time, or between one time zone and another) take daylight saving time into account, but arithmetic and comparison operations do not.

The <xref:System.DateTime> structure itself offers limited support for converting from one time zone to another. You can use the <xref:System.DateTime.ToLocalTime%2A> method to convert UTC to local time, or you can use the <xref:System.DateTime.ToUniversalTime%2A> method to convert from local time to UTC. However, a full set of time zone conversion methods is available in the <xref:System.TimeZoneInfo> class. You convert the time in any one of the world's time zones to the time in any other time zone using these methods.

Calculations and comparisons of <xref:System.DateTime> objects are meaningful only if the objects represent times in the same time zone. You can use a <xref:System.TimeZoneInfo> object to represent a <xref:System.DateTime> value's time zone, although the two are loosely coupled. A <xref:System.DateTime> object does not have a property that returns an object that represents that date and time value's time zone. The <xref:System.DateTime.Kind> property indicates if a `DateTime` represents UTC, local time, or is unspecified. In a time zone-aware application, you must rely on some external mechanism to determine the time zone in which a <xref:System.DateTime> object was created. You could use a structure that wraps both the <xref:System.DateTime> value and the <xref:System.TimeZoneInfo> object that represents the <xref:System.DateTime> value's time zone. For details on using UTC in calculations and comparisons with <xref:System.DateTime> values, see [Performing Arithmetic Operations with Dates and Times](../../standard/datetime/performing-arithmetic-operations.md).

Each <xref:System.DateTime> member implicitly uses the Gregorian calendar to perform its operation. Exceptions are methods that implicitly specify a calendar. These include constructors that specify a calendar, and methods with a parameter derived from <xref:System.IFormatProvider>, such as <xref:System.Globalization.DateTimeFormatInfo?displayProperty=nameWithType>.

Operations by members of the <xref:System.DateTime> type take into account details such as leap years and the number of days in a month.

## DateTime values and calendars

The .NET Class Library includes a number of calendar classes, all of which are derived from the <xref:System.Globalization.Calendar> class. They are:

- The <xref:System.Globalization.ChineseLunisolarCalendar> class.
- The <xref:System.Globalization.EastAsianLunisolarCalendar> class.
- The <xref:System.Globalization.GregorianCalendar> class.
- The <xref:System.Globalization.HebrewCalendar> class.
- The <xref:System.Globalization.HijriCalendar> class.
- The <xref:System.Globalization.JapaneseCalendar> class.
- The <xref:System.Globalization.JapaneseLunisolarCalendar> class.
- The <xref:System.Globalization.JulianCalendar> class.
- The <xref:System.Globalization.KoreanCalendar> class.
- The <xref:System.Globalization.KoreanLunisolarCalendar> class.
- The <xref:System.Globalization.PersianCalendar> class.
- The <xref:System.Globalization.TaiwanCalendar> class.
- The <xref:System.Globalization.TaiwanLunisolarCalendar> class.
- The <xref:System.Globalization.ThaiBuddhistCalendar> class.
- The <xref:System.Globalization.UmAlQuraCalendar> class.

[!INCLUDE[japanese-era-note](./includes/calendar-era.md)]

Each culture uses a default calendar defined by its read-only <xref:System.Globalization.CultureInfo.Calendar?displayProperty=nameWithType> property. Each culture may support one or more calendars defined by its read-only <xref:System.Globalization.CultureInfo.OptionalCalendars?displayProperty=nameWithType> property. The calendar currently used by a specific <xref:System.Globalization.CultureInfo> object is defined by its <xref:System.Globalization.DateTimeFormatInfo.Calendar?displayProperty=nameWithType> property. It must be one of the calendars found in the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> array.

A culture's current calendar is used in all formatting operations for that culture. For example, the default calendar of the Thai Buddhist culture is the Thai Buddhist Era calendar, which is represented by the <xref:System.Globalization.ThaiBuddhistCalendar> class. When a <xref:System.Globalization.CultureInfo> object that represents the Thai Buddhist culture is used in a date and time formatting operation, the Thai Buddhist Era calendar is used by default. The Gregorian calendar is used only if the culture's <xref:System.Globalization.DateTimeFormatInfo.Calendar?displayProperty=nameWithType> property is changed, as the following example shows:

<a name="calendars-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Calendar.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Calendar.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Calendar.vb" id="Snippet1":::

A culture's current calendar is also used in all parsing operations for that culture, as the following example shows.

<a name="calendars-02"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Calendar.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Calendar.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Calendar.vb" id="Snippet2":::

You instantiate a <xref:System.DateTime> value using the date and time elements (number of the year, month, and day) of a specific calendar by calling a [DateTime constructor](xref:System.DateTime.%23ctor%2A) that includes a `calendar` parameter and passing it a <xref:System.Globalization.CultureInfo.Calendar%2A> object that represents that calendar. The following example uses the date and time elements from the <xref:System.Globalization.ThaiBuddhistCalendar> calendar.

<a name="calendars-03"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Calendar.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Calendar.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Calendar.vb" id="Snippet3":::

<xref:System.DateTime> constructors that do not include a `calendar` parameter assume that the date and time elements are expressed as units in the Gregorian calendar.

All other <xref:System.DateTime> properties and methods use the Gregorian calendar. For example, the <xref:System.DateTime.Year?displayProperty=nameWithType> property returns the year in the Gregorian calendar, and the <xref:System.DateTime.IsLeapYear%28System.Int32%29?displayProperty=nameWithType> method assumes that the `year` parameter is a year in the Gregorian calendar. Each <xref:System.DateTime> member that uses the Gregorian calendar has a corresponding member of the <xref:System.Globalization.CultureInfo.Calendar%2A> class that uses a specific calendar. For example, the <xref:System.Globalization.Calendar.GetYear%2A?displayProperty=nameWithType> method returns the year in a specific calendar, and the <xref:System.Globalization.Calendar.IsLeapYear%2A?displayProperty=nameWithType> method interprets the `year` parameter as a year number in a specific calendar. The following example uses both the <xref:System.DateTime> and the corresponding members of the  <xref:System.Globalization.ThaiBuddhistCalendar> class.

<a name="calendars-04"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Calendar.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Calendar.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Calendar.vb" id="Snippet4":::

The <xref:System.DateTime> structure includes a <xref:System.DateTime.DayOfWeek> property that returns the day of the week in the Gregorian calendar. It does not include a member that allows you to retrieve the week number of the year. To retrieve the week of the year, call the individual calendar's <xref:System.Globalization.Calendar.GetWeekOfYear%2A?displayProperty=nameWithType> method. The following example provides an illustration.

<a name="calendars-05"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Calendar.cs" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Calendar.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/Calendar.vb" id="Snippet5":::

For more information on dates and calendars, see [Working with Calendars](../../standard/datetime/working-with-calendars.md).

## Persist DateTime values

You can persist <xref:System.DateTime> values in the following ways:

- [Convert them to strings](#persist-values-as-strings) and persist the strings.
- [Convert them to 64-bit integer values](#persist-values-as-integers) (the value of the <xref:System.DateTime.Ticks> property) and persist the integers.
- [Serialize the DateTime values](#serializing-datetime-values).

You must ensure that the routine that restores the <xref:System.DateTime> values doesn't lose data or throw an exception regardless of which technique you choose. <xref:System.DateTime> values should round-trip. That is, the original value and the restored value should be the same. And if the original <xref:System.DateTime> value represents a single instant of time, it should identify the same moment of time when it's restored.

### Persist values as strings

To successfully restore <xref:System.DateTime> values that are persisted as strings, follow these rules:

- Make the same assumptions about culture-specific formatting when you restore the string as when you persisted it. To ensure that a string can be restored on a system whose current culture is different from the culture of the system it was saved on, call the <xref:System.DateTime.ToString%2A> overload to save the string by using the conventions of the invariant culture. Call the <xref:System.DateTime.Parse%28System.String%2CSystem.IFormatProvider%2CSystem.Globalization.DateTimeStyles%29> or <xref:System.DateTime.TryParse%28System.String%2CSystem.IFormatProvider%2CSystem.Globalization.DateTimeStyles%2CSystem.DateTime%40%29> overload to restore the string by using the conventions of the invariant culture. Never use the <xref:System.DateTime.ToString>, <xref:System.DateTime.Parse%28System.String%29>, or <xref:System.DateTime.TryParse%28System.String%2CSystem.DateTime%40%29> overloads, which use the conventions of the current culture.

- If the date represents a single moment of time, ensure that it represents the same moment in time when it's restored, even on a different time zone. Convert the <xref:System.DateTime> value to Coordinated Universal Time (UTC) before saving it or use <xref:System.DateTimeOffset>.

The most common error made when persisting <xref:System.DateTime> values as strings is to rely on the formatting conventions of the default or current culture. Problems arise if the current culture is different when saving and restoring the strings. The following example illustrates these problems. It saves five dates using the formatting conventions of the current culture, which in this case is English (United States). It restores the dates using the formatting conventions of a different culture, which in this case is English (United Kingdom). Because the formatting conventions of the two cultures are different, two of the dates can't be restored, and the remaining three dates are interpreted incorrectly. Also, if the original date and time values represent single moments in time, the restored times are incorrect because time zone information is lost.

<a name="persistence-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Persistence.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Persistence.fs" id="Snippet1":::

To round-trip <xref:System.DateTime> values successfully, follow these steps:

1. If the values represent single moments of time, convert them from the local time to UTC by calling the <xref:System.DateTime.ToUniversalTime%2A> method.
1. Convert the dates to their string representations by calling the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29> or <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> overload. Use the formatting conventions of the invariant culture by specifying <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> as the `provider` argument. Specify that the value should round-trip by using the "O" or "R" standard format string.

To restore the persisted <xref:System.DateTime> values without data loss, follow these steps:

1. Parse the data by calling the <xref:System.DateTime.ParseExact%2A> or <xref:System.DateTime.TryParseExact%2A> overload. Specify <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> as the `provider` argument, and use the same standard format string you used for the `format` argument during conversion. Include the <xref:System.Globalization.DateTimeStyles.RoundtripKind?displayProperty=nameWithType> value in the `styles` argument.
1. If the <xref:System.DateTime> values represent single moments in time, call the <xref:System.DateTime.ToLocalTime%2A> method to convert the parsed date from UTC to local time.

The following example uses the invariant culture and the "O" standard format string to ensure that <xref:System.DateTime> values saved and restored represent the same moment in time regardless of the system, culture, or time zone of the source and target systems.

<a name="persistence-02"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Persistence.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Persistence.fs" id="Snippet2":::

### Persist values as integers

You can persist a date and time as an <xref:System.Int64> value that represents a number of ticks. In this case, you don't have to consider the culture of the systems the <xref:System.DateTime> values are persisted and restored on.

To persist a <xref:System.DateTime> value as an integer:

1. If the <xref:System.DateTime> values represent single moments in time, convert them to UTC by calling the <xref:System.DateTime.ToUniversalTime%2A> method.
1. Retrieve the number of ticks represented by the <xref:System.DateTime> value from its <xref:System.DateTime.Ticks> property.

To restore a <xref:System.DateTime> value that has been persisted as an integer:

1. Instantiate a new <xref:System.DateTime> object by passing the <xref:System.Int64> value to the <xref:System.DateTime.%23ctor%28System.Int64%29> constructor.
1. If the <xref:System.DateTime> value represents a single moment in time, convert it from UTC to the local time by calling the <xref:System.DateTime.ToLocalTime%2A> method.

The following example persists an array of <xref:System.DateTime> values as integers on a system in the U.S. Pacific Time zone. It restores it on a system in the UTC zone. The file that contains the integers includes an <xref:System.Int32> value that indicates the total number of <xref:System.Int64> values that immediately follow it.

<a name="persistence-03"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Persistence.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Persistence.fs" id="Snippet3":::

<a name="serializing-datetime-values"></a>

### Serialize DateTime values

You can persist <xref:System.DateTime> values through serialization to a stream or file, and then restore them through deserialization. <xref:System.DateTime> data is serialized in some specified object format. The objects are restored when they are deserialized. A formatter or serializer, such as <xref:System.Text.Json.JsonSerializer> or <xref:System.Xml.Serialization.XmlSerializer>, handles the process of serialization and deserialization. For more information about serialization and the types of serialization supported by .NET, see [Serialization](../../standard/serialization/index.md).

The following example uses the <xref:System.Xml.Serialization.XmlSerializer> class to serialize and deserialize <xref:System.DateTime> values. The values represent all leap year days in the twenty-first century. The output represents the result if the example is run on a system whose current culture is English (United Kingdom). Because you've deserialized the <xref:System.DateTime> object itself, the code doesn't have to handle cultural differences in date and time formats.

<a name="persistence-04"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/Persistence.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/Persistence.fs" id="Snippet4":::

The previous example doesn't include time information. If a <xref:System.DateTime> value represents a moment in time and is expressed as a local time, convert it from local time to UTC before serializing it by calling the <xref:System.DateTime.ToUniversalTime%2A> method. After you deserialize it, convert it from UTC to local time by calling the <xref:System.DateTime.ToLocalTime%2A> method.

## DateTime vs. TimeSpan

The <xref:System.DateTime> and <xref:System.TimeSpan> value types differ in that a <xref:System.DateTime> represents an instant in time whereas a <xref:System.TimeSpan> represents a time interval. You can subtract one instance of <xref:System.DateTime> from another to obtain a <xref:System.TimeSpan> object that represents the time interval between them. Or you could add a positive <xref:System.TimeSpan> to the current <xref:System.DateTime> to obtain a <xref:System.DateTime> value that represents a future date.

You can add or subtract a time interval from a <xref:System.DateTime> object. Time intervals can be negative or positive, and they can be expressed in units such as ticks, seconds, or as a <xref:System.TimeSpan> object.

## Compare for equality within tolerance

Equality comparisons for <xref:System.DateTime> values are exact. To be considered equal, two values must be expressed as the same number of ticks. That precision is often unnecessary or even incorrect for many applications. Often, you want to test if <xref:System.DateTime> objects are **roughly equal**.

The following example demonstrates how to compare roughly equivalent <xref:System.DateTime> values. It accepts a small margin of difference when declaring them equal.

<a name="comparison-01"></a>
:::code language="csharp" source="./snippets/System/DateTime/Overview/csharp/DateTimeComparisons.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/DateTime/Overview/fsharp/DateTimeComparisons.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/DateTime/Overview/vb/DateTimeComparisons.vb" id="Snippet1":::

## COM interop considerations

A <xref:System.DateTime> value that is transferred to a COM application, then is transferred back to a managed application, is said to round-trip. However, a <xref:System.DateTime> value that specifies only a time does not round-trip as you might expect.

If you round-trip only a time, such as 3 P.M., the final date and time is December 30, 1899 C.E. at 3:00 P.M., instead of January, 1, 0001 C.E. at 3:00 P.M. .NET and COM assume a default date when only a time is specified. However, the COM system assumes a base date of December 30, 1899 C.E., while .NET assumes a base date of January, 1, 0001 C.E.

When only a time is passed from .NET to COM, special processing is performed that converts the time to the format used by COM. When only a time is passed from COM to .NET, no special processing is performed because that would corrupt legitimate dates and times on or before December 30, 1899. If a date starts its round-trip from COM, .NET and COM preserve the date.

The behavior of .NET and COM means that if your application round-trips a <xref:System.DateTime> that only specifies a time, your application must remember to modify or ignore the erroneous date from the final <xref:System.DateTime> object.
