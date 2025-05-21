---
title: Composite formatting
description: Learn about .NET composite formatting, which takes as input a list of objects and a composite format string, containing fixed text with indexed placeholders.
ms.date: 08/07/2023
ms.topic: article
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "parameter specifiers"
  - "strings [.NET], alignment"
  - "format specifiers, composite formatting"
  - "strings [.NET], composite"
  - "composite formatting"
  - "objects [.NET], formatting multiple objects"
---
# Composite formatting

The .NET composite formatting feature takes a list of objects and a composite format string as input. A composite format string consists of fixed text intermixed with indexed placeholders, called format items. These format items correspond to the objects in the list. The formatting operation yields a result string that consists of the original fixed text intermixed with the string representation of the objects in the list.

> [!IMPORTANT]
> Instead of using composite format strings, you can use *interpolated strings* if the language and its version that you're using support them. An interpolated string contains *interpolated expressions*. Each interpolated expression is resolved with the expression's value and included in the result string when the string is assigned. For more information, see [String interpolation (C# Reference)](../../csharp/language-reference/tokens/interpolated.md) and [Interpolated strings (Visual Basic Reference)](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md).

The following methods support the composite formatting feature:

- <xref:System.String.Format%2A?displayProperty=nameWithType>, which returns a formatted result string.
- <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>, which appends a formatted result string to a <xref:System.Text.StringBuilder> object.
- Some overloads of the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method, which display a formatted result string to the console.
- Some overloads of the <xref:System.IO.TextWriter.WriteLine%2A?displayProperty=nameWithType> method, which write the formatted result string to a stream or file. The classes derived from <xref:System.IO.TextWriter>, such as <xref:System.IO.StreamWriter> and <xref:System.Web.UI.HtmlTextWriter>, also share this functionality.
- <xref:System.Diagnostics.Debug.WriteLine%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, which outputs a formatted message to trace listeners.
- The <xref:System.Diagnostics.Trace.TraceError%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, <xref:System.Diagnostics.Trace.TraceInformation%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, and <xref:System.Diagnostics.Trace.TraceWarning%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> methods, which output formatted messages to trace listeners.
- The <xref:System.Diagnostics.TraceSource.TraceInformation%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method, which writes an informational method to trace listeners.

## Composite format string

A composite format string and object list are used as arguments of methods that support the composite formatting feature. A composite format string consists of zero or more runs of fixed text intermixed with one or more format items. The fixed text is any string that you choose, and each format item corresponds to an object or boxed structure in the list. The string representation of each object replaces the corresponding format item.

Consider the following <xref:System.String.Format%2A> code fragment:

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="basic":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="basic":::

<!-- markdownlint-disable-next-line no-space-in-code -->
The fixed text is `Name = `&nbsp;and `, hours = `. The format items are `{0}`, whose index of 0 corresponds to the object `name`, and `{1:hh}`, whose index of 1 corresponds to the object `DateTime.Now`.

## Format item syntax

Each format item takes the following form and consists of the following components:

`{index[,width][:formatString]}`

The matching braces (`{` and `}`) are required.

### Index component

The mandatory `index` component, which is also called a parameter specifier, is a number starting from 0 that identifies a corresponding item in the list of objects. That is, the format item whose parameter specifier is `0` formats the first object in the list. The format item whose parameter specifier is `1` formats the second object in the list, and so on. The following example includes four parameter specifiers, numbered zero through three,  to represent prime numbers less than 10:

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="index":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="index":::

Multiple format items can refer to the same element in the list of objects by specifying the same parameter specifier. For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying a composite format string such as `"0x{0:X} {0:E} {0:N}"`, as the following example shows:

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="multiple":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="multiple":::

Each format item can refer to any object in the list. For example, if there are three objects, you can format the second, first, and third object by specifying a composite format string such as `{1} {0} {2}`. An object that isn't referenced by a format item is ignored. A <xref:System.FormatException> is thrown at run time if a parameter specifier designates an item outside the bounds of the list of objects.

### Width component

The optional `width` component is a signed integer indicating the preferred formatted field width. If the value of `width` is less than the length of the formatted string, `width` is ignored, and the length of the formatted string is used as the field width. The formatted data in the field is right-aligned if `width` is positive and left-aligned if `width` is negative. If padding is necessary, white space is used. The comma is required if `width` is specified.

The following example defines two arrays, one containing the names of employees and the other containing the hours they worked over two weeks. The composite format string left-aligns the names in a 20-character field and right-aligns their hours in a 5-character field. The "N1" standard format string formats the hours with one fractional digit.

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="alignment":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="alignment":::

### Format string component

The optional `formatString` component is a format string that's appropriate for the type of object being formatted. You can specify:

- A standard or custom numeric format string if the corresponding object is a numeric value.
- A standard or custom date and time format string if the corresponding object is a <xref:System.DateTime> object.
- An [enumeration format string](enumeration-format-strings.md) if the corresponding object is an enumeration value.

If `formatString` isn't specified, the general ("G") format specifier for a numeric, date and time, or enumeration type is used. The colon is required if `formatString` is specified.

The following table lists types or categories of types in the .NET class library that support a predefined set of format strings, and provides links to the articles that list the supported format strings. String formatting is an extensible mechanism that makes it possible to define new format strings for all existing types and to define a set of format strings supported by an application-defined type.

For more information, see the <xref:System.IFormattable> and <xref:System.ICustomFormatter> interface articles.

| Type or type category | See |
|--|--|
| Date and time types (<xref:System.DateTime>, <xref:System.DateTimeOffset>) | [Standard Date and Time Format Strings](standard-date-and-time-format-strings.md)<br /><br /> [Custom Date and Time Format Strings](custom-date-and-time-format-strings.md) |
| Enumeration types (all types derived from <xref:System.Enum?displayProperty=nameWithType>) | [Enumeration Format Strings](enumeration-format-strings.md) |
| Numeric types (<xref:System.Numerics.BigInteger>, <xref:System.Byte>, <xref:System.Decimal>, <xref:System.Double>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.Single>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>) | [Standard Numeric Format Strings](standard-numeric-format-strings.md)<br /><br /> [Custom Numeric Format Strings](custom-numeric-format-strings.md) |
| <xref:System.Guid> | <xref:System.Guid.ToString%28System.String%29?displayProperty=nameWithType> |
| <xref:System.TimeSpan> | [Standard TimeSpan Format Strings](standard-timespan-format-strings.md)<br /><br /> [Custom TimeSpan Format Strings](custom-timespan-format-strings.md) |

### Escaping braces

Opening and closing braces are interpreted as starting and ending a format item. To display a literal opening brace or closing brace, you must use an escape sequence. Specify two opening braces (`{{`) in the fixed text to display one opening brace (`{`), or two closing braces (`}}`) to display one closing brace (`}`).

Escaped braces with a format item are parsed differently between .NET and .NET Framework.

#### .NET

Braces can be escaped around a format item. For example, consider the format item `{{{0:D}}}`, which is intended to display an opening brace, a numeric value formatted as a decimal number, and a closing brace. The format item is interpreted in the following manner:

1. The first two opening braces (`{{`) are escaped and yield one opening brace.
1. The next three characters (`{0:`) are interpreted as the start of a format item.
1. The next character (`D`) is interpreted as the Decimal standard numeric format specifier.
1. The next brace (`}`) is interpreted as the end of the format item.
1. The final two closing braces are escaped and yield one closing brace.
1. The final result that's displayed is the literal string, `{6324}`.

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="now_good":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="now_good":::

#### .NET Framework

Braces in a format item are interpreted sequentially in the order they're encountered. Interpreting nested braces isn't supported.

The way escaped braces are interpreted can lead to unexpected results. For example, consider the format item `{{{0:D}}}`, which is intended to display an opening brace, a numeric value formatted as a decimal number, and a closing brace. However, the format item is interpreted in the following manner:

1. The first two opening braces (`{{`) are escaped and yield one opening brace.
1. The next three characters (`{0:`) are interpreted as the start of a format item.
1. The next character (`D`) would be interpreted as the Decimal standard numeric format specifier, but the next two escaped braces (`}}`) yield a single brace. Because the resulting string (`D}`) isn't a standard numeric format specifier, the resulting string is interpreted as a custom format string that means display the literal string `D}`.
1. The last brace (`}`) is interpreted as the end of the format item.
1. The final result that's displayed is the literal string, `{D}`. The numeric value that was to be formatted isn't displayed.

:::code language="csharp" source="./snippets/composite-formatting/framework/csharp/Program.cs" id="bad":::
:::code language="vb" source="./snippets/composite-formatting/framework/vb/Program.vb" id="bad":::

One way to write your code to avoid misinterpreting escaped braces and format items is to format the braces and format items separately. That is, in the first format operation, display a literal opening brace. In the next operation, display the result of the format item, and in the final operation, display a literal closing brace. The following example illustrates this approach:

:::code language="csharp" source="./snippets/composite-formatting/framework/csharp/Program.cs" id="good":::
:::code language="vb" source="./snippets/composite-formatting/framework/vb/Program.vb" id="good":::

### Processing order

If the call to the composite formatting method includes an <xref:System.IFormatProvider> argument whose value isn't `null`, the runtime calls its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method to request an <xref:System.ICustomFormatter> implementation. If the method can return an <xref:System.ICustomFormatter> implementation, it's cached during the call of the composite formatting method.

Each value in the parameter list that corresponds to a format item is converted to a string as follows:

1. If the value to be formatted is `null`, an empty string <xref:System.String.Empty?displayProperty=nameWithType> is returned.
1. If an <xref:System.ICustomFormatter> implementation is available, the runtime calls its <xref:System.ICustomFormatter.Format%2A> method. The runtime passes the format item's `formatString` value (or `null` if it's not present) to the method. The runtime also passes the <xref:System.IFormatProvider> implementation to the method. If the call to the <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> method returns `null`, execution proceeds to the next step. Otherwise, the result of the <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> call is returned.
1. If the value implements the <xref:System.IFormattable> interface, the interface's <xref:System.IFormattable.ToString%28System.String%2CSystem.IFormatProvider%29> method is called. If one is present in the format item, the `formatString` value is passed to the method. Otherwise, `null` is passed. The <xref:System.IFormatProvider> argument is determined as follows:

    - For a numeric value, if a composite formatting method with a non-null <xref:System.IFormatProvider> argument is called, the runtime requests a <xref:System.Globalization.NumberFormatInfo> object from its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method. If it's unable to supply one, if the value of the argument is `null`, or if the composite formatting method doesn't have an <xref:System.IFormatProvider> parameter, the <xref:System.Globalization.NumberFormatInfo> object for the current culture is used.
    - For a date and time value, if a composite formatting method with a non-null <xref:System.IFormatProvider> argument is called, the runtime requests a <xref:System.Globalization.DateTimeFormatInfo> object from its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method. In the following situations, the <xref:System.Globalization.DateTimeFormatInfo> object for the current culture is used instead:

       - The <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method is unable to supply a <xref:System.Globalization.DateTimeFormatInfo> object.
       - The value of the argument is `null`.
       - The composite formatting method doesn't have an <xref:System.IFormatProvider> parameter.

    - For objects of other types, if a composite formatting method is called with an <xref:System.IFormatProvider> argument, its value is passed directly to the <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation. Otherwise, `null` is passed to the <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation.

1. The type's parameterless `ToString` method, which either overrides <xref:System.Object.ToString?displayProperty=nameWithType> or inherits the behavior of its base class, is called. In this case, the format string specified by the `formatString` component in the format item, if it's present, is ignored.

Alignment is applied after the preceding steps have been performed.

## Code examples

The following example shows one string created using composite formatting and another created using an object's `ToString` method. Both types of formatting produce equivalent results.

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="example_tostring":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="example_tostring":::

Assuming that the current day is a Thursday in May, the value of both strings in the preceding example is `Thursday May` in the U.S. English culture.

<xref:System.Console.WriteLine%2A?displayProperty=nameWithType> exposes the same functionality as <xref:System.String.Format%2A?displayProperty=nameWithType>. The only difference between the two methods is that <xref:System.String.Format%2A?displayProperty=nameWithType> returns its result as a string, while <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> writes the result to the output stream associated with the <xref:System.Console> object. The following example uses the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method to format the value of `myNumber` to a currency value:

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="example_currency":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="example_currency":::

The following example demonstrates formatting multiple objects, including formatting one object in two different ways:

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="example_multiple":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="example_multiple":::

The following example demonstrates the use of width in formatting. The arguments that are formatted are placed between vertical bar characters (`|`) to highlight the resulting alignment.

:::code language="csharp" source="./snippets/composite-formatting/net/csharp/Program.cs" id="example_bar":::
:::code language="vb" source="./snippets/composite-formatting/net/vb/Program.vb" id="example_bar":::

## See also

- <xref:System.Console.WriteLine%2A>
- <xref:System.String.Format%2A?displayProperty=nameWithType>
- [String interpolation (C#)](../../csharp/language-reference/tokens/interpolated.md)
- [String interpolation (Visual Basic)](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md)
- [Formatting types](formatting-types.md)
- [Standard numeric format strings](standard-numeric-format-strings.md)
- [Custom numeric format strings](custom-numeric-format-strings.md)
- [Standard date and time format strings](standard-date-and-time-format-strings.md)
- [Custom date and time format strings](custom-date-and-time-format-strings.md)
- [Standard TimeSpan format strings](standard-timespan-format-strings.md)
- [Custom TimeSpan format strings](custom-timespan-format-strings.md)
- [Enumeration format strings](enumeration-format-strings.md)
