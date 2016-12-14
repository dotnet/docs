---
title: Character escapes in regular expressions
description: Character escapes in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 41d35531-2af9-47d4-9780-fbc1e682fbc2
---

# Character escapes in regular expressions

The backslash (\) in a regular expression indicates one of the following: 

* The character that follows it is a special character, as shown in the table in the following section. For example, **\b** is an anchor that indicates that a regular expression match should begin on a word boundary, **\t** represents a tab, and **\x020** represents a space.

* A character that otherwise would be interpreted as an unescaped language construct should be interpreted literally. For example, a brace (**{**) begins the definition of a quantifier, but a backslash followed by a brace (**\{**) indicates that the regular expression engine should match the brace. Similarly, a single backslash marks the beginning of an escaped language construct, but two backslashes (**\\**) indicate that the regular expression engine should match the backslash.

> [!NOTE]
> Character escapes are recognized in regular expression patterns but not in replacement patterns. 
 
## Character Escapes in .NET

The following table lists the character escapes supported by regular expressions in .NET.

Character or sequence | Description
--------------------- | ----------- 
All characters except for the following: **. $ ^ { [ ( &#124; ) * + ? \** | Characters other than those listed in the **Character or sequence** column have no special meaning in regular expressions; they match themselves. The characters included in the **Character or sequence** column are special regular expression language elements. To match them in a regular expression, they must be escaped or included in a positive character group. For example, the regular expression `\$\d+ or [$]\d+` matches "$1200". 
**\a** | Matches a bell (alarm) character, **\u0007**.
**\b** | In a __[__*character*_*group*__]__ character class, matches a backspace, **\u0008**. (See [Character classes in regular expressions](classes.md).) Outside a character class, **\b** is an anchor that matches a word boundary. (See [Anchors in regular expressions](anchors.md).)
**\t** | Matches a tab, **\u0009**.
**\r** | Matches a carriage return, **\u000D**. Note that **\r** is not equivalent to the newline character, **\n**.
**\v** | Matches a vertical tab, **\u000B**.
**\f** | Matches a form feed, **\u000C**.
**\n** | Matches a new line, **\u000A**.
**\e** | Matches an escape, **\u001B**.
**\**_nnn_ | Matches an ASCII character, where nnn consists of two or three digits that represent the octal character code. For example, `\040` represents a space character. This construct is interpreted as a backreference if it has only one digit (for example, `\2`) or if it corresponds to the number of a capturing group. (See [Backreference constructs in regular expressions](backreference.md).) 
**\x**_nn_ | Matches an ASCII character, where *nn* is a two-digit hexadecimal character code.
**\c**_X_ | Matches an ASCII control character, where *X* is the letter of the control character. For example, `\cC` is CTRL-C.
**\u**_nnnn_ | Matches a UTF-16 code unit whose value is *nnnn* hexadecimal. **Note** The Perl 5 character escape that is used to specify Unicode is not supported by .NET. The Perl 5 character escape has the form **\x{####…}**, where **####…** is a series of hexadecimal digits. Instead, use **\u**_nnnn_. 
**\** | When followed by a character that is not recognized as an escaped character, matches that character. For example, `\*` matches an asterisk (*) and is the same as `\x2A`.
 
## Example

The following example illustrates the use of character escapes in a regular expression. It parses a string that contains the names of the world's largest cities and their populations in 2009. Each city name is separated from its population by a tab (**\t**) or a vertical bar (| or `\u007c`). Individual cities and their populations are separated from each other by a carriage return and line feed. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string delimited = @"\G(.+)[\t\u007c](.+)\r?\n";
      string input = "Mumbai, India|13,922,125\t\n" + 
                            "Shanghai, China\t13,831,900\n" + 
                            "Karachi, Pakistan|12,991,000\n" + 
                            "Delhi, India\t12,259,230\n" + 
                            "Istanbul, Turkey|11,372,613\n";
      Console.WriteLine("Population of the World's Largest Cities, 2009");
      Console.WriteLine();
      Console.WriteLine("{0,-20} {1,10}", "City", "Population");
      Console.WriteLine();
      foreach (Match match in Regex.Matches(input, delimited))
         Console.WriteLine("{0,-20} {1,10}", match.Groups[1].Value, 
                                            match.Groups[2].Value);
   }
}
// The example displyas the following output:
//       Population of the World's Largest Cities, 2009
//       
//       City                 Population
//       
//       Mumbai, India        13,922,125
//       Shanghai, China      13,831,900
//       Karachi, Pakistan    12,991,000
//       Delhi, India         12,259,230
//       Istanbul, Turkey     11,372,613
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim delimited As String = "\G(.+)[\t\u007c](.+)\r?\n"
      Dim input As String = "Mumbai, India|13,922,125" + vbCrLf + _
                            "Shanghai, China" + vbTab + "13,831,900" + vbCrLf + _
                            "Karachi, Pakistan|12,991,000" + vbCrLf + _
                            "Delhi, India" + vbTab + "12,259,230" + vbCrLf + _
                            "Istanbul, Turkey|11,372,613" + vbCrLf
      Console.WriteLine("Population of the World's Largest Cities, 2009")
      Console.WriteLine()
      Console.WriteLine("{0,-20} {1,10}", "City", "Population")
      Console.WriteLine()
      For Each match As Match In Regex.Matches(input, delimited)
         Console.WriteLine("{0,-20} {1,10}", match.Groups(1).Value, _
                                            match.Groups(2).Value)
      Next                         
   End Sub
End Module
' The example displays the following output:
'       Population of the World's Largest Cities, 2009
'       
'       City                 Population
'       
'       Mumbai, India        13,922,125
'       Shanghai, China      13,831,900
'       Karachi, Pakistan    12,991,000
'       Delhi, India         12,259,230
'       Istanbul, Turkey     11,372,613
```

The regular expression `\G(.+)[\t|\u007c](.+)\r?\n` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`\G` | Begin the match where the last match ended.
`(.+)` | Match any character one or more times. This is the first capturing group.
`[\t\u007c]` | Match a tab (**\t**) or a vertical bar (&#124;).
`(.+)` | Match any character one or more times. This is the second capturing group.
`\r?\n` | Match zero or one occurrence of a carriage return followed by a new line.
 
## See Also

[Regular expression language - quick reference](quick-ref.md)

