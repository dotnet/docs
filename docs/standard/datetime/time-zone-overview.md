---
title: Time Zone Overview
description: Time Zone Overview
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

# Time Zone Overview

The [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) class simplifies the creation of time zone-aware applications. The `TimeZoneInfo` class supports working with the local time zone and Coordinated Universal Time (UTC), as well as any time zone about which information is predefined in the registry. You can also use `TimeZoneInfo` to define custom time zones that the system has no information about.

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

In .NET Core, a [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) object represents a time zone, based on information provided by the operating system. The dependence of the `TimeZoneInfo` class on the operating system means that a time zone-aware application cannot be certain that a particular time zone is defined on all operating systems. As a result, the attempt to instantiate a specific time zone (other than the local time zone or the time zone that represents UTC) should use exception handling. It should also provide some method of letting the application to continue if a required `TimeZoneInfo` object cannot be instantiated.

Because each time zone is characterized by a base offset from UTC, as well as by an offset from UTC that reflects any existing adjustment rules, a time in one time zone can be easily converted to the time in another time zone. For this purpose, the `TimeZoneInfo` object includes several conversion methods, including:

* `ConvertTime(DateTime, TimeZoneInfo)`, which converts a [System.DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) to the time in a particular time zone.

* `ConvertTime(DateTime, TimeZoneInfo, TimeZoneInfo)`, which converts a `DateTime` from one time zone to another.

* `ConvertTime(DateTimeOffset, TimeZoneInfo)`, which converts a [System.DateTimeOffset](https://docs.microsoft.com/dotnet/core/api/System.DateTimeOffset) to the time in a particular time zone. 

For details on converting times between time zones, see [Converting Times Between Time Zones](converting-between-time-zones.md).

## See Also

[Dates, Times, and Time Zones](index.md)