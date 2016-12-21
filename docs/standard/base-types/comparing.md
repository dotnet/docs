---
title: Comparing strings
description: Comparing strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 920ee5e8-3d61-4941-b5af-fc50eaee427c
---

# Comparing strings

.NET provides several methods to compare the values of strings. The following table lists and describes the value-comparison methods.

Method name | Use
----------- | ---
[String.Compare](xref:System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)) | Compares the values of two strings. Returns an integer value.
[String.CompareOrdinal](xref:System.String.CompareOrdinal(System.String,System.Int32,System.String,System.Int32,System.Int32)) | Compares two strings without regard to local culture. Returns an integer value.
[String.CompareTo](xref:System.String.CompareTo(System.String)) | Compares the current string object to another string. Returns an integer value.
[String.StartsWith](xref:System.String.StartsWith(System.String)) | Determines whether a string begins with the string passed. Returns a Boolean value.
[String.EndsWith](xref:System.String.CompareTo(System.String)) | Determines whether a string ends with the string passed. Returns a Boolean value.
[String.Equals](xref:System.String.CompareTo(System.String)) | Determines whether two strings are the same. Returns a Boolean value.
[String.IndexOf](xref:System.String.IndexOf(System.Char)) | Returns the index position of a character or string, starting from the beginning of the string you are examining. Returns an integer value.
[String.LastIndexOf](xref:System.String.LastIndexOf(System.Char)) | Returns the index position of a character or string, starting from the end of the string you are examining. Returns an integer value.

## Compare

The static [String.Compare](xref:System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)) method provides a thorough way of comparing two strings. This method is culturally aware. You can use this function to compare two strings or substrings of two strings. Additionally, overloads are provided that regard or disregard case and cultural variance. The following table shows the three integer values that this method might return. 

Return value | Condition
------------ | ---------
A negative integer | The first string precedes the second string in the sort order, or the first string is `null`.
0 | The first string and the second string are equal, or both strings are `null`.
A positive integer, or 1 | The first string follows the second string in the sort order, or the second string is null.
 
> [!IMPORTANT]
> The [String.Compare](xref:System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)) method is primarily intended for use when ordering or sorting strings. You should not use the [String.Compare](xref:System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](xref:System.String.Equals(System.String,System.String,System.StringComparison)) method.

The following example uses the [String.Compare](xref:System.String.Compare(System.String,System.Int32,System.String,System.Int32,System.Int32)) method to determine the relative values of two strings.

```csharp
string string1 = "Hello World!";
Console.WriteLine(String.Compare(string1, "Hello World?"));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(String.Compare(string1, "Hello World?"))
```

This example displays `-1` to the console.

## CompareOrdinal

The [String.CompareOrdinal](xref:System.String.CompareOrdinal(System.String,System.Int32,System.String,System.Int32,System.Int32)) method compares two string objects without considering the local culture. The return values of this method are identical to the values returned by the `Compare` method in the previous table.

> [!IMPORTANT]
> The [String.CompareOrdinal](xref:System.String.CompareOrdinal(System.String,System.Int32,System.String,System.Int32,System.Int32)) method is primarily intended for use when ordering or sorting strings. You should not use the [String.CompareOrdinal](xref:System.String.CompareOrdinal(System.String,System.Int32,System.String,System.Int32,System.Int32)) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](xref:System.String.Equals(System.String,System.String,System.StringComparison)) method.

The following example uses the `CompareOrdinal` method to compare the values of two strings.

```csharp
string string1 = "Hello World!";
Console.WriteLine(String.CompareOrdinal(string1, "hello world!"));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(String.CompareOrdinal(string1, "hello world!"))
```

This example displays `-32` to the console.

## CompareTo

The [String.CompareTo](xref:System.String.CompareTo(System.String)) method compares the string that the current string object encapsulates to another string or object. The return values of this method are identical to the values returned by the `String.Compare` method in the previous table.

> [!IMPORTANT]
> The [String.CompareTo](xref:System.String.CompareTo(System.String)) method is primarily intended for use when ordering or sorting strings. You should not use the [String.CompareTo](xref:System.String.CompareTo(System.String)) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](xref:System.String.Equals(System.String,System.String,System.StringComparison)) method.

The following example uses the `String.CompareTo` method to compare the `string1` object to the `string2` object.

```csharp
string string1 = "Hello World";
string string2 = "Hello World!";
int MyInt = string1.CompareTo(string2);
Console.WriteLine( MyInt );
```

```vb
Dim string1 As String = "Hello World"
Dim string2 As String = "Hello World!"
Dim MyInt As Integer = string1.CompareTo(string2)
Console.WriteLine(MyInt)
```

This example displays `-1` to the console.

## Equals

The [String.Equals](xref:System.String.CompareTo(System.String)) method can easily determine if two strings are the same. This case-sensitive method returns a `true` or `false` Boolean value. It can be used from an existing class, as illustrated in the next example. The following example uses the `Equals` method to determine whether a string object contains the phrase "Hello World".

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.Equals("Hello World"));
```

```vb
Dim string1 As String = "Hello World"
Console.WriteLine(string1.Equals("Hello World"))
```

This example displays `true` to the console.

This method can also be used as a static method. The following example compares two string objects using a static method.

```csharp
string string1 = "Hello World";
string string2 = "Hello World";
Console.WriteLine(String.Equals(string1, string2));
```

```vb
Dim string1 As String = "Hello World"
Dim string2 As String = "Hello World"
Console.WriteLine(String.Equals(string1, string2))
```

This example displays `true` to the console.

## StartsWith and EndsWith

You can use the [String.StartsWith](xref:System.String.StartsWith(System.String)) method to determine whether a string object begins with the same characters that encompass another string. This case-sensitive method returns `true` if the current string object begins with the passed string and `false` if it does not. The following example uses this method to determine if a string object begins with "Hello".

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.StartsWith("Hello"));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(string1.StartsWith("Hello"))
```

This example displays `true` to the console.

The [String.EndsWith](xref:System.String.CompareTo(System.String)) method compares a passed string to the characters that exist at the end of the current string object. It also returns a Boolean value. The following example checks the end of a string using the `EndsWith` method.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.EndsWith("Hello"));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(string1.EndsWith("Hello"))
```

This example displays `false` to the console.

## IndexOf and LastIndexOf

You can use the [String.IndexOf](xref:System.String.IndexOf(System.Char)) method to determine the position of the first occurrence of a particular character within a string. This case-sensitive method starts counting from the beginning of a string and returns the position of a passed character using a zero-based index. If the character cannot be found, a value of –1 is returned.

The following example uses the `IndexOf` method to search for the first occurrence of the '`l`' character in a string.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.IndexOf('l'));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(string1.IndexOf("l"))
```

This example displays `2` to the console.

The [String.LastIndexOf](xref:System.String.LastIndexOf(System.Char)) method is similar to the `String.IndexOf` method except that it returns the position of the last occurrence of a particular character within a string. It is case-sensitive and uses a zero-based index. 

The following example uses the `LastIndexOf` method to search for the last occurrence of the '`l`' character in a string.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.LastIndexOf('l'));
```

```vb
Dim string1 As String = "Hello World!"
Console.WriteLine(string1.LastIndexOf("l"))
```

This example displays `9` to the console.

Both methods are useful when used in conjunction with the [String.Remove](xref:System.String.Remove(System.Int32)) method. You can use either the `IndexOf` or `LastIndexOf` methods to retrieve the position of a character, and then supply that position to the `Remove method` in order to remove a character or a word that begins with that character.

## See Also

[Basic string operations](basic-string-operations.md)












