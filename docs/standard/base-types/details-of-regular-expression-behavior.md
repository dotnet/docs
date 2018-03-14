---
title: "Details of Regular Expression Behavior"
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
  - "regular expressions, behavior"
  - ".NET Framework regular expressions, behavior"
ms.assetid: 0ee1a6b8-caac-41d2-917f-d35570021b10
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Details of Regular Expression Behavior
The .NET Framework regular expression engine is a backtracking regular expression matcher that incorporates a traditional Nondeterministic Finite Automaton (NFA) engine such as that used by Perl, Python, Emacs, and Tcl. This distinguishes it from faster, but more limited, pure regular expression Deterministic Finite Automaton (DFA) engines such as those found in awk, egrep, or lex. This also distinguishes it from standardized, but slower, POSIX NFAs. The following section describes the three types of regular expression engines, and explains why regular expressions in the .NET Framework are implemented by using a traditional NFA engine.  
  
## Benefits of the NFA Engine  
 When DFA engines perform pattern matching, their processing order is driven by the input string. The engine begins at the beginning of the input string and proceeds sequentially to determine whether the next character matches the regular expression pattern. They can guarantee to match the longest string possible. Because they never test the same character twice, DFA engines do not support backtracking. However, because a DFA engine contains only finite state, it cannot match a pattern with backreferences, and because it does not construct an explicit expansion, it cannot capture subexpressions.  
  
 Unlike DFA engines, when traditional NFA engines perform pattern matching, their processing order is driven by the regular expression pattern. As it processes a particular language element, the engine uses greedy matching; that is, it matches as much of the input string as it possibly can. But it also saves its state after successfully matching a subexpression. If a match eventually fails, the engine can return to a saved state so it can try additional matches. This process of abandoning a successful subexpression match so that later language elements in the regular expression can also match is known as *backtracking*. NFA engines use backtracking to test all possible expansions of a regular expression in a specific order and accept the first match. Because a traditional NFA engine constructs a specific expansion of the regular expression for a successful match, it can capture subexpression matches and matching backreferences. However, because a traditional NFA backtracks, it can visit the same state multiple times if it arrives at the state over different paths. As a result, it can run exponentially slowly in the worst case. Because a traditional NFA engine accepts the first match it finds, it can also leave other (possibly longer) matches undiscovered.  
  
 POSIX NFA engines are like traditional NFA engines, except that they continue to backtrack until they can guarantee that they have found the longest match possible. As a result, a POSIX NFA engine is slower than a traditional NFA engine, and when you use a POSIX NFA engine, you cannot favor a shorter match over a longer one by changing the order of the backtracking search.  
  
 Traditional NFA engines are favored by programmers because they offer greater control over string matching than either DFA or POSIX NFA engines. Although, in the worst case, they can run slowly, you can steer them to find matches in linear or polynomial time by using patterns that reduce ambiguities and limit backtracking. In other words, although NFA engines trade performance for power and flexibility, in most cases they offer good to acceptable performance if a regular expression is well-written and avoids cases in which backtracking degrades performance exponentially.  
  
> [!NOTE]
>  For information about the performance penalty caused by excessive backtracking and ways to craft a regular expression to work around them, see [Backtracking](../../../docs/standard/base-types/backtracking-in-regular-expressions.md).  
  
## .NET Framework Engine Capabilities  
 To take advantage of the benefits of a traditional NFA engine, the .NET Framework regular expression engine includes a complete set of constructs to enable programmers to steer the backtracking engine. These constructs can be used to find matches faster or to favor specific expansions over others.  
  
 Other features of the .NET Framework regular expression engine include the following:  
  
-   Lazy quantifiers: `??`, `*?`, `+?`, `{`*n*`,`*m*`}?`. These constructs tell the backtracking engine to search the minimum number of repetitions first. In contrast, ordinary greedy quantifiers try to match the maximum number of repetitions first. The following example illustrates the difference between the two. A regular expression matches a sentence that ends in a number, and a capturing group is intended to extract that number. The regular expression `.+(\d+)\.` includes the greedy quantifier `.+`, which causes the regular expression engine to capture only the last digit of the number. In contrast, the regular expression `.+?(\d+)\.` includes the lazy quantifier `.+?`, which causes the regular expression engine to capture the entire number.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/lazy1.cs#1)]
     [!code-vb[Conceptual.RegularExpressions.Design#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/lazy1.vb#1)]  
  
     The greedy and lazy versions of this regular expression are defined as shown in the following table.`  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |`.+` (greedy quantifier)|Match at least one occurrence of any character. This causes the regular expression engine to match the entire string, and then to backtrack as needed to match the remainder of the pattern.|  
    |`.+?` (lazy quantifier)|Match at least one occurrence of any character, but match as few as possible.|  
    |`(\d+)`|Match at least one numeric character, and assign it to the first capturing group.|  
    |`\.`|Match a period.|  
  
     For more information about lazy quantifiers, see [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md).  
  
-   Positive lookahead: `(?=`*subexpression*`)`. This feature allows the backtracking engine to return to the same spot in the text after matching a subexpression. It is useful for searching throughout the text by verifying multiple patterns that start from the same position. It also allows the engine to verify that a substring exists at the end of the match without including the substring in the matched text. The following example uses positive lookahead to extract the words in a sentence that are not followed by punctuation symbols.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/lookahead1.cs#2)]
     [!code-vb[Conceptual.RegularExpressions.Design#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/lookahead1.vb#2)]  
  
     The regular expression `\b[A-Z]+\b(?=\P{P})` is defined as shown in the following table.  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |`\b`|Begin the match at a word boundary.|  
    |`[A-Z]+`|Match any alphabetic character one or more times. Because the <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method is called with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option, the comparison is case-insensitive.|  
    |`\b`|End the match at a word boundary.|  
    |`(?=\P{P})`|Look ahead to determine whether the next character is a punctuation symbol. If it is not, the match succeeds.|  
  
     For more information about positive lookahead assertions, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
-   Negative lookahead: `(?!`*subexpression*`)`. This feature adds the ability to match an expression only if a subexpression fails to match. This is particularly powerful for pruning a search, because it is often simpler to provide an expression for a case that should be eliminated than an expression for cases that must be included. For example, it is difficult to write an expression for words that do not begin with "non". The following example uses negative lookahead to exclude them.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/lookahead2.cs#3)]
     [!code-vb[Conceptual.RegularExpressions.Design#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/lookahead2.vb#3)]  
  
     The regular expression pattern `\b(?!non)\w+\b` is defined as shown in the following table.  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |`\b`|Begin the match at a word boundary.|  
    |`(?!non)`|Look ahead to ensure that the current string does not begin with "non". If it does, the match fails.|  
    |`(\w+)`|Match one or more word characters.|  
    |`\b`|End the match at a word boundary.|  
  
     For more information about negative lookahead assertions, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
-   Conditional evaluation: `(?(`*expression*`)`*yes*`|`*no*`)` and `(?(`*name*`)`*yes*`|`*no*`)`, where *expression* is a subexpression to match, *name* is the name of a capturing group, *yes* is the string to match if *expression* is matched or *name* is a valid, non-empty captured group, and *no* is the subexpression to match if *expression* is not matched or *name* is not a valid, non-empty captured group. This feature allows the engine to search by using more than one alternate pattern, depending on the result of a previous subexpression match or the result of a zero-width assertion. This allows a more powerful form of backreference that permits, for example, matching a subexpression based on whether a previous subexpression was matched. The regular expression in the following example matches paragraphs that are intended for both public and internal use. Paragraphs intended only for internal use begin with a `<PRIVATE>` tag. The regular expression pattern `^(?<Pvt>\<PRIVATE\>\s)?(?(Pvt)((\w+\p{P}?\s)+)|((\w+\p{P}?\s)+))\r?$` uses conditional evaluation to assign the contents of paragraphs intended for public and for internal use to separate capturing groups. These paragraphs can then be handled differently.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/conditional1.cs#4)]
     [!code-vb[Conceptual.RegularExpressions.Design#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/conditional1.vb#4)]  
  
     The regular expression pattern is defined as shown in the following table.  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |`^`|Begin the match at the beginning of a line.|  
    |`(?<Pvt>\<PRIVATE\>\s)?`|Match zero or one occurrence of the string `<PRIVATE>` followed by a white-space character. Assign the match to a capturing group named `Pvt`.|  
    |`(?(Pvt)((\w+\p{P}?\s)+)`|If the `Pvt` capturing group exists, match one or more occurrences of one or more word characters followed by zero or one punctuation separator followed by a white-space character. Assign the substring to the first capturing group.|  
    |<code>&#124;((\w+\p{P}?\s)+))<code>|If the `Pvt` capturing group does not exist, match one or more occurrences of one or more word characters followed by zero or one punctuation separator followed by a white-space character. Assign the substring to the third capturing group.|  
    |`\r?$`|Match the end of a line or the end of the string.|  
  
     For more information about conditional evaluation, see [Alternation Constructs](../../../docs/standard/base-types/alternation-constructs-in-regular-expressions.md).  
  
-   Balancing group definitions: `(?<`*name1*`-`*name2*`>` *subexpression*`)`. This feature allows the regular expression engine to keep track of nested constructs such as parentheses or opening and closing brackets. For an example, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
-   Nonbacktracking subexpressions (also known as greedy subexpressions): `(?>`*subexpression*`)`. This feature allows the backtracking engine to guarantee that a subexpression matches only the first match found for that subexpression, as if the expression were running independent of its containing expression. If you do not use this construct, backtracking searches from the larger expression can change the behavior of a subexpression. For example, the regular expression `(a+)\w` matches one or more "a" characters, along with a word character that follows the sequence of "a" characters, and assigns the sequence of "a" characters to the first capturing group, However, if the final character of the input string is also an "a", it is matched by the `\w` language element and is not included in the captured group.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/nonbacktracking2.cs#7)]
     [!code-vb[Conceptual.RegularExpressions.Design#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/nonbacktracking2.vb#7)]  
  
     The regular expression `((?>a+))\w` prevents this behavior. Because all consecutive "a" characters are matched without backtracking, the first capturing group includes all consecutive "a" characters. If the "a" characters are not followed by at least one more character other than "a", the match fails.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/nonbacktracking1.cs#8)]
     [!code-vb[Conceptual.RegularExpressions.Design#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/nonbacktracking1.vb#8)]  
  
     For more information about nonbacktracking subexpressions, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
-   Right-to-left matching, which is specified by supplying the <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType> option to a <xref:System.Text.RegularExpressions.Regex> class constructor or static instance matching method. This feature is useful when searching from right to left instead of from left to right, or in cases where it is more efficient to begin a match at the right part of the pattern instead of the left. As the following example illustrates, using right-to-left matching can change the behavior of greedy quantifiers. The example conducts two searches for a sentence that ends in a number. The left-to-right search that uses the greedy quantifier `+` matches one of the six digits in the sentence, whereas the right-to-left search matches all six digits. For an description of the regular expression pattern, see the example that illustrates lazy quantifiers earlier in this section.  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/rtl1.cs#6)]
     [!code-vb[Conceptual.RegularExpressions.Design#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/rtl1.vb#6)]  
  
     For more information about right-to-left matching, see [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
-   Positive and negative lookbehind: `(?<=`*subexpression*`)` for positive lookbehind, and `(?<!`*subexpression*`)` for negative lookbehind. This feature is similar to lookahead, which is discussed earlier in this topic. Because the regular expression engine allows complete right-to-left matching, regular expressions allow unrestricted lookbehinds. Positive and negative lookbehind can also be used to avoid nesting quantifiers when the nested subexpression is a superset of an outer expression. Regular expressions with such nested quantifiers often offer poor performance. For example, the following example verifies that a string begins and ends with an alphanumeric character, and that any other character in the string is one of a larger subset. It forms a portion of the regular expression used to validate email addresses; for more information, see [How to: Verify that Strings Are in Valid Email Format](../../../docs/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format.md).  
  
     [!code-csharp[Conceptual.RegularExpressions.Design#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.design/cs/lookbehind1.cs#5)]
     [!code-vb[Conceptual.RegularExpressions.Design#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.design/vb/lookbehind1.vb#5)]  
  
     The regular expression `^[A-Z0-9]([-!#$%&'.*+/=?^`{}|~\w])*(?<=[A-Z0-9])$` is defined as shown in the following table.  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |`^`|Begin the match at the beginning of the string.|  
    |`[A-Z0-9]`|Match any numeric or alphanumeric character. (The comparison is case-insensitive.)|  
    |<code>([-!#$%&'.*+/=?^\`{}&#124;~\w])*<code>|Match zero or more occurrences of any word character, or any of the following characters:  -, !, #, $, %, &, ', ., *, +, /, =, ?, ^, \`, {, }, &#124;, or ~.|  
    |`(?<=[A-Z0-9])`|Look behind to the previous character, which must be numeric or alphanumeric. (The comparison is case-insensitive.)|  
    |`$`|End the match at the end of the string.|  
  
     For more information about positive and negative lookbehind, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Backtracking](../../../docs/standard/base-types/backtracking-in-regular-expressions.md)|Provides information about how regular expression backtracking branches to find alternative matches.|  
|[Compilation and Reuse](../../../docs/standard/base-types/compilation-and-reuse-in-regular-expressions.md)|Provides information about compiling and reusing regular expressions to increase performance.|  
|[Thread Safety](../../../docs/standard/base-types/thread-safety-in-regular-expressions.md)|Provides information about regular expression thread safety and explains when you should synchronize access to regular expression objects.|  
|[.NET Framework Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)|Provides an overview of the programming language aspect of regular expressions.|  
|[The Regular Expression Object Model](../../../docs/standard/base-types/the-regular-expression-object-model.md)|Provides information and code examples illustrating how to use the regular expression classes.|  
|[Regular Expression Examples](../../../docs/standard/base-types/regular-expression-examples.md)|Contains code examples that illustrate the use of regular expressions in common applications.|  
|[Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)|Provides information about the set of characters, operators, and constructs that you can use to define regular expressions.|  
  
## Reference  
 <xref:System.Text.RegularExpressions?displayProperty=nameWithType>
