---
title: Composite Formatting
description: Composite Formatting
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: b6f03ceb-d919-4ad9-9839-757dbfc2c0ac
---

# Composite Formatting

The .NET Core composite formatting feature takes a list of objects and a composite format string as input. A composite format string consists of fixed text intermixed with indexed placeholders, called format items, that correspond to the objects in the list. The formatting operation yields a result string that consists of the original fixed text intermixed with the string representation of the objects in the list. 

The composite formatting feature is supported by methods such as the following: 

* [String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_), which returns a formatted result string. 

* [StringBuilder.AppendFormat](https://docs.microsoft.com/dotnet/core/api/System.Text.StringBuilder#System_Text_StringBuilder_AppendFormat_System_IFormatProvider_System_String_System_Object_), which appends a formatted result string to a [StringBuilder](https://docs.microsoft.com/dotnet/core/api/System.Text.StringBuilder) object.

* Some overloads of the [Console.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.Console#System_Console_WriteLine) method, which display a formatted result string to the console.  

* Some overloads of the [TextWriter.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.IO.TextWriter#System_IO_TextWriter_WriteLine) method, which write the formatted result string to a stream or file. Classes derived from [TextWriter](https://docs.microsoft.com/dotnet/core/api/System.IO.TextWriter), such as [StreamWriter](https://docs.microsoft.com/dotnet/core/api/System.IO.StreamWriter), also share this functionality.

* [Debug.WriteLine(String, Object[])](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.Debug#System_Diagnostics_Debug_WriteLine_System_String_System_Object___), which outputs a formatted message to trace listeners. 

* The [Trace.TraceError(String, Object[])](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.Trace#System_Diagnostics_Trace_TraceError_System_String_System_Object___), [Trace.TraceInformation(String, Object[])](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.Trace#System_Diagnostics_Trace_TraceInformation_System_String_System_Object___), and [Trace.TraceWarning(String, Object[])](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.Trace#System_Diagnostics_Trace_TraceWarning_System_String_System_Object___) methods, which output formatted messages to trace listeners. 

* The [TraceSource.TraceInformation(String, Object[])](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.TraceSource#System_Diagnostics_TraceSource_TraceInformation_System_String_System_Object___) method, which writes an informational method to trace listeners. 

## Composite Format String

A composite format string and object list are used as arguments of methods that support the composite formatting feature. A composite format string consists of zero or more runs of fixed text intermixed with one or more format items. The fixed text is any string that you choose, and each format item corresponds to an object or boxed structure in the list. The composite formatting feature returns a new result string where each format item is replaced by the string representation of the corresponding object in the list.

Consider the following [Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_) code fragment.

```csharp
string name = "Fred";
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now);
```

The fixed text is `"Name = "` and `", hours = "`. The format items are `"{0}"`, whose index is 0, which corresponds to the object `name` and `"{1:hh}"`, whose index is 1, which corresponds to the object `DateTime.Now`.

## Format Item Syntax

Each format item takes the following form and consists of the following components:

__{__*index*[,*alignment*][:*formatString*]__}__

The matching braces ("{" and "}") are required. 
 
### Index Component

The mandatory *index* component, also called a parameter specifier, is a number starting from 0 that identifies a corresponding item in the list of objects. That is, the format item whose parameter specifier is 0 formats the first object in the list, the format item whose parameter specifier is 1 formats the second object in the list, and so on. The following example includes four parameter specifiers, numbered zero through three, to represent prime numbers less than ten: 

```csharp
string primes;
primes = String.Format("Prime numbers less than 10: {0}, {1}, {2}, {3}",
                       2, 3, 5, 7 );
Console.WriteLine(primes);
// The example displays the following output:
//      Prime numbers less than 10: 2, 3, 5, 7
```

Multiple format items can refer to the same element in the list of objects by specifying the same parameter specifier. For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying a composite format string such as : "0x{0:X} {0:E} {0:N}", as the following example shows. 

```csharp
string multiple = String.Format("0x{0:X} {0:E} {0:N}",
                                Int64.MaxValue);
Console.WriteLine(multiple);
// The example displays the following output:
//      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
```

Each format item can refer to any object in the list. For example, if there are three objects, you can format the second, first, and third object by specifying a composite format string like this: "{1} {0} {2}". An object that is not referenced by a format item is ignored. A [FormatException](https://docs.microsoft.com/dotnet/core/api/System.FormatException) is thrown at runtime if a parameter specifier designates an item outside the bounds of the list of objects.

### Alignment Component

The optional *alignment* component is a signed integer indicating the preferred formatted field width. If the value of *alignment* is less than the length of the formatted string, *alignment* is ignored and the length of the formatted string is used as the field width. The formatted data in the field is right-aligned if *alignment* is positive and left-aligned if *alignment* is negative. If padding is necessary, white space is used. The comma is required if *alignment*  is specified.

The following example defines two arrays, one containing the names of employees and the other containing the hours they worked over a two-week period. The composite format string left-aligns the names in a 20-character field, and right-aligns their hours in a 5-character field. Note that the "N1" standard format string is also used to format the hours with one fractional digit. 

```csharp
using System;

public class Example
{
   public static void Main()
   {
      string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                         "Ebenezer", "Francine", "George" };
      decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
                                 16.75m };

      Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
      for (int ctr = 0; ctr < names.Length; ctr++)
         Console.WriteLine("{0,-20} {1,5:N1}", names[ctr], hours[ctr]);

   }
}
// The example displays the following output:
//       Name                 Hours
//
//       Adam                  40.0
//       Bridgette              6.7
//       Carla                 40.4
//       Daniel                82.0
//       Ebenezer              40.3
//       Francine              80.0
//       George                16.8
```

### Format String Component

The optional *formatString* component is a format string that is appropriate for the type of object being formatted. Specify a standard or custom numeric format string if the corresponding object is a numeric value, a standard or custom date and time format string if the corresponding object is a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) object, or an [enumeration format string](enumerationformat.md) if the corresponding object is an enumeration value. If *formatString* is not specified, the general ("G") format specifier for a numeric, date and time, or enumeration type is used. The colon is required if *formatString* is specified.

The following table lists types or categories of types in the .NET Framework class library that support a predefined set of format strings, and provides links to the topics that list the supported format strings. Note that string formatting is an extensible mechanism that makes it possible to define new format strings for all existing types as well as to define a set of format strings supported by an application-defined type. For more information, see the [IFormattable](https://docs.microsoft.com/dotnet/core/api/System.IFormattable) and [ICustomFormatter](https://docs.microsoft.com/dotnet/core/api/System.ICustomFormatter) interface topics. 

Type or type category | See
--------------------- | ---
Date and time types ([DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime), [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset)) | [Standard Date and Time Format Strings](standarddatetime.md), [Custom Date and Time Format Strings](customdatetime.md)
Enumeration types (all types derived from [System.Enum](https://docs.microsoft.com/dotnet/core/api/System.Enum)) | [Enumeration Format Strings](enumerationformat.md)
Numeric types ([BigInteger](https://docs.microsoft.com/dotnet/core/api/System.Numerics.BigInteger), [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64)) | [Standard Numeric Format Strings](standardnumeric.md), [Custom Numeric Format Strings](customnumeric.md)
[Guid](https://docs.microsoft.com/dotnet/core/api/System.Guid) | [Guid.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.Guid#System_Guid_ToString_System_String_)
[TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) | [Standard TimeSpan Format Strings](standardtimespan.md), [Custom TimeSpan Format Strings](customtimespan.md)

### Escaping Braces

Opening and closing braces are interpreted as starting and ending a format item. Consequently, you must use an escape sequence to display a literal opening brace or closing brace. Specify two opening braces ("{{") in the fixed text to display one opening brace ("{"), or two closing braces ("}}") to display one closing brace ("}"). Braces in a format item are interpreted sequentially in the order they are encountered. Interpreting nested braces is not supported. 

The way escaped braces are interpreted can lead to unexpected results. For example, consider the format item "{{{0:D}}}", which is intended to display an opening brace, a numeric value formatted as a decimal number, and a closing brace. However, the format item is actually interpreted in the following manner: 

1. The first two opening braces ("{{") are escaped and yield one opening brace. 

2. The next three characters ("{0:") are interpreted as the start of a format item.

3. The next character ("D") would be interpreted as the Decimal standard numeric format specifier, but the next two escaped braces ("}}") yield a single brace. Because the resulting string ("D}") is not a standard numeric format specifier, the resulting string is interpreted as a custom format string that means display the literal string "D}". 

4. The last brace ("}") is interpreted as the end of the format item. 

5. The final result that is displayed is the literal string, "{D}". The numeric value that was to be formatted is not displayed.

One way to write your code to avoid misinterpreting escaped braces and format items is to format the braces and format item separately. That is, in the first format operation display a literal opening brace, in the next operation display the result of the format item, then in the final operation display a literal closing brace. The following example illustrates this approach.

```csharp
int value = 6324;
string output = string.Format("{0}{1:D}{2}", 
                             "{", value, "}");
Console.WriteLine(output);
// The example displays the following output:
//       {6324} 
```

### Processing Order

If the call to the composite formatting method includes an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) argument whose value is not null, the runtime calls its [IFormatProvider.GetFormat](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider#System_IFormatProvider_GetFormat_System_Type_) method to request an [ICustomFormatter](https://docs.microsoft.com/dotnet/core/api/System.ICustomFormatter) implementation. If the method is able to return an [ICustomFormatter](https://docs.microsoft.com/dotnet/core/api/System.ICustomFormatter) implementation, it is cached for later use. 

Each value in the parameter list that corresponds to a format item is converted to a string by performing the following steps. If any condition in the first three steps is true, the string representation of the value is returned in that step, and subsequent steps are not executed.

1. If the value to be formatted is `null`, an empty string ("") is returned. 

2. If an [ICustomFormatter](https://docs.microsoft.com/dotnet/core/api/System.ICustomFormatter) implementation is available, the runtime calls its [Format](https://docs.microsoft.com/dotnet/core/api/System.ICustomFormatter#System_ICustomFormatter_Format_System_String_System_Object_System_IFormatProvider_) method. It passes the method the format item's *formatString* value, if one is present, or `null` if it is not, along with the [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) implementation. 

3. If the value implements the [IFormattable](https://docs.microsoft.com/dotnet/core/api/System.IFormattable) interface, the interface's [ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.IFormattable#System_IFormattable_ToString_System_String_System_IFormatProvider_) method is called. The method is passed the *formatString* value, if one is present in the format item, or `null` if it is not. The [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) argument is determined as follows:

    *   For a numeric value, if a composite formatting method with a non-null [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) argument is called, the runtime requests a [NumberFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.NumberFormatInfo) object from its [IFormatProvider.GetFormat](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider#System_IFormatProvider_GetFormat_System_Type_) method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) parameter, the [NumberFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.NumberFormatInfo object for the current thread culture is used. 
    
    * For a date and time value, if a composite formatting method with a non-null [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) argument is called, the runtime requests a [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object from its [IFormatProvider.GetFormat](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider#System_IFormatProvider_GetFormat_System_Type_) method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) parameter, the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object for the current thread culture is used. 
    
    * For objects of other types, if a composite formatting is called with an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) argument, its value (including a `null`, if no [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) object is supplied) is passed directly to the [IFormattable.ToString](https://docs.microsoft.com/dotnet/core/api/System.IFormattable#System_IFormattable_ToString_System_String_System_IFormatProvider_) implementation. Otherwise, a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object that represents the current thread culture is passed to the [IFormattable.ToString](https://docs.microsoft.com/dotnet/core/api/System.IFormattable#System_IFormattable_ToString_System_String_System_IFormatProvider_) implementation. 
    
4. The type's parameterless `ToString` method, which either overrides [Object.ToString()](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_ToString) or inherits the behavior of its base class, is called. In this case, the format string specified by the *formatString* component in the format item, if it is present, is ignored.

Alignment is applied after the preceding steps have been performed. 

## Code Examples

The following example shows one string created using composite formatting and another created using an object's `ToString` method. Both types of formatting produce equivalent results. 

```csharp
string FormatString1 = String.Format("{0:dddd MMMM}", DateTime.Now);
string FormatString2 = DateTime.Now.ToString("dddd MMMM");
```

Assuming that the current day is a Thursday in May, the value of both strings in the preceding example is `Thursday May` in the U.S. English culture.

[Console.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.Console#System_Console_WriteLine) exposes the same functionality as [String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_). The only difference between the two methods is that [String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_) returns its result as a string, while [Console.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.Console#System_Console_WriteLine) writes the result to the output stream associated with the [Console](https://docs.microsoft.com/dotnet/core/api/System.Console) object. The following example uses the [Console.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.Console#System_Console_WriteLine) method to format the value of `MyInt` to a currency value.

```csharp
int MyInt = 100;
Console.WriteLine("{0:C}", MyInt);
// The example displays the following output 
// if en-US is the current culture:
//        $100.00
```

The following example demonstrates formatting multiple objects, including formatting one object two different ways.

```csharp
string myName = "Fred";
Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}",
      myName, DateTime.Now));
// Depending on the current time, the example displays output like the following:
//    Name = Fred, hours = 11, minutes = 30                 
```

The following example demonstrates the use of alignment in formatting. The arguments that are formatted are placed between vertical bar characters (|) to highlight the resulting alignment.

```csharp
string myFName = "Fred";
string myLName = "Opals";
int myInt = 100;
string FormatFName = String.Format("First Name = |{0,10}|", myFName);
string FormatLName = String.Format("Last Name = |{0,10}|", myLName);
string FormatPrice = String.Format("Price = |{0,10:C}|", myInt); 
Console.WriteLine(FormatFName);
Console.WriteLine(FormatLName);
Console.WriteLine(FormatPrice);
Console.WriteLine();

FormatFName = String.Format("First Name = |{0,-10}|", myFName);
FormatLName = String.Format("Last Name = |{0,-10}|", myLName);
FormatPrice = String.Format("Price = |{0,-10:C}|", myInt);
Console.WriteLine(FormatFName);
Console.WriteLine(FormatLName);
Console.WriteLine(FormatPrice);
// The example displays the following output on a system whose current
// culture is en-US:
//          First Name = |      Fred|
//          Last Name = |     Opals|
//          Price = |   $100.00|
//
//          First Name = |Fred      |
//          Last Name = |Opals     |
//          Price = |$100.00   |
```

## See Also

[Console.WriteLine](https://docs.microsoft.com/dotnet/core/api/System.Console#System_Console_WriteLine)

[String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_)

[Standard Date and Time Format Strings](standarddatetime.md)

[Custom Date and Time Format Strings](customdatetime.md)

[Enumeration Format Strings](enumerationformat.md)

[Standard Numeric Format Strings](standardnumeric.md)

[Custom Numeric Format Strings](customnumeric.md)

[Standard TimeSpan Format Strings](standardtimespan.md)

[Custom TimeSpan Format Strings](customtimespan.md)








