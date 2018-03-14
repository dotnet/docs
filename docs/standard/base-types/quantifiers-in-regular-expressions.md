---
title: "Quantifiers in Regular Expressions"
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
  - "regular expressions, quantifiers"
  - "metacharacters, quantifiers"
  - "minimal matching quantifiers"
  - "quantifiers in regular expressions"
  - ".NET Framework regular expressions, quantifiers"
  - "quantifiers"
  - "lazy quantifiers"
ms.assetid: 36b81212-6511-49ed-a8f1-ff080415312f
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Quantifiers in Regular Expressions
Quantifiers specify how many instances of a character, group, or character class must be present in the input for a match to be found.  The following table lists the quantifiers supported by .NET.  
  
|Greedy quantifier|Lazy quantifier|Description|  
|-----------------------|---------------------|-----------------|  
|`*`|`*?`|Match zero or more times.|  
|`+`|`+?`|Match one or more times.|  
|`?`|`??`|Match zero or one time.|  
|`{` *n* `}`|`{` *n* `}?`|Match exactly *n* times.|  
|`{` *n* `,}`|`{` *n* `,}?`|Match at least *n* times.|  
|`{` *n* `,` *m* `}`|`{` *n* `,` *m* `}?`|Match from *n* to *m* times.|  
  
 The quantities `n` and `m` are integer constants. Ordinarily, quantifiers are greedy; they cause the regular expression engine to match as many occurrences of particular patterns as possible. Appending the `?` character to a quantifier makes it lazy; it causes the regular expression engine to match as few occurrences as possible. For a complete description of the difference between greedy and lazy quantifiers, see the section [Greedy and Lazy Quantifiers](#Greedy) later in this topic.  
  
> [!IMPORTANT]
>  Nesting quantifiers (for example, as the regular expression pattern `(a*)*` does) can increase the number of comparisons that the regular expression engine must perform, as an exponential function of the number of characters in the input string. For more information about this behavior and its workarounds, see [Backtracking](../../../docs/standard/base-types/backtracking-in-regular-expressions.md).  
  
## Regular Expression Quantifiers  
 The following sections list the quantifiers supported by .NET regular expressions.  
  
> [!NOTE]
>  If the *, +, ?, {, and } characters are encountered in a regular expression pattern, the regular expression engine interprets them as quantifiers or part of quantifier constructs unless they are included in a [character class](../../../docs/standard/base-types/character-classes-in-regular-expressions.md). To interpret these as literal characters outside a character class, you must escape them by preceding them with a backslash. For example, the string `\*` in a regular expression pattern is interpreted as a literal asterisk ("\*") character.  
  
### Match Zero or More Times: *  
 The `*` quantifier matches the preceding element zero or more times. It is equivalent to the `{0,}` quantifier. `*` is a greedy quantifier whose lazy equivalent is `*?`.  
  
 The following example illustrates this regular expression. Of the nine digits in the input string, five match the pattern and four (`95`, `929`, `9129`, and `9919`) do not.  
  
 [!code-csharp[RegularExpressions.Quantifiers#1](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#1)]
 [!code-vb[RegularExpressions.Quantifiers#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#1)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`91*`|Match a "9" followed by zero or more "1" characters.|  
|`9*`|Match zero or more "9" characters.|  
|`\b`|End at a word boundary.|  
  
### Match One or More Times: +  
 The `+` quantifier matches the preceding element one or more times. It is equivalent to `{1,}`. `+` is a greedy quantifier whose lazy equivalent is `+?`.  
  
 For example, the regular expression `\ban+\w*?\b` tries to match entire words that begin with the letter `a` followed by one or more instances of the letter `n`. The following example illustrates this regular expression. The regular expression matches the words `an`, `annual`, `announcement`, and `antique`, and correctly fails to match `autumn` and `all`.  
  
 [!code-csharp[RegularExpressions.Quantifiers#2](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#2)]
 [!code-vb[RegularExpressions.Quantifiers#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#2)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`an+`|Match an "a" followed by one or more "n" characters.|  
|`\w*?`|Match a word character zero or more times, but as few times as possible.|  
|`\b`|End at a word boundary.|  
  
### Match Zero or One Time: ?  
 The `?` quantifier matches the preceding element zero or one time. It is equivalent to `{0,1}`. `?` is a greedy quantifier whose lazy equivalent is `??`.  
  
 For example, the regular expression `\ban?\b` tries to match entire words that begin with the letter `a` followed by zero or one instances of the letter `n`. In other words, it tries to match the words `a` and `an`. The following example illustrates this regular expression.  
  
 [!code-csharp[RegularExpressions.Quantifiers#3](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#3)]
 [!code-vb[RegularExpressions.Quantifiers#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#3)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`an?`|Match an "a" followed by zero or one "n" character.|  
|`\b`|End at a word boundary.|  
  
### Match Exactly n Times: {n}  
 The `{`*n*`}` quantifier matches the preceding element exactly *n* times, where *n* is any integer. `{`*n*`}` is a greedy quantifier whose lazy equivalent is `{`*n*`}?`.  
  
 For example, the regular expression `\b\d+\,\d{3}\b` tries to match a word boundary followed by one or more decimal digits followed by three decimal digits followed by a word boundary. The following example illustrates this regular expression.  
  
 [!code-csharp[RegularExpressions.Quantifiers#4](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#4)]
 [!code-vb[RegularExpressions.Quantifiers#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#4)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`\d+`|Match one or more decimal digits.|  
|`\,`|Match a comma character.|  
|`\d{3}`|Match three decimal digits.|  
|`\b`|End at a word boundary.|  
  
### Match at Least n Times: {n,}  
 The `{`*n*`,}` quantifier matches the preceding element at least *n* times, where *n* is any integer. `{`*n*`,}` is a greedy quantifier whose lazy equivalent is `{`*n*`}?`.  
  
 For example, the regular expression `\b\d{2,}\b\D+` tries to match a word boundary followed by at least two digits followed by a word boundary and a non-digit character. The following example illustrates this regular expression. The regular expression fails to match the phrase `"7 days"` because it contains just one decimal digit, but it successfully matches the phrases `"10 weeks and 300 years"`.  
  
 [!code-csharp[RegularExpressions.Quantifiers#5](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#5)]
 [!code-vb[RegularExpressions.Quantifiers#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#5)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`\d{2,}`|Match at least two decimal digits.|  
|`\b`|Match a word boundary.|  
|`\D+`|Match at least one non-decimal digit.|  
  
### Match Between n and m Times: {n,m}  
 The `{`*n*`,`*m*`}` quantifier matches the preceding element at least *n* times, but no more than *m* times, where *n* and *m* are integers. `{`*n*`,`*m*`}` is a greedy quantifier whose lazy equivalent is `{`*n*`,`*m*`}?`.  
  
 In the following example, the regular expression `(00\s){2,4}` tries to match between two and four occurrences of two zero digits followed by a space. Note that the final portion of the input string includes this pattern five times rather than the maximum of four. However, only the initial portion of this substring (up to the space and the fifth pair of zeros) matches the regular expression pattern.  
  
 [!code-csharp[RegularExpressions.Quantifiers#6](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#6)]
 [!code-vb[RegularExpressions.Quantifiers#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#6)]  
  
### Match Zero or More Times (Lazy Match): *?  
 The `*?` quantifier matches the preceding element zero or more times, but as few times as possible. It is the lazy counterpart of the greedy quantifier `*`.  
  
 In the following example, the regular expression `\b\w*?oo\w*?\b` matches all words that contain the string `oo`.  
  
 [!code-csharp[RegularExpressions.Quantifiers#7](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#7)]
 [!code-vb[RegularExpressions.Quantifiers#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#7)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`\w*?`|Match zero or more word characters, but as few characters as possible.|  
|`oo`|Match the string "oo".|  
|`\w*?`|Match zero or more word characters, but as few characters as possible.|  
|`\b`|End on a word boundary.|  
  
### Match One or More Times (Lazy Match): +?  
 The `+?` quantifier matches the preceding element one or more times, but as few times as possible. It is the lazy counterpart of the greedy quantifier `+`.  
  
 For example, the regular expression `\b\w+?\b` matches one or more characters separated by word boundaries. The following example illustrates this regular expression.  
  
 [!code-csharp[RegularExpressions.Quantifiers#8](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#8)]
 [!code-vb[RegularExpressions.Quantifiers#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#8)]  
  
### Match Zero or One Time (Lazy Match): ??  
 The `??` quantifier matches the preceding element zero or one time, but as few times as possible. It is the lazy counterpart of the greedy quantifier `?`.  
  
 For example, the regular expression `^\s*(System.)??Console.Write(Line)??\(??` attempts to match the strings "Console.Write" or "Console.WriteLine". The string can also include "System." before "Console", and it can be followed by an opening parenthesis. The string must be at the beginning of a line, although it can be preceded by white space. The following example illustrates this regular expression.  
  
 [!code-csharp[RegularExpressions.Quantifiers#9](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#9)]
 [!code-vb[RegularExpressions.Quantifiers#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#9)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Match the start of the input stream.|  
|`\s*`|Match zero or more white-space characters.|  
|`(System.)??`|Match zero or one occurrence of the string "System.".|  
|`Console.Write`|Match the string "Console.Write".|  
|`(Line)??`|Match zero or one occurrence of the string "Line".|  
|`\(??`|Match zero or one occurrence of the opening parenthesis.|  
  
### Match Exactly n Times (Lazy Match): {n}?  
 The `{`*n*`}?` quantifier matches the preceding element exactly `n` times, where *n* is any integer. It is the lazy counterpart of the greedy quantifier `{`*n*`}+`.  
  
 In the following example, the regular expression `\b(\w{3,}?\.){2}?\w{3,}?\b` is used to identify a Web site address. Note that it matches "www.microsoft.com" and "msdn.microsoft.com", but does not match "mywebsite" or "mycompany.com".  
  
 [!code-csharp[RegularExpressions.Quantifiers#10](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#10)]
 [!code-vb[RegularExpressions.Quantifiers#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#10)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`(\w{3,}?\.)`|Match at least 3 word characters, but as few characters as possible, followed by a dot or period character. This is the first capturing group.|  
|`(\w{3,}?\.){2}?`|Match the pattern in the first group two times, but as few times as possible.|  
|`\b`|End the match on a word boundary.|  
  
### Match at Least n Times (Lazy Match): {n,}?  
 The `{`*n*`,}?` quantifier matches the preceding element at least `n` times, where *n* is any integer, but as few times as possible. It is the lazy counterpart of the greedy quantifier `{`*n*`,}`.  
  
 See the example for the `{`*n*`}?` quantifier in the previous section for an illustration. The regular expression in that example uses the `{`*n*`,}` quantifier to match a string that has at least three characters followed by a period.  
  
### Match Between n and m Times (Lazy Match): {n,m}?  
 The `{`*n*`,`*m*`}?` quantifier matches the preceding element between `n` and `m` times, where *n* and *m* are integers, but as few times as possible. It is the lazy counterpart of the greedy quantifier `{`*n*`,`*m*`}`.  
  
 In the following example, the regular expression `\b[A-Z](\w*\s+){1,10}?[.!?]` matches sentences that contain between one and ten words. It matches all the sentences in the input string except for one sentence that contains 18 words.  
  
 [!code-csharp[RegularExpressions.Quantifiers#12](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers/cs/Quantifiers1.cs#12)]
 [!code-vb[RegularExpressions.Quantifiers#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers/vb/Quantifiers1.vb#12)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`[A-Z]`|Match an uppercase character from A to Z.|  
|`(\w*\s+)`|Match zero or more word characters, followed by one or more white-space characters. This is the first capture group.|  
|`{1,10}?`|Match the previous pattern between 1 and 10 times, but as few times as possible.|  
|`[.!?]`|Match any one of the punctuation characters ".", "!", or "?".|  
  
<a name="Greedy"></a>   
## Greedy and Lazy Quantifiers  
 A number of the quantifiers have two versions:  
  
-   A greedy version.  
  
     A greedy quantifier tries to match an element as many times as possible.  
  
-   A non-greedy (or lazy) version.  
  
     A non-greedy quantifier tries to match an element as few times as possible. You can turn a greedy quantifier into a lazy quantifier by simply adding a `?`.  
  
 Consider a simple regular expression that is intended to extract the last four digits from a string of numbers such as a credit card number. The version of the regular expression that uses the `*` greedy quantifier is `\b.*([0-9]{4})\b`. However, if a string contains two numbers, this regular expression matches the last four digits of the second number only, as the following example shows.  
  
 [!code-csharp[RegularExpressions.Quantifiers.Greedy#1](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers.Greedy/cs/Greedy.cs#1)]
 [!code-vb[RegularExpressions.Quantifiers.Greedy#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers.Greedy/vb/Greedy.vb#1)]  
  
 The regular expression fails to match the first number because the `*` quantifier tries to match the previous element as many times as possible in the entire string, and so it finds its match at the end of the string.  
  
 This is not the desired behavior. Instead, you can use the `*?`lazy quantifier to extract digits from both numbers, as the following example shows.  
  
 [!code-csharp[RegularExpressions.Quantifiers.Greedy#2](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Quantifiers.Greedy/cs/Greedy.cs#2)]
 [!code-vb[RegularExpressions.Quantifiers.Greedy#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Quantifiers.Greedy/vb/Greedy.vb#2)]  
  
 In most cases, regular expressions with greedy and lazy quantifiers return the same matches. They most commonly return different results when they are used with the wildcard (`.`) metacharacter, which matches any character.  
  
## Quantifiers and Empty Matches  
 The quantifiers `*`, `+`, and `{`*n*`,`*m*`}` and their lazy counterparts never repeat after an empty match when the minimum number of captures has been found. This rule prevents quantifiers from entering infinite loops on empty subexpression matches when the maximum number of possible group captures is infinite or near infinite.  
  
 For example, the following code shows the result of a call to the <xref:System.Text.RegularExpressions.Regex.Match%2A?displayProperty=nameWithType> method with the regular expression pattern `(a?)*`, which matches zero or one "a" character zero or more times. Note that the single capturing group captures each "a" as well as <xref:System.String.Empty?displayProperty=nameWithType>, but that there is no second empty match, because the first empty match causes the quantifier to stop repeating.  
  
 [!code-csharp[RegularExpressions.Quantifiers.EmptyMatch#1](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.quantifiers.emptymatch/cs/emptymatch1.cs#1)]
 [!code-vb[RegularExpressions.Quantifiers.EmptyMatch#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.quantifiers.emptymatch/vb/emptymatch1.vb#1)]  
  
 To see the practical difference between a capturing group that defines a minimum and a maximum number of captures and one that defines a fixed number of captures, consider the regular expression patterns `(a\1|(?(1)\1)){0,2}` and `(a\1|(?(1)\1)){2}`. Both regular expressions consist of a single capturing group, which is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`(a\1`|Either match "a" along with the value of the first captured group …|  
|<code>&#124;(?(1)</code>|… or test whether the first captured group has been defined. (Note that the `(?(1)` construct does not define a capturing group.)|  
|`\1))`|If the first captured group exists, match its value. If the group does not exist, the group will match <xref:System.String.Empty?displayProperty=nameWithType>.|  
  
 The first regular expression tries to match this pattern between zero and two times; the second, exactly two times. Because the first pattern reaches its minimum number of captures with its first capture of <xref:System.String.Empty?displayProperty=nameWithType>, it never repeats to try to match `a\1`; the `{0,2}` quantifier allows only empty matches in the last iteration. In contrast, the second regular expression does match "a" because it evaluates `a\1` a second time; the minimum number of iterations, 2, forces the engine to repeat after an empty match.  
  
 [!code-csharp[RegularExpressions.Quantifiers.EmptyMatch#2](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.quantifiers.emptymatch/cs/emptymatch4.cs#2)]
 [!code-vb[RegularExpressions.Quantifiers.EmptyMatch#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.quantifiers.emptymatch/vb/emptymatch4.vb#2)]  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)  
 [Backtracking](../../../docs/standard/base-types/backtracking-in-regular-expressions.md)
