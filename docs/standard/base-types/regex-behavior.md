---
title: Details of regular expression behavior
description: Details of regular expression behavior
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 6f11047f-45a4-4caf-a259-18abe08cc0d2
---

# Details of regular expression behavior


The .NET regular expression engine is a backtracking regular expression matcher that incorporates a traditional Nondeterministic Finite Automaton (NFA) engine such as that used by Perl, Python, Emacs, and Tcl. This distinguishes it from faster, but more limited, pure regular expression Deterministic Finite Automaton (DFA) engines such as those found in awk, egrep, or lex. This also distinguishes it from standardized, but slower, POSIX NFAs. The following section describes the three types of regular expression engines, and explains why regular expressions in .NET are implemented by using a traditional NFA engine.

## Benefits of the NFA Engine

When DFA engines perform pattern matching, their processing order is driven by the input string. The engine begins at the beginning of the input string and proceeds sequentially to determine whether the next character matches the regular expression pattern. They can guarantee to match the longest string possible. Because they never test the same character twice, DFA engines do not support backtracking. However, because a DFA engine contains only finite state, it cannot match a pattern with backreferences, and because it does not construct an explicit expansion, it cannot capture subexpressions.

Unlike DFA engines, when traditional NFA engines perform pattern matching, their processing order is driven by the regular expression pattern. As it processes a particular language element, the engine uses greedy matching; that is, it matches as much of the input string as it possibly can. But it also saves its state after successfully matching a subexpression. If a match eventually fails, the engine can return to a saved state so it can try additional matches. This process of abandoning a successful subexpression match so that later language elements in the regular expression can also match is known as backtracking. NFA engines use backtracking to test all possible expansions of a regular expression in a specific order and accept the first match. Because a traditional NFA engine constructs a specific expansion of the regular expression for a successful match, it can capture subexpression matches and matching backreferences. However, because a traditional NFA backtracks, it can visit the same state multiple times if it arrives at the state over different paths. As a result, it can run exponentially slowly in the worst case. Because a traditional NFA engine accepts the first match it finds, it can also leave other (possibly longer) matches undiscovered.

POSIX NFA engines are like traditional NFA engines, except that they continue to backtrack until they can guarantee that they have found the longest match possible. As a result, a POSIX NFA engine is slower than a traditional NFA engine, and when you use a POSIX NFA engine, you cannot favor a shorter match over a longer one by changing the order of the backtracking search. 

Traditional NFA engines are favored by programmers because they offer greater control over string matching than either DFA or POSIX NFA engines. Although, in the worst case, they can run slowly, you can steer them to find matches in linear or polynomial time by using patterns that reduce ambiguities and limit backtracking. In other words, although NFA engines trade performance for power and flexibility, in most cases they offer good to acceptable performance if a regular expression is well-written and avoids cases in which backtracking degrades performance exponentially.

> [!NOTE]
> For information about the performance penalty caused by excessive backtracking and ways to craft a regular expression to work around them, see [Backtracking in Regular Expressions](backtracking.md).
 
## .NET Framework Engine Capabilities

To take advantage of the benefits of a traditional NFA engine, the .NET regular expression engine includes a complete set of constructs to enable programmers to steer the backtracking engine. These constructs can be used to find matches faster or to favor specific expansions over others.

Other features of the .NET regular expression engine include the following: 

### Lazy quantifiers

Lazy quantifiers: **??**, __*?__, **+?**, **{**_n_**,**_m_**}?**. These constructs tell the backtracking engine to search the minimum number of repetitions first. In contrast, ordinary greedy quantifiers try to match the maximum number of repetitions first. The following example illustrates the difference between the two. A regular expression matches a sentence that ends in a number, and a capturing group is intended to extract that number. The regular expression `.+(\d+)\.` includes the greedy quantifier `.+`, which causes the regular expression engine to capture only the last digit of the number. In contrast, the regular expression `.+?(\d+)\.` includes the lazy quantifier `.+?`, which causes the regular expression engine to capture the entire number.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string greedyPattern = @".+(\d+)\.";
      string lazyPattern = @".+?(\d+)\.";
      string input = "This sentence ends with the number 107325.";
      Match match;

      // Match using greedy quantifier .+.
      match = Regex.Match(input, greedyPattern);
      if (match.Success)
         Console.WriteLine("Number at end of sentence (greedy): {0}", 
                           match.Groups[1].Value);
      else
         Console.WriteLine("{0} finds no match.", greedyPattern);
       // Match using lazy quantifier .+?.
      match = Regex.Match(input, lazyPattern);
      if (match.Success)
         Console.WriteLine("Number at end of sentence (lazy): {0}", 
                           match.Groups[1].Value);
      else
         Console.WriteLine("{0} finds no match.", lazyPattern);
   }
}
// The example displays the following output:
//       Number at end of sentence (greedy): 5
//       Number at end of sentence (lazy): 107325
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim greedyPattern As String = ".+(\d+)\."
      Dim lazyPattern As String = ".+?(\d+)\."
      Dim input As String = "This sentence ends with the number 107325."
      Dim match As Match

      ' Match using greedy quantifier .+.
      match = Regex.Match(input, greedyPattern)
      If match.Success Then
         Console.WriteLine("Number at end of sentence (greedy): {0}", 
                           match.Groups(1).Value)
      Else
         Console.WriteLine("{0} finds no match.", greedyPattern)
      End If

      ' Match using lazy quantifier .+?.
      match = Regex.Match(input, lazyPattern)
      If match.Success Then
         Console.WriteLine("Number at end of sentence (lazy): {0}", 
                           match.Groups(1).Value)
      Else
         Console.WriteLine("{0} finds no match.", lazyPattern)
      End If
   End Sub
End Module
' The example displays the following output:
'       Number at end of sentence (greedy): 5
'       Number at end of sentence (lazy): 107325
```

The greedy and lazy versions of this regular expression are defined as shown in the following table.

Pattern | Description
------- | -----------
`.+` (greedy quantifier) | Match at least one occurrence of any character. This causes the regular expression engine to match the entire string, and then to backtrack as needed to match the remainder of the pattern.
`.+?` (lazy quantifier) | Match at least one occurrence of any character, but match as few as possible.
`(\d+)` | Match at least one numeric character, and assign it to the first capturing group.
`\.` | Match a period.
 
For more information about lazy quantifiers, see [Quantifiers in regular expressions](quantifiers.md).

### Positive lookahead

Positive lookahead: **(?**=_subexpression_**)**. This feature allows the backtracking engine to return to the same spot in the text after matching a subexpression. It is useful for searching throughout the text by verifying multiple patterns that start from the same position. It also allows the engine to verify that a substring exists at the end of the match without including the substring in the matched text. The following example uses positive lookahead to extract the words in a sentence that are not followed by punctuation symbols.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[A-Z]+\b(?=\P{P})";
      string input = "If so, what comes next?";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       If
//       what
//       comes
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b[A-Z]+\b(?=\P{P})"
      Dim input As String = "If so, what comes next?"
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine(match.Value)
      Next   
   End Sub
End Module
' The example displays the following output:
'       If
'       what
'       comes
```

The regular expression `\b[A-Z]+\b(?=\P{P})` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`[A-Z]+` | Match any alphabetic character one or more times. Because the [Regex.Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method is called with the [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) option, the comparison is case-insensitive. 
`\b` | End the match at a word boundary.
`(?=\P{P})` | Look ahead to determine whether the next character is a punctuation symbol. If it is not, the match succeeds.

For more information about positive lookahead assertions, see [Grouping constructs in regular expressions](grouping.md).

### Negative lookahead

Negative lookahead: **(?!**_subexpression_**)**. This feature adds the ability to match an expression only if a subexpression fails to match. This is particularly powerful for pruning a search, because it is often simpler to provide an expression for a case that should be eliminated than an expression for cases that must be included. For example, it is difficult to write an expression for words that do not begin with "non". The following example uses negative lookahead to exclude them.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(?!non)\w+\b";
      string input = "Nonsense is not always non-functional.";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       is
//       not
//       always
//       functional
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(?!non)\w+\b"
      Dim input As String = "Nonsense is not always non-functional."
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       is
'       not
'       always
'       functional
```

The regular expression pattern `\b(?!non)\w+\b` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`(?!non)` | Look ahead to ensure that the current string does not begin with "non". If it does, the match fails.
`(\w+)` | Match one or more word characters.
`\b` | End the match at a word boundary.
 
For more information about negative lookahead assertions, see [Grouping constructs in regular expressions](grouping.md).

### Conditional evaluation

Conditional evaluation: **(?(**_expression_**)**_yes_&#124;_no_**)** and**(?(**_name_**)**_yes_&#124;_no_**)**, where *expression* is a subexpression to match, *name* is the name of a capturing group, *yes* is the string to match if *expression* is matched or *name* is a valid, non-empty captured group, and *no* is the subexpression to match if *expression* is not matched or *name* is not a valid, non-empty captured group. This feature allows the engine to search by using more than one alternate pattern, depending on the result of a previous subexpression match or the result of a zero-width assertion. This allows a more powerful form of backreference that permits, for example, matching a subexpression based on whether a previous subexpression was matched. The regular expression in the following example matches paragraphs that are intended for both public and internal use. Paragraphs intended only for internal use begin with a `<PRIVATE>` tag. The regular expression pattern `^(?<Pvt>\<PRIVATE\>\s)?(?(Pvt)((\w+\p{P}?\s)+)|((\w+\p{P}?\s)+))\r?$` uses conditional evaluation to assign the contents of paragraphs intended for public and for internal use to separate capturing groups. These paragraphs can then be handled differently.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "<PRIVATE> This is not for public consumption." + Environment.NewLine + 
                     "But this is for public consumption." + Environment.NewLine + 
                     "<PRIVATE> Again, this is confidential.\n";  
      string pattern = @"^(?<Pvt>\<PRIVATE\>\s)?(?(Pvt)((\w+\p{P}?\s)+)|((\w+\p{P}?\s)+))\r?$";
      string publicDocument = null, privateDocument = null;

      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
      {
         if (match.Groups[1].Success) {
            privateDocument += match.Groups[1].Value + "\n";
         }
         else {
            publicDocument += match.Groups[3].Value + "\n";   
            privateDocument += match.Groups[3].Value + "\n";
         }  
      }

      Console.WriteLine("Private Document:");
      Console.WriteLine(privateDocument);
      Console.WriteLine("Public Document:");
      Console.WriteLine(publicDocument);
   }
}
// The example displays the following output:
//    Private Document:
//    This is not for public consumption.
//    But this is for public consumption.
//    Again, this is confidential.
//    
//    Public Document:
//    But this is for public consumption.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "<PRIVATE> This is not for public consumption." + vbCrLf + _
                            "But this is for public consumption." + vbCrLf + _
                            "<PRIVATE> Again, this is confidential." + vbCrLf
      Dim pattern As String = "^(?<Pvt>\<PRIVATE\>\s)?(?(Pvt)((\w+\p{P}?\s)+)|((\w+\p{P}?\s)+))\r?$"
      Dim publicDocument As String = Nothing
      Dim privateDocument As String = Nothing

      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Multiline)
         If match.Groups(1).Success Then
            privateDocument += match.Groups(1).Value + vbCrLf
         Else
            publicDocument += match.Groups(3).Value + vbCrLf   
            privateDocument += match.Groups(3).Value + vbCrLf
         End If  
      Next

      Console.WriteLine("Private Document:")
      Console.WriteLine(privateDocument)
      Console.WriteLine("Public Document:")
      Console.WriteLine(publicDocument)
   End Sub
End Module
' The example displays the following output:
'    Private Document:
'    This is not for public consumption.
'    But this is for public consumption.
'    Again, this is confidential.
'    
'    Public Document:
'    But this is for public consumption.
```

The regular expression pattern is defined as shown in the following table.

Pattern | Description
------- | -----------
`^` | Begin the match at the beginning of a line.
`(?<Pvt>\<PRIVATE\>\s)?` | Match zero or one occurrence of the string `<PRIVATE>` followed by a white-space character. Assign the match to a capturing group named Pvt.
`(?(Pvt)((\w+\p{P}?\s)+)` | If the `Pvt` capturing group exists, match one or more occurrences of one or more word characters followed by zero or one punctuation separator followed by a white-space character. Assign the substring to the first capturing group.
`&#124;((\w+\p{P}?\s)+))` | If the `Pvt` capturing group does not exist, match one or more occurrences of one or more word characters followed by zero or one punctuation separator followed by a white-space character. Assign the substring to the third capturing group.
`\r?$` | Match the end of a line or the end of the string.
 
For more information about conditional evaluation, see [Alternation constructs in regular expressions](alternation.md).

### Balancing group definitions

Balancing group definitions: **(?<**_name1-name2_**>** _subexpression_**)**. This feature allows the regular expression engine to keep track of nested constructs such as parentheses or opening and closing brackets. For an example, see [Grouping constructs in regular expressions](grouping.md).

### Nonbacktracking subexpressions

Nonbacktracking subexpressions (also known as greedy subexpressions): **(?>**_subexpression_**)**. This feature allows the backtracking engine to guarantee that a subexpression matches only the first match found for that subexpression, as if the expression were running independent of its containing expression. If you do not use this construct, backtracking searches from the larger expression can change the behavior of a subexpression. For example, the regular expression `(a+)\w` matches one or more "a" characters, along with a word character that follows the sequence of "a" characters, and assigns the sequence of "a" characters to the first capturing group, However, if the final character of the input string is also an "a", it is matched by the `\w` language element and is not included in the captured group.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "aaaaa", "aaaaab" };
      string backtrackingPattern = @"(a+)\w";
      Match match;

      foreach (string input in inputs) {
         Console.WriteLine("Input: {0}", input);
         match = Regex.Match(input, backtrackingPattern);
         Console.WriteLine("   Pattern: {0}", backtrackingPattern);
         if (match.Success) { 
            Console.WriteLine("      Match: {0}", match.Value);
            Console.WriteLine("      Group 1: {0}", match.Groups[1].Value);
         }
         else {
            Console.WriteLine("      Match failed.");
         }   
      }
      Console.WriteLine();            
   }
}
// The example displays the following output:
//       Input: aaaaa
//          Pattern: (a+)\w
//             Match: aaaaa
//             Group 1: aaaa
//       Input: aaaaab
//          Pattern: (a+)\w
//             Match: aaaaab
//             Group 1: aaaaa
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "aaaaa", "aaaaab" }
      Dim backtrackingPattern As String = "(a+)\w"
      Dim match As Match

      For Each input As String In inputs
         Console.WriteLine("Input: {0}", input)
         match = Regex.Match(input, backtrackingPattern)
         Console.WriteLine("   Pattern: {0}", backtrackingPattern)
         If match.Success Then 
            Console.WriteLine("      Match: {0}", match.Value)
            Console.WriteLine("      Group 1: {0}", match.Groups(1).Value)
         Else 
            Console.WriteLine("      Match failed.")
         End If   
      Next
      Console.WriteLine()            
   End Sub
End Module
' The example displays the following output:
'       Input: aaaaa
'          Pattern: (a+)\w
'             Match: aaaaa
'             Group 1: aaaa
'       Input: aaaaab
'          Pattern: (a+)\w
'             Match: aaaaab
'             Group 1: aaaaa
```

The regular expression `((?>a+))\w` prevents this behavior. Because all consecutive "a" characters are matched without backtracking, the first capturing group includes all consecutive "a" characters. If the "a" characters are not followed by at least one more character other than "a", the match fails.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "aaaaa", "aaaaab" };
      string nonbacktrackingPattern = @"((?>a+))\w";
      Match match;

      foreach (string input in inputs) {
         Console.WriteLine("Input: {0}", input);
         match = Regex.Match(input, nonbacktrackingPattern);
         Console.WriteLine("   Pattern: {0}", nonbacktrackingPattern);
         if (match.Success) { 
            Console.WriteLine("      Match: {0}", match.Value);
            Console.WriteLine("      Group 1: {0}", match.Groups[1].Value);
         }
         else {
            Console.WriteLine("      Match failed.");
         }   
      }
      Console.WriteLine();            
   }
}
// The example displays the following output:
//       Input: aaaaa
//          Pattern: ((?>a+))\w
//             Match failed.
//       Input: aaaaab
//          Pattern: ((?>a+))\w
//             Match: aaaaab
//             Group 1: aaaaa
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "aaaaa", "aaaaab" }
      Dim nonbacktrackingPattern As String = "((?>a+))\w"
      Dim match As Match

      For Each input As String In inputs
         Console.WriteLine("Input: {0}", input)
         match = Regex.Match(input, nonbacktrackingPattern)
         Console.WriteLine("   Pattern: {0}", nonbacktrackingPattern)
         If match.Success Then 
            Console.WriteLine("      Match: {0}", match.Value)
            Console.WriteLine("      Group 1: {0}", match.Groups(1).Value)
         Else 
            Console.WriteLine("      Match failed.")
         End If   
      Next
      Console.WriteLine()            
   End Sub
End Module
' The example displays the following output:
'       Input: aaaaa
'          Pattern: ((?>a+))\w
'             Match failed.
'       Input: aaaaab
'          Pattern: ((?>a+))\w
'             Match: aaaaab
'             Group 1: aaaaa
```

For more information about nonbacktracking subexpressions, see [Grouping constructs in regular expressions](grouping.md).

### Right-to-left matching

Right-to-left matching, which is specified by supplying the [RegexOptions.RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft) option to a [Regex](xref:System.Text.RegularExpressions.Regex) class constructor or static instance matching method. This feature is useful when searching from right to left instead of from left to right, or in cases where it is more efficient to begin a match at the right part of the pattern instead of the left. As the following example illustrates, using right-to-left matching can change the behavior of greedy quantifiers. The example conducts two searches for a sentence that ends in a number. The left-to-right search that uses the greedy quantifier `+` matches one of the six digits in the sentence, whereas the right-to-left search matches all six digits. For an description of the regular expression pattern, see the example that illustrates lazy quantifiers earlier in this section.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string greedyPattern = @".+(\d+)\.";
      string input = "This sentence ends with the number 107325.";
      Match match;

      // Match from left-to-right using lazy quantifier .+?.
      match = Regex.Match(input, greedyPattern);
      if (match.Success)
         Console.WriteLine("Number at end of sentence (left-to-right): {0}", 
                           match.Groups[1].Value);
      else
         Console.WriteLine("{0} finds no match.", greedyPattern);

      // Match from right-to-left using greedy quantifier .+.
      match = Regex.Match(input, greedyPattern, RegexOptions.RightToLeft);
      if (match.Success)
         Console.WriteLine("Number at end of sentence (right-to-left): {0}", 
                           match.Groups[1].Value);
      else
         Console.WriteLine("{0} finds no match.", greedyPattern);
   }
}
// The example displays the following output:
//       Number at end of sentence (left-to-right): 5
//       Number at end of sentence (right-to-left): 107325
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim greedyPattern As String = ".+(\d+)\."
      Dim input As String = "This sentence ends with the number 107325."
      Dim match As Match

      ' Match from left-to-right using lazy quantifier .+?.
      match = Regex.Match(input, greedyPattern)
      If match.Success Then
         Console.WriteLine("Number at end of sentence (left-to-right): {0}", 
                           match.Groups(1).Value)
      Else
         Console.WriteLine("{0} finds no match.", greedyPattern)
      End If

      ' Match from right-to-left using greedy quantifier .+.
      match = Regex.Match(input, greedyPattern, RegexOptions.RightToLeft)
      If match.Success Then
         Console.WriteLine("Number at end of sentence (right-to-left): {0}", 
                           match.Groups(1).Value)
      Else
         Console.WriteLine("{0} finds no match.", greedyPattern)
      End If
   End Sub
End Module
' The example displays the following output:
'       Number at end of sentence (left-to-right): 5
'       Number at end of sentence (right-to-left): 107325
```

For more information about right-to-left matching, see [Regular expression options](options.md).

### Positive and negative lookbehind

Positive and negative lookbehind: **(?<**=_subexpression_**)** for positive lookbehind, and **(?<!**_subexpression_**)** for negative lookbehind. This feature is similar to lookahead, which is discussed earlier in this topic. Because the regular expression engine allows complete right-to-left matching, regular expressions allow unrestricted lookbehinds. Positive and negative lookbehind can also be used to avoid nesting quantifiers when the nested subexpression is a superset of an outer expression. Regular expressions with such nested quantifiers often offer poor performance. For example, the following example verifies that a string begins and ends with an alphanumeric character, and that any other character in the string is one of a larger subset. It forms a portion of the regular expression used to validate e-mail addresses; for more information, see [How to: Verify that Strings Are in Valid Email Format](verify-format.md).

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "jack.sprat", "dog#", "dog#1", "me.myself", 
                          "me.myself!" };
      string pattern = @"^[A-Z0-9]([-!#$%&'.*+/=?^`{}|~\w])*(?<=[A-Z0-9])$";
      foreach (string input in inputs) {
         if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            Console.WriteLine("{0}: Valid", input);
         else
            Console.WriteLine("{0}: Invalid", input);
      }
   }
}
// The example displays the following output:
//       jack.sprat: Valid
//       dog#: Invalid
//       dog#1: Valid
//       me.myself: Valid
//       me.myself!: Invalid
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "jack.sprat", "dog#", "dog#1", "me.myself", 
                                 "me.myself!" }
      Dim pattern As String = "^[A-Z0-9]([-!#$%&'.*+/=?^`{}|~\w])*(?<=[A-Z0-9])$"
      For Each input As String In inputs
         If Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase) Then
            Console.WriteLine("{0}: Valid", input)
         Else
            Console.WriteLine("{0}: Invalid", input)
         End If   
      Next
   End Sub
End Module
' The example displays the following output:
'       jack.sprat: Valid
'       dog#: Invalid
'       dog#1: Valid
'       me.myself: Valid
'       me.myself!: Invalid
```

The regular expression `^[A-Z0-9]([-!#$%&'.*+/=?^`{}|~\w])*(?<=[A-Z0-9])$` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`^` | Begin the match at the beginning of the string.
`[A-Z0-9]` | Match any numeric or alphanumeric character. (The comparison is case-insensitive.)
`([-!#$%&'.*+/=?^`{}&#124;~\w])*` | Match zero or more occurrences of any word character, or any of the following characters: -, !, #, $, %, &, ', ., *, +, /, =, ?, ^, `, {, }, &#124;, or ~.
`(?<=[A-Z0-9])` | Look behind to the previous character, which must be numeric or alphanumeric. (The comparison is case-insensitive.)
`$` | End the match at the end of the string.
 
For more information about positive and negative lookbehind, see [Grouping constructs in regular expressions](grouping.md).


## Related Topics

Title | Description
----- | ----------- 
[Backtracking](backtracking.md) | Provides information about how regular expression backtracking branches to find alternative matches.
[Compilation and reuse](compilation.md) | Provides information about compiling and reusing regular expressions to increase performance.
[Thread safety](thread-safety.md) | Provides information about regular expression thread safety and explains when you should synchronize access to regular expression objects.
[.NET regular expressions](regular-expressions.md) | Provides an overview of the programming language aspect of regular expressions.
[The regular expression Object Model](object-model.md) | Provides information and code examples illustrating how to use the regular expression classes.
[Regular expression examples](regex-examples.md) | Contains code examples that illustrate the use of regular expressions in common applications.
[Regular expression language - quick reference](quick-ref.md) | Provides information about the set of characters, operators, and constructs that you can use to define regular expressions.
 
## Reference

[System.Text.RegularExpressions](xref:System.Text.RegularExpressions)

