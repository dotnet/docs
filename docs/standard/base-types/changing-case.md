---
title: Changing case
description: Changing case
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 646c5afd-8aec-4393-9c00-f68ad2580c68
---

# Changing case

If you write an application that accepts input from a user, you can never be sure what case he or she will use to enter the data. Often, you want strings to be cased consistently, particularly if you are displaying them in the user interface. The following table describes two case-changing methods.

Method name | Use
----------- | ---
[String.ToUpper](xref:System.String.ToUpper) | Converts all characters in a string to uppercase.
[String.ToLower](xref:System.String.ToLower) | Converts all characters in a string to lowercase.

> [!WARNING]  
> Note that the `String.ToUpper` and `String.ToLower` methods should not be used to convert strings in order to compare them or test them for equality. 

## Comparing strings of mixed case

To compare strings of mixed case to determine whether they are equal, their, call one of the overloads of the [String](xref:System) `Equals` method with a *comparisonType* parameter, and provide a value of either [StringComparison.CurrentCultureIgnoreCase](xref:System.StringComparison.CurrentCultureIgnoreCase) or [StringComparison.OrdinalIgnoreCase](xref:System.StringComparison.OrdinalIgnoreCase) for the *comparisonType* argument. 

For more information, see [Best Practices for Using Strings](best-practices.md). 

## ToUpper

The [String.ToUpper](xref:System.String.ToUpper) method changes all characters in a string to uppercase. The following example converts the string "Hello World!" from mixed case to uppercase.

```csharp
string properString = "Hello World!";
Console.WriteLine(properString.ToUpper());
// This example displays the following output:
//       HELLO WORLD!
```

```vb
Dim MyString As String = "Hello World!"
Console.WriteLine(MyString.ToUpper())
' This example displays the following output:
'       HELLO WORLD!
```

## ToLower

The [String.ToLower](xref:System.String.ToLower) method is similar to the previous method, but instead converts all the characters in a string to lowercase. The following example converts the string "Hello World!" to lowercase.

```csharp
string properString = "Hello World!";
Console.WriteLine(properString.ToLower());
// This example displays the following output:
//       hello world!
```

```vb
Dim MyString As String = "Hello World!"
Console.WriteLine(MyString.ToLower())
' This example displays the following output:
'       hello world!
```

## See Also

[Basic string operations](basic-string-operations.md)
