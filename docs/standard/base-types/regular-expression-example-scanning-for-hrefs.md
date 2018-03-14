---
title: "Regular Expression Example: Scanning for HREFs"
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
  - "searching with regular expressions, examples"
  - "parsing text with regular expressions, examples"
  - "regular expressions, examples"
  - ".NET Framework regular expressions, examples"
  - "regular expressions [.NET Framework], examples"
  - "pattern-matching with regular expressions, examples"
ms.assetid: fae2c15b-7adf-4b15-b118-58eb3906994f
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Regular Expression Example: Scanning for HREFs
The following example searches an input string and displays all the href="…" values and their locations in the string.  
  
## The Regex Object  
 Because the `DumpHRefs` method can be called multiple times from user code, it uses the `static` (`Shared` in Visual Basic) <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method. This enables the regular expression engine to cache the regular expression and avoids the overhead of instantiating a new <xref:System.Text.RegularExpressions.Regex> object each time the method is called. A <xref:System.Text.RegularExpressions.Match> object is then used to iterate through all matches in the string.  
  
 [!code-csharp[RegularExpressions.Examples.HREF#1](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.HREF/cs/example.cs#1)]
 [!code-vb[RegularExpressions.Examples.HREF#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.HREF/vb/example.vb#1)]  
  
 The following example then illustrates a call to the `DumpHRefs` method.  
  
 [!code-csharp[RegularExpressions.Examples.HREF#2](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.HREF/cs/example.cs#2)]
 [!code-vb[RegularExpressions.Examples.HREF#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.HREF/vb/example.vb#2)]  
  
 The regular expression pattern `href\s*=\s*(?:["'](?<1>[^"']*)["']|(?<1>\S+))` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`href`|Match the literal string "href". The match is case-insensitive.|  
|`\s*`|Match zero or more white-space characters.|  
|`=`|Match the equals sign.|  
|`\s*`|Match zero or more white-space characters.|  
|<code>(?:\["'\](?<1>\[^"'\]*)"&#124;(?<1>\S+))</code>|Match one of the following without assigning the result to a captured group:<br /> <ul><li><p>A quotation mark or apostrophe, followed by zero or more occurrences of any character other than a quotation mark or apostrophe, followed by a quotation mark or apostrophe. The group named `1` is included in this pattern.</p></li><li><p>One or more non-white-space characters. The group named `1` is included in this pattern.</p></li></ul>|  
|`(?<1>[^"']*)`|Assign zero or more occurrences of any character other than a quotation mark or apostrophe to the capturing group named `1`.|  
|`"(?<1>\S+)`|Assign one or more non-white-space characters to the capturing group named `1`.|  
  
## Match Result Class  
 The results of a search are stored in the <xref:System.Text.RegularExpressions.Match> class, which provides access to all the substrings extracted by the search. It also remembers the string being searched and the regular expression being used, so it can call the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method to perform another search starting where the last one ended.  
  
## Explicitly Named Captures  
 In traditional regular expressions, capturing parentheses are automatically numbered sequentially. This leads to two problems. First, if a regular expression is modified by inserting or removing a set of parentheses, all code that refers to the numbered captures must be rewritten to reflect the new numbering. Second, because different sets of parentheses often are used to provide two alternative expressions for an acceptable match, it might be difficult to determine which of the two expressions actually returned a result.  
  
 To address these problems, the <xref:System.Text.RegularExpressions.Regex> class supports the syntax `(?<name>…)` for capturing a match into a specified slot (the slot can be named using a string or an integer; integers can be recalled more quickly). Thus, alternative matches for the same string all can be directed to the same place. In case of a conflict, the last match dropped into a slot is the successful match. (However, a complete list of multiple matches for a single slot is available. See the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> collection for details.)  
  
## See Also  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)
