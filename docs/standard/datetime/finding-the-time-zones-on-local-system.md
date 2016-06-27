---
title: Finding the Time Zones Defined on a Local System
description: Finding the Time Zones Defined on a Local System
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: d081ed64-c390-4d2c-ac37-b0646c698eb7
---

# Finding the Time Zones Defined on a Local System

The [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) class does not expose a public constructor. As a result, the `new` keyword cannot be used to create a new `TimeZoneInfo` object. Instead, `TimeZoneInfo` objects are instantiated by retrieving information on predefined time zones from the operating system. This topic discusses instantiating a time zone from data stored by the operating system. In addition, static properties of the `TimeZoneInfo` class provide access to Coordinated Universal Time (UTC) and the local time zone.

## Accessing Individual Time Zones

The `TimeZoneInfo` class provides two predefined time zone objects that represent the UTC time and the local time zone. They are available from the `Utc` and `Local` properties, respectively. For instructions on accessing the UTC or local time zones, see [How to: Access the Predefined UTC and Local Time Zone Objects](access-utc-and-local.md). 

You can also instantiate a `TimeZoneInfo` object that represents any time zone defined by the operating system. For instructions on instantiating a specific time zone object, see [How to: Instantiate a TimeZoneInfo Object](instantiate-time-zone-info.md).

## Time Zone Identifiers

The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the `TimeZoneInfo.StandardNam` property, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note their associated identifiers. For instructions on enumerating time zones, see [How to: Enumerate Time Zones Present on a Computer](enumerate-time-zones.md).

## See Also

[Dates, Times, and Time Zones](index.md)

[How to: Access the Predefined UTC and Local Time Zone Objects](access-utc-and-local.md)

[How to: Instantiate a TimeZoneInfo Object](instantiate-time-zone-info.md)

[How to: Enumerate Time Zones Present on a Computer](enumerate-time-zones.md)

[Converting Times Between Time Zones](converting-between-time-zones.md)