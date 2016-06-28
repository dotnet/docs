---
title: How to: Use Time Zones in Date and Time Arithmetic
description: How to: Use Time Zones in Date and Time Arithmetic
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: d01e8de1-7893-4dcf-bdae-50505a39e719
---

# How to: Use Time Zones in Date and Time Arithmetic

Ordinarily, when you perform date and time arithmetic using [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) values, the result does not reflect any time zone adjustment rules. This is true even when the time zone of the date and time value is clearly identifiable. This article shows how to perform arithmetic operations on date and time values that belong to a particular time zone. The results of the arithmetic operations will reflect the time zone's adjustment rules.

## To apply adjustment rules to date and time arithmetic

1. Implement some method of closely coupling a date and time value with the time zone to which it belongs. For example, declare a structure that includes both the date and time value and its time zone. The following example uses this approach to link a `DateTimeOffset` value with its time zone.

    ```csharp
    // Define a structure for DateTime values for internal use only
    internal struct TimeWithTimeZone
    {
    TimeZoneInfo TimeZone;
    DateTimeOffset Time;
    }
    ```
    
2. Convert a time to Coordinated Universal Time (UTC) by calling the [TimeZoneInfo.ConvertTime(DateTime, TimeZoneInfo)](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo#System_TimeZoneInfo_ConvertTime_System_DateTime_System_TimeZoneInfo_) method.

3. Perform the arithmetic operation on the UTC time.

4. Convert the time from UTC to the original time's associated time zone by calling the `TimeZoneInfo.ConvertTime(DateTime, TimeZoneInfo)` method. 

## Example

The following example adds two hours and thirty minutes to March 9, 2008, at 1:30 A.M. Central Standard Time. The time zone's transition to daylight saving time occurs thirty minutes later, at 2:00 A.M. on March 9, 2008. Because the example follows the four steps listed in the previous section, it correctly reports the resulting time as 5:00 A.M. on March 9, 2008. 

```csharp
using System;

public struct TimeZoneTime
{
   public TimeZoneInfo TimeZone;
   public DateTimeOffset Time;

   public TimeZoneTime(TimeZoneInfo tz, DateTimeOffset time)
   {
      if (tz == null) 
         throw new ArgumentNullException("The time zone cannot be a null reference.");

      this.TimeZone = tz;
      this.Time = time;   
   }

   public TimeZoneTime AddTime(TimeSpan interval)
   {
      // Convert time to UTC
      DateTimeOffset utcTime = TimeZoneInfo.ConvertTime(this.Time, TimeZoneInfo.Utc);      
      // Add time interval to time
      utcTime = utcTime.Add(interval);
      // Convert time back to time in time zone
      return new TimeZoneTime(this.TimeZone, TimeZoneInfo.ConvertTime(utcTime, this.TimeZone));
   }
}

public class TimeArithmetic
{
   public const string tzName = "Central Standard Time";

   public static void Main()
   {
      try
      {
         TimeZoneTime cstTime1, cstTime2;

         TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(tzName);
         DateTime time1 = new DateTime(2008, 3, 9, 1, 30, 0);          
         TimeSpan twoAndAHalfHours = new TimeSpan(2, 30, 0);

         cstTime1 = new TimeZoneTime(cst, 
                        new DateTimeOffset(time1, cst.GetUtcOffset(time1)));
         cstTime2 = cstTime1.AddTime(twoAndAHalfHours);
         Console.WriteLine("{0} + {1} hours = {2}", cstTime1.Time, 
                                                    twoAndAHalfHours.ToString(),  
                                                    cstTime2.Time);
      }
      catch
      {
         Console.WriteLine("Unable to find {0}.", tzName);
      }
   }
}
```

Note that if this addition is simply performed on the `DateTimeOffset` value without first converting it to UTC, the result reflects the correct point in time but its offset does not reflect that of the designated time zone for that time. 

`DateTimeOffset` values are disassociated from any time zone to which they might belong. To perform date and time arithmetic in a way that automatically applies a time zone's adjustment rules, the time zone to which any date and time value belongs must be immediately identifiable. This means that a date and time and its associated time zone must be tightly coupled. There are several ways to do this, which include the following:

* Assume that all times used in an application belong to a particular time zone. Although appropriate in some cases, this approach offers limited flexibility and possibly limited portability.

* Define a type that tightly couples a date and time with its associated time zone by including both as fields of the type. This approach is used in the code example, which defines a structure to store the date and time and the time zone in two member fields.

## See Also

[Dates, Times, and Time Zones](index.md)

[Performing Arithmetic Operations with Dates and Times](performing-arithmetic-operations.md)
