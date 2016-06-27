---
title: How to: Display Milliseconds in Date and Time Values
description: How to: Display Milliseconds in Date and Time Values
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: a9ccd37b-9d8a-416a-89f8-0edaa951e50a
---

# How to: Display Milliseconds in Date and Time Values

The default date and time formatting methods, such as [DateTime.ToString()](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString), include the hours, minutes, and seconds of a time value but exclude its milliseconds component. This topic shows how to include a date and time's millisecond component in formatted date and time strings.

## To display the millisecond component of a DateTime value

1. If you are working with the string representation of a date, convert it to a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value by using the static [DateTime.Parse(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_Parse_System_String_) or [DateTimeOffset.Parse(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_Parse_System_String_) method.

2. To extract the string representation of a time's millisecond component, call the date and time value's [DateTime.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_) or [DateTimeOffset.ToString](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_) method, and pass the `fff` or `FFF` custom format pattern either alone or with other custom format specifiers as the format parameter.

## Example

The example displays the millisecond component of a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) and a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value to the console, both alone and included in a longer date and time string. 

```csharp
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class MillisecondDisplay
{
   public static void Main()
   {
      string dateString = "7/16/2008 8:32:45.126 AM";

      try
      {
         DateTime dateValue = DateTime.Parse(dateString);
         DateTimeOffset dateOffsetValue = DateTimeOffset.Parse(dateString);

         // Display Millisecond component alone.
         Console.WriteLine("Millisecond component only: {0}", 
                           dateValue.ToString("fff"));
         Console.WriteLine("Millisecond component only: {0}", 
                           dateOffsetValue.ToString("fff"));

         // Display Millisecond component with full date and time.
         Console.WriteLine("Date and Time with Milliseconds: {0}", 
                           dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));                        
         Console.WriteLine("Date and Time with Milliseconds: {0}", 
                           dateOffsetValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));

         // Append millisecond pattern to current culture's full date time pattern
         string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
         fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", "$1.fff");

         // Display Millisecond component with modified full date and time pattern.
         Console.WriteLine("Modified full date time pattern: {0}", 
                           dateValue.ToString(fullPattern));
         Console.WriteLine("Modified full date time pattern: {0}",
                           dateOffsetValue.ToString(fullPattern));
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert {0} to a date.", dateString);
      }
   }
}
// The example displays the following output if the current culture is en-US:
//    Millisecond component only: 126
//    Millisecond component only: 126
//    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
//    Date and Time with Milliseconds: 07/16/2008 08:32:45.126 AM
//    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
//    Modified full date time pattern: Wednesday, July 16, 2008 8:32:45.126 AM
```

The `fff` format pattern includes any trailing zeros in the millisecond value. The `FFF` format pattern suppresses them. The difference is illustrated in the following example.

```csharp
DateTime dateValue = new DateTime(2008, 7, 16, 8, 32, 45, 180); 
Console.WriteLine(dateValue.ToString("fff"));    
Console.WriteLine(dateValue.ToString("FFF"));
// The example displays the following output to the console:
//    180
//    18 
```

A problem with defining a complete custom format specifier that includes the millisecond component of a date and time is that it defines a hard-coded format that may not correspond to the arrangement of time elements in the application's current culture. A better alternative is to retrieve one of the date and time display patterns defined by the current culture's [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object and modify it to include milliseconds. The example also illustrates this approach. It retrieves the current culture's full date and time pattern from the [DateTimeFormatInfo.FullDateTimePattern](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo#System_Globalization_DateTimeFormatInfo_FullDateTimePattern) property, and then inserts the custom pattern `.ffff` after its seconds pattern. Note that the example uses a regular expression to perform this operation in a single method call.

You can also use a custom format specifier to display a fractional part of seconds other than milliseconds. For example, the `f` or `F` custom format specifier displays tenths of a second, the `ff` or `FF` custom format specifier displays hundredths of a second, and the `ffff` or `FFFF` custom format specifier displays ten thousandths of a second. Fractional parts of a millisecond are truncated instead of rounded in the returned string. These format specifiers are used in the following example.

```csharp
DateTime dateValue = new DateTime(2008, 7, 16, 8, 32, 45, 180); 
Console.WriteLine("{0} seconds", dateValue.ToString("s.f"));
Console.WriteLine("{0} seconds", dateValue.ToString("s.ff"));      
Console.WriteLine("{0} seconds", dateValue.ToString("s.ffff"));
// The example displays the following output to the console:
//    45.1 seconds
//    45.18 seconds
//    45.1800 seconds
```

> **Note**
>
> It is possible to display very small fractional units of a second, such as ten thousandths of a second or hundred-thousandths of a second. However, these values may not be meaningful. The precision of date and time values depends on the resolution of the system clock.

## See Also

[System.Globalization/DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo)


