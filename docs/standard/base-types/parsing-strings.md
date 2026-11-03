---
title: "Convert strings to types"
description: Understand string parsing in .NET. Parsing converts a string representing a .NET base type into that base type. Parsing is the reverse operation to formatting.
ms.date: "03/30/2017"
ms.topic: concept-article
helpviewer_keywords:
  - "parsing strings, about parsing strings"
  - "IFormatProvider interface, parsing strings"
  - "base types, parsing strings"
  - "Parse method"
  - "parsing strings"
ms.assetid: 5e758b41-db93-456b-8999-99b7304b090d
---
# Parse strings in .NET

A *parsing* operation converts a string that represents a .NET base type into that base type. For example, a parsing operation is used to convert a string to a floating-point number or to a date-and-time value. The method most commonly used to perform a parsing operation is the `Parse` method. Because parsing is the reverse operation of formatting (which involves converting a base type into its string representation), many of the same rules and conventions apply. Just as formatting uses an object that implements the <xref:System.IFormatProvider> interface to provide culture-sensitive formatting information, parsing also uses an object that implements the <xref:System.IFormatProvider> interface to determine how to interpret a string representation. For more information, see [Format types](formatting-types.md).

## In This Section

 [Parsing Numeric Strings](parsing-numeric.md)\
 Describes how to convert strings into .NET numeric types.

 [Parsing Date and Time Strings](parsing-datetime.md)\
 Describes how to convert strings into .NET **DateTime** types.

 [Parsing Other Strings](parsing-other.md)\
 Describes how to convert strings into **Char**, **Boolean**, and **Enum** types.

## Related Sections

 [Formatting Types](formatting-types.md)\
 Describes basic formatting concepts like format specifiers and format providers.

 [Type Conversion in .NET](type-conversion.md)\
 Describes how to convert types.
