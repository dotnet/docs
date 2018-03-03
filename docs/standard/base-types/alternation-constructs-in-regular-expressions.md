---
title: "Alternation Constructs in Regular Expressions"
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
  - "either/or matching"
  - "alternative matching patterns"
  - "regular expressions, alternation constructs"
  - "alternation constructs"
  - "optional matching patterns"
  - "constructs, alternation"
  - ".NET Framework regular expressions, alternation constructs"
ms.assetid: 071e22e9-fbb0-4ecf-add1-8d2424f9f2d1
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Alternation Constructs in Regular Expressions
<a name="top"></a> Alternation constructs modify a regular expression to enable either/or or conditional matching. .NET supports three alternation constructs:  
  
-   [Pattern matching with &#124;](#Either_Or)  
  
-   [Conditional matching with (?(expression)yes&#124;no)](#Conditional_Expr)  
  
-   [Conditional matching based on a valid captured group](#Conditional_Group)  
  
<a name="Either_Or"></a>   
## Pattern Matching with &#124;  
 You can use the vertical bar (`|`) character to match any one of a series of patterns, where the `|` character separates each pattern.  
  
 Like the positive character class, the `|` character can be used to match any one of a number of single characters. The following example uses both a positive character class and either/or pattern matching with the `|` character to locate occurrences of the words "gray" or "grey" in a string. In this case, the `|` character produces a regular expression that is more verbose.  
  
 [!code-csharp[RegularExpressions.Language.Alternation#1](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.alternation/cs/alternation1.cs#1)]
 [!code-vb[RegularExpressions.Language.Alternation#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.alternation/vb/alternation1.vb#1)]  
  
 The regular expression that uses the `|` character, `\bgr(a|e)y\b`, is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`gr`|Match the characters "gr".|  
|<code>(a&#124;e)</code>|Match either an "a" or an "e".|  
|`y\b`|Match a "y" on a word boundary.|  
  
 The `|` character can also be used to perform an either/or match with multiple characters or subexpressions, which can include any combination of character literals and regular expression language elements. (The character class does not provide this functionality.) The following example uses the `|` character to extract either a U.S. Social Security Number (SSN), which is a 9-digit number with the format *ddd*-*dd*-*dddd*, or a U.S. Employer Identification Number (EIN), which is a 9-digit number with the format *dd*-*ddddddd*.  
  
 [!code-csharp[RegularExpressions.Language.Alternation#2](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.alternation/cs/alternation2.cs#2)]
 [!code-vb[RegularExpressions.Language.Alternation#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.alternation/vb/alternation2.vb#2)]  
  
 The regular expression `\b(\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|<code>(\d{2}-\d{7}&#124;\d{3}-\d{2}-\d{4})</code>|Match either of the following: two decimal digits followed by a hyphen followed by seven decimal digits; or three decimal digits, a hyphen, two decimal digits, another hyphen, and four decimal digits.|  
|`\d`|End the match at a word boundary.|  
  
 [Back to top](#top)  
  
<a name="Conditional_Expr"></a>   
## Conditional Matching with an Expression  
 This language element attempts to match one of two patterns depending on whether it can match an initial pattern. Its syntax is:  
  
 `(?(` *expression* `)` *yes* `|` *no* `)`  
  
 where *expression* is the initial pattern to match, *yes* is the pattern to match if *expression* is matched, and *no* is the optional pattern to match if *expression* is not matched. The regular expression engine treats *expression* as a zero-width assertion; that is, the regular expression engine does not advance in the input stream after it evaluates *expression*. Therefore, this construct is equivalent to the following:  
  
 `(?(?=` *expression* `)` *yes* `|` *no* `)`  
  
 where `(?=`*expression*`)` is a zero-width assertion construct. (For more information, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).) Because the regular expression engine interprets *expression* as an anchor (a zero-width assertion), *expression* must either be a zero-width assertion (for more information, see [Anchors](../../../docs/standard/base-types/anchors-in-regular-expressions.md)) or a subexpression that is also contained in *yes*. Otherwise, the *yes* pattern cannot be matched.  
  
> [!NOTE]
>  If *expression*is a named or numbered capturing group, the alternation construct is interpreted as a capture test; for more information, see the next section, [Conditional Matching Based on a Valid Capture Group](#Conditional_Group). In other words, the regular expression engine does not attempt to match the captured substring, but instead tests for the presence or absence of the group.  
  
 The following example is a variation of the example that appears in the [Either/Or Pattern Matching with &#124;](#Either_Or) section. It uses conditional matching to determine whether the first three characters after a word boundary are two digits followed by a hyphen. If they are, it attempts to match a U.S. Employer Identification Number (EIN). If not, it attempts to match a U.S. Social Security Number (SSN).  
  
 [!code-csharp[RegularExpressions.Language.Alternation#3](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.alternation/cs/alternation3.cs#3)]
 [!code-vb[RegularExpressions.Language.Alternation#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.alternation/vb/alternation3.vb#3)]  
  
 The regular expression pattern `\b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`(?(\d{2}-)`|Determine whether the next three characters consist of two digits followed by a hyphen.|  
|`\d{2}-\d{7}`|If the previous pattern matches, match two digits followed by a hyphen followed by seven digits.|  
|`\d{3}-\d{2}-\d{4}`|If the previous pattern does not match, match three decimal digits, a hyphen, two decimal digits, another hyphen, and four decimal digits.|  
|`\b`|Match a word boundary.|  
  
 [Back to top](#top)  
  
<a name="Conditional_Group"></a>   
## Conditional Matching Based on a Valid Captured Group  
 This language element attempts to match one of two patterns depending on whether it has matched a specified capturing group. Its syntax is:  
  
 `(?(` *name* `)` *yes* `|` *no* `)`  
  
 or  
  
 `(?(` *number* `)` *yes* `|` *no* `)`  
  
 where *name* is the name and *number* is the number of a capturing group, *yes* is the expression to match if *name* or *number* has a match, and *no* is the optional expression to match if it does not.  
  
 If *name* does not correspond to the name of a capturing group that is used in the regular expression pattern, the alternation construct is interpreted as an expression test, as explained in the previous section. Typically, this means that *expression* evaluates to `false`. If *number* does not correspond to a numbered capturing group that is used in the regular expression pattern, the regular expression engine throws an <xref:System.ArgumentException>.  
  
 The following example is a variation of the example that appears in the [Either/Or Pattern Matching with &#124;](#Either_Or) section. It uses a capturing group named `n2` that consists of two digits followed by a hyphen. The alternation construct tests whether this capturing group has been matched in the input string. If it has, the alternation construct attempts to match the last seven digits of a nine-digit U.S. Employer Identification Number (EIN). If it has not, it attempts to match a nine-digit U.S. Social Security Number (SSN).  
  
 [!code-csharp[RegularExpressions.Language.Alternation#4](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.alternation/cs/alternation4.cs#4)]
 [!code-vb[RegularExpressions.Language.Alternation#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.alternation/vb/alternation4.vb#4)]  
  
 The regular expression pattern `\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`(?<n2>\d{2}-)?`|Match zero or one occurrence of two digits followed by a hyphen. Name this capturing group `n2`.|  
|`(?(n2)`|Test whether `n2` was matched in the input string.|  
|`)\d{7}`|If `n2` was matched, match seven decimal digits.|  
|<code>&#124;\d{3}-\d{2}-\d{4}</code>|If `n2` was not matched, match three decimal digits, a hyphen, two decimal digits, another hyphen, and four decimal digits.|  
|`\b`|Match a word boundary.|  
  
 A variation of this example that uses a numbered group instead of a named group is shown in the following example. Its regular expression pattern is `\b(\d{2}-)?(?(1)\d{7}|\d{3}-\d{2}-\d{4})\b`.  
  
 [!code-csharp[RegularExpressions.Language.Alternation#5](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.alternation/cs/alternation5.cs#5)]
 [!code-vb[RegularExpressions.Language.Alternation#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.alternation/vb/alternation5.vb#5)]  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
