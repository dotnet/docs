---
title: "How to: enumerate time zones present on a computer"
description: How to enumerate time zones present on a computer
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/15/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c5ae4a6c-1790-4355-b5b1-879aaf956129
---

# How to: enumerate time zones present on a computer

Successfully working with a designated time zone requires that information about that time zone be available to the system. For example, the Windows operating system stores this information in the registry. However, although the total number of time zones that exist throughout the world is large, the registry contains information about only a subset of them. In addition, the registry itself is a dynamic structure whose contents are subject to both deliberate and accidental change. As a result, an application cannot always assume that a particular time zone is defined and available on a system. The first step for many applications that use time zone information applications is to determine whether required time zones are available on the local system, or to give the user a list of time zones from which to select. This requires that an application enumerate the time zones defined on a local system. 

## To enumerate the time zones present on the local system

1. Call the [TimeZoneInfo.GetSystemTimeZones](xref:System.TimeZoneInfo.GetSystemTimeZones) method. The method returns a generic [ReadOnlyCollection&lt;T&gt;](xref:System.Collections.ObjectModel.ReadOnlyCollection%601) collection of [TimeZoneInfo](xref:System.TimeZoneInfo) objects. The entries in the collection are sorted by their [DisplayName](xref:System.TimeZoneInfo.DisplayName) property. For example:

    ```csharp
    ReadOnlyCollection<TimeZoneInfo> tzCollection;
    tzCollection = TimeZoneInfo.GetSystemTimeZones();
    ```

    ```vb
    Dim tzCollection As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones
    ```

2. Enumerate the individual [TimeZoneInfo](xref:System.TimeZoneInfo) objects in the collection by using a `foreach` loop (in C#) or a `For Each…Next` loop (in Visual Basic), and perform any necessary processing on each object. For example, the following code enumerates the [ReadOnlyCollection&lt;T&gt;](xref:System.Collections.ObjectModel.ReadOnlyCollection%601) collection of [TimeZoneInfo](xref:System.TimeZoneInfo) objects returned in step 1 and lists the display name of each time zone on the console.

    ```csharp
    foreach (TimeZoneInfo timeZone in tzCollection)
    Console.WriteLine("   {0}: {1}", timeZone.Id, timeZone.DisplayName);
    ```

    ```vb
    For Each timeZone As TimeZoneInfo In tzCollection
        Console.WriteLine("   {0}: {1}", timeZone.Id, timeZone.DisplayName)
    Next
    ```

## See Also

[Dates, times, and time zones](index.md)

[Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md)

