---
title: How to use DateOnly and TimeOnly
description: Learn about the DateOnly and TimeOnly structures in .NET.
ms.date: 01/11/2023
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DateOnly structure"
  - "TimeOnly structure"
  - "date and time classes [.NET]"
---

# How to use the DateOnly and TimeOnly structures

The <xref:System.DateOnly> and <xref:System.TimeOnly> structures were introduced with .NET 6 and represent a specific date or time-of-day, respectively. Prior to .NET 6, and always in .NET Framework, developers used the <xref:System.DateTime> type (or some other alternative) to represent one of the following:

- A whole date and time.
- A date, disregarding the time.
- A time, disregarding the date.

`DateOnly` and `TimeOnly` are types that represent those particular portions of a `DateTime` type.

> [!IMPORTANT]
> <xref:System.DateOnly> and <xref:System.TimeOnly> types aren't available in .NET Framework.

## The DateOnly structure

The <xref:System.DateOnly> structure represents a specific date, without time. Since it has no time component, it represents a date from the start of the day to the end of the day. This structure is ideal for storing specific dates, such as a birth date, an anniversary date, or business-related dates.

Although you could use `DateTime` while ignoring the time component, there are a few benefits to using `DateOnly` over `DateTime`:

- The `DateTime` structure may roll into the previous or next day if it's offset by a time zone. `DateOnly` can't be offset by a time zone, and it always represents the date that was set.

- Serializing a `DateTime` structure includes the time component, which may obscure the intent of the data. Also, `DateOnly` serializes less data.

- When code interacts with a database, such as SQL Server, whole dates are generally stored as the `date` data type, which doesn't include a time. `DateOnly` matches the database type better.

`DateOnly` has a range from 0001-01-01 through 9999-12-31, just like `DateTime`. You can specify a specific calendar in the `DateOnly` constructor. However, a `DateOnly` object always represents a date in the proleptic Gregorian calendar, regardless of which calendar was used to construct it. For example, you can build the date from a Hebrew calendar, but the date is converted to Gregorian:

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="hebrew":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="hebrew":::

## DateOnly examples

Use the following examples to learn about `DateOnly`:

- [Convert DateTime to DateOnly](#convert-datetime-to-dateonly)
- [Add or subtract days, months, years](#add-or-subtract-days-months-years)
- [Parse and format DateOnly](#parse-and-format-dateonly)
- [Compare DateOnly](#compare-dateonly)

### Convert DateTime to DateOnly

Use the <xref:System.DateOnly.FromDateTime%2A?displayProperty=nameWithType> static method to create a `DateOnly` type from a `DateTime` type, as demonstrated in the following code:

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="today":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="today":::

### Add or subtract days, months, years

There are three methods used to adjust a <xref:System.DateOnly> structure: <xref:System.DateOnly.AddDays%2A>, <xref:System.DateOnly.AddMonths%2A>, and <xref:System.DateOnly.AddYears%2A>. Each method takes an integer parameter, and increases the date by that measurement. If a negative number is provided, the date is decreased by that measurement. The methods return a new instance of `DateOnly`, as the structure is immutable.

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="date_adjust":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="date_adjust":::

### Parse and format DateOnly

<xref:System.DateOnly> can be parsed from a string, just like the <xref:System.DateTime> structure. All of the standard .NET date-based parsing tokens work with `DateOnly`. When converting a `DateOnly` type to a string, you can use standard .NET date-based formatting patterns too. For more information about formatting strings, see [Standard date and time format strings](../base-types/standard-date-and-time-format-strings.md).

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="parse":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="parse":::

### Compare DateOnly

<xref:System.DateOnly> can be compared with other instances. For example, you can check if a date is before or after another, or if a date today matches a specific date.

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="date_compare":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="date_compare":::

## The TimeOnly structure

The <xref:System.TimeOnly> structure represents a time-of-day value, such as a daily alarm clock or what time you eat lunch each day. `TimeOnly` is limited to the range of **00:00:00.0000000** - **23:59:59.9999999**, a specific time of day.

Prior to the `TimeOnly` type being introduced, programmers typically used either the <xref:System.DateTime> type or the <xref:System.TimeSpan> type to represent a specific time. However, using these structures to simulate a time without a date may introduce some problems, which `TimeOnly` solves:

- `TimeSpan` represents elapsed time, such as time measured with a stopwatch. The upper range is more than 29,000 years, and its value can be negative to indicate moving backwards in time. A negative `TimeSpan` doesn't indicate a specific time of the day.

- If `TimeSpan` is used as a time of day, there's a risk that it could be manipulated to a value outside of the 24-hour day. `TimeOnly` doesn't have this risk. For example, if an employee's work shift starts at 18:00 and lasts for 8 hours, adding 8 hours to the `TimeOnly` structure rolls over to 2:00

- Using `DateTime` for a time of day requires that an arbitrary date be associated with the time, and then later disregarded. It's common practice to choose `DateTime.MinValue` (0001-01-01) as the date, however, if hours are subtracted from the `DateTime` value, an `OutOfRange` exception might occur. `TimeOnly` doesn't have this problem as the time rolls forwards and backwards around the 24-hour timeframe.

- Serializing a `DateTime` structure includes the date component, which may obscure the intent of the data. Also, `TimeOnly` serializes less data.

## TimeOnly examples

Use the following examples to learn about `TimeOnly`:

- [Convert DateTime to TimeOnly](#convert-datetime-to-timeonly)
- [Add or subtract time](#add-or-subtract-time)
- [Parse and format TimeOnly](#parse-and-format-timeonly)
- [Work with TimeSpan and DateTime](#work-with-timespan-and-datetime)
- [Arithmetic operators and comparing TimeOnly](#arithmetic-operators-and-comparing-timeonly)

### Convert DateTime to TimeOnly

Use the <xref:System.TimeOnly.FromDateTime%2A?displayProperty=nameWithType> static method to create a `TimeOnly` type from a `DateTime` type, as demonstrated in the following code:

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_now":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_now":::

### Add or subtract time

There are three methods used to adjust a <xref:System.TimeOnly> structure: <xref:System.TimeOnly.AddHours%2A>, <xref:System.TimeOnly.AddMinutes%2A>, and <xref:System.TimeOnly.Add%2A>. Both `AddHours` and `AddMinutes` take an integer parameter, and adjust the value accordingly. You can use a negative value to subtract and a positive value to add. The methods return a new instance of `TimeOnly` is returned, as the structure is immutable. The `Add` method takes a <xref:System.TimeSpan> parameter and adds or subtracts the value from the `TimeOnly` value.

Because `TimeOnly` only represents a 24-hour period, it rolls over forwards or backwards appropriately when adding values supplied to those three methods. For example, if you use a value of `01:30:00` to represent 1:30 AM, then add -4 hours from that period, it rolls backwards to `21:30:00`, which is 9:30 PM. There are method overloads for `AddHours`, `AddMinutes`, and `Add` that capture the number of days rolled over.

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_adjust":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_adjust":::

### Parse and format TimeOnly

<xref:System.TimeOnly> can be parsed from a string, just like the <xref:System.DateTime> structure. All of the standard .NET time-based parsing tokens work with `TimeOnly`. When converting a `TimeOnly` type to a string, you can use standard .NET date-based formatting patterns too. For more information about formatting strings, see [Standard date and time format strings](../base-types/standard-date-and-time-format-strings.md).

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_parse":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_parse":::

### Serialize DateOnly and TimeOnly types

[!INCLUDE [dateonly-and-timeonly-serialization](includes/dateonly-and-timeonly-serialization.md)]

For more information, see [How to serialize and deserialize (marshal and unmarshal) JSON in .NET](../serialization/system-text-json/how-to.md#how-to-serialize-and-deserialize-marshal-and-unmarshal-json-in-net).

### Work with TimeSpan and DateTime

<xref:System.TimeOnly> can be created from and converted to a <xref:System.TimeSpan>. Also, `TimeOnly` can be used with a <xref:System.DateTime>, either to create the `TimeOnly` instance, or to create a `DateTime` instance as long as a date is provided.

The following example creates a `TimeOnly` object from a `TimeSpan`, and then converts it back:

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_timespan":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_timespan":::

The following example creates a `DateTime` from a `TimeOnly` object, with an arbitrary date chosen:

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_datetime":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_datetime":::

### Arithmetic operators and comparing TimeOnly

Two <xref:System.TimeOnly> instances can be compared with one another, and you can use the <xref:System.TimeOnly.IsBetween%2A> method to check if a time is between two other times. When an addition or subtraction operator is used on a `TimeOnly`, a <xref:System.TimeSpan> is returned, representing a duration of time.

:::code language="csharp" source="./snippets/how-to-use-dateonly-timeonly/csharp/Program.cs" id="time_between":::
:::code language="vb" source="./snippets/how-to-use-dateonly-timeonly/vb/Program.vb" id="time_between":::
