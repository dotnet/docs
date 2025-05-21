---
title: System.Convert class
description: Learn about the System.Convert class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Convert class

[!INCLUDE [context](includes/context.md)]

The static <xref:System.Convert> class contains methods that are primarily used to support conversion to and from the base data types in .NET. The supported base types are <xref:System.Boolean>, <xref:System.Char>, <xref:System.SByte>, <xref:System.Byte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>, <xref:System.Single>, <xref:System.Double>, <xref:System.Decimal>, <xref:System.DateTime> and <xref:System.String>. In addition, the <xref:System.Convert> class includes methods to support other kinds of conversions.

## Conversions to and from base types

A conversion method exists to convert every base type to every other base type. However, the actual call to a particular conversion method can produce one of five outcomes, depending on the value of the base type at run time and the target base type. These five outcomes are:

- No conversion. This occurs when an attempt is made to convert from a type to itself (for example, by calling <xref:System.Convert.ToInt32%28System.Int32%29?displayProperty=nameWithType> with an argument of type <xref:System.Int32>). In this case, the method simply returns an instance of the original type.

- An <xref:System.InvalidCastException>. This occurs when a particular conversion is not supported. An <xref:System.InvalidCastException> is thrown for the following conversions:

  - Conversions from <xref:System.Char> to <xref:System.Boolean>, <xref:System.Single>, <xref:System.Double>, <xref:System.Decimal>, or <xref:System.DateTime>.
  - Conversions from <xref:System.Boolean>, <xref:System.Single>, <xref:System.Double>, <xref:System.Decimal>, or <xref:System.DateTime> to <xref:System.Char>.
  - Conversions from <xref:System.DateTime> to any other type except <xref:System.String>.
  - Conversions from any other type, except <xref:System.String>, to <xref:System.DateTime>.

- A <xref:System.FormatException>. This occurs when the attempt to convert a string value to any other base type fails because the string is not in the proper format. The exception is thrown for the following conversions:

  - A string to be converted to a <xref:System.Boolean> value does not equal <xref:System.Boolean.TrueString?displayProperty=nameWithType> or <xref:System.Boolean.FalseString?displayProperty=nameWithType>.
  - A string to be converted to a <xref:System.Char> value consists of multiple characters.
  - A string to be converted to any numeric type is not recognized as a valid number.
  - A string to be converted to a <xref:System.DateTime> is not recognized as a valid date and time value.

- A successful conversion. For conversions between two different base types not listed in the previous outcomes, all widening conversions as well as all narrowing conversions that do not result in a loss of data will succeed and the method will return a value of the targeted base type.

- An <xref:System.OverflowException>. This occurs when a narrowing conversion results in a loss of data. For example, trying to convert a <xref:System.Int32> instance whose value is 10000 to a <xref:System.Byte> type throws an <xref:System.OverflowException> because 10000 is outside the range of the <xref:System.Byte> data type.

An exception will not be thrown if the conversion of a numeric type results in a loss of precision (that is, the loss of some least significant digits). However, an exception will be thrown if the result is larger than can be represented by the particular conversion method's return value type.

For example, when a <xref:System.Double> is converted to a <xref:System.Single>, a loss of precision might occur but no exception is thrown. However, if the magnitude of the <xref:System.Double> is too large to be represented by a <xref:System.Single>, an overflow exception is thrown.

## Non-decimal numbers

The <xref:System.Convert> class includes static methods that you can call to convert integral values to non-decimal string representations, and to convert strings that represent non-decimal numbers to integral values. Each of these conversion methods includes a `base` argument  that lets you specify  the number system; binary (base 2), octal (base 8), and hexadecimal (base 16), as well as decimal (base 10). There is a set of methods to convert each of the CLS-compliant primitive integral types to a string, and one to convert a string to each of the primitive integral types:

- <xref:System.Convert.ToString%28System.Byte%2CSystem.Int32%29> and <xref:System.Convert.ToByte%28System.String%2CSystem.Int32%29>, to convert a byte value to and from a string in a specified base.

- <xref:System.Convert.ToString%28System.Int16%2CSystem.Int32%29> and <xref:System.Convert.ToInt16%28System.String%2CSystem.Int32%29>, to convert a 16-bit signed integer to and from a string in a specified base.

- <xref:System.Convert.ToString%28System.Int32%2CSystem.Int32%29> and <xref:System.Convert.ToInt32%28System.String%2CSystem.Int32%29>, to convert a 32-bit signed integer to and from a string in a specified base.

- <xref:System.Convert.ToString%28System.Int64%2CSystem.Int32%29> and <xref:System.Convert.ToInt64%28System.String%2CSystem.Int32%29>, to convert a 64-bit signed integer to and from a string in a specified base.

- <xref:System.Convert.ToSByte%28System.String%2CSystem.Int32%29>, to convert the string representation of a byte value in a specified format to a signed byte.

- <xref:System.Convert.ToUInt16%28System.String%2CSystem.Int32%29>, to convert the string representation of an integer in a specified format to an unsigned 16-bit integer.

- <xref:System.Convert.ToUInt32%28System.String%2CSystem.Int32%29>, to convert the string representation of an integer in a specified format to an unsigned 32-bit integer.

- <xref:System.Convert.ToUInt64%28System.String%2CSystem.Int32%29>, to convert the string representation of an integer in a specified format to an unsigned 64-bit integer.

The following example converts the value of <xref:System.Int16.MaxValue?displayProperty=nameWithType> to a string in all supported numeric formats. It then converts the string value back to a <xref:System.Int16> value.

:::code language="csharp" source="./snippets/System/Convert/Overview/csharp/NonDecimal1.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Convert/Overview/fsharp/NonDecimal1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Convert/Overview/vb/NonDecimal1.vb" id="Snippet2":::

## Conversions from custom objects to base types

In addition to supporting conversions between the base types, the <xref:System.Convert> method supports conversion of any custom type to any base type. To do this, the custom type must implement the <xref:System.IConvertible> interface, which defines methods for converting the implementing type to each of the base types. Conversions that are not supported by a particular type should throw an <xref:System.InvalidCastException>.

When the <xref:System.Convert.ChangeType%2A> method is passed a custom type as its first parameter, or when the `Convert.To`*Type* method (such as <xref:System.Convert.ToInt32%28System.Object%29?displayProperty=nameWithType> or <xref:System.Convert.ToDouble%28System.Object%2CSystem.IFormatProvider%29?displayProperty=nameWithType> is called and passed an instance of a custom type as its first parameter, the <xref:System.Convert> method, in turn, calls the custom type's <xref:System.IConvertible> implementation to perform the conversion. For more information, see [Type Conversion in .NET](../../standard/base-types/type-conversion.md).

## Culture-specific formatting information

All the base type conversion methods and the <xref:System.Convert.ChangeType%2A> method include overloads that have a parameter of type <xref:System.IFormatProvider>. For example, the <xref:System.Convert.ToBoolean%2A?displayProperty=nameWithType> method has the following two overloads:

- <xref:System.Convert.ToBoolean%28System.Object%2CSystem.IFormatProvider%29?displayProperty=nameWithType>
- <xref:System.Convert.ToBoolean%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType>

The <xref:System.IFormatProvider> parameter can supply culture-specific formatting information to assist the conversion process. However, it is ignored by most of the base type conversion methods. It is used only by the following base type conversion methods. If a `null` <xref:System.IFormatProvider> argument is passed to these methods, the <xref:System.Globalization.CultureInfo> object that represents the current culture is used.

- By methods that convert a value to a numeric type. The <xref:System.IFormatProvider> parameter is used by the overload that has parameters of type <xref:System.String> and <xref:System.IFormatProvider>. It is also used by the overload that has parameters of type <xref:System.Object> and <xref:System.IFormatProvider> if the object's run-time type is a <xref:System.String>.

- By methods that convert a value to a date and time. The <xref:System.IFormatProvider> parameter is used by the overload that has parameters of type <xref:System.String> and <xref:System.IFormatProvider>. It is also used by the overload that has parameters of type <xref:System.Object> and <xref:System.IFormatProvider> if the object's run-time type is a <xref:System.String>.

- By the <xref:System.Convert.ToString%2A?displayProperty=nameWithType> overloads that include an <xref:System.IFormatProvider> parameter and that convert either a numeric value to a string or a <xref:System.DateTime> value to a string.

However, any user-defined type that implements <xref:System.IConvertible> can make use of the <xref:System.IFormatProvider> parameter.

## Base64 encoding

Base64 encoding converts binary data to a string. Data expressed as base-64 digits can be easily conveyed over data channels that can only transmit 7-bit characters. The <xref:System.Convert> class includes the following methods to support base64 encoding: A set of methods support converting an array of bytes to and from a <xref:System.String> or to and from an array of Unicode characters consisting of base-64 digit characters.

- <xref:System.Convert.ToBase64String%2A>, which converts a byte array to a base64-encoded string.
- <xref:System.Convert.ToBase64CharArray%2A>, which converts a byte array to a base64-encoded character array.
- <xref:System.Convert.FromBase64String%2A>, which converts a base64-encoded string to a byte array.
- <xref:System.Convert.FromBase64CharArray%2A>, which converts a base64-encoded character array to a byte array.

## Other common conversions

You can use other .NET classes to perform some conversions that aren't supported by the static methods of the <xref:System.Convert> class. These include:

- Conversion to byte arrays

  The <xref:System.BitConverter> class provides methods that convert the primitive numeric types (including <xref:System.Boolean>) to byte arrays and from byte arrays back to primitive data types.

- Character encoding and decoding

  The <xref:System.Text.Encoding> class and its derived classes (such as <xref:System.Text.UnicodeEncoding> and <xref:System.Text.UTF8Encoding>) provide methods to encode a character array or a string (that is, to convert them to a byte array in a particular encoding) and to decode an encoded byte array (that is, convert a byte array back to UTF16-encoded Unicode characters). For more information, see [Character Encoding in .NET](../../standard/base-types/character-encoding.md).

## Examples

The following example demonstrates some of the conversion methods in the <xref:System.Convert> class, including <xref:System.Convert.ToInt32%2A>, <xref:System.Convert.ToBoolean%2A>, and <xref:System.Convert.ToString%2A>.

:::code language="csharp" source="./snippets/System/Convert/Overview/csharp/converter.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Convert/Overview/fsharp/converter.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Convert/Overview/vb/converter.vb" id="Snippet1":::
