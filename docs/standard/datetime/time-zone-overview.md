---
title: "Time zone overview"
ms.custom: ""
ms.date: "04/10/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "time zones [.NET Framework], about time zones"
  - "transition time [.NET Framework]"
  - "TimeZoneInfo class, about TimeZoneInfo class"
  - "time zones [.NET Framework], creating"
  - "invalid time [.NET Framework]"
  - "fixed rule [.NET Framework]"
  - "ambiguous time [.NET Framework]"
  - "floating rule [.NET Framework]"
  - "daylight saving time [.NET Framework]"
  - "adjustment rule [.NET Framework]"
  - "time zones [.NET Framework], terminology"
ms.assetid: c4b7ed01-5e38-4959-a3b6-ef9765d6ccf1
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Time zone overview

The <xref:System.TimeZoneInfo> class simplifies the creation of time zone-aware applications. The <xref:System.TimeZone> class supports working with the local time zone and Coordinated Universal Time (UTC). The <xref:System.TimeZoneInfo> class supports both of these zones as well as any time zone about which information is predefined in the registry. You can also use <xref:System.TimeZoneInfo> to define custom time zones that the system has no information about.

## Time zone essentials

A time zone is a geographical region in which the same time is used. Typically, but not always, adjacent time zones are one hour apart. The time in any of the world's time zones can be expressed as an offset from Coordinated Universal Time (UTC).

Many of the world's time zones support daylight saving time. Daylight saving time tries to maximize daylight hours by advancing the time forward by one hour in the spring or early summer, and returning to the normal (or standard) time in the late summer or fall. These changes to and from standard time are known as adjustment rules.

The transition to and from daylight saving time in a particular time zone can be defined either by a fixed or a floating adjustment rule. A fixed adjustment rule sets a particular date on which the transition to or from daylight saving time occurs each year. For example, a transition from daylight saving time to standard time that occurs each year on October 25 follows a fixed adjustment rule. Much more common are floating adjustment rules, which set a particular day of a particular week of a particular month for the transition to or from daylight saving time. For example, a transition from standard time to daylight saving time that occurs on the third Sunday of March follows a floating adjustment rule.

For time zones that support adjustment rules, the transition to and from daylight saving time creates two kinds of anomalous times: invalid times and ambiguous times. An invalid time is a nonexistent time created by the transition from standard time to daylight saving time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 3:00 A.M., each time interval between 2:00 A.M. and 2:59:99 A.M. is invalid. An ambiguous time is a time that can be mapped to two different times in a single time zone. It is created by the transition from daylight saving time to standard time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 1:00 A.M., each time interval between 1:00 A.M. and 1:59:99 A.M. can be interpreted as either a standard time or a daylight saving time.

## Time zone terminology

The following table defines terms commonly used when working with time zones and developing time zone-aware applications.

| Term            | Definition |
| --------------- | ---------- |
| Adjustment rule | A rule that defines when the transition from standard time to daylight saving time and back from daylight saving time to standard time occurs. Each adjustment rule has a start and end date that defines when the rule is in place (for example, the adjustment rule is in place from January 1, 1986, to December 31, 2006), a delta (the amount of time by which the standard time changes as a result of the application of the adjustment rule), and information about the specific date and time that the transitions are to occur during the adjustment period. Transitions can follow either a fixed rule or a floating rule. |
| Ambiguous time  | A time that can be mapped to two different times in a single time zone. It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 1:00 A.M., each time interval between 1:00 A.M. and 1:59:99 A.M. can be interpreted as either a standard time or a daylight saving time. |
| Fixed rule      | An adjustment rule that sets a particular date for the transition to or from daylight saving time. For example, a transition from daylight saving time to standard time that occurs each year on October 25 follows a fixed adjustment rule. |
| Floating rule   | An adjustment rule that sets a particular day of a particular week of a particular month for the transition to or from daylight saving time. For example, a transition from standard time to daylight saving time that occurs on the third Sunday of March follows a floating adjustment rule. |
| Invalid time    | A nonexistent time that is an artifact of the transition from standard time to daylight saving time. It occurs when the clock time is adjusted forward in time, such as during the transition from a time zone's standard time to its daylight saving time. For example, if this transition occurs on a particular day at 2:00 A.M. and causes the time to change to 3:00 A.M., each time interval between 2:00 A.M. and 2:59:99 A.M. is invalid. |
| Transition time | Information about a specific time change, such as the change from daylight saving time to standard time or vice versa, in a particular time zone. |

## Time zones and the TimeZoneInfo class

In .NET, a <xref:System.TimeZoneInfo> object represents a time zone. The <xref:System.TimeZoneInfo> class includes a <xref:System.TimeZoneInfo.GetAdjustmentRules%2A> method that returns an array of <xref:System.TimeZoneInfo.AdjustmentRule> objects. Each element of this array provides information about the transition to and from daylight saving time for a particular time period. (For time zones that do not support daylight saving time, the method returns an empty array.) Each <xref:System.TimeZoneInfo.AdjustmentRule> object has a <xref:System.TimeZoneInfo.AdjustmentRule.DaylightTransitionStart%2A> and a <xref:System.TimeZoneInfo.AdjustmentRule.DaylightTransitionEnd%2A> property that defines the particular date and time of the transition to and from daylight saving time. The <xref:System.TimeZoneInfo.TransitionTime.IsFixedDateRule%2A> property indicates whether that transition is fixed or floating.

.NET relies on time zone information provided by the Windows operating system and stored in the registry. Due to the number of the earth's time zones, not all existing time zones are represented in the registry. In addition, because the registry is a dynamic structure, predefined time zones can be added to or removed from it. Finally, the registry does not necessarily contain historic time zone data. For example, in Windows XP the registry contains data about only a single set of time zone adjustments. Windows Vista supports dynamic time zone data, which means that a single time zone can have multiple adjustment rules that apply to specific intervals of years. However, most time zones that are defined in the Windows Vista registry and support daylight saving time have only one or two predefined adjustment rules.

The dependence of the <xref:System.TimeZoneInfo> class on the registry means that a time zone-aware application cannot be certain that a particular time zone is defined in the registry. As a result, the attempt to instantiate a specific time zone (other than the local time zone or the time zone that represents UTC) should use exception handling. It should also provide some method of letting the application to continue if a required <xref:System.TimeZoneInfo> object cannot be instantiated from the registry.

To handle the absence of a required time zone, the <xref:System.TimeZoneInfo> class includes a <xref:System.TimeZoneInfo.CreateCustomTimeZone%2A> method, which you can use to create custom time zones that are not found in the registry. For details on creating a custom time zone, see [How to: Create time zones without adjustment rules](../../../docs/standard/datetime/create-time-zones-without-adjustment-rules.md) and [How to: Create time zones with adjustment rules](../../../docs/standard/datetime/create-time-zones-with-adjustment-rules.md). In addition, you can use the <xref:System.TimeZoneInfo.ToSerializedString%2A> method to convert a newly created time zone to a string and save it in a data store (such as a database, a text file, the registry, or an application resource). You can then use the <xref:System.TimeZoneInfo.FromSerializedString%2A> method to convert this string back to a <xref:System.TimeZoneInfo> object. For details, see [How to: Save time zones to an embedded resource](../../../docs/standard/datetime/save-time-zones-to-an-embedded-resource.md) and [How to: Restore time zones from an embedded resource](../../../docs/standard/datetime/restore-time-zones-from-an-embedded-resource.md).

Because each time zone is characterized by a base offset from UTC, as well as by an offset from UTC that reflects any existing adjustment rules, a time in one time zone can be easily converted to the time in another time zone. For this purpose, the <xref:System.TimeZoneInfo> object includes several conversion methods, including:

* <xref:System.TimeZoneInfo.ConvertTimeFromUtc%2A>, which converts UTC to the time in a designated time zone.

* <xref:System.TimeZoneInfo.ConvertTimeToUtc%2A>, which converts the time in a designated time zone to UTC.

* <xref:System.TimeZoneInfo.ConvertTime%2A>, which converts the time in one designated time zone to the time in another designated time zone.

* <xref:System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId%2A>, which uses time zone identifiers (instead of <xref:System.TimeZoneInfo> objects) as parameters to convert the time in one designated time zone to the time in another designated time zone.

For details on converting times between time zones, see [Converting times between time zones](../../../docs/standard/datetime/converting-between-time-zones.md).

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
