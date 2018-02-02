---
title: "Performing arithmetic operations with dates and times"
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
  - "times [.NET Framework], arithmetic operations"
  - "dates [.NET Framework], arithmetic operations"
  - "time zones [.NET Framework], arithmetic operations"
  - "arithmetic operations [.NET Framework], dates and times"
  - "dates [.NET Framework], comparing"
  - "DateTime structure, arithmetic operations"
  - "DateTimeOffset structure, arithmetic operations"
ms.assetid: 87c7ddf2-f15e-48af-8602-b3642237e6d0
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Performing arithmetic operations with dates and times

Although both the <xref:System.DateTime> and the <xref:System.DateTimeOffset> structures provide members that perform arithmetic operations on their values, the results of arithmetic operations are very different. This topic examines those differences, relates them to degrees of time zone awareness in date and time data, and discusses how to perform fully time zone aware operations using date and time data.

## Comparisons and arithmetic operations with DateTime values

The <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> property allows a <xref:System.DateTimeKind> value to be assigned to the date and time to indicate whether it represents local time, Coordinated Universal Time (UTC), or the time in an unspecified time zone. However, this limited time zone information is ignored when comparing or performing date and time arithmetic on <xref:System.DateTimeKind> values. The following example, which compares the current local time with the current UTC time, illustrates this.

[!code-csharp[System.DateTimeOffset.Conceptual#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual2.cs#2)]
[!code-vb[System.DateTimeOffset.Conceptual#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual2.vb#2)]

The <xref:System.DateTime.CompareTo%28System.DateTime%29> method reports that the local time is earlier than (or less than) the UTC time, and the subtraction operation indicates that the difference between UTC and the local time for a system in the U.S. Pacific Standard Time zone is seven hours. But because these two values provide different representations of a single point in time, it is clear in this case that this time interval is completely attributable to the local time zone's offset from UTC.

More generally, the <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> property does not affect the results returned by <xref:System.DateTime.Kind> comparison and arithmetic methods (as the comparison of two identical points in time indicates), although it can affect the interpretation of those results. For example:

* The result of any arithmetic operation performed on two date and time values whose <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> properties both equal <xref:System.DateTimeKind> reflects the actual time interval between the two values. Similarly, the comparison of two such date and time values accurately reflects the relationship between times.

* The result of any arithmetic or comparison operation performed on two date and time values whose <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> properties both equal <xref:System.DateTimeKind> or on two date and time values with different <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> property values reflects the difference in clock time between the two values.

* Arithmetic or comparison operations on local date and time values do not consider whether a particular value is ambiguous or invalid, nor do they take account of the effect of any adjustment rules that result from the local time zone's transition to or from daylight saving time.

* Any operation that compares or calculates the difference between UTC and a local time includes a time interval equal to the local time zone's offset from UTC in the result.

* Any operation that compares or calculates the difference between an unspecified time and either UTC or the local time reflects simple clock time. Time zone differences are not considered, and the result does not reflect the application of time zone adjustment rules.

* Any operation that compares or calculates the difference between two unspecified times may include an unknown interval that reflects the difference between the time in two different time zones.

There are many scenarios in which time zone differences do not affect date and time calculations (for a discussion of some of these, see [Choosing between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](../../../docs/standard/datetime/choosing-between-datetime.md)) or in which the context of the date and time data defines the meaning of comparison or arithmetic operations.

## Comparisons and arithmetic operations with DateTimeOffset values

A <xref:System.DateTimeOffset> value includes not only a date and time, but also an offset that unambiguously defines that date and time relative to UTC. This makes it possible to define equality somewhat differently than for <xref:System.DateTimeOffset> values. Whereas <xref:System.DateTime> values are equal if they have the same date and time value, <xref:System.DateTimeOffset> values are equal if they both refer to the same point in time. This makes a <xref:System.DateTimeOffset> value more accurate and less in need of interpretation when used in comparisons and in most arithmetic operations that determine the interval between two dates and times. The following example, which is the <xref:System.DateTimeOffset> equivalent to the previous example that compared local and UTC <xref:System.DateTimeOffset> values, illustrates this difference in behavior.

[!code-csharp[System.DateTimeOffset.Conceptual#3](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual3.cs#3)]
[!code-vb[System.DateTimeOffset.Conceptual#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual3.vb#3)]

In this example, the <xref:System.DateTimeOffset.CompareTo%2A> method indicates that the current local time and the current UTC time are equal, and subtraction of <xref:System.DateTimeOffset.CompareTo(System.DateTimeOffset)> values indicates that the difference between the two times is <xref:System.TimeSpan.Zero?displayProperty=nameWithType>.

The chief limitation of using <xref:System.DateTimeOffset> values in date and time arithmetic is that although <xref:System.DateTimeOffset> values have some time zone awareness, they are not fully time zone aware. Although the <xref:System.DateTimeOffset> value's offset reflects a time zone's offset from UTC when a <xref:System.DateTimeOffset> variable is first assigned a value, it becomes disassociated from the time zone thereafter. Because it is no longer directly associated with an identifiable time, the addition and subtraction of date and time intervals does not consider a time zone's adjustment rules.

To illustrate, the transition to daylight saving time in the U.S. Central Standard Time zone occurs at 2:00 A.M. on March 9, 2008. This means that adding a two and a half hour interval to a Central Standard time of 1:30 A.M. on March 9, 2008, should produce a date and time of 5:00 A.M. on March 9, 2008. However, as the following example shows, the result of the addition is 4:00 A.M. on March 9, 2008. Note that this result of this operation does represent the correct point in time, although it is not the time in the time zone in which we are interested (that is, it does not have the expected time zone offset).

[!code-csharp[System.DateTimeOffset.Conceptual#4](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual4.cs#4)]
[!code-vb[System.DateTimeOffset.Conceptual#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual4.vb#4)]

## Arithmetic operations with times in time zones

The <xref:System.TimeZoneInfo> class includes a number of conversion methods that automatically apply adjustments when they convert times from one time zone to another. These include the following:

* The <xref:System.TimeZoneInfo.ConvertTime%2A> and <xref:System.TimeZoneInfo.ConvertTimeBySystemTimeZoneId%2A> methods, which convert times between any two time zones.

* The <xref:System.TimeZoneInfo.ConvertTimeFromUtc%2A> and <xref:System.TimeZoneInfo.ConvertTimeToUtc%2A> methods, which convert the time in a particular time zone to UTC, or convert UTC to the time in a particular time zone.

For details, see [Converting times between time zones](../../../docs/standard/datetime/converting-between-time-zones.md).

The <xref:System.TimeZoneInfo.ConvertTimeToUtc(System.DateTime)> class does not provide any methods that automatically apply adjustment rules when you perform date and time arithmetic. However, you can do this by converting the time in a time zone to UTC, performing the arithmetic operation, and then converting from UTC back to the time in the time zone. For details, see [How to: Use time zones in date and time arithmetic](../../../docs/standard/datetime/use-time-zones-in-arithmetic.md).

For example, the following code is similar to the previous code that added two-and-a-half hours to 2:00 A.M. on March 9, 2008. However, because it converts a Central Standard time to UTC before it performs date and time arithmetic, and then converts the result from UTC back to Central Standard time, the resulting time reflects the Central Standard Time Zone's transition to daylight saving time.

[!code-csharp[System.DateTimeOffset.Conceptual#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual5.cs#5)]
[!code-vb[System.DateTimeOffset.Conceptual#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual5.vb#5)]

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
[How to: Use time zones in date and time arithmetic](../../../docs/standard/datetime/use-time-zones-in-arithmetic.md)
