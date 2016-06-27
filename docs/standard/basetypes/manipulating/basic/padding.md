---
title: Padding Strings
description: Padding Strings
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: f143f80f-ca6f-4d38-a643-22ea1bbfa597
---

# Padding Strings

Use one of the following [System.String]( https://docs.microsoft.com/dotnet/core/api/System.String) methods to create a new string that consists of an original string that is padded with leading or trailing characters to a specified total length. The padding character can be spaces or a specified character, and consequently appears to be either right-aligned or left-aligned.

Method name | Use
----------- | ---
[String.PadLeft]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadLeft_System_Int32_) | Pads a string with leading characters to a specified total length.
[String.PadRight]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadRight_System_Int32_) | Pads a string with trailing characters to a specified total length.

## PadLeft

The [String.PadLeft]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadLeft_System_Int32_) method creates a new string by concatenating enough leading pad characters to an original string to achieve a specified total length. The [String.PadLeft(Int32)]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadLeft_System_Int32_) method uses white space as the padding character and the [String.PadLeft(Int32, Char)]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadLeft_System_Int32_System_Char_) method enables you to specify your own padding character.

The following code example uses the [PadLeft]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadLeft_System_Int32_System_Char__) method to create a new string that is twenty characters long. The example displays "`--------Hello World!`" to the console.

```csharp
string MyString = "Hello World!";
Console.WriteLine(MyString.PadLeft(20, '-'));
```

## PadRight

The [String.PadRight]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadRight_System_Int32_) method creates a new string by concatenating enough trailing pad characters to an original string to achieve a specified total length. The [String.PadRight(Int32)]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadRight_System_Int32_) method uses white space as the padding character and the [String.PadRight(Int32, Char)]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadRight_System_Int32_System_Char_) method enables you to specify your own padding character.

The following code example uses the [PadRight(Int32, Char)]( https://docs.microsoft.com/dotnet/core/api/System.String#System_String_PadRight_System_Int32_System_Char_) method to create a new string that is twenty characters long. The example displays "`Hello World!--------`" to the console.

```csharp
string MyString = "Hello World!";
Console.WriteLine(MyString.PadRight(20, '-'));
```



