---
title: How to: resolve ambiguous times
description: How to: resolve ambiguous times
keywords: .NET, .NET Core
author: stevehoag
manager: wpickett
ms.date: 08/16/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: e86050c6-d16d-405e-8bba-7205945c9a81
---

# How to: resolve ambiguous times

An ambiguous time is a time that maps to more than one Coordinated Universal Time (UTC). It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. When handling an ambiguous time, you can do one of the following:

* Make an assumption about how the time maps to UTC. For example, you can assume that an ambiguous time is always expressed in the time zone's standard time.

* If the ambiguous time is an item of data entered by the user, you can leave it to the user to resolve the ambiguity.

This article shows how to resolve an ambiguous time by assuming that it represents the time zone's standard time.

## To map an ambiguous time to a time zone's standard time

1. Call the [System.TimeZoneInfo.IsAmbiguousTime(DateTime)](xref:System.TimeZoneInfo.IsAmbiguousTime_System_DateTime_) or [System.TimeZoneInfo.IsAmbiguousTime(DateTimeOffset)](xref:System.TimeZoneInfo.IsAmbiguousTime_System_DateTimeOffset_) method to determine whether the time is ambiguous.

2. If the time is ambiguous, subtract the time from the [TimeSpan](xref:system.timespan) object returned by the time zone's 'BaseUtcOffset' property.

3. Call the `static` (`Shared` in Visual Basic) [SpecifyKind](xref:system.datetime.SpecifyKind_System_DateTime_System_DateTimeKind_) method to set the UTC date and time value's [Kind](xref:system.datetime.Kind) property to [DateTimeKind.Utc](xref:system.datetimekind.Utc).

## Example

The following example illustrates how to convert an ambiguous [DateTime](xref:system.datetime) to UTC by assuming that it represents the local time zone's standard time. 

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

```vb
Private Function ResolveAmbiguousTime(ambiguousTime As Date) As Date
   ' Time is not ambiguous
   If Not TimeZoneInfo.Local.IsAmbiguousTime(ambiguousTime) Then 
      Return TimeZoneInfo.ConvertTimeToUtc(ambiguousTime) 
   ' Time is ambiguous
   Else
      Dim utcTime As Date = DateTime.SpecifyKind(ambiguousTime - TimeZoneInfo.Local.BaseUtcOffset, DateTimeKind.Utc)      
      Console.WriteLine("{0} local time corresponds to {1} {2}.", ambiguousTime, utcTime, utcTime.Kind.ToString())
      Return utcTime            
   End If   
End Function
```

The example consists of a method named `ResolveAmbiguousTime` that determines whether the [DateTime](xref:system.datetime) value passed to it is ambiguous. If the value is ambiguous, the method returns a [DateTime](xref:system.datetime) value that represents the corresponding UTC time. The method handles this conversion by subtracting the value of the local time zone's [BaseUtcOffset](xref:system.timezoneinfo.BaseUtcOffset) property from the local time. 

Ordinarily, an ambiguous time is handled by calling the [GetAmbiguousTimeOffsets](xref:system.timezoneinfo.GetAmbiguousTimeOffsets_System_DateTime_) method to retrieve an array of [TimeSpan](xref:system.timespan) objects that contain the ambiguous time's possible UTC offsets. However, this example makes the arbitrary assumption that an ambiguous time should always be mapped to the time zone's standard time. The [BaseUtcOffset](xref:system.timezoneinfo.BaseUtcOffset) property returns the offset between UTC and a time zone's standard time.

## See Also

[Dates, times, and time zones](index.md)

[How to: let users resolve ambiguous times](let-users-resolve-ambiguous-times.md)

