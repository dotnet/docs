---
title: "How to: Extract the Day of the Week from a Specific Date"
ms.custom: ""
ms.date: "03/30/2017"
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
  - "formatting [.NET Framework], dates"
  - "DateTime.DayOfWeek property"
  - "DateTime.ToString method"
  - "dates [.NET Framework], retrieving week information"
  - "DateTimeOffset.DayOfWeek property"
  - "dates [.NET Framework], day of week"
  - "Weekday function"
  - "day of week [.NET Framework]"
  - "extracting day of week"
  - "weekday names"
  - "WeekdayName function"
  - "numbers [.NET Framework], day of week"
  - "formatting [.NET Framework], time"
  - "DateTimeOffset.ToString method"
  - "full weekday names"
ms.assetid: 1c9bef76-5634-46cf-b91c-9b9eb72091d7
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Extract the Day of the Week from a Specific Date
The .NET Framework makes it easy to determine the ordinal day of the week for a particular date, and to display the localized weekday name for a particular date. An enumerated value that indicates the day of the week corresponding to a particular date is available from the <xref:System.DateTime.DayOfWeek%2A> or <xref:System.DateTimeOffset.DayOfWeek%2A> property. In contrast, retrieving the weekday name is a formatting operation that can be performed by calling a formatting method, such as a date and time value's `ToString` method or the <xref:System.String.Format%2A?displayProperty=nameWithType> method. This topic shows how to perform these formatting operations.  
  
### To extract a number indicating the day of the week from a specific date  
  
1.  If you are working with the string representation of a date, convert it to a <xref:System.DateTime> or a <xref:System.DateTimeOffset> value by using the static <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> or <xref:System.DateTimeOffset.Parse%2A?displayProperty=nameWithType> method.  
  
2.  Use the <xref:System.DateTime.DayOfWeek%2A?displayProperty=nameWithType> or <xref:System.DateTimeOffset.DayOfWeek%2A?displayProperty=nameWithType> property to retrieve a <xref:System.DayOfWeek> value that indicates the day of the week.  
  
3.  If necessary, cast (in C#) or convert (in Visual Basic) the <xref:System.DayOfWeek> value to an integer.  
  
 The following example displays an integer that represents the day of the week of a specific date.  
  
 [!code-csharp[Formatting.Howto.WeekdayName#7](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/weekdaynumber7.cs#7)]
 [!code-vb[Formatting.Howto.WeekdayName#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/weekdaynumber7.vb#7)]  
  
### To extract the abbreviated weekday name from a specific date  
  
1.  If you are working with the string representation of a date, convert it to a <xref:System.DateTime> or a <xref:System.DateTimeOffset> value by using the static <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> or <xref:System.DateTimeOffset.Parse%2A?displayProperty=nameWithType> method.  
  
2.  You can extract the abbreviated weekday name of the current culture or of a specific culture:  
  
    1.  To extract the abbreviated weekday name for the current culture, call the date and time value's <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%28System.String%29?displayProperty=nameWithType> instance method, and pass the string "ddd" as the `format` parameter. The following example illustrates the call to the <xref:System.DateTime.ToString%28System.String%29> method.  
  
         [!code-csharp[Formatting.Howto.WeekdayName#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/abbrname1.cs#1)]
         [!code-vb[Formatting.Howto.WeekdayName#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/abbrname1.vb#1)]  
  
    2.  To extract the abbreviated weekday name for a specific culture, call the date and time value’s <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> instance method. Pass the string "ddd" as the `format` parameter. Pass either a <xref:System.Globalization.CultureInfo> or a <xref:System.Globalization.DateTimeFormatInfo> object that represents the culture whose weekday name you want to retrieve as the `provider` parameter. The following code illustrates a call to the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29> method using a <xref:System.Globalization.CultureInfo> object that represents the fr-FR culture.  
  
         [!code-csharp[Formatting.Howto.WeekdayName#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/abbrname2.cs#2)]
         [!code-vb[Formatting.Howto.WeekdayName#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/abbrname2.vb#2)]  
  
### To extract the full weekday name from a specific date  
  
1.  If you are working with the string representation of a date, convert it to a <xref:System.DateTime> or a <xref:System.DateTimeOffset> value by using the static <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> or <xref:System.DateTimeOffset.Parse%2A?displayProperty=nameWithType> method.  
  
2.  You can extract the full weekday name of the current culture or of a specific culture:  
  
    1.  To extract the weekday name for the current culture, call the date and time value’s <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%28System.String%29?displayProperty=nameWithType> instance method, and pass the string "dddd" as the `format` parameter. The following example illustrates the call to the <xref:System.DateTime.ToString%28System.String%29> method.  
  
         [!code-csharp[Formatting.Howto.WeekdayName#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/fullname4.cs#4)]
         [!code-vb[Formatting.Howto.WeekdayName#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/fullname4.vb#4)]  
  
    2.  To extract the weekday name for a specific culture, call the date and time value’s <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> or <xref:System.DateTimeOffset.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> instance method. Pass the string "dddd" as the `format` parameter. Pass either a <xref:System.Globalization.CultureInfo> or a <xref:System.Globalization.DateTimeFormatInfo> object that represents the culture whose weekday name you want to retrieve as the `provider` parameter. The following code illustrates a call to the <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29> method using a <xref:System.Globalization.CultureInfo> object that represents the es-ES culture.  
  
         [!code-csharp[Formatting.Howto.WeekdayName#5](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/fullname5.cs#5)]
         [!code-vb[Formatting.Howto.WeekdayName#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/fullname5.vb#5)]  
  
## Example  
 The example illustrates calls to the <xref:System.DateTime.DayOfWeek%2A?displayProperty=nameWithType> and <xref:System.DateTimeOffset.DayOfWeek%2A?displayProperty=nameWithType> properties and the <xref:System.DateTime.ToString%2A?displayProperty=nameWithType> and <xref:System.DateTimeOffset.ToString%2A?displayProperty=nameWithType> methods to retrieve the number that represents the day of the week, the abbreviated weekday name, and the full weekday name for a particular date.  
  
 [!code-csharp[Formatting.Howto.WeekdayName#6](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/example6.cs#6)]
 [!code-vb[Formatting.Howto.WeekdayName#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/example6.vb#6)]  
  
 Individual languages may provide functionality that duplicates or supplements the functionality provided by the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. For example, Visual Basic includes two such functions:  
  
-   `Weekday`, which returns a number that indicates the day of the week of a particular date. It considers the ordinal value of the first day of the week to be one, whereas the <xref:System.DateTime.DayOfWeek%2A?displayProperty=nameWithType> property considers it to be zero.  
  
-   `WeekdayName`, which returns the name of the week in the current culture that corresponds to a particular weekday number.  
  
 The following example illustrates the use of the Visual Basic `Weekday` and `WeekdayName` functions.  
  
 [!code-vb[Formatting.HowTo.WeekdayName#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/example9.vb#9)]  
  
 You can also use the value returned by the <xref:System.DateTime.DayOfWeek%2A?displayProperty=nameWithType> property to retrieve the weekday name of a particular date. This requires only a call to the <xref:System.Enum.ToString%2A> method on the <xref:System.DayOfWeek> value returned by the property. However, this technique does not produce a localized weekday name for the current culture, as the following example illustrates.  
  
 [!code-csharp[Formatting.HowTo.WeekdayName#8](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/cs/Howto1.cs#8)]
 [!code-vb[Formatting.HowTo.WeekdayName#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.WeekdayName/vb/Howto1.vb#8)]  
  
## See Also  
 [Performing Formatting Operations](../../../docs/standard/base-types/performing-formatting-operations.md)  
 [Standard Date and Time Format Strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md)  
 [Custom Date and Time Format Strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md)
