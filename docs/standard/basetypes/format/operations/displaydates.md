---
title: How to: Display Dates in Non-Gregorian Calendars
description: How to: Display Dates in Non-Gregorian Calendars
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 117f853f-8b81-4842-bf80-5a6b15484586
---

# How to: Display Dates in Non-Gregorian Calendars

The [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) and [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) types use the Gregorian calendar as their default calendar. This means that calling a date and time value's `ToString` method displays the string representation of that date and time in the Gregorian calendar, even if that date and time was created using another calendar. This is illustrated in the following example, which uses two different ways to create a date and time value with the Persian calendar, but still displays those date and time values in the Gregorian calendar when it calls the [ToString](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString) method. This example reflects two commonly used but incorrect techniques for displaying the date in a particular calendar.

```csharp
PersianCalendar persianCal = new PersianCalendar();

DateTime persianDate = persianCal.ToDateTime(1387, 3, 18, 12, 0, 0, 0);
Console.WriteLine(persianDate.ToString());

persianDate = new DateTime(1387, 3, 18, persianCal);
Console.WriteLine(persianDate.ToString());
// The example displays the following output to the console:
//       6/7/2008 12:00:00 PM
//       6/7/2008 12:00:00 AM
```

Two different techniques can be used to display the date in a particular calendar. The first requires that the calendar be the default calendar for a particular culture. The second can be used with any calendar.

## To display the date for a culture's default calendar

1. Instantiate a calendar object derived from the [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar) class that represents the calendar to be used.

2. Instantiate a [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object representing the culture whose formatting will be used to display the date.

3. Call the [Array.Exists&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Array#System_Array_Exists__1___0___System_Predicate___0__) method to determine whether the calendar object is a member of the array returned by the [CultureInfo.OptionalCalendars](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_OptionalCalendars) property. This indicates that the calendar can serve as the default calendar for the [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object. If it is not a member of the array, follow the instructions in the "To Display the Date in Any Calendar" section.

4. Assign the calendar object to the [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo#System_Globalization_DateTimeFormatInfo_Calendar) property of the [DateTimeFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo) object returned by the [CultureInfo.DateTimeFormat](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_DateTimeFormat) property.

  > **Note**
  >
  > The [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) class also has a [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_Calendar) property. However, it is read-only and constant; it does not change to reflect the new default calendar assigned to the [DateTimeFormatInfo.Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo#System_Globalization_DateTimeFormatInfo_Calendar) property.
  
5. Call either the [DateTime.ToString(IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_IFormatProvider_) or the [DateTime.ToString(String, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_ToString_System_String_System_IFormatProvider_) method, and pass it the [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object whose default calendar was modified in the previous step.

## To display the date in any calendar

1. Instantiate a calendar object derived from the [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar) class that represents the calendar to be used.

2. Determine which date and time elements should appear in the string representation of the date and time value.

3. For each date and time element that you want to display, call the calendar object's `Get…` method. The following methods are available:

    * [GetYear](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetYear_System_DateTime_), to display the year in the appropriate calendar.
    
    * [GetMonth](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetMonth_System_DateTime_), to display the month in the appropriate calendar. 
    
    * [GetDayOfMonth](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetDayOfMonth_System_DateTime_), to display the number of the day of the month in the appropriate calendar.
    
    * [GetHour](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetHour_System_DateTime_), to display the hour of the day in the appropriate calendar.
    
    * [GetMinute](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetMinute_System_DateTime_), to display the minutes in the hour in the appropriate calendar.
    
    * [GetSecond](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetSecond_System_DateTime_), to display the seconds in the minute in the appropriate calendar. 
    
    * [GetMilliseconds](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar#System_Globalization_Calendar_GetMilliseconds_System_DateTime_) , to display the milliseconds in the second in the appropriate calendar.
    
## Example
    
The example displays a date using two different calendars. It displays the date after defining the Hijri calendar as the default calendar for the ar-JO culture, and displays the date using the Persian calendar, which is not supported as an optional calendar by the fa-IR culture.

```csharp
using System;
using System.Globalization;

public class CalendarDates
{
   public static void Main()
   {
      HijriCalendar hijriCal = new HijriCalendar();
      CalendarUtility hijriUtil = new CalendarUtility(hijriCal);
      DateTime dateValue1 = new DateTime(1429, 6, 29, hijriCal);
      DateTimeOffset dateValue2 = new DateTimeOffset(dateValue1, 
                                  TimeZoneInfo.Local.GetUtcOffset(dateValue1));
      CultureInfo jc = CultureInfo.CreateSpecificCulture("ar-JO");

      // Display the date using the Gregorian calendar.
      Console.WriteLine("Using the system default culture: {0}", 
                        dateValue1.ToString("d"));
      // Display the date using the ar-JO culture's original default calendar.
      Console.WriteLine("Using the ar-JO culture's original default calendar: {0}", 
                        dateValue1.ToString("d", jc));
      // Display the date using the Hijri calendar.
      Console.WriteLine("Using the ar-JO culture with Hijri as the default calendar:");
      // Display a Date value.
      Console.WriteLine(hijriUtil.DisplayDate(dateValue1, jc));
      // Display a DateTimeOffset value.
      Console.WriteLine(hijriUtil.DisplayDate(dateValue2, jc));

      Console.WriteLine();

      PersianCalendar persianCal = new PersianCalendar();
      CalendarUtility persianUtil = new CalendarUtility(persianCal);
      CultureInfo ic = CultureInfo.CreateSpecificCulture("fa-IR");

      // Display the date using the ir-FA culture's default calendar.
      Console.WriteLine("Using the ir-FA culture's default calendar: {0}",       
                        dateValue1.ToString("d", ic));
      // Display a Date value.
      Console.WriteLine(persianUtil.DisplayDate(dateValue1, ic));
      // Display a DateTimeOffset value.
      Console.WriteLine(persianUtil.DisplayDate(dateValue2, ic));
   }
}

public class CalendarUtility
{
   private Calendar thisCalendar;
   private CultureInfo targetCulture;

   public CalendarUtility(Calendar cal)
   {
      this.thisCalendar = cal;
   }

   private bool CalendarExists(CultureInfo culture)
   {
      this.targetCulture = culture;
      return Array.Exists(this.targetCulture.OptionalCalendars, 
                          this.HasSameName);
   }

   private bool HasSameName(Calendar cal)
   {
      if (cal.ToString() == thisCalendar.ToString())
         return true;
      else
         return false;
   }

   public string DisplayDate(DateTime dateToDisplay, CultureInfo culture)
   {
      DateTimeOffset displayOffsetDate = dateToDisplay;
      return DisplayDate(displayOffsetDate, culture);
   }

   public string DisplayDate(DateTimeOffset dateToDisplay, 
                             CultureInfo culture)
   {
      string specifier = "yyyy/MM/dd";

      if (this.CalendarExists(culture))
      {
         Console.WriteLine("Displaying date in supported {0} calendar...", 
                           this.thisCalendar.GetType().Name);
         culture.DateTimeFormat.Calendar = this.thisCalendar;
         return dateToDisplay.ToString(specifier, culture);
      }
      else
      {
         Console.WriteLine("Displaying date in unsupported {0} calendar...", 
                           thisCalendar.GetType().Name);

         string separator = targetCulture.DateTimeFormat.DateSeparator;

         return thisCalendar.GetYear(dateToDisplay.DateTime).ToString("0000") +
                separator +
                thisCalendar.GetMonth(dateToDisplay.DateTime).ToString("00") + 
                separator +
                thisCalendar.GetDayOfMonth(dateToDisplay.DateTime).ToString("00"); 
      }
   } 
}
// The example displays the following output to the console:
//       Using the system default culture: 7/3/2008
//       Using the ar-JO culture's original default calendar: 03/07/2008
//       Using the ar-JO culture with Hijri as the default calendar:
//       Displaying date in supported HijriCalendar calendar...
//       1429/06/29
//       Displaying date in supported HijriCalendar calendar...
//       1429/06/29
//       
//       Using the ir-FA culture's default calendar: 7/3/2008
//       Displaying date in unsupported PersianCalendar calendar...
//       1387/04/13
//       Displaying date in unsupported PersianCalendar calendar...
//       1387/04/13
```

Each [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object can support one or more calendars, which are indicated by the [OptionalCalendars](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_OptionalCalendars) property. One of these is designated as the culture's default calendar and is returned by the read-only [CultureInfo.Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_Calendar) property. Another of the optional calendars can be designated as the default by assigning a [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar) object that represents that calendar to the [DateTimeFormatInfo.Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.DateTimeFormatInfo#System_Globalization_DateTimeFormatInfo_Calendar) property returned by the [CultureInfo.DateTimeFormat](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_DateTimeFormat) property. However, some calendars, such as the Persian calendar represented by the [PersianCalendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.PersianCalendar) class, do not serve as optional calendars for any culture.   

The example defines a reusable calendar utility class, `CalendarUtility`, to handle many of the details of generating the string representation of a date using a particular calendar. The `CalendarUtility` class has the following members: 

* A parameterized constructor whose single parameter is a [Calendar](https://docs.microsoft.com/dotnet/core/api/System.Globalization.Calendar) object in which a date is to be represented. This is assigned to a private field of the class.

* `CalendarExists`, a private method that returns a Boolean value indicating whether the calendar represented by the `CalendarUtility` object is supported by the [CultureInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo) object that is passed to the method as a parameter. The method wraps a call to the [Array.Exists&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Array#System_Array_Exists__1___0___System_Predicate___0__) method, to which it passes the [CultureInfo.OptionalCalendars](https://docs.microsoft.com/dotnet/core/api/System.Globalization.CultureInfo#System_Globalization_CultureInfo_OptionalCalendars) array.

* `HasSameName`, a private method assigned to the [Predicate&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Predicate%601) delegate that is passed as a parameter to the [Array.Exists&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Array#System_Array_Exists__1___0___System_Predicate___0__) method. Each member of the array is passed to the method until the method returns `true`. The method determines whether the name of an optional calendar is the same as the calendar represented by the `CalendarUtility` object.

* `DisplayDate`, an overloaded public method that is passed two parameters: either a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value to express in the calendar represented by the `CalendarUtility` object; and the culture whose formatting rules are to be used. Its behavior in returning the string representation of a date depends on whether the target calendar is supported by the culture whose formatting rules are to be used.

Regardless of the calendar used to create a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) or [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) value in this example, that value is typically expressed as a Gregorian date. This is because the [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) and [DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) types do not preserve any calendar information. Internally, they are represented as the number of ticks that have elapsed since midnight of January 1, 0001. The interpretation of that number depends on the calendar. For most cultures, the default calendar is the Gregorian calendar. 



