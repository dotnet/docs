---
title: Standard date and time format strings
description: Standard date and time format strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/25/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: be239871-10cc-4949-b548-200bb260630a
---

# Standard date and time format strings

A standard date and time format string uses a single format specifier to define the text representation of a date and time value. Any date and time format string that contains more than one character, including white space, is interpreted as a custom date and time format string; for more information, see [Custom date and time format strings](custom-datetime.md). A standard or custom format string can be used in two ways:

* To define the string that results from a formatting operation.

* To define the text representation of a date and time value that can be converted to a [DateTime](xref:System.DateTime) or [DateTimeOffset](xref:System.DateTimeOffset) value by a parsing operation.

Standard date and time format strings can be used with both [DateTime](xref:System.DateTime) and [DateTimeOffset](xref:System.DateTimeOffset) values. 

The following table describes the standard date and time format specifiers. Unless otherwise noted, a particular standard date and time format specifier produces an identical string representation regardless of whether it is used with a [DateTime](xref:System.DateTime) or a [DateTimeOffset](xref:System.DateTimeOffset) value. See the [Notes](#notes) section for additional information about using standard date and time format strings.

Format specifier | Description | Examples
---------------- | ----------- | --------
"d" | Short date pattern. | `2009-06-15T13:45:30 -> 6/15/2009 (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 (fr-FR)`; `2009-06-15T13:45:30 -> 2009/06/15 (ja-JP)`
"D" | Long date pattern. | `2009-06-15T13:45:30 -> Monday, June 15, 2009 (en-US)`; `2009-06-15T13:45:30 -> 15 июня 2009 г. (ru-RU)`; `2009-06-15T13:45:30 -> Montag, 15. Juni 2009 (de-DE)`
"f" | Full date/time pattern (short time). | `2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 13:45 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45 μμ (el-GR)`
"F" | Full date/time pattern (long time). | `2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 13:45:30 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45:30 μμ (el-GR)`
"g" | General date/time pattern (short time). | `2009-06-15T13:45:30 -> 6/15/2009 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 13:45 (es-ES)`; `2009-06-15T13:45:30 -> 2009/6/15 13:45 (zh-CN)`
"G" | General date/time pattern (long time). | `2009-06-15T13:45:30 -> 6/15/2009 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 13:45:30 (es-ES)`; `2009-06-15T13:45:30 -> 2009/6/15 13:45:30 (zh-CN)`
"M", "m' | Month/day pattern. | `2009-06-15T13:45:30 -> June 15 (en-US)`; `2009-06-15T13:45:30 -> 15. juni (da-DK)`; `2009-06-15T13:45:30 -> 15 Juni (id-ID)`
"O", "o" | Round-trip date/time pattern. | [DateTime](xref:System.DateTime) values: `2009-06-15T13:45:30 (DateTimeKind.Local) --> 2009-06-15T13:45:30.0000000-07:00`; `2009-06-15T13:45:30 (DateTimeKind.Utc) --> 2009-06-15T13:45:30.0000000Z`; `2009-06-15T13:45:30 (DateTimeKind.Unspecified) --> 2009-06-15T13:45:30.0000000`. [DateTimeOffset](xref:System.DateTimeOffset) values: `2009-06-15T13:45:30-07:00 --> 2009-06-15T13:45:30.0000000-07:00`
"R", "r" | RFC1123 pattern. | `2009-06-15T13:45:30 -> Mon, 15 Jun 2009 20:45:30 GMT`
"s" | Sortable date/time pattern. | `2009-06-15T13:45:30 (DateTimeKind.Local) -> 2009-06-15T13:45:30`; `2009-06-15T13:45:30 (DateTimeKind.Utc) -> 2009-06-15T13:45:30`
"t" | Short time pattern. | `2009-06-15T13:45:30 -> 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> 13:45 (hr-HR)`; `2009-06-15T13:45:30 -> 01:45 م (ar-EG)` 
"T" | Long time pattern. | `2009-06-15T13:45:30 -> 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> 13:45:30 (hr-HR)`; `2009-06-15T13:45:30 -> 01:45:30 م (ar-EG)`
"u" | Universal sortable date/time pattern. | With a [DateTime](xref:System.DateTime) value: `2009-06-15T13:45:30 -> 2009-06-15 13:45:30Z`. With a [DateTimeOffset](xref:System.DateTimeOffset) value: `2009-06-15T13:45:30 -> 2009-06-15 20:45:30Z`
"U" | Universal full date/time pattern. | `2009-06-15T13:45:30 -> Monday, June 15, 2009 8:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 20:45:30 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 8:45:30 μμ (el-GR)`
"Y", "y" | Year month pattern. | `2009-06-15T13:45:30 -> June, 2009 (en-US)`; `2009-06-15T13:45:30 -> juni 2009 (da-DK)`; `2009-06-15T13:45:30 -> Juni 2009 (id-ID)`
Any other single character | Unknown specifier. | Throws a run-time [FormatException](xref:System.FormatException).

## How standard format strings work

In a formatting operation, a standard format string is simply an alias for a custom format string. The advantage of using an alias to refer to a custom format string is that, although the alias remains invariant, the custom format string itself can vary. This is important because the string representations of date and time values typically vary by culture. For example, the "d" standard format string indicates that a date and time value is to be displayed using a short date pattern. For the invariant culture, this pattern is "MM/dd/yyyy". For the fr-FR culture, it is "dd/MM/yyyy". For the ja-JP culture, it is "yyyy/MM/dd".

If a standard format string in a formatting operation maps to a particular culture's custom format string, your application can define the specific culture whose custom format strings are used in one of these ways:

* You can use the default (or current) culture. The following example displays a date using the current culture's short date format. In this case, the current culture is en-US. 

  ```csharp
  // Display using current (en-us) culture's short date format
  DateTime thisDate = new DateTime(2008, 3, 15);
  Console.WriteLine(thisDate.ToString("d"));           // Displays 3/15/2008
  ```

  ```vb
  ' Display using current (en-us) culture's short date format
  Dim thisDate As Date = #03/15/2008#
  Console.WriteLine(thisDate.ToString("d"))     ' Displays 3/15/2008
  ```
  
* You can pass a [CultureInfo](xref:System.Globalization.CultureInfo) object representing the culture whose formatting is to be used to a method that has an [IFormatProvider](xref:System.IFormatProvider) parameter. The following example displays a date using the short date format of the pt-BR culture.
  
  ```csharp
  // Display using pt-BR culture's short date format
  DateTime thisDate = new DateTime(2008, 3, 15);
  CultureInfo culture = new CultureInfo("pt-BR");      
  Console.WriteLine(thisDate.ToString("d", culture));  // Displays 15/3/2008
  ```

  ```vb
  ' Display using pt-BR culture's short date format
  Dim thisDate As Date = #03/15/2008#
  Dim culture As New CultureInfo("pt-BR")      
  Console.WriteLine(thisDate.ToString("d", culture))   ' Displays 15/3/2008
  ```
  
* You can pass a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object that provides formatting information to a method that has an [IFormatProvider](xref:System.IFormatProvider) parameter. The following example displays a date using the short date format from a DateTimeFormatInfo object for the hr-HR culture.  

  ```csharp
  // Display using date format information from hr-HR culture
  DateTime thisDate = new DateTime(2008, 3, 15);
  DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;
  Console.WriteLine(thisDate.ToString("d", fmt));      // Displays 15.3.2008
  ```

  ```vb
  ' Display using date format information from hr-HR culture
  Dim thisDate As Date = #03/15/2008#
  Dim fmt As DateTimeFormatInfo = (New CultureInfo("hr-HR")).DateTimeFormat
  Console.WriteLine(thisDate.ToString("d", fmt))   ' Displays 15.3.2008
  ```
  
In some cases, the standard format string serves as a convenient abbreviation for a longer custom format string that is invariant. Four standard format strings fall into this category: "O" (or "o"), "R" (or "r"), "s", and "u". These strings correspond to custom format strings defined by the invariant culture. They produce string representations of date and time values that are intended to be identical across cultures. The following table provides information on these four standard date and time format strings.

Standard format string | Defined by DateTimeFormatInfo.InvariantInfo property | Custom format string
---------------------- | ---------------------------------------------------- | --------------------
"O" or "o" | None | yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzz
"R" or "r" | [RFC1123Pattern](xref:System.Globalization.DateTimeFormatInfo.RFC1123Pattern) | ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
"s" | [SortableDateTime](xref:System.Globalization.DateTimeFormatInfo.SortableDateTimePattern) | yyyy'-'MM'-'dd'T'HH':'mm':'ss
"u" | [UniversalSortableDateTime](xref:System.Globalization.DateTimeFormatInfo.UniversalSortableDateTimePattern) | yyyy'-'MM'-'dd HH':'mm':'ss'Z'

The following sections describe the standard format specifiers for [DateTime](xref:System.DateTime) and [DateTimeOffset](xref:System.DateTimeOffset) values.

## The short date ("d") format specifier

The "d" standard format specifier represents a custom date and time format string that is defined by a specific culture's [DateTimeFormatInfo.ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) property. For example, the custom format string that is returned by the [ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) property of the invariant culture is "MM/dd/yyyy". 

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that control the formatting of the returned string.
The following example uses the "d" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008,4, 10);
Console.WriteLine(date1.ToString("d", DateTimeFormatInfo.InvariantInfo));
// Displays 04/10/2008
Console.WriteLine(date1.ToString("d", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays 4/10/2008                       
Console.WriteLine(date1.ToString("d", 
                  CultureInfo.CreateSpecificCulture("en-NZ")));
// Displays 10/04/2008                       
Console.WriteLine(date1.ToString("d", 
                  CultureInfo.CreateSpecificCulture("de-DE")));
// Displays 10.04.2008 
```

```vb
Dim date1 As Date = #4/10/2008#
Console.WriteLine(date1.ToString("d", DateTimeFormatInfo.InvariantInfo))
' Displays 04/10/2008
Console.WriteLine(date1.ToString("d", _
                  CultureInfo.CreateSpecificCulture("en-US")))
' Displays 4/10/2008                       
Console.WriteLine(date1.ToString("d", _
                  CultureInfo.CreateSpecificCulture("en-NZ")))
' Displays 10/04/2008                       
Console.WriteLine(date1.ToString("d", _
                  CultureInfo.CreateSpecificCulture("de-DE")))
' Displays 10.04.2008 
```

## The long date ("D") format specifier

The "D" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.LongDatePattern](xref:System.Globalization.DateTimeFormatInfo.LongDatePattern) property. For example, the custom format string for the invariant culture is "dddd, dd MMMM yyyy".

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[LongDatePattern](xref:System.Globalization.DateTimeFormatInfo.LongDatePattern) | Defines the overall format of the result string.
[DayNames](xref:System.Globalization.DateTimeFormatInfo.DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.

The following example uses the "D" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10);
Console.WriteLine(date1.ToString("D", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays Thursday, April 10, 2008                        
Console.WriteLine(date1.ToString("D", 
                  CultureInfo.CreateSpecificCulture("pt-BR")));
// Displays quinta-feira, 10 de abril de 2008                        
Console.WriteLine(date1.ToString("D", 
                  CultureInfo.CreateSpecificCulture("es-MX")));
// Displays jueves, 10 de abril de 2008
```

```vb
Dim date1 As Date = #4/10/2008#
Console.WriteLine(date1.ToString("D", _
                  CultureInfo.CreateSpecificCulture("en-US")))
' Displays Thursday, April 10, 2008                        
Console.WriteLine(date1.ToString("D", _
                  CultureInfo.CreateSpecificCulture("pt-BR")))
' Displays quinta-feira, 10 de abril de 2008                        
Console.WriteLine(date1.ToString("D", _
                  CultureInfo.CreateSpecificCulture("es-MX")))
' Displays jueves, 10 de abril de 2008
```

## The full date short time ("f") format specifier

The "f" standard format specifier represents a combination of the long date ("D") and short time ("t") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier returned by the [DateTimeFormatInfo.LongDatePattern](xref:System.Globalization.DateTimeFormatInfo.LongDatePattern) and [DateTimeFormatInfo.ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[LongDatePattern](xref:System.Globalization.DateTimeFormatInfo.LongDatePattern) | Defines the format of the date component of the result string.
[ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) | Defines the format of the time component of the result string.
[DayNames](xref:System.Globalization.DateTimeFormatInfo.DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "f" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("f", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays Thursday, April 10, 2008 6:30 AM                        
Console.WriteLine(date1.ToString("f", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays jeudi 10 avril 2008 06:30 
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("f", _
                  CultureInfo.CreateSpecificCulture("en-US")))
' Displays Thursday, April 10, 2008 6:30 AM                        
Console.WriteLine(date1.ToString("f", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays jeudi 10 avril 2008 06:30 
```

## The full date long time ("F") format specifier

The "F" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) property. For example, the custom format string for the invariant culture is "dddd, dd MMMM yyyy HH:mm:ss".

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) | Defines the overall format of the result string.
[DayNames](xref:System.Globalization.DateTimeFormatInfo.DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "F" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("F", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays Thursday, April 10, 2008 6:30:00 AM                        
Console.WriteLine(date1.ToString("F", 
                  CultureInfo.CreateSpecificCulture("fr-FR")));
// Displays jeudi 10 avril 2008 06:30:00 
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("F", _
                  CultureInfo.CreateSpecificCulture("en-US")))
' Displays Thursday, April 10, 2008 6:30:00 AM                        
Console.WriteLine(date1.ToString("F", _
                  CultureInfo.CreateSpecificCulture("fr-FR")))
' Displays jeudi 10 avril 2008 06:30:00 
```

## The general date short time ("g") format specifier

The "g" standard format specifier represents a combination of the short date ("d") and short time ("t") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) and [DateTimeFormatInfo.ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) | Defines the format of the date component of the result string.
[ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "g" format specifier to display a date and time value. 

``` csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("g", 
                  DateTimeFormatInfo.InvariantInfo));
// Displays 04/10/2008 06:30                      
Console.WriteLine(date1.ToString("g", 
                  CultureInfo.CreateSpecificCulture("en-us")));
// Displays 4/10/2008 6:30 AM                       
Console.WriteLine(date1.ToString("g", 
                  CultureInfo.CreateSpecificCulture("fr-BE")));
// Displays 10/04/2008 6:30 
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("g", _
                  DateTimeFormatInfo.InvariantInfo))
' Displays 04/10/2008 06:30                      
Console.WriteLine(date1.ToString("g", _
                  CultureInfo.CreateSpecificCulture("en-us")))
' Displays 4/10/2008 6:30 AM                       
Console.WriteLine(date1.ToString("g", _
                  CultureInfo.CreateSpecificCulture("fr-BE")))
' Displays 10/04/2008 6:30  
```

## The general date long time ("G") format specifier

The "G" standard format specifier represents a combination of the short date ("d") and long time ("T") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) and [DateTimeFormatInfo.LongTimePattern](xref:System.Globalization.DateTimeFormatInfo.LongTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[ShortDatePattern](xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern) | Defines the format of the date component of the result string.
[LongTimePattern](xref:System.Globalization.DateTimeFormatInfo.LongTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "G" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("G", 
                  DateTimeFormatInfo.InvariantInfo));
// Displays 04/10/2008 06:30:00
Console.WriteLine(date1.ToString("G", 
                  CultureInfo.CreateSpecificCulture("en-us")));
// Displays 4/10/2008 6:30:00 AM                        
Console.WriteLine(date1.ToString("G", 
                  CultureInfo.CreateSpecificCulture("nl-BE")));
// Displays 10/04/2008 6:30:00  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("G", _
                  DateTimeFormatInfo.InvariantInfo))
' Displays 04/10/2008 06:30:00
Console.WriteLine(date1.ToString("G", _
                  CultureInfo.CreateSpecificCulture("en-us")))
' Displays 4/10/2008 6:30:00 AM                        
Console.WriteLine(date1.ToString("G", _
                  CultureInfo.CreateSpecificCulture("nl-BE")))
' Displays 10/04/2008 6:30:00                       
```

## The month ("M", "m") format specifier

The "M" or "m" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.MonthDayPattern](xref:System.Globalization.DateTimeFormatInfo.MonthDayPattern) property. For example, the custom format string for the invariant culture is "MMMM dd".

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[MonthDayPattern](xref:System.Globalization.DateTimeFormatInfo.MonthDayPattern) | Defines the overall format of the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.

The following example uses the "m" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("m", 
                  CultureInfo.CreateSpecificCulture("en-us")));
// Displays April 10                        
Console.WriteLine(date1.ToString("m", 
                  CultureInfo.CreateSpecificCulture("ms-MY")));
// Displays 10 April  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("m", _
                  CultureInfo.CreateSpecificCulture("en-us")))
' Displays April 10                        
Console.WriteLine(date1.ToString("m", _
                  CultureInfo.CreateSpecificCulture("ms-MY")))
' Displays 10 April
```

## The round-trip ("O", "o") format specifier

The "O" or "o" standard format specifier represents a custom date and time format string using a pattern that preserves time zone information and emits a result string that complies with ISO 8601. For [DateTime](xref:System.DateTime) values, this format specifier is designed to preserve date and time values along with the [DateTime.Kind](xref:System.DateTime.Kind) property in text. The formatted string can be parsed back by using the [DateTime.Parse(String, IFormatProvider, DateTimeStyles)](xref:System.DateTime.Parse(System.String,System.IFormatProvider,System.Globalization.DateTimeStyles)) or [DateTime.ParseExact](xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.DateTimeStyles)) method if the styles parameter is set to [DateTimeStyles.RoundtripKind](xref:System.Globalization.DateTimeStyles.RoundtripKind). 

The "O" or "o" standard format specifier corresponds to the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK" custom format string for DateTime values and to the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz" custom format string for [DateTimeOffset](xref:System.DateTimeOffset) values. In this string, the pairs of single quotation marks that delimit individual characters, such as the hyphens, the colons, and the letter "T", indicate that the individual character is a literal that cannot be changed. The apostrophes do not appear in the output string. 

The O" or "o" standard format specifier (and the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK" custom format string) takes advantage of the three ways that ISO 8601 represents time zone information to preserve the [Kind](xref:System.DateTime.Kind) property of [DateTime](xref:System.DateTime) values: 

* The time zone component of [DateTimeKind.Local](xref:System.DateTimeKind.Local) date and time values is an offset from UTC (for example, +01:00, -07:00). All DateTimeOffset values are also represented in this format. 

* The time zone component of [DateTimeKind.Utc](xref:System.DateTimeKind.Utc) date and time values uses "Z" (which stands for zero offset) to represent UTC. 

* [DateTimeKind.Unspecified](xref:System.DateTimeKind.Unspecified) date and time values have no time zone information. 

Because the O" or "o" standard format specifier conforms to an international standard, the formatting or parsing operation that uses the specifier always uses the invariant culture and the Gregorian calendar. 

Strings that are passed to the `Parse`, `TryParse`, `ParseExact`, and `TryParseExact` methods of [DateTime](xref:System.DateTime) and [DateTimeOffset](xref:System.DateTimeOffset) can be parsed by using the "O" or "o" format specifier if they are in one of these formats. In the case of [DateTime](xref:System.DateTime) objects, the parsing overload that you call should also include a styles parameter with a value of [DateTimeStyles.RoundtripKind](xref:System.Globalization.DateTimeStyles.RoundtripKind). Note that if you call a parsing method with the custom format string that corresponds to the "O" or "o" format specifier, you won't get the same results as "O" or "o". This is because parsing methods that use a custom format string can't parse the string representation of date and time values that lack a time zone component or use "Z" to indicate UTC. 

The following example uses the "o" format specifier to display a series of [DateTime](xref:System.DateTime) values and a [DateTimeOffset](xref:System.DateTimeOffset) value on a system in the U.S. Pacific Time zone. 

```csharp
using System;

public class Example
{
   public static void Main()
   {
       DateTime dat = new DateTime(2009, 6, 15, 13, 45, 30, 
                                   DateTimeKind.Unspecified);
       Console.WriteLine("{0} ({1}) --> {0:O}", dat, dat.Kind); 

       DateTime uDat = new DateTime(2009, 6, 15, 13, 45, 30, 
                                    DateTimeKind.Utc);
       Console.WriteLine("{0} ({1}) --> {0:O}", uDat, uDat.Kind);

       DateTime lDat = new DateTime(2009, 6, 15, 13, 45, 30, 
                                    DateTimeKind.Local);
       Console.WriteLine("{0} ({1}) --> {0:O}\n", lDat, lDat.Kind);

       DateTimeOffset dto = new DateTimeOffset(lDat);
       Console.WriteLine("{0} --> {0:O}", dto);
   }
}
// The example displays the following output:
//    6/15/2009 1:45:30 PM (Unspecified) --> 2009-06-15T13:45:30.0000000
//    6/15/2009 1:45:30 PM (Utc) --> 2009-06-15T13:45:30.0000000Z
//    6/15/2009 1:45:30 PM (Local) --> 2009-06-15T13:45:30.0000000-07:00
//    
//    6/15/2009 1:45:30 PM -07:00 --> 2009-06-15T13:45:30.0000000-07:00
```

```vb
Module Example
   Public Sub Main()
       Dim dat As New Date(2009, 6, 15, 13, 45, 30, 
                           DateTimeKind.Unspecified)
       Console.WriteLine("{0} ({1}) --> {0:O}", dat, dat.Kind) 

       Dim uDat As New Date(2009, 6, 15, 13, 45, 30, DateTimeKind.Utc)
       Console.WriteLine("{0} ({1}) --> {0:O}", uDat, uDat.Kind)

       Dim lDat As New Date(2009, 6, 15, 13, 45, 30, DateTimeKind.Local)
       Console.WriteLine("{0} ({1}) --> {0:O}", lDat, lDat.Kind)
       Console.WriteLine()

       Dim dto As New DateTimeOffset(lDat)
       Console.WriteLine("{0} --> {0:O}", dto)
   End Sub
End Module
' The example displays the following output:
'    6/15/2009 1:45:30 PM (Unspecified) --> 2009-06-15T13:45:30.0000000
'    6/15/2009 1:45:30 PM (Utc) --> 2009-06-15T13:45:30.0000000Z
'    6/15/2009 1:45:30 PM (Local) --> 2009-06-15T13:45:30.0000000-07:00
'    
'    6/15/2009 1:45:30 PM -07:00 --> 2009-06-15T13:45:30.0000000-07:00
```

The following example uses the "o" format specifier to create a formatted string, and then restores the original date and time value by calling a date and time `Parse` method.

```csharp
// Round-trip DateTime values.
DateTime originalDate, newDate;
string dateString;
// Round-trip a local time.
originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 10, 6, 30, 0), DateTimeKind.Local);
dateString = originalDate.ToString("o");
newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, 
                  newDate, newDate.Kind);
// Round-trip a UTC time.
originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 12, 9, 30, 0), DateTimeKind.Utc);                  
dateString = originalDate.ToString("o");
newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, 
                  newDate, newDate.Kind);
// Round-trip time in an unspecified time zone.
originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 13, 12, 30, 0), DateTimeKind.Unspecified);                  
dateString = originalDate.ToString("o");
newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, 
                  newDate, newDate.Kind);

// Round-trip a DateTimeOffset value.
DateTimeOffset originalDTO = new DateTimeOffset(2008, 4, 12, 9, 30, 0, new TimeSpan(-8, 0, 0));
dateString = originalDTO.ToString("o");
DateTimeOffset newDTO = DateTimeOffset.Parse(dateString, null, DateTimeStyles.RoundtripKind);
Console.WriteLine("Round-tripped {0} to {1}.", originalDTO, newDTO);
// The example displays the following output:
//    Round-tripped 4/10/2008 6:30:00 AM Local to 4/10/2008 6:30:00 AM Local.
//    Round-tripped 4/12/2008 9:30:00 AM Utc to 4/12/2008 9:30:00 AM Utc.
//    Round-tripped 4/13/2008 12:30:00 PM Unspecified to 4/13/2008 12:30:00 PM Unspecified.
//    Round-tripped 4/12/2008 9:30:00 AM -08:00 to 4/12/2008 9:30:00 AM -08:00.
```

```vb
' Round-trip DateTime values.
Dim originalDate, newDate As Date
Dim dateString As String
' Round-trip a local time.
originalDate = Date.SpecifyKind(#4/10/2008 6:30AM#, DateTimeKind.Local)
dateString = originalDate.ToString("o")
newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                  newDate, newDate.Kind)
' Round-trip a UTC time.
originalDate = Date.SpecifyKind(#4/12/2008 9:30AM#, DateTimeKind.Utc)                  
dateString = originalDate.ToString("o")
newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                  newDate, newDate.Kind)
' Round-trip time in an unspecified time zone.
originalDate = Date.SpecifyKind(#4/13/2008 12:30PM#, DateTimeKind.Unspecified)                  
dateString = originalDate.ToString("o")
newDate = Date.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, _
                  newDate, newDate.Kind)

' Round-trip a DateTimeOffset value.
Dim originalDTO As New DateTimeOffset(#4/12/2008 9:30AM#, New TimeSpan(-8, 0, 0))
dateString = originalDTO.ToString("o")
Dim newDTO As DateTimeOffset = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.RoundtripKind)
Console.WriteLine("Round-tripped {0} to {1}.", originalDTO, newDTO)
' The example displays the following output:
'    Round-tripped 4/10/2008 6:30:00 AM Local to 4/10/2008 6:30:00 AM Local.
'    Round-tripped 4/12/2008 9:30:00 AM Utc to 4/12/2008 9:30:00 AM Utc.
'    Round-tripped 4/13/2008 12:30:00 PM Unspecified to 4/13/2008 12:30:00 PM Unspecified.
'    Round-tripped 4/12/2008 9:30:00 AM -08:00 to 4/12/2008 9:30:00 AM -08:00.
```

## The RFC1123 ("R", "r") format specifier

The "R" or "r" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.RFC1123Pattern](xref:System.Globalization.DateTimeFormatInfo.RFC1123Pattern) property. The pattern reflects a defined standard, and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'". When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture.

The result string is affected by the following properties of the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object returned by the [DateTimeFormatInfo.InvariantInfo](xref:System.Globalization.DateTimeFormatInfo.InvariantInfo) property that represents the invariant culture.

Property | Description
-------- | -----------
[RFC1123Pattern](xref:System.Globalization.DateTimeFormatInfo.RFC1123Pattern) | Defines the format of the result string.
[AbbreviatedDayNames](xref:System.Globalization.DateTimeFormatInfo.AbbreviatedDayNames) | Defines the abbreviated day names that can appear in the result string.
[AbbreviatedMonthNames](xref:System.Globalization.DateTimeFormatInfo.AbbreviatedMonthNames) | Defines the abbreviated month names that can appear in the result string.

Although the RFC 1123 standard expresses a time as Coordinated Universal Time (UTC), the formatting operation does not modify the value of the [DateTime](xref:System.DateTime) object that is being formatted. Therefore, you must convert the [DateTime](xref:System.DateTime) value to UTC by calling the [DateTime.ToUniversalTime](xref:System.DateTime.ToUniversalTime) method before you perform the formatting operation. In contrast, [DateTimeOffset](xref:System.DateTimeOffset) values perform this conversion automatically; there is no need to call the [DateTimeOffset.ToUniversalTime](xref:System.DateTimeOffset.ToUniversalTime) method before the formatting operation. 

The following example uses the "r" format specifier to display a [DateTime](xref:System.DateTime) and a [DateTimeOffset](xref:System.DateTimeOffset) value on a system in the U.S. Pacific Time zone.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
DateTimeOffset dateOffset = new DateTimeOffset(date1, 
                            TimeZoneInfo.Local.GetUtcOffset(date1));
Console.WriteLine(date1.ToUniversalTime().ToString("r"));
// Displays Thu, 10 Apr 2008 13:30:00 GMT                       
Console.WriteLine(dateOffset.ToUniversalTime().ToString("r"));
// Displays Thu, 10 Apr 2008 13:30:00 GMT  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Dim dateOffset As New DateTimeOffset(date1, TimeZoneInfo.Local.GetUtcOFfset(date1))
Console.WriteLine(date1.ToUniversalTime.ToString("r"))
' Displays Thu, 10 Apr 2008 13:30:00 GMT                       
Console.WriteLine(dateOffset.ToUniversalTime.ToString("r"))
' Displays Thu, 10 Apr 2008 13:30:00 GMT
```

## The sortable ("s") format specifier

The "s" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.SortableDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.SortableDateTimePattern) property. The pattern reflects a defined standard (ISO 8601), and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "yyyy'-'MM'-'dd'T'HH':'mm':'ss".

The purpose of the "s" format specifier is to produce result strings that sort consistently in ascending or descending order based on date and time values. As a result, although the "s" standard format specifier represents a date and time value in a consistent format, the formatting operation does not modify the value of the date and time object that is being formatted to reflect its [DateTime.Kind](xref:System.DateTime.Kind) property or its [DateTimeOffset.Offset](xref:System.DateTimeOffset.Offset)value. For example, the result strings produced by formatting the date and time values 2014-11-15T18:32:17+00:00 and 2014-11-15T18:32:17+08:00 are identical. 

When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture. 

The following example uses the "s" format specifier to display a [DateTime](xref:System.DateTime) and a [DateTimeOffset](xref:System.DateTimeOffset) value on a system in the U.S. Pacific Time zone.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("s"));
// Displays 2008-04-10T06:30:00
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("s"))
' Displays 2008-04-10T06:30:00 
```

## The short time ("t") format specifier

The "t" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) property. For example, the custom format string for the invariant culture is "HH:mm".

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[DateTimeFormatInfo.ShortTimePattern](xref:System.Globalization.DateTimeFormatInfo.ShortTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "t" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("t", 
                  CultureInfo.CreateSpecificCulture("en-us")));
// Displays 6:30 AM                        
Console.WriteLine(date1.ToString("t", 
                  CultureInfo.CreateSpecificCulture("es-ES")));
// Displays 6:30  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("t", _
                  CultureInfo.CreateSpecificCulture("en-us")))
' Displays 6:30 AM                        
Console.WriteLine(date1.ToString("t", _
                  CultureInfo.CreateSpecificCulture("es-ES")))
' Displays 6:30
```

## The long time ("T") format specifier

The "T" standard format specifier represents a custom date and time format string that is defined by a specific culture's [DateTimeFormatInfo.LongTimePattern](xref:System.Globalization.DateTimeFormatInfo.LongTimePattern) property. For example, the custom format string for the invariant culture is "HH:mm:ss".

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.LongTimePattern](xref:System.Globalization.DateTimeFormatInfo.LongTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[LongTimePattern](xref:System.Globalization.DateTimeFormatInfo.LongTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The following example uses the "T" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("T", 
                  CultureInfo.CreateSpecificCulture("en-us")));
// Displays 6:30:00 AM                       
Console.WriteLine(date1.ToString("T", 
                  CultureInfo.CreateSpecificCulture("es-ES")));
// Displays 6:30:00  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("T", _
                  CultureInfo.CreateSpecificCulture("en-us")))
' Displays 6:30:00 AM                       
Console.WriteLine(date1.ToString("T", _
                  CultureInfo.CreateSpecificCulture("es-ES")))
' Displays 6:30:00 
```

## The universal sortable ("u") format specifier

The "u" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.UniversalSortableDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.UniversalSortableDateTimePattern) property. The pattern reflects a defined standard, and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "yyyy'-'MM'-'dd HH':'mm':'ss'Z'". When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture. 

Although the result string should express a time as Coordinated Universal Time (UTC), no conversion of the original [DateTime](xref:System.DateTime) value is performed during the formatting operation. Therefore, you must convert a [DateTime](xref:System.DateTime) value to UTC by calling the [DateTime.ToUniversalTime](xref:System.DateTime.ToUniversalTime) method before formatting it. In contrast, [DateTimeOffset](xref:System.DateTimeOffset) values perform this conversion automatically; there is no need to call the [DateTimeOffset.ToUniversalTime](xref:System.DateTimeOffset.ToUniversalTime) method before the formatting operation.   

The following example uses the "u" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToUniversalTime().ToString("u"));
// Displays 2008-04-10 13:30:00Z
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToUniversalTime.ToString("u"))
' Displays 2008-04-10 13:30:00Z                       
```

## The universal full ("U") format specifier

The "U" standard format specifier represents a custom date and time format string that is defined by a specified culture's [DateTimeFormatInfo.FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) property. The pattern is the same as the "F" pattern. However, the [DateTime](xref:System.DateTime) value is automatically converted to UTC before it is formatted.

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[FullDateTimePattern](xref:System.Globalization.DateTimeFormatInfo.FullDateTimePattern) | Defines the overall format of the result string.
[DayNames](xref:System.Globalization.DateTimeFormatInfo.DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](xref:System.Globalization.DateTimeFormatInfo.AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](xref:System.Globalization.DateTimeFormatInfo.PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The "U" format specifier is not supported by the [DateTimeOffset](xref:System.DateTimeOffset) type and throws a [FormatException](xref:System.FormatException) if it is used to format a [DateTimeOffset](xref:System.DateTimeOffset) value.

The following example uses the "U" format specifier to display a date and time value.

``` csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("U", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays Thursday, April 10, 2008 1:30:00 PM                       
Console.WriteLine(date1.ToString("U", 
                  CultureInfo.CreateSpecificCulture("sv-FI")));
// Displays den 10 april 2008 13:30:00  
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("U", CultureInfo.CreateSpecificCulture("en-US")))
' Displays Thursday, April 10, 2008 1:30:00 PM                       
Console.WriteLine(date1.ToString("U", CultureInfo.CreateSpecificCulture("sv-FI")))
' Displays den 10 april 2008 13:30:00                       
```

## The year month ("Y", "y") format specifier

The "Y" or "y" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.YearMonthPattern](xref:System.Globalization.DateTimeFormatInfo.YearMonthPattern) property of a specified culture. For example, the custom format string for the invariant culture is "yyyy MMMM".

The following table lists the [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[YearMonthPattern](xref:System.Globalization.DateTimeFormatInfo.YearMonthPattern) | Defines the overall format of the result string.
[MonthNames](xref:System.Globalization.DateTimeFormatInfo.MonthNames) | Defines the localized month names that can appear in the result string.

The following example uses the "y" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("Y", 
                  CultureInfo.CreateSpecificCulture("en-US")));
// Displays April, 2008                       
Console.WriteLine(date1.ToString("y", 
                  CultureInfo.CreateSpecificCulture("af-ZA")));
// Displays April 2008 
```

```vb
Dim date1 As Date = #4/10/2008 6:30AM#
Console.WriteLine(date1.ToString("Y", CultureInfo.CreateSpecificCulture("en-US")))
' Displays April, 2008                       
Console.WriteLine(date1.ToString("y", CultureInfo.CreateSpecificCulture("af-ZA")))
' Displays April 2008
```                       

## Notes

### DateTimeFormatInfo properties

Formatting is influenced by properties of the current [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object, which is provided implicitly by the current thread culture or explicitly by the [IFormatProvider](xref:System.IFormatProvider) parameter of the method that invokes formatting. For the [IFormatProvider](xref:System.IFormatProvider) parameter, your application should specify a [CultureInfo](xref:System.Globalization.CultureInfo) object, which represents a culture, or a [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object, which represents a particular culture's date and time formatting conventions. Many of the standard date and time format specifiers are aliases for formatting patterns defined by properties of the current [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) object. Your application can change the result produced by some standard date and time format specifiers by changing the corresponding date and time format patterns of the corresponding [DateTimeFormatInfo](xref:System.Globalization.DateTimeFormatInfo) property.

## See also

[Formatting types](formatting-types.md)

[Custom date and time format strings](custom-datetime.md)

