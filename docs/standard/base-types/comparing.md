---
title: "Comparing Strings in .NET"
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
  - "value comparisons of strings"
  - "LastIndexOf method"
  - "CompareTo method"
  - "IndexOf method"
  - "Compare method"
  - "strings [.NET Framework], comparing"
  - "CompareOrdinal method"
  - "EndsWith method"
  - "Equals method"
  - "StartsWith method"
ms.assetid: 977dc094-fe19-4955-98ec-d2294d04a4ba
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Comparing Strings in .NET
.NET provides several methods to compare the values of strings. The following table lists and describes the value-comparison methods.  
  
|Method name|Use|  
|-----------------|---------|  
|<xref:System.String.Compare%2A?displayProperty=nameWithType>|Compares the values of two strings. Returns an integer value.|  
|<xref:System.String.CompareOrdinal%2A?displayProperty=nameWithType>|Compares two strings without regard to local culture. Returns an integer value.|  
|<xref:System.String.CompareTo%2A?displayProperty=nameWithType>|Compares the current string object to another string. Returns an integer value.|  
|<xref:System.String.StartsWith%2A?displayProperty=nameWithType>|Determines whether a string begins with the string passed. Returns a Boolean value.|  
|<xref:System.String.EndsWith%2A?displayProperty=nameWithType>|Determines whether a string ends with the string passed. Returns a Boolean value.|  
|<xref:System.String.Equals%2A?displayProperty=nameWithType>|Determines whether two strings are the same. Returns a Boolean value.|  
|<xref:System.String.IndexOf%2A?displayProperty=nameWithType>|Returns the index position of a character or string, starting from the beginning of the string you are examining. Returns an integer value.|  
|<xref:System.String.LastIndexOf%2A?displayProperty=nameWithType>|Returns the index position of a character or string, starting from the end of the string you are examining. Returns an integer value.|  
  
## Compare  
 The static <xref:System.String.Compare%2A?displayProperty=nameWithType> method provides a thorough way of comparing two strings. This method is culturally aware. You can use this function to compare two strings or substrings of two strings. Additionally, overloads are provided that regard or disregard case and cultural variance. The following table shows the three integer values that this method might return.  
  
|Return value|Condition|  
|------------------|---------------|  
|A negative integer|The first string precedes the second string in the sort order.<br /><br /> -or-<br /><br /> The first string is `null`.|  
|0|The first string and the second string are equal.<br /><br /> -or-<br /><br /> Both strings are `null`.|  
|A positive integer<br /><br /> -or-<br /><br /> 1|The first string follows the second string in the sort order.<br /><br /> -or-<br /><br /> The second string is `null`.|  
  
> [!IMPORTANT]
>  The <xref:System.String.Compare%2A?displayProperty=nameWithType> method is primarily intended for use when ordering or sorting strings. You should not use the <xref:System.String.Compare%2A?displayProperty=nameWithType> method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the <xref:System.String.Equals%28System.String%2CSystem.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method.  
  
 The following example uses the <xref:System.String.Compare%2A?displayProperty=nameWithType> method to determine the relative values of two strings.  
  
 [!code-cpp[Conceptual.String.BasicOps#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#6)]
 [!code-csharp[Conceptual.String.BasicOps#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#6)]
 [!code-vb[Conceptual.String.BasicOps#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#6)]  
  
 This example displays `-1` to the console.  
  
 The preceding example is culture-sensitive by default. To perform a culture-insensitive string comparison, use an overload of the <xref:System.String.Compare%2A?displayProperty=nameWithType> method that allows you to specify the culture to use by supplying a *culture* parameter. For an example that demonstrates how to use the <xref:System.String.Compare%2A?displayProperty=nameWithType> method to perform a culture-insensitive comparison, see [Performing Culture-Insensitive String Comparisons](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-comparisons.md).  
  
## CompareOrdinal  
 The <xref:System.String.CompareOrdinal%2A?displayProperty=nameWithType> method compares two string objects without considering the local culture. The return values of this method are identical to the values returned by the **Compare** method in the previous table.  
  
> [!IMPORTANT]
>  The <xref:System.String.CompareOrdinal%2A?displayProperty=nameWithType> method is primarily intended for use when ordering or sorting strings. You should not use the <xref:System.String.CompareOrdinal%2A?displayProperty=nameWithType> method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the <xref:System.String.Equals%28System.String%2CSystem.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method.  
  
 The following example uses the **CompareOrdinal** method to compare the values of two strings.  
  
 [!code-cpp[Conceptual.String.BasicOps#7](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#7)]
 [!code-csharp[Conceptual.String.BasicOps#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#7)]
 [!code-vb[Conceptual.String.BasicOps#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#7)]  
  
 This example displays `-32` to the console.  
  
## CompareTo  
 The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method compares the string that the current string object encapsulates to another string or object. The return values of this method are identical to the values returned by the <xref:System.String.Compare%2A?displayProperty=nameWithType> method in the previous table.  
  
> [!IMPORTANT]
>  The <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method is primarily intended for use when ordering or sorting strings. You should not use the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the <xref:System.String.Equals%28System.String%2CSystem.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method.  
  
 The following example uses the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method to compare the `string1` object to the `string2` object.  
  
 [!code-cpp[Conceptual.String.BasicOps#8](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#8)]
 [!code-csharp[Conceptual.String.BasicOps#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#8)]
 [!code-vb[Conceptual.String.BasicOps#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#8)]  
  
 This example displays `-1` to the console.  
  
 All overloads of the <xref:System.String.CompareTo%2A?displayProperty=nameWithType> method perform culture-sensitive and case-sensitive comparisons by default. No overloads of this method are provided that allow you to perform a culture-insensitive comparison. For code clarity, we recommend that you use the **String.Compare** method instead, specifying <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> for culture-sensitive operations or <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> for culture-insensitive operations. For examples that demonstrate how to use the **String.Compare** method to perform both culture-sensitive and culture-insensitive comparisons, see [Performing Culture-Insensitive String Comparisons](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-comparisons.md).  
  
## Equals  
 The **String.Equals** method can easily determine if two strings are the same. This case-sensitive method returns a **true** or **false** Boolean value. It can be used from an existing class, as illustrated in the next example. The following example uses the **Equals** method to determine whether a string object contains the phrase "Hello World".  
  
 [!code-cpp[Conceptual.String.BasicOps#9](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#9)]
 [!code-csharp[Conceptual.String.BasicOps#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#9)]
 [!code-vb[Conceptual.String.BasicOps#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#9)]  
  
 This example displays `True` to the console.  
  
 This method can also be used as a static method. The following example compares two string objects using a static method.  
  
 [!code-cpp[Conceptual.String.BasicOps#10](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#10)]
 [!code-csharp[Conceptual.String.BasicOps#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#10)]
 [!code-vb[Conceptual.String.BasicOps#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#10)]  
  
 This example displays `True` to the console.  
  
## StartsWith and EndsWith  
 You can use the **String.StartsWith** method to determine whether a string object begins with the same characters that encompass another string. This case-sensitive method returns **true** if the current string object begins with the passed string and **false** if it does not. The following example uses this method to determine if a string object begins with "Hello".  
  
 [!code-cpp[Conceptual.String.BasicOps#11](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#11)]
 [!code-csharp[Conceptual.String.BasicOps#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#11)]
 [!code-vb[Conceptual.String.BasicOps#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#11)]  
  
 This example displays `True` to the console.  
  
 The **String.EndsWith** method compares a passed string to the characters that exist at the end of the current string object. It also returns a Boolean value. The following example checks the end of a string using the **EndsWith** method.  
  
 [!code-cpp[Conceptual.String.BasicOps#12](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#12)]
 [!code-csharp[Conceptual.String.BasicOps#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#12)]
 [!code-vb[Conceptual.String.BasicOps#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#12)]  
  
 This example displays `False` to the console.  
  
## IndexOf and LastIndexOf  
 You can use the **String.IndexOf** method to determine the position of the first occurrence of a particular character within a string. This case-sensitive method starts counting from the beginning of a string and returns the position of a passed character using a zero-based index. If the character cannot be found, a value of –1 is returned.  
  
 The following example uses the **IndexOf** method to search for the first occurrence of the '`l`' character in a string.  
  
 [!code-cpp[Conceptual.String.BasicOps#13](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#13)]
 [!code-csharp[Conceptual.String.BasicOps#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#13)]
 [!code-vb[Conceptual.String.BasicOps#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#13)]  
  
 This example displays `2` to the console.  
  
 The **String.LastIndexOf** method is similar to the **String.IndexOf** method except that it returns the position of the last occurrence of a particular character within a string. It is case-sensitive and uses a zero-based index.  
  
 The following example uses the **LastIndexOf** method to search for the last occurrence of the '`l`' character in a string.  
  
 [!code-cpp[Conceptual.String.BasicOps#14](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/compare.cpp#14)]
 [!code-csharp[Conceptual.String.BasicOps#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/compare.cs#14)]
 [!code-vb[Conceptual.String.BasicOps#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/compare.vb#14)]  
  
 This example displays `9` to the console.  
  
 Both methods are useful when used in conjunction with the **String.Remove** method. You can use either the **IndexOf** or **LastIndexOf** methods to retrieve the position of a character, and then supply that position to the **Remove** method in order to remove a character or a word that begins with that character.  
  
## See Also  
 [Basic String Operations](../../../docs/standard/base-types/basic-string-operations.md)  
 [Performing Culture-Insensitive String Operations](../../../docs/standard/globalization-localization/performing-culture-insensitive-string-operations.md)
