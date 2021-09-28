---
description: "Learn more about: How to: Create time zones without adjustment rules"
title: "How to: Create time zones without adjustment rules"
ms.date: "04/10/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "time zones [.NET], adjustment rule"
  - "time zones [.NET], creating"
  - "adjustment rule [.NET]"
ms.topic: how-to
---
# How to: Create time zones without adjustment rules

The precise time zone information that is required by an application may not be present on a particular system for several reasons:

- The time zone has never been defined in the local system's registry.

- Data about the time zone has been modified or removed from the registry.

- The time zone exists but does not have accurate information about time zone adjustments for a particular historic period.

In these cases, you can call the <xref:System.TimeZoneInfo.CreateCustomTimeZone%2A> method to define the time zone required by your application. You can use the overloads of this method to create a time zone with or without adjustment rules. If the time zone supports daylight saving time, you can define adjustments with either fixed or floating adjustment rules. (For definitions of these terms, see the "Time Zone Terminology" section in [Time zone overview](time-zone-overview.md).)

> [!IMPORTANT]
> Custom time zones created by calling the <xref:System.TimeZoneInfo.CreateCustomTimeZone%2A> method are not added to the registry. Instead, they can be accessed only through the object reference returned by the <xref:System.TimeZoneInfo.CreateCustomTimeZone%2A> method call.

This topic shows how to create a time zone without adjustment rules. To create a time zone that supports daylight saving time adjustment rules, see [How to: Create time zones with adjustment rules](create-time-zones-with-adjustment-rules.md).

### To create a time zone without adjustment rules

1. Define the time zone's display name.

   The display name follows a fairly standard format in which the time zone's offset from Coordinated Universal Time (UTC) is enclosed in parentheses and is followed by a string that identifies the time zone, one or more of the cities in the time zone, or one or more of the countries or regions in the time zone.

2. Define the name of the time zone's standard time. Typically, this string is also used as the time zone's identifier.

3. If you want to use a different identifier than the time zone's standard name, define the time zone identifier.

4. Instantiate a <xref:System.TimeSpan> object that defines the time zone's offset from UTC. Time zones with times that are later than UTC have a positive offset. Time zones with times that are earlier than UTC have a negative offset.

5. Call the <xref:System.TimeZoneInfo.CreateCustomTimeZone%28System.String%2CSystem.TimeSpan%2CSystem.String%2CSystem.String%29?displayProperty=nameWithType> method to instantiate the new time zone.

## Example

The following example defines a custom time zone for Mawson, Antarctica, which has no adjustment rules.

[!code-csharp[System.TimeZone2.CreateTimeZone#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.CreateTimeZone/cs/System.TimeZone2.CreateTimeZone.cs#1)]
[!code-vb[System.TimeZone2.CreateTimeZone#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.CreateTimeZone/vb/System.TimeZone2.CreateTimeZone.vb#1)]

The string assigned to the <xref:System.TimeZoneInfo.DisplayName%2A> property follows a standard format in which the time zone's offset from UTC is followed by a friendly description of the time zone.

## Compiling the code

This example requires:

- That the following namespaces be imported:

  [!code-csharp[System.TimeZone2.CreateTimeZone#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.CreateTimeZone/cs/System.TimeZone2.CreateTimeZone.cs#6)]
  [!code-vb[System.TimeZone2.CreateTimeZone#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.CreateTimeZone/vb/System.TimeZone2.CreateTimeZone.vb#6)]

## See also

- [Dates, times, and time zones](index.md)
- [Time zone overview](time-zone-overview.md)
- [How to: Create time zones with adjustment rules](create-time-zones-with-adjustment-rules.md)
