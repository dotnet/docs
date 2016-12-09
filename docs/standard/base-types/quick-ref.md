---
title: Regular expression language - quick reference
description: Regular expression language - quick reference
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 8c5dee8c-7bc7-4e6e-aff1-986965c4d98e
---

# Regular expression language - quick reference

A regular expression is a pattern that the regular expression engine attempts to match in input text. A pattern consists of one or more character literals, operators, or constructs. For a brief introduction, see [Regular expressions in .NET](regular-expressions.md). 

Each section in this quick reference lists a particular category of characters, operators, and constructs that you can use to define regular expressions: 

* [Character escapes](#character-escapes)

* [Character classes](#character-classes)
      
* [Anchors](#anchors)
    
* [Grouping constructs](#grouping-constructs)
      
* [Quantifiers](#quantifiers)
    
* [Backreference constructs](#backreference-constructs)
      
* [Alternation constructs](#alternation-constructs)
     
* [Substitutions](#substitutions)
      
* [Regular expression options](#regular-expression-options)
      
* [Miscellaneous constructs](#miscellaneous-constructs)

We’ve also provided this information in two formats that you can download and print for easy reference: 

* [Download in Word (.docx) format](http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)
    
* [Download in PDF (.pdf) format](http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)
    
## Character Escapes

The backslash character (\) in a regular expression indicates that the character that follows it either is a special character (as shown in the following table), or should be interpreted literally. For more information, see [Character escapes in regular expressions](escapes.md). 

Escaped character | Description | Pattern | Matches
----------------- | ----------- | ------- | -------
**\a** | Matches a bell character, \u0007. | `\a` | "\u0007" in "Error!" + '\u0007'
**\b** | In a character class, matches a backspace, \u0008. | `[\b]{3,}` | "\b\b\b\b" in "\b\b\b\b"
**\t** | Matches a tab, \u0009. | `(\w+)\t` | "item1\t", "item2\t" in "item1\titem2\t"
**\r** | Matches a carriage return, \u000D. (**\r** is not equivalent to the newline character, **\n**.) | `\r\n(\w+)` | "\r\nThese" in "\r\nThese are\ntwo lines."
**\v** | Matches a vertical tab, \u000B. | `[\v]{2,}` | "\v\v\v" in "\v\v\v"
**\f** | Matches a form feed, \u000C. | `[\f]{2,}` | "\f\f\f" in "\f\f\f" 
**\n** | Matches a new line, \u000A. | `\r\n(\w+)` | "\r\nThese" in "\r\nThese are\ntwo lines."
**\e** | Matches an escape, \u001B. | `\e` | "\x001B" in "\x001B"
**\**_nnn_ | Uses octal representation to specify a character (*nnn* consists of two or three digits). | `\w\040\w` | "a b", "c d" in "a bc d"
**\x**_nn_ | Uses hexadecimal representation to specify a character (*nn* consists of exactly two digits). | `\w\x20\w` | "a b", "c d" in "a bc d"
**\c**_X_ or **\c**_x_ | Matches the ASCII control character that is specified by *X* or *x*, where *X* or *x* is the letter of the control character. | `\cC` | "\x0003" in "\x0003" (Ctrl-C) 
**\u**_nnnn_ | Matches a Unicode character by using hexadecimal representation (exactly four digits, as represented by *nnnn*). | `\w\u0020\w` | "a b", "c d" in "a bc d"
**\\** | When followed by a character that is not recognized as an escaped character in this and other tables in this topic, matches that character. For example, __\*__ is the same as **\x2A**, and **\.** is the same as **\x2E**. This allows the regular expression engine to disambiguate language elements (such as `*` or `?`) and character literals (represented by `\*` or `\?)`. | `\d+[\+-x\*]\d+` | "2+2" and "3*9" in "(2+2) * 3*9"
 
## Character Classes

A character class matches any one of a set of characters. Character classes include the language elements listed in the following table. For more information, see [Character classes in regular expressions](classes.md).

Character class | Description | Pattern | Matches
--------------- | ----------- | ------- | ------- 
__[__*character_group*__]__ | Matches any single character in character_group. By default, the match is case-sensitive. | `[ae]` | "a" in "gray", "a", "e" in "lane"
__[^__*character_group*__]__ | Negation: Matches any single character that is not in *character_group*. By default, characters in *character_group* are case-sensitive. | `[^aei]` |  "r", "g", "n" in "reign"
__[__*first-last*__]__ | Character range: Matches any single character in the range from *first* to *last*. | `[A-Z]` | "A", "B" in "AB123"
**.** | Wildcard: Matches any single character except \n. To match a literal period character (. or \u002E), you must precede it with the escape character (\.). | `a.e` |  "ave" in "nave", "ate" in "water"
__\p{__*name*__}__ | Matches any single character in the Unicode general category or named block specified by *name*. | `\p{Lu}`, `\p{IsCyrillic}` | "C", "L" in "City Lights", "?", "?" in "??em"
__\P{__*name*__}__ | Matches any single character that is not in the Unicode general category or named block specified by *name*. | `\P{Lu}`, `\P{IsCyrillic}` |` "i", "t", "y" in "City", "e", "m" in "??em"
**\w** | Matches any word character. | `\w` | "I", "D", "A", "1", "3" in "ID A1.3" 
**\W** | Matches any non-word character. | `\W` | " ", "." in "ID A1.3"
**\s** | Matches any white-space character. | `\w\s` | "D " in "ID A1.3"
**\S** | Matches any non-white-space character. | `\s\S` | " _" in "int __ctr" 
**\d** | Matches any decimal digit. | `\d` | "4" in "4 = IV" 
**\D** | Matches any character other than a decimal digit. | `\D` | " ", "=", " ", "I", "V" in "4 = IV" 

## Anchors

Anchors, or atomic zero-width assertions, cause a match to succeed or fail depending on the current position in the string, but they do not cause the engine to advance through the string or consume characters. The metacharacters listed in the following table are anchors. For more information, see [Anchors in regular expressions](anchors.md).

Assertion | Description | Pattern | Matches
--------- | ----------- | ------- | ------- 
**^** | The match must start at the beginning of the string or line. | `^\d{3}` | "901" in "901-333-"
**$** | The match must occur at the end of the string or before **\n** at the end of the line or string. | `-\d{3}$` | "-333" in "-901-333"
**\A** | The match must occur at the start of the string. | `\A\d{3}` | "901" in "901-333-"
**\Z** | The match must occur at the end of the string or before **\n** at the end of the string. | `-\d{3}\Z` | "-333" in "-901-333"
**\z** | The match must occur at the end of the string. | `-\d{3}\z` | "-333" in "-901-333"
**\G** | The match must occur at the point where the previous match ended. | `\G\(\d\)` | "(1)", "(3)", "(5)" in "(1)(3)(5)[7]&#40;9)"
**\b** | The match must occur on a boundary between a **\w** (alphanumeric) and a **\W** (nonalphanumeric) character. | `\b\w+\s\w+\b` | "them theme", "them them" in "them theme them them" 
**\B** | The match must not occur on a **\b** boundary. | `\Bend\w*\b` | "ends", "ender" in "end sends endure lender"

## Grouping Constructs

Grouping constructs delineate subexpressions of a regular expression and typically capture substrings of an input string. Grouping constructs include the language elements listed in the following table. For more information, see [Grouping constructs in regular expressions](grouping.md).

Grouping construct | Description | Pattern | Matches
------------------ | ----------- | ------- | ------- 
**(**_subexpression_**)** | Captures the matched subexpression and assigns it a one-based ordinal number. | `(\w)\1` | "ee" in "deep"
**(?**<name> _subexpression_**)** | Captures the matched subexpression into a named group. | `(?<double>\w)\k<double>` | "ee" in "deep"
**(?**<name1-name2> _subexpression_**)** | Defines a balancing group definition. For more information, see the [Balancing Group Definitions](grouping.md#balancing-group-definitions) section in [Grouping constructs in regular expressions](grouping.md). | `(((?'Open'\()[^\(\)]*)+((?'Close-Open'\))[^\(\)]*)+)*(?(Open)(?!))$` | "((1-3)*(3-1))" in "3+2^((1-3)*(3-1))"
**(?**: subexpression**)** | Defines a noncapturing group. | `Write(?:Line)?` | "WriteLine" in "Console.WriteLine()", "Write" in "Console.Write(value)"
**(?imnsx-imnsx**: _subexpression_**)** | Applies or disables the specified options within _subexpression_. For more information, see [Regular expression options](options.md). | `A\d{2}(?i:\w+)\b` | "A12xl", "A12XL" in "A12xl A12XL a12xl"
**(?**= _subexpression_**)** | Zero-width positive lookahead assertion. | `\w+(?=\.)` | "is", "ran", and "out" in "He is. The dog ran. The sun is out."
**(?!** _subexpression_**)** | Zero-width negative lookahead assertion. | `\b(?!un)\w+\b` | "sure", "used" in "unsure sure unity used"
**(?**<= _subexpression_**)** | Zero-width positive lookbehind assertion. | `(?<=19)\d{2}\b` | "99", "50", "05" in "1851 1999 1950 1905 2003"
**(?**<! _subexpression_**)** | Zero-width negative lookbehind assertion. | `(?<!19)\d{2}\b` | "51", "03" in "1851 1999 1950 1905 2003"
**(?**> _subexpression_**)** | Nonbacktracking (or "greedy") subexpression. | `[13579](?>A+B+)` | "1ABB", "3ABB", and "5AB" in "1ABB 3ABBC 5AB 5AC"

## Quantifiers

A quantifier specifies how many instances of the previous element (which can be a character, a group, or a character class) must be present in the input string for a match to occur. Quantifiers include the language elements listed in the following table. For more information, see [Quantifiers in regular expressions](quantifiers.md).

Quantifier | Description | Pattern | Matches
---------- | ----------- | ------- | -------
__*__ | Matches the previous element zero or more times. | `\d*\.\d` | ".0", "19.9", "219.9"
**+** | Matches the previous element one or more times. | `"be+"` | "bee" in "been", "be" in "bent"
**?** | Matches the previous element zero or one time. | `"rai?n"` | "ran", "rain"
**{**_n_**}** | Matches the previous element exactly *n* times. | `",\d{3}"` | ",043" in "1,043.6", ",876", ",543", and ",210" in "9,876,543,210"
**{**_n_,**}** | Matches the previous element at least *n* times. | `"\d{2,}"` | "166", "29", "1930"
**{**_n_,_m_**}** | Matches the previous element at least *n* times, but no more than *m* times. | `"\d{3,5}"` | "166", "17668"; "19302" in "193024"
__*?__ | Matches the previous element zero or more times, but as few times as possible. | `\d*?\.\d` | ".0", "19.9", "219.9"
**+?** | Matches the previous element one or more times, but as few times as possible. | `"be+?"` | "be" in "been", "be" in "bent"
**??** | Matches the previous element zero or one time, but as few times as possible. | `"rai??n"` | "ran", "rain"
**{**_n_**}?** | Matches the preceding element exactly *n* times. | `",\d{3}?"` | ",043" in "1,043.6", ",876", ",543", and ",210" in "9,876,543,210"
**{**_n_,**}?** | Matches the previous element at least *n* times, but as few times as possible. | `"\d{2,}?"` | "166", "29", "1930"
**{**_n_,_m_**}?** | Matches the previous element between *n* and *m* times, but as few times as possible. | `"\d{3,5}?"` | "166", "17668"; "193", "024" in "193024"

## Backreference Constructs

A backreference allows a previously matched subexpression to be identified subsequently in the same regular expression. The following table lists the backreference constructs supported by regular expressions in the .NET Framework. For more information, see [Backreference constructs in regular expressions](backreference.md).

Backreference construct | Description | Pattern | Matches
----------------------- | ----------- | ------- | -------
**\**_number_ | Backreference. Matches the value of a numbered subexpression. | `(\w)\1	` | "ee" in "seek"
**\k<**_name_**>** | Named backreference. Matches the value of a named expression. | `(?<char>\w)\k<char>` | "ee" in "seek"

## Alternation Constructs

Alternation constructs modify a regular expression to enable either/or matching. These constructs include the language elements listed in the following table. For more information, see [Alternation constructs in regular expressions](alternation.md).

Alternation construct | Description | Pattern | Matches
--------------------- | ----------- | ------- | ------- 
**&#124;** | Matches any one element separated by the vertical bar (*&#124;) character. | `th(e*&#124;is*&#124;at)` | "the", "this" in "this is the day. "
__(?(__*expression*__)__*yes*__&#124;__*no*__)__ | Matches *yes* if the regular expression pattern designated by *expression* matches; otherwise, matches the optional *no* part. *expression* is interpreted as a zero-width assertion. | `(?(A)A\d{2}\b*&#124;\b\d{3}\b)` | "A10", "910" in "A10 C103 910"
**(?(**_name_**)**_yes_&#124;_no_**)** | Matches *yes* if *name*, a named or numbered capturing group, has a match; otherwise, matches the optional *no*. | `(?<quoted>")?(?,(quoted).+?"*&#124;\S+\s)` | Dogs.jpg, "Yiska playing.jpg" in "Dogs.jpg "Yiska playing.jpg""

## Substitutions

Substitutions are regular expression language elements that are supported in replacement patterns. For more information, see [Substitutions in regular expressions](substitutions.md). The metacharacters listed in the following table are atomic zero-width assertions.

Character | Description | Pattern | Replacement pattern | Input string | Result string
--------- | ----------- | ------- | ------------------- | ------------ | ------------- 
**$**_number_ | Substitutes the substring matched by group *number*. | `\b(\w+)(\s)(\w+)\b` | `$3$2$1` | "one two" | "two one"
**${**_name_**}** | Substitutes the substring matched by the named group *name*. | `\b(?<word1>\w+)(\s)(?<word2>\w+)\b` | `${word2} ${word1}` | "one two" | "two one"
**$$** | Substitutes a literal "$". | `\b(\d+)\s?USD` | `$$$1` | "103 USD" | "$103"
**$&** | Substitutes a copy of the whole match. | `\$?\d*\.?\d+` | `**$&**` | "$1.30" | "**$1.30**"
**$`** | Substitutes all the text of the input string before the match. | `B+` | `$`` | "AABBCC" | "AAAACC"
**$'** | Substitutes all the text of the input string after the match. | `B+` | `$'` | "AABBCC" | "AACCCC"
**$+** | Substitutes the last group that was captured. | `B+(C+)` | `$+` | "AABBCCDD" | "AACCDD"
**$_** | Substitutes the entire input string. | `B+` | `$_` | "AABBCC" | "AAAABBCCCC"

## Regular Expression Options

You can specify options that control how the regular expression engine interprets a regular expression pattern. Many of these options can be specified either inline (in the regular expression pattern) or as one or more `RegexOptions` constants. This quick reference lists only inline options. For more information about inline and `RegexOptions` options, see the article [Regular expression options](options.md). 

You can specify an inline option in two ways:

* By using the miscellaneous construct **(?imnsx-imnsx)**, where a minus sign (-) before an option or set of options turns those options off. For example, **(?i-mn)** turns case-insensitive matching (i) on, turns multiline mode (**m**) off, and turns unnamed group captures (**n**) off. The option applies to the regular expression pattern from the point at which the option is defined, and is effective either to the end of the pattern or to the point where another construct reverses the option.

* By using the grouping construct **(?imnsx-imnsx:**_subexpression_**)**, which defines options for the specified group only.

The .NET regular expression engine supports the following inline options.

Option | Description | Pattern | Matches
------ | ----------- | ------- | ------- 
**i** | Use case-insensitive matching. | **\b(?i)a(?-i)a\w+\b** | "aardvark", "aaaAuto" in "aardvark AAAuto aaaAuto Adam breakfast" 
**m** | Use multiline mode. **^** and **$** match the beginning and end of a line, instead of the beginning and end of a string. | For an example, see the "Multiline Mode" section in [Regular expression options](options.md). | 
**n*** | Do not capture unnamed groups. | For an example, see the "Explicit Captures Only" section in [Regular expression options](options.md). | 
**s** | Use single-line mode. | For an example, see the "Single-line Mode" section in [Regular expression options](options.md). | 
**x** | Ignore unescaped white space in the regular expression pattern. | **\b(?x) \d+ \s \w+** | "1 aardvark", "2 cats" in "1 aardvark 2 cats IV centurions" 

##Miscellaneous Constructs

Miscellaneous constructs either modify a regular expression pattern or provide information about it. The following table lists the miscellaneous constructs supported by the .NET. For more information, see [Miscellaneous Constructs in Regular Expressions](miscellaneous.md).

Construct | Definition | Example
--------- | ---------- | ------- 
**(?imnsx-imnsx)** | Sets or disables options such as case insensitivity in the middle of a pattern. For more information, see [Regular expression options](options.md). | `\bA(?i)b\w+\b` matches "ABA", "Able" in "ABA Able Act"
**(?#** _comment_**)** | Inline comment. The comment ends at the first closing parenthesis. | `\bA(?#` matches words starting with `A)\w+\b`
**#** [to end of line] | X-mode comment. The comment starts at an unescaped # and continues to the end of the line. | `(?x)\bA\w+\b#` matches words starting with `A`

## See Also




[System.Text.RegularExpressions](xref:System.Text.RegularExpressions)

[Regex](xref:System.Text.RegularExpressions.Regex)

[Regular expressions in .NET](regular-expressions.md)

[The regular expression object model](object-model.md)

[Regular expression examples](regex-examples.md)

[Download in Word (.docx) format](http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)
    
[Download in PDF (.pdf) format](http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)
