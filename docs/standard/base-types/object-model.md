---
title: The regular expression object model
description: The regular expression object model
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: a1e611ec-c6a2-48c6-9c52-0ed845787621
---

# The regular expression object model

This topic describes the object model used in working with.NET regular expressions. It contains the following sections:

* [The regular expression engine](#the-regular-expression-engine)

* [The MatchCollection and Match objects](#the-matchcollection-and-match-objects)

* [The Group collection](#the-group-collection)

* [The captured group](#the-captured-group)

* [The capture collection](#the-capture-collection)

* [The individual capture](#the-individual-capture)

## The regular expression engine

The regular expression engine in .NET is represented by the [Regex](xref:System.Text.RegularExpressions.Regex) class. The regular expression engine is responsible for parsing and compiling a regular expression, and for performing operations that match the regular expression pattern with an input string. The engine is the central component in .NET regular expression object model.

You can use the regular expression engine in either of two ways:

* By calling the static methods of the [Regex](xref:System.Text.RegularExpressions.Regex) class. The method parameters include the input string and the regular expression pattern. The regular expression engine caches regular expressions that are used in static method calls, so repeated calls to static regular expression methods that use the same regular expression offer relatively good performance.

* By instantiating a [Regex](xref:System.Text.RegularExpressions.Regex) object, by passing a regular expression to the class constructor. In this case, the [Regex](xref:System.Text.RegularExpressions.Regex) object is immutable (read-only) and represents a regular expression engine that is tightly coupled with a single regular expression. Because regular expressions used by Regex instances are not cached, you should not instantiate a [Regex](xref:System.Text.RegularExpressions.Regex) object multiple times with the same regular expression.

You can call the methods of the [Regex](xref:System.Text.RegularExpressions.Regex) class to perform the following operations: 

* Determine whether a string matches a regular expression pattern.

* Extract a single match or the first match.

* Extract all matches.

* Replace a matched substring.

* Split a single string into an array of strings.

These operations are described in the following sections.

### Matching a regular expression pattern

The [Regex.IsMatch](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String)) method returns `true` if the string matches the pattern, or `false` if it does not. The [IsMatch](xref:System.Text.RegularExpressions.Regex.IsMatch(System.String)) method is often used to validate string input. For example, the following code ensures that a string matches a valid social security number in the United States.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] values = { "111-22-3333", "111-2-3333"};
      string pattern = @"^\d{3}-\d{2}-\d{4}$";
      foreach (string value in values) {
         if (Regex.IsMatch(value, pattern))
            Console.WriteLine("{0} is a valid SSN.", value);
         else   
            Console.WriteLine("{0}: Invalid", value);
      }
   }
}
// The example displays the following output:
//       111-22-3333 is a valid SSN.
//       111-2-3333: Invalid
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim values() As String = { "111-22-3333", "111-2-3333"}
      Dim pattern As String = "^\d{3}-\d{2}-\d{4}$"
      For Each value As String In values
         If Regex.IsMatch(value, pattern) Then
            Console.WriteLine("{0} is a valid SSN.", value)
         Else   
            Console.WriteLine("{0}: Invalid", value)
         End If   
      Next
   End Sub
End Module
' The example displays the following output:
'       111-22-3333 is a valid SSN.
'       111-2-3333: Invalid
```

The regular expression pattern `^\d{3}-\d{2}-\d{4}$` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`^` | Match the beginning of the input string.
`\d{3}` | Match three decimal digits.
`-` | Match a hyphen.
`\d{2}` | Match two decimal digits.
`-` | Match a hyphen.
`\d{4}` | Match four decimal digits.
`$` | Match the end of the input string.
 
### Extracting a single match or the first match

The [Regex.Match](xref:System.Text.RegularExpressions.Regex.Match(System.String)) method returns a [Match](xref:System.Text.RegularExpressions.Match) object that contains information about the first substring that matches a regular expression pattern. If the `Match.Success` property returns `true`, indicating that a match was found, you can retrieve information about subsequent matches by calling the [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method. These method calls can continue until the `Match.Success` property returns `false`. For example, the following code uses the [Regex.Match(String, String)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String)) method to find the first occurrence of a duplicated word in a string. It then calls the [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method to find any additional occurrences. The example examines the `Match.Success` property after each method call to determine whether the current match was successful and whether a call to the [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method should follow.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is a a farm that that raises dairy cattle."; 
      string pattern = @"\b(\w+)\W+(\1)\b";
      Match match = Regex.Match(input, pattern);
      while (match.Success)
      {
         Console.WriteLine("Duplicate '{0}' found at position {1}.",  
                           match.Groups[1].Value, match.Groups[2].Index);
         match = match.NextMatch();
      }                       
   }
}
// The example displays the following output:
//       Duplicate 'a' found at position 10.
//       Duplicate 'that' found at position 22.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is a a farm that that raises dairy cattle." 
      Dim pattern As String = "\b(\w+)\W+(\1)\b"
      Dim match As Match = Regex.Match(input, pattern)
      Do While match.Success
         Console.WriteLine("Duplicate '{0}' found at position {1}.", _ 
                           match.Groups(1).Value, match.Groups(2).Index)
         match = match.NextMatch()
      Loop                       
   End Sub
End Module
' The example displays the following output:
'       Duplicate 'a' found at position 10.
'       Duplicate 'that' found at position 22.
```

The regular expression pattern `\b(\w+)\W+(\1)\b` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Begin the match on a word boundary.
`(\w+)` | Match one or more word characters. This is the first capturing group.
`\W+` | Match one or more non-word characters.
`(\1)` | Match the first captured string. This is the second capturing group. 
`\b` | End the match on a word boundary.
 
### Extracting all matches

The [Regex.Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method returns a [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object that contains information about all matches that the regular expression engine found in the input string. For example, the previous example could be rewritten to call the [Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method instead of the [Match](xref:System.Text.RegularExpressions.Regex.Match(System.String)) and [NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) methods.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "This is a a farm that that raises dairy cattle."; 
      string pattern = @"\b(\w+)\W+(\1)\b";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine("Duplicate '{0}' found at position {1}.",  
                           match.Groups[1].Value, match.Groups[2].Index);
   }
}
// The example displays the following output:
//       Duplicate 'a' found at position 10.
//       Duplicate 'that' found at position 22.
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is a a farm that that raises dairy cattle." 
      Dim pattern As String = "\b(\w+)\W+(\1)\b"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("Duplicate '{0}' found at position {1}.", _ 
                           match.Groups(1).Value, match.Groups(2).Index)
      Next                       
   End Sub
End Module
' The example displays the following output:
'       Duplicate 'a' found at position 10.
'       Duplicate 'that' found at position 22.
```

### Replacing a matched substring

The [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) method replaces each substring that matches the regular expression pattern with a specified string or regular expression pattern, and returns the entire input string with replacements. For example, the following code adds a U.S. currency symbol before a decimal number in a string.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\d+\.\d{2}\b";
      string replacement = "$$$&"; 
      string input = "Total Cost: 103.64";
      Console.WriteLine(Regex.Replace(input, pattern, replacement));     
   }
}
// The example displays the following output:
//       Total Cost: $103.64
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\d+\.\d{2}\b"
      Dim replacement As String = "$$$&" 
      Dim input As String = "Total Cost: 103.64"
      Console.WriteLine(Regex.Replace(input, pattern, replacement))     
   End Sub
End Module
' The example displays the following output:
'       Total Cost: $103.64
```

The regular expression pattern `\b\d+\.\d{2}\b` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Begin the match at a word boundary.
`\d+` | Match one or more decimal digits.
`\.` | Match a period.
`\d{2}` | Match two decimal digits.
`\b` | End the match at a word boundary.
 
The replacement pattern `$$$&` is interpreted as shown in the following table.

Pattern | Replacement string
------- | ------------------ 
`$$` | The dollar sign (**$**) character.
`$&` | The entire matched substring.
 
### Splitting a single string into an array of strings

The [Regex.Split](xref:System.Text.RegularExpressions.Regex.Split(System.String)) method splits the input string at the positions defined by a regular expression match. For example, the following code places the items in a numbered list into a string array.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "1. Eggs 2. Bread 3. Milk 4. Coffee 5. Tea";
      string pattern = @"\b\d{1,2}\.\s";
      foreach (string item in Regex.Split(input, pattern))
      {
         if (! String.IsNullOrEmpty(item))
            Console.WriteLine(item);
      }      
   }
}
// The example displays the following output:
//       Eggs
//       Bread
//       Milk
//       Coffee
//       Tea
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "1. Eggs 2. Bread 3. Milk 4. Coffee 5. Tea"
      Dim pattern As String = "\b\d{1,2}\.\s"
      For Each item As String In Regex.Split(input, pattern)
         If Not String.IsNullOrEmpty(item) Then
            Console.WriteLine(item)
         End If
      Next      
   End Sub
End Module
' The example displays the following output:
'       Eggs
'       Bread
'       Milk
'       Coffee
'       Tea
```

The regular expression pattern `\b\d{1,2}\.\s` is interpreted as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`\d{1,2}` | Match one or two decimal digits.
`\.` | Match a period.
`\s` | Match a white-space character.
 
## The MatchCollection and Match objects

[Regex](xref:System.Text.RegularExpressions.Regex) methods return two objects that are part of the regular expression object model: the [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object, and the [Match](xref:System.Text.RegularExpressions.Match) object. 

### The Match collection

The [Regex.Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method returns a [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object that contains [Match](xref:System.Text.RegularExpressions.Match) objects that represent all the matches that the regular expression engine found, in the order in which they occur in the input string. If there are no matches, the method returns a [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object that contains  [Match](xref:System.Text.RegularExpressions.Match) object with no members. The [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) `Item` property lets you access individual members of the collection by index, from zero to one less than the value of the [MatchCollection.Count](xref:System.Text.RegularExpressions.MatchCollection.Count) property. 'Item` is the collection's indexer (in C#) and default property (in Visual Basic)..

By default, the call to the [Regex.Matches](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method uses lazy evaluation to populate the [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object. Access to properties that require a fully populated collection, such as the [MatchCollection.Count](xref:System.Text.RegularExpressions.MatchCollection.Count) and `Item` properties, may involve a performance penalty. As a result, we recommend that you access the collection by using the [IEnumerator](xref:System.Collections.IEnumerator) object that is returned by the [MatchCollection.GetEnumerator](xref:System.Text.RegularExpressions.MatchCollection.GetEnumerator) method. Individual languages provide constructs, such as `foreach` in C# and `For Each' in Visual Basic, that wrap the collection's IEnumerator](xref:System.Collections.IEnumerator) interface.

The following example uses the [Regex.Matches(String)](xref:System.Text.RegularExpressions.Regex.Matches(System.String)) method to populate a [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object with all the matches found in an input string. The example enumerates the collection, copies the matches to a string array, and records the character positions in an integer array.

```csharp
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
       MatchCollection matches;
       List<string> results = new List<string>();
       List<int> matchposition = new List<int>();

       // Create a new Regex object and define the regular expression.
       Regex r = new Regex("abc");
       // Use the Matches method to find all matches in the input string.
       matches = r.Matches("123abc4abcd");
       // Enumerate the collection to retrieve all matches and positions.
       foreach (Match match in matches)
       {
          // Add the match string to the string array.
           results.Add(match.Value);
           // Record the character position where the match was found.
           matchposition.Add(match.Index);
       }
       // List the results.
       for (int ctr = 0; ctr < results.Count; ctr++)
         Console.WriteLine("'{0}' found at position {1}.", 
                           results[ctr], matchposition[ctr]);  
   }
}
// The example displays the following output:
//       'abc' found at position 3.
//       'abc' found at position 7.
```

```vb
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
       Dim matches As MatchCollection
       Dim results As New List(Of String)
       Dim matchposition As New List(Of Integer)

       ' Create a new Regex object and define the regular expression.
       Dim r As New Regex("abc")
       ' Use the Matches method to find all matches in the input string.
       matches = r.Matches("123abc4abcd")
       ' Enumerate the collection to retrieve all matches and positions.
       For Each match As Match In matches
          ' Add the match string to the string array.
           results.Add(match.Value)
           ' Record the character position where the match was found.
           matchposition.Add(match.Index)
       Next
       ' List the results.
       For ctr As Integer = 0 To results.Count - 1
         Console.WriteLine("'{0}' found at position {1}.", _
                           results(ctr), matchposition(ctr))  
       Next
   End Sub
End Module
' The example displays the following output:
'       'abc' found at position 3.
'       'abc' found at position 7.
```

### The Match

The [Match](xref:System.Text.RegularExpressions.Match) class represents the result of a single regular expression match. You can access [Match](xref:System.Text.RegularExpressions.Match) objects in two ways:

* By retrieving them from the [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object that is returned by the Regex.Matches method. To retrieve individual [Match](xref:System.Text.RegularExpressions.Match) objects, iterate the collection by using a `foreach` (in C#) or `For Each...Next` (in Visual Basic) construct, or use the [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) `Item` property to retrieve a specific [Match](xref:System.Text.RegularExpressions.Match) object either by index or by name. You can also retrieve individual [Match](xref:System.Text.RegularExpressions.Match) objects from the collection by iterating the collection by index, from zero to one less that the number of objects in the collection. However, this method does not take advantage of lazy evaluation, because it accesses the [MatchCollection.Count](xref:System.Text.RegularExpressions.MatchCollection.Count) property. 

  The following example retrieves individual [Match](xref:System.Text.RegularExpressions.Match) objects from a [MatchCollection](xref:System.Text.RegularExpressions.MatchCollection) object by iterating the collection using the `foreach` construct. The regular expression simply matches the string "abc" in the input string.

  ```csharp
  using System;
  using System.Text.RegularExpressions;

  public class Example
  {
     public static void Main()
     {
        string pattern = "abc";
        string input = "abc123abc456abc789";
        foreach (Match match in Regex.Matches(input, pattern))
           Console.WriteLine("{0} found at position {1}.", 
                             match.Value, match.Index);
     }
  }
  // The example displays the following output:
  //       abc found at position 0.
  //       abc found at position 6.
  //       abc found at position 12.
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Public Sub Main()
        Dim pattern As String = "abc"
        Dim input As String = "abc123abc456abc789"
        For Each match As Match In Regex.Matches(input, pattern)
           Console.WriteLine("{0} found at position {1}.", _
                             match.Value, match.Index)
        Next                     
     End Sub
  End Module
  ' The example displays the following output:
  '       abc found at position 0.
  '       abc found at position 6.
  '       abc found at position 12.
  ```

* By calling the [Regex.Match](xref:System.Text.RegularExpressions.Regex.Match(System.String)) method, which returns a [Match](xref:System.Text.RegularExpressions.Match) object that represents the first match in a string or a portion of a string. You can determine whether the match has been found by retrieving the value of the `Match.Success` property. To retrieve [Match](xref:System.Text.RegularExpressions.Match) objects that represent subsequent matches, call the [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method repeatedly, until the `Success` property of the returned [Match](xref:System.Text.RegularExpressions.Match) object is `false`. 

  The following example uses the [Regex.Match(String, String)](xref:System.Text.RegularExpressions.Regex.Match(System.String,System.String)) and [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) methods to match the string "abc" in the input string.

  ```csharp
  using System;
  using System.Text.RegularExpressions;

  public class Example
  {
     public static void Main()
     {
        string pattern = "abc";
        string input = "abc123abc456abc789";
        Match match = Regex.Match(input, pattern);
        while (match.Success)
        {
           Console.WriteLine("{0} found at position {1}.", 
                             match.Value, match.Index);
           match = match.NextMatch();                  
        }                     
     }
  }
  // The example displays the following output:
  //       abc found at position 0.
  //       abc found at position 6.
  //       abc found at position 12.
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Public Sub Main()
        Dim pattern As String = "abc"
        Dim input As String = "abc123abc456abc789"
        Dim match As Match = Regex.Match(input, pattern)
        Do While match.Success
           Console.WriteLine("{0} found at position {1}.", _
                             match.Value, match.Index)
           match = match.NextMatch()                  
        Loop                     
     End Sub
  End Module
  ' The example displays the following output:
  '       abc found at position 0.
  '       abc found at position 6.
  '       abc found at position 12.
  ```

Two properties of the [Match](xref:System.Text.RegularExpressions.Match) class return collection objects:

* The [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property returns a [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object that contains information about the substrings that match capturing groups in the regular expression pattern. 

* The `Match.Captures` property returns a [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object that is of limited use. The collection is not populated for a [Match](xref:System.Text.RegularExpressions.Match) object whose `Success` property is `false`. Otherwise, it contains a single [Capture](xref:System.Text.RegularExpressions.Capture) object that has the same information as the [Match](xref:System.Text.RegularExpressions.Match) object. 

For more information about these objects, see the [The Group collection](#the-group-collection) and [The capture collection](#the-capture-collection) sections later in this topic.

Two additional properties of the [Match](xref:System.Text.RegularExpressions.Match) class provide information about the match. The `Match.Value` property returns the substring in the input string that matches the regular expression pattern. The `Match.Index` property returns the zero-based starting position of the matched string in the input string.

The [Match](xref:System.Text.RegularExpressions.Match) class also has two pattern-matching methods:

* The [Match.NextMatch](xref:System.Text.RegularExpressions.Match.NextMatch) method finds the match after the match represented by the current [Match](xref:System.Text.RegularExpressions.Match) object, and returns a [Match](xref:System.Text.RegularExpressions.Match) object that represents that match.

* The [Match.Result](xref:System.Text.RegularExpressions.Match.NextMatch) method performs a specified replacement operation on the matched string and returns the result. 


The following example uses the [Match.Result](xref:System.Text.RegularExpressions.Match.NextMatch) method to prepend a **$** symbol and a space before every number that includes two fractional digits. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b\d+(,\d{3})*\.\d{2}\b";
      string input = "16.32\n194.03\n1,903,672.08"; 

      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Result("$$ $&"));
   }
}
// The example displays the following output:
//       $ 16.32
//       $ 194.03
//       $ 1,903,672.08
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\d+(,\d{3})*\.\d{2}\b"
      Dim input As String = "16.32" + vbCrLf + "194.03" + vbCrLf + "1,903,672.08" 

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Result("$$ $&"))
      Next
   End Sub
End Module
' The example displays the following output:
'       $ 16.32
'       $ 194.03
'       $ 1,903,672.08
```

The regular expression pattern `\b\d+(,\d{3})*\.\d{2}\b` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`\d+` | Match one or more decimal digits.
`(,\d{3})*` | Match zero or more occurrences of a comma followed by three decimal digits.
`\.` | Match the decimal point character.
`\d{2} | Match two decimal digits.
`\b` | End the match at a word boundary.
 
The replacement pattern **$$ $&** indicates that the matched substring should be replaced by a dollar sign (**$**) symbol (the `$$` pattern), a space, and the value of the match (the `$&` pattern).

## The Group collection

The [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property returns a [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object that contains [Group](xref:System.Text.RegularExpressions.Group) objects that represent captured groups in a single match. The first [Group](xref:System.Text.RegularExpressions.Group) object in the collection (at index 0) represents the entire match. Each object that follows represents the results of a single capturing group. 

You can retrieve individual [Group](xref:System.Text.RegularExpressions.Group) objects in the collection by using the [GroupCollection.Item](xref:System.Text.RegularExpressions.GroupCollection.Item(System.Int32)) property. You can retrieve unnamed groups by their ordinal position in the collection, and retrieve named groups either by name or by ordinal position. Unnamed captures appear first in the collection, and are indexed from left to right in the order in which they appear in the regular expression pattern. Named captures are indexed after unnamed captures, from left to right in the order in which they appear in the regular expression pattern. To determine what numbered groups are available in the collection returned for a particular regular expression matching method, you can call the instance [Regex.GetGroupNumbers](xref:System.Text.RegularExpressions.Regex.GetGroupNumbers) method. To determine what named groups are available in the collection, you can call the instance R[Regex.GetGroupNames](xref:System.Text.RegularExpressions.Regex.GetGroupNames) method. Both methods are particularly useful in general-purpose routines that analyze the matches found by any regular expression. 

The [GroupCollection.Item](xref:System.Text.RegularExpressions.GroupCollection.Item(System.Int32)) property is the indexer of the collection in C# and the collection object's default property in Visual Basic. This means that individual [Group](xref:System.Text.RegularExpressions.Group) objects can be accessed by index (or by name, in the case of named groups) as follows: 

```csharp
Group group = match.Groups[ctr];
```

```vb
Dim group As Group = match.Groups(ctr)
```

The following example defines a regular expression that uses grouping constructs to capture the month, day, and year of a date. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b(\w+)\s(\d{1,2}),\s(\d{4})\b";
      string input = "Born: July 28, 1989";
      Match match = Regex.Match(input, pattern);
      if (match.Success)
         for (int ctr = 0; ctr <  match.Groups.Count; ctr++)
            Console.WriteLine("Group {0}: {1}", ctr, match.Groups[ctr].Value);
    }
}
// The example displays the following output:
//       Group 0: July 28, 1989
//       Group 1: July
//       Group 2: 28
//       Group 3: 1989
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\w+)\s(\d{1,2}),\s(\d{4})\b"
      Dim input As String = "Born: July 28, 1989"
      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         For ctr As Integer = 0 To match.Groups.Count - 1
            Console.WriteLine("Group {0}: {1}", ctr, match.Groups(ctr).Value)
         Next      
      End If   
   End Sub
End Module
' The example displays the following output:
'       Group 0: July 28, 1989
'       Group 1: July
'       Group 2: 28
'       Group 3: 1989
```

The regular expression pattern `\b(\w+)\s(\d{1,2}),\s(\d{4})\b` is defined as shown in the following table.

Pattern | Description
------- | -----------
`\b` | Begin the match at a word boundary.
`(\w+)` | Match one or more word characters. This is the first capturing group.
`\s` | Match a white-space character.
`(\d{1,2})` | Match one or two decimal digits. This is the second capturing group.
`,` | Match a comma.
`\s` | Match a white-space character.
`(\d{4})` | Match four decimal digits. This is the third capturing group.
`\b` | End the match on a word boundary.
 
## The captured group

The [Group](xref:System.Text.RegularExpressions.Group) class represents the result from a single capturing group. [Group](xref:System.Text.RegularExpressions.Group) objects that represent the capturing groups defined in a regular expression are returned by the [Item](xref:System.Text.RegularExpressions.GroupCollection.Item(System.Int32)) property of the [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object returned by the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property. The [Item](xref:System.Text.RegularExpressions.GroupCollection.Item(System.Int32)) property is the indexer (in C#) and the default property (in Visual Basic) of the [Group](xref:System.Text.RegularExpressions.Group) class. You can also retrieve individual members by iterating the collection using the `foreach` construct. For an example, see the previous section.

The following example uses nested grouping constructs to capture substrings into groups. The regular expression pattern `(a(b))c` matches the string "abc". It assigns the substring "ab" to the first capturing group, and the substring "b" to the second capturing group.

```csharp
List<int> matchposition = new List<int>();
List<string> results = new List<string>();
// Define substrings abc, ab, b.
Regex r = new Regex("(a(b))c"); 
Match m = r.Match("abdabc");
for (int i = 0; m.Groups[i].Value != ""; i++) 
{
   // Add groups to string array.
   results.Add(m.Groups[i].Value); 
   // Record character position.
   matchposition.Add(m.Groups[i].Index); 
}

// Display the capture groups.
for (int ctr = 0; ctr < results.Count; ctr++)
   Console.WriteLine("{0} at position {1}", 
                     results[ctr], matchposition[ctr]);
// The example displays the following output:
//       abc at position 3
//       ab at position 3
//       b at position 4
```

```vb
Dim matchposition As New List(Of Integer)
 Dim results As New List(Of String)
 ' Define substrings abc, ab, b.
 Dim r As New Regex("(a(b))c") 
 Dim m As Match = r.Match("abdabc")
 Dim i As Integer = 0
 While Not (m.Groups(i).Value = "")    
    ' Add groups to string array.
    results.Add(m.Groups(i).Value)     
    ' Record character position. 
    matchposition.Add(m.Groups(i).Index) 
     i += 1
 End While

 ' Display the capture groups.
 For ctr As Integer = 0 to results.Count - 1
    Console.WriteLine("{0} at position {1}", _ 
                      results(ctr), matchposition(ctr))
 Next                     
' The example displays the following output:
'       abc at position 3
'       ab at position 3
'       b at position 4
```

The following example uses named grouping constructs to capture substrings from a string that contains data in the format "DATANAME:VALUE", which the regular expression splits at the colon (:).

```csharp
Regex r = new Regex("^(?<name>\\w+):(?<value>\\w+)");
Match m = r.Match("Section1:119900");
Console.WriteLine(m.Groups["name"].Value);
Console.WriteLine(m.Groups["value"].Value);
// The example displays the following output:
//       Section1
//       119900
```

```vb
Dim r As New Regex("^(?<name>\w+):(?<value>\w+)")
Dim m As Match = r.Match("Section1:119900")
Console.WriteLine(m.Groups("name").Value)
Console.WriteLine(m.Groups("value").Value)
' The example displays the following output:
'       Section1
'       119900
```

The regular expression pattern `^(?<name>\w+):(?<value>\w+)` is defined as shown in the following table.

Pattern | Description
------- | -----------
`^` | Begin the match at the beginning of the input string.
`(?<name>\w+)` | Match one or more word characters. The name of this capturing group is name.
`:` | Match a colon.
`(?<value>\w+)` | Match one or more word characters. The name of this capturing group is value.
 
The properties of the [Group](xref:System.Text.RegularExpressions.Group) class provide information about the captured group: The `Group.Value` property contains the captured substring, the `Group.Index` property indicates the starting position of the captured group in the input text, the `Group.Length` property contains the length of the captured text, and the `Group.Success` property indicates whether a substring matched the pattern defined by the capturing group.

Applying quantifiers to a group (for more information, see [Quantifiers in regular expressions](quantifiers.md)) modifies the relationship of one capture per capturing group in two ways:

* If the __*__ or __*?__ quantifier (which specifies zero or more matches) is applied to a group, a capturing group may not have a match in the input string. When there is no captured text, the properties of the [Group](xref:System.Text.RegularExpressions.Group) object are set as shown in the following table.

  Group property | Value
  -------------- | ----- 
  `Success` | `false`
  `Value` | [String.Empty](xref:System.String.Empty) 
  `Length` | 0
 
  The following example provides an illustration. In the regular expression pattern `aaa(bbb)*ccc`, the first capturing group (the substring "bbb") can be matched zero or more times. Because the input string "aaaccc" matches the pattern, the capturing group does not have a match.

  ```csharp
  using System;
  using System.Text.RegularExpressions;

  public class Example
  {
     public static void Main()
     {
        string pattern = "aaa(bbb)*ccc";
        string input = "aaaccc";
        Match match = Regex.Match(input, pattern);
        Console.WriteLine("Match value: {0}", match.Value);
        if (match.Groups[1].Success)
           Console.WriteLine("Group 1 value: {0}", match.Groups[1].Value);
        else
           Console.WriteLine("The first capturing group has no match.");
     }
  }
  // The example displays the following output:
  //       Match value: aaaccc
  //       The first capturing group has no match.
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Public Sub Main()
        Dim pattern As String = "aaa(bbb)*ccc"
        Dim input As String = "aaaccc"
        Dim match As Match = Regex.Match(input, pattern)
        Console.WriteLine("Match value: {0}", match.Value)
        If match.Groups(1).Success Then
           Console.WriteLine("Group 1 value: {0}", match.Groups(1).Value)
        Else
           Console.WriteLine("The first capturing group has no match.")
       End If   
     End Sub
  End Module
  ' The example displays the following output:
  '       Match value: aaaccc
  '       The first capturing group has no match.
  ```

* Quantifiers can match multiple occurrences of a pattern that is defined by a capturing group. In this case, the `Value` and `Length` properties of a [Group](xref:System.Text.RegularExpressions.Group) object contain information only about the last captured substring. For example, the following regular expression matches a single sentence that ends in a period. It uses two grouping constructs: The first captures individual words along with a white-space character; the second captures individual words. As the output from the example shows, although the regular expression succeeds in capturing an entire sentence, the second capturing group captures only the last word.

  ```csharp
  using System;
  using System.Text.RegularExpressions;

  public class Example
  {
     public static void Main()
     {
        string pattern = @"\b((\w+)\s?)+\.";
        string input = "This is a sentence. This is another sentence.";
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
           Console.WriteLine("Match: " + match.Value);
           Console.WriteLine("Group 2: " + match.Groups[2].Value);
        }   
     }
  }
  // The example displays the following output:
  //       Match: This is a sentence.
  //       Group 2: sentence
  ```

  ```vb
  Imports System.Text.RegularExpressions

  Module Example
     Public Sub Main()
        Dim pattern As String = "\b((\w+)\s?)+\."
        Dim input As String = "This is a sentence. This is another sentence."
        Dim match As Match = Regex.Match(input, pattern)
        If match.Success Then
           Console.WriteLine("Match: " + match.Value)
           Console.WriteLine("Group 2: " + match.Groups(2).Value)
        End If   
     End Sub
  End Module
  ' The example displays the following output:
  '       Match: This is a sentence.
  '       Group 2: sentence
  ```

## The capture collection

The [Group](xref:System.Text.RegularExpressions.Group) object contains information only about the last capture. However, the entire set of captures made by a capturing group is still available from the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object that is returned by the [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) property. Each member of the collection is a [Capture](xref:System.Text.RegularExpressions.Capture) object that represents a capture made by that capturing group, in the order in which they were captured (and, therefore, in the order in which the captured strings were matched from left to right in the input string). You can retrieve individual [Capture](xref:System.Text.RegularExpressions.Capture) objects from the collection in either of two ways: 

* By iterating through the collection using a construct such as `foreach` (in C#) or `For Each` (in Visual Basic).

* By using the [CaptureCollection.Item](xref:System.Text.RegularExpressions.CaptureCollection.Item(System.Int32)) property to retrieve a specific object by index. The Item property is the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object's default property (in Visual Basic) or indexer (in C#).


If a quantifier is not applied to a capturing group, the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object contains a single [Capture](xref:System.Text.RegularExpressions.Capture) object that is of little interest, because it provides information about the same match as its [Group](xref:System.Text.RegularExpressions.Group) object. If a quantifier is applied to a capturing group, the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object contains all captures made by the capturing group, and the last member of the collection represents the same capture as the [Group](xref:System.Text.RegularExpressions.Group) object. 

For example, if you use the regular expression pattern `((a(b))c)+` (where the `+` quantifier specifies one or more matches) to capture matches from the string "abcabcabc", the [CaptureCollection](xref:System.Text.RegularExpressions.CaptureCollection) object for each [Group](xref:System.Text.RegularExpressions.Group) object contains three members.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "((a(b))c)+";
      string input = "abcabcabc";

      Match match = Regex.Match(input, pattern);
      if (match.Success)
      {
         Console.WriteLine("Match: '{0}' at position {1}",  
                           match.Value, match.Index);
         GroupCollection groups = match.Groups;
         for (int ctr = 0; ctr < groups.Count; ctr++) {
            Console.WriteLine("   Group {0}: '{1}' at position {2}", 
                              ctr, groups[ctr].Value, groups[ctr].Index);
            CaptureCollection captures = groups[ctr].Captures;
            for (int ctr2 = 0; ctr2 < captures.Count; ctr2++) {
               Console.WriteLine("      Capture {0}: '{1}' at position {2}", 
                                 ctr2, captures[ctr2].Value, captures[ctr2].Index);
            }                     
         }
      }
   }
}
// The example displays the following output:
//       Match: 'abcabcabc' at position 0
//          Group 0: 'abcabcabc' at position 0
//             Capture 0: 'abcabcabc' at position 0
//          Group 1: 'abc' at position 6
//             Capture 0: 'abc' at position 0
//             Capture 1: 'abc' at position 3
//             Capture 2: 'abc' at position 6
//          Group 2: 'ab' at position 6
//             Capture 0: 'ab' at position 0
//             Capture 1: 'ab' at position 3
//             Capture 2: 'ab' at position 6
//          Group 3: 'b' at position 7
//             Capture 0: 'b' at position 1
//             Capture 1: 'b' at position 4
//             Capture 2: 'b' at position 7
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "((a(b))c)+"
      Dim input As STring = "abcabcabc"

      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         Console.WriteLine("Match: '{0}' at position {1}", _ 
                           match.Value, match.Index)
         Dim groups As GroupCollection = match.Groups
         For ctr As Integer = 0 To groups.Count - 1
            Console.WriteLine("   Group {0}: '{1}' at position {2}", _
                              ctr, groups(ctr).Value, groups(ctr).Index)
            Dim captures As CaptureCollection = groups(ctr).Captures
            For ctr2 As Integer = 0 To captures.Count - 1
               Console.WriteLine("      Capture {0}: '{1}' at position {2}", _
                                 ctr2, captures(ctr2).Value, captures(ctr2).Index)
            Next
         Next
      End If
   End Sub
End Module
' The example dosplays the following output:
'       Match: 'abcabcabc' at position 0
'          Group 0: 'abcabcabc' at position 0
'             Capture 0: 'abcabcabc' at position 0
'          Group 1: 'abc' at position 6
'             Capture 0: 'abc' at position 0
'             Capture 1: 'abc' at position 3
'             Capture 2: 'abc' at position 6
'          Group 2: 'ab' at position 6
'             Capture 0: 'ab' at position 0
'             Capture 1: 'ab' at position 3
'             Capture 2: 'ab' at position 6
'          Group 3: 'b' at position 7
'             Capture 0: 'b' at position 1
'             Capture 1: 'b' at position 4
'             Capture 2: 'b' at position 7
```

The following example uses the regular expression `(Abc)+` to find one or more consecutive runs of the string "Abc" in the string "XYZAbcAbcAbcXYZAbcAb". The example illustrates the use of the [Group.Captures](xref:System.Text.RegularExpressions.Group.Captures) property to return multiple groups of captured substrings.

```csharp
{
   int counter;
   Match m;
   CaptureCollection cc;
   GroupCollection gc;

   // Look for groupings of "Abc".
   Regex r = new Regex("(Abc)+"); 
   // Define the string to search.
   m = r.Match("XYZAbcAbcAbcXYZAbcAb"); 
   gc = m.Groups;

   // Display the number of groups.
   Console.WriteLine("Captured groups = " + gc.Count.ToString());

   // Loop through each group.
   for (int i=0; i < gc.Count; i++) 
   {
      cc = gc[i].Captures;
      counter = cc.Count;

      // Display the number of captures in this group.
      Console.WriteLine("Captures count = " + counter.ToString());

      // Loop through each capture in the group.
      for (int ii = 0; ii < counter; ii++) 
      {
         // Display the capture and its position.
         Console.WriteLine(cc[ii] + "   Starts at character " + 
              cc[ii].Index);
      }
   }
}
// The example displays the following output:
//       Captured groups = 2
//       Captures count = 1
//       AbcAbcAbc   Starts at character 3
//       Captures count = 3
//       Abc   Starts at character 3
//       Abc   Starts at character 6
//       Abc   Starts at character 9  
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "((a(b))c)+"
      Dim input As STring = "abcabcabc"

      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         Console.WriteLine("Match: '{0}' at position {1}", _ 
                           match.Value, match.Index)
         Dim groups As GroupCollection = match.Groups
         For ctr As Integer = 0 To groups.Count - 1
            Console.WriteLine("   Group {0}: '{1}' at position {2}", _
                              ctr, groups(ctr).Value, groups(ctr).Index)
            Dim captures As CaptureCollection = groups(ctr).Captures
            For ctr2 As Integer = 0 To captures.Count - 1
               Console.WriteLine("      Capture {0}: '{1}' at position {2}", _
                                 ctr2, captures(ctr2).Value, captures(ctr2).Index)
            Next
         Next
      End If
   End Sub
End Module
' The example displays the following output:
'       Match: 'abcabcabc' at position 0
'          Group 0: 'abcabcabc' at position 0
'             Capture 0: 'abcabcabc' at position 0
'          Group 1: 'abc' at position 6
'             Capture 0: 'abc' at position 0
'             Capture 1: 'abc' at position 3
'             Capture 2: 'abc' at position 6
'          Group 2: 'ab' at position 6
'             Capture 0: 'ab' at position 0
'             Capture 1: 'ab' at position 3
'             Capture 2: 'ab' at position 6
'          Group 3: 'b' at position 7
'             Capture 0: 'b' at position 1
'             Capture 1: 'b' at position 4
'             Capture 2: 'b' at position 7
```

## The individual capture

The [Capture](xref:System.Text.RegularExpressions.Capture) class contains the results from a single subexpression capture. The [Capture.Value](xref:System.Text.RegularExpressions.Capture.Value) property contains the matched text, and the [Capture.Index](xref:System.Text.RegularExpressions.Capture.Index) property indicates the zero-based position in the input string at which the matched substring begins. 

The following example parses an input string for the temperature of selected cities. A comma (",") is used to separate a city and its temperature, and a semicolon (";") is used to separate each city's data. The entire input string represents a single match. In the regular expression pattern `((\w+(\s\w+)*),(\d+);)+`, which is used to parse the string, the city name is assigned to the second capturing group, and the temperature is assigned to the fourth capturing group.

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "Miami,78;Chicago,62;New York,67;San Francisco,59;Seattle,58;"; 
      string pattern = @"((\w+(\s\w+)*),(\d+);)+";
      Match match = Regex.Match(input, pattern);
      if (match.Success)
      {
         Console.WriteLine("Current temperatures:");
         for (int ctr = 0; ctr < match.Groups[2].Captures.Count; ctr++)
            Console.WriteLine("{0,-20} {1,3}", match.Groups[2].Captures[ctr].Value, 
                              match.Groups[4].Captures[ctr].Value);
      }
   }
}
// The example displays the following output:
//       Current temperatures:
//       Miami                 78
//       Chicago               62
//       New York              67
//       San Francisco         59
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "Miami,78;Chicago,62;New York,67;San Francisco,59;Seattle,58;" 
      Dim pattern As String = "((\w+(\s\w+)*),(\d+);)+"
      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         Console.WriteLine("Current temperatures:")
         For ctr As Integer = 0 To match.Groups(2).Captures.Count - 1
            Console.WriteLine("{0,-20} {1,3}", match.Groups(2).Captures(ctr).Value, _
                              match.Groups(4).Captures(ctr).Value)
         Next
      End If
   End Sub
End Module
' The example displays the following output:
'       Current temperatures:
'       Miami                 78
'       Chicago               62
'       New York              67
'       San Francisco         59
```

The regular expression is defined as shown in the following table.

Pattern | Description
------- | -----------
`\w+` | Match one or more word characters.
`(\s\w+)*` | Match zero or more occurrences of a white-space character followed by one or more word characters. This pattern matches multi-word city names. This is the third capturing group.
`(\w+(\s\w+)*)` | Match one or more word characters followed by zero or more occurrences of a white-space character and one or more word characters. This is the second capturing group.
`,` | Match a comma.
`(\d+)` | Match one or more digits. This is the fourth capturing group.
`;` | Match a semicolon.
`((\w+(\s\w+)*),(\d+);)+` | Match the pattern of a word followed by any additional words followed by a comma, one or more digits, and a semicolon, one or more times. This is the first capturing group. 
 
## See also

[System.Text.RegularExpressions](xref:System.Text.RegularExpressions)

[.NET regular expressions](regular-expressions.md)

[Regular expression language - quick reference](quick-ref.md)

