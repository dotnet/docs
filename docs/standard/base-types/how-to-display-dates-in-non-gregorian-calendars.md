---
title: "How to: Display Dates in Non-Gregorian Calendars"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "formatting [.NET Framework], dates"
  - "dates [.NET Framework], formatting"
  - "calendars [.NET Framework], displaying dates"
  - "displaying date and time data"
ms.assetid: ed324eff-4aff-4a76-b6c0-04e6c0d8f5a9
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Display Dates in Non-Gregorian Calendars
The <xref:System.DateTime> and <xref:System.DateTimeOffset> types use the Gregorian calendar as their default calendar. This means that calling a date and time value's `ToString` method displays the string representation of that date and time in the Gregorian calendar, even if that date and time was created using another calendar. This is illustrated in the following example, which uses two different ways to create a date and time value with the Persian calendar, but still displays those date and time values in the Gregorian calendar when it calls the <xref:System.DateTime.ToString%2A> method. This example reflects two commonly used but incorrect techniques for displaying the date in a particular calendar.  
  
 [!code-csharp[Formatting.HowTo.Calendar#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.Calendar/cs/Calendar1.cs#1)]
 [!code-vb[Formatting.HowTo.Calendar#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.Calendar/vb/Calendar1.vb#1)]  
  
 Two different techniques can be used to display the date in a particular calendar. The first requires that the calendar be the default calendar for a particular culture. The second can be used with any calendar.  
  
### To display the date for a culture's default calendar  
  
1.  Instantiate a calendar object derived from the <xref:System.Globalization.Calendar> class that represents the calendar to be used.  
  
2.  Instantiate a <xref:System.Globalization.CultureInfo> object representing the culture whose formatting will be used to display the date.  
  
3.  Call the <xref:System.Array.Exists%2A?displayProperty=nameWithType> method to determine whether the calendar object is a member of the array returned by the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> property. This indicates that the calendar can serve as the default calendar for the <xref:System.Globalization.CultureInfo> object. If it is not a member of the array, follow the instructions in the "To Display the Date in Any Calendar" section.  
  
4.  Assign the calendar object to the <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A> property of the <xref:System.Globalization.DateTimeFormatInfo> object returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property.  
  
    > [!NOTE]
    >  The <xref:System.Globalization.CultureInfo> class also has a <xref:System.Globalization.CultureInfo.Calendar%2A> property. However, it is read-only and constant; it does not change to reflect the new default calendar assigned to the <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A?displayProperty=nameWithType> property.  
  
5.  Call either the <xref:System.DateTime.ToString%2A> or the <xref:System.DateTime.ToString%2A> method, and pass it the <xref:System.Globalization.CultureInfo> object whose default calendar was modified in the previous step.  
  
### To display the date in any calendar  
  
1.  Instantiate a calendar object derived from the <xref:System.Globalization.Calendar> class that represents the calendar to be used.  
  
2.  Determine which date and time elements should appear in the string representation of the date and time value.  
  
3.  For each date and time element that you want to display, call the calendar object's `Get`… method. The following methods are available:  
  
    -   <xref:System.Globalization.Calendar.GetYear%2A>, to display the year in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetMonth%2A>, to display the month in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetDayOfMonth%2A>, to display the number of the day of the month in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetHour%2A>, to display the hour of the day in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetMinute%2A>, to display the minutes in the hour in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetSecond%2A>, to display the seconds in the minute in the appropriate calendar.  
  
    -   <xref:System.Globalization.Calendar.GetMilliseconds%2A> , to display the milliseconds in the second in the appropriate calendar.  
  
## Example  
 The example displays a date using two different calendars. It displays the date after defining the Hijri calendar as the default calendar for the ar-JO culture, and displays the date using the Persian calendar, which is not supported as an optional calendar by the fa-IR culture.  
  
 [!code-csharp[Formatting.HowTo.Calendar#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.Calendar/cs/Calendar1.cs#2)]
 [!code-vb[Formatting.HowTo.Calendar#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.Calendar/vb/Calendar1.vb#2)]  
  
 Each <xref:System.Globalization.CultureInfo> object can support one or more calendars, which are indicated by the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A> property. One of these is designated as the culture's default calendar and is returned by the read-only <xref:System.Globalization.CultureInfo.Calendar%2A?displayProperty=nameWithType> property. Another of the optional calendars can be designated as the default by assigning a <xref:System.Globalization.Calendar> object that represents that calendar to the <xref:System.Globalization.DateTimeFormatInfo.Calendar%2A?displayProperty=nameWithType> property returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property. However, some calendars, such as the Persian calendar represented by the <xref:System.Globalization.PersianCalendar> class, do not serve as optional calendars for any culture.  
  
 The example defines a reusable calendar utility class, `CalendarUtility`, to handle many of the details of generating the string representation of a date using a particular calendar. The `CalendarUtility` class has the following members:  
  
-   A parameterized constructor whose single parameter is a <xref:System.Globalization.Calendar> object in which a date is to be represented. This is assigned to a private field of the class.  
  
-   `CalendarExists`, a private method that returns a Boolean value indicating whether the calendar represented by the `CalendarUtility` object is supported by the <xref:System.Globalization.CultureInfo> object that is passed to the method as a parameter. The method wraps a call to the <xref:System.Array.Exists%2A?displayProperty=nameWithType> method, to which it passes the <xref:System.Globalization.CultureInfo.OptionalCalendars%2A?displayProperty=nameWithType> array.  
  
-   `HasSameName`, a private method assigned to the <xref:System.Predicate%601> delegate that is passed as a parameter to the <xref:System.Array.Exists%2A?displayProperty=nameWithType> method. Each member of the array is passed to the method until the method returns `true`. The method determines whether the name of an optional calendar is the same as the calendar represented by the `CalendarUtility` object.  
  
-   `DisplayDate`, an overloaded public method that is passed two parameters: either a <xref:System.DateTime> or <xref:System.DateTimeOffset> value to express in the calendar represented by the `CalendarUtility` object; and the culture whose formatting rules are to be used. Its behavior in returning the string representation of a date depends on whether the target calendar is supported by the culture whose formatting rules are to be used.  
  
 Regardless of the calendar used to create a <xref:System.DateTime> or <xref:System.DateTimeOffset> value in this example, that value is typically expressed as a Gregorian date. This is because the <xref:System.DateTime> and <xref:System.DateTimeOffset> types do not preserve any calendar information. Internally, they are represented as the number of ticks that have elapsed since midnight of January 1, 0001. The interpretation of that number depends on the calendar. For most cultures, the default calendar is the Gregorian calendar.  
  
## Compiling the Code  
 This example requires a reference to System.Core.dll.  
  
 Compile the code at the command line using csc.exe or vb.exe. To compile the code in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], put it in a console application project template.  
  
## See Also  
 [Performing Formatting Operations](../../../docs/standard/base-types/performing-formatting-operations.md)
