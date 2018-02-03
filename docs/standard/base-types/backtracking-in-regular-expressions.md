---
title: "Backtracking in Regular Expressions"
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
  - ".NET Framework regular expressions, backtracking"
  - "alternative matching patterns"
  - "optional matching patterns"
  - "searching with regular expressions, backtracking"
  - "pattern-matching with regular expressions, backtracking"
  - "backtracking"
  - "regular expressions [.NET Framework], backtracking"
  - "strings [.NET Framework], regular expressions"
  - "parsing text with regular expressions, backtracking"
ms.assetid: 34df1152-0b22-4a1c-a76c-3c28c47b70d8
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Backtracking in Regular Expressions
<a name="top"></a> Backtracking occurs when a regular expression pattern contains optional [quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md) or [alternation constructs](../../../docs/standard/base-types/alternation-constructs-in-regular-expressions.md), and the regular expression engine returns to a previous saved state to continue its search for a match. Backtracking is central to the power of regular expressions; it makes it possible for expressions to be powerful and flexible, and to match very complex patterns. At the same time, this power comes at a cost. Backtracking is often the single most important factor that affects the performance of the regular expression engine. Fortunately, the developer has control over the behavior of the regular expression engine and how it uses backtracking. This topic explains how backtracking works and how it can be controlled.  
  
> [!NOTE]
>  In general, a Nondeterministic Finite Automaton (NFA) engine like .NET regular expression engine places the responsibility for crafting efficient, fast regular expressions on the developer.  
  
 This topic contains the following sections:  
  
-   [Linear Comparison Without Backtracking](#linear_comparison_without_backtracking)  
  
-   [Backtracking with Optional Quantifiers or Alternation Constructs](#backtracking_with_optional_quantifiers_or_alternation_constructs)  
  
-   [Backtracking with Nested Optional Quantifiers](#backtracking_with_nested_optional_quantifiers)  
  
-   [Controlling Backtracking](#controlling_backtracking)  
  
<a name="linear_comparison_without_backtracking"></a>   
## Linear Comparison Without Backtracking  
 If a regular expression pattern has no optional quantifiers or alternation constructs, the regular expression engine executes in linear time. That is, after the regular expression engine matches the first language element in the pattern with text in the input string, it tries to match the next language element in the pattern with the next character or group of characters in the input string. This continues until the match either succeeds or fails. In either case, the regular expression engine advances by one character at a time in the input string.  
  
 The following example provides an illustration. The regular expression `e{2}\w\b` looks for two occurrences of the letter "e" followed by any word character followed by a word boundary.  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking1.cs#1)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking1.vb#1)]  
  
 Although this regular expression includes the quantifier `{2}`, it is evaluated in a linear manner. The regular expression engine does not backtrack because `{2}` is not an optional quantifier; it specifies an exact number and not a variable number of times that the previous subexpression must match. As a result, the regular expression engine tries to match the regular expression pattern with the input string as shown in the following table.  
  
|Operation|Position in pattern|Position in string|Result|  
|---------------|-------------------------|------------------------|------------|  
|1|e|"needing a reed" (index 0)|No match.|  
|2|e|"eeding a reed" (index 1)|Possible match.|  
|3|e{2}|"eding a reed" (index 2)|Possible match.|  
|4|\w|"ding a reed" (index 3)|Possible match.|  
|5|\b|"ing a reed" (index 4)|Possible match fails.|  
|6|e|"eding a reed" (index 2)|Possible match.|  
|7|e{2}|"ding a reed" (index 3)|Possible match fails.|  
|8|e|"ding a reed" (index 3)|Match fails.|  
|9|e|"ing a reed" (index 4)|No match.|  
|10|e|"ng a reed" (index 5)|No match.|  
|11|e|"g a reed" (index 6)|No match.|  
|12|e|" a reed" (index 7)|No match.|  
|13|e|"a reed" (index 8)|No match.|  
|14|e|" reed" (index 9)|No match.|  
|15|e|"reed" (index 10)|No match|  
|16|e|"eed" (index 11)|Possible match.|  
|17|e{2}|"ed" (index 12)|Possible match.|  
|18|\w|"d" (index 13)|Possible match.|  
|19|\b|"" (index 14)|Match.|  
  
 If a regular expression pattern includes no optional quantifiers or alternation constructs, the maximum number of comparisons required to match the regular expression pattern with the input string is roughly equivalent to the number of characters in the input string. In this case, the regular expression engine uses 19 comparisons to identify possible matches in this 13-character string.  In other words, the regular expression engine runs in near-linear time if it contains no optional quantifiers or alternation constructs.  
  
 [Back to top](#top)  
  
<a name="backtracking_with_optional_quantifiers_or_alternation_constructs"></a>   
## Backtracking with Optional Quantifiers or Alternation Constructs  
 When a regular expression includes optional quantifiers or alternation constructs, the evaluation of the input string is no longer linear. Pattern matching with an NFA engine is driven by the language elements in the regular expression and not by the characters to be matched in the input string. Therefore, the regular expression engine tries to fully match optional or alternative subexpressions. When it advances to the next language element in the subexpression and the match is unsuccessful, the regular expression engine can abandon a portion of its successful match and return to an earlier saved state in the interest of matching the regular expression as a whole with the input string. This process of returning to a previous saved state to find a match is known as backtracking.  
  
 For example, consider the regular expression pattern `.*(es)`, which matches the characters "es" and all the characters that precede it. As the following example shows, if the input string is "Essential services are provided by regular expressions.", the pattern matches the whole string up to and including the "es" in "expressions".  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking2.cs#2)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking2.vb#2)]  
  
 To do this, the regular expression engine uses backtracking as follows:  
  
-   It matches the `.*` (which matches zero, one, or more occurrences of any character) with the whole input string.  
  
-   It attempts to match "e" in the regular expression pattern. However, the input string has no remaining characters available to match.  
  
-   It backtracks to its last successful match, "Essential services are provided by regular expressions", and attempts to match "e" with the period at the end of the sentence. The match fails.  
  
-   It continues to backtrack to a previous successful match one character at a time until the tentatively matched substring is "Essential services are provided by regular expr". It then compares the "e" in the pattern to the second "e" in "expressions" and finds a match.  
  
-   It compares "s" in the pattern to the "s" that follows the matched "e" character (the first "s" in "expressions"). The match is successful.  
  
 When you use backtracking, matching the regular expression pattern with the input string, which is 55 characters long, requires 67 comparison operations. Interestingly, if the regular expression pattern included a lazy quantifier, .`*?(es)`, matching the regular expression would require additional comparisons. In this case, instead of having to backtrack from the end of the string to the "r" in "expressions", the regular expression engine would have to backtrack all the way to the beginning of the string to match "Es" and would require 113 comparisons. Generally, if a regular expression pattern has a single alternation construct or a single optional quantifier, the number of comparison operations required to match the pattern is more than twice the number of characters in the input string.  
  
 [Back to top](#top)  
  
<a name="backtracking_with_nested_optional_quantifiers"></a>   
## Backtracking with Nested Optional Quantifiers  
 The number of comparison operations required to match a regular expression pattern can increase exponentially if the pattern includes a large number of alternation constructs, if it includes nested alternation constructs, or, most commonly, if it includes nested optional quantifiers. For example, the regular expression pattern `^(a+)+$` is designed to match a complete string that contains one or more "a" characters. The example provides two input strings of identical length, but only the first string matches the pattern. The <xref:System.Diagnostics.Stopwatch?displayProperty=nameWithType> class is used to determine how long the match operation takes.  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking3.cs#3)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking3.vb#3)]  
  
 As the output from the example shows, the regular expression engine took about twice as long to find that an input string did not match the pattern as it did to identify a matching string. This is because an unsuccessful match always represents a worst-case scenario. The regular expression engine must use the regular expression to follow all possible paths through the data before it can conclude that the match is unsuccessful, and the nested parentheses create many additional paths through the data. The regular expression engine concludes that the second string did not match the pattern by doing the following:  
  
-   It checks that it was at the beginning of the string, and then matches the first five characters in the string with the pattern `a+`. It then determines that there are no additional groups of "a" characters in the string. Finally, it tests for the end of the string. Because one additional character remains in the string, the match fails. This failed match requires 9 comparisons. The regular expression engine also saves state information from its matches of "a" (which we will call match 1), "aa" (match 2), "aaa" (match 3), and "aaaa" (match 4).  
  
-   It returns to the previously saved match 4. It determines that there is one additional "a" character to assign to an additional captured group. Finally, it tests for the end of the string. Because one additional character remains in the string, the match fails. This failed match requires 4 comparisons. So far, a total of 13 comparisons have been performed.  
  
-   It returns to the previously saved match 3. It determines that there are two additional "a" characters to assign to an additional captured group. However, the end-of-string test fails. It then returns to match3 and tries to match the two additional "a" characters in two additional captured groups. The end-of-string test still fails. These failed matches require 12 comparisons. So far, a total of 25 comparisons have been performed.  
  
 Comparison of the input string with the regular expression continues in this way until the regular expression engine has tried all possible combinations of matches, and then concludes that there is no match. Because of the nested quantifiers, this comparison is an O(2<sup>n</sup>) or an exponential operation, where *n* is the number of characters in the input string. This means that in the worst case, an input string of 30 characters requires approximately 1,073,741,824 comparisons, and an input string of 40 characters requires approximately 1,099,511,627,776 comparisons. If you use strings of these or even greater lengths, regular expression methods can take an extremely long time to complete when they process input that does not match the regular expression pattern.  
  
 [Back to top](#top)  
  
<a name="controlling_backtracking"></a>   
## Controlling Backtracking  
 Backtracking lets you create powerful, flexible regular expressions. However, as the previous section showed, these benefits may be coupled with unacceptably poor performance. To prevent excessive backtracking, you should define a time-out interval when you instantiate a <xref:System.Text.RegularExpressions.Regex> object or call a static regular expression matching method. This is discussed in the next section. In addition, .NET supports three regular expression language elements that limit or suppress backtracking and that support complex regular expressions with little or no performance penalty: [nonbacktracking subexpressions](#Nonbacktracking), [lookbehind assertions](#Lookbehind), and [lookahead assertions](#Lookahead). For more information about each language element, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
<a name="Timeout"></a>   
### Defining a Time-out Interval  
 Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], you can set a time-out value that represents the longest interval the regular expression engine will search for a single match before it abandons the attempt and throws a <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> exception. You specify the time-out interval by supplying a <xref:System.TimeSpan> value to the <xref:System.Text.RegularExpressions.Regex.%23ctor%28System.String%2CSystem.Text.RegularExpressions.RegexOptions%2CSystem.TimeSpan%29?displayProperty=nameWithType> constructor for instance regular expressions. In addition, each static pattern matching method has an overload with a <xref:System.TimeSpan> parameter that allows you to specify a time-out value. By default, the time-out interval is set to <xref:System.Text.RegularExpressions.Regex.InfiniteMatchTimeout?displayProperty=nameWithType> and the regular expression engine does not time out.  
  
> [!IMPORTANT]
>  We recommend that you always set a time-out interval if your regular expression relies on backtracking.  
  
 A <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> exception indicates that the regular expression engine was unable to find a match within in the specified time-out interval but does not indicate why the exception was thrown. The reason might be excessive backtracking, but it is also possible that the time-out interval was set too low given the system load at the time the exception was thrown. When you handle the exception, you can choose to abandon further matches with the input string or increase the time-out interval and retry the matching operation.  
  
 For example, the following code calls the <xref:System.Text.RegularExpressions.Regex.%23ctor%28System.String%2CSystem.Text.RegularExpressions.RegexOptions%2CSystem.TimeSpan%29?displayProperty=nameWithType> constructor to instantiate a <xref:System.Text.RegularExpressions.Regex> object with a time-out value of one second. The regular expression pattern `(a+)+$`, which matches one or more sequences of one or more "a" characters at the end of a line, is subject to excessive backtracking. If a <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> is thrown, the example increases the time-out value up to a maximum interval of three seconds. After that, it abandons the attempt to match the pattern.  
  
 [!code-csharp[System.Text.RegularExpressions.Regex.ctor#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.text.regularexpressions.regex.ctor/cs/ctor1.cs#1)]
 [!code-vb[System.Text.RegularExpressions.Regex.ctor#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.text.regularexpressions.regex.ctor/vb/ctor1.vb#1)]  
  
<a name="Nonbacktracking"></a>   
### Nonbacktracking Subexpression  
 The `(?>` *subexpression*`)` language element suppresses backtracking in a subexpression. It is useful for preventing the performance problems associated with failed matches.  
  
 The following example illustrates how suppressing backtracking improves performance when using nested quantifiers. It measures the time required for the regular expression engine to determine that an input string does not match two regular expressions. The first regular expression uses backtracking to attempt to match a string that contains one or more occurrences of one or more hexadecimal digits, followed by a colon, followed by one or more hexadecimal digits, followed by two colons. The second regular expression is identical to the first, except that it disables backtracking. As the output from the example shows, the performance improvement from disabling backtracking is significant.  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking4.cs#4)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking4.vb#4)]  
  
<a name="Lookbehind"></a>   
### Lookbehind Assertions  
 .NET includes two language elements, `(?<=`*subexpression*`)` and `(?<!`*subexpression*`)`, that match the previous character or characters in the input string. Both language elements are zero-width assertions; that is, they determine whether the character or characters that immediately precede the current character can be matched by *subexpression*, without advancing or backtracking.  
  
 `(?<=` *subexpression* `)` is a positive lookbehind assertion; that is, the character or characters before the current position must match *subexpression*. `(?<!`*subexpression*`)` is a negative lookbehind assertion; that is, the character or characters before the current position must not match *subexpression*. Both positive and negative lookbehind assertions are most useful when *subexpression* is a subset of the previous subexpression.  
  
 The following example uses two equivalent regular expression patterns that validate the user name in an email address. The first pattern is subject to poor performance because of excessive backtracking. The second pattern modifies the first regular expression by replacing a nested quantifier with a positive lookbehind assertion. The output from the example displays the execution time of the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method.  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking5.cs#5)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking5.vb#5)]  
  
 The first regular expression pattern, `^[0-9A-Z]([-.\w]*[0-9A-Z])*@`, is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Start the match at the beginning of the string.|  
|`[0-9A-Z]`|Match an alphanumeric character. This comparison is case-insensitive, because the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method is called with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option.|  
|`[-.\w]*`|Match zero, one, or more occurrences of a hyphen, period, or word character.|  
|`[0-9A-Z]`|Match an alphanumeric character.|  
|`([-.\w]*[0-9A-Z])*`|Match zero or more occurrences of the combination of zero or more hyphens, periods, or word characters, followed by an alphanumeric character. This is the first capturing group.|  
|`@`|Match an at sign ("@").|  
  
 The second regular expression pattern, `^[0-9A-Z][-.\w]*(?<=[0-9A-Z])@`, uses a positive lookbehind assertion. It is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Start the match at the beginning of the string.|  
|`[0-9A-Z]`|Match an alphanumeric character. This comparison is case-insensitive, because the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method is called with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option.|  
|`[-.\w]*`|Match zero or more occurrences of a hyphen, period, or word character.|  
|`(?<=[0-9A-Z])`|Look back at the last matched character and continue the match if it is alphanumeric. Note that alphanumeric characters are a subset of the set that consists of periods, hyphens, and all word characters.|  
|`@`|Match an at sign ("@").|  
  
<a name="Lookahead"></a>   
### Lookahead Assertions  
 .NET includes two language elements, `(?=`*subexpression*`)` and `(?!`*subexpression*`)`, that match the next character or characters in the input string. Both language elements are zero-width assertions; that is, they determine whether the character or characters that immediately follow the current character can be matched by *subexpression*, without advancing or backtracking.  
  
 `(?=` *subexpression* `)` is a positive lookahead assertion; that is, the character or characters after the current position must match *subexpression*. `(?!`*subexpression*`)` is a negative lookahead assertion; that is, the character or characters after the current position must not match *subexpression*. Both positive and negative lookahead assertions are most useful when *subexpression* is a subset of the next subexpression.  
  
 The following example uses two equivalent regular expression patterns that validate a fully qualified type name. The first pattern is subject to poor performance because of excessive backtracking. The second modifies the first regular expression by replacing a nested quantifier with a positive lookahead assertion. The output from the example displays the execution time of the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method.  
  
 [!code-csharp[Conceptual.RegularExpressions.Backtracking#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/cs/backtracking6.cs#6)]
 [!code-vb[Conceptual.RegularExpressions.Backtracking#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.backtracking/vb/backtracking6.vb#6)]  
  
 The first regular expression pattern, `^(([A-Z]\w*)+\.)*[A-Z]\w*$`, is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Start the match at the beginning of the string.|  
|`([A-Z]\w*)+\.`|Match an alphabetical character (A-Z) followed by zero or more word characters one or more times, followed by a period. This comparison is case-insensitive, because the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method is called with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option.|  
|`(([A-Z]\w*)+\.)*`|Match the previous pattern zero or more times.|  
|`[A-Z]\w*`|Match an alphabetical character followed by zero or more word characters.|  
|`$`|End the match at the end of the input string.|  
  
 The second regular expression pattern, `^((?=[A-Z])\w+\.)*[A-Z]\w*$`, uses a positive lookahead assertion. It is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Start the match at the beginning of the string.|  
|`(?=[A-Z])`|Look ahead to the first character and continue the match if it is alphabetical (A-Z). This comparison is case-insensitive, because the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method is called with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option.|  
|`\w+\.`|Match one or more word characters followed by a period.|  
|`((?=[A-Z])\w+\.)*`|Match the pattern of one or more word characters followed by a period zero or more times. The initial word character must be alphabetical.|  
|`[A-Z]\w*`|Match an alphabetical character followed by zero or more word characters.|  
|`$`|End the match at the end of the input string.|  
  
 [Back to top](#top)  
  
## See Also  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)  
 [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md)  
 [Alternation Constructs](../../../docs/standard/base-types/alternation-constructs-in-regular-expressions.md)  
 [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md)
