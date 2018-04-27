---
title: ".NET Framework Regular Expressions"
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
  - "pattern-matching with regular expressions, about pattern-matching"
  - "substrings"
  - "searching with regular expressions, about regular expressions"
  - "pattern-matching with regular expressions"
  - "searching with regular expressions"
  - "parsing text with regular expressions"
  - "regular expressions [.NET Framework], about regular expressions"
  - "regular expressions [.NET Framework]"
  - ".NET Framework regular expressions, about"
  - "characters [.NET Framework], regular expressions"
  - "parsing text with regular expressions, overview"
  - ".NET Framework regular expressions"
  - "strings [.NET Framework], regular expressions"
ms.assetid: 521b3f6d-f869-42e1-93e5-158c54a6895d
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# .NET Regular Expressions
Regular expressions provide a powerful, flexible, and efficient method for processing text. The extensive pattern-matching notation of regular expressions enables you to quickly parse large amounts of text to find specific character patterns; to validate text to ensure that it matches a predefined pattern (such as an email address); to extract, edit, replace, or delete text substrings; and to add the extracted strings to a collection in order to generate a report. For many applications that deal with strings or that parse large blocks of text, regular expressions are an indispensable tool.  
  
## How Regular Expressions Work  
 The centerpiece of text processing with regular expressions is the regular expression engine, which is represented by the <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> object in .NET. At a minimum, processing text using regular expressions requires that the regular expression engine be provided with the following two items of information:  
  
-   The regular expression pattern to identify in the text.  
  
     In .NET, regular expression patterns are defined by a special syntax or language, which is compatible with Perl 5 regular expressions and adds some additional features such as right-to-left matching. For more information, see [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md).  
  
-   The text to parse for the regular expression pattern.  
  
 The methods of the <xref:System.Text.RegularExpressions.Regex> class let you perform the following operations:  
  
-   Determine whether the regular expression pattern occurs in the input text by calling the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method. For an example that uses the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A> method for validating text, see [How to: Verify that Strings Are in Valid Email Format](../../../docs/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format.md).  
  
-   Retrieve one or all occurrences of text that matches the regular expression pattern by calling the <xref:System.Text.RegularExpressions.Regex.Match%2A?displayProperty=nameWithType> or <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method. The former method returns a <xref:System.Text.RegularExpressions.Match?displayProperty=nameWithType> object that provides information about the matching text. The latter returns a <xref:System.Text.RegularExpressions.MatchCollection> object that contains one <xref:System.Text.RegularExpressions.Match?displayProperty=nameWithType> object for each match found in the parsed text.  
  
-   Replace text that matches the regular expression pattern by calling the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method. For examples that use the <xref:System.Text.RegularExpressions.Regex.Replace%2A> method to change date formats and remove invalid characters from a string, see [How to: Strip Invalid Characters from a String](../../../docs/standard/base-types/how-to-strip-invalid-characters-from-a-string.md) and [Example: Changing Date Formats](../../../docs/standard/base-types/regular-expression-example-changing-date-formats.md).  
  
 For an overview of the regular expression object model, see [The Regular Expression Object Model](../../../docs/standard/base-types/the-regular-expression-object-model.md).  
  
 For more information about the regular expression language, see [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md) or download and print one of these brochures:  
  
 [Quick Reference in Word (.docx) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)  
 [Quick Reference in PDF (.pdf) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)  
  
## Regular Expression Examples  
 The <xref:System.String> class includes a number of string search and replacement methods that you can use when you want to locate literal strings in a larger string. Regular expressions are most useful either when you want to locate one of several substrings in a larger string, or when you want to identify patterns in a string, as the following examples illustrate.  
  
### Example 1: Replacing Substrings  
 Assume that a mailing list contains names that sometimes include a title (Mr., Mrs., Miss, or Ms.) along with a first and last name. If you do not want to include the titles when you generate envelope labels from the list, you can use a regular expression to remove the titles, as the following example illustrates.  
  
 [!code-csharp[Conceptual.Regex#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex/cs/example1.cs#2)]
 [!code-vb[Conceptual.Regex#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex/vb/example1.vb#2)]  
  
 The regular expression pattern`(Mr\.? |Mrs\.? |Miss |Ms\.? )` matches any occurrence of "Mr ", "Mr. ", "Mrs ", "Mrs. ", "Miss ", "Ms or "Ms. ". The call to the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method replaces the matched string with <xref:System.String.Empty?displayProperty=nameWithType>; in other words, it removes it from the original string.  
  
### Example 2: Identifying Duplicated Words  
 Accidentally duplicating words is a common error that writers make. A regular expression can be used to identify duplicated words, as the following example shows.  
  
 [!code-csharp[Conceptual.Regex#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex/cs/example2.cs#3)]
 [!code-vb[Conceptual.Regex#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex/vb/example2.vb#3)]  
  
 The regular expression pattern `\b(\w+?)\s\1\b` can be interpreted as follows:  
  
|||  
|-|-|  
|`\b`|Start at a word boundary.|  
|(\w+?)|Match one or more word characters, but as few characters as possible. Together, they form a group that can be referred to as `\1`.|  
|`\s`|Match a white-space character.|  
|`\1`|Match the substring that is equal to the group named `\1`.|  
|`\b`|Match a word boundary.|  
  
 The <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method is called with regular expression options set to <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType>. Therefore, the match operation is case-insensitive, and the example identifies the substring "This this" as a duplication.  
  
 Note that the input string includes the substring "this? This". However, because of the intervening punctuation mark, it is not identified as a duplication.  
  
### Example 3: Dynamically Building a Culture-Sensitive Regular Expression  
 The following example illustrates the power of regular expressions combined with the flexibility offered by .NET's globalization features. It uses the <xref:System.Globalization.NumberFormatInfo> object to determine the format of currency values in the system's current culture. It then uses that information to dynamically construct a regular expression that extracts currency values from the text. For each match, it extracts the subgroup that contains the numeric string only, converts it to a <xref:System.Decimal> value, and calculates a running total.  
  
 [!code-csharp[Conceptual.Regex#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex/cs/example.cs#1)]
 [!code-vb[Conceptual.Regex#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex/vb/example.vb#1)]  
  
 On a computer whose current culture is English - United States (en-US), the example dynamically builds the regular expression `\$\s*[-+]?([0-9]{0,3}(,[0-9]{3})*(\.[0-9]+)?)`. This regular expression pattern can be interpreted as follows:  
  
|||  
|-|-|  
|`\$`|Look for a single occurrence of the dollar symbol ($) in the input string. The regular expression pattern string includes a backslash to indicate that the dollar symbol is to be interpreted literally rather than as a regular expression anchor. (The $ symbol alone would indicate that the regular expression engine should try to begin its match at the end of a string.) To ensure that the current culture's currency symbol is not misinterpreted as a regular expression symbol, the example calls the <xref:System.Text.RegularExpressions.Regex.Escape%2A> method to escape the character.|  
|`\s*`|Look for zero or more occurrences of a white-space character.|  
|`[-+]?`|Look for zero or one occurrence of either a positive sign or a negative sign.|  
|`([0-9]{0,3}(,[0-9]{3})*(\.[0-9]+)?)`|The outer parentheses around this expression define it as a capturing group or a subexpression. If a match is found, information about this part of the matching string can be retrieved from the second <xref:System.Text.RegularExpressions.Group> object in the <xref:System.Text.RegularExpressions.GroupCollection> object returned by the <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property. (The first element in the collection represents the entire match.)|  
|`[0-9]{0,3}`|Look for zero to three occurrences of the decimal digits 0 through 9.|  
|`(,[0-9]{3})*`|Look for zero or more occurrences of a group separator followed by three decimal digits.|  
|`\.`|Look for a single occurrence of the decimal separator.|  
|`[0-9]+`|Look for one or more decimal digits.|  
|`(\.[0-9]+)?`|Look for zero or one occurrence of the decimal separator followed by at least one decimal digit.|  
  
 If each of these subpatterns is found in the input string, the match succeeds, and a <xref:System.Text.RegularExpressions.Match> object that contains information about the match is added to the <xref:System.Text.RegularExpressions.MatchCollection> object.  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)|Provides information on the set of characters, operators, and constructs that you can use to define regular expressions.|  
|[The Regular Expression Object Model](../../../docs/standard/base-types/the-regular-expression-object-model.md)|Provides information and code examples that illustrate how to use the regular expression classes.|  
|[Details of Regular Expression Behavior](../../../docs/standard/base-types/details-of-regular-expression-behavior.md)|Provides information about the capabilities and behavior of .NET regular expressions.|  
|[Regular Expression Examples](../../../docs/standard/base-types/regular-expression-examples.md)|Provides code examples that illustrate typical uses of regular expressions.|  
  
## Reference  
 <xref:System.Text.RegularExpressions?displayProperty=nameWithType>  
 <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType>  
 [Regular Expressions - Quick Reference (download in Word format)](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)  
 [Regular Expressions - Quick Reference (download in PDF format)](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)
