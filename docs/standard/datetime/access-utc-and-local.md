---
title: How to: Access the Predefined UTC and Local Time Zone Objects
description: How to: Access the Predefined UTC and Local Time Zone Objects
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 6c521dda-9c27-49cb-97f4-f440f02e38f6
---

# How to: Access the Predefined UTC and Local Time Zone Objects

The [System.TimeZoneInfo](https://docs.microsoft.com/dotnet/core/api/System.TimeZoneInfo) class provides two properties, `Utc` and `Local`, that give your code access to predefined time zone objects. This topic discusses how to access the `TimeZoneInfo` objects returned by those properties.

## To access the Coordinated Universal Time (UTC) TimeZoneInfo object

1. Use the **static** `TimeZoneInfo.Utc` property to access Coordinated Universal Time.

2. Rather than assigning the `TimeZoneInfo` object returned by the property to an object variable, continue to access Coordinated Universal Time through the `TimeZoneInfo.Utc` property.


## To access the local time zone

1. Use the **static** `TimeZoneInfo.Local` property to access the local system time zone.

2. Rather than assigning the `TimeZoneInfo` object returned by the property to an object variable, continue to access the local time zone through the `TimeZoneInfo.Local` property.


## See Also

[Dates, Times, and Time Zones](index.md)

[Finding the Time Zones Defined on a Local System](finding-the-time-zones-on-local-system.md)
