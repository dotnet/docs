---
title: Parsing date and time strings in .NET
description: Parsing date and time strings in .NET
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: e61514cd-5329-4eb8-b122-482fffb54ab7
---

# Parsing date and time strings in .NET

Parsing methods convert the string representation of a date and time to an equivalent [DateTime](xref:System.DateTime) object. The [Parse](xref:System.DateTime.Parse(System.String)) and [TryParse](xref:System.DateTime.TryParse(System.String,System.DateTime@)) methods convert any of several common representations of a date and time. The [ParseExact](xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider)) and [TryParseExact](xref:System.DateTime.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles,System.DateTime@)) methods convert a string representation that conforms to the pattern specified by a date and time format string. (See the topics on [standard date and time format strings](standard-datetime.md) and [custom date and time format strings](custom-datetime.md).) 

Parsing is influenced by the properties of a format provider that supplies information such as the strings used for date and time separators, and the names of months, days, and eras. The format provider is the current [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object, which is provided implicitly by the current thread culture or explicitly by the [IFormatProvider](xref:System.IFormatProvider) parameter of a parsing method. For the [IFormatProvider](xref:System.IFormatProvider) parameter, specify a [CultureInfo](xref:System.Globalization.CultureInfo) object, which represents a culture, or a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. 

The string representation of a date to be parsed must include the month and at least a day or year. The string representation of a time must include the hour and at least minutes or the AM/PM designator. However, parsing supplies default values for omitted components if possible. A missing date defaults to the current date, a missing year defaults to the current year, a missing day of the month defaults to the first day of the month, and a missing time defaults to midnight. 

If the string representation specifies only a time, parsing returns a [DateTime](xref:System.DateTime) object with its [Year](xref:System.DateTime.Year), [Month](xref:System.DateTime.Month), and [Day](xref:System.DateTime.Day) properties set to the corresponding values of the [Today](xref:System.DateTime.Today) property. However, if the [DateTimeStyles.NoCurrentDateDefault](xref:System.Globalization.DateTimeStyles.NoCurrentDateDefault) constant is specified in the parsing method, the resulting year, month, and day properties are set to the value 1.

In addition to a date and a time component, the string representation of a date and time can include an offset that indicates how much the time differs from Coordinated Universal Time (UTC). For example, the string "2/14/2007 5:32:00 -7:00" defines a time that is seven hours earlier than UTC. If an offset is omitted from the string representation of a time, parsing returns a [DateTime](xref:System.DateTime) object with its [Kind](xref:System.DateTime.Kind) property set to [DateTimeKind.Unspecified](xref:System.DateTimeKind.Unspecified). If an offset is specified, parsing returns a [DateTime](xref:System.DateTime) object with its [Kind](xref:System.DateTime.Kind) property set to [Local](xref:System.DateTimeKind.Local) and its value adjusted to the local time zone of your machine. You can modify this behavior by using a [DateTimeStyles](xref:System.Globalization.DateTimeStyles) constant with the parsing method.

The format provider is also used to interpret an ambiguous numeric date. For example, it is not clear which components of the date represented by the string "02/03/04" are the month, day, and year. In this case, the components are interpreted according to the order of similar date formats in the format provider. 

## Parse

The following code example illustrates the use of the `Parse` method to convert a string into a `DateTime`. This example uses the culture associated with the current thread to perform the parse. If the [CultureInfo](xref:System.Globalization.CultureInfo) associated with the current culture cannot parse the input string, a [FormatException](xref:System.FormatException) is thrown.

```csharp
string MyString = "Jan 1, 2009";
DateTime MyDateTime = DateTime.Parse(MyString);
Console.WriteLine(MyDateTime);
// Displays the following output on a system whose culture is en-US:
//       1/1/2009 12:00:00 AM
```

```vb
Dim MyString As String = "Jan 1, 2009"
Dim MyDateTime As DateTime = DateTime.Parse(MyString)
Console.WriteLine(MyDateTime)
' Displays the following output on a system whose culture is en-US:
'       1/1/2009 12:00:00 AM
```

You can also specify a `CultureInfo` set to one of the cultures defined by that object, or you can specify one of the standard [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) objects returned by the [CultureInfo.DateTimeFormat](xref:System.Globalization.CultureInfo.DateTimeFormat) property. The following code example uses a format provider to parse a German string into a `DateTime`. A `CultureInfo` representing the de-DE culture is defined and passed with the string being parsed to ensure successful parsing of this particular string. This precludes whatever setting is in the `CurrentCulture` of the `CurrentThread`.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo MyCultureInfo = new CultureInfo("de-DE");
      string MyString = "12 Juni 2008";
      DateTime MyDateTime = DateTime.Parse(MyString, MyCultureInfo);
      Console.WriteLine(MyDateTime);
   }
}
// The example displays the following output:
//       6/12/2008 12:00:00 AM
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim MyCultureInfo As CultureInfo = new CultureInfo("de-DE")
      Dim MyString As String = "12 Juni 2008"
      Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo)
      Console.WriteLine(MyDateTime)
   End Sub
End Module
' The example displays the following output:
'       6/12/2008 12:00:00 AM
```

However, although you can use overloads of the [Parse](xref:System.DateTime.Parse(System.String)) method to specify custom format providers, the method does not support the use of non-standard format providers. To parse a date and time expressed in a non-standard format, use the [ParseExact](xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider)) method instead.

The following code example uses the [DateTimeStyles](xref:System.Globalization.DateTimeStyles) enumeration to specify that the current date and time information should not be added to the `DateTime` for fields that the string does not define.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo MyCultureInfo = new CultureInfo("de-DE");
      string MyString = "12 Juni 2008";
      DateTime MyDateTime = DateTime.Parse(MyString, MyCultureInfo, 
                                           DateTimeStyles.NoCurrentDateDefault);
      Console.WriteLine(MyDateTime);
   }
}
// The example displays the following output if the current culture is en-US:
//      6/12/2008 12:00:00 AM
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim MyCultureInfo As CultureInfo = new CultureInfo("de-DE")
      Dim MyString As String = "12 Juni 2008"
      Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo)
      Console.WriteLine(MyDateTime)
   End Sub
End Module
' The example displays the following output:
'       6/12/2008 12:00:00 AM
```

## ParseExact

The [DateTime.ParseExact]((xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider)) method converts a string that conforms to a specified string pattern to a `DateTime` object. When a string that is not of the form specified is passed to this method, a [FormatException](xref:System.FormatException) is thrown. You can specify one of the standard date and time format specifiers or a limited combination of the custom date and time format specifiers. Using the custom format specifiers, it is possible for you to construct a custom recognition string. For an explanation of the specifiers, see the topics on [standard date and time format strings](standard-datetime.md) and [custom date and time format strings](custom-datetime.md). 

Each overload of the [ParseExact](xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider)) method also has an [IFormatProvider](xref:System.IFormatProvider) parameter that typically provides culture-specific information about the formatting of the string. Typically, this [IFormatProvider](xref:System.IFormatProvider) object is a [CultureInfo](xref:System.Globalization.CultureInfo) object that represents a standard culture or a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object that is returned by the [CultureInfo.DateTimeFormat](xref:System.Globalization.CultureInfo.DateTimeFormat) property. However, unlike the other date and time parsing functions, this method also supports an [IFormatProvider](xref:System.IFormatProvider) that defines a non-standard date and time format. 

In the following code example, the `ParseExact` method is passed a string object to parse, followed by a format specifier, followed by a `CultureInfo` object. This `ParseExact` method can only parse strings that exhibit the long date pattern in the en-US culture.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo MyCultureInfo = new CultureInfo("en-US");
      string[] MyString = {" Friday, April 10, 2009", "Friday, April 10, 2009"};
      foreach (string dateString in MyString)
      {
         try {
            DateTime MyDateTime = DateTime.ParseExact(dateString, "D", MyCultureInfo);
            Console.WriteLine(MyDateTime);
         }
         catch (FormatException) {
            Console.WriteLine("Unable to parse '{0}'", dateString);
         }
      }
   }
}
// The example displays the following output:
//       Unable to parse ' Friday, April 10, 2009'
//       4/10/2009 12:00:00 AM
```

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim MyCultureInfo As CultureInfo = new CultureInfo("en-US")
      Dim MyString() As String = {" Friday, April 10, 2009", "Friday, April 10, 2009"}
      For Each dateString As String In MyString
         Try
            Dim MyDateTime As DateTime = DateTime.ParseExact(dateString, "D", _
                                                             MyCultureInfo)
            Console.WriteLine(MyDateTime)
         Catch e As FormatException
            Console.WriteLine("Unable to parse '{0}'", dateString)
         End Try
      Next
   End Sub
End Module
' The example displays the following output:
'       Unable to parse ' Friday, April 10, 2009'
'       4/10/2009 12:00:00 AM
```

## See Also

[Parsing strings in .NET](parsing-strings.md)

[Formatting types in .NET](formatting-types.md)

[Type conversion in .NET](type-conversion.md)

