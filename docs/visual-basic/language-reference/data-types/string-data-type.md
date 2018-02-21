---
title: "String Data Type (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.String"
helpviewer_keywords: 
  - "strings [Visual Basic], character"
  - "strings [Visual Basic], fixed-length"
  - "string keyword [Visual Basic]"
  - "fixed-length strings [Visual Basic], string data type"
  - "literals [Visual Basic], string"
  - "text [Visual Basic], String data type"
  - "$ identifier type character"
  - "String data type"
  - "fixed-length strings"
  - "string literals [Visual Basic]"
  - "data types [Visual Basic], assigning"
  - "String literals [Visual Basic]"
  - "identifier type characters [Visual Basic], $"
ms.assetid: 15ac03f5-cabd-42cc-a754-1df3893c25d9
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# String Data Type (Visual Basic)
Holds sequences of unsigned 16-bit (2-byte) code points that range in value from 0 through 65535. Each *code point*, or character code, represents a single Unicode character. A string can contain from 0 to approximately two billion (2 ^ 31) Unicode characters.  
  
## Remarks  
 Use the `String` data type to hold multiple characters without the array management overhead of `Char()`, an array of `Char` elements.  
  
 The default value of `String` is `Nothing` (a null reference). Note that this is not the same as the empty string (value `""`).  
  
## Unicode Characters  
 The first 128 code points (0–127) of Unicode correspond to the letters and symbols on a standard U.S. keyboard. These first 128 code points are the same as those the ASCII character set defines. The second 128 code points (128–255) represent special characters, such as Latin-based alphabet letters, accents, currency symbols, and fractions. Unicode uses the remaining code points (256-65535) for a wide variety of symbols. This includes worldwide textual characters, diacritics, and mathematical and technical symbols.  
  
 You can use methods such as <xref:System.Char.IsDigit%2A> and <xref:System.Char.IsPunctuation%2A> on an individual character in a `String` variable to determine its Unicode classification.  
  
## Format Requirements  
 You must enclose a `String` literal within quotation marks (`" "`). If you must include a quotation mark as one of the characters in the string, you use two contiguous quotation marks (`""`). The following example illustrates this.  
  
```  
Dim j As String = "Joe said ""Hello"" to me."  
Dim h As String = "Hello"  
' The following messages all display the same thing:  
' "Joe said "Hello" to me."  
MsgBox(j)  
MsgBox("Joe said " & """" & h & """" & " to me.")  
MsgBox("Joe said """ & h & """ to me.")  
```  
  
 Note that the contiguous quotation marks that represent a quotation mark in the string are independent of the quotation marks that begin and end the `String` literal.  
  
## String Manipulations  
 Once you assign a string to a `String` variable, that string is *immutable*, which means you cannot change its length or contents. When you alter a string in any way, Visual Basic creates a new string and abandons the previous one. The `String` variable then points to the new string.  
  
 You can manipulate the contents of a `String` variable by using a variety of string functions. The following example illustrates the <xref:Microsoft.VisualBasic.Strings.Left%2A> function  
  
```  
Dim S As String = "Database"  
' The following statement sets S to a new string containing "Data".  
S = Microsoft.VisualBasic.Left(S, 4)  
```  
  
 A string created by another component might be padded with leading or trailing spaces. If you receive such a string, you can use the <xref:Microsoft.VisualBasic.Strings.Trim%2A>, <xref:Microsoft.VisualBasic.Strings.LTrim%2A>, and <xref:Microsoft.VisualBasic.Strings.RTrim%2A> functions to remove these spaces.  
  
 For more information about string manipulations, see [Strings](../../../visual-basic/programming-guide/language-features/strings/index.md).  
  
## Programming Tips  
  
-   **Negative Numbers.** Remember that the characters held by `String` are unsigned and cannot represent negative values. In any case, you should not use `String` to hold numeric values.  
  
-   **Interop Considerations.** If you are interfacing with components not written for the .NET Framework, for example Automation or COM objects, remember that string characters have a different data width (8 bits) in other environments. If you are passing a string argument of 8-bit characters to such a component, declare it as `Byte()`, an array of `Byte` elements, instead of `String` in your new Visual Basic code.  
  
-   **Type Characters.** Appending the identifier type character `$` to any identifier forces it to the `String` data type. `String` has no literal type character. However, the compiler treats literals enclosed in quotation marks (`" "`) as `String`.  
  
-   **Framework Type.** The corresponding type in the .NET Framework is the <xref:System.String?displayProperty=nameWithType> class.  
  
## See Also  
 <xref:System.String?displayProperty=nameWithType>  
 [Data Types](../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Char Data Type](../../../visual-basic/language-reference/data-types/char-data-type.md)  
 [Type Conversion Functions](../../../visual-basic/language-reference/functions/type-conversion-functions.md)  
 [Conversion Summary](../../../visual-basic/language-reference/keywords/conversion-summary.md)  
 [How to: Call a Windows Function that Takes Unsigned Types](../../../visual-basic/programming-guide/com-interop/how-to-call-a-windows-function-that-takes-unsigned-types.md)  
 [Efficient Use of Data Types](../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
