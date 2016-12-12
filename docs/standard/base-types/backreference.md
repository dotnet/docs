---
title: Backreference constructs in regular expressions
description: Backreference constructs in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c453ed78-650f-4c3c-9ab4-9d89d250bf88
---

# Backreference constructs in regular expressions

Backreferences provide a convenient way to identify a repeated character or substring within a string. For example, if the input string contains multiple occurrences of an arbitrary substring, you can match the first occurrence with a capturing group, and then use a backreference to match subsequent occurrences of the substring. 

> [!NOTE]
> A separate syntax is used to refer to named and numbered capturing groups in replacement strings. For more information, see [Substitutions in regular expressions](substitutions.md).
 
.NET defines separate language elements to refer to numbered and named capturing groups. For more information about capturing groups, see [Grouping constructs in regular expressions](grouping.md).

## Numbered Backreferences

A numbered backreference uses the following syntax:

**\**_number_

where *number* is the ordinal position of the capturing group in the regular expression. For example, `\4` matches the contents of the fourth capturing group. If *number* is not defined in the regular expression pattern, a parsing error occurs, and the regular expression engine throws an [ArgumentException](xref:System.ArgumentException). For example, the regular expression `\b(\w+)\s\1` is valid, because `(\w+)` is the first and only capturing group in the expression. On the other hand, `\b(\w+)\s\2` is invalid and throws an argument exception, because there is no capturing group numbered `\2`.

Note the ambiguity between octal escape codes (such as `\16`) and **\**_number_ backreferences that use the same notation. This ambiguity is resolved as follows:

* The expressions `\1` through `\9` are always interpreted as backreferences, and not as octal codes.

* If the first digit of a multidigit expression is 8 or 9 (such as `\80` or `\91`), the expression as interpreted as a literal.

* Expressions from `\10` and greater are considered backreferences if there is a backreference corresponding to that number; otherwise, they are interpreted as octal codes.

* If a regular expression contains a backreference to an undefined group number, a parsing error occurs, and the regular expression engine throws an [ArgumentException](xref:System.ArgumentException).

If the ambiguity is a problem, you can use the **\k<**_name_**>** notation, which is unambiguous and cannot be confused with octal character codes. Similarly, hexadecimal codes such as `\xdd` are unambiguous and cannot be confused with backreferences.

The following example finds doubled word characters in a string. It defines a regular expression, `(\w)\1,` which consists of the following elements.

Element | Description
------- | -----------
`(\w)` | Match a word character and assign it to the first capturing group.
`\1` | Match the next character that is the same as the value of the first capturing group.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\w)\1";
      string input = "trellis llama webbing dresser swagger";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Found '{0}' at position {1}.", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'll' at position 3.
//       Found 'll' at position 8.
//       Found 'bb' at position 16.
//       Found 'ss' at position 25.
//       Found 'gg' at position 33.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\w)\1"
      Dim input As String = "trellis llama webbing dresser swagger"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found '{0}' at position {1}.", _
                           match.Value, match.Index)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Found 'll' at position 3.
'       Found 'll' at position 8.
'       Found 'bb' at position 16.
'       Found 'ss' at position 25.
'       Found 'gg' at position 33.
```

## Named Backreferences

A named backreference is defined by using the following syntax:

**\k<**_name_**>**

or:

**\k'**_name_**'**

where *name* is the name of a capturing group defined in the regular expression pattern. If *name* is not defined in the regular expression pattern, a parsing error occurs, and the regular expression engine throws an [ArgumentException](xref:System.ArgumentException).

The following example finds doubled word characters in a string. It defines a regular expression, `(?<char>\w)\k<char>`, which consists of the following elements.

Element | Description
------- | -----------
`(?<char>\w)` | Match a word character and assign it to a capturing group named char.
`\k<char>` | Match the next character that is the same as the value of the char capturing group.
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<char>\w)\k<char>";
      string input = "trellis llama webbing dresser swagger";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Found '{0}' at position {1}.", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'll' at position 3.
//       Found 'll' at position 8.
//       Found 'bb' at position 16.
//       Found 'ss' at position 25.
//       Found 'gg' at position 33.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<char>\w)\k<char>"
      Dim input As String = "trellis llama webbing dresser swagger"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found '{0}' at position {1}.", _
                           match.Value, match.Index)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Found 'll' at position 3.
'       Found 'll' at position 8.
'       Found 'bb' at position 16.
'       Found 'ss' at position 25.
'       Found 'gg' at position 33.
```

Note that *name* can also be the string representation of a number. For example, the following example uses the regular expression `(?<2>\w)\k<2>` to find doubled word characters in a string.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<2>\w)\k<2>";
      string input = "trellis llama webbing dresser swagger";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Found '{0}' at position {1}.", 
                           match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found 'll' at position 3.
//       Found 'll' at position 8.
//       Found 'bb' at position 16.
//       Found 'ss' at position 25.
//       Found 'gg' at position 33.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<2>\w)\k<2>"
      Dim input As String = "trellis llama webbing dresser swagger"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found '{0}' at position {1}.", _
                           match.Value, match.Index)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Found 'll' at position 3.
'       Found 'll' at position 8.
'       Found 'bb' at position 16.
'       Found 'ss' at position 25.
'       Found 'gg' at position 33.
```

## What Backreferences Match

A backreference refers to the most recent definition of a group (the definition most immediately to the left, when matching left to right). When a group makes multiple captures, a backreference refers to the most recent capture. 

The following example includes a regular expression pattern, `(?<1>a)(?<1>\1b)*`, which redefines the \1 named group. The following table describes each pattern in the regular expression. 

Pattern | Description
------- | -----------
`(?<1>a)` | Match the character "a" and assign the result to the capturing group named 1.
`(?<1>\1b)*` |Match 0 or 1 occurrence of the group named 1 along with a "b", and assign the result to the capturing group named 1. 
 
```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(?<1>a)(?<1>\1b)*";
      string input = "aababb";
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine("Match: " + match.Value);
         foreach (Group group in match.Groups)
            Console.WriteLine("   Group: " + group.Value);
      }
   }
}
// The example displays the following output:
//          Group: aababb
//          Group: abb
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?<1>a)(?<1>\1b)*"
      Dim input As String = "aababb"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Match: " + match.Value)
         For Each group As Group In match.Groups
            Console.WriteLIne("   Group: " + group.Value)
         Next
      Next
   End Sub
End Module
' The example display the following output:
'          Group: aababb
'          Group: abb
```

In comparing the regular expression with the input string ("aababb"), the regular expression engine performs the following operations:

1. It starts at the beginning of the string, and successfully matches "a" with the expression `(?<1>a)`. The value of the 1 group is now "a".

2. It advances to the second character, and successfully matches the string "ab" with the expression `\1b`, or "ab". It then assigns the result, "ab" to `\1`.

3. It advances to the fourth character. The expression `(?<1>\1b)` is to be matched zero or more times, so it successfully matches the string "abb" with the expression `\1b`. It assigns the result, "abb", back to `\1`.

In this example, \* is a looping quantifier -- it is evaluated repeatedly until the regular expression engine cannot match the pattern it defines. Looping quantifiers do not clear group definitions.

If a group has not captured any substrings, a backreference to that group is undefined and never matches. This is illustrated by the regular expression pattern `\b(\p{Lu}{2})(\d{2})?(\p{Lu}{2})\b,` which is defined as follows:

Pattern | Description
------- | -----------
`\b` | Begin the match on a word boundary.
`(\p{Lu}{2})` | Match two uppercase letters. This is the first capturing group.
`(\d{2})?` | Match zero or one occurrence of two decimal digits. This is the second capturing group.
`(\p{Lu}{2})` | Match two uppercase letters. This is the third capturing group.
`\b` | End the match on a word boundary.

An input string can match this regular expression even if the two decimal digits that are defined by the second capturing group are not present. The following example shows that even though the match is successful, an empty capturing group is found between two successful capturing groups.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\p{Lu}{2})(\d{2})?(\p{Lu}{2})\b";
      string[] inputs = { "AA22ZZ", "AABB" };
      foreach (string input in inputs)
      {
         Match match = Regex.Match(input, pattern);
         if (match.Success)
         {
            Console.WriteLine("Match in {0}: {1}", input, match.Value);
            if (match.Groups.Count > 1)
            {
               for (int ctr = 1; ctr <= match.Groups.Count - 1; ctr++)
               {
                  if (match.Groups[ctr].Success)
                     Console.WriteLine("Group {0}: {1}", 
                                       ctr, match.Groups[ctr].Value);
                  else
                     Console.WriteLine("Group {0}: <no match>", ctr);
               }
            }
         }
         Console.WriteLine();
      }      
   }
}
// The example displays the following output:
//       Match in AA22ZZ: AA22ZZ
//       Group 1: AA
//       Group 2: 22
//       Group 3: ZZ
//       
//       Match in AABB: AABB
//       Group 1: AA
//       Group 2: <no match>
//       Group 3: BB
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\p{Lu}{2})(\d{2})?(\p{Lu}{2})\b"
      Dim inputs() As String = { "AA22ZZ", "AABB" }
      For Each input As String In inputs
         Dim match As Match = Regex.Match(input, pattern)
         If match.Success Then
            Console.WriteLine("Match in {0}: {1}", input, match.Value)
            If match.Groups.Count > 1 Then
               For ctr As Integer = 1 To match.Groups.Count - 1
                  If match.Groups(ctr).Success Then
                     Console.WriteLine("Group {0}: {1}", _
                                       ctr, match.Groups(ctr).Value)
                  Else
                     Console.WriteLine("Group {0}: <no match>", ctr)
                  End If      
               Next
            End If
         End If
         Console.WriteLine()
      Next      
   End Sub
End Module
' The example displays the following output:
'       Match in AA22ZZ: AA22ZZ
'       Group 1: AA
'       Group 2: 22
'       Group 3: ZZ
'       
'       Match in AABB: AABB
'       Group 1: AA
'       Group 2: <no match>
'       Group 3: BB
```

## See Also

[Regular expression language - quick reference](quick-ref.md)

