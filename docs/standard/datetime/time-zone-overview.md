---
title: Time zone overview
description: Time zone overview
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/16/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: e3a10f62-d403-4441-8621-adc964e32c07
---

# Time zone overview

The [System.TimeZoneInfo](xref:System.TimeZoneInfo) class simplifies the creation of time zone-aware applications. The [TimeZoneInfo](xref:System.TimeZoneInfo) class supports working with the local time zone and Coordinated Universal Time (UTC), as well as any time zone about which information is predefined in the registry. You can also use [TimeZoneInfo](xref:System.TimeZoneInfo) to define custom time zones that the system has no information about.

## Time Zone Essentials

A time zone is a geographical region in which the same time is used. Typically, but not always, adjacent time zones are one hour apart. The time in any of the world's time zones can be expressed as an offset from Coordinated Universal Time (UTC).

Many of the world's time zones support daylight saving time. Daylight saving time tries to maximize daylight hours by advancing the time forward by one hour in the spring or early summer, and returning to the normal (or standard) time in the late summer or fall. These changes to and from standard time are known as adjustment rules.

The transition to and from daylight saving time in a particular time zone can be defined either by a fixed or a floating adjustment rule. A fixed adjustment rule sets a particular date on which the transition to or from daylight saving time occurs each year. For example, a transition from daylight saving time to standard time that occurs each year on October 25 follows a fixed adjustment rule. Much more common are floating adjustment rules, which set a particular day of a particular week of a particular month for the transition to or from daylight saving time. For example, a transition from standard time to daylight saving time that occurs on the third Sunday of March follows a floating adjustment rule.

For time zones that support adjustment rules, the transition to and from daylight saving time creates two kinds of anomalous times: invalid times and ambiguous times. An invalid time is a nonexistent time created by the transition from standard time to daylight saving time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 3:00 A.M., each time interval between 2:00 A.M. and 2:59:99 A.M. is invalid. An ambiguous time is a time that can be mapped to two different times in a single time zone. It is created by the transition from daylight saving time to standard time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 1:00 A.M., each time interval between 1:00 A.M. and 1:59:99 A.M. can be interpreted as either a standard time or a daylight saving time. 

## Time Zone Terminology

The following table defines terms commonly used when working with time zones and developing time zone-aware applications.

Term | Definition
---- | ----------
Adjustment rule | A rule that defines when the transition from standard time to daylight saving time and back from daylight saving time to standard time occurs. Each adjustment rule has a start and end date that defines when the rule is in place (for example, the adjustment rule is in place from January 1, 1986, to December 31, 2020), a delta (the amount of time by which the standard time changes as a result of the application of the adjustment rule), and information about the specific date and time that the transitions are to occur during the adjustment period. Transitions can follow either a fixed rule or a floating rule.
Ambiguous time | A time that can be mapped to two different times in a single time zone. It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 1:00 A.M., each time interval between 1:00 A.M. and 1:59:99 A.M. can be interpreted as either a standard time or a daylight saving time. 
Fixed rule | An adjustment rule that sets a particular date for the transition to or from daylight saving time. For example, a transition from daylight saving time to standard time that occurs each year on October 25 follows a fixed adjustment rule.
Floating rule | An adjustment rule that sets a particular day of a particular week of a particular month for the transition to or from daylight saving time. For example, a transition from standard time to daylight saving time that occurs on the third Sunday of March follows a floating adjustment rule.
Invalid time | A nonexistent time that is an artifact of the transition from standard time to daylight saving time. It occurs when the clock time is adjusted forward in time, such as during the transition from a time zone's standard time to its daylight saving time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 3:00 A.M., each time interval between 2:00 A.M. and 2:59:99 A.M. is invalid.
Transition time | Information about a specific time change, such as the change from daylight saving time to standard time or vice versa, in a particular time zone.

## Time Zones and the TimeZoneInfo Class

In .NET, a [System.TimeZoneInfo](xref:System.TimeZoneInfo) object represents a time zone, based on information provided by the operating system. The dependence of the [TimeZoneInfo](xref:System.TimeZoneInfo) class on the operating system means that a time zone-aware application cannot be certain that a particular time zone is defined on all operating systems. As a result, the attempt to instantiate a specific time zone (other than the local time zone or the time zone that represents UTC) should use exception handling. It should also provide some method of letting the application to continue if a required [TimeZoneInfo](xref:System.TimeZoneInfo) object cannot be instantiated.

Because each time zone is characterized by a base offset from UTC, as well as by an offset from UTC that reflects any existing adjustment rules, a time in one time zone can be easily converted to the time in another time zone. For this purpose, the [TimeZoneInfo](xref:System.TimeZoneInfo) object includes several conversion methods, including:

* [ConvertTime(DateTime, TimeZoneInfo)](xref:System.TimeZoneInfo.ConvertTime(System.DateTime,System.TimeZoneInfo)), which converts a [System.DateTime](xref:System.DateTime) to the time in a particular time zone.

* [ConvertTime(DateTime, TimeZoneInfo, TimeZoneInfo)](xref:System.TimeZoneInfo.ConvertTime(System.DateTime,System.TimeZoneInfo,System.TimeZoneInfo)), which converts a [DateTime](xref:System.DateTime) from one time zone to another.

* [ConvertTime(DateTimeOffset, TimeZoneInfo)](xref:System.TimeZoneInfo.ConvertTime(System.DateTimeOffset,System.TimeZoneInfo)), which converts a [System.DateTimeOffset](xref:System.DateTimeOffset) to the time in a particular time zone. 

For details on converting times between time zones, see [Converting times between time zones](converting-between-time-zones.md).

## See Also

[Dates, times, and time zones](index.md)