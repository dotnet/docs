---
title: "Character Escapes in Regular Expressions"
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
  - "unescaped characters"
  - "replacement patterns"
  - "characters, escapes"
  - "regular expressions, character escapes"
  - "escape characters"
  - ".NET Framework regular expressions, character escapes"
  - "constructs, character escapes"
ms.assetid: f49cc9cc-db7d-4058-8b8a-422bc08b29b0
caps.latest.revision: 31
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Character Escapes in Regular Expressions
The backslash (\\) in a regular expression indicates one of the following:  
  
-   The character that follows it is a special character, as shown in the table in the following section. For example, `\b` is an anchor that indicates that a regular expression match should begin on a word boundary, `\t` represents a tab, and `\x020` represents a space.  
  
-   A character that otherwise would be interpreted as an unescaped language construct should be interpreted literally. For example, a brace (`{`) begins the definition of a quantifier, but a backslash followed by a brace (`\{`) indicates that the regular expression engine should match the brace. Similarly, a single backslash marks the beginning of an escaped language construct, but two backslashes (`\\`) indicate that the regular expression engine should match the backslash.  
  
> [!NOTE]
>  Character escapes are recognized in regular expression patterns but not in replacement patterns.  
  
## Character Escapes in .NET  
 The following table lists the character escapes supported by regular expressions in .NET.  
  
|Character or sequence|Description|  
|---------------------------|-----------------|  
|All characters except for the following:<br /><br /> . $ ^ { [ ( &#124; ) * + ? \|Characters other than those listed in the **Character or sequence** column have no special meaning in regular expressions; they match themselves.<br /><br /> The characters included in the **Character or sequence** column are special regular expression language elements. To match them in a regular expression, they must be escaped or included in a [positive character group](../../../docs/standard/base-types/character-classes-in-regular-expressions.md). For example, the regular expression `\$\d+` or `[$]\d+` matches "$1200".|  
|`\a`|Matches a bell (alarm) character, `\u0007`.|  
|`\b`|In a `[`*character_group*`]` character class, matches a backspace, `\u0008`.  (See [Character Classes](../../../docs/standard/base-types/character-classes-in-regular-expressions.md).) Outside a character class, `\b` is an anchor that matches a word boundary. (See [Anchors](../../../docs/standard/base-types/anchors-in-regular-expressions.md).)|  
|`\t`|Matches a tab, `\u0009`.|  
|`\r`|Matches a carriage return, `\u000D`. Note that `\r` is not equivalent to the newline character, `\n`.|  
|`\v`|Matches a vertical tab, `\u000B`.|  
|`\f`|Matches a form feed, `\u000C`.|  
|`\n`|Matches a new line, `\u000A`.|  
|`\e`|Matches an escape, `\u001B`.|  
|`\` *nnn*|Matches an ASCII character, where *nnn* consists of two or three digits that represent the octal character code. For example, `\040` represents a space character. This construct is interpreted as a backreference if it has only one digit (for example, `\2`) or if it corresponds to the number of a capturing group. (See [Backreference Constructs](../../../docs/standard/base-types/backreference-constructs-in-regular-expressions.md).)|  
|`\x` *nn*|Matches an ASCII character, where *nn* is a two-digit hexadecimal character code.|  
|`\c` *X*|Matches an ASCII control character, where X is the letter of the control character. For example, `\cC` is CTRL-C.|  
|`\u` *nnnn*|Matches a UTF-16 code unit whose value is *nnnn* hexadecimal. **Note:**  The Perl 5 character escape that is used to specify Unicode is not supported by .NET. The Perl 5 character escape has the form `\x{`*####*`…}`, where *####*`…` is a series of hexadecimal digits. Instead, use `\u`*nnnn*.|  
|`\`|When followed by a character that is not recognized as an escaped character, matches that character. For example, `\*` matches an asterisk (*) and is the same as `\x2A`.|  
  
## An Example  
 The following example illustrates the use of character escapes in a regular expression. It parses a string that contains the names of the world's largest cities and their populations in 2009. Each city name is separated from its population by a tab (`\t`) or a vertical bar (&#124; or `\u007c`). Individual cities and their populations are separated from each other by a carriage return and line feed.  
  
 [!code-csharp[RegularExpressions.Language.Escapes#1](../../../samples/snippets/csharp/VS_Snippets_CLR/regularexpressions.language.escapes/cs/escape1.cs#1)]
 [!code-vb[RegularExpressions.Language.Escapes#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/regularexpressions.language.escapes/vb/escape1.vb#1)]  
  
 The regular expression `\G(.+)[\t|\u007c](.+)\r?\n` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\G`|Begin the match where the last match ended.|  
|`(.+)`|Match any character one or more times. This is the first capturing group.|  
|`[\t\u007c]`|Match a tab (`\t`) or a vertical bar (&#124;).|  
|`(.+)`|Match any character one or more times. This is the second capturing group.|  
|`\r?\n`|Match zero or one occurrence of a carriage return followed by a new line.|  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
