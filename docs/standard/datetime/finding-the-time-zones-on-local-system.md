---
title: Finding the time zones defined on a local system
description: Finding the time zones defined on a local system
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/15/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3a6ee323-f3cf-486d-aa0c-103931f1eba9
---

# Finding the time zones defined on a local system

The [System.TimeZoneInfo](xref:System.TimeZoneInfo) class does not expose a public constructor. As a result, the `new` keyword cannot be used to create a new [TimeZoneInfo](xref:System.TimeZoneInfo) object. Instead, [TimeZoneInfo](xref:System.TimeZoneInfo) objects are instantiated by retrieving information on predefined time zones from the operating system. This topic discusses instantiating a time zone from data stored by the operating system. In addition, `static` (`Shared` in Visual Basic) properties of the [TimeZoneInfo](xref:System.TimeZoneInfo) class provide access to Coordinated Universal Time (UTC) and the local time zone.

## Accessing Individual Time Zones

The [TimeZoneInfo](xref:System.TimeZoneInfo) class provides two predefined time zone objects that represent the UTC time and the local time zone. They are available from the [TimeZoneInfo.Utc](xref:System.TimeZoneInfo.Utc) and [TimeZoneInfo.Local](xref:System.TimeZoneInfo.Local) properties, respectively. For instructions on accessing the UTC or local time zones, see [How to: access the predefined UTC and local time zone objects](access-utc-and-local.md). 

You can also instantiate a [TimeZoneInfo](xref:System.TimeZoneInfo) object that represents any time zone defined by the operating system. For instructions on instantiating a specific time zone object, see [How to: instantiate a TimeZoneInfo object](instantiate-time-zone-info.md).

## Time Zone Identifiers

The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the [TimeZoneInfo.StandardName](xref:System.TimeZoneInfo.StandardName) property, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note their associated identifiers. For instructions on enumerating time zones, see [How to: enumerate time zones present on a computer](enumerate-time-zones.md).

## See Also

[Dates, times, and time zones](index.md)

[How to: access the predefined UTC and local time zone objects](access-utc-and-local.md)

[How to: instantiate a TimeZoneInfo object](instantiate-time-zone-info.md)

[How to: enumerate time zones present on a computer](enumerate-time-zones.md)

[Converting times between time zones](converting-between-time-zones.md)