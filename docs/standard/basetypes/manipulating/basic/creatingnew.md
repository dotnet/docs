---
title: Creating New Strings
description: Creating New Strings
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8e8ddb1b-218e-4007-ae6d-b2e7f91f155d
---

# Creating New Strings

.NET Core  allows strings to be created using simple assignment, and also overloads a class constructor to support string creation using a number of different parameters. .NET Core also provides several methods in the [System.String](https://docs.microsoft.com/dotnet/core/api/System.String) class that create new string objects by combining several strings, arrays of strings, or objects. 

## Creating Strings Using Assignment

The easiest way to create a new [String](https://docs.microsoft.com/dotnet/core/api/System.String) object is simply to assign a string literal to a [String](https://docs.microsoft.com/dotnet/core/api/System.String) object. 

## Creating Strings Using a Class Constructor

You can use overloads of the [String](https://docs.microsoft.com/dotnet/core/api/System.String) class constructor to create strings from character arrays. You can also create a new string by duplicating a particular character a specified number of times. 

## Methods that Return Strings

The following table lists several useful methods that return new string objects.

Method name | Use
----------- | ---
[String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_String_System_Object_) | Builds a formatted string from a set of input objects.
[String.Concat](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Concat_System_String_System_String_) | Builds strings from two or more strings.
[String.Join](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Join_System_String_System_String___) |Builds a new string by combining an array of strings.
[String.Insert](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Insert_System_Int32_System_String_) | Builds a new string by inserting a string into the specified index of an existing string.
[String.CopyTo](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_CopyTo_System_Int32_System_Char___System_Int32_System_Int32_) | Copies specified characters in a string into a specified position in an array of characters.

### Format

You can use the `String.Format` method to create formatted strings and concatenate strings representing multiple objects. This method automatically converts any passed object into a string. For example, if your application must display an [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) value and a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) value to the user, you can easily construct a string to represent these values using the `Format` method. 

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

In this example, [DateTime.Now](https://docs.microsoft.com/dotnet/core/api/System.DateTime#System_DateTime_Now) displays the current date and time in a manner specified by the culture associated with the current thread.

### Concat

The `String.Concat` method can be used to easily create a new string object from two or more existing objects. It provides a language-independent way to concatenate strings. This method accepts any class that derives from `System.Object`. The following example creates a string from two existing string objects and a separating character.

```csharp
string helloString1 = "Hello";
string helloString2 = "World!";
Console.WriteLine(String.Concat(helloString1, ' ', helloString2));
// The example displays the following output:
//      Hello World!
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

### Insert

The `String.Insert` method creates a new string by inserting a string into a specified position in another string. This method uses a zero-based index. The following example inserts a string into the fifth index position of `MyString` and creates a new string with this value.

```csharp
string sentence = "Once a time.";   
 Console.WriteLine(sentence.Insert(4, " upon"));
 // The example displays the following output:
 //      Once upon a time.
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


 




