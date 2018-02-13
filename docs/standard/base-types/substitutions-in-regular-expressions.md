---
title: "Substitutions in Regular Expressions"
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
  - "regular expressions, substitutions"
  - "replacement patterns"
  - "metacharacters, substitutions"
  - ".NET Framework regular expressions, substitutions"
  - "constructs, substitutions"
  - "substitutions"
ms.assetid: d1f52431-1c7d-4dc6-8792-6b988256892e
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Substitutions in Regular Expressions
<a name="Top"></a> Substitutions are language elements that are recognized only within replacement patterns. They use a regular expression pattern to define all or part of the text that is to replace matched text in the input string. The replacement pattern can consist of one or more substitutions along with literal characters. Replacement patterns are provided to overloads of the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method that have a `replacement` parameter and to the <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method. The methods replace the matched pattern with the pattern that is defined by the `replacement` parameter.  
  
 The .NET Framework defines the substitution elements listed in the following table.  
  
|Substitution|Description|  
|------------------|-----------------|  
|`$` *number*|Includes the last substring matched by the capturing group that is identified by *number*, where *number* is a decimal value, in the replacement string. For more information, see [Substituting a Numbered Group](#Numbered).|  
|`${` *name* `}`|Includes the last substring matched by the named group that is designated by `(?<`*name*`> )` in the replacement string. For more information, see [Substituting a Named Group](#Named).|  
|`$$`|Includes a single "$" literal in the replacement string. For more information, see [Substituting a "$" Symbol](#DollarSign).|  
|`$&`|Includes a copy of the entire match in the replacement string. For more information, see [Substituting the Entire Match](#EntireMatch).|  
|<code>$\`</code>|Includes all the text of the input string before the match in the replacement string. For more information, see [Substituting the Text before the Match](#BeforeMatch).|  
|`$'`|Includes all the text of the input string after the match in the replacement string. For more information, see [Substituting the Text after the Match](#AfterMatch).|  
|`$+`|Includes the last group captured in the replacement string. For more information, see [Substituting the Last Captured Group](#LastGroup).|  
|`$_`|Includes the entire input string in the replacement string. For more information, see [Substituting the Entire Input String](#EntireString).|  
  
## Substitution Elements and Replacement Patterns  
 Substitutions are the only special constructs recognized in a replacement pattern. None of the other regular expression language elements, including character escapes and the period (`.`), which matches any character, are supported. Similarly, substitution language elements are recognized only in replacement patterns and are never valid in regular expression patterns.  
  
 The only character that can appear either in a regular expression pattern or in a substitution is the `$` character, although it has a different meaning in each context. In a regular expression pattern, `$` is an anchor that matches the end of the string. In a replacement pattern, `$` indicates the beginning of a substitution.  
  
> [!NOTE]
>  For functionality similar to a replacement pattern within a regular expression, use a backreference. For more information about backreferences, see [Backreference Constructs](../../../docs/standard/base-types/backreference-constructs-in-regular-expressions.md).  
  
<a name="Numbered"></a>   
## Substituting a Numbered Group  
 The `$`*number* language element includes the last substring matched by the *number* capturing group in the replacement string, where *number* is the index of the capturing group. For example, the replacement pattern `$1` indicates that the matched substring is to be replaced by the first captured group. For more information about numbered capturing groups, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
 All digits that follow `$` are interpreted as belonging to the *number* group. If this is not your intent, you can substitute a named group instead. For example, you can use the replacement string `${1}1` instead of `$11` to define the replacement string as the value of the first captured group along with the number "1". For more information, see [Substituting a Named Group](#Named).  
  
 Capturing groups that are not explicitly assigned names using the `(?<`*name*`>)` syntax are numbered from left to right starting at one. Named groups are also numbered from left to right, starting at one greater than the index of the last unnamed group. For example, in the regular expression `(\w)(?<digit>\d)`, the index of the `digit` named group is 2.  
  
 If *number* does not specify a valid capturing group defined in the regular expression pattern, `$`*number* is interpreted as a literal character sequence that is used to replace each match.  
  
 The following example uses the `$`*number* substitution to strip the currency symbol from a decimal value. It removes currency symbols found at the beginning or end of a monetary value, and recognizes the two most common decimal separators ("." and ",").  
  
 [!code-csharp[Conceptual.RegEx.Language.Substitutions#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/numberedgroup1.cs#1)]
 [!code-vb[Conceptual.RegEx.Language.Substitutions#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/numberedgroup1.vb#1)]  
  
 The regular expression pattern `\p{Sc}*(\s?\d+[.,]?\d*)\p{Sc}*` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\p{Sc}*`|Match zero or more currency symbol characters.|  
|`\s?`|Match zero or one white-space characters.|  
|`\d+`|Match one or more decimal digits.|  
|`[.,]?`|Match zero or one period or comma.|  
|`\d*`|Match zero or more decimal digits.|  
|`(\s?\d+[.,]?\d*)`|Match a white space followed by one or more decimal digits, followed by zero or one period or comma, followed by zero or more decimal digits. This is the first capturing group. Because the replacement pattern is `$1`, the call to the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method replaces the entire matched substring with this captured group.|  
  
 [Back to top](#Top)  
  
<a name="Named"></a>   
## Substituting a Named Group  
 The `${`*name*`}` language element substitutes the last substring matched by the *name* capturing group, where *name* is the name of a capturing group defined by the `(?<`*name*`>)` language element. For more information about named capturing groups, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
 If *name* doesn't specify a valid named capturing group defined in the regular expression pattern but consists of digits, `${`*name*`}` is interpreted as a numbered group.  
  
 If *name* specifies neither a valid named capturing group nor a valid numbered capturing group defined in the regular expression pattern, `${`*name*`}` is interpreted as a literal character sequence that is used to replace each match.  
  
 The following example uses the `${`*name*`}` substitution to strip the currency symbol from a decimal value. It removes currency symbols found at the beginning or end of a monetary value, and recognizes the two most common decimal separators ("." and ",").  
  
 [!code-csharp[Conceptual.RegEx.Language.Substitutions#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/namedgroup1.cs#2)]
 [!code-vb[Conceptual.RegEx.Language.Substitutions#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/namedgroup1.vb#2)]  
  
 The regular expression pattern `\p{Sc}*(?<amount>\s?\d[.,]?\d*)\p{Sc}*` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\p{Sc}*`|Match zero or more currency symbol characters.|  
|`\s?`|Match zero or one white-space characters.|  
|`\d+`|Match one or more decimal digits.|  
|`[.,]?`|Match zero or one period or comma.|  
|`\d*`|Match zero or more decimal digits.|  
|`(?<amount>\s?\d[.,]?\d*)`|Match a white space, followed by one or more decimal digits, followed by zero or one period or comma, followed by zero or more decimal digits. This is the capturing group named `amount`. Because the replacement pattern is `${amount}`, the call to the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method replaces the entire matched substring with this captured group.|  
  
 [Back to top](#Top)  
  
<a name="DollarSign"></a>   
## Substituting a "$" Character  
 The `$$` substitution inserts a literal "$" character in the replaced string.  
  
 The following example uses the <xref:System.Globalization.NumberFormatInfo> object to determine the current culture's currency symbol and its placement in a currency string. It then builds both a regular expression pattern and a replacement pattern dynamically. If the example is run on a computer whose current culture is en-US, it generates the regular expression pattern `\b(\d+)(\.(\d+))?` and the replacement pattern `$$ $1$2`. The replacement pattern replaces the matched text with a currency symbol and a space followed by the first and second captured groups.  
  
 [!code-csharp[Conceptual.Regex.Language.Substitutions#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/dollarsign1.cs#8)]
 [!code-vb[Conceptual.Regex.Language.Substitutions#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/dollarsign1.vb#8)]  
  
 The regular expression pattern `\b(\d+)(\.(\d+))?` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start the match at the beginning of a word boundary.|  
|`(\d+)`|Match one or more decimal digits. This is the first capturing group.|  
|`\.`|Match a period (the decimal separator).|  
|`(\d+)`|Match one or more decimal digits. This is the third capturing group.|  
|`(\.(\d+))?`|Match zero or one occurrence of a period followed by one or more decimal digits. This is the second capturing group.|  
  
<a name="EntireMatch"></a>   
## Substituting the Entire Match  
 The `$&` substitution includes the entire match in the replacement string. Often, it is used to add a substring to the beginning or end of the matched string. For example, the `($&)` replacement pattern adds parentheses to the beginning and end of each match. If there is no match, the `$&` substitution has no effect.  
  
 The following example uses the `$&` substitution to add quotation marks at the beginning and end of book titles stored in a string array.  
  
 [!code-csharp[Conceptual.RegEx.Language.Substitutions#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/entirematch1.cs#3)]
 [!code-vb[Conceptual.RegEx.Language.Substitutions#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/entirematch1.vb#3)]  
  
 The regular expression pattern `^(\w+\s?)+$` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Start the match at the beginning of the input string.|  
|`(\w+\s?)+`|Match the pattern of one or more word characters followed by zero or one white-space characters one or more times.|  
|`$`|Match the end of the input string.|  
  
 The `"$&"` replacement pattern adds a literal quotation mark to the beginning and end of each match.  
  
 [Back to top](#Top)  
  
<a name="BeforeMatch"></a>   
## Substituting the Text Before the Match  
 The <code>$\`</code> substitution replaces the matched string with the entire input string before the match. That is, it duplicates the input string up to the match while removing the matched text. Any text that follows the matched text is unchanged in the result string. If there are multiple matches in an input string, the replacement text is derived from the original input string, rather than from the string in which text has been replaced by earlier matches. \(The example provides an illustration.\) If there is no match, the <code>$\`</code> substitution has no effect.  
  
 The following example uses the regular expression pattern `\d+` to match a sequence of one or more decimal digits in the input string. The replacement string <code>$`</code> replaces these digits with the text that precedes the match.  
  
 [!code-csharp[Conceptual.Regex.Language.Substitutions#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/before1.cs#4)]
 [!code-vb[Conceptual.Regex.Language.Substitutions#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/before1.vb#4)]  
  
 In this example, the input string `"aa1bb2cc3dd4ee5"` contains five matches. The following table illustrates how the <code>$`</code> substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the results column.  
  
|Match|Position|String before match|Result string|  
|-----------|--------------|-------------------------|-------------------|  
|1|2|aa|aa**aa**bb2cc3dd4ee5|  
|2|5|aa1bb|aaaabb**aa1bb**cc3dd4ee5|  
|3|8|aa1bb2cc|aaaabbaa1bbcc**aa1bb2cc**dd4ee5|  
|4|11|aa1bb2cc3dd|aaaabbaa1bbccaa1bb2ccdd**aa1bb2cc3dd**ee5|  
|5|14|aa1bb2cc3dd4ee|aaaabbaa1bbccaa1bb2ccddaa1bb2cc3ddee**aa1bb2cc3dd4ee**|  
  
 [Back to top](#Top)  
  
<a name="AfterMatch"></a>   
## Substituting the Text After the Match  
 The `$'` substitution replaces the matched string with the entire input string after the match. That is, it duplicates the input string after the match while removing the matched text. Any text that precedes the matched text is unchanged in the result string. If there is no match, the  `$'` substitution has no effect.  
  
 The following example uses the regular expression pattern `\d+` to match a sequence of one or more decimal digits in the input string. The replacement string `$'` replaces these digits with the text that follows the match.  
  
 [!code-csharp[Conceptual.Regex.Language.Substitutions#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/after1.cs#5)]
 [!code-vb[Conceptual.Regex.Language.Substitutions#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/after1.vb#5)]  
  
 In this example, the input string `"aa1bb2cc3dd4ee5"` contains five matches. The following table illustrates how the `$'` substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the results column.  
  
|Match|Position|String after match|Result string|  
|-----------|--------------|------------------------|-------------------|  
|1|2|bb2cc3dd4ee5|aa**bb2cc3dd4ee5**bb2cc3dd4ee5|  
|2|5|cc3dd4ee5|aabb2cc3dd4ee5bb**cc3dd4ee5**cc3dd4ee5|  
|3|8|dd4ee5|aabb2cc3dd4ee5bbcc3dd4ee5cc**dd4ee5**dd4ee5|  
|4|11|ee5|aabb2cc3dd4ee5bbcc3dd4ee5ccdd4ee5dd**ee5**ee5|  
|5|14|<xref:System.String.Empty?displayProperty=nameWithType>|aabb2cc3dd4ee5bbcc3dd4ee5ccdd4ee5ddee5ee|  
  
 [Back to top](#Top)  
  
<a name="LastGroup"></a>   
## Substituting the Last Captured Group  
 The `$+` substitution replaces the matched string with the last captured group. If there are no captured groups or if the value of the last captured group is <xref:System.String.Empty?displayProperty=nameWithType>, the `$+` substitution has no effect.  
  
 The following example identifies duplicate words in a string and uses the `$+` substitution to replace them with a single occurrence of the word. The <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option is used to ensure that words that differ in case but that are otherwise identical are considered duplicates.  
  
 [!code-csharp[Conceptual.Regex.Language.Substitutions#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/lastmatch1.cs#6)]
 [!code-vb[Conceptual.Regex.Language.Substitutions#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/lastmatch1.vb#6)]  
  
 The regular expression pattern `\b(\w+)\s\1\b` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`(\w+)`|Match one or more word characters. This is the first capturing group.|  
|`\s`|Match a white-space character.|  
|`\1`|Match the first captured group.|  
|`\b`|End the match at a word boundary.|  
  
 [Back to top](#Top)  
  
<a name="EntireString"></a>   
## Substituting the Entire Input String  
 The `$_` substitution replaces the matched string with the entire input string. That is, it removes the matched text and replaces it with the entire string, including the matched text.  
  
 The following example matches one or more decimal digits in the input string. It uses the `$_` substitution to replace them with the entire input string.  
  
 [!code-csharp[Conceptual.Regex.Language.Substitutions#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.substitutions/cs/entire1.cs#7)]
 [!code-vb[Conceptual.Regex.Language.Substitutions#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.substitutions/vb/entire1.vb#7)]  
  
 In this example, the input string `"ABC123DEF456"` contains two matches. The following table illustrates how the `$_` substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the results column.  
  
|Match|Position|Match|Result string|  
|-----------|--------------|-----------|-------------------|  
|1|3|123|ABC**ABC123DEF456**DEF456|  
|2|5|456|ABCABC123DEF456DEF**ABC123DEF456**|  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
