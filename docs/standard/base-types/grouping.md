---
title: Grouping constructs in regular expressions
description: Grouping constructs in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: e0bf3718-e64b-460b-b73d-66678cec6093
---

# Grouping constructs in regular expressions

Grouping constructs delineate the subexpressions of a regular expression and capture the substrings of an input string. You can use grouping constructs to do the following:

* Match a subexpression that is repeated in the input string.

* Apply a quantifier to a subexpression that has multiple regular expression language elements. For more information about quantifiers, see [Quantifiers in regular expressions](quantifiers.md).

* Include a subexpression in the string that is returned by the [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) and [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) methods.

* Retrieve individual subexpressions from the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property and process them separately from the matched text as a whole.

The following table lists the grouping constructs supported by .NET regular expression engine and indicates whether they are capturing or non-capturing. 

Grouping construct | Capturing or noncapturing
------------------ | -------------------------
[Matched subexpressions](#matched-subexpressions) | Capturing
[Named matched subexpressions](#named-matched-subexpressions) | Capturing
[Balancing group definitions](#balancing-group-definitions) | Capturing
[Noncapturing groups](#noncapturing-groups) | Noncapturing
[Group options](#group-options) | Noncapturing
[Zero-width positive lookahead assertions](#zero-width-positive-lookahead-assertions) | Noncapturing
[Zero-width negative lookahead assertions](#zero-width-negative-lookahead-assertions) | Noncapturing
[Zero-width positive lookbehind assertions](#zero-width-positive-lookbehind-assertions) | Noncapturing
[Zero-width negative lookbehind assertions](#zero-width-negative-lookbehind-assertions) | Noncapturing
[Nonbacktracking subexpressions](#nonbacktracking-subexpressions) | Noncapturing

For information on groups and the regular expression object model, see [Grouping Constructs and Regular Expression Objects](#grouping-constructs-and-regular-expression-objects). 

## Matched subexpressions

The following grouping construct captures a matched subexpression: 

**(**_subexpression_**)**

where *subexpression* is any valid regular expression pattern. Captures that use parentheses are numbered automatically from left to right based on the order of the opening parentheses in the regular expression, starting from one. The capture that is numbered zero is the text matched by the entire regular expression pattern.

> [!NOTE]
> By default, the (subexpression) language element captures the matched subexpression. But if the RegexOptions parameter of a regular expression pattern matching method includes the RegexOptions.ExplicitCapture flag, or if the n option is applied to this subexpression (see Group options later in this topic), the matched subexpression is not captured.
 
You can access captured groups in four ways:

* By using the backreference construct within the regular expression. The matched subexpression is referenced in the same regular expression by using the syntax **\**_number_, where *number* is the ordinal number of the captured subexpression.

* By using the named backreference construct within the regular expression. The matched subexpression is referenced in the same regular expression by using the syntax **\k<**_name_**>**, where *name* is the name of a capturing group, or **\k**_<number_**>**, where *number* is the ordinal number of a capturing group. A capturing group has a default name that is identical to its ordinal number. For more information, see Grouping constructs and regular expression objects later in this topic.

* By using the **$**_number_ replacement sequence in a [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) or [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method call, where *number* is the ordinal number of the captured subexpression.

* Programmatically, by using the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object returned by the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property. The member at position zero in the collection represents the entire regular expression match. Each subsequent member represents a matched subexpression. For more information, see the [Grouping Constructs and Regular Expression Objects](#grouping-constructs-and-regular-expression-objects) section.

The following example illustrates a regular expression that identifies duplicated words in text. The regular expression pattern's two capturing groups represent the two instances of the duplicated word. The second instance is captured to report its starting position in the input string.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\w+)\s(\1)";
      string input = "He said that that was the the correct answer.";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine("Duplicate '{0}' found at positions {1} and {2}.", 
                           match.Groups[1].Value, match.Groups[1].Index, match.Groups[2].Index);
   }
}
// The example displays the following output:
//       Duplicate 'that' found at positions 8 and 13.
//       Duplicate 'the' found at positions 22 and 26.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\w+)\s(\1)\W"
      Dim input As String = "He said that that was the the correct answer."
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine("Duplicate '{0}' found at positions {1} and {2}.", _
                           match.Groups(1).Value, match.Groups(1).Index, match.Groups(2).Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Duplicate 'that' found at positions 8 and 13.
'       Duplicate 'the' found at positions 22 and 26.
```

The regular expression pattern is the following:

```
(\w+)\s(\1)\W
```

The following table shows how the regular expression pattern is interpreted. 

Pattern | Description
------- | ----------- 
`(\w+)` | Match one or more word characters. This is the first capturing group.
`\s` | Match a white-space character.
`(\1)` | Match the string in the first captured group. This is the second capturing group. The example assigns it to a captured group so that the starting position of the duplicate word can be retrieved from the `Match.Index` property.
`\W` | Match a non-word character, including white space and punctuation. This prevents the regular expression pattern from matching a word that starts with the word from the first captured group.
 
## Named matched subexpressions

The following grouping construct captures a matched subexpression and lets you access it by name or by number: 

```
(?<name>subexpression)
```

or:

```
(?'name'subexpression)
```

where *name* is a valid group name, and *subexpression* is any valid regular expression pattern. *name* must not contain any punctuation characters and cannot begin with a number.

> [!NOTE]
> If the [RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) parameter of a regular expression pattern matching method includes the [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture) flag, or if the **n** option is applied to this subexpression (see [Group options](#group-options) later in this topic), the only way to capture a subexpression is to explicitly name capturing groups.
 
You can access named captured groups in the following ways:

* By using the named backreference construct within the regular expression. The matched subexpression is referenced in the same regular expression by using the syntax **\k<**_name_**>**, where *name* is the name of the captured subexpression. 

* By using the backreference construct within the regular expression. The matched subexpression is referenced in the same regular expression by using the syntax **\**_number_, where *number* is the ordinal number of the captured subexpression. Named matched subexpressions are numbered consecutively from left to right after matched subexpressions.

* By using the **${**_name_**}** replacement sequence in a [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) or [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method call, where *name* is the name of the captured subexpression.

* By using the **$**_number_ replacement sequence in a [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) or [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method call, where *number* is the ordinal number of the captured subexpression.

* Programmatically, by using the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object returned by the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property. The member at position zero in the collection represents the entire regular expression match. Each subsequent member represents a matched subexpression. Named captured groups are stored in the collection after numbered captured groups.

* Programmatically, by providing the subexpression name to the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object's indexer  (in C#) or to its Item property (in Visual Basic).

A simple regular expression pattern illustrates how numbered (unnamed) and named groups can be referenced either programmatically or by using regular expression language syntax. The regular expression `((?<One>abc)\d+)?(?<Two>xyz)(.*)` produces the following capturing groups by number and by name. The first capturing group (number 0) always refers to the entire pattern.

Number | Name | Pattern
------ | ---- | ------- 
0 | 0 (default name) | `((?<One>abc)\d+)?(?<Two>xyz)(.*)`
1 | 1 (default name) | `((?<One>abc)\d+)`
2 | 2 (default name) | `(.*)`
3 | One | `(?<One>abc)`
4 | Two | `(?<Two>xyz)`
 
The following example illustrates a regular expression that identifies duplicated words and the word that immediately follows each duplicated word. The regular expression pattern defines two named subexpressions: `duplicateWord`, which represents the duplicated word; and `nextWord`, which represents the word that follows the duplicated word. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<duplicateWord>\w+)\s\k<duplicateWord>\W(?<nextWord>\w+)";
      string input = "He said that that was the the correct answer.";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine("A duplicate '{0}' at position {1} is followed by '{2}'.", 
                           match.Groups["duplicateWord"].Value, match.Groups["duplicateWord"].Index, 
                           match.Groups["nextWord"].Value);

   }
}
// The example displays the following output:
//       A duplicate 'that' at position 8 is followed by 'was'.
//       A duplicate 'the' at position 22 is followed by 'correct'.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<duplicateWord>\w+)\s\k<duplicateWord>\W(?<nextWord>\w+)"
      Dim input As String = "He said that that was the the correct answer."
      Console.WriteLine(Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count)
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine("A duplicate '{0}' at position {1} is followed by '{2}'.", _
                           match.Groups("duplicateWord").Value, match.Groups("duplicateWord").Index, _
                           match.Groups("nextWord").Value)
      Next
   End Sub
End Module
' The example displays the following output:
'    A duplicate 'that' at position 8 is followed by 'was'.
'    A duplicate 'the' at position 22 is followed by 'correct'.
```

The regular expression pattern is as follows:

```
(?<duplicateWord>\w+)\s\k<duplicateWord>\W(?<nextWord>\w+)
```

The following table shows how the regular expression is interpreted.

Pattern | Description
------- | -----------
`(?<duplicateWord>\w+)` | Match one or more word characters. Name this capturing group `duplicateWord`.
`\s` | Match a white-space character.
`\k<duplicateWord>` | Match the string from the captured group that is named `duplicateWord`. 
`\W` | Match a non-word character, including white space and punctuation. This prevents the regular expression pattern from matching a word that starts with the word from the first captured group.
`(?<nextWord>\w+)` | Match one or more word characters. Name this capturing group `nextWord`.
 
Note that a group name can be repeated in a regular expression. For example, it is possible for more than one group to be named `digit`, as the following example illustrates. In the case of duplicate names, the value of the [Group](xref:System.Text.RegularExpressions.Group) object is determined by the last successful capture in the input string. In addition, the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) is populated with information about each capture just as it would be if the group name was not duplicated. 

In the following example, the regular expression `\D+(?<digit>\d+)\D+(?<digit>\d+)?` includes two occurrences of a group named `digit`. The first `digit` named group captures one or more digit characters. The second `digit` named group captures either zero or one occurrence of one or more digit characters. As the output from the example shows, if the second capturing group successfully matches text, the value of that text defines the value of the [Group](xref:System.Text.RegularExpressions.Group) object. If the second capturing group cannot does not match the input string, the value of the last successful match defines the value of the [Group](xref:System.Text.RegularExpressions.Group) object. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      String pattern = @"\D+(?<digit>\d+)\D+(?<digit>\d+)?";
      String[] inputs = { "abc123def456", "abc123def" };
      foreach (var input in inputs) {
         Match m = Regex.Match(input, pattern);
         if (m.Success) {
            Console.WriteLine("Match: {0}", m.Value);
            for (int grpCtr = 1; grpCtr < m.Groups.Count; grpCtr++) {
               Group grp = m.Groups[grpCtr];
               Console.WriteLine("Group {0}: {1}", grpCtr, grp.Value);
               for (int capCtr = 0; capCtr < grp.Captures.Count; capCtr++)
                  Console.WriteLine("   Capture {0}: {1}", capCtr,
                                    grp.Captures[capCtr].Value);
            }
         }
         else {
            Console.WriteLine("The match failed.");
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Match: abc123def456
//       Group 1: 456
//          Capture 0: 123
//          Capture 1: 456
//
//       Match: abc123def
//       Group 1: 123
//          Capture 0: 123
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\D+(?<digit>\d+)\D+(?<digit>\d+)?"
      Dim inputs() As String = { "abc123def456", "abc123def" }
      For Each input As String In inputs
         Dim m As Match = Regex.Match(input, pattern)
         If m.Success Then
            Console.WriteLine("Match: {0}", m.Value)
            For grpCtr As Integer = 1 to m.Groups.Count - 1
               Dim grp As Group = m.Groups(grpCtr)
               Console.WriteLine("Group {0}: {1}", grpCtr, grp.Value)
               For capCtr As Integer = 0 To grp.Captures.Count - 1
                  Console.WriteLine("   Capture {0}: {1}", capCtr,
                                    grp.Captures(capCtr).Value)
               Next
            Next
         Else
            Console.WriteLine("The match failed.")
         End If
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       Match: abc123def456
'       Group 1: 456
'          Capture 0: 123
'          Capture 1: 456
'
'       Match: abc123def
'       Group 1: 123
'          Capture 0: 123
```

The following table shows how the regular expression is interpreted.

Pattern | Description
------- | -----------
`\D+` | Match one or more non-decimal digit characters. 
`(?<digit>\d+)` | Match one or more decimal digit characters. Assign the match to the `digit` named group. 
`\D+` | Match one or more non-decimal digit characters. 
`(?<digit>\d+)?` | Match zero or one occurrence of one or more decimal digit characters. Assign the match to the `digit` named group.
 
## Balancing group definitions

A balancing group definition deletes the definition of a previously defined group and stores, in the current group, the interval between the previously defined group and the current group. This grouping construct has the following format: 

```
(?<name1-name2>subexpression)
```

or:

```
(?'name1-name2' subexpression)
```

where *name1* is the current group (optional), *name2* is a previously defined group, and *subexpression* is any valid regular expression pattern. The balancing group definition deletes the definition of *name2* and stores the interval between *name2* and *name1* in *name1*. If no *name2* group is defined, the match backtracks. Because deleting the last definition of *name2* reveals the previous definition of *name2*, this construct lets you use the stack of captures for group *name2* as a counter for keeping track of nested constructs such as parentheses or opening and closing brackets. 

The balancing group definition uses *name2*as a stack. The beginning character of each nested construct is placed in the group and in its [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) collection. When the closing character is matched, its corresponding opening character is removed from the group, and the [Captures](xref:System.Text.RegularExpressions.Group.Captures) collection is decreased by one. After the opening and closing characters of all nested constructs have been matched, *name1* is empty.

> [!NOTE]
> After you modify the regular expression in the following example to use the appropriate opening and closing character of a nested construct, you can use it to handle most nested constructs, such as mathematical expressions or lines of program code that include multiple nested method calls. 
 
The following example uses a balancing group definition to match left and right angle brackets (<>) in an input string. The example defines two named groups, `Open` and `Close`, that are used like a stack to track matching pairs of angle brackets. Each captured left angle bracket is pushed into the capture collection of the `Open` group, and each captured right angle bracket is pushed into the capture collection of the `Close` group. The balancing group definition ensures that there is a matching right angle bracket for each left angle bracket. If there is not, the final subpattern, `(?(Open)(?!))`, is evaluated only if the `Open` group is not empty (and, therefore, if all nested constructs have not been closed). If the final subpattern is evaluated, the match fails, because the `(?!)` subpattern is a zero-width negative lookahead assertion that always fails. 

```csharp
using System;
using System.Text.RegularExpressions;

class Example
{
   public static void Main() 
   {
      string pattern = "^[^<>]*" +
                       "(" + 
                       "((?'Open'<)[^<>]*)+" +
                       "((?'Close-Open'>)[^<>]*)+" +
                       ")*" +
                       "(?(Open)(?!))$";
      string input = "<abc><mno<xyz>>";

      Match m = Regex.Match(input, pattern);
      if (m.Success == true)
      {
         Console.WriteLine("Input: \"{0}\" \nMatch: \"{1}\"", input, m);
         int grpCtr = 0;
         foreach (Group grp in m.Groups)
         {
            Console.WriteLine("   Group {0}: {1}", grpCtr, grp.Value);
            grpCtr++;
            int capCtr = 0;
            foreach (Capture cap in grp.Captures)
            {            
                Console.WriteLine("      Capture {0}: {1}", capCtr, cap.Value);
                capCtr++;
            }
          }
      }
      else
      {
         Console.WriteLine("Match failed.");
      }   
    }
}
// The example displays the following output:
//    Input: "<abc><mno<xyz>>"
//    Match: "<abc><mno<xyz>>"
//       Group 0: <abc><mno<xyz>>
//          Capture 0: <abc><mno<xyz>>
//       Group 1: <mno<xyz>>
//          Capture 0: <abc>
//          Capture 1: <mno<xyz>>
//       Group 2: <xyz
//          Capture 0: <abc
//          Capture 1: <mno
//          Capture 2: <xyz
//       Group 3: >
//          Capture 0: >
//          Capture 1: >
//          Capture 2: >
//       Group 4:
//       Group 5: mno<xyz>
//          Capture 0: abc
//          Capture 1: xyz
//          Capture 2: mno<xyz>
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main() 
        Dim pattern As String = "^[^<>]*" & _
                                "(" + "((?'Open'<)[^<>]*)+" & _
                                "((?'Close-Open'>)[^<>]*)+" + ")*" & _
                                "(?(Open)(?!))$"
        Dim input As String = "<abc><mno<xyz>>"
        Dim rgx AS New Regex(pattern)'
        Dim m As Match = Regex.Match(input, pattern)
        If m.Success Then
            Console.WriteLine("Input: ""{0}"" " & vbCrLf & "Match: ""{1}""", _
                               input, m)
            Dim grpCtr As Integer = 0
            For Each grp As Group In m.Groups
               Console.WriteLine("   Group {0}: {1}", grpCtr, grp.Value)
               grpCtr += 1
               Dim capCtr As Integer = 0
               For Each cap As Capture In grp.Captures            
                  Console.WriteLine("      Capture {0}: {1}", capCtr, cap.Value)
                  capCtr += 1
               Next
            Next
        Else
            Console.WriteLine("Match failed.")
        End If
    End Sub
End Module  
' The example displays the following output:
'       Input: "<abc><mno<xyz>>"
'       Match: "<abc><mno<xyz>>"
'          Group 0: <abc><mno<xyz>>
'             Capture 0: <abc><mno<xyz>>
'          Group 1: <mno<xyz>>
'             Capture 0: <abc>
'             Capture 1: <mno<xyz>>
'          Group 2: <xyz
'             Capture 0: <abc
'             Capture 1: <mno
'             Capture 2: <xyz
'          Group 3: >
'             Capture 0: >
'             Capture 1: >
'             Capture 2: >
'          Group 4:
'          Group 5: mno<xyz>
'             Capture 0: abc
'             Capture 1: xyz
'             Capture 2: mno<xyz>
```

The regular expression pattern is:

```
^[^<>]*(((?'Open'<)[^<>]*)+((?'Close-Open'>)[^<>]*)+)*(?(Open)(?!))$
```

The regular expression is interpreted as follows:

Pattern | Description
------- | -----------
`^` | Begin at the start of the string.
`[^<>]*` | Match zero or more characters that are not left or right angle brackets.
`(?'Open'<)` | Match a left angle bracket and assign it to a group named `Open`.
`[^<>]*` | Match zero or more characters that are not left or right angle brackets.
`((?'Open'<)[^<>]*) +` | Match one or more occurrences of a left angle bracket followed by zero or more characters that are not left or right angle brackets. This is the second capturing group.
`(?'Close-Open'>)` | Match a right angle bracket, assign the substring between the `Open` group and the current group to the `Close` group, and delete the definition of the `Open` group.
`[^<>]*` | Match zero or more occurrences of any character that is neither a left nor a right angle bracket. 
`((?'Close-Open'>)[^<>]*)+` | Match one or more occurrences of a right angle bracket, followed by zero or more occurrences of any character that is neither a left nor a right angle bracket. When matching the right angle bracket, assign the substring between the `Open` group and the current group to the `Close` group, and delete the definition of the`Open` group. This is the third capturing group.
`(((?'Open'<)[^<>]*)+((?'Close-Open'>)[^<>]*)+)*` | Match zero or more occurrences of the following pattern: one or more occurrences of a left angle bracket, followed by zero or more non-angle bracket characters, followed by one or more occurrences of a right angle bracket, followed by zero or more occurrences of non-angle brackets. When matching the right angle bracket, delete the definition of the `Open` group, and assign the substring between the `Open` group and the current group to the `Close` group. This is the first capturing group.
`(?(Open)(?!))` | If the `Open` group exists, abandon the match if an empty string can be matched, but do not advance the position of the regular expression engine in the string. This is a zero-width negative lookahead assertion. Because an empty string is always implicitly present in an input string, this match always fails. Failure of this match indicates that the angle brackets are not balanced. 
`$` | Match the end of the input string.
 
The final subexpression, `(?(Open)(?!))`, indicates whether the nesting constructs in the input string are properly balanced (for example, whether each left angle bracket is matched by a right angle bracket). It uses conditional matching based on a valid captured group; for more information, see [Alternation constructs in regular expressions](alternation.md). If the `Open` group is defined, the regular expression engine attempts to match the subexpression `(?!)` in the input string. The `Open` group should be defined only if nesting constructs are unbalanced. Therefore, the pattern to be matched in the input string should be one that always causes the match to fail. In this case, `(?!)` is a zero-width negative lookahead assertion that always fails, because an empty string is always implicitly present at the next position in the input string.

In the example, the regular expression engine evaluates the input string "<abc><mno<xyz>>" as shown in the following table.

Step | Pattern | Result
---- | ------- | ------ 
1 | `^` | Starts the match at the beginning of the input string
2 | `[^<>]*` | Looks for non-angle bracket characters before the left angle bracket;finds no matches. 
3 | `(((?'Open'<)` | Matches the left angle bracket in "<abc>" and assigns it to the `Open` group.
4 | `[^<>]*` | Matches "abc".
5 | `)+` | "<abc" is the value of the second captured group. The next character in the input string is not a left angle bracket, so the regular expression engine does not loop back to the `(?'Open'<)[^<>]*)` subpattern.
6 | `((?'Close-Open'>)` | Matches the right angle bracket in "<abc>", assigns "abc", which is the substring between the `Open` group and the right angle bracket, to the `Close` group, and deletes the current value ("<") of the `Open` group, leaving it empty.
7 | `[^<>]*` | Looks for non-angle bracket characters after the right angle bracket; finds no matches.
8 | `)+` | The value of the third captured group is ">". The next character in the input string is not a right angle bracket, so the regular expression engine does not loop back to the `((?'Close-Open'>)[^<>]*)` subpattern.
9 | `)*` | The value of the first captured group is "<abc>". The next character in the input string is a left angle bracket, so the regular expression engine loops back to the `(((?'Open'<)` subpattern.
10 | `(((?'Open'<)` | Matches the left angle bracket in "<mno>" and assigns it to the `Open` group. Its `Group.Captures` collection now has a single value, "<".
11 | `[^<>]*` | Matches "mno".
12 | `)+` | "<mno" is the value of the second captured group. The next character in the input string is an left angle bracket, so the regular expression engine loops back to the `(?'Open'<)[^<>]*)` subpattern.
13 | `(((?'Open'<)` | Matches the left angle bracket in "<xyz>" and assigns it to the `Open` group. The `Group.Captures` collection of the `Open` group now includes two captures: the left angle bracket from "<mno>", and the left angle bracket from "<xyz>".
14 | `[^<>]*` | Matches "xyz".
15 | `)+` | "<xyz" is the value of the second captured group. The next character in the input string is not a left angle bracket, so the regular expression engine does not loop back to the `(?'Open'<)[^<>]*)` subpattern.
16 | `((?'Close-Open'>)` | Matches the right angle bracket in "<xyz>". "xyz", assigns the substring between the `Open` group and the right angle bracket to the `Close` group, and deletes the current value of the `Open` group. The value of the previous capture (the left angle bracket in "<mno>") becomes the current value of the `Open` group. The `Captures` collection of the `Open` group now includes a single capture, the left angle bracket from "<xyz>".
17 | `[^<>]*` | Looks for non-angle bracket characters; finds no matches.
18 | `)+` | The value of the third captured group is ">". The next character in the input string is a right angle bracket, so the regular expression engine loops back to the `((?'Close-Open'>)[^<>]*)` subpattern.
19 | `((?'Close-Open'>)` | Matches the final right angle bracket in "xyz>>", assigns "mno<xyz>" (the substring between the `Open` group and the right angle bracket) to the `Close` group, and deletes the current value of the `Open` group. The `Open` group is now empty.
20 | `[^<>]*` | Looks for non-angle bracket characters; finds no matches.
21 | `)+` | The value of the third captured group is ">". The next character in the input string is not a right angle bracket, so the regular expression engine does not loop back to the `((?'Close-Open'>)[^<>]*)` subpattern.
22 | `)*` | The value of the first captured group is "<mno<xyz>>". The next character in the input string is not a left angle bracket, so the regular expression engine does not loop back to the `(((?'Open'<)` subpattern.
23 | `(?(Open)(?!))` | The `Open` group is not defined, so no match is attempted.
24 | `$` | Matches the end of the input string.

## Noncapturing groups

The following grouping construct does not capture the substring that is matched by a subexpression:

```
**(?**:_subexpression_**)**
```

where *subexpression* is any valid regular expression pattern. The noncapturing group construct is typically used when a quantifier is applied to a group, but the substrings captured by the group are of no interest.

>[!NOTE]
> If a regular expression includes nested grouping constructs, an outer noncapturing group construct does not apply to the inner nested group constructs. 
 
The following example illustrates a regular expression that includes noncapturing groups. Note that the output does not include any captured groups.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?:\b(?:\w+)\W*)+\.";
      string input = "This is a short sentence.";
      Match match = Regex.Match(input, pattern);
      Console.WriteLine("Match: {0}", match.Value);
      for (int ctr = 1; ctr < match.Groups.Count; ctr++)
         Console.WriteLine("   Group {0}: {1}", ctr, match.Groups[ctr].Value);
   }
}
// The example displays the following output:
//       Match: This is a short sentence.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?:\b(?:\w+)\W*)+\."
      Dim input As String = "This is a short sentence."
      Dim match As Match = Regex.Match(input, pattern)
      Console.WriteLine("Match: {0}", match.Value)
      For ctr As Integer = 1 To match.Groups.Count - 1
         Console.WriteLine("   Group {0}: {1}", ctr, match.Groups(ctr).Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       Match: This is a short sentence.
```

The regular expression `(?:\b(?:\w+)\W*)+\.` matches a sentence that is terminated by a period. Because the regular expression focuses on sentences and not on individual words, grouping constructs are used exclusively as quantifiers. The regular expression pattern is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`(?:\w+)` | Match one or more word characters. Do not assign the matched text to a captured group.
`\W*` | Match zero or more non-word characters.
`(?:\b(?:\w+)\W*)+` | Match the pattern of one or more word characters starting at a word boundary, followed by zero or more non-word characters, one or more times. Do not assign the matched text to a captured group.
`\.` | Match a period.
 
## Group options

The following grouping construct applies or disables the specified options within a subexpression:

**(?imnsx-imnsx:**_subexpression_**)**

where *subexpression* is any valid regular expression pattern. For example, `(?i-s:)` turns on case insensitivity and disables single-line mode. For more information about the inline options you can specify, see [Regular expression options](options.md).

> [!NOTE]
> You can specify options that apply to an entire regular expression rather than a subexpression by using a [System.Text.RegularExpressions.Regex](xref:System.Text.RegularExpressions.Regex) class constructor or a static method. You can also specify inline options that apply after a specific point in a regular expression by using the `(?imnsx-imnsx)` language construct.
 
The group options construct is not a capturing group. That is, although any portion of a string that is captured by *subexpression* is included in the match, it is not included in a captured group nor used to populate the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object.

For example, the regular expression `\b(?ix: d \w+)\s `in the following example uses inline options in a grouping construct to enable case-insensitive matching and ignore pattern whitespace in identifying all words that begin with the letter "d". The regular expression is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
 `(?ix: d \w+)` | Using case-insensitive matching and ignoring white space in this pattern, match a "d" followed by one or more word characters. 
`\s` | Match a white-space character.
 
```csharp
string pattern = @"\b(?ix: d \w+)\s";
string input = "Dogs are decidedly good pets.";

foreach (Match match in Regex.Matches(input, pattern))
   Console.WriteLine("'{0}// found at index {1}.", match.Value, match.Index);
// The example displays the following output:
//    'Dogs // found at index 0.
//    'decidedly // found at index 9.      
```

```vb
Dim pattern As String = "\b(?ix: d \w+)\s"
Dim input As String = "Dogs are decidedly good pets."

For Each match As Match In Regex.Matches(input, pattern)
   Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
Next
' The example displays the following output:
'    'Dogs ' found at index 0.
'    'decidedly ' found at index 9. 
```

## Zero-width positive lookahead assertions

The following grouping construct defines a zero-width positive lookahead assertion:

**(?**=*subexpression*__)__

where *subexpression* is any regular expression pattern. For a match to be successful, the input string must match the regular expression pattern in *subexpression*, although the matched substring is not included in the match result. A zero-width positive lookahead assertion does not backtrack.

Typically, a zero-width positive lookahead assertion is found at the end of a regular expression pattern. It defines a substring that must be found at the end of a string for a match to occur but that should not be included in the match. It is also useful for preventing excessive backtracking. You can use a zero-width positive lookahead assertion to ensure that a particular captured group begins with text that matches a subset of the pattern defined for that captured group. For example, if a capturing group matches consecutive word characters, you can use a zero-width positive lookahead assertion to require that the first character be an alphabetical uppercase character.

The following example uses a zero-width positive lookahead assertion to match the word that precedes the verb "is" in the input string. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+(?=\sis\b)";
      string[] inputs = { "The dog is a Malamute.", 
                          "The island has beautiful birds.", 
                          "The pitch missed home plate.", 
                          "Sunday is a weekend day." };

      foreach (string input in inputs)
      {
         Match match = Regex.Match(input, pattern);
         if (match.Success)
            Console.WriteLine("'{0}' precedes 'is'.", match.Value);
         else
            Console.WriteLine("'{0}' does not match the pattern.", input); 
      }
   }
}
// The example displays the following output:
//    'dog' precedes 'is'.
//    'The island has beautiful birds.' does not match the pattern.
//    'The pitch missed home plate.' does not match the pattern.
//    'Sunday' precedes 'is'.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+(?=\sis\b)"
      Dim inputs() As String = { "The dog is a Malamute.", _
                                 "The island has beautiful birds.", _
                                 "The pitch missed home plate.", _
                                 "Sunday is a weekend day." }

      For Each input As String In inputs
         Dim match As Match = Regex.Match(input, pattern)
         If match.Success Then
            Console.WriteLine("'{0}' precedes 'is'.", match.Value)
         Else
            Console.WriteLine("'{0}' does not match the pattern.", input) 
         End If     
      Next
   End Sub
End Module
' The example displays the following output:
'       'dog' precedes 'is'.
'       'The island has beautiful birds.' does not match the pattern.
'       'The pitch missed home plate.' does not match the pattern.
'       'Sunday' precedes 'is'.
```

The regular expression \b\w+(?=\sis\b) is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`\w+` | Match one or more word characters.
`(?=\sis\b)` | Determine whether the word characters are followed by a white-space character and the string "is", which ends on a word boundary. If so, the match is successful.

## Zero-width negative lookahead assertions

The following grouping construct defines a zero-width negative lookahead assertion:

**(?!**_subexpression_**)**

where *subexpression* is any regular expression pattern. For the match to be successful, the input string must not match the regular expression pattern in *subexpression*, although the matched string is not included in the match result. 

A zero-width negative lookahead assertion is typically used either at the beginning or at the end of a regular expression. At the beginning of a regular expression, it can define a specific pattern that should not be matched when the beginning of the regular expression defines a similar but more general pattern to be matched. In this case, it is often used to limit backtracking. At the end of a regular expression, it can define a subexpression that cannot occur at the end of a match. 

The following example defines a regular expression that uses a zero-width lookahead assertion at the beginning of the regular expression to match words that do not begin with "un". 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(?!un)\w+\b";
      string input = "unite one unethical ethics use untie ultimate";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       one
//       ethics
//       use
//       ultimate
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(?!un)\w+\b"
      Dim input As String = "unite one unethical ethics use untie ultimate"
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       one
'       ethics
'       use
'       ultimate
```

The regular expression \b(?!un)\w+\b is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`(?!un)` | Determine whether the next two characters are "un". If they are not, a match is possible.
`\w+` | Match one or more word characters.
`\b` | End the match at a word boundary.
 
The following example defines a regular expression that uses a zero-width lookahead assertion at the end of the regular expression to match words that do not end with a punctuation character.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\w+\b(?!\p{P})";
      string input = "Disconnected, disjointed thoughts in a sentence fragment.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       disjointed
//       thoughts
//       in
//       a
//       sentence
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+\b(?!\p{P})"
      Dim input As String = "Disconnected, disjointed thoughts in a sentence fragment."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next   
   End Sub
End Module
' The example displays the following output:
'       disjointed
'       thoughts
'       in
'       a
'       sentence
```

The regular expression `\b\w+\b(?!\p{P})` is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`\w+` | Match one or more word characters.
`\b` | End the match at a word boundary.
`\p{P})` | If the next character is not a punctuation symbol (such as a period or a comma), the match succeeds.
 
## Zero-width positive lookbehind assertions

The following grouping construct defines a zero-width positive lookbehind assertion:

**(?<=**_subexpression_**)**

where *subexpression* is any regular expression pattern. For a match to be successful, *subexpression* must occur at the input string to the left of the current position, although subexpression is not included in the match result. A zero-width positive lookbehind assertion does not backtrack.

Zero-width positive lookbehind assertions are typically used at the beginning of regular expressions. The pattern that they define is a precondition for a match, although it is not a part of the match result. 

For example, the following example matches the last two digits of the year for the twenty first century (that is, it requires that the digits "20" precede the matched string).

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "2010 1999 1861 2140 2009";
      string pattern = @"(?<=\b20)\d{2}\b";

      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       10
//       09
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "2010 1999 1861 2140 2009"
      Dim pattern As String = "(?<=\b20)\d{2}\b"

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next      
   End Sub
End Module
' The example displays the following output:
'       10
'       09
```

The regular expression pattern `(?<=\b20)\d{2}\b` is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\d{2}` | Match two decimal digits.
`{?<=\b20)` | Continue the match if the two decimal digits are preceded by the decimal digits "20" on a word boundary.
`\b` | End the match at a word boundary.
 
Zero-width positive lookbehind assertions are also used to limit backtracking when the last character or characters in a captured group must be a subset of the characters that match that group's regular expression pattern. For example, if a group captures all consecutive word characters, you can use a zero-width positive lookbehind assertion to require that the last character be alphabetical. 

## Zero-width negative lookbehind assertions

The following grouping construct defines a zero-width negative lookbehind assertion:

**(?<!**_subexpression_**)**

where *subexpression* is any regular expression pattern. For a match to be successful, *subexpression* must not occur at the input string to the left of the current position. However, any substring that does not match subexpression is not included in the match result.

Zero-width negative lookbehind assertions are typically used at the beginning of regular expressions. The pattern that they define precludes a match in the string that follows. They are also used to limit backtracking when the last character or characters in a captured group must not be one or more of the characters that match that group's regular expression pattern. For example, if a group captures all consecutive word characters, you can use a zero-width positive lookbehind assertion to require that the last character not be an underscore (_).

The following example matches the date for any day of the week that is not a weekend (that is, that is neither Saturday nor Sunday). 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] dates = { "Monday February 1, 2010", 
                         "Wednesday February 3, 2010", 
                         "Saturday February 6, 2010", 
                         "Sunday February 7, 2010", 
                         "Monday, February 8, 2010" };
      string pattern = @"(?<!(Saturday|Sunday) )\b\w+ \d{1,2}, \d{4}\b";

      foreach (string dateValue in dates)
      {
         Match match = Regex.Match(dateValue, pattern);
         if (match.Success)
            Console.WriteLine(match.Value);
      }      
   }
}
// The example displays the following output:
//       February 1, 2010
//       February 3, 2010
//       February 8, 2010
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim dates() As String = { "Monday February 1, 2010", _
                                "Wednesday February 3, 2010", _
                                "Saturday February 6, 2010", _
                                "Sunday February 7, 2010", _
                                "Monday, February 8, 2010" }
      Dim pattern As String = "(?<!(Saturday|Sunday) )\b\w+ \d{1,2}, \d{4}\b"

      For Each dateValue As String In dates
         Dim match As Match = Regex.Match(dateValue, pattern)
         If match.Success Then
            Console.WriteLine(match.Value)
         End If   
      Next      
   End Sub
End Module
' The example displays the following output:
'       February 1, 2010
'       February 3, 2010
'       February 8, 2010
```

The regular expression pattern `(?<!(Saturday|Sunday) )\b\w+ \d{1,2}, \d{4}\b` is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`\w+` | Match one or more word characters followed by a white-space character.
`\d{1,2},` | Match either one or two decimal digits followed by a white-space character and a comma.
`\d{4}\b` | Match four decimal digits, and end the match at a word boundary.
`(?<!(Saturday|Sunday) )` | If the match is preceded by something other than the strings "Saturday" or "Sunday" followed by a space, the match is successful.

## Nonbacktracking subexpressions

The following grouping construct represents a nonbacktracking subexpression (also known as a "greedy" subexpression):

**(?>**_subexpression_**)**

where *subexpression* is any regular expression pattern.

Ordinarily, if a regular expression includes an optional or alternative matching pattern and a match does not succeed, the regular expression engine can branch in multiple directions to match an input string with a pattern. If a match is not found when it takes the first branch, the regular expression engine can back up or backtrack to the point where it took the first match and attempt the match using the second branch. This process can continue until all branches have been tried.

The **(?>**_subexpression_**)** language construct disables backtracking. The regular expression engine will match as many characters in the input string as it can. When no further match is possible, it will not backtrack to attempt alternate pattern matches. (That is, the subexpression matches only strings that would be matched by the subexpression alone; it does not attempt to match a string based on the subexpression and any subexpressions that follow it.) 

This option is recommended if you know that backtracking will not succeed. Preventing the regular expression engine from performing unnecessary searching improves performance. 

The following example illustrates how a nonbacktracking subexpression modifies the results of a pattern match. The backtracking regular expression successfully matches a series of repeated characters followed by one more occurrence of the same character on a word boundary, but the nonbacktracking regular expression does not. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "cccd.", "aaad", "aaaa" };
      string back = @"(\w)\1+.\b";
      string noback = @"(?>(\w)\1+).\b";

      foreach (string input in inputs)
      {
         Match match1 = Regex.Match(input, back);
         Match match2 = Regex.Match(input, noback);
         Console.WriteLine("{0}: ", input);

         Console.Write("   Backtracking : ");
         if (match1.Success)
            Console.WriteLine(match1.Value);
         else
            Console.WriteLine("No match");

         Console.Write("   Nonbacktracking: ");
         if (match2.Success)
            Console.WriteLine(match2.Value);
         else
            Console.WriteLine("No match");
      }
   }
}
// The example displays the following output:
//    cccd.:
//       Backtracking : cccd
//       Nonbacktracking: cccd
//    aaad:
//       Backtracking : aaad
//       Nonbacktracking: aaad
//    aaaa:
//       Backtracking : aaaa
//       Nonbacktracking: No match
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "cccd.", "aaad", "aaaa" }
      Dim back As String = "(\w)\1+.\b"
      Dim noback As String = "(?>(\w)\1+).\b"

      For Each input As String In inputs
         Dim match1 As Match = Regex.Match(input, back)
         Dim match2 As Match = Regex.Match(input, noback)
         Console.WriteLine("{0}: ", input)

         Console.Write("   Backtracking : ")
         If match1.Success Then
            Console.WriteLine(match1.Value)
         Else
            Console.WriteLine("No match")
         End If

         Console.Write("   Nonbacktracking: ")
         If match2.Success Then
            Console.WriteLine(match2.Value)
         Else
            Console.WriteLine("No match")
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    cccd.:
'       Backtracking : cccd
'       Nonbacktracking: cccd
'    aaad:
'       Backtracking : aaad
'       Nonbacktracking: aaad
'    aaaa:
'       Backtracking : aaaa
'       Nonbacktracking: No match
```

The nonbacktracking regular expression `(?>(\w)\1+).\b` is defined as shown in the following table.

Pattern | Description
------- | -----------
`(\w)` | Match a single word character and assign it to the first capturing group.
`\1+` | Match the value of the first captured substring one or more times.
`.` | Match any character.
`\b` | End the match on a word boundary.
`(?>(\w)\1+)` | Match one or more occurrences of a duplicated word character, but do not backtrack to match the last character on a word boundary.
 
## Grouping constructs and regular expression objects

Substrings that are matched by a regular expression capturing group are represented by [System.Text.RegularExpressions.Group](xref:System.Text.RegularExpressions.Group) objects, which can be retrieved from the [System.Text.RegularExpressions.GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object that is returned by the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property. The [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object is populated as follows:

* The first [Group](xref:System.Text.RegularExpressions.Group) object in the collection (the object at index zero) represents the entire match.

* The next set of [Group](xref:System.Text.RegularExpressions.Group) objects represent unnamed (numbered) capturing groups. They appear in the order in which they are defined in the regular expression, from left to right. The index values of these groups range from 1 to the number of unnamed capturing groups in the collection. (The index of a particular group is equivalent to its numbered backreference. For more information about backreferences, see [Backreference constructs in regular expressions](backreference.md)

* The final set of [Group](xref:System.Text.RegularExpressions.Group) objects represent named capturing groups. They appear in the order in which they are defined in the regular expression, from left to right. The index value of the first named capturing group is one greater than the index of the last unnamed capturing group. If there are no unnamed capturing groups in the regular expression, the index value of the first named capturing group is one. 


If you apply a quantifier to a capturing group, the corresponding [Group](xref:System.Text.RegularExpressions.Group) object's [Capture.Value](xref:System.Text.RegularExpressions.Capture.Value), [Capture.Index](xref:System.Text.RegularExpressions.Capture.Index), and [Capture.Length](xref:System.Text.RegularExpressions.Capture.Length) properties reflect the last substring that is captured by a capturing group. You can retrieve a complete set of substrings that are captured by groups that have quantifiers from the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object that is returned by the [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) property.

The following example clarifies the relationship between the [Group](xref:System.Text.RegularExpressions.Group) and [Capture](xref:System.Text.RegularExpressions.Capture) objects. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\b(\w+)\W+)+";
      string input = "This is a short sentence.";
      Match match = Regex.Match(input, pattern);
      Console.WriteLine("Match: '{0}'", match.Value);
      for (int ctr = 1; ctr < match.Groups.Count; ctr++)
      {
         Console.WriteLine("   Group {0}: '{1}'", ctr, match.Groups[ctr].Value);
         int capCtr = 0;
         foreach (Capture capture in match.Groups[ctr].Captures)
         {
            Console.WriteLine("      Capture {0}: '{1}'", capCtr, capture.Value);
            capCtr++;
         }
      }
   }
}
// The example displays the following output:
//       Match: 'This is a short sentence. '
//          Group 1: 'sentence.'
//             Capture 0: 'This '
//             Capture 1: 'is '
//             Capture 2: 'a '
//             Capture 3: 'short '
//             Capture 4: 'sentence.'
//          Group 2: 'sentence'
//             Capture 0: 'This'
//             Capture 1: 'is'
//             Capture 2: 'a'
//             Capture 3: 'short'
//             Capture 4: 'sentence'
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\b(\w+)\W+)+"
      Dim input As String = "This is a short sentence."
      Dim match As Match = Regex.Match(input, pattern)
      Console.WriteLine("Match: '{0}'", match.Value)
      For ctr As Integer = 1 To match.Groups.Count - 1
         Console.WriteLine("   Group {0}: '{1}'", ctr, match.Groups(ctr).Value)
         Dim capCtr As Integer = 0
         For Each capture As Capture In match.Groups(ctr).Captures
            Console.WriteLine("      Capture {0}: '{1}'", capCtr, capture.Value)
            capCtr += 1
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       Match: 'This is a short sentence.'
'          Group 1: 'sentence.'
'             Capture 0: 'This '
'             Capture 1: 'is '
'             Capture 2: 'a '
'             Capture 3: 'short '
'             Capture 4: 'sentence.'
'          Group 2: 'sentence'
'             Capture 0: 'This'
'             Capture 1: 'is'
'             Capture 2: 'a'
'             Capture 3: 'short'
'             Capture 4: 'sentence'
```

The regular expression pattern `\b(\w+)\W+)+` extracts individual words from a string. It is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`(\w+)` | Match one or more word characters. Together, these characters form a word. This is the second capturing group.
`\W+` | Match one or more non-word characters.
`(\w+)\W+)+` | Match the pattern of one or more word characters followed by one or more non-word characters one or more times. This is the first capturing group.
 
The first capturing group matches each word of the sentence. The second capturing group matches each word along with the punctuation and white space that follow the word. The [Group](xref:System.Text.RegularExpressions.Group) object whose index is 2 provides information about the text matched by the second capturing group. The complete set of words captured by the capturing group are available from the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object returned by the [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) property.

## See also

[Regular expression language - quick reference](quick-ref.md)

[Backtracking in regular expressions](backtracking.md)
