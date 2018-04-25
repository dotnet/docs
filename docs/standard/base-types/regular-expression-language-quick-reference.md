---
title: "Regular Expression Language - Quick Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "VS.RegularExpressionBuilder"
helpviewer_keywords: 
  - "regex cheat sheet"
  - "parsing text with regular expressions, language elements"
  - "searching with regular expressions, language elements"
  - "pattern-matching with regular expressions, language elements"
  - "regular expressions, language elements"
  - "regular expressions [.NET Framework]"
  - "cheat sheet"
  - ".NET Framework regular expressions, language elements"
ms.assetid: 930653a6-95d2-4697-9d5a-52d11bb6fd4c
caps.latest.revision: 56
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Regular Expression Language - Quick Reference
<a name="top"></a> A regular expression is a pattern that the regular expression engine attempts to match in input text. A pattern consists of one or more character literals, operators, or constructs.  For a brief introduction, see [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md).  
  
 Each section in this quick reference lists a particular category of characters, operators, and constructs that you can use to define regular expressions:  
  
 [Character escapes](#character_escapes)  
 [Character classes](#character_classes)  
 [Anchors](#atomic_zerowidth_assertions)  
 [Grouping constructs](#grouping_constructs)  
 [Quantifiers](#quantifiers)  
 [Backreference constructs](#backreference_constructs)  
 [Alternation constructs](#alternation_constructs)  
 [Substitutions](#substitutions)  
 [Regular expression options](#options)  
 [Miscellaneous constructs](#miscellaneous_constructs)  
  
 We’ve also provided this information in two formats that you can download and print for easy reference:  
  
 [Download in Word (.docx) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)  
 [Download in PDF (.pdf) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)  
  
<a name="character_escapes"></a>   
## Character Escapes  
 The backslash character (\\) in a regular expression indicates that the character that follows it either is a special character (as shown in the following table), or should be interpreted literally. For more information, see [Character Escapes](../../../docs/standard/base-types/character-escapes-in-regular-expressions.md).  
  
|Escaped character|Description|Pattern|Matches|  
|-----------------------|-----------------|-------------|-------------|  
|`\a`|Matches a bell character, \u0007.|`\a`|"\u0007" in "Error!" + '\u0007'|  
|`\b`|In a character class, matches a backspace, \u0008.|`[\b]{3,}`|"\b\b\b\b" in "\b\b\b\b"|  
|`\t`|Matches a tab, \u0009.|`(\w+)\t`|"item1\t", "item2\t" in "item1\titem2\t"|  
|`\r`|Matches a carriage return, \u000D. (`\r` is not equivalent to the newline character, `\n`.)|`\r\n(\w+)`|"\r\nThese" in "\r\nThese are\ntwo lines."|  
|`\v`|Matches a vertical tab, \u000B.|`[\v]{2,}`|"\v\v\v" in "\v\v\v"|  
|`\f`|Matches a form feed, \u000C.|`[\f]{2,}`|"\f\f\f" in "\f\f\f"|  
|`\n`|Matches a new line, \u000A.|`\r\n(\w+)`|"\r\nThese" in "\r\nThese are\ntwo lines."|  
|`\e`|Matches an escape, \u001B.|`\e`|"\x001B" in "\x001B"|  
|`\` *nnn*|Uses octal representation to specify a character (*nnn* consists of two or three digits).|`\w\040\w`|"a b", "c d" in<br /><br /> "a bc d"|  
|`\x` *nn*|Uses hexadecimal representation to specify a character (*nn* consists of exactly two digits).|`\w\x20\w`|"a b", "c d" in<br /><br /> "a bc d"|  
|`\c` *X*<br /><br /> `\c` *x*|Matches the ASCII control character that is specified by *X* or *x*, where *X* or *x* is the letter of the control character.|`\cC`|"\x0003" in "\x0003" (Ctrl-C)|  
|`\u` *nnnn*|Matches a Unicode character by using hexadecimal representation (exactly four digits, as represented by *nnnn*).|`\w\u0020\w`|"a b", "c d" in<br /><br /> "a bc d"|  
|`\`|When followed by a character that is not recognized as an escaped character in this and other tables in this topic, matches that character. For example, `\*` is the same as `\x2A`, and `\.` is the same as `\x2E`. This allows the regular expression engine to disambiguate language elements (such as \* or ?) and character literals (represented by `\*` or `\?`).|`\d+[\+-x\*]\d+`|"2+2" and "3\*9" in "(2+2) \* 3\*9"|  
  
 [Back to top](#top)  
  
<a name="character_classes"></a>   
## Character Classes  
 A character class matches any one of a set of characters. Character classes include the language elements listed in the following table. For more information, see [Character Classes](../../../docs/standard/base-types/character-classes-in-regular-expressions.md).  
  
|Character class|Description|Pattern|Matches|  
|---------------------|-----------------|-------------|-------------|  
|`[` *character_group* `]`|Matches any single character in *character_group*. By default, the match is case-sensitive.|`[ae]`|"a" in "gray"<br /><br /> "a", "e" in "lane"|  
|`[^` *character_group* `]`|Negation: Matches any single character that is not in *character_group*. By default, characters in *character_group* are case-sensitive.|`[^aei]`|"r", "g", "n" in "reign"|  
|`[` *first* `-` *last* `]`|Character range: Matches any single character in the range from *first* to *last*.|`[A-Z]`|"A", "B" in "AB123"|  
|`.`|Wildcard: Matches any single character except \n.<br /><br /> To match a literal period character (. or `\u002E`), you must precede it with the escape character (`\.`).|`a.e`|"ave" in "nave"<br /><br /> "ate" in "water"|  
|`\p{` *name* `}`|Matches any single character in the Unicode general category or named block specified by *name*.|`\p{Lu}`<br /><br /> `\p{IsCyrillic}`|"C", "L" in "City Lights"<br /><br /> "Д", "Ж" in "ДЖem"|  
|`\P{` *name* `}`|Matches any single character that is not in the Unicode general category or named block specified by *name*.|`\P{Lu}`<br /><br /> `\P{IsCyrillic}`|"i", "t", "y" in "City"<br /><br /> "e", "m" in "ДЖem"|  
|`\w`|Matches any word character.|`\w`|"I", "D", "A", "1", "3" in "ID A1.3"|  
|`\W`|Matches any non-word character.|`\W`|" ", "." in "ID A1.3"|  
|`\s`|Matches any white-space character.|`\w\s`|"D " in "ID A1.3"|  
|`\S`|Matches any non-white-space character.|`\s\S`|" _" in "int \__ctr"|  
|`\d`|Matches any decimal digit.|`\d`|"4" in "4 = IV"|  
|`\D`|Matches any character other than a decimal digit.|`\D`|" ", "=", " ", "I", "V" in "4 = IV"|  
  
 [Back to top](#top)  
  
<a name="atomic_zerowidth_assertions"></a>   
## Anchors  
 Anchors, or atomic zero-width assertions, cause a match to succeed or fail depending on the current position in the string, but they do not cause the engine to advance through the string or consume characters. The metacharacters listed in the following table are anchors. For more information, see [Anchors](../../../docs/standard/base-types/anchors-in-regular-expressions.md).  
  
|Assertion|Description|Pattern|Matches|  
|---------------|-----------------|-------------|-------------|  
|`^`|The match must start at the beginning of the string or line.|`^\d{3}`|"901" in<br /><br /> "901-333-"|  
|`$`|The match must occur at the end of the string or before `\n` at the end of the line or string.|`-\d{3}$`|"-333" in<br /><br /> "-901-333"|  
|`\A`|The match must occur at the start of the string.|`\A\d{3}`|"901" in<br /><br /> "901-333-"|  
|`\Z`|The match must occur at the end of the string or before `\n` at the end of the string.|`-\d{3}\Z`|"-333" in<br /><br /> "-901-333"|  
|`\z`|The match must occur at the end of the string.|`-\d{3}\z`|"-333" in<br /><br /> "-901-333"|  
|`\G`|The match must occur at the point where the previous match ended.|`\G\(\d\)`|"(1)", "(3)", "(5)" in "(1)(3)(5)[7](9\)"|  
|`\b`|The match must occur on a boundary between a `\w` (alphanumeric) and a `\W` (nonalphanumeric) character.|`\b\w+\s\w+\b`|"them theme", "them them" in "them theme them them"|  
|`\B`|The match must not occur on a `\b` boundary.|`\Bend\w*\b`|"ends", "ender" in "end sends endure lender"|  
  
 [Back to top](#top)  
  
<a name="grouping_constructs"></a>   
## Grouping Constructs  
 Grouping constructs delineate subexpressions of a regular expression and typically capture substrings of an input string. Grouping constructs include the language elements listed in the following table. For more information, see [Grouping Constructs](grouping-constructs-in-regular-expressions.md).  
  
|Grouping construct|Description|Pattern|Matches|  
|------------------------|-----------------|-------------|-------------|  
|`(` *subexpression* `)`|Captures the matched subexpression and assigns it a one-based ordinal number.|`(\w)\1`|"ee" in "deep"|  
|`(?<` *name* `>` *subexpression* `)`|Captures the matched subexpression into a named group.|`(?<double>\w)\k<double>`|"ee" in "deep"|  
|`(?<` *name1* `-` *name2* `>` *subexpression* `)`|Defines a balancing group definition. For more information, see the "Balancing Group Definition" section in [Grouping Constructs](grouping-constructs-in-regular-expressions.md).|`(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*(?(Open)(?!))$`|"((1-3)\*(3-1))" in "3+2^((1-3)\*(3-1))"|  
|`(?:` *subexpression* `)`|Defines a noncapturing group.|`Write(?:Line)?`|"WriteLine" in "Console.WriteLine()"<br /><br /> "Write" in "Console.Write(value)"|  
|`(?imnsx-imnsx:` *subexpression* `)`|Applies or disables the specified options within *subexpression*. For more information, see [Regular Expression Options](regular-expression-options.md).|`A\d{2}(?i:\w+)\b`|"A12xl", "A12XL" in "A12xl A12XL a12xl"|  
|`(?=` *subexpression* `)`|Zero-width positive lookahead assertion.|`\w+(?=\.)`|"is", "ran", and "out" in "He is. The dog ran. The sun is out."|  
|`(?!` *subexpression* `)`|Zero-width negative lookahead assertion.|`\b(?!un)\w+\b`|"sure", "used" in "unsure sure unity used"|  
|`(?<=` *subexpression* `)`|Zero-width positive lookbehind assertion.|`(?<=19)\d{2}\b`|"99", "50", "05" in "1851 1999 1950 1905 2003"|  
|`(?<!` *subexpression* `)`|Zero-width negative lookbehind assertion.|`(?<!19)\d{2}\b`|"51", "03" in "1851 1999 1950 1905 2003"|  
|`(?>` *subexpression* `)`|Nonbacktracking (or "greedy") subexpression.|`[13579](?>A+B+)`|"1ABB", "3ABB", and "5AB" in "1ABB 3ABBC 5AB 5AC"|  
  
 [Back to top](#top)  
  
<a name="quantifiers"></a>   
## Quantifiers  
 A quantifier specifies how many instances of the previous element (which can be a character, a group, or a character class) must be present in the input string for a match to occur. Quantifiers include the language elements listed in the following table. For more information, see [Quantifiers](quantifiers-in-regular-expressions.md).  
  
|Quantifier|Description|Pattern|Matches|  
|----------------|-----------------|-------------|-------------|  
|`*`|Matches the previous element zero or more times.|`\d*\.\d`|".0", "19.9", "219.9"|  
|`+`|Matches the previous element one or more times.|`"be+"`|"bee" in "been", "be" in "bent"|  
|`?`|Matches the previous element zero or one time.|`"rai?n"`|"ran", "rain"|  
|`{` *n* `}`|Matches the previous element exactly *n* times.|`",\d{3}"`|",043" in "1,043.6", ",876", ",543", and ",210" in "9,876,543,210"|  
|`{` *n* `,}`|Matches the previous element at least *n* times.|`"\d{2,}"`|"166", "29", "1930"|  
|`{` *n* `,` *m* `}`|Matches the previous element at least *n* times, but no more than *m* times.|`"\d{3,5}"`|"166", "17668"<br /><br /> "19302" in "193024"|  
|`*?`|Matches the previous element zero or more times, but as few times as possible.|`\d*?\.\d`|".0", "19.9", "219.9"|  
|`+?`|Matches the previous element one or more times, but as few times as possible.|`"be+?"`|"be" in "been", "be" in "bent"|  
|`??`|Matches the previous element zero or one time, but as few times as possible.|`"rai??n"`|"ran", "rain"|  
|`{` *n* `}?`|Matches the preceding element exactly *n* times.|`",\d{3}?"`|",043" in "1,043.6", ",876", ",543", and ",210" in "9,876,543,210"|  
|`{` *n* `,}?`|Matches the previous element at least *n* times, but as few times as possible.|`"\d{2,}?"`|"166", "29", "1930"|  
|`{` *n* `,` *m* `}?`|Matches the previous element between *n* and *m* times, but as few times as possible.|`"\d{3,5}?"`|"166", "17668"<br /><br /> "193", "024" in "193024"|  
  
 [Back to top](#top)  
  
<a name="backreference_constructs"></a>   
## Backreference Constructs  
 A backreference allows a previously matched subexpression to be identified subsequently in the same regular expression. The following table lists the backreference constructs supported by regular expressions in .NET. For more information, see [Backreference Constructs](backreference-constructs-in-regular-expressions.md).  
  
|Backreference construct|Description|Pattern|Matches|  
|-----------------------------|-----------------|-------------|-------------|  
|`\` *number*|Backreference. Matches the value of a numbered subexpression.|`(\w)\1`|"ee" in "seek"|  
|`\k<` *name* `>`|Named backreference. Matches the value of a named expression.|`(?<char>\w)\k<char>`|"ee" in "seek"|  
  
 [Back to top](#top)  
  
<a name="alternation_constructs"></a>   
## Alternation Constructs  
 Alternation constructs modify a regular expression to enable either/or matching. These constructs include the language elements listed in the following table. For more information, see [Alternation Constructs](alternation-constructs-in-regular-expressions.md).  
  
|Alternation construct|Description|Pattern|Matches|  
|---------------------------|-----------------|-------------|-------------|  
|<code>&#124;</code>|Matches any one element separated by the vertical bar (&#124;) character.|<code>th(e&#124;is&#124;at)</code>|"the", "this" in "this is the day. "|  
|`(?(` *expression* `)` *yes* <code>&#124;</code> *no* `)`|Matches *yes* if the regular expression pattern designated by *expression* matches; otherwise, matches the optional *no* part. *expression* is interpreted as a zero-width assertion.|<code>(?(A)A\d{2}\b&#124;\b\d{3}\b)</code>|"A10", "910" in "A10 C103 910"|  
|`(?(` *name* `)` *yes* <code>&#124;</code> *no* `)`|Matches *yes* if *name*, a named or numbered capturing group, has a match; otherwise, matches the optional *no*.|<code>(?&lt;quoted&gt;&quot;)?(?(quoted).+?&quot;&#124;\S+\s)</code>|Dogs.jpg, "Yiska playing.jpg" in "Dogs.jpg "Yiska playing.jpg""|  
  
 [Back to top](#top)  
  
<a name="substitutions"></a>   
## Substitutions  
 Substitutions are regular expression language elements that are supported in replacement patterns. For more information, see [Substitutions](substitutions-in-regular-expressions.md). The metacharacters listed in the following table are atomic zero-width assertions.  
  
|Character|Description|Pattern|Replacement pattern|Input string|Result string|  
|---------------|-----------------|-------------|-------------------------|------------------|-------------------|  
|`$` *number*|Substitutes the substring matched by group *number*.|`\b(\w+)(\s)(\w+)\b`|`$3$2$1`|"one two"|"two one"|  
|`${` *name* `}`|Substitutes the substring matched by the named group *name*.|`\b(?<word1>\w+)(\s)(?<word2>\w+)\b`|`${word2} ${word1}`|"one two"|"two one"|  
|`$$`|Substitutes a literal "$".|`\b(\d+)\s?USD`|`$$$1`|"103 USD"|"$103"|  
|`$&`|Substitutes a copy of the whole match.|`\$?\d*\.?\d+`|`**$&**`|"$1.30"|"\*\*$1.30\*\*"|  
|<code>$`</code>|Substitutes all the text of the input string before the match.|`B+`|<code>$`</code>|"AABBCC"|"AAAACC"|  
|`$'`|Substitutes all the text of the input string after the match.|`B+`|`$'`|"AABBCC"|"AACCCC"|  
|`$+`|Substitutes the last group that was captured.|`B+(C+)`|`$+`|"AABBCCDD"|AACCDD|  
|`$_`|Substitutes the entire input string.|`B+`|`$_`|"AABBCC"|"AAAABBCCCC"|  
  
 [Back to top](#top)  
  
<a name="options"></a>   
## Regular Expression Options  
 You can specify options that control how the regular expression engine interprets a regular expression pattern. Many of these options can be specified either inline (in the regular expression pattern) or as one or more <xref:System.Text.RegularExpressions.RegexOptions> constants. This quick reference lists only inline options. For more information about inline and <xref:System.Text.RegularExpressions.RegexOptions> options, see the article [Regular Expression Options](regular-expression-options.md).  
  
 You can specify an inline option in two ways:  
  
-   By using the [miscellaneous construct](miscellaneous-constructs-in-regular-expressions.md) `(?imnsx-imnsx)`, where a minus sign (-) before an option or set of options turns those options off. For example, `(?i-mn)` turns case-insensitive matching (`i`) on, turns multiline mode (`m`) off, and turns unnamed group captures (`n`) off. The option applies to the regular expression pattern from the point at which the option is defined, and is effective either to the end of the pattern or to the point where another construct reverses the option.  
  
-   By using the [grouping construct](grouping-constructs-in-regular-expressions.md)`(?imnsx-imnsx:`*subexpression*`)`, which defines options for the specified group only.  
  
 The .NET regular expression engine supports the following inline options.  
  
|Option|Description|Pattern|Matches|  
|------------|-----------------|-------------|-------------|  
|`i`|Use case-insensitive matching.|`\b(?i)a(?-i)a\w+\b`|"aardvark", "aaaAuto" in "aardvark AAAuto aaaAuto Adam breakfast"|  
|`m`|Use multiline mode. `^` and `$` match the beginning and end of a line, instead of the beginning and end of a string.|For an example, see the "Multiline Mode" section in [Regular Expression Options](regular-expression-options.md).||  
|`n`|Do not capture unnamed groups.|For an example, see the "Explicit Captures Only" section in [Regular Expression Options](regular-expression-options.md).||  
|`s`|Use single-line mode.|For an example, see the "Single-line Mode" section in [Regular Expression Options](regular-expression-options.md).||  
|`x`|Ignore unescaped white space in the regular expression pattern.|`\b(?x) \d+ \s \w+`|"1 aardvark", "2 cats" in "1 aardvark 2 cats IV centurions"|  
  
 [Back to top](#top)  
  
<a name="miscellaneous_constructs"></a>   
## Miscellaneous Constructs  
 Miscellaneous constructs either modify a regular expression pattern or provide information about it. The following table lists the miscellaneous constructs supported by .NET. For more information, see [Miscellaneous Constructs](miscellaneous-constructs-in-regular-expressions.md).  
  
|Construct|Definition|Example|  
|---------------|----------------|-------------|  
|`(?imnsx-imnsx)`|Sets or disables options such as case insensitivity in the middle of a pattern.For more information, see [Regular Expression Options](regular-expression-options.md).|`\bA(?i)b\w+\b` matches "ABA", "Able" in "ABA Able Act"|  
|`(?#` *comment* `)`|Inline comment. The comment ends at the first closing parenthesis.|`\bA(?#Matches words starting with A)\w+\b`|  
|`#` [to end of line]|X-mode comment. The comment starts at an unescaped `#` and continues to the end of the line.|`(?x)\bA\w+\b#Matches words starting with A`|  
  
## See Also  
 <xref:System.Text.RegularExpressions?displayProperty=nameWithType>  
 <xref:System.Text.RegularExpressions.Regex>  
 [Regular Expressions](regular-expressions.md)  
 [Regular Expression Classes](the-regular-expression-object-model.md)  
 [Regular Expression Examples](regular-expression-examples.md)  
 [Regular Expressions - Quick Reference (download in Word format)](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)  
 [Regular Expressions - Quick Reference (download in PDF format)](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)
