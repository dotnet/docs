---
title: How to: Instantiate a TimeZoneInfo Object
description: How to: Instantiate a TimeZoneInfo Object
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 08fe7f7b-774f-427b-8d4b-2635fed58166
---

# How to: Instantiate a TimeZoneInfo Object

The most common way to instantiate a `TimeZoneInfo` object is to retrieve information about it from the operating system. This topic discusses how to instantiate a `TimeZoneInfo` object from the local system.

## To instantiate a TimeZoneInfo Object

1. Declare a `TimeZoneInfo` object.

2. Call the static `TimeZoneInfo.FindSystemTimeZoneById` method.

3. Handle any exceptions thrown by the method, particularly the `System.TimeZoneNotFoundException` that is thrown if the time zone is not defined in the registry.

## See Also

[Dates, Times, and Time Zones](index.md)

[Finding the Time Zones Defined on a Local System](finding-the-time-zones-on-local-system.md)