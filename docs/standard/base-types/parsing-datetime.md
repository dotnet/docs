---
title: "Parsing Date and Time Strings in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "parsing strings, date and time strings"
  - "date and time strings"
  - "ParseExact method"
  - "enumerations [.NET Framework], parsing strings"
  - "base types, parsing strings"
  - "DateTime object"
  - "time strings"
ms.assetid: 43bae51e-9b1d-41a6-a187-772c0d096d90
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Parsing Date and Time Strings in .NET
Parsing methods convert the string representation of a date and time to an equivalent <xref:System.DateTime> object. The <xref:System.DateTime.Parse%2A> and <xref:System.DateTime.TryParse%2A> methods convert any of several common representations of a date and time. The <xref:System.DateTime.ParseExact%2A> and <xref:System.DateTime.TryParseExact%2A> methods convert a string representation that conforms to the pattern specified by a date and time format string. (See the topics on [standard date and time format strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md) and [custom date and time format strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md).)  
  
 Parsing is influenced by the properties of a format provider that supplies information such as the strings used for date and time separators, and the names of months, days, and eras. The format provider is the current <xref:System.Globalization.DateTimeFormatInfo> object, which is provided implicitly by the current thread culture or explicitly by the <xref:System.IFormatProvider> parameter of a parsing method. For the <xref:System.IFormatProvider> parameter, specify a <xref:System.Globalization.CultureInfo> object, which represents a culture, or a <xref:System.Globalization.DateTimeFormatInfo> object.  
  
 The string representation of a date to be parsed must include the month and at least a day or year. The string representation of a time must include the hour and at least minutes or the AM/PM designator. However, parsing supplies default values for omitted components if possible. A missing date defaults to the current date, a missing year defaults to the current year, a missing day of the month defaults to the first day of the month, and a missing time defaults to midnight.  
  
 If the string representation specifies only a time, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Year%2A>, <xref:System.DateTime.Month%2A>, and <xref:System.DateTime.Day%2A> properties set to the corresponding values of the <xref:System.DateTime.Today%2A> property. However, if the <xref:System.Globalization.DateTimeStyles> constant is specified in the parsing method, the resulting year, month, and day properties are set to the value `1`.  
  
 In addition to a date and a time component, the string representation of a date and time can include an offset that indicates how much the time differs from Coordinated Universal Time (UTC). For example, the string "2/14/2007 5:32:00 -7:00" defines a time that is seven hours earlier than UTC. If an offset is omitted from the string representation of a time, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind?displayProperty=fullName>. If an offset is specified, parsing returns a <xref:System.DateTime> object with its <xref:System.DateTime.Kind%2A> property set to <xref:System.DateTimeKind> and its value adjusted to the local time zone of your machine. You can modify this behavior by using a <xref:System.Globalization.DateTimeStyles> constant with the parsing method.  
  
 The format provider is also used to interpret an ambiguous numeric date. For example, it is not clear which components of the date represented by the string "02/03/04" are the month, day, and year. In this case, the components are interpreted according to the order of similar date formats in the format provider.  
  
## Parse  
 The following code example illustrates the use of the **Parse** method to convert a string into a **DateTime**. This example uses the culture associated with the current thread to perform the parse. If the <xref:System.Globalization.CultureInfo> associated with the current culture cannot parse the input string, a <xref:System.FormatException> is thrown.  
  
 [!code-csharp[Parsing.DateAndTime#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Parsing.DateAndTime/cs/Example.cs#1)]
 [!code-vb[Parsing.DateAndTime#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Parsing.DateAndTime/vb/Example.vb#1)]  
  
 You can also specify a **CultureInfo** set to one of the cultures defined by that object, or you can specify one of the standard <xref:System.Globalization.DateTimeFormatInfo> objects returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=fullName> property. The following code example uses a format provider to parse a German string into a **DateTime**. A **CultureInfo** representing the de-DE culture is defined and passed with the string being parsed to ensure successful parsing of this particular string. This precludes whatever setting is in the **CurrentCulture** of the **CurrentThread**.  
  
 [!code-csharp[Parsing.DateAndTime#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Parsing.DateAndTime/cs/Example2.cs#2)]
 [!code-vb[Parsing.DateAndTime#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Parsing.DateAndTime/vb/Example2.vb#2)]  
  
 However, although you can use overloads of the <xref:System.DateTime.Parse%2A> method to specify custom format providers, the method does not support the use of non-standard format providers. To parse a date and time expressed in a non-standard format, use the <xref:System.DateTime.ParseExact%2A> method instead.  
  
 The following code example uses the <xref:System.Globalization.DateTimeStyles> enumeration to specify that the current date and time information should not be added to the **DateTime** for fields that the string does not define.  
  
 [!code-csharp[Parsing.DateAndTime#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Parsing.DateAndTime/cs/Example3.cs#3)]
 [!code-vb[Parsing.DateAndTime#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Parsing.DateAndTime/vb/Example3.vb#3)]  
  
## ParseExact  
 The <xref:System.DateTime.ParseExact%2A?displayProperty=fullName> method converts a string that conforms to a specified string pattern to a **DateTime** object. When a string that is not of the form specified is passed to this method, a <xref:System.FormatException> is thrown. You can specify one of the standard date and time format specifiers or a limited combination of the custom date and time format specifiers. Using the custom format specifiers, it is possible for you to construct a custom recognition string. For an explanation of the specifiers, see the topics on [standard date and time format strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md) and [custom date and time format strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md).  
  
 Each overload of the <xref:System.DateTime.ParseExact%2A> method also has an <xref:System.IFormatProvider> parameter that typically provides culture-specific information about the formatting of the string. Typically, this <xref:System.IFormatProvider> object is a <xref:System.Globalization.CultureInfo> object that represents a standard culture or a <xref:System.Globalization.DateTimeFormatInfo> object that is returned by the <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=fullName> property. However, unlike the other date and time parsing functions, this method also supports an <xref:System.IFormatProvider> that defines a non-standard date and time format.  
  
 In the following code example, the **ParseExact** method is passed a string object to parse, followed by a format specifier, followed by a **CultureInfo** object. This **ParseExact** method can only parse strings that exhibit the long date pattern in the en-US culture.  
  
 [!code-csharp[Parsing.DateAndTime#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Parsing.DateAndTime/cs/Example4.cs#4)]
 [!code-vb[Parsing.DateAndTime#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Parsing.DateAndTime/vb/Example4.vb#4)]  
  
## See Also  
 [Parsing Strings](../../../docs/standard/base-types/parsing-strings.md)   
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)   
 [Type Conversion in .NET](../../../docs/standard/base-types/type-conversion.md)