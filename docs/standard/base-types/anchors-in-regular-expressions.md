---
title: "Anchors in Regular Expressions"
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
  - "atomic zero-width assertions"
  - "regular expressions, anchors"
  - "regular expressions, atomic zero-width assertions"
  - "anchors, in regular expressions"
  - "metacharacters, atomic zero-width assertions"
  - "metacharacters, anchors"
  - ".NET Framework regular expressions, anchors"
  - ".NET Framework regular expressions, atomic zero-width assertions"
ms.assetid: 336391f6-2614-499b-8b1b-07a6837108a7
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Anchors in Regular Expressions
<a name="top"></a> Anchors, or atomic zero-width assertions, specify a position in the string where a match must occur. When you use an anchor in your search expression, the regular expression engine does not advance through the string or consume characters; it looks for a match in the specified position only. For example, `^` specifies that the match must start at the beginning of a line or string. Therefore, the regular expression `^http:` matches "http:" only when it occurs at the beginning of a line. The following table lists the anchors supported by the regular expressions in .NET.  
  
|Anchor|Description|  
|------------|-----------------|  
|`^`|The match must occur at the beginning of the string or line. For more information, see [Start of String or Line](#Start).|  
|`$`|The match must occur at the end of the string or line, or before `\n` at the end of the string or line. For more information, see [End of String or Line](#End).|  
|`\A`|The match must occur at the beginning of the string only (no multiline support). For more information, see [Start of String Only](#StartOnly).|  
|`\Z`|The match must occur at the end of the string, or before `\n` at the end of the string. For more information, see [End of String or Before Ending Newline](#EndOrNOnly).|  
|`\z`|The match must occur at the end of the string only. For more information, see [End of String Only](#EndOnly).|  
|`\G`|The match must start at the position where the previous match ended. For more information, see [Contiguous Matches](#Contiguous).|  
|`\b`|The match must occur on a word boundary. For more information, see [Word Boundary](#WordBoundary).|  
|`\B`|The match must not occur on a word boundary. For more information, see [Non-Word Boundary](#NonwordBoundary).|  
  
<a name="Start"></a>   
## Start of String or Line: ^  
 The `^` anchor specifies that the following pattern must begin at the first character position of the string. If you use `^` with the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option (see [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md)), the match must occur at the beginning of each line.  
  
 The following example uses the `^` anchor in a regular expression that extracts information about the years during which some professional baseball teams existed. The example calls two overloads of the <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method:  
  
-   The call to the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%29> overload finds only the first substring in the input string that matches the regular expression pattern.  
  
-   The call to the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29> overload with the `options` parameter set to <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> finds all five substrings.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/startofstring1.cs#1)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/startofstring1.vb#1)]  
  
 The regular expression pattern `^((\w+(\s?)){2,}),\s(\w+\s\w+),(\s\d{4}(-(\d{4}|present))?,?)+` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Begin the match at the beginning of the input string (or the beginning of the line if the method is called with the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option).|  
|`((\w+(\s?)){2,}`|Match one or more word characters followed either by zero or by one space exactly two times. This is the first capturing group. This expression also defines a second and third capturing group: The second consists of the captured word, and the third consists of the captured spaces.|  
|`,\s`|Match a comma followed by a white-space character.|  
|`(\w+\s\w+)`|Match one or more word characters followed by a space, followed by one or more word characters. This is the fourth capturing group.|  
|`,`|Match a comma.|  
|`\s\d{4}`|Match a space followed by four decimal digits.|  
|<code>(-(\d{4}&#124;present))?</code>|Match zero or one occurrence of a hyphen followed by four decimal digits or the string "present". This is the sixth capturing group. It also includes a seventh capturing group.|  
|`,?`|Match zero or one occurrence of a comma.|  
|<code>(\s\d{4}(-(\d{4}&#124;present))?,?)+</code>|Match one or more occurrences of the following: a space, four decimal digits, zero or one occurrence of a hyphen followed by four decimal digits or the string "present", and zero or one comma. This is the fifth capturing group.|  
  
 [Back to top](#top)  
  
<a name="End"></a>   
## End of String or Line: $  
 The `$` anchor specifies that the preceding pattern must occur at the end of the input string, or before `\n` at the end of the input string.  
  
 If you use `$` with the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option, the match can also occur at the end of a line. Note that `$` matches `\n` but does not match `\r\n` (the combination of carriage return and newline characters, or CR/LF). To match the CR/LF character combination, include `\r?$` in the regular expression pattern.  
  
 The following example adds the `$` anchor to the regular expression pattern used in the example in the [Start of String or Line](#Start) section. When used with the original input string, which includes five lines of text, the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%29?displayProperty=nameWithType> method is unable to find a match, because the end of the first line does not match the `$` pattern. When the original input string is split into a string array, the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%29?displayProperty=nameWithType> method succeeds in matching each of the five lines. When the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method is called with the `options` parameter set to <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType>, no matches are found because the regular expression pattern does not account for the carriage return element (\u+000D). However, when the regular expression pattern is modified by replacing `$` with `\r?$`, calling the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method with the `options` parameter set to <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> again finds five matches.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/endofstring1.cs#2)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/endofstring1.vb#2)]  
  
 [Back to top](#top)  
  
<a name="StartOnly"></a>   
## Start of String Only: \A  
 The `\A` anchor specifies that a match must occur at the beginning of the input string. It is identical to the `^` anchor, except that `\A` ignores the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option. Therefore, it can only match the start of the first line in a multiline input string.  
  
 The following example is similar to the examples for the `^` and `$` anchors. It uses the `\A` anchor in a regular expression that extracts information about the years during which some professional baseball teams existed. The input string includes five lines. The call to the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method finds only the first substring in the input string that matches the regular expression pattern. As the example shows, the <xref:System.Text.RegularExpressions.RegexOptions.Multiline> option has no effect.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/startofstring2.cs#3)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/startofstring2.vb#3)]  
  
 [Back to top](#top)  
  
<a name="EndOrNOnly"></a>   
## End of String or Before Ending Newline: \Z  
 The `\Z` anchor specifies that a match must occur at the end of the input string, or before `\n` at the end of the input string. It is identical to the `$` anchor, except that `\Z` ignores the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option. Therefore, in a multiline string, it can only match the end of the last line, or the last line before `\n`.  
  
 Note that `\Z` matches `\n` but does not match `\r\n` (the CR/LF character combination). To match CR/LF, include `\r?\Z` in the regular expression pattern.  
  
 The following example uses the `\Z` anchor in a regular expression that is similar to the example in the [Start of String or Line](#Start) section, which extracts information about the years during which some professional baseball teams existed. The subexpression `\r?\Z` in the regular expression `^((\w+(\s?)){2,}),\s(\w+\s\w+),(\s\d{4}(-(\d{4}|present))?,?)+\r?\Z` matches the end of a string, and also matches a string that ends with `\n` or `\r\n`. As a result, each element in the array matches the regular expression pattern.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/endofstring2.cs#4)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/endofstring2.vb#4)]  
  
 [Back to top](#top)  
  
<a name="EndOnly"></a>   
## End of String Only: \z  
 The `\z` anchor specifies that a match must occur at the end of the input string. Like the `$` language element, `\z` ignores the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option. Unlike the `\Z` language element, `\z` does not match a `\n` character at the end of a string. Therefore, it can only match the last line of the input string.  
  
 The following example uses the `\z` anchor in a regular expression that is otherwise identical to the example in the previous section, which extracts information about the years during which some professional baseball teams existed. The example tries to match each of five elements in a string array with the regular expression pattern `^((\w+(\s?)){2,}),\s(\w+\s\w+),(\s\d{4}(-(\d{4}|present))?,?)+\r?\z`. Two of the strings end with carriage return and line feed characters, one ends with a line feed character, and two end with neither a carriage return nor a line feed character. As the output shows, only the strings without a carriage return or line feed character match the pattern.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/endofstring3.cs#5)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/endofstring3.vb#5)]  
  
 [Back to top](#top)  
  
<a name="Contiguous"></a>   
## Contiguous Matches: \G  
 The `\G` anchor specifies that a match must occur at the point where the previous match ended. When you use this anchor with the <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> or <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method, it ensures that all matches are contiguous.  
  
 The following example uses a regular expression to extract the names of rodent species from a comma-delimited string.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/contiguous1.cs#6)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/contiguous1.vb#6)]  
  
 The regular expression `\G(\w+\s?\w*),?` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\G`|Begin where the last match ended.|  
|`\w+`|Match one or more word characters.|  
|`\s?`|Match zero or one space.|  
|`\w*`|Match zero or more word characters.|  
|`(\w+\s?\w*)`|Match one or more word characters followed by zero or one space, followed by zero or more word characters. This is the first capturing group.|  
|`,?`|Match zero or one occurrence of a literal comma character.|  
  
 [Back to top](#top)  
  
<a name="WordBoundary"></a>   
## Word Boundary: \b  
 The `\b` anchor specifies that the match must occur on a boundary between a word character (the `\w` language element) and a non-word character (the `\W` language element). Word characters consist of alphanumeric characters and underscores; a non-word character is any character that is not alphanumeric or an underscore. (For more information, see [Character Classes](../../../docs/standard/base-types/character-classes-in-regular-expressions.md).) The match may also occur on a word boundary at the beginning or end of the string.  
  
 The `\b` anchor is frequently used to ensure that a subexpression matches an entire word instead of just the beginning or end of a word. The regular expression `\bare\w*\b` in the following example illustrates this usage. It matches any word that begins with the substring "are". The output from the example also illustrates that `\b` matches both the beginning and the end of the input string.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/word1.cs#7)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/word1.vb#7)]  
  
 The regular expression pattern is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`are`|Match the substring "are".|  
|`\w*`|Match zero or more word characters.|  
|`\b`|End the match at a word boundary.|  
  
 [Back to top](#top)  
  
<a name="NonwordBoundary"></a>   
## Non-Word Boundary: \B  
 The `\B` anchor specifies that the match must not occur on a word boundary. It is the opposite of the `\b` anchor.  
  
 The following example uses the `\B` anchor to locate occurrences of the substring "qu" in a word. The regular expression pattern `\Bqu\w+` matches a substring that begins with a "qu" that does not start a word and that continues to the end of the word.  
  
 [!code-csharp[Conceptual.RegEx.Language.Assertions#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.assertions/cs/nonword1.cs#8)]
 [!code-vb[Conceptual.RegEx.Language.Assertions#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.assertions/vb/nonword1.vb#8)]  
  
 The regular expression pattern is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\B`|Do not begin the match at a word boundary.|  
|`qu`|Match the substring "qu".|  
|`\w+`|Match one or more word characters.|  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)  
 [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md)
