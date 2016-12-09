---
title: Parsing strings in .NET
description: Parsing strings in .NET
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/22/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 8103c0a6-61d3-40dd-a3e9-2a32ba6a4c05
---

# Parsing strings in .NET

A parsing operation converts a string that represents a .NET base type into that base type. For example, a parsing operation is used to convert a string to a floating-point number or to a date and time value. The method most commonly used to perform a parsing operation is the `Parse` method. Because parsing is the reverse operation of formatting (which involves converting a base type into its string representation), many of the same rules and conventions apply. Just as formatting uses an object that implements the [IFormatProvider](xref:System.IFormatProvider) interface to provide culture-sensitive formatting information, parsing also uses an object that implements the [IFormatProvider](xref:System.IFormatProvider) interface to determine how to interpret a string representation. For more information, see [Formatting Types in .NET](formatting-types.md).

## In This Section

[Parsing Numeric Strings in .NET](parsing-numeric.md) - Describes how to convert strings into .NET numeric types.

[Parsing Date and Time Strings in .NET](parsing-datetime.md) - Describes how to convert strings into .NET `DateTime` types.

[Parsing Other Strings in .NET](parsing-other.md) - Describes how to convert strings into [Char](xref:System.Char), [Boolean](xref:System.Boolean), and [Enum](xref:System.Enum) types.

[Formatting Types in .NET](formatting-types.md) - Describes basic formatting concepts like format specifiers and format providers.

[Type Conversion in .NET](type-conversion.md) - Describes how to convert types.

[Working with Base Types in .NET](index.md) - Describes common operations that you can perform on .NET base types.

