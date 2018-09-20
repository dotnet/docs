---
title: "Formatting numeric results table (C# Reference)"
description: "Learn about C# standard numeric format strings"
ms.date: 09/20/2018
helpviewer_keywords: 
  - "formatting [C#]"
  - "numeric formatting [C#]"
  - "String.Format method"
ms.assetid: 120ba537-4448-4c62-8676-7a8fdd98f496
---
# Formatting numeric results table (C# Reference)

The following table shows supported format specifiers for formatting numeric results.

|Format specifier|Description|Examples|Output|  
|----------------------|-----------------|--------------|------------|  
|C or c|Currency|`Console.Write("{0:C}", 2.5);`<br /><br /> `Console.Write("{0:C}", -2.5);`|$2.50<br /><br /> ($2.50)|  
|D or d|Decimal|`Console.Write("{0:D5}", 25);`|00025|  
|E or e|Exponential|`Console.Write("{0:E2}", 250000);`|2.50E+005|  
|F or f|Fixed-point|`Console.Write("{0:F2}", 2.5);`<br /><br /> `Console.Write("{0:F0}", 2.5);`|2.50<br /><br /> 3|  
|G or g|General|`Console.Write("{0:G}", 2.5);`|2.5|  
|N or n|Numeric|`Console.Write("{0:N}", 2500000);`|2,500,000.00|  
|P or p|Percent|`Console.Write("{0:P}", 0.25);`|25.00%|  
|R or r|Round-trip|`Console.Write("{0:R}", 2.5);`|2.5|  
|X or x|Hexadecimal|`Console.Write("{0:X}", 250);`<br /><br /> `Console.Write("{0:X}", 0xffff);`|FA<br /><br /> FFFF|  

## Remarks

The output presented in the table is generated with the "en-US" <xref:System.Globalization.CultureInfo>.

Decimal and hexadecimal format specifiers are supported only for integral types. The round-trip format specifier is supported only for <xref:System.Single>, <xref:System.Double>, and <xref:System.Numerics.BigInteger> types.

You use a format specifier to create a format string. The format string is of the following form: `Axx`, where

- `A` is the format specifier, which controls the type of formatting applied to the numeric value.
- `xx` is the precision specifier, which affects the number of digits in the formatted output. The value of the precision specifier ranges from 0 to 99.

Standard numeric format strings are supported by:

- Some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the <xref:System.Int32.ToString%28System.String%29?displayProperty=nameWithType> and <xref:System.Int32.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods.

- The .NET [composite formatting feature](../../../standard/base-types/composite-formatting.md), which is supported by the <xref:System.String.Format%2A?displayProperty=nameWithType> method, for example.

- [Interpolated strings](../tokens/interpolated.md).

For more information, see [Standard Numeric Format Strings](../../../standard/base-types/standard-numeric-format-strings.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Reference tables for types](reference-tables-for-types.md)
- [Formatting types](../../../standard/base-types/formatting-types.md)
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- [string](string.md)
