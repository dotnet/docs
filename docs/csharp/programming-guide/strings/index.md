---
title: "Strings - C# Programming Guide"
description: Learn about strings in C# programming. See information on declaring and initializing strings, the immutability of string objects, and string escape sequences.
ms.date: 06/30/2021
helpviewer_keywords: 
  - "C# language, strings"
  - "strings [C#]"
ms.assetid: 21580405-cb25-4541-89d5-037846a38b07
---
# Strings (C# Programming Guide)

A string is an object of type <xref:System.String> whose value is text. Internally, the text is stored as a sequential read-only collection of <xref:System.Char> objects. There is no null-terminating character at the end of a C# string; therefore a C# string can contain any number of embedded null characters ('\0'). The <xref:System.String.Length%2A> property of a string represents the number of `Char` objects it contains, not the number of Unicode characters. To access the individual Unicode code points in a string, use the <xref:System.Globalization.StringInfo> object.  
  
## string vs. System.String  

 In C#, the `string` keyword is an alias for <xref:System.String>. Therefore, `String` and `string` are equivalent, regardless it is recommended to use the provided alias `string` as it works even without `using System;`. The `String` class provides many methods for safely creating, manipulating, and comparing strings. In addition, the C# language overloads some operators to simplify common string operations. For more information about the keyword, see [string](../../language-reference/builtin-types/reference-types.md). For more information about the type and its methods, see <xref:System.String>.
  
## Declaring and Initializing Strings  

 You can declare and initialize strings in various ways, as shown in the following example:  
  
 [!code-csharp[csProgGuideStrings#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#1)]  
  
 Note that you do not use the [new](../../language-reference/operators/new-operator.md) operator to create a string object except when initializing the string with an array of chars.  
  
 Initialize a string with the <xref:System.String.Empty> constant value to create a new <xref:System.String> object whose string is of zero length. The string literal representation of a zero-length string is "". By initializing strings with the <xref:System.String.Empty> value instead of [null](../../language-reference/keywords/null.md), you can reduce the chances of a <xref:System.NullReferenceException> occurring. Use the static <xref:System.String.IsNullOrEmpty%28System.String%29> method to verify the value of a string before you try to access it.  
  
## Immutability of String Objects  

 String objects are *immutable*: they cannot be changed after they have been created. All of the <xref:System.String> methods and C# operators that appear to modify a string actually return the results in a new string object. In the following example, when the contents of `s1` and `s2` are concatenated to form a single string, the two original strings are unmodified. The `+=` operator creates a new string that contains the combined contents. That new object is assigned to the variable `s1`, and the original object that was assigned to `s1` is released for garbage collection because no other variable holds a reference to it.  
  
 [!code-csharp[csProgGuideStrings#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#2)]  
  
 Because a string "modification" is actually a new string creation, you must use caution when you create references to strings. If you create a reference to a string, and then "modify" the original string, the reference will continue to point to the original object instead of the new object that was created when the string was modified. The following code illustrates this behavior:  
  
 [!code-csharp[csProgGuideStrings#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#25)]  
  
 For more information about how to create new strings that are based on modifications such as search and replace operations on the original string, see [How to modify string contents](../../how-to/modify-string-contents.md).  
  
## Regular and Verbatim String Literals  

 Use regular string literals when you must embed escape characters provided by C#, as shown in the following example:  
  
 [!code-csharp[csProgGuideStrings#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#3)]  
  
 Use verbatim strings for convenience and better readability when the string text contains backslash characters, for example in file paths. Because verbatim strings preserve new line characters as part of the string text, they can be used to initialize multiline strings. Use double quotation marks to embed a quotation mark inside a verbatim string. The following example shows some common uses for verbatim strings:  
  
 [!code-csharp[csProgGuideStrings#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#4)]  
  
## String Escape Sequences  
  
|Escape sequence|Character name|Unicode encoding|  
|---------------------|--------------------|----------------------|  
|\\'|Single quote|0x0027|  
|\\"|Double quote|0x0022|  
|\\\\ |Backslash|0x005C|  
|\0|Null|0x0000|  
|\a|Alert|0x0007|  
|\b|Backspace|0x0008|  
|\f|Form feed|0x000C|  
|\n|New line|0x000A|  
|\r|Carriage return|0x000D|  
|\t|Horizontal tab|0x0009|  
|\v|Vertical tab|0x000B|  
|\u|Unicode escape sequence (UTF-16)|`\uHHHH` (range: 0000 - FFFF; example: `\u00E7` = "ç")|  
|\U|Unicode escape sequence (UTF-32)|`\U00HHHHHH` (range: 000000 - 10FFFF; example: `\U0001F47D` = "&#x1F47D;")|  
|\x|Unicode escape sequence similar to "\u" except with variable length|`\xH[H][H][H]` (range: 0 - FFFF; example: `\x00E7` or `\x0E7` or `\xE7` = "ç")|  
  
> [!WARNING]
> When using the `\x` escape sequence and specifying less than 4 hex digits, if the characters that immediately follow the escape sequence are valid hex digits (i.e. 0-9, A-F, and a-f), they will be interpreted as being part of the escape sequence. For example, `\xA1` produces "&#161;", which is code point U+00A1. However, if the next character is "A" or "a", then the escape sequence will instead be interpreted as being `\xA1A` and produce "&#x0A1A;", which is code point U+0A1A. In such cases, specifying all 4 hex digits (e.g. `\x00A1` ) will prevent any possible misinterpretation.  
  
> [!NOTE]
> At compile time, verbatim strings are converted to ordinary strings with all the same escape sequences. Therefore, if you view a verbatim string in the debugger watch window, you will see the escape characters that were added by the compiler, not the verbatim version from your source code. For example, the verbatim string `@"C:\files.txt"` will appear in the watch window as "C:\\\files.txt".  
  
## Format Strings  

 A format string is a string whose contents are determined dynamically at run time. Format strings are created by embedding *interpolated expressions* or placeholders inside of braces within a string. Everything inside the braces (`{...}`) will be resolved to a value and output as a formatted string at run time. There are two methods to create format strings: string interpolation and composite formatting.

### String Interpolation

Available in C# 6.0 and later, [*interpolated strings*](../../language-reference/tokens/interpolated.md) are identified by the `$` special character and include interpolated expressions in braces. If you are new to string interpolation, see the [String interpolation - C# interactive tutorial](../../tutorials/exploration/interpolated-strings.yml) for a quick overview.

Use string interpolation to improve the readability and maintainability of your code. String interpolation achieves the same results as the `String.Format` method, but improves ease of use and inline clarity.

[!code-csharp[csProgGuideFormatStrings](~/samples/snippets/csharp/programming-guide/strings/Strings_1.cs#StringInterpolation)]

Beginning with C# 10, you can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

### Composite Formatting

The <xref:System.String.Format%2A?displayProperty=nameWithType> utilizes placeholders in braces to create a format string. This example results in similar output to the string interpolation method used above.
  
[!code-csharp[csProgGuideFormatStrings](~/samples/snippets/csharp/programming-guide/strings/Strings_1.cs#StringFormat)]

For more information on formatting .NET types see [Formatting Types in .NET](../../../standard/base-types/formatting-types.md).
  
## Substrings  

 A substring is any sequence of characters that is contained in a string. Use the <xref:System.String.Substring%2A> method to create a new string from a part of the original string. You can search for one or more occurrences of a substring by using the <xref:System.String.IndexOf%2A> method. Use the <xref:System.String.Replace%2A> method to replace all occurrences of a specified substring with a new string. Like the <xref:System.String.Substring%2A> method, <xref:System.String.Replace%2A> actually returns a new string and does not modify the original string. For more information, see [How to search strings](../../how-to/search-strings.md) and [How to modify string contents](../../how-to/modify-string-contents.md).
  
 [!code-csharp[csProgGuideStrings#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#7)]  
  
## Accessing Individual Characters  

 You can use array notation with an index value to acquire read-only access to individual characters, as in the following example:  
  
 [!code-csharp[csProgGuideStrings#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#8)]  
  
 If the <xref:System.String> methods do not provide the functionality that you must have to modify individual characters in a string, you can use a <xref:System.Text.StringBuilder> object to modify the individual chars "in-place", and then create a new string to store the results by using the <xref:System.Text.StringBuilder> methods. In the following example, assume that you must modify the original string in a particular way and then store the results for future use:  
  
 [!code-csharp[csProgGuideStrings#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#27)]  
  
## Null Strings and Empty Strings  

 An empty string is an instance of a <xref:System.String?displayProperty=nameWithType> object that contains zero characters. Empty strings are used often in various programming scenarios to represent a blank text field. You can call methods on empty strings because they are valid <xref:System.String?displayProperty=nameWithType> objects. Empty strings are initialized as follows:  
  
```csharp  
string s = String.Empty;  
```  
  
 By contrast, a null string does not refer to an instance of a <xref:System.String?displayProperty=nameWithType> object and any attempt to call a method on a null string causes a <xref:System.NullReferenceException>. However, you can use null strings in concatenation and comparison operations with other strings. The following examples illustrate some cases in which a reference to a null string does and does not cause an exception to be thrown:  
  
 [!code-csharp[csProgGuideStrings#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#20)]  
  
## Using StringBuilder for Fast String Creation  

 String operations in .NET are highly optimized and in most cases do not significantly impact performance. However, in some scenarios such as tight loops that are executing many hundreds or thousands of times, string operations can affect performance. The <xref:System.Text.StringBuilder> class creates a string buffer that offers better performance if your program performs many string manipulations. The <xref:System.Text.StringBuilder> string also enables you to reassign individual characters, something the built-in string data type does not support. This code, for example, changes the content of a string without creating a new string:  
  
 [!code-csharp[csProgGuideStrings#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#15)]  
  
 In this example, a <xref:System.Text.StringBuilder> object is used to create a string from a set of numeric types:  
  
 [!code-csharp[TestStringBuilder#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/TestStringBuilder.cs)]
  
## Strings, Extension Methods and LINQ  

 Because the <xref:System.String> type implements <xref:System.Collections.Generic.IEnumerable%601>, you can use the extension methods defined in the <xref:System.Linq.Enumerable> class on strings. To avoid visual clutter, these methods are excluded from IntelliSense for the <xref:System.String> type, but they are available nevertheless. You can also use LINQ query expressions on strings. For more information, see [LINQ and Strings](../concepts/linq/linq-and-strings.md).  
  
## Related Topics  
  
|Topic|Description|  
|-----------|-----------------|  
|[How to modify string contents](../../how-to/modify-string-contents.md)|Illustrates techniques to transform strings and modify the contents of strings.|  
|[How to compare strings](../../how-to/compare-strings.md)|Shows how to perform ordinal and culture specific comparisons of strings.|  
|[How to concatenate multiple strings](../../how-to/concatenate-multiple-strings.md)|Demonstrates various ways to join multiple strings into one.|
|[How to parse strings using String.Split](../../how-to/parse-strings-using-split.md)|Contains code examples that illustrate how to use the `String.Split` method to parse strings.|  
|[How to search strings](../../how-to/search-strings.md)|Explains how to use search for specific text or patterns in strings.|  
|[How to determine whether a string represents a numeric value](./how-to-determine-whether-a-string-represents-a-numeric-value.md)|Shows how to safely parse a string to see whether it has a valid numeric value.|  
|[String interpolation](../../language-reference/tokens/interpolated.md)|Describes the string interpolation feature that provides a convenient syntax to format strings.|
|[Basic String Operations](../../../standard/base-types/basic-string-operations.md)|Provides links to topics that use <xref:System.String?displayProperty=nameWithType> and <xref:System.Text.StringBuilder?displayProperty=nameWithType> methods to perform basic string operations.|  
|[Parsing Strings](../../../standard/base-types/parsing-strings.md)|Describes how to convert string representations of .NET base types to instances of the corresponding types.|  
|[Parsing Date and Time Strings in .NET](../../../standard/base-types/parsing-datetime.md)|Shows how to convert a string such as "01/24/2008" to a <xref:System.DateTime?displayProperty=nameWithType> object.|  
|[Comparing Strings](../../../standard/base-types/comparing.md)|Includes information about how to compare strings and provides examples in C# and Visual Basic.|  
|[Using the StringBuilder Class](../../../standard/base-types/stringbuilder.md)|Describes how to create and modify dynamic string objects by using the <xref:System.Text.StringBuilder> class.|  
|[LINQ and Strings](../concepts/linq/linq-and-strings.md)|Provides information about how to perform various string operations by using LINQ queries.|  
|[C# Programming Guide](../index.md)|Provides links to topics that explain programming constructs in C#.|  
