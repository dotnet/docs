---
title: How to: Extract the Day of the Week from a Specific Date
description: How to: Extract the Day of the Week from a Specific Date
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: c562e432-ef15-4c27-b580-c6f888504289
---

# How to: Extract the Day of the Week from a Specific Date

.NET Core makes it easy to determine the ordinal day of the week for a particular date, and to display the localized weekday name for a particular date. An enumerated value that indicates the day of the week corresponding to a particular date is available from the [Datetime.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_DayOfWeek) or [DateTimeOffset.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_DayOfWeek) property. In contrast, retrieving the weekday name is a formatting operation that can be performed by calling a formatting method, such as a date and time value's `ToString` method or the [String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_) method. This topic shows how to perform these formatting operations.

## To extract a number indicating the day of the week from a specific date

1. If you are working with the string representation of a date, convert it to a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value by using the static [DateTime.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_Parse_System_String_) or [DateTimeOffset.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) method.

2. Use the [Datetime.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_DayOfWeek) or [DateTimeOffset.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_DayOfWeek) property to retrieve a [DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DayOfWeek) value that indicates the day of the week.

3. If necessary, cast the [DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DayOfWeek) value to an integer. 

The following example displays an integer that represents the day of the week of a specific date. 

```csharp
using System;

public class Example
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2008, 6, 11);
      Console.WriteLine((int) dateValue.DayOfWeek);      
   }
}
// The example displays the following output:
//       3
```

## To extract the abbreviated weekday name from a specific date

1. If you are working with the string representation of a date, convert it to a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value by using the static [DateTime.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_Parse_System_String_) or [DateTimeOffset.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) method.

2. You can extract the abbreviated weekday name of the current culture or of a specific culture:

    a. To extract the abbreviated weekday name for the current culture, call the date and time value's [DateTime.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_) or [DateTimeOffset.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_) instance method, and pass the string "ddd" as the *format* parameter. The following example illustrates the call to the `ToString(String)` method.
    
    ```csharp
    using System;

    public class Example
    {
       public static void Main()
       {
          DateTime dateValue = new DateTime(2008, 6, 11);
          Console.WriteLine(dateValue.ToString("ddd"));   
       }
    }
    // The example displays the following output:
    //       Wed
    ```
    
    b. To extract the abbreviated weekday name for a specific culture, call the date and time value’s [DateTime.ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_System_IFormatProvider_) or [DateTimeOffset.ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_System_IFormatProvider_) instance method. Pass the string "ddd" as the *format* parameter. Pass either a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) or a [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object that represents the culture whose weekday name you want to retrieve as the *provider* parameter. The following code illustrates a call to the [ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_System_IFormatProvider_) method using a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object that represents the fr-FR culture.
    
    ```csharp
    using System;
    using System.Globalization;

    public class Example
    {
    public static void Main()
    {
        DateTime dateValue = new DateTime(2008, 6, 11);
        Console.WriteLine(dateValue.ToString("ddd", 
                            new CultureInfo("fr-FR")));    
    }
    }
    // The example displays the following output:
    //       mer. 
    ```
    
## To extract the full weekday name from a specific date

1. If you are working with the string representation of a date, convert it to a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or a [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value by using the static [DateTime.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_Parse_System_String_) or [DateTimeOffset.Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) method.

2. You can extract the abbreviated weekday name of the current culture or of a specific culture:

    a. To extract the abbreviated weekday name for the current culture, call the date and time value's [DateTime.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_) or [DateTimeOffset.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_) instance method, and pass the string "dddd" as the *format* parameter. The following example illustrates the call to the `ToString(String)` method.
    
    ```csharp
    using System;

    public class Example
    {
    public static void Main()
    {
        DateTime dateValue = new DateTime(2008, 6, 11);
        Console.WriteLine(dateValue.ToString("dddd"));    
    }
    }
    // The example displays the following output:
    //       Wednesday
    ```
    
    b. To extract the weekday name for a specific culture, call the date and time value’s [DateTime.ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_System_IFormatProvider_) or [DateTimeOffset.ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_System_IFormatProvider_) instance method. Pass the string "dddd" as the *format* parameter. Pass either a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) or a [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object that represents the culture whose weekday name you want to retrieve as the *provider* parameter. The following code illustrates a call to the [ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_System_IFormatProvider_) method using a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object that represents the es-ES  culture.
    
    ```csharp
    using System;
    using System.Globalization;

    public class Example
    {
    public static void Main()
    {
        DateTime dateValue = new DateTime(2008, 6, 11);
        Console.WriteLine(dateValue.ToString("dddd", 
                            new CultureInfo("es-ES")));    
    }
    }
    // The example displays the following output:
    //       miércoles.
    ```
    
## Example

The example illustrates calls to the [Datetime.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_DayOfWeek) and [DateTimeOffset.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_DayOfWeek) properties and the [DateTime.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_) or [DateTimeOffset.ToString(String)](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ToString_System_String_) methods to retrieve the number that represents the day of the week, the abbreviated weekday name, and the full weekday name for a particular date. 

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string dateString = "6/11/2007";
      DateTime dateValue;
      DateTimeOffset dateOffsetValue;

      try
      {
         DateTimeFormatInfo dateTimeFormats;
         // Convert date representation to a date value
         dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
         dateOffsetValue = new DateTimeOffset(dateValue, 
                                      TimeZoneInfo.Local.GetUtcOffset(dateValue));         

         // Convert date representation to a number indicating the day of week
         Console.WriteLine((int) dateValue.DayOfWeek);
         Console.WriteLine((int) dateOffsetValue.DayOfWeek);

         // Display abbreviated weekday name using current culture
         Console.WriteLine(dateValue.ToString("ddd"));
         Console.WriteLine(dateOffsetValue.ToString("ddd"));

         // Display full weekday name using current culture
         Console.WriteLine(dateValue.ToString("dddd"));
         Console.WriteLine(dateOffsetValue.ToString("dddd"));

         // Display abbreviated weekday name for de-DE culture
         Console.WriteLine(dateValue.ToString("ddd", new CultureInfo("de-DE")));
         Console.WriteLine(dateOffsetValue.ToString("ddd", 
                                                     new CultureInfo("de-DE")));

         // Display abbreviated weekday name with de-DE DateTimeFormatInfo object
         dateTimeFormats = new CultureInfo("de-DE").DateTimeFormat;
         Console.WriteLine(dateValue.ToString("ddd", dateTimeFormats));
         Console.WriteLine(dateOffsetValue.ToString("ddd", dateTimeFormats));

         // Display full weekday name for fr-FR culture
         Console.WriteLine(dateValue.ToString("ddd", new CultureInfo("fr-FR")));
         Console.WriteLine(dateOffsetValue.ToString("ddd", 
                                                    new CultureInfo("fr-FR")));

         // Display abbreviated weekday name with fr-FR DateTimeFormatInfo object
         dateTimeFormats = new CultureInfo("fr-FR").DateTimeFormat;
         Console.WriteLine(dateValue.ToString("dddd", dateTimeFormats));
         Console.WriteLine(dateOffsetValue.ToString("dddd", dateTimeFormats));
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to convert {0} to a date.", dateString);
      }
   }
}
// The example displays the following output:
//       1
//       1
//       Mon
//       Mon
//       Monday
//       Monday
//       Mo
//       Mo
//       Mo
//       Mo
//       lun.
//       lun.
//       lundi
//       lundi
```

You can also use the value returned by the [Datetime.DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_DayOfWeek) property to retrieve the weekday name of a particular date. This requires only a call to the [Enum.ToString](https://docs.microsoft.com/dotnet/core/api/System.Enum#System_Enum_System_IConvertible_ToString_System_IFormatProvider_) method on the [DayOfWeek](https://docs.microsoft.com/dotnet/core/api/System.DayOfWeek) value returned by the property. However, this technique does not produce a localized weekday name for the current culture, as the following example illustrates. 

```csharp
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // Change current culture to fr-FR
      CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

      DateTime dateValue = new DateTime(2008, 6, 11);
      // Display the DayOfWeek string representation
      Console.WriteLine(dateValue.DayOfWeek.ToString());   
      // Restore original current culture
      Thread.CurrentThread.CurrentCulture = originalCulture;
   }
}
// The example displays the following output:
//       Wednesday
```





