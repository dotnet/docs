---
title: Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo
description: Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 6c521dda-9c27-49cb-97f4-f440f02e38f6
---

# Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo

.NET Core applications that use date and time information are very diverse and can use that information in several ways. The more common uses of date and time information include one or more of the following:

* To reflect a date only, so that time information is not important.

* To reflect a time only, so that date information is not important.

* To reflect an abstract date and time that is not tied to a specific time and place (for example, most stores in an international chain open on weekdays at 9:00 A.M.).

* To retrieve date and time information from sources outside of the .NET Core application, typically where date and time information is stored in a simple data type.

* To uniquely and unambiguously identify a single point in time. Some applications require that a date and time be unambiguous only on the host system; others require that it be unambiguous across systems (that is, a date serialized on one system can be meaningfully deserialized and used on another system anywhere in the world). 

* To preserve multiple related times (such as the requestor's local time and the server's time of receipt for a Web request).

* To perform date and time arithmetic, possibly with a result that uniquely and unambiguously identifies a single point in time. 

.NET Core includes the [System.DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime), [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset), [System.TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan), and [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) types, all of which can be used to build applications that work with dates and times. 

## The DateTime structure

A [System.DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) value defines a particular date and time. It includes a `Kind` property that provides limited information about the time zone to which that date and time belongs. The [DateTimeKind](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind) value returned by the `Kind` property indicates whether the `DateTime` value represents the local time (`DateTimeKind.Local`), Coordinated Universal Time (UTC) (`DateTimeKind.Utc`), or an unspecified time (`DateTimeKind.Unspecified`).

The `DateTime` structure is suitable for applications that do the following: 

* Work with dates only.

* Work with times only.

* Work with abstract dates and times.

* Work with dates and times for which time zone information is missing. 

* Work with UTC dates and times only. 

* Retrieve date and time information from sources outside the .NET Framework, such as SQL databases. Typically, these sources store date and time information in a simple format that is compatible with the DateTime structure.

* Perform date and time arithmetic, but are concerned with general results. For example, in an addition operation that adds six months to a particular date and time, it is often not important whether the result is adjusted for daylight saving time.

Unless a particular `DateTim` value represents UTC, that date and time value is often ambiguous or limited in its portability. For example, if a `DateTime` value represents the local time, it is portable within that local time zone (that is, if the value is deserialized on another system in the same time zone, that value still unambiguously identifies a single point in time). Outside the local time zone, that `DateTime` value can have multiple interpretations. If the value's `Kind` property is `DateTimeKind.Unspecified`, it is even less portable: it is now ambiguous within the same time zone and possibly even on the same system on which it was first serialized. Only if a `DateTime` value represents UTC does that value unambiguously identify a single point in time regardless of the system or time zone in which the value is used.

> **Important**
>
> When saving or sharing `DateTime` data, UTC should be used and the `DateTime` value's `Kind` property should be set to `DateTimeKind.Utc`.

## The DateTimeOffset structure

The [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) structure represents a date and time value, together with an offset that indicates how much that value differs from UTC. Thus, the value always unambiguously identifies a single point in time. 

The `DateTimeOffset` type includes all of the functionality of the `DateTime` type along with time zone awareness. This makes it is suitable for applications that do the following: 

* Uniquely and unambiguously identify a single point in time. The `DateTimeOffset` type can be used to unambiguously define the meaning of "now", to log transaction times, to log the times of system or application events, and to record file creation and modification times. 

* Perform general date and time arithmetic.

* Preserve multiple related times, as long as those times are stored as two separate values or as two members of a structure.

> **Note**
>
> These uses for `DateTimeOffset` values are much more common than those for DateTime values. As a result, `DateTimeOffset` should be considered the default date and time type for application development.

A `DateTimeOffset` value is not tied to a particular time zone, but can originate from any of a variety of time zones. To illustrate this, the following example lists the time zones to which a number of `DateTimeOffset` values (including a local Pacific Standard Time) can belong.

```csharp
using System;
using System.Collections.ObjectModel;

public class TimeOffsets
{
   public static void Main()
   {
      DateTime thisDate = new DateTime(2007, 3, 10, 0, 0, 0);
      DateTime dstDate = new DateTime(2007, 6, 10, 0, 0, 0);
      DateTimeOffset thisTime;

      thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));
      ShowPossibleTimeZones(thisTime);

      thisTime = new DateTimeOffset(thisDate, new TimeSpan(-6, 0, 0));  
      ShowPossibleTimeZones(thisTime);

      thisTime = new DateTimeOffset(thisDate, new TimeSpan(+1, 0, 0));
      ShowPossibleTimeZones(thisTime);
   }

   private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
   {
      TimeSpan offset = offsetTime.Offset;
      ReadOnlyCollection<TimeZoneInfo> timeZones;

      Console.WriteLine("{0} could belong to the following time zones:", 
                        offsetTime.ToString());
      // Get all time zones defined on local system
      timeZones = TimeZoneInfo.GetSystemTimeZones();     
      // Iterate time zones 
      foreach (TimeZoneInfo timeZone in timeZones)
      {
         // Compare offset with offset for that date in that time zone
         if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
            Console.WriteLine("   {0}", timeZone.DisplayName);
      }
      Console.WriteLine();
   } 
}
// This example displays the following output to the console:
//       6/10/2007 12:00:00 AM -07:00 could belong to the following time zones:
//          (GMT-07:00) Arizona
//          (GMT-08:00) Pacific Time (US & Canada)
//          (GMT-08:00) Tijuana, Baja California
//       
//       3/10/2007 12:00:00 AM -06:00 could belong to the following time zones:
//          (GMT-06:00) Central America
//          (GMT-06:00) Central Time (US & Canada)
//          (GMT-06:00) Guadalajara, Mexico City, Monterrey - New
//          (GMT-06:00) Guadalajara, Mexico City, Monterrey - Old
//          (GMT-06:00) Saskatchewan
//       
//       3/10/2007 12:00:00 AM +01:00 could belong to the following time zones:
//          (GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
//          (GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
//          (GMT+01:00) Brussels, Copenhagen, Madrid, Paris
//          (GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb
//          (GMT+01:00) West Central Africa
```

The output shows that each date and time value in this example can belong to at least three different time zones. The `DateTimeOffset` value of 6/10/2007 shows that if a date and time value represents a daylight saving time, its offset from UTC does not even necessarily correspond to the originating time zone's base UTC offset or to the offset from UTC found in its display name. This means that, because a single `DateTimeOffset` value is not tightly coupled with its time zone, it cannot reflect a time zone's transition to and from daylight saving time. This can be particularly problematic when date and time arithmetic is used to manipulate a `DateTimeOffset` value. For a discussion of how to perform date and time arithmetic in a way that takes account of a time zone's adjustment rules, see [Performing Arithmetic Operations with Dates and Times](performing-arithmetic-operations.md).

## The TimeSpan structure

The [System.TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) structure represents a time interval. Its two typical uses are: 

* Reflecting the time interval between two date and time values. For example, subtracting one `DateTime` value from another returns a `TimeSpan` value. 

* Measuring elapsed time. For example, the `Stopwatch.Elapse` property returns a `TimeSpan` value that reflects the time interval that has elapsed since the call to one of the [System.Diagnostics.Stopwatch](https://docs.microsoft.com/dotnet/core/api/System.Diagnostics.Stopwatch) methods that begins to measure elapsed time.

A `TimeSpan` value can also be used as a replacement for a `DateTime` value when that value reflects a time without reference to a particular time of day. This usage is similar to the `DateTime.TimeOfDay` and `DateTimeOffset.TimeOfDay` properties, which return a `TimeSpan` value that represents the time without reference to a date. For example, the `TimeSpan` structure can be used to reflect a store's daily opening or closing time, or it can be used to represent the time at which any regular event occurs.

The following example defines a `StoreInfo` structure that includes `TimeSpan` objects for store opening and closing times, as well as a `TimeZoneInfo` object that represents the store's time zone. The structure also includes two methods, `IsOpenNow` and `IsOpenAt`, that indicates whether the store is open at a time specified by the user, who is assumed to be in the local time zone.  

```csharp
using System;

public struct StoreInfo
{
   public String store;
   public TimeZoneInfo tz;
   public TimeSpan open;
   public TimeSpan close;

   public bool IsOpenNow()
   {
      return IsOpenAt(DateTime.TimeOfDay);
   }

   public bool IsOpenAt(TimeSpan time)
   {
      TimeZoneInfo local = TimeZoneInfo.Local;
      TimeSpan offset = TimeZoneInfo.BaseUtcOffset;

      // Is the store in the same time zone?
      if (tz.Equals(local)) {
         return time >= open & time <= close;
      }
   }
}
```

The `StoreInfo` structure can then be used by client code like the following. 

```csharp
public class Example
{
   public static void Main()
   {
      // Instantiate a StoreInfo object.
      var store103 = new StoreInfo();
      store103.store = "Store #103";
      store103.tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      // Store opens at 8:00.
      store103.open = new TimeSpan(8, 0, 0);
      // Store closes at 9:30.
      store103.close = new TimeSpan(21, 30, 0);

      Console.WriteLine("Store is open now at {0}: {1}",
                        DateTime.TimeOfDay, store103.IsOpenNow());
      TimeSpan[] times = { new TimeSpan(8, 0, 0), new TimeSpan(21, 0, 0),
                           new TimeSpan(4, 59, 0), new TimeSpan(18, 31, 0) };
      foreach (var time in times)
         Console.WriteLine("Store is open at {0}: {1}",
                           time, store103.IsOpenAt(time));
   }
}
// The example displays the following output:
//       Store is open now at 15:29:01.6129911: True
//       Store is open at 08:00:00: True
//       Store is open at 21:00:00: False
//       Store is open at 04:59:00: False
//       Store is open at 18:31:00: False
```

## The TimeZoneInfo class

The [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) class represents any of the earth's time zones, and enables the conversion of any date and time in one time zone to its equivalent in another time zone. The `TimeZoneInfo` class makes it possible to work with dates and times so that any date and time value unambiguously identifies a single point in time.

In some cases, taking full advantage of the `TimeZoneInfo` class may require further development work. Date and time values are not tightly coupled with the time zones to which they belong. As a result, unless your application provides some mechanism for linking a date and time with its associated time zone, it is easy for a particular date and time value to become disassociated from its time zone. One method of linking this information is to define a class or structure that contains both the date and time value and its associated time zone object.

Taking advantage of time zone support in .NET Core is possible only if the time zone to which a date and time value belongs is known when that date and time object is instantiated. This is often not the case, particularly in Web or network applications.

## See Also

[Dates, Times, and Time Zones](index.md)