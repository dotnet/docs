---
title: "How to: Instantiate a TimeZoneInfo object"
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
  - "instantiating time zone objects"
  - "time zone objects [.NET Framework], instantiation"
ms.assetid: 8cb620e5-c6a6-4267-a52e-beeb73cd1a34
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# How to: Instantiate a TimeZoneInfo object

The most common way to instantiate a <xref:System.TimeZoneInfo> object is to retrieve information about it from the registry. This topic discusses how to instantiate a <xref:System.TimeZoneInfo> object from the local system registry.

### To instantiate a TimeZoneInfo object

1. Declare a <xref:System.TimeZoneInfo> object.

2. Call the `static` (`Shared` in Visual Basic) <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A?displayProperty=nameWithType> method.

3. Handle any exceptions thrown by the method, particularly the <xref:System.TimeZoneNotFoundException> that is thrown if the time zone is not defined in the registry.

## Example

The following code retrieves a <xref:System.TimeZoneInfo> object that represents the Eastern Standard Time zone and displays the Eastern Standard time that corresponds to the local time.

[!code-csharp[System.TimeZone2.Concepts#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#5)]
[!code-vb[System.TimeZone2.Concepts#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#5)]

The <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A?displayProperty=nameWithType> method's single parameter is the identifier of the time zone that you want to retrieve, which corresponds to the object's <xref:System.TimeZoneInfo.Id%2A?displayProperty=nameWithType> property. The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the <xref:System.TimeZoneInfo.StandardName%2A> property of a <xref:System.TimeZoneInfo> object, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note the identifiers of the time zones present on them. For an illustration, see [How to: Enumerate time zones present on a computer](../../../docs/standard/datetime/enumerate-time-zones.md). The [Finding the time zones defined on a local system](../../../docs/standard/datetime/finding-the-time-zones-on-local-system.md) topic also contains a list of selected time zone identifiers.

If the time zone is found, the method returns its <xref:System.TimeZoneInfo> object. If the time zone is not found, the method throws a <xref:System.TimeZoneNotFoundException>. If the time zone is found but its data is corrupted or incomplete, the method throws an <xref:System.InvalidTimeZoneException>.

If your application relies on a time zone that must be present, you should first call the <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A> method to retrieve the time zone information from the registry. If the method call fails, your exception handler should then either create a new instance of the time zone or re-create it by deserializing a serialized <xref:System.TimeZoneInfo> object. See [How to: Restore time zones from an embedded resource](../../../docs/standard/datetime/restore-time-zones-from-an-embedded-resource.md) for an example.

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
[Finding the time zones defined on a local system](../../../docs/standard/datetime/finding-the-time-zones-on-local-system.md)
[How to: Access the predefined UTC and local time zone objects](../../../docs/standard/datetime/access-utc-and-local.md)
