---
description: "Learn more about: Dates, times, and time zones"
title: "Dates, times, and time zones"
ms.date: 12/07/2021
helpviewer_keywords: 
  - "time zone objects [.NET]"
  - "date and time data [.NET]"
  - "time zones [.NET]"
  - "times [.NET], time zones"
  - "time [.NET], time zones"
ms.assetid: 295c16e0-641b-4771-94b3-39c1ffa98c13
---
# Dates, times, and time zones

In addition to the basic <xref:System.DateTime> structure, .NET provides the following classes that support working with time zones:

* <xref:System.TimeZone>

  Use this class to work with the system's local time zone and the Coordinated Universal Time (UTC) zone. The functionality of the <xref:System.TimeZone> class is largely superseded by the <xref:System.TimeZoneInfo> class.

* <xref:System.TimeZoneInfo>

  Use this class to work with any time zone that is predefined on a system, to create new time zones, and to easily convert dates and times from one time zone to another. For new development, use the <xref:System.TimeZoneInfo> class instead of the <xref:System.TimeZone> class.

* <xref:System.DateTimeOffset>

  Use this structure to work with dates and times whose offset (or difference) from UTC is known. The <xref:System.DateTimeOffset> structure combines a date and time value with that time's offset from UTC. Because of its relationship to UTC, an individual date and time value unambiguously identifies a single point in time. This makes a <xref:System.DateTimeOffset> value more portable from one computer to another than a <xref:System.DateTime> value.

Starting with .NET 6, the following types are available:

* <xref:System.DateOnly>

  Use this structure when working with a value that only represents a date. The date represents the entire day, from the start of the day to the end. `DateOnly` has a range of `0001-01-01` through `9999-12-31`. And, this type represents the month, day, and year combination without a specific time. If you previously used a `DateTime` type in your code to represent a date that disregarded the time, use this type in its place.

* <xref:System.TimeOnly>

  Use this structure to represent a time without a date. The time represents the hours, minutes, and seconds of a non-specific day. `TimeOnly` has a range of `00:00:00.0000000` to `23:59:59.9999999`. This type can be used to replace `DateTime` and `TimeSpan` types in your code when you used those types to represent a time.

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
