---
title: Creating new strings
description: Creating new strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 639397c7-e694-43e0-845b-1681c62bd9fd
---

# Creating new strings

.NET  allows strings to be created using simple assignment, and also overloads a class constructor to support string creation using a number of different parameters. .NET also provides several methods in the [System.String](xref:System.String) class that create new string objects by combining several strings, arrays of strings, or objects. 

## Creating Strings Using Assignment

The easiest way to create a new [String](xref:System.String) object is simply to assign a string literal to a [String](xref:System.String) object. 

## Creating Strings Using a Class Constructor

You can use overloads of the [String](xref:System.String) class constructor to create strings from character arrays. You can also create a new string by duplicating a particular character a specified number of times. 

## Methods that Return Strings

The following table lists several useful methods that return new string objects.

Method name | Use
----------- | ---
[String.Format](xref:System.String.Format(System.String,System.Object)) | Builds a formatted string from a set of input objects.
[String.Concat](xref:System.String.Concat(System.String,System.String)) | Builds strings from two or more strings.
[String.Join](xref:System.String.Join(System.String,System.String[])) |Builds a new string by combining an array of strings.
[String.Insert](xref:System.String.Insert(System.Int32,System.String)) | Builds a new string by inserting a string into the specified index of an existing string.
[String.CopyTo](xref:System.String.CopyTo(System.Int32,System.Char[],System.Int32,System.Int32)) | Copies specified characters in a string into a specified position in an array of characters.

### Format

You can use the `String.Format` method to create formatted strings and concatenate strings representing multiple objects. This method automatically converts any passed object into a string. For example, if your application must display an [Int32](xref:System.Int32) value and a [DateTime](xref:System.DateTime) value to the user, you can easily construct a string to represent these values using the `Format` method. For information about formatting conventions used with this method, see the section on [composite formatting](composite-format.md).

The following example uses the `Format` method to create a string that uses an integer variable.

```csharp
int numberOfFleas = 12;
string miscInfo = String.Format("Your dog has {0} fleas. " +
                                "It is time to get a flea collar. " + 
                                "The current universal date is: {1:u}.", 
                                numberOfFleas, DateTime.Now);
Console.WriteLine(miscInfo);
// The example displays the following output:
//       Your dog has 12 fleas. It is time to get a flea collar. 
//       The current universal date is: 2008-03-28 13:31:40Z.
```

```vb
Dim numberOfFleas As Integer = 12
Dim miscInfo As String = String.Format("Your dog has {0} fleas. " & _
                                       "It is time to get a flea collar. " & _ 
                                       "The current universal date is: {1:u}.", _ 
                                       numberOfFleas, Date.Now)
Console.WriteLine(miscInfo)
' The example displays the following output:
'       Your dog has 12 fleas. It is time to get a flea collar. 
'       The current universal date is: 2008-03-28 13:31:40Z.
```

In this example, [DateTime.Now](xref:System.DateTime.Now) displays the current date and time in a manner specified by the culture associated with the current thread.

### Concat

The `String.Concat` method can be used to easily create a new string object from two or more existing objects. It provides a language-independent way to concatenate strings. This method accepts any class that derives from `System.Object`. The following example creates a string from two existing string objects and a separating character.

```csharp
string helloString1 = "Hello";
string helloString2 = "World!";
Console.WriteLine(String.Concat(helloString1, ' ', helloString2));
// The example displays the following output:
//      Hello World!
```

```vb
Dim helloString1 As String = "Hello"
Dim helloString2 As String = "World!"
Console.WriteLine(String.Concat(helloString1, " "c, helloString2))
' The example displays the following output:
'      Hello World!
```

### Join

The `String.Join` method creates a new string from an array of strings and a separator string. This method is useful if you want to concatenate multiple strings together, making a list perhaps separated by a comma.

The following example uses a space to bind a string array.

```csharp
string[] words = {"Hello", "and", "welcome", "to", "my" , "world!"};
Console.WriteLine(String.Join(" ", words));
// The example displays the following output:
//      Hello and welcome to my world!
```

```vb
Dim words() As String = {"Hello", "and", "welcome", "to", "my" , "world!"}
Console.WriteLine(String.Join(" ", words))
' The example displays the following output:
'      Hello and welcome to my world!
```

### Insert

The `String.Insert` method creates a new string by inserting a string into a specified position in another string. This method uses a zero-based index. The following example inserts a string into the fifth index position of `MyString` and creates a new string with this value.

```csharp
string sentence = "Once a time.";   
 Console.WriteLine(sentence.Insert(4, " upon"));
 // The example displays the following output:
 //      Once upon a time.
```

```vb
Dim sentence As String = "Once a time."   
 Console.WriteLine(sentence.Insert(4, " upon"))
 ' The example displays the 
```

### CopyTo

The `String.CopyTo` method copies portions of a string into an array of characters. You can specify both the beginning index of the string and the number of characters to be copied. This method takes the source index, an array of characters, the destination index, and the number of characters to copy. All indexes are zero-based.

The following example uses the `CopyTo` method to copy the characters of the word "Hello" from a string object to the first index position of an array of characters.

```csharp
string greeting = "Hello World!";
char[] charArray = {'W','h','e','r','e'};
Console.WriteLine("The original character array: {0}", new string(charArray));
greeting.CopyTo(0, charArray,0 ,5);
Console.WriteLine("The new character array: {0}", new string(charArray));
// The example displays the following output:
//       The original character array: Where
//       The new character array: Hello
```

```vb
Dim greeting As String = "Hello World!"
Dim charArray() As Char = {"W"c, "h"c, "e"c, "r"c, "e"c}
Console.WriteLine("The original character array: {0}", New String(charArray))
greeting.CopyTo(0, charArray,0 ,5)
Console.WriteLine("The new character array: {0}", New String(charArray))
' The example displays the following output:
'       The original character array: Where
'       The new character array: Hello
```

## See Also

[Basic string operations](basic-string-operations.md)

[Composite formatting](composite-format.md)

