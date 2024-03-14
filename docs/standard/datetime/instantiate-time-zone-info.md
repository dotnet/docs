---
title: "How to: Obtain a TimeZoneInfo object"
description: Learn how to obtain a TimeZoneInfo object
ms.date: 03/06/2024
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "instantiating time zone objects"
  - "time zone objects [.NET], instantiation"
ms.topic: how-to
---
# How to: Obtain a TimeZoneInfo object

The most common way to obtain a <xref:System.TimeZoneInfo> object is to retrieve information about it from the registry. To obtain the object, call the `static` (`Shared` in Visual Basic) <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A?displayProperty=nameWithType> method, which looks in the registry. Handle any exceptions thrown by the method, particularly the <xref:System.TimeZoneNotFoundException> that's thrown if the time zone isn't defined in the registry.

> [!NOTE]
> Starting in .NET 8, <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A?displayProperty=nameWithType> returns a cached <xref:System.TimeZoneInfo> object instead of instantiating a new object. For more information, see [FindSystemTimeZoneById doesn't return new object](../../core/compatibility/core-libraries/8.0/timezoneinfo-object.md).

## Example

The following code retrieves a <xref:System.TimeZoneInfo> object that represents the Eastern Standard Time zone and displays the Eastern Standard time that corresponds to the local time.

[!code-csharp[System.TimeZone2.Concepts#5](./snippets/timezone-concepts/TimeZone2Concepts.cs#5)]
[!code-vb[System.TimeZone2.Concepts#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#5)]

The <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A?displayProperty=nameWithType> method's single parameter is the identifier of the time zone that you want to retrieve, which corresponds to the object's <xref:System.TimeZoneInfo.Id%2A?displayProperty=nameWithType> property. The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the <xref:System.TimeZoneInfo.StandardName> property of a <xref:System.TimeZoneInfo> object, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note the identifiers of the time zones present on them. For an illustration, see [How to: Enumerate time zones present on a computer](enumerate-time-zones.md). The [Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md) article also contains a list of selected time-zone identifiers.

If the time zone is found, the method returns its <xref:System.TimeZoneInfo> object. If the time zone is not found, the method throws a <xref:System.TimeZoneNotFoundException>. If the time zone is found but its data is corrupted or incomplete, the method throws an <xref:System.InvalidTimeZoneException>.

If your application relies on a time zone that must be present, you should first call the <xref:System.TimeZoneInfo.FindSystemTimeZoneById%2A> method to retrieve the time zone information from the registry. If the method call fails, your exception handler should then either create a new instance of the time zone or re-create it by deserializing a serialized <xref:System.TimeZoneInfo> object. See [How to: Restore time zones from an embedded resource](restore-time-zones-from-an-embedded-resource.md) for an example.

## See also

- [Dates, times, and time zones](index.md)
- [Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md)
- [How to: Access the predefined UTC and local time zone objects](access-utc-and-local.md)
