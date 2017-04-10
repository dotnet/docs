---
title: "Changing Case in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "strings [.NET Framework], case"
  - "case sensitivity"
  - "ToUpper method"
  - "ToLower method"
  - "uppercase"
  - "lowercase"
ms.assetid: 6805f81b-e9ad-4387-9f4c-b9bdb21b87c0
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Changing Case in .NET
If you write an application that accepts input from a user, you can never be sure what case he or she will use to enter the data. Often, you want strings to be cased consistently, particularly if you are displaying them in the user interface. The following table describes three case-changing methods. The first two methods provide an overload that accepts a culture.  
  
|Method name|Use|  
|-----------------|---------|  
|<xref:System.String.ToUpper%2A?displayProperty=fullName>|Converts all characters in a string to uppercase.|  
|<xref:System.String.ToLower%2A?displayProperty=fullName>|Converts all characters in a string to lowercase.|  
|<xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=fullName>|Converts a string to title case.|  
  
> [!WARNING]
>  Note that the <xref:System.String.ToUpper%2A?displayProperty=fullName> and <xref:System.String.ToLower%2A?displayProperty=fullName> methods should not be used to convert strings in order to compare them or test them for equality. For more information, see the [Comparing strings of mixed case](#Comparing) section.  
  
<a name="Comparing"></a>   
## Comparing strings of mixed case  
 To compare strings of mixed case to determine their ordering, call one of the overloads of the <xref:System.String.CompareTo%2A?displayProperty=fullName> method with a `comparisonType` parameter, and provide a value of either <xref:System.StringComparison?displayProperty=fullName>, <xref:System.StringComparison?displayProperty=fullName>, or <xref:System.StringComparison?displayProperty=fullName> for the `comparisonType` argument. For a comparison using a specific culture other than the current culture, call an overload of the <xref:System.String.CompareTo%2A?displayProperty=fullName> method with both a `culture` and `options` parameter, and provide a value of <xref:System.Globalization.CompareOptions?displayProperty=fullName> as the `options` argument.  
  
 To compare strings of mixed case to determine whether they are equal, their, call one of the overloads of the <xref:System.String.Equals%2A?displayProperty=fullName> method with a `comparisonType` parameter, and provide a value of either <xref:System.StringComparison?displayProperty=fullName>, <xref:System.StringComparison?displayProperty=fullName>, or <xref:System.StringComparison?displayProperty=fullName> for the `comparisonType` argument.  
  
 For more information, see [Best Practices for Using Strings](../../../docs/standard/base-types/best-practices-strings.md).  
  
## ToUpper  
 The <xref:System.String.ToUpper%2A?displayProperty=fullName> method changes all characters in a string to uppercase. The following example converts the string "Hello World!" from mixed case to uppercase.  
  
 [!code-csharp[Strings.ChangingCase#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.ChangingCase/cs/Example.cs#1)]
 [!code-vb[Strings.ChangingCase#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.ChangingCase/vb/Example.vb#1)]  
  
 The preceding example is culture-sensitive by default; it applies the casing conventions of the current culture. To perform a culture-insensitive case change or to apply the casing conventions of a particular culture, use the <xref:System.String.ToUpper%28System.Globalization.CultureInfo%29?displayProperty=fullName> method overload and supply a value of <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=fullName> or a <xref:System.Globalization.CultureInfo?displayProperty=fullName> object that represents the specified culture to the *culture* parameter. For an example that demonstrates how to use the <xref:System.String.ToUpper%2A> method to perform a culture-insensitive case change, see [Performing Culture-Insensitive Case Changes](../../../docs/standard/globalization-localization/performing-culture-insensitive-case-changes.md).  
  
## ToLower  
 The <xref:System.String.ToLower%2A?displayProperty=fullName> method is similar to the previous method, but instead converts all the characters in a string to lowercase. The following example converts the string "Hello World!" to lowercase.  
  
 [!code-csharp[Strings.ChangingCase#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.ChangingCase/cs/Example.cs#2)]
 [!code-vb[Strings.ChangingCase#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.ChangingCase/vb/Example.vb#2)]  
  
 The preceding example is culture-sensitive by default; it applies the casing conventions of the current culture. To perform a culture-insensitive case change or to apply the casing conventions of a particular culture, use the <xref:System.String.ToLower%28System.Globalization.CultureInfo%29?displayProperty=fullName> method overload and supply a value of <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=fullName> or a <xref:System.Globalization.CultureInfo?displayProperty=fullName> object that represents the specified culture to the *culture* parameter. For an example that demonstrates how to use the <xref:System.String.ToLower%28System.Globalization.CultureInfo%29> method to perform a culture-insensitive case change, see [Performing Culture-Insensitive Case Changes](../../../docs/standard/globalization-localization/performing-culture-insensitive-case-changes.md).  
  
## ToTitleCase  
 The <xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=fullName> converts the first character of each word to uppercase and the remaining characters to lowercase. However, words that are entirely uppercase are assumed to be acronyms and are not converted.  
  
 The <xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=fullName> method is culture-sensitive; that is, it uses the casing conventions of a particular culture. In order to call the method, you first retrieve the <xref:System.Globalization.TextInfo> object that represents the casing conventions of the particular culture from the <xref:System.Globalization.CultureInfo.TextInfo%2A?displayProperty=fullName> property of a particular culture.  
  
 The following example passes each string in an array to the <xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=fullName> method.  The strings include proper title strings as well as acronyms. The strings are converted to title case by using the casing conventions of the English (United States) culture.  
  
 [!code-csharp[System.Globalization.TextInfo.ToTitleCase#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.globalization.textinfo.totitlecase/cs/totitlecase2.cs#1)]
 [!code-vb[System.Globalization.TextInfo.ToTitleCase#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.globalization.textinfo.totitlecase/vb/totitlecase2.vb#1)]  
  
 Note that although it is culture-sensitive, the <xref:System.Globalization.TextInfo.ToTitleCase%2A?displayProperty=fullName> method does not provide linguistically correct casing rules. For instance, in the previous example, the method converts "a tale of two cities" to "A Tale Of Two Cities". However, the linguistically correct title casing for the en-US culture is "A Tale of Two Cities."  
  
## See Also  
 [Basic String Operations](../../../docs/standard/base-types/basic-string-operations.md)   
 [Performing Culture-Insensitive String Operations](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-operations.md)