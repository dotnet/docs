---
title: "Character Classes in Regular Expressions"
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
  - "character classes"
  - "regular expressions, character classes"
  - "characters, matching syntax"
  - ".NET Framework regular expressions, character classes"
ms.assetid: 0f8bffab-ee0d-4e0e-9a96-2b4a252bb7e4
caps.latest.revision: 58
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Character Classes in Regular Expressions
<a name="Top"></a> A character class defines a set of characters, any one of which can occur in an input string for a match to succeed. The regular expression language in .NET supports the following character classes:  
  
-   Positive character groups. A character in the input string must match one of a specified set of characters. For more information, see [Positive Character Group](#PositiveGroup).  
  
-   Negative character groups. A character in the input string must not match one of a specified set of characters. For more information, see [Negative Character Group](#NegativeGroup).  
  
-   Any character. The `.` (dot or period) character in a regular expression is a wildcard character that matches any character except `\n`. For more information, see [Any Character](#AnyCharacter).  
  
-   A general Unicode category or named block. A character in the input string must be a member of a particular Unicode category or must fall within a contiguous range of Unicode characters for a match to succeed. For more information, see [Unicode Category or Unicode Block](#CategoryOrBlock).  
  
-   A negative general Unicode category or named block. A character in the input string must not be a member of a particular Unicode category or must not fall within a contiguous range of Unicode characters for a match to succeed. For more information, see [Negative Unicode Category or Unicode Block](#NegativeCategoryOrBlock).  
  
-   A word character. A character in the input string can belong to any of the Unicode categories that are appropriate for characters in words. For more information, see [Word Character](#WordCharacter).  
  
-   A non-word character. A character in the input string can belong to any Unicode category that is not a word character. For more information, see [Non-Word Character](#NonWordCharacter).  
  
-   A white-space character. A character in the input string can be any Unicode separator character, as well as any one of a number of control characters. For more information, see [White-Space Character](#WhitespaceCharacter).  
  
-   A non-white-space character. A character in the input string can be any character that is not a white-space character. For more information, see [Non-White-Space Character](#NonWhitespaceCharacter).  
  
-   A decimal digit. A character in the input string can be any of a number of characters classified as Unicode decimal digits. For more information, see [Decimal Digit Character](#DigitCharacter).  
  
-   A non-decimal digit. A character in the input string can be anything other than a Unicode decimal digit. For more information, see [Decimal Digit Character](#NonDigitCharacter).  
  
 .NET supports character class subtraction expressions, which enables you to define a set of characters as the result of excluding one character class from another character class. For more information, see [Character Class Subtraction](#CharacterClassSubtraction).  
  
> [!NOTE]
>  Character classes that match characters by category, such as [\w](#WordCharacter) to match word characters or [\p{}](#CategoryOrBlock) to match a Unicode category, rely on the <xref:System.Globalization.CharUnicodeInfo> class to provide information about character categories.  Starting with the [!INCLUDE[net_v462](../../../includes/net-v462-md.md)], character categories are based on [The Unicode Standard, Version 8.0.0](https://www.unicode.org/versions/Unicode8.0.0/). In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] through the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], they are based on [The Unicode Standard, Version 6.3.0](https://www.unicode.org/versions/Unicode6.3.0/).  
  
<a name="PositiveGroup"></a>   
## Positive Character Group: [ ]  
 A positive character group specifies a list of characters, any one of which may appear in an input string for a match to occur. This list of characters may be specified individually, as a range, or both.  
  
 The syntax for specifying a list of individual characters is as follows:  
  
 [*character_group*]  
  
 where *character_group* is a list of the individual characters that can appear in the input string for a match to succeed. *character_group* can consist of any combination of one or more literal characters, [escape characters](../../../docs/standard/base-types/character-escapes-in-regular-expressions.md), or character classes.  
  
 The syntax for specifying a range of characters is as follows:  
  
```  
[firstCharacter-lastCharacter]  
```  
  
 where *firstCharacter* is the character that begins the range and *lastCharacter* is the character that ends the range. A character range is a contiguous series of characters defined by specifying the first character in the series, a hyphen (-), and then the last character in the series. Two characters are contiguous if they have adjacent Unicode code points.  
  
 Some common regular expression patterns that contain positive character classes are listed in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`[aeiou]`|Match all vowels.|  
|`[\p{P}\d]`|Match all punctuation and decimal digit characters.|  
|`[\s\p{P}]`|Match all white space and punctuation.|  
  
 The following example defines a positive character group that contains the characters "a" and "e" so that the input string must contain the words "grey" or "gray" followed by another word for a match to occur.  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/positivecharclasses.cs#1)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/positivecharclasses.vb#1)]  
  
 The regular expression `gr[ae]y\s\S+?[\s|\p{P}]` is defined as follows:  
  
|Pattern|Description|  
|-------------|-----------------|  
|`gr`|Match the literal characters "gr".|  
|`[ae]`|Match either an "a" or an "e".|  
|`y\s`|Match the literal character "y" followed by a white-space character.|  
|`\S+?`|Match one or more non-white-space characters, but as few as possible.|  
|`[\s\p{P}]`|Match either a white-space character or a punctuation mark.|  
  
 The following example matches words that begin with any capital letter. It uses the subexpression `[A-Z]` to represent the range of capital letters from A to Z.  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/range.cs#3)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/range.vb#3)]  
  
 The regular expression `\b[A-Z]\w*\b` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`[A-Z]`|Match any uppercase character from A to Z.|  
|`\w*`|Match zero or more word characters.|  
|`\b`|Match a word boundary.|  
  
 [Back to Top](#Top)  
  
<a name="NegativeGroup"></a>   
## Negative Character Group: [^]  
 A negative character group specifies a list of characters that must not appear in an input string for a match to occur. The list of characters may be specified individually, as a range, or both.  
  
 The syntax for specifying a list of individual characters is as follows:  
  
 [*^character_group*]  
  
 where *character_group* is a list of the individual characters that cannot appear in the input string for a match to succeed. *character_group* can consist of any combination of one or more literal characters, [escape characters](../../../docs/standard/base-types/character-escapes-in-regular-expressions.md), or character classes.  
  
 The syntax for specifying a range of characters is as follows:  
  
 [^*firstCharacter*-*lastCharacter*]  
  
 where *firstCharacter* is the character that begins the range, and *lastCharacter* is the character that ends the range. A character range is a contiguous series of characters defined by specifying the first character in the series, a hyphen (-), and then the last character in the series. Two characters are contiguous if they have adjacent Unicode code points.  
  
 Two or more character ranges can be concatenated. For example, to specify the range of decimal digits from "0" through "9", the range of lowercase letters from "a" through "f", and the range of uppercase letters from "A" through "F", use `[0-9a-fA-F]`.  
  
 The leading carat character (`^`) in a negative character group is mandatory and indicates the character group is a negative character group instead of a positive character group.  
  
> [!IMPORTANT]
>  A negative character group in a larger regular expression pattern is not a zero-width assertion. That is, after evaluating the negative character group, the regular expression engine advances one character in the input string.  
  
 Some common regular expression patterns that contain negative character groups are listed in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`[^aeiou]`|Match all characters except vowels.|  
|`[^\p{P}\d]`|Match all characters except punctuation and decimal digit characters.|  
  
 The following example matches any word that begins with the characters "th" and is not followed by an "o".  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/negativecharclasses.cs#2)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/negativecharclasses.vb#2)]  
  
 The regular expression `\bth[^o]\w+\b` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`th`|Match the literal characters "th".|  
|`[^o]`|Match any character that is not an "o".|  
|`\w+`|Match one or more word characters.|  
|`\b`|End at a word boundary.|  
  
 [Back to Top](#Top)  
  
<a name="AnyCharacter"></a>   
## Any Character: .  
 The period character (.) matches any character except `\n` (the newline character, \u000A), with the following two qualifications:  
  
-   If a regular expression pattern is modified by the <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option, or if the portion of the pattern that contains the `.` character class is modified by the `s` option, `.` matches any character. For more information, see [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
     The following example illustrates the different behavior of the `.` character class by default and with the <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option. The regular expression `^.+` starts at the beginning of the string and matches every character. By default, the match ends at the end of the first line; the regular expression pattern matches the carriage return character, `\r` or \u000D, but it does not match `\n`. Because the <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option interprets the entire input string as a single line, it matches every character in the input string, including `\n`.  
  
     [!code-csharp[Conceptual.Regex.Language.CharacterClasses#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/any2.cs#5)]
     [!code-vb[Conceptual.Regex.Language.CharacterClasses#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/any2.vb#5)]  
  
> [!NOTE]
>  Because it matches any character except `\n`, the `.` character class also matches `\r` (the carriage return character, \u000D).  
  
-   In a positive or negative character group, a period is treated as a literal period character, and not as a character class. For more information, see [Positive Character Group](#PositiveGroup) and [Negative Character Group](#NegativeGroup) earlier in this topic. The following example provides an illustration by defining a regular expression that includes the period character (`.`) both as a character class and as a member of a positive character group. The regular expression `\b.*[.?!;:](\s|\z)` begins at a word boundary, matches any character until it encounters one of four punctuation marks, including a period, and then matches either a white-space character or the end of the string.  
  
     [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/any1.cs#4)]
     [!code-vb[Conceptual.RegEx.Language.CharacterClasses#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/any1.vb#4)]  
  
> [!NOTE]
>  Because it matches any character, the `.` language element is often used with a lazy quantifier if a regular expression pattern attempts to match any character multiple times. For more information, see [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md).  
  
 [Back to Top](#Top)  
  
<a name="CategoryOrBlock"></a>   
## Unicode Category or Unicode Block: \p{}  
 The Unicode standard assigns each character a general category. For example, a particular character can be an uppercase letter (represented by the `Lu` category), a decimal digit (the `Nd` category), a math symbol (the `Sm` category), or a paragraph separator (the `Zl` category). Specific character sets in the Unicode standard also occupy a specific range or block of consecutive code points. For example, the basic Latin character set is found from \u0000 through \u007F, while the Arabic character set is found from \u0600 through \u06FF.  
  
 The regular expression construct  
  
 `\p{` *name* `}`  
  
 matches any character that belongs to a Unicode general category or named block, where *name* is the category abbreviation or named block name. For a list of category abbreviations, see the [Supported Unicode General Categories](#SupportedUnicodeGeneralCategories) section later in this topic. For a list of named blocks, see the [Supported Named Blocks](#SupportedNamedBlocks) section later in this topic.  
  
 The following example uses the `\p{`*name*`}` construct to match both a Unicode general category (in this case, the `Pd`, or Punctuation,Dash category) and a named block (the `IsGreek` and `IsBasicLatin` named blocks).  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/category1.cs#6)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/category1.vb#6)]  
  
 The regular expression `\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Start at a word boundary.|  
|`\p{IsGreek}+`|Match one or more Greek characters.|  
|`(\s)?`|Match zero or one white-space character.|  
|`(\p{IsGreek}+(\s)?)+`|Match the pattern of one or more Greek characters followed by zero or one white-space characters one or more times.|  
|`\p{Pd}`|Match a Punctuation, Dash character.|  
|`\s`|Match a white-space character.|  
|`\p{IsBasicLatin}+`|Match one or more basic Latin characters.|  
|`(\s)?`|Match zero or one white-space character.|  
|`(\p{IsBasicLatin}+(\s)?)+`|Match the pattern of one or more basic Latin characters followed by zero or one white-space characters one or more times.|  
  
 [Back to Top](#Top)  
  
<a name="NegativeCategoryOrBlock"></a>   
## Negative Unicode Category or Unicode Block: \P{}  
 The Unicode standard assigns each character a general category. For example, a particular character can be an uppercase letter (represented by the `Lu` category), a decimal digit (the `Nd` category), a math symbol (the `Sm` category), or a paragraph separator (the `Zl` category). Specific character sets in the Unicode standard also occupy a specific range or block of consecutive code points. For example, the basic Latin character set is found from \u0000 through \u007F, while the Arabic character set is found from \u0600 through \u06FF.  
  
 The regular expression construct  
  
 `\P{` *name* `}`  
  
 matches any character that does not belong to a Unicode general category or named block, where *name* is the category abbreviation or named block name. For a list of category abbreviations, see the [Supported Unicode General Categories](#SupportedUnicodeGeneralCategories) section later in this topic. For a list of named blocks, see the [Supported Named Blocks](#SupportedNamedBlocks) section later in this topic.  
  
 The following example uses the `\P{`*name*`}` construct to remove any currency symbols (in this case, the `Sc`, or Symbol, Currency category) from numeric strings.  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/notcategory1.cs#7)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/notcategory1.vb#7)]  
  
 The regular expression pattern `(\P{Sc})+` matches one or more characters that are not currency symbols; it effectively strips any currency symbol from the result string.  
  
 [Back to Top](#Top)  
  
<a name="WordCharacter"></a>   
## Word Character: \w  
 `\w` matches any word character. A word character is a member of any of the Unicode categories listed in the following table.  
  
|Category|Description|  
|--------------|-----------------|  
|Ll|Letter, Lowercase|  
|Lu|Letter, Uppercase|  
|Lt|Letter, Titlecase|  
|Lo|Letter, Other|  
|Lm|Letter, Modifier|  
|Mn|Mark, Nonspacing|  
|Nd|Number, Decimal Digit|  
|Pc|Punctuation, Connector. This category includes ten characters, the most commonly used of which is the LOWLINE character (_), u+005F.|  
  
 If ECMAScript-compliant behavior is specified, `\w` is equivalent to `[a-zA-Z_0-9]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
> [!NOTE]
>  Because it matches any word character, the `\w` language element is often used with a lazy quantifier if a regular expression pattern attempts to match any word character multiple times, followed by a specific word character. For more information, see [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md).  
  
 The following example uses the `\w` language element to match duplicate characters in a word. The example defines a regular expression pattern, `(\w)\1`, which can be interpreted as follows.  
  
|Element|Description|  
|-------------|-----------------|  
|(\w)|Match a word character. This is the first capturing group.|  
|\1|Match the value of the first capture.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/wordchar1.cs#8)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/wordchar1.vb#8)]  
  
 [Back to Top](#Top)  
  
<a name="NonWordCharacter"></a>   
## Non-Word Character: \W  
 `\W` matches any non-word character. The \W language element is equivalent to the following character class:  
  
```  
[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]  
```  
  
 In other words, it matches any character except for those in the Unicode categories listed in the following table.  
  
|Category|Description|  
|--------------|-----------------|  
|Ll|Letter, Lowercase|  
|Lu|Letter, Uppercase|  
|Lt|Letter, Titlecase|  
|Lo|Letter, Other|  
|Lm|Letter, Modifier|  
|Mn|Mark, Nonspacing|  
|Nd|Number, Decimal Digit|  
|Pc|Punctuation, Connector. This category includes ten characters, the most commonly used of which is the LOWLINE character (_), u+005F.|  
  
 If ECMAScript-compliant behavior is specified, `\W` is equivalent to `[^a-zA-Z_0-9]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
> [!NOTE]
>  Because it matches any non-word character, the `\W` language element is often used with a lazy quantifier if a regular expression pattern attempts to match any non-word character multiple times followed by a specific non-word character. For more information, see [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md).  
  
 The following example illustrates the `\W` character class.  It defines a regular expression pattern, `\b(\w+)(\W){1,2}`, that matches a word followed by one or two non-word characters, such as white space or punctuation. The regular expression is interpreted as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|\b|Begin the match at a word boundary.|  
|(\w+)|Match one or more word characters. This is the first capturing group.|  
|(\W){1,2}|Match a non-word character either one or two times. This is the second capturing group.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/nonwordchar1.cs#9)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/nonwordchar1.vb#9)]  
  
 Because the <xref:System.Text.RegularExpressions.Group> object for the second capturing group contains only a single captured non-word character, the example retrieves all captured non-word characters from the <xref:System.Text.RegularExpressions.CaptureCollection> object that is returned by the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> property.  
  
 [Back to Top](#Top)  
  
<a name="WhitespaceCharacter"></a>   
## White-Space Character: \s  
 `\s` matches any white-space character. It is equivalent to the escape sequences and Unicode categories listed in the following table.  
  
|Category|Description|  
|--------------|-----------------|  
|`\f`|The form feed character, \u000C.|  
|`\n`|The newline character, \u000A.|  
|`\r`|The carriage return character, \u000D.|  
|`\t`|The tab character, \u0009.|  
|`\v`|The vertical tab character, \u000B.|  
|`\x85`|The ellipsis or NEXT LINE (NEL) character (…), \u0085.|  
|`\p{Z}`|Matches any separator character.|  
  
 If ECMAScript-compliant behavior is specified, `\s` is equivalent to `[ \f\n\r\t\v]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
 The following example illustrates the `\s` character class. It defines a regular expression pattern, `\b\w+(e)?s(\s|$)`, that matches a word ending in either "s" or "es" followed by either a white-space character or the end of the input string. The regular expression is interpreted as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|\b|Begin the match at a word boundary.|  
|\w+|Match one or more word characters.|  
|(e)?|Match an "e" either zero or one time.|  
|s|Match an "s".|  
|(\s&#124;$)|Match either a white-space character or the end of the input string.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/whitespace1.cs#10)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/whitespace1.vb#10)]  
  
 [Back to Top](#Top)  
  
<a name="NonWhitespaceCharacter"></a>   
## Non-White-Space Character: \S  
 `\S` matches any non-white-space character. It is equivalent to the `[^\f\n\r\t\v\x85\p{Z}]` regular expression pattern, or the opposite of the regular expression pattern that is equivalent to `\s`, which matches white-space characters. For more information, see [White-Space Character: \s](#WhitespaceCharacter).  
  
 If ECMAScript-compliant behavior is specified, `\S` is equivalent to  `[^ \f\n\r\t\v]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
 The following example illustrates the `\S` language element. The regular expression pattern `\b(\S+)\s?` matches strings that are delimited by white-space characters. The second element in the match's <xref:System.Text.RegularExpressions.GroupCollection> object contains the matched string. The regular expression can be interpreted as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`(\S+)`|Match one or more non-white-space characters. This is the first capturing group.|  
|`\s?`|Match zero or one white-space character.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/nonwhitespace1.cs#11)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/nonwhitespace1.vb#11)]  
  
 [Back to Top](#Top)  
  
<a name="DigitCharacter"></a>   
## Decimal Digit Character: \d  
 `\d` matches any decimal digit. It is equivalent to the `\p{Nd}` regular expression pattern, which includes the standard decimal digits 0-9 as well as the decimal digits of a number of other character sets.  
  
 If ECMAScript-compliant behavior is specified, `\d` is equivalent to  `[0-9]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
 The following example illustrates the `\d` language element. It tests whether an input string represents a valid telephone number in the United States and Canada. The regular expression pattern `^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$` is defined as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|`^`|Begin the match at the beginning of the input string.|  
|`\(?`|Match zero or one literal "(" character.|  
|`\d{3}`|Match three decimal digits.|  
|`\)?`|Match zero or one literal ")" character.|  
|`[\s-]`|Match a hyphen or a white-space character.|  
|`(\(?\d{3}\)?[\s-])?`|Match an optional opening parenthesis followed by three decimal digits, an optional closing parenthesis, and either a white-space character or a hyphen zero or one time. This is the first capturing group.|  
|`\d{3}-\d{4}`|Match three decimal digits followed by a hyphen and four more decimal digits.|  
|`$`|Match the end of the input string.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/digit1.cs#12)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/digit1.vb#12)]  
  
 [Back to Top](#Top)  
  
<a name="NonDigitCharacter"></a>   
## Non-Digit Character: \D  
 `\D` matches any non-digit character. It is equivalent to the `\P{Nd}` regular expression pattern.  
  
 If ECMAScript-compliant behavior is specified, `\D` is equivalent to  `[^0-9]`. For information on ECMAScript regular expressions, see the "ECMAScript Matching Behavior" section in [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md).  
  
 The following example illustrates the \D language element. It tests whether a string such as a part number consists of the appropriate combination of decimal and non-decimal characters. The regular expression pattern `^\D\d{1,5}\D*$` is defined as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|`^`|Begin the match at the beginning of the input string.|  
|`\D`|Match a non-digit character.|  
|`\d{1,5}`|Match from one to five decimal digits.|  
|`\D*`|Match zero, one, or more non-decimal characters.|  
|`$`|Match the end of the input string.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/nondigit1.cs#13)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/nondigit1.vb#13)]  
  
 [Back to Top](#Top)  
  
<a name="SupportedUnicodeGeneralCategories"></a>   
## Supported Unicode General Categories  
 Unicode defines the general categories listed in the following table. For more information, see the "UCD File Format" and "General Category Values" subtopics at the [Unicode Character Database](https://www.unicode.org/reports/tr44/).  
  
|Category|Description|  
|--------------|-----------------|  
|`Lu`|Letter, Uppercase|  
|`Ll`|Letter, Lowercase|  
|`Lt`|Letter, Titlecase|  
|`Lm`|Letter, Modifier|  
|`Lo`|Letter, Other|  
|`L`|All letter characters. This includes the `Lu`, `Ll`, `Lt`, `Lm`, and `Lo` characters.|  
|`Mn`|Mark, Nonspacing|  
|`Mc`|Mark, Spacing Combining|  
|`Me`|Mark, Enclosing|  
|`M`|All diacritic marks. This includes the `Mn`, `Mc`, and `Me` categories.|  
|`Nd`|Number, Decimal Digit|  
|`Nl`|Number, Letter|  
|`No`|Number, Other|  
|`N`|All numbers. This includes the `Nd`, `Nl`, and `No` categories.|  
|`Pc`|Punctuation, Connector|  
|`Pd`|Punctuation, Dash|  
|`Ps`|Punctuation, Open|  
|`Pe`|Punctuation, Close|  
|`Pi`|Punctuation, Initial quote (may behave like Ps or Pe depending on usage)|  
|`Pf`|Punctuation, Final quote (may behave like Ps or Pe depending on usage)|  
|`Po`|Punctuation, Other|  
|`P`|All punctuation characters. This includes the `Pc`, `Pd`, `Ps`, `Pe`, `Pi`, `Pf`, and `Po` categories.|  
|`Sm`|Symbol, Math|  
|`Sc`|Symbol, Currency|  
|`Sk`|Symbol, Modifier|  
|`So`|Symbol, Other|  
|`S`|All symbols. This includes the `Sm`, `Sc`, `Sk`, and `So` categories.|  
|`Zs`|Separator, Space|  
|`Zl`|Separator, Line|  
|`Zp`|Separator, Paragraph|  
|`Z`|All separator characters. This includes the `Zs`, `Zl`, and `Zp` categories.|  
|`Cc`|Other, Control|  
|`Cf`|Other, Format|  
|`Cs`|Other, Surrogate|  
|`Co`|Other, Private Use|  
|`Cn`|Other, Not Assigned (no characters have this property)|  
|`C`|All control characters. This includes the `Cc`, `Cf`, `Cs`, `Co`, and `Cn` categories.|  
  
 You can determine the Unicode category of any particular character by passing that character to the <xref:System.Char.GetUnicodeCategory%2A> method. The following example uses the <xref:System.Char.GetUnicodeCategory%2A> method to determine the category of each element in an array that contains selected Latin characters.  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/getunicodecategory1.cs#14)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/getunicodecategory1.vb#14)]  
  
 [Back to Top](#Top)  
  
<a name="SupportedNamedBlocks"></a>   
## Supported Named Blocks  
 .NET provides the named blocks listed in the following table. The set of supported named blocks is based on Unicode 4.0 and Perl 5.6.  
  
|Code point range|Block name|  
|----------------------|----------------|  
|0000 - 007F|`IsBasicLatin`|  
|0080 - 00FF|`IsLatin-1Supplement`|  
|0100 - 017F|`IsLatinExtended-A`|  
|0180 - 024F|`IsLatinExtended-B`|  
|0250 - 02AF|`IsIPAExtensions`|  
|02B0 - 02FF|`IsSpacingModifierLetters`|  
|0300 - 036F|`IsCombiningDiacriticalMarks`|  
|0370 - 03FF|`IsGreek`<br /><br /> -or-<br /><br /> `IsGreekandCoptic`|  
|0400 - 04FF|`IsCyrillic`|  
|0500 - 052F|`IsCyrillicSupplement`|  
|0530 - 058F|`IsArmenian`|  
|0590 - 05FF|`IsHebrew`|  
|0600 - 06FF|`IsArabic`|  
|0700 - 074F|`IsSyriac`|  
|0780 - 07BF|`IsThaana`|  
|0900 - 097F|`IsDevanagari`|  
|0980 - 09FF|`IsBengali`|  
|0A00 - 0A7F|`IsGurmukhi`|  
|0A80 - 0AFF|`IsGujarati`|  
|0B00 - 0B7F|`IsOriya`|  
|0B80 - 0BFF|`IsTamil`|  
|0C00 - 0C7F|`IsTelugu`|  
|0C80 - 0CFF|`IsKannada`|  
|0D00 - 0D7F|`IsMalayalam`|  
|0D80 - 0DFF|`IsSinhala`|  
|0E00 - 0E7F|`IsThai`|  
|0E80 - 0EFF|`IsLao`|  
|0F00 - 0FFF|`IsTibetan`|  
|1000 - 109F|`IsMyanmar`|  
|10A0 - 10FF|`IsGeorgian`|  
|1100 - 11FF|`IsHangulJamo`|  
|1200 - 137F|`IsEthiopic`|  
|13A0 - 13FF|`IsCherokee`|  
|1400 - 167F|`IsUnifiedCanadianAboriginalSyllabics`|  
|1680 - 169F|`IsOgham`|  
|16A0 - 16FF|`IsRunic`|  
|1700 - 171F|`IsTagalog`|  
|1720 - 173F|`IsHanunoo`|  
|1740 - 175F|`IsBuhid`|  
|1760 - 177F|`IsTagbanwa`|  
|1780 - 17FF|`IsKhmer`|  
|1800 - 18AF|`IsMongolian`|  
|1900 - 194F|`IsLimbu`|  
|1950 - 197F|`IsTaiLe`|  
|19E0 - 19FF|`IsKhmerSymbols`|  
|1D00 - 1D7F|`IsPhoneticExtensions`|  
|1E00 - 1EFF|`IsLatinExtendedAdditional`|  
|1F00 - 1FFF|`IsGreekExtended`|  
|2000 - 206F|`IsGeneralPunctuation`|  
|2070 - 209F|`IsSuperscriptsandSubscripts`|  
|20A0 - 20CF|`IsCurrencySymbols`|  
|20D0 - 20FF|`IsCombiningDiacriticalMarksforSymbols`<br /><br /> -or-<br /><br /> `IsCombiningMarksforSymbols`|  
|2100 - 214F|`IsLetterlikeSymbols`|  
|2150 - 218F|`IsNumberForms`|  
|2190 - 21FF|`IsArrows`|  
|2200 - 22FF|`IsMathematicalOperators`|  
|2300 - 23FF|`IsMiscellaneousTechnical`|  
|2400 - 243F|`IsControlPictures`|  
|2440 - 245F|`IsOpticalCharacterRecognition`|  
|2460 - 24FF|`IsEnclosedAlphanumerics`|  
|2500 - 257F|`IsBoxDrawing`|  
|2580 - 259F|`IsBlockElements`|  
|25A0 - 25FF|`IsGeometricShapes`|  
|2600 - 26FF|`IsMiscellaneousSymbols`|  
|2700 - 27BF|`IsDingbats`|  
|27C0 - 27EF|`IsMiscellaneousMathematicalSymbols-A`|  
|27F0 - 27FF|`IsSupplementalArrows-A`|  
|2800 - 28FF|`IsBraillePatterns`|  
|2900 - 297F|`IsSupplementalArrows-B`|  
|2980 - 29FF|`IsMiscellaneousMathematicalSymbols-B`|  
|2A00 - 2AFF|`IsSupplementalMathematicalOperators`|  
|2B00 - 2BFF|`IsMiscellaneousSymbolsandArrows`|  
|2E80 - 2EFF|`IsCJKRadicalsSupplement`|  
|2F00 - 2FDF|`IsKangxiRadicals`|  
|2FF0 - 2FFF|`IsIdeographicDescriptionCharacters`|  
|3000 - 303F|`IsCJKSymbolsandPunctuation`|  
|3040 - 309F|`IsHiragana`|  
|30A0 - 30FF|`IsKatakana`|  
|3100 - 312F|`IsBopomofo`|  
|3130 - 318F|`IsHangulCompatibilityJamo`|  
|3190 - 319F|`IsKanbun`|  
|31A0 - 31BF|`IsBopomofoExtended`|  
|31F0 - 31FF|`IsKatakanaPhoneticExtensions`|  
|3200 - 32FF|`IsEnclosedCJKLettersandMonths`|  
|3300 - 33FF|`IsCJKCompatibility`|  
|3400 - 4DBF|`IsCJKUnifiedIdeographsExtensionA`|  
|4DC0 - 4DFF|`IsYijingHexagramSymbols`|  
|4E00 - 9FFF|`IsCJKUnifiedIdeographs`|  
|A000 - A48F|`IsYiSyllables`|  
|A490 - A4CF|`IsYiRadicals`|  
|AC00 - D7AF|`IsHangulSyllables`|  
|D800 - DB7F|`IsHighSurrogates`|  
|DB80 - DBFF|`IsHighPrivateUseSurrogates`|  
|DC00 - DFFF|`IsLowSurrogates`|  
|E000 - F8FF|`IsPrivateUse` or `IsPrivateUseArea`|  
|F900 - FAFF|`IsCJKCompatibilityIdeographs`|  
|FB00 - FB4F|`IsAlphabeticPresentationForms`|  
|FB50 - FDFF|`IsArabicPresentationForms-A`|  
|FE00 - FE0F|`IsVariationSelectors`|  
|FE20 - FE2F|`IsCombiningHalfMarks`|  
|FE30 - FE4F|`IsCJKCompatibilityForms`|  
|FE50 - FE6F|`IsSmallFormVariants`|  
|FE70 - FEFF|`IsArabicPresentationForms-B`|  
|FF00 - FFEF|`IsHalfwidthandFullwidthForms`|  
|FFF0 - FFFF|`IsSpecials`|  
  
 [Back to Top](#Top)  
  
<a name="CharacterClassSubtraction"></a>   
## Character Class Subtraction: [base_group - [excluded_group]]  
 A character class defines a set of characters. Character class subtraction yields a set of characters that is the result of excluding the characters in one character class from another character class.  
  
 A character class subtraction expression has the following form:  
  
 `[` *base_group* `-[` *excluded_group* `]]`  
  
 The square brackets (`[]`) and hyphen (`-`) are mandatory. The *base_group* is a [positive character group](#PositiveGroup) or a [negative character group](#NegativeGroup). The *excluded_group* component is another positive or negative character group, or another character class subtraction expression (that is, you can nest character class subtraction expressions).  
  
 For example, suppose you have a base group that consists of the character range from "a" through "z". To define the set of characters that consists of the base group except for the character "m", use `[a-z-[m]]`. To define the set of characters that consists of the base group except for the set of characters "d", "j", and "p", use `[a-z-[djp]]`. To define the set of characters that consists of the base group except for the character range from "m" through "p", use `[a-z-[m-p]]`.  
  
 Consider the nested character class subtraction expression, `[a-z-[d-w-[m-o]]]`. The expression is evaluated from the innermost character range outward. First, the character range from "m" through "o" is subtracted from the character range "d" through "w", which yields the set of characters from "d" through "l" and "p" through "w". That set is then subtracted from the character range from "a" through "z", which yields the set of characters `[abcmnoxyz]`.  
  
 You can use any character class with character class subtraction. To define the set of characters that consists of all Unicode characters from \u0000 through \uFFFF except white-space characters (`\s`), the characters in the punctuation general category (`\p{P}`), the characters in the `IsGreek` named block (`\p{IsGreek}`), and the Unicode NEXT LINE control character (\x85), use `[\u0000-\uFFFF-[\s\p{P}\p{IsGreek}\x85]]`.  
  
 Choose character classes for a character class subtraction expression that will yield useful results. Avoid an expression that yields an empty set of characters, which cannot match anything, or an expression that is equivalent to the original base group. For example, the empty set is the result of the expression `[\p{IsBasicLatin}-[\x00-\x7F]]`, which subtracts all characters in the `IsBasicLatin` character range from the `IsBasicLatin` general category. Similarly, the original base group is the result of the expression `[a-z-[0-9]]`.  This is because the base group, which is the character range of letters from "a" through "z", does not contain any characters in the excluded group, which is the character range of decimal digits from "0" through "9".  
  
 The following example defines a regular expression, `^[0-9-[2468]]+$`, that matches zero and odd digits in an input string.  The regular expression is interpreted as shown in the following table.  
  
|Element|Description|  
|-------------|-----------------|  
|^|Begin the match at the start of the input string.|  
|`[0-9-[2468]]+`|Match one or more occurrences of any character from 0 to 9 except for 2, 4, 6, and 8. In other words, match one or more occurrences of zero or an odd digit.|  
|$|End the match at the end of the input string.|  
  
 [!code-csharp[Conceptual.RegEx.Language.CharacterClasses#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/classsubtraction1.cs#15)]
 [!code-vb[Conceptual.RegEx.Language.CharacterClasses#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/classsubtraction1.vb#15)]  
  
## See Also  
 <xref:System.Char.GetUnicodeCategory%2A>  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)  
 [Regular Expression Options](../../../docs/standard/base-types/regular-expression-options.md)
