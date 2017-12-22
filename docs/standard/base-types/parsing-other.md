---
title: "Parsing Other Strings in .NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "Char data type, parsing strings"
  - "enumerations [.NET Framework], parsing strings"
  - "base types, parsing strings"
  - "parsing strings, other strings"
  - "Boolean data type, parsing strings"
ms.assetid: d139bc00-3c4e-4d78-ac9a-5c951b258d28
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Parsing Other Strings in .NET
In addition to numeric and <xref:System.DateTime> strings, you can also parse strings that represent the types <xref:System.Char>, <xref:System.Boolean>, and <xref:System.Enum> into data types.  
  
## Char  
 The static parse method associated with the **Char** data type is useful for converting a string that contains a single character into its Unicode value. The following code example parses a string into a Unicode character.  
  
 [!code-cpp[Conceptual.String.Parse#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.parse/cpp/parse.cpp#2)]
 [!code-csharp[Conceptual.String.Parse#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.parse/cs/parse.cs#2)]
 [!code-vb[Conceptual.String.Parse#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.parse/vb/parse.vb#2)]  
  
## Boolean  
 The **Boolean** data type contains a **Parse** method that you can use to convert a string that represents a Boolean value into an actual **Boolean** type. This method is not case-sensitive and can successfully parse a string containing "True" or "False." The **Parse** method associated with the **Boolean** type can also parse strings that are surrounded by white spaces. If any other string is passed, a <xref:System.FormatException> is thrown.  
  
 The following code example uses the **Parse** method to convert a string into a Boolean value.  
  
 [!code-cpp[Conceptual.String.Parse#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.parse/cpp/parse.cpp#3)]
 [!code-csharp[Conceptual.String.Parse#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.parse/cs/parse.cs#3)]
 [!code-vb[Conceptual.String.Parse#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.parse/vb/parse.vb#3)]  
  
## Enumeration  
 You can use the static **Parse** method to initialize an enumeration type to the value of a string. This method accepts the enumeration type you are parsing, the string to parse, and an optional Boolean flag indicating whether or not the parse is case-sensitive. The string you are parsing can contain several values separated by commas, which can be preceded or followed by one or more empty spaces (also called white spaces). When the string contains multiple values, the value of the returned object is the value of all specified values combined with a bitwise OR operation.  
  
 The following example uses the **Parse** method to convert a string representation into an enumeration value. The <xref:System.DayOfWeek> enumeration is initialized to **Thursday** from a string.  
  
 [!code-cpp[Conceptual.String.Parse#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.parse/cpp/parse.cpp#4)]
 [!code-csharp[Conceptual.String.Parse#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.parse/cs/parse.cs#4)]
 [!code-vb[Conceptual.String.Parse#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.parse/vb/parse.vb#4)]  
  
## See Also  
 [Parsing Strings](../../../docs/standard/base-types/parsing-strings.md)  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 [Type Conversion in the .NET](../../../docs/standard/base-types/type-conversion.md)
