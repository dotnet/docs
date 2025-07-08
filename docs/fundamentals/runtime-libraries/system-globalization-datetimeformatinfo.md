---
title: System.Globalization.DateTimeFormatInfo class
description: Learn more about the System.Globalization.DateTimeFormatInfo class.
ms.date: 12/28/2023
ms.topic: concept-article
---
# <xref:System.Globalization.DateTimeFormatInfo> class

[!INCLUDE [context](includes/context.md)]

The properties of the <xref:System.Globalization.DateTimeFormatInfo> class contain culture-specific information for formatting or parsing date and time values such as the following:

- The patterns used to format date values.
- The patterns used to format time values.
- The names of the days of the week.
- The names of the months of the year.
- The A.M. and P.M. designators used in time values.
- The calendar in which dates are expressed.

## Instantiate a DateTimeFormatInfo object

A <xref:System.Globalization.DateTimeFormatInfo> object can represent the formatting conventions of the invariant culture, a specific culture, a neutral culture, or the current culture. This section discusses how to instantiate each type of <xref:System.Globalization.DateTimeFormatInfo> object.

### Instantiate a DateTimeFormatInfo object for the invariant culture

The invariant culture represents a culture that is culture-insensitive. It is based on the English language, but not on any specific English-speaking country/region. Although the data of specific cultures can be dynamic and can change to reflect new cultural conventions or user preferences, the data of the invariant culture does not change. You can instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of the invariant culture in the following ways:

- By retrieving the value of the <xref:System.Globalization.DateTimeFormatInfo.InvariantInfo%2A> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.
- By calling the parameterless <xref:System.Globalization.DateTimeFormatInfo.%23ctor%2A> constructor. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read/write.
- By retrieving the value of the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A> property from the <xref:System.Globalization.CultureInfo> object that is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.

The following example uses each of these methods to instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the invariant culture. It then indicates whether the object is read-only.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/create1.cs" interactive="try-dotnet-method" id="Snippet1":::

### Instantiate a DateTimeFormatInfo object for a specific culture

A specific culture represents a language that is spoken in a particular country/region. For example, en-US is a specific culture that represents the English language spoken in the United States, and en-CA is a specific culture that represents the English language spoken in Canada. You can instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of a specific culture in the following ways:

- By calling the <xref:System.Globalization.CultureInfo.GetCultureInfo%28System.String%29?displayProperty=nameWithType> method and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.

- By passing the static <xref:System.Globalization.DateTimeFormatInfo.GetInstance%2A> method a <xref:System.Globalization.CultureInfo> object that represents the culture whose <xref:System.Globalization.DateTimeFormatInfo> object you want to retrieve. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read/write.

- By calling the static <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read/write.

- By calling the <xref:System.Globalization.CultureInfo.%23ctor%2A?displayProperty=nameWithType> class constructor and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read/write.

The following example illustrates each of these ways to instantiate a <xref:System.Globalization.DateTimeFormatInfo> object and indicates whether the resulting object is read-only.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/create1.cs" interactive="try-dotnet-method" id="Snippet3":::

### Instantiate a DateTimeFormatInfo object for a neutral culture

A neutral culture represents a culture or language that is independent of a country/region; it is typically the parent of one or more specific cultures. For example, Fr is a neutral culture for the French language and the parent of the fr-FR culture. You can instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of a neutral culture in the same ways that you create a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of a specific culture. In addition, you can retrieve a neutral culture's <xref:System.Globalization.DateTimeFormatInfo> object by retrieving a neutral culture from a specific culture's <xref:System.Globalization.CultureInfo.Parent%2A?displayProperty=nameWithType> property and retrieving the <xref:System.Globalization.DateTimeFormatInfo> object returned by its <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. Unless the parent culture represents the invariant culture, the returned <xref:System.Globalization.DateTimeFormatInfo> object is read/write. The following example illustrates these ways of instantiating a <xref:System.Globalization.DateTimeFormatInfo> object that represents a neutral culture.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/create1.cs" interactive="try-dotnet-method" id="Snippet2":::

However, a neutral culture lacks culture-specific formatting information, because it is independent of a specific country/region. Instead of populating the <xref:System.Globalization.DateTimeFormatInfo> object with generic values, .NET returns a <xref:System.Globalization.DateTimeFormatInfo> object that reflects the formatting conventions of a specific culture that is a child of the neutral culture. For example, the <xref:System.Globalization.DateTimeFormatInfo> object for the neutral en culture reflects the formatting conventions of the en-US culture, and the <xref:System.Globalization.DateTimeFormatInfo> object for the fr culture reflects the formatting conventions of the fr-FR culture.

You can use code like the following to determine which specific culture's formatting conventions a neutral culture represents. The example uses reflection to compare the <xref:System.Globalization.DateTimeFormatInfo> properties of a neutral culture with the properties of a specific child culture. It considers two calendars to be equivalent if they are the same calendar type and, for Gregorian calendars, if their <xref:System.Globalization.GregorianCalendar.CalendarType%2A?displayProperty=nameWithType> properties have identical values.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/instantiate6.cs" interactive="try-dotnet" id="Snippet6":::

### Instantiate a DateTimeFormatInfo object for the current culture

You can instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of the current culture in the following ways:

- By retrieving the value of the <xref:System.Globalization.DateTimeFormatInfo.CurrentInfo%2A> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.

- By retrieving the value of the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A> property from the <xref:System.Globalization.CultureInfo> object that is returned by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.

- By calling the <xref:System.Globalization.NumberFormatInfo.GetInstance%2A> method with a <xref:System.Globalization.CultureInfo> object that represents the current culture. The returned <xref:System.Globalization.DateTimeFormatInfo> object is read-only.

The following example uses each of these methods to instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of the current culture. It then indicates whether the object is read-only.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/create2.cs" interactive="try-dotnet-method" id="Snippet4":::

You can create a writable <xref:System.Globalization.DateTimeFormatInfo> object that represents the conventions of the current culture in one of these ways:

- By retrieving a <xref:System.Globalization.DateTimeFormatInfo> object in any of the three previous ways and calling the <xref:System.Globalization.DateTimeFormatInfo.Clone%2A> method on the returned <xref:System.Globalization.DateTimeFormatInfo> object. This creates a copy of the original <xref:System.Globalization.DateTimeFormatInfo> object, except that its <xref:System.Globalization.DateTimeFormatInfo.IsReadOnly%2A> property is `false`.

- By calling the <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method to create a <xref:System.Globalization.CultureInfo> object that represents the current culture, and then using its <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property to retrieve the <xref:System.Globalization.DateTimeFormatInfo> object.

The following example illustrates each way of instantiating a read/write <xref:System.Globalization.DateTimeFormatInfo> object and displays the value of its <xref:System.Globalization.DateTimeFormatInfo.IsReadOnly%2A> property.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/instantiate2.cs" id="Snippet7":::

In Windows, the user can override some of the <xref:System.Globalization.DateTimeFormatInfo> property values used in formatting and parsing operations through the **Region and Language** application in Control Panel. For example, a user whose culture is English (United States) might choose to display long time values using a 24-hour clock (in the format HH:mm:ss) instead of the default 12-hour clock (in the format h:mm:ss tt). The <xref:System.Globalization.DateTimeFormatInfo> objects retrieved in the ways discussed previously all reflect these user overrides. If this is undesirable, you can create a <xref:System.Globalization.NumberFormatInfo> object that does not reflect user overrides (and is also read/write instead of read-only) by calling the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor and supplying a value of `false` for the `useUserOverride` argument. The following example illustrates this for a system whose current culture is English (United States) and whose long time pattern has been changed from the default of h:mm:ss tt to HH:mm:ss.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/instantiate3.cs" id="Snippet8":::

## DateTimeFormatInfo and dynamic data

The culture-specific data for formatting date and time values provided by the <xref:System.Globalization.DateTimeFormatInfo> class is dynamic, just like cultural data provided by the <xref:System.Globalization.CultureInfo> class. You should not make any assumptions about the stability of values for <xref:System.Globalization.DateTimeFormatInfo> objects that are associated with particular <xref:System.Globalization.CultureInfo> objects. Only the data provided by the invariant culture and its associated <xref:System.Globalization.DateTimeFormatInfo> object is stable. Other data can change between application sessions or even while your application is running. There are four major sources of change:

- System updates. Cultural preferences such as the preferred calendar or customary date and time formats change over time. When this happens, Windows Update includes changes to the <xref:System.Globalization.DateTimeFormatInfo> property value for a particular culture.

- Replacement cultures. The <xref:System.Globalization.CultureAndRegionInfoBuilder> class can be used to replace the data of an existing culture.

- Cascading changes to property values. A number of culture-related properties can change at run time, which, in turn, causes <xref:System.Globalization.DateTimeFormatInfo> data to change. For example, the current culture can be changed either programmatically or through user action. When this happens, the <xref:System.Globalization.DateTimeFormatInfo> object returned by the <xref:System.Globalization.DateTimeFormatInfo.CurrentInfo%2A> property changes to an object associated with the current culture. Similarly, a culture's calendar can change, which can result in changes to numerous <xref:System.Globalization.DateTimeFormatInfo> property values.

- User preferences. Users of your application might choose to override some of the values associated with the current system culture through the regional and language options in Control Panel. For example, users might choose to display the date in a different format. If the <xref:System.Globalization.CultureInfo.UseUserOverride%2A?displayProperty=nameWithType> property is set to `true`, the properties of the <xref:System.Globalization.DateTimeFormatInfo> object is also retrieved from the user settings. If the user settings are incompatible with the culture associated with the <xref:System.Globalization.CultureInfo> object (for example, if the selected calendar is not one of the calendars indicated by the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A> property), the results of the methods and the values of the properties are undefined.

To minimize the possibility of inconsistent data, all user-overridable properties of a <xref:System.Globalization.DateTimeFormatInfo> object are initialized when the object is created. There is still a possibility of inconsistency, because neither object creation nor the user override process is atomic and the relevant values can change during object creation. However, this situation should be extremely rare.

You can control whether user overrides are reflected in <xref:System.Globalization.DateTimeFormatInfo> objects that represent the same culture as the system culture. The following table lists the ways in which a <xref:System.Globalization.DateTimeFormatInfo> object can be retrieved and indicates whether the resulting object reflects user overrides.

|Source of CultureInfo and DateTimeFormatInfo object|Reflects user overrides|
|---------------------------------------------------------|-----------------------------|
|`CultureInfo.CurrentCulture.DateTimeFormat` property|Yes|
|<xref:System.Globalization.DateTimeFormatInfo.CurrentInfo%2A?displayProperty=nameWithType> property|Yes|
|<xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method|Yes|
|<xref:System.Globalization.CultureInfo.GetCultureInfo%2A?displayProperty=nameWithType> method|No|
|<xref:System.Globalization.CultureInfo.%23ctor%28System.String%29?displayProperty=nameWithType> constructor|Yes|
|<xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor|Depends on value of `useUserOverride` parameter|

Unless there is a compelling reason to do otherwise, you should respect user overrides when you use the <xref:System.Globalization.DateTimeFormatInfo> object in client applications to format and parse user input or to display data. For server applications or unattended applications, you should not. However, if you are using the <xref:System.Globalization.DateTimeFormatInfo> object either explicitly or implicitly to persist date and time data in string form, you should either use a <xref:System.Globalization.DateTimeFormatInfo> object that reflects the formatting conventions of the invariant culture, or you should specify a custom date and time format string that you use regardless of culture.

## Format dates and times

A <xref:System.Globalization.DateTimeFormatInfo> object is used implicitly or explicitly in all date and time formatting operations. These include calls to the following methods:

- All date and time formatting methods, such as <xref:System.DateTime.ToString?displayProperty=nameWithType> and <xref:System.DateTimeOffset.ToString%28System.String%29?displayProperty=nameWithType>.
- The major composite formatting method, which is <xref:System.String.Format%2A?displayProperty=nameWithType>.
- Other composite formatting methods, such as <xref:System.Console.WriteLine%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> and <xref:System.Text.StringBuilder.AppendFormat%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>.

All date and time formatting operations make use of an <xref:System.IFormatProvider> implementation. The <xref:System.IFormatProvider> interface includes a single method, <xref:System.IFormatProvider.GetFormat%28System.Type%29?displayProperty=nameWithType>. This callback method is passed a <xref:System.Type> object that represents the type needed to provide formatting information. The method returns either an instance of that type or `null` if it cannot provide an instance of the type. .NET includes two <xref:System.IFormatProvider> implementations for formatting dates and times:

- The <xref:System.Globalization.CultureInfo> class,  which represents a specific culture (or a specific language in a specific country/region). In a date and time formatting operation, the <xref:System.Globalization.CultureInfo.GetFormat%2A?displayProperty=nameWithType> method returns the <xref:System.Globalization.DateTimeFormatInfo> object associated with its <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property.
- The <xref:System.Globalization.DateTimeFormatInfo> class, which provides information about the formatting conventions of its associated culture. The <xref:System.Globalization.DateTimeFormatInfo.GetFormat%2A?displayProperty=nameWithType> method returns an instance of itself.

If an <xref:System.IFormatProvider> implementation is not provided to a formatting method explicitly, the <xref:System.Globalization.CultureInfo> object returned by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property that represents the current culture is used.

The following example illustrates the relationship between the <xref:System.IFormatProvider> interface and the <xref:System.Globalization.DateTimeFormatInfo> class in formatting operations. It defines a custom <xref:System.IFormatProvider> implementation whose <xref:System.IFormatProvider.GetFormat%2A> method displays the type of the object requested by the formatting operation. If it is requesting a <xref:System.Globalization.DateTimeFormatInfo> object, the method provides the <xref:System.Globalization.DateTimeFormatInfo> object for the current culture. As the output from the example shows, the <xref:System.Decimal.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method requests a <xref:System.Globalization.DateTimeFormatInfo> object to provide formatting information, whereas the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method requests <xref:System.Globalization.NumberFormatInfo> and <xref:System.Globalization.DateTimeFormatInfo> objects as well as an <xref:System.ICustomFormatter> implementation.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/formatprovider1.cs" id="Snippet9":::

## Format strings and DateTimeFormatInfo properties

The <xref:System.Globalization.DateTimeFormatInfo> object includes three kinds of properties that are used in formatting operations with date and time values:

- Calendar-related properties. Properties such as <xref:System.Globalization.DateTimeFormatInfo.AbbreviatedDayNames%2A>, <xref:System.Globalization.DateTimeFormatInfo.AbbreviatedMonthNames%2A>, <xref:System.Globalization.DateTimeFormatInfo.DayNames%2A>, and <xref:System.Globalization.DateTimeFormatInfo.MonthNames%2A>, are associated with the calendar used by the culture, which is defined by the <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A> property. These properties are used for long date and time formats.

- Properties that produce a standards-defined result string. The <xref:System.Globalization.DateTimeFormatInfo.RFC1123Pattern%2A>, <xref:System.Globalization.DateTimeFormatInfo.SortableDateTimePattern%2A>, and <xref:System.Globalization.DateTimeFormatInfo.UniversalSortableDateTimePattern%2A> properties contain custom format strings that produce result strings defined by international standards. These properties are  read-only and cannot be modified.

- Properties that define culture-sensitive result strings. Some properties, such as <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A> and <xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A>, contain  [custom format strings](../../standard/base-types/custom-date-and-time-format-strings.md) that specify the format of the result string. Others, such as <xref:System.Globalization.DateTimeFormatInfo.AMDesignator%2A>, <xref:System.Globalization.DateTimeFormatInfo.DateSeparator%2A>, <xref:System.Globalization.DateTimeFormatInfo.PMDesignator%2A>, and <xref:System.Globalization.DateTimeFormatInfo.TimeSeparator%2A>, define culture-sensitive symbols or substrings that can be included in a result string.

The [standard date and time format strings](../../standard/base-types/standard-date-and-time-format-strings.md), such as "d", "D", "f", and "F", are aliases that correspond to particular <xref:System.Globalization.DateTimeFormatInfo> format pattern properties. Most of the  [custom date and time format strings](../../standard/base-types/custom-date-and-time-format-strings.md) are related to strings or substrings that a formatting operation inserts into the result stream. The following table lists the standard and custom date and time format specifiers and their associated <xref:System.Globalization.DateTimeFormatInfo> properties. For details about how to use these format specifiers, see [Standard Date and Time Format Strings](../../standard/base-types/standard-date-and-time-format-strings.md) and [Custom Date and Time Format Strings](../../standard/base-types/custom-date-and-time-format-strings.md). Note that each standard format string corresponds to a <xref:System.Globalization.DateTimeFormatInfo> property whose value is a custom date and time format string. The individual specifiers in this custom format string in turn correspond to other <xref:System.Globalization.DateTimeFormatInfo> properties. The table lists only the <xref:System.Globalization.DateTimeFormatInfo> properties for which the standard format strings are aliases, and does not list properties that may be accessed by custom format strings assigned to those aliased properties. In addition, the table lists only custom format specifiers that correspond to <xref:System.Globalization.DateTimeFormatInfo> properties.

|Format specifier|Associated properties|
|----------------------|---------------------------|
|"d" (short date; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A>, to define the overall format of the result string.|
|"D" (long date; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A>, to define the overall format of the result string.|
|"f" (full date / short time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A>, to define the format of the date component of the result string.<br /><br /><xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern%2A>, to define the format of the time component of the result string.|
|"F" (full date / long time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A>, to define the format of the date component of the result string.<br /><br /><xref:System.Globalization.DateTimeFormatInfo.LongTimePattern%2A>, to define the format of the time component of the result string.|
|"g" (general date / short time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A>, to define the format of the date component of the result string.<br /><br /><xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern%2A>, to define the format of the time component of the result string.|
|"G" (general date / long time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A>, to define the format of the date component of the result string.<br /><br /><xref:System.Globalization.DateTimeFormatInfo.LongTimePattern%2A>, to define the format of the time component of the result string.|
|"M", "m" (month/day; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.MonthDayPattern%2A>, to define the overall format of the result string.|
|"O", "o" (round-trip date/time; standard format string)|None.|
|"R", "r" (RFC1123; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.RFC1123Pattern%2A>, to define a result string that conforms to the RFC 1123 standard. The property is read-only.|
|"s" (sortable date/time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.SortableDateTimePattern%2A>, to define a result string that conforms to the ISO 8601 standard. The property is read-only.|
|"t" (short time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern%2A>, to define the overall format of the result string.|
|"T" (long time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.LongTimePattern%2A>, to define the overall format of the result string.|
|"u" (universal sortable date/time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.UniversalSortableDateTimePattern%2A>, to define a result string that conforms to the ISO 8601 standard for coordinated universal time. The property is read-only.|
|"U" (universal full date/time; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A>, to define the overall format of the result string.|
|"Y", "y" (year month; standard format string)|<xref:System.Globalization.DateTimeFormatInfo.YearMonthPattern%2A>, to define the overall format of the result string.|
|"ddd" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.AbbreviatedDayNames%2A>, to include the abbreviated name of the day of the week in the result string.|
|"g", "gg" (custom format specifier)|Calls the <xref:System.Globalization.DateTimeFormatInfo.GetEraName%2A> method to insert the era name in the result string.|
|"MMM" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.AbbreviatedMonthNames%2A> or <xref:System.Globalization.DateTimeFormatInfo.AbbreviatedMonthGenitiveNames%2A>, to include the abbreviated month name in the result string.|
|"MMMM" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.MonthNames%2A> or <xref:System.Globalization.DateTimeFormatInfo.MonthGenitiveNames%2A>, to include the full month name in the result string.|
|"t" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.AMDesignator%2A> or <xref:System.Globalization.DateTimeFormatInfo.PMDesignator%2A>, to include the first character of the AM/PM designator in the result string.|
|"tt" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.AMDesignator%2A> or <xref:System.Globalization.DateTimeFormatInfo.PMDesignator%2A>, to include the full AM/PM designator in the result string.|
|":" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.TimeSeparator%2A>, to include the time separator in the result string.|
|"/" (custom format specifier)|<xref:System.Globalization.DateTimeFormatInfo.DateSeparator%2A>, to include the date separator in the result string.|

## Modify DateTimeFormatInfo properties

You can change the result string produced by date and time format strings by modifying the associated properties of a writable <xref:System.Globalization.DateTimeFormatInfo> object. To determine if a <xref:System.Globalization.DateTimeFormatInfo> object is writable, use the <xref:System.Globalization.DateTimeFormatInfo.IsReadOnly%2A> property. To customize a <xref:System.Globalization.DateTimeFormatInfo> object in this way:

1. Create a read/write copy of a <xref:System.Globalization.DateTimeFormatInfo> object whose formatting conventions you want to modify.

2. Modify the property or properties that are used to produce the desired result string. (For information about how formatting methods use <xref:System.Globalization.DateTimeFormatInfo> properties to define result strings, see the previous section, [Format strings and DateTimeFormatInfo properties](#format-strings-and-datetimeformatinfo-properties).)

3. Use the custom <xref:System.Globalization.DateTimeFormatInfo> object you created as the <xref:System.IFormatProvider> argument in calls to formatting methods.

There are two other ways to change the format of a result string:

- You can use the <xref:System.Globalization.CultureAndRegionInfoBuilder> class to define either a custom culture (a culture that has a unique name and that supplements existing cultures) or a replacement culture (one that is used instead of a specific culture). You can save and access this culture programmatically as you would any <xref:System.Globalization.CultureInfo> object supported by .NET.

- If the result string is not culture-sensitive and doesn't follow a predefined format, you can use a custom date and time format string. For example, if you are serializing date and time data in the format YYYYMMDDHHmmss, you can generate the result string by passing the custom format string to the <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> method, and you can convert the result string back to a <xref:System.DateTime> value by calling the <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method.

### Change the short date pattern

The following example changes the format of a result string produced by the "d" (short date) standard format string. It changes the associated <xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A> property for the en-US or English (United States) culture from its default of "M/d/yyyy" to "yyyy'-"MM"-"dd" and uses the "d" standard format string to display the date both before and after the <xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A> property is changed.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/example1.cs" interactive="try-dotnet" id="Snippet10":::

### Change the date separator character

The following example changes the date separator character in a <xref:System.Globalization.DateTimeFormatInfo> object that represents the formatting conventions of the fr-FR culture. The example uses the "g" standard format string to display the date both before and after the <xref:System.Globalization.DateTimeFormatInfo.DateSeparator%2A> property is changed.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/example3.cs" interactive="try-dotnet" id="Snippet12":::

### Change day name abbreviations and the long date pattern

In some cases, the long date pattern, which typically displays the full day and month name along with the number of the day of the month and the year, may be too long. The following example shortens the long date pattern for the en-US culture to return a one-character or two-character day name abbreviation followed by the day number, the month name abbreviation, and the year. It does this by assigning shorter day name abbreviations to the <xref:System.Globalization.DateTimeFormatInfo.AbbreviatedDayNames%2A> array, and by modifying the custom format string assigned to the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> property. This affects the result strings returned by the "D" and "f" standard format strings.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/example2.cs" interactive="try-dotnet" id="Snippet13":::

Ordinarily, the change to the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> property also affects the <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A> property, which in turn defines the result string returned by the "F" standard format string. To preserve the original full date and time pattern, the example reassigns the original custom format string assigned to the <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A> property after the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> property is modified.

### Change from a 12-hour clock to a 24-hour clock

For many cultures in .NET, the time is expressed by using a 12-hour clock and an AM/PM designator. The following example defines a `ReplaceWith24HourClock` method that replaces any time format that uses a 12-hour clock with a format that uses a 24-hour clock.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/example5.cs" interactive="try-dotnet" id="Snippet14":::

The example uses a regular expression to modify the format string. The regular expression pattern `@"^(?<openAMPM>\s*t+\s*)? (?(openAMPM) h+(?<nonHours>[^ht]+)$ | \s*h+(?<nonHours>[^ht]+)\s*t+)` is defined as follows:

|Pattern|Description|
|-------------|-----------------|
|`^`|Begin the match at the beginning of the string.|
|`(?<openAMPM>\s*t+\s*)?`|Match zero or one occurrence of zero or more white-space characters, followed by the letter "t" one or more times, followed by zero or more white-space characters. This capturing group is named `openAMPM`.|
|`(?(openAMPM) h+(?<nonHours>[^ht]+)$`|If the `openAMPM` group has a match, match the letter "h" one or more times, followed by one or more characters that are neither "h" nor "t". The match ends at the end of the string. All characters captured after "h" are included in a capturing group named `nonHours`.|
|`&#124; \s*h+(?<nonHours>[^ht]+)\s*t+)`|If the `openAMPM` group does not have a match, match the letter "h" one or more times, followed by one or more characters that are neither "h" nor "t", followed by zero or more white-space characters. Finally, match one or more occurrences of the letter "t". All characters captured after "h" and before the white-spaces and "t" are included in a capturing group named `nonHours`.|

The `nonHours` capturing group contains the minute and possibly the second component of a custom date and time format string, along with any time separator symbols. The replacement pattern `HH${nonHours}` prepends the substring "HH" to these elements.

### Display and change the era in a date

The following example adds the "g" custom format specifier to the  <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> property of an object that represents the formatting conventions of the en-US culture. This addition affects the following three standard format strings:

- The "D" (long date) standard format string, which maps directly to the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> property.

- The "f" (full date / short time) standard format string, which produces a result string that concatenates the substrings produced by the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> and <xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern%2A> properties.

- The "F" (full date / long time) standard format string, which maps directly to the <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A> property. Because we have not explicitly set this property value, it is generated dynamically by concatenating the <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A> and <xref:System.Globalization.DateTimeFormatInfo.LongTimePattern%2A> properties.

The example also shows how to change the era name for a culture whose calendar has a single era. In this case, the en-US culture uses the Gregorian calendar, which is represented by a <xref:System.Globalization.GregorianCalendar> object. The <xref:System.Globalization.GregorianCalendar> class supports a single era, which it names A.D. (Anno Domini). The example changes the era name to C.E. (Common Era) by replacing the "g" custom format specifier in the format string assigned to the <xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern%2A> property with a literal string. The use of a literal string is necessary, because the era name is typically returned by the <xref:System.Globalization.DateTimeFormatInfo.GetEraName%2A> method from private data in the culture tables supplied by either .NET or the operating system.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/example4.cs" interactive="try-dotnet" id="Snippet11":::

## Parse date and time strings

Parsing involves converting the string representation of a date and time to a <xref:System.DateTime> or <xref:System.DateTimeOffset> value. Both of these types include the `Parse`, `TryParse`, `ParseExact`, and `TryParseExact` methods to support parsing operations. The `Parse` and `TryParse` methods convert a string that can have a variety of formats, whereas `ParseExact` and `TryParseExact` require that the string have a defined format or formats. If the parsing operation fails, `Parse` and `ParseExact` throw an exception, whereas `TryParse` and `TryParseExact` return `false`.

The parsing methods implicitly or explicitly use a <xref:System.Globalization.DateTimeStyles> enumeration value to determine which style elements (such as leading, trailing, or inner white space) can be present in the string to be parsed, and how to interpret the parsed string or any missing elements. If you don't provide a <xref:System.Globalization.DateTimeStyles> value when you call the `Parse` or `TryParse` method, the default is <xref:System.Globalization.DateTimeStyles.AllowWhiteSpaces?displayProperty=nameWithType>, which is a composite style that includes the <xref:System.Globalization.DateTimeStyles.AllowLeadingWhite?displayProperty=nameWithType>, <xref:System.Globalization.DateTimeStyles.AllowTrailingWhite?displayProperty=nameWithType>, and <xref:System.Globalization.DateTimeStyles.AllowInnerWhite?displayProperty=nameWithType> flags. For the `ParseExact` and `TryParseExact` methods, the default is <xref:System.Globalization.DateTimeStyles.None?displayProperty=nameWithType>; the input string must correspond precisely to a particular custom date and time format string.

The parsing methods also implicitly or explicitly use a <xref:System.Globalization.DateTimeFormatInfo> object that defines the specific symbols and patterns that can occur in the string to be parsed. If you don't provide a <xref:System.Globalization.DateTimeFormatInfo> object, the <xref:System.Globalization.DateTimeFormatInfo> object for the current culture is used by default. For more information about parsing date and time strings, see the individual parsing methods, such as <xref:System.DateTime.Parse%2A?displayProperty=nameWithType>, <xref:System.DateTime.TryParse%2A?displayProperty=nameWithType>, <xref:System.DateTimeOffset.ParseExact%2A?displayProperty=nameWithType>, and <xref:System.DateTimeOffset.TryParseExact%2A?displayProperty=nameWithType>.

The following example illustrates the culture-sensitive nature of parsing date and time strings. It tries to parse two date strings by using the conventions of the en-US, en-GB, fr-FR, and fi-FI cultures. The date that is interpreted as 8/18/2014 in the en-US culture throws a <xref:System.FormatException> exception in the other three cultures because 18 is interpreted as the month number. 1/2/2015 is parsed as the second day of the first month in the en-US culture, but as the first day of the second month in the remaining cultures.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/parse1.cs" interactive="try-dotnet" id="Snippet15":::

Date and time strings are typically parsed for two reasons:

- To convert user input into a date and time value.
- To round-trip a date and time value; that is, to deserialize a date and time value that was previously serialized as a string.

The following sections discuss these two operations in greater detail.

### Parse user strings

When you parse date and time strings input by the user, you should always instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that reflects the user's cultural settings, including any customizations the user may have made. Otherwise, the date and time object may have incorrect values. For information about how to instantiate a <xref:System.Globalization.DateTimeFormatInfo> object that reflects user cultural customizations, see the [DateTimeFormatInfo and dynamic data](#datetimeformatinfo-and-dynamic-data) section.

The following example illustrates the difference between a parsing operation that reflects user cultural settings and one that does not. In this case, the default system culture is en-US, but the user has used Control Panel, **Region and Language** to change the short date pattern from its default of "M/d/yyyy" to "yy/MM/dd". When the user enters a string that reflects user settings, and the string is parsed by a <xref:System.Globalization.DateTimeFormatInfo> object that also reflects user settings (overrides), the parsing operation returns a correct result. However, when the string is parsed by a <xref:System.Globalization.DateTimeFormatInfo> object that reflects standard en-US cultural settings, the parsing method throws a <xref:System.FormatException> exception because it interprets 14 as the number of the month, not the last two digits of the year.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/parse2.cs" id="Snippet16":::

### Serialize and deserialize date and time data

Serialized date and time data are expected to round-trip; that is, all serialized and deserialized values should be identical. If a date and time value represents a single moment in time, the deserialized value should represent the same moment in time regardless of the culture or time zone of the system on which it was restored. To round-trip date and time data successfully, you must use the conventions of the invariant culture, which is returned by the <xref:System.Globalization.DateTimeFormatInfo.InvariantInfo%2A> property, to generate and parse the data. The formatting and parsing operations should never reflect the conventions of the default culture. If you use default cultural settings, the portability of the data is strictly limited; it can be successfully deserialized only on a thread whose cultural-specific settings are identical to those of the thread on which it was serialized. In some cases, this means that the data cannot even be successfully serialized and deserialized on the same system.

If the time component of a date and time value is significant, it should also be converted to UTC and serialized by using the "o" or "r" [standard format string](../../standard/base-types/standard-date-and-time-format-strings.md). The time data can then be restored by calling a parsing method and passing it the appropriate format string along with the invariant culture as the `provider` argument.

The following example illustrates the process of round-tripping a date and time value. It serializes a date and time on a system that observes U.S. Pacific time and whose current culture is en-US.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/serialize1.cs" id="Snippet17":::

It deserializes the data on a system in the Brussels, Copenhagen, Madrid and Paris time zone and whose current culture is fr-FR. The restored date is nine hours later than the original date, which reflects the time zone adjustment from eight hours behind UTC to one hour ahead of UTC. Both the original date and the restored date represent the same moment in time.

:::code language="csharp" source="./snippets/System.Globalization/DateTimeFormatInfo/csharp/serialize2.cs" id="Snippet18":::
