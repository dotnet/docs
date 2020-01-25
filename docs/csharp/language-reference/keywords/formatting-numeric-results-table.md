---
title: "Formatting numeric results table - C# Reference"
description: "Learn about C# standard numeric format strings"
ms.date: 09/20/2018
helpviewer_keywords: 
  - "formatting [C#]"
  - "numeric formatting [C#]"
  - "String.Format method"
ms.assetid: 120ba537-4448-4c62-8676-7a8fdd98f496
---
# Formatting numeric results table (C# Reference)

The following table shows supported format specifiers for formatting numeric results. The formatted result in the last column corresponds to the "en-US" <xref:System.Globalization.CultureInfo>.

|Format specifier|Description|Examples|Result|  
|----------------------|-----------------|--------------|------------|  
|C or c|Currency|`string s = $"{2.5:C}";`<br /><br /> `string s = $"{-2.5:C}";`|\\$2.50<br /><br /> (\\$2.50)|  
|D or d|Decimal|`string s = $"{25:D5}";`|00025|  
|E or e|Exponential|`string s = $"{250000:E2}";`|2.50E+005|  
|F or f|Fixed-point|`string s = $"{2.5:F2}";`<br /><br /> `string s = $"{2.5:F0}";`|2.50<br /><br /> 3|  
|G or g|General|`string s = $"{2.5:G}";`|2.5|  
|N or n|Numeric|`string s = $"{2500000:N}";`|2,500,000.00|  
|P or p|Percent|`string s = $"{0.25:P}";`|25.00%|  
|R or r|Round-trip|`string s = $"{2.5:R}";`|2.5|  
|X or x|Hexadecimal|`string s = $"{250:X}";`<br /><br /> `string s = $"{0xffff:X}";`|FA<br /><br /> FFFF|  

## Remarks

You use a format specifier to create a format string. The format string is of the following form: `Axx`, where

- `A` is the format specifier, which controls the type of formatting applied to the numeric value.
- `xx` is the precision specifier, which affects the number of digits in the formatted output. The value of the precision specifier ranges from 0 to 99.

The decimal ("D" or "d") and hexadecimal ("X" or "x") format specifiers are supported only for integral types. The round-trip ("R" or "r") format specifier is supported only for <xref:System.Single>, <xref:System.Double>, and <xref:System.Numerics.BigInteger> types.

Standard numeric format strings are supported by:

- Some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the <xref:System.Int32.ToString%28System.String%29?displayProperty=nameWithType> and <xref:System.Int32.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods.

- The .NET [composite formatting feature](../../../standard/base-types/composite-formatting.md), which is supported by the <xref:System.String.Format%2A?displayProperty=nameWithType> method, for example.

- [Interpolated strings](../tokens/interpolated.md).

For more information, see [Standard Numeric Format Strings](../../../standard/base-types/standard-numeric-format-strings.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Formatting types](../../../standard/base-types/formatting-types.md)
- [Composite formatting](../../../standard/base-types/composite-formatting.md)
- [String interpolation](../tokens/interpolated.md)
- [string](../builtin-types/reference-types.md)
