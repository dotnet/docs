---
title: Parsing Strings in .NET Core
description: Parsing Strings in .NET Core
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8d9c21fa-ad9c-4296-b595-5eb6f82adf4c
---

# Parsing Strings in .NET Core

A parsing operation converts a string that represents a .NET Core base type into that base type. For example, a parsing operation is used to convert a string to a floating-point number or to a date and time value. The method most commonly used to perform a parsing operation is the `Parse` method. Because parsing is the reverse operation of formatting (which involves converting a base type into its string representation), many of the same rules and conventions apply. Just as formatting uses an object that implements the [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) interface to provide culture-sensitive formatting information, parsing also uses an object that implements the [IFormatProvider](https://docs.microsoft.com/dotnet/core/api/System.IFormatProvider) interface to determine how to interpret a string representation. 

## In This Section

[Parsing Numeric Strings in .NET Core](parsingnumeric.md) - Describes how to convert strings into .NET Core numeric types.

[Parsing Date and Time Strings in .NET Core](parsingdatetime.md) - Describes how to convert strings into .NET Core `DateTime` types.

[Parsing Other Strings in .NET Core](.//parsingother.md) - Describes how to convert strings into `Char`, `Boolean`, and `Enum` types.


