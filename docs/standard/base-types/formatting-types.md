---
title: "Formatting types in .NET"
description: Learn how to format types in .NET. Understand how to use or override the ToString method. Learn about culture-sensitive, composite, and custom formatting.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "data formatting [.NET]"
  - "dates [.NET], formatting"
  - "date formatting [.NET]"
  - "number formatting [.NET]"
  - "ToString method"
  - "custom cultural settings [.NET]"
  - "numbers [.NET], formatting"
  - "formatting strings [.NET]"
  - "time [.NET], formatting"
  - "currency [.NET], formatting"
  - "types [.NET], formatting"
  - "format specifiers [.NET]"
  - "times [.NET], formatting"
  - "culture [.NET], formatting"
  - "formatting [.NET], types supported"
  - "base types [.NET], formatting"
  - "custom formatting [.NET]"
  - "strings [.NET], formatting"
ms.assetid: 0d1364da-5b30-4d42-8e6b-03378343343f
---
# Format types in .NET

Formatting is the process of converting an instance of a class, structure, or enumeration value to its string representation, often so that the resulting string can be displayed to users or deserialized to restore the original data type. This conversion can pose a number of challenges:

- The way that values are stored internally does not necessarily reflect the way that users want to view them. For example, a telephone number might be stored in the form 8009999999, which is not user-friendly. It should instead be displayed as 800-999-9999. See the [Custom Format Strings](#custom-format-strings) section for an example that formats a number in this way.

- Sometimes the conversion of an object to its string representation is not intuitive. For example, it is not clear how the string representation of a Temperature object or a Person object should appear. For an example that formats a Temperature object in a variety of ways, see the [Standard Format Strings](#standard-format-strings) section.

- Values often require culture-sensitive formatting. For example, in an application that uses numbers to reflect monetary values, numeric strings should include the current culture's currency symbol, group separator (which, in most cultures, is the thousands separator), and decimal symbol. For an example, see the [Culture-sensitive formatting with format providers](#culture-sensitive-formatting-with-format-providers) section.

- An application may have to display the same value in different ways. For example, an application may represent an enumeration member by displaying a string representation of its name or by displaying its underlying value. For an example that formats a member of the <xref:System.DayOfWeek> enumeration in different ways, see the [Standard Format Strings](#standard-format-strings) section.

> [!NOTE]
> Formatting converts the value of a type into a string representation. Parsing is the inverse of formatting. A parsing operation creates an instance of a data type from its string representation. For information about converting strings to other data types, see [Parsing Strings](parsing-strings.md).

.NET provides rich formatting support that enables developers to address these requirements.

## Formatting in .NET

The basic mechanism for formatting is the default implementation of the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method, which is discussed in the [Default Formatting Using the ToString Method](#default-formatting-using-the-tostring-method) section later in this topic. However, .NET provides several ways to modify and extend its default formatting support. These include the following:

- Overriding the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to define a custom string representation of an object's value. For more information, see the [Override the ToString Method](#override-the-tostring-method) section later in this topic.

- Defining format specifiers that enable the string representation of an object's value to take multiple forms. For example, the "X" format specifier in the following statement converts an integer to the string representation of a hexadecimal value.

     [!code-csharp[Conceptual.Formatting.Overview#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/specifier1.cs#3)]
     [!code-vb[Conceptual.Formatting.Overview#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/specifier1.vb#3)]

     For more information about format specifiers, see the [ToString Method and Format Strings](#the-tostring-method-and-format-strings) section.

- Using format providers to take advantage of the formatting conventions of a specific culture. For example, the following statement displays a currency value by using the formatting conventions of the en-US culture.

     [!code-csharp[Conceptual.Formatting.Overview#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/specifier1.cs#10)]
     [!code-vb[Conceptual.Formatting.Overview#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/specifier1.vb#10)]

     For more information about formatting with format providers, see the [Format Providers](#culture-sensitive-formatting-with-format-providers) section.

- Implementing the <xref:System.IFormattable> interface to support both string conversion with the <xref:System.Convert> class and composite formatting. For more information, see the [IFormattable Interface](#the-iformattable-interface) section.

- Using composite formatting to embed the string representation of a value in a larger string. For more information, see the [Composite Formatting](#composite-formatting) section.

- Implementing <xref:System.ICustomFormatter> and <xref:System.IFormatProvider> to provide a complete custom formatting solution. For more information, see the [Custom Formatting with ICustomFormatter](#custom-formatting-with-icustomformatter) section.

The following sections examine these methods for converting an object to its string representation.

## Default formatting using the ToString method

Every type that is derived from <xref:System.Object?displayProperty=nameWithType> automatically inherits a parameterless `ToString` method, which returns the name of the type by default. The following example illustrates the default `ToString` method. It defines a class named `Automobile` that has no implementation. When the class is instantiated and its `ToString` method is called, it displays its type name. Note that the `ToString` method is not explicitly called in the example. The <xref:System.Console.WriteLine%28System.Object%29?displayProperty=nameWithType> method implicitly calls the `ToString` method of the object passed to it as an argument.

[!code-csharp[Conceptual.Formatting.Overview#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/default1.cs#1)]
[!code-vb[Conceptual.Formatting.Overview#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/default1.vb#1)]

> [!WARNING]
> Starting with Windows 8.1, the Windows Runtime includes an <xref:Windows.Foundation.IStringable> interface with a single method, [IStringable.ToString](xref:Windows.Foundation.IStringable.ToString%2A), which provides default formatting support. However, we recommend that managed types do not implement the `IStringable` interface. For more information, see "The Windows Runtime and the `IStringable` Interface" section on the <xref:System.Object.ToString%2A?displayProperty=nameWithType> reference page.

Because all types other than interfaces are derived from <xref:System.Object>, this functionality is automatically provided to your custom classes or structures. However, the functionality offered by the default `ToString` method, is limited: Although it identifies the type, it fails to provide any information about an instance of the type. To provide a string representation of an object that provides information about that object, you must override the `ToString` method.

> [!NOTE]
> Structures inherit from <xref:System.ValueType>, which in turn is derived from <xref:System.Object>. Although <xref:System.ValueType> overrides <xref:System.Object.ToString%2A?displayProperty=nameWithType>, its implementation is identical.

## Override the ToString method

Displaying the name of a type is often of limited use and does not allow consumers of your types to differentiate one instance from another. However, you can override the `ToString` method to provide a more useful representation of an object's value. The following example defines a `Temperature` object and overrides its `ToString` method to display the temperature in degrees Celsius.

[!code-csharp[Conceptual.Formatting.Overview#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/overrides1.cs#2)]
[!code-vb[Conceptual.Formatting.Overview#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/overrides1.vb#2)]

In .NET, the `ToString` method of each primitive value type has been overridden to display the object's value instead of its name. The following table shows the override for each primitive type. Note that most of the overridden methods call another overload of the `ToString` method and pass it the "G" format specifier, which defines the general format for its type, and an <xref:System.IFormatProvider> object that represents the current culture.

|Type|ToString override|
|----------|-----------------------|
|<xref:System.Boolean>|Returns either <xref:System.Boolean.TrueString?displayProperty=nameWithType> or <xref:System.Boolean.FalseString?displayProperty=nameWithType>.|
|<xref:System.Byte>|Calls `Byte.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Byte> value for the current culture.|
|<xref:System.Char>|Returns the character as a string.|
|<xref:System.DateTime>|Calls `DateTime.ToString("G", DatetimeFormatInfo.CurrentInfo)` to format the date and time value for the current culture.|
|<xref:System.Decimal>|Calls `Decimal.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Decimal> value for the current culture.|
|<xref:System.Double>|Calls `Double.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Double> value for the current culture.|
|<xref:System.Int16>|Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Int16> value for the current culture.|
|<xref:System.Int32>|Calls `Int32.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Int32> value for the current culture.|
|<xref:System.Int64>|Calls `Int64.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Int64> value for the current culture.|
|<xref:System.SByte>|Calls `SByte.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.SByte> value for the current culture.|
|<xref:System.Single>|Calls `Single.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.Single> value for the current culture.|
|<xref:System.UInt16>|Calls `UInt16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.UInt16> value for the current culture.|
|<xref:System.UInt32>|Calls `UInt32.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.UInt32> value for the current culture.|
|<xref:System.UInt64>|Calls `UInt64.ToString("G", NumberFormatInfo.CurrentInfo)` to format the <xref:System.UInt64> value for the current culture.|

## The ToString method and format strings

Relying on the default `ToString` method or overriding `ToString` is appropriate when an object has a single string representation. However, the value of an object often has multiple representations. For example, a temperature can be expressed in degrees Fahrenheit, degrees Celsius, or kelvins. Similarly, the integer value 10 can be represented in numerous ways, including 10, 10.0, 1.0e01, or $10.00.

To enable a single value to have multiple string representations, .NET uses format strings. A format string is a string that contains one or more predefined format specifiers, which are single characters or groups of characters that define how the `ToString` method should format its output. The format string is then passed as a parameter to the object's `ToString` method and determines how the string representation of that object's value should appear.

All numeric types, date and time types, and enumeration types in .NET support a predefined set of format specifiers. You can also use format strings to define multiple string representations of your application-defined data types.

### Standard format strings

A standard format string contains a single format specifier, which is an alphabetic character that defines the string representation of the object to which it is applied, along with an optional precision specifier that affects how many digits are displayed in the result string. If the precision specifier is omitted or is not supported, a standard format specifier is equivalent to a standard format string.

.NET defines a set of standard format specifiers for all numeric types, all date and time types, and all enumeration types. For example, each of these categories supports a "G" standard format specifier, which defines a general string representation of a value of that type.

Standard format strings for enumeration types directly control the string representation of a value. The format strings passed to an enumeration value's `ToString` method determine whether the value is displayed using its string name (the "G" and "F" format specifiers), its underlying integral value (the "D" format specifier), or its hexadecimal value (the "X" format specifier). The following example illustrates the use of standard format strings to format a <xref:System.DayOfWeek> enumeration value.

[!code-csharp[Conceptual.Formatting.Overview#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/standard1.cs#4)]
[!code-vb[Conceptual.Formatting.Overview#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/standard1.vb#4)]

For information about enumeration format strings, see [Enumeration Format Strings](enumeration-format-strings.md).

Standard format strings for numeric types usually define a result string whose precise appearance is controlled by one or more property values. For example, the "C" format specifier formats a number as a currency value. When you call the `ToString` method with the "C" format specifier as the only parameter, the following property values from the current culture's <xref:System.Globalization.NumberFormatInfo> object are used to define the string representation of the numeric value:

- The <xref:System.Globalization.NumberFormatInfo.CurrencySymbol%2A> property, which specifies the current culture's currency symbol.

- The <xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern%2A> or <xref:System.Globalization.NumberFormatInfo.CurrencyPositivePattern%2A> property, which returns an integer that determines the following:

  - The placement of the currency symbol.

  - Whether negative values are indicated by a leading negative sign, a trailing negative sign, or parentheses.

  - Whether a space appears between the numeric value and the currency symbol.

- The <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A> property, which defines the number of fractional digits in the result string.

- The <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator%2A> property, which defines the decimal separator symbol in the result string.

- The <xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator%2A> property, which defines the group separator symbol.

- The <xref:System.Globalization.NumberFormatInfo.CurrencyGroupSizes%2A> property, which defines the number of digits in each group to the left of the decimal.

- The <xref:System.Globalization.NumberFormatInfo.NegativeSign%2A> property, which determines the negative sign used in the result string if parentheses are not used to indicate negative values.

In addition, numeric format strings may include a precision specifier. The meaning of this specifier depends on the format string with which it is used, but it typically indicates either the total number of digits or the number of fractional digits that should appear in the result string. For example, the following example uses the "X4" standard numeric string and a precision specifier to create a string value that has four hexadecimal digits.

[!code-csharp[Conceptual.Formatting.Overview#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/precisionspecifier1.cs#6)]
[!code-vb[Conceptual.Formatting.Overview#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/precisionspecifier1.vb#6)]

For more information about standard numeric formatting strings, see [Standard Numeric Format Strings](standard-numeric-format-strings.md).

Standard format strings for date and time values are aliases for custom format strings stored by a particular <xref:System.Globalization.DateTimeFormatInfo> property. For example, calling the `ToString` method of a date and time value with the "D" format specifier displays the date and time by using the custom format string stored in the current culture's <xref:System.Globalization.DateTimeFormatInfo.LongDatePattern%2A?displayProperty=nameWithType> property. (For more information about custom format strings, see the [next section](#custom-format-strings).) The following example illustrates this relationship.

[!code-csharp[Conceptual.Formatting.Overview#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/alias1.cs#5)]
[!code-vb[Conceptual.Formatting.Overview#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/alias1.vb#5)]

For more information about standard date and time format strings, see [Standard Date and Time Format Strings](standard-date-and-time-format-strings.md).

You can also use standard format strings to define the string representation of an application-defined object that is produced by the object's `ToString(String)` method. You can define the specific standard format specifiers that your object supports, and you can determine whether they are case-sensitive or case-insensitive. Your implementation of the `ToString(String)` method should support the following:

- A "G" format specifier that represents a customary or common format of the object. The parameterless overload of your object's `ToString` method should call its `ToString(String)` overload and pass it the "G" standard format string.

- Support for a format specifier that is equal to a null reference (`Nothing` in Visual Basic). A format specifier that is equal to a null reference should be considered equivalent to the "G" format specifier.

For example, a `Temperature` class can internally store the temperature in degrees Celsius and use format specifiers to represent the value of the `Temperature` object in degrees Celsius, degrees Fahrenheit, and kelvins. The following example provides an illustration.

[!code-csharp[Conceptual.Formatting.Overview#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/appstandard1.cs#7)]
[!code-vb[Conceptual.Formatting.Overview#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/appstandard1.vb#7)]

### Custom format strings

In addition to the standard format strings, .NET defines custom format strings for both numeric values and date and time values. A custom format string consists of one or more custom format specifiers that define the string representation of a value. For example, the custom date and time format string "yyyy/mm/dd hh:mm:ss.ffff t zzz" converts a date to its string representation in the form "2008/11/15 07:45:00.0000 P -08:00" for the en-US culture. Similarly, the custom format string "0000" converts the integer value 12 to "0012". For a complete list of custom format strings, see [Custom Date and Time Format Strings](custom-date-and-time-format-strings.md) and [Custom Numeric Format Strings](custom-numeric-format-strings.md).

If a format string consists of a single custom format specifier, the format specifier should be preceded by the percent (%) symbol to avoid confusion with a standard format specifier. The following example uses the "M" custom format specifier to display a one-digit or two-digit number of the month of a particular date.

[!code-csharp[Conceptual.Formatting.Overview#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/singlecustom1.cs#8)]
[!code-vb[Conceptual.Formatting.Overview#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/singlecustom1.vb#8)]

Many standard format strings for date and time values are aliases for custom format strings that are defined by properties of the <xref:System.Globalization.DateTimeFormatInfo> object. Custom format strings also offer considerable flexibility in providing application-defined formatting for numeric values or date and time values. You can define your own custom result strings for both numeric values and date and time values by combining multiple custom format specifiers into a single custom format string. The following example defines a custom format string that displays the day of the week in parentheses after the month name, day, and year.

[!code-csharp[Conceptual.Formatting.Overview#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/custom1.cs#9)]
[!code-vb[Conceptual.Formatting.Overview#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/custom1.vb#9)]

The following example defines a custom format string that displays an <xref:System.Int64> value as a standard, seven-digit U.S. telephone number along with its area code.

[!code-csharp[Conceptual.Formatting.Overview#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/telnumber1.cs#21)]
[!code-vb[Conceptual.Formatting.Overview#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/telnumber1.vb#21)]

Although standard format strings can generally handle most of the formatting needs for your application-defined types, you may also define custom format specifiers to format your types.

### Format strings and .NET types

All numeric types (that is, the <xref:System.Byte>, <xref:System.Decimal>, <xref:System.Double>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.Single>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>, and <xref:System.Numerics.BigInteger> types), as well as the <xref:System.DateTime>, <xref:System.DateTimeOffset>, <xref:System.TimeSpan>, <xref:System.Guid>, and all enumeration types, support formatting with format strings. For information on the specific format strings supported by each type, see the following topics:

|Title|Definition|
|-----------|----------------|
|[Standard Numeric Format Strings](standard-numeric-format-strings.md)|Describes standard format strings that create commonly used string representations of numeric values.|
|[Custom Numeric Format Strings](custom-numeric-format-strings.md)|Describes custom format strings that create application-specific formats for numeric values.|
|[Standard Date and Time Format Strings](standard-date-and-time-format-strings.md)|Describes standard format strings that create commonly used string representations of <xref:System.DateTime> and <xref:System.DateTimeOffset> values.|
|[Custom Date and Time Format Strings](custom-date-and-time-format-strings.md)|Describes custom format strings that create application-specific formats for <xref:System.DateTime> and <xref:System.DateTimeOffset> values.|
|[Standard TimeSpan Format Strings](standard-timespan-format-strings.md)|Describes standard format strings that create commonly used string representations of time intervals.|
|[Custom TimeSpan Format Strings](custom-timespan-format-strings.md)|Describes custom format strings that create application-specific formats for time intervals.|
|[Enumeration Format Strings](enumeration-format-strings.md)|Describes standard format strings that are used to create string representations of enumeration values.|
|<xref:System.Guid.ToString%28System.String%29?displayProperty=nameWithType>|Describes standard format strings for <xref:System.Guid> values.|

## Culture-sensitive formatting with format providers

Although format specifiers let you customize the formatting of objects, producing a meaningful string representation of objects often requires additional formatting information. For example, formatting a number as a currency value by using either the "C" standard format string or a custom format string such as "$ #,#.00" requires, at a minimum, information about the correct currency symbol, group separator, and decimal separator to be available to include in the formatted string. In .NET, this additional formatting information is made available through the <xref:System.IFormatProvider> interface, which is provided as a parameter to one or more overloads of the `ToString` method of numeric types and date and time types. <xref:System.IFormatProvider> implementations are used in .NET to support culture-specific formatting. The following example illustrates how the string representation of an object changes when it is formatted with three <xref:System.IFormatProvider> objects that represent different cultures.

[!code-csharp[Conceptual.Formatting.Overview#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/iformatprovider1.cs#11)]
[!code-vb[Conceptual.Formatting.Overview#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/iformatprovider1.vb#11)]

The <xref:System.IFormatProvider> interface includes one method, <xref:System.IFormatProvider.GetFormat%28System.Type%29>, which has a single parameter that specifies the type of object that provides formatting information. If the method can provide an object of that type, it returns it. Otherwise, it returns a null reference (`Nothing` in Visual Basic).

<xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> is a callback method. When you call a `ToString` method overload that includes an <xref:System.IFormatProvider> parameter, it calls the <xref:System.IFormatProvider.GetFormat%2A> method of that <xref:System.IFormatProvider> object. The <xref:System.IFormatProvider.GetFormat%2A> method is responsible for returning an object that provides the necessary formatting information, as specified by its `formatType` parameter, to the `ToString` method.

A number of formatting or string conversion methods include a parameter of type <xref:System.IFormatProvider>, but in many cases the value of the parameter is ignored when the method is called. The following table lists some of the formatting methods that use the parameter and the type of the <xref:System.Type> object that they pass to the <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method.

|Method|Type of `formatType` parameter|
|------------|------------------------------------|
|`ToString` method of numeric types|<xref:System.Globalization.NumberFormatInfo?displayProperty=nameWithType>|
|`ToString` method of date and time types|<xref:System.Globalization.DateTimeFormatInfo?displayProperty=nameWithType>|
|<xref:System.String.Format%2A?displayProperty=nameWithType>|<xref:System.ICustomFormatter?displayProperty=nameWithType>|
|<xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>|<xref:System.ICustomFormatter?displayProperty=nameWithType>|

> [!NOTE]
> The `ToString` methods of the numeric types and date and time types are overloaded, and only some of the overloads include an <xref:System.IFormatProvider> parameter. If a method does not have a parameter of type <xref:System.IFormatProvider>, the object that is returned by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property is passed instead. For example, a call to the default <xref:System.Int32.ToString?displayProperty=nameWithType> method ultimately results in a method call such as the following: `Int32.ToString("G", System.Globalization.CultureInfo.CurrentCulture)`.

.NET provides three classes that implement <xref:System.IFormatProvider>:

- <xref:System.Globalization.DateTimeFormatInfo>, a class that provides formatting information for date and time values for a specific culture. Its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation returns an instance of itself.

- <xref:System.Globalization.NumberFormatInfo>, a class that provides numeric formatting information for a specific culture. Its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation returns an instance of itself.

- <xref:System.Globalization.CultureInfo>. Its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation can return either a <xref:System.Globalization.NumberFormatInfo> object to provide numeric formatting information or a <xref:System.Globalization.DateTimeFormatInfo> object to provide formatting information for date and time values.

You can also implement your own format provider to replace any one of these classes. However, your implementation's <xref:System.IFormatProvider.GetFormat%2A> method must return an object of the type listed in the previous table if it has to provide formatting information to the `ToString` method.

### Culture-sensitive formatting of numeric values

By default, the formatting of numeric values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current culture are used. This is illustrated in the following example, which changes the current culture four times and then calls the <xref:System.Decimal.ToString%28System.String%29?displayProperty=nameWithType> method. In each case, the result string reflects the formatting conventions of the current culture. This is because the `ToString` and `ToString(String)` methods wrap calls to each numeric type's `ToString(String, IFormatProvider)` method.

[!code-csharp[Conceptual.Formatting.Overview#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/culturespecific3.cs#19)]
[!code-vb[Conceptual.Formatting.Overview#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/culturespecific3.vb#19)]

You can also format a numeric value for a specific culture by calling a `ToString` overload that has a `provider` parameter and passing it either of the following:

- A <xref:System.Globalization.CultureInfo> object that represents the culture whose formatting conventions are to be used. Its <xref:System.Globalization.CultureInfo.GetFormat%2A?displayProperty=nameWithType> method returns the value of the <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType> property, which is the <xref:System.Globalization.NumberFormatInfo> object that provides culture-specific formatting information for numeric values.

- A <xref:System.Globalization.NumberFormatInfo> object that defines the culture-specific formatting conventions to be used. Its <xref:System.Globalization.NumberFormatInfo.GetFormat%2A> method returns an instance of itself.

The following example uses <xref:System.Globalization.NumberFormatInfo> objects that represent the English (United States) and English (Great Britain) cultures and the French and Russian neutral cultures to format a floating-point number.

[!code-csharp[Conceptual.Formatting.Overview#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/culturespecific4.cs#20)]
[!code-vb[Conceptual.Formatting.Overview#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/culturespecific4.vb#20)]

### Culture-sensitive formatting of date and time values

By default, the formatting of date and time values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current culture are used. This is illustrated in the following example, which changes the current culture four times and then calls the <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> method. In each case, the result string reflects the formatting conventions of the current culture. This is because the <xref:System.DateTime.ToString?displayProperty=nameWithType>, <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType>, <xref:System.DateTimeOffset.ToString?displayProperty=nameWithType>, and <xref:System.DateTimeOffset.ToString%28System.String%29?displayProperty=nameWithType> methods wrap calls to the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> and <xref:System.DateTimeOffset.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods.

[!code-csharp[Conceptual.Formatting.Overview#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/culturespecific1.cs#17)]
[!code-vb[Conceptual.Formatting.Overview#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/culturespecific1.vb#17)]

You can also format a date and time value for a specific culture by calling a <xref:System.DateTime.ToString%2A?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%2A?displayProperty=nameWithType> overload that has a `provider` parameter and passing it either of the following:

- A <xref:System.Globalization.CultureInfo> object that represents the culture whose formatting conventions are to be used. Its <xref:System.Globalization.CultureInfo.GetFormat%2A?displayProperty=nameWithType> method returns the value of the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property, which is the <xref:System.Globalization.DateTimeFormatInfo> object that provides culture-specific formatting information for date and time values.

- A <xref:System.Globalization.DateTimeFormatInfo> object that defines the culture-specific formatting conventions to be used. Its <xref:System.Globalization.DateTimeFormatInfo.GetFormat%2A> method returns an instance of itself.

The following example uses <xref:System.Globalization.DateTimeFormatInfo> objects that represent the English (United States) and English (Great Britain) cultures and the French and Russian neutral cultures to format a date.

[!code-csharp[Conceptual.Formatting.Overview#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/culturespecific2.cs#18)]
[!code-vb[Conceptual.Formatting.Overview#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/culturespecific2.vb#18)]

## The IFormattable interface

Typically, types that overload the `ToString` method with a format string and an <xref:System.IFormatProvider> parameter also implement the <xref:System.IFormattable> interface. This interface has a single member, <xref:System.IFormattable.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType>, that includes both a format string and a format provider as parameters.

Implementing the <xref:System.IFormattable> interface for your application-defined class offers two advantages:

- Support for string conversion by the <xref:System.Convert> class. Calls to the <xref:System.Convert.ToString%28System.Object%29?displayProperty=nameWithType> and <xref:System.Convert.ToString%28System.Object%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods call your <xref:System.IFormattable> implementation automatically.

- Support for composite formatting. If a format item that includes a format string is used to format your custom type, the common language runtime automatically calls your <xref:System.IFormattable> implementation and passes it the format string. For more information about composite formatting with methods such as <xref:System.String.Format%2A?displayProperty=nameWithType> or <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, see the [Composite Formatting](#composite-formatting) section.

The following example defines a `Temperature` class that implements the <xref:System.IFormattable> interface. It supports the "C" or "G" format specifiers to display the temperature in Celsius, the "F" format specifier to display the temperature in Fahrenheit, and the "K" format specifier to display the temperature in Kelvin.

[!code-csharp[Conceptual.Formatting.Overview#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/iformattable.cs#12)]
[!code-vb[Conceptual.Formatting.Overview#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/iformattable.vb#12)]

The following example instantiates a `Temperature` object. It then calls the <xref:System.Convert.ToString%2A> method and uses several composite format strings to obtain different string representations of a `Temperature` object. Each of these method calls, in turn, calls the <xref:System.IFormattable> implementation of the `Temperature` class.

[!code-csharp[Conceptual.Formatting.Overview#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/iformattable.cs#13)]
[!code-vb[Conceptual.Formatting.Overview#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/iformattable.vb#13)]

## Composite formatting

Some methods, such as <xref:System.String.Format%2A?displayProperty=nameWithType> and <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>, support composite formatting. A composite format string is a kind of template that returns a single string that incorporates the string representation of zero, one, or more objects. Each object is represented in the composite format string by an indexed format item. The index of the format item corresponds to the position of the object that it represents in the method's parameter list. Indexes are zero-based. For example, in the following call to the <xref:System.String.Format%2A?displayProperty=nameWithType> method, the first format item, `{0:D}`, is replaced by the string representation of `thatDate`; the second format item, `{1}`, is replaced by the string representation of `item1`; and the third format item, `{2:C2}`, is replaced by the string representation of `item1.Value`.

[!code-csharp[Conceptual.Formatting.Overview#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/composite1.cs#14)]
[!code-vb[Conceptual.Formatting.Overview#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/composite1.vb#14)]

In addition to replacing a format item with the string representation of its corresponding object, format items also let you control the following:

- The specific way in which an object is represented as a string, if the object implements the <xref:System.IFormattable> interface and supports format strings. You do this by following the format item's index with a `:` (colon) followed by a valid format string. The previous example did this by formatting a date value with the "d" (short date pattern) format string (e.g., `{0:d}`) and   by formatting a numeric value with the "C2" format string (e.g., `{2:C2}` to represent the number as a currency value with two fractional decimal digits.

- The width of the field that contains the object's string representation, and the alignment of the string representation in that field. You do this by following the format item's index with a `,` (comma) followed the field width. The string is right-aligned in the field if the field width is a positive value, and it is left-aligned if the field width is a negative value. The following example left-aligns date values in a 20-character field, and it right-aligns decimal values with one fractional digit in an 11-character field.

     [!code-csharp[Conceptual.Formatting.Overview#22](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/composite2.cs#22)]
     [!code-vb[Conceptual.Formatting.Overview#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/composite2.vb#22)]

     Note that, if both the alignment string component and the format string component are present, the former precedes the latter (for example, `{0,-20:g}`.

For more information about composite formatting, see [Composite Formatting](composite-formatting.md).

## Custom formatting with ICustomFormatter

Two composite formatting methods, <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> and <xref:System.Text.StringBuilder.AppendFormat%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, include a format provider parameter that supports custom formatting. When either of these formatting methods is called, it passes a <xref:System.Type> object that represents an <xref:System.ICustomFormatter> interface to the format provider's <xref:System.IFormatProvider.GetFormat%2A> method. The <xref:System.IFormatProvider.GetFormat%2A> method is then responsible for returning the <xref:System.ICustomFormatter> implementation that provides custom formatting.

The <xref:System.ICustomFormatter> interface has a single method, <xref:System.ICustomFormatter.Format%28System.String%2CSystem.Object%2CSystem.IFormatProvider%29>, that is called automatically by a composite formatting method, once for each format item in a composite format string. The <xref:System.ICustomFormatter.Format%28System.String%2CSystem.Object%2CSystem.IFormatProvider%29> method has three parameters: a format string, which represents the `formatString` argument in a format item, an object to format, and an <xref:System.IFormatProvider> object that provides formatting services. Typically, the class that implements <xref:System.ICustomFormatter> also implements <xref:System.IFormatProvider>, so this last parameter is a reference to the custom formatting class itself. The method returns a custom formatted string representation of the object to be formatted. If the method cannot format the object, it should return a null reference (`Nothing` in Visual Basic).

The following example provides an <xref:System.ICustomFormatter> implementation named `ByteByByteFormatter` that displays integer values as a sequence of two-digit hexadecimal values followed by a space.

[!code-csharp[Conceptual.Formatting.Overview#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/icustomformatter1.cs#15)]
[!code-vb[Conceptual.Formatting.Overview#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/icustomformatter1.vb#15)]

The following example uses the `ByteByByteFormatter` class to format integer values. Note that the <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> method is called more than once in the second <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method call, and that the default <xref:System.Globalization.NumberFormatInfo> provider is used in the third method call because the .`ByteByByteFormatter.Format` method does not recognize the "N0" format string and returns a null reference (`Nothing` in Visual Basic).

[!code-csharp[Conceptual.Formatting.Overview#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.formatting.overview/cs/icustomformatter1.cs#16)]
[!code-vb[Conceptual.Formatting.Overview#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.formatting.overview/vb/icustomformatter1.vb#16)]

## Related topics

|Title|Definition|
|-----------|----------------|
|[Standard Numeric Format Strings](standard-numeric-format-strings.md)|Describes standard format strings that create commonly used string representations of numeric values.|
|[Custom Numeric Format Strings](custom-numeric-format-strings.md)|Describes custom format strings that create application-specific formats for numeric values.|
|[Standard Date and Time Format Strings](standard-date-and-time-format-strings.md)|Describes standard format strings that create commonly used string representations of <xref:System.DateTime> values.|
|[Custom Date and Time Format Strings](custom-date-and-time-format-strings.md)|Describes custom format strings that create application-specific formats for <xref:System.DateTime> values.|
|[Standard TimeSpan Format Strings](standard-timespan-format-strings.md)|Describes standard format strings that create commonly used string representations of time intervals.|
|[Custom TimeSpan Format Strings](custom-timespan-format-strings.md)|Describes custom format strings that create application-specific formats for time intervals.|
|[Enumeration Format Strings](enumeration-format-strings.md)|Describes standard format strings that are used to create string representations of enumeration values.|
|[Composite Formatting](composite-formatting.md)|Describes how to embed one or more formatted values in a string. The string can subsequently be displayed on the console or written to a stream.|
|[Parsing Strings](parsing-strings.md)|Describes how to initialize objects to the values described by string representations of those objects. Parsing is the inverse operation of formatting.|

## Reference

- <xref:System.IFormattable?displayProperty=nameWithType>
- <xref:System.IFormatProvider?displayProperty=nameWithType>
- <xref:System.ICustomFormatter?displayProperty=nameWithType>
