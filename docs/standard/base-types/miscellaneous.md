---
title: Miscellaneous constructs in regular expressions
description: Miscellaneous constructs in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 478901dc-db6c-4d90-9d3b-f5cfdca2cbf5
---

# Miscellaneous constructs in regular expressions


Regular expressions in .NET include three miscellaneous language constructs. One lets you enable or disable particular matching options in the middle of a regular expression pattern. The remaining two let you include comments in a regular expression.

## Inline Options

You can set or disable specific pattern matching options for part of a regular expression by using the syntax

```
(?imnsx-imnsx)
```

You list the options you want to enable after the question mark, and the options you want to disable after the minus sign. The following table describes each option. For more information about each option, see [Regular expression options](options.md).

Option | Description
------ | ----------- 
**i** | Case-insensitive matching.
**m** | Multiline mode.
**n** | Explicit captures only. (Parentheses do not act as capturing groups.)
**s** | Single-line mode.
**x** | Ignore unescaped white space, and allow x-mode comments. 
 
Any change in regular expression options defined by the **(?imnsx-imnsx)** construct remains in effect until the end of the enclosing group.

> [!NOTE]
> The **(?imnsx-imnsx**:_subexpression_**)** grouping construct provides identical functionality for a subexpression. For more information, see [Grouping constructs in regular expressions](grouping.md).
 
The following example uses the **i**, **n**, and **x** options to enable case insensitivity and explicit captures, and to ignore white space in the regular expression pattern in the middle of a regular expression. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern; 
      string input = "double dare double Double a Drooling dog The Dreaded Deep";

      pattern = @"\b(D\w+)\s(d\w+)\b";
      // Match pattern using default options.
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine(match.Value);
         if (match.Groups.Count > 1)
            for (int ctr = 1; ctr < match.Groups.Count; ctr++) 
               Console.WriteLine("   Group {0}: {1}", ctr, match.Groups[ctr].Value);
      }
      Console.WriteLine();

      // Change regular expression pattern to include options.
      pattern = @"\b(D\w+)(?ixn) \s (d\w+) \b";
      // Match new pattern with options. 
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine(match.Value);
         if (match.Groups.Count > 1)
            for (int ctr = 1; ctr < match.Groups.Count; ctr++) 
               Console.WriteLine("   Group {0}: '{1}'", ctr, match.Groups[ctr].Value);
      }
   }
}
// The example displays the following output:
//       Drooling dog
//          Group 1: Drooling
//          Group 2: dog
//       
//       Drooling dog
//          Group 1: 'Drooling'
//       Dreaded Deep
//          Group 1: 'Dreaded'
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String 
      Dim input As String = "double dare double Double a Drooling dog The Dreaded Deep"

      pattern = "\b(D\w+)\s(d\w+)\b"
      ' Match pattern using default options.
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
         If match.Groups.Count > 1 Then
            For ctr As Integer = 1 To match.Groups.Count - 1 
               Console.WriteLine("   Group {0}: {1}", ctr, match.Groups(ctr).Value)
            Next
         End If
      Next
      Console.WriteLine()

      ' Change regular expression pattern to include options.
      pattern = "\b(D\w+)(?ixn) \s (d\w+) \b"
      ' Match new pattern with options. 
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
         If match.Groups.Count > 1 Then
            For ctr As Integer = 1 To match.Groups.Count - 1 
               Console.WriteLine("   Group {0}: '{1}'", ctr, match.Groups(ctr).Value)
            Next
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       Drooling dog
'          Group 1: Drooling
'          Group 2: dog
'       
'       Drooling dog
'          Group 1: 'Drooling'
'       Dreaded Deep
'          Group 1: 'Dreaded'
```

The example defines two regular expressions. The first, `\b(D\w+)\s(d\w+)\b`, matches two consecutive words that begin with an uppercase "D" and a lowercase "d". The second regular expression, `\b(D\w+)(?ixn) \s (d\w+) \b`, uses inline options to modify this pattern, as described in the following table. A comparison of the results confirms the effect of the `(?ixn)` construct.

Pattern | Description
------- | ----------- 
`\b` | Start at a word boundary.
`(D\w+)` | Match a capital "D" followed by one or more word characters. This is the first capture group.
`(?ixn)` | From this point on, make comparisons case-insensitive, make only explicit captures, and ignore white space in the regular expression pattern.
`\s` | Match a white-space character.
`(d\w+)` | Match an uppercase or lowercase "d" followed by one or more word characters. This group is not captured because the n (explicit capture) option was enabled..
`\b` | Match a word boundary.
 
## Inline Comment

The **(?#** _comment_**)** construct lets you include an inline comment in a regular expression. The regular expression engine does not use any part of the comment in pattern matching, although the comment is included in the string that is returned by the [Regex.ToString](xref:System.Text.RegularExpressions.Regex.Unescape(System.String)) method. The comment ends at the first closing parenthesis.

The following example repeats the first regular expression pattern from the example in the previous section. It adds two inline comments to the regular expression to indicate whether the comparison is case-sensitive. The regular expression pattern, `\b((?# case-sensitive comparison)D\w+)\s((?#case-insensitive comparison)d\w+)\b`, is defined as follows.

Pattern | Description
------- | ----------- 
`\b` | Start at a word boundary.
`(?# case-sensitive comparison)` | A comment. It does not affect pattern-matching behavior.
`(D\w+)` | Match a capital "D" followed by one or more word characters. This is the first capturing group.
`\s` | Match a white-space character.
`(?ixn)` |`From this point on, make comparisons case-insensitive, make only explicit captures, and ignore white space in the regular expression pattern.
`(?#case-insensitive comparison)` | A comment. It does not affect pattern-matching behavior. 
`(d\w+)` | Match an uppercase or lowercase "d" followed by one or more word characters. This is the second capture group.
`\b` | Match a word boundary.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b((?# case sensitive comparison)D\w+)\s(?ixn)((?#case insensitive comparison)d\w+)\b";
      Regex rgx = new Regex(pattern);
      string input = "double dare double Double a Drooling dog The Dreaded Deep";

      Console.WriteLine("Pattern: " + pattern.ToString());
      // Match pattern using default options.
      foreach (Match match in rgx.Matches(input))
      {
         Console.WriteLine(match.Value);
         if (match.Groups.Count > 1)
         {
            for (int ctr = 1; ctr <match.Groups.Count; ctr++) 
               Console.WriteLine("   Group {0}: {1}", ctr, match.Groups[ctr].Value);
         }
      }
   }
}
// The example displays the following output:
//    Pattern: \b((?# case sensitive comparison)D\w+)\s(?ixn)((?#case insensitive comp
//    arison)d\w+)\b
//    Drooling dog
//       Group 1: Drooling
//    Dreaded Deep
//       Group 1: Dreaded
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b((?# case sensitive comparison)D\w+)\s(?ixn)((?#case insensitive comparison)d\w+)\b"
      Dim rgx As New Regex(pattern)
      Dim input As String = "double dare double Double a Drooling dog The Dreaded Deep"

      Console.WriteLine("Pattern: " + pattern.ToString())
      ' Match pattern using default options.
      For Each match As Match In rgx.Matches(input)
         Console.WriteLine(match.Value)
         If match.Groups.Count > 1 Then
            For ctr As Integer = 1 To match.Groups.Count - 1 
               Console.WriteLine("   Group {0}: {1}", ctr, match.Groups(ctr).Value)
            Next
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    Pattern: \b((?# case sensitive comparison)D\w+)\s(?ixn)((?#case insensitive comp
'    arison)d\w+)\b
'    Drooling dog
'       Group 1: Drooling
'    Dreaded Deep
'       Group 1: Dreaded
```

## End-of-Line Comment

A number sign (**#**) marks an x-mode comment, which starts at the unescaped # character at the end of the regular expression pattern and continues until the end of the line. To use this construct, you must either enable the **x** option (through inline options) or supply the [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) value to the *option* parameter when instantiating the [Regex](xref:System.Text.RegularExpressions.Regex) object or calling a static [Regex](xref:System.Text.RegularExpressions.Regex) method. 

The following example illustrates the end-of-line comment construct. It determines whether a string is a composite format string that includes at least one format item. The following table describes the constructs in the regular expression pattern: 

`\{\d+(,-*\d+)*(\:\w{1,4}?)*\}(?x) # Looks for a composite format item`. 

Pattern | Description
------- | ----------- 
`\{` | Match an opening brace.
`\d+` | Match one or more decimal digits.
`(,-*\d+)*` | Match zero or one occurrence of a comma, followed by an optional minus sign, followed by one or more decimal digits.
`(\:\w{1,4}?)*` | Match zero or one occurrence of a colon, followed by one to four, but as few as possible, white-space characters.
`(?#case insensitive comparison)` | An inline comment. It has no effect on pattern-matching behavior.
`\}` | Match a closing brace.
`(?x)` | Enable the ignore pattern white-space option so that the end-of-line comment will be recognized.
`# Looks for a composite format item.` | An end-of-line comment.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\{\d+(,-*\d+)*(\:\w{1,4}?)*\}(?x) # Looks for a composite format item.";
      string input = "{0,-3:F}";
      Console.WriteLine("'{0}':", input);
      if (Regex.IsMatch(input, pattern))
         Console.WriteLine("   contains a composite format item.");
      else
         Console.WriteLine("   does not contain a composite format item.");
   }
}
// The example displays the following output:
//       '{0,-3:F}':
//          contains a composite format item.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\{\d+(,-*\d+)*(\:\w{1,4}?)*\}(?x) # Looks for a composite format item."
      Dim input As String = "{0,-3:F}"
      Console.WriteLine("'{0}':", input)
      If Regex.IsMatch(input, pattern) Then
         Console.WriteLine("   contains a composite format item.")
      Else
         Console.WriteLine("   does not contain a composite format item.")
      End If
   End Sub
End Module
' The example displays the following output:
'       '{0,-3:F}':
'          contains a composite format item.
```

Note that, instead of providing the `(?x)` construct in the regular expression, the comment could also have been recognized by calling the [Regex.IsMatch(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method and passing it the [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) enumeration value.

## See Also

[Regular expression language - quick reference](quick-ref.md)

