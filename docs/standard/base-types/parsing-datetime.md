---
title: Parse date and time strings
description: "Learn techniques to parse strings that represent dates and times to create DateTime, DateOnly, and TimeOnly objects from string representations."
ms.date: 01/16/2026
ms.custom: devdivchpfy22
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "parsing strings, date and time strings"
  - "date and time strings"
  - "ParseExact method"
  - "enumerations [.NET], parsing strings"
  - "base types, parsing strings"
  - "DateTime object"
  - "DateOnly structure"
  - "TimeOnly structure"
  - "time strings"
---
# Parse date and time strings in .NET

.NET provides several types for working with date and time data, each optimized for different scenarios:

- **<xref:System.DateTime>** - Represents a date and time together, ideal when you need both components or when working with legacy code.
- **<xref:System.DateOnly>** (not available in .NET Framework) - Represents only a date without time information, perfect for birthdays, anniversaries, or business dates.
- **<xref:System.TimeOnly>** (not available in .NET Framework) - Represents only a time without date information, ideal for schedules, alarms, or recurring daily events.

Each type provides parsing methods that convert strings to their respective objects, with different levels of flexibility and control over the parsing process.

## Common parsing concepts

All three date and time types share similar parsing approaches:

- **Parse methods** - Convert many common string representations using current culture or specified culture settings
- **ParseExact methods** - Convert strings that conform to specific format patterns, providing precise control over expected formats
- **Culture and format providers** - Control how text is interpreted based on cultural conventions for date and time representation
- **Format strings** - Define patterns for parsing using standard or custom format specifiers

Different cultures use different orders for day, month, and year. Some time representations use a 24-hour clock, others specify "AM" and "PM." The parsing methods handle these variations through culture-specific formatting rules.

The <xref:System.Globalization.DateTimeFormatInfo> object provides control over how text should be interpreted. Properties describe the date and time separators, names of months, days, eras, and the format for "AM" and "PM" designations. You can specify culture through the <xref:System.IFormatProvider> parameter using a <xref:System.Globalization.CultureInfo> object or a <xref:System.Globalization.DateTimeFormatInfo> object.

For more information about format patterns, see [standard date and time format strings](standard-date-and-time-format-strings.md) and [custom date and time format strings](custom-date-and-time-format-strings.md).

> [!IMPORTANT]
> <xref:System.DateOnly> and <xref:System.TimeOnly> types aren't available for .NET Framework.

## DateTime parsing

<xref:System.DateTime> represents both date and time components together. When parsing strings to DateTime objects, you need to consider several DateTime-specific aspects:

1. **Missing information handling** - DateTime uses defaults when parts are missing from the input string
2. **Time zone and UTC offset support** - DateTime can represent local, UTC, or unspecified time zones
3. **Combined date and time parsing** - Must handle both date and time components in a single operation

### Missing information handling

The text representing a date or time might be missing some information. For example, most people would assume the date "March 12" represents the current year. Similarly, "March 2018" represents the month of March in the year 2018. Text representing time often includes only hours, minutes, and an AM/PM designation. DateTime parsing methods handle this missing information by using reasonable defaults:

- When only the time is present, the date portion uses the current date.
- When only the date is present, the time portion is midnight.
- When the year isn't specified in a date, the current year is used.
- When the day of the month isn't specified, the first day of the month is used.

If the date is present in the string, it must include the month and one of the day or year. If the time is present, it must include the hour, and either the minutes or the AM/PM designator.

You can specify the <xref:System.Globalization.DateTimeStyles.NoCurrentDateDefault> constant to override these defaults. When you use that constant, any missing year, month, or day properties are set to the value `1`. The [last example](#styles-example) using <xref:System.DateTime.Parse%2A> demonstrates this behavior.

### UTC offset and time zone handling

In addition to a date and a time component, the string representation of a date and time can include an offset that indicates how much the time differs from Coordinated Universal Time (UTC). For example, the string "2/14/2007 5:32:00 -7:00" defines a time that's seven hours earlier than UTC. If an offset is omitted from the string representation of a time, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>. If an offset is specified, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind.Local?displayProperty=nameWithType>. Its value is also adjusted to the local time zone of your machine. You can modify this behavior by using a <xref:System.Globalization.DateTimeStyles> value with the parsing method.

### Ambiguous date handling

The format provider is also used to interpret an ambiguous numeric date. It's unclear which components of the date represented by the string "02/03/04" are the month, day, and year. The components are interpreted according to the order of similar date formats in the format provider.

### DateTime.Parse

The following example shows the use of the <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> method to convert a `string` into a <xref:System.DateTime>. This example uses the culture associated with the current thread. If the <xref:System.Globalization.CultureInfo> associated with the current culture can't parse the input string, a <xref:System.FormatException> is thrown.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="datetime-parse" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="datetime-parse" lang="vb":::

You can also explicitly define the culture whose formatting conventions are used when you parse a string. You specify one of the standard <xref:System.Globalization.DateTimeFormatInfo> objects returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. The following example uses a format provider to parse a German string into a <xref:System.DateTime>. It creates a <xref:System.Globalization.CultureInfo> representing the `de-DE` culture. That `CultureInfo` object ensures successful parsing of this particular string. This process precludes whatever setting is in the <xref:System.Threading.Thread.CurrentCulture> of the <xref:System.Threading.Thread.CurrentThread>.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="datetime-parse-culture" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="datetime-parse-culture" lang="vb":::

However, you can use overloads of the <xref:System.DateTime.Parse%2A> method to specify custom format providers. The <xref:System.DateTime.Parse%2A> method doesn't support parsing non-standard formats. To parse a date and time expressed in a non-standard format, use the <xref:System.DateTime.ParseExact%2A> method instead.

<a name="styles-example"></a>The following example uses the <xref:System.Globalization.DateTimeStyles> enumeration to specify that the current date and time information shouldn't be added to the <xref:System.DateTime> for unspecified fields.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="datetime-parse-nodefault" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="datetime-parse-nodefault" lang="vb":::

### DateTime.ParseExact

The <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method converts a string to a <xref:System.DateTime> object if it conforms to one of the specified string patterns. When a string that isn't one of the forms specified is passed to this method, a <xref:System.FormatException> is thrown. You can specify one of the standard date and time format specifiers or a combination of the custom format specifiers. Using the custom format specifiers, it's possible for you to construct a custom recognition string. For an explanation of the specifiers, see the articles on [standard date and time format strings](standard-date-and-time-format-strings.md) and [custom date and time format strings](custom-date-and-time-format-strings.md).

In the following example, the <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method is passed a string object to parse, followed by a format specifier, followed by a <xref:System.Globalization.CultureInfo> object. This <xref:System.DateTime.ParseExact%2A> method can only parse strings that follow the long date pattern in the `en-US` culture.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="datetime-parseexact" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="datetime-parseexact" lang="vb":::

Each overload of the <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.ParseExact%2A> methods also has an <xref:System.IFormatProvider> parameter that provides culture-specific information about the formatting of the string. The <xref:System.IFormatProvider> object is a <xref:System.Globalization.CultureInfo> object that represents a standard culture or a <xref:System.Globalization.DateTimeFormatInfo> object that's returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. <xref:System.DateTime.ParseExact%2A> also uses an additional string or string array argument that defines one or more custom date and time formats.

## DateOnly parsing

The <xref:System.DateOnly> structure represents only a date without time information, making it perfect for scenarios like birthdays, anniversaries, or business dates. Since it has no time component, it represents a date from the start of the day to the end of the day.

`DateOnly` has several advantages over using `DateTime` for date-only scenarios:

- The `DateTime` structure might roll into the previous or next day if it's offset by a time zone. `DateOnly` can't be offset by a time zone, and it always represents the date that was set.
- Serializing a `DateOnly` includes less data than `DateTime`.
- When code interacts with a database, such as SQL Server, whole dates are generally stored as the `date` data type, which doesn't include a time. `DateOnly` matches the database type better.

### DateOnly.Parse

The <xref:System.DateOnly.Parse%2A?displayProperty=nameWithType> method converts common date string representations to a <xref:System.DateOnly> object. The method accepts various formats and uses the current culture or a specified culture for parsing.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="dateonly-parse" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="dateonly-parse" lang="vb":::

### DateOnly.ParseExact

The <xref:System.DateOnly.ParseExact%2A?displayProperty=nameWithType> method provides precise control over the expected format of the input string. Use this method when you know the exact format of the date string and want to ensure strict parsing.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="dateonly-parseexact" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="dateonly-parseexact" lang="vb":::

The `ParseExact` method accepts either a single format string or an array of format strings, allowing you to parse dates that might come in multiple acceptable formats.

## TimeOnly parsing

The <xref:System.TimeOnly> structure represents a time-of-day value, such as a daily alarm clock or what time you eat lunch each day. `TimeOnly` is limited to the range of **00:00:00.0000000** - **23:59:59.9999999**, a specific time of day.

`TimeOnly` solves several problems that existed when using other types for time-only scenarios:

- `TimeSpan` represents elapsed time and can be negative or exceed 24 hours, making it unsuitable for representing a specific time of day.
- Using `DateTime` for a time of day requires an arbitrary date, which can lead to unexpected behavior when performing calculations.
- `TimeOnly` naturally handles 24-hour rollover when adding or subtracting time values.

### TimeOnly.Parse

The <xref:System.TimeOnly.Parse%2A?displayProperty=nameWithType> method converts common time string representations to a <xref:System.TimeOnly> object. The method accepts various formats including 12-hour and 24-hour notation.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="timeonly-parse" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="timeonly-parse" lang="vb":::

### TimeOnly.ParseExact

The <xref:System.TimeOnly.ParseExact%2A?displayProperty=nameWithType> method provides precise control over the expected format of the input time string. Use this method when you know the exact format and want to ensure strict parsing.

:::snippet source="./snippets/parsing-datetime/csharp/Program.cs" id="timeonly-parseexact" lang="csharp":::
:::snippet source="./snippets/parsing-datetime/vb/Program.vb" id="timeonly-parseexact" lang="vb":::

## See also

- [Parsing strings](parsing-strings.md)
- [Formatting types](formatting-types.md)
- [Type conversion in .NET](type-conversion.md)
- [Standard date and time formats](standard-date-and-time-format-strings.md)
- [Custom date and time format strings](custom-date-and-time-format-strings.md)
- [How to use the DateOnly and TimeOnly structures](../datetime/how-to-use-dateonly-timeonly.md)
