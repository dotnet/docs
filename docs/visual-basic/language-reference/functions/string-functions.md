---
title: "String Functions (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "string functions"
ms.assetid: f1bf9ac2-cbcf-4298-ae51-53182076bdc8
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# String Functions (Visual Basic)
The following table lists the functions that Visual Basic provides to search and manipulate strings.  
  
|.NET Framework method|Description|  
|---------------------------|-----------------|  
|<xref:Microsoft.VisualBasic.Strings.Asc%2A>, <xref:Microsoft.VisualBasic.Strings.AscW%2A>|Returns an `Integer` value representing the character code corresponding to a character.|  
|<xref:Microsoft.VisualBasic.Strings.Chr%2A>, <xref:Microsoft.VisualBasic.Strings.ChrW%2A>|Returns the character associated with the specified character code.|  
|<xref:Microsoft.VisualBasic.Strings.Filter%2A>|Returns a zero-based array containing a subset of a `String` array based on specified filter criteria.|  
|<xref:Microsoft.VisualBasic.Strings.Format%2A>|Returns a string formatted according to instructions contained in a format `String` expression.|  
|<xref:Microsoft.VisualBasic.Strings.FormatCurrency%2A>|Returns an expression formatted as a currency value using the currency symbol defined in the system control panel.|  
|<xref:Microsoft.VisualBasic.Strings.FormatDateTime%2A>|Returns a string expression representing a date/time value.|  
|<xref:Microsoft.VisualBasic.Strings.FormatNumber%2A>|Returns an expression formatted as a number.|  
|<xref:Microsoft.VisualBasic.Strings.FormatPercent%2A>|Returns an expression formatted as a percentage (that is, multiplied by 100) with a trailing % character.|  
|<xref:Microsoft.VisualBasic.Strings.InStr%2A>|Returns an integer specifying the start position of the first occurrence of one string within another.|  
|<xref:Microsoft.VisualBasic.Strings.InStrRev%2A>|Returns the position of the first occurrence of one string within another, starting from the right side of the string.|  
|<xref:Microsoft.VisualBasic.Strings.Join%2A>|Returns a string created by joining a number of substrings contained in an array.|  
|<xref:Microsoft.VisualBasic.Strings.LCase%2A>|Returns a string or character converted to lowercase.|  
|<xref:Microsoft.VisualBasic.Strings.Left%2A>|Returns a string containing a specified number of characters from the left side of a string.|  
|<xref:Microsoft.VisualBasic.Strings.Len%2A>|Returns an integer that contains the number of characters in a string.|  
|<xref:Microsoft.VisualBasic.Strings.LSet%2A>|Returns a left-aligned string containing the specified string adjusted to the specified length.|  
|<xref:Microsoft.VisualBasic.Strings.LTrim%2A>|Returns a string containing a copy of a specified string with no leading spaces.|  
|<xref:Microsoft.VisualBasic.Strings.Mid%2A>|Returns a string containing a specified number of characters from a string.|  
|<xref:Microsoft.VisualBasic.Strings.Replace%2A>|Returns a string in which a specified substring has been replaced with another substring a specified number of times.|  
|<xref:Microsoft.VisualBasic.Strings.Right%2A>|Returns a string containing a specified number of characters from the right side of a string.|  
|<xref:Microsoft.VisualBasic.Strings.RSet%2A>|Returns a right-aligned string containing the specified string adjusted to the specified length.|  
|<xref:Microsoft.VisualBasic.Strings.RTrim%2A>|Returns a string containing a copy of a specified string with no trailing spaces.|  
|<xref:Microsoft.VisualBasic.Strings.Space%2A>|Returns a string consisting of the specified number of spaces.|  
|<xref:Microsoft.VisualBasic.Strings.Split%2A>|Returns a zero-based, one-dimensional array containing a specified number of substrings.|  
|<xref:Microsoft.VisualBasic.Strings.StrComp%2A>|Returns -1, 0, or 1, based on the result of a string comparison.|  
|<xref:Microsoft.VisualBasic.Strings.StrConv%2A>|Returns a string converted as specified.|  
|<xref:Microsoft.VisualBasic.Strings.StrDup%2A>|Returns a string or object consisting of the specified character repeated the specified number of times.|  
|<xref:Microsoft.VisualBasic.Strings.StrReverse%2A>|Returns a string in which the character order of a specified string is reversed.|  
|<xref:Microsoft.VisualBasic.Strings.Trim%2A>|Returns a string containing a copy of a specified string with no leading or trailing spaces.|  
|<xref:Microsoft.VisualBasic.Strings.UCase%2A>|Returns a string or character containing the specified string converted to uppercase.|  
  
 You can use the [Option Compare](../../../visual-basic/language-reference/statements/option-compare-statement.md) statement to set whether strings are compared using a case-insensitive text sort order determined by your system's locale (`Text`) or by the internal binary representations of the characters (`Binary`). The default text comparison method is `Binary`.  
  
## Example  
 This example uses the `UCase` function to return an uppercase version of a string.  
  
 [!code-vb[VbVbalrStrings#31](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_1.vb)]  
  
## Example  
 This example uses the `LTrim` function to strip leading spaces and the `RTrim` function to strip trailing spaces from a string variable. It uses the `Trim` function to strip both types of spaces.  
  
 [!code-vb[VbVbalrStrings#25](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_2.vb)]  
  
## Example  
 This example uses the `Mid` function to return a specified number of characters from a string.  
  
 [!code-vb[VbVbalrStrings#17](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_3.vb)]  
  
## Example  
 This example uses `Len` to return the number of characters in a string.  
  
 [!code-vb[VbVbalrStrings#33](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_4.vb)]  
  
## Example  
 This example uses the `InStr` function to return the position of the first occurrence of one string within another.  
  
 [!code-vb[VbVbalrStrings#8](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_5.vb)]  
  
## Example  
 This example shows various uses of the `Format` function to format values using both `String` formats and user-defined formats. For the date separator (`/`), time separator (`:`), and the AM/PM indicators (`t` and `tt`), the actual formatted output displayed by your system depends on the locale settings the code is using. When times and dates are displayed in the development environment, the short time format and short date format of the code locale are used.  
  
> [!NOTE]
>  For locales that use a 24-hour clock, the AM/PM indicators (`t` and `tt`) display nothing.  
  
 [!code-vb[VbVbalrStrings#27](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-functions_6.vb)]  
  
## See Also  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Visual Basic Runtime Library Members](../../../visual-basic/language-reference/runtime-library-members.md)  
 [String Manipulation Summary](../../../visual-basic/language-reference/keywords/string-manipulation-summary.md)
