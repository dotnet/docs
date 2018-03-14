---
title: "Converting times between time zones"
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
  - "times [.NET Framework], converting"
  - "time zones [.NET Framework], conversions"
  - "UTC times, converting"
  - "converting times"
  - "local time conversions"
ms.assetid: a51e1a3b-c983-4320-b31a-1f9fa3cf824a
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Converting times between time zones

It is becoming increasingly important for any application that works with dates and times to handle differences between time zones. An application can no longer assume that all times can be expressed in the local time, which is the time available from the <xref:System.DateTime> structure. For example, a Web page that displays the current time in the eastern part of the United States will lack credibility to a customer in eastern Asia. This topic explains how to convert times from one time zone to another, as well as how to convert <xref:System.DateTimeOffset> values that have limited time zone awareness.

## Converting to Coordinated Universal Time

Coordinated Universal Time (UTC) is a high-precision, atomic time standard. The world’s time zones are expressed as positive or negative offsets from UTC. Thus, UTC provides a kind of time-zone free or time-zone neutral time. The use of UTC time is recommended when a date and time's portability across computers is important. (For details and other best practices using dates and times, see [Coding best practices using DateTime in the .NET Framework](https://msdn.microsoft.com/library/ms973825.aspx).) Converting individual time zones to UTC makes time comparisons easy.

> [!NOTE]
> You can also serialize a <xref:System.DateTimeOffset> structure to unambiguously represent a single point in time. Because <xref:System.DateTimeOffset> objects store a date and time value along with its offset from UTC, they always represent a particular point in time in relationship to UTC.

The easiest way to convert a time to UTC is to call the `static` (`Shared` in Visual Basic) <xref:System.TimeZoneInfo.ConvertTimeToUtc%28System.DateTime%29?displayProperty=nameWithType> method. The exact conversion performed by the method depends on the value of the `dateTime` parameter's <xref:System.DateTime.Kind%2A> property, as the following table shows.

| `DateTime.Kind`            | Conversion                                                                     |
| -------------------------- | ------------------------------------------------------------------------------ |
| `DateTimeKind.Local`       | Converts local time to UTC.                                                    |
| `DateTimeKind.Unspecified` | Assumes the `dateTime` parameter is local time and converts local time to UTC. |
| `DateTimeKind.Utc`         | Returns the `dateTime` parameter unchanged.                                    |

The following code converts the current local time to UTC and displays the result to the console.

[!code-csharp[System.TimeZone2.Concepts#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#6)]
[!code-vb[System.TimeZone2.Concepts#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#6)]

> [!NOTE]
> The <xref:System.TimeZoneInfo.ConvertTimeToUtc%28System.DateTime%29?displayProperty=nameWithType> method does not necessarily produce results that are identical to the <xref:System.TimeZone.ToUniversalTime%2A?displayProperty=nameWithType> and <xref:System.DateTime.ToUniversalTime%2A?displayProperty=nameWithType> methods. If the host system's local time zone includes multiple adjustment rules, <xref:System.TimeZoneInfo.ConvertTimeToUtc%28System.DateTime%29?displayProperty=nameWithType> applies the appropriate rule to a particular date and time. The other two methods always apply the latest adjustment rule.

If the date and time value does not represent either the local time or UTC, the <xref:System.DateTime.ToUniversalTime%2A> method will likely return an erroneous result. However, you can use the <xref:System.TimeZoneInfo.ConvertTimeToUtc%2A?displayProperty=nameWithType> method to convert the date and time from a specified time zone. (For details on retrieving a <xref:System.TimeZoneInfo> object that represents the destination time zone, see [Finding the time zones defined on a local system](../../../docs/standard/datetime/finding-the-time-zones-on-local-system.md).) The following code uses the <xref:System.TimeZoneInfo.ConvertTimeToUtc%2A?displayProperty=nameWithType> method to convert Eastern Standard Time to UTC.

[!code-csharp[System.TimeZone2.Concepts#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#7)]
[!code-vb[System.TimeZone2.Concepts#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#7)]

Note that this method throws an <xref:System.ArgumentException> if the <xref:System.DateTime> object's <xref:System.DateTime.Kind%2A> property and the time zone are mismatched. A mismatch occurs if the <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind?displayProperty=nameWithType> but the <xref:System.TimeZoneInfo> object does not represent the local time zone, or if the <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind?displayProperty=nameWithType> but the <xref:System.TimeZoneInfo> object does not equal <xref:System.DateTimeKind?displayProperty=nameWithType>.

All of these methods take <xref:System.DateTime> values as parameters and return a <xref:System.DateTime> value. For <xref:System.DateTimeOffset> values, the <xref:System.DateTimeOffset> structure has a <xref:System.DateTimeOffset.ToUniversalTime%2A> instance method that converts the date and time of the current instance to UTC. The following example calls the <xref:System.DateTimeOffset.ToUniversalTime%2A> method to convert a local time and several other times to Coordinated Universal Time (UTC).

[!code-csharp[System.DateTimeOffset.Methods#16](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Methods/cs/Methods.cs#16)]
[!code-vb[System.DateTimeOffset.Methods#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Methods/vb/Methods.vb#16)]

## Converting UTC to a designated time zone

To convert UTC to local time, see the "Converting UTC to Local Time" section that follows. To convert UTC to the time in any time zone that you designate, call the <xref:System.TimeZoneInfo.ConvertTimeFromUtc%2A> method. The method takes two parameters:

* The UTC to convert. This must be a <xref:System.DateTime> value whose <xref:System.DateTime.Kind%2A> property is set to `Unspecified` or `Utc`.

* The time zone to convert the UTC to.

The following code converts UTC to Central Standard Time.

[!code-csharp[System.TimeZone2.Concepts#8](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#8)]
[!code-vb[System.TimeZone2.Concepts#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#8)]

## Converting UTC to local time

To convert UTC to local time, call the <xref:System.DateTime.ToLocalTime%2A> method of the <xref:System.DateTime> object whose time you want to convert. The exact behavior of the method depends on the value of the object’s <xref:System.DateTime.Kind%2A> property, as the following table shows.

| `DateTime.Kind`            | Conversion                                                                               |
| -------------------------- | ---------------------------------------------------------------------------------------- |
| `DateTimeKind.Local`       | Returns the <xref:System.DateTime> value unchanged.                                      |
| `DateTimeKind.Unspecified` | Assumes that the <xref:System.DateTime> value is UTC and converts the UTC to local time. |
| `DateTimeKind.Utc`         | Converts the <xref:System.DateTime> value to local time.                                 |

> [!NOTE]
> The <xref:System.TimeZone.ToLocalTime%2A?displayProperty=nameWithType> method behaves identically to the `DateTime.ToLocalTime` method. It takes a single parameter, which is the date and time value to convert.

You can also convert the time in any designated time zone to local time by using the `static` (`Shared` in Visual Basic) <xref:System.TimeZoneInfo.ConvertTime%2A?displayProperty=nameWithType> method. This technique is discussed in the next section.

## Converting between any two time zones

You can convert between any two time zones by using either of the following two `static` (`Shared` in Visual Basic) methods of the <xref:System.TimeZoneInfo> class:

* <xref:System.TimeZoneInfo.ConvertTime%2A>

  This method's parameters are the date and time value to convert, a `TimeZoneInfo` object that represents the time zone of the date and time value, and a `TimeZoneInfo` object that represents the time zone to convert the date and time value to.

* <xref:System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId%2A>

  This method's parameters are the date and time value to convert, the identifier of the date and time value's time zone, and the identifier of the time zone to convert the date and time value to.

Both methods require that the <xref:System.DateTime.Kind%2A> property of the date and time value to convert and the <xref:System.TimeZoneInfo> object or time zone identifier that represents its time zone correspond to one another. Otherwise, an <xref:System.ArgumentException> is thrown. For example, if the `Kind` property of the date and time value is `DateTimeKind.Local`, an exception is thrown if the `TimeZoneInfo` object passed as a parameter to the method is not equal to `TimeZoneInfo.Local`. An exception is also thrown if the identifier passed as a parameter to the method is not equal to `TimeZoneInfo.Local.Id`.

The following example uses the <xref:System.TimeZoneInfo.ConvertTime%2A> method to convert from Hawaiian Standard Time to local time.

[!code-csharp[System.TimeZone2.Concepts#9](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Concepts/CS/TimeZone2Concepts.cs#9)]
[!code-vb[System.TimeZone2.Concepts#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Concepts/VB/TimeZone2Concepts.vb#9)]

## Converting DateTimeOffset values

Date and time values represented by <xref:System.DateTimeOffset> objects are not fully time-zone aware because the object is disassociated from its time zone at the time it is instantiated. However, in many cases an application simply needs to convert a date and time based on two different offsets from UTC rather than on the time in particular time zones. To perform this conversion, you can call the current instance's <xref:System.DateTimeOffset.ToOffset%2A> method. The method's single parameter is the offset of the new date and time value that the method is to return.

For example, if the date and time of a user request for a Web page is known and is serialized as a string in the format MM/dd/yyyy hh:mm:ss zzzz, the following `ReturnTimeOnServer` method converts this date and time value to the date and time on the Web server.

[!code-csharp[System.DateTimeOffset.Conceptual.OffsetConversions#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.OffsetConversions/cs/TimeConversions.cs#1)]
[!code-vb[System.DateTimeOffset.Conceptual.OffsetConversions#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.OffsetConversions/vb/TimeConversions.vb#1)] 

If the method is passed the string "9/1/2007 5:32:07 -05:00", which represents the date and time in a time zone five hours earlier than UTC, it returns 9/1/2007 3:32:07 AM -07:00 for a server located in the U.S. Pacific Standard Time zone.

The <xref:System.TimeZoneInfo> class also includes an overload of the <xref:System.TimeZoneInfo.ConvertTime%28System.DateTimeOffset%2CSystem.TimeZoneInfo%29?displayProperty=nameWithType> method that performs time zone conversions with <xref:System.DateTimeOffset.ToOffset(System.TimeSpan)> values. The method's parameters are a <xref:System.DateTimeOffset> value and a reference to the time zone to which the time is to be converted. The method call returns a <xref:System.DateTimeOffset> value. For example, the `ReturnTimeOnServer` method in the previous example could be rewritten as follows to call the <xref:System.TimeZoneInfo.ConvertTime%28System.DateTimeOffset%2CSystem.TimeZoneInfo%29> method.

[!code-csharp[System.DateTimeOffset.Conceptual.OffsetConversions#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.OffsetConversions/cs/timeconversions2.cs#2)]
[!code-vb[System.DateTimeOffset.Conceptual.OffsetConversions#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.OffsetConversions/vb/TimeConversions2.vb#2)]

## See also

<xref:System.TimeZoneInfo>
[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
[Finding the time zones defined on a local system](../../../docs/standard/datetime/finding-the-time-zones-on-local-system.md)
