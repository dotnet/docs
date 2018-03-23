---
title: "Strings (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, strings"
  - "strings [C#]"
ms.assetid: 21580405-cb25-4541-89d5-037846a38b07
caps.latest.revision: 41
author: "BillWagner"
ms.author: "wiwagn"
---
# Strings (C# Programming Guide)
A string is an object of type <xref:System.String> whose value is text. Internally, the text is stored as a sequential read-only collection of <xref:System.Char> objects. There is no null-terminating character at the end of a C# string; therefore a C# string can contain any number of embedded null characters ('\0'). The <xref:System.String.Length%2A> property of a string represents the number of `Char` objects it contains, not the number of Unicode characters. To access the individual Unicode code points in a string, use the <xref:System.Globalization.StringInfo> object.  
  
## string vs. System.String  
 In C#, the `string` keyword is an alias for <xref:System.String>. Therefore, `String` and `string` are equivalent, and you can use whichever naming convention you prefer. The `String` class provides many methods for safely creating, manipulating, and comparing strings. In addition, the C# language overloads some operators to simplify common string operations. For more information about the keyword, see [string](../../../csharp/language-reference/keywords/string.md). For more information about the type and its methods, see <xref:System.String>.  
  
## Declaring and Initializing Strings  
 You can declare and initialize strings in various ways, as shown in the following example:  
  
 [!code-csharp[csProgGuideStrings#1](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_1.cs)]  
  
 Note that you do not use the [new](../../../csharp/language-reference/keywords/new-operator.md) operator to create a string object except when initializing the string with an array of chars.  
  
 Initialize a string with the <xref:System.String.Empty> constant value to create a new <xref:System.String> object whose string is of zero length. The string literal representation of a zero-length string is "". By initializing strings with the <xref:System.String.Empty> value instead of [null](../../../csharp/language-reference/keywords/null.md), you can reduce the chances of a <xref:System.NullReferenceException> occurring. Use the static <xref:System.String.IsNullOrEmpty%28System.String%29> method to verify the value of a string before you try to access it.  
  
## Immutability of String Objects  
 String objects are *immutable*: they cannot be changed after they have been created. All of the <xref:System.String> methods and C# operators that appear to modify a string actually return the results in a new string object. In the following example, when the contents of `s1` and `s2` are concatenated to form a single string, the two original strings are unmodified. The `+=` operator creates a new string that contains the combined contents. That new object is assigned to the variable `s1`, and the original object that was assigned to `s1` is released for garbage collection because no other variable holds a reference to it.  
  
 [!code-csharp[csProgGuideStrings#2](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_2.cs)]  
  
 Because a string "modification" is actually a new string creation, you must use caution when you create references to strings. If you create a reference to a string, and then "modify" the original string, the reference will continue to point to the original object instead of the new object that was created when the string was modified. The following code illustrates this behavior:  
  
 [!code-csharp[csProgGuideStrings#25](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_3.cs)]  
  
 For more information about how to create new strings that are based on modifications such as search and replace operations on the original string, see [How to: Modify String Contents](../../how-to/modify-string-contents.md).  
  
## Regular and Verbatim String Literals  
 Use regular string literals when you must embed escape characters provided by C#, as shown in the following example:  
  
 [!code-csharp[csProgGuideStrings#3](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_4.cs)]  
  
 Use verbatim strings for convenience and better readability when the string text contains backslash characters, for example in file paths. Because verbatim strings preserve new line characters as part of the string text, they can be used to initialize multiline strings. Use double quotation marks to embed a quotation mark inside a verbatim string. The following example shows some common uses for verbatim strings:  
  
 [!code-csharp[csProgGuideStrings#4](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_5.cs)]  
  
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
|\U|Unicode escape sequence for surrogate pairs.|\Unnnnnnnn|  
|\u|Unicode escape sequence|\u0041 = "A"|  
|\v|Vertical tab|0x000B|  
|\x|Unicode escape sequence similar to "\u" except with variable length.|\x0041 = "A"|  
  
> [!NOTE]
>  At compile time, verbatim strings are converted to ordinary strings with all the same escape sequences. Therefore, if you view a verbatim string in the debugger watch window, you will see the escape characters that were added by the compiler, not the verbatim version from your source code. For example, the verbatim string @"C:\files.txt" will appear in the watch window as "C:\\\files.txt".  
  
## Format Strings  
 A format string is a string whose contents can be determined dynamically at runtime. You create a format string by using the static <xref:System.String.Format%2A> method and embedding placeholders in braces that will be replaced by other values at runtime. The following example uses a format string to output the result of each iteration of a loop:  
  
 [!code-csharp[csProgGuideStrings#26](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_6.cs)]  
  
 One overload of the <xref:System.Console.WriteLine%2A> method takes a format string as a parameter. Therefore, you can just embed a format string literal without an explicit call to the method. However, if you use the <xref:System.Diagnostics.Trace.WriteLine%2A> method to display debug output in the Visual Studio **Output** window, you have to explicitly call the <xref:System.String.Format%2A> method because <xref:System.Diagnostics.Trace.WriteLine%2A> only accepts a string, not a format string. For more information about format strings, see [Formatting Types](../../../standard/base-types/formatting-types.md).  
  
## Substrings  
 A substring is any sequence of characters that is contained in a string. Use the <xref:System.String.Substring%2A> method to create a new string from a part of the original string. You can search for one or more occurrences of a substring by using the <xref:System.String.IndexOf%2A> method. Use the <xref:System.String.Replace%2A> method to replace all occurrences of a specified substring with a new string. Like the <xref:System.String.Substring%2A> method, <xref:System.String.Replace%2A> actually returns a new string and does not modify the original string. For more information, see [How to: search strings](../../how-to/search-strings.md) and [How to: Modify String Contents](../../how-to/modify-string-contents.md).  
  
 [!code-csharp[csProgGuideStrings#7](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_7.cs)]  
  
## Accessing Individual Characters  
 You can use array notation with an index value to acquire read-only access to individual characters, as in the following example:  
  
 [!code-csharp[csProgGuideStrings#9](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_8.cs)]  
  
 If the <xref:System.String> methods do not provide the functionality that you must have to modify individual characters in a string, you can use a <xref:System.Text.StringBuilder> object to modify the individual chars "in-place", and then create a new string to store the results by using the <xref:System.Text.StringBuilder> methods. In the following example, assume that you must modify the original string in a particular way and then store the results for future use:  
  
 [!code-csharp[csProgGuideStrings#8](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_9.cs)]  
  
## Null Strings and Empty Strings  
 An empty string is an instance of a <xref:System.String?displayProperty=nameWithType> object that contains zero characters. Empty strings are used often in various programming scenarios to represent a blank text field. You can call methods on empty strings because they are valid <xref:System.String?displayProperty=nameWithType> objects. Empty strings are initialized as follows:  
  
```  
string s = String.Empty;  
```  
  
 By contrast, a null string does not refer to an instance of a <xref:System.String?displayProperty=nameWithType> object and any attempt to call a method on a null string causes a <xref:System.NullReferenceException>. However, you can use null strings in concatenation and comparison operations with other strings. The following examples illustrate some cases in which a reference to a null string does and does not cause an exception to be thrown:  
  
 [!code-csharp[csProgGuideStrings#27](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_10.cs)]  
  
## Using StringBuilder for Fast String Creation  
 String operations in .NET are highly optimized and in most cases do not significantly impact performance. However, in some scenarios such as tight loops that are executing many hundreds or thousands of times, string operations can affect performance. The <xref:System.Text.StringBuilder> class creates a string buffer that offers better performance if your program performs many string manipulations. The <xref:System.Text.StringBuilder> string also enables you to reassign individual characters, something the built-in string data type does not support. This code, for example, changes the content of a string without creating a new string:  
  
 [!code-csharp[csProgGuideStrings#20](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_11.cs)]  
  
 In this example, a <xref:System.Text.StringBuilder> object is used to create a string from a set of numeric types:  
  
 [!code-csharp[csProgGuideStrings#15](../../../csharp/programming-guide/strings/codesnippet/CSharp/index_12.cs)]  
  
## Strings, Extension Methods and LINQ  
 Because the <xref:System.String> type implements <xref:System.Collections.Generic.IEnumerable%601>, you can use the extension methods defined in the <xref:System.Linq.Enumerable> class on strings. To avoid visual clutter, these methods are excluded from IntelliSense for the <xref:System.String> type, but they are available nevertheless. You can also use [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expressions on strings. For more information, see [LINQ and Strings](../../../csharp/programming-guide/concepts/linq/linq-and-strings.md).  
  
## Related Topics  
  
|Topic|Description|  
|-----------|-----------------|  
|[How to: Modify String Contents](../../how-to/modify-string-contents.md)|Illustrates techniques to transform strings and modify the contents of strings.|  
|[How to: Compare Strings](../../how-to/compare-strings.md)|Shows how to perform ordinal and culture specific comparisons of strings.|  
|[How to: Parse Strings Using String.Split ](../../how-to/parse-strings-using-split.md)|Contains a code example that illustrates how to use the `String.Split` method to parse strings.|  
|[How to: Search Strings](../../how-to/search-strings.md)|Explains how to use search for specific text or patterns in strings.|  
|[How to: Determine Whether a String Represents a Numeric Value](../../../csharp/programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md)|Shows how to safely parse a string to see whether it has a valid numeric value.|  
|[How to: Convert a String to a DateTime](../../../csharp/programming-guide/strings/how-to-convert-a-string-to-a-datetime.md)|Shows how to convert a string such as "01/24/2008" to a <xref:System.DateTime?displayProperty=nameWithType> object.|  
|[Basic String Operations](../../../../docs/standard/base-types/basic-string-operations.md)|Provides links to topics that use <xref:System.String?displayProperty=nameWithType> and <xref:System.Text.StringBuilder?displayProperty=nameWithType> methods to perform basic string operations.|  
|[Parsing Strings](../../../../docs/standard/base-types/parsing-strings.md)|Describes how to insert characters or empty spaces into a string.|  
|[Comparing Strings](../../../../docs/standard/base-types/comparing.md)|Includes information about how to compare strings and provides examples in C# and Visual Basic.|  
|[Using the StringBuilder Class](../../../standard/base-types/stringbuilder.md)|Describes how to create and modify dynamic string objects by using the <xref:System.Text.StringBuilder> class.|  
|[LINQ and Strings](../../../csharp/programming-guide/concepts/linq/linq-and-strings.md)|Provides information about how to perform various string operations by using LINQ queries.|  
|[C# Programming Guide](../../../csharp/programming-guide/index.md)|Provides links to topics that explain programming constructs in C#.|  
