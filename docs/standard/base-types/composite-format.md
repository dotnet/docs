---
title: Composite formatting
description: Composite formatting
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/25/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: a01efc8f-c242-4535-bd32-acd0032d9590
---

# Composite formatting

The .NET composite formatting feature takes a list of objects and a composite format string as input. A composite format string consists of fixed text intermixed with indexed placeholders, called format items, that correspond to the objects in the list. The formatting operation yields a result string that consists of the original fixed text intermixed with the string representation of the objects in the list. 

The composite formatting feature is supported by methods such as the following: 

* [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)), which returns a formatted result string. 

* [StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider, System.String, System.Object), which appends a formatted result string to a [StringBuilder](xref:System.Text.StringBuilder) object.

* Some overloads of the [Console](xref:System.Console) `WriteLine` method, which display a formatted result string to the console.  

* Some overloads of the [TextWriter](xref:System.IO.TextWriter) `WriteLine` method, which write the formatted result string to a stream or file. Classes derived from [TextWriter](xref:System.IO.TextWriter), such as [StreamWriter](xref:System.IO.StreamWriter), also share this functionality.

* [Debug.WriteLine(String, Object[])](xref:System.Diagnostics.Debug.WriteLine(System.String,System.Object[])), which outputs a formatted message to trace listeners. 

* The [Trace.TraceError(String, Object[])](xref:System.Diagnostics.Trace.TraceError(System.String,System.Object[])), [Trace.TraceInformation(String, Object[])](xref:System.Diagnostics.Trace.TraceInformation(System.String,System.Object[])), and [Trace.TraceWarning(String, Object[])](xref:System.Diagnostics.Trace.TraceWarning(System.String,System.Object[])) methods, which output formatted messages to trace listeners. 

* The [TraceSource.TraceInformation(String, Object[])](xref:System.Diagnostics.TraceSource.TraceInformation(System.String,System.Object[])) method, which writes an informational method to trace listeners. 

## Composite Format String

A composite format string and object list are used as arguments of methods that support the composite formatting feature. A composite format string consists of zero or more runs of fixed text intermixed with one or more format items. The fixed text is any string that you choose, and each format item corresponds to an object or boxed structure in the list. The composite formatting feature returns a new result string where each format item is replaced by the string representation of the corresponding object in the list.

Consider the following [Format](xref:System.String.Format(System.String.Format(System.IFormatProvider,System.String,System.Object)) code fragment.

```csharp
string name = "Fred";
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now);
```

```vb
Dim name As String = "Fred"
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now)
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

```vb
Dim primes As String
primes = String.Format("Prime numbers less than 10: {0}, {1}, {2}, {3}",
                       2, 3, 5, 7 )
Console.WriteLine(primes)
' The example displays the following output:
'      Prime numbers less than 10: 2, 3, 5, 7
```

Multiple format items can refer to the same element in the list of objects by specifying the same parameter specifier. For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying a composite format string such as : "0x{0:X} {0:E} {0:N}", as the following example shows. 

```csharp
string multiple = String.Format("0x{0:X} {0:E} {0:N}",
                                Int64.MaxValue);
Console.WriteLine(multiple);
// The example displays the following output:
//      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
```

```vb
Dim multiple As String = String.Format("0x{0:X} {0:E} {0:N}",
                                       Int64.MaxValue)
Console.WriteLine(multiple)
' The example displays the following output:
'      0x7FFFFFFFFFFFFFFF 9.223372E+018 9,223,372,036,854,775,807.00
```

Each format item can refer to any object in the list. For example, if there are three objects, you can format the second, first, and third object by specifying a composite format string like this: "{1} {0} {2}". An object that is not referenced by a format item is ignored. A [FormatException](xref:System.FormatException) is thrown at runtime if a parameter specifier designates an item outside the bounds of the list of objects.

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

```vb
Module Example
   Public Sub Main()
      Dim names() As String = { "Adam", "Bridgette", "Carla", "Daniel",
                                "Ebenezer", "Francine", "George" }
      Dim hours() As Decimal = { 40, 6.667d, 40.39d, 82, 40.333d, 80,
                                 16.75d }

      Console.WriteLine("{0,-20} {1,5}", "Name", "Hours")
      Console.WriteLine()
      For ctr As Integer = 0 To names.Length - 1
         Console.WriteLine("{0,-20} {1,5:N1}", names(ctr), hours(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'       Name                 Hours
'
'       Adam                  40.0
'       Bridgette              6.7
'       Carla                 40.4
'       Daniel                82.0
'       Ebenezer              40.3
'       Francine              80.0
'       George                16.8
```

### Format String Component

The optional *formatString* component is a format string that is appropriate for the type of object being formatted. Specify a standard or custom numeric format string if the corresponding object is a numeric value, a standard or custom date and time format string if the corresponding object is a [DateTime](xref:System.DateTime) object, or an [enumeration format string](enumeration-format.md) if the corresponding object is an enumeration value. If *formatString* is not specified, the general ("G") format specifier for a numeric, date and time, or enumeration type is used. The colon is required if *formatString* is specified.

The following table lists types or categories of types in the .NET Framework class library that support a predefined set of format strings, and provides links to the topics that list the supported format strings. Note that string formatting is an extensible mechanism that makes it possible to define new format strings for all existing types as well as to define a set of format strings supported by an application-defined type. For more information, see the [IFormattable](xref:System.IFormattable) and [ICustomFormatter](xref:System.ICustomFormatter) interface topics. 

Type or type category | See
--------------------- | ---
Date and time types ([DateTime](xref:System.DateTime), [DateTimeOffset](xref:System.DateTimeOffset)) | [Standard Date and Time Format Strings](standard-datetime.md), [Custom date and time format strings](custom-datetime.md)
Enumeration types (all types derived from [System.Enum](xref:System.Enum)) | [Enumeration Format Strings](enumeration-format.md)
Numeric types ([BigInteger](xref:System.Numerics.BigInteger), [Byte](xref:System.Byte), [Decimal](xref:System.Decimal), [Double](xref:System.Double), [Int16](xref:System.Int16), [Int32](xref:System.Int32), [Int64](xref:System.Int64), [SByte](xref:System.SByte), [Single](xref:System.Single), [UInt16](xref:System.UInt16), [UInt32](xref:System.UInt32), [UInt64](xref:System.UInt64)) | [Standard Numeric Format Strings](standard-numeric.md), [Custom Numeric Format Strings](custom-numeric.md)
[Guid](xref:System.Guid) | [Guid.ToString(String)](xref:System.Guid.ToString(System.String))
[TimeSpan](xref:System.TimeSpan) | [Standard TimeSpan Format Strings](standard-timespan.md), [Custom TimeSpan Format Strings](custom-timespan.md)

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

```vb
Dim value As Integer = 6324
Dim output As String = String.Format("{0}{1:D}{2}", _
                                     "{", value, "}")
Console.WriteLine(output)   
' The example displays the following output:
'       {6324}
```

### Processing Order

If the call to the composite formatting method includes an [IFormatProvider](xref:System.IFormatProvider) argument whose value is not null, the runtime calls its [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) method to request an [ICustomFormatter](xref:System.ICustomFormatter) implementation. If the method is able to return an [ICustomFormatter](xref:System.ICustomFormatter) implementation, it is cached for later use. 

Each value in the parameter list that corresponds to a format item is converted to a string by performing the following steps. If any condition in the first three steps is true, the string representation of the value is returned in that step, and subsequent steps are not executed.

1. If the value to be formatted is `null`, an empty string ("") is returned. 

2. If an [ICustomFormatter](xref:System.ICustomFormatter) implementation is available, the runtime calls its [Format](xref:System.ICustomFormatter.Format(System.String,System.Object,System.IFormatProvider)) method. It passes the method the format item's *formatString* value, if one is present, or `null` if it is not, along with the [IFormatProvider](xref:System.IFormatProvider) implementation. 

3. If the value implements the [IFormattable](xref:System.IFormattable) interface, the interface's [ToString(String,IFormatProvider)](xref:System.IFormattable.ToString(System.String,System.IFormatProvider)) method is called. The method is passed the *formatString* value, if one is present in the format item, or `null` if it is not. The [IFormatProvider](xref:System.IFormatProvider) argument is determined as follows:

    *   For a numeric value, if a composite formatting method with a non-null [IFormatProvider](xref:System.IFormatProvider) argument is called, the runtime requests a [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo) object from its [IFormatProvider.GetFormat](xref:System.IFormatProvider.GetFormat(System.Type)) method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an [IFormatProvider](xref:System.IFormatProvider) parameter, the [NumberFormatInfo](xref:System.Globalization.NumberFormatInfo object for the current thread culture is used. 
    
    * For a date and time value, if a composite formatting method with a non-null [IFormatProvider](xref:System.IFormatProvider) argument is called, the runtime requests a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object from its [IFormatProvider.GetFormat](xref:System.IFormatProvider._GetFormat(System.Type) method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an [IFormatProvider](xref:System.IFormatProvider) parameter, the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object for the current thread culture is used. 
    
    * For objects of other types, if a composite formatting is called with an [IFormatProvider](xref:System.IFormatProvider) argument, its value (including a `null`, if no [IFormatProvider](xref:System.IFormatProvider) object is supplied) is passed directly to the [IFormattable.ToString](xref:System.IFormattable.ToString(System.String,System.IFormatProvider)) implementation. Otherwise, a [CultureInfo](xref:System.Globalization.CultureInfo) object that represents the current thread culture is passed to the [IFormattable.ToString](xref:System.IFormattable.ToString(System.String,System.IFormatProvider)) implementation. 
    
4. The type's parameterless `ToString` method, which either overrides [Object.ToString()](xref:System.Object.ToString) or inherits the behavior of its base class, is called. In this case, the format string specified by the *formatString* component in the format item, if it is present, is ignored.

Alignment is applied after the preceding steps have been performed. 

## Code Examples

The following example shows one string created using composite formatting and another created using an object's `ToString` method. Both types of formatting produce equivalent results. 

```csharp
string FormatString1 = String.Format("{0:dddd MMMM}", DateTime.Now);
string FormatString2 = DateTime.Now.ToString("dddd MMMM");
```

```vb
Dim FormatString1 As String = String.Format("{0:dddd MMMM}", DateTime.Now)
Dim FormatString2 As String = DateTime.Now.ToString("dddd MMMM")
```

Assuming that the current day is a Thursday in May, the value of both strings in the preceding example is `Thursday May` in the U.S. English culture.

[Console.WriteLine](xref:System.Console.WriteLine) exposes the same functionality as [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)). The only difference between the two methods is that [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)) returns its result as a string, while [Console.WriteLine](xref:System.Console.WriteLine) writes the result to the output stream associated with the [Console](xref:System.Console) object. The following example uses the [Console.WriteLine](xref:System.Console.WriteLine) method to format the value of `MyInt` to a currency value.

```csharp
int MyInt = 100;
Console.WriteLine("{0:C}", MyInt);
// The example displays the following output 
// if en-US is the current culture:
//        $100.00
```

```vb
Dim MyInt As Integer = 100
Console.WriteLine("{0:C}", MyInt)
' The example displays the following output
' if en-US is the current culture:
'        $100.00
```

The following example demonstrates formatting multiple objects, including formatting one object two different ways.

```csharp
string myName = "Fred";
Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}",
      myName, DateTime.Now));
// Depending on the current time, the example displays output like the following:
//    Name = Fred, hours = 11, minutes = 30                 
```

```vb
Dim myName As String = "Fred"
Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}", _
                  myName, DateTime.Now))
' Depending on the current time, the example displays output like the following:
'    Name = Fred, hours = 11, minutes = 30
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

```vb
Dim myFName As String = "Fred"
Dim myLName As String = "Opals"

Dim myInt As Integer = 100
Dim FormatFName As String = String.Format("First Name = |{0,10}|", myFName)
Dim FormatLName As String = String.Format("Last Name = |{0,10}|", myLName)
Dim FormatPrice As String = String.Format("Price = |{0,10:C}|", myInt)
Console.WriteLine(FormatFName)
Console.WriteLine(FormatLName)
Console.WriteLine(FormatPrice)
Console.WriteLine()

FormatFName = String.Format("First Name = |{0,-10}|", myFName)
FormatLName = String.Format("Last Name = |{0,-10}|", myLName)
FormatPrice = String.Format("Price = |{0,-10:C}|", myInt)
Console.WriteLine(FormatFName)
Console.WriteLine(FormatLName)
Console.WriteLine(FormatPrice)
' The example displays the following output on a system whose current
' culture is en-US:
'          First Name = |      Fred|
'          Last Name = |     Opals|
'          Price = |   $100.00|
'
'          First Name = |Fred      |
'          Last Name = |Opals     |
'          Price = |$100.00   |
```

## See Also

[Console.WriteLine](xref:System.Console.WriteLine)

[String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object))

[Formatting types](formatting-types.md)

[Standard date and time format strings](standard-datetime.md)

[Custom date and time format strings](custom-datetime.md)

[Enumeration format strings](enumeration-format.md)

[Standard numeric format strings](standard-numeric.md)

[Custom numeric format strings](custom-numeric.md)

[Standard TimeSpan format strings](standard-timespan.md)

[Custom TimeSpan format strings](custom-timespan.md)
