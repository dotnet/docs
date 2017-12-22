---
title: "Converting between DateTime and DateTimeOffset"
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
  - "DateTime structure, converting"
  - "time zones [.NET Framework], conversions"
  - "UTC times, converting"
  - "DateTimeOffset structure, converting"
  - "converting DateTimeOffset and DateTime values"
  - "dates [.NET Framework], converting"
  - "converting times"
  - "Date data type, converting"
  - "local time conversions"
ms.assetid: b605ff97-0c45-4c24-833f-4c6a3e8be64c
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Converting between DateTime and DateTimeOffset

Although the <xref:System.DateTimeOffset> structure provides a greater degree of time zone awareness than the <xref:System.DateTime> structure, <xref:System.DateTime> parameters are used more commonly in method calls. Because of this, the ability to convert <xref:System.DateTimeOffset> values to <xref:System.DateTime> values and vice versa is particularly important. This topic shows how to perform these conversions in a way that preserves as much time zone information as possible.

> [!NOTE]
> Both the <xref:System.DateTime> and the <xref:System.DateTimeOffset> types have some limitations when representing times in time zones. With its <xref:System.DateTime.Kind%2A> property, <xref:System.DateTime> is able to reflect only Coordinated Universal Time (UTC) and the system's local time zone. <xref:System.DateTimeOffset> reflects a time's offset from UTC, but it does not reflect the actual time zone to which that offset belongs. For details about time values and support for time zones, see [Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](../../../docs/standard/datetime/choosing-between-datetime.md).

## Conversions from DateTime to DateTimeOffset

The <xref:System.DateTimeOffset> structure provides two equivalent ways to perform <xref:System.DateTime> to <xref:System.DateTimeOffset> conversion that are suitable for most conversions:

* The <xref:System.DateTimeOffset.%23ctor%2A> constructor, which creates a new <xref:System.DateTimeOffset> object based on a <xref:System.DateTime> value.

* The implicit conversion operator, which allows you to assign a <xref:System.DateTime> value to a <xref:System.DateTimeOffset> object.

For UTC and local <xref:System.DateTime> values, the <xref:System.DateTimeOffset.Offset%2A> property of the resulting <xref:System.DateTimeOffset> value accurately reflects the UTC or local time zone offset. For example, the following code converts a UTC time to its equivalent <xref:System.DateTimeOffset> value.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#1)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#1)]

In this case, the offset of the `utcTime2` variable is 00:00. Similarly, the following code converts a local time to its equivalent <xref:System.DateTimeOffset> value.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#2)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#2)]

However, for <xref:System.DateTime> values whose <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>, these two conversion methods produce a <xref:System.DateTimeOffset> value whose offset is that of the local time zone. This is shown in the following example, which is run in the U.S. Pacific Standard Time zone.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#3](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#3)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#3)]

If the <xref:System.DateTime> value reflects the date and time in something other than the local time zone or UTC, you can convert it to a <xref:System.DateTimeOffset> value and preserve its time zone information by calling the overloaded <xref:System.DateTimeOffset.%23ctor%2A> constructor. For example, the following example instantiates a <xref:System.DateTimeOffset> object that reflects Central Standard Time.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#4](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#4)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#4)]

The second parameter to this constructor overload, a <xref:System.TimeSpan> object that represents the time's offset from UTC, should be retrieved by calling the <xref:System.TimeZoneInfo.GetUtcOffset%28System.DateTime%29?displayProperty=nameWithType> method of the time's corresponding time zone. The method's single parameter is the <xref:System.DateTime> value that represents the date and time to be converted. If the time zone supports daylight saving time, this parameter allows the method to determine the appropriate offset for that particular date and time.

## Conversions from DateTimeOffset to DateTime

The <xref:System.DateTimeOffset.DateTime%2A> property is most commonly used to perform <xref:System.DateTimeOffset> to <xref:System.DateTime> conversion. However, it returns a <xref:System.DateTime> value whose <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind.Unspecified>, as the following example illustrates.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#5)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#5)]

This means that any information about the <xref:System.DateTimeOffset> value's relationship to UTC is lost by the conversion when the <xref:System.DateTimeOffset.DateTime%2A> property is used. This affects <xref:System.DateTimeOffset> values that correspond to UTC time or to the system's local time because the <xref:System.DateTimeOffset.DateTime%2A> structure reflects only those two time zones in its <xref:System.DateTime.Kind%2A> property.

To preserve as much time zone information as possible when converting a <xref:System.DateTimeOffset> to a <xref:System.DateTime> value, you can use the <xref:System.DateTimeOffset.UtcDateTime%2A?displayProperty=nameWithType> and <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> properties.

### Converting a UTC time

To indicate that a converted <xref:System.DateTimeOffset.DateTime%2A> value is the UTC time, you can retrieve the value of the <xref:System.DateTimeOffset.UtcDateTime%2A?displayProperty=nameWithType> property. It differs from the <xref:System.DateTimeOffset.DateTime%2A> property in two ways:

* It returns a <xref:System.DateTime> value whose <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind.Utc>.

* If the <xref:System.DateTimeOffset.Offset%2A> property value does not equal <xref:System.TimeSpan.Zero?displayProperty=nameWithType>, it converts the time to UTC.

> [!NOTE]
> If your application requires that converted <xref:System.DateTime> values unambiguously identify a single point in time, you should consider using the <xref:System.DateTimeOffset.UtcDateTime%2A?displayProperty=nameWithType> property to handle all <xref:System.DateTimeOffset> to <xref:System.DateTime> conversions.

The following code uses the <xref:System.DateTimeOffset.UtcDateTime%2A> property to convert a <xref:System.DateTimeOffset> value whose offset equals <xref:System.TimeSpan.Zero?displayProperty=nameWithType> to a <xref:System.DateTime> value.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#6)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#6)]

The following code uses the <xref:System.DateTimeOffset.UtcDateTime%2A> property to perform both a time zone conversion and a type conversion on a <xref:System.DateTimeOffset> value.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#12](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#12)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#12)]

### Converting a local time

To indicate that a <xref:System.DateTimeOffset> value represents the local time, you can pass the <xref:System.DateTime> value returned by the <xref:System.DateTimeOffset.DateTime%2A?displayProperty=nameWithType> property to the `static` (`Shared` in Visual Basic) <xref:System.DateTime.SpecifyKind%2A> method. The method returns the date and time passed to it as its first parameter, but sets the <xref:System.DateTime.Kind%2A> property to the value specified by its second parameter. The following code uses the <xref:System.DateTime.SpecifyKind%2A> method when converting a <xref:System.DateTimeOffset> value whose offset corresponds to that of the local time zone.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#7)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#7)]

You can also use the <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> property to convert a <xref:System.DateTimeOffset> value to a local <xref:System.DateTime> value. The <xref:System.DateTime.Kind%2A> property of the returned <xref:System.DateTime> value is <xref:System.DateTimeKind.Local>. The following code uses the <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> property when converting a <xref:System.DateTimeOffset> value whose offset corresponds to that of the local time zone. 

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#10](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#10)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#10)]

When you retrieve a <xref:System.DateTime> value using the <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> property, the property's `get` accessor first converts the <xref:System.DateTimeOffset> value to UTC, then converts it to local time by calling the <xref:System.DateTimeOffset.ToLocalTime%2A> method. This means that you can retrieve a value from the <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> property to perform a time zone conversion at the same time that you perform a type conversion. It also means that the local time zone's adjustment rules are applied in performing the conversion. The following code illustrates the use of the <xref:System.DateTimeOffset.LocalDateTime%2A?displayProperty=nameWithType> property to perform both a type and a time zone conversion.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#11](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#11)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#11)]

### A general-purpose conversion method

The following example defines a method named `ConvertFromDateTimeOffset` that converts <xref:System.DateTimeOffset> values to <xref:System.DateTime> values. Based on its offset, it determines whether the <xref:System.DateTimeOffset> value is a UTC time, a local time, or some other time, and defines the returned date and time value's <xref:System.DateTime.Kind%2A> property accordingly.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#8](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#8)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#8)]

The follow example calls the `ConvertFromDateTimeOffset` method to convert <xref:System.DateTimeOffset> values that represent a UTC time, a local time, and a time in the U.S. Central Standard Time zone.

[!code-csharp[System.DateTimeOffset.Conceptual.Conversions#9](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/cs/Conversions.cs#9)]
[!code-vb[System.DateTimeOffset.Conceptual.Conversions#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Conversions/vb/Conversions.vb#9)]

Note that this code makes two assumptions that, depending on the application and the source of its date and time values, may not always be valid:

* It assumes that a date and time value whose offset is <xref:System.TimeSpan.Zero?displayProperty=nameWithType> represents UTC. In fact, UTC is not a time in a particular time zone, but the time in relation to which the times in the world's time zones are standardized. Time zones can also have an offset of <xref:System.TimeSpan.Zero>.

* It assumes that a date and time whose offset equals that of the local time zone represents the local time zone. Because date and time values are disassociated from their original time zone, this may not be the case; the date and time can have originated in another time zone with the same offset.

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
