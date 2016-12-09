---
title: Best practices for using strings
description: Best practices for using strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: b3cefaa4-0a3f-4a96-aba9-1de30fb07c29
---

# Best practices for using strings

.NET provides extensive support for developing localized and globalized applications, and makes it easy to apply the conventions of either the current culture or a specific culture when performing common operations such as sorting and displaying strings. But sorting or comparing strings is not always a culture-sensitive operation. For example, strings that are used internally by an application typically should be handled identically across all cultures. When culturally independent string data, such as XML tags, HTML tags, user names, file paths, and the names of system objects, are interpreted as if they were culture-sensitive, application code can be subject to subtle bugs, poor performance, and, in some cases, security issues.

This article examines the string sorting, comparison, and casing methods in .NET, presents recommendations for selecting an appropriate string-handling method, and provides additional information about string-handling methods. It also examines how formatted data, such as numeric data and date and time data, is handled for display and for storage. 

This article contains the following sections:

* [Recommendations for string usage](#recommendations-for-string-usage)

* [Specifying string comparisons explicitly](#specifying-string-comparisons-explicitly)

* [The details of string comparison](#the-details-of-string-comparison)

* [Choosing a StringComparison member for your method call](#choosing-a-stringcomparison-member-for-your-method-call)

* [Common string comparison methods](#common-string-comparison-methods)

* [Methods that perform string comparison indirectly](#methods-that-perform-string-comparison-indirectly)

* [Displaying and persisting formatted data](#displaying-and-persisting-formatted-data)

## Recommendations for string usage

When you develop with .NET, follow these simple recommendations when you use strings: 

* Use overloads that explicitly specify the string comparison rules for string operations. Typically, this involves calling a method overload that has a parameter of type [StringComparison](xref:System.StringComparison).

* Use [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) or [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) for comparisons as your safe default for culture-agnostic string matching.

* Use comparisons with [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) or [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) for better performance.

* Use string operations that are based on [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture) when you display output to the user.

* Use the non-linguistic [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) or [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) values instead of string operations based on [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) when the comparison is linguistically irrelevant (symbolic, for example).

* Use the [String.ToUpperInvariant](xref:System.String.ToUpperInvariant) method instead of the [String.ToLowerInvariant](xref:System.String.ToLowerInvariant) method when you normalize strings for comparison.

* Use an overload of the [String](xref:System.String) `Equals` method to test whether two strings are equal.

* Use an overload of the [String](xref:System.String) `Compare` and [String.CompareTo](xref:System.String.CompareTo(System.String)) methods to sort strings, not to check for equality.

* Use culture-sensitive formatting to display non-string data, such as numbers and dates, in a user interface. Use formatting with the invariant culture to persist non-string data in string form.

Avoid the following practices when you use strings:

* Do not use overloads that do not explicitly or implicitly specify the string comparison rules for string operations. 

* Do not use an overload of the [String](xref:System.String) `Compare` or [String.CompareTo](xref:System.String.CompareTo(System.String)) methods and test for a return value of zero to determine whether two strings are equal.

* Do not use culture-sensitive formatting to persist numeric data or date and time data in string form.

## Specifying string comparisons explicitly

Most of the string manipulation methods in .NET are overloaded. Typically, one or more overloads accept default settings, whereas others accept no defaults and instead define the precise way in which strings are to be compared or manipulated. Most of the methods that do not rely on defaults include a parameter of type [StringComparison](xref:System.StringComparison), which is an enumeration that explicitly specifies rules for string comparison by culture and case. The following table describes the [StringComparison](xref:System.StringComparison) enumeration members. 

StringComparison member | Description
----------------------- | -----------
[StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture) | Performs a case-sensitive comparison using the current culture.
[CurrentCultureIgnoreCase](xref:System.StringComparison.CurrentCultureIgnoreCase) | Performs a case-insensitive comparison using the current culture.
[StringComparison.Ordinal](xref:System.StringComparison.Ordinal) | Performs an ordinal comparison.
[StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) | Performs a case-insensitive ordinal comparison.

For example, the [String](xref:System.String) `IndexOf` method, which returns the index of a substring in a [String](xref:System.String) object that matches either a character or a string, has nine overloads:

* [IndexOf(Char)](xref:System.String.IndexOf(System.Char)), [IndexOf(Char, Int32)](xref:System.String.IndexOf(System.Char,System.Int32)), and [IndexOf(Char, Int32, Int32)](xref:System.String.IndexOf(System.Char,System.Int32,System.Int32)), which by default perform an ordinal (case-sensitive and culture-insensitive) search for a character in the string.

* [IndexOf(String)](xref:System.String.IndexOf(System.String)), [IndexOf(String, Int32)](xref:System.String.IndexOf(System.String,System.Int32)), and [IndexOf(String, Int32, Int32)](xref:System.String.IndexOf(System.String,System.Int32,System.Int32)), which by default perform a case-sensitive and culture-sensitive search for a substring in the string.

* [IndexOf(String, StringComparison)](xref:System.String.IndexOf(System.String,System.StringComparison)), [IndexOf(String, Int32, StringComparison)](xref:System.String.IndexOf(System.String,System.Int32,System.StringComparison)), and [IndexOf(String, Int32, Int32, StringComparison)](xref:System.String.IndexOf(System.String,System.Int32,System.Int32,System.StringComparison)), which include a parameter of type StringComparison that allows the form of the comparison to be specified.

We recommend that you select an overload that does not use default values, for the following reasons:

* Some overloads with default parameters (those that search for a [Char](xref:System.Char) in the string instance) perform an ordinal comparison, whereas others (those that search for a string in the string instance) are culture-sensitive. It is difficult to remember which method uses which default value, and easy to confuse the overloads.

* The intent of the code that relies on default values for method calls is not clear. In the following example, which relies on defaults, it is difficult to know whether the developer actually intended an ordinal or a linguistic comparison of two strings, or whether a case difference between `protocol` and "http" might cause the test for equality to return `false`.

```csharp
string protocol = GetProtocol(url);       
if (String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase)) {
   // ...Code to handle HTTP protocol.
}
else {
   throw new InvalidOperationException();
}
```

```vb
Dim protocol As String = GetProtocol(url)       
If String.Equals(protocol, "http") Then
  ' ...Code to handle HTTP protocol.
Else
   Throw New InvalidOperationException()
End If
```

In general, we recommend that you call a method that does not rely on defaults, because it makes the intent of the code unambiguous. This, in turn, makes the code more readable and easier to debug and maintain. The following example addresses the questions raised about the previous example. It makes it clear that ordinal comparison is used and that differences in case are ignored. 

```csharp
string protocol = GetProtocol(url);       
if (String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase)) {
   // ...Code to handle HTTP protocol.
}
else {
   throw new InvalidOperationException();
}
```

```vb
Dim protocol As String = GetProtocol(url)       
If String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase) Then
   ' ...Code to handle HTTP protocol.
Else
   Throw New InvalidOperationException()
End If
```

## The details of string comparison

String comparison is the heart of many string-related operations, particularly sorting and testing for equality. Strings sort in a determined order: If "my" appears before "string" in a sorted list of strings, "my" must compare less than or equal to "string". Additionally, comparison implicitly defines equality. The comparison operation returns zero for strings it deems equal. A good interpretation is that neither string is less than the other. Most meaningful operations involving strings include one or both of these procedures: comparing with another string, and executing a well-defined sort operation.

However, evaluating two strings for equality or sort order does not yield a single, correct result; the outcome depends on the criteria used to compare the strings. In particular, string comparisons that are ordinal or that are based on the casing and sorting conventions of the current culture or the invariant culture (a locale-agnostic culture based on the English language) may produce different results.

### String comparisons that use the current culture

One criterion involves using the conventions of the current culture when comparing strings. Comparisons that are based on the current culture use the thread's current culture or locale. You should always use comparisons that are based on the current culture when data is linguistically relevant, and when it reflects culture-sensitive user interaction. 

However, comparison and casing behavior in .NET changes when the culture changes. This happens when an application executes on a computer that has a different culture than the computer on which the application was developed, or when the executing thread changes its culture. This behavior is intentional, but it remains non-obvious to many developers. The following example illustrates differences in sort order between the U.S. English ("en-US") and Swedish ("sv-SE") cultures. Note that the words "ångström", "Windows", and "Visual Studio" appear in different positions in the sorted string arrays.

```csharp
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string[] values= { "able", "ångström", "apple", "Æble", 
                         "Windows", "Visual Studio" };
      Array.Sort(values);
      DisplayArray(values);

      // Change culture to Swedish (Sweden).
      string originalCulture = CultureInfo.CurrentCulture.Name;
      Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
      Array.Sort(values);
      DisplayArray(values);

      // Restore the original culture.
      Thread.CurrentThread.CurrentCulture = new CultureInfo(originalCulture);
    }

    private static void DisplayArray(string[] values)
    {
      Console.WriteLine("Sorting using the {0} culture:",  
                        CultureInfo.CurrentCulture.Name);
      foreach (string value in values)
         Console.WriteLine("   {0}", value);

      Console.WriteLine();
    }
}
// The example displays the following output:
//       Sorting using the en-US culture:
//          able
//          Æble
//          ångström
//          apple
//          Visual Studio
//          Windows
//       
//       Sorting using the sv-SE culture:
//          able
//          Æble
//          apple
//          Windows
//          Visual Studio
//          ångström
```

```vb
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim values() As String = { "able", "ångström", "apple", _
                                 "Æble", "Windows", "Visual Studio" }
      Array.Sort(values)
      DisplayArray(values)

      ' Change culture to Swedish (Sweden).
      Dim originalCulture As String = CultureInfo.CurrentCulture.Name
      Thread.CurrentThread.CurrentCulture = New CultureInfo("sv-SE")
      Array.Sort(values)
      DisplayArray(values)

      ' Restore the original culture.
      Thread.CurrentThread.CurrentCulture = New CultureInfo(originalCulture)
    End Sub

    Private Sub DisplayArray(values() As String)
      Console.WRiteLine("Sorting using the {0} culture:", _ 
                        CultureInfo.CurrentCulture.Name)
      For Each value As String In values
         Console.WriteLine("   {0}", value)
      Next
      Console.WriteLine()   
    End Sub
End Module
' The example displays the following output:
'       Sorting using the en-US culture:
'          able
'          Æble
'          ångström
'          apple
'          Visual Studio
'          Windows
'       
'       Sorting using the sv-SE culture:
'          able
'          Æble
'          apple
'          Windows
'          Visual Studio
'          ångström
```

Case-insensitive comparisons that use the current culture are the same as culture-sensitive comparisons, except that they ignore case as dictated by the thread's current culture. This behavior may manifest itself in sort orders as well. 

Comparisons that use current culture semantics are the default for the following methods:

* [String](xref:System.String) `Compare` overloads that do not include a [StringComparison](xref:System.StringComparison) parameter.

* [String.CompareTo](xref:System.String.CompareTo(System.String)) overloads.

* The default [String.StartsWith(String)](xref:System.String.StartsWith(System.String)) method. 

* The default [String.EndsWith(String)](xref:System.String.EndsWith(System.String)) method.

* [String](xref:System.String) `IndexOf` overloads that accept a [String](xref:System.String) as a search parameter and that do not have a [StringComparison](xref:System.StringComparison) parameter.

* [String](xref:System.String) `LastIndexOf` overloads that accept a [String](xref:System.String) as a search parameter and that do not have a [StringComparison](xref:System.StringComparison) parameter.

In any case, we recommend that you call an overload that has a [StringComparison](xref:System.StringComparison) parameter to make the intent of the method call clear. 

Subtle and not so subtle bugs can emerge when non-linguistic string data is interpreted linguistically, or when string data from a particular culture is interpreted using the conventions of another culture. The canonical example is the Turkish-I problem.

For nearly all Latin alphabets, including U.S. English, the character "i" (\u0069) is the lowercase version of the character "I" (\u0049). This casing rule quickly becomes the default for someone programming in such a culture. However, the Turkish ("tr-TR") alphabet includes an "I with a dot" character "İ" (\u0130), which is the capital version of "i". Turkish also includes a lowercase "i without a dot" character, "ı" (\u0131), which capitalizes to "I". This behavior occurs in the Azerbaijani ("az") culture as well.

Therefore, assumptions made about capitalizing "i" or lowercasing "I" are not valid among all cultures. If you use the default overloads for string comparison routines, they will be subject to variance between cultures. If the data to be compared is non-linguistic, using the default overloads can produce undesirable results, as the following attempt to perform a case-insensitive comparison of the strings "file" and "FILE" illustrates.

```csharp
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string fileUrl = "file";
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine("Culture = {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      Console.WriteLine("(file == FILE) = {0}", 
                       fileUrl.StartsWith("FILE", true, null));
      Console.WriteLine();

      Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
      Console.WriteLine("Culture = {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      Console.WriteLine("(file == FILE) = {0}", 
                        fileUrl.StartsWith("FILE", true, null));
   }
}
// The example displays the following output:
//       Culture = English (United States)
//       (file == FILE) = True
//       
//       Culture = Turkish (Turkey)
//       (file == FILE) = False
```

```vb
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim fileUrl = "file"
      Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
      Console.WriteLine("Culture = {0}", _
                        Thread.CurrentThread.CurrentCulture.DisplayName)
      Console.WriteLine("(file == FILE) = {0}", _ 
                       fileUrl.StartsWith("FILE", True, Nothing))
      Console.WriteLine()

      Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")
      Console.WriteLine("Culture = {0}", _
                        Thread.CurrentThread.CurrentCulture.DisplayName)
      Console.WriteLine("(file == FILE) = {0}", _ 
                        fileUrl.StartsWith("FILE", True, Nothing))
   End Sub
End Module
' The example displays the following output:
'       Culture = English (United States)
'       (file == FILE) = True
'       
'       Culture = Turkish (Turkey)
'       (file == FILE) = False
```

This comparison could cause significant problems if the culture is inadvertently used in security-sensitive settings, as in the following example. A method call such as `IsFileURI("file:")` returns `true` if the current culture is U.S. English, but `false` if the current culture is Turkish. Thus, on Turkish systems, someone could circumvent security measures that block access to case-insensitive URIs that begin with "FILE:".

```csharp
public static bool IsFileURI(String path) 
{
   return path.StartsWith("FILE:", true, null);
}
```

```vb
Public Shared Function IsFileURI(path As String) As Boolean 
   Return path.StartsWith("FILE:", True, Nothing)
End Function
```

In this case, because "file:" is meant to be interpreted as a non-linguistic, culture-insensitive identifier, the code should instead be written as shown in the following example.

```csharp
public static bool IsFileURI(string path) 
{
   return path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase);
}
```

```vb
Public Shared Function IsFileURI(path As String) As Boolean 
    Return path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase)
End Function
```

## Ordinal String Operations

Specifying the [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) or [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) value in a method call signifies a non-linguistic comparison in which the features of natural languages are ignored. Methods that are invoked with these [StringComparison](xref:System.StringComparison) values base string operation decisions on simple byte comparisons instead of casing or equivalence tables that are parameterized by culture. In most cases, this approach best fits the intended interpretation of strings while making code faster and more reliable. 

Ordinal comparisons are string comparisons in which each byte of each string is compared without linguistic interpretation; for example, "windows" does not match "Windows". Use this comparison when the context dictates that strings should be matched exactly or demands conservative matching policy. Additionally, ordinal comparison is the fastest comparison operation because it applies no linguistic rules when determining a result.

Strings in .NET can contain embedded null characters. One of the clearest differences between ordinal and culture-sensitive comparison (including comparisons that use the invariant culture) concerns the handling of embedded null characters in a string. These characters are ignored when you use the [String](xref:System.String) `Compare` and [String](xref:System.String) `Equals` methods to perform culture-sensitive comparisons (including comparisons that use the invariant culture). As a result, in culture-sensitive comparisons, strings that contain embedded null characters can be considered equal to strings that do not. 

> [!IMPORTANT]
> Although string comparison methods disregard embedded null characters, string search methods such as [String.Contains](xref:System.String.Contains(System.String)), [String.EndsWith](xref:System.String.EndsWith(System.String)), [String.IndexOf](xref:System.String.IndexOf(System.Char)), [String.LastIndexOf](xref:System.String.LastIndexOf(System.String)), and [String.StartsWith](xref:System.String.StartsWith(System.String)) do not. 

The following example performs a culture-sensitive comparison of the string "Aa" with a similar string that contains several embedded null characters between "A" and "a", and shows how the two strings are considered equal. 

```csharp
using System;

public class Example
{
   public static void Main()
   {
      string str1 = "Aa";
      string str2 = "A" + new String('\u0000', 3) + "a";
      Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):", 
                        str1, ShowBytes(str1), str2, ShowBytes(str2));
      Console.WriteLine("   With String.Compare:");
      Console.WriteLine("      Current Culture: {0}", 
                        String.Compare(str1, str2, StringComparison.CurrentCulture));
      Console.WriteLine("      Invariant Culture: {0}", 
                        String.Compare(str1, str2, StringComparison.InvariantCulture));

      Console.WriteLine("   With String.Equals:");
      Console.WriteLine("      Current Culture: {0}", 
                        String.Equals(str1, str2, StringComparison.CurrentCulture));
      Console.WriteLine("      Invariant Culture: {0}", 
                        String.Equals(str1, str2, StringComparison.InvariantCulture));
   }

   private static string ShowBytes(string str)
   {
      string hexString = String.Empty;
      for (int ctr = 0; ctr < str.Length; ctr++)
      {
         string result = String.Empty;
         result = Convert.ToInt32(str[ctr]).ToString("X4");
         result = " " + result.Substring(0,2) + " " + result.Substring(2, 2);
         hexString += result;
      }
      return hexString.Trim();
   }
}
// The example displays the following output:
//    Comparing 'Aa' (00 41 00 61) and 'A   a' (00 41 00 00 00 00 00 00 00 61):
//       With String.Compare:
//          Current Culture: 0
//          Invariant Culture: 0
//       With String.Equals:
//          Current Culture: True
//          Invariant Culture: True
```

```vb
Module Example
   Public Sub Main()
      Dim str1 As String = "Aa"
      Dim str2 As String = "A" + New String(Convert.ToChar(0), 3) + "a"
      Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):", _
                        str1, ShowBytes(str1), str2, ShowBytes(str2))
      Console.WriteLine("   With String.Compare:")
      Console.WriteLine("      Current Culture: {0}", _
                        String.Compare(str1, str2, StringComparison.CurrentCulture))
      Console.WriteLine("      Invariant Culture: {0}", _
                        String.Compare(str1, str2, StringComparison.InvariantCulture))

      Console.WriteLine("   With String.Equals:")
      Console.WriteLine("      Current Culture: {0}", _
                        String.Equals(str1, str2, StringComparison.CurrentCulture))
      Console.WriteLine("      Invariant Culture: {0}", _
                        String.Equals(str1, str2, StringComparison.InvariantCulture))
   End Sub

   Private Function ShowBytes(str As String) As String
      Dim hexString As String = String.Empty
      For ctr As Integer = 0 To str.Length - 1
         Dim result As String = String.Empty
         result = Convert.ToInt32(str.Chars(ctr)).ToString("X4")
         result = " " + result.Substring(0,2) + " " + result.Substring(2, 2)
         hexString += result
      Next
      Return hexString.Trim()
   End Function
End Module
```

However, the strings are not considered equal when you use ordinal comparison, as the following example shows.

```csharp
Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):", 
                  str1, ShowBytes(str1), str2, ShowBytes(str2));
Console.WriteLine("   With String.Compare:");
Console.WriteLine("      Ordinal: {0}", 
                  String.Compare(str1, str2, StringComparison.Ordinal));

Console.WriteLine("   With String.Equals:");
Console.WriteLine("      Ordinal: {0}", 
                  String.Equals(str1, str2, StringComparison.Ordinal));
// The example displays the following output:
//    Comparing 'Aa' (00 41 00 61) and 'A   a' (00 41 00 00 00 00 00 00 00 61):
//       With String.Compare:
//          Ordinal: 97
//       With String.Equals:
//          Ordinal: False
```

```vb
Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):", _
                  str1, ShowBytes(str1), str2, ShowBytes(str2))
Console.WriteLine("   With String.Compare:")
Console.WriteLine("      Ordinal: {0}", _
                  String.Compare(str1, str2, StringComparison.Ordinal))

Console.WriteLine("   With String.Equals:")
Console.WriteLine("      Ordinal: {0}", _
                  String.Equals(str1, str2, StringComparison.Ordinal))
' The example displays the following output:
'    Comparing 'Aa' (00 41 00 61) and 'A   a' (00 41 00 00 00 00 00 00 00 61):
'       With String.Compare:
'          Ordinal: 97
'       With String.Equals:
'          Ordinal: False
```

Case-insensitive ordinal comparisons are the next most conservative approach. These comparisons ignore most casing; for example, "windows" matches "Windows". When dealing with ASCII characters, this policy is equivalent to [StringComparison.Ordinal](xref:System.StringComparison.Ordinal), except that it ignores the usual ASCII casing. Therefore, any character in \[A, Z\] (\u0041-\u005A) matches the corresponding character in \[a,z\] (\u0061-\007A). Casing outside the ASCII range uses the invariant culture's tables. Therefore, the following comparison:

```csharp
String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase);
```

```vb
String.Compare(strA, strB, StringComparison.OrdinalIgnoreCase)
```

is equivalent to (but faster than) this comparison: 

```csharp
String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), 
               StringComparison.Ordinal);
```

```vb
String.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), 
               StringComparison.Ordinal)
```

These comparisons are still very fast.

Both [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) and [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) use the binary values directly, and are best suited for matching. When you are not sure about your comparison settings, use one of these two values. However, because they perform a byte-by-byte comparison, they do not sort by a linguistic sort order (like an English dictionary) but by a binary sort order. The results may look odd in most contexts if displayed to users.

Ordinal semantics are the default for [String](xref:System.String) `Equals` overloads that do not include a [StringComparison](xref:System.StringComparison) argument (including the equality operator). In any case, we recommend that you call an overload that has a [StringComparison](xref:System.StringComparison) parameter.

### String operations that use the invariant culture

Comparisons with the invariant culture use the [CompareInfo](xref:System.Globalization.CompareInfo) property returned by the static [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) property. This behavior is the same on all systems; it translates any characters outside its range into what it believes are equivalent invariant characters. This policy can be useful for maintaining one set of string behavior across cultures, but it often provides unexpected results.

Case-insensitive comparisons with the invariant culture use the static [CompareInfo](xref:System.Globalization.CompareInfo) property returned by the static [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) property for comparison information as well. Any case differences among these translated characters are ignored.

The [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) object makes a [String](xref:System.String) `Compare` method interpret certain sets of characters as equivalent. For example, the following equivalence is valid under the invariant culture:

InvariantCulture: a + ̊ = å

The latin small lette A character "a" (\u0061), when it is next to the combining ring above character "+ " ̊" (\u030a), is interpreted as the latin small letter A with ring above character "å" (\u00e5). As the following example shows, this behavior differs from ordinal comparison.

```csharp
string separated = "\u0061\u030a";
string combined = "\u00e5";

Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}",
                  separated, combined, 
                  String.Compare(separated, combined, 
                                 StringComparison.InvariantCulture) == 0);

Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}",
                  separated, combined,
                  String.Compare(separated, combined, 
                                 StringComparison.Ordinal) == 0);
// The example displays the following output:
//    Equal sort weight of a° and å using InvariantCulture: True
//    Equal sort weight of a° and å using Ordinal: False 
```

```vb
Dim separated As String = ChrW(&h61) + ChrW(&h30a)
Dim combined As String = ChrW(&he5)

Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}", _
                  separated, combined, _
                  String.Compare(separated, combined, _ 
                                 StringComparison.InvariantCulture) = 0)

Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}", _
                  separated, combined, _
                  String.Compare(separated, combined, _
                                 StringComparison.Ordinal) = 0)
' The example displays the following output:
'    Equal sort weight of a° and å using InvariantCulture: True
'    Equal sort weight of a° and å using Ordinal: False
```

When interpreting file names, cookies, or anything else where a combination such as "å" can appear, ordinal comparisons still offer the most transparent and fitting behavior.

On balance, the invariant culture has very few properties that make it useful for comparison. It does comparison in a linguistically relevant manner, which prevents it from guaranteeing full symbolic equivalence, but it is not the choice for display in any culture. For example, if a large data file that contains a list of sorted identifiers for display accompanies an application, adding to this list would require an insertion with invariant-style sorting.

## Choosing a StringComparison member for your method call

The following table outlines the mapping from semantic string context to a [StringComparison](xref:System.StringComparison) enumeration member.

Data | Behavior | Corresponding System.StringComparison value
---- | -------- | -------------------------------------------
Case-sensitive internal identifiers, case-sensitive identifiers in standards such as XML and HTTP, or case-sensitive security-related settings. | A non-linguistic identifier, where bytes match exactly. | [StringComparison.Ordinal](xref:System.StringComparison.Ordinal)
Case-insensitive internal identifiers, case-insensitive identifiers in standards such as XML and HTTP, file paths, registry keys and values, environment variables, resource identifiers (for example, handle names), or case-insensitive security-related settings. | A non-linguistic identifier, where case is irrelevant. | [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase)
Data displayed to the user or most user input. | Data that requires local linguistic customs. | [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture) or [CurrentCultureIgnoreCase](xref:System.StringComparison.CurrentCultureIgnoreCase)

## Common string comparison methods

The following sections describe the methods that are most commonly used for string comparison.

### String.Compare

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

As the operation most central to string interpretation, all instances of these method calls should be examined to determine whether strings should be interpreted according to the current culture, or dissociated from the culture (symbolically). Typically, it is the latter, and a [StringComparison.Ordinal](xref:System.StringComparison.Ordinal) comparison should be used instead.

The [System.Globalization.CompareInfo](xref:System.Globalization.CompareInfo) class, which is returned by the [CultureInfo.CompareInfo](xref:System.Globalization.CultureInfo.CompareInfo) property, also includes a [Compare](xref:System.Globalization.CompareInfo.Compare(System.String,System.Int32,System.String,System.Int32,System.Globalization.CompareOptions)) method that provides a large number of matching options (ordinal, ignoring white space, ignoring kana type, and so on) by means of the [CompareOptions](xref:System.Globalization.CompareOptions) flag enumeration. 

### String.CompareTo

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

This method does not currently offer an overload that specifies a [StringComparison](xref:System.StringComparison) type. It is usually possible to convert this method to the recommended [String.Compare(String, String, StringComparison)](xref:System.String.Compare(System.String,System.String,System.StringComparison)) form.

Types that implement the [IComparable](xref:System.IComparable) and [IComparable&lt;T&gt;](xref:System.IComparable%601) interfaces implement this method. Because it does not offer the option of a [StringComparison](xref:System.StringComparison) parameter, implementing types often let the user specify a [StringComparer](xref:System.StringComparer) in their constructor. The following example defines a `FileName` class whose class constructor includes a [StringComparer](xref:System.StringComparer) parameter. This [StringComparer](xref:System.StringComparer) object is then used in the `FileName.CompareTo` method.

```csharp
using System;

public class FileName : IComparable
{
   string fname;
   StringComparer comparer; 

   public FileName(string name, StringComparer comparer)
   {
      if (String.IsNullOrEmpty(name))
         throw new ArgumentNullException("name");

      this.fname = name;

      if (comparer != null)
         this.comparer = comparer;
      else
         this.comparer = StringComparer.OrdinalIgnoreCase;
   }

   public string Name
   {
      get { return fname; }
   }

   public int CompareTo(object obj)
   {
      if (obj == null) return 1;

      if (! (obj is FileName))
         return comparer.Compare(this.fname, obj.ToString());
      else
         return comparer.Compare(this.fname, ((FileName) obj).Name);
   }
}
```

```vb
Public Class FileName : Implements IComparable
   Dim fname As String
   Dim comparer As StringComparer 

   Public Sub New(name As String, comparer As StringComparer)
      If String.IsNullOrEmpty(name) Then
         Throw New ArgumentNullException("name")
      End If

      Me.fname = name

      If comparer IsNot Nothing Then
         Me.comparer = comparer
      Else
         Me.comparer = StringComparer.OrdinalIgnoreCase
      End If      
   End Sub

   Public ReadOnly Property Name As String
      Get
         Return fname
      End Get   
   End Property

   Public Function CompareTo(obj As Object) As Integer _
          Implements IComparable.CompareTo
      If obj Is Nothing Then Return 1

      If Not TypeOf obj Is FileName Then
         obj = obj.ToString()
      Else
         obj = CType(obj, FileName).Name
      End If         
      Return comparer.Compare(Me.fname, obj)
   End Function
End Class
```

### String.Equals

Default interpretation: [StringComparison.Ordinal](xref:System.StringComparison.Ordinal).

The [String](xref:System.String) class lets you test for equality by calling either the static or instance `Equals` method overloads, or by using the static equality operator. The overloads and operator use ordinal comparison by default. However, we still recommend that you call an overload that explicitly specifies the [StringComparison](xref:System.StringComparison) type even if you want to perform an ordinal comparison; this makes it easier to search code for a certain string interpretation. 

### String.ToUpper and String.ToLower

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

You should be careful when you use these methods, because forcing a string to a uppercase or lowercase is often used as a small normalization for comparing strings regardless of case. If so, consider using a case-insensitive comparison. 

The [String.ToUpperInvariant](xref:System.String.ToUpperInvariant) and [String.ToLowerInvariant](xref:System.String.ToLowerInvariant) methods are also available. [ToUpperInvariant](xref:System.String.ToUpperInvariant) is the standard way to normalize case. Comparisons made using [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) are behaviorally the composition of two calls: calling [ToUpperInvariant](xref:System.String.ToUpperInvariant) on both string arguments, and doing a comparison using [StringComparison.Ordinal](xref:System.StringComparison.Ordinal).

Overloads are also available for converting to uppercase and lowercase in a specific culture, by passing a [CultureInfo](xref:System.Globalization.CultureInfo) object that represents that culture to the method.

### Char.ToUpper and Char.ToLower

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

These methods work similarly to the [String.ToUpper](xref:System.String.ToUpper) and [String.ToLower](xref:System.String.ToLower) methods described in the previous section.

### String.StartsWith and String.EndsWith

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

By default, both of these methods perform a culture-sensitive comparison.

### String.IndexOf and String.LastIndexOf

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

There is a lack of consistency in how the default overloads of these methods perform comparisons. All [String](xref:System.String) `IndexOf` and [String](xref:System.String) `LastIndexOf` methods that include a [Char](xref:System.Char) parameter perform an ordinal comparison, but the default [String](xref:System.String) `IndexOf` and [String`](xref:System.String) `LastIndexOf` methods that include a [String](xref:System.String) parameter perform a culture-sensitive comparison. 

If you call ` `IndexOf` or `LastIndexOf` method and pass it a string to locate in the current instance, we recommend that you call an overload that explicitly specifies the [StringComparison](xref:System.StringComparison) type. The overloads that include a [Char](xref:System.Char) argument do not allow you to specify a [StringComparison](xref:System.StringComparison) type.

## Methods that perform string comparison indirectly

Some non-string methods that have string comparison as a central operation use the [StringComparer](xref:System.StringComparer) type. The [StringComparer](xref:System.StringComparer) class includes four static properties that return [StringComparer](xref:System.StringComparer) instances whose `Compare` methods perform the following types of string comparisons:

* Culture-sensitive string comparisons using the current culture. This [StringComparer](xref:System.StringComparer) object is returned by the [StringComparer.CurrentCulture](xref:System.StringComparer.CurrentCulture) property.

* Case-insensitive comparisons using the current culture. This [StringComparer](xref:System.StringComparer) object is returned by the [StringComparer.CurrentCultureIgnoreCase](xref:System.StringComparer.CurrentCultureIgnoreCase) property.

* Ordinal comparison. This [StringComparer](xref:System.StringComparer) object is returned by the [StringComparer.Ordinal](xref:System.StringComparer.Ordinal) property. 

* Case-insensitive ordinal comparison. This [StringComparer](xref:System.StringComparer) object is returned by the [StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase) property.

### Array.Sort and Array.BinarySearch

Default interpretation: [StringComparison.CurrentCulture](xref:System.StringComparison.CurrentCulture).

When you store any data in a collection, or read persisted data from a file or database into a collection, switching the current culture can invalidate the invariants in the collection. The [Array.BinarySearch](xref:System.Array.BinarySearch(System.Array,System.Object)) method assumes that the elements in the array to be searched are already sorted. To sort any string element in the array, the [Array.Sort](xref:System.Array.Sort(System.Array)) method calls the [String] `Compare` method to order individual elements. Using a culture-sensitive comparer can be dangerous if the culture changes between the time that the array is sorted and its contents are searched. For example, in the following code, storage and retrieval operate on the comparer that is provided implicitly by the `Thread.CurrentThread.CurrentCulture` property. If the culture can change between the calls to `StoreNames` and `DoesNameExist`, and especially if the array contents are persisted somewhere between the two method calls, the binary search may fail. 

```csharp
// Incorrect.
string []storedNames;

public void StoreNames(string [] names)
{
   int index = 0;
   storedNames = new string[names.Length];

   foreach (string name in names)
   {
      this.storedNames[index++] = name;
   }

   Array.Sort(names); // Line A.
}

public bool DoesNameExist(string name)
{
   return (Array.BinarySearch(this.storedNames, name) >= 0);  // Line B.
}
```

```vb
' Incorrect.
Dim storedNames() As String

Public Sub StoreNames(names() As String)
   Dim index As Integer = 0
   ReDim storedNames(names.Length - 1)

   For Each name As String In names
      Me.storedNames(index) = name
      index+= 1
   Next

   Array.Sort(names)          ' Line A.
End Sub

Public Function DoesNameExist(name As String) As Boolean
   Return Array.BinarySearch(Me.storedNames, name) >= 0      ' Line B.
End Function
```

A recommended variation appears in the following example, which uses the same ordinal (culture-insensitive) comparison method both to sort and to search the array. The change code is reflected in the lines labeled `Line A` and `Line B` in the two examples.

```csharp
// Correct.
string []storedNames;

public void StoreNames(string [] names)
{
   int index = 0;
   storedNames = new string[names.Length];

   foreach (string name in names)
   {
      this.storedNames[index++] = name;
   }

   Array.Sort(names, StringComparer.Ordinal);  // Line A.
}

public bool DoesNameExist(string name)
{
   return (Array.BinarySearch(this.storedNames, name, StringComparer.Ordinal) >= 0);  // Line B.
}
```

```vb
' Correct.
Dim storedNames() As String

Public Sub StoreNames(names() As String)
   Dim index As Integer = 0
   ReDim storedNames(names.Length - 1)

   For Each name As String In names
      Me.storedNames(index) = name
      index+= 1
   Next

   Array.Sort(names, StringComparer.Ordinal)           ' Line A.
End Sub

Public Function DoesNameExist(name As String) As Boolean
   Return Array.BinarySearch(Me.storedNames, name, StringComparer.Ordinal) >= 0      ' Line B.
End Function
```

If this data is persisted and moved across cultures, and sorting is used to present this data to the user, you might consider using `StringComparison.InvariantCulture`, which operates linguistically for better user output but is unaffected by changes in culture. The following example modifies the two previous examples to use the invariant culture for sorting and searching the array.

```csharp
// Correct.
string []storedNames;

public void StoreNames(string [] names)
{
   int index = 0;
   storedNames = new string[names.Length];

   foreach (string name in names)
   {
      this.storedNames[index++] = name;
   }

   Array.Sort(names, StringComparer.InvariantCulture);  // Line A.
}

public bool DoesNameExist(string name)
{
   return (Array.BinarySearch(this.storedNames, name, StringComparer.InvariantCulture) >= 0);  // Line B.
}
```

```vb
' Correct.
Dim storedNames() As String

Public Sub StoreNames(names() As String)
   Dim index As Integer = 0
   ReDim storedNames(names.Length - 1)

   For Each name As String In names
      Me.storedNames(index) = name
      index+= 1
   Next

   Array.Sort(names, StringComparer.InvariantCulture)           ' Line A.
End Sub

Public Function DoesNameExist(name As String) As Boolean
   Return Array.BinarySearch(Me.storedNames, name, StringComparer.InvariantCulture) >= 0      ' Line B.
End Function
```

### Collections Example: Hashtable Constructor

Hashing strings provides a second example of an operation that is affected by the way in which strings are compared. 

The following example instantiates a [Hashtable](xref:System.Collections.Hashtable) object by passing it the [StringComparer](xref:System.StringComparer) object that is returned by the [StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase) property. Because a class [StringComparer](xref:System.StringComparer) that is derived from [StringComparer](xref:System.StringComparer) implements the [IEqualityComparer](xref:System.Collections.IEqualityComparer) interface, its [GetHashCode](xref:System.Collections.IEqualityComparer) method is used to compute the hash code of strings in the hash table.

```csharp
const int initialTableCapacity = 100;
Hashtable h;

public void PopulateFileTable(string directory)
{
   h = new Hashtable(initialTableCapacity, 
                     StringComparer.OrdinalIgnoreCase);

   foreach (string file in Directory.GetFiles(directory))
         h.Add(file, File.GetCreationTime(file));
}

public void PrintCreationTime(string targetFile)
{
   Object dt = h[targetFile];
   if (dt != null)
   {
      Console.WriteLine("File {0} was created at time {1}.",
         targetFile, 
         (DateTime) dt);
   }
   else
   {
      Console.WriteLine("File {0} does not exist.", targetFile);
   }
}
```

```vb
Const initialTableCapacity As Integer = 100
Dim h As Hashtable

Public Sub PopulateFileTable(dir As String)
   h = New Hashtable(initialTableCapacity, _
                     StringComparer.OrdinalIgnoreCase)

   For Each filename As String In Directory.GetFiles(dir)
      h.Add(filename, File.GetCreationTime(filename))
   Next                        
End Sub

Public Sub PrintCreationTime(targetFile As String)
   Dim dt As Object = h(targetFile)
   If dt IsNot Nothing Then
      Console.WriteLine("File {0} was created at {1}.", _
         targetFile, _
         CDate(dt))
   Else
      Console.WriteLine("File {0} does not exist.", targetFile)
   End If
End Sub  
```

## Displaying and persisting formatted data

When you display non-string data such as numbers and dates and times to users, format them by using the user's cultural settings. By default, the [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)) method and the `ToString` methods of the numeric types and the date and time types use the current thread culture for formatting operations. To explicitly specify that the formatting method should use the current culture, you can call an overload of a formatting method that has a provider parameter, such as [String.Format(IFormatProvider, String, Object[])](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)) or [DateTime.ToString(IFormatProvider)](xref:System.DateTime.ToString(System.IFormatProvider)), and pass it the [CultureInfo.CurrentCulture](xref:System.Globalization.CultureInfo.CurrentCulture) property. 

You can persist non-string data either as binary data or as formatted data. If you choose to save it as formatted data, you should call a formatting method overload that includes a *provider* parameter and pass it the [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) property. The invariant culture provides a consistent format for formatted data that is independent of culture and machine. In contrast, persisting data that is formatted by using cultures other than the invariant culture has a number of limitations: 

* The data is likely to be unusable if it is retrieved on a system that has a different culture, or if the user of the current system changes the current culture and tries to retrieve the data. 

* The properties of a culture on a specific computer can differ from standard values. At any time, a user can customize culture-sensitive display settings. Because of this, formatted data that is saved on a system may not be readable after the user customizes cultural settings. The portability of formatted data across computers is likely to be even more limited. 

* International, regional, or national standards that govern the formatting of numbers or dates and times change over time, and these changes are incorporated into operating system updates. When formatting conventions change, data that was formatted by using the previous conventions may become unreadable. 

The following example illustrates the limited portability that results from using culture-sensitive formatting to persist data. The example saves an array of date and time values to a file. These are formatted by using the conventions of the English (United States) culture. After the application changes the current thread culture to French (Switzerland), it tries to read the saved values by using the formatting conventions of the current culture. The attempt to read two of the data items throws a [FormatException](xref:System.FormatException) exception, and the array of dates now contains two incorrect elements that are equal to [MinValue](xref:System.DateTime.MinValue). 

```csharp
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

public class Example
{
   private static string filename = @".\dates.dat";

   public static void Main()
   {
      DateTime[] dates = { new DateTime(1758, 5, 6, 21, 26, 0), 
                           new DateTime(1818, 5, 5, 7, 19, 0), 
                           new DateTime(1870, 4, 22, 23, 54, 0),  
                           new DateTime(1890, 9, 8, 6, 47, 0), 
                           new DateTime(1905, 2, 18, 15, 12, 0) }; 
      // Write the data to a file using the current culture.
      WriteData(dates);
      // Change the current culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-CH");
      // Read the data using the current culture.
      DateTime[] newDates = ReadData();
      foreach (var newDate in newDates)
         Console.WriteLine(newDate.ToString("g"));
   }

   private static void WriteData(DateTime[] dates) 
   {
      StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);    
      for (int ctr = 0; ctr < dates.Length; ctr++) {
         sw.Write("{0}", dates[ctr].ToString("g", CultureInfo.CurrentCulture));
         if (ctr < dates.Length - 1) sw.Write("|");   
      }      
      sw.Close();
   }

   private static DateTime[] ReadData() 
   {
      bool exceptionOccurred = false;

      // Read file contents as a single string, then split it.
      StreamReader sr = new StreamReader(filename, Encoding.UTF8);
      string output = sr.ReadToEnd();
      sr.Close();   

      string[] values = output.Split( new char[] { '|' } );
      DateTime[] newDates = new DateTime[values.Length]; 
      for (int ctr = 0; ctr < values.Length; ctr++) {
         try {
            newDates[ctr] = DateTime.Parse(values[ctr], CultureInfo.CurrentCulture);
         }
         catch (FormatException) {
            Console.WriteLine("Failed to parse {0}", values[ctr]);
            exceptionOccurred = true;
         }
      }      
      if (exceptionOccurred) Console.WriteLine();
      return newDates;
   }
}
// The example displays the following output:
//       Failed to parse 4/22/1870 11:54 PM
//       Failed to parse 2/18/1905 3:12 PM
//       
//       05.06.1758 21:26
//       05.05.1818 07:19
//       01.01.0001 00:00
//       09.08.1890 06:47
//       01.01.0001 00:00
//       01.01.0001 00:00
```

```vb
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading

Module Example
   Private filename As String = ".\dates.dat"

   Public Sub Main()
      Dim dates() As Date = { #5/6/1758 9:26PM#, #5/5/1818 7:19AM#, _ 
                              #4/22/1870 11:54PM#, #9/8/1890 6:47AM#, _ 
                              #2/18/1905 3:12PM# }
      ' Write the data to a file using the current culture.
      WriteData(dates)
      ' Change the current culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-CH")
      ' Read the data using the current culture.
      Dim newDates() As Date = ReadData()
      For Each newDate In newDates
         Console.WriteLine(newDate.ToString("g"))
      Next
   End Sub

   Private Sub WriteData(dates() As Date)
      Dim sw As New StreamWriter(filename, False, Encoding.Utf8)    
      For ctr As Integer = 0 To dates.Length - 1
         sw.Write("{0}", dates(ctr).ToString("g", CultureInfo.CurrentCulture))
         If ctr < dates.Length - 1 Then sw.Write("|")   
      Next      
      sw.Close()
   End Sub

   Private Function ReadData() As Date()
      Dim exceptionOccurred As Boolean = False

      ' Read file contents as a single string, then split it.
      Dim sr As New StreamReader(filename, Encoding.Utf8)
      Dim output As String = sr.ReadToEnd()
      sr.Close()   

      Dim values() As String = output.Split( {"|"c } )
      Dim newDates(values.Length - 1) As Date 
      For ctr As Integer = 0 To values.Length - 1
         Try
            newDates(ctr) = DateTime.Parse(values(ctr), CultureInfo.CurrentCulture)
         Catch e As FormatException
            Console.WriteLine("Failed to parse {0}", values(ctr))
            exceptionOccurred = True
         End Try
      Next      
      If exceptionOccurred Then Console.WriteLine()
      Return newDates
   End Function
End Module
' The example displays the following output:
'       Failed to parse 4/22/1870 11:54 PM
'       Failed to parse 2/18/1905 3:12 PM
'       
'       05.06.1758 21:26
'       05.05.1818 07:19
'       01.01.0001 00:00
'       09.08.1890 06:47
'       01.01.0001 00:00
'       01.01.0001 00:00
'
```

However, if you replace the [CultureInfo.CurrentCulture](xref:System.Globalization.CultureInfo.CurrentCulture) property with [CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) in the calls to [DateTime.ToString(String, IFormatProvider)](xref:System.DateTime.ToString(System.String,System.IFormatProvider)) and [DateTime.Parse(String, IFormatProvider)](xref:System.DateTime.Parse(System.String,System.IFormatProvider)), the persisted date and time data is successfully restored, as the following output shows.

```
// 06.05.1758 21:26
// 05.05.1818 07:19
// 22.04.1870 23:54
// 08.09.1890 06:47
// 18.02.1905 15:12
```

## See also

[Manipulating strings](manipulating-strings.md)
