---
title: System.String.Format method
description: Learn about the System.String.Format method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.String.Format method

[!INCLUDE [context](includes/context.md)]

[!INCLUDE[interpolated-strings](includes/interpolated-strings.md)]

## Examples

Numerous examples that call the <xref:System.String.Format%2A> method are interspersed throughout this article. You can also download a complete set of `String.Format` examples, which are included a [.NET Core project for C#](/samples/dotnet/samples/string-format/).

The following are some of the examples included in the article:

### Create a format string

[Insert a string](#insert-a-string)\
[The format item](#the-format-item)\
[Format items that have the same index](#format-items-that-have-the-same-index)

### Control formatted output

[Control formatting](#control-formatting)\
[Control spacing](#control-spacing)\
[Control alignment](#control-alignment)\
[Control the number of integral digits](#how-do-i-control-the-number-of-integral-digits)\
[Control the number of digits after the decimal separator](#how-do-i-control-the-number-of-digits-after-the-decimal-separator)\
[Include literal braces in the result string](#how-do-i-include-literal-braces--and--in-the-result-string)

### Make format strings culture-sensitive

[Make format strings culture-sensitive](#make-format-strings-culture-sensitive)

### Customize the formatting operation

[A custom formatting operation](#example-a-custom-formatting-operation)\
[An intercept provider and Roman numeral formatter](#example-an-intercept-provider-and-roman-numeral-formatter)

## Get started with the String.Format method

Use <xref:System.String.Format%2A?displayProperty=nameWithType> if you need to insert the value of an object, variable, or expression into another string. For example, you can insert the value of a <xref:System.Decimal> value into a string to display it to the user as a single string:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting2.cs" interactive="try-dotnet-method" id="Snippet35":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting2.fs" id="Snippet35":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting2.vb" id="Snippet35":::

And you can control that value's formatting:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting2.cs" id="Snippet36":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting2.fs" id="Snippet36":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting2.vb" id="Snippet36":::

Besides formatting, you can also control alignment and spacing.

### Insert a string

<xref:System.String.Format%2A?displayProperty=nameWithType> starts with a format string, followed by one or more objects or expressions that will be converted to strings and inserted at a specified place in the format string. For example:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting1.cs" interactive="try-dotnet-method" id="Snippet30":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting1.fs" id="Snippet30":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting1.vb" id="Snippet30":::

The `{0}` in the format string is a format item. `0` is the index of the object whose string value will be inserted at that position. (Indexes start at 0.) If the object to be inserted is not a string, its `ToString` method is called to convert it to one before inserting it in the result string.

Here's another example that uses two format items and two objects in the object list:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting1.cs" id="Snippet31":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting1.fs" id="Snippet31":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting1.vb" id="Snippet31":::

You can have as many format items and as many objects in the object list as you want, as long as the index of every format item has a matching object in the object list. You also don't have to worry about which overload you call; the compiler will select the appropriate one for you.

### Control formatting

You can follow the index in a format item with a format string to control how an object is formatted. For example, `{0:d}` applies the "d" format string to the first object in the object list. Here is an example with a single object and two format items:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting1.cs" id="Snippet32":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting1.fs" id="Snippet32":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting1.vb" id="Snippet32":::

Numerous types support format strings, including all numeric types (both [standard](../../standard/base-types/standard-numeric-format-strings.md) and [custom](../../standard/base-types/custom-numeric-format-strings.md) format strings), all dates and times (both [standard](../../standard/base-types/standard-date-and-time-format-strings.md) and [custom](../../standard/base-types/custom-date-and-time-format-strings.md) format strings) and time intervals (both [standard](../../standard/base-types/standard-timespan-format-strings.md) and [custom](../../standard/base-types/custom-timespan-format-strings.md) format strings), all enumeration types [enumeration types](../../standard/base-types/enumeration-format-strings.md), and [GUIDs](xref:System.Guid.ToString(System.String)). You can also add support for format strings to your own types.

### Control spacing

You can define the width of the string that's inserted into the result string by using syntax such as `{0,12}`, which inserts a 12-character string. In this case, the string representation of the first object is right-aligned in the 12-character field. (If the string representation of the first object is more than 12 characters in length, though, the preferred field width is ignored, and the entire string is inserted into the result string.)

The following example defines a 6-character field to hold the string "Year" and some year strings, as well as an 15-character field to hold the string "Population" and some population data. Note that the characters are right-aligned in the field.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting3.cs" id="Snippet33":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting3.fs" id="Snippet33":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting1.vb" id="Snippet33":::

### Control alignment

By default, strings are right-aligned within their field if you specify a field width. To left-align strings in a field, you preface the field width with a negative sign, such as `{0,-12}` to define a 12-character left-aligned field.

The following example is similar to the previous one, except that it left-aligns both labels and data.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/starting1.cs" id="Snippet34":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/starting1.fs" id="Snippet34":::
:::code language="vb" source="./snippets/System/String/Format/vb/starting1.vb" id="Snippet34":::

<xref:System.String.Format%2A?displayProperty=nameWithType> makes use of the composite formatting feature. For more information, see [Composite Formatting](../../standard/base-types/composite-formatting.md).

## Which method do I call?

| Objective | Method to call |
|-----------|----------------|
|Format one or more objects by using the conventions of the current culture.|Except for the overloads that include a `provider` parameter, the remaining <xref:System.String.Format%2A> overloads include a <xref:System.String> parameter followed by one or more object parameters. Because of this, you don't have to determine which <xref:System.String.Format%2A> overload you intend to call. Your language compiler selects the appropriate overload from among the overloads that don't have a `provider` parameter, based on your argument list. For example, if your argument list has five arguments, the compiler calls the <xref:System.String.Format(System.String,System.Object%5B%5D)> method.|
|Format one or more objects by using the conventions of a specific culture.|Each <xref:System.String.Format%2A> overload that begins with a `provider` parameter is followed by a <xref:System.String> parameter and one or more object parameters. Because of this, you don't have to determine which specific <xref:System.String.Format%2A> overload you intend to call. Your language compiler selects the appropriate overload from among the overloads that have a `provider` parameter, based on your argument list. For example, if your argument list has five arguments, the compiler calls the <xref:System.String.Format(System.IFormatProvider,System.String,System.Object%5B%5D)> method.|
|Perform a custom formatting operation either with an <xref:System.ICustomFormatter> implementation or an <xref:System.IFormattable> implementation.|Any of the four overloads with a `provider` parameter. The compiler selects the appropriate overload from among the overloads that have a `provider` parameter, based on your argument list.|

## The Format method in brief

Each overload of the <xref:System.String.Format%2A> method uses the [composite formatting feature](../../standard/base-types/composite-formatting.md) to include zero-based indexed placeholders, called *format items*, in a composite format string. At run time, each format item is replaced with the string representation of the corresponding argument in a parameter list. If the value of the argument is `null`, the format item is replaced with <xref:System.String.Empty?displayProperty=nameWithType>. For example, the following call to the <xref:System.String.Format(System.String,System.Object,System.Object,System.Object)> method includes a format string with three format items, {0}, {1}, and {2}, and an argument list with three items.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/formatoverload1.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/formatoverload1.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/String/Format/vb/formatoverload1.vb" id="Snippet8":::

## The format item

A format item has this syntax:

```txt
{index[,width][:formatString]}
```

Brackets denote optional elements. The opening and closing braces are required. (To include a literal opening or closing brace in the format string, see the [Escaping Braces](../../standard/base-types/composite-formatting.md#escaping-braces) section in the [Composite Formatting](../../standard/base-types/composite-formatting.md) article.)

For example, a format item to format a currency value might appear like this:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/formatsyntax1.cs" id="Snippet12":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/formatsyntax1.fs" id="Snippet12":::
:::code language="vb" source="./snippets/System/String/Format/vb/formatsyntax1.vb" id="Snippet12":::

A format item has the following elements:

`index`\
The zero-based index of the argument whose string representation is to be included at this position in the string. If this argument is `null`, an empty string will be included at this position in the string.

`width`\
Optional. A signed integer that indicates the total length of the field into which the argument is inserted and whether it is right-aligned (a positive integer) or left-aligned (a negative integer). If you omit `width`, the string representation of the corresponding argument is inserted in a field with no leading or trailing spaces.

If the value of `width` is less than the length of the argument to be inserted, `width` is ignored and the length of the string representation of the argument is used as the field width.

`formatString`\
Optional. A string that specifies the format of the corresponding argument's result string. If you omit `formatString`, the corresponding argument's parameterless `ToString` method is called to produce its string representation. If you specify `formatString`, the argument referenced by the format item must implement the <xref:System.IFormattable> interface. Types that support format strings include:

- All integral and floating-point types. (See [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).)

- <xref:System.DateTime> and <xref:System.DateTimeOffset>. (See [Standard Date and Time Format Strings](../../standard/base-types/standard-date-and-time-format-strings.md) and [Custom Date and Time Format Strings](../../standard/base-types/custom-date-and-time-format-strings.md).)

- All enumeration types. (See [Enumeration Format Strings](../../standard/base-types/enumeration-format-strings.md).)

- <xref:System.TimeSpan> values. (See [Standard TimeSpan Format Strings](../../standard/base-types/standard-timespan-format-strings.md) and [Custom TimeSpan Format Strings](../../standard/base-types/custom-timespan-format-strings.md).)

- GUIDs. (See the <xref:System.Guid.ToString(System.String)?displayProperty=nameWithType> method.)

However, any custom type can implement <xref:System.IFormattable> or extend an existing type's <xref:System.IFormattable> implementation.

The following example uses the `width` and `formatString` arguments to produce formatted output.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/formatoverload2.cs" interactive="try-dotnet-method" id="Snippet9":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/formatoverload2.fs" id="Snippet9":::
:::code language="vb" source="./snippets/System/String/Format/vb/formatoverload2.vb" id="Snippet9":::

## How arguments are formatted

Format items are processed sequentially from the beginning of the string. Each format item has an index that corresponds to an object in the method's argument list. The <xref:System.String.Format%2A> method retrieves the argument and derives its string representation as follows:

- If the argument is `null`, the method inserts <xref:System.String.Empty?displayProperty=nameWithType> into the result string. You don't have to be concerned with handling a <xref:System.NullReferenceException> for null arguments.

- If you call the <xref:System.String.Format(System.IFormatProvider,System.String,System.Object%5B%5D)> overload and the `provider` object's <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation returns a non-null <xref:System.ICustomFormatter> implementation, the argument is passed to its <xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)?displayProperty=nameWithType> method. If the format item includes a `formatString` argument, it is passed as the first argument to the method. If the <xref:System.ICustomFormatter> implementation is available and produces a non-null string, that string is returned as the string representation of the argument; otherwise, the next step executes.

- If the argument implements the <xref:System.IFormattable> interface, its <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation is called.

- The argument's parameterless `ToString` method, which either overrides or inherits from a base class implementation, is called.

For an example that intercepts calls to the <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> method and allows you to see what information the <xref:System.String.Format%2A> method passes to a formatting method for each format item in a composite format string, see [Example: An intercept provider and Roman numeral formatter](#example-an-intercept-provider-and-roman-numeral-formatter).

For more information, see [Processing order](../../standard/base-types/composite-formatting.md#processing-order).

## Format items that have the same index

The <xref:System.String.Format%2A> method throws a <xref:System.FormatException> exception if the index of an index item is greater than or equal to the number of arguments in the argument list. However, `format` can include more format items than there are arguments, as long as multiple format items have the same index. In the call to the <xref:System.String.Format(System.String,System.Object)> method in following example, the argument list has a single argument, but the format string includes two format items: one displays the decimal value of a number, and the other displays its hexadecimal value.

:::code language="csharp" source="./snippets/System/String/Format/csharp/Example1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/Format/fsharp/Example1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/Format/vb/Example1.vb" id="Snippet1":::

## Format and culture

Generally, objects in the argument list are converted to their string representations by using the conventions of the current culture, which is returned by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property. You can control this behavior by calling one of the overloads of <xref:System.String.Format%2A> that includes a `provider` parameter. The `provider` parameter is an <xref:System.IFormatProvider> implementation that supplies custom and culture-specific formatting information that is used to moderate the formatting process.

The <xref:System.IFormatProvider> interface has a single member, <xref:System.IFormatProvider.GetFormat%2A>, which is responsible for returning the object that provides formatting information. .NET has three <xref:System.IFormatProvider> implementations that provide culture-specific formatting:

- <xref:System.Globalization.CultureInfo>. Its <xref:System.Globalization.CultureInfo.GetFormat%2A> method returns a culture-specific <xref:System.Globalization.NumberFormatInfo> object for formatting numeric values and a culture-specific <xref:System.Globalization.DateTimeFormatInfo> object for formatting date and time values.
- <xref:System.Globalization.DateTimeFormatInfo>, which is used for culture-specific formatting of date and time values. Its <xref:System.Globalization.DateTimeFormatInfo.GetFormat%2A> method returns itself.
- <xref:System.Globalization.NumberFormatInfo>, which is used for culture-specific formatting of numeric values. Its <xref:System.Globalization.NumberFormatInfo.GetFormat(System.Type)> method returns itself.

## Custom formatting operations

You can also call the any of the overloads of the <xref:System.String.Format%2A> method that have a `provider` parameter of type <xref:System.IFormatProvider> to perform custom formatting operations. For example, you could format an integer as an identification number or as a telephone number. To perform custom formatting, your `provider` argument must implement both the <xref:System.IFormatProvider> and <xref:System.ICustomFormatter> interfaces. When the <xref:System.String.Format%2A> method is passed an <xref:System.ICustomFormatter> implementation as the `provider` argument, the <xref:System.String.Format%2A> method calls its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation and requests an object of type <xref:System.ICustomFormatter>. It then calls the returned <xref:System.ICustomFormatter> object's <xref:System.ICustomFormatter.Format%2A> method to format each format item in the composite string passed to it.

For more information about providing custom formatting solutions, see [How to: Define and Use Custom Numeric Format Providers](../../standard/base-types/how-to-define-and-use-custom-numeric-format-providers.md) and <xref:System.ICustomFormatter>. For an example that converts integers to formatted custom numbers, see [Example: A custom formatting operation](#example-a-custom-formatting-operation). For an example that converts unsigned bytes to Roman numerals, see [Example: An intercept provider and Roman numeral formatter](#example-an-intercept-provider-and-roman-numeral-formatter).

### Example: A custom formatting operation

This example defines a format provider that formats an integer value as a customer account number in the form x-xxxxx-xx.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/FormatExample2.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/FormatExample2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/String/Format/vb/FormatExample2.vb" id="Snippet2":::

### Example: An intercept provider and Roman numeral formatter

This example defines a custom format provider that implements the <xref:System.ICustomFormatter> and <xref:System.IFormatProvider> interfaces to do two things:

- It displays the parameters passed to its <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> implementation. This enables us to see what parameters the <xref:System.String.Format(System.IFormatProvider,System.String,System.Object%5B%5D)> method is passing to the custom formatting implementation for each object that it tries to format. This can be useful when you're debugging your application.
- If the object to be formatted is an unsigned byte value that is to be formatted by using the "R" standard format string, the custom formatter formats the numeric value as a Roman numeral.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/interceptor2.cs" id="Snippet11":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/interceptor2.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System/String/Format/vb/interceptor2.vb" id="Snippet11":::

## FAQ

### Why do you recommend string interpolation over calls to the `String.Format` method?

String interpolation is:

- More flexible. It can be used in any string without requiring a call to a method that supports composite formatting. Otherwise, you have to call the <xref:System.String.Format%2A> method or another method that supports composite formatting, such as <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> or <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>.
- More readable. Because the expression to insert into a string appears in the interpolated expression rather than in a argument list, interpolated strings are easier to code and to read. Interpolated strings can also be used in string concatenation operations to produce more concise, clearer code.

A comparison of the following two code examples illustrates the superiority of interpolated strings over string concatenation and calls to composite formatting methods. The use of multiple string concatenation operations in the following example produces verbose and hard-to-read code.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa-interpolated1.cs" id="SnippetQAInterpolated":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa-interpolated1.fs" id="SnippetQAInterpolated":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa-interpolated1.vb":::

In contrast, the use of interpolated strings in the following example produces much clearer, more concise code than the string concatenation statement and the call to the <xref:System.String.Format%2A> method in the previous example.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa-interpolated2.cs" id="SnippetQAInterpolated2":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa-interpolated2.fs" id="SnippetQAInterpolated2":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa-interpolated2.vb":::

### Where can I find the predefined format strings?

- For all integral and floating-point types, see [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).
- For date and time values, see [Standard Date and Time Format Strings](../../standard/base-types/standard-date-and-time-format-strings.md) and [Custom Date and Time Format Strings](../../standard/base-types/custom-date-and-time-format-strings.md).
- For enumeration values, see [Enumeration Format Strings](../../standard/base-types/enumeration-format-strings.md).
- For <xref:System.TimeSpan> values, see [Standard TimeSpan Format Strings](../../standard/base-types/standard-timespan-format-strings.md) and [Custom TimeSpan Format Strings](../../standard/base-types/custom-timespan-format-strings.md).
- For <xref:System.Guid> values, see the Remarks section of the <xref:System.Guid.ToString(System.String)?displayProperty=nameWithType> reference page.

### How do I control the alignment of the result strings that replace format items?

The general syntax of a format item is:

```txt
{index[,width][: formatString]}
```

`width` is a signed integer that defines the field width. If this value is negative, text in the field is left-aligned. If it is positive, text is right-aligned.

### How do I control the number of digits after the decimal separator?

All [standard numeric format strings](../../standard/base-types/standard-numeric-format-strings.md) except "D" (which is used with integers only), "G", "R", and "X" allow a precision specifier that defines the number of decimal digits in the result string. The following example uses standard numeric format strings to control the number of decimal digits in the result string.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa26.cs" id="Snippet26":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa26.fs" id="Snippet26":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa26.vb" id="Snippet26":::

If you're using a [custom numeric format string](../../standard/base-types/custom-numeric-format-strings.md), use the "0" format specifier to control the number of decimal digits in the result string, as the following example shows.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa27.cs" interactive="try-dotnet-method" id="Snippet27":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa27.fs" id="Snippet27":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa27.vb" id="Snippet27":::

### How do I control the number of integral digits?

By default, formatting operations only display non-zero integral digits. If you're formatting integers, you can use a precision specifier with the "D" and "X" standard format strings to control the number of digits.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa29.cs" interactive="try-dotnet-method" id="Snippet29":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa29.fs" id="Snippet29":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa29.vb" id="Snippet29":::

You can pad an integer or floating-point number with leading zeros to produce a result string with a specified number of integral digits by using the "0" [custom numeric format specifier](../../standard/base-types/custom-numeric-format-strings.md), as the following example shows.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa28.cs" interactive="try-dotnet-method" id="Snippet28":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa28.fs" id="Snippet28":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa28.vb" id="Snippet28":::

### How many items can I include in the format list?

There is no practical limit. The second parameter of the <xref:System.String.Format(System.IFormatProvider,System.String,System.Object%5B%5D)> method is tagged with the <xref:System.ParamArrayAttribute> attribute, which allows you to include either a delimited list or an object array as your format list.

### How do I include literal braces ("{" and "}") in the result string?

For example, how do you prevent the following method call from throwing a <xref:System.FormatException> exception?

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa3.cs" id="Snippet23":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa3.fs" id="Snippet23":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa3.vb" id="Snippet23":::

A single opening or closing brace is always interpreted as the beginning or end of a format item. To be interpreted literally, it must be escaped. You escape a brace by adding another brace ("{{" and "}}" instead of "{" and "}"), as in the following method call:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa3.cs" interactive="try-dotnet-method" id="Snippet24":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa3.fs" id="Snippet24":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa3.vb" id="Snippet24":::

However, even escaped braces are easily misinterpreted. We recommend that you include braces in the format list and use format items to insert them in the result string, as the following example shows.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa3.cs" interactive="try-dotnet-method" id="Snippet25":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa3.fs" id="Snippet25":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa3.vb" id="Snippet25":::

### Why does my call to the String.Format method throw a FormatException?

The most common cause of the exception is that the index of a format item doesn't correspond to an object in the format list. Usually this indicates that you've misnumbered the indexes of format items or you've forgotten to include an object in the format list. Attempting to include an unescaped left or right brace character also throws a <xref:System.FormatException>. Occasionally, the exception is the result of a typo; for example, a typical mistake is to mistype "[" (the left bracket) instead of "{" (the left brace).

### If the Format(System.IFormatProvider,System.String,System.Object[]) method supports parameter arrays, why does my code throw an exception when I use an array?

For example, the following code throws a <xref:System.FormatException> exception:

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa11.cs" id="Snippet21":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa11.fs" id="Snippet21":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa1.vb" id="Snippet21":::

This is a problem of compiler overload resolution. Because the compiler cannot convert an array of integers to an object array, it treats the integer array as a single argument, so it calls the <xref:System.String.Format(System.String,System.Object)> method. The exception is thrown because there are four format items but only a single item in the format list.

Because neither Visual Basic nor C# can convert an integer array to an object array, you have to perform the conversion yourself before calling the <xref:System.String.Format(System.String,System.Object%5B%5D)> method. The following example provides one implementation.

:::code language="csharp" source="./snippets/System/FormatException/Overview/csharp/qa21.cs" interactive="try-dotnet-method" id="Snippet22":::
:::code language="fsharp" source="./snippets/System/FormatException/Overview/fsharp/qa21.fs" id="Snippet22":::
:::code language="vb" source="./snippets/System/String/Format/vb/qa2.vb" id="Snippet22":::
