---
title: "Composite Formatting"
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
helpviewer_keywords: 
  - "parameter specifiers"
  - "strings [.NET Framework], alignment"
  - "format specifiers, composite formatting"
  - "strings [.NET Framework], composite"
  - "composite formatting"
  - "objects [.NET Framework], formatting multiple objects"
ms.assetid: 87b7d528-73f6-43c6-b71a-f23043039a49
caps.latest.revision: 36
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Composite Formatting
The .NET composite formatting feature takes a list of objects and a composite format string as input. A composite format string consists of fixed text intermixed with indexed placeholders, called format items, that correspond to the objects in the list. The formatting operation yields a result string that consists of the original fixed text intermixed with the string representation of the objects in the list.  
  
 The composite formatting feature is supported by methods such as the following:  
  
-   <xref:System.String.Format%2A?displayProperty=nameWithType>, which returns a formatted result string.  
  
-   <xref:System.Text.StringBuilder.AppendFormat%2A?displayProperty=nameWithType>, which appends a formatted result string to a <xref:System.Text.StringBuilder> object.  
  
-   Some overloads of the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method, which display a formatted result string to the console.  
  
-   Some overloads of the <xref:System.IO.TextWriter.WriteLine%2A?displayProperty=nameWithType> method, which write the formatted result string to a stream or file. The classes derived from <xref:System.IO.TextWriter>, such as <xref:System.IO.StreamWriter> and <xref:System.Web.UI.HtmlTextWriter>, also share this functionality.  
  
-   <xref:System.Diagnostics.Debug.WriteLine%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, which outputs a formatted message to trace listeners.  
  
-   The <xref:System.Diagnostics.Trace.TraceError%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, <xref:System.Diagnostics.Trace.TraceInformation%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType>, and <xref:System.Diagnostics.Trace.TraceWarning%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> methods, which output formatted messages to trace listeners.  
  
-   The <xref:System.Diagnostics.TraceSource.TraceInformation%28System.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method, which writes an informational method to trace listeners.  
  
## Composite Format String  
 A composite format string and object list are used as arguments of methods that support the composite formatting feature. A composite format string consists of zero or more runs of fixed text intermixed with one or more format items. The fixed text is any string that you choose, and each format item corresponds to an object or boxed structure in the list. The composite formatting feature returns a new result string where each format item is replaced by the string representation of the corresponding object in the list.  
  
 Consider the following <xref:System.String.Format%2A> code fragment.  
  
 [!code-csharp[Formatting.Composite#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Composite1.cs#1)]
 [!code-vb[Formatting.Composite#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Composite1.vb#1)]  
  
 The fixed text is "`Name =` " and "`, hours =` ". The format items are "`{0}`", whose index is 0, which corresponds to the object `name`, and "`{1:hh}`", whose index is 1, which corresponds to the object `DateTime.Now`.  
  
## Format Item Syntax  
 Each format item takes the following form and consists of the following components:  
  
 `{` *index*[`,`*alignment*][`:`*formatString*]`}`  
  
 The matching braces ("{" and "}") are required.  
  
### Index Component  
 The mandatory *index* component, also called a parameter specifier, is a number starting from 0 that identifies a corresponding item in the list of objects. That is, the format item whose parameter specifier is 0 formats the first object in the list, the format item whose parameter specifier is 1 formats the second object in the list, and so on. The following example includes four parameter specifiers, numbered zero through three,  to represent prime numbers less than ten:  
  
 [!code-csharp[Formatting.Composite#7](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/index1.cs#7)]
 [!code-vb[Formatting.Composite#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/index1.vb#7)]  
  
 Multiple format items can refer to the same element in the list of objects by specifying the same parameter specifier. For example, you can format the same numeric value in hexadecimal, scientific, and number format by specifying a composite format string such as : "0x{0:X} {0:E} {0:N}", as the following example shows.  
  
 [!code-csharp[Formatting.Composite#10](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/index1.cs#10)]
 [!code-vb[Formatting.Composite#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/index1.vb#10)]  
  
 Each format item can refer to any object in the list. For example, if there are three objects, you can format the second, first, and third object by specifying a composite format string like this: "{1} {0} {2}". An object that is not referenced by a format item is ignored. A <xref:System.FormatException> is thrown at runtime if a parameter specifier designates an item outside the bounds of the list of objects.  
  
### Alignment Component  
 The optional *alignment* component is a signed integer indicating the preferred formatted field width. If the value of *alignment* is less than the length of the formatted string, *alignment* is ignored and the length of the formatted string is used as the field width. The formatted data in the field is right-aligned if *alignment* is positive and left-aligned if *alignment* is negative. If padding is necessary, white space is used. The comma is required if *alignment*  is specified.  
  
 The following example defines two arrays, one containing the names of employees and the other containing the hours they worked over a two-week period. The composite format string left-aligns the names in a 20-character field, and right-aligns their hours in a 5-character field. Note that the "N1" standard format string is also used to format the hours with one fractional digit.  
  
 [!code-csharp[Formatting.Composite#8](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/alignment1.cs#8)]
 [!code-vb[Formatting.Composite#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/alignment1.vb#8)]  
  
### Format String Component  
 The optional *formatString* component is a format string that is appropriate for the type of object being formatted. Specify a standard or custom numeric format string if the corresponding object is a numeric value, a standard or custom date and time format string if the corresponding object is a <xref:System.DateTime> object, or an [enumeration format string](../../../docs/standard/base-types/enumeration-format-strings.md) if the corresponding object is an enumeration value. If *formatString* is not specified, the general ("G") format specifier for a numeric, date and time, or enumeration type is used. The colon is required if *formatString* is specified.  
  
 The following table lists types or categories of types in the .NET Framework class library that support a predefined set of format strings, and provides links to the topics that list the supported format strings. Note that string formatting is an extensible mechanism that makes it possible to define new format strings for all existing types as well as to define a set of format strings supported by an application-defined type. For more information, see the <xref:System.IFormattable> and <xref:System.ICustomFormatter> interface topics.  
  
|Type or type category|See|  
|---------------------------|---------|  
|Date and time types (<xref:System.DateTime>, <xref:System.DateTimeOffset>)|[Standard Date and Time Format Strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md)<br /><br /> [Custom Date and Time Format Strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md)|  
|Enumeration types (all types derived from <xref:System.Enum?displayProperty=nameWithType>)|[Enumeration Format Strings](../../../docs/standard/base-types/enumeration-format-strings.md)|  
|Numeric types (<xref:System.Numerics.BigInteger>, <xref:System.Byte>, <xref:System.Decimal>, <xref:System.Double>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.Single>, <xref:System.UInt16>, <xref:System.UInt32>, <xref:System.UInt64>)|[Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md)<br /><br /> [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md)|  
|<xref:System.Guid>|<xref:System.Guid.ToString%28System.String%29?displayProperty=nameWithType>|  
|<xref:System.TimeSpan>|[Standard TimeSpan Format Strings](../../../docs/standard/base-types/standard-timespan-format-strings.md)<br /><br /> [Custom TimeSpan Format Strings](../../../docs/standard/base-types/custom-timespan-format-strings.md)|  
  
### Escaping Braces  
 Opening and closing braces are interpreted as starting and ending a format item. Consequently, you must use an escape sequence to display a literal opening brace or closing brace. Specify two opening braces ("{{") in the fixed text to display one opening brace ("{"), or two closing braces ("}}") to display one closing brace ("}"). Braces in a format item are interpreted sequentially in the order they are encountered. Interpreting nested braces is not supported.  
  
 The way escaped braces are interpreted can lead to unexpected results. For example, consider the format item "{{{0:D}}}", which is intended to display an opening brace, a numeric value formatted as a decimal number, and a closing brace. However, the format item is actually interpreted in the following manner:  
  
1.  The first two opening braces ("{{") are escaped and yield one opening brace.  
  
2.  The next three characters ("{0:") are interpreted as the start of a format item.  
  
3.  The next character ("D") would be interpreted as the Decimal standard numeric format specifier, but the next two escaped braces ("}}") yield a single brace. Because the resulting string ("D}") is not a standard numeric format specifier, the resulting string is interpreted as a custom format string that means display the literal string "D}".  
  
4.  The last brace ("}") is interpreted as the end of the format item.  
  
5.  The final result that is displayed is the literal string, "{D}". The numeric value that was to be formatted is not displayed.  
  
 One way to write your code to avoid misinterpreting escaped braces and format items is to format the braces and format item separately. That is, in the first format operation display a literal opening brace, in the next operation display the result of the format item, then in the final operation display a literal closing brace. The following example illustrates this approach.  
  
 [!code-csharp[Formatting.Composite#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Escaping1.cs#2)]
 [!code-vb[Formatting.Composite#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Escaping1.vb#2)]  
  
### Processing Order  
 If the call to the composite formatting method includes an <xref:System.IFormatProvider> argument whose value is not `null`, the runtime calls its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method to request an <xref:System.ICustomFormatter> implementation. If the method is able to return an <xref:System.ICustomFormatter> implementation, it is cached for later use.  
  
 Each value in the parameter list that corresponds to a format item is converted to a string by performing the following steps. If any condition in the first three steps is true, the string representation of the value is returned in that step, and subsequent steps are not executed.  
  
1.  If the value to be formatted is `null`, an empty string ("") is returned.  
  
2.  If an <xref:System.ICustomFormatter> implementation is available, the runtime calls its <xref:System.ICustomFormatter.Format%2A> method. It passes the method the format item's *formatString* value, if one is present, or `null` if it is not, along with the <xref:System.IFormatProvider> implementation.  
  
3.  If the value implements the <xref:System.IFormattable> interface, the interface's <xref:System.IFormattable.ToString%28System.String%2CSystem.IFormatProvider%29> method is called. The method is passed the *formatString* value, if one is present in the format item, or `null` if it is not. The <xref:System.IFormatProvider> argument is determined as follows:  
  
    -   For a numeric value, if a composite formatting method with a non-null <xref:System.IFormatProvider> argument is called, the runtime requests a <xref:System.Globalization.NumberFormatInfo> object from its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an <xref:System.IFormatProvider> parameter, the <xref:System.Globalization.NumberFormatInfo> object for the current thread culture is used.  
  
    -   For a date and time value, if a composite formatting method with a non-null <xref:System.IFormatProvider> argument is called, the runtime requests a <xref:System.Globalization.DateTimeFormatInfo> object from its <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method. If it is unable to supply one, if the value of the argument is `null`, or if the composite formatting method does not have an <xref:System.IFormatProvider> parameter, the <xref:System.Globalization.DateTimeFormatInfo> object for the current thread culture is used.  
  
    -   For objects of other types, if a composite formatting is called with an <xref:System.IFormatProvider> argument, its value (including a `null`, if no <xref:System.IFormatProvider> object is supplied) is passed directly to the <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation.  Otherwise, a <xref:System.Globalization.CultureInfo> object that represents the current thread culture is passed to the <xref:System.IFormattable.ToString%2A?displayProperty=nameWithType> implementation.  
  
4.  The type's parameterless `ToString` method, which either overrides <xref:System.Object.ToString?displayProperty=nameWithType> or inherits the behavior of its base class, is called. In this case, the format string specified by the *formatString* component in the format item, if it is present, is ignored.  
  
 Alignment is applied after the preceding steps have been performed.  
  
## Code Examples  
 The following example shows one string created using composite formatting and another created using an object's `ToString` method. Both types of formatting produce equivalent results.  
  
 [!code-csharp[Formatting.Composite#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Composite1.cs#3)]
 [!code-vb[Formatting.Composite#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Composite1.vb#3)]  
  
 Assuming that the current day is a Thursday in May, the value of both strings in the preceding example is `Thursday May` in the U.S. English culture.  
  
 <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> exposes the same functionality as <xref:System.String.Format%2A?displayProperty=nameWithType>. The only difference between the two methods is that <xref:System.String.Format%2A?displayProperty=nameWithType> returns its result as a string, while <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> writes the result to the output stream associated with the <xref:System.Console> object. The following example uses the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method to format the value of `MyInt` to a currency value.  
  
 [!code-csharp[Formatting.Composite#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Composite1.cs#4)]
 [!code-vb[Formatting.Composite#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Composite1.vb#4)]  
  
 The following example demonstrates formatting multiple objects, including formatting one object two different ways.  
  
 [!code-csharp[Formatting.Composite#5](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Composite1.cs#5)]
 [!code-vb[Formatting.Composite#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Composite1.vb#5)]  
  
 The following example demonstrates the use of alignment in formatting. The arguments that are formatted are placed between vertical bar characters (&#124;) to highlight the resulting alignment.  
  
 [!code-csharp[Formatting.Composite#6](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.Composite/cs/Composite1.cs#6)]
 [!code-vb[Formatting.Composite#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.Composite/vb/Composite1.vb#6)]  
  
## See Also  
 <xref:System.Console.WriteLine%2A>  
 <xref:System.String.Format%2A?displayProperty=nameWithType>  
 [String interpolation (C#)](../../csharp/language-reference/tokens/interpolated.md)  
 [String interpolation (Visual Basic)](../../visual-basic/programming-guide/language-features/strings/interpolated-strings.md)  
 [Formatting Types](../../../docs/standard/base-types/formatting-types.md)  
 [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md)  
 [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md)  
 [Standard Date and Time Format Strings](../../../docs/standard/base-types/standard-date-and-time-format-strings.md)  
 [Custom Date and Time Format Strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md)  
 [Standard TimeSpan Format Strings](../../../docs/standard/base-types/standard-timespan-format-strings.md)  
 [Custom TimeSpan Format Strings](../../../docs/standard/base-types/custom-timespan-format-strings.md)  
 [Enumeration Format Strings](../../../docs/standard/base-types/enumeration-format-strings.md)
