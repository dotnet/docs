---
title: "Parsing Numeric Strings in .NET"
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
  - "parsing strings, numeric strings"
  - "numeric strings"
  - "enumerations [.NET Framework], parsing strings"
  - "base types, parsing strings"
ms.assetid: e39324ee-72e5-42d4-a80d-bf3ee7fc6c59
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Parsing Numeric Strings in NET
All numeric types have two static parsing methods, `Parse` and `TryParse`, that you can use to convert the string representation of a number into a numeric type. These methods enable you to parse strings that were produced by using the format strings documented in [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md). By default, the `Parse` and `TryParse` methods can successfully convert strings that contain integral decimal digits only to integer values. They can successfully convert strings that contain integral and fractional decimal digits, group separators, and a decimal separator to floating-point values. The `Parse` method throws an exception if the operation fails, whereas the `TryParse` method returns `false`.  
  
## Parsing and Format Providers  
 Typically, the string representations of numeric values differ by culture. Elements of numeric strings such as currency symbols, group (or thousands) separators, and decimal separators all vary by culture. Parsing methods either implicitly or explicitly use a format provider that recognizes these culture-specific variations. If no format provider is specified in a call to the `Parse` or `TryParse` method, the format provider associated with the current thread culture (the <xref:System.Globalization.NumberFormatInfo> object returned by the <xref:System.Globalization.NumberFormatInfo.CurrentInfo%2A?displayProperty=nameWithType> property) is used.  
  
 A format provider is represented by an <xref:System.IFormatProvider> implementation. This interface has a single member, the <xref:System.IFormatProvider.GetFormat%2A> method, whose single parameter is a <xref:System.Type> object that represents the type to be formatted. This method returns the object that provides formatting information. .NET supports the following two <xref:System.IFormatProvider> implementations for parsing numeric strings:  
  
-   A <xref:System.Globalization.CultureInfo> object whose <xref:System.Globalization.CultureInfo.GetFormat%2A?displayProperty=nameWithType> method returns a <xref:System.Globalization.NumberFormatInfo> object that provides culture-specific formatting information.  
  
-   A <xref:System.Globalization.NumberFormatInfo> object whose <xref:System.Globalization.NumberFormatInfo.GetFormat%2A?displayProperty=nameWithType> method returns itself.  
  
 The following example tries to convert each string in an array to a <xref:System.Double> value. It first tries to parse the string by using a format provider that reflects the conventions of the English (United States) culture. If this operation throws a <xref:System.FormatException>, it tries to parse the string by using a format provider that reflects the conventions of the French (France) culture.  
  
 [!code-csharp[Parsing.Numbers#1](../../../samples/snippets/csharp/VS_Snippets_CLR/parsing.numbers/cs/formatproviders1.cs#1)]
 [!code-vb[Parsing.Numbers#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/parsing.numbers/vb/formatproviders1.vb#1)]  
  
## Parsing and NumberStyles Values  
 The style elements (such as white space, group separators, and decimal separator) that the parse operation can handle are defined by a <xref:System.Globalization.NumberStyles> enumeration value. By default, strings that represent integer values are parsed by using the <xref:System.Globalization.NumberStyles.Integer?displayProperty=nameWithType> value, which permits only numeric digits, leading and trailing white space, and a leading sign. Strings that represent floating-point values are parsed using a combination of the <xref:System.Globalization.NumberStyles.Float?displayProperty=nameWithType> and <xref:System.Globalization.NumberStyles.AllowThousands?displayProperty=nameWithType> values; this composite style permits decimal digits along with leading and trailing white space, a leading sign, a decimal separator, a group separator, and an exponent. By calling an overload of the `Parse` or `TryParse` method that includes a parameter of type <xref:System.Globalization.NumberStyles> and setting one or more <xref:System.Globalization.NumberStyles> flags, you can control the style elements that can be present in the string for the parse operation to succeed.  
  
 For example, a string that contains a group separator cannot be converted to an <xref:System.Int32> value by using the <xref:System.Int32.Parse%28System.String%29?displayProperty=nameWithType> method. However, the conversion succeeds if you use the <xref:System.Globalization.NumberStyles.AllowThousands?displayProperty=nameWithType> flag, as the following example illustrates.  
  
 [!code-csharp[Parsing.Numbers#2](../../../samples/snippets/csharp/VS_Snippets_CLR/parsing.numbers/cs/styles1.cs#2)]
 [!code-vb[Parsing.Numbers#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/parsing.numbers/vb/styles1.vb#2)]  
  
> [!WARNING]
>  The parse operation always uses the formatting conventions of a particular culture. If you do not specify a culture by passing a <xref:System.Globalization.CultureInfo> or <xref:System.Globalization.NumberFormatInfo> object, the culture associated with the current thread is used.  
  
 The following table lists the members of the <xref:System.Globalization.NumberStyles> enumeration and describes the effect that they have on the parsing operation.  
  
|NumberStyles value|Effect on the string to be parsed|  
|------------------------|---------------------------------------|  
|<xref:System.Globalization.NumberStyles.None?displayProperty=nameWithType>|Only numeric digits are permitted.|  
|<xref:System.Globalization.NumberStyles.AllowDecimalPoint?displayProperty=nameWithType>|The decimal separator and fractional digits are permitted. For integer values, only zero is permitted as a fractional digit. Valid decimal separators are determined by the <xref:System.Globalization.NumberFormatInfo.NumberDecimalSeparator%2A?displayProperty=nameWithType> or <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator%2A?displayProperty=nameWithType> property.|  
|<xref:System.Globalization.NumberStyles.AllowExponent?displayProperty=nameWithType>|The "e" or "E" character can be used to indicate exponential notation. See <xref:System.Globalization.NumberStyles> for additional information.|  
|<xref:System.Globalization.NumberStyles.AllowLeadingWhite?displayProperty=nameWithType>|Leading white space is permitted.|  
|<xref:System.Globalization.NumberStyles.AllowTrailingWhite?displayProperty=nameWithType>|Trailing white space is permitted.|  
|<xref:System.Globalization.NumberStyles.AllowLeadingSign?displayProperty=nameWithType>|A positive or negative sign can precede numeric digits.|  
|<xref:System.Globalization.NumberStyles.AllowTrailingSign?displayProperty=nameWithType>|A positive or negative sign can follow numeric digits.|  
|<xref:System.Globalization.NumberStyles.AllowParentheses?displayProperty=nameWithType>|Parentheses can be used to indicate negative values.|  
|<xref:System.Globalization.NumberStyles.AllowThousands?displayProperty=nameWithType>|The group separator is permitted. The group separator character is determined by the <xref:System.Globalization.NumberFormatInfo.NumberGroupSeparator%2A?displayProperty=nameWithType> or <xref:System.Globalization.NumberFormatInfo.CurrencyGroupSeparator%2A?displayProperty=nameWithType> property.|  
|<xref:System.Globalization.NumberStyles.AllowCurrencySymbol?displayProperty=nameWithType>|The currency symbol is permitted. The currency symbol is defined by the <xref:System.Globalization.NumberFormatInfo.CurrencySymbol%2A?displayProperty=nameWithType> property.|  
|<xref:System.Globalization.NumberStyles.AllowHexSpecifier?displayProperty=nameWithType>|The string to be parsed is interpreted as a hexadecimal number. It can include the hexadecimal digits 0-9, A-F, and a-f. This flag can be used only to parse integer values.|  
  
 In addition, the <xref:System.Globalization.NumberStyles> enumeration provides the following composite styles, which include multiple <xref:System.Globalization.NumberStyles> flags.  
  
|Composite NumberStyles value|Includes members|  
|----------------------------------|----------------------|  
|<xref:System.Globalization.NumberStyles.Integer?displayProperty=nameWithType>|Includes the <xref:System.Globalization.NumberStyles.AllowLeadingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowTrailingWhite?displayProperty=nameWithType>, and <xref:System.Globalization.NumberStyles.AllowLeadingSign?displayProperty=nameWithType> styles. This is the default style used to parse integer values.|  
|<xref:System.Globalization.NumberStyles.Number?displayProperty=nameWithType>|Includes the <xref:System.Globalization.NumberStyles.AllowLeadingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowTrailingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowLeadingSign?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowTrailingSign?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowDecimalPoint?displayProperty=nameWithType>, and <xref:System.Globalization.NumberStyles.AllowThousands?displayProperty=nameWithType> styles.|  
|<xref:System.Globalization.NumberStyles.Float?displayProperty=nameWithType>|Includes the <xref:System.Globalization.NumberStyles.AllowLeadingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowTrailingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowLeadingSign?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowDecimalPoint?displayProperty=nameWithType>, and <xref:System.Globalization.NumberStyles.AllowExponent?displayProperty=nameWithType> styles.|  
|<xref:System.Globalization.NumberStyles.Currency?displayProperty=nameWithType>|Includes all styles except <xref:System.Globalization.NumberStyles.AllowExponent?displayProperty=nameWithType> and <xref:System.Globalization.NumberStyles.AllowHexSpecifier?displayProperty=nameWithType>.|  
|<xref:System.Globalization.NumberStyles.Any?displayProperty=nameWithType>|Includes all styles except <xref:System.Globalization.NumberStyles.AllowHexSpecifier?displayProperty=nameWithType>.|  
|<xref:System.Globalization.NumberStyles.HexNumber?displayProperty=nameWithType>|Includes the <xref:System.Globalization.NumberStyles.AllowLeadingWhite?displayProperty=nameWithType>, <xref:System.Globalization.NumberStyles.AllowTrailingWhite?displayProperty=nameWithType>, and <xref:System.Globalization.NumberStyles.AllowHexSpecifier?displayProperty=nameWithType> styles.|  
  
## Parsing and Unicode Digits  
 The Unicode standard defines code points for digits in various writing systems. For example, code points from U+0030 to U+0039 represent the basic Latin digits 0 through 9, code points from U+09E6 to U+09EF represent the Bangla digits 0 through 9, and code points from U+FF10 to U+FF19 represent the Fullwidth digits 0 through 9. However, the only numeric digits recognized by parsing methods are the basic Latin digits 0-9 with code points from U+0030 to U+0039. If a numeric parsing method is passed a string that contains any other digits, the method throws a <xref:System.FormatException>.  
  
 The following example uses the <xref:System.Int32.Parse%2A?displayProperty=nameWithType> method to parse strings that consist of digits in different writing systems. As the output from the example shows, the attempt to parse the basic Latin digits succeeds, but the attempt to parse the Fullwidth, Arabic-Indic, and Bangla digits fails.  
  
 [!code-csharp[Parsing.Numbers#3](../../../samples/snippets/csharp/VS_Snippets_CLR/parsing.numbers/cs/unicode1.cs#3)]
 [!code-vb[Parsing.Numbers#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/parsing.numbers/vb/unicode1.vb#3)]  
  
## See Also  
 <xref:System.Globalization.NumberStyles>  
 [Parsing Strings](../../../docs/standard/base-types/parsing-strings.md)  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)
