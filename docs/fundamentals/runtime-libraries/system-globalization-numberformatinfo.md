---
title: System.Globalization.NumberFormatInfo class
description: Learn more about the System.Globalization.NumberFormatInfo class.
ms.date: 12/28/2023
ms.topic: conceptual
---
# <xref:System.Globalization.NumberFormatInfo> class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Globalization.NumberFormatInfo> class contains culture-specific information that is used when you format and parse numeric values. This information includes the currency symbol, the decimal symbol, the group separator symbol, and the symbols for positive and negative signs.

## Instantiate a NumberFormatInfo object

You can instantiate a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of the current culture, the invariant culture, a specific culture, or a neutral culture.

### Instantiate a NumberFormatInfo object for the current culture

You can instantiate a <xref:System.Globalization.NumberFormatInfo> object for the current culture in any of the following ways. In each case, the returned <xref:System.Globalization.NumberFormatInfo> object is read-only.

- By retrieving a <xref:System.Globalization.CultureInfo> object that represents the current culture from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> property, and retrieving the <xref:System.Globalization.NumberFormatInfo> object from its <xref:System.Globalization.CultureInfo.NumberFormat?displayProperty=nameWithType> property.

- By retrieving the <xref:System.Globalization.NumberFormatInfo> object returned by the `static` (`Shared` in Visual Basic) <xref:System.Globalization.NumberFormatInfo.CurrentInfo> property.

- By calling the <xref:System.Globalization.NumberFormatInfo.GetInstance%2A> method with a <xref:System.Globalization.CultureInfo> object that represents the current culture.

The following example uses these three ways to create <xref:System.Globalization.NumberFormatInfo> objects that represent the formatting conventions of the current culture. It also retrieves the value of the <xref:System.Globalization.NumberFormatInfo.IsReadOnly> property to illustrate that each object is read-only.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate1.cs" interactive="try-dotnet" id="Snippet1":::

You can create a writable <xref:System.Globalization.NumberFormatInfo> object that represents the conventions of the current culture in any of the following ways:

- By retrieving a <xref:System.Globalization.NumberFormatInfo> object in any of the ways illustrated in the previous code example, and calling the <xref:System.Globalization.NumberFormatInfo.Clone%2A> method on the returned <xref:System.Globalization.NumberFormatInfo> object. This creates a copy of the original <xref:System.Globalization.NumberFormatInfo> object, except that its <xref:System.Globalization.NumberFormatInfo.IsReadOnly> property is `false`.

- By calling the <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method to create a <xref:System.Globalization.CultureInfo> object that represents the current culture, and then using its <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType> property to retrieve the <xref:System.Globalization.NumberFormatInfo> object.

The following example illustrates these two ways of instantiating a <xref:System.Globalization.NumberFormatInfo> object, and displays the value of its <xref:System.Globalization.NumberFormatInfo.IsReadOnly> property to illustrate that the object is not read-only.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate2.cs" id="Snippet2":::

Note that the Windows operating system allows the user to override some of the <xref:System.Globalization.NumberFormatInfo> property values used in numeric formatting and parsing operations through the **Region and Language** item in Control Panel. For example, a user whose culture is English (United States) might choose to display currency values as 1.1 USD instead of the default of $1.1. The <xref:System.Globalization.NumberFormatInfo> objects retrieved in the ways discussed previously all reflect these user overrides. If this is undesirable, you can create a <xref:System.Globalization.NumberFormatInfo> object that does not reflect user overrides (and that is also read/write rather than read-only) by calling the <xref:System.Globalization.CultureInfo.%23ctor(System.String,System.Boolean)?displayProperty=nameWithType> constructor and supplying a value of `false` for the `useUserOverride` argument. The following example provides an illustration for a system whose current culture is English (United States) and whose currency symbol has been changed from the default of $ to USD.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate3.cs" id="Snippet3":::

If the <xref:System.Globalization.CultureInfo.UseUserOverride%2A?displayProperty=nameWithType> property is set to `true`, the properties <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType>, <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType>, and <xref:System.Globalization.CultureInfo.TextInfo%2A?displayProperty=nameWithType> are also retrieved from the user settings. If the user settings are incompatible with the culture associated with the <xref:System.Globalization.CultureInfo> object (for example, if the selected calendar is not one of the calendars listed by the <xref:System.Globalization.CultureInfo.OptionalCalendars> property), the results of the methods and the values of the properties are undefined.

### Instantiate a NumberFormatInfo object for the invariant culture

The invariant culture represents a culture that is culture-insensitive. It is based on the English language but not on any specific English-speaking country/region. Although the data of specific cultures can be dynamic and can change to reflect new cultural conventions or user preferences, the data of the invariant culture does not change. A <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of the invariant culture can be used for formatting operations in which result strings should not vary by culture.

You can instantiate a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of the invariant culture in the following ways:

- By retrieving the value of the <xref:System.Globalization.NumberFormatInfo.InvariantInfo> property. The returned  <xref:System.Globalization.NumberFormatInfo> object is read-only.

- By retrieving the value of the <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType> property from the <xref:System.Globalization.CultureInfo> object that is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. The returned <xref:System.Globalization.NumberFormatInfo> object is read-only.

- By calling the parameterless <xref:System.Globalization.NumberFormatInfo.%23ctor%2A> class constructor. The returned <xref:System.Globalization.NumberFormatInfo> object is read/write.

The following example uses each of these methods to instantiate a <xref:System.Globalization.NumberFormatInfo> object that represents the invariant culture. It then indicates whether the object is read-only,

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate4.cs" interactive="try-dotnet" id="Snippet4":::

### Instantiate a NumberFormatInfo object for a specific culture

A specific culture represents a language that is spoken in a particular country/region. For example, en-US is a specific culture that represents the English language spoken in the United States, and en-CA is a specific culture that represents the English language spoken in Canada. You can instantiate a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of a specific culture in the following ways:

- By calling the <xref:System.Globalization.CultureInfo.GetCultureInfo%28System.String%29?displayProperty=nameWithType> method and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.NumberFormat> property. The returned <xref:System.Globalization.NumberFormatInfo> object is read-only.

- By passing a <xref:System.Globalization.CultureInfo> object that represents the culture whose <xref:System.Globalization.NumberFormatInfo> object you want to retrieve to the static <xref:System.Globalization.NumberFormatInfo.GetInstance%2A> method. The returned <xref:System.Globalization.NumberFormatInfo> object is read/write.

- By calling the <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.NumberFormat> property. The returned <xref:System.Globalization.NumberFormatInfo> object is read/write.

- By calling one of the <xref:System.Globalization.CultureInfo.%23ctor%2A?displayProperty=nameWithType> class constructors and retrieving the value of the returned <xref:System.Globalization.CultureInfo> object's <xref:System.Globalization.CultureInfo.NumberFormat> property. The returned <xref:System.Globalization.NumberFormatInfo> object is read/write.

The following example uses these four ways to create a <xref:System.Globalization.NumberFormatInfo> object that reflects the formatting conventions of the Indonesian (Indonesia) culture. It also indicates whether each object is read-only.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate5.cs" interactive="try-dotnet" id="Snippet5":::

### Instantiate a NumberFormatInfo object for a neutral culture

A neutral culture represents a culture or language that is independent of a country/region. It is typically the parent of one or more specific cultures. For example, fr is a neutral culture for the French language and the parent of the fr-FR culture. You create a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of a neutral culture in the same way that you create a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of a specific culture.

However, because it is independent of a specific country/region, a neutral culture lacks culture-specific formatting information. Rather than populating the <xref:System.Globalization.NumberFormatInfo> object with generic values, .NET returns a <xref:System.Globalization.NumberFormatInfo> object that reflects the formatting conventions of a specific culture that is a child of the neutral culture. For example, the <xref:System.Globalization.NumberFormatInfo> object for the neutral en culture reflects the formatting conventions of the en-US culture, and the <xref:System.Globalization.NumberFormatInfo> object for the fr culture reflects the formatting conventions of the fr-FR culture.

You can use code like the following to determine which specific culture's formatting conventions each neutral culture represents.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/instantiate6.cs" id="Snippet6":::

## Dynamic data

The culture-specific data for formatting numeric values provided by the <xref:System.Globalization.NumberFormatInfo> class is dynamic, just like the cultural data provided by the <xref:System.Globalization.CultureInfo> class. You should not make any assumptions about the stability of values for <xref:System.Globalization.NumberFormatInfo> objects that are associated with particular <xref:System.Globalization.CultureInfo> objects. Only the data provided by the invariant culture and its associated <xref:System.Globalization.NumberFormatInfo> object is stable. Other data can change between application sessions, or even within a single session, for the following reasons:

- **System updates.** Cultural preferences such as the currency symbol or currency formats change over time. When this happens, Windows Update includes changes to the <xref:System.Globalization.NumberFormatInfo> property value for a particular culture.

- **Replacement cultures.** The <xref:System.Globalization.CultureAndRegionInfoBuilder> class can be used to replace the data of an existing culture.

- **Cascading changes to property values.** A number of culture-related properties can change at run time, which, in turn, causes <xref:System.Globalization.NumberFormatInfo> data to change. For example, the current culture can be changed either programmatically or through user action. When this happens, the <xref:System.Globalization.NumberFormatInfo> object returned by the <xref:System.Globalization.NumberFormatInfo.CurrentInfo> property changes to an object associated with the current culture.

- **User preferences.** Users of your application might override some of the values associated with the current system culture through the region and language options in Control Panel. For example, users might choose a different currency symbol or a different decimal separator symbol. If the <xref:System.Globalization.CultureInfo.UseUserOverride%2A?displayProperty=nameWithType> property is set to `true` (its default value), the properties of the <xref:System.Globalization.NumberFormatInfo> object are also retrieved from the user settings.

All user-overridable properties of a <xref:System.Globalization.NumberFormatInfo> object are initialized when the object is created. There is still a possibility of inconsistency, because neither object creation nor the user override process is atomic, and the relevant values may change during object creation. However, these inconsistencies should be extremely rare.

You can control whether user overrides are reflected in <xref:System.Globalization.NumberFormatInfo> objects that represent the same culture as the current culture. The following table lists the ways in which a <xref:System.Globalization.NumberFormatInfo> object can be retrieved and indicates whether the resulting object reflects user overrides.

|Source of CultureInfo and NumberFormatInfo object|Reflects user overrides|
|-------------------------------------------------------|-----------------------------|
|`CultureInfo.CurrentCulture.NumberFormat` property|Yes|
|<xref:System.Globalization.NumberFormatInfo.CurrentInfo%2A?displayProperty=nameWithType> property|Yes|
|<xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A?displayProperty=nameWithType> method|Yes|
|<xref:System.Globalization.CultureInfo.GetCultureInfo%2A?displayProperty=nameWithType> method|No|
|<xref:System.Globalization.CultureInfo.%23ctor%28System.String%29> constructor|Yes|
|<xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor|Depends on value of `useUserOverride` parameter|

Unless there is a compelling reason to do otherwise, you should respect user overrides when you use the <xref:System.Globalization.NumberFormatInfo> object in client applications to format and parse user input or to display numeric data. For server applications or unattended applications, you should not respect user overrides. However, if you are using the <xref:System.Globalization.NumberFormatInfo> object either explicitly or implicitly to persist numeric data in string form, you should either use a <xref:System.Globalization.NumberFormatInfo> object that reflects the formatting conventions of the invariant culture, or you should specify a custom numeric format string that you use regardless of culture.

## IFormatProvider, NumberFormatInfo, and numeric formatting

A <xref:System.Globalization.NumberFormatInfo> object is used implicitly or explicitly in all numeric formatting operations. These include calls to the following methods:

- All numeric formatting methods, such as <xref:System.Int32.ToString%2A?displayProperty=nameWithType>, <xref:System.Double.ToString%2A?displayProperty=nameWithType>, and <xref:System.Convert.ToString%28System.Int32%29?displayProperty=nameWithType>.

- The major composite formatting method, <xref:System.String.Format%2A?displayProperty=nameWithType>.

- Other composite formatting methods, such as <xref:System.Console.WriteLine%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> and <xref:System.Text.StringBuilder.AppendFormat%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>.

All numeric formatting operations make use of an <xref:System.IFormatProvider> implementation. The <xref:System.IFormatProvider> interface includes a single method, <xref:System.IFormatProvider.GetFormat%28System.Type%29>. This is a callback method that is passed a <xref:System.Type> object that represents the type needed to provide formatting information. The method is responsible for returning either an instance of that type or `null`, if it cannot provide an instance of the type. .NET provides two <xref:System.IFormatProvider> implementations for formatting numbers:

- The <xref:System.Globalization.CultureInfo> class, which represents a specific culture (or a specific language in a specific country/region). In a numeric formatting operation, the <xref:System.Globalization.CultureInfo.GetFormat%2A?displayProperty=nameWithType> method returns the <xref:System.Globalization.NumberFormatInfo> object associated with its <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType> property.

- The <xref:System.Globalization.NumberFormatInfo> class, which provides information about the formatting conventions of its associated culture. The <xref:System.Globalization.NumberFormatInfo.GetFormat%2A?displayProperty=nameWithType> method returns an instance of itself.

If an <xref:System.IFormatProvider> implementation is not provided to a formatting method explicitly, a <xref:System.Globalization.CultureInfo> object returned by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property that represents the current culture is used.

The following example illustrates the relationship between the <xref:System.IFormatProvider> interface and the <xref:System.Globalization.NumberFormatInfo> class in formatting operations by defining a custom <xref:System.IFormatProvider> implementation. Its <xref:System.IFormatProvider.GetFormat%2A> method displays the type name of the object requested by the formatting operation. If the interface is requesting a <xref:System.Globalization.NumberFormatInfo> object, this method provides the <xref:System.Globalization.NumberFormatInfo> object for the current culture. As the output from the example shows, the <xref:System.Decimal.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method requests a <xref:System.Globalization.NumberFormatInfo> object to provide formatting information, whereas the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method requests <xref:System.Globalization.NumberFormatInfo> and <xref:System.Globalization.DateTimeFormatInfo> objects as well as an <xref:System.ICustomFormatter> implementation.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/formatprovider1.cs" id="Snippet1":::

If an <xref:System.IFormatProvider> implementation is not explicitly provided in a numeric formatting method call, the method calls the `CultureInfo.CurrentCulture.GetFormat` method, which returns the <xref:System.Globalization.NumberFormatInfo> object that corresponds to the current culture.

## Format strings and NumberFormatInfo properties

Every formatting operation uses either a standard or a custom numeric format string to produce a result string from a number. In some cases, the use of a format string to produce a result string is explicit, as in the following example. This code calls the <xref:System.Decimal.ToString%28System.IFormatProvider%29?displayProperty=nameWithType> method to convert a <xref:System.Decimal> value to a number of different string representations by using the formatting conventions of the en-US culture.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/properties1.cs" interactive="try-dotnet" id="Snippet2":::

In other cases, the use of a format string is implicit. For example, in the following method calls to the default or parameterless <xref:System.Decimal.ToString?displayProperty=nameWithType> method, the value of the <xref:System.Decimal> instance is formatted by using the general ("G") format specifier and the conventions of the current culture, which in this case is the en-US culture.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/properties2.cs" interactive="try-dotnet" id="Snippet3":::

Each standard numeric format string uses one or more <xref:System.Globalization.NumberFormatInfo> properties to determine the pattern or the symbols used in the result string. Similarly, each custom numeric format specifier except "0" and "#" insert symbols in the result string that are defined by <xref:System.Globalization.NumberFormatInfo> properties. The following table lists the standard and custom numeric format specifiers and their associated <xref:System.Globalization.NumberFormatInfo> properties. To change the appearance of the result string for a particular culture, see the [Modify NumberFormatInfo properties](#modify-numberformatinfo-properties) section. For details about the use of these format specifiers, see [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md).

|Format specifier|Associated properties|
|----------------------|---------------------------|
|"C" or "c" (currency format specifier)|<xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A>, to define the default number of fractional digits.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator%2A>, to define the group or thousands separator.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencyGroupSizes%2A>, to define the sizes of integral groups.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern%2A>, to define the pattern of negative currency values.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencyPositivePattern%2A>, to define the pattern of positive currency values.<br /><br /><xref:System.Globalization.NumberFormatInfo.CurrencySymbol%2A>, to define the currency symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.|
|"D" or "d" (decimal format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.|
|"E" or "e" (exponential or scientific format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol in the mantissa and exponent.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>, to define the positive sign symbol in the exponent.|
|"F" or "f" (fixed-point format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A>, to define the default number of fractional digits.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.|
|"G" or "g" (general format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>, to define the positive sign symbol for result strings in exponential format.|
|"N" or "n" (number format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A>, to define the default number of fractional digits.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator%2A>, to define the group separator (thousands) symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberGroupSizes%2A>, to define the number of integral digits in a group.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberNegativePattern%2A>, to define the format of negative values.|
|"P" or "p" (percent format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits%2A>, to define the default number of fractional digits.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentGroupSeparator%2A>, to define the group separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentGroupSizes%2A>, to define the number of integral digits in a group.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentNegativePattern%2A>, to define the placement of the percent symbol and the negative symbol for negative values.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentPositivePattern%2A>, to define the placement of the percent symbol for positive values.<br /><br /><xref:System.Globalization.NumberFormatInfo.PercentSymbol%2A>, to define the percent symbol.|
|"R" or "r" (round-trip format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.<br /><br /><xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>, to define the positive sign symbol in an exponent.|
|"X" or "x" (hexadecimal format specifier)|None.|
|"." (decimal point custom format specifier)|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>, to define the decimal separator symbol.|
|"," (group separator custom format specifier)|<xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator%2A>, to define the group (thousands) separator symbol.|
|"%" (percentage placeholder custom format specifier)|<xref:System.Globalization.NumberFormatInfo.PercentSymbol%2A>, to define the percent symbol.|
|"‰" (per mille placeholder custom format specifier)|<xref:System.Globalization.NumberFormatInfo.PerMilleSymbol%2A>, to define the per mille symbol.|
|"E" (exponential notation custom format specifier)|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>, to define the negative sign symbol in the mantissa and exponent.<br /><br /><xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>, to define the positive sign symbol in the exponent.|

Note that the <xref:System.Globalization.NumberFormatInfo> class includes a <xref:System.Globalization.NumberFormatInfo.NativeDigits> property that specifies the base 10 digits used by a specific culture. However, the property is not used in formatting operations; only the Basic Latin digits 0 (U+0030) through 9 (U+0039) are used in the result string. In addition, for <xref:System.Single> and <xref:System.Double> values of `NaN`, `PositiveInfinity`, and `NegativeInfinity`, the result string consists exclusively of the symbols defined by the <xref:System.Globalization.NumberFormatInfo.NaNSymbol%2A>, <xref:System.Globalization.NumberFormatInfo.PositiveInfinitySymbol%2A>, and <xref:System.Globalization.NumberFormatInfo.NegativeInfinitySymbol%2A> properties, respectively.

## Modify NumberFormatInfo properties

You can modify the properties of a <xref:System.Globalization.NumberFormatInfo> object to customize the result string produced in a numeric formatting operation. To do this:

1. Create a read/write copy of a <xref:System.Globalization.NumberFormatInfo> object whose formatting conventions you want to modify. For more information, see the [Instantiate a NumberFormatInfo object](#instantiate-a-numberformatinfo-object) section.

2. Modify the property or properties that are used to produce the desired result string. For information about how formatting methods use <xref:System.Globalization.NumberFormatInfo> properties to define result strings, see the [Format strings and NumberFormatInfo properties](#format-strings-and-numberformatinfo-properties) section.

3. Use the custom <xref:System.Globalization.NumberFormatInfo> object as the <xref:System.IFormatProvider> argument in calls to formatting methods.

> [!NOTE]
> Instead of dynamically modifying a culture's property values each time an application is started, you can use the <xref:System.Globalization.CultureAndRegionInfoBuilder> class to define either a custom culture (a culture that has a unique name and that supplements existing cultures) or a replacement culture (one that is used instead of a specific culture).

The following sections provide some examples.

### Modify the currency symbol and pattern

The following example modifies a <xref:System.Globalization.NumberFormatInfo> object that represents the formatting conventions of the en-US culture. It assigns the ISO-4217 currency symbol to the <xref:System.Globalization.NumberFormatInfo.CurrencySymbol> property and defines a pattern for currency values that consists of the currency symbol followed by a space and a numeric value.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/customize_currency1.cs" interactive="try-dotnet" id="Snippet1":::

### Format a national identification number

Many national identification numbers consist exclusively of digits and so can easily be formatted by modifying the properties of a <xref:System.Globalization.NumberFormatInfo> object. For example, a social security number in the United States consists of 9 digits arranged as follows: `XXX-XX-XXXX`. The following example assumes that social security numbers are stored as integer values and formats them appropriately.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/customize_ssn1.cs" interactive="try-dotnet" id="Snippet2":::

## Parse numeric strings

Parsing involves converting the string representation of a number to a number. Each numeric type in .NET includes two overloaded parsing methods: `Parse` and `TryParse`. The `Parse` method converts a string to a number and throws an exception if the conversion fails. The `TryParse` method converts a string to a number, assigns the number to an `out` argument, and returns a <xref:System.Boolean> value that indicates whether the conversion succeeded.

The parsing methods implicitly or explicitly use a <xref:System.Globalization.NumberStyles> enumeration value to determine what style elements (such as group separators, a decimal separator, or a currency symbol) can be present in a string if the parsing operation is to succeed. If a <xref:System.Globalization.NumberStyles> value is not provided in the method call, the default is a <xref:System.Globalization.NumberStyles> value that includes the <xref:System.Globalization.NumberStyles.Float> and <xref:System.Globalization.NumberStyles.AllowThousands> flags, which specifies that the parsed string can include group symbols, a decimal separator, a negative sign, and white-space characters, or it can be the string representation of a number in exponential notation.

The parsing methods also implicitly or explicitly use a <xref:System.Globalization.NumberFormatInfo> object that defines the specific symbols and patterns that can occur in the string to be parsed. If a <xref:System.Globalization.NumberFormatInfo> object is not provided, the default is the <xref:System.Globalization.NumberFormatInfo> for the current culture. For more information about parsing, see the individual parsing methods, such as <xref:System.Int16.Parse%28System.String%29?displayProperty=nameWithType>, <xref:System.Int32.Parse%28System.String%2CSystem.Globalization.NumberStyles%29?displayProperty=nameWithType>, <xref:System.Int64.Parse%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType>, <xref:System.Decimal.Parse%28System.String%2CSystem.Globalization.NumberStyles%2CSystem.IFormatProvider%29?displayProperty=nameWithType>, <xref:System.Double.TryParse%28System.String%2CSystem.Double%40%29?displayProperty=nameWithType>, and <xref:System.Numerics.BigInteger.TryParse%28System.String%2CSystem.Globalization.NumberStyles%2CSystem.IFormatProvider%2CSystem.Numerics.BigInteger%40%29?displayProperty=nameWithType>.

The following example illustrates the culture-sensitive nature of parsing strings. It tries to parse a string that include thousands separators by using the conventions of the en-US, fr-FR, and invariant cultures. A string that includes the comma as a group separator and the period as a decimal separator fails to parse in the fr-FR culture, and a string with white space as a group separator and a comma as a decimal separator fails to parse in the en-US and invariant cultures.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/parse1.cs" interactive="try-dotnet" id="Snippet4":::

Parsing generally occurs in two contexts:

- As an operation that is designed to convert user input into a numeric value.

- As an operation that is designed to round-trip a numeric value; that is, to deserialize a numeric value that was previously serialized as a string.

The following sections discuss these two operations in greater detail.

### Parse user strings

When you are parsing numeric strings input by the user, you should always instantiate a <xref:System.Globalization.NumberFormatInfo> object that reflects the user's cultural settings. For information about how to instantiate a <xref:System.Globalization.NumberFormatInfo> object that reflects user customizations, see the [Dynamic data](#dynamic-data) section.

The following example illustrates the difference between a parsing operation that reflects user cultural settings and one that does not. In this case, the default system culture is en-US, but the user has defined "," as the decimal symbol and "." as the group separator in Control Panel, **Region and Language**. Ordinarily, these symbols are reversed in the default en-US culture. When the user enters a string that reflects user settings, and the string is parsed by a <xref:System.Globalization.NumberFormatInfo> object that also reflects user settings (overrides), the parsing operation returns a correct result. However, when the string is parsed by a <xref:System.Globalization.NumberFormatInfo> object that reflects standard en-US cultural settings, it mistakes the comma symbol for a group separator and returns an incorrect result.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/parseuser1.cs" interactive="try-dotnet" id="Snippet5":::

### Serialize and deserialize numeric data

When numeric data is serialized in string format and later deserialized and parsed, the strings should be generated and parsed by using the conventions of the invariant culture. The formatting and parsing operations should never reflect the conventions of a specific culture. If culture-specific settings are used, the portability of the data is strictly limited; it can be successfully deserialized only on a thread whose culture-specific settings are identical to those of the thread on which it was serialized. In some cases, this means that the data cannot even be successfully deserialized on the same system on which it was serialized.

The following example illustrates what can happen when this principle is violated. Floating-point values in an array are converted to strings when the current thread uses the culture-specific settings of the en-US culture.
The data is then parsed by a thread that uses the culture-specific settings of the pt-BR culture. In this case, although each parsing operation succeeds, the data doesn't round-trip successfully and data corruption occurs.
In other cases, a parsing operation could fail and a <xref:System.FormatException> exception could be thrown.

:::code language="csharp" source="./snippets/System.Globalization/NumberFormatInfo/csharp/parsepersisted.cs" interactive="try-dotnet" id="Snippet6":::
