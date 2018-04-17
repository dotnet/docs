---
title: "Standard Numeric Format Strings"
ms.date: "09/10/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "numeric format strings [.NET Framework]"
  - "formatting [.NET Framework], numbers"
  - "standard format strings, numeric"
  - "format strings"
  - "numbers [.NET Framework], formatting"
  - "format specifiers, numeric"
  - "standard numeric format strings"
  - "formatting numbers [.NET Framework]"
  - "format specifiers, standard numeric format strings"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Standard Numeric Format Strings
Standard numeric format strings are used to format common numeric types. A standard numeric format string takes the form `Axx`, where:  
  
-   `A` is a single alphabetic character called the *format specifier*. Any numeric format string that contains more than one alphabetic character, including white space, is interpreted as a custom numeric format string. For more information, see [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md).  
  
-   `xx` is an optional integer called the *precision specifier*. The precision specifier ranges from 0 to 99 and affects the number of digits in the result. Note that the precision specifier controls the number of digits in the string representation of a number. It does not round the number itself. To perform a rounding operation, use the <xref:System.Math.Ceiling%2A?displayProperty=nameWithType>, <xref:System.Math.Floor%2A?displayProperty=nameWithType>, or <xref:System.Math.Round%2A?displayProperty=nameWithType> method.  
  
     When *precision specifier* controls the number of fractional digits in the result string, the result strings reflect numbers that are rounded away from zero (that is, using <xref:System.MidpointRounding.AwayFromZero?displayProperty=nameWithType>).  
  
    > [!NOTE]
    >  The precision specifier determines the number of digits in the result string. To pad a result string with leading or trailing spaces, use the [composite formatting](../../../docs/standard/base-types/composite-formatting.md) feature and define an *alignment component* in the format item.  
  
Standard numeric format strings are supported by:

- Some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the <xref:System.Int32.ToString%28System.String%29?displayProperty=nameWithType> and <xref:System.Int32.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods. 
 
- The .NET [composite formatting feature](../../../docs/standard/base-types/composite-formatting.md), which is used by some `Write` and `WriteLine` methods of the <xref:System.Console> and <xref:System.IO.StreamWriter> classes, the <xref:System.String.Format%2A?displayProperty=nameWithType> method, and the <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType> method. The composite format feature allows you to include the string representation of multiple data items in a single string, to specify field width, and to align numbers in a field. For more information, see [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md).  

- [Interpolated strings](../../csharp/language-reference/tokens/interpolated.md) in C# and Visual Basic, which provide a simplified syntax when compared to composite format strings.
 
> [!TIP]
>  You can download the [Formatting Utility](https://code.msdn.microsoft.com/NET-Framework-4-Formatting-9c4dae8d), an application that enables you to apply format strings to either numeric or date and time values and displays the result string.  
  
<a name="table"></a> The following table describes the standard numeric format specifiers and displays sample output produced by each format specifier. See the [Notes](#NotesStandardFormatting) section for additional information about using standard numeric format strings, and the [Example](#example) section for a comprehensive illustration of their use.  
  
|Format specifier|Name|Description|Examples|  
|----------------------|----------|-----------------|--------------|  
|"C" or "c"|Currency|Result: A currency value.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: Defined by <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A?displayProperty=nameWithType>.<br /><br /> More information: [The Currency ("C") Format Specifier](#CFormatString).|123.456 ("C", en-US) -> $123.46<br /><br /> 123.456 ("C", fr-FR) -> 123,46 €<br /><br /> 123.456 ("C", ja-JP) -> ¥123<br /><br /> -123.456 ("C3", en-US) -> ($123.456)<br /><br /> -123.456 ("C3", fr-FR) -> -123,456 €<br /><br /> -123.456 ("C3", ja-JP) -> -¥123.456|  
|"D" or "d"|Decimal|Result: Integer digits with optional negative sign.<br /><br /> Supported by: Integral types only.<br /><br /> Precision specifier: Minimum number of digits.<br /><br /> Default precision specifier: Minimum number of digits required.<br /><br /> More information: [The Decimal("D") Format Specifier](#DFormatString).|1234 ("D") -> 1234<br /><br /> -1234 ("D6") -> -001234|  
|"E" or "e"|Exponential (scientific)|Result: Exponential notation.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: 6.<br /><br /> More information: [The Exponential ("E") Format Specifier](#EFormatString).|1052.0329112756 ("E", en-US) -> 1.052033E+003<br /><br /> 1052.0329112756 ("e", fr-FR) -> 1,052033e+003<br /><br /> -1052.0329112756 ("e2", en-US) -> -1.05e+003<br /><br /> -1052.0329112756 ("E2", fr_FR) -> -1,05E+003|  
|"F" or "f"|Fixed-point|Result: Integral and decimal digits with optional negative sign.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of decimal digits.<br /><br /> Default precision specifier: Defined by <xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A?displayProperty=nameWithType>.<br /><br /> More information: [The Fixed-Point ("F") Format Specifier](#FFormatString).|1234.567 ("F", en-US) -> 1234.57<br /><br /> 1234.567 ("F", de-DE) -> 1234,57<br /><br /> 1234 ("F1", en-US) -> 1234.0<br /><br /> 1234 ("F1", de-DE) -> 1234,0<br /><br /> -1234.56 ("F4", en-US) -> -1234.5600<br /><br /> -1234.56 ("F4", de-DE) -> -1234,5600|  
|"G" or "g"|General|Result: The more compact of either fixed-point or scientific notation.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Number of significant digits.<br /><br /> Default precision specifier: Depends on numeric type.<br /><br /> More information: [The General ("G") Format Specifier](#GFormatString).|-123.456 ("G", en-US) -> -123.456<br /><br /> -123.456 ("G", sv-SE) -> -123,456<br /><br /> 123.4546 ("G4", en-US) -> 123.5<br /><br /> 123.4546 ("G4", sv-SE) -> 123,5<br /><br /> -1.234567890e-25 ("G", en-US) -> -1.23456789E-25<br /><br /> -1.234567890e-25 ("G", sv-SE) -> -1,23456789E-25|  
|"N" or "n"|Number|Result: Integral and decimal digits, group separators, and a decimal separator with optional negative sign.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Desired number of decimal places.<br /><br /> Default precision specifier: Defined by <xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A?displayProperty=nameWithType>.<br /><br /> More information: [The Numeric ("N") Format Specifier](#NFormatString).|1234.567 ("N", en-US) -> 1,234.57<br /><br /> 1234.567 ("N", ru-RU) -> 1 234,57<br /><br /> 1234 ("N1", en-US) -> 1,234.0<br /><br /> 1234 ("N1", ru-RU) -> 1 234,0<br /><br /> -1234.56 ("N3", en-US) -> -1,234.560<br /><br /> -1234.56 ("N3", ru-RU) -> -1 234,560|  
|"P" or "p"|Percent|Result: Number multiplied by 100 and displayed with a percent symbol.<br /><br /> Supported by: All numeric types.<br /><br /> Precision specifier: Desired number of decimal places.<br /><br /> Default precision specifier: Defined by  <xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits%2A?displayProperty=nameWithType>.<br /><br /> More information: [The Percent ("P") Format Specifier](#PFormatString).|1 ("P", en-US) -> 100.00 %<br /><br /> 1 ("P", fr-FR) -> 100,00 %<br /><br /> -0.39678 ("P1", en-US) -> -39.7 %<br /><br /> -0.39678 ("P1", fr-FR) -> -39,7 %|  
|"R" or "r"|Round-trip|Result: A string that can round-trip to an identical number.<br /><br /> Supported by: <xref:System.Single>, <xref:System.Double>, and <xref:System.Numerics.BigInteger>.<br /><br /> Note: Recommended for the <xref:System.Numerics.BigInteger> type only. For <xref:System.Double> types, use "G17"; for <xref:System.Single> types, use "G9". </br> Precision specifier: Ignored.<br /><br /> More information: [The Round-trip ("R") Format Specifier](#RFormatString).|123456789.12345678 ("R") -> 123456789.12345678<br /><br /> -1234567890.12345678 ("R") -> -1234567890.1234567|  
|"X" or "x"|Hexadecimal|Result: A hexadecimal string.<br /><br /> Supported by: Integral types only.<br /><br /> Precision specifier: Number of digits in the result string.<br /><br /> More information: [The HexaDecimal ("X") Format Specifier](#XFormatString).|255 ("X") -> FF<br /><br /> -1 ("x") -> ff<br /><br /> 255 ("x4") -> 00ff<br /><br /> -1 ("X4") -> 00FF|  
|Any other single character|Unknown specifier|Result: Throws a <xref:System.FormatException> at run time.||  
  
<a name="Using"></a>   
## Using Standard Numeric Format Strings  
 A standard numeric format string can be used to define the formatting of a numeric value in one of two ways:  
  
-   It can be passed to an overload of the `ToString` method that has a `format` parameter. The following example formats a numeric value as a currency string in the current culture (in this case, the en-US culture).  
  
     [!code-cpp[Formatting.Numeric.Standard#10](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/standardusage1.cpp#10)]
     [!code-csharp[Formatting.Numeric.Standard#10](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/standardusage1.cs#10)]
     [!code-vb[Formatting.Numeric.Standard#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/standardusage1.vb#10)]  
  
-   It can be supplied as the `formatString` argument in a format item used with such methods as <xref:System.String.Format%2A?displayProperty=nameWithType>, <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, and <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>. For more information, see [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md). The following example uses a format item to insert a currency value in a string.  
  
     [!code-cpp[Formatting.Numeric.Standard#11](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/standardusage1.cpp#11)]
     [!code-csharp[Formatting.Numeric.Standard#11](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/standardusage1.cs#11)]
     [!code-vb[Formatting.Numeric.Standard#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/standardusage1.vb#11)]  
  
     Optionally, you can supply an `alignment` argument to specify the width of the numeric field and whether its value is right- or left-aligned. The following example left-aligns a currency value in a 28-character field, and it right-aligns a currency value in a 14-character field.  
  
     [!code-cpp[Formatting.Numeric.Standard#12](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/standardusage1.cpp#12)]
     [!code-csharp[Formatting.Numeric.Standard#12](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/standardusage1.cs#12)]
     [!code-vb[Formatting.Numeric.Standard#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/standardusage1.vb#12)]  
  
-   It can be supplied as the `formatString` argument in an interpolated expression item of an interpolated string. For more information, see the [String interpolation](../../csharp/language-reference/tokens/interpolated.md) topic in the C# reference or the [Interpolated strings](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md) topic in the Visual Basic reference.  
  
 The following sections provide detailed information about each of the standard numeric format strings.  
  
<a name="CFormatString"></a>   
## The Currency ("C") Format Specifier  
 The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The precision specifier indicates the desired number of decimal places in the result string. If the precision specifier is omitted, the default precision is defined by the <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A?displayProperty=nameWithType> property.  
  
 If the value to be formatted has more than the specified or default number of decimal places, the fractional value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or greater, the last digit in the result string is rounded away from zero.  
  
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the returned string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyPositivePattern%2A>|Defines the placement of the currency symbol for positive values.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern%2A>|Defines the placement of the currency symbol for negative values, and specifies whether the negative sign is represented by parentheses or the <xref:System.Globalization.NumberFormatInfo.NegativeSign%2A> property.|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the negative sign used if <xref:System.Globalization.NumberFormatInfo.CurrencyNegativePattern%2A> indicates that parentheses are not used.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencySymbol%2A>|Defines the currency symbol.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A>|Defines the default number of decimal digits in a currency value. This value can be overridden by using the precision specifier.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator%2A>|Defines the string that separates integral and decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator%2A>|Defines the string that separates groups of integral numbers.|  
|<xref:System.Globalization.NumberFormatInfo.CurrencyGroupSizes%2A>|Defines the number of integer digits that appear in a group.|  
  
 The following example formats a <xref:System.Double> value with the currency format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#1](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#1)]
 [!code-csharp[Formatting.Numeric.Standard#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#1)]
 [!code-vb[Formatting.Numeric.Standard#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#1)]  
  
 [Back to table](#table)  
  
<a name="DFormatString"></a>   
## The Decimal ("D") Format Specifier  
 The "D" (or decimal) format specifier converts a number to a string of decimal digits (0-9), prefixed by a minus sign if the number is negative. This format is supported only for integral types.  
  
 The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier. If no precision specifier is specified, the default is the minimum value required to represent the integer without leading zeros.  
  
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. As the following table shows, a single property affects the formatting of the result string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
  
 The following example formats an <xref:System.Int32> value with the decimal format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#2](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#2)]
 [!code-csharp[Formatting.Numeric.Standard#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#2)]
 [!code-vb[Formatting.Numeric.Standard#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#2)]  
  
 [Back to table](#table)  
  
<a name="EFormatString"></a>   
## The Exponential ("E") Format Specifier  
 The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd", where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one digit always precedes the decimal point.  
  
 The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, a default of six digits after the decimal point is used.  
  
 The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet this minimum, if required.  
  
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the returned string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative for both the coefficient and exponent.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>|Defines the string that separates the integral digit from decimal digits in the coefficient.|  
|<xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>|Defines the string that indicates that an exponent is positive.|  
  
 The following example formats a <xref:System.Double> value with the exponential format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#3](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#3)]
 [!code-csharp[Formatting.Numeric.Standard#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#3)]
 [!code-vb[Formatting.Numeric.Standard#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#3)]  
  
 [Back to table](#table)  
  
<a name="FFormatString"></a>   
## The Fixed-Point ("F") Format Specifier  
 The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative.  
  
 The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the current <xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A?displayProperty=nameWithType> property supplies the numeric precision.  
  
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the properties of the <xref:System.Globalization.NumberFormatInfo> object that control the formatting of the result string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>|Defines the string that separates integral digits from decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A>|Defines the default number of decimal digits. This value can be overridden by using the precision specifier.|  
  
 The following example formats a <xref:System.Double> and an <xref:System.Int32> value with the fixed-point format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#4](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#4)]
 [!code-csharp[Formatting.Numeric.Standard#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#4)]
 [!code-vb[Formatting.Numeric.Standard#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#4)]  
  
 [Back to table](#table)  
  
<a name="GFormatString"></a>   
## The General ("G") Format Specifier  
 The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific notation, depending on the type of the number and whether a precision specifier is present. The precision specifier defines the maximum number of significant digits that can appear in the result string. If the precision specifier is omitted or zero, the type of the number determines the default precision, as indicated in the following table.  
  
|Numeric type|Default precision|  
|------------------|-----------------------|  
|<xref:System.Byte> or <xref:System.SByte>|3 digits|  
|<xref:System.Int16> or <xref:System.UInt16>|5 digits|  
|<xref:System.Int32> or <xref:System.UInt32>|10 digits|  
|<xref:System.Int64>|19 digits|  
|<xref:System.UInt64>|20 digits|  
|<xref:System.Numerics.BigInteger>|Unlimited (same as ["R"](#RFormatString))|  
|<xref:System.Single>|7 digits|  
|<xref:System.Double>|15 digits|  
|<xref:System.Decimal>|29 digits|  
  
 Fixed-point notation is used if the exponent that would result from expressing the number in scientific notation is greater than -5 and less than the precision specifier; otherwise, scientific notation is used. The result contains a decimal point if required, and trailing zeros after the decimal point are omitted. If the precision specifier is present and the number of significant digits in the result exceeds the specified precision, the excess trailing digits are removed by rounding.  
  
 However, if the number is a <xref:System.Decimal> and the precision specifier is omitted, fixed-point notation is always used and trailing zeros are preserved.  
  
 If scientific notation is used, the exponent in the result is prefixed with "E" if the format specifier is "G", or "e" if the format specifier is "g". The exponent contains a minimum of two digits. This differs from the format for scientific notation that is produced by the exponential format specifier, which includes a minimum of three digits in the exponent.  
 
Note that, when used with a <xref:System.Double> value, the "G17" format specifier ensures that the original <xref:System.Double> value successfully round-trips. This is because <xref:System.Double> is an IEEE 754-2008-compliant double-precision (`binary64`) floating point number that gives up to 17 significant digits of precision. We recommend its use instead of the ["R" format specifier](#RFormatString), since in some cases "R" fails to successfully round-trip double-precision floating point values. The following example illustrates one such case.

[!code-csharp[Round-tripping a Double](../../../samples/snippets/standard/base-types/format-strings/csharp/g17.cs)]   
[!code-vb[Round-tripping a Double](../../../samples/snippets/standard/base-types/format-strings/vb/g17.vb)]   

When used with a <xref:System.Single> value, the "G9" format specifier ensures that the original <xref:System.Single> value successfully round-trips. This is because <xref:System.Single> is an IEEE 754-2008-compliant single-precision (`binary32`) floating point number that gives up to nine significant digits of precision. We recommend its use instead of the ["R" format specifier](#RFormatString), since in some cases "R" fails to successfully round-trip single-precision floating point values.

 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the result string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>|Defines the string that separates integral digits from decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>|Defines the string that indicates that an exponent is positive.|  
  
 The following example formats assorted floating-point values with the general format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#5](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#5)]
 [!code-csharp[Formatting.Numeric.Standard#5](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#5)]
 [!code-vb[Formatting.Numeric.Standard#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#5)]  
  
 [Back to table](#table)  
  
<a name="NFormatString"></a>   
## The Numeric ("N") Format Specifier  
 The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "." indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier is omitted, the number of decimal places is defined by the current <xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A?displayProperty=nameWithType> property.  
  
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the result string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
|<xref:System.Globalization.NumberFormatInfo.NumberNegativePattern%2A>|Defines the format of negative values, and specifies whether the negative sign is represented by parentheses or the <xref:System.Globalization.NumberFormatInfo.NegativeSign%2A> property.|  
|<xref:System.Globalization.NumberFormatInfo.NumberGroupSizes%2A>|Defines the number of integral digits that appear between group separators.|  
|<xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator%2A>|Defines the string that separates groups of integral numbers.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>|Defines the string that separates integral and decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalDigits%2A>|Defines the default number of decimal digits. This value can be overridden by using a precision specifier.|  
  
 The following example formats assorted floating-point values with the number format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#6](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#6)]
 [!code-csharp[Formatting.Numeric.Standard#6](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#6)]
 [!code-vb[Formatting.Numeric.Standard#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#6)]  
  
 [Back to table](#table)  
  
<a name="PFormatString"></a>   
## The Percent ("P") Format Specifier  
 The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the default numeric precision supplied by the current <xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits%2A> property is used.  
  
 The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the returned string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.PercentPositivePattern%2A>|Defines the placement of the percent symbol for positive values.|  
|<xref:System.Globalization.NumberFormatInfo.PercentNegativePattern%2A>|Defines the placement of the percent symbol and the negative symbol for negative values.|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
|<xref:System.Globalization.NumberFormatInfo.PercentSymbol%2A>|Defines the percent symbol.|  
|<xref:System.Globalization.NumberFormatInfo.PercentDecimalDigits%2A>|Defines the default number of decimal digits in a percentage value. This value can be overridden by using the precision specifier.|  
|<xref:System.Globalization.NumberFormatInfo.PercentDecimalSeparator%2A>|Defines the string that separates integral and decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.PercentGroupSeparator%2A>|Defines the string that separates groups of integral numbers.|  
|<xref:System.Globalization.NumberFormatInfo.PercentGroupSizes%2A>|Defines the number of integer digits that appear in a group.|  
  
 The following example formats floating-point values with the percent format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#7](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#7)]
 [!code-csharp[Formatting.Numeric.Standard#7](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#7)]
 [!code-vb[Formatting.Numeric.Standard#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#7)]  
  
 [Back to table](#table)  
  
<a name="RFormatString"></a>   
## The Round-trip ("R") Format Specifier  
 The round-trip ("R") format specifier attempts to ensure that a numeric value that is converted to a string is parsed back into the same numeric value. This format is supported only for the <xref:System.Single>, <xref:System.Double>, and <xref:System.Numerics.BigInteger> types.  

For <xref:System.Double> and <xref:System.Single> values, the "R" format specifier in some cases fails to successfully round-trip the original value and also offers relatively poor performance. Instead, we recommend that you use the ["G17"](#GFormatString) format specifier for <xref:System.Double> values and the ["G9"](#GFormatString) format specifier to successfully round-trip <xref:System.Single> values.

 When a <xref:System.Numerics.BigInteger> value is formatted using this specifier, its string representation contains all the significant digits in the <xref:System.Numerics.BigInteger> value.  
  
 Although you can include a precision specifier, it is ignored. Round trips are given precedence over precision when using this specifier.    
 The result string is affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object. The following table lists the <xref:System.Globalization.NumberFormatInfo> properties that control the formatting of the result string.  
  
|NumberFormatInfo property|Description|  
|-------------------------------|-----------------|  
|<xref:System.Globalization.NumberFormatInfo.NegativeSign%2A>|Defines the string that indicates that a number is negative.|  
|<xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A>|Defines the string that separates integral digits from decimal digits.|  
|<xref:System.Globalization.NumberFormatInfo.PositiveSign%2A>|Defines the string that indicates that an exponent is positive.|  
  
 The following example formats a <xref:System.Numerics.BigInteger> value with the round-trip format specifier.  
  
 [!code-cpp[R format specifier with a BigInteger](../../../samples/snippets/standard/base-types/format-strings/biginteger-r.cpp)]
 [!code-csharp[R format specifier with a BigInteger](../../../samples/snippets/standard/base-types/format-strings/biginteger-r.cs)]
 [!code-vb[R format specifier with a BigInteger](../../../samples/snippets/standard/base-types/format-strings/biginteger-r.vb)]  
  
> [!IMPORTANT]
>  In some cases, <xref:System.Double> values formatted with the "R" standard numeric format string do not successfully round-trip if compiled using the `/platform:x64` or `/platform:anycpu` switches and run on 64-bit systems. See the following paragraph for more information.  
  
 To work around the problem of <xref:System.Double> values formatted with the "R" standard numeric format string not successfully round-tripping if compiled using the `/platform:x64` or `/platform:anycpu` switches and run on 64-bit systems., you can format <xref:System.Double> values by using the "G17" standard numeric format string. The following example uses the "R" format string with a <xref:System.Double> value that does not round-trip successfully, and also uses the "G17" format string to successfully round-trip the original value.  
  
 [!code-csharp[System.Double.ToString#5](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.Double.ToString/cs/roundtripex1.cs#5)]
 [!code-vb[System.Double.ToString#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Double.ToString/vb/roundtripex1.vb#5)]  
  
 [Back to table](#table)  
  
<a name="XFormatString"></a>   
## The Hexadecimal ("X") Format Specifier  
 The hexadecimal ("X") format specifier converts a number to a string of hexadecimal digits. The case of the format specifier indicates whether to use uppercase or lowercase characters for hexadecimal digits that are greater than 9. For example, use "X" to produce "ABCDEF", and "x" to produce "abcdef". This format is supported only for integral types.  
  
 The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier.  
  
 The result string is not affected by the formatting information of the current <xref:System.Globalization.NumberFormatInfo> object.  
  
 The following example formats <xref:System.Int32> values with the hexadecimal format specifier.  
  
 [!code-cpp[Formatting.Numeric.Standard#9](../../../samples/snippets/cpp/VS_Snippets_CLR/Formatting.Numeric.Standard/cpp/Standard.cpp#9)]
 [!code-csharp[Formatting.Numeric.Standard#9](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Numeric.Standard/cs/Standard.cs#9)]
 [!code-vb[Formatting.Numeric.Standard#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Numeric.Standard/vb/Standard.vb#9)]  
  
 [Back to table](#table)  
  
<a name="NotesStandardFormatting"></a>   
## Notes  
  
### Control Panel Settings  
 The settings in the **Regional and Language Options** item in Control Panel influence the result string produced by a formatting operation. Those settings are used to initialize the <xref:System.Globalization.NumberFormatInfo> object associated with the current thread culture, which provides values used to govern formatting. Computers that use different settings generate different result strings.  
  
 In addition, if the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%29?displayProperty=nameWithType> constructor is used to instantiate a new <xref:System.Globalization.CultureInfo> object that represents the same culture as the current system culture, any customizations established by the **Regional and Language Options** item in Control Panel will be applied to the new <xref:System.Globalization.CultureInfo> object. You can use the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor to create a <xref:System.Globalization.CultureInfo> object that does not reflect a system's customizations.  
  
### NumberFormatInfo Properties  
 Formatting is influenced by the properties of the current <xref:System.Globalization.NumberFormatInfo> object, which is provided implicitly by the current thread culture or explicitly by the <xref:System.IFormatProvider> parameter of the method that invokes formatting. Specify a <xref:System.Globalization.NumberFormatInfo> or <xref:System.Globalization.CultureInfo> object for that parameter.  
  
> [!NOTE]
>  For information about customizing the patterns or strings used in formatting numeric values, see the <xref:System.Globalization.NumberFormatInfo> class topic.  
  
### Integral and Floating-Point Numeric Types  
 Some descriptions of standard numeric format specifiers refer to integral or floating-point numeric types. The integral numeric types are <xref:System.Byte>, <xref:System.SByte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>, and <xref:System.Numerics.BigInteger>. The floating-point numeric types are <xref:System.Decimal>, <xref:System.Single>, and <xref:System.Double>.  
  
### Floating-Point Infinities and NaN  
 Regardless of the format string, if the value of a <xref:System.Single> or <xref:System.Double> floating-point type is positive infinity, negative infinity, or not a number (NaN), the formatted string is the value of the respective <xref:System.Globalization.NumberFormatInfo.PositiveInfinitySymbol%2A>, <xref:System.Globalization.NumberFormatInfo.NegativeInfinitySymbol%2A>, or <xref:System.Globalization.NumberFormatInfo.NaNSymbol%2A> property that is specified by the currently applicable <xref:System.Globalization.NumberFormatInfo> object.  
  
<a name="example"></a>   
## Example  
 The following example formats an integral and a floating-point numeric value using the en-US culture and all the standard numeric format specifiers. This example uses two particular numeric types (<xref:System.Double> and <xref:System.Int32>), but would yield similar results for any of the other numeric base types (<xref:System.Byte>, <xref:System.SByte>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>, <xref:System.Numerics.BigInteger>, <xref:System.Decimal>, and <xref:System.Single>).  
  
 [!code-csharp[system.x.tostring-and-culture#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.X.ToString-and-Culture/cs/xts.cs#1)]
 [!code-vb[system.x.tostring-and-culture#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.X.ToString-and-Culture/vb/xts.vb#1)]  
  
## See Also  
 <xref:System.Globalization.NumberFormatInfo>  
 [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md)  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 [How to: Pad a Number with Leading Zeros](../../../docs/standard/base-types/how-to-pad-a-number-with-leading-zeros.md)  
 [Sample: .NET Framework 4 Formatting Utility](https://code.msdn.microsoft.com/NET-Framework-4-Formatting-9c4dae8d)  
 [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md)
