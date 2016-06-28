---
title: Instantiating a DateTimeOffset Object
description: Instantiating a DateTimeOffset Object
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: bac8c875-da82-43f0-b92f-588077191e3c
---

# Instantiating a DateTimeOffset Object

The [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) structure offers a number of ways to create new `DateTimeOffset` values. Many of them correspond directly to the methods available for instantiating new [System.DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) values, with enhancements that allow you to specify the date and time value's offset from Coordinated Universal Time (UTC). In particular, you can instantiate a `DateTimeOffset` value in the following ways:

* By calling a `DateTimeOffset` constructor.

* By implicitly converting a value to `DateTimeOffset` value.

* By parsing the string representation of a date and time.

## DateTimeOffset Constructors

The [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) type defines five constructors. Three of them correspond directly to `DateTime` constructors, with an additional parameter of type [System.TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) that defines the date and time's offset from UTC. These allow you to define a `DateTimeOffset` value based on the value of its individual date and time components. For example, the following code uses these three constructors to instantiate `DateTimeOffset` objects with identical values of 7/1/2008 12:05 AM +01:00.

```csharp
DateTimeOffset dateAndTime;

// Instantiate date and time using years, months, days, 
// hours, minutes, and seconds
dateAndTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 
                                 new TimeSpan(1, 0, 0));
Console.WriteLine(dateAndTime);
// Instantiate date and time using years, months, days,
// hours, minutes, seconds, and milliseconds
dateAndTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32, 545, 
                                 new TimeSpan(1, 0, 0));
Console.WriteLine("{0} {1}", dateAndTime.ToString("G"), 
                             dateAndTime.ToString("zzz"));

// Instantiate date and time using number of ticks
// 05/01/2008 8:06:32 AM is 633,452,259,920,000,000 ticks
dateAndTime = new DateTimeOffset(633452259920000000, new TimeSpan(1, 0, 0));  
Console.WriteLine(dateAndTime);
// The example displays the following output to the console:
//       5/1/2008 8:06:32 AM +01:00
//       5/1/2008 8:06:32 AM +01:00
//       5/1/2008 8:06:32 AM +01:00
```

The other two constructors create a `DateTimeOffset` object from a DateTime value. The first of these has a single parameter, the `DateTime` value to convert to a `DateTimeOffset` value. The offset of the resulting `DateTimeOffset` value depends on the `Kind` property of the constructor's single `DateTime` parameter. If its value is [DateTimeKind.Utc](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Utc), the offset is set equal to [TimeSpan.Zero](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_Zero). Otherwise, its offset is set equal to that of the local time zone. The following example illustrates the use of this constructor to instantiate `DateTimeOffset` objects representing UTC and the local time zone:

```csharp
// Declare date; Kind property is DateTimeKind.Unspecified
DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
DateTimeOffset targetTime;

// Instantiate a DateTimeOffset value from a UTC time 
DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
targetTime = new DateTimeOffset(utcTime);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM +00:00
// Because the Kind property is DateTimeKind.Utc, 
// the offset is TimeSpan.Zero.

// Instantiate a DateTimeOffset value from a UTC time with a zero offset
targetTime = new DateTimeOffset(utcTime, TimeSpan.Zero);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM +00:00
// Because the Kind property is DateTimeKind.Utc, 
// the call to the constructor succeeds

// Instantiate a DateTimeOffset value from a UTC time with a negative offset
try
{
   targetTime = new DateTimeOffset(utcTime, new TimeSpan(-2, 0, 0));
   Console.WriteLine(targetTime);
}
catch (ArgumentException)
{
   Console.WriteLine("Attempt to create DateTimeOffset value from {0} failed.", 
                      targetTime);
}   
// Throws exception and displays the following to the console:
//   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM +00:00 failed.

// Instantiate a DateTimeOffset value from a local time
DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
targetTime = new DateTimeOffset(localTime);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM -07:00
// Because the Kind property is DateTimeKind.Local, 
// the offset is that of the local time zone.

// Instantiate a DateTimeOffset value from an unspecified time
targetTime = new DateTimeOffset(sourceDate);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM -07:00
// Because the Kind property is DateTimeKind.Unspecified, 
// the offset is that of the local time zone.
```

> **Note**
>
> Calling the overload of the `DateTimeOffset` constructor that has a single `DateTime` parameter is equivalent to performing an implicit conversion of a `DateTime` value to a `DateTimeOffset` value.

The second constructor that creates a `DateTimeOffset` object from a `DateTime` value has two parameters: the `DateTime` value to convert, and a `TimeSpan` value representing the date and time's offset from UTC. This offset value must correspond to the `Kind` property of the constructor's first parameter or an [System.ArgumentException](https://docs.microsoft.com/dotnet/core/api/System.ArgumentException) is thrown. If the `Kind` property of the first parameter is [DateTimeKind.Utc](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Utc), the value of the second parameter must be `TimeSpan.Zero`. If the `Kind` property of the first parameter is [DateTimeKind.Local](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Local), the value of the second parameter must be the offset of the local system's time zone. If the `Kind` property of the first parameter is [DateTimeKind.Unspecified](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Unspecified), the offset can be any valid value. The following code illustrates calls to this constructor to convert `DateTime` to `DateTimeOffset` values.

```csharp
DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
DateTimeOffset targetTime;

// Instantiate a DateTimeOffset value from a UTC time with a zero offset.
DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
targetTime = new DateTimeOffset(utcTime, TimeSpan.Zero);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM +00:00
// Because the Kind property is DateTimeKind.Utc,  
// the call to the constructor succeeds

// Instantiate a DateTimeOffset value from a UTC time with a non-zero offset.
try
{
   targetTime = new DateTimeOffset(utcTime, new TimeSpan(-2, 0, 0));
   Console.WriteLine(targetTime);
}
catch (ArgumentException)
{
   Console.WriteLine("Attempt to create DateTimeOffset value from {0} failed.", 
                      utcTime);
}   
// Throws exception and displays the following to the console:
//   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM failed.

// Instantiate a DateTimeOffset value from a local time with 
// the offset of the local time zone
DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
targetTime = new DateTimeOffset(localTime, 
                                TimeZoneInfo.Local.GetUtcOffset(localTime));
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM -07:00
// Because the Kind property is DateTimeKind.Local and the offset matches
// that of the local time zone, the call to the constructor succeeds.

// Instantiate a DateTimeOffset value from a local time with a zero offset.
try
{
   targetTime = new DateTimeOffset(localTime, TimeSpan.Zero);
   Console.WriteLine(targetTime);
}
catch (ArgumentException)
{
   Console.WriteLine("Attempt to create DateTimeOffset value from {0} failed.", 
                      localTime);
}   
// Throws exception and displays the following to the console:
//   Attempt to create DateTimeOffset value from 5/1/2008 8:30:00 AM failed.

// Instantiate a DateTimeOffset value with an arbitary time zone. 
string timeZoneName = "Central Standard Time";
TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName). 
                         GetUtcOffset(sourceDate); 
targetTime = new DateTimeOffset(sourceDate, offset);
Console.WriteLine(targetTime);
// Displays 5/1/2008 8:30:00 AM -05:00
```

## Implicit Type Conversion
 
The [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) type supports one implicit type conversion: from a [System.DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) value to a `DateTimeOffset` value. (An implicit type conversion is a conversion from one type to another that does not require an explicit cast and that does not lose information. It makes code like the following possible.

```csharp
DateTimeOffset targetTime;

// The Kind property of sourceDate is DateTimeKind.Unspecified
DateTime sourceDate = new DateTime(2008, 5, 1, 8, 30, 0);
targetTime = sourceDate;
Console.WriteLine(targetTime);   
// Displays 5/1/2008 8:30:00 AM -07:00

// define a UTC time (Kind property is DateTimeKind.Utc)
DateTime utcTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Utc);
targetTime = utcTime;
Console.WriteLine(targetTime);   
// Displays 5/1/2008 8:30:00 AM +00:00

// Define a local time (Kind property is DateTimeKind.Local)
DateTime localTime = DateTime.SpecifyKind(sourceDate, DateTimeKind.Local);
targetTime = localTime;
Console.WriteLine(targetTime);      
// Displays 5/1/2008 8:30:00 AM -07:00
```

The offset of the resulting `DateTimeOffset` value depends on the `DateTime.Kind` property value. If its value is [DateTimeKind.Utc](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Utc), the offset is set equal to [TimeSpan.Zero](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_Zero). If its value is either [DateTimeKind.Local](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Local) or [DateTimeKind.Unspecified](https://docs.microsoft.com/dotnet/core/api/System.DateTimeKind#System_DateTimeKind_Unspecified), the offset is set equal to that of the local time zone.

## Parsing the String Representation of a Date and Time

The [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) type supports four methods that allow you to convert the string representation of a date and time into a `DateTimeOffset` value:

* [Parse](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_Parse_System_String_), which tries to convert the string representation of a date and time to a `DateTimeOffset` value and throws an exception if the conversion fails.

* [TryParse](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#methods), which tries to convert the string representation of a date and time to a `DateTimeOffset` value and returns `false` if the conversion fails.

* [ParseExact](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#System_DateTimeOffset_ParseExact_System_String_System_String_System_IFormatProvider_), which tries to convert the string representation of a date and time in a specified format to a `DateTimeOffset` value. The method throws an exception if the conversion fails.

* [TryParseExact](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset#methods), which tries to convert the string representation of a date and time in a specified format to a `DateTimeOffset` value. The method returns `false` if the conversion fails.

The following example illustrates calls to each of these four string conversion methods to instantiate a `DateTimeOffset` value.

```csharp
string timeString; 
DateTimeOffset targetTime;

timeString = "05/01/2008 8:30 AM +01:00";
try
{
   targetTime = DateTimeOffset.Parse(timeString);
   Console.WriteLine(targetTime);
}
catch (FormatException)
{
   Console.WriteLine("Unable to parse {0}.", timeString);   
}   

timeString = "05/01/2008 8:30 AM";
if (DateTimeOffset.TryParse(timeString, out targetTime))
   Console.WriteLine(targetTime);
else
   Console.WriteLine("Unable to parse {0}.", timeString);   

timeString = "Thursday, 01 May 2008 08:30";
try
{
   targetTime = DateTimeOffset.ParseExact(timeString, "f", 
                CultureInfo.InvariantCulture);
   Console.WriteLine(targetTime);
}
catch (FormatException)
{
   Console.WriteLine("Unable to parse {0}.", timeString);   
}   

timeString = "Thursday, 01 May 2008 08:30 +02:00";
string formatString; 
formatString = CultureInfo.InvariantCulture.DateTimeFormat.LongDatePattern +
                " " +
                CultureInfo.InvariantCulture.DateTimeFormat.ShortTimePattern +
                " zzz"; 
if (DateTimeOffset.TryParseExact(timeString, 
                                formatString, 
                                CultureInfo.InvariantCulture, 
                                DateTimeStyles.AllowLeadingWhite, 
                                out targetTime))
   Console.WriteLine(targetTime);
else
   Console.WriteLine("Unable to parse {0}.", timeString);
// The example displays the following output to the console:
//    5/1/2008 8:30:00 AM +01:00
//    5/1/2008 8:30:00 AM -07:00
//    5/1/2008 8:30:00 AM -07:00
//    5/1/2008 8:30:00 AM +02:00
```

## See Also

[Dates, Times, and Time Zones](index.md)

