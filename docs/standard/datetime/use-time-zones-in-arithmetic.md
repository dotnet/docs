---
title: "How to: Use time zones in date and time arithmetic"
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
  - "time zones [.NET Framework], arithmetic operations"
  - "arithmetic operations [.NET Framework], dates and times"
  - "dates [.NET Framework], adding and subtracting"
ms.assetid: 83dd898d-1338-415d-8cd6-445377ab7871
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# How to: Use time zones in date and time arithmetic

Ordinarily, when you perform date and time arithmetic using <xref:System.DateTime> or <xref:System.DateTimeOffset> values, the result does not reflect any time zone adjustment rules. This is true even when the time zone of the date and time value is clearly identifiable (for example, when the <xref:System.DateTime.Kind%2A> property is set to <xref:System.DateTimeKind.Local>). This topic shows how to perform arithmetic operations on date and time values that belong to a particular time zone. The results of the arithmetic operations will reflect the time zone's adjustment rules.

### To apply adjustment rules to date and time arithmetic

1. Implement some method of closely coupling a date and time value with the time zone to which it belongs. For example, declare a structure that includes both the date and time value and its time zone. The following example uses this approach to link a <xref:System.DateTime> value with its time zone.

   [!code-csharp[System.DateTimeOffset.Conceptual#6](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual6.cs#6)]
   [!code-vb[System.DateTimeOffset.Conceptual#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual6.vb#6)]

2. Convert a time to Coordinated Universal Time (UTC) by calling either the <xref:System.TimeZoneInfo.ConvertTimeToUtc%2A> method or the <xref:System.TimeZoneInfo.ConvertTime%2A> method.

3. Perform the arithmetic operation on the UTC time.

4. Convert the time from UTC to the original time's associated time zone by calling the <xref:System.TimeZoneInfo.ConvertTime%28System.DateTime%2CSystem.TimeZoneInfo%29?displayProperty=nameWithType> method.

## Example

The following example adds two hours and thirty minutes to March 9, 2008, at 1:30 A.M. Central Standard Time. The time zone's transition to daylight saving time occurs thirty minutes later, at 2:00 A.M. on March 9, 2008. Because the example follows the four steps listed in the previous section, it correctly reports the resulting time as 5:00 A.M. on March 9, 2008.

[!code-csharp[System.DateTimeOffset.Conceptual#8](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual8.cs#8)]
[!code-vb[System.DateTimeOffset.Conceptual#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual8.vb#8)]

Both <xref:System.DateTime> and <xref:System.DateTimeOffset> values are disassociated from any time zone to which they might belong. To perform date and time arithmetic in a way that automatically applies a time zone's adjustment rules, the time zone to which any date and time value belongs must be immediately identifiable. This means that a date and time and its associated time zone must be tightly coupled. There are several ways to do this, which include the following:

* Assume that all times used in an application belong to a particular time zone. Although appropriate in some cases, this approach offers limited flexibility and possibly limited portability.

* Define a type that tightly couples a date and time with its associated time zone by including both as fields of the type. This approach is used in the code example, which defines a structure to store the date and time and the time zone in two member fields.

The example illustrates how to perform arithmetic operations on <xref:System.DateTime> values so that time zone adjustment rules are applied to the result. However, <xref:System.DateTimeOffset> values can be used just as easily. The following example illustrates how the code in the original example might be adapted to use <xref:System.DateTimeOffset> instead of <xref:System.DateTime> values.

[!code-csharp[System.DateTimeOffset.Conceptual#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/cs/Conceptual6.cs#7)]
[!code-vb[System.DateTimeOffset.Conceptual#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.DateTimeOffset.Conceptual/vb/Conceptual6.vb#7)]

Note that if this addition is simply performed on the <xref:System.DateTimeOffset> value without first converting it to UTC, the result reflects the correct point in time but its offset does not reflect that of the designated time zone for that time.

## Compiling the code

This example requires:

* That a reference to System.Core.dll be added to the project.

* That the <xref:System> namespace be imported with the `using` statement (required in C# code).

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
[Performing arithmetic operations with dates and times](../../../docs/standard/datetime/performing-arithmetic-operations.md)
