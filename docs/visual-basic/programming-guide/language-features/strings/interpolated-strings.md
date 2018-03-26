---
title: "Interpolated Strings (Visual Basic)"
ms.date: "10/31/2017"
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
author: "rpetrusha"
ms.author: "ronpet"
---
# Interpolated Strings (Visual Basic Reference)

Used to construct strings.  An interpolated string looks like a template string that contains *interpolated expressions*.  An interpolated string returns a string that replaces the interpolated expressions that it contains with their string representations. This feature is available in Visual Basic 14 and later versions.

The arguments of an interpolated string are easier to understand than a [composite format string](../../../../standard/base-types/composite-formatting.md#composite-format-string).  For example, the interpolated string  
  
```vb  
Console.WriteLine($"Name = {name}, hours = {hours:hh}")
```  
contains two interpolated expressions, '{name}' and '{hours:hh}'. The equivalent composite format string is:

```vb
Console.WriteLine("Name = {0}, hours = {1:hh}", name, hours); 
```  

The structure of an interpolated string is:  
  
```vb  
$"<text> {<interpolated-expression> [,<field-width>] [:<format-string>] } <text> ..."  
```  

where: 

- *field-width* is a signed integer that indicates the number of characters in the field. If it is positive, the field is right-aligned; if negative, left-aligned. 

- *format-string* is a format string appropriate for the type of object being formatted. For example, for a <xref:System.DateTime> value, it could be a [standard date and time format string](~/docs/standard/base-types/standard-date-and-time-format-strings.md) such as "D" or "d".

> [!IMPORTANT]
> You cannot have any whitespace between the `$` and the `"` that starts the string. Doing so causes a compiler error.

 You can use an interpolated string anywhere you can use a string literal.  The interpolated string is evaluated each time the code with the interpolated string executes. This allows you to separate the definition and evaluation of an interpolated string.  
  
 To include a curly brace ("{" or "}") in an interpolated string, use two curly braces, "{{" or "}}".  See the Implicit Conversions section for more details.  

If the interpolated string contains other characters with special meaning in an interpolated string, such as the quotation mark ("), colon (:), or comma (,), they should be escaped if they occur in literal text, or they should be included in an expression delimited by parentheses if they are language elements included in an interpolated expression. The following example escapes quotation marks to include them in the result string, and it uses parentheses to delimit the expression `(age == 1 ? "" : "s")` so that the colon is not interpreted as beginning a format string.

[!code-vb[interpolated-strings](../../../../../samples/snippets/visualbasic/programming-guide/language-features/strings/interpolated-strings4.vb)]  

## Implicit Conversions  

There are three implicit type conversions from an interpolated string:  

1. Conversion of an interpolated string to a <xref:System.String>. The following example returns a string whose interpolated string expressions have been replaced with their string representations. For example:

   [!code-vb[interpolated-strings1](../../../../../samples/snippets/visualbasic/programming-guide/language-features/strings/interpolated-strings1.vb)]  

   This is the final result of a string interpretation. All occurrences of double curly braces ("{{" and "}}") are converted to a single curly brace. 

2. Conversion of an interpolated string to an <xref:System.IFormattable> variable that allows you create multiple result strings with culture-specific content from a single <xref:System.IFormattable> instance. This is useful for including such things as the correct numeric and date formats for individual cultures.  All occurrences of double curly braces ("{{" and "}}") remain as double curly braces until you format the string by explicitly or implicitly calling the <xref:System.Object.ToString> method.  All contained interpolation expressions are converted to {0}, {1}, and so on.  

   The following example uses reflection to display the members as well as the field and property values of an <xref:System.IFormattable> variable that is created from an interpolated string. It also passes the <xref:System.IFormattable> variable to the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method.

   [!code-vb[interpolated-strings2](../../../../../samples/snippets/visualbasic/programming-guide/language-features/strings/interpolated-strings2.vb)]  

   Note that the interpolated string can be inspected only by using reflection. If it is passed to a string formatting method, such as <xref:System.Console.WriteLine(System.String)>, its format items are resolved and the result string returned. 

3. Conversion of an interpolated string to a <xref:System.FormattableString> variable that represents a composite format string. Inspecting the composite format string and how it renders as a result string might, for example, help you protect against an injection attack if you were building a query. A <xref:System.FormattableString> also includes:

      - A <xref:System.FormattableString.ToString> overload that produces a result string for the <xref:System.Globalization.CultureInfo.CurrentCulture>.
      
      - A <xref:System.FormattableString.Invariant%2A> method that produces a string for the <xref:System.Globalization.CultureInfo.InvariantCulture>.
      
      - A <xref:System.FormattableString.ToString(System.IFormatProvider)> method that produces a result string for a specified culture. 
  
    All occurrences of double curly braces ("{{" and "}}") remain as double curly braces until you format.  All contained interpolation expressions are converted to {0}, {1}, and so on.  

   [!code-vb[interpolated-strings3](../../../../../samples/snippets/visualbasic/programming-guide/language-features/strings/interpolated-strings3.vb)]  

## See Also  
 <xref:System.IFormattable?displayProperty=nameWithType>  
 <xref:System.FormattableString?displayProperty=nameWithType>  
 [Visual Basic Language Reference](index.md)  
 