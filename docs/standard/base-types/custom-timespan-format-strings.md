---
title: "Custom TimeSpan Format Strings"
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
  - "format spexifiers, custom time interval"
  - "format strings"
  - "formatting [.NET Framework], time interval"
  - "custom time interval format strings"
  - "formatting [.NET Framework], time"
  - "custom TimeSpan format strings"
ms.assetid: a63ebf55-7269-416b-b4f5-286f6c03bf0e
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Custom TimeSpan Format Strings
A <xref:System.TimeSpan> format string defines the string representation of a <xref:System.TimeSpan> value that results from a formatting operation. A custom format string consists of one or more custom <xref:System.TimeSpan> format specifiers along with any number of literal characters. Any string that is not a [standard TimeSpan format string](../../../docs/standard/base-types/standard-timespan-format-strings.md) is interpreted as a custom <xref:System.TimeSpan> format string.  
  
> [!IMPORTANT]
>  The custom <xref:System.TimeSpan> format specifiers do not include placeholder separator symbols, such as the symbols that separate days from hours, hours from minutes, or seconds from fractional seconds. Instead, these symbols must be included in the custom format string as string literals. For example, `"dd\.hh\:mm"` defines a period (.) as the separator between days and hours, and a colon (:) as the separator between hours and minutes.  
>   
>  Custom <xref:System.TimeSpan> format specifiers also do not include a sign symbol that enables you to differentiate between negative and positive time intervals. To include a sign symbol, you have to construct a format string by using conditional logic. The [Other Characters](#Other) section includes an example.  
  
 The string representations of <xref:System.TimeSpan> values are produced by calls to the overloads of the <xref:System.TimeSpan.ToString%2A?displayProperty=nameWithType> method, and by methods that support composite formatting, such as <xref:System.String.Format%2A?displayProperty=nameWithType>. For more information, see [Formatting Types](../../../docs/standard/base-types/formatting-types.md) and [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md). The following example illustrates the use of custom format strings in formatting operations.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customformatexample1.cs#1)]
 [!code-vb[Conceptual.TimeSpan.Custom#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customformatexample1.vb#1)]  
  
 Custom <xref:System.TimeSpan> format strings are also used by the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> and <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> methods to define the required format of input strings for parsing operations. (Parsing converts the string representation of a value to that value.) The following example illustrates the use of standard format strings in parsing operations.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customparseexample1.cs#2)]
 [!code-vb[Conceptual.TimeSpan.Custom#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customparseexample1.vb#2)]  
  
<a name="table"></a> The following table describes the custom date and time format specifiers.  
  
|Format specifier|Description|Example|  
|----------------------|-----------------|-------------|  
|"d", "%d"|The number of whole days in the time interval.<br /><br /> More information: [The "d" Custom Format Specifier](#dSpecifier).|`new TimeSpan(6, 14, 32, 17, 685):`<br /><br /> `%d` --> "6"<br /><br /> `d\.hh\:mm` --> "6.14:32"|  
|"dd"-"dddddddd"|The number of whole days in the time interval, padded with leading zeros as needed.<br /><br /> More information: [The "dd"-"dddddddd" Custom Format Specifiers](#ddSpecifier).|`new TimeSpan(6, 14, 32, 17, 685):`<br /><br /> `ddd` --> "006"<br /><br /> `dd\.hh\:mm` --> "06.14:32"|  
|"h", "%h"|The number of whole hours in the time interval that are not counted as part of days. Single-digit hours do not have a leading zero.<br /><br /> More information: [The "h" Custom Format Specifier](#hSpecifier).|`new TimeSpan(6, 14, 32, 17, 685):`<br /><br /> `%h` --> "14"<br /><br /> `hh\:mm` --> "14:32"|  
|"hh"|The number of whole hours in the time interval that are not counted as part of days. Single-digit hours have a leading zero.<br /><br /> More information: [The "hh" Custom Format Specifier](#hhSpecifier).|`new TimeSpan(6, 14, 32, 17, 685):`<br /><br /> `hh` --> "14"<br /><br /> `new TimeSpan(6, 8, 32, 17, 685):`<br /><br /> `hh` --> 08|  
|"m", "%m"|The number of whole minutes in the time interval that are not included as part of hours or days. Single-digit minutes do not have a leading zero.<br /><br /> More information: [The "m" Custom Format Specifier](#mSpecifier).|`new TimeSpan(6, 14, 8, 17, 685):`<br /><br /> `%m` --> "8"<br /><br /> `h\:m` --> "14:8"|  
|"mm"|The number of whole minutes in the time interval that are not included as part of hours or days. Single-digit minutes have a leading zero.<br /><br /> More information: [The "mm" Custom Format Specifier](#mmSpecifier).|`new TimeSpan(6, 14, 8, 17, 685):`<br /><br /> `mm` --> "08"<br /><br /> `new TimeSpan(6, 8, 5, 17, 685):`<br /><br /> `d\.hh\:mm\:ss` --> 6.08:05:17|  
|"s", "%s"|The number of whole seconds in the time interval that are not included as part of hours, days, or minutes. Single-digit seconds do not have a leading zero.<br /><br /> More information: [The "s" Custom Format Specifier](#sSpecifier).|`TimeSpan.FromSeconds(12.965)`:<br /><br /> `%s` --> 12<br /><br /> `s\.fff` --> 12.965|  
|"ss"|The number of whole seconds in the time interval that are not included as part of hours, days, or minutes.  Single-digit seconds have a leading zero.<br /><br /> More information: [The "ss" Custom Format Specifier](#ssSpecifier).|`TimeSpan.FromSeconds(6.965)`:<br /><br /> `ss` --> 06<br /><br /> `ss\.fff` --> 06.965|  
|"f", "%f"|The tenths of a second in a time interval.<br /><br /> More information: [The "f" Custom Format Specifier](#fSpecifier).|`TimeSpan.FromSeconds(6.895)`:<br /><br /> `f` --> 8<br /><br /> `ss\.f` --> 06.8|  
|"ff"|The hundredths of a second in a time interval.<br /><br /> More information:[The "ff" Custom Format Specifier](#ffSpecifier).|`TimeSpan.FromSeconds(6.895)`:<br /><br /> `ff` --> 89<br /><br /> `ss\.ff` --> 06.89|  
|"fff"|The milliseconds in a time interval.<br /><br /> More information: [The "fff" Custom Format Specifier](#f3Specifier).|`TimeSpan.FromSeconds(6.895)`:<br /><br /> `fff` --> 895<br /><br /> `ss\.fff` --> 06.895|  
|"ffff"|The ten-thousandths of a second in a time interval.<br /><br /> More information: [The "ffff" Custom Format Specifier](#f4Specifier).|`TimeSpan.Parse("0:0:6.8954321")`:<br /><br /> `ffff` --> 8954<br /><br /> `ss\.ffff` --> 06.8954|  
|"fffff"|The hundred-thousandths of a second in a time interval.<br /><br /> More information: [The "fffff" Custom Format Specifier](#f5Specifier).|`TimeSpan.Parse("0:0:6.8954321")`:<br /><br /> `fffff` --> 89543<br /><br /> `ss\.fffff` --> 06.89543|  
|"ffffff"|The millionths of a second in a time interval.<br /><br /> More information: [The "ffffff" Custom Format Specifier](#f6Specifier).|`TimeSpan.Parse("0:0:6.8954321")`:<br /><br /> `ffffff` --> 895432<br /><br /> `ss\.ffffff` --> 06.895432|  
|"fffffff"|The ten-millionths of a second (or the fractional ticks) in a time interval.<br /><br /> More information: [The "fffffff" Custom Format Specifier](#f7Specifier).|`TimeSpan.Parse("0:0:6.8954321")`:<br /><br /> `fffffff` --> 8954321<br /><br /> `ss\.fffffff` --> 06.8954321|  
|"F", "%F"|The tenths of a second in a time interval. Nothing is displayed if the digit is zero.<br /><br /> More information: [The "F" Custom Format Specifier](#F_Specifier).|`TimeSpan.Parse("00:00:06.32")`:<br /><br /> `%F`: 3<br /><br /> `TimeSpan.Parse("0:0:3.091")`:<br /><br /> `ss\.F`: 03.|  
|"FF"|The hundredths of a second in a time interval. Any fractional trailing zeros or two zero digits are not included.<br /><br /> More information: [The "FF" Custom Format Specifier](#FF_Specifier).|`TimeSpan.Parse("00:00:06.329")`:<br /><br /> `FF`: 32<br /><br /> `TimeSpan.Parse("0:0:3.101")`:<br /><br /> `ss\.FF`: 03.1|  
|"FFF"|The milliseconds in a time interval. Any fractional trailing zeros are not included.<br /><br /> More information:|`TimeSpan.Parse("00:00:06.3291")`:<br /><br /> `FFF`: 329<br /><br /> `TimeSpan.Parse("0:0:3.1009")`:<br /><br /> `ss\.FFF`: 03.1|  
|"FFFF"|The ten-thousandths of a second in a time interval. Any fractional trailing zeros are not included.<br /><br /> More information: [The "FFFF" Custom Format Specifier](#F4_Specifier).|`TimeSpan.Parse("00:00:06.32917")`:<br /><br /> `FFFFF`: 3291<br /><br /> `TimeSpan.Parse("0:0:3.10009")`:<br /><br /> `ss\.FFFF`: 03.1|  
|"FFFFF"|The hundred-thousandths of a second in a time interval. Any fractional trailing zeros are not included.<br /><br /> More information: [The "FFFFF" Custom Format Specifier](#F5_Specifier).|`TimeSpan.Parse("00:00:06.329179")`:<br /><br /> `FFFFF`: 32917<br /><br /> `TimeSpan.Parse("0:0:3.100009")`:<br /><br /> `ss\.FFFFF`: 03.1|  
|"FFFFFF"|The millionths of a second in a time interval. Any fractional trailing zeros are not displayed.<br /><br /> More information: [The "FFFFFF" Custom Format Specifier](#F6_Specifier).|`TimeSpan.Parse("00:00:06.3291791")`:<br /><br /> `FFFFFF`: 329179<br /><br /> `TimeSpan.Parse("0:0:3.1000009")`:<br /><br /> `ss\.FFFFFF`: 03.1|  
|"FFFFFFF"|The ten-millions of a second in a time interval. Any fractional trailing zeros or seven zeros are not displayed.<br /><br /> More information: [The "FFFFFFF" Custom Format Specifier](#F7_Specifier).|`TimeSpan.Parse("00:00:06.3291791")`:<br /><br /> `FFFFFF`: 3291791<br /><br /> `TimeSpan.Parse("0:0:3.1900000")`:<br /><br /> `ss\.FFFFFF`: 03.19|  
|*'string*'|Literal string delimiter.<br /><br /> More information: [Other Characters](#Other).|`new TimeSpan(14, 32, 17):`<br /><br /> `hh':'mm':'ss` --> "14:32:17"|  
|\|The escape character.<br /><br /> More information:[Other Characters](#Other).|`new TimeSpan(14, 32, 17):`<br /><br /> `hh\:mm\:ss` --> "14:32:17"|  
|Any other character|Any other unescaped character is interpreted as a custom format specifier.<br /><br /> More Information: [Other Characters](#Other).|`new TimeSpan(14, 32, 17):`<br /><br /> `hh\:mm\:ss` --> "14:32:17"|  
  
<a name="dSpecifier"></a>   
## The "d" Custom Format Specifier  
 The "d" custom format specifier outputs the value of the <xref:System.TimeSpan.Days%2A?displayProperty=nameWithType> property, which represents the number of whole days in the time interval. It outputs the full number of days in a <xref:System.TimeSpan> value, even if the value has more than one digit. If the value of the <xref:System.TimeSpan.Days%2A?displayProperty=nameWithType> property is zero, the specifier outputs "0".  
  
 If the "d" custom format specifier is used alone, specify "%d" so that it is not misinterpreted as a standard format string. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#3)]
 [!code-vb[Conceptual.TimeSpan.Custom#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#3)]  
  
 The following example illustrates the use of the "d" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#4)]
 [!code-vb[Conceptual.TimeSpan.Custom#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#4)]  
  
 [Back to table](#table)  
  
<a name="ddSpecifier"></a>   
## The "dd"-"dddddddd" Custom Format Specifiers  
 The "dd", "ddd", "dddd", "ddddd", "dddddd", "ddddddd", and "dddddddd" custom format specifiers output the value of the <xref:System.TimeSpan.Days%2A?displayProperty=nameWithType> property, which represents the number of whole days in the time interval.  
  
 The output string includes a minimum number of digits specified by the number of "d" characters in the format specifier, and it is padded with leading zeros as needed. If the digits in the number of days exceed the number of "d" characters in the format specifier, the full number of days is output in the result string.  
  
 The following example uses these format specifiers to display the string representation of two <xref:System.TimeSpan> values. The value of the days component of the first time interval is zero; the value of the days component of the second is 365.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#5)]
 [!code-vb[Conceptual.TimeSpan.Custom#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#5)]  
  
 [Back to table](#table)  
  
<a name="hSpecifier"></a>   
## The "h" Custom Format Specifier  
 The "h" custom format specifier outputs the value of the <xref:System.TimeSpan.Hours%2A?displayProperty=nameWithType> property, which represents the number of whole hours in the time interval that is not counted as part of its day component. It returns a one-digit string value if the value of the <xref:System.TimeSpan.Hours%2A?displayProperty=nameWithType> property is 0 through 9, and it returns a two-digit string value if the value of the <xref:System.TimeSpan.Hours%2A?displayProperty=nameWithType> property ranges from 10 to 23.  
  
 If the "h" custom format specifier is used alone, specify "%h" so that it is not misinterpreted as a standard format string. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#6)]
 [!code-vb[Conceptual.TimeSpan.Custom#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#6)]  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "%h" custom format specifier instead to interpret the numeric string as the number of hours. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#8)]
 [!code-vb[Conceptual.TimeSpan.Custom#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#8)]  
  
 The following example illustrates the use of the "h" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#7)]
 [!code-vb[Conceptual.TimeSpan.Custom#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#7)]  
  
 [Back to table](#table)  
  
<a name="hhSpecifier"></a>   
## The "hh" Custom Format Specifier  
 The "hh" custom format specifier outputs the value of the <xref:System.TimeSpan.Hours%2A?displayProperty=nameWithType> property, which represents the number of whole hours in the time interval that is not counted as part of its day component. For values from 0 through 9, the output string includes a leading zero.  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "hh" custom format specifier instead to interpret the numeric string as the number of hours. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#9)]
 [!code-vb[Conceptual.TimeSpan.Custom#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#9)]  
  
 The following example illustrates the use of the "hh" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#10)]
 [!code-vb[Conceptual.TimeSpan.Custom#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#10)]  
  
 [Back to table](#table)  
  
<a name="mSpecifier"></a>   
## The "m" Custom Format Specifier  
 The "m" custom format specifier outputs the value of the <xref:System.TimeSpan.Minutes%2A?displayProperty=nameWithType> property, which represents the number of whole minutes in the time interval that is not counted as part of its day component. It returns a one-digit string value if the value of the <xref:System.TimeSpan.Minutes%2A?displayProperty=nameWithType> property is 0 through 9, and it returns a two-digit string value if the value of the <xref:System.TimeSpan.Minutes%2A?displayProperty=nameWithType> property ranges from 10 to 59.  
  
 If the "m" custom format specifier is used alone, specify "%m" so that it is not misinterpreted as a standard format string. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#6)]
 [!code-vb[Conceptual.TimeSpan.Custom#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#6)]  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "%m" custom format specifier instead to interpret the numeric string as the number of minutes. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#11)]
 [!code-vb[Conceptual.TimeSpan.Custom#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#11)]  
  
 The following example illustrates the use of the "m" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#12)]
 [!code-vb[Conceptual.TimeSpan.Custom#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#12)]  
  
 [Back to table](#table)  
  
<a name="mmSpecifier"></a>   
## The "mm" Custom Format Specifier  
 The "mm" custom format specifier outputs the value of the <xref:System.TimeSpan.Minutes%2A?displayProperty=nameWithType> property, which represents the number of whole minutes in the time interval that is not included as part of its hours or days component. For values from 0 through 9, the output string includes a leading zero.  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "mm" custom format specifier instead to interpret the numeric string as the number of minutes. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#13)]
 [!code-vb[Conceptual.TimeSpan.Custom#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#13)]  
  
 The following example illustrates the use of the "mm" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#14)]
 [!code-vb[Conceptual.TimeSpan.Custom#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#14)]  
  
 [Back to table](#table)  
  
<a name="sSpecifier"></a>   
## The "s" Custom Format Specifier  
 The "s" custom format specifier outputs the value of the <xref:System.TimeSpan.Seconds%2A?displayProperty=nameWithType> property, which represents the number of whole seconds in the time interval that is not included as part of its hours, days, or minutes component. It returns a one-digit string value if the value of the <xref:System.TimeSpan.Seconds%2A?displayProperty=nameWithType> property is 0 through 9, and it returns a two-digit string value if the value of the <xref:System.TimeSpan.Seconds%2A?displayProperty=nameWithType> property ranges from 10 to 59.  
  
 If the "s" custom format specifier is used alone, specify "%s" so that it is not misinterpreted as a standard format string. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#15)]
 [!code-vb[Conceptual.TimeSpan.Custom#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#15)]  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "%s" custom format specifier instead to interpret the numeric string as the number of seconds. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#17)]
 [!code-vb[Conceptual.TimeSpan.Custom#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#17)]  
  
 The following example illustrates the use of the "s" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#16)]
 [!code-vb[Conceptual.TimeSpan.Custom#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#16)]  
  
 [Back to table](#table)  
  
<a name="ssSpecifier"></a>   
## The "ss" Custom Format Specifier  
 The "ss" custom format specifier outputs the value of the <xref:System.TimeSpan.Seconds%2A?displayProperty=nameWithType> property, which represents the number of whole seconds in the time interval that is not included as part of its hours, days, or minutes component. For values from 0 through 9, the output string includes a leading zero.  
  
 Ordinarily, in a parsing operation, an input string that includes only a single number is interpreted as the number of days. You can use the "ss" custom format specifier instead to interpret the numeric string as the number of seconds. The following example provides an illustration.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#18)]
 [!code-vb[Conceptual.TimeSpan.Custom#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#18)]  
  
 The following example illustrates the use of the "ss" custom format specifier.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/customexamples1.cs#19)]
 [!code-vb[Conceptual.TimeSpan.Custom#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/customexamples1.vb#19)]  
  
 [Back to table](#table)  
  
<a name="fSpecifier"></a>   
## The"f" Custom Format Specifier  
 The "f" custom format specifier outputs the tenths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly one fractional digit.  
  
 If the "f" custom format specifier is used alone, specify "%f" so that it is not misinterpreted as a standard format string.  
  
 The following example uses the "f" custom format specifier to display the tenths of a second in a <xref:System.TimeSpan> value. "f" is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="ffSpecifier"></a>   
## The "ff" Custom Format Specifier  
 The "ff" custom format specifier outputs the hundredths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly two fractional digits.  
  
 The following example uses the "ff" custom format specifier to display the hundredths of a second in a <xref:System.TimeSpan> value. "ff" is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="f3Specifier"></a>   
## The "fff" Custom Format Specifier  
 The "fff" custom format specifier (with three "f" characters) outputs the milliseconds in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly three fractional digits.  
  
 The following example uses the "fff" custom format specifier to display the milliseconds in a <xref:System.TimeSpan> value. "fff" is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="f4Specifier"></a>   
## The "ffff" Custom Format Specifier  
 The "ffff" custom format specifier (with four "f" characters) outputs the ten-thousandths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly four fractional digits.  
  
 The following example uses the "ffff" custom format specifier to display the ten-thousandths of a second in a <xref:System.TimeSpan> value. "ffff" is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="f5Specifier"></a>   
## The "fffff" Custom Format Specifier  
 The "fffff" custom format specifier (with five "f" characters) outputs the hundred-thousandths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly five fractional digits.  
  
 The following example uses the "fffff" custom format specifier to display the hundred-thousandths of a second in a <xref:System.TimeSpan> value. "fffff" is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="f6Specifier"></a>   
## The "ffffff" Custom Format Specifier  
 The "ffffff" custom format specifier (with six "f" characters) outputs the millionths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly six fractional digits.  
  
 The following example uses the "ffffff" custom format specifier to display the millionths of a second in a <xref:System.TimeSpan> value. It is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="f7Specifier"></a>   
## The "fffffff" Custom Format Specifier  
 The "fffffff" custom format specifier (with seven "f" characters) outputs the ten-millionths of a second (or the fractional number of ticks) in a time interval. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the input string must contain exactly seven fractional digits.  
  
 The following example uses the "fffffff" custom format specifier to display the fractional number of ticks in a <xref:System.TimeSpan> value. It is used first as the only format specifier, and then combined with the "s" specifier in a custom format string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/fspecifiers1.cs#20)]
 [!code-vb[Conceptual.TimeSpan.Custom#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/fspecifiers1.vb#20)]  
  
 [Back to table](#table)  
  
<a name="F_Specifier"></a>   
## The "F" Custom Format Specifier  
 The "F" custom format specifier outputs the tenths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. If the value of the time interval's tenths of a second is zero, it is not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths of a second digit is optional.  
  
 If the "F" custom format specifier is used alone, specify "%F" so that it is not misinterpreted as a standard format string.  
  
 The following example uses the "F" custom format specifier to display the tenths of a second in a <xref:System.TimeSpan> value. It also uses this custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#21)]
 [!code-vb[Conceptual.TimeSpan.Custom#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#21)]  
  
 [Back to table](#table)  
  
<a name="FF_Specifier"></a>   
## The "FF" Custom Format Specifier  
 The "FF" custom format specifier outputs the hundredths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths and hundredths of a second digit is optional.  
  
 The following example uses the "FF" custom format specifier to display the hundredths of a second in a <xref:System.TimeSpan> value. It also uses this custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#22](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#22)]
 [!code-vb[Conceptual.TimeSpan.Custom#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#22)]  
  
 [Back to table](#table)  
  
<a name="F3_Specifier"></a>   
## The "FFF" Custom Format Specifier  
 The "FFF" custom format specifier (with three "F" characters) outputs the milliseconds in a time interval. In a formatting operation, any remaining fractional digits are truncated. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths, hundredths, and thousandths of a second digit is optional.  
  
 The following example uses the "FFF" custom format specifier to display the thousandths of a second in a <xref:System.TimeSpan> value. It also uses this custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#23](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#23)]
 [!code-vb[Conceptual.TimeSpan.Custom#23](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#23)]  
  
 [Back to table](#table)  
  
<a name="F4_Specifier"></a>   
## The "FFFF" Custom Format Specifier  
 The "FFFF" custom format specifier (with four "F" characters) outputs the ten-thousandths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths, hundredths, thousandths, and ten-thousandths of a second digit is optional.  
  
 The following example uses the "FFFF" custom format specifier to display the ten-thousandths of a second in a <xref:System.TimeSpan> value. It also uses the "FFFF" custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#24](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#24)]
 [!code-vb[Conceptual.TimeSpan.Custom#24](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#24)]  
  
 [Back to table](#table)  
  
<a name="F5_Specifier"></a>   
## The "FFFFF" Custom Format Specifier  
 The "FFFFF" custom format specifier (with five "F" characters) outputs the hundred-thousandths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths, hundredths, thousandths, ten-thousandths, and hundred-thousandths of a second digit is optional.  
  
 The following example uses the "FFFFF" custom format specifier to display the hundred-thousandths of a second in a <xref:System.TimeSpan> value. It also uses the "FFFFF" custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#25](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#25)]
 [!code-vb[Conceptual.TimeSpan.Custom#25](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#25)]  
  
 [Back to table](#table)  
  
<a name="F6_Specifier"></a>   
## The "FFFFFF" Custom Format Specifier  
 The "FFFFFF" custom format specifier (with six "F" characters) outputs the millionths of a second in a time interval. In a formatting operation, any remaining fractional digits are truncated. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the tenths, hundredths, thousandths, ten-thousandths, hundred-thousandths, and millionths of a second digit is optional.  
  
 The following example uses the "FFFFFF" custom format specifier to display the millionths of a second in a <xref:System.TimeSpan> value. It also uses this custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#26](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#26)]
 [!code-vb[Conceptual.TimeSpan.Custom#26](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#26)]  
  
 [Back to table](#table)  
  
<a name="F7_Specifier"></a>   
## The "FFFFFFF" Custom Format Specifier  
 The "FFFFFFF" custom format specifier (with seven "F" characters) outputs the ten-millionths of a second (or the fractional number of ticks) in a time interval. If there are any trailing fractional zeros, they are not included in the result string. In a parsing operation that calls the <xref:System.TimeSpan.ParseExact%2A?displayProperty=nameWithType> or <xref:System.TimeSpan.TryParseExact%2A?displayProperty=nameWithType> method, the presence of the seven fractional digits in the input string is optional.  
  
 The following example uses the "FFFFFFF" custom format specifier to display the fractional parts of a second in a <xref:System.TimeSpan> value. It also uses this custom format specifier in a parsing operation.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#27](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/f_specifiers1.cs#27)]
 [!code-vb[Conceptual.TimeSpan.Custom#27](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/f_specifiers1.vb#27)]  
  
 [Back to table](#table)  
  
<a name="Other"></a>   
## Other Characters  
 Any other unescaped character in a format string, including a white-space character, is interpreted as a custom format specifier. In most cases, the presence of any other unescaped character results in a <xref:System.FormatException>.  
  
 There are two ways to include a literal character in a format string:  
  
-   Enclose it in single quotation marks (the literal string delimiter).  
  
-   Precede it with a backslash ("\\"), which is interpreted as an escape character. This means that, in C#, the format string must either be @-quoted, or the literal character must be preceded by an additional backslash.  
  
     In some cases, you may have to use conditional logic to include an escaped literal in a format string. The following example uses conditional logic to include a sign symbol for negative time intervals.  
  
     [!code-csharp[Conceptual.TimeSpan.Custom#29](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/negativevalues1.cs#29)]
     [!code-vb[Conceptual.TimeSpan.Custom#29](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/negativevalues1.vb#29)]  
  
 .NET does not define a grammar for separators in time intervals. This means that the separators between days and hours, hours and minutes, minutes and seconds, and seconds and fractions of a second must all be treated as character literals in a format string.  
  
 The following example uses both the escape character and the single quote to define a custom format string that includes the word "minutes" in the output string.  
  
 [!code-csharp[Conceptual.TimeSpan.Custom#28](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.timespan.custom/cs/literal1.cs#28)]
 [!code-vb[Conceptual.TimeSpan.Custom#28](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.timespan.custom/vb/literal1.vb#28)]  
  
 [Back to table](#table)  
  
## See Also  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 [Standard TimeSpan Format Strings](../../../docs/standard/base-types/standard-timespan-format-strings.md)
