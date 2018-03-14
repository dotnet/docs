---
title: "Regular Expression Options"
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
  - "regular expressions, options"
  - "constructs, options"
  - ".NET Framework regular expressions, options"
  - "inline option constructs"
  - "options parameter"
ms.assetid: c82dc689-7e82-4767-a18d-cd24ce5f05e9
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Regular Expression Options
<a name="Top"></a> By default, the comparison of an input string with any literal characters in a regular expression pattern is case sensitive, white space in a regular expression pattern is interpreted as literal white-space characters, and capturing groups in a regular expression are named implicitly as well as explicitly. You can modify these and several other aspects of default regular expression behavior by specifying regular expression options. These options, which are listed in the following table, can be included inline as part of the regular expression pattern, or they can be supplied to a <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class constructor or static pattern matching method as a <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType> enumeration value.  
  
|RegexOptions member|Inline character|Effect|  
|-------------------------|----------------------|------------|  
|<xref:System.Text.RegularExpressions.RegexOptions.None>|Not available|Use default behavior. For more information, see [Default Options](#Default).|  
|<xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase>|`i`|Use case-insensitive matching. For more information, see [Case-Insensitive Matching](#Case).|  
|<xref:System.Text.RegularExpressions.RegexOptions.Multiline>|`m`|Use multiline mode, where `^` and `$` match the beginning and end of each line (instead of the beginning and end of the input string). For more information, see [Multiline Mode](#Multiline).|  
|<xref:System.Text.RegularExpressions.RegexOptions.Singleline>|`s`|Use single-line mode, where the period (.) matches every character (instead of every character except `\n`). For more information, see [Singleline Mode](#Singleline).|  
|<xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture>|`n`|Do not capture unnamed groups. The only valid captures are explicitly named or numbered groups of the form `(?<`*name*`>` *subexpression*`)`. For more information, see [Explicit Captures Only](#Explicit).|  
|<xref:System.Text.RegularExpressions.RegexOptions.Compiled>|Not available|Compile the regular expression to an assembly. For more information, see [Compiled Regular Expressions](#Compiled).|  
|<xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace>|`x`|Exclude unescaped white space from the pattern, and enable comments after a number sign (`#`). For more information, see [Ignore White Space](#Whitespace).|  
|<xref:System.Text.RegularExpressions.RegexOptions.RightToLeft>|Not available|Change the search direction. Search moves from right to left instead of from left to right. For more information, see [Right-to-Left Mode](#RightToLeft).|  
|<xref:System.Text.RegularExpressions.RegexOptions.ECMAScript>|Not available|Enable ECMAScript-compliant behavior for the expression. For more information, see [ECMAScript Matching Behavior](#ECMAScript).|  
|<xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant>|Not available|Ignore cultural differences in language. For more information, see [Comparison Using the Invariant Culture](#Invariant).|  
  
## Specifying the Options  
 You can specify options for regular expressions in one of three ways:  
  
-   In the `options` parameter of a <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class constructor or static (`Shared` in Visual Basic) pattern-matching method, such as <xref:System.Text.RegularExpressions.Regex.%23ctor%28System.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> or <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType>. The `options` parameter is a bitwise OR combination of <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType> enumerated values.  
  
     When options are supplied to a <xref:System.Text.RegularExpressions.Regex> instance by using the `options` parameter of a class constructor, the options are are assigned to the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType> property. However, the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType> property does not reflect inline options in the regular expression pattern itself.  
  
     The following example provides an illustration. It uses the `options` parameter of the <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".  
  
     [!code-csharp[Conceptual.Regex.Language.Options#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/example1.cs#6)]
     [!code-vb[Conceptual.Regex.Language.Options#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/example1.vb#6)]  
  
-   By applying inline options in a regular expression pattern with the syntax `(?imnsx-imnsx)`. The option applies to the pattern from the point that the option is defined to either the end of the pattern or to the point at which the option is undefined by another inline option. Note that the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=nameWithType> property of a <xref:System.Text.RegularExpressions.Regex> instance does not reflect these inline options. For more information, see the [Miscellaneous Constructs](../../../docs/standard/base-types/miscellaneous-constructs-in-regular-expressions.md) topic.  
  
     The following example provides an illustration. It uses inline options to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".  
  
     [!code-csharp[Conceptual.Regex.Language.Options#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/example1.cs#7)]
     [!code-vb[Conceptual.Regex.Language.Options#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/example1.vb#7)]  
  
-   By applying inline options in a particular grouping construct in a regular expression pattern with the syntax `(?imnsx-imnsx:`*subexpression*`)`. No sign before a set of options turns the set on; a minus sign before a set of options turns the set off. (`?` is a fixed part of the language construct's syntax that is required whether options are enabled or disabled.) The option applies only to that group. For more information, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
     The following example provides an illustration. It uses inline options in a grouping construct to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".  
  
     [!code-csharp[Conceptual.Regex.Language.Options#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/example1.cs#8)]
     [!code-vb[Conceptual.Regex.Language.Options#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/example1.vb#8)]  
  
 If options are specified inline, a minus sign (`-`) before an option or set of options turns off those options. For example, the inline construct `(?ix-ms)` turns on the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> options and turns off the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> options. All regular expression options are turned off by default.  
  
> [!NOTE]
>  If the regular expression options specified in the `options` parameter of a constructor or method call conflict with the options specified inline in a regular expression pattern, the inline options are used.  
  
 The following five regular expression options can be set both with the options parameter and inline:  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType>  
  
 The following five regular expression options can be set using the `options` parameter but cannot be set inline:  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant?displayProperty=nameWithType>  
  
-   <xref:System.Text.RegularExpressions.RegexOptions.ECMAScript?displayProperty=nameWithType>  
  
## Determining the Options  
 You can determine which options were provided to a <xref:System.Text.RegularExpressions.Regex> object when it was instantiated by retrieving the value of the read-only <xref:System.Text.RegularExpressions.Regex.Options%2A?displayProperty=nameWithType> property. This property is particularly useful for determining the options that are defined for a compiled regular expression created by the <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> method.  
  
 To test for the presence of any option except <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType>, perform an AND operation with the value of the <xref:System.Text.RegularExpressions.Regex.Options%2A?displayProperty=nameWithType> property and the <xref:System.Text.RegularExpressions.RegexOptions> value in which you are interested. Then test whether the result equals that <xref:System.Text.RegularExpressions.RegexOptions> value. The following example tests whether the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> option has been set.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/determine1.cs#19)]
 [!code-vb[Conceptual.Regex.Language.Options#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/determine1.vb#19)]  
  
 To test for <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType>, determine whether the value of the <xref:System.Text.RegularExpressions.Regex.Options%2A?displayProperty=nameWithType> property is equal to <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType>, as the following example illustrates.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/determine1.cs#20)]
 [!code-vb[Conceptual.Regex.Language.Options#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/determine1.vb#20)]  
  
 The following sections list the options supported by regular expression in .NET.  
  
<a name="Default"></a>   
## Default Options  
 The <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType> option indicates that no options have been specified, and the regular expression engine uses its default behavior. This includes the following:  
  
-   The pattern is interpreted as a canonical rather than an ECMAScript regular expression.  
  
-   The regular expression pattern is matched in the input string from left to right.  
  
-   Comparisons are case-sensitive.  
  
-   The `^` and `$` language elements match the beginning and end of the input string.  
  
-   The `.` language element matches every character except `\n`.  
  
-   Any white space in a regular expression pattern is interpreted as a literal space character.  
  
-   The conventions of the current culture are used when comparing the pattern to the input string.  
  
-   Capturing groups in the regular expression pattern are implicit as well as explicit.  
  
> [!NOTE]
>  The <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType> option has no inline equivalent. When regular expression options are applied inline, the default behavior is restored on an option-by-option basis, by turning a particular option off. For example, `(?i)` turns on case-insensitive comparison, and `(?-i)` restores the default case-sensitive comparison.  
  
 Because the <xref:System.Text.RegularExpressions.RegexOptions.None?displayProperty=nameWithType> option represents the default behavior of the regular expression engine, it is rarely explicitly specified in a method call. A constructor or static pattern-matching method without an `options` parameter is called instead.  
  
 [Back to Top](#Top)  
  
<a name="Case"></a>   
## Case-Insensitive Matching  
 The <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase> option, or the `i` inline option, provides case-insensitive matching. By default, the casing conventions of the current culture are used.  
  
 The following example defines a regular expression pattern, `\bthe\w*\b`, that matches all words starting with "the". Because the first call to the <xref:System.Text.RegularExpressions.Regex.Match%2A> method uses the default case-sensitive comparison, the output indicates that the string "The" that begins the sentence is not matched. It is matched when the <xref:System.Text.RegularExpressions.Regex.Match%2A> method is called with options set to <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase>.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/case1.cs#1)]
 [!code-vb[Conceptual.Regex.Language.Options#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/case1.vb#1)]  
  
 The following example modifies the regular expression pattern from the previous example to use inline options instead of the `options` parameter to provide case-insensitive comparison. The first pattern defines the case-insensitive option in a grouping construct that applies only to the letter "t" in the string "the". Because the option construct occurs at the beginning of the pattern, the second pattern applies the case-insensitive option to the entire regular expression.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/case2.cs#2)]
 [!code-vb[Conceptual.Regex.Language.Options#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/case2.vb#2)]  
  
 [Back to Top](#Top)  
  
<a name="Multiline"></a>   
## Multiline Mode  
 The <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option, or the `m` inline option, enables the regular expression engine to handle an input string that consists of multiple lines. It changes the interpretation of the `^` and `$` language elements so that they match the beginning and end of a line, instead of the beginning and end of the input string.  
  
 By default, `$` matches only the end of the input string. If you specify the <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> option, it matches either the newline character (`\n`) or the end of the input string. It does not, however, match the carriage return/line feed character combination. To successfully match them, use the subexpression `\r?$` instead of just `$`.  
  
 The following example extracts bowlers' names and scores and adds them to a <xref:System.Collections.Generic.SortedList%602> collection that sorts them in descending order. The <xref:System.Text.RegularExpressions.Regex.Matches%2A> method is called twice. In the first method call, the regular expression is `^(\w+)\s(\d+)$` and no options are set. As the output shows, because the regular expression engine cannot match the input pattern along with the beginning and end of the input string, no matches are found. In the second method call, the regular expression is changed to `^(\w+)\s(\d+)\r?$` and the options are set to <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType>. As the output shows, the names and scores are successfully matched, and the scores are displayed in descending order.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/multiline1.cs#3)]
 [!code-vb[Conceptual.Regex.Language.Options#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/multiline1.vb#3)]  
  
 The regular expression pattern `^(\w+)\s(\d+)\r*$` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Begin at the start of the line.|  
|`(\w+)`|Match one or more word characters. This is the first capturing group.|  
|`\s`|Match a white-space character.|  
|`(\d+)`|Match one or more decimal digits. This is the second capturing group.|  
|`\r?`|Match zero or one carriage return character.|  
|`$`|End at the end of the line.|  
  
 The following example is equivalent to the previous one, except that it uses the inline option `(?m)` to set the multiline option.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/multiline2.cs#4)]
 [!code-vb[Conceptual.Regex.Language.Options#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/multiline2.vb#4)]  
  
 [Back to Top](#Top)  
  
<a name="Singleline"></a>   
## Single-line Mode  
 The <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option, or the `s` inline option, causes the regular expression engine to treat the input string as if it consists of a single line. It does this by changing the behavior of the period (`.`) language element so that it matches every character, instead of matching every character except for the newline character `\n` or \u000A.  
  
 The following example illustrates how the behavior of the `.` language element changes when you use the <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option. The regular expression `^.+` starts at the beginning of the string and matches every character. By default, the match ends at the end of the first line; the regular expression pattern matches the carriage return character, `\r` or \u000D, but it does not match `\n`. Because the <xref:System.Text.RegularExpressions.RegexOptions.Singleline?displayProperty=nameWithType> option interprets the entire input string as a single line, it matches every character in the input string, including `\n`.  
  
 [!code-csharp[Conceptual.Regex.Language.CharacterClasses#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.characterclasses/cs/any2.cs#5)]
 [!code-vb[Conceptual.Regex.Language.CharacterClasses#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.characterclasses/vb/any2.vb#5)]  
  
 The following example is equivalent to the previous one, except that it uses the inline option `(?s)` to enable single-line mode.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/singleline1.cs#5)]
 [!code-vb[Conceptual.Regex.Language.Options#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/singleline1.vb#5)]  
  
 [Back to Top](#Top)  
  
<a name="Explicit"></a>   
## Explicit Captures Only  
 By default, capturing groups are defined by the use of parentheses in the regular expression pattern. Named groups are assigned a name or number by the `(?<`*name*`>`*subexpression*`)` language option, whereas unnamed groups are accessible by index. In the <xref:System.Text.RegularExpressions.GroupCollection> object, unnamed groups precede named groups.  
  
 Grouping constructs are often used only to apply quantifiers to multiple language elements, and the captured substrings are of no interest. For example, if the following regular expression:  
  
```  
\b\(?((\w+),?\s?)+[\.!?]\)?  
```  
  
 is intended only to extract sentences that end with a period, exclamation point, or question mark from a document, only the resulting sentence (which is represented by the <xref:System.Text.RegularExpressions.Match> object) is of interest. The individual words in the collection are not.  
  
 Capturing groups that are not subsequently used can be expensive, because the regular expression engine must populate both the <xref:System.Text.RegularExpressions.GroupCollection> and <xref:System.Text.RegularExpressions.CaptureCollection> collection objects. As an alternative, you can use either the <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture?displayProperty=nameWithType> option or the `n` inline option to specify that the only valid captures are explicitly named or numbered groups that are designated by the `(?<`*name*`>` *subexpression*`)` construct.  
  
 The following example displays information about the matches returned by the `\b\(?((\w+),?\s?)+[\.!?]\)?` regular expression pattern when the <xref:System.Text.RegularExpressions.Regex.Match%2A> method is called with and without the <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture?displayProperty=nameWithType> option. As the output from the first method call shows, the regular expression engine fully populates the <xref:System.Text.RegularExpressions.GroupCollection> and <xref:System.Text.RegularExpressions.CaptureCollection> collection objects with information about captured substrings. Because the second method is called with `options` set to <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture?displayProperty=nameWithType>, it does not capture information on groups.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/explicit1.cs#9)]
 [!code-vb[Conceptual.Regex.Language.Options#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/explicit1.vb#9)]  
  
 The regular expression pattern`\b\(?((?>\w+),?\s?)+[\.!?]\)?` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin at a word boundary.|  
|`\(?`|Match zero or one occurrences of the opening parenthesis ("(").|  
|`(?>\w+),?`|Match one or more word characters, followed by zero or one commas. Do not backtrack when matching word characters.|  
|`\s?`|Match zero or one white-space characters.|  
|`((\w+),?\s?)+`|Match the combination of one or more word characters, zero or one commas, and zero or one white-space characters one or more times.|  
|`[\.!?]\)?`|Match any of the three punctuation symbols, followed by zero or one closing parentheses (")").|  
  
 You can also use the `(?n)` inline element to suppress automatic captures. The following example modifies the previous regular expression pattern to use the `(?n)` inline element instead of the <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture?displayProperty=nameWithType> option.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/explicit2.cs#10)]
 [!code-vb[Conceptual.Regex.Language.Options#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/explicit2.vb#10)]  
  
 Finally, you can use the inline group element `(?n:)` to suppress automatic captures on a group-by-group basis. The following example modifies the previous pattern to suppress unnamed captures in the outer group, `((?>\w+),?\s?)`. Note that this suppresses unnamed captures in the inner group as well.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/explicit3.cs#11)]
 [!code-vb[Conceptual.Regex.Language.Options#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/explicit3.vb#11)]  
  
 [Back to Top](#Top)  
  
<a name="Compiled"></a>   
## Compiled Regular Expressions  
 By default, regular expressions in .NET are interpreted. When a <xref:System.Text.RegularExpressions.Regex> object is instantiated or a static <xref:System.Text.RegularExpressions.Regex> method is called, the regular expression pattern is parsed into a set of custom opcodes, and an interpreter uses these opcodes to run the regular expression. This involves a tradeoff: The cost of initializing the regular expression engine is minimized at the expense of run-time performance.  
  
 You can use compiled instead of interpreted regular expressions by using the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option. In this case, when a pattern is passed to the regular expression engine, it is parsed into a set of opcodes and then converted to Microsoft intermediate language (MSIL), which can be passed directly to the common language runtime. Compiled regular expressions maximize run-time performance at the expense of initialization time.  
  
> [!NOTE]
>  A regular expression can be compiled only by supplying the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> value to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> class constructor or a static pattern-matching method. It is not available as an inline option.  
  
 You can use compiled regular expressions in calls to both static and instance regular expressions. In static regular expressions, the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option is passed to the `options` parameter of the regular expression pattern-matching method. In instance regular expressions, it is passed to the `options` parameter of the <xref:System.Text.RegularExpressions.Regex> class constructor. In both cases, it results in enhanced performance.  
  
 However, this improvement in performance occurs only under the following conditions:  
  
-   A <xref:System.Text.RegularExpressions.Regex> object that represents a particular regular expression is used in multiple calls to regular expression pattern-matching methods.  
  
-   The <xref:System.Text.RegularExpressions.Regex> object is not allowed to go out of scope, so it can be reused.  
  
-   A static regular expression is used in multiple calls to regular expression pattern-matching methods. (The performance improvement is possible because regular expressions used in static method calls are cached by the regular expression engine.)  
  
> [!NOTE]
>  The <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option is unrelated to the <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> method, which creates a special-purpose assembly that contains predefined compiled regular expressions.  
  
 [Back to Top](#Top)  
  
<a name="Whitespace"></a>   
## Ignore White Space  
 By default, white space in a regular expression pattern is significant; it forces the regular expression engine to match a white-space character in the input string. Because of this, the regular expression "`\b\w+\s`" and "`\b\w+` " are roughly equivalent regular expressions. In addition, when the number sign (#) is encountered in a regular expression pattern, it is interpreted as a literal character to be matched.  
  
 The <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> option, or the `x` inline option, changes this default behavior as follows:  
  
-   Unescaped white space in the regular expression pattern is ignored. To be part of a regular expression pattern, white-space characters must be escaped (for example, as `\s` or "`\` ").  
  
-   The number sign (#) is interpreted as the beginning of a comment, rather than as a literal character. All text in the regular expression pattern from the # character to the end of the string is interpreted as a comment.  
  
 However, in the following cases, white-space characters in a regular expression aren't ignored, even if you use the <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> option:  
  
-   White space within a character class is always interpreted literally. For example, the regular expression pattern `[ .,;:]` matches any single white-space character, period, comma, semicolon, or colon.  
  
-   White space isn't allowed within a bracketed quantifier, such as `{`*n*`}`, `{`*n*`,}`, and `{`*n*`,`*m*`}`. For example, the regular expression pattern `\d{1. 3}` fails to match any sequences of digits from one to three digits because it contains a white-space character.  
  
-   White space isn't allowed within a character sequence that introduces a language element. For example:  
  
    -   The language element `(?:`*subexpression*`)` represents a noncapturing group, and the `(?:` portion of the element can't have embedded spaces. The pattern `(? :`*subexpression*`)` throws an <xref:System.ArgumentException> at run time because the regular expression engine can't parse the pattern, and the pattern `( ?:`*subexpression*`)` fails to match *subexpression*.  
  
    -   The language element `\p{`*name*`}`, which represents a Unicode category or named block, can't include embedded spaces in the `\p{` portion of the element. If you do include a white space, the element throws an <xref:System.ArgumentException> at run time.  
  
 Enabling this option helps simplify regular expressions that are often difficult to parse and to understand. It improves readability, and makes it possible to document a regular expression.  
  
 The following example defines the following regular expression pattern:  
  
 `\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence.`  
  
 This pattern is similar to the pattern defined in the [Explicit Captures Only](#Explicit) section, except that it uses the <xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace?displayProperty=nameWithType> option to ignore pattern white space.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/whitespace1.cs#12)]
 [!code-vb[Conceptual.Regex.Language.Options#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/whitespace1.vb#12)]  
  
 The following example uses the inline option `(?x)` to ignore pattern white space.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/whitespace2.cs#13)]
 [!code-vb[Conceptual.Regex.Language.Options#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/whitespace2.vb#13)]  
  
 [Back to Top](#Top)  
  
<a name="RightToLeft"></a>   
## Right-to-Left Mode  
 By default, the regular expression engine searches from left to right. You can reverse the search direction by using the <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType> option. The search automatically begins at the last character position of the string. For pattern-matching methods that include a starting position parameter, such as <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.Int32%29?displayProperty=nameWithType>, the starting position is the index of the rightmost character position at which the search is to begin.  
  
> [!NOTE]
>  Right-to-left pattern mode is available only by supplying the <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType> value to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> class constructor or static pattern-matching method. It is not available as an inline option.  
  
 The <xref:System.Text.RegularExpressions.RegexOptions.RightToLeft?displayProperty=nameWithType> option changes the search direction only; it does not interpret the regular expression pattern from right to left. For example, the regular expression `\bb\w+\s` matches words that begin with the letter "b" and are followed by a white-space character. In the following example, the input string consists of three words that include one or more "b" characters. The first word begins with "b", the second ends with "b", and the third includes two "b" characters in the middle of the word. As the output from the example shows, only the first word matches the regular expression pattern.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/righttoleft1.cs#17)]
 [!code-vb[Conceptual.Regex.Language.Options#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/righttoleft1.vb#17)]  
  
 Also note that the lookahead assertion (the `(?=`*subexpression*`)` language element) and the lookbehind assertion (the `(?<=`*subexpression*`)` language element) do not change direction. The lookahead assertions look to the right; the lookbehind assertions look to the left. For example, the regular expression `(?<=\d{1,2}\s)\w+,?\s\d{4}` uses the lookbehind assertion to test for a date that precedes a month name. The regular expression then matches the month and the year. For information on lookahead and lookbehind assertsions, see [Grouping Constructs](../../../docs/standard/base-types/grouping-constructs-in-regular-expressions.md).  
  
 [!code-csharp[Conceptual.Regex.Language.Options#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/righttoleft2.cs#18)]
 [!code-vb[Conceptual.Regex.Language.Options#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/righttoleft2.vb#18)]  
  
 The regular expression pattern is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`(?<=\d{1,2}\s)`|The beginning of the match must be preceded by one or two decimal digits followed by a space.|  
|`\w+`|Match one or more word characters.|  
|`,?`|Match zero or one comma characters.|  
|`\s`|Match a white-space character.|  
|`\d{4}`|Match four decimal digits.|  
  
 [Back to Top](#Top)  
  
<a name="ECMAScript"></a>   
## ECMAScript Matching Behavior  
 By default, the regular expression engine uses canonical behavior when matching a regular expression pattern to input text. However, you can instruct the regular expression engine to use ECMAScript matching behavior by specifying the <xref:System.Text.RegularExpressions.RegexOptions.ECMAScript?displayProperty=nameWithType> option.  
  
> [!NOTE]
>  ECMAScript-compliant behavior is available only by supplying the <xref:System.Text.RegularExpressions.RegexOptions.ECMAScript?displayProperty=nameWithType> value to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> class constructor or static pattern-matching method. It is not available as an inline option.  
  
 The <xref:System.Text.RegularExpressions.RegexOptions.ECMAScript?displayProperty=nameWithType> option can be combined only with the <xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.RegexOptions.Multiline?displayProperty=nameWithType> options. The use of any other option in a regular expression results in an <xref:System.ArgumentOutOfRangeException>.  
  
 The behavior of ECMAScript and canonical regular expressions differs in three areas: character class syntax, self-referencing capturing groups, and octal versus backreference interpretation.  
  
-   Character class syntax. Because canonical regular expressions support Unicode whereas ECMAScript does not, character classes in ECMAScript have a more limited syntax, and some character class language elements have a different meaning. For example, ECMAScript does not support language elements such as the Unicode category or block elements `\p` and `\P`. Similarly, the `\w` element, which matches a word character, is equivalent to the `[a-zA-Z_0-9]` character class when using ECMAScript and `[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]` when using canonical behavior. For more information, see [Character Classes](../../../docs/standard/base-types/character-classes-in-regular-expressions.md).  
  
     The following example illustrates the difference between canonical and ECMAScript pattern matching. It defines a regular expression, `\b(\w+\s*)+`, that matches words followed by white-space characters. The input consists of two strings, one that uses the Latin character set and the other that uses the Cyrillic character set. As the output shows, the call to the <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method that uses ECMAScript matching fails to match the Cyrillic words, whereas the method call that uses canonical matching does match these words.  
  
     [!code-csharp[Conceptual.Regex.Language.Options#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/ecmascript1.cs#16)]
     [!code-vb[Conceptual.Regex.Language.Options#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/ecmascript1.vb#16)]  
  
-   Self-referencing capturing groups. A regular expression capture class with a backreference to itself must be updated with each capture iteration. As the following example shows, this feature enables the regular expression `((a+)(\1) ?)+` to match the input string " aa aaaa aaaaaa " when using ECMAScript, but not when using canonical matching.  
  
     [!code-csharp[Conceptual.Regex.Language.Options#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/ecmascript2.cs#21)]
     [!code-vb[Conceptual.Regex.Language.Options#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/ecmascript2.vb#21)]  
  
     The regular expression is defined as shown in the following table.  
  
    |Pattern|Description|  
    |-------------|-----------------|  
    |(a+)|Match the letter "a" one or more times. This is the second capturing group.|  
    |(\1)|Match the substring captured by the first capturing group. This is the third capturing group.|  
    |?|Match zero or one space characters.|  
    |((a+)(\1) ?)+|Match the pattern of one or more "a" characters followed by a string that matches the first capturing group followed by zero or one space characters one or more times. This is the first capturing group.|  
  
-   Resolution of ambiguities between octal escapes and backreferences. The following table summarizes the differences in octal versus backreference interpretation by canonical and ECMAScript regular expressions.  
  
    |Regular expression|Canonical behavior|ECMAScript behavior|  
    |------------------------|------------------------|-------------------------|  
    |`\0` followed by 0 to 2 octal digits|Interpret as an octal. For example, `\044` is always interpreted as an octal value and means "$".|Same behavior.|  
    |`\` followed by a digit from 1 to 9, followed by no additional decimal digits,|Interpret as a backreference. For example, `\9` always means backreference 9, even if a ninth capturing group does not exist. If the capturing group does not exist, the regular expression parser throws an <xref:System.ArgumentException>.|If a single decimal digit capturing group exists, backreference to that digit. Otherwise, interpret the value as a literal.|  
    |`\` followed by a digit from 1 to 9, followed by additional decimal digits|Interpret the digits as a decimal value. If that capturing group exists, interpret the expression as a backreference.<br /><br /> Otherwise, interpret the leading octal digits up to octal 377; that is, consider only the low 8 bits of the value. Interpret the remaining digits as literals. For example, in the expression `\3000`, if capturing group 300 exists, interpret as backreference 300; if capturing group 300 does not exist, interpret as octal 300 followed by 0.|Interpret as a backreference by converting as many digits as possible to a decimal value that can refer to a capture. If no digits can be converted, interpret as an octal by using the leading octal digits up to octal 377; interpret the remaining digits as literals.|  
  
 [Back to Top](#Top)  
  
<a name="Invariant"></a>   
## Comparison Using the Invariant Culture  
 By default, when the regular expression engine performs case-insensitive comparisons, it uses the casing conventions of the current culture to determine equivalent uppercase and lowercase characters.  
  
 However, this behavior is undesirable for some types of comparisons, particularly when comparing user input to the names of system resources, such as passwords, files, or URLs. The following example illustrates such as scenario. The code is intended to block access to any resource whose URL is prefaced with **FILE://**. The regular expression attempts a case-insensitive match with the string by using the regular expression `$FILE://`. However, when the current system culture is tr-TR (Turkish-Turkey), "I" is not the uppercase equivalent of "i". As a result, the call to the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method returns `false`, and access to the file is allowed.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/culture1.cs#14)]
 [!code-vb[Conceptual.Regex.Language.Options#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/culture1.vb#14)]  
  
> [!NOTE]
>  For more information about string comparisons that are case-sensitive and that use the invariant culture, see [Best Practices for Using Strings](../../../docs/standard/base-types/best-practices-strings.md).  
  
 Instead of using the case-insensitive comparisons of the current culture, you can specify the <xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant?displayProperty=nameWithType> option to ignore cultural differences in language and to use the conventions of the invariant culture.  
  
> [!NOTE]
>  Comparison using the invariant culture is available only by supplying the <xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant?displayProperty=nameWithType> value to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> class constructor or static pattern-matching method. It is not available as an inline option.  
  
 The following example is identical to the previous example, except that the static <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%29?displayProperty=nameWithType> method is called with options that include <xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant?displayProperty=nameWithType>. Even when the current culture is set to Turkish (Turkey), the regular expression engine is able to successfully match "FILE" and "file" and block access to the file resource.  
  
 [!code-csharp[Conceptual.Regex.Language.Options#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regex.language.options/cs/culture1.cs#15)]
 [!code-vb[Conceptual.Regex.Language.Options#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regex.language.options/vb/culture1.vb#15)]  
  
## See Also  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
