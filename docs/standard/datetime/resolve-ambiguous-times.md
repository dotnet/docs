---
title: "How to: Resolve ambiguous times"
ms.custom: ""
ms.date: "04/10/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "time zones [.NET Framework], ambiguous time"
  - "ambiguous time [.NET Framework]"
ms.assetid: 2cf5fb25-492c-4875-9245-98cac8348e97
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# How to: Resolve ambiguous times

An ambiguous time is a time that maps to more than one Coordinated Universal Time (UTC). It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. When handling an ambiguous time, you can do one of the following:

* Make an assumption about how the time maps to UTC. For example, you can assume that an ambiguous time is always expressed in the time zone's standard time.

* If the ambiguous time is an item of data entered by the user, you can leave it to the user to resolve the ambiguity.

This topic shows how to resolve an ambiguous time by assuming that it represents the time zone's standard time.

### To map an ambiguous time to a time zone's standard time

1. Call the <xref:System.TimeZoneInfo.IsAmbiguousTime%2A> method to determine whether the time is ambiguous.

2. If the time is ambiguous, subtract the time from the <xref:System.TimeSpan> object returned by the time zone's <xref:System.TimeZoneInfo.BaseUtcOffset%2A> property.

3. Call the `static` (`Shared` in Visual Basic .NET) <xref:System.DateTime.SpecifyKind%2A> method to set the UTC date and time value's <xref:System.DateTime.Kind%2A> property to <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>.

## Example

The following example illustrates how to convert an ambiguous time to UTC by assuming that it represents the local time zone's standard time.

[!code-csharp[System.TimeZone2.Concepts#10](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#10)]
[!code-vb[System.TimeZone2.Concepts#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#10)]

The example consists of a method named `ResolveAmbiguousTime` that determines whether the <xref:System.DateTime> value passed to it is ambiguous. If the value is ambiguous, the method returns a <xref:System.DateTime> value that represents the corresponding UTC time. The method handles this conversion by subtracting the value of the local time zone's <xref:System.TimeZoneInfo.BaseUtcOffset%2A> property from the local time.

Ordinarily, an ambiguous time is handled by calling the <xref:System.TimeZoneInfo.GetAmbiguousTimeOffsets%2A> method to retrieve an array of <xref:System.TimeSpan> objects that contain the ambiguous time's possible UTC offsets. However, this example makes the arbitrary assumption that an ambiguous time should always be mapped to the time zone's standard time. The <xref:System.TimeZoneInfo.BaseUtcOffset%2A> property returns the offset between UTC and a time zone's standard time.

In this example, all references to the local time zone are made through the <xref:System.TimeZoneInfo.Local%2A?displayProperty=nameWithType> property; the local time zone is never assigned to an object variable. This is a recommended practice because a call to the <xref:System.TimeZoneInfo.ClearCachedData%2A?displayProperty=nameWithType> method invalidates any objects that the local time zone is assigned to.

## Compiling the code

This example requires:

* That a reference to System.Core.dll be added to the project.

* That the <xref:System> namespace be imported with the `using` statement (required in C# code).

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
[How to: Let users resolve ambiguous times](../../../docs/standard/datetime/let-users-resolve-ambiguous-times.md)
