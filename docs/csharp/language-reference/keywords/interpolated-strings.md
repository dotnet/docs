---
title: "Interpolated Strings (C#)"
ms.date: "10/18/2017"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 324f267e-1c61-431a-97ed-852c1530742d
caps.latest.revision: 9
author: "BillWagner"
ms.author: "wiwagn"
---
# Interpolated Strings (C# Reference)

Used to construct strings.  An interpolated string looks like a template string that contains *interpolated expressions*.  An interpolated string returns a string that replaces the interpolated expressions that it contains with their string representations. This feature is available in C# 6 and later versions.

The arguments of an interpolated string are easier to understand than a [composite format string](../../../standard/base-types/composite-formatting.md#composite-format-string).  For example, the interpolated string  
  
```csharp  
Console.WriteLine($"Name = {name}, hours = {hours:hh}");
```  
contains two interpolated expressions, '{name}' and '{hours:hh}'. The equivalent composite format string is:

```csharp
Console.WriteLine("Name = {0}, hours = {1:hh}", name, hours); 
```  

The structure of an interpolated string is:  
  
```  
$"<text> {<interpolated-expression> [,<field-width>] [:<format-string>] } <text> ..."  
```  

where: 

- *field-width* is a signed integer that indicates the number of characters in the field. If it is positive, the field is right-aligned; if negative, left-aligned. 

- *format-string* is a format string appropriate for the type of object being formatted. For example, for a <xref:System.DateTime> value, it could be a standard date and time format string such as "D" or "d".

> [!IMPORTANT]
> You cannot have any whitespace between the `$` and the `"` that starts the string. Doing so causes a compile time error.

 You can use an interpolated string anywhere you can use a string literal.  The interpolated string is evaluated each time the code with the interpolated string executes. This allows you to separate the definition and evaluation of an interpolated string.  
  
 To include a curly brace ("{" or "}") in an interpolated string, use two curly braces, "{{" or "}}".  See the Implicit Conversions section for more details.  

If the interpolated string contains other characters with special meaning in an interpolated string, such as the quotation mark ("), colon (:), or comma (,), they should be escaped if they occur in literal text, or they should be included in an expression delimited by parentheses if they are language elements included in an interpolated expression. The following example escapes quotation marks to include them in the result string, and it uses parentheses to delimit the expression `(age == 1 ? "" : "s")` so that the colon is not interpreted as beginning a format string.

[!code-csharp[interpolated-strings4](../../../../samples/snippets/csharp/language-reference/keywords/interpolated-strings4.cs#1)]  

Verbatim interpolated strings use the `$` character followed by the `@` character. For more information about verbatim strings, see the [string](string.md) topic. The following code is a modified version of the previous snippet using a verbatim interpolated string:

[!code-csharp[interpolated-strings4](../../../../samples/snippets/csharp/language-reference/keywords/interpolated-strings5.cs#1)]  

The formatting changes are necessary because verbatim strings do not obey `\` escape sequences.

> [!IMPORTANT]
> The `$` token must appear before the `@` token in a verbatim interpolated string.


## Implicit Conversions  

There are three implicit type conversions from an interpolated string:  

1. Conversion of an interpolated string to a <xref:System.String>. The following example returns a string whose interpolated string expressions have been replaced with their string representations. For example:

   [!code-csharp[interpolated-strings1](../../../../samples/snippets/csharp/language-reference/keywords/interpolated-strings1.cs#1)]  

   This is the final result of a string interpretation. All occurrences of double curly braces ("{{" and "}}") are converted to a single curly brace. 

2. Conversion of an interpolated string to an <xref:System.IFormattable> variable that allows you create multiple result strings with culture-specific content from a single <xref:System.IFormattable> instance. This is useful for including such things as the correct numeric and date formats for individual cultures.  All occurrences of double curly braces ("{{" and "}}") remain as double curly braces until you format the string by explicitly or implicitly calling the <xref:System.Object.ToString> method.  All contained interpolation expressions are converted to {0}, {1}, and so on.  

   The following example uses reflection to display the members as well as the field and property values of an <xref:System.IFormattable> variable that is created from an interpolated string. It also passes the <xref:System.IFormattable> variable to the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method.

   [!code-csharp[interpolated-strings2](../../../../samples/snippets/csharp/language-reference/keywords/interpolated-strings2.cs#1)]  

   Note that the interpolated string can be inspected only by using reflection. If it is passed to a string formatting method, such as <xref:System.Console.WriteLine(System.String)>, its format items are resolved and the result string returned. 

3. Conversion of an interpolated string to an <xref:System.FormattableString> variable that represents a composite format string. Inspecting the composite format string and how it renders as a result string might, for example, help you protect against an injection attack if you were building a query. <xref:System.FormattableString> also includes <xref:System.FormattableString.ToString> overloads that let you produce result strings for the <xref:System.Globalization.CultureInfo.InvariantCulture> and <xref:System.Globalization.CultureInfo.CurrentCulture>.  All occurrences of double curly braces ("{{" and "}}") remain as double curly braces, until you format.  All contained interpolation expressions are converted to {0}, {1}, and so on.  

   [!code-csharp[interpolated-strings3](../../../../samples/snippets/csharp/language-reference/keywords/interpolated-strings3.cs#1)]  

## Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.IFormattable?displayProperty=nameWithType>  
 <xref:System.FormattableString?displayProperty=nameWithType>  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)
