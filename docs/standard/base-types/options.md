---
title: Regular expression options
description: Regular expression options
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 2db2c3e6-953e-4913-8168-d707c437f2df
---

# Regular expression options

By default, the comparison of an input string with any literal characters in a regular expression pattern is case sensitive, white space in a regular expression pattern is interpreted as literal white-space characters, and capturing groups in a regular expression are named implicitly as well as explicitly. You can modify these and several other aspects of default regular expression behavior by specifying regular expression options. These options, which are listed in the following table, can be included inline as part of the regular expression pattern, or they can be supplied to a [System.Text.RegularExpressions.Regex](xref:System.Text.RegularExpressions.Regex) class constructor or static pattern matching method as a [System.Text.RegularExpressions.RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) enumeration value. 

RegexOptions member | Inline character | Effect
------------------- | ---------------- | ------ 
[None](xref:System.Text.RegularExpressions.RegexOptions.None) | Not available | Use default behavior. For more information, see [Default options](#default-options).
[IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) | **i** | Use case-insensitive matching. For more information, see [Case-insensitive matching](#case-insensitive-matching).
[Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline) | **m** | Use multiline mode, where **^** and **$** match the beginning and end of each line (instead of the beginning and end of the input string). For more information, see [Multiline mode](#multiline-mode).
[Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) | **s** | Use single-line mode, where the period (**.**) matches every character (instead of every character except **\n**). For more information, see [Single-line mode](#single-line-mode).
[ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture) | **n** | Do not capture unnamed groups. The only valid captures are explicitly named or numbered groups of the form **(?<**_name_**>** _subexpression_**)**. For more information, see [Explicit captures only](#explicit-captures-only).
[Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) | Not available | Compile the regular expression to an assembly. For more information, see [Compiled regular expressions](#compiled-regular-expressions).
[IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) | **x** | Exclude unescaped white space from the pattern, and enable comments after a number sign (**#**). For more information, see [Ignore white space](#ignore-white-space).
[RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft) | Not available | Change the search direction. Search moves from right to left instead of from left to right. For more information, see [Right-to-left mode](#right-to-left-mode).
[ECMAScript](xref:System.Text.RegularExpressions.RegexOptions.ECMAScript) | Not available | Enable ECMAScript-compliant behavior for the expression. For more information, see [ECMAScript matching behavior](#ecmascript-matching-behavior).
[CultureInvariant](xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant) | Not available | Ignore cultural differences in language. For more information, see [Comparison using the invariant culture](#comparison-using-the-invariant-culture).
 
## Specifying the options

You can specify options for regular expressions in one of three ways:

* In the *options* parameter of a [System.Text.RegularExpressions.Regex](xref:System.Text.RegularExpressions.Regex) class constructor such as [Regex.Regex(String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.%23ctor(System.String,System.Text.RegularExpressions.RegexOptions)) or static (Shared in Visual Basic) pattern-matching method, such as  [Regex.Match(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String,System.Text.RegularExpressions.RegexOptions)). The *options* parameter is a bitwise OR combination of [System.Text.RegularExpressions.RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) enumerated values. 

  When options are supplied to a [Regex](xref:System.Text.RegularExpressions.Regex) instance by using the *options* parameter of a class constructor, the options are are assigned to the [System.Text.RegularExpressions.RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) property. However, the [System.Text.RegularExpressions.RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) property does not reflect inline options in the regular expression pattern itself. 

  The following example provides an illustration. It uses the *options* parameter of the [Regex.Match(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".

  ```csharp
  string pattern = @"d \w+ \s";
  string input = "Dogs are decidedly good pets.";
  RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
  
  foreach (Match match in Regex.Matches(input, pattern, options))
     Console.WriteLine("'{0}// found at index {1}.", match.Value, match.Index);
  // The example displays the following output:
  //    'Dogs // found at index 0.
  //    'decidedly // found at index 9.      
  ```

  ```vb
  Dim pattern As String = "d \w+ \s"
  Dim input As String = "Dogs are decidedly good pets."
  Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.IgnorePatternWhitespace

  For Each match As Match In Regex.Matches(input, pattern, options)
     Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
  Next
  ' The example displays the following output:
  '    'Dogs ' found at index 0.
  '    'decidedly ' found at index 9.  
  ```

* By applying inline options in a regular expression pattern with the syntax **(?imnsx-imnsx)**. The option applies to the pattern from the point that the option is defined to either the end of the pattern or to the point at which the option is undefined by another inline option. Note that the [System.Text.RegularExpressions.RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) property of a [Regex](xref:System.Text.RegularExpressions.Regex) instance does not reflect these inline options. For more information, see the [Miscellaneous constructs in regular expressions](miscellaneous.md) topic.

  The following example provides an illustration. It uses inline options to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".

  ```csharp
  string pattern = @"(?ix) d \w+ \s";
  string input = "Dogs are decidedly good pets.";
  
  foreach (Match match in Regex.Matches(input, pattern))
     Console.WriteLine("'{0}// found at index {1}.", match.Value, match.Index);
  // The example displays the following output:
  //    'Dogs // found at index 0.
  //    'decidedly // found at index 9.      
  ```

  ```vb
  Dim pattern As String = "\b(?ix) d \w+ \s"
  Dim input As String = "Dogs are decidedly good pets."

  For Each match As Match In Regex.Matches(input, pattern)
     Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
  Next
  ' The example displays the following output:
  '    'Dogs ' found at index 0.
  '    'decidedly ' found at index 9.  
  ```

* By applying inline options in a particular grouping construct in a regular expression pattern with the syntax **(?imnsx-imnsx:**_subexpression_**)**. No sign before a set of options turns the set on; a minus sign before a set of options turns the set off. (**?** is a fixed part of the language construct's syntax that is required whether options are enabled or disabled.) The option applies only to that group. For more information, see [Grouping constructs in regular expressions](grouping.md).

  The following example provides an illustration. It uses inline options in a grouping construct to enable case-insensitive matching and to ignore pattern white space when identifying words that begin with the letter "d".

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


If options are specified inline, a minus sign (-) before an option or set of options turns off those options. For example, the inline construct **(?ix-ms)** turns on the [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) and [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) options and turns off the [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline) and [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) options. All regular expression options are turned off by default.

> [!NOTE]
> If the regular expression options specified in the options parameter of a constructor or method call conflict with the options specified inline in a regular expression pattern, the inline options are used.
 

The following five regular expression options can be set both with the *options* parameter and inline:

* [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase)

* [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline)

* [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline)

* [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture)

* [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace)

The following five regular expression options can be set using the *options* parameter but cannot be set inline:

* [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None)

* [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled)

* [RegexOptions.RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft)

* [RegexOptions.CultureInvariant](xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant)

* [RegexOptions.ECMAScript](xref:System.Text.RegularExpressions.RegexOptions.ECMAScript)

## Determining the options

You can determine which options were provided to a [Regex](xref:System.Text.RegularExpressions.Regex) object when it was instantiated by retrieving the value of the read-only [Regex.Options](xref:System.Text.RegularExpressions.Regex.Options) property.

To test for the presence of any option except [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None), perform an AND operation with the value of the [Regex.Options](xref:System.Text.RegularExpressions.Regex.Options) property and the [RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) value in which you are interested. Then test whether the result equals that [RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) value. The following example tests whether the [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) option has been set. 

```csharp
if ((rgx.Options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase)
   Console.WriteLine("Case-insensitive pattern comparison.");
else
   Console.WriteLine("Case-sensitive pattern comparison.");
```

```vb
If (rgx.Options And RegexOptions.IgnoreCase) = RegexOptions.IgnoreCase Then
   Console.WriteLine("Case-insensitive pattern comparison.")
Else
   Console.WriteLine("Case-sensitive pattern comparison.")
End If 
```

To test for [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None), determine whether the value of the [RegexOptions](xref:System.Text.RegularExpressions.RegexOptions) property is equal to [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None), as the following example illustrates. 

```csharp
if (rgx.Options == RegexOptions.None)
   Console.WriteLine("No options have been set.");
```

```vb
If rgx.Options = RegexOptions.None Then
   Console.WriteLine("No options have been set.")
End If
```

The following sections list the options supported by regular expression in  .NET. 

## Default options

The [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None) option indicates that no options have been specified, and the regular expression engine uses its default behavior. This includes the following:

* The pattern is interpreted as a canonical rather than an ECMAScript regular expression.

* The regular expression pattern is matched in the input string from left to right.

* Comparisons are case-sensitive.

* The **^** and **$** language elements match the beginning and end of the input string.

* The **.** language element matches every character except **\n**.

* Any white space in a regular expression pattern is interpreted as a literal space character.

* The conventions of the current culture are used when comparing the pattern to the input string. 

* Capturing groups in the regular expression pattern are implicit as well as explicit. 

> [!NOTE]
> The [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None) option has no inline equivalent. When regular expression options are applied inline, the default behavior is restored on an option-by-option basis, by turning a particular option off. For example, `(?i)` turns on case-insensitive comparison, and `(?-i)` restores the default case-sensitive comparison.
 
Because the [RegexOptions.None](xref:System.Text.RegularExpressions.RegexOptions.None) option represents the default behavior of the regular expression engine, it is rarely explicitly specified in a method call. A constructor or static pattern-matching method without an options parameter is called instead.

## Case-insensitive matching

The [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) option, or the **i** inline option, provides case-insensitive matching. By default, the casing conventions of the current culture are used.

The following example defines a regular expression pattern, `\bthe\w*\b`, that matches all words starting with "the". Because the first call to the Match method uses the default case-sensitive comparison, the output indicates that the string "The" that begins the sentence is not matched. It is matched when the [Match](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method is called with options set to [IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase). 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bthe\w*\b";
      string input = "The man then told them about that event.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);

      Console.WriteLine();
      foreach (Match match in Regex.Matches(input, pattern, 
                                            RegexOptions.IgnoreCase))
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found then at index 8.
//       Found them at index 18.
//       
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\bthe\w*\b"
      Dim input As String = "The man then told them about that event."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
      Next
      Console.WriteLine()
      For Each match As Match In Regex.Matches(input, pattern, _
                                               RegexOptions.IgnoreCase)
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Found then at index 8.
'       Found them at index 18.
'       
'       Found The at index 0.
'       Found then at index 8.
'       Found them at index 18.
```

The following example modifies the regular expression pattern from the previous example to use inline options instead of the *options* parameter to provide case-insensitive comparison. The first pattern defines the case-insensitive option in a grouping construct that applies only to the letter "t" in the string "the". Because the option construct occurs at the beginning of the pattern, the second pattern applies the case-insensitive option to the entire regular expression.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(?i:t)he\w*\b";
      string input = "The man then told them about that event.";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);

      Console.WriteLine();
      pattern = @"(?i)\bthe\w*\b";
      foreach (Match match in Regex.Matches(input, pattern, 
                                            RegexOptions.IgnoreCase))
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);
   }
}
// The example displays the following output:
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
//       
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(?i:t)he\w*\b"
      Dim input As String = "The man then told them about that event."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
      Next
      Console.WriteLine()
      pattern = "(?i)\bthe\w*\b"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Found The at index 0.
'       Found then at index 8.
'       Found them at index 18.
'       
'       Found The at index 0.
'       Found then at index 8.
'       Found them at index 18.
```

## Multiline mode

The [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline) option, or the **m** inline option, enables the regular expression engine to handle an input string that consists of multiple lines. It changes the interpretation of the **^** and **$** language elements so that they match the beginning and end of a line, instead of the beginning and end of the input string. 

By default, **$** matches only the end of the input string. If you specify the [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline) option, it matches either the newline character **(\n)** or the end of the input string. It does not, however, match the carriage return/line feed character combination. To successfully match them, use the subexpression **\r?$** instead of just **$**. 

The following example extracts bowlers names and scores and adds them to a [SortedList&lt;TKey, TValue&gt;](xref:System.Collections.Generic.SortedList%602) collection that sorts them in descending order. The [Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method is called twice. In the first method call, the regular expression is `^(\w+)\s(\d+)$` and no options are set. As the output shows, because the regular expression engine cannot match the input pattern along with the beginning and end of the input string, no matches are found. In the second method call, the regular expression is changed to `^(\w+)\s(\d+)\r?$` and the options are set to [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline). As the output shows, the names and scores are successfully matched, and the scores are displayed in descending order.

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer<int>());

      string input = "Joe 164\n" + 
                     "Sam 208\n" + 
                     "Allison 211\n" + 
                     "Gwen 171\n"; 
      string pattern = @"^(\w+)\s(\d+)$";
      bool matched = false;

      Console.WriteLine("Without Multiline option:");
      foreach (Match match in Regex.Matches(input, pattern))
      {
         scores.Add(Int32.Parse(match.Groups[2].Value), (string) match.Groups[1].Value);
         matched = true;
      }
      if (! matched)
         Console.WriteLine("   No matches.");
      Console.WriteLine();

      // Redefine pattern to handle multiple lines.
      pattern = @"^(\w+)\s(\d+)\r*$";
      Console.WriteLine("With multiline option:");
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
         scores.Add(Int32.Parse(match.Groups[2].Value), (string) match.Groups[1].Value);

      // List scores in descending order. 
      foreach (KeyValuePair<int, string> score in scores)
         Console.WriteLine("{0}: {1}", score.Value, score.Key);
   }
}

public class DescendingComparer<T> : IComparer<T>
{
   public int Compare(T x, T y)
   {
      return Comparer<T>.Default.Compare(x, y) * -1;       
   }
}
// The example displays the following output:
//   Without Multiline option:
//      No matches.
//   
//   With multiline option:
//   Allison: 211
//   Sam: 208
//   Gwen: 171
//   Joe: 164
```

```vb
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim scores As New SortedList(Of Integer, String)(New DescendingComparer(Of Integer)())

      Dim input As String = "Joe 164" + vbCrLf + _
                            "Sam 208" + vbCrLf + _
                            "Allison 211" + vbCrLf + _
                            "Gwen 171" + vbCrLf
      Dim pattern As String = "^(\w+)\s(\d+)$"
      Dim matched As Boolean = False

      Console.WriteLine("Without Multiline option:")
      For Each match As Match In Regex.Matches(input, pattern)
         scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
         matched = True
      Next
      If Not matched Then Console.WriteLine("   No matches.")
      Console.WriteLine()

      ' Redefine pattern to handle multiple lines.
      pattern = "^(\w+)\s(\d+)\r*$"
      Console.WriteLine("With multiline option:")
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Multiline)
         scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
      Next
      ' List scores in descending order. 
      For Each score As KeyValuePair(Of Integer, String) In scores
         Console.WriteLine("{0}: {1}", score.Value, score.Key)
      Next
   End Sub
End Module

Public Class DescendingComparer(Of T) : Implements IComparer(Of T)
   Public Function Compare(x As T, y As T) As Integer _
          Implements IComparer(Of T).Compare
      Return Comparer(Of T).Default.Compare(x, y) * -1       
   End Function
End Class
' The example displays the following output:
'    Without Multiline option:
'       No matches.
'    
'    With multiline option:
'    Allison: 211
'    Sam: 208
'    Gwen: 171
'    Joe: 164
```

The regular expression pattern `^(\w+)\s(\d+)\r*$` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`^` | Begin at the start of the line.
`(\w+)` | Match one or more word characters. This is the first capturing group.
`\s` | Match a white-space character.
`(\d+)` | Match one or more decimal digits. This is the second capturing group.
`\r?` | Match zero or one carriage return character.
`$` | End at the end of the line.
 
The following example is equivalent to the previous one, except that it uses the inline option **(?m)** to set the multiline option.

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer<int>());

      string input = "Joe 164\n" +  
                     "Sam 208\n" +  
                     "Allison 211\n" +  
                     "Gwen 171\n"; 
      string pattern = @"(?m)^(\w+)\s(\d+)\r*$";

      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
         scores.Add(Convert.ToInt32(match.Groups[2].Value), match.Groups[1].Value);

      // List scores in descending order. 
      foreach (KeyValuePair<int, string> score in scores)
         Console.WriteLine("{0}: {1}", score.Value, score.Key);
   }
}

public class DescendingComparer<T> : IComparer<T>
{
   public int Compare(T x, T y) 
   {
      return Comparer<T>.Default.Compare(x, y) * -1;       
   }
}
// The example displays the following output:
//    Allison: 211
//    Sam: 208
//    Gwen: 171
//    Joe: 164
```

```vb
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim scores As New SortedList(Of Integer, String)(New DescendingComparer(Of Integer)())

      Dim input As String = "Joe 164" + vbCrLf + _
                            "Sam 208" + vbCrLf + _
                            "Allison 211" + vbCrLf + _
                            "Gwen 171" + vbCrLf
      Dim pattern As String = "(?m)^(\w+)\s(\d+)\r*$"

      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Multiline)
         scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
      Next
      ' List scores in descending order. 
      For Each score As KeyValuePair(Of Integer, String) In scores
         Console.WriteLine("{0}: {1}", score.Value, score.Key)
      Next
   End Sub
End Module

Public Class DescendingComparer(Of T) : Implements IComparer(Of T)
   Public Function Compare(x As T, y As T) As Integer _
          Implements IComparer(Of T).Compare
      Return Comparer(Of T).Default.Compare(x, y) * -1       
   End Function
End Class
' The example displays the following output:
'    Allison: 211
'    Sam: 208
'    Gwen: 171
'    Joe: 164
```

## Single-line mode

The [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option, or the s inline option, causes the regular expression engine to treat the input string as if it consists of a single line. It does this by changing the behavior of the period (**.**) language element so that it matches every character, instead of matching every character except for the newline character **\n** or \u000A.

The following example illustrates how the behavior of the . language element changes when you use the [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option. The regular expression `^.+` starts at the beginning of the string and matches every character. By default, the match ends at the end of the first line; the regular expression pattern matches the carriage return character, **\r** or \u000D, but it does not match **\n**. Because the [RegexOptions.Singleline](xref:System.Text.RegularExpressions.RegexOptions.Singleline) option interprets the entire input string as a single line, it matches every character in the input string, including **\n**.

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

The following example is equivalent to the previous one, except that it uses the inline option **(?s)** to enable single-line mode. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {      
      string pattern = "(?s)^.+";
      string input = "This is one line and" + Environment.NewLine + "this is the second.";

      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(Regex.Escape(match.Value));
   }
}
// The example displays the following output:
//       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(?s)^.+"
      Dim input As String = "This is one line and" + vbCrLf + "this is the second."

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(Regex.Escape(match.Value))
      Next
   End Sub
End Module
' The example displays the following output:
'       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
```

## Explicit captures only

By default, capturing groups are defined by the use of parentheses in the regular expression pattern. Named groups are assigned a name or number by the **(?<**_name_**>** _subexpression_**)** language option, whereas unnamed groups are accessible by index. In the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object, unnamed groups precede named groups. 

Grouping constructs are often used only to apply quantifiers to multiple language elements, and the captured substrings are of no interest. For example, if the following regular expression:

```
\b\(?((\w+),?\s?)+[\.!?]\)?
```

is intended only to extract sentences that end with a period, exclamation point, or question mark from a document, only the resulting sentence (which is represented by the [Match](xref:System.Text.RegularExpressions.Match) object) is of interest. The individual words in the collection are not. 

Capturing groups that are not subsequently used can be expensive, because the regular expression engine must populate both the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) and [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) collection objects. As an alternative, you can use either the [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture) option or the **n** inline option to specify that the only valid captures are explicitly named or numbered groups that are designated by the **(?<**_name_**>** _subexpression_**)** construct. 

The following example displays information about the matches returned by the `\b\(?((\w+),?\s?)+[\.!?]\)?` regular expression pattern when the [Match](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.Int32)) method is called with and without the [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture) option. As the output from the first method call shows, the regular expression engine fully populates the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) and [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) collection objects with information about captured substrings. Because the second method is called with options set to [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture), it does not capture information on groups.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is the first sentence. Is it the beginning " + 
                     "of a literary masterpiece? I think not. Instead, " + 
                     "it is a nonsensical paragraph.";
      string pattern = @"\b\(?((?>\w+),?\s?)+[\.!?]\)?";
      Console.WriteLine("With implicit captures:");
      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine("The match: {0}", match.Value);
         int groupCtr = 0;
         foreach (Group group in match.Groups)
         {
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
            groupCtr++;
            int captureCtr = 0;
            foreach (Capture capture in group.Captures)
            {
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value);
               captureCtr++;
            }
         }
      }
      Console.WriteLine();
      Console.WriteLine("With explicit captures only:");
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.ExplicitCapture))
      {
         Console.WriteLine("The match: {0}", match.Value);
         int groupCtr = 0;
         foreach (Group group in match.Groups)
         {
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
            groupCtr++;
            int captureCtr = 0;
            foreach (Capture capture in group.Captures)
            {
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value);
               captureCtr++;
            }
         }
      }
   }
}
// The example displays the following output:
//    With implicit captures:
//    The match: This is the first sentence.
//       Group 0: This is the first sentence.
//          Capture 0: This is the first sentence.
//       Group 1: sentence
//          Capture 0: This
//          Capture 1: is
//          Capture 2: the
//          Capture 3: first
//          Capture 4: sentence
//       Group 2: sentence
//          Capture 0: This
//          Capture 1: is
//          Capture 2: the
//          Capture 3: first
//          Capture 4: sentence
//    The match: Is it the beginning of a literary masterpiece?
//       Group 0: Is it the beginning of a literary masterpiece?
//          Capture 0: Is it the beginning of a literary masterpiece?
//       Group 1: masterpiece
//          Capture 0: Is
//          Capture 1: it
//          Capture 2: the
//          Capture 3: beginning
//          Capture 4: of
//          Capture 5: a
//          Capture 6: literary
//          Capture 7: masterpiece
//       Group 2: masterpiece
//          Capture 0: Is
//          Capture 1: it
//          Capture 2: the
//          Capture 3: beginning
//          Capture 4: of
//          Capture 5: a
//          Capture 6: literary
//          Capture 7: masterpiece
//    The match: I think not.
//       Group 0: I think not.
//          Capture 0: I think not.
//       Group 1: not
//          Capture 0: I
//          Capture 1: think
//          Capture 2: not
//       Group 2: not
//          Capture 0: I
//          Capture 1: think
//          Capture 2: not
//    The match: Instead, it is a nonsensical paragraph.
//       Group 0: Instead, it is a nonsensical paragraph.
//          Capture 0: Instead, it is a nonsensical paragraph.
//       Group 1: paragraph
//          Capture 0: Instead,
//          Capture 1: it
//          Capture 2: is
//          Capture 3: a
//          Capture 4: nonsensical
//          Capture 5: paragraph
//       Group 2: paragraph
//          Capture 0: Instead
//          Capture 1: it
//          Capture 2: is
//          Capture 3: a
//          Capture 4: nonsensical
//          Capture 5: paragraph
//    
//    With explicit captures only:
//    The match: This is the first sentence.
//       Group 0: This is the first sentence.
//          Capture 0: This is the first sentence.
//    The match: Is it the beginning of a literary masterpiece?
//       Group 0: Is it the beginning of a literary masterpiece?
//          Capture 0: Is it the beginning of a literary masterpiece?
//    The match: I think not.
//       Group 0: I think not.
//          Capture 0: I think not.
//    The match: Instead, it is a nonsensical paragraph.
//       Group 0: Instead, it is a nonsensical paragraph.
//          Capture 0: Instead, it is a nonsensical paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is the first sentence. Is it the beginning " + _
                            "of a literary masterpiece? I think not. Instead, " + _
                            "it is a nonsensical paragraph."
      Dim pattern As String = "\b\(?((?>\w+),?\s?)+[\.!?]\)?"
      Console.WriteLine("With implicit captures:")
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("The match: {0}", match.Value)
         Dim groupCtr As Integer = 0
         For Each group As Group In match.Groups
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
            groupCtr += 1
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value)
               captureCtr += 1
            Next
         Next
      Next
      Console.WriteLine()
      Console.WriteLine("With explicit captures only:")
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.ExplicitCapture)
         Console.WriteLine("The match: {0}", match.Value)
         Dim groupCtr As Integer = 0
         For Each group As Group In match.Groups
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
            groupCtr += 1
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value)
               captureCtr += 1
            Next
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'    With implicit captures:
'    The match: This is the first sentence.
'       Group 0: This is the first sentence.
'          Capture 0: This is the first sentence.
'       Group 1: sentence
'          Capture 0: This
'          Capture 1: is
'          Capture 2: the
'          Capture 3: first
'          Capture 4: sentence
'       Group 2: sentence
'          Capture 0: This
'          Capture 1: is
'          Capture 2: the
'          Capture 3: first
'          Capture 4: sentence
'    The match: Is it the beginning of a literary masterpiece?
'       Group 0: Is it the beginning of a literary masterpiece?
'          Capture 0: Is it the beginning of a literary masterpiece?
'       Group 1: masterpiece
'          Capture 0: Is
'          Capture 1: it
'          Capture 2: the
'          Capture 3: beginning
'          Capture 4: of
'          Capture 5: a
'          Capture 6: literary
'          Capture 7: masterpiece
'       Group 2: masterpiece
'          Capture 0: Is
'          Capture 1: it
'          Capture 2: the
'          Capture 3: beginning
'          Capture 4: of
'          Capture 5: a
'          Capture 6: literary
'          Capture 7: masterpiece
'    The match: I think not.
'       Group 0: I think not.
'          Capture 0: I think not.
'       Group 1: not
'          Capture 0: I
'          Capture 1: think
'          Capture 2: not
'       Group 2: not
'          Capture 0: I
'          Capture 1: think
'          Capture 2: not
'    The match: Instead, it is a nonsensical paragraph.
'       Group 0: Instead, it is a nonsensical paragraph.
'          Capture 0: Instead, it is a nonsensical paragraph.
'       Group 1: paragraph
'          Capture 0: Instead,
'          Capture 1: it
'          Capture 2: is
'          Capture 3: a
'          Capture 4: nonsensical
'          Capture 5: paragraph
'       Group 2: paragraph
'          Capture 0: Instead
'          Capture 1: it
'          Capture 2: is
'          Capture 3: a
'          Capture 4: nonsensical
'          Capture 5: paragraph
'    
'    With explicit captures only:
'    The match: This is the first sentence.
'       Group 0: This is the first sentence.
'          Capture 0: This is the first sentence.
'    The match: Is it the beginning of a literary masterpiece?
'       Group 0: Is it the beginning of a literary masterpiece?
'          Capture 0: Is it the beginning of a literary masterpiece?
'    The match: I think not.
'       Group 0: I think not.
'          Capture 0: I think not.
'    The match: Instead, it is a nonsensical paragraph.
'       Group 0: Instead, it is a nonsensical paragraph.
'          Capture 0: Instead, it is a nonsensical paragraph.
```

The regular expression pattern `\b\(?((?>\w+),?\s?)+[\.!?]\)?` is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Begin at a word boundary.
`\(?` | Match zero or one occurrences of the opening parenthesis ("(").
`(?>\w+),?` | Match one or more word characters, followed by zero or one commas. Do not backtrack when matching word characters.
`\s?` | Match zero or one white-space characters.
`((\w+),?\s?)+` | Match the combination of one or more word characters, zero or one commas, and zero or one white-space characters one or more times.
`[\.!?]\)?` | Match any of the three punctuation symbols, followed by zero or one closing parentheses (")").
 
You can also use the **(?n)** inline element to suppress automatic captures. The following example modifies the previous regular expression pattern to use the **(?n)** inline element instead of the [RegexOptions.ExplicitCapture](xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture) option.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is the first sentence. Is it the beginning " + 
                     "of a literary masterpiece? I think not. Instead, " + 
                     "it is a nonsensical paragraph.";
      string pattern = @"(?n)\b\(?((?>\w+),?\s?)+[\.!?]\)?";

      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine("The match: {0}", match.Value);
         int groupCtr = 0;
         foreach (Group group in match.Groups)
         {
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
            groupCtr++;
            int captureCtr = 0;
            foreach (Capture capture in group.Captures)
            {
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value);
               captureCtr++;
            }
         }
      }
   }
}
// The example displays the following output:
//       The match: This is the first sentence.
//          Group 0: This is the first sentence.
//             Capture 0: This is the first sentence.
//       The match: Is it the beginning of a literary masterpiece?
//          Group 0: Is it the beginning of a literary masterpiece?
//             Capture 0: Is it the beginning of a literary masterpiece?
//       The match: I think not.
//          Group 0: I think not.
//             Capture 0: I think not.
//       The match: Instead, it is a nonsensical paragraph.
//          Group 0: Instead, it is a nonsensical paragraph.
//             Capture 0: Instead, it is a nonsensical paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is the first sentence. Is it the beginning " + _
                            "of a literary masterpiece? I think not. Instead, " + _
                            "it is a nonsensical paragraph."
      Dim pattern As String = "(?n)\b\(?((?>\w+),?\s?)+[\.!?]\)?"

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("The match: {0}", match.Value)
         Dim groupCtr As Integer = 0
         For Each group As Group In match.Groups
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
            groupCtr += 1
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value)
               captureCtr += 1
            Next
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       The match: This is the first sentence.
'          Group 0: This is the first sentence.
'             Capture 0: This is the first sentence.
'       The match: Is it the beginning of a literary masterpiece?
'          Group 0: Is it the beginning of a literary masterpiece?
'             Capture 0: Is it the beginning of a literary masterpiece?
'       The match: I think not.
'          Group 0: I think not.
'             Capture 0: I think not.
'       The match: Instead, it is a nonsensical paragraph.
'          Group 0: Instead, it is a nonsensical paragraph.
'             Capture 0: Instead, it is a nonsensical paragraph.
```

Finally, you can use the inline group element **(?n:)** to suppress automatic captures on a group-by-group basis. The following example modifies the previous pattern to suppress unnamed captures in the outer group, `((?>\w+),?\s?)`. Note that this suppresses unnamed captures in the inner group as well.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is the first sentence. Is it the beginning " + 
                     "of a literary masterpiece? I think not. Instead, " + 
                     "it is a nonsensical paragraph.";
      string pattern = @"\b\(?(?n:(?>\w+),?\s?)+[\.!?]\)?";

      foreach (Match match in Regex.Matches(input, pattern))
      {
         Console.WriteLine("The match: {0}", match.Value);
         int groupCtr = 0;
         foreach (Group group in match.Groups)
         {
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
            groupCtr++;
            int captureCtr = 0;
            foreach (Capture capture in group.Captures)
            {
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value);
               captureCtr++;
            }
         }
      }
   }
}
// The example displays the following output:
//       The match: This is the first sentence.
//          Group 0: This is the first sentence.
//             Capture 0: This is the first sentence.
//       The match: Is it the beginning of a literary masterpiece?
//          Group 0: Is it the beginning of a literary masterpiece?
//             Capture 0: Is it the beginning of a literary masterpiece?
//       The match: I think not.
//          Group 0: I think not.
//             Capture 0: I think not.
//       The match: Instead, it is a nonsensical paragraph.
//          Group 0: Instead, it is a nonsensical paragraph.
//             Capture 0: Instead, it is a nonsensical paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is the first sentence. Is it the beginning " + _
                            "of a literary masterpiece? I think not. Instead, " + _
                            "it is a nonsensical paragraph."
      Dim pattern As String = "\b\(?(?n:(?>\w+),?\s?)+[\.!?]\)?"

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("The match: {0}", match.Value)
         Dim groupCtr As Integer = 0
         For Each group As Group In match.Groups
            Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
            groupCtr += 1
            Dim captureCtr As Integer = 0
            For Each capture As Capture In group.Captures
               Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value)
               captureCtr += 1
            Next
         Next
      Next
   End Sub
End Module
' The example displays the following output:
'       The match: This is the first sentence.
'          Group 0: This is the first sentence.
'             Capture 0: This is the first sentence.
'       The match: Is it the beginning of a literary masterpiece?
'          Group 0: Is it the beginning of a literary masterpiece?
'             Capture 0: Is it the beginning of a literary masterpiece?
'       The match: I think not.
'          Group 0: I think not.
'             Capture 0: I think not.
'       The match: Instead, it is a nonsensical paragraph.
'          Group 0: Instead, it is a nonsensical paragraph.
'             Capture 0: Instead, it is a nonsensical paragraph.
```

## Compiled regular expressions

By default, regular expressions in .NET are interpreted. When a [Regex](xref:System.Text.RegularExpressions.Regex) object is instantiated or a static [Regex](xref:System.Text.RegularExpressions.Regex) method is called, the regular expression pattern is parsed into a set of custom opcodes, and an interpreter uses these opcodes to run the regular expression. This involves a tradeoff: The cost of initializing the regular expression engine is minimized at the expense of run-time performance.

You can use compiled instead of interpreted regular expressions by using the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) option. In this case, when a pattern is passed to the regular expression engine, it is parsed into a set of opcodes and then converted to Microsoft intermediate language (MSIL), which can be passed directly to the common language runtime. Compiled regular expressions maximize run-time performance at the expense of initialization time.

> [!NOTE]
> A regular expression can be compiled only by supplying the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) value to the options parameter of a [Regex](xref:System.Text.RegularExpressions.Regex) class constructor or a static pattern-matching method. It is not available as an inline option. 
 

You can use compiled regular expressions in calls to both static and instance regular expressions. In static regular expressions, the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) option is passed to the options parameter of the regular expression pattern-matching method. In instance regular expressions, it is passed to the options parameter of the [Regex](xref:System.Text.RegularExpressions.Regex) class constructor. In both cases, it results in enhanced performance. 

However, this improvement in performance occurs only under the following conditions:

* A [Regex](xref:System.Text.RegularExpressions.Regex) object that represents a particular regular expression is used in multiple calls to regular expression pattern-matching methods.

* The [Regex](xref:System.Text.RegularExpressions.Regex) object is not allowed to go out of scope, so it can be reused.

* A static regular expression is used in multiple calls to regular expression pattern-matching methods. (The performance improvement is possible because regular expressions used in static method calls are cached by the regular expression engine.) 

## Ignore white space

By default, white space in a regular expression pattern is significant; it forces the regular expression engine to match a white-space character in the input string. Because of this, the regular expression `"\b\w+\s"` and `"\b\w+ "` are roughly equivalent regular expressions. In addition, when the number sign (**#**) is encountered in a regular expression pattern, it is interpreted as a literal character to be matched.

The [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) option, or the **x** inline option, changes this default behavior as follows:

* Unescaped white space in the regular expression pattern is ignored. To be part of a regular expression pattern, white-space characters must be escaped (for example, as **\s** or "**\** ").

* The number sign (**#**) is interpreted as the beginning of a comment, rather than as a literal character. All text in the regular expression pattern from the **#** character to the end of the string is interpreted as a comment.

However, in the following cases, white space characters in a regular expression aren't ignored, even if you use the [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) option: 

* White space within a character class is always interpreted literally. For example, the regular expression pattern `[ .,;:]` matches any single white-space character, period, comma, semicolon, or colon. 

* White space isn't allowed within a bracketed quantifier, such as **{**_n_**}**, **{**_n_**,}**, and **{**_n_**,**_m_**}**. For example, the regular expression pattern **\d{1. 3}** fails to match any sequences of digits from one to three digits because it contains a white-space character. 

* White space isn't allowed within a character sequence that introduces a language element. For example: 

    * The language element **(?:**_subexpression_**)** represents a noncapturing group, and the **(?:** portion of the element can't have embedded spaces. The pattern **(? :**_subexpression_**)** throws an [ArgumentException](xref:System.ArgumentException) at run time because the regular expression engine can't parse the pattern, and the pattern **(? :**_subexpression_**)**  fails to match *subexpression*.

    * The language element **\p{**_name_**}**, which represents a Unicode category or named block, can't include embedded spaces in the **\p{** portion of the element. If you do include a white space, the element throws an [ArgumentException](xref:System.ArgumentException) at run time. 

Enabling this option helps simplify regular expressions that are often difficult to parse and to understand. It improves readability, and makes it possible to document a regular expression. 

The following example defines the following regular expression pattern:

`\b \(? ( (?>\w+) ,?\s? )+ [\.!?] \)? # Matches an entire sentence`.

This pattern is similar to the pattern defined in the [Explicit captures only](#explicit-captures-only) section, except that it uses the [RegexOptions.IgnorePatternWhitespace](xref:System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace) option to ignore pattern white space.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is the first sentence. Is it the beginning " + 
                     "of a literary masterpiece? I think not. Instead, " + 
                     "it is a nonsensical paragraph.";
      string pattern = @"\b\(?((?>\w+),?\s?)+[\.!?]\)?";

      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnorePatternWhitespace))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       This is the first sentence.
//       Is it the beginning of a literary masterpiece?
//       I think not.
//       Instead, it is a nonsensical paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is the first sentence. Is it the beginning " + _
                            "of a literary masterpiece? I think not. Instead, " + _
                            "it is a nonsensical paragraph."
      Dim pattern As String = "\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence."

      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnorePatternWhitespace)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       This is the first sentence.
'       Is it the beginning of a literary masterpiece?
'       I think not.
'       Instead, it is a nonsensical paragraph.
```

The following example uses the inline option **(?x)** to ignore pattern white space.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is the first sentence. Is it the beginning " + 
                     "of a literary masterpiece? I think not. Instead, " + 
                     "it is a nonsensical paragraph.";
      string pattern = @"(?x)\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence.";

      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
// The example displays the following output:
//       This is the first sentence.
//       Is it the beginning of a literary masterpiece?
//       I think not.
//       Instead, it is a nonsensical paragraph.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is the first sentence. Is it the beginning " + _
                            "of a literary masterpiece? I think not. Instead, " + _
                            "it is a nonsensical paragraph."
      Dim pattern As String = "(?x)\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence."

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       This is the first sentence.
'       Is it the beginning of a literary masterpiece?
'       I think not.
'       Instead, it is a nonsensical paragraph.
```

## Right-to-left mode

By default, the regular expression engine searches from left to right. You can reverse the search direction by using the [RegexOptions.RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft) option. The search automatically begins at the last character position of the string. For pattern-matching methods that include a starting position parameter, such as [Regex.Match(String, Int32)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.Int32)), the starting position is the index of the rightmost character position at which the search is to begin. 

> [!NOTE]
> Right-to-left pattern mode is available only by supplying the [RegexOptions.RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft) value to the options parameter of a [Regex](xref:System.Text.RegularExpressions.Regex) class constructor or static pattern-matching method. It is not available as an inline option. 
 

The [RegexOptions.RightToLeft](xref:System.Text.RegularExpressions.RegexOptions.RightToLeft) option changes the search direction only; it does not interpret the regular expression pattern from right to left. For example, the regular expression `\bb\w+\s` matches words that begin with the letter "b" and are followed by a white-space character. In the following example, the input string consists of three words that include one or more "b" characters. The first word begins with "b", the second ends with "b", and the third includes two "b" characters in the middle of the word. As the output from the example shows, only the first word matches the regular expression pattern. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bb\w+\s";
      string input = "builder rob rabble";
      foreach (Match match in Regex.Matches(input, pattern, RegexOptions.RightToLeft))
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);     
   }
}
// The example displays the following output:
//       'builder ' found at position 0.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\bb\w+\s"
      Dim input As String = "builder rob rabble"
      For Each match As Match In Regex.Matches(input, pattern, RegexOptions.RightToLeft)
         Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)     
      Next
   End Sub
End Module
' The example displays the following output:
'       'builder ' found at position 0.
```

Also note that the lookahead assertion (the **(?**=_subexpression_**)** language element) and the lookbehind assertion (the **(?<**=_subexpression_**)** language element) do not change direction. The lookahead assertions look to the right; the lookbehind assertions look to the left. For example, the regular expression `(?<=\d{1,2}\s)\w+,?\s\d{4}` uses the lookbehind assertion to test for a date that precedes a month name. The regular expression then matches the month and the year. For information on lookahead and lookbehind assertsions, see [Grouping constructs in regular expressions](grouping.md).

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] inputs = { "1 May 1917", "June 16, 2003" };
      string pattern = @"(?<=\d{1,2}\s)\w+,?\s\d{4}";

      foreach (string input in inputs)
      {
         Match match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
         if (match.Success)
            Console.WriteLine("The date occurs in {0}.", match.Value);
         else
            Console.WriteLine("{0} does not match.", input);
      }
   }
}
// The example displays the following output:
//       The date occurs in May 1917.
//       June 16, 2003 does not match.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim inputs() As String = { "1 May 1917", "June 16, 2003" }
      Dim pattern As String = "(?<=\d{1,2}\s)\w+,?\s\d{4}"

      For Each input As String In inputs
         Dim match As Match = Regex.Match(input, pattern, RegexOptions.RightToLeft)
         If match.Success Then
            Console.WriteLine("The date occurs in {0}.", match.Value)
         Else
            Console.WriteLine("{0} does not match.", input)
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       The date occurs in May 1917.
'       June 16, 2003 does not match.
```

The regular expression pattern is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`(?<=\d{1,2}\s)` | The beginning of the match must be preceded by one or two decimal digits followed by a space.
`\w+` | Match one or more word characters.
`,?` | Match zero or one comma characters.
`\s` | Match a white-space character.
`\d{4}` | Match four decimal digits.
 
## ECMAScript matching behavior

By default, the regular expression engine uses canonical behavior when matching a regular expression pattern to input text. However, you can instruct the regular expression engine to use ECMAScript matching behavior by specifying the [RegexOptions.ECMAScript](xref:System.Text.RegularExpressions.RegexOptions.ECMAScript) option. 

> [!NOTE]
> ECMAScript-compliant behavior is available only by supplying the [RegexOptions.ECMAScript](xref:System.Text.RegularExpressions.RegexOptions.ECMAScript) value to the options parameter of a [Regex](xref:System.Text.RegularExpressions.Regex) class constructor or static pattern-matching method. It is not available as an inline option. 
 
The [RegexOptions.ECMAScript](xref:System.Text.RegularExpressions.RegexOptions.ECMAScript) option can be combined only with the [RegexOptions.IgnoreCase](xref:System.Text.RegularExpressions.RegexOptions.IgnoreCase) and [RegexOptions.Multiline](xref:System.Text.RegularExpressions.RegexOptions.Multiline) options. The use of any other option in a regular expression results in an [ArgumentOutOfRangeException](xref:System.ArgumentOutOfRangeException).

The behavior of ECMAScript and canonical regular expressions differs in three areas: character class syntax, self-referencing capturing groups, and octal versus backreference interpretation. 

* Character class syntax. Because canonical regular expressions support Unicode whereas ECMAScript does not, character classes in ECMAScript have a more limited syntax, and some character class language elements have a different meaning. For example, ECMAScript does not support language elements such as the Unicode category or block elements *\p* and **\P**. Similarly, the **\w** element, which matches a word character, is equivalent to the **[a-zA-Z_0-9]** character class when using ECMAScript and **[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]** when using canonical behavior. For more information, see [Character classes in regular expressions](classes.md).

  The following example illustrates the difference between canonical and ECMAScript pattern matching. It defines a regular expression, `\b(\w+\s*)+`, that matches words followed by white-space characters. The input consists of two strings, one that uses the Latin character set and the other that uses the Cyrillic character set. As the output shows, the call to the [Regex.IsMatch(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method that uses ECMAScript matching fails to match the Cyrillic words, whereas the method call that uses canonical matching does match these words. 

  ```csharp
  using System;
  using System.Text.RegularExpressions;
  
  public class Example
  {
     public static void Main()
     {
        string[] values = { "целый мир", "the whole world" };
        string pattern = @"\b(\w+\s*)+";
        foreach (var value in values)
        {
           Console.Write("Canonical matching: ");
           if (Regex.IsMatch(value, pattern))
              Console.WriteLine("'{0}' matches the pattern.", value);
           else
              Console.WriteLine("{0} does not match the pattern.", value);
  
           Console.Write("ECMAScript matching: ");
           if (Regex.IsMatch(value, pattern, RegexOptions.ECMAScript))
              Console.WriteLine("'{0}' matches the pattern.", value);
           else
              Console.WriteLine("{0} does not match the pattern.", value);
           Console.WriteLine();
        }
     }
  }
  // The example displays the following output:
  //       Canonical matching: 'целый мир' matches the pattern.
  //       ECMAScript matching: целый мир does not match the pattern.
  //       
  //       Canonical matching: 'the whole world' matches the pattern.
  //       ECMAScript matching: 'the whole world' matches the pattern.
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Public Sub Main()
        Dim values() As String = { "целый мир", "the whole world" }
        Dim pattern As String = "\b(\w+\s*)+"
        For Each value In values
           Console.Write("Canonical matching: ")
           If Regex.IsMatch(value, pattern)
              Console.WriteLine("'{0}' matches the pattern.", value)
           Else
              Console.WriteLine("{0} does not match the pattern.", value)
           End If

           Console.Write("ECMAScript matching: ")
           If Regex.IsMatch(value, pattern, RegexOptions.ECMAScript)
              Console.WriteLine("'{0}' matches the pattern.", value)
           Else
              Console.WriteLine("{0} does not match the pattern.", value)
           End If
           Console.WriteLine()
        Next
     End Sub
  End Module
  ' The example displays the following output:
  '       Canonical matching: 'целый мир' matches the pattern.
  '       ECMAScript matching: целый мир does not match the pattern.
  '       
  '       Canonical matching: 'the whole world' matches the pattern.
  '       ECMAScript matching: 'the whole world' matches the pattern.
  ```

* Self-referencing capturing groups. A regular expression capture class with a backreference to itself must be updated with each capture iteration. As the following example shows, this feature enables the regular expression `((a+)(\1) ?)+` to match the input string " aa aaaa aaaaaa " when using ECMAScript, but not when using canonical matching. 

  ```csharp
  using System;
  using System.Text.RegularExpressions;

  public class Example
  {
     static string pattern;
  
     public static void Main()
     {
        string input = "aa aaaa aaaaaa "; 
        pattern = @"((a+)(\1) ?)+";
  
        // Match input using canonical matching.
        AnalyzeMatch(Regex.Match(input, pattern));

        // Match input using ECMAScript.
        AnalyzeMatch(Regex.Match(input, pattern, RegexOptions.ECMAScript));
     }   

     private static void AnalyzeMatch(Match m)
     {
        if (m.Success)
        {
           Console.WriteLine("'{0}' matches {1} at position {2}.",  
                             pattern, m.Value, m.Index);
           int grpCtr = 0;
           foreach (Group grp in m.Groups)
           {
              Console.WriteLine("   {0}: '{1}'", grpCtr, grp.Value);
              grpCtr++;
              int capCtr = 0;
              foreach (Capture cap in grp.Captures)
              {
                 Console.WriteLine("      {0}: '{1}'", capCtr, cap.Value);
                 capCtr++;
              }
           }
        }
        else
        {
           Console.WriteLine("No match found.");
        }   
        Console.WriteLine();
     }
  }
  // The example displays the following output:
  //    No match found.
  //    
  //    '((a+)(\1) ?)+' matches aa aaaa aaaaaa  at position 0.
  //       0: 'aa aaaa aaaaaa '
  //          0: 'aa aaaa aaaaaa '
  //       1: 'aaaaaa '
  //          0: 'aa '
  //          1: 'aaaa '
  //          2: 'aaaaaa '
  //       2: 'aa'
  //          0: 'aa'
  //          1: 'aa'
  //          2: 'aa'
  //       3: 'aaaa '
  //          0: ''
  //          1: 'aa '
  //          2: 'aaaa '
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Dim pattern As String

     Public Sub Main()
        Dim input As String = "aa aaaa aaaaaa " 
        pattern = "((a+)(\1) ?)+"
  
        ' Match input using canonical matching.
        AnalyzeMatch(Regex.Match(input, pattern))

        ' Match input using ECMAScript.
        AnalyzeMatch(Regex.Match(input, pattern, RegexOptions.ECMAScript))
     End Sub   

     Private Sub AnalyzeMatch(m As Match)
        If m.Success
           Console.WriteLine("'{0}' matches {1} at position {2}.", _ 
                             pattern, m.Value, m.Index)
           Dim grpCtr As Integer = 0
           For Each grp As Group In m.Groups
              Console.WriteLine("   {0}: '{1}'", grpCtr, grp.Value)
              grpCtr += 1
              Dim capCtr As Integer = 0
              For Each cap As Capture In grp.Captures
                 Console.WriteLine("      {0}: '{1}'", capCtr, cap.Value)
                 capCtr += 1
              Next
           Next
        Else
           Console.WriteLine("No match found.")
        End If   
        Console.WriteLine()
     End Sub
  End Module
  ' The example displays the following output:
  '    No match found.
  '    
  '    '((a+)(\1) ?)+' matches aa aaaa aaaaaa  at position 0.
  '       0: 'aa aaaa aaaaaa '
  '          0: 'aa aaaa aaaaaa '
  '       1: 'aaaaaa '
  '          0: 'aa '
  '          1: 'aaaa '  
  '          2: 'aaaaaa '
  '       2: 'aa'
  '          0: 'aa'
  '          1: 'aa'
  '          2: 'aa'
  '       3: 'aaaa '
  '          0: ''
  '          1: 'aa '
  '          2: 'aaaa '
  ``

  The regular expression is defined as shown in the following table.

Pattern | Description
------- | ----------- 
`(a+)` | Match the letter "a" one or more times. This is the second capturing group.
`(\1)` | Match the substring captured by the first capturing group. This is the third capturing group.
`?` | Match zero or one space characters.
`((a+)(\1) ?)+` | Match the pattern of one or more "a" characters followed by a string that matches the first capturing group followed by zero or one space characters one or more times. This is the first capturing group.
  
* Resolution of ambiguities between octal escapes and backreferences. The following table summarizes the differences in octal versus backreference interpretation by canonical and ECMAScript regular expressions.

Regular expression | Canonical behavior | ECMAScript behavior
------------------ | ------------------ | ------------------- 
`\0` followed by 0 to 2 octal digits | Interpret as an octal. For example, `\044` is always interpreted as an octal value and means "**$**". | Same behavior.
**\** followed by a digit from 1 to 9, followed by no additional decimal digits | Interpret as a backreference. For example, \9 always means backreference 9, even if a ninth capturing group does not exist. If the capturing group does not exist, the regular expression parser throws an [ArgumentException](xref:System.ArgumentException). | If a single decimal digit capturing group exists, backreference to that digit. Otherwise, interpret the value as a literal.
**\** followed by a digit from 1 to 9, followed by additional decimal digits | Interpret the digits as a decimal value. If that capturing group exists, interpret the expression as a backreference. Otherwise, interpret the leading octal digits up to octal 377; that is, consider only the low 8 bits of the value. Interpret the remaining digits as literals. For example, in the expression `\3000`, if capturing group 300 exists, interpret as backreference 300; if capturing group 300 does not exist, interpret as octal 300 followed by 0. | Interpret as a backreference by converting as many digits as possible to a decimal value that can refer to a capture. If no digits can be converted, interpret as an octal by using the leading octal digits up to octal 377; interpret the remaining digits as literals.
 
## Comparison using the invariant culture

By default, when the regular expression engine performs case-insensitive comparisons, it uses the casing conventions of the current culture to determine equivalent uppercase and lowercase characters. 

However, this behavior is undesirable for some types of comparisons, particularly when comparing user input to the names of system resources, such as passwords, files, or URLs. The following example illustrates such as scenario. The code is intended to block access to any resource whose URL is prefaced with **FILE://**. The regular expression attempts a case-insensitive match with the string by using the regular expression `$FILE://`. However, when the current system culture is tr-TR (Turkish-Turkey), "I" is not the uppercase equivalent of "i". As a result, the call to the [Regex.IsMatch](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String)) method returns `false`, and access to the file is allowed. 

```csharp
CultureInfo defaultCulture = Thread.CurrentThread.CurrentCulture;
Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

string input = "file://c:/Documents.MyReport.doc";
string pattern = "FILE://";

Console.WriteLine("Culture-sensitive matching ({0} culture)...", 
                  Thread.CurrentThread.CurrentCulture.Name);
if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
   Console.WriteLine("URLs that access files are not allowed.");      
else
   Console.WriteLine("Access to {0} is allowed.", input);

Thread.CurrentThread.CurrentCulture = defaultCulture;
// The example displays the following output:
//       Culture-sensitive matching (tr-TR culture)...
//       Access to file://c:/Documents.MyReport.doc is allowed.
```

```vb
Dim defaultCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")

Dim input As String = "file://c:/Documents.MyReport.doc"
Dim pattern As String = "$FILE://"

Console.WriteLine("Culture-sensitive matching ({0} culture)...", _
                  Thread.CurrentThread.CurrentCulture.Name)
If Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase) Then
   Console.WriteLine("URLs that access files are not allowed.")      
Else
   Console.WriteLine("Access to {0} is allowed.", input)
End If

Thread.CurrentThread.CurrentCulture = defaultCulture
' The example displays the following output:
'       Culture-sensitive matching (tr-TR culture)...
'       Access to file://c:/Documents.MyReport.doc is allowed.
```

> [!NOTE]
>   For more information about string comparisons that are case-sensitive and that use the invariant culture, see [Best Practices for Using Strings](best-practices.md).
 
Instead of using the case-insensitive comparisons of the current culture, you can specify the [RegexOptions.CultureInvariant](xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant) option to ignore cultural differences in language and to use the conventions of the invariant culture.

> [!NOTE]
> Comparison using the invariant culture is available only by supplying the [RegexOptions.CultureInvariant](xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant) value to the options parameter of a [Regex](xref:System.Text.RegularExpressions.Regex) class constructor or static pattern-matching method. It is not available as an inline option. 
 
The following example is identical to the previous example, except that the static [Regex.IsMatch(String, String, RegexOptions)](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String,System.String,System.Text.RegularExpressions.RegexOptions)) method is called with options that include [RegexOptions.CultureInvariant](xref:System.Text.RegularExpressions.RegexOptions.CultureInvariant). Even when the current culture is set to Turkish (Turkey), the regular expression engine is able to successfully match "FILE" and "file" and block access to the file resource. 

```csharp
CultureInfo defaultCulture = Thread.CurrentThread.CurrentCulture;
Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

string input = "file://c:/Documents.MyReport.doc";
string pattern = "FILE://";

Console.WriteLine("Culture-insensitive matching...");
if (Regex.IsMatch(input, pattern, 
                  RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) 
   Console.WriteLine("URLs that access files are not allowed.");
else
   Console.WriteLine("Access to {0} is allowed.", input);

Thread.CurrentThread.CurrentCulture = defaultCulture;
// The example displays the following output:
//       Culture-insensitive matching...
//       URLs that access files are not allowed.
```

```vb
Dim defaultCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")

Dim input As String = "file://c:/Documents.MyReport.doc"
Dim pattern As String = "$FILE://"

Console.WriteLine("Culture-insensitive matching...")
If Regex.IsMatch(input, pattern, _
               RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant) Then
   Console.WriteLine("URLs that access files are not allowed.")      
Else
   Console.WriteLine("Access to {0} is allowed.", input)
End If
Thread.CurrentThread.CurrentCulture = defaultCulture
' The example displays the following output:
'        Culture-insensitive matching...
'        URLs that access files are not allowed.
```

## See also

[Regular expression language - quick reference](quick-ref.md)

