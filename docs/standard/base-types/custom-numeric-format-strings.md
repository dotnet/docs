---
title: "Custom Numeric Format Strings"
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
  - "cpp"
helpviewer_keywords: 
  - "numeric format strings [.NET Framework]"
  - "formatting [.NET Framework], numbers"
  - "format strings"
  - "custom numeric format strings"
  - "numbers [.NET Framework], formatting"
  - "format specifiers, numeric"
  - "formatting numbers [.NET Framework]"
  - "format specifiers, custom numeric format strings"
ms.assetid: 6f74fd32-6c6b-48ed-8241-3c2b86dea5f4
caps.latest.revision: 54
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Custom Numeric Format Strings
You can create a custom numeric format string, which consists of one or more custom numeric specifiers, to define how to format numeric data. A custom numeric format string is any format string that is not a [standard numeric format string](../../../docs/standard/base-types/standard-numeric-format-strings.md).  
  
 Custom numeric format strings are supported by some overloads of the `ToString` method of all numeric types. For example, you can supply a numeric format string to the <xref:System.Int32.ToString%28System.String%29> and <xref:System.Int32.ToString%28System.String%2CSystem.IFormatProvider%29> methods of the <xref:System.Int32> type. Custom numeric format strings are also supported by the .NET [composite formatting feature](../../../docs/standard/base-types/composite-formatting.md), which is used by some `Write` and `WriteLine` methods of the <xref:System.Console> and <xref:System.IO.StreamWriter> classes, the <xref:System.String.Format%2A?displayProperty=nameWithType> method, and the <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType> method. [String interpolation](../../csharp/language-reference/tokens/interpolated.md) feature also supports custom numeric format strings.  
  
> [!TIP]
>  You can download the [Formatting Utility](https://code.msdn.microsoft.com/NET-Framework-4-Formatting-9c4dae8d), an application that enables you to apply format strings to either numeric or date and time values and displays the result string.  
  
<a name="table"></a> The following table describes the custom numeric format specifiers and displays sample output produced by each format specifier. See the [Notes](#NotesCustomFormatting) section for additional information about using custom numeric format strings, and the [Example](#example) section for a comprehensive illustration of their use.  
  
|Format specifier|Name|Description|Examples|  
|----------------------|----------|-----------------|--------------|  
|"0"|Zero placeholder|Replaces the zero with the corresponding digit if one is present; otherwise, zero appears in the result string.<br /><br /> More information: [The "0" Custom Specifier](#Specifier0).|1234.5678 ("00000") -> 01235<br /><br /> 0.45678 ("0.00", en-US) -> 0.46<br /><br /> 0.45678 ("0.00", fr-FR) -> 0,46|  
|"#"|Digit placeholder|Replaces the "#" symbol with the corresponding digit if one is present; otherwise, no digit appears in the result string.<br /><br /> Note that no digit appears in the result string if the corresponding digit in the input string is a non-significant 0. For example, 0003 ("####") -> 3.<br /><br /> More information: [The "#" Custom Specifier](#SpecifierD).|1234.5678 ("#####") -> 1235<br /><br /> 0.45678 ("#.##", en-US) -> .46<br /><br /> 0.45678 ("#.##", fr-FR) -> ,46|  
|"."|Decimal point|Determines the location of the decimal separator in the result string.<br /><br /> More information: [The "." Custom Specifier](#SpecifierPt).|0.45678 ("0.00", en-US) -> 0.46<br /><br /> 0.45678 ("0.00", fr-FR) -> 0,46|  
|","|Group separator and number scaling|Serves as both a group separator and a number scaling specifier. As a group separator, it inserts a localized group separator character between each group. As a number scaling specifier, it divides a number by 1000 for each comma specified.<br /><br /> More information: [The "," Custom Specifier](#SpecifierTh).|Group separator specifier:<br /><br /> 2147483647 ("##,#", en-US) -> 2,147,483,647<br /><br /> 2147483647 ("##,#", es-ES) -> 2.147.483.647<br /><br /> Scaling specifier:<br /><br /> 2147483647 ("#,#,,", en-US) -> 2,147<br /><br /> 2147483647 ("#,#,,", es-ES) -> 2.147|  
|"%"|Percentage placeholder|Multiplies a number by 100 and inserts a localized percentage symbol in the result string.<br /><br /> More information: [The "%" Custom Specifier](#SpecifierPct).|0.3697 ("%#0.00", en-US) -> %36.97<br /><br /> 0.3697 ("%#0.00", el-GR) -> %36,97<br /><br /> 0.3697 ("##.0 %", en-US) -> 37.0 %<br /><br /> 0.3697 ("##.0 %", el-GR) -> 37,0 %|  
|"‰"|Per mille placeholder|Multiplies a number by 1000 and inserts a localized per mille symbol in the result string.<br /><br /> More information: [The "‰" Custom Specifier](#SpecifierPerMille).|0.03697 ("#0.00‰", en-US) -> 36.97‰<br /><br /> 0.03697 ("#0.00‰", ru-RU) -> 36,97‰|  
|"E0"<br /><br /> "E+0"<br /><br /> "E-0"<br /><br /> "e0"<br /><br /> "e+0"<br /><br /> "e-0"|Exponential notation|If followed by at least one 0 (zero), formats the result using exponential notation. The case of "E" or "e" indicates the case of the exponent symbol in the result string. The number of zeros following the "E" or "e" character determines the minimum number of digits in the exponent. A plus sign (+) indicates that a sign character always precedes the exponent. A minus sign (-) indicates that a sign character precedes only negative exponents.<br /><br /> More information: [The "E" and "e" Custom Specifiers](#SpecifierExponent).|987654 ("#0.0e0") -> 98.8e4<br /><br /> 1503.92311 ("0.0##e+00") -> 1.504e+03<br /><br /> 1.8901385E-16 ("0.0e+00") -> 1.9e-16|  
|"\\"|Escape character|Causes the next character to be interpreted as a literal rather than as a custom format specifier.<br /><br /> More information: [The "\\" Escape Character](#SpecifierEscape).|987654 ("\\###00\\#") -> #987654#|  
|'*string*'<br /><br /> "*string*"|Literal string delimiter|Indicates that the enclosed characters should be copied to the result string unchanged.|68 ("# ' degrees'") -> 68  degrees<br /><br /> 68 ("#' degrees'") -> 68 degrees|  
|;|Section separator|Defines sections with separate format strings for positive, negative, and zero numbers.<br /><br /> More information: [The ";" Section Separator](#SectionSeparator).|12.345 ("#0.0#;(#0.0#);-\0-") -> 12.35<br /><br /> 0 ("#0.0#;(#0.0#);-\0-") -> -0-<br /><br /> -12.345 ("#0.0#;(#0.0#);-\0-") -> (12.35)<br /><br /> 12.345 ("#0.0#;(#0.0#)") -> 12.35<br /><br /> 0 ("#0.0#;(#0.0#)") -> 0.0<br /><br /> -12.345 ("#0.0#;(#0.0#)") -> (12.35)|  
|Other|All other characters|The character is copied to the result string unchanged.|68 ("# °") -> 68 °|  
  
 The following sections provide detailed information about each of the custom numeric format specifiers.  
  
<a name="Specifier0"></a>   
## The "0" Custom Specifier  
 The "0" custom format specifier serves as a zero-placeholder symbol. If the value that is being formatted has a digit in the position where the zero appears in the format string, that digit is copied to the result string; otherwise, a zero appears in the result string. The position of the leftmost zero before the decimal point and the rightmost zero after the decimal point determines the range of digits that are always present in the result string.  
  
 The "00" specifier causes the value to be rounded to the nearest digit preceding the decimal, where rounding away from zero is always used. For example, formatting 34.5 with "00" would result in the value 35.  
  
 The following example displays several values that are formatted by using custom format strings that include zero placeholders.  
  
 [!code-cpp[Formatting.Numeric.Custom#1](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#1)]
 [!code-csharp[Formatting.Numeric.Custom#1](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#1)]
 [!code-vb[Formatting.Numeric.Custom#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#1)]  
  
 [Back to table](#table)  
  
<a name="SpecifierD"></a>   
## The "#" Custom Specifier  
 The "#" custom format specifier serves as a digit-placeholder symbol. If the value that is being formatted has a digit in the position where the "#" symbol appears in the format string, that digit is copied to the result string. Otherwise, nothing is stored in that position in the result string.  
  
 Note that this specifier never displays a zero that is not a significant digit, even if zero is the only digit in the string. It will display zero only if it is a significant digit in the number that is being displayed.  
  
 The "##" format string causes the value to be rounded to the nearest digit preceding the decimal, where rounding away from zero is always used. For example, formatting 34.5 with "##" would result in the value 35.  
  
 The following example displays several values that are formatted by using custom format strings that include digit placeholders.  
  
 [!code-cpp[Formatting.Numeric.Custom#2](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#2)]
 [!code-csharp[Formatting.Numeric.Custom#2](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#2)]
 [!code-vb[Formatting.Numeric.Custom#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#2)]  
  
 To return a result string in which absent digits or leading zeroes are replaced by spaces, use the [composite formatting feature](../../../docs/standard/base-types/composite-formatting.md) and specify a field width, as the following example illustrates.  
  
 [!code-cpp[Formatting.Numeric.Custom#12](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/SpaceOrDigit1.cpp#12)]
 [!code-csharp[Formatting.Numeric.Custom#12](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/SpaceOrDigit1.cs#12)]
 [!code-vb[Formatting.Numeric.Custom#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/SpaceOrDigit1.vb#12)]  
  
 [Back to table](#table)  
  
<a name="SpecifierPt"></a>   
## The "." Custom Specifier  
 The "." custom format specifier inserts a localized decimal separator into the result string. The first period in the format string determines the location of the decimal separator in the formatted value; any additional periods are ignored.  
  
 The character that is used as the decimal separator in the result string is not always a period; it is determined by the <xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A> property of the <xref:System.Globalization.NumberFormatInfo> object that controls formatting.  
  
 The following example uses the "." format specifier to define the location of the decimal point in several result strings.  
  
 [!code-cpp[Formatting.Numeric.Custom#3](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#3)]
 [!code-csharp[Formatting.Numeric.Custom#3](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#3)]
 [!code-vb[Formatting.Numeric.Custom#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#3)]  
  
 [Back to table](#table)  
  
<a name="SpecifierTh"></a>   
## The "," Custom Specifier  
 The "," character serves as both a group separator and a number scaling specifier.  
  
-   Group separator: If one or more commas are specified between two digit placeholders (0 or #) that format the integral digits of a number, a group separator character is inserted between each number group in the integral part of the output.  
  
     The <xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator%2A> and <xref:System.Globalization.NumberFormatInfo.NumberGroupSizes%2A> properties of the current <xref:System.Globalization.NumberFormatInfo> object determine the character used as the number group separator and the size of each number group. For example, if the string "#,#" and the invariant culture are used to format the number 1000, the output is "1,000".  
  
-   Number scaling specifier: If one or more commas are specified immediately to the left of the explicit or implicit decimal point, the number to be formatted is divided by 1000 for each comma. For example, if the string "0,," is used to format the number 100 million, the output is "100".  
  
 You can use group separator and number scaling specifiers in the same format string. For example, if the string "#,0,," and the invariant culture are used to format the number one billion, the output is "1,000".  
  
 The following example illustrates the use of the comma as a group separator.  
  
 [!code-cpp[Formatting.Numeric.Custom#4](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#4)]
 [!code-csharp[Formatting.Numeric.Custom#4](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#4)]
 [!code-vb[Formatting.Numeric.Custom#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#4)]  
  
 The following example illustrates the use of the comma as a specifier for number scaling.  
  
 [!code-cpp[Formatting.Numeric.Custom#5](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#5)]
 [!code-csharp[Formatting.Numeric.Custom#5](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#5)]
 [!code-vb[Formatting.Numeric.Custom#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#5)]  
  
 [Back to table](#table)  
  
<a name="SpecifierPct"></a>   
## The "%" Custom Specifier  
 A percent sign (%) in a format string causes a number to be multiplied by 100 before it is formatted. The localized percent symbol is inserted in the number at the location where the % appears in the format string. The percent character used is defined by the <xref:System.Globalization.NumberFormatInfo.PercentSymbol%2A> property of the current <xref:System.Globalization.NumberFormatInfo> object.  
  
 The following example defines several custom format strings that include the "%" custom specifier.  
  
 [!code-cpp[Formatting.Numeric.Custom#6](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#6)]
 [!code-csharp[Formatting.Numeric.Custom#6](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#6)]
 [!code-vb[Formatting.Numeric.Custom#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#6)]  
  
 [Back to table](#table)  
  
<a name="SpecifierPerMille"></a>   
## The "‰" Custom Specifier  
 A per mille character (‰ or \u2030) in a format string causes a number to be multiplied by 1000 before it is formatted. The appropriate per mille symbol is inserted in the returned string at the location where the ‰ symbol appears in the format string. The per mille character used is defined by the <xref:System.Globalization.NumberFormatInfo.PerMilleSymbol%2A?displayProperty=nameWithType> property of the object that provides culture-specific formatting information.  
  
 The following example defines a custom format string that includes the "‰" custom specifier.  
  
 [!code-cpp[Formatting.Numeric.Custom#9](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#9)]
 [!code-csharp[Formatting.Numeric.Custom#9](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#9)]
 [!code-vb[Formatting.Numeric.Custom#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#9)]  
  
 [Back to table](#table)  
  
<a name="SpecifierExponent"></a>   
## The "E" and "e" Custom Specifiers  
 If any of the strings "E", "E+", "E-", "e", "e+", or "e-" are present in the format string and are followed immediately by at least one zero, the number is formatted by using scientific notation with an "E" or "e" inserted between the number and the exponent. The number of zeros following the scientific notation indicator determines the minimum number of digits to output for the exponent. The "E+" and "e+" formats indicate that a plus sign or minus sign should always precede the exponent. The "E", "E-", "e", or "e-" formats indicate that a sign character should precede only negative exponents.  
  
 The following example formats several numeric values using the specifiers for scientific notation.  
  
 [!code-cpp[Formatting.Numeric.Custom#7](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#7)]
 [!code-csharp[Formatting.Numeric.Custom#7](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#7)]
 [!code-vb[Formatting.Numeric.Custom#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#7)]  
  
 [Back to table](#table)  
  
<a name="SpecifierEscape"></a>   
## The "\\" Escape Character  
 The "#", "0", ".", ",", "%", and "‰" symbols in a format string are interpreted as format specifiers rather than as literal characters. Depending on their position in a custom format string, the uppercase and lowercase "E" as well as the + and - symbols may also be interpreted as format specifiers.  
  
 To prevent a character from being interpreted as a format specifier, you can precede it with a backslash, which is the escape character. The escape character signifies that the following character is a character literal that should be included in the result string unchanged.  
  
 To include a backslash in a result string, you must escape it with another backslash (`\\`).  
  
> [!NOTE]
>  Some compilers, such as the C++ and C# compilers, may also interpret a single backslash character as an escape character. To ensure that a string is interpreted correctly when formatting, you can use the verbatim string literal character (the @ character) before the string in C#, or add another backslash character before each backslash in C# and C++. The following C# example illustrates both approaches.  
  
 The following example uses the escape character to prevent the formatting operation from interpreting the "#", "0", and "\\" characters as either escape characters or format specifiers. The C# examples uses an additional backslash to ensure that a backslash is interpreted as a literal character.  
  
 [!code-cpp[Formatting.Numeric.Custom#11](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/escape1.cpp#11)]
 [!code-csharp[Formatting.Numeric.Custom#11](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/escape1.cs#11)]
 [!code-vb[Formatting.Numeric.Custom#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/escape1.vb#11)]  
  
 [Back to table](#table)  
  
<a name="SectionSeparator"></a>   
## The ";" Section Separator  
 The semicolon (;) is a conditional format specifier that applies different formatting to a number depending on whether its value is positive, negative, or zero. To produce this behavior, a custom format string can contain up to three sections separated by semicolons. These sections are described in the following table.  
  
|Number of sections|Description|  
|------------------------|-----------------|  
|One section|The format string applies to all values.|  
|Two sections|The first section applies to positive values and zeros, and the second section applies to negative values.<br /><br /> If the number to be formatted is negative, but becomes zero after rounding according to the format in the second section, the resulting zero is formatted according to the first section.|  
|Three sections|The first section applies to positive values, the second section applies to negative values, and the third section applies to zeros.<br /><br /> The second section can be left empty (by having nothing between the semicolons), in which case the first section applies to all nonzero values.<br /><br /> If the number to be formatted is nonzero, but becomes zero after rounding according to the format in the first or second section, the resulting zero is formatted according to the third section.|  
  
 Section separators ignore any preexisting formatting associated with a number when the final value is formatted. For example, negative values are always displayed without a minus sign when section separators are used. If you want the final formatted value to have a minus sign, you should explicitly include the minus sign as part of the custom format specifier.  
  
 The following example uses the ";" format specifier to format positive, negative, and zero numbers differently.  
  
 [!code-cpp[Formatting.Numeric.Custom#8](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/custom.cpp#8)]
 [!code-csharp[Formatting.Numeric.Custom#8](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/custom.cs#8)]
 [!code-vb[Formatting.Numeric.Custom#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/Custom.vb#8)]  
  
 [Back to table](#table)  
  
<a name="NotesCustomFormatting"></a>   
## Notes  
  
### Floating-Point Infinities and NaN  
 Regardless of the format string, if the value of a <xref:System.Single> or <xref:System.Double> floating-point type is positive infinity, negative infinity, or not a number (NaN), the formatted string is the value of the respective <xref:System.Globalization.NumberFormatInfo.PositiveInfinitySymbol%2A>, <xref:System.Globalization.NumberFormatInfo.NegativeInfinitySymbol%2A>, or <xref:System.Globalization.NumberFormatInfo.NaNSymbol%2A> property specified by the currently applicable <xref:System.Globalization.NumberFormatInfo> object.  
  
### Control Panel Settings  
 The settings in the **Regional and Language Options** item in Control Panel influence the result string produced by a formatting operation. Those settings are used to initialize the <xref:System.Globalization.NumberFormatInfo> object associated with the current thread culture, and the current thread culture provides values used to govern formatting. Computers that use different settings generate different result strings.  
  
 In addition, if you use the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%29?displayProperty=nameWithType> constructor to instantiate a new <xref:System.Globalization.CultureInfo> object that represents the same culture as the current system culture, any customizations established by the **Regional and Language Options** item in Control Panel will be applied to the new <xref:System.Globalization.CultureInfo> object. You can use the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor to create a <xref:System.Globalization.CultureInfo> object that does not reflect a system's customizations.  
  
### Rounding and Fixed-Point Format Strings  
 For fixed-point format strings (that is, format strings that do not contain scientific notation format characters), numbers are rounded to as many decimal places as there are digit placeholders to the right of the decimal point. If the format string does not contain a decimal point, the number is rounded to the nearest integer. If the number has more digits than there are digit placeholders to the left of the decimal point, the extra digits are copied to the result string immediately before the first digit placeholder.  
  
 [Back to table](#table)  
  
<a name="example"></a>   
## Example  
 The following example demonstrates two custom numeric format strings. In both cases, the digit placeholder (`#`) displays the numeric data, and all other characters are copied to the result string.  
  
 [!code-cpp[Formatting.Numeric.Custom#10](../../../samples/snippets/cpp/VS_Snippets_CLR/formatting.numeric.custom/cpp/example1.cpp#10)]
 [!code-csharp[Formatting.Numeric.Custom#10](../../../samples/snippets/csharp/VS_Snippets_CLR/formatting.numeric.custom/cs/example1.cs#10)]
 [!code-vb[Formatting.Numeric.Custom#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/formatting.numeric.custom/vb/example1.vb#10)]  
  
 [Back to table](#table)  
  
## See Also  
 <xref:System.Globalization.NumberFormatInfo>  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md)  
 [How to: Pad a Number with Leading Zeros](../../../docs/standard/base-types/how-to-pad-a-number-with-leading-zeros.md)  
 [Sample: .NET Framework 4 Formatting Utility](https://code.msdn.microsoft.com/NET-Framework-4-Formatting-9c4dae8d)
