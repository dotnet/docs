---
title: "Instantiating a DateTimeOffset object"
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
  - "DateTimeOffset structure, converting to DateTime"
  - "DateTimeOffset structure, instantiating"
ms.assetid: 9648375f-d368-4373-a976-3332ece00c0a
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Instantiating a DateTimeOffset object

The <xref:System.DateTimeOffset> structure offers a number of ways to create new <xref:System.DateTimeOffset> values. Many of them correspond directly to the methods available for instantiating new <xref:System.DateTime> values, with enhancements that allow you to specify the date and time value's offset from Coordinated Universal Time (UTC). In particular, you can instantiate a <xref:System.DateTimeOffset> value in the following ways:

* By using a date and time literal.

* By calling a <xref:System.DateTimeOffset> constructor.

* By implicitly converting a value to <xref:System.DateTimeOffset> value.

* By parsing the string representation of a date and time.

This topic provides greater detail and code examples that illustrate these methods of instantiating new <xref:System.DateTimeOffset> values.

## Date and time literals

For languages that support it, one of the most common ways to instantiate a <xref:System.DateTime> value is to provide the date and time as a hard-coded literal value. For example, the following Visual Basic code creates a <xref:System.DateTime> object whose value is January 1, 2008, at 10:00 AM.

[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#1)]

<xref:System.DateTimeOffset> values can also be initialized using date and time literals when using languages that support <xref:System.DateTime> literals. For example, the following Visual Basic code creates a <xref:System.DateTimeOffset> object.

[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#2)]

As the console output shows, the <xref:System.DateTimeOffset> value created in this way is assigned the offset of the local time zone. This means that a <xref:System.DateTimeOffset> value assigned using a character literal does not identify a single point of time if the code is run on different computers.

## DateTimeOffset constructors

The <xref:System.DateTimeOffset> type defines six constructors. Four of them correspond directly to <xref:System.DateTime> constructors, with an additional parameter of type <xref:System.TimeSpan> that defines the date and time's offset from UTC. These allow you to define a <xref:System.DateTimeOffset> value based on the value of its individual date and time components. For example, the following code uses these four constructors to instantiate <xref:System.DateTimeOffset> objects with identical values of 7/1/2008 12:05 AM +01:00.

[!code-csharp[System.DateTimeOffset.Conceptual.Instantiate#3](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/cs/Instantiate.cs#3)]
[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#3)]

Note that, when the value of the <xref:System.DateTimeOffset> object instantiated using a <xref:System.Globalization.PersianCalendar> object as one of the arguments to its constructor is displayed to the console, it is expressed as a date in the Gregorian rather than the Persian calendar. To output a date using the Persian calendar, see the example in the <xref:System.Globalization.PersianCalendar> topic.

The other two constructors create a <xref:System.DateTimeOffset> object from a <xref:System.DateTime> value. The first of these has a single parameter, the <xref:System.DateTime> value to convert to a <xref:System.DateTimeOffset> value. The offset of the resulting <xref:System.DateTimeOffset> value depends on the <xref:System.DateTime.Kind%2A> property of the constructor's single parameter. If its value is <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>, the offset is set equal to <xref:System.TimeSpan.Zero?displayProperty=nameWithType>. Otherwise, its offset is set equal to that of the local time zone. The following example illustrates the use of this constructor to instantiate <xref:System.DateTimeOffset> objects representing UTC and the local time zone:

[!code-csharp[System.DateTimeOffset.Conceptual.Instantiate#4](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/cs/Instantiate.cs#4)]
[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#4)]

> [!NOTE]
> Calling the overload of the <xref:System.DateTimeOffset> constructor that has a single <xref:System.DateTime> parameter is equivalent to performing an implicit conversion of a <xref:System.DateTime> value to a <xref:System.DateTimeOffset> value.

The second constructor that creates a <xref:System.DateTimeOffset> object from a <xref:System.DateTime> value has two parameters: the <xref:System.DateTime> value to convert, and a <xref:System.TimeSpan> value representing the date and time's offset from UTC. This offset value must correspond to the <xref:System.DateTime.Kind%2A> property of the constructor's first parameter or an <xref:System.ArgumentException> is thrown. If the <xref:System.DateTime.Kind%2A> property of the first parameter is <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>, the value of the second parameter must be <xref:System.TimeSpan.Zero?displayProperty=nameWithType>. If the <xref:System.DateTime.Kind%2A> property of the first parameter is <xref:System.DateTimeKind.Local?displayProperty=nameWithType>, the value of the second parameter must be the offset of the local system's time zone. If the <xref:System.DateTime.Kind%2A> property of the first parameter is <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>, the offset can be any valid value. The following code illustrates calls to this constructor to convert <xref:System.DateTime> to <xref:System.DateTimeOffset> values.

[!code-csharp[System.DateTimeOffset.Conceptual.Instantiate#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/cs/Instantiate.cs#5)]
[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#5)]

## Implicit type conversion

The <xref:System.DateTimeOffset> type supports one implicit type conversion: from a <xref:System.DateTime> value to a <xref:System.DateTimeOffset> value. (An implicit type conversion is a conversion from one type to another that does not require an explicit cast (in C#) or conversion (in Visual Basic) and that does not lose information. It makes code like the following possible.

[!code-csharp[System.DateTimeOffset.Conceptual.Instantiate#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/cs/Instantiate.cs#6)]
[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#6)]

The offset of the resulting <xref:System.DateTimeOffset> value depends on the <xref:System.DateTime.Kind%2A?displayProperty=nameWithType> property value. If its value is <xref:System.DateTimeKind.Utc?displayProperty=nameWithType>, the offset is set equal to <xref:System.TimeSpan.Zero?displayProperty=nameWithType>. If its value is either <xref:System.DateTimeKind.Local?displayProperty=nameWithType> or <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>, the offset is set equal to that of the local time zone.

## Parsing the string representation of a date and time

The <xref:System.DateTimeOffset> type supports four methods that allow you to convert the string representation of a date and time into a <xref:System.DateTimeOffset> value:

* <xref:System.DateTimeOffset.Parse%2A>, which tries to convert the string representation of a date and time to a <xref:System.DateTimeOffset> value and throws an exception if the conversion fails.

* <xref:System.DateTimeOffset.TryParse%2A>, which tries to convert the string representation of a date and time to a <xref:System.DateTimeOffset> value and returns `false` if the conversion fails.

* <xref:System.DateTimeOffset.ParseExact%2A>, which tries to convert the string representation of a date and time in a specified format to a <xref:System.DateTimeOffset> value. The method throws an exception if the conversion fails.

* <xref:System.DateTimeOffset.TryParseExact%2A>, which tries to convert the string representation of a date and time in a specified format to a <xref:System.DateTimeOffset> value. The method returns `false` if the conversion fails.

The following example illustrates calls to each of these four string conversion methods to instantiate a <xref:System.DateTimeOffset> value.

[!code-csharp[System.DateTimeOffset.Conceptual.Instantiate#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/cs/Instantiate.cs#7)]
[!code-vb[System.DateTimeOffset.Conceptual.Instantiate#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual.Instantiate/vb/Instantiate.vb#7)]

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
