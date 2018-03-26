---
title: "Formatting Numeric Results Table (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "formatting [C#]"
  - "numeric formatting [C#]"
  - "String.Format method"
  - "Console.Write method"
ms.assetid: 120ba537-4448-4c62-8676-7a8fdd98f496
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# Formatting Numeric Results Table (C# Reference)
You can format numeric results by using the <xref:System.String.Format%2A?displayProperty=nameWithType> method, through the <xref:System.Console.Write%2A?displayProperty=nameWithType> or <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> methods, which call `String.Format`, or by using [string interpolation](../tokens/interpolated.md). The format is specified by using format strings. The following table contains the supported standard format strings. The format string takes the following form: `Axx`, where `A` is the format specifier and `xx` is the precision specifier. The format specifier controls the type of formatting applied to the numeric value, and the precision specifier controls the number of significant digits or decimal places of the formatted output. The value of the precision specifier ranges from 0 to 99.  
  
 For more information about standard and custom formatting strings, see [Formatting Types](../../../standard/base-types/formatting-types.md).
  
|Format Specifier|Description|Examples|Output|  
|----------------------|-----------------|--------------|------------|  
|C or c|Currency|Console.Write("{0:C}", 2.5);<br /><br /> Console.Write("{0:C}", -2.5);|$2.50<br /><br /> ($2.50)|  
|D or d|Decimal|Console.Write("{0:D5}", 25);|00025|  
|E or e|Scientific|Console.Write("{0:E}", 250000);|2.500000E+005|  
|F or f|Fixed-point|Console.Write("{0:F2}", 25);<br /><br /> Console.Write("{0:F0}", 25);|25.00<br /><br /> 25|  
|G or g|General|Console.Write("{0:G}", 2.5);|2.5|  
|N or n|Number|Console.Write("{0:N}", 2500000);|2,500,000.00|  
|X or x|Hexadecimal|Console.Write("{0:X}", 250);<br /><br /> Console.Write("{0:X}", 0xffff);|FA<br /><br /> FFFF|  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Standard Numeric Format Strings](../../../standard/base-types/standard-numeric-format-strings.md)  
 [Reference Tables for Types](../../../csharp/language-reference/keywords/reference-tables-for-types.md)  
 [string](../../../csharp/language-reference/keywords/string.md)
