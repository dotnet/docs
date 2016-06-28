---
title: Changing Case
description: Changing Case
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: b4fbbe41-e16f-4767-ae19-fdc9bc0b6f10
---

# Changing Case

If you write an application that accepts input from a user, you can never be sure what case he or she will use to enter the data. Often, you want strings to be cased consistently, particularly if you are displaying them in the user interface. The following table describes two case-changing methods.

Method name | Use
----------- | ---
[String.ToUpper](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_ToUpper) | Converts all characters in a string to uppercase.
[String.ToLower](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_ToLower) | Converts all characters in a string to lowercase.

> **Warning**
>   
> Note that the `String.ToUpper` and `String.ToLower` methods should not be used to convert strings in order to compare them or test them for equality. 

## Comparing strings of mixed case

To compare strings of mixed case to determine whether they are equal, their, call one of the overloads of the [String.Equals](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Equals_System_String_System_StringComparison_) method with a *comparisonType* parameter, and provide a value of either [StringComparison.CurrentCultureIgnoreCase](https://docs.microsoft.com/dotnet/core/api/System.StringComparison#System_StringComparison_CurrentCultureIgnoreCase) or [StringComparison.OrdinalIgnoreCase](https://docs.microsoft.com/dotnet/core/api/System.StringComparison#System_StringComparison_OrdinalIgnoreCase) for the *comparisonType* argument. 

## ToUpper

The [String.ToUpper](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_ToUpper) method changes all characters in a string to uppercase. The following example converts the string "Hello World!" from mixed case to uppercase.

```csharp
string properString = "Hello World!";
Console.WriteLine(properString.ToUpper());
// This example displays the following output:
//       HELLO WORLD!
```

## ToLower

The [String.ToLower](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_ToLower) method is similar to the previous method, but instead converts all the characters in a string to lowercase. The following example converts the string "Hello World!" to lowercase.

```csharp
string properString = "Hello World!";
Console.WriteLine(properString.ToLower());
// This example displays the following output:
//       hello world!
```
