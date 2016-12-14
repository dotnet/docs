---
title: Formatting types
description: Formatting types
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: cf497639-9f91-45cb-836f-998d1cea2f43
---

# Formatting types

Formatting is the process of converting an instance of a class, structure, or enumeration value to its string representation, often so that the resulting string can be displayed to users or deserialized to restore the original data type. This conversion can pose a number of challenges:

* The way that values are stored internally does not necessarily reflect the way that users want to view them. For example, a telephone number might be stored in the form **8009999999**, which is not user-friendly. It should instead be displayed as **800-999-9999**. See the [Custom format strings](#custom-format-strings) section for an example that formats a number in this way. 

* Sometimes the conversion of an object to its string representation is not intuitive. For example, it is not clear how the string representation of a **Temperature** object or a **Person** object should appear. For an example that formats a **Temperature** object in a variety of ways, see the [Standard format strings](#standard-format-strings) section.

* Values often require culture-sensitive formatting. For example, in an application that uses numbers to reflect monetary values, numeric strings should include the current culture’s currency symbol, group separator (which, in most cultures, is the thousands separator), and decimal symbol. For an example, see the [Culture-sensitive formatting with format providers and the IFormatProvider interface](#culture-sensitive-formatting-with-format-providers-and-the-iformatprovider-interface) section. 

* An application may have to display the same value in different ways. For example, an application may represent an enumeration member by displaying a string representation of its name or by displaying its underlying value. For an example that formats a member of the [DayOfWeek](xref:System.DayOfWeek) enumeration in different ways, see the [Standard format strings](#standard-format-strings) section.

.NET provides rich formatting support that enables developers to address these requirements. 

> [!NOTE]
> Formatting converts the value of a type into a string representation. Parsing is the inverse of formatting. A parsing operation creates an instance of a data type from its string representation. For information about converting strings to other data types, see [Parsing strings](parsing-strings.md).

This overview contains the following sections:

* [Formatting in .NET](#formatting-in-net)

* [Default formatting using the ToString method](#default-formatting-using-the-tostring-method)

* [Overriding the ToString method](#overriding-the-tostring-method)

* [The ToString method and format strings](#the-tostring-method-and-format-strings)

    * [Standard format strings](#standard-format-strings)
    
    * [Custom format strings](#custom-format-strings)
    
    * [Format strings and .NET types](#format-strings-and-net-types)
    
* [Culture-sensitive formatting with format providers and the IFormatProvider interface](#culture-sensitive-formatting-with-format-providers-and-the-iformatprovider-interface)

    * [Culture-sensitive formatting of numeric values](#culture-sensitive-formatting-of-numeric-values)
    
    * [Culture-sensitive formatting of date and time values](#culture-sensitive-formatting-of-date-and-time-values)
    
* [The IFormattable interface](#the-iformattable-interface)

* [Composite formatting](#composite-formatting)

* [Custom formatting with ICustomFormatter](#custom-formatting-with-icustomformatter)

* [Related topics](#related-topics)

* [Reference](#reference)

## Formatting in .NET

The basic mechanism for formatting is the default implementation of the [Object.ToString](xref:System.Object.ToString) method, which is discussed in the [Default formatting using the ToString method](#default-formatting-using-the-tostring-method) section later in this topic. However, .NET provides several ways to modify and extend its default formatting support. These include the following:

* Overriding the [Object.ToString](xref:System.Object.ToString) method to define a custom string representation of an object’s value. For more information, see the [Overriding the ToString method](#overriding-the-tostring-method) section later in this topic.

* Defining format specifiers that enable the string representation of an object’s value to take multiple forms. For example, the "X" format specifier in the following statement converts an integer to the string representation of a hexadecimal value.

  ```csharp
  int integerValue = 60312;
  Console.WriteLine(integerValue.ToString("X"));   // Displays EB98.
  ```

  ```vb
  Dim integerValue As Integer = 60312
  Console.WriteLine(integerValue.ToString("X"))   ' Displays EB98.
  ```
  
  For more information about format specifiers, see the [The ToString method and format strings](#the-tostring-method-and-format-strings) section.
  
* Using format providers to take advantage of the formatting conventions of a specific culture. For example, the following statement displays a currency value by using the formatting conventions of the en-US culture. 

  ```csharp
  double cost = 1632.54; 
  Console.WriteLine(cost.ToString("C", 
                  new System.Globalization.CultureInfo("en-US")));   
  // The example displays the following output:
  //       $1,632.54
  ```

  ```vb
  Dim cost As Double = 1632.54
  Console.WriteLine(cost.ToString("C", New System.Globalization.CultureInfo("en-US")))
  ' The example displays the following output:
  '       $1,632.54
  ```
  
  For more information about formatting with format providers, see the [Culture-sensitive formatting with format providers and the IFormatProvider interface](#culture-sensitive-formatting-with-format-providers-and-the-iformatprovider-interface) section.  
  
* Implementing the [IFormattable](xref:System.IFormattable) interface to support both string conversion with the [Convert](xref:System.Convert) class and composite formatting. For more information, see the [The IFormattable interface](#the-iformattable-interface) section.

* Using composite formatting to embed the string representation of a value in a larger string. For more information, see the [Composite formatting](#composite-formatting) section.

* Implementing [ICustomFormatter](xref:System.ICustomFormatter) and [IFormatProvider](xref:System.IFormatProvider) to provide a complete custom formatting solution. For more information, see the [Custom formatting with ICustomFormatter](#custom-formatting-with-icustomformatter) section.

The following sections examine these methods for converting an object to its string representation.

## Default formatting using the ToString method

Every type that is derived from [System.Object](xref:System.Object) automatically inherits a parameterless [ToString](xref:System.Object.ToString) method, which returns the name of the type by default. The following example illustrates the default [ToString](xref:System.Object.ToString) method. It defines a class named `Automobile` that has no implementation. When the class is instantiated and its [ToString](xref:System.Object.ToString) method is called, it displays its type name. Note that the [ToString](xref:System.Object.ToString) method is not explicitly called in the example. The [Console.WriteLine(Object)](xref:System.Console.WriteLine(System.Object)) method implicitly calls the [ToString](xref:System.Object.ToString) method of the object passed to it as an argument. 

```csharp
using System;

public class Automobile
{
   // No implementation. All members are inherited from Object.
}

public class Example
{
   public static void Main()
   {
      Automobile firstAuto = new Automobile();
      Console.WriteLine(firstAuto);
   }
}
// The example displays the following output:
//       Automobile
```

```vb 
Public Class Automobile
   ' No implementation. All members are inherited from Object.
End Class

Module Example
   Public Sub Main()
      Dim firstAuto As New Automobile()
      Console.WriteLine(firstAuto)
   End Sub
End Module
' The example displays the following output:
'       Automobile
```

Because all types other than interfaces are derived from [Object](xref:System.Object), this functionality is automatically provided to your custom classes or structures. However, the functionality offered by the default [ToString](xref:System.Object.ToString) method, is limited: Although it identifies the type, it fails to provide any information about an instance of the type. To provide a string representation of an object that provides information about that object, you must override the [ToString](xref:System.Object.ToString) method.

> [!NOTE]
> Structures inherit from [ValueType](xref:System.ValueType), which in turn is derived from [Object](xref:System.Object). Although [ValueType](xref:System.ValueType) overrides [Object.ToString](xref:System.Object.ToString), its implementation is identical.

## Overriding the ToString method

Displaying the name of a type is often of limited use and does not allow consumers of your types to differentiate one instance from another. However, you can override the [ToString](xref:System.Object.ToString) method to provide a more useful representation of an object’s value. The following example defines a `Temperature` object and overrides its [ToString](xref:System.Object.ToString) method to display the temperature in degrees Celsius.

```csharp
using System;

public class Temperature
{
   private decimal temp;

   public Temperature(decimal temperature)
   {
      this.temp = temperature;   
   }

   public override string ToString()
   {
      return this.temp.ToString("N1") + "°C";
   }
}

public class Example
{
   public static void Main()
   {
      Temperature currentTemperature = new Temperature(23.6m);
      Console.WriteLine("The current temperature is " +
                        currentTemperature.ToString());
   }
}
// The example displays the following output:
//       The current temperature is 23.6°C.
```

```vb
Public Class Temperature
   Private temp As Decimal

   Public Sub New(temperature As Decimal)
      Me.temp = temperature
   End Sub

   Public Overrides Function ToString() As String
      Return Me.temp.ToString("N1") + "°C"   
   End Function
End Class

Module Example
   Public Sub Main()
      Dim currentTemperature As New Temperature(23.6d)
      Console.WriteLine("The current temperature is " +
                        currentTemperature.ToString())
   End Sub
End Module
' The example displays the following output:
'       The current temperature is 23.6°C.
```

In .NET, the [ToString](xref:System.Object.ToString) method of each primitive value type has been overridden to display the object’s value instead of its name. The following table shows the override for each primitive type. Note that most of the overridden methods call another overload of the [ToString](xref:System.Object.ToString) method and pass it the "G" format specifier, which defines the general format for its type, and an [IFormatProvider](xref:System.IFormatProvider) object that represents the current culture.

Type | ToString override
---- | -----------------
[Boolean](xref:System.Boolean) | Returns either [Boolean.TrueString](xref:System.Boolean.TrueString) or [Boolean.FalseString](xref:System.Boolean.FalseString).
[Byte](xref:System.Byte) | Calls `Byte.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Byte](xref:System.Byte) value for the current culture.
[Char](xref:System.Char) | Returns the character as a string.
[DateTime](xref:System.DateTime) | Calls `DateTime.ToString("G", DatetimeFormatInfo.CurrentInfo)` to format the date and time value for the current culture. 
[Decimal](xref:System.Decimal) | Calls `Decimal.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Decimal](xref:System.Decimal) value for the current culture.
[Double](xref:System.Double) | Calls `Double.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Double](xref:System.Double) value for the current culture.
[Int16](xref:System.Int16) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Int16](xref:System.Int16) value for the current culture.
[Int32](xref:System.Int32) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Int32](xref:System.Int32) value for the current culture.
[Int64](xref:System.Int64) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Int64](xref:System.Int64) value for the current culture.
[SByte](xref:System.SByte) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [SByte](xref:System.SByte) | value for the current culture.
[Single](xref:System.Single) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [Single](xref:System.Single) value for the current culture.
[UInt32](xref:System.UInt32) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [UInt32](xref:System.UInt32)value for the current culture.
[UInt32](xref:System.UInt32) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [UInt32](xref:System.UInt32) value for the current culture.
[UInt64](xref:System.UInt64) | Calls `Int16.ToString("G", NumberFormatInfo.CurrentInfo)` to format the [UInt64](xref:System.UInt64)  value for the current culture.

## The ToString method and format strings

Relying on the default [ToString](xref:System.Object.ToString) method or overriding [ToString](xref:System.Object.ToString) is appropriate when an object has a single string representation. However, the value of an object often has multiple representations. For example, a temperature can be expressed in degrees Fahrenheit, degrees Celsius, or kelvins. Similarly, the integer value 10 can be represented in numerous ways, including 10, 10.0, 1.0e01, or $10.00.

To enable a single value to have multiple string representations, .NET uses format strings. A format string is a string that contains one or more predefined format specifiers, which are single characters or groups of characters that define how the [ToString](xref:System.Object.ToString) method should format its output. The format string is then passed as a parameter to the object's [ToString](xref:System.Object.ToString) method and determines how the string representation of that object's value should appear.

All numeric types, date and time types, and enumeration types in .NET support a predefined set of format specifiers. You can also use format strings to define multiple string representations of your application-defined data types.

### Standard format strings

A standard format string contains a single format specifier, which is an alphabetic character that defines the string representation of the object to which it is applied, along with an optional precision specifier that affects how many digits are displayed in the result string. If the precision specifier is omitted or is not supported, a standard format specifier is equivalent to a standard format string. 

.NET defines a set of standard format specifiers for all numeric types, all date and time types, and all enumeration types. For example, each of these categories supports a "G" standard format specifier, which defines a general string representation of a value of that type.

Standard format strings for enumeration types directly control the string representation of a value. The format strings passed to an enumeration value’s [ToString](xref:System.Object.ToString) method determine whether the value is displayed using its string name (the "G" and "F" format specifiers), its underlying integral value (the "D" format specifier), or its hexadecimal value (the "X" format specifier). The following example illustrates the use of standard format strings to format a [DayOfWeek](xref:System.DayOfWeek) enumeration value. 

```csharp
DayOfWeek thisDay = DayOfWeek.Monday;
string[] formatStrings = {"G", "F", "D", "X"};

foreach (string formatString in formatStrings)
   Console.WriteLine(thisDay.ToString(formatString));
// The example displays the following output:
//       Monday
//       Monday
//       1
//       00000001
```

```vb
Dim thisDay As DayOfWeek = DayOfWeek.Monday
Dim formatStrings() As String = {"G", "F", "D", "X"}

For Each formatString As String In formatStrings
   Console.WriteLine(thisDay.ToString(formatString))
Next
' The example displays the following output:
'       Monday
'       Monday
'       1
'       00000001
```

For information about enumeration format strings, see [Enumeration format strings](enumeration-format.md).

Standard format strings for numeric types usually define a result string whose precise appearance is controlled by one or more property values. For example, the "C" format specifier formats a number as a currency value. When you call the [ToString](xref:System.Object.ToString) method with the "C" format specifier as the only parameter, the following property values from the current culture’s [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object are used to define the string representation of the numeric value:

* The [CurrencySymbol](xref:System.Globalization.NumberFormatInfo.CurrencySymbol) property, which specifies the current culture’s currency symbol.

* The [CurrencyNegativePattern](xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern) or [CurrencyPositivePattern](xref:System.Globalization.NumberFormatInfo.CurrencyPositivePattern) property, which returns an integer that determines the following: 

    * The placement of the currency symbol.
    
    * Whether negative values are indicated by a leading negative sign, a trailing negative sign, or parentheses.
    
    * Whether a space appears between the numeric value and the currency symbol.
    
* The [CurrencyDecimalDigits](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits) property, which defines the number of fractional digits in the result string.

* The [CurrencyDecimalSeparator](xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator) property, which defines the decimal separator symbol in the result string.

* The [CurrencyGroupSeparator](xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator) property, which defines the group separator symbol.

* The [CurrencyGroupSizes](xref:System.Globalization.NumberFormatInfo.CurrencyGroupSizes) property, which defines the number of digits in each group to the left of the decimal.

* The [NegativeSign](xref:System.Globalization.NumberFormatInfo.NegativeSign) property, which determines the negative sign used in the result string if parentheses are not used to indicate negative values.

In addition, numeric format strings may include a precision specifier. The meaning of this specifier depends on the format string with which it is used, but it typically indicates either the total number of digits or the number of fractional digits that should appear in the result string. For example, the following example uses the "X4" standard numeric string and a precision specifier to create a string value that has four hexadecimal digits.

```csharp
byte[] byteValues = { 12, 163, 255 };
foreach (byte byteValue in byteValues)
   Console.WriteLine(byteValue.ToString("X4"));
// The example displays the following output:
//       000C
//       00A3
//       00FF
```

```vb
Dim byteValues() As Byte = { 12, 163, 255 }
For Each byteValue As Byte In byteValues
   Console.WriteLine(byteValue.ToString("X4"))
Next
' The example displays the following output:
'       000C
'       00A3
'       00FF
```

For more information about standard numeric formatting strings, see [Standard numeric format strings](standard-numeric.md). 

Standard format strings for date and time values are aliases for custom format strings stored by a particular [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) class. For example, calling the [ToString](xref:System.Object.ToString) method of a date and time value with the "D" format specifier displays the date and time by using the custom format string stored in the current culture’s [DateTimeFormatInfo.LongDatePattern](xref:System.Globalization.DateTimeFormatInfo.LongDatePattern) property. (For more information about custom format strings, see the [Custom format strings](#custom-format-strings) section.) The following example illustrates this relationship.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2017, 6, 30);
      Console.WriteLine("D Format Specifier:     {0:D}", date1);
      string longPattern = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
      Console.WriteLine("'{0}' custom format string:     {1}", 
                        longPattern, date1.ToString(longPattern));
   }
}
// The example displays the following output when run on a system whose
// current culture is en-US:
//    D Format Specifier:     Tuesday, June 30, 2017
//    'dddd, MMMM dd, yyyy' custom format string:     Tuesday, June 30, 2017
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim date1 As Date = #6/30/2009#
      Console.WriteLine("D Format Specifier:     {0:D}", date1)
      Dim longPattern As String = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern
      Console.WriteLine("'{0}' custom format string:     {1}", _
                        longPattern, date1.ToString(longPattern))
   End Sub
End Module
' The example displays the following output when run on a system whose
' current culture is en-US:
'    D Format Specifier:     Tuesday, June 30, 2009
'    'dddd, MMMM dd, yyyy' custom format string:     Tuesday, June 30, 2009
```

For more information about standard date and time format strings, see [Standard date and time format strings](standard-datetime.md).

You can also use standard format strings to define the string representation of an application-defined object that is produced by the object’s `ToString(String)` method. You can define the specific standard format specifiers that your object supports, and you can determine whether they are case-sensitive or case-insensitive. Your implementation of the `ToString(String)` method should support the following:

* A "G" format specifier that represents a customary or common format of the object. The parameterless overload of your object's `ToString` method should call its `ToString(String)` overload and pass it the "G" standard format string.

* Support for a format specifier that is equal to a null reference. A format specifier that is equal to a null reference should be considered equivalent to the "G" format specifier.

For example, a `Temperature` class can internally store the temperature in degrees Celsius and use format specifiers to represent the value of the `Temperature` object in degrees Celsius, degrees Fahrenheit, and kelvins. The following example provides an illustration.

```csharp
using System;

public class Temperature
{
   private decimal m_Temp;

   public Temperature(decimal temperature)
   {
      this.m_Temp = temperature;
   }

   public decimal Celsius
   {
      get { return this.m_Temp; }
   }

   public decimal Kelvin
   {
      get { return this.m_Temp + 273.15m; }   
   }

   public decimal Fahrenheit
   {
      get { return Math.Round(((decimal) (this.m_Temp * 9 / 5 + 32)), 2); }
   }

   public override string ToString()
   {
      return this.ToString("C");
   }

   public string ToString(string format)
   {  
      // Handle null or empty string.
      if (String.IsNullOrEmpty(format)) format = "C";
      // Remove spaces and convert to uppercase.
      format = format.Trim().ToUpperInvariant();      

      // Convert temperature to Fahrenheit and return string.
      switch (format)
      {
         // Convert temperature to Fahrenheit and return string.
         case "F":
            return this.Fahrenheit.ToString("N2") + " °F";
         // Convert temperature to Kelvin and return string.
         case "K":
            return this.Kelvin.ToString("N2") + " K";
         // return temperature in Celsius.
         case "G":
         case "C":
            return this.Celsius.ToString("N2") + " °C";
         default:
            throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
      }      
   }
}

public class Example
{
   public static void Main()
   {
      Temperature temp1 = new Temperature(0m);
      Console.WriteLine(temp1.ToString());
      Console.WriteLine(temp1.ToString("G"));
      Console.WriteLine(temp1.ToString("C"));
      Console.WriteLine(temp1.ToString("F"));
      Console.WriteLine(temp1.ToString("K"));

      Temperature temp2 = new Temperature(-40m);
      Console.WriteLine(temp2.ToString());
      Console.WriteLine(temp2.ToString("G"));
      Console.WriteLine(temp2.ToString("C"));
      Console.WriteLine(temp2.ToString("F"));
      Console.WriteLine(temp2.ToString("K"));

      Temperature temp3 = new Temperature(16m);
      Console.WriteLine(temp3.ToString());
      Console.WriteLine(temp3.ToString("G"));
      Console.WriteLine(temp3.ToString("C"));
      Console.WriteLine(temp3.ToString("F"));
      Console.WriteLine(temp3.ToString("K"));

      Console.WriteLine(String.Format("The temperature is now {0:F}.", temp3));
   }
}
// The example displays the following output:
//       0.00 °C
//       0.00 °C
//       0.00 °C
//       32.00 °F
//       273.15 K
//       -40.00 °C
//       -40.00 °C
//       -40.00 °C
//       -40.00 °F
//       233.15 K
//       16.00 °C
//       16.00 °C
//       16.00 °C
//       60.80 °F
//       289.15 K
//       The temperature is now 16.00 °C.
```

```vb
Public Class Temperature
   Private m_Temp As Decimal

   Public Sub New(temperature As Decimal)
      Me.m_Temp = temperature
   End Sub

   Public ReadOnly Property Celsius() As Decimal
      Get
         Return Me.m_Temp
      End Get   
   End Property

   Public ReadOnly Property Kelvin() As Decimal
      Get
         Return Me.m_Temp + 273.15d   
      End Get
   End Property

   Public ReadOnly Property Fahrenheit() As Decimal
      Get
         Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
      End Get      
   End Property

   Public Overrides Function ToString() As String
      Return Me.ToString("C")
   End Function

   Public Overloads Function ToString(format As String) As String  
      ' Handle null or empty string.
      If String.IsNullOrEmpty(format) Then format = "C"
      ' Remove spaces and convert to uppercase.
      format = format.Trim().ToUpperInvariant()      

      Select Case format
         Case "F"
           ' Convert temperature to Fahrenheit and return string.
            Return Me.Fahrenheit.ToString("N2") & " °F"
         Case "K"
            ' Convert temperature to Kelvin and return string.
            Return Me.Kelvin.ToString("N2") & " K"
         Case "C", "G"
            ' Return temperature in Celsius.
            Return Me.Celsius.ToString("N2") & " °C"
         Case Else
            Throw New FormatException(String.Format("The '{0}' format string is not supported.", format))
      End Select      
   End Function
End Class

Public Module Example
   Public Sub Main()
      Dim temp1 As New Temperature(0d)
      Console.WriteLine(temp1.ToString())
      Console.WriteLine(temp1.ToString("G"))
      Console.WriteLine(temp1.ToString("C"))
      Console.WriteLine(temp1.ToString("F"))
      Console.WriteLine(temp1.ToString("K"))

      Dim temp2 As New Temperature(-40d)
      Console.WriteLine(temp2.ToString())
      Console.WriteLine(temp2.ToString("G"))
      Console.WriteLine(temp2.ToString("C"))
      Console.WriteLine(temp2.ToString("F"))
      Console.WriteLine(temp2.ToString("K"))

      Dim temp3 As New Temperature(16d)
      Console.WriteLine(temp3.ToString())
      Console.WriteLine(temp3.ToString("G"))
      Console.WriteLine(temp3.ToString("C"))
      Console.WriteLine(temp3.ToString("F"))
      Console.WriteLine(temp3.ToString("K"))

      Console.WriteLine(String.Format("The temperature is now {0:F}.", temp3))
   End Sub
End Module
' The example displays the following output:
'       0.00 °C
'       0.00 °C
'       0.00 °C
'       32.00 °F
'       273.15 K
'       -40.00 °C
'       -40.00 °C
'       -40.00 °C
'       -40.00 °F
'       233.15 K
'       16.00 °C
'       16.00 °C
'       16.00 °C
'       60.80 °F
'       289.15 K
'       The temperature is now 16.00 °C.
```

### Custom format strings

In addition to the standard format strings, .NET defines custom format strings for both numeric values and date and time values. A custom format string consists of one or more custom format specifiers that define the string representation of a value. For example, the custom date and time format string "yyyy/mm/dd hh:mm:ss.ffff t zzz" converts a date to its string representation in the form "2008/11/15 07:45:00.0000 P -08:00" for the en-US culture. Similarly, the custom format string "0000" converts the integer value 12 to "0012". For a complete list of custom format strings, see [Custom date and time format strings](custom-datetime.md) and [Custom numeric format strings](custom-numeric.md).

If a format string consists of a single custom format specifier, the format specifier should be preceded by the percent (%) symbol to avoid confusion with a standard format specifier. The following example uses the "M" custom format specifier to display a one-digit or two-digit number of the month of a particular date.

```csharp
DateTime date1 = new DateTime(2009, 9, 8);
Console.WriteLine(date1.ToString("%M"));       
// Displays 9
```

```vb
Dim date1 As Date = #09/08/2009#
Console.WriteLine(date1.ToString("%M"))      ' Displays 9
```

Many standard format strings for date and time values are aliases for custom format strings that are defined by properties of the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. Custom format strings also offer considerable flexibility in providing application-defined formatting for numeric values or date and time values. You can define your own custom result strings for both numeric values and date and time values by combining multiple custom format specifiers into a single custom format string. The following example defines a custom format string that displays the day of the week in parentheses after the month name, day, and year.

```csharp
string customFormat = "MMMM dd, yyyy (dddd)";
DateTime date1 = new DateTime(2009, 8, 28);
Console.WriteLine(date1.ToString(customFormat));   
// The example displays the following output if run on a system
// whose language is English:
//       August 28, 2009 (Friday) 
```

```vb
Dim customFormat As String = "MMMM dd, yyyy (dddd)"
Dim date1 As Date = #8/28/2009#
Console.WriteLine(date1.ToString(customFormat))   
' The example displays the following output if run on a system
' whose language is English:
'       August 28, 2009 (Friday) 
```

The following example defines a custom format string that displays an [Int64](xref:System.Int64) value as a standard, seven-digit U.S. telephone number along with its area code. 

```csharp
using System;

public class Example
{
   public static void Main()
   {
      long number = 8009999999;
      string fmt = "000-000-0000";
      Console.WriteLine(number.ToString(fmt));
   }
}
// The example displays the following output:
//        800-999-9999
```

```vb
Module Example
   Public Sub Main()
      Dim number As Long = 8009999999
      Dim fmt As String = "000-000-0000"
      Console.WriteLine(number.ToString(fmt))
   End Sub
End Module
' The example displays the following output:

' The example displays the following output:
'       800-999-9999
```

Although standard format strings can generally handle most of the formatting needs for your application-defined types, you may also define custom format specifiers to format your types. 

### Format strings and .NET types

All numeric types (that is, the [Byte](xref:System.Byte), [Decimal](xref:System.Decimal), [Double](xref:System.Double), [Int16](xref:System.Int16), [Int32](xref:System.Int32), [Int64](xref:System.Int64), [SByte](xref:System.SByte), [Single](xref:System.Single), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64), and [BigInteger](xref:System.Numerics.BigInteger) types), as well as the [DateTime](xref:System.DateTime), [DateTimeOffset](xref:System.DateTimeOffset), [TimeSpan](xref:System.TimeSpan), [Guid](xref:System.Guid), and all enumeration types, support formatting with format strings. For information on the specific format strings supported by each type, see the following topics: 

Title | Definition
----- | ----------
[Standard numeric format strings](standard-numeric.md) | Describes standard format strings that create commonly used string representations of numeric values. 
[Custom numeric format strings](custom-numeric.md) | Describes custom format strings that create application-specific formats for numeric values.
[Standard date and time format strings](standard-datetime.md) | Describes standard format strings that create commonly used string representations of [DateTime](xref:System.DateTime) values.
[Custom date and time format strings](custom-datetime.md) | Describes custom format strings that create application-specific formats for [DateTime](xref:System.DateTime) values.
[Standard TimeSpan format Strings](standard-timespan.md) | Describes standard format strings that create commonly used string representations of time intervals.
[Custom TimeSpan format strings](custom-timespan.md) | Describes custom format strings that create application-specific formats for time intervals.
[Enumeration format strings](enumeration-format.md) | Describes standard format strings that are used to create string representations of enumeration values.
[Guid.ToString(String)](xref:System.Guid.ToString(System.String)) | Describes standard format strings for [Guid](xref:System.Guid) values.

## Culture-Sensitive Formatting with Format Providers and the IFormatProvider Interface

Although format specifiers let you customize the formatting of objects, producing a meaningful string representation of objects often requires additional formatting information. For example, formatting a number as a currency value by using either the "C" standard format string or a custom format string such as "$ #,#.00" requires, at a minimum, information about the correct currency symbol, group separator, and decimal separator to be available to include in the formatted string. In .NET, this additional formatting information is made available through the [IFormatProvider](xref:System.IFormatProvider) interface, which is provided as a parameter to one or more overloads of the `ToString` method of numeric types and date and time types. [IFormatProvider](xref:System.IFormatProvider) implementations are used in .NET to support culture-specific formatting. The following example illustrates how the string representation of an object changes when it is formatted with three [IFormatProvider](xref:System.IFormatProvider) objects that represent different cultures.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      decimal value = 1603.42m;
      Console.WriteLine(value.ToString("C3", new CultureInfo("en-US")));
      Console.WriteLine(value.ToString("C3", new CultureInfo("fr-FR")));
      Console.WriteLine(value.ToString("C3", new CultureInfo("de-DE")));
   }
}
// The example displays the following output:
//       $1,603.420
//       1 603,420 €
//       1.603,420 €
```

```vb
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim value As Decimal = 1603.42d
      Console.WriteLine(value.ToString("C3", New CultureInfo("en-US")))
      Console.WriteLine(value.ToString("C3", New CultureInfo("fr-FR")))
      Console.WriteLine(value.ToString("C3", New CultureInfo("de-DE")))
   End Sub
End Module
' The example displays the following output:
'       $1,603.420
'       1 603,420 €
'       1.603,420 €
```

The [IFormatProvider](xref:System.IFormatProvider) interface includes one method, [GetFormat(Type)](xref:System.IFormatProvider.GetFormat(System.Type)), which has a single parameter that specifies the type of object that provides formatting information. If the method can provide an object of that type, it returns it. Otherwise, it returns a null reference.

[IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) is a callback method. When you call a `ToString` method overload that includes an [IFormatProvider](xref:System.IFormatProvider) parameter, it calls the [GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) method of that [IFormatProvider](xref:System.IFormatProvider) object. The [GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) method is responsible for returning an object that provides the necessary formatting information, as specified by its *formatType* parameter, to the `ToString` method. 

A number of formatting or string conversion methods include a parameter of type [IFormatProvider](xref:System.IFormatProvider), but in many cases the value of the parameter is ignored when the method is called. The following table lists some of the formatting methods that use the parameter and the type of the [Type](xref:System.Type) object that they pass to the [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) method. 

Method | Type of *formatType* parameter
------ | ------------------------------
`ToString` method of numeric types | [System.Globalization.NumberFormatInfo](xref:System.Globalization.NumberFormatInfo)
`ToString` method of date and time types | [System.Globalization.DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo)
[String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)) | [System.ICustomFormatter](xref:System.ICustomFormatter)
[StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)) | [System.ICustomFormatter](xref:System.ICustomFormatter)

.NET provides three classes that implement [IFormatProvider](xref:System.IFormatProvider): 

* [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo), a class that provides formatting information for date and time values for a specific culture. Its [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) implementation returns an instance of itself.

* [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo), a class that provides numeric formatting information for a specific culture. Its [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) implementation returns an instance of itself.

* [CultureInfo](xref:System.Globalization.CultureInfo). Its [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) implementation can return either a [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object to provide numeric formatting information or a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object to provide formatting information for date and time values. 

You can also implement your own format provider to replace any one of these classes. However, your implementation’s `GetFormat` method must return an object of the type listed in the previous table if it has to provide formatting information to the `ToString` method.

### Culture-sensitive formatting of numeric values

By default, the formatting of numeric values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current thread culture are used. This is illustrated in the following example, which changes the current thread culture four times and then calls the [Decimal.ToString(String)](xref:System.Decimal.ToString(System.String)) method. In each case, the result string reflects the formatting conventions of the current culture. This is because the `ToString` and `ToString(String)` methods wrap calls to each numeric type's `ToString(String, IFormatProvider)` method. 

```csharp
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR", "es-MX", "de-DE" };
      Decimal value = 1043.17m;

      foreach (var cultureName in cultureNames) {
         // Change the current thread culture.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
         Console.WriteLine("The current culture is {0}", 
                           Thread.CurrentThread.CurrentCulture.Name);
         Console.WriteLine(value.ToString("C2"));
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       The current culture is en-US
//       $1,043.17
//       
//       The current culture is fr-FR
//       1 043,17 €
//       
//       The current culture is es-MX
//       $1,043.17
//       
//       The current culture is de-DE
//       1.043,17 €
```

```vb
Imports System.Globalization
Imports System.Threading 

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR", "es-MX", "de-DE" }
      Dim value As Decimal = 1043.17d 

      For Each cultureName In cultureNames
         ' Change the current thread culture.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("The current culture is {0}", 
                           Thread.CurrentThread.CurrentCulture.Name)
         Console.WriteLine(value.ToString("C2"))
         Console.WriteLine()
      Next                  
   End Sub
End Module
' The example displays the following output:
'       The current culture is en-US
'       $1,043.17
'       
'       The current culture is fr-FR
'       1 043,17 €
'       
'       The current culture is es-MX
'       $1,043.17
'       
'       The current culture is de-DE
'       1.043,17 €
```

You can also format a numeric value for a specific culture by calling a `ToString` overload that has a *provider* parameter and passing it either of the following: 

* A [CultureInfo](xref:System.Globalization.CultureInfo) object that represents the culture whose formatting conventions are to be used. Its [CultureInfo.GetFormat](xref:System.Globalization.CultureInfo.GetFormat(System.Type)) method returns the value of the [CultureInfo.NumberFormat](xref:System.Globalization.CultureInfo.NumberFormat) property, which is the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object that provides culture-specific formatting information for numeric values.

* A [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object that defines the culture-specific formatting conventions to be used. Its [GetFormat](xref:System.Globalization.NumberFormatInfo.GetFormat(System.Type)) method returns an instance of itself.

The following example uses [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) objects that represent the English (United States) and English (Great Britain) cultures and the French and Russian neutral cultures to format a floating-point number.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {                                                                                                    
      Double value = 1043.62957;
      string[] cultureNames = { "en-US", "en-GB", "ru", "fr" };

      foreach (var name in cultureNames) {
         NumberFormatInfo nfi = CultureInfo.CreateSpecificCulture(name).NumberFormat;
         Console.WriteLine("{0,-6} {1}", name + ":", value.ToString("N3", nfi));
      }   
   }
}
// The example displays the following output:
//       en-US: 1,043.630
//       en-GB: 1,043.630
//       ru:    1 043,630
//       fr:    1 043,630
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim value As Double = 1043.62957
      Dim cultureNames() As String = { "en-US", "en-GB", "ru", "fr" }

      For Each name In cultureNames
         Dim nfi As NumberFormatInfo = CultureInfo.CreateSpecificCulture(name).NumberFormat
         Console.WriteLine("{0,-6} {1}", name + ":", value.ToString("N3", nfi))
      Next   
   End Sub
End Module
' The example displays the following output:
'       en-US: 1,043.630
'       en-GB: 1,043.630
'       ru:    1 043,630
'       fr:    1 043,630
```

### Culture-sensitive formatting of date and time values

By default, the formatting of date and time values is culture-sensitive. If you do not specify a culture when you call a formatting method, the formatting conventions of the current thread culture are used. This is illustrated in the following example, which changes the current thread culture four times and then calls the [DateTime.ToString(String)](xref:System.DateTime.ToString(System.String)) method. In each case, the result string reflects the formatting conventions of the current culture. This is because the [DateTime.ToString()](xref:System.DateTime.ToString), [DateTime.ToString(String)](xref:System.DateTime.ToString(System.String)), [DateTimeOffset.ToString()](xref:System.DateTimeOffset.ToString(System.String)), and [DateTimeOffset.ToString(String)](xref:System.DateTimeOffset.ToString(System.String)) methods wrap calls to the [DateTime.ToString(String, IFormatProvider)](xref:System.DateTime.ToString(System.String,System.IFormatProvider)) and [DateTimeOffset.ToString(String, IFormatProvider)](xref:System.DateTimeOffset.ToString(System.String,System.IFormatProvider)) methods.

```csharp
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR", "es-MX", "de-DE" };
      DateTime dateToFormat = new DateTime(2012, 5, 28, 11, 30, 0);

      foreach (var cultureName in cultureNames) {
         // Change the current thread culture.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
         Console.WriteLine("The current culture is {0}", 
                           Thread.CurrentThread.CurrentCulture.Name);
         Console.WriteLine(dateToFormat.ToString("F"));
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       The current culture is en-US
//       Monday, May 28, 2012 11:30:00 AM
//       
//       The current culture is fr-FR
//       lundi 28 mai 2012 11:30:00
//       
//       The current culture is es-MX
//       lunes, 28 de mayo de 2012 11:30:00 a.m.
//       
//       The current culture is de-DE
//       Montag, 28. Mai 2012 11:30:00
```

```vb
Imports System.Globalization
Imports System.Threading 

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR", "es-MX", "de-DE" }
      Dim dateToFormat As Date = #5/28/2012 11:30AM#

      For Each cultureName In cultureNames
         ' Change the current thread culture.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
         Console.WriteLine("The current culture is {0}", 
                           Thread.CurrentThread.CurrentCulture.Name)
         Console.WriteLine(dateToFormat.ToString("F"))
         Console.WriteLine()
      Next                  
   End Sub
End Module
' The example displays the following output:
'       The current culture is en-US
'       Monday, May 28, 2012 11:30:00 AM
'       
'       The current culture is fr-FR
'       lundi 28 mai 2012 11:30:00
'       
'       The current culture is es-MX
'       lunes, 28 de mayo de 2012 11:30:00 a.m.
'       
'       The current culture is de-DE
'       Montag, 28. Mai 2012 11:30:00
```

You can also format a date and time value for a specific culture by calling a [DateTime.ToString](xref:System.DateTime.ToString(System.String,System.IFormatProvider)) or [DateTimeOffset.ToString](xref:System.DateTimeOffset.ToString(System.String,System.IFormatProvider)) overload that has a provider parameter and passing it either of the following: 

* A [CultureInfo](xref:System.Globalization.CultureInfo) object that represents the culture whose formatting conventions are to be used. Its [CultureInfo.GetFormat](xref:System.Globalization.CultureInfo.GetFormat(System.Type)) method returns the value of the [CultureInfo.NumberFormat](xref:System.Globalization.CultureInfo.NumberFormat) property, which is the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object that provides culture-specific formatting information for numeric values.

* A [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object that defines the culture-specific formatting conventions to be used. Its [GetFormat](xref:System.Globalization.DateTimeFormatInfo.GetFormat(System.Type)) method returns an instance of itself.

The following example uses [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) objects that represent the English (United States) and English (Great Britain) cultures and the French and Russian neutral cultures to format a date. 

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {                                                                                                    
      DateTime dat1 = new DateTime(2012, 5, 28, 11, 30, 0);
      string[] cultureNames = { "en-US", "en-GB", "ru", "fr" };

      foreach (var name in cultureNames) {
         DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture(name).DateTimeFormat;
         Console.WriteLine("{0}: {1}", name, dat1.ToString(dtfi));
      }   
   }
}
// The example displays the following output:
//       en-US: 5/28/2012 11:30:00 AM
//       en-GB: 28/05/2012 11:30:00
//       ru: 28.05.2012 11:30:00
//       fr: 28/05/2012 11:30:00
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dat1 As Date = #5/28/2012 11:30AM#
      Dim cultureNames() As String = { "en-US", "en-GB", "ru", "fr" }

      For Each name In cultureNames
         Dim dtfi As DateTimeFormatInfo = CultureInfo.CreateSpecificCulture(name).DateTimeFormat
         Console.WriteLine("{0}: {1}", name, dat1.ToString(dtfi))
      Next   
   End Sub
End Module
' The example displays the following output:
'       en-US: 5/28/2012 11:30:00 AM
'       en-GB: 28/05/2012 11:30:00
'       ru: 28.05.2012 11:30:00
'       fr: 28/05/2012 11:30:00
```

## The IFormattable interface

Typically, types that overload the `ToString` method with a format string and an [IFormatProvider](xref:System.IFormatProvider) parameter also implement the [IFormattable](xref:System.IFormattable) interface. This interface has a single member, [IFormattable.ToString(String, IFormatProvider)](xref:System.IFormattable.ToString(System.String,System.IFormatProvider)), that includes both a format string and a format provider as parameters.

Implementing the [IFormattable](xref:System.IFormattable) interface for your application-defined class offers two advantages: 

* Support for string conversion by the [Convert](xref:System.Convert) class. Calls to the [Convert.ToString(Object)](xref:System.Convert.ToString(System.Object)) and [Convert.ToString(Object, IFormatProvider)](xref:System.Convert.ToString(System.Object,System.IFormatProvider)) methods call your [IFormattable](xref:System.IFormattable) implementation automatically.

* Support for composite formatting. If a format item that includes a format string is used to format your custom type, the Common Language Runtime automatically calls your [IFormattable](xref:System.IFormattable) implementation and passes it the format string. For more information about composite formatting with methods such as `String.Format` or `Console.WriteLine`, see the [Composite formatting](#composite-formatting) section.

The following example defines a `Temperature` class that implements the [IFormattable](xref:System.IFormattable) interface. It supports the "C" or "G" format specifiers to display the temperature in Celsius, the "F" format specifier to display the temperature in Fahrenheit, and the "K" format specifier to display the temperature in Kelvin.

```csharp
using System;
using System.Globalization;

public class Temperature : IFormattable
{
   private decimal m_Temp;

   public Temperature(decimal temperature)
   {
      this.m_Temp = temperature;
   }

   public decimal Celsius
   {
      get { return this.m_Temp; }
   }

   public decimal Kelvin
   {
      get { return this.m_Temp + 273.15m; }   
   }

   public decimal Fahrenheit
   {
      get { return Math.Round((decimal) this.m_Temp * 9 / 5 + 32, 2); }
   }

   public override string ToString()
   {
      return this.ToString("G", null);
   }

   public string ToString(string format)
   {
      return this.ToString(format, null);
   }

   public string ToString(string format, IFormatProvider provider)  
   {
      // Handle null or empty arguments.
      if (String.IsNullOrEmpty(format)) format = "G";
      // Remove any white space and convert to uppercase.
      format = format.Trim().ToUpperInvariant();

      if (provider == null) provider = NumberFormatInfo.CurrentInfo;

      switch (format)
      {
         // Convert temperature to Fahrenheit and return string.
         case "F":
            return this.Fahrenheit.ToString("N2", provider) + "°F";
         // Convert temperature to Kelvin and return string.
         case "K":
            return this.Kelvin.ToString("N2", provider) + "K";
         // Return temperature in Celsius.
         case "C":
         case "G":
            return this.Celsius.ToString("N2", provider) + "°C";
         default:
            throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
      }      
   }
}
```

```vb
Imports System.Globalization

Public Class Temperature : Implements IFormattable
   Private m_Temp As Decimal

   Public Sub New(temperature As Decimal)
      Me.m_Temp = temperature
   End Sub

   Public ReadOnly Property Celsius() As Decimal
      Get
         Return Me.m_Temp
      End Get   
   End Property

   Public ReadOnly Property Kelvin() As Decimal
      Get
         Return Me.m_Temp + 273.15d   
      End Get
   End Property

   Public ReadOnly Property Fahrenheit() As Decimal
      Get
         Return Math.Round(CDec(Me.m_Temp * 9 / 5 + 32), 2)
      End Get      
   End Property

   Public Overrides Function ToString() As String
      Return Me.ToString("G", Nothing)
   End Function

   Public Overloads Function ToString(format As String) As String
      Return Me.ToString(format, Nothing)
   End Function

   Public Overloads Function ToString(format As String, provider As IFormatProvider) As String _  
      Implements IFormattable.ToString

      ' Handle null or empty arguments.
      If String.IsNullOrEmpty(format) Then format = "G"
      ' Remove any white space and convert to uppercase.
      format = format.Trim().ToUpperInvariant()

      If provider Is Nothing Then provider = NumberFormatInfo.CurrentInfo

      Select Case format
         ' Convert temperature to Fahrenheit and return string.
         Case "F"
            Return Me.Fahrenheit.ToString("N2", provider) & "°F"
         ' Convert temperature to Kelvin and return string.
         Case "K"
            Return Me.Kelvin.ToString("N2", provider) & "K"
         ' Return temperature in Celsius.
         Case "C", "G"
            Return Me.Celsius.ToString("N2", provider) & "°C"
         Case Else
            Throw New FormatException(String.Format("The '{0}' format string is not supported.", format))
      End Select      
   End Function
End Class
```

The following example instantiates a `Temperature` object. It then calls the [ToString](xref:System.Convert.ToString(System.Object,System.IFormatProvider)) method and uses several composite format strings to obtain different string representations of a `Temperature` object. Each of these method calls, in turn, calls the [IFormattable](xref:System.IFormattable) implementation of the `Temperature` class.

```csharp
public class Example
{
   public static void Main()
   {
      Temperature temp1 = new Temperature(22m);
      Console.WriteLine(Convert.ToString(temp1, new CultureInfo("ja-JP")));
      Console.WriteLine("Temperature: {0:K}", temp1);
      Console.WriteLine("Temperature: {0:F}", temp1);
      Console.WriteLine(String.Format(new CultureInfo("fr-FR"), "Temperature: {0:F}", temp1));
   }
}
// The example displays the following output:
//       22.00°C
//       Temperature: 295.15°K
//       Temperature: 71.60°F
//       Temperature: 71,60°F
```

```vb
Public Module Example
   Public Sub Main()
      Dim temp1 As New Temperature(22d)
      Console.WriteLine(Convert.ToString(temp1, New CultureInfo("ja-JP")))
      Console.WriteLine("Temperature: {0:K}", temp1)
      Console.WriteLine("Temperature: {0:F}", temp1)
      Console.WriteLine(String.Format(New CultureInfo("fr-FR"), "Temperature: {0:F}", temp1)) 
   End Sub
End Module
' The example displays the following output:
'       22.00°C
'       Temperature: 295.15°K
'       Temperature: 71.60°F
'       Temperature: 71,60°F
```

## Composite formatting

Some methods, such as `String.Format` and `StringBuilder.AppendFormat`, support composite formatting. A composite format string is a kind of template that returns a single string that incorporates the string representation of zero, one, or more objects. Each object is represented in the composite format string by an indexed format item. The index of the format item corresponds to the position of the object that it represents in the method's parameter list. Indexes are zero-based. For example, in the following call to the `String.Format` method, the first format item, `{0:D}`, is replaced by the string representation of `thatDate`; the second format item, `{1}`, is replaced by the string representation of `item1`; and the third format item, `{2:C2}`, is replaced by the string representation of `item1.Value`.

```csharp
result = String.Format("On {0:d}, the inventory of {1} was worth {2:C2}.", 
                       thatDate, item1, item1.Value);
Console.WriteLine(result);                            
// The example displays output like the following if run on a system
// whose current culture is en-US:
//       On 5/1/2009, the inventory of WidgetA was worth $107.44.
```

```vb
result = String.Format("On {0:d}, the inventory of {1} was worth {2:C2}.", _
                       thatDate, item1, item1.Value)
Console.WriteLine(result)                            
' The example displays output like the following if run on a system
' whose current culture is en-US:
'       On 5/1/2009, the inventory of WidgetA was worth $107.44.
```

In addition to replacing a format item with the string representation of its corresponding object, format items also let you control the following: 

* The specific way in which an object is represented as a string, if the object implements the [IFormattable](xref:System.IFormattable) interface and supports format strings. You do this by following the format item's index with a : (colon) followed by a valid format string. The previous example did this by formatting a date value with the "d" (short date pattern) format string (e.g., `{0:d}`) and by formatting a numeric value with the "C2" format string (e.g., `{2:C2}` to represent the number as a currency value with two fractional decimal digits. 

* The width of the field that contains the object's string representation, and the alignment of the string representation in that field. You do this by following the format item's index with a , (comma) followed the field width. The string is right-aligned in the field if the field width is a positive value, and it is left-aligned if the field width is a negative value. The following example left-aligns date values in a 20-character field, and it right-aligns decimal values with one fractional digit in an 11-character field. 

```csharp
DateTime startDate = new DateTime(2015, 8, 28, 6, 0, 0);
decimal[] temps = { 73.452m, 68.98m, 72.6m, 69.24563m,
                   74.1m, 72.156m, 72.228m };
Console.WriteLine("{0,-20} {1,11}\n", "Date", "Temperature");
for (int ctr = 0; ctr < temps.Length; ctr++)
   Console.WriteLine("{0,-20:g} {1,11:N1}", startDate.AddDays(ctr), temps[ctr]);

// The example displays the following output:
//       Date                 Temperature
//
//       8/28/2015 6:00 AM           73.5
//       8/29/2015 6:00 AM           69.0
//       8/30/2015 6:00 AM           72.6
//       8/31/2015 6:00 AM           69.2
//       9/1/2015 6:00 AM            74.1
//       9/2/2015 6:00 AM            72.2
//       9/3/2015 6:00 AM            72.2
```

```vb
Dim startDate As New Date(2015, 8, 28, 6, 0, 0)
Dim temps() As Decimal = { 73.452, 68.98, 72.6, 69.24563,
                           74.1, 72.156, 72.228 }
Console.WriteLine("{0,-20} {1,11}", "Date", "Temperature")
Console.WriteLine()
For ctr As Integer = 0 To temps.Length - 1
   Console.WriteLine("{0,-20:g} {1,11:N1}", startDate.AddDays(ctr), temps(ctr))
Next
' The example displays the following output:
'       Date                 Temperature
'
'       8/28/2015 6:00 AM           73.5
'       8/29/2015 6:00 AM           69.0
'       8/30/2015 6:00 AM           72.6
'       8/31/2015 6:00 AM           69.2
'       9/1/2015 6:00 AM            74.1
'       9/2/2015 6:00 AM            72.2
'       9/3/2015 6:00 AM            72.2
```

Note that, if both the alignment string component and the format string component are present, the former precedes the latter (for example, `{0,-20:g}`. 

For more information about composite formatting, see [Composite formatting](composite-format.md).

## Custom formatting with ICustomFormatter

Two composite formatting methods, [String.Format(IFormatProvider, String, Object[])](xref:System.String.Format(System.IFormatProvider,System.String,System.Object[])) and [StringBuilder.AppendFormat(IFormatProvider, String, Object[])](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)), include a format provider parameter that supports custom formatting. When either of these formatting methods is called, it passes a [Type](xref:System.Type) object that represents an [ICustomFormatter](xref:System.ICustomFormatter) interface to the format provider’s `GetFormat` method. The `GetFormat` method is then responsible for returning the [ICustomFormatter](xref:System.ICustomFormatter) implementation that provides custom formatting.

The [ICustomFormatter](xref:System.ICustomFormatter) interface has a single method, [Format(String, Object, IFormatProvider)](xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)), that is called automatically by a composite formatting method, once for each format item in a composite format string. The [Format(String, Object, IFormatProvider)](xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)) method has three parameters: a format string, which represents the *formatString* argument in a format item, an object to format, and an [IFormatProvider](xref:System.IFormatProvider) object that provides formatting services. Typically, the class that implements [ICustomFormatter](xref:System.ICustomFormatter) also implements [IFormatProvider](xref:System.IFormatProvider), so this last parameter is a reference to the custom formatting class itself. The method returns a custom formatted string representation of the object to be formatted. If the method cannot format the object, it should return a null reference.

The following example provides an [ICustomFormatter](xref:System.ICustomFormatter) implementation named `ByteByByteFormatter` that displays integer values as a sequence of two-digit hexadecimal values followed by a space.

```csharp
public class ByteByByteFormatter : IFormatProvider, ICustomFormatter
{
   public object GetFormat(Type formatType)
   { 
      if (formatType == typeof(ICustomFormatter))
         return this;
      else
         return null;
   }

   public string Format(string format, object arg, 
                          IFormatProvider formatProvider)
   {   
      if (! formatProvider.Equals(this)) return null;

      // Handle only hexadecimal format string.
      if (! format.StartsWith("X")) return null;

      byte[] bytes;
      string output = null;

      // Handle only integral types.
      if (arg is Byte) 
         bytes = BitConverter.GetBytes((Byte) arg);
      else if (arg is Int16)
         bytes = BitConverter.GetBytes((Int16) arg);
      else if (arg is Int32)
         bytes = BitConverter.GetBytes((Int32) arg);
      else if (arg is Int64)   
         bytes = BitConverter.GetBytes((Int64) arg);
      else if (arg is SByte)
         bytes = BitConverter.GetBytes((SByte) arg);
      else if (arg is UInt16)
         bytes = BitConverter.GetBytes((UInt16) arg);
      else if (arg is UInt32)
         bytes = BitConverter.GetBytes((UInt32) arg);
      else if (arg is UInt64)
         bytes = BitConverter.GetBytes((UInt64) arg);
      else
         return null;

      for (int ctr = bytes.Length - 1; ctr >= 0; ctr--)
         output += String.Format("{0:X2} ", bytes[ctr]);   

      return output.Trim();
   }
}
```

```vb
Public Class ByteByByteFormatter : Implements IFormatProvider, ICustomFormatter
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function

   Public Function Format(fmt As String, arg As Object, 
                          formatProvider As IFormatProvider) As String _
                          Implements ICustomFormatter.Format

      If Not formatProvider.Equals(Me) Then Return Nothing

      ' Handle only hexadecimal format string.
      If Not fmt.StartsWith("X") Then 
            Return Nothing
      End If

      ' Handle only integral types.
      If Not typeof arg Is Byte AndAlso
         Not typeof arg Is Int16 AndAlso
         Not typeof arg Is Int32 AndAlso
         Not typeof arg Is Int64 AndAlso
         Not typeof arg Is SByte AndAlso
         Not typeof arg Is UInt16 AndAlso
         Not typeof arg Is UInt32 AndAlso
         Not typeof arg Is UInt64 Then _
            Return Nothing

      Dim bytes() As Byte = BitConverter.GetBytes(arg)
      Dim output As String = Nothing

      For ctr As Integer = bytes.Length - 1 To 0 Step -1
         output += String.Format("{0:X2} ", bytes(ctr))   
      Next

      Return output.Trim()
   End Function
End Class
```

The following example uses the `ByteByByteFormatter` class to format integer values. Note that the [ICustomFormatter.Format](xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)) method is called more than once in the second [String.Format(IFormatProvider, String, Object[])](xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)) method call, and that the default [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) provider is used in the third method call because the `.ByteByByteFormatter.Format` method does not recognize the "N0" format string and returns a null reference.

```csharp
public class Example
{
   public static void Main()
   {
      long value = 3210662321; 
      byte value1 = 214;
      byte value2 = 19;

      Console.WriteLine(String.Format(new ByteByByteFormatter(), "{0:X}", value));
      Console.WriteLine(String.Format(new ByteByByteFormatter(), "{0:X} And {1:X} = {2:X} ({2:000})", 
                                      value1, value2, value1 & value2));                                
      Console.WriteLine(String.Format(new ByteByByteFormatter(), "{0,10:N0}", value));
   }
}
// The example displays the following output:
//       00 00 00 00 BF 5E D1 B1
//       00 D6 And 00 13 = 00 12 (018)
//       3,210,662,321
```

```vb
Public Module Example
   Public Sub Main()
      Dim value As Long = 3210662321 
      Dim value1 As Byte = 214
      Dim value2 As Byte = 19

      Console.WriteLine((String.Format(New ByteByByteFormatter(), "{0:X}", value)))
      Console.WriteLine((String.Format(New ByteByByteFormatter(), "{0:X} And {1:X} = {2:X} ({2:000})", 
                                      value1, value2, value1 And value2)))                                
      Console.WriteLine(String.Format(New ByteByByteFormatter(), "{0,10:N0}", value))
   End Sub
End Module
' The example displays the following output:
'       00 00 00 00 BF 5E D1 B1
'       00 D6 And 00 13 = 00 12 (018)
'       3,210,662,321
```

## Related topics

Title | Definition
----- | ----------
[Standard numeric format strings](standard-numeric.md) | Describes standard format strings that create commonly used string representations of numeric values. 
[Custom numeric format strings](custom-numeric.md) | Describes custom format strings that create application-specific formats for numeric values.
[Standard date and time format strings](standard-datetime.md) |  Describes standard format strings that create commonly used string representations of [DateTime](xref:System.DateTime) values.
[Custom date and time format strings](custom-datetime.md) | Describes custom format strings that create application-specific formats for [DateTime](xref:System.DateTime) values.
[Standard TimeSpan format strings](standard-timespan.md) | Describes standard format strings that create commonly used string representations of time intervals.
[Custom TimeSpan format strings](custom-timespan.md) | Describes custom format strings that create application-specific formats for time intervals.
[Enumeration format strings](enumeration-format.md) | Describes standard format strings that are used to create string representations of enumeration values.
[Composite formatting](composite-format.md) | Describes how to embed one or more formatted values in a string. The string can subsequently be displayed on the console or written to a stream.
[Performing formatting operations](performing-formatting-operations.md) | Lists topics that provide step-by-step instructions for performing specific formatting operations.
[Parsing strings](parsing-strings.md) | Describes how to initialize objects to the values described by string representations of those objects. Parsing is the inverse operation of formatting.

## Reference

[System.IFormattable](xref:System.IFormattable)

[System.IFormatProvider](xref:System.IFormatProvider)

[System.ICustomFormatter](xref:System.ICustomFormatter)
