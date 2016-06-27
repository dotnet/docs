---
title: Converting Between DateTime and DateTimeOffset
description: Converting Between DateTime and DateTimeOffset
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 08957e66-441a-4153-b57b-cc6a3c7b02f8
---

# Converting Between DateTime and DateTimeOffset

Although the [System.DateTimeOffset]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) structure provides a greater degree of time zone awareness than the [System.DateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTime) structure, `DateTime` parameters are used more commonly in method calls. Because of this, the ability to convert `DateTimeOffset` values to `DateTime` values and vice versa is particularly important. This article shows how to perform these conversions in a way that preserves as much time zone information as possible.

> **Note**
>
> Both the `DateTime` and the `DateTimeOffset` types have some limitations when representing times in time zones. With its `Kind` property, `DateTime` is able to reflect only Coordinated Universal Time (UTC) and the system's local time zone. `DateTimeOffset` reflects a time's offset from UTC, but it does not reflect the actual time zone to which that offset belongs. For details about time values and support for time zones, see [Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](choosing-between-datetime.md).

## Conversions from DateTime to DateTimeOffset

The `DateTimeOffset` structure provides two equivalent ways to perform `DateTime` to `DateTimeOffset` conversion that are suitable for most conversions:

* The [DateTimeOffset(DateTime)]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset__ctor_System_DateTime_) constructor, which creates a new `DateTimeOffset` object based on a `DateTime` value.

* The implicit conversion operator, which allows you to assign a `DateTime` value to a `DateTimeOffset` object.

For UTC and local `DateTime` values, the [DateTimeOffset.Offset]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_Offset) property of the resulting `DateTimeOffset` value accurately reflects the UTC or local time zone offset. For example, the following code converts a UTC time to its equivalent `DateTimeOffset` value. 

```csharp
DateTime utcTime1 = new DateTime(2008, 6, 19, 7, 0, 0);
utcTime1 = DateTime.SpecifyKind(utcTime1, DateTimeKind.Utc);
DateTimeOffset utcTime2 = utcTime1;
Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", 
                  utcTime1, 
                  utcTime1.Kind.ToString(), 
                  utcTime2);
// This example displays the following output to the console:
//    Converted 6/19/2008 7:00:00 AM Utc to a DateTimeOffset value of 6/19/2008 7:00:00 AM +00:00
```

In this case, the offset of the `utcTime2` variable is 00:00. Similarly, the following code converts a local time to its equivalent `DateTimeOffset` value.

```csharp
DateTime localTime1 = new DateTime(2008, 6, 19, 7, 0, 0);
localTime1 = DateTime.SpecifyKind(localTime1, DateTimeKind.Local);
DateTimeOffset localTime2 = localTime1;
Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", 
                  localTime1, 
                  localTime1.Kind.ToString(), 
                  localTime2);
// This example displays the following output to the console:
//    Converted 6/19/2008 7:00:00 AM Local to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
```

However, for `DateTime` values whose `Kind` property is [DateTimeKind.Unspecified]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Unspecified), these two conversion methods produce a `DateTimeOffset` value whose offset is that of the local time zone. This is shown in the following example, which is run in the U.S. Pacific Standard Time zone.

```csharp
DateTime time1 = new DateTime(2008, 6, 19, 7, 0, 0);  // Kind is DateTimeKind.Unspecified
DateTimeOffset time2 = time1;
Console.WriteLine("Converted {0} {1} to a DateTimeOffset value of {2}", 
                  time1, 
                  time1.Kind.ToString(), 
                  time2);
// This example displays the following output to the console:
//    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTimeOffset value of 6/19/2008 7:00:00 AM -07:00
```

If the `DateTime` value reflects the date and time in something other than the local time zone or UTC, you can convert it to a `DateTimeOffset` value and preserve its time zone information by calling the overloaded [DateTimeOffset(DateTime, TimeSpan)]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset__ctor_System_DateTime_System_TimeSpan_) constructor. For example, the following example instantiates a DateTimeOffset object that reflects Central Standard Time.

```csharp
DateTime time1 = new DateTime(2008, 6, 19, 7, 0, 0);     // Kind is DateTimeKind.Unspecified
try
{
   DateTimeOffset time2 = new DateTimeOffset(time1, 
                  TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(time1)); 
   Console.WriteLine("Converted {0} {1} to a DateTime value of {2}", 
                     time1, 
                     time1.Kind.ToString(), 
                     time2);
}
// Handle exception if time zone is not defined in registry
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("Unable to identify target time zone for conversion.");
}
// This example displays the following output to the console:
//    Converted 6/19/2008 7:00:00 AM Unspecified to a DateTime value of 6/19/2008 7:00:00 AM -05:00
```

The second parameter to this constructor overload, a [System.TimeSpan]( https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) object that represents the time's offset from UTC, should be retrieved by calling the [TimeZoneInfo.GetUtcOffset(DateTime)]( https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo#System_TimeZoneInfo_GetUtcOffset_System_DateTime_) method of the time's corresponding time zone. The method's single parameter is the `DateTime` value that represents the date and time to be converted. If the time zone supports daylight saving time, this parameter allows the method to determine the appropriate offset for that particular date and time.

## Conversions from DateTimeOffset to DateTime

The `DateTime` property is most commonly used to perform `DateTimeOffset` to `DateTime` conversion. However, it returns a `DateTime` value whose `Kind` property is [DateTimeKind.Unspecified]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Unspecified), as the following example illustrates. 

```csharp
DateTime baseTime = new DateTime(2008, 6, 19, 7, 0, 0);
DateTimeOffset sourceTime;
DateTime targetTime;

// Convert UTC to DateTime value
sourceTime = new DateTimeOffset(baseTime, TimeSpan.Zero);
targetTime = sourceTime.DateTime;
Console.WriteLine("{0} converts to {1} {2}", 
                  sourceTime, 
                  targetTime, 
                  targetTime.Kind.ToString());

// Convert local time to DateTime value
sourceTime = new DateTimeOffset(baseTime, 
                                TimeZoneInfo.Local.GetUtcOffset(baseTime));
targetTime = sourceTime.DateTime;
Console.WriteLine("{0} converts to {1} {2}", 
                  sourceTime, 
                  targetTime, 
                  targetTime.Kind.ToString());

// Convert Central Standard Time to a DateTime value
try
{
   TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(baseTime);
   sourceTime = new DateTimeOffset(baseTime, offset);
   targetTime = sourceTime.DateTime;
   Console.WriteLine("{0} converts to {1} {2}", 
                     sourceTime, 
                     targetTime, 
                     targetTime.Kind.ToString());
}
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("Unable to create DateTimeOffset based on U.S. Central Standard Time.");
} 
// This example displays the following output to the console:
//    6/19/2008 7:00:00 AM +00:00 converts to 6/19/2008 7:00:00 AM Unspecified
//    6/19/2008 7:00:00 AM -07:00 converts to 6/19/2008 7:00:00 AM Unspecified
//    6/19/2008 7:00:00 AM -05:00 converts to 6/19/2008 7:00:00 AM Unspecified 
```

This means that any information about the `DateTimeOffset` value's relationship to UTC is lost by the conversion when the `DateTime` property is used. This affects `DateTimeOffset` values that correspond to UTC time or to the system's local time because the `DateTime` structure reflects only those two time zones in its `Kind` property.

To preserve as much time zone information as possible when converting a `DateTimeOffset` to a `DateTime` value, you can use the [DateTimeOffset.UtcDateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_UtcDateTime) and [DateTimeOffset.LocalDateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_LocalDateTime) properties. 

## Converting a UTC Time

To indicate that a converted `DateTime` value is the UTC time, you can retrieve the value of the [DateTimeOffset.UtcDateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_UtcDateTime) property. It differs from the [DateTimeOffset.DateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_DateTime) property in two ways:

* It returns a `DateTime` value whose `Kind` property is [DateTimeKind.Utc]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Utc).

* If the [DateTimeOffset.Offset]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_Offset) property value does not equal [TimeSpan.Zero]( https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_Zero), it converts the time to UTC.

> **Note**
>
> If your application requires that converted `DateTime` values unambiguously identify a single point in time, you should consider using the `DateTimeOffset.UtcDateTime` property to handle all `DateTimeOffset` to `DateTime` conversions.

The following code uses the `UtcDateTime` property to convert a `DateTimeOffset` value whose offset equals `TimeSpan.Zero` to a `DateTime` value.

```csharp
DateTimeOffset utcTime1 = new DateTimeOffset(2008, 6, 19, 7, 0, 0, TimeSpan.Zero);
DateTime utcTime2 = utcTime1.UtcDateTime;
Console.WriteLine("{0} converted to {1} {2}", 
                  utcTime1, 
                  utcTime2, 
                  utcTime2.Kind.ToString());
// The example displays the following output to the console:
//   6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc
```

The following code uses the UtcDateTime property to perform both a time zone conversion and a type conversion on a `DateTimeOffset` value.

```csharp
DateTimeOffset originalTime = new DateTimeOffset(2008, 6, 19, 7, 0, 0, new TimeSpan(5, 0, 0));
DateTime utcTime = originalTime.UtcDateTime;
Console.WriteLine("{0} converted to {1} {2}", 
                  originalTime, 
                  utcTime, 
                  utcTime.Kind.ToString());
// The example displays the following output to the console:
//       6/19/2008 7:00:00 AM +05:00 converted to 6/19/2008 2:00:00 AM Utc
```

## Converting a Local Time

To indicate that a `DateTimeOffset` value represents the local time, you can pass the `DateTime` value returned by the [DateTimeOffset.DateTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_DateTime) property to the static [DateTime.SpecifyKind Method (DateTime, DateTimeKind)]( https://docs.microsoft.com/dotnet/core/api/System.DateTime#methods) method. The method returns the date and time passed to it as its first parameter, but sets the `Kind` property to the value specified by its second parameter. The following code uses the `SpecifyKind` method when converting a `DateTimeOffset` value whose offset corresponds to that of the local time zone.

```csharp
DateTime sourceDate = new DateTime(2008, 6, 19, 7, 0, 0);
DateTimeOffset utcTime1 = new DateTimeOffset(sourceDate, 
                          TimeZoneInfo.Local.GetUtcOffset(sourceDate));
DateTime utcTime2 = utcTime1.DateTime;
if (utcTime1.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(utcTime1.DateTime))) 
   utcTime2 = DateTime.SpecifyKind(utcTime2, DateTimeKind.Local);

Console.WriteLine("{0} converted to {1} {2}", 
                  utcTime1, 
                  utcTime2, 
                  utcTime2.Kind.ToString());
// The example displays the following output to the console:
//   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
```

You can also use the `DateTimeOffset.LocalDateTime` property to convert a `DateTimeOffset` value to a local `DateTime` value. The `Kind` property of the returned `DateTime` value is [DateTimeKind.Local]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Local). The following code uses the `DateTimeOffset.LocalDateTime` property when converting a `DateTimeOffset` value whose offset corresponds to that of the local time zone.

```csharp
DateTime sourceDate = new DateTime(2008, 6, 19, 7, 0, 0);
DateTimeOffset localTime1 = new DateTimeOffset(sourceDate, 
                          TimeZoneInfo.Local.GetUtcOffset(sourceDate));
DateTime localTime2 = localTime1.LocalDateTime;

Console.WriteLine("{0} converted to {1} {2}", 
                  localTime1, 
                  localTime2, 
                  localTime2.Kind.ToString());
// The example displays the following output to the console:
//   6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
```

When you retrieve a `DateTime` value using the `DateTimeOffset.LocalDateTime` property, the property's `get` accessor first converts the `DateTimeOffset` value to UTC, then converts it to local time by calling the [DateTimeOffset.ToLocalTime]( https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#methods) method. This means that you can retrieve a value from the `DateTimeOffset.LocalDateTime` property to perform a time zone conversion at the same time that you perform a type conversion. It also means that the local time zone's adjustment rules are applied in performing the conversion. The following code illustrates the use of the `DateTimeOffset.LocalDateTime` property to perform both a type and a time zone conversion.

```csharp
DateTimeOffset originalDate;
DateTime localDate;

// Convert time originating in a different time zone
originalDate = new DateTimeOffset(2008, 6, 18, 7, 0, 0, 
                                  new TimeSpan(-5, 0, 0));
localDate = originalDate.LocalDateTime;
Console.WriteLine("{0} converted to {1} {2}", 
                  originalDate, 
                  localDate, 
                  localDate.Kind.ToString());
// Convert time originating in a different time zone 
// so local time zone's adjustment rules are applied
originalDate = new DateTimeOffset(2007, 11, 4, 4, 0, 0, 
                                  new TimeSpan(-5, 0, 0));
localDate = originalDate.LocalDateTime;
Console.WriteLine("{0} converted to {1} {2}", 
                  originalDate, 
                  localDate, 
                  localDate.Kind.ToString());
// The example displays the following output to the console:
//       6/19/2008 7:00:00 AM -05:00 converted to 6/19/2008 5:00:00 AM Local
//       11/4/2007 4:00:00 AM -05:00 converted to 11/4/2007 1:00:00 AM Local
```

## A General-Purpose Conversion Method

The following example defines a method named `ConvertFromDateTimeOffset` that converts `DateTimeOffset` values to `DateTime` values. Based on its offset, it determines whether the `DateTimeOffset` value is a UTC time, a local time, or some other time, and defines the returned date and time value's `Kind` property accordingly. 

```csharp
static DateTime ConvertFromDateTimeOffset(DateTimeOffset dateTime)
{
   if (dateTime.Offset.Equals(TimeSpan.Zero))
      return dateTime.UtcDateTime;
   else if (dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)))
      return DateTime.SpecifyKind(dateTime.DateTime, DateTimeKind.Local);
   else
      return dateTime.DateTime;   
}
```

The follow example calls the `ConvertFromDateTimeOffset` method to convert `DateTimeOffset` values that represent a UTC time, a local time, and a time in the U.S. Central Standard Time zone.

```csharp
DateTime timeComponent = new DateTime(2008, 6, 19, 7, 0, 0);
DateTime returnedDate; 

// Convert UTC time
DateTimeOffset utcTime = new DateTimeOffset(timeComponent, TimeSpan.Zero);
returnedDate = ConvertFromDateTimeOffset(utcTime); 
Console.WriteLine("{0} converted to {1} {2}", 
                  utcTime, 
                  returnedDate, 
                  returnedDate.Kind.ToString());

// Convert local time
DateTimeOffset localTime = new DateTimeOffset(timeComponent, 
                           TimeZoneInfo.Local.GetUtcOffset(timeComponent)); 
returnedDate = ConvertFromDateTimeOffset(localTime);                                          
Console.WriteLine("{0} converted to {1} {2}", 
                  localTime, 
                  returnedDate, 
                  returnedDate.Kind.ToString());

// Convert Central Standard Time
DateTimeOffset cstTime = new DateTimeOffset(timeComponent, 
               TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time").GetUtcOffset(timeComponent));
returnedDate = ConvertFromDateTimeOffset(cstTime);
Console.WriteLine("{0} converted to {1} {2}", 
                  cstTime, 
                  returnedDate, 
                  returnedDate.Kind.ToString());
// The example displays the following output to the console:
//    6/19/2008 7:00:00 AM +00:00 converted to 6/19/2008 7:00:00 AM Utc
//    6/19/2008 7:00:00 AM -07:00 converted to 6/19/2008 7:00:00 AM Local
//    6/19/2008 7:00:00 AM -05:00 converted to 6/19/2008 7:00:00 AM Unspecified
```

Note that this code makes two assumptions that, depending on the application and the source of its date and time values, may not always be valid:

* It assumes that a date and time value whose offset is `TimeSpan.Zero` represents UTC. In fact, UTC is not a time in a particular time zone, but the time in relation to which the times in the world's time zones are standardized. Time zones can also have an offset of `Zero`.

* It assumes that a date and time whose offset equals that of the local time zone represents the local time zone. Because date and time values are disassociated from their original time zone, this may not be the case; the date and time can have originated in another time zone with the same offset.

## See Also

[Dates, Times, and Time Zones](index.md)




