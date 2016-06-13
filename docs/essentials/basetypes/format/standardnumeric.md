# Standard Numeric Format Strings

Standard numeric format strings are used to format common numeric types. A standard numeric format string takes the form **A**_xx_, where: 

* **A** is a single alphabetic character called the *format specifier*. Any numeric format string that contains more than one alphabetic character, including white space, is interpreted as a custom numeric format string. For more information, see [Custom Numeric Format Strings](customnumeric.md). 

* *xx* is an optional integer called the *precision specifier*. The precision specifier ranges from 0 to 99 and affects the number of digits in the result. Note that the precision specifier controls the number of digits in the string representation of a number. It does not round the number itself. To perform a rounding operation, use the [Math.Ceiling](http://dotnet.github.io/api/System.Math.html#methods), [Math.Floor](http://dotnet.github.io/api/System.Math.html#methods), or [Math.Round](http://dotnet.github.io/api/System.Math.html#methods) methods. 

When *precision specifier* controls the number of fractional digits in the result string, the result strings reflect numbers that are rounded away from zero (that is, using [MidpointRounding.AwayFromZero](http://dotnet.github.io/api/System.MidpointRounding.html#System_MidpointRounding_AwayFromZero)). 

> **Note**
>
> The precision specifier determines the number of digits in the result string. To pad a result string with leading or trailing spaces, use the [composite formatting](compositeformat.md) feature and define an *alignment component* in the format item. 

Standard numeric format strings are supported by some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the [ToString(String)](http://dotnet.github.io/api/System.Int32.html#System_Int32_ToString_System_String_) and [ToString(String, IFormatProvider)](http://dotnet.github.io/api/System.Int32.html#System_Int32_ToString_System_String_System_IFormatProvider_) methods of the [Int32](http://dotnet.github.io/api/System.Int32.html) type. Standard numeric format strings are also supported by the .NET Core [composite formatting](compositeformat.md) feature, which is used by some `Write` and `WriteLine` methods of the [Console](http://dotnet.github.io/api/System.Console.html) and [StreamWriter](http://dotnet.github.io/api/System.IO.StreamWriter.html) classes, the [String.Format](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method, and the [StringBuilder.AppendFormat](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_AppendFormat_System_IFormatProvider_System_String_System_Object_) method. The composite format feature allows you to include the string representation of multiple data items in a single string, to specify field width, and to align numbers in a field. For more information, see [Composite Formatting](compositeformat.md). 

The following table describes the standard numeric format specifiers and displays sample output produced by each format specifier. See the [Notes](#Notes) section for additional information about using standard numeric format strings, and the [Example](#Example) section for a comprehensive illustration of their use.

Format specifier | Name | Result | Supported By | Precision specifier | Default precision specifier | Examples
---------------- | ---- | ------ | ------------ | ------------------- | --------------------------- | --------
"C" or "c" | Currency | A currency value | All numeric types | Number of decimal digits | Defined by [NumberFormatInfo.CurrencyDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyDecimalDigits) | `123.456 ("C", en-US) -> $123.46`; `123.456 ("C", fr-FR) -> 123,46 €`; `123.456 ("C", ja-JP) -> ¥123`; `-123.456 ("C3", en-US) -> ($123.456)`; `-123.456 ("C3", fr-FR) -> -123,456 €`; `-123.456 ("C3", ja-JP) -> -¥123.456`
"D" or "d" | Decimal | Integer digits with optional negative sign | Integral types only | Minimum number of digits | Minimum number of digits required | `1234 ("D") -> 1234`; `-1234 ("D6") -> -001234`
"E" or "e" | Exponential (scientific) | Exponential notation | All numeric types | Number of decimal digits | 6 | `1052.0329112756 ("E", en-US) -> 1.052033E+003`; `1052.0329112756 ("e", fr-FR) -> 1,052033e+003`; `-1052.0329112756 ("e2", en-US) -> -1.05e+003`; `-1052.0329112756 ("E2", fr_FR) -> -1,05E+003`
"F" or "f" | Fixed-point | Integral and decimal digits with optional negative sign | All numeric types | Number of decimal digits | Defined by [NumberFormatInfo.NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) | `1234.567 ("F", en-US) -> 1234.57`; `1234.567 ("F", de-DE) -> 1234,57`; `1234 ("F1", en-US) -> 1234.0`; `1234 ("F1", de-DE) -> 1234,0`; `-1234.56 ("F4", en-US) -> -1234.5600`; `-1234.56 ("F4", de-DE) -> -1234,5600`
"G" or "g" | General | The more compact of either fixed-point or scientific notation | All numeric types | Number of significant digits | Depends on numeric type | `-123.456 ("G", en-US) -> -123.456`; `-123.456 ("G", sv-SE) -> -123,456`; `123.4546 ("G4", en-US) -> 123.5`; `123.4546 ("G4", sv-SE) -> 123,5`; `-1.234567890e-25 ("G", en-US) -> -1.23456789E-25`; `-1.234567890e-25 ("G", sv-SE) -> -1,23456789E-25`
"N" or "n" | Number | Integral and decimal digits, group separators, and a decimal separator with optional negative sign | All numeric types | Desired number of decimal places | Defined by [NumberFormatInfo.NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) | `1234.567 ("N", en-US) -> 1,234.57`; `1234.567 ("N", ru-RU) -> 1 234,57`; `1234 ("N1", en-US) -> 1,234.0`; `1234 ("N1", ru-RU) -> 1 234,0`; `-1234.56 ("N3", en-US) -> -1,234.560`; `-1234.56 ("N3", ru-RU) -> -1 234,560`
"P" or "p" | Percent | Number multiplied by 100 and displayed with a percent symbol | All numeric types | Desired number of decimal places | Defined by [NumberFormatInfo.PercentDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentDecimalDigits) | `1 ("P", en-US) -> 100.00 %`; `1 ("P", fr-FR) -> 100,00 %`; `-0.39678 ("P1", en-US) -> -39.7 %`; `-0.39678 ("P1", fr-FR) -> -39,7 %`
"R" or "r" | Round-trip | A string that can round-trip to an identical number | [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), and [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html) | Ignored |  | `123456789.12345678 ("R") -> 123456789.12345678`; `-1234567890.12345678 ("R") -> -1234567890.1234567`
"X" or "x" | Hexadecimal | A hexadecimal string | Integral types only | Number of digits in the result string |  | `55 ("X") -> FF`; `-1 ("x") -> ff`; `255 ("x4") -> 00ff`; `-1 ("X4") -> 00FF`
Any other single character | Unknown specifier | Throws a [FormatException](http://dotnet.github.io/api/System.FormatException.html) at run time |  |  |  | 

## Using Standard Numeric Format Strings

A standard numeric format string can be used to define the formatting of a numeric value in one of two ways:

* It can be passed to an overload of the `ToString` method that has a *format* parameter. The following example formats a numeric value as a currency string in the current (in this case, the en-US) culture. 

  ```csharp
  decimal value = 123.456m;
Console.WriteLine(value.ToString("C2"));
// Displays $123.46
  ```
  
* It can be supplied as the *formatString* argument in a format item used with such methods as [String.Format](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_), [Console.WriteLine](http://dotnet.github.io/api/System.Console.html#System_Console_WriteLine), and [StringBuilder.AppendFormat](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_AppendFormat_System_IFormatProvider_System_String_System_Object_). For more information, see [Composite Formatting](compositeformat.md). The following example uses a format item to insert a currency value in a string.

  ```csharp
  decimal value = 123.456m;
Console.WriteLine("Your account balance is {0:C2}.", value);
// Displays "Your account balance is $123.46."
  ```
  
  Optionally, you an supply an alignment argument to specify the width of the numeric field and whether its value is right- or left-aligned. The following example left-aligns a currency value in a 28-character field, and it right-aligns a currency value in a 14-character field.
  
  ```csharp
  decimal[] amounts = { 16305.32m, 18794.16m };
Console.WriteLine("   Beginning Balance           Ending Balance");
Console.WriteLine("   {0,-28:C2}{1,14:C2}", amounts[0], amounts[1]);
// Displays:
//        Beginning Balance           Ending Balance
//        $16,305.32                      $18,794.16
  ```
  
The following sections provide detailed information about each of the standard numeric format strings.

## The Currency ("C") Format Specifier

The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The precision specifier indicates the desired number of decimal places in the result string. If the precision specifier is omitted, the default precision is defined by the [NumberFormatInfo.CurrencyDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyDecimalDigits) property.

If the value to be formatted has more than the specified or default number of decimal places, the fractional value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or greater, the last digit in the result string is rounded away from zero.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

NumberFormatInfo property | Description
------------------------- | -----------
[CurrencyPositivePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyPositivePattern) | Defines the placement of the currency symbol for positive values.
[CurrencyNegativePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyNegativePattern) | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the [NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) property.
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the negative sign used if [CurrencyNegativePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyNegativePattern) indicates that parentheses are not used. 
[CurrencySymbol](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencySymbol) | Defines the currency symbol.
[CurrencyDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyDecimalDigits) | Defines the default number of decimal digits in a currency value. This value can be overridden by using the precision specifier.
[CurrencyDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyDecimalSeparator) | Defines the string that separates integral and decimal digits.
[CurrencyGroupSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyGroupSeparator) | Defines the string that separates groups of integral numbers. 
[CurrencyGroupSizes](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyGroupSizes) | Defines the number of integer digits that appear in a group.

The following example formats a [Double](http://dotnet.github.io/api/System.Double.html) value with the currency format specifier. 

```csharp
double value = 12345.6789;
Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));

Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture));

Console.WriteLine(value.ToString("C3", 
                  CultureInfo.CreateSpecificCulture("da-DK")));
// The example displays the following output on a system whose
// current culture is English (United States):
//       $12,345.68
//       $12,345.679
//       kr 12.345,679
```

## The Decimal ("D") Format Specifier

The "D" (or decimal) format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign if the number is negative. This format is supported only for integral types.

The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier. If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. As the following table shows, a single property affects the formatting of the result string. 

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative. 

The following example formats an [Int32](http://dotnet.github.io/api/System.Int32.html) value with the decimal format specifier.

```csharp
int value; 

value = 12345;
Console.WriteLine(value.ToString("D"));
// Displays 12345
Console.WriteLine(value.ToString("D8"));
// Displays 00012345

value = -12345;
Console.WriteLine(value.ToString("D"));
// Displays -12345
Console.WriteLine(value.ToString("D8"));
// Displays -00012345
```

## The Exponential ("E") Format Specifier

The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd", where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one digit always precedes the decimal point. 

The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, a default of six digits after the decimal point is used. 

The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet this minimum, if required.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative for both the coefficient and exponent. 
[NumberDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) | Defines the string that separates the integral digit from decimal digits in the coefficient.
[PositiveSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PositiveSign) | Defines the string that indicates that an exponent is positive.

The following example formats a [Double](http://dotnet.github.io/api/System.Double.html) value with the exponential format specifier. 

```csharp
double value = 12345.6789;
Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture));
// Displays 1.234568E+004

Console.WriteLine(value.ToString("E10", CultureInfo.InvariantCulture));
// Displays 1.2345678900E+004

Console.WriteLine(value.ToString("e4", CultureInfo.InvariantCulture));
// Displays 1.2346e+004

Console.WriteLine(value.ToString("E", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays 1,234568E+004
```

## The Fixed-Point ("F") Format Specifier

The fixed-point ("F) format specifier converts a number to a string of the form "-ddd.ddd…" where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. 

The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the current [NumberFormatInfo.NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) property supplies the numeric precision.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the properties of the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[NumberFormatInfo.NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) | Defines the default number of decimal digits. This value can be overridden by using the precision specifier.

The following example formats a [Double](http://dotnet.github.io/api/System.Double.html) and an [Int32](http://dotnet.github.io/api/System.Int32.html) value with the fixed-point format specifier.

```csharp
int integerNumber;
integerNumber = 17843;
Console.WriteLine(integerNumber.ToString("F", 
                  CultureInfo.InvariantCulture));
// Displays 17843.00

integerNumber = -29541;
Console.WriteLine(integerNumber.ToString("F3", 
                  CultureInfo.InvariantCulture));
// Displays -29541.000

double doubleNumber;
doubleNumber = 18934.1879;
Console.WriteLine(doubleNumber.ToString("F", CultureInfo.InvariantCulture));
// Displays 18934.19

Console.WriteLine(doubleNumber.ToString("F0", CultureInfo.InvariantCulture));
// Displays 18934

doubleNumber = -1898300.1987;
Console.WriteLine(doubleNumber.ToString("F1", CultureInfo.InvariantCulture));  
// Displays -1898300.2

Console.WriteLine(doubleNumber.ToString("F3", 
                  CultureInfo.CreateSpecificCulture("es-ES")));
// Displays -1898300,199 
```

## The General ("G") Format Specifier

The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific notation, depending on the type of the number and whether a precision specifier is present. The precision specifier defines the maximum number of significant digits that can appear in the result string. If the precision specifier is omitted or zero, the type of the number determines the default precision, as indicated in the following table. 

Numeric type | Default precision
------------ | -----------------
[Byte](http://dotnet.github.io/api/System.Byte.html) or [SByte](http://dotnet.github.io/api/System.SByte.html) | 3 digits
[Int16](http://dotnet.github.io/api/System.Int16.html) or [UInt16](http://dotnet.github.io/api/System.UInt16.html) | 5 digits
[Int32](http://dotnet.github.io/api/System.Int32.html) or [UInt32](http://dotnet.github.io/api/System.UInt32.html) | 10 digits
[Int64](http://dotnet.github.io/api/System.Int64.html) | 19 digits
[UInt64](http://dotnet.github.io/api/System.UInt64.html) | 20 digits
[BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html) | Unlimited (same as "R")
[Single](http://dotnet.github.io/api/System.Single.html) | 7 digits
[Double](http://dotnet.github.io/api/System.Double.html) | 15 digits
[Decimal](http://dotnet.github.io/api/System.Decimal.html) | 29 digits

Fixed-point notation is used if the exponent that would result from expressing the number in scientific notation is greater than -5 and less than the precision specifier; otherwise, scientific notation is used. The result contains a decimal point if required, and trailing zeros after the decimal point are omitted. If the precision specifier is present and the number of significant digits in the result exceeds the specified precision, the excess trailing digits are removed by rounding. 

However, if the number is a [Decimal](http://dotnet.github.io/api/System.Decimal.html) and the precision specifier is omitted, fixed-point notation is always used and trailing zeros are preserved.

If scientific notation is used, the exponent in the result is prefixed with "E" if the format specifier is "G", or "e" if the format specifier is "g". The exponent contains a minimum of two digits. This differs from the format for scientific notation that is produced by the exponential format specifier, which includes a minimum of three digits in the exponent.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[PositiveSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PositiveSign) | Defines the string that indicates that an exponent is positive. 

The following example formats assorted floating-point values with the general format specifier.

```csharp
double number;

number = 12345.6789;      
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
// Displays  12345.6789
Console.WriteLine(number.ToString("G", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays 12345,6789

Console.WriteLine(number.ToString("G7", CultureInfo.InvariantCulture));
// Displays 12345.68 

number = .0000023;
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
// Displays 2.3E-06       
Console.WriteLine(number.ToString("G", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays 2,3E-06

number = .0023;
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture));
// Displays 0.0023

number = 1234;
Console.WriteLine(number.ToString("G2", CultureInfo.InvariantCulture));
// Displays 1.2E+03

number = Math.PI;
Console.WriteLine(number.ToString("G5", CultureInfo.InvariantCulture));
// Displays 3.1416    
```

## The Numeric ("N") Format Specifier

The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "." indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, the number of decimal places is defined by the current [NumberFormatInfo.NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) property.

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative.
[NumberNegativePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberNegativePattern) | Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the [NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) property.
[NumberGroupSizes](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberGroupSizes) | Defines the number of integral digits that appear between group separators.
[NumberGroupSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberGroupSeparator) | Defines the string that separates groups of integral numbers.
[NumberDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[NumberDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalDigits) | Defines the default number of decimal digits. This value can be overridden by using a precision specifier.

The following example formats assorted floating-point values with the number format specifier.

```csharp
double dblValue = -12445.6789;
Console.WriteLine(dblValue.ToString("N", CultureInfo.InvariantCulture));
// Displays -12,445.68
Console.WriteLine(dblValue.ToString("N1", 
                  CultureInfo.CreateSpecificCulture("sv-SE")));
// Displays -12 445,7

int intValue = 123456789;
Console.WriteLine(intValue.ToString("N1", CultureInfo.InvariantCulture));
// Displays 123,456,789.0 
```

## The Percent ("P") Format Specifier

The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the default numeric precision supplied by the current [PercentDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentDecimalDigits) property is used.

The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

umberFormatInfo property | Description
------------------------- | -----------
[PercentPositivePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentPositivePattern) | Defines the placement of the percent symbol for positive values.
[PercentNegativePattern](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentNegativePattern) | 
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative.
[PercentSymbol](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentSymbol) | Defines the percent symbol.
[PercentDecimalDigits](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentDecimalDigits) | Defines the default number of decimal digits in a percentage value. This value can be overridden by using the precision specifier.
[PercentDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentDecimalSeparator) | Defines the string that separates integral and decimal digits.
[PercentGroupSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentGroupSeparator) | Defines the string that separates groups of integral numbers. 
[PercentGroupSizes](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PercentGroupSizes) | Defines the number of integer digits that appear in a group.

The following example formats floating-point values with the percent format specifier.

```csharp
double number = .2468013;
Console.WriteLine(number.ToString("P", CultureInfo.InvariantCulture));
// Displays 24.68 %
Console.WriteLine(number.ToString("P", 
                  CultureInfo.CreateSpecificCulture("hr-HR")));
// Displays 24,68%     
Console.WriteLine(number.ToString("P1", CultureInfo.InvariantCulture));
// Displays 24.7 %
```

## The Round-trip ("R") Format Specifier

The round-trip ("R") format specifier is used to ensure that a numeric value that is converted to a string will be parsed back into the same numeric value. This format is supported only for the [Single](http://dotnet.github.io/api/System.Single.html), [Double](http://dotnet.github.io/api/System.Double.html), and [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html) types. 

When a [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html) value is formatted using this specifier, its string representation contains all the significant digits in the [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html) value. When a [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) value is formatted using this specifier, it is first tested using the general format, with 15 digits of precision for a [Double](http://dotnet.github.io/api/System.Double.html) and 7 digits of precision for a [Single](http://dotnet.github.io/api/System.Single.html). If the value is successfully parsed back to the same numeric value, it is formatted using the general format specifier. If the value is not successfully parsed back to the same numeric value, it is formatted using 17 digits of precision for a [Double](http://dotnet.github.io/api/System.Double.html) and 9 digits of precision for a [Single](http://dotnet.github.io/api/System.Single.html). 

Although you can include a precision specifier, it is ignored. Round trips are given precedence over precision when using this specifier. 

The result string is affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[PositiveSign](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PositiveSign) | Defines the string that indicates that an exponent is positive.

 The following example formats [Double](http://dotnet.github.io/api/System.Double.html) values with the round-trip format specifier.

```csharp
double value;

value = Math.PI;
Console.WriteLine(value.ToString("r"));
// Displays 3.1415926535897931
Console.WriteLine(value.ToString("r", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays 3,1415926535897931
value = 1.623e-21;
Console.WriteLine(value.ToString("r"));
// Displays 1.623E-21
```

## The Hexadecimal ("X") Format Specifier

The hexadecimal ("X") format specifier converts a number to a string of hexadecimal digits. The case of the format specifier indicates whether to use uppercase or lowercase characters for hexadecimal digits that are greater than 9. For example, use "X" to produce "ABCDEF", and "x" to produce "abcdef". This format is supported only for integral types.

The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.

The result string is not affected by the formatting information of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object. 

The following example formats [Int32](http://dotnet.github.io/api/System.Int32.html) values with the hexadecimal format specifier.

```csharp
int value; 

value = 0x2045e;
Console.WriteLine(value.ToString("x"));
// Displays 2045e
Console.WriteLine(value.ToString("X"));
// Displays 2045E
Console.WriteLine(value.ToString("X8"));
// Displays 0002045E

value = 123456789;
Console.WriteLine(value.ToString("X"));
// Displays 75BCD15
Console.WriteLine(value.ToString("X2"));
// Displays 75BCD15
```

## Notes

### NumberFormatInfo Properties

Formatting is influenced by the properties of the current [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object, which is provided implicitly by the current thread culture or explicitly by the [IFormatProvider](http://dotnet.github.io/api/System.IFormatProvider.html) parameter of the method that invokes formatting. Specify a [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) or [CultureInfo](http://dotnet.github.io/api/System.Globalization.CultureInfo.html) object for that parameter. 

### Integral and Floating-Point Numeric Types

Some descriptions of standard numeric format specifiers refer to integral or floating-point numeric types. The integral numeric types are [Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), and [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html). The floating-point numeric types are [Decimal](http://dotnet.github.io/api/System.Decimal.html), [Single](http://dotnet.github.io/api/System.Single.html), and [Double](http://dotnet.github.io/api/System.Double.html). 

### Floating-Point Infinities and NaN

Regardless of the format string, if the value of a [Single](http://dotnet.github.io/api/System.Single.html) or [Double](http://dotnet.github.io/api/System.Double.html) floating-point type is positive infinity, negative infinity, or not a number (NaN), the formatted string is the value of the respective [PositiveInfinitySymbol](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_PositiveInfinitySymbol), [NegativeInfinitySymbol](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NegativeInfinitySymbol), or [NaNSymbol](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NaNSymbol) property that is specified by the currently applicable [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo) object.

## Example

The following example formats an integral and a floating-point numeric value using the en-US culture and all the standard numeric format specifiers. This example uses two particular numeric types ([Double](http://dotnet.github.io/api/System.Double.html) and [Int32](http://dotnet.github.io/api/System.Int32.html)), but would yield similar results for any of the other numeric base types ([Byte](http://dotnet.github.io/api/System.Byte.html), [SByte](http://dotnet.github.io/api/System.SByte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [Int64](http://dotnet.github.io/api/System.Int64.html), [UInt16](http://dotnet.github.io/api/System.UInt16.html), [UInt32](http://dotnet.github.io/api/System.UInt32.html), [UInt64](http://dotnet.github.io/api/System.UInt64.html), and [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html), [Decimal](http://dotnet.github.io/api/System.Decimal.html), and [Single](http://dotnet.github.io/api/System.Single.html)). 

```csharp
using System;
using System.Globalization;
using System.Threading;

public class NumericFormats
{
   public static void Main()
   {
      // Display string representations of numbers for en-us culture
      CultureInfo ci = new CultureInfo("en-us");

      // Output floating point values
      double floating = 10761.937554;
      Console.WriteLine("C: {0}", 
              floating.ToString("C", ci));           // Displays "C: $10,761.94"
      Console.WriteLine("E: {0}", 
              floating.ToString("E03", ci));         // Displays "E: 1.076E+004"
      Console.WriteLine("F: {0}", 
              floating.ToString("F04", ci));         // Displays "F: 10761.9376"         
      Console.WriteLine("G: {0}",  
              floating.ToString("G", ci));           // Displays "G: 10761.937554"
      Console.WriteLine("N: {0}", 
              floating.ToString("N03", ci));         // Displays "N: 10,761.938"
      Console.WriteLine("P: {0}", 
              (floating/10000).ToString("P02", ci)); // Displays "P: 107.62 %"
      Console.WriteLine("R: {0}", 
              floating.ToString("R", ci));           // Displays "R: 10761.937554"            
      Console.WriteLine();

      // Output integral values
      int integral = 8395;
      Console.WriteLine("C: {0}", 
              integral.ToString("C", ci));           // Displays "C: $8,395.00"
      Console.WriteLine("D: {0}", 
              integral.ToString("D6", ci));          // Displays "D: 008395" 
      Console.WriteLine("E: {0}", 
              integral.ToString("E03", ci));         // Displays "E: 8.395E+003"
      Console.WriteLine("F: {0}", 
              integral.ToString("F01", ci));         // Displays "F: 8395.0"    
      Console.WriteLine("G: {0}",  
              integral.ToString("G", ci));           // Displays "G: 8395"
      Console.WriteLine("N: {0}", 
              integral.ToString("N01", ci));         // Displays "N: 8,395.0"
      Console.WriteLine("P: {0}", 
              (integral/10000.0).ToString("P02", ci)); // Displays "P: 83.95 %"
      Console.WriteLine("X: 0x{0}", 
              integral.ToString("X", ci));           // Displays "X: 0x20CB"
      Console.WriteLine();
   }
}
```

## See Also

[System.Globalization.NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo)

[Custom Numeric Format Strings](customnumeric.md)

[Formatting Types](../formattingtypes.md)

[How to: Pad a Number with Leading Zeros](../padnumber.md)

[Composite Formatting](compositeformat.md)
