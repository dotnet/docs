---
description: "Learn more about: Dates, times, and time zones"
title: "Dates, times, and time zones"
ms.date: 12/05/2024
helpviewer_keywords: 
  - "time zone objects [.NET]"
  - "date and time data [.NET]"
  - "time zones [.NET]"
  - "times [.NET], time zones"
  - "time [.NET], time zones"
ms.assetid: 295c16e0-641b-4771-94b3-39c1ffa98c13
ms.topic: article
---
# Dates, times, and time zones

.NET provides types that represent dates, times, and time zones. This article describes those types.

In addition to the basic <xref:System.DateTime> structure, .NET provides the following classes that support working with time zones:

* <xref:System.TimeZoneInfo>

  Use this class to work with any time zone that is predefined on a system, to create new time zones, and to easily convert dates and times from one time zone to another. For new development, use the <xref:System.TimeZoneInfo> class instead of the <xref:System.TimeZone> class.

* <xref:System.DateTimeOffset>

  Use this structure to work with dates and times whose offset (or difference) from UTC is known. The <xref:System.DateTimeOffset> structure combines a date and time value with that time's offset from UTC. Because of its relationship to UTC, an individual date and time value unambiguously identifies a single point in time. This makes a <xref:System.DateTimeOffset> value more portable from one computer to another than a <xref:System.DateTime> value.

The following classes to support working with time:

* <xref:System.TimeSpan>

  Use this structure to represents a time interval, such as an elapsed amount of time or the difference between two dates.

* <xref:System.TimeOnly>

  Use this structure to represent a time without a date. The time represents the hours, minutes, and seconds of a non-specific day. `TimeOnly` has a range of `00:00:00.0000000` to `23:59:59.9999999`. This type can be used to replace `DateTime` and `TimeSpan` types in your code when you used those types to represent a time. For more information, see [How to use the DateOnly and TimeOnly structures](how-to-use-dateonly-timeonly.md).

  > [!IMPORTANT]
  > <xref:System.TimeOnly> isn't available for .NET Framework.

* <xref:System.TimeProvider>

  This is a base class that provides an abstraction of time. A common way to check the current time is by using `DateTime.UtcNow` or `DateTimeOffset.UtcNow`. However, these types don't provide any control over what's considered "now." Why would you want to control that? Testability. For example, consider you're writing an event tracking application that provides reminders 1 day before the event. The app's logic is to check the event time every hour, and alert the user once it's 24 hours before the event. As you write your tests for the app, you would provide your own type that wraps `DateTimeOffset.UtcNow` to test this logic, but now .NET provides this abstraction class for you.

  For more information, see [What is TimeProvider](timeprovider-overview.md).

  The `TimeProvider` type is included in .NET.

  For .NET Framework and .NET Standard, `TimeProvider` is provided by the [**Microsoft.Bcl.TimeProvider** NuGet package](https://www.nuget.org/packages/Microsoft.Bcl.TimeProvider/).

The following classes to support working with dates:

* <xref:System.DateOnly>

  Use this structure when working with a value that only represents a date. The date represents the entire day, from the start of the day to the end. `DateOnly` has a range of `0001-01-01` through `9999-12-31`. And, this type represents the month, day, and year combination without a specific time. If you previously used a `DateTime` type in your code to represent a date that disregarded the time, use this type in its place. For more information, see [How to use the DateOnly and TimeOnly structures](how-to-use-dateonly-timeonly.md).

  > [!IMPORTANT]
  > <xref:System.DateOnly> isn't available for .NET Framework.

The next section provides the information that you need to work with time zones and to create time zone-aware applications that can convert dates and times from one time zone to another.

## In this section

[Time zone overview](time-zone-overview.md)\
Discusses the terminology, concepts, and issues involved in creating time zone-aware applications.

[Choosing between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](choosing-between-datetime.md)\
Discusses when to use the <xref:System.DateTime>, <xref:System.DateTimeOffset>, and <xref:System.TimeZoneInfo> types when working with date and time data.

[Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md)\
Describes how to enumerate the time zones found on a local system.

[How to: Enumerate time zones present on a computer](enumerate-time-zones.md)\
Provides examples that enumerate the time zones defined in a computer's registry and that let users select a predefined time zone from a list.

[How to: Access the predefined UTC and local time zone objects](access-utc-and-local.md)\
Describes how to access Coordinated Universal Time and the local time zone.

[How to: Instantiate a TimeZoneInfo object](instantiate-time-zone-info.md)\
Describes how to instantiate a <xref:System.TimeZoneInfo> object from the local system registry.

[Instantiating a DateTimeOffset object](instantiating-a-datetimeoffset-object.md)\
Discusses the ways in which a <xref:System.DateTimeOffset> object can be instantiated, and the ways in which a <xref:System.DateTime> value can be converted to a <xref:System.DateTimeOffset> value.

[How to: Create time zones without adjustment rules](create-time-zones-without-adjustment-rules.md)\
Describes how to create a custom time zone that does not support the transition to and from daylight saving time.

[How to: Create time zones with adjustment rules](create-time-zones-with-adjustment-rules.md)\
Describes how to create a custom time zone that supports one or more transitions to and from daylight saving time.

[Saving and restoring time zones](saving-and-restoring-time-zones.md)\
Describes <xref:System.TimeZoneInfo> support for serialization and deserialization of time zone data and illustrates some of the scenarios in which these features can be used.

[How to: Save time zones to an embedded resource](save-time-zones-to-an-embedded-resource.md)\
Describes how to create a custom time zone and save its information in a resource file.

[How to: Restore time zones from an embedded resource](restore-time-zones-from-an-embedded-resource.md)\
Describes how to instantiate custom time zones that have been saved to an embedded resource file.

[Performing arithmetic operations with dates and times](performing-arithmetic-operations.md)\
Discusses the issues involved in adding, subtracting, and comparing <xref:System.DateTime> and <xref:System.DateTimeOffset> values.

[How to: Use time zones in date and time arithmetic](use-time-zones-in-arithmetic.md)\
Discusses how to perform date and time arithmetic that reflects a time zone's adjustment rules.

[Converting between DateTime and DateTimeOffset](converting-between-datetime-and-offset.md)\
Describes how to convert between <xref:System.DateTime> and <xref:System.DateTimeOffset> values.

[Converting times between time zones](converting-between-time-zones.md)\
Describes how to convert times from one time zone to another.

[How to: Resolve ambiguous times](resolve-ambiguous-times.md)\
Describes how to resolve an ambiguous time by mapping it to the time zone's standard time.

[How to: Let users resolve ambiguous times](let-users-resolve-ambiguous-times.md)\
Describes how to let a user determine the mapping between an ambiguous local time and Coordinated Universal Time.

## Reference

<xref:System.TimeZoneInfo?displayProperty=nameWithType>
