---
title: "Regular expression example: scanning for HREFs"
description: Regular expression example scanning for HREFs
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: d6484880-bdac-47cd-b5e5-9419c9ed14cd
---

# Regular expression example: scanning for HREFs

The following example searches an input string and displays all the href="…" values and their locations in the string. 

## The Regex Object

Because the `DumpHRefs` method can be called multiple times from user code, it uses the `static` [Regex.Match(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method. This enables the regular expression engine to cache the regular expression and avoids the overhead of instantiating a new [Regex](xref:System.Text.RegularExpressions.Regex) object each time the method is called. A [Match](xref:System.Text.RegularExpressions.Match) object is then used to iterate through all matches in the string. 

```csharp
private static void DumpHRefs(string inputString) 
{
   Match m;
   string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

   try {
      m = Regex.Match(inputString, HRefPattern, 
                      RegexOptions.IgnoreCase | RegexOptions.Compiled, 
                      TimeSpan.FromSeconds(1));
      while (m.Success)
      {
         Console.WriteLine("Found href " + m.Groups[1] + " at " 
            + m.Groups[1].Index);
         m = m.NextMatch();
      }   
   }
   catch (RegexMatchTimeoutException) {
      Console.WriteLine("The matching operation timed out.");
   }
}
```

```vb
Private Sub DumpHRefs(inputString As String) 
   Dim m As Match
   Dim HRefPattern As String = "href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))"

   Try
      m = Regex.Match(inputString, HRefPattern, _ 
                      RegexOptions.IgnoreCase Or RegexOptions.Compiled,
                      TimeSpan.FromSeconds(1))
      Do While m.Success
         Console.WriteLine("Found href {0} at {1}.", _
                           m.Groups(1), m.Groups(1).Index)
         m = m.NextMatch()
      Loop   
   Catch e As RegexMatchTimeoutException
      Console.WriteLine("The matching operation timed out.")
   End Try
End Sub
```

The following example then illustrates a call to the `DumpHRefs` method.

```csharp
public static void Main()
{
   string inputString = "My favorite web sites include:</P>" +
                        "<A HREF=\"http://msdn2.microsoft.com\">" +
                        "MSDN Home Page</A></P>" +
                        "<A HREF=\"http://www.microsoft.com\">" +
                        "Microsoft Corporation Home Page</A></P>" +
                        "<A HREF=\"http://blogs.msdn.com/bclteam\">" +
                        ".NET Base Class Library blog</A></P>";
   DumpHRefs(inputString);                     

}
// The example displays the following output:
//       Found href http://msdn2.microsoft.com at 43
//       Found href http://www.microsoft.com at 102
//       Found href http://blogs.msdn.com/bclteam at 176
```

```vb
Public Sub Main()
   Dim inputString As String = "My favorite web sites include:</P>" & _
                               "<A HREF=""http://msdn2.microsoft.com"">" & _
                               "MSDN Home Page</A></P>" & _
                               "<A HREF=""http://www.microsoft.com"">" & _
                               "Microsoft Corporation Home Page</A></P>" & _
                               "<A HREF=""http://blogs.msdn.com/bclteam"">" & _
                               ".NET Base Class Library blog</A></P>"
   DumpHRefs(inputString)                     
End Sub
' The example displays the following output:
'       Found href http://msdn2.microsoft.com at 43
'       Found href http://www.microsoft.com at 102
'       Found href http://blogs.msdn.com/bclteam/) at 176
```

The regular expression pattern `href\s*=\s*(?:["']&#40;?<1>[^"']*)["']|(?<1>\S+))` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`href` | Match the literal string "href". The match is case-insensitive.
`\s*` | Match zero or more white-space characters.
`=` |`Match the equals sign.
`\s*` | Match zero or more white-space characters.
`(?:["']&#40;?<1>[^"']*)"&#124;(?<1>\S+))` | Match one of the following without assigning the result to a captured group: A quotation mark or apostrophe, followed by zero or more occurrences of any character other than a quotation mark or apostrophe, followed by a quotation mark or apostrophe. The group named `1` is included in this pattern. -or- One or more non-white-space characters. The group named `1` is included in this pattern.
`(?<1>[^"']*)` | Assign zero or more occurrences of any character other than a quotation mark or apostrophe to the capturing group named `1`.
`"(?<1>\S+)` | Assign one or more non-white-space characters to the capturing group named `1`.
 
## Match Result Class

The results of a search are stored in the [Match](xref:System.Text.RegularExpressions.Match) class, which provides access to all the substrings extracted by the search. It also remembers the string being searched and the regular expression being used, so it can call the [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method to perform another search starting where the last one ended.

## Explicitly Named Captures

In traditional regular expressions, capturing parentheses are automatically numbered sequentially. This leads to two problems. First, if a regular expression is modified by inserting or removing a set of parentheses, all code that refers to the numbered captures must be rewritten to reflect the new numbering. Second, because different sets of parentheses often are used to provide two alternative expressions for an acceptable match, it might be difficult to determine which of the two expressions actually returned a result.

To address these problems, the [Regex](xref:System.Text.RegularExpressions.Regex) class supports the syntax `(?<name>…)` for capturing a match into a specified slot (the slot can be named using a string or an integer; integers can be recalled more quickly). Thus, alternative matches for the same string all can be directed to the same place. In case of a conflict, the last match dropped into a slot is the successful match. (However, a complete list of multiple matches for a single slot is available. See the [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) collection for details.)

## See Also

[.NET regular expressions](regular-expressions.md)

[Regular expression examples](regex-examples.md)

