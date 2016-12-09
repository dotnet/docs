---
title: Standard numeric format strings
description: Standard numeric format strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 285faf73-466a-4af0-8eba-7e509958f240
---

# Standard numeric format strings

Standard numeric format strings are used to format common numeric types. A standard numeric format string takes the form **A**_xx_, where: 

* **A** is a single alphabetic character called the *format specifier*. Any numeric format string that contains more than one alphabetic character, including white space, is interpreted as a custom numeric format string. For more information, see [Custom Numeric Format Strings](custom-numeric.md). 

* *xx* is an optional integer called the *precision specifier*. The precision specifier ranges from 0 to 99 and affects the number of digits in the result. Note that the precision specifier controls the number of digits in the string representation of a number. It does not round the number itself. To perform a rounding operation, use the [Math.Ceiling](xref:System.Math), [Math.Floor](xref:System.Math), or [Math.Round](xref:System.Math) methods. 

When *precision specifier* controls the number of fractional digits in the result string, the result strings reflect numbers that are rounded away from zero (that is, using [MidpointRounding.AwayFromZero](xref:System.MidpointRounding.AwayFromZero)). 

> [!NOTE]
> The precision specifier determines the number of digits in the result string. To pad a result string with leading or trailing spaces, use the [composite formatting](composite-format.md) feature and define an *alignment component* in the format item. 

Standard numeric format strings are supported by some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the [ToString(String)](xref:System.Int32.ToString(System.String)) and [ToString(String, IFormatProvider)](xref:System.Int32.ToString(System.String,System.IFormatProvider)) methods of the [Int32](xref:System.Int32) type. Standard numeric format strings are also supported by the .NET [composite formatting](composite-format.md) feature, which is used by some `Write` and `WriteLine` methods of the [Console](xref:System.Console) and [StreamWriter](xref:System.IO.StreamWriter) classes, the [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)) method, and the [StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)) method. The composite format feature allows you to include the string representation of multiple data items in a single string, to specify field width, and to align numbers in a field. For more information, see [Composite Formatting](composite-format.md). 

The following table describes the standard numeric format specifiers and displays sample output produced by each format specifier. See the [Notes](#notes) section for additional information about using standard numeric format strings, and the [Example](#example) section for a comprehensive illustration of their use.

|Format specifier|Name|Description|Examples|  
|----------------------|----------|-----------------|--------------|  
|"C" or "c"|Currency|Result: A currency value.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: Defined by [NumberFormatInfo.CurrencyDecimalDigits](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits).<br /><br /> |123.456 ("C", en-US) -> $123.46<br /><br /> 123.456 ("C", fr-FR) -> 123,46 €<br /><br /> 123.456 ("C", ja-JP) -> ¥123<br /><br /> -123.456 ("C3", en-US) -> ($123.456)<br /><br /> -123.456 ("C3", fr-FR) -> -123,456 €<br /><br /> -123.456 ("C3", ja-JP) -> -¥123.456|  
|"D" or "d"|Decimal|Result: Integer digits with optional negative sign.<br /><br /> Supported by: Integral types only.<br /><br /> Precision specifier: Minimum number of digits.<br /><br /> Default precision specifier: Minimum number of digits required.<br /><br /> |1234 ("D") -> 1234<br /><br /> -1234 ("D6") -> -001234|  
|"E" or "e"|Exponential (scientific)|Result: Exponential notation.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: 6.<br /><br /> |1052.0329112756 ("E", en-US) -> 1.052033E+003<br /><br /> 1052.0329112756 ("e", fr-FR) -> 1,052033e+003<br /><br /> -1052.0329112756 ("e2", en-US) -> -1.05e+003<br /><br /> -1052.0329112756 ("E2", fr_FR) -> -1,05E+003|  
|"F" or "f"|Fixed-point|Result: Integral and decimal digits with optional negative sign.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: Defined by [NumberFormatInfo.NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits).<br /><br /> |1234.567 ("F", en-US) -> 1234.57<br /><br /> 1234.567 ("F", de-DE) -> 1234,57<br /><br /> 1234 ("F1", en-US) -> 1234.0<br /><br /> 1234 ("F1", de-DE) -> 1234,0<br /><br /> -1234.56 ("F4", en-US) -> -1234.5600<br /><br /> -1234.56 ("F4", de-DE) -> -1234,5600|  
|"G" or "g"|General|Result: The more compact of either fixed-point or scientific notation.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of significant digits.<br /><br /> Default precision specifier: Depends on numeric type.<br /><br /> |-123.456 ("G", en-US) -> -123.456<br /><br /> -123.456 ("G", sv-SE) -> -123,456<br /><br /> 123.4546 ("G4", en-US) -> 123.5<br /><br /> 123.4546 ("G4", sv-SE) -> 123,5<br /><br /> -1.234567890e-25 ("G", en-US) -> -1.23456789E-25<br /><br /> -1.234567890e-25 ("G", sv-SE) -> -1,23456789E-25|  
|"N" or "n"|Number|Result: Integral and decimal digits, group separators, and a decimal separator with optional negative sign.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Desired number of decimal places.<br /><br /> Default precision specifier: Defined by [NumberFormatInfo.NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits).<br /><br /> |1234.567 ("N", en-US) -> 1,234.57<br /><br /> 1234.567 ("N", ru-RU) -> 1 234,57<br /><br /> 1234 ("N1", en-US) -> 1,234.0<br /><br /> 1234 ("N1", ru-RU) -> 1 234,0<br /><br /> -1234.56 ("N3", en-US) -> -1,234.560<br /><br /> -1234.56 ("N3", ru-RU) -> -1 234,560|  
|"P" or "p"|Percent|Result: Number multiplied by 100 and displayed with a percent symbol.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Desired number of decimal places.<br /><br /> Default precision specifier: Defined by  [NumberFormatInfo.PercentDecimalDigits](xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits).<br /><br /> |1 ("P", en-US) -> 100.00 %<br /><br /> 1 ("P", fr-FR) -> 100,00 %<br /><br /> -0.39678 ("P1", en-US) -> -39.7 %<br /><br /> -0.39678 ("P1", fr-FR) -> -39,7 %|  
|"R" or "r"|Round-trip|Result: A string that can round-trip to an identical number.<br /><br /> Supported by: [Single](xref:System.Single), [Double](xref:System.Double), and [BigInteger](xref:System.Numerics.BigInteger).<br /><br /> Precision specifier: Ignored.<br /><br /> |123456789.12345678 ("R") -> 123456789.12345678<br /><br /> -1234567890.12345678 ("R") -> -1234567890.1234567|  
|"X" or "x"|Hexadecimal|Result: A hexadecimal string.<br /><br /> Supported by: Integral types only.<br /><br /> Precision specifier: Number of digits in the result string.<br /><br /> |255 ("X") -> FF<br /><br /> -1 ("x") -> ff<br /><br /> 255 ("x4") -> 00ff<br /><br /> -1 ("X4") -> 00FF|  
|Any other single character|Unknown specifier|Result: Throws a [FormatException](xref:System.FormatException) at run time.|| 

## Using standard numeric format strings

A standard numeric format string can be used to define the formatting of a numeric value in one of two ways:

* It can be passed to an overload of the `ToString` method that has a *format* parameter. The following example formats a numeric value as a currency string in the current (in this case, the en-US) culture. 

  ```csharp
  decimal value = 123.456m;
  Console.WriteLine(value.ToString("C2"));
  // Displays $123.46
  ```

  ```vb
  Dim value As Decimal = 123.456d
  Console.WriteLine(value.ToString("C2"))         
  ' Displays $123.46
  ```
  
* It can be supplied as the *formatString* argument in a format item used with such methods as [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)), [Console.WriteLine](xref:System.Console.WriteLine), and [StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)). For more information, see [Composite Formatting](composite-format.md). The following example uses a format item to insert a currency value in a string.

  ```csharp
  decimal value = 123.456m;
  Console.WriteLine("Your account balance is {0:C2}.", value);
  // Displays "Your account balance is $123.46."
  ```

  ```vb
  Dim value As Decimal = 123.456d
  Console.WriteLine("Your account balance is {0:C2}.", value)
  ' Displays "Your account balance is $123.46."
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

  ```vb
  Dim amounts() As Decimal = { 16305.32d, 18794.16d }
  Console.WriteLine("   Beginning Balance           Ending Balance")
  Console.WriteLine("   {0,-28:C2}{1,14:C2}", amounts(0), amounts(1))
  ' Displays:
  '        Beginning Balance           Ending Balance
  '        $16,305.32                      $18,794.16
  ```
  
The following sections provide detailed information about each of the standard numeric format strings.

## The currency ("C") format specifier

The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The precision specifier indicates the desired number of decimal places in the result string. If the precision specifier is omitted, the default precision is defined by the [NumberFormatInfo.CurrencyDecimalDigits](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits) property.

If the value to be formatted has more than the specified or default number of decimal places, the fractional value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or greater, the last digit in the result string is rounded away from zero.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

NumberFormatInfo property | Description
------------------------- | -----------
[CurrencyPositivePattern](xref:System.Globalization.NumberFormatInfo.CurrencyPositivePattern) | Defines the placement of the currency symbol for positive values.
[CurrencyNegativePattern](xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern) | Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the [NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) property.
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the negative sign used if [CurrencyNegativePattern](xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern) indicates that parentheses are not used. 
[CurrencySymbol](xref:System.Globalization.NumberFormatInfo.CurrencySymbol) | Defines the currency symbol.
[CurrencyDecimalDigits](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits) | Defines the default number of decimal digits in a currency value. This value can be overridden by using the precision specifier.
[CurrencyDecimalSeparator](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator) | Defines the string that separates integral and decimal digits.
[CurrencyGroupSeparator](xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator) | Defines the string that separates groups of integral numbers. 
[CurrencyGroupSizes](xref:System.Globalization.NumberFormatInfo.CurrencyGroupSizes) | Defines the number of integer digits that appear in a group.

The following example formats a [Double](xref:System.Double) value with the currency format specifier. 

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

```vb
Dim value As Double = 12345.6789
Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture))

Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture))

Console.WriteLine(value.ToString("C3", _
                  CultureInfo.CreateSpecificCulture("da-DK")))
' The example displays the following output on a system whose
' current culture is English (United States):
'       $12,345.68
'       $12,345.679
'       kr 12.345,679
```

## The decimal ("D") format specifier

The "D" (or decimal) format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign if the number is negative. This format is supported only for integral types.

The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier. If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. As the following table shows, a single property affects the formatting of the result string. 

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative. 

The following example formats an [Int32](xref:System.Int32) value with the decimal format specifier.

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

```vb
Dim value As Integer 

value = 12345
Console.WriteLine(value.ToString("D"))
' Displays 12345   
Console.WriteLine(value.ToString("D8"))
' Displays 00012345

value = -12345
Console.WriteLine(value.ToString("D"))
' Displays -12345
Console.WriteLine(value.ToString("D8"))
' Displays -00012345
```

## The exponential ("E") format specifier

The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd", where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one digit always precedes the decimal point. 

The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, a default of six digits after the decimal point is used. 

The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet this minimum, if required.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative for both the coefficient and exponent. 
[NumberDecimalSeparator](xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator) | Defines the string that separates the integral digit from decimal digits in the coefficient.
[PositiveSign](xref:System.Globalization.NumberFormatInfo.PositiveSign) | Defines the string that indicates that an exponent is positive.

The following example formats a [Double](xref:System.Double) value with the exponential format specifier. 

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

```vb
Dim value As Double = 12345.6789
Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture))
' Displays 1.234568E+004

Console.WriteLine(value.ToString("E10", CultureInfo.InvariantCulture))
' Displays 1.2345678900E+004

Console.WriteLine(value.ToString("e4", CultureInfo.InvariantCulture))
' Displays 1.2346e+004

Console.WriteLine(value.ToString("E", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays 1,234568E+004
```

## The fixed-point ("F") format specifier

The fixed-point ("F) format specifier converts a number to a string of the form "-ddd.ddd…" where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. 

The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the current [NumberFormatInfo.NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits) property supplies the numeric precision.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the properties of the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[NumberFormatInfo.NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits) | Defines the default number of decimal digits. This value can be overridden by using the precision specifier.

The following example formats a [Double](xref:System.Double) and an [Int32](xref:System.Int32) value with the fixed-point format specifier.

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

```vb
Dim integerNumber As Integer
integerNumber = 17843
Console.WriteLine(integerNumber.ToString("F", CultureInfo.InvariantCulture))
' Displays 17843.00

integerNumber = -29541
Console.WriteLine(integerNumber.ToString("F3", CultureInfo.InvariantCulture))
' Displays -29541.000

Dim doubleNumber As Double
doubleNumber = 18934.1879
Console.WriteLine(doubleNumber.ToString("F", CultureInfo.InvariantCulture))
' Displays 18934.19

Console.WriteLine(doubleNumber.ToString("F0", CultureInfo.InvariantCulture))
' Displays 18934

doubleNumber = -1898300.1987
Console.WriteLine(doubleNumber.ToString("F1", CultureInfo.InvariantCulture))  
' Displays -1898300.2

Console.WriteLine(doubleNumber.ToString("F3", _ 
                  CultureInfo.CreateSpecificCulture("es-ES")))
' Displays -1898300,199                        
```

## The general ("G") format specifier

The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific notation, depending on the type of the number and whether a precision specifier is present. The precision specifier defines the maximum number of significant digits that can appear in the result string. If the precision specifier is omitted or zero, the type of the number determines the default precision, as indicated in the following table. 

Numeric type | Default precision
------------ | -----------------
[Byte](xref:System.Byte) or [SByte](xref:System.SByte) | 3 digits
[Int16](xref:System.Int16) or [UInt16](xref:System.UInt16) | 5 digits
[Int32](xref:System.Int32) or [UInt32](xref:System.UInt32) | 10 digits
[Int64](xref:System.Int64) | 19 digits
[UInt64](xref:System.UInt64) | 20 digits
[BigInteger](xref:System.Numerics.BigInteger) | Unlimited (same as "R")
[Single](xref:System.Single) | 7 digits
[Double](xref:System.Double) | 15 digits
[Decimal](xref:System.Decimal) | 29 digits

Fixed-point notation is used if the exponent that would result from expressing the number in scientific notation is greater than -5 and less than the precision specifier; otherwise, scientific notation is used. The result contains a decimal point if required, and trailing zeros after the decimal point are omitted. If the precision specifier is present and the number of significant digits in the result exceeds the specified precision, the excess trailing digits are removed by rounding. 

However, if the number is a [Decimal](xref:System.Decimal) and the precision specifier is omitted, fixed-point notation is always used and trailing zeros are preserved.

If scientific notation is used, the exponent in the result is prefixed with "E" if the format specifier is "G", or "e" if the format specifier is "g". The exponent contains a minimum of two digits. This differs from the format for scientific notation that is produced by the exponential format specifier, which includes a minimum of three digits in the exponent.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[PositiveSign](xref:System.Globalization.NumberFormatInfo.PositiveSign) | Defines the string that indicates that an exponent is positive. 

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

```vb
Dim number As Double

number = 12345.6789      
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
' Displays  12345.6789
Console.WriteLine(number.ToString("G", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays 12345,6789

Console.WriteLine(number.ToString("G7", CultureInfo.InvariantCulture))
' Displays 12345.68 

number = .0000023
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
' Displays 2.3E-06       
Console.WriteLine(number.ToString("G", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays 2,3E-06

number = .0023
Console.WriteLine(number.ToString("G", CultureInfo.InvariantCulture))
' Displays 0.0023

number = 1234
Console.WriteLine(number.ToString("G2", CultureInfo.InvariantCulture))
' Displays 1.2E+03

number = Math.Pi
Console.WriteLine(number.ToString("G5", CultureInfo.InvariantCulture))
' Displays 3.1416
```

## The numeric ("N") format specifier

The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "." indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, the number of decimal places is defined by the current [NumberFormatInfo.NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits) property.

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative.
[NumberNegativePattern](xref:System.Globalization.NumberFormatInfo.NumberNegativePattern) | Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the [NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) property.
[NumberGroupSizes](xref:System.Globalization.NumberFormatInfo.NumberGroupSizes) | Defines the number of integral digits that appear between group separators.
[NumberGroupSeparator](xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator) | Defines the string that separates groups of integral numbers.
[NumberDecimalSeparator](xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[NumberDecimalDigits](xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits) | Defines the default number of decimal digits. This value can be overridden by using a precision specifier.

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

```vb
Dim dblValue As Double = -12445.6789
Console.WriteLine(dblValue.ToString("N", CultureInfo.InvariantCulture))
' Displays -12,445.68
Console.WriteLine(dblValue.ToString("N1", _
                  CultureInfo.CreateSpecificCulture("sv-SE")))
' Displays -12 445,7

Dim intValue As Integer = 123456789
Console.WriteLine(intValue.ToString("N1", CultureInfo.InvariantCulture))
' Displays 123,456,789.0 
```

## The percent ("P") format specifier

The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the default numeric precision supplied by the current [PercentDecimalDigits](xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits) property is used.

The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the returned string.

umberFormatInfo property | Description
------------------------- | -----------
[PercentPositivePattern](xref:System.Globalization.NumberFormatInfo.PercentPositivePattern) | Defines the placement of the percent symbol for positive values.
[PercentNegativePattern](xref:System.Globalization.NumberFormatInfo.PercentNegativePattern) | 
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative.
[PercentSymbol](xref:System.Globalization.NumberFormatInfo.PercentSymbol) | Defines the percent symbol.
[PercentDecimalDigits](xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits) | Defines the default number of decimal digits in a percentage value. This value can be overridden by using the precision specifier.
[PercentDecimalSeparator](xref:System.Globalization.NumberFormatInfo.PercentDecimalSeparator) | Defines the string that separates integral and decimal digits.
[PercentGroupSeparator](xref:System.Globalization.NumberFormatInfo.PercentGroupSeparator) | Defines the string that separates groups of integral numbers. 
[PercentGroupSizes](xref:System.Globalization.NumberFormatInfo.PercentGroupSizes) | Defines the number of integer digits that appear in a group.

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

```vb
Dim number As Double = .2468013
Console.WriteLine(number.ToString("P", CultureInfo.InvariantCulture))
' Displays 24.68 %
Console.WriteLine(number.ToString("P", _
                  CultureInfo.CreateSpecificCulture("hr-HR")))
' Displays 24,68%     
Console.WriteLine(number.ToString("P1", CultureInfo.InvariantCulture))
' Displays 24.7 %
```

## The round-trip ("R") format specifier

The round-trip ("R") format specifier is used to ensure that a numeric value that is converted to a string will be parsed back into the same numeric value. This format is supported only for the [Single](xref:System.Single), [Double](xref:System.Double), and [BigInteger](xref:System.Numerics.BigInteger) types. 

When a [BigInteger](xref:System.Numerics.BigInteger) value is formatted using this specifier, its string representation contains all the significant digits in the [BigInteger](xref:System.Numerics.BigInteger) value. When a [Single](xref:System.Single) or [Double](xref:System.Double) value is formatted using this specifier, it is first tested using the general format, with 15 digits of precision for a [Double](xref:System.Double) and 7 digits of precision for a [Single](xref:System.Single). If the value is successfully parsed back to the same numeric value, it is formatted using the general format specifier. If the value is not successfully parsed back to the same numeric value, it is formatted using 17 digits of precision for a [Double](xref:System.Double) and 9 digits of precision for a [Single](xref:System.Single). 

Although you can include a precision specifier, it is ignored. Round trips are given precedence over precision when using this specifier. 

The result string is affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. The following table lists the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) properties that control the formatting of the result string.

NumberFormatInfo property | Description
------------------------- | -----------
[NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) | Defines the string that indicates that a number is negative.
[NumberDecimalSeparator](xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator) | Defines the string that separates integral digits from decimal digits.
[PositiveSign](xref:System.Globalization.NumberFormatInfo.PositiveSign) | Defines the string that indicates that an exponent is positive.

 The following example formats [Double](xref:System.Double) values with the round-trip format specifier.

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

```vb
Dim value As Double

value = Math.Pi
Console.WriteLine(value.ToString("r"))
' Displays 3.1415926535897931
Console.WriteLine(value.ToString("r", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays 3,1415926535897931
value = 1.623e-21
Console.WriteLine(value.ToString("r"))
' Displays 1.623E-21
```

## The hexadecimal ("X") format specifier

The hexadecimal ("X") format specifier converts a number to a string of hexadecimal digits. The case of the format specifier indicates whether to use uppercase or lowercase characters for hexadecimal digits that are greater than 9. For example, use "X" to produce "ABCDEF", and "x" to produce "abcdef". This format is supported only for integral types.

The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.

The result string is not affected by the formatting information of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object. 

The following example formats [Int32](xref:System.Int32) values with the hexadecimal format specifier.

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

```vb
Dim value As Integer 

value = &h2045e
Console.WriteLine(value.ToString("x"))
' Displays 2045e
Console.WriteLine(value.ToString("X"))
' Displays 2045E
Console.WriteLine(value.ToString("X8"))
' Displays 0002045E

value = 123456789
Console.WriteLine(value.ToString("X"))
' Displays 75BCD15
Console.WriteLine(value.ToString("X2"))
' Displays 75BCD15
```

## Notes

### NumberFormatInfo properties

Formatting is influenced by the properties of the current [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object, which is provided implicitly by the current thread culture or explicitly by the [IFormatProvider](xref:System.IFormatProvider) parameter of the method that invokes formatting. Specify a [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) or [CultureInfo](xref:System.Globalization.CultureInfo) object for that parameter. 

### Integral and floating-point numeric types

Some descriptions of standard numeric format specifiers refer to integral or floating-point numeric types. The integral numeric types are [Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [Int32](xref:System.Int32), [Int64](xref:System.Int64), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64), and [BigInteger](xref:System.Numerics.BigInteger). The floating-point numeric types are [Decimal](xref:System.Decimal), [Single](xref:System.Single), and [Double](xref:System.Double). 

### Floating-point infinities and NaN

Regardless of the format string, if the value of a [Single](xref:System.Single) or [Double](xref:System.Double) floating-point type is positive infinity, negative infinity, or not a number (NaN), the formatted string is the value of the respective [PositiveInfinitySymbol](xref:System.Globalization.NumberFormatInfo.PositiveInfinitySymbol), [NegativeInfinitySymbol](xref:System.Globalization.NumberFormatInfo.NegativeInfinitySymbol), or [NaNSymbol](xref:System.Globalization.NumberFormatInfo.NaNSymbol) property that is specified by the currently applicable [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object.

## Example

The following example formats an integral and a floating-point numeric value using the en-US culture and all the standard numeric format specifiers. This example uses two particular numeric types ([Double](xref:System.Double) and [Int32](xref:System.Int32)), but would yield similar results for any of the other numeric base types ([Byte](xref:System.Byte), [SByte](xref:System.SByte), [Int16](xref:System.Int16), [Int64](xref:System.Int64), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64), and [BigInteger](xref:System.Numerics.BigInteger), [Decimal](xref:System.Decimal), and [Single](xref:System.Single)). 

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

```vb
Option Strict On

Imports System.Globalization
Imports System.Threading

Module NumericFormats
   Public Sub Main()
      ' Display string representations of numbers for en-us culture
      Dim ci As New CultureInfo("en-us")

      ' Output floating point values
      Dim floating As Double = 10761.937554
      Console.WriteLine("C: {0}", _
              floating.ToString("C", ci))           ' Displays "C: $10,761.94"
      Console.WriteLine("E: {0}", _
              floating.ToString("E03", ci))         ' Displays "E: 1.076E+004"
      Console.WriteLine("F: {0}", _
              floating.ToString("F04", ci))         ' Displays "F: 10761.9376"         
      Console.WriteLine("G: {0}", _ 
              floating.ToString("G", ci))           ' Displays "G: 10761.937554"
      Console.WriteLine("N: {0}", _
              floating.ToString("N03", ci))         ' Displays "N: 10,761.938"
      Console.WriteLine("P: {0}", _
              (floating/10000).ToString("P02", ci)) ' Displays "P: 107.62 %"
      Console.WriteLine("R: {0}", _
              floating.ToString("R", ci))           ' Displays "R: 10761.937554"            
      Console.WriteLine()

      ' Output integral values
      Dim integral As Integer = 8395
      Console.WriteLine("C: {0}", _
              integral.ToString("C", ci))           ' Displays "C: $8,395.00"
      Console.WriteLine("D: {0}", _
              integral.ToString("D6"))              ' Displays "D: 008395" 
      Console.WriteLine("E: {0}", _
              integral.ToString("E03", ci))         ' Displays "E: 8.395E+003"
      Console.WriteLine("F: {0}", _
              integral.ToString("F01", ci))         ' Displays "F: 8395.0"    
      Console.WriteLine("G: {0}", _ 
              integral.ToString("G", ci))           ' Displays "G: 8395"
      Console.WriteLine("N: {0}", _
              integral.ToString("N01", ci))         ' Displays "N: 8,395.0"
      Console.WriteLine("P: {0}", _
              (integral/10000).ToString("P02", ci)) ' Displays "P: 83.95 %"
      Console.WriteLine("X: 0x{0}", _
              integral.ToString("X", ci))           ' Displays "X: 0x20CB"
      Console.WriteLine()
   End Sub
End Module
```

## See also

[System.Globalization.NumberFormatInfo](xref:System.Globalization.NumberFormatInfo)

[Custom numeric format strings](custom-numeric.md)

[Formatting types](formatting-types.md)

[How to: pad a number with leading zeros](pad-number.md)

[Composite formatting](composite-format.md)
