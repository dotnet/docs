---
title: How to: Enumerate Time Zones Present on a Computer
description: How to: Enumerate Time Zones Present on a Computer
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 5bff08fc-dedd-4b11-a709-3682141af556
---

# How to: Enumerate Time Zones Present on a Computer

Successfully working with a designated time zone requires that information about that time zone be available to the system. For example, the Windows operating system stores this information in the registry. However, although the total number of time zones that exist throughout the world is large, the registry contains information about only a subset of them. In addition, the registry itself is a dynamic structure whose contents are subject to both deliberate and accidental change. As a result, an application cannot always assume that a particular time zone is defined and available on a system. The first step for many applications that use time zone information applications is to determine whether required time zones are available on the local system, or to give the user a list of time zones from which to select. This requires that an application enumerate the time zones defined on a local system. 

## To enumerate the time zones present on the local system

1. Call the `TimeZoneInfo.GetSystemTimeZones` method. The method returns a generic [ReadOnlyCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.ReadOnlyCollection%601) collection of `TimeZoneInfo` objects. The entries in the collection are sorted by their `DisplayName` property. For example:

    ```csharp
    ReadOnlyCollection<TimeZoneInfo> tzCollection;
    tzCollection = TimeZoneInfo.GetSystemTimeZones();
    ```

2. Enumerate the individual `TimeZoneInfo` objects in the collection by using a `foreach` loop, and perform any necessary processing on each object. For example, the following code enumerates the `ReadOnlyCollection&lt;T&gt;` collection of `TimeZoneInfo` objects returned in step 1 and lists the display name of each time zone on the console.

    ```csharp
    foreach (TimeZoneInfo timeZone in tzCollection)
    Console.WriteLine("   {0}: {1}", timeZone.Id, timeZone.DisplayName);
    ```
## See Also

[Dates, Times, and Time Zones](index.md)

[Finding the Time Zones Defined on a Local System](finding-the-time-zones-on-local-system.md)

