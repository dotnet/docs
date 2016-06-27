---
title: How to: Resolve Ambiguous Times
description: How to: Resolve Ambiguous Times
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 072444dc-84d0-4b2b-96a2-5f995a485a3a
---

# How to: Resolve Ambiguous Times

An ambiguous time is a time that maps to more than one Coordinated Universal Time (UTC). It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. When handling an ambiguous time, you can do one of the following:

* Make an assumption about how the time maps to UTC. For example, you can assume that an ambiguous time is always expressed in the time zone's standard time.

* If the ambiguous time is an item of data entered by the user, you can leave it to the user to resolve the ambiguity.

This article shows how to resolve an ambiguous time by assuming that it represents the time zone's standard time.

## To map an ambiguous time to a time zone's standard time

1. Call the [System.TimeZoneInfo.IsAmbiguousTime(DateTime)](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo#System_TimeZoneInfo_IsAmbiguousTime_System_DateTime_) or [System.TimeZoneInfo.IsAmbiguousTime(DateTimeOffset)](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo#System_TimeZoneInfo_IsAmbiguousTime_System_DateTimeOffset_) method to determine whether the time is ambiguous.

2. If the time is ambiguous, subtract the time from the 'TimeSpan' object returned by the time zone's 'BaseUtcOffset' property.

3. Call the static `SpecifyKind` method to set the UTC date and time value's `Kind` property to `DateTimeKind.Utc`.

## Example

The following example illustrates how to convert an ambiguous `DateTime` to UTC by assuming that it represents the local time zone's standard time. 

```csharp
private DateTime ResolveAmbiguousTime(DateTime ambiguousTime)
{
   // Time is not ambiguous
   if (! TimeZoneInfo.Local.IsAmbiguousTime(ambiguousTime))
   { 
      return ambiguousTime; 
   }
   // Time is ambiguous
   else
   {
      DateTime utcTime = DateTime.SpecifyKind(ambiguousTime - TimeZoneInfo.Local.BaseUtcOffset, 
                                              DateTimeKind.Utc);      
      Console.WriteLine("{0} local time corresponds to {1} {2}.", 
                        ambiguousTime, utcTime, utcTime.Kind.ToString());
      return utcTime;            
   }   
}
```

The example consists of a method named `ResolveAmbiguousTime` that determines whether the `DateTime` value passed to it is ambiguous. If the value is ambiguous, the method returns a `DateTime` value that represents the corresponding UTC time. The method handles this conversion by subtracting the value of the local time zone's `BaseUtcOffset` property from the local time. 

Ordinarily, an ambiguous time is handled by calling the `GetAmbiguousTimeOffsets` method to retrieve an array of `TimeSpan` objects that contain the ambiguous time's possible UTC offsets. However, this example makes the arbitrary assumption that an ambiguous time should always be mapped to the time zone's standard time. The `BaseUtcOffset` property returns the offset between UTC and a time zone's standard time.

## See Also

[Dates, Times, and Time Zones](index.md)

[How to: Let Users Resolve Ambiguous Times](let-users-resolve-ambiguous-times.md)

