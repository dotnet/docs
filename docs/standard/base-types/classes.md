---
title: Character classes in regular expressions
description: Character classes in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c7a9305f-7144-4fe8-80e8-a727bf7d223f
---

# Character classes in regular expressions

A character class defines a set of characters, any one of which can occur in an input string for a match to succeed. The regular expression language in .NET supports the following character classes:

* Positive character groups. A character in the input string must match one of a specified set of characters. For more information, see [Positive character group](#positive-character-group--).

* Negative character groups. A character in the input string must not match one of a specified set of characters. For more information, see [Negative character group](#negative-character-group-).

* Any character. The . (dot or period) character in a regular expression is a wildcard character that matches any character except **\n**. For more information, see [Any character](#any-character-). 

* A general Unicode category or named block. A character in the input string must be a member of a particular Unicode category or must fall within a contiguous range of Unicode characters for a match to succeed. For more information, see [Unicode category or Unicode block](#unicode-category-or-unicode-block-p).

* A negative general Unicode category or named block. A character in the input string must not be a member of a particular Unicode category or must not fall within a contiguous range of Unicode characters for a match to succeed. For more information, see [Negative Unicode category or Unicode block](#negative-unicode-category-or-unicode-block-p).

* A word character. A character in the input string can belong to any of the Unicode categories that are appropriate for characters in words. For more information, see [Word character](#word-character-w).

* A non-word character. A character in the input string can belong to any Unicode category that is not a word character. For more information, see [Non-word character](#non-word-character-w).

* A white-space character. A character in the input string can be any Unicode separator character, as well as any one of a number of control characters. For more information, see [White-space character](#white-space-character-s).

* A non-white-space character. A character in the input string can be any character that is not a white-space character. For more information, see [Non-white-space character](#non-white-space-character-s).

* A decimal digit. A character in the input string can be any of a number of characters classified as Unicode decimal digits. For more information, see [Decimal digit character](#decimal-digit-character-d).

* A non-decimal digit. A character in the input string can be anything other than a Unicode decimal digit. For more information, see [Non-digit character](#non-digit-character-d).


.NET supports character class subtraction expressions, which enables you to define a set of characters as the result of excluding one character class from another character class. For more information, see [Character class subtraction](#character-class-subtraction).

## Positive character group: [ ]

A positive character group specifies a list of characters, any one of which may appear in an input string for a match to occur. This list of characters may be specified individually, as a range, or both. 

The syntax for specifying a list of individual characters is as follows: 

[*character*_*group*]

where *character_group* is a list of the individual characters that can appear in the input string for a match to succeed. *character*_*group* can consist of any combination of one or more literal characters, [escape characters](escapes.md), or character classes. 

The syntax for specifying a range of characters is as follows:

```
[firstCharacter-lastCharacter]
```

where *firstCharacter* is the character that begins the range and *lastCharacter* is the character that ends the range. A character range is a contiguous series of characters defined by specifying the first character in the series, a hyphen (-), and then the last character in the series. Two characters are contiguous if they have adjacent Unicode code points.

Some common regular expression patterns that contain positive character classes are listed in the following table.

Pattern | Description
------- | ----------- 
`[aeiou]` | Match all vowels.
`[\p{P}\d]` | Match all punctuation and decimal digit characters.
`[\s\p{P}]` | Match all white-space and punctuation.
 
The following example defines a positive character group that contains the characters "a" and "e" so that the input string must contain the words "grey" or "gray" followed by another word for a match to occur.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"gr[ae]y\s\S+?[\s\p{P}]";
      string input = "The gray wolf jumped over the grey wall.";
      MatchCollection matches = Regex.Matches(input, pattern);
      foreach (Match match in matches)
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       gray wolf
//       grey wall.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "gr[ae]y\s\S+?[\s\p{P}]"
      Dim input As String = "The gray wolf jumped over the grey wall."
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      For Each match As Match In matches
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       gray wolf
'       grey wall.
```

The regular expression `gr[ae]y\s\S+?[\s|\p{P}]` is defined as follows:

Pattern | Description
------- | ----------- 
`gr` | Match the literal characters "gr".
`[ae]` | Match either an "a" or an "e".
`y\s` | Match the literal character "y" followed by a white-space character.
`\S+?` | Match one or more non-white-space characters, but as few as possible.
`[\s\p{P}]` | Match either a white-space character or a punctuation mark.
 
The following example matches words that begin with any capital letter. It uses the subexpression `[A-Z]` to represent the range of capital letters from A to Z. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[A-Z]\w*\b";
      string input = "A city Albany Zulu maritime Marseilles";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       A
//       Albany
//       Zulu
//       Marseilles
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b[A-Z]\w*\b"
      Dim input As String = "A city Albany Zulu maritime Marseilles"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
```

The regular expression `\b[A-Z]\w*\b` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Start at a word boundary.
`[A-Z]` | Match any uppercase character from A to Z.
`\w*` | Match zero or more word characters.
`\b` | Match a word boundary.

## Negative character group: [^]

A negative character group specifies a list of characters that must not appear in an input string for a match to occur. The list of characters may be specified individually, as a range, or both. 

The syntax for specifying a list of individual characters is as follows:

[^*character*_*group*]

where *character_group* is a list of the individual characters that cannot appear in the input string for a match to succeed. *character*_*group* can consist of any combination of one or more literal characters, [escape characters](escapes.md), or character classes. 

The syntax for specifying a range of characters is as follows:

[^*firstCharacter-lastCharacter*]

where *firstCharacter* is the character that begins the range, and *lastCharacter* is the character that ends the range. A character range is a contiguous series of characters defined by specifying the first character in the series, a hyphen (-), and then the last character in the series. Two characters are contiguous if they have adjacent Unicode code points.

Two or more character ranges can be concatenated. For example, to specify the range of decimal digits from "0" through "9", the range of lowercase letters from "a" through "f", and the range of uppercase letters from "A" through "F", use `[0-9a-fA-F]`.

The leading carat character (^) in a negative character group is mandatory and indicates the character group is a negative character group instead of a positive character group.

> [!IMPORTANT]
> A negative character group in a larger regular expression pattern is not a zero-width assertion. That is, after evaluating the negative character group, the regular expression engine advances one character in the input string.

Some common regular expression patterns that contain negative character groups are listed in the following table.

Pattern | Description
------- | ----------- 
`[^aeiou]` | Match all characters except vowels.
`[^\p{P}\d]` | Match all characters except punctuation and decimal digit characters.
 
The following example matches any word that begins with the characters "th" and is not followed by an "o". 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bth[^o]\w+\b";
      string input = "thought thing though them through thus thorough this";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       thing
//       them
//       through
//       thus
//       this
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\bth[^o]\w+\b"
      Dim input As String = "thought thing though them through thus " + _
                            "thorough this"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       thing
'       them
'       through
'       thus
'       this
```

The regular expression `\bth[^o]\w+\b` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Start at a word boundary.
`th` | Match the literal characters "th".
`[^o]` | Match any character that is not an "o".
`\w+` | Match one or more word characters.
`\b` | End at a word boundary.

## Any character: .

The period character (.) matches any character except **\n** (the newline character, **\u000A**), with the following two qualifications:

* If a regular expression pattern is modified by the [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option, or if the portion of the pattern that contains the . character class is modified by the **s** option, . matches any character. For more information, see [Regular expression options](options.md).

  The following example illustrates the different behavior of the . character class by default and with the [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option. The regular expression `^.+` starts at the beginning of the string and matches every character. By default, the match ends at the end of the first line; the regular expression pattern matches the carriage return character, **\r** or **\u000D**, but it does not match **\n**. Because the [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option interprets the entire input string as a single line, it matches every character in the input string, including **\n**.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "^.+";
      string input = "This is one line and" + Environment.NewLine + "this is the second.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(Regex.Escape(match.Value));

      Console.WriteLine();
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Singleline))
         Console.WriteLine(Regex.Escape(match.Value));
   }
}
// The example displays the following output:
//       This\ is\ one\ line\ and\r
//       
//       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
```

```vb
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "^.+"
        Dim input As String = "This is one line and" + vbCrLf + "this is the second."
        For Each match As Match In Regex.Matches(input, pattern)
           Console.WriteLine(Regex.Escape(match.Value))
        Next
        Console.WriteLine()
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.SingleLine)
           Console.WriteLine(Regex.Escape(match.Value))
        Next
     End Sub
  End Module
  ' The example displays the following output:
  '       This\ is\ one\ line\ and\r
  '       
  '       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
```

  > [!NOTE]
  > Because it matches any character except **\n**, the . character class also matches **\r** (the carriage return character, **\u000D**).
 
* In a positive or negative character group, a period is treated as a literal period character, and not as a character class. For more information, see [Positive character group](#positive-character-group--) or [Negative character group](#negative-character-group-) earlier in this topic. The following example provides an illustration by defining a regular expression that includes the period character (**.**) both as a character class and as a member of a positive character group. The regular expression `\b.*[.?!;:](\s|\z)` begins at a word boundary, matches any character until it encounters one of four punctuation marks, including a period, and then matches either a white-space character or the end of the string.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b.*[.?!;:](\s|\z)";
      string input = "this. what: is? go, thing.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       this. what: is? go, thing.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As STring = "\b.*[.?!;:](\s|\z)"
      Dim input As String = "this. what: is? go, thing."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next   
   End Sub
End Module
' The example displays the following output:
'       this. what: is? go, thing.
```

  > [!NOTE]
  > Because it matches any character, the . language element is often used with a lazy quantifier if a regular expression pattern attempts to match any character multiple times. For more information, see [Quantifiers in regular expressions](quantifiers.md). 
 
## Unicode category or Unicode block: \p{}

The Unicode standard assigns each character a general category. For example, a particular character can be an uppercase letter (represented by the **Lu** category), a decimal digit (the **Nd** category), a math symbol (the **Sm** category), or a paragraph separator (the **Zl** category). Specific character sets in the Unicode standard also occupy a specific range or block of consecutive code points. For example, the basic Latin character set is found from **\u0000** through **\u007F**, while the Arabic character set is found from **\u0600** through **\u06FF**. 

The regular expression construct

**\p{**_name_**}**

matches any character that belongs to a Unicode general category or named block, where name is the category abbreviation or named block name. For a list of category abbreviations, see the [Supported Unicode general categories](#supported-unicode-general-categories) section later in this topic. For a list of named blocks, see the [Supported named blocks](#supported-named-blocks) section later in this topic. 

The following example uses the **\p{**_name_**}** construct to match both a Unicode general category (in this case, the **Pd**, or Punctuation,Dash category) and a named block (the **IsGreek** and **IsBasicLatin** named blocks).

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+";
      string input = "?ata ?a??a??? - The Gospel of Matthew";

      Console.WriteLine(Regex.IsMatch(input, pattern));        // Displays True.
   }
}
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+"
      Dim input As String = "Κατα Μαθθαίον - The Gospel of Matthew"

      Console.WriteLine(Regex.IsMatch(input, pattern))         ' Displays True.
   End Sub
End Module
```

The regular expression `\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Start at a word boundary.
`\p{IsGreek}+` | Match one or more Greek characters.
`(\s)?` | Match zero or one white-space character.
`(\p{IsGreek}+(\s)?)+` | Match the pattern of one or more Greek characters followed by zero or one white-space characters one or more times. 
`\p{Pd}` | Match a Punctuation, Dash character.
`\s` | Match a white-space character.
`\p{IsBasicLatin}+` | Match one or more basic Latin characters.
`(\s)?` | Match zero or one white-space character.
`(\p{IsBasicLatin}+(\s)?)+` | Match the pattern of one or more basic Latin characters followed by zero or one white-space characters one or more times.

## Negative Unicode category or Unicode block: \P{}

The Unicode standard assigns each character a general category. For example, a particular character can be an uppercase letter (represented by the **Lu** category), a decimal digit (the **Nd** category), a math symbol (the **Sm** category), or a paragraph separator (the **Zl** category). Specific character sets in the Unicode standard also occupy a specific range or block of consecutive code points. For example, the basic Latin character set is found from **\u0000** through **\u007F**, while the Arabic character set is found from **\u0600** through **\u06FF**. 

The regular expression construct

**\P{**_name_**}**

matches any character that belongs to a Unicode general category or named block, where name is the category abbreviation or named block name. For a list of category abbreviations, see the [Supported Unicode general categories](#supported-unicode-general-categories) section later in this topic. For a list of named blocks, see the [Supported named blocks](#supported-named-blocks) section later in this topic.

The following example uses the **\P{**_name_**}** construct to remove any currency symbols (in this case, the **Sc**, or Symbol, Currency category) from numeric strings.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\P{Sc})+";

      string[] values = { "$164,091.78", "£1,073,142.68", "73¢", "€120" };
      foreach (string value in values)
         Console.WriteLine(Regex.Match(value, pattern).Value);
   }
}
// The example displays the following output:
//       164,091.78
//       1,073,142.68
//       73
//       120
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\P{Sc})+"

      Dim values() As String = { "$164,091.78", "£1,073,142.68", "73¢", "€120"}
      For Each value As String In values
         Console.WriteLine(Regex.Match(value, pattern).Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       164,091.78
'       1,073,142.68
'       73
'       120
```

The regular expression pattern `(\P{Sc})+` matches one or more characters that are not currency symbols; it effectively strips any currency symbol from the result string.

## Word character: \w

**\w** matches any word character. A word character is a member of any of the Unicode categories listed in the following table. 

Category | Description
-------- | ----------- 
Ll | Letter, Lowercase
Lu | Letter, Uppercase
Lt | Letter, Titlecase
Lo | Letter, Other
Lm | Letter, Modifier
Mn | Mark, Nonspacing
Nd | Number, Decimal Digit
Pc | Punctuation, Connector. This category includes ten characters, the most commonly used of which is the LOWLINE character (_), u+005F.
 
If ECMAScript-compliant behavior is specified, **\w** is equivalent to `[a-zA-Z_0-9]`. For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md). 

> [!NOTE]
> Because it matches any word character, the \w language element is often used with a lazy quantifier if a regular expression pattern attempts to match any word character multiple times, followed by a specific word character. For more information, see [Quantifiers in regular expressions](quantifiers.md).

The following example uses the **\w** language element to match duplicate characters in a word. The example defines a regular expression pattern, **(\w)\1**, which can be interpreted as follows.

Element | Description
------- | -----------
(\w) | Match a word character. This is the first capturing group.
\1 | Match the value of the first capture. 
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\w)\1";
      string[] words = { "trellis", "seer", "latter", "summer", 
                         "hoarse", "lesser", "aardvark", "stunned" };
      foreach (string word in words)
      {
         Match match = Regex.Match(word, pattern);
         if (match.Success)
            Console.WriteLine("'{0}' found in '{1}' at position {2}.", 
                              match.Value, word, match.Index);
         else
            Console.WriteLine("No double characters in '{0}'.", word);
      }                                                  
   }
}
// The example displays the following output:
//       'll' found in 'trellis' at position 3.
//       'ee' found in 'seer' at position 1.
//       'tt' found in 'latter' at position 2.
//       'mm' found in 'summer' at position 2.
//       No double characters in 'hoarse'.
//       'ss' found in 'lesser' at position 2.
//       'aa' found in 'aardvark' at position 0.
//       'nn' found in 'stunned' at position 3.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\w)\1"
      Dim words() As String = { "trellis", "seer", "latter", "summer", _
                                "hoarse", "lesser", "aardvark", "stunned" }
      For Each word As String In words
         Dim match As Match = Regex.Match(word, pattern)
         If match.Success Then
            Console.WriteLine("'{0}' found in '{1}' at position {2}.", _
                              match.Value, word, match.Index)
         Else
            Console.WriteLine("No double characters in '{0}'.", word)
         End If
      Next                                                  
   End Sub
End Module
' The example displays the following output:
'       'll' found in 'trellis' at position 3.
'       'ee' found in 'seer' at position 1.
'       'tt' found in 'latter' at position 2.
'       'mm' found in 'summer' at position 2.
'       No double characters in 'hoarse'.
'       'ss' found in 'lesser' at position 2.
'       'aa' found in 'aardvark' at position 0.
'       'nn' found in 'stunned' at position 3.
```

## Non-word character: \W

**\W** matches any non-word character. The **\W** language element is equivalent to the following character class:

```
[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]
```

In other words, it matches any character except for those in the Unicode categories listed in the following table.

Category | Description
-------- | -----------
Ll | Letter, Lowercase
Lu | Letter, Uppercase
Lt | Letter, Titlecase
Lo | Letter, Other
Lm | Letter, Modifier
Mn | Mark, Nonspacing
Nd | Number, Decimal Digit
Pc | Punctuation, Connector. This category includes ten characters, the most commonly used of which is the LOWLINE character (_), u+005F.
 
If ECMAScript-compliant behavior is specified, **\W** is equivalent to `[^a-zA-Z_0-9]`. For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md). 

> [!NOTE]
> Because it matches any word character, the \w language element is often used with a lazy quantifier if a regular expression pattern attempts to match any word character multiple times, followed by a specific word character. For more information, see [Quantifiers in regular expressions](quantifiers.md). 

The following example illustrates the **\W** character class. It defines a regular expression pattern, `\b(\w+)(\W){1,2}`, that matches a word followed by one or two non-word characters, such as white space or punctuation. The regular expression is interpreted as shown in the following table.

Element | Description
------- | ----------- 
\b | Begin the match at a word boundary.
(\w+) | Match one or more word characters. This is the first capturing group.
(\W){1,2} | Match a non-word character either one or two times. This is the second capturing group.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\w+)(\W){1,2}";
      string input = "The old, grey mare slowly walked across the narrow, green pasture.";
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine(match.Value);
         Console.Write("   Non-word character(s):");
         CaptureCollection captures = match.Groups[2].Captures;
         for (int ctr = 0; ctr < captures.Count; ctr++)
             Console.Write(@"'{0}' (\u{1}){2}", captures[ctr].Value, 
                           Convert.ToUInt16(captures[ctr].Value[0]).ToString("X4"), 
                           ctr < captures.Count - 1 ? ", " : "");
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       The
//          Non-word character(s):' ' (\u0020)
//       old,
//          Non-word character(s):',' (\u002C), ' ' (\u0020)
//       grey
//          Non-word character(s):' ' (\u0020)
//       mare
//          Non-word character(s):' ' (\u0020)
//       slowly
//          Non-word character(s):' ' (\u0020)
//       walked
//          Non-word character(s):' ' (\u0020)
//       across
//          Non-word character(s):' ' (\u0020)
//       the
//          Non-word character(s):' ' (\u0020)
//       narrow,
//          Non-word character(s):',' (\u002C), ' ' (\u0020)
//       green
//          Non-word character(s):' ' (\u0020)
//       pasture.
//          Non-word character(s):'.' (\u002E)
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\w+)(\W){1,2}"
      Dim input As String = "The old, grey mare slowly walked across the narrow, green pasture."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
         Console.Write("   Non-word character(s):")
         Dim captures As CaptureCollection = match.Groups(2).Captures
         For ctr As Integer = 0 To captures.Count - 1
             Console.Write("'{0}' (\u{1}){2}", captures(ctr).Value, _
                           Convert.ToUInt16(captures(ctr).Value.Chars(0)).ToString("X4"), _
                           If(ctr < captures.Count - 1, ", ", ""))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       The
'          Non-word character(s):' ' (\u0020)
'       old,
'          Non-word character(s):',' (\u002C), ' ' (\u0020)
'       grey
'          Non-word character(s):' ' (\u0020)
'       mare
'          Non-word character(s):' ' (\u0020)
'       slowly
'          Non-word character(s):' ' (\u0020)
'       walked
'          Non-word character(s):' ' (\u0020)
'       across
'          Non-word character(s):' ' (\u0020)
'       the
'          Non-word character(s):' ' (\u0020)
'       narrow,
'          Non-word character(s):',' (\u002C), ' ' (\u0020)
'       green
'          Non-word character(s):' ' (\u0020)
'       pasture.
'          Non-word character(s):'.' (\u002E)
```

Because the `Group` object for the second capturing group contains only a single captured non-word character, the example retrieves all captured non-word characters from the `CaptureCollection` object that is returned by the `Group.Captures` property.

## White-space character: \s

**\s** matches any white-space character. It is equivalent to the escape sequences and Unicode categories listed in the following table. 

Category | Description
-------- | ----------- 
**\f** | The form feed character, \u000C.
**\n** | The newline character, \u000A.
**\r** | The carriage return character, \u000D.
**\t** | The tab character, \u0009.
**\v** | The vertical tab character, \u000B.
**\x85** | The ellipsis or NEXT LINE (NEL) character (…), \u0085.
**\p{Z}** | Matches any separator character.
 

If ECMAScript-compliant behavior is specified, **\s** is equivalent to `[ \f\n\r\t\v]`.  For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md). 

The following example illustrates the \s character class. It defines a regular expression pattern, `\b\w+(e)?s(\s|$)`, that matches a word ending in either "s" or "es" followed by either a white-space character or the end of the input string. The regular expression is interpreted as shown in the following table.

Element | Description
------- | -----------
\b | Begin the match at a word boundary.
\w+ | Match one or more word characters. 
(e)? | Match an "e" either zero or one time.
s | Match an "s".
(\s&#124;$) | Match either a whitespace character or the end of the input string.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+(e)?s(\s|$)";
      string input = "matches stores stops leave leaves";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       matches
//       stores
//       stops
//       leaves
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+(e)?s(\s|$)"
      Dim input As String = "matches stores stops leave leaves"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)      
      Next
   End Sub
End Module
' The example displays the following output:
'       matches
'       stores
'       stops
'       leaves
```

## Non-white-space character: \S

**\S** matches any non-white-space character. It is equivalent to the `[^\f\n\r\t\v\x85\p{Z}]` regular expression pattern, or the opposite of the regular expression pattern that is equivalent to **\s**, which matches white-space characters. For more information, see the oprevious section, "White-Space Character: \s".

If ECMAScript-compliant behavior is specified, **\S** is equivalent to `[^ \f\n\r\t\v]`. For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md).

The following example illustrates the **\S** language element. The regular expression pattern \b(\S+)\s? matches strings that are delimited by white-space characters. The second element in the match's GroupCollection object contains the matched string. The regular expression can be interpreted as shown in the following table.

Element | Description
------- | ----------- 
`\b` | Begin the match at a word boundary.
`(\S+)` | Match one or more non-white-space characters. This is the first capturing group.
`\s?` | Match zero or one white-space character. 
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\S+)\s?";
      string input = "This is the first sentence of the first paragraph. " + 
                            "This is the second sentence.\n" + 
                            "This is the only sentence of the second paragraph.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Groups[1]);
   }
}
// The example displays the following output:
//    This
//    is
//    the
//    first
//    sentence
//    of
//    the
//    first
//    paragraph.
//    This
//    is
//    the
//    second
//    sentence.
//    This
//    is
//    the
//    only
//    sentence
//    of
//    the
//    second
//    paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\S+)\s?"
      Dim input As String = "This is the first sentence of the first paragraph. " + _
                            "This is the second sentence." + vbCrLf + _
                            "This is the only sentence of the second paragraph."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Groups(1))
      Next
   End Sub
End Module
' The example displays the following output:
'    This
'    is
'    the
'    first
'    sentence
'    of
'    the
'    first
'    paragraph.
'    This
'    is
'    the
'    second
'    sentence.
'    This
'    is
'    the
'    only
'    sentence
'    of
'    the
'    second
'    paragraph.
```

## Decimal digit character: \d

**\d** matches any decimal digit. It is equivalent to the `\\p{Nd}` regular expression pattern, which includes the standard decimal digits 0-9 as well as the decimal digits of a number of other character sets.

If ECMAScript-compliant behavior is specified, **\d** is equivalent to `[0-9]`. For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md).

The following example illustrates the **\d** language element. It tests whether an input string represents a valid telephone number in the United States and Canada. The regular expression pattern `^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$` is defined as shown in the following table.

Element | Description
------- | ----------- 
`^` | Begin the match at the beginning of the input string.
`\(?` | Match zero or one literal "(" character. 
`\d{3}` | Match three decimal digits. 
`\)?` | Match zero or one literal ")" character.
`[\s-]` | Match a hyphen or a white-space character.
`(\(?\d{3}\)?[\s-])?` | Match an optional opening parenthesis followed by three decimal digits, an optional closing parenthesis, and either a white-space character or a hyphen zero or one time. This is the first capturing group.
`\d{3}-\d{4}` | Match three decimal digits followed by a hyphen and four more decimal digits.
`$` | Match the end of the input string.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$";
      string[] inputs = { "111 111-1111", "222-2222", "222 333-444", 
                          "(212) 111-1111", "111-AB1-1111", 
                          "212-111-1111", "01 999-9999" };

      foreach (string input in inputs)
      {
         if (Regex.IsMatch(input, pattern)) 
            Console.WriteLine(input + ": matched");
         else
            Console.WriteLine(input + ": match failed");
      }
   }
}
// The example displays the following output:
//       111 111-1111: matched
//       222-2222: matched
//       222 333-444: match failed
//       (212) 111-1111: matched
//       111-AB1-1111: match failed
//       212-111-1111: matched
//       01 999-9999: match failed
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$"
      Dim inputs() As String = { "111 111-1111", "222-2222", "222 333-444", _
                                 "(212) 111-1111", "111-AB1-1111", _
                                 "212-111-1111", "01 999-9999" }

      For Each input As String In inputs
         If Regex.IsMatch(input, pattern) Then 
            Console.WriteLine(input + ": matched")
         Else
            Console.WriteLine(input + ": match failed")
         End If   
      Next
   End Sub
End Module
' The example displays the following output:
'       111 111-1111: matched
'       222-2222: matched
'       222 333-444: match failed
'       (212) 111-1111: matched
'       111-AB1-1111: match failed
'       212-111-1111: matched
'       01 999-9999: match failed
```

## Non-digit character: \D

**\D** matches any non-digit character. It is equivalent to the `\P{Nd}` regular expression pattern.

If ECMAScript-compliant behavior is specified, **\D** is equivalent to `[^0-9]`. For information on ECMAScript regular expressions, see the [ECMAScript matching behavior](options.md#ecmascript-matching-behavior) section in [Regular expression options](options.md).

The following example illustrates the **\D** language element. It tests whether a string such as a part number consists of the appropriate combination of decimal and non-decimal characters. The regular expression pattern `^\D\d{1,5}\D*$` is defined as shown in the following table.

Element | Description
------- | ----------- 
`^` | Begin the match at the beginning of the input string.
`\D` | Match a non-digit character. 
`\d{1,5}` | Match from one to five decimal digits. 
`\D*` | Match zero, one, or more non-decimal characters. 
`$` | Match the end of the input string.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"^\D\d{1,5}\D*$"; 
      string[] inputs = { "A1039C", "AA0001", "C18A", "Y938518" }; 

      foreach (string input in inputs)
      {
         if (Regex.IsMatch(input, pattern))
            Console.WriteLine(input + ": matched");
         else
            Console.WriteLine(input + ": match failed");
      }
   }
}
// The example displays the following output:
//       A1039C: matched
//       AA0001: match failed
//       C18A: matched
//       Y938518: match failed
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "^\D\d{1,5}\D*$" 
      Dim inputs() As String = { "A1039C", "AA0001", "C18A", "Y938518" } 

      For Each input As String In inputs
         If Regex.IsMatch(input, pattern) Then
            Console.WriteLine(input + ": matched")
         Else
            Console.WriteLine(input + ": match failed")
         End If   
      Next
   End Sub
End Module
' The example displays the following output:
```

## Supported Unicode general categories

Unicode defines the general categories listed in the following table. For more information, see the "UCD File Format" and "General Category Values" subtopics at the [Unicode Character Database](http://www.unicode.org/reports/tr44/).

Category | Description
-------- | -----------
**Lu** | Letter, Uppercase
**Ll** | Letter, Lowercase
**Lt** | Letter, Titlecase
**Lm** | Letter, Modifier
**Lo** | Letter, Other
**L** | All letter characters. This includes the **Lu**, **Ll**, **Lt**, **Lm**, and **Lo** characters.
**Mn** | Mark, Nonspacing
**Mc** | Mark, Spacing Combining
**Me** | Mark, Enclosing
**M** | All diacritic marks. This includes the **Mn**, **Mc**, and **Me** categories.
**Nd** | Number, Decimal Digit
**Nl** | Number, Letter
**No** | Number, Other
**N** | All numbers. This includes the **Nd**, **Nl**, and **No** categories.
**Pc** | Punctuation, Connector
**Pd** | Punctuation, Dash
**Ps** | Punctuation, Open
**Pe** | Punctuation, Close
**Pi** | Punctuation, Initial quote (may behave like Ps or Pe depending on usage)
**Pf** | Punctuation, Final quote (may behave like Ps or Pe depending on usage)
**Po** | Punctuation, Other
**P** | All punctuation characters. This includes the **Pc**, **Pd**, **Ps**, **Pe**, **Pi**, **Pf**, and **Po** categories.
**Sm** | Symbol, Math
**Sc** | Symbol, Currency
**Sk** | Symbol, Modifier
**So** | Symbol, Other
**S** | All symbols. This includes the **Sm**, **Sc**, **Sk**, and **So** categories.
**Zs** | Separator, Space
**Zl** | Separator, Line
**Zp** | Separator, Paragraph
**Z** | All separator characters. This includes the **Zs**, **Zl**, and **Zp** categories.
**Cc** | Other, Control
**Cf** | Other, Format
**Cs** | Other, Surrogate
**Co** | Other, Private Use
**Cn** | Other, Not Assigned (no characters have this property)
**C** | All control characters. This includes the **Cc**, **Cf**, **Cs**, **Co**, and **Cn** categories.
 
##Supported Named Blocks

.NET provides the named blocks listed in the following table. The set of supported named blocks is based on Unicode 4.0 and Perl 5.6.

Code point range | Block name
---------------- | ---------- 
0000 - 007F | **IsBasicLatin**
0080 - 00FF | **IsLatin-1Supplement**
0100 - 017F | **IsLatinExtended-A**
0180 - 024F | **IsLatinExtended-B**
0250 - 02AF | **IsIPAExtensions**
02B0 - 02FF | **IsSpacingModifierLetters**
0300 - 036F | **IsCombiningDiacriticalMarks**
0370 - 03FF | **IsGreek** -or- **IsGreekandCoptic**
0400 - 04FF | **IsCyrillic**
0500 - 052F | **IsCyrillicSupplement**
0530 - 058F | **IsArmenian**
0590 - 05FF | **IsHebrew**
0600 - 06FF | **IsArabic**
0700 - 074F | **IsSyriac**
0780 - 07BF | **IsThaana**
0900 - 097F | **IsDevanagari**
0980 - 09FF | **IsBengali**
0A00 - 0A7F | **IsGurmukhi**
0A80 - 0AFF | **IsGujarati**
0B00 - 0B7F | **IsOriya**
0B80 - 0BFF | **IsTamil**
0C00 - 0C7F | **IsTelugu**
0C80 - 0CFF | **IsKannada**
0D00 - 0D7F | **IsMalayalam**
0D80 - 0DFF | **IsSinhala**
0E00 - 0E7F | **IsThai**
0E80 - 0EFF | **IsLao**
0F00 - 0FFF | **IsTibetan**
1000 - 109F | **IsMyanmar**
10A0 - 10FF | **IsGeorgian**
1100 - 11FF | **IsHangulJamo**
1200 - 137F | **IsEthiopic**
13A0 - 13FF | **IsCherokee**
1400 - 167F | **IsUnifiedCanadianAboriginalSyllabics**
1680 - 169F | **IsOgham**
16A0 - 16FF | **IsRunic**
1700 - 171F | **IsTagalog**
1720 - 173F | **IsHanunoo**
1740 - 175F | **IsBuhid**
1760 - 177F | **IsTagbanwa**
1780 - 17FF | **IsKhmer**
1800 - 18AF | **IsMongolian**
1900 - 194F | **IsLimbu**
1950 - 197F | **IsTaiLe**
19E0 - 19FF | **IsKhmerSymbols**
1D00 - 1D7F | **IsPhoneticExtensions**
1E00 - 1EFF | **IsLatinExtendedAdditional**
1F00 - 1FFF | **IsGreekExtended**
2000 - 206F | **IsGeneralPunctuation**
2070 - 209F | **IsSuperscriptsandSubscripts**
20A0 - 20CF | **IsCurrencySymbols**
20D0 - 20FF | **IsCombiningDiacriticalMarksforSymbols** -or- **IsCombiningMarksforSymbols**
2100 - 214F | **IsLetterlikeSymbols**
2150 - 218F | **IsNumberForms**
2190 - 21FF | **IsArrows**
2200 - 22FF | **IsMathematicalOperators**
2300 - 23FF | **IsMiscellaneousTechnical**
2400 - 243F | **IsControlPictures**
2440 - 245F | **IsOpticalCharacterRecognition**
2460 - 24FF | **IsEnclosedAlphanumerics**
2500 - 257F | **IsBoxDrawing**
2580 - 259F | **IsBlockElements**
25A0 - 25FF | **IsGeometricShapes**
2600 - 26FF | **IsMiscellaneousSymbols**
2700 - 27BF | **IsDingbats**
27C0 - 27EF | **IsMiscellaneousMathematicalSymbols-A**
27F0 - 27FF | **IsSupplementalArrows-A**
2800 - 28FF | **IsBraillePatterns**
2900 - 297F | **IsSupplementalArrows-B**
2980 - 29FF | **IsMiscellaneousMathematicalSymbols-B**
2A00 - 2AFF | **IsSupplementalMathematicalOperators**
2B00 - 2BFF | **IsMiscellaneousSymbolsandArrows**
2E80 - 2EFF | **IsCJKRadicalsSupplement**
2F00 - 2FDF | **IsKangxiRadicals**
2FF0 - 2FFF | **IsIdeographicDescriptionCharacters**
3000 - 303F | **IsCJKSymbolsandPunctuation**
3040 - 309F | **IsHiragana**
30A0 - 30FF | **IsKatakana**
3100 - 312F | **IsBopomofo**
3130 - 318F | **IsHangulCompatibilityJamo**
3190 - 319F | **IsKanbun**
31A0 - 31BF | **IsBopomofoExtended**
31F0 - 31FF | **IsKatakanaPhoneticExtensions**
3200 - 32FF | **IsEnclosedCJKLettersandMonths**
3300 - 33FF | **IsCJKCompatibility**
3400 - 4DBF | **IsCJKUnifiedIdeographsExtensionA**
4DC0 - 4DFF | **IsYijingHexagramSymbols**
4E00 - 9FFF | **IsCJKUnifiedIdeographs**
A000 - A48F | **IsYiSyllables**
A490 - A4CF | **IsYiRadicals**
AC00 - D7AF | **IsHangulSyllables**
D800 - DB7F | **IsHighSurrogates**
DB80 - DBFF | **IsHighPrivateUseSurrogates**
DC00 - DFFF | **IsLowSurrogates**
E000 - F8FF | **IsPrivateUse** or **IsPrivateUseArea**
F900 - FAFF | **IsCJKCompatibilityIdeographs**
FB00 - FB4F | **IsAlphabeticPresentationForms** 
FB50 - FDFF | **IsArabicPresentationForms-A** 
FE00 - FE0F | **IsVariationSelectors** 
FE20 - FE2F | **IsCombiningHalfMarks** 
FE30 - FE4F | **IsCJKCompatibilityForms** 
FE50 - FE6F | **IsSmallFormVariants**
FE70 - FEFF | **IsArabicPresentationForms-B** 
FF00 - FFEF | **IsHalfwidthandFullwidthForms** 
FFF0 - FFFF | **IsSpecials**
 
<a name="character-class-subtraction"></a>
## Character class subtraction: [base_group - [excluded_group]]

A character class defines a set of characters. Character class subtraction yields a set of characters that is the result of excluding the characters in one character class from another character class. 

A character class subtraction expression has the following form:

__[__*base*_*group*-__[__*excluded*_*group*__]]--

The square brackets (**[]**) and hyphen (-) are mandatory. The *base_group* is a positive character group or a negative character group. The *excluded_group* component is another positive or negative character group, or another character class subtraction expression (that is, you can nest character class subtraction expressions). 

For example, suppose you have a base group that consists of the character range from "a" through "z". To define the set of characters that consists of the base group except for the character "m", use `[a-z-[m]]`. To define the set of characters that consists of the base group except for the set of characters "d", "j", and "p", use `[a-z-[djp]]`. To define the set of characters that consists of the base group except for the character range from "m" through "p", use `[a-z-[m-p]]`. 

Consider the nested character class subtraction expression, `[a-z-[d-w-[m-o]]]`. The expression is evaluated from the innermost character range outward. First, the character range from "m" through "o" is subtracted from the character range "d" through "w", which yields the set of characters from "d" through "l" and "p" through "w". That set is then subtracted from the character range from "a" through "z", which yields the set of characters `[abcmnoxyz]`.

You can use any character class with character class subtraction. To define the set of characters that consists of all Unicode characters from \u0000 through \uFFFF except white-space characters (**\s**), the characters in the punctuation general category (**\p{P}**), the characters in the **IsGreek** named block (**\p{IsGreek}**), and the Unicode NEXT LINE control character (\x85), use `[\u0000-\uFFFF-[\s\p{P}\p{IsGreek}\x85]]`.

Choose character classes for a character class subtraction expression that will yield useful results. Avoid an expression that yields an empty set of characters, which cannot match anything, or an expression that is equivalent to the original base group. For example, the empty set is the result of the expression `[\p{IsBasicLatin}-[\x00-\x7F]]`, which subtracts all characters in the **IsBasicLatin** character range from the **IsBasicLatin** general category. Similarly, the original base group is the result of the expression `[a-z-[0-9]]`. This is because the base group, which is the character range of letters from "a" through "z", does not contain any characters in the excluded group, which is the character range of decimal digits from "0" through "9". 

The following example defines a regular expression, `^[0-9-[2468]]+$`, that matches zero and odd digits in an input string. The regular expression is interpreted as shown in the following table.

Element | Description
------- | ----------- 
`^` | Begin the match at the start of the input string.
`[0-9-[2468]]+` | Match one or more occurrences of any character from 0 to 9 except for 2, 4, 6, and 8. In other words, match one or more occurrences of zero or an odd digit.
`$` | End the match at the end of the input string.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "123", "13579753", "3557798", "335599901" };
      string pattern = @"^[0-9-[2468]]+$";

      foreach (string input in inputs)
      {
         Match match = Regex.Match(input, pattern);
         if (match.Success) 
            Console.WriteLine(match.Value);
      }      
   }
}
// The example displays the following output:
//       13579753
//       335599901
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "123", "13579753", "3557798", "335599901" }
      Dim pattern As String = "^[0-9-[2468]]+$"

      For Each input As String In inputs
         Dim match As Match = Regex.Match(input, pattern)
         If match.Success Then Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       13579753
'       335599901
```

## See also

[Regular expression options](options.md)