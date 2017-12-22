---
title: "Parsing Strings in .NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "parsing strings, about parsing strings"
  - "IFormatProvider interface, parsing strings"
  - "base types, parsing strings"
  - "Parse method"
  - "parsing strings"
ms.assetid: 5e758b41-db93-456b-8999-99b7304b090d
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Parsing Strings in .NET
A parsing operation converts a string that represents a .NET base type into that base type. For example, a parsing operation is used to convert a string to a floating-point number or to a date and time value. The method most commonly used to perform a parsing operation is the `Parse` method. Because parsing is the reverse operation of formatting (which involves converting a base type into its string representation), many of the same rules and conventions apply. Just as formatting uses an object that implements the <xref:System.IFormatProvider> interface to provide culture-sensitive formatting information, parsing also uses an object that implements the <xref:System.IFormatProvider> interface to determine how to interpret a string representation. For more information, see [Formatting Types](../../../docs/standard/base-types/formatting-types.md).  
  
## In This Section  
 [Parsing Numeric Strings](../../../docs/standard/base-types/parsing-numeric.md)  
 Describes how to convert strings into .NET numeric types.  
  
 [Parsing Date and Time Strings](../../../docs/standard/base-types/parsing-datetime.md)  
 Describes how to convert strings into .NET **DateTime** types.  
  
 [Parsing Other Strings](../../../docs/standard/base-types/parsing-other.md)  
 Describes how to convert strings into **Char**, **Boolean**, and **Enum** types.  
  
## Related Sections  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 Describes basic formatting concepts like format specifiers and format providers.  
  
 [Type Conversion in .NET](../../../docs/standard/base-types/type-conversion.md)  
 Describes how to convert types.  
  
 [Base Types](../../../docs/standard/base-types/index.md)  
 Describes common operations that you can perform on .NET base types.
