---
title: Padding strings
description: Padding strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 1c8b3b44-d370-49e1-90b5-64ac81c02ae91c8b3b44-d370-49e1-90b5-64ac81c02ae9
---

# Padding strings

Use one of the following [System.String](xref:System.String) methods to create a new string that consists of an original string that is padded with leading or trailing characters to a specified total length. The padding character can be spaces or a specified character, and consequently appears to be either right-aligned or left-aligned.

Method name | Use
----------- | ---
[String.PadLeft](xref:System.String.PadLeft(System.Int32)) | Pads a string with leading characters to a specified total length.
[String.PadRight](xref:System.String.PadRight(System.Int32)) | Pads a string with trailing characters to a specified total length.

## PadLeft

The [String.PadLeft](xref:System.String.PadLeft(System.Int32)) method creates a new string by concatenating enough leading pad characters to an original string to achieve a specified total length. The [String.PadLeft(Int32)](xref:System.String.PadLeft(System.Int32)) method uses white space as the padding character and the [String.PadLeft(Int32, Char)](xref:System.String.PadLeft(System.Int32,System.Char)) method enables you to specify your own padding character.

The following code example uses the [PadLeft(Int32, Char)](xref:System.String.PadLeft(System.Int32,System.Char)) method to create a new string that is twenty characters long. The example displays "`--------Hello World!`" to the console.

```csharp
string MyString = "Hello World!";
Console.WriteLine(MyString.PadLeft(20, '-'));
```

```vb
Dim MyString As String = "Hello World!"
Console.WriteLine(MyString.PadLeft(20, "-"c))
```

## PadRight

The [String.PadRight](xref:System.String.PadRight(System.Int32)) method creates a new string by concatenating enough trailing pad characters to an original string to achieve a specified total length. The [String.PadRight(Int32)](xref:System.String.PadRight(System.Int32)) method uses white space as the padding character and the [String.PadRight(Int32, Char)](xref:System.String.PadRight(System.Int32,System.Char)) method enables you to specify your own padding character.

The following code example uses the [PadRight(Int32, Char)](xref:System.String.PadRight(System.Int32,System.Char)) method to create a new string that is twenty characters long. The example displays "`Hello World!--------`" to the console.

```csharp
string MyString = "Hello World!";
Console.WriteLine(MyString.PadRight(20, '-'));
```

```vb
Dim MyString As String = "Hello World!"
Console.WriteLine(MyString.PadRight(20, "-"c))
```

## See Also

[Basic string operations](basic-string-operations.md)

