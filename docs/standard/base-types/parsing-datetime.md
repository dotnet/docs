---
title: Convert strings to DateTime
description: "Learn techniques to parse strings that represent dates and times to create a DateTime from the date and time string."
ms.date: 02/15/2018
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
  - "time strings"
---
# Parse date and time strings in .NET

Parsing strings to convert them to <xref:System.DateTime> objects requires you to specify information about how the dates and times are represented as text. Different cultures use different orders for day, month, and year. Some time representations use a 24-hour clock, others specify "AM" and "PM." Some applications need only the date. Others need only the time. Still others need to specify both the date and the time. The methods that convert strings to <xref:System.DateTime> objects enable you to provide detailed information about the formats you expect and the elements of a date and time your application needs. There are three subtasks to correctly converting text into a <xref:System.DateTime>:

1. You must specify the expected format of the text representing a date and time.
1. You may specify the culture for the format of a date time.
1. You may specify how missing components in the text representation are set in the date and time.

The <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.TryParse%2A> methods convert many common representations of a date and time. The <xref:System.DateTime.ParseExact%2A> and <xref:System.DateTime.TryParseExact%2A> methods convert a string representation that conforms to the pattern specified by a date and time format string. (See the articles on [standard date and time format strings](standard-date-and-time-format-strings.md) and [custom date and time format strings](custom-date-and-time-format-strings.md) for details.)

The current <xref:System.Globalization.DateTimeFormatInfo> object provides more control over how text should be interpreted as a date and time. Properties of a <xref:System.Globalization.DateTimeFormatInfo> describe the date and time separators, the names of months, days, and eras, and the format for the "AM" and "PM" designations. The <xref:System.Globalization.CultureInfo> returned by <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> has a <xref:System.Globalization.CultureInfo.DateTimeFormat?displayProperty=nameWithType> property that represents the current culture. If you want a specific culture or custom settings, you specify the <xref:System.IFormatProvider> parameter of a parsing method. For the <xref:System.IFormatProvider> parameter, specify a <xref:System.Globalization.CultureInfo> object, which represents a culture, or a <xref:System.Globalization.DateTimeFormatInfo> object.

The text representing a date or time may be missing some information. For example, most people would assume the date "March 12" represents the current year. Similarly, "March 2018" represents the month of March in the year 2018. Text representing time often does only includes hours, minutes, and an AM/PM designation.  Parsing methods handle this missing information by using reasonable defaults:

- When only the time is present, the date portion uses the current date.
- When only the date is present, the time portion is midnight.
- When the year isn't specified in a date, the current year is used.
- When the day of the month isn't specified, the first of the month is used.

If the date is present in the string, it must include the month and one of the day or year. If the time is present, it must include the hour, and either the minutes or the AM/PM designator.

You can specify the <xref:System.Globalization.DateTimeStyles.NoCurrentDateDefault> constant to override these defaults. When you use that constant, any missing year, month, or day properties are set to the value `1`. The [last example](#styles-example) using <xref:System.DateTime.Parse%2A> demonstrates this behavior.

In addition to a date and a time component, the string representation of a date and time can include an offset that indicates how much the time differs from Coordinated Universal Time (UTC). For example, the string "2/14/2007 5:32:00 -7:00" defines a time that is seven hours earlier than UTC. If an offset is omitted from the string representation of a time, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>. If an offset is specified, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind.Local?displayProperty=nameWithType> and its value adjusted to the local time zone of your machine. You can modify this behavior by using a <xref:System.Globalization.DateTimeStyles> value with the parsing method.

The format provider is also used to interpret an ambiguous numeric date. It is not clear which components of the date represented by the string "02/03/04" are the month, day, and year. The components are interpreted according to the order of similar date formats in the format provider.

## Parse

The following example illustrates the use of the <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> method to convert a `string` into a <xref:System.DateTime>. This example uses the culture associated with the current thread. If the <xref:System.Globalization.CultureInfo> associated with the current culture cannot parse the input string, a <xref:System.FormatException> is thrown.

> [!TIP]
> All the C# samples in this article run in your browser. Press the **Run** button to see the output. You can also edit them to experiment yourself.

> [!NOTE]
> These examples are available in the GitHub docs repo for both [C#](https://github.com/dotnet/docs/tree/main/samples/snippets/csharp/how-to/conversions) and [Visual Basic](https://github.com/dotnet/docs/tree/main/samples/snippets/visualbasic/how-to/conversions).

[!code-csharp-interactive[Parsing.DateAndTime#1](../../../samples/snippets/csharp/how-to/conversions/StringToDateTime.cs#1)]
[!code-vb[Parsing.DateAndTime#1](../../../samples/snippets/visualbasic/how-to/conversions/Program.vb#1)]

You can also explicitly define the culture whose formatting conventions are used when you parse a string. You specify one of the standard <xref:System.Globalization.DateTimeFormatInfo> objects returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. The following example uses a format provider to parse a German string into a <xref:System.DateTime>. It creates a <xref:System.Globalization.CultureInfo> representing the `de-DE` culture. That `CultureInfo` object ensures successful parsing of this particular string. This precludes whatever setting is in the <xref:System.Threading.Thread.CurrentCulture> of the <xref:System.Threading.Thread.CurrentThread>.

[!code-csharp-interactive[Parsing.DateAndTime#2](../../../samples/snippets/csharp/how-to/conversions/StringToDateTime.cs#2)]
[!code-vb[Parsing.DateAndTime#2](../../../samples/snippets/visualbasic/how-to/conversions/Program.vb#2)]

However, although you can use overloads of the <xref:System.DateTime.Parse%2A> method to specify custom format providers, the method does not support parsing non-standard formats. To parse a date and time expressed in a non-standard format, use the <xref:System.DateTime.ParseExact%2A> method instead.

<a name="styles-example"></a>The following example uses the <xref:System.Globalization.DateTimeStyles> enumeration to specify that the current date and time information should not be added to the <xref:System.DateTime> for unspecified fields.

[!code-csharp-interactive[Parsing.DateAndTime#3](../../../samples/snippets/csharp/how-to/conversions/StringToDateTime.cs#3)]
[!code-vb[Parsing.DateAndTime#3](../../../samples/snippets/visualbasic/how-to/conversions/Program.vb#3)]

## ParseExact

The <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method converts a string to a <xref:System.DateTime> object if it conforms to one of the specified string patterns. When a string that is not one of the forms specified is passed to this method, a <xref:System.FormatException> is thrown. You can specify one of the standard date and time format specifiers or a combination of the custom format specifiers. Using the custom format specifiers, it is possible for you to construct a custom recognition string. For an explanation of the specifiers, see the topics on [standard date and time format strings](standard-date-and-time-format-strings.md) and [custom date and time format strings](custom-date-and-time-format-strings.md).

In the following example, the <xref:System.DateTime.ParseExact%2A?displayProperty=nameWithType> method is passed a string object to parse, followed by a format specifier, followed by a <xref:System.Globalization.CultureInfo> object. This <xref:System.DateTime.ParseExact%2A> method can only parse strings that follow the long date pattern in the `en-US` culture.

[!code-csharp-interactive[Parsing.DateAndTime#4](../../../samples/snippets/csharp/how-to/conversions/StringToDateTime.cs#4)]
[!code-vb[Parsing.DateAndTime#4](../../../samples/snippets/visualbasic/how-to/conversions/Program.vb#4)]

Each overload of the <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.ParseExact%2A> methods also has an <xref:System.IFormatProvider> parameter that provides culture-specific information about the formatting of the string. This <xref:System.IFormatProvider> object is a <xref:System.Globalization.CultureInfo> object that represents a standard culture or a <xref:System.Globalization.DateTimeFormatInfo> object that is returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property.  <xref:System.DateTime.ParseExact%2A> also uses an additional string or string array argument that defines one or more custom date and time formats.

## See also

- [Parsing strings](parsing-strings.md)
- [Formatting types](formatting-types.md)
- [Type conversion in .NET](type-conversion.md)
- [Standard date and time formats](standard-date-and-time-format-strings.md)
- [Custom date and time format strings](custom-date-and-time-format-strings.md)
