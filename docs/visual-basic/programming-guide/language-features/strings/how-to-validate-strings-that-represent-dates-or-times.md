---
title: "How to: Validate Strings That Represent Dates or Times (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "strings [Visual Basic], validating"
  - "String data type [Visual Basic], validation"
ms.assetid: ae7d4b29-3436-4032-bdbf-4650eb1c8e19
---
# How to: Validate Strings That Represent Dates or Times (Visual Basic)
The following code example sets a `Boolean` value that indicates whether a string represents a valid date or time.  
  
## Example  
 [!code-vb[VbVbcnRegEx#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnRegEx/VB/Class1.vb#2)]  
  
## Compiling the Code  
 Replace `("01/01/03")` and `"9:30 PM"` with the date and time you want to validate. You can replace the string with another hard-coded string, with a `String` variable, or with a method that returns a string, such as `InputBox`.  
  
## Robust Programming  
 Use this method to validate the string before trying to convert the `String` to a `DateTime` variable. By checking the date or time first, you can avoid generating an exception at run time.  
  
## See also

- <xref:Microsoft.VisualBasic.Information.IsDate%2A>
- <xref:Microsoft.VisualBasic.Interaction.InputBox%2A>
- [Validating Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/validating-strings.md)
