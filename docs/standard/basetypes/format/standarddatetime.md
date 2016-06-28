---
title: Standard Date and Time Format Strings
description: Standard Date and Time Format Strings
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 76214bda-5607-48bd-b9ee-b8888bdaf1e7
---

# Standard Date and Time Format Strings

A standard date and time format string uses a single format specifier to define the text representation of a date and time value. Any date and time format string that contains more than one character, including white space, is interpreted as a custom date and time format string; for more information, see [Custom Date and Time Format Strings](customdatetime.md). A standard or custom format string can be used in two ways:

* To define the string that results from a formatting operation.

* To define the text representation of a date and time value that can be converted to a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) or [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value by a parsing operation.

Standard date and time format strings can be used with both [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) and [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values. 

The following table describes the standard date and time format specifiers. Unless otherwise noted, a particular standard date and time format specifier produces an identical string representation regardless of whether it is used with a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) or a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value. See the [Notes](#Notes) section for additional information about using standard date and time format strings.

Format specifier | Description | Examples
---------------- | ----------- | --------
"d" | Short date pattern. | `2009-06-15T13:45:30 -> 6/15/2009 (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 (fr-FR)`; `2009-06-15T13:45:30 -> 2009/06/15 (ja-JP)`
"D" | Long date pattern. | `2009-06-15T13:45:30 -> Monday, June 15, 2009 (en-US)`; `2009-06-15T13:45:30 -> 15 июня 2009 г. (ru-RU)`; `2009-06-15T13:45:30 -> Montag, 15. Juni 2009 (de-DE)`
"f" | Full date/time pattern (short time). | `2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 13:45 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45 μμ (el-GR)`
"F" | Full date/time pattern (long time). | `2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 13:45:30 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45:30 μμ (el-GR)`
"g" | General date/time pattern (short time). | `2009-06-15T13:45:30 -> 6/15/2009 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 13:45 (es-ES)`; `2009-06-15T13:45:30 -> 2009/6/15 13:45 (zh-CN)`
"G" | General date/time pattern (long time). | `2009-06-15T13:45:30 -> 6/15/2009 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> 15/06/2009 13:45:30 (es-ES)`; `2009-06-15T13:45:30 -> 2009/6/15 13:45:30 (zh-CN)`
"M", "m' | Month/day pattern. | `2009-06-15T13:45:30 -> June 15 (en-US)`; `2009-06-15T13:45:30 -> 15. juni (da-DK)`; `2009-06-15T13:45:30 -> 15 Juni (id-ID)`
"O", "o" | Round-trip date/time pattern. | [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) values: `2009-06-15T13:45:30 (DateTimeKind.Local) --> 2009-06-15T13:45:30.0000000-07:00`; `2009-06-15T13:45:30 (DateTimeKind.Utc) --> 2009-06-15T13:45:30.0000000Z`; `2009-06-15T13:45:30 (DateTimeKind.Unspecified) --> 2009-06-15T13:45:30.0000000`. [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values: `2009-06-15T13:45:30-07:00 --> 2009-06-15T13:45:30.0000000-07:00`
"R", "r" | RFC1123 pattern. | `2009-06-15T13:45:30 -> Mon, 15 Jun 2009 20:45:30 GMT`
"s" | Sortable date/time pattern. | `2009-06-15T13:45:30 (DateTimeKind.Local) -> 2009-06-15T13:45:30`; `2009-06-15T13:45:30 (DateTimeKind.Utc) -> 2009-06-15T13:45:30`
"t" | Short time pattern. | `2009-06-15T13:45:30 -> 1:45 PM (en-US)`; `2009-06-15T13:45:30 -> 13:45 (hr-HR)`; `2009-06-15T13:45:30 -> 01:45 م (ar-EG)` 
"T" | Long time pattern. | `2009-06-15T13:45:30 -> 1:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> 13:45:30 (hr-HR)`; `2009-06-15T13:45:30 -> 01:45:30 م (ar-EG)`
"u" | Universal sortable date/time pattern. | With a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) value: `2009-06-15T13:45:30 -> 2009-06-15 13:45:30Z`. With a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value: `2009-06-15T13:45:30 -> 2009-06-15 20:45:30Z`
"U" | Universal full date/time pattern. | `2009-06-15T13:45:30 -> Monday, June 15, 2009 8:45:30 PM (en-US)`; `2009-06-15T13:45:30 -> den 15 juni 2009 20:45:30 (sv-SE)`; `2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 8:45:30 μμ (el-GR)`
"Y", "y" | Year month pattern. | `2009-06-15T13:45:30 -> June, 2009 (en-US)`; `2009-06-15T13:45:30 -> juni 2009 (da-DK)`; `2009-06-15T13:45:30 -> Juni 2009 (id-ID)`
Any other single character | Unknown specifier. | Throws a run-time [FormatException](https://docs.microsoft.com/dotnet/core/api/System.FormatException ).

## How Standard Format Strings Work

In a formatting operation, a standard format string is simply an alias for a custom format string. The advantage of using an alias to refer to a custom format string is that, although the alias remains invariant, the custom format string itself can vary. This is important because the string representations of date and time values typically vary by culture. For example, the "d" standard format string indicates that a date and time value is to be displayed using a short date pattern. For the invariant culture, this pattern is "MM/dd/yyyy". For the fr-FR culture, it is "dd/MM/yyyy". For the ja-JP culture, it is "yyyy/MM/dd".

If a standard format string in a formatting operation maps to a particular culture's custom format string, your application can define the specific culture whose custom format strings are used in one of these ways:

* You can use the default (or current) culture. The following example displays a date using the current culture's short date format. In this case, the current culture is en-US.

  ```csharp
  // Display using current (en-us) culture's short date format
DateTime thisDate = new DateTime(2008, 3, 15);
Console.WriteLine(thisDate.ToString("d"));           // Displays 3/15/2008
  ```
  
* You can pass a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo ) object representing the culture whose formatting is to be used to a method that has an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider ) parameter. The following example displays a date using the short date format of the pt-BR culture.
  
  ```csharp
  // Display using pt-BR culture's short date format
DateTime thisDate = new DateTime(2008, 3, 15);
CultureInfo culture = new CultureInfo("pt-BR");      
Console.WriteLine(thisDate.ToString("d", culture));  // Displays 15/3/2008
  ```
  
* You can pass a [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object that provides formatting information to a method that has an [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider ) parameter. The following example displays a date using the short date format from a DateTimeFormatInfo object for the hr-HR culture.  

  ```csharp
  // Display using date format information from hr-HR culture
DateTime thisDate = new DateTime(2008, 3, 15);
DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;
Console.WriteLine(thisDate.ToString("d", fmt));      // Displays 15.3.2008
  ```
  
In some cases, the standard format string serves as a convenient abbreviation for a longer custom format string that is invariant. Four standard format strings fall into this category: "O" (or "o"), "R" (or "r"), "s", and "u". These strings correspond to custom format strings defined by the invariant culture. They produce string representations of date and time values that are intended to be identical across cultures. The following table provides information on these four standard date and time format strings.

Standard format string | Defined by DateTimeFormatInfo.InvariantInfo property | Custom format string
---------------------- | ---------------------------------------------------- | --------------------
"O" or "o" | None | `yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzz`
"R" or "r" | [RFC1123Pattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_RFC1123Pattern) | `ddd, dd MMM yyyy HH':'mm':'ss 'GMT'`
"s" | [SortableDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_SortableDateTimePattern) | `yyyy'-'MM'-'dd'T'HH':'mm':'ss`
"u" | [UniversalSortableDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_UniversalSortableDateTimePattern) | `yyyy'-'MM'-'dd HH':'mm':'ss'Z'`

The following sections describe the standard format specifiers for [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) and [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values. 

## The Short Date ("d") Format Specifier

The "d" standard format specifier represents a custom date and time format string that is defined by a specific culture's [DateTimeFormatInfo.ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) property. For example, the custom format string that is returned by the [ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) property of the invariant culture is "MM/dd/yyyy". 

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

## The Long Date ("D") Format Specifier

The "D" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.LongDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongDatePattern) property. For example, the custom format string for the invariant culture is "dddd, dd MMMM yyyy".

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[LongDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongDatePattern) | Defines the overall format of the result string.
[DayNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.

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

## The Full Date Short Time ("f") Format Specifier

The "f" standard format specifier represents a combination of the long date ("D") and short time ("t") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object. The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier returned by the [DateTimeFormatInfo.LongDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongDatePattern) and [DateTimeFormatInfo.ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[LongDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongDatePattern) | Defines the format of the date component of the result string.
[ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) | Defines the format of the time component of the result string.
[DayNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The Full Date Long Time ("F") Format Specifier

The "F" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) property. For example, the custom format string for the invariant culture is "dddd, dd MMMM yyyy HH:mm:ss".

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) | Defines the overall format of the result string.
[DayNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The General Date Short Time ("g") Format Specifier

The "g" standard format specifier represents a combination of the short date ("d") and short time ("t") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object. The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) and [DateTimeFormatInfo.ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) | Defines the format of the date component of the result string.
[ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The General Date Long Time ("G") Format Specifier

The "G" standard format specifier represents a combination of the short date ("d") and long time ("T") patterns, separated by a space.

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object. The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) and [DateTimeFormatInfo.LongTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongTimePattern) properties of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[ShortDatePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortDatePattern) | Defines the format of the date component of the result string.
[LongTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The Month ("M", "m") Format Specifier

The "M" or "m" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.MonthDayPattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthDayPattern) property. For example, the custom format string for the invariant culture is "MMMM dd".

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[MonthDayPattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthDayPattern) | Defines the overall format of the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.

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

## The Round-trip ("O", "o") Format Specifier

The "O" or "o" standard format specifier represents a custom date and time format string using a pattern that preserves time zone information and emits a result string that complies with ISO 8601. For [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) values, this format specifier is designed to preserve date and time values along with the [DateTime.Kind](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_Kind) property in text. The formatted string can be parsed back by using the [DateTime.Parse(String, IFormatProvider, DateTimeStyles)](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_Parse_System_String_System_IFormatProvider_System_Globalization_DateTimeStyles_) or [DateTime.ParseExact](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_Parse_System_String_System_IFormatProvider_System_Globalization_DateTimeStyles_) method if the styles parameter is set to [DateTimeStyles.RoundtripKind](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeStyles #System_Globalization_DateTimeStyles_RoundtripKind). 

The "O" or "o" standard format specifier corresponds to the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK" custom format string for DateTime values and to the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz" custom format string for [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values. In this string, the pairs of single quotation marks that delimit individual characters, such as the hyphens, the colons, and the letter "T", indicate that the individual character is a literal that cannot be changed. The apostrophes do not appear in the output string. 

The O" or "o" standard format specifier (and the "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK" custom format string) takes advantage of the three ways that ISO 8601 represents time zone information to preserve the [Kind](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_Kind) property of [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) values: 

* The time zone component of [DateTimeKind.Local](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind #System_DateTimeKind_Local) date and time values is an offset from UTC (for example, +01:00, -07:00). All DateTimeOffset values are also represented in this format. 

* The time zone component of [DateTimeKind.Utc](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind #System_DateTimeKind_Utc) date and time values uses "Z" (which stands for zero offset) to represent UTC. 

* [DateTimeKind.Unspecified](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind #System_DateTimeKind_Unspecified) date and time values have no time zone information. 

Because the O" or "o" standard format specifier conforms to an international standard, the formatting or parsing operation that uses the specifier always uses the invariant culture and the Gregorian calendar. 

Strings that are passed to the `Parse`, `TryParse`, `ParseExact`, and `TryParseExact` methods of [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) and [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) can be parsed by using the "O" or "o" format specifier if they are in one of these formats. In the case of [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) objects, the parsing overload that you call should also include a styles parameter with a value of [DateTimeStyles.RoundtripKind](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeStyles #System_Globalization_DateTimeStyles_RoundtripKind). Note that if you call a parsing method with the custom format string that corresponds to the "O" or "o" format specifier, you won't get the same results as "O" or "o". This is because parsing methods that use a custom format string can't parse the string representation of date and time values that lack a time zone component or use "Z" to indicate UTC. 

The following example uses the "o" format specifier to display a series of [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) values and a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value on a system in the U.S. Pacific Time zone. 

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

## The RFC1123 ("R", "r") Format Specifier

The "R" or "r" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.RFC1123Pattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_RFC1123Pattern) property. The pattern reflects a defined standard, and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'". When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture.

The result string is affected by the following properties of the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object returned by the [DateTimeFormatInfo.InvariantInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_InvariantInfo) property that represents the invariant culture.

Property | Description
-------- | -----------
[RFC1123Pattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_RFC1123Pattern) | Defines the format of the result string.
[AbbreviatedDayNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AbbreviatedDayNames) | Defines the abbreviated day names that can appear in the result string.
[AbbreviatedMonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AbbreviatedMonthNames) | Defines the abbreviated month names that can appear in the result string.

Although the RFC 1123 standard expresses a time as Coordinated Universal Time (UTC), the formatting operation does not modify the value of the [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) object that is being formatted. Therefore, you must convert the [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) value to UTC by calling the [DateTime.ToUniversalTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_ToUniversalTime) method before you perform the formatting operation. In contrast, [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values perform this conversion automatically; there is no need to call the [DateTimeOffset.ToUniversalTime](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset #System_DateTimeOffset_ToUniversalTime) method before the formatting operation. 

The following example uses the "r" format specifier to display a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) and a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value on a system in the U.S. Pacific Time zone.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
DateTimeOffset dateOffset = new DateTimeOffset(date1, 
                            TimeZoneInfo.Local.GetUtcOffset(date1));
Console.WriteLine(date1.ToUniversalTime().ToString("r"));
// Displays Thu, 10 Apr 2008 13:30:00 GMT                       
Console.WriteLine(dateOffset.ToUniversalTime().ToString("r"));
// Displays Thu, 10 Apr 2008 13:30:00 GMT  
```

## The Sortable ("s") Format Specifier

The "s" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.SortableDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_SortableDateTimePattern) property. The pattern reflects a defined standard (ISO 8601), and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "yyyy'-'MM'-'dd'T'HH':'mm':'ss".

The purpose of the "s" format specifier is to produce result strings that sort consistently in ascending or descending order based on date and time values. As a result, although the "s" standard format specifier represents a date and time value in a consistent format, the formatting operation does not modify the value of the date and time object that is being formatted to reflect its [DateTime.Kind](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_Kind) property or its [DateTimeOffset.Offset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset #System_DateTimeOffset_Offset)value. For example, the result strings produced by formatting the date and time values 2014-11-15T18:32:17+00:00 and 2014-11-15T18:32:17+08:00 are identical. 

When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture. 

The following example uses the "s" format specifier to display a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) and a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value on a system in the U.S. Pacific Time zone.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToString("s"));
// Displays 2008-04-10T06:30:00
```

## The Short Time ("t") Format Specifier

The "t" standard format specifier represents a custom date and time format string that is defined by the current [DateTimeFormatInfo.ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) property. For example, the custom format string for the invariant culture is "HH:mm".

The result string is affected by the formatting information of a specific [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object. The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[DateTimeFormatInfo.ShortTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_ShortTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The Long Time ("T") Format Specifier

The "T" standard format specifier represents a custom date and time format string that is defined by a specific culture's [DateTimeFormatInfo.LongTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongTimePattern) property. For example, the custom format string for the invariant culture is "HH:mm:ss".

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [DateTimeFormatInfo.LongTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[LongTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_LongTimePattern) | Defines the format of the time component of the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

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

## The Universal Sortable ("u") Format Specifier

The "u" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.UniversalSortableDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_UniversalSortableDateTimePattern) property. The pattern reflects a defined standard, and the property is read-only. Therefore, it is always the same, regardless of the culture used or the format provider supplied. The custom format string is "yyyy'-'MM'-'dd HH':'mm':'ss'Z'". When this standard format specifier is used, the formatting or parsing operation always uses the invariant culture. 

Although the result string should express a time as Coordinated Universal Time (UTC), no conversion of the original [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) value is performed during the formatting operation. Therefore, you must convert a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) value to UTC by calling the [DateTime.ToUniversalTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime #System_DateTime_ToUniversalTime) method before formatting it. In contrast, [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) values perform this conversion automatically; there is no need to call the [DateTimeOffset.ToUniversalTime](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset #System_DateTimeOffset_ToUniversalTime) method before the formatting operation.   

The following example uses the "u" format specifier to display a date and time value.

```csharp
DateTime date1 = new DateTime(2008, 4, 10, 6, 30, 0);
Console.WriteLine(date1.ToUniversalTime().ToString("u"));
// Displays 2008-04-10 13:30:00Z
```

## The Universal Full ("U") Format Specifier

The "U" standard format specifier represents a custom date and time format string that is defined by a specified culture's [DateTimeFormatInfo.FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) property. The pattern is the same as the "F" pattern. However, the [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime ) value is automatically converted to UTC before it is formatted.

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that may control the formatting of the returned string. The custom format specifier that is returned by the [FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) property of some cultures may not make use of all properties.

Property | Description
-------- | -----------
[FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_FullDateTimePattern) | Defines the overall format of the result string.
[DayNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_DayNames) | Defines the localized day names that can appear in the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.
[AMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_AMDesignator) | Defines the string that indicates times from midnight to before noon in a 12-hour clock.
[PMDesignator](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_PMDesignator) | Defines the string that indicates times from noon to before midnight in a 12-hour clock.

The "U" format specifier is not supported by the [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) type and throws a [FormatException](https://docs.microsoft.com/dotnet/core/api/System.FormatException ) if it is used to format a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset ) value.

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

## The Year Month ("Y", "y") Format Specifier

The "Y" or "y" standard format specifier represents a custom date and time format string that is defined by the [DateTimeFormatInfo.YearMonthPattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_YearMonthPattern) property of a specified culture. For example, the custom format string for the invariant culture is "yyyy MMMM".

The following table lists the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object properties that control the formatting of the returned string.

Property | Description
-------- | -----------
[YearMonthPattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_YearMonthPattern) | Defines the overall format of the result string.
[MonthNames](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo #System_Globalization_DateTimeFormatInfo_MonthNames) | Defines the localized month names that can appear in the result string.

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

## Notes

### DateTimeFormatInfo Properties

Formatting is influenced by properties of the current [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object, which is provided implicitly by the current thread culture or explicitly by the [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider ) parameter of the method that invokes formatting. For the [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider ) parameter, your application should specify a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo ) object, which represents a culture, or a [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object, which represents a particular culture's date and time formatting conventions. Many of the standard date and time format specifiers are aliases for formatting patterns defined by properties of the current [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) object. Your application can change the result produced by some standard date and time format specifiers by changing the corresponding date and time format patterns of the corresponding [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo ) property.

## See Also

[Custom Date and Time Format Strings](customdatetime.md)






