---
description: "Learn more about: Finding the time zones defined on a local system"
title: "Finding the time zones defined on a local system"
ms.date: "04/10/2017"
helpviewer_keywords: 
  - "time zones [.NET], local"
  - "time zones [.NET], finding local system time zones"
  - "time zone identifiers [.NET]"
  - "local time zone access"
  - "time zones [.NET], retrieving"
  - "UTC times, finding local system time zones"
  - "time zones [.NET], UTC"
ms.topic: how-to
---
# Finding the time zones defined on a local system

The <xref:System.TimeZoneInfo> class does not expose a public constructor. As a result, the `new` keyword cannot be used to create a new <xref:System.TimeZoneInfo> object. Instead, <xref:System.TimeZoneInfo> objects are instantiated either by retrieving information on predefined time zones from the registry or by creating a custom time zone. This topic discusses instantiating a time zone from data stored in the registry. In addition, `static` (`shared` in Visual Basic) properties of the <xref:System.TimeZoneInfo> class provide access to Coordinated Universal Time (UTC) and the local time zone.

> [!NOTE]
> For time zones that are not defined in the registry, you can create custom time zones by calling the overloads of the <xref:System.TimeZoneInfo.CreateCustomTimeZone%2A> method. Creating a custom time zone is discussed in the [How to: Create time zones without adjustment rules](create-time-zones-without-adjustment-rules.md) and [How to: Create time zones with adjustment rules](create-time-zones-with-adjustment-rules.md) topics. In addition, you can instantiate a <xref:System.TimeZoneInfo> object by restoring it from a serialized string with the <xref:System.TimeZoneInfo.FromSerializedString%2A> method. Serializing and deserializing a <xref:System.TimeZoneInfo> object is discussed in the [How to: Save time zones to an embedded resource](save-time-zones-to-an-embedded-resource.md) and [How to: Restore Time Zones from an Embedded Resource](restore-time-zones-from-an-embedded-resource.md) topics.

## Accessing individual time zones

The <xref:System.TimeZoneInfo> class provides two predefined time zone objects that represent the UTC time and the local time zone. They are available from the <xref:System.TimeZoneInfo.Utc%2A> and <xref:System.TimeZoneInfo.Local%2A> properties, respectively. For instructions on accessing the UTC or local time zones, see [How to: Access the predefined UTC and local time zone objects](access-utc-and-local.md).

You can also instantiate a <xref:System.TimeZoneInfo> object that represents any time zone defined in the registry. For instructions on instantiating a specific time zone object, see [How to: Instantiate a TimeZoneInfo object](instantiate-time-zone-info.md).

## Time zone identifiers

The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the <xref:System.TimeZoneInfo.StandardName%2A?displayProperty=nameWithType> property, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note their associated identifiers.

## See also

- [Dates, times, and time zones](index.md)
- [How to: Access the predefined UTC and local time zone objects](access-utc-and-local.md)
- [How to: Instantiate a TimeZoneInfo object](instantiate-time-zone-info.md)
- [Converting times between time zones](converting-between-time-zones.md)
