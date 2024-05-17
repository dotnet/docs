---
title: System.TimeSpan struct
description: Learn about the System.TimeSpan struct.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.TimeSpan struct

[!INCLUDE [context](includes/context.md)]

A <xref:System.TimeSpan> object represents a time interval (duration of time or elapsed time) that is measured as a positive or negative number of days, hours, minutes, seconds, and fractions of a second. The <xref:System.TimeSpan> structure can also be used to represent the time of day, but only if the time is unrelated to a particular date. Otherwise, the <xref:System.DateTime> or <xref:System.DateTimeOffset> structure should be used instead. (For more information about using the <xref:System.TimeSpan> structure to reflect the time of day, see [Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](../../standard/datetime/choosing-between-datetime.md).)

> [!NOTE]
> A <xref:System.TimeSpan> value represents a time interval and can be expressed as a particular number of days, hours, minutes, seconds, and milliseconds. Because it represents a general interval without reference to a particular start or end point, it cannot be expressed in terms of years and months, both of which have a variable number of days. It differs from a <xref:System.DateTime> value, which represents a date and time without reference to a particular time zone, or a <xref:System.DateTimeOffset> value, which represents a specific moment of time.

The largest unit of time that the <xref:System.TimeSpan> structure uses to measure duration is a day. Time intervals are measured in days for consistency, because the number of days in larger units of time, such as months and years, varies.

The value of a <xref:System.TimeSpan> object is the number of ticks that equal the represented time interval. A tick is equal to 100 nanoseconds, or one ten-millionth of a second. The value of a <xref:System.TimeSpan> object can range from <xref:System.TimeSpan.MinValue?displayProperty=nameWithType> to <xref:System.TimeSpan.MaxValue?displayProperty=nameWithType>.

## Instantiate a TimeSpan value

You can instantiate a <xref:System.TimeSpan> value in a number of ways:

- By calling its implicit parameterless constructor. This creates an object whose value is <xref:System.TimeSpan.Zero?displayProperty=nameWithType>, as the following example shows.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/instantiate1.cs" interactive="try-dotnet-method" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/instantiate1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/instantiate1.vb" id="Snippet2":::

- By calling one of its explicit constructors. The following example initializes a <xref:System.TimeSpan> value to a specified number of hours, minutes, and seconds.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/instantiate1.cs" interactive="try-dotnet-method" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/instantiate1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/instantiate1.vb" id="Snippet3":::

- By calling a method or performing an operation that returns a <xref:System.TimeSpan> value. For example, you can instantiate a <xref:System.TimeSpan> value that represents the interval between two date and time values, as the following example shows.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/instantiate1.cs" interactive="try-dotnet-method" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/instantiate1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/instantiate1.vb" id="Snippet4":::

  You can also initialize a <xref:System.TimeSpan> object to a zero time value in this way, as the following example shows.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/zero1.cs" interactive="try-dotnet-method" id="Snippet6":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/zero1.fs" id="Snippet6":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/zero1.vb" id="Snippet6":::

     <xref:System.TimeSpan> values are returned by arithmetic operators and methods of the <xref:System.DateTime>, <xref:System.DateTimeOffset>, and <xref:System.TimeSpan> structures.

- By parsing the string representation of a <xref:System.TimeSpan> value. You can use the <xref:System.TimeSpan.Parse%2A> and <xref:System.TimeSpan.TryParse%2A> methods to convert strings that contain time intervals to <xref:System.TimeSpan> values. The following example uses the <xref:System.TimeSpan.Parse%2A> method to convert an array of strings to <xref:System.TimeSpan> values.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/instantiate1.cs" interactive="try-dotnet-method" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/instantiate1.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/instantiate1.vb" id="Snippet5":::

  In addition, you can define the precise format of the input string to be parsed and converted to a <xref:System.TimeSpan> value by calling the <xref:System.TimeSpan.ParseExact%2A> or <xref:System.TimeSpan.TryParseExact%2A> method.

## Perform operations on TimeSpan values

You can add and subtract time durations either by using the <xref:System.TimeSpan.op_Addition%2A> and <xref:System.TimeSpan.op_Subtraction%2A> operators, or by calling the <xref:System.TimeSpan.Add%2A> and <xref:System.TimeSpan.Subtract%2A> methods. You can also compare two time durations by calling the <xref:System.TimeSpan.Compare%2A>, <xref:System.TimeSpan.CompareTo%2A>, and <xref:System.TimeSpan.Equals%2A> methods. The <xref:System.TimeSpan> structure also includes the <xref:System.TimeSpan.Duration%2A> and <xref:System.TimeSpan.Negate%2A> methods, which convert time intervals to positive and negative values,

The range of <xref:System.TimeSpan> values is <xref:System.TimeSpan.MinValue> to <xref:System.TimeSpan.MaxValue>.

## Format a TimeSpan value

A <xref:System.TimeSpan> value can be represented as [*-*]*d*.*hh*:*mm*:*ss*.*ff*, where the optional minus sign indicates a negative time interval, the *d* component is days, *hh* is hours as measured on a 24-hour clock, *mm* is minutes, *ss* is seconds, and *ff* is fractions of a second. That is, a time interval consists of a positive or negative number of days without a time of day, or a number of days with a time of day, or only a time of day.

Beginning with .NET Framework 4, the <xref:System.TimeSpan> structure supports culture-sensitive formatting through the overloads of its <xref:System.TimeSpan.ToString%2A> method, which converts a <xref:System.TimeSpan> value to its string representation. The default <xref:System.TimeSpan.ToString?displayProperty=nameWithType> method returns a time interval by using an invariant format that is identical to its return value in previous versions of .NET Framework. The <xref:System.TimeSpan.ToString%28System.String%29?displayProperty=nameWithType> overload lets you specify a format string that defines the string representation of the time interval. The <xref:System.TimeSpan.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> overload lets you specify a format string and the culture whose formatting conventions are used to create the string representation of the time interval. <xref:System.TimeSpan> supports both standard and custom format strings. (For more information, see [Standard TimeSpan Format Strings](../../standard/base-types/standard-timespan-format-strings.md) and [Custom TimeSpan Format Strings](../../standard/base-types/custom-timespan-format-strings.md).) However, only standard format strings are culture-sensitive.

## Restore legacy TimeSpan formatting

In some cases, code that successfully formats <xref:System.TimeSpan> values in .NET Framework 3.5 and earlier versions fails in .NET Framework 4. This is most common in code that calls a [<TimeSpan_LegacyFormatMode> element](../../framework/configure-apps/file-schema/runtime/timespan-legacyformatmode-element.md) method to format a <xref:System.TimeSpan> value with a format string. The following example successfully formats a <xref:System.TimeSpan> value in .NET Framework 3.5 and earlier versions, but throws an exception in .NET Framework 4 and later versions. Note that it attempts to format a <xref:System.TimeSpan> value by using an unsupported format specifier, which is ignored in .NET Framework 3.5 and earlier versions.

:::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/legacycode1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/legacycode1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/legacycode1.vb" id="Snippet1":::

If you cannot modify the code, you can restore the legacy formatting of <xref:System.TimeSpan> values in one of the following ways:

- By creating a configuration file that contains the [<TimeSpan_LegacyFormatMode> element](../../framework/configure-apps/file-schema/runtime/timespan-legacyformatmode-element.md). Setting this element's `enabled` attribute to `true` restores legacy <xref:System.TimeSpan> formatting on a per-application basis.

- By setting the "NetFx40_TimeSpanLegacyFormatMode" compatibility switch when you create an application domain. This enables legacy <xref:System.TimeSpan> formatting on a per-application-domain basis. The following example creates an application domain that uses legacy <xref:System.TimeSpan> formatting.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/perappdomain1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/perappdomain1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/perappdomain1.vb" id="Snippet1":::

  When the following code executes in the new application domain, it reverts to legacy <xref:System.TimeSpan> formatting behavior.

  :::code language="csharp" source="./snippets/System/TimeSpan/Overview/csharp/showtimespan.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/TimeSpan/Overview/fsharp/showtimespan.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/TimeSpan/Overview/vb/showtimespan.vb" id="Snippet2":::
