---
title: "Miscellaneous Constructs in Regular Expressions"
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
  - "constructs, miscellaneous"
  - ".NET Framework regular expressions, miscellaneous constructs"
  - "regular expressions, miscellaneous constructs"
ms.assetid: 7d10d11f-680f-4721-b047-fb136316b4cd
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Miscellaneous Constructs in Regular Expressions
Regular expressions in .NET include three miscellaneous language constructs. One lets you enable or disable particular matching options in the middle of a regular expression pattern. The remaining two let you include comments in a regular expression.  
  
## Inline Options  
 You can set or disable specific pattern matching options for part of a regular expression by using the syntax  
  
```  
(?imnsx-imnsx)  
```  
  
 You list the options you want to enable after the question mark, and the options you want to disable after the minus sign. The following table describes each option. For more information about each option, see [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
|Option|Description|  
|------------|-----------------|  
|`i`|Case-insensitive matching.|  
|`m`|Multiline mode.|  
|`n`|Explicit captures only. (Parentheses do not act as capturing groups.)|  
|`s`|Single-line mode.|  
|`x`|Ignore unescaped white space, and allow x-mode comments.|  
  
 Any change in regular expression options defined by the `(?imnsx-imnsx)` construct remains in effect until the end of the enclosing group.  
  
> [!NOTE]
>  The `(?imnsx-imnsx:`*subexpression*`)` grouping construct provides identical functionality for a subexpression. For more information, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
 The following example uses the `i`, `n`, and `x` options to enable case insensitivity and explicit captures, and to ignore white space in the regular expression pattern in the middle of a regular expression.  
  
 [!code-csharp[RegularExpressions.Language.Miscellaneous#1](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.miscellaneous/cs/miscellaneous1.cs#1)]
 [!code-vb[RegularExpressions.Language.Miscellaneous#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.miscellaneous/vb/miscellaneous1.vb#1)]  
  
 The example defines two regular expressions. The first, `\b(D\w+)\s(d\w+)\b`, matches two consecutive words that begin with an uppercase "D" and a lowercase "d". The second regular expression, `\b(D\w+)(?ixn) \s (d\w+) \b`, uses inline options to modify this pattern, as described in the following table. A comparison of the results confirms the effect of the `(?ixn)` construct.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`(D\w+)`|Match a capital "D" followed by one or more word characters. This is the first capture group.|  
|`(?ixn)`|From this point on, make comparisons case-insensitive, make only explicit captures, and ignore white space in the regular expression pattern.|  
|`\s`|Match a white-space character.|  
|`(d\w+)`|Match an uppercase or lowercase "d" followed by one or more word characters. This group is not captured because the `n` (explicit capture) option was enabled..|  
|`\b`|Match a word boundary.|  
  
## Inline Comment  
 The `(?#` *comment*`)` construct lets you include an inline comment in a regular expression. The regular expression engine does not use any part of the comment in pattern matching, although the comment is included in the string that is returned by the <xref:System.Text.RegularExpressions.Regex.ToString%2A?displayProperty=nameWithType> method. The comment ends at the first closing parenthesis.  
  
 The following example repeats the first regular expression pattern from the example in the previous section. It adds two inline comments to the regular expression to indicate whether the comparison is case-sensitive. The regular expression pattern, `\b((?# case-sensitive comparison)D\w+)\s((?#case-insensitive comparison)d\w+)\b`, is defined as follows.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`(?# case-sensitive comparison)`|A comment. It does not affect pattern-matching behavior.|  
|`(D\w+)`|Match a capital "D" followed by one or more word characters. This is the first capturing group.|  
|`\s`|Match a white-space character.|  
|`(?ixn)`|From this point on, make comparisons case-insensitive, make only explicit captures, and ignore white space in the regular expression pattern.|  
|`(?#case-insensitive comparison)`|A comment. It does not affect pattern-matching behavior.|  
|`(d\w+)`|Match an uppercase or lowercase "d" followed by one or more word characters. This is the second capture group.|  
|`\b`|Match a word boundary.|  
  
 [!code-csharp[RegularExpressions.Language.Miscellaneous#2](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.miscellaneous/cs/miscellaneous2.cs#2)]
 [!code-vb[RegularExpressions.Language.Miscellaneous#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.miscellaneous/vb/miscellaneous2.vb#2)]  
  
## End-of-Line Comment  
 A number sign (`#`)marks an x-mode comment, which starts at the unescaped # character at the end of the regular expression pattern and continues until the end of the line. To use this construct, you must either enable the `x` option (through inline options) or supply the <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> value to the `option` parameter when instantiating the <xref:System.Text.RegularExpressions.Regex> object or calling a static <xref:System.Text.RegularExpressions.Regex> method.  
  
 The following example illustrates the end-of-line comment construct. It determines whether a string is a composite format string that includes at least one format item. The following table describes the constructs in the regular expression pattern:  
  
 `\{\d+(,-*\d+)*(\:\w{1,4}?)*\}(?x) # Looks for a composite format item.`  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\{`|Match an opening brace.|  
|`\d+`|Match one or more decimal digits.|  
|`(,-*\d+)*`|Match zero or one occurrence of a comma, followed by an optional minus sign, followed by one or more decimal digits.|  
|`(\:\w{1,4}?)*`|Match zero or one occurrence of a colon, followed by one to four, but as few as possible, white-space characters.|  
|`(?#case insensitive comparison)`|An inline comment. It has no effect on pattern-matching behavior.|  
|`\}`|Match a closing brace.|  
|`(?x)`|Enable the ignore pattern white-space option so that the end-of-line comment will be recognized.|  
|`# Looks for a composite format item.`|An end-of-line comment.|  
  
 [!code-csharp[RegularExpressions.Language.Miscellaneous#3](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.miscellaneous/cs/miscellaneous3.cs#3)]
 [!code-vb[RegularExpressions.Language.Miscellaneous#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.miscellaneous/vb/miscellaneous3.vb#3)]  
  
 Note that, instead of providing the `(?x)` construct in the regular expression, the comment could also have been recognized by calling the <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method and passing it the <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> enumeration value.  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
