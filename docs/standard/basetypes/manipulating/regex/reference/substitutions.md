---
title: Substitutions in Regular Expressions
description: Substitutions in Regular Expressions
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: b1a753f6-febc-4c6d-9d04-283203370aed
---

# Substitutions in Regular Expressions


Substitutions are language elements that are recognized only within replacement patterns. They use a regular expression pattern to define all or part of the text that is to replace matched text in the input string. The replacement pattern can consist of one or more substitutions along with literal characters. Replacement patterns are provided to overloads of the [Regex.Replace](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex#System_Text_RegularExpressions_Regex_Matches_System_String_System_String_System_Text_RegularExpressions_RegexOptions_) method that have a *replacement* parameter and to the [Match.Result](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match#System_Text_RegularExpressions_Match_Result_System_String_) method. The methods replace the matched pattern with the pattern that is defined by the *replacement* parameter.

.NET Core defines the substitution elements listed in the following table.

Substitution | Description
------------ | ----------- 
**$**_number_ | Includes the last substring matched by the capturing group that is identified by *number*, where *number* is a decimal value, in the replacement string. For more information, see [Substituting a Numbered Group](#Substituting-a-Numbered-Group).
**${**_name_**}** | Includes the last substring matched by the named group that is designated by **(?<**_name_**>)** in the replacement string. For more information, see [Substituting a Named Group](#Substituting-a-Named-Group).
**$$** | Includes a single "$" literal in the replacement string. For more information, see [Substituting a "$" Symbol](#Substituting-a-"$"-Symbol).
**$&** | Includes a copy of the entire match in the replacement string. For more information, see [Substituting the Entire Match](#Substituting-the-Entire-Match).
**$`** | Includes all the text of the input string before the match in the replacement string. For more information, see [Substituting the Text before the Match](#Substituting-the-Text-before-the-Match).
**$'** | Includes all the text of the input string after the match in the replacement string. For more information, see [Substituting the Text after the Match](#Substituting-the-Text-after-the-Match). 
**$+** | Includes the last group captured in the replacement string. For more information, see [Substituting the Last Captured Group](#Substituting-the-Last-Captured-Group).
**$_** | Includes the entire input string in the replacement string. For more information, see [Substituting the Entire Input String](#Substituting-the-Entire-Input-String).
 
## Substitution Elements and Replacement Patterns

Substitutions are the only special constructs recognized in a replacement pattern. None of the other regular expression language elements, including character escapes and the period (**.**), which matches any character, are supported. Similarly, substitution language elements are recognized only in replacement patterns and are never valid in regular expression patterns. 

The only character that can appear either in a regular expression pattern or in a substitution is the **$** character, although it has a different meaning in each context. In a regular expression pattern, **$** is an anchor that matches the end of the string. In a replacement pattern, **$** indicates the beginning of a substitution. 

> **Note**
>
> For functionality similar to a replacement pattern within a regular expression, use a backreference. For more information about backreferences, see [Backreference Constructs](backreference.md).
 
## Substituting a Numbered Group

The **$**_number_ language element includes the last substring matched by the number capturing group in the replacement string, where *number* is the index of the capturing group. For example, the replacement pattern `$1` indicates that the matched substring is to be replaced by the first captured group. For more information about numbered capturing groups, see [Grouping Constructs in Regular Expressions](grouping.md).

All digits that follow **$** are interpreted as belonging to the number group. If this is not your intent, you can substitute a named group instead. For example, you can use the replacement string **${1}1** instead of **$11** to define the replacement string as the value of the first captured group along with the number "1". For more information, see [Substituting a Named Group](#Substituting-a-Named-Group). 

Capturing groups that are not explicitly assigned names using the **(?<**_name-**>)** syntax are numbered from left to right starting at one. Named groups are also numbered from left to right, starting at one greater than the index of the last unnamed group. For example, in the regular expression `(\w)(?<digit>\d)`, the index of the `digit` named group is 2.

If *number* does not specify a valid capturing group defined in the regular expression pattern, **$**_number_ is interpreted as a literal character sequence that is used to replace each match.

The following example uses the **$**_number_ substitution to strip the currency symbol from a decimal value. It removes currency symbols found at the beginning or end of a monetary value, and recognizes the two most common decimal separators ("." and ","). 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\p{Sc}*(\s?\d+[.,]?\d*)\p{Sc}*";
      string replacement = "$1";
      string input = "$16.32 12.19 £16.29 €18.29  €18,29";
      string result = Regex.Replace(input, pattern, replacement);
      Console.WriteLine(result);
   }
}
// The example displays the following output:
//       16.32 12.19 16.29 18.29  18,29
```

The regular expression pattern `\p{Sc}*(\s?\d+[.,]?\d*)\p{Sc}*` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\p{Sc}*` | Match zero or more currency symbol characters.
`\s?` | Match zero or one white-space characters.
`\d+` | Match one or more decimal digits.
`[.,]?` | Match zero or one period or comma.
`\d*` | Match zero or more decimal digits.
`(\s?\d+[.,]?\d*)` | Match a white space followed by one or more decimal digits, followed by zero or one period or comma, followed by zero or more decimal digits. This is the first capturing group. Because the replacement pattern is `$1`, the call to the [Regex.Replace](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex#System_Text_RegularExpressions_Regex_Matches_System_String_System_String_System_Text_RegularExpressions_RegexOptions_) method replaces the entire matched substring with this captured group. 
 
## Substituting a Named Group

The **${**_name_**}** language element substitutes the last substring matched by the *name* capturing group, where *name* is the name of a capturing group defined by the **(?<**_name_**>)** language element. For more information about named capturing groups, see [Grouping Constructs in Regular Expressions](grouping.md).

If *name* doesn't specify a valid named capturing group defined in the regular expression pattern but consists of digits, **${**_name_**}** is interpreted as a numbered group. 

If *name* specifies neither a valid named capturing group nor a valid numbered capturing group defined in the regular expression pattern, **${**_name_**}** is interpreted as a literal character sequence that is used to replace each match.

The following example uses the **${**_name_**}** substitution to strip the currency symbol from a decimal value. It removes currency symbols found at the beginning or end of a monetary value, and recognizes the two most common decimal separators ("." and ",").

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\p{Sc}*(?<amount>\s?\d+[.,]?\d*)\p{Sc}*";
      string replacement = "${amount}";
      string input = "$16.32 12.19 £16.29 €18.29  €18,29";
      string result = Regex.Replace(input, pattern, replacement);
      Console.WriteLine(result);
   }
}
// The example displays the following output:
//       16.32 12.19 16.29 18.29  18,29
```

The regular expression pattern `\p{Sc}*(?<amount>\s?\d[.,]?\d*)\p{Sc}*` is defined as shown in the following table. 

Pattern | Description
------- | -----------
`\p{Sc}*` | Match zero or more currency symbol characters.
`\s?` | Match zero or one white-space characters.
`\d+` | Match one or more decimal digits.
`[.,]?` | Match zero or one period or comma.
`\d*` | Match zero or more decimal digits.
`(?<amount>\s?\d[.,]?\d*)` | Match a white space, followed by one or more decimal digits, followed by zero or one period or comma, followed by zero or more decimal digits. This is the capturing group named amount. Because the replacement pattern is `${amount}`, the call to the [Regex.Replace](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex#System_Text_RegularExpressions_Regex_Matches_System_String_System_String_System_Text_RegularExpressions_RegexOptions_) method replaces the entire matched substring with this captured group. 
 
## Substituting a "$" Character

The **$$** substitution inserts a literal "$" character in the replaced string. 

The following example uses the [NumberFormatInfo](https://docs.microsoft.com/dotnet/core/api/System.Globalization.NumberFormatInfo) object to determine the current culture's currency symbol and its placement in a currency string. It then builds both a regular expression pattern and a replacement pattern dynamically. If the example is run on a computer whose current culture is en-US, it generates the regular expression pattern `\b(\d+)(\.(\d+))?` and the replacement pattern `$$ $1$2`. The replacement pattern replaces the matched text with a currency symbol and a space followed by the first and second captured groups.

```csharp
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      // Define array of decimal values.
      string[] values= { "16.35", "19.72", "1234", "0.99"};
      // Determine whether currency precedes (True) or follows (False) number.
      bool precedes = NumberFormatInfo.CurrentInfo.CurrencyPositivePattern % 2 == 0;
      // Get decimal separator.
      string cSeparator = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
      // Get currency symbol.
      string symbol = NumberFormatInfo.CurrentInfo.CurrencySymbol;
      // If symbol is a "$", add an extra "$".
      if (symbol == "$") symbol = "$$";

      // Define regular expression pattern and replacement string.
      string pattern = @"\b(\d+)(" + cSeparator + @"(\d+))?"; 
      string replacement = "$1$2";
      replacement = precedes ? symbol + " " + replacement : replacement + " " + symbol;
      foreach (string value in values)
         Console.WriteLine("{0} --> {1}", value, Regex.Replace(value, pattern, replacement));
   }
}
// The example displays the following output:
//       16.35 --> $ 16.35
//       19.72 --> $ 19.72
//       1234 --> $ 1234
//       0.99 --> $ 0.99
```

The regular expression pattern `\b(\d+)(\.(\d+))?` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Start the match at the beginning of a word boundary.
`(\d+)` | Match one or more decimal digits. This is the first capturing group.
`\.` | Match a period (the decimal separator).
`(\d+)` | Match one or more decimal digits. This is the third capturing group.
`(\.(\d+))?` | Match zero or one occurrence of a period followed by one or more decimal digits. This is the second capturing group.
 
## Substituting the Entire Match

The **$&** substitution includes the entire match in the replacement string. Often, it is used to add a substring to the beginning or end of the matched string. For example, the `($&)` replacement pattern adds parentheses to the beginning and end of each match. If there is no match, the **$&** substitution has no effect.

The following example uses the **$&** substitution to add quotation marks at the beginning and end of book titles stored in a string array.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"^(\w+\s?)+$";
      string[] titles = { "A Tale of Two Cities", 
                          "The Hound of the Baskervilles", 
                          "The Protestant Ethic and the Spirit of Capitalism", 
                          "The Origin of Species" };
      string replacement = "\"$&\"";
      foreach (string title in titles)
         Console.WriteLine(Regex.Replace(title, pattern, replacement));
   }
}
// The example displays the following output:
//       "A Tale of Two Cities"
//       "The Hound of the Baskervilles"
//       "The Protestant Ethic and the Spirit of Capitalism"
//       "The Origin of Species"
```

The regular expression pattern `^(\w+\s?)+$` is defined as shown in the following table.

Pattern | Description
------- | -----------
`^` | Start the match at the beginning of the input string.
`(\w+\s?)+` | Match the pattern of one or more word characters followed by zero or one white-space characters one or more times. 
`$` | Match the end of the input string.

The `"$&"` replacement pattern adds a literal quotation mark to the beginning and end of each match.

## Substituting the Text Before the Match

The **$`** substitution replaces the matched string with the entire input string before the match. That is, it duplicates the input string up to the match while removing the matched text. Any text that follows the matched text is unchanged in the result string. If there are multiple matches in an input string, the replacement text is derived from the original input string, rather than from the string in which text has been replaced by earlier matches. (The example provides an illustration.) If there is no match, the **$`** substitution has no effect.

The following example uses the regular expression pattern `\d+` to match a sequence of one or more decimal digits in the input string. The replacement string **$`** replaces these digits with the text that precedes the match. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "aa1bb2cc3dd4ee5";
      string pattern = @"\d+";
      string substitution = "$`";
      Console.WriteLine("Matches:");
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("   {0} at position {1}", match.Value, match.Index);

      Console.WriteLine("Input string:  {0}", input);
      Console.WriteLine("Output string: " + 
                        Regex.Replace(input, pattern, substitution));
   }
}
// The example displays the following output:
//    Matches:
//       1 at position 2
//       2 at position 5
//       3 at position 8
//       4 at position 11
//       5 at position 14
//    Input string:  aa1bb2cc3dd4ee5
//    Output string: aaaabbaa1bbccaa1bb2ccddaa1bb2cc3ddeeaa1bb2cc3dd4ee
```

In this example, the input string `"aa1bb2cc3dd4ee5"` contains five matches. The following table illustrates how the $` substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the Result string column.

Match | Position | String before match | Result string
----- | -------- | ------------------- | -------------
1 | 2 | aa | aa**aa**bb2cc3dd4ee5
2 | 5 | aa1bb | aaaabb**aa1bb**cc3dd4ee5
3 | 8 | aa1bb2cc | aaaabbaa1bbcc**aa1bb2cc**dd4ee5
4 | 11 | aa1bb2cc3dd | aaaabbaa1bbccaa1bb2ccdd**aa1bb2cc3dd**ee5
5 | 14 | aa1bb2cc3dd4ee | aaaabbaa1bbccaa1bb2ccddaa1bb2cc3ddee **aa1bb2cc3dd4ee**
 
## Substituting the Text After the Match

The **$'** substitution replaces the matched string with the entire input string after the match. That is, it duplicates the input string after the match while removing the matched text. Any text that precedes the matched text is unchanged in the result string. If there is no match, the **$'** substitution has no effect.

The following example uses the regular expression pattern `\d+` to match a sequence of one or more decimal digits in the input string. The replacement string **$'** replaces these digits with the text that follows the match. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "aa1bb2cc3dd4ee5";
      string pattern = @"\d+";
      string substitution = "$'";
      Console.WriteLine("Matches:");
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("   {0} at position {1}", match.Value, match.Index);
      Console.WriteLine("Input string:  {0}", input);
      Console.WriteLine("Output string: " + 
                        Regex.Replace(input, pattern, substitution));
   }
}
// The example displays the following output:
//    Matches:
//       1 at position 2
//       2 at position 5
//       3 at position 8
//       4 at position 11
//       5 at position 14
//    Input string:  aa1bb2cc3dd4ee5
//    Output string: aaaabbaa1bbccaa1bb2ccddaa1bb2cc3ddeeaa1bb2cc3dd4ee
```

In this example, the input string `"aa1bb2cc3dd4ee5"` contains five matches. The following table illustrates how the **$'** substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the Result string column.

Match | Position | String before match | Result string
----- | -------- | ------------------- | -------------
1 | 2 | bb2cc3dd4ee5 | aa**bb2cc3dd4ee5**bb2cc3dd4ee5
2 | 5 | cc3dd4ee5 | aabb2cc3dd4ee5bb**cc3dd4ee5**cc3dd4ee5
3 | 8 | dd4ee5 | aabb2cc3dd4ee5bbcc3dd4ee5cc**dd4ee5**dd4ee5
4 | 11 | ee5 | aabb2cc3dd4ee5bbcc3dd4ee5ccdd4ee5dd**ee5**ee5
5 | 14 | [String.Empty](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Empty) | aabb2cc3dd4ee5bbcc3dd4ee5ccdd4ee5ddee5ee
 
## Substituting the Last Captured Group

The **$+** substitution replaces the matched string with the last captured group. If there are no captured groups or if the value of the last captured group is [String.Empty](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Empty), the **$+** substitution has no effect.

The following example identifies duplicate words in a string and uses the **$+** substitution to replace them with a single occurrence of the word. The [RegexOptions.IgnoreCase](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.RegexOptions#System_Text_RegularExpressions_RegexOptions_IgnoreCase) option is used to ensure that words that differ in case but that are otherwise identical are considered duplicates.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\w+)\s\1\b";
      string substitution = "$+";
      string input = "The the dog jumped over the fence fence.";
      Console.WriteLine(Regex.Replace(input, pattern, substitution, 
                        RegexOptions.IgnoreCase));
   }
}
// The example displays the following output:
//      The dog jumped over the fence.
```

The regular expression pattern `\b(\w+)\s\1\b` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Begin the match at a word boundary.
`(\w+)` | Match one or more word characters. This is the first capturing group.
`\s` | Match a white-space character.
`\1` | Match the first captured group.
`\b` | End the match at a word boundary.
 
## Substituting the Entire Input String

The **$_** substitution replaces the matched string with the entire input string. That is, it removes the matched text and replaces it with the entire string, including the matched text.

The following example matches one or more decimal digits in the input string. It uses the **$_** substitution to replace them with the entire input string.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "ABC123DEF456";
      string pattern = @"\d+";
      string substitution = "$_";
      Console.WriteLine("Original string:          {0}", input);
      Console.WriteLine("String with substitution: {0}", 
                        Regex.Replace(input, pattern, substitution));      
   }
}
// The example displays the following output:
//       Original string:          ABC123DEF456
//       String with substitution: ABCABC123DEF456DEFABC123DEF456
```

In this example, the input string `"ABC123DEF456"` contains two matches. The following table illustrates how the **$_** substitution causes the regular expression engine to replace each match in the input string. Inserted text is shown in bold in the Result string column.

Match | Position | String before match | Result string
----- | -------- | ------------------- | -------------
1 | 3 | 123 | ABC**ABC123DEF456**DEF456
2 | 5 | 456 | ABCABC123DEF456DEF**ABC123DEF456**
 
## See Also

[Regular Expression Language - Quick Reference](index.md)

