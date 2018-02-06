---
title: "Choosing between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo"
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
  - "DateTimeOffset structure"
  - "TimeZoneInfo class"
  - "time zones [.NET Framework], common uses"
  - "date and time classes [.NET Framework]"
  - "time zones [.NET Framework], type options"
  - "DateTime structure"
ms.assetid: 07f17aad-3571-4014-9ef3-b695a86f3800
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Choosing between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo

.NET applications that use date and time information are very diverse and can use that information in several ways. The more common uses of date and time information include one or more of the following:

* To reflect a date only, so that time information is not important.

* To reflect a time only, so that date information is not important.

* To reflect an abstract date and time that is not tied to a specific time and place (for example, most stores in an international chain open on weekdays at 9:00 A.M.).

* To retrieve date and time information from sources outside of .NET, typically where date and time information is stored in a simple data type.

* To uniquely and unambiguously identify a single point in time. Some applications require that a date and time be unambiguous only on the host system; others require that it be unambiguous across systems (that is, a date serialized on one system can be meaningfully deserialized and used on another system anywhere in the world).

* To preserve multiple related times (such as the requestor's local time and the server's time of receipt for a Web request).

* To perform date and time arithmetic, possibly with a result that uniquely and unambiguously identifies a single point in time.

.NET includes the <xref:System.DateTime>, <xref:System.DateTimeOffset>, <xref:System.TimeSpan>, and <xref:System.TimeZoneInfo> types, all of which can be used to build applications that work with dates and times.

> [!NOTE]
> This topic does not discuss a fourth type, <xref:System.TimeZone>, because its functionality is almost entirely incorporated in the <xref:System.TimeZoneInfo> class. Whenever possible, developers should use the <xref:System.TimeZoneInfo> class instead of the <xref:System.TimeZone> class.

## The DateTime structure

A <xref:System.DateTime> value defines a particular date and time. It includes a <xref:System.DateTime.Kind%2A> property that provides limited information about the time zone to which that date and time belongs. The <xref:System.DateTimeKind> value returned by the <xref:System.DateTime.Kind%2A> property indicates whether the <xref:System.DateTime> value represents the local time (<xref:System.DateTimeKind.Local?displayProperty=nameWithType>), Coordinated Universal Time (UTC) (<xref:System.DateTimeKind.Utc?displayProperty=nameWithType>), or an unspecified time (<xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>).

The <xref:System.DateTime> structure is suitable for applications that do the following:

* Work with dates only.

* Work with times only.

* Work with abstract dates and times.

* Work with dates and times for which time zone information is missing.

* Work with UTC dates and times only.

* Retrieve date and time information from sources outside of .NET, such as SQL databases. Typically, these sources store date and time information in a simple format that is compatible with the <xref:System.DateTime> structure.

* Perform date and time arithmetic, but are concerned with general results. For example, in an addition operation that adds six months to a particular date and time, it is often not important whether the result is adjusted for daylight saving time.

Unless a particular <xref:System.DateTime> value represents UTC, that date and time value is often ambiguous or limited in its portability. For example, if a <xref:System.DateTime> value represents the local time, it is portable within that local time zone (that is, if the value is deserialized on another system in the same time zone, that value still unambiguously identifies a single point in time). Outside the local time zone, that <xref:System.DateTime> value can have multiple interpretations. If the value's <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>, it is even less portable: it is now ambiguous within the same time zone and possibly even on the same system on which it was first serialized. Only if a <xref:System.DateTime> value represents UTC does that value unambiguously identify a single point in time regardless of the system or time zone in which the value is used.

> [!IMPORTANT]
> When saving or sharing <xref:System.DateTime> data, UTC should be used and the <xref:System.DateTime> value's <xref:System.DateTime.Kind%2A> property should be set to <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>.

## The DateTimeOffset structure

The <xref:System.DateTimeOffset> structure represents a date and time value, together with an offset that indicates how much that value differs from UTC. Thus, the value always unambiguously identifies a single point in time.

The <xref:System.DateTimeOffset> type includes all of the functionality of the <xref:System.DateTime> type along with time zone awareness. This makes it suitable for applications that do the following:

* Uniquely and unambiguously identify a single point in time. The <xref:System.DateTimeOffset> type can be used to unambiguously define the meaning of "now", to log transaction times, to log the times of system or application events, and to record file creation and modification times.

* Perform general date and time arithmetic.

* Preserve multiple related times, as long as those times are stored as two separate values or as two members of a structure.

> [!NOTE]
> These uses for <xref:System.DateTimeOffset> values are much more common than those for <xref:System.DateTime> values. As a result, <xref:System.DateTimeOffset> should be considered the default date and time type for application development.

A <xref:System.DateTimeOffset> value is not tied to a particular time zone, but can originate from any of a variety of time zones. To illustrate this, the following example lists the time zones to which a number of <xref:System.DateTimeOffset> values (including a local Pacific Standard Time) can belong.

[!code-csharp[System.DateTimeOffset.Conceptual#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual1.cs#1)]
[!code-vb[System.DateTimeOffset.Conceptual#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual1.vb#1)]

The output shows that each date and time value in this example can belong to at least three different time zones. The <xref:System.DateTimeOffset> value of 6/10/2007 shows that if a date and time value represents a daylight saving time, its offset from UTC does not even necessarily correspond to the originating time zone's base UTC offset or to the offset from UTC found in its display name. This means that, because a single <xref:System.DateTimeOffset> value is not tightly coupled with its time zone, it cannot reflect a time zone's transition to and from daylight saving time. This can be particularly problematic when date and time arithmetic is used to manipulate a <xref:System.DateTimeOffset> value. (For a discussion of how to perform date and time arithmetic in a way that takes account of a time zone's adjustment rules, see [Performing arithmetic operations with dates and times](../../../docs/standard/datetime/performing-arithmetic-operations.md).)

## The TimeSpan structure

The <xref:System.TimeSpan> structure represents a time interval. Its two typical uses are:

* Reflecting the time interval between two date and time values. For example, subtracting one <xref:System.DateTime> value from another returns a <xref:System.TimeSpan> value.

* Measuring elapsed time. For example, the <xref:System.Diagnostics.Stopwatch.Elapsed%2A?displayProperty=nameWithType> property returns a <xref:System.TimeSpan> value that reflects the time interval that has elapsed since the call to one of the <xref:System.Diagnostics.Stopwatch> methods that begins to measure elapsed time.

A <xref:System.TimeSpan> value can also be used as a replacement for a <xref:System.DateTime> value when that value reflects a time without reference to a particular time of day. This usage is similar to the <xref:System.DateTime.TimeOfDay%2A?displayProperty=nameWithType> and <xref:System.DateTimeOffset.TimeOfDay%2A?displayProperty=nameWithType> properties, which return a <xref:System.TimeSpan> value that represents the time without reference to a date. For example, the <xref:System.TimeSpan> structure can be used to reflect a store's daily opening or closing time, or it can be used to represent the time at which any regular event occurs.

The following example defines a `StoreInfo` structure that includes <xref:System.TimeSpan> objects for store opening and closing times, as well as a <xref:System.TimeZoneInfo> object that represents the store's time zone. The structure also includes two methods, `IsOpenNow` and `IsOpenAt`, that indicates whether the store is open at a time specified by the user, who is assumed to be in the local time zone.

[!code-csharp[Conceptual.ChoosingDates#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.choosingdates/cs/datetimereplacement1.cs#1)]
[!code-vb[Conceptual.ChoosingDates#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.choosingdates/vb/datetimereplacement1.vb#1)]

The `StoreInfo` structure can then be used by client code like the following.

[!code-csharp[Conceptual.ChoosingDates#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.choosingdates/cs/datetimereplacement1.cs#2)]
[!code-vb[Conceptual.ChoosingDates#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.choosingdates/vb/datetimereplacement1.vb#2)]

## The TimeZoneInfo class

The <xref:System.TimeZoneInfo> class represents any of the Earth's time zones, and enables the conversion of any date and time in one time zone to its equivalent in another time zone. The <xref:System.TimeZoneInfo> class makes it possible to work with dates and times so that any date and time value unambiguously identifies a single point in time. The <xref:System.TimeZoneInfo> class is also extensible. Although it depends on time zone information provided for Windows systems and defined in the registry, it supports the creation of custom time zones. It also supports the serialization and deserialization of time zone information.

In some cases, taking full advantage of the <xref:System.TimeZoneInfo> class may require further development work. If date and time values are not tightly coupled with the time zones to which they belong, further work is required. Unless your application provides some mechanism for linking a date and time with its associated time zone, it's easy for a particular date and time value to become disassociated from its time zone. One method of linking this information is to define a class or structure that contains both the date and time value and its associated time zone object.

Taking advantage of time zone support in .NET is possible only if the time zone to which a date and time value belongs is known when that date and time object is instantiated. This is often not the case, particularly in Web or network applications.

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
